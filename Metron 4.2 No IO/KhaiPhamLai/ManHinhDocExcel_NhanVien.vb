Imports System.IO
Public Class ManHinhDocExcel_NhanVien
    Dim bus As New nhanvienBus(DTOKetnoi, False)
    Dim dto As New nhanviendto
    Public Trangthai As String = ""
    Dim busChucvu As New chucvuBus(DTOKetnoi, False)
    Dim dtochucvu As New chucvudto
    Dim busdonvi As New donviBus(DTOKetnoi, False)
    Dim dtodonvi As New donvidto
#Region "Load file "

#Region " ListLocalFiles "
    Private Sub ListLocalFiles(ByVal ParentPath As String)
        lvwLocalFiles.Items.Clear()
        lvwLocalFiles.BeginUpdate()
        Try
            For Each filePath As String In Directory.GetFiles(ParentPath)
                Select Case (File.GetAttributes(filePath) And FileAttributes.Hidden)
                    Case FileAttributes.Hidden
                    Case Else
                        If Microsoft.VisualBasic.Strings.Right(GetFilenameFromPath(filePath, "\"), 3) = "xls" Then
                            Dim lvi As New ListViewItem
                            lvi.SubItems(0).Text = GetFilenameFromPath(filePath, "\")
                            lvi.SubItems.Add(ByteUnits(CType(New FileInfo(filePath).Length, Single)))
                            lvi.SubItems.Add(File.GetLastAccessTime(filePath))
                            lvi.Tag = filePath
                            lvwLocalFiles.Items.Add(lvi)
                            lvi = Nothing
                        End If
                End Select
            Next
        Catch ex As Exception
        End Try
        lvwLocalFiles.EndUpdate()
    End Sub
    Private Function GetFilenameFromPath(ByVal FilePath As String, _
                                       ByVal PathCharacter As String) As String
        If FilePath = Nothing Then
            Return ""
        End If
        If FilePath.Length <= 0 Then
            Return ""
        End If
        Dim pathElements() As String = FilePath.Split(CType(PathCharacter, Char))
        If pathElements.GetUpperBound(0) > 0 Then
            Select Case pathElements(pathElements.GetUpperBound(0)).Length
                Case 0
                    Return ""
                Case Else
                    Return pathElements(pathElements.GetUpperBound(0))
            End Select
        Else
            Return ""
        End If
    End Function
    Public Function ByteUnits(ByVal NumberOfBytes As Single, _
                              Optional ByVal DecimalPlaces As Integer = 1) As String
        Dim units As String = " Bytes"
        Dim oneK As Single = 1024
        If NumberOfBytes > oneK Then
            NumberOfBytes = NumberOfBytes / oneK
            units = " KB"
            If NumberOfBytes > oneK Then
                NumberOfBytes = NumberOfBytes / oneK
                units = " MB"
                If NumberOfBytes > oneK Then
                    NumberOfBytes = NumberOfBytes / oneK
                    units = " GB"
                End If
            End If
            Return FormatNumber(NumberOfBytes, DecimalPlaces) & units
        Else
            Return NumberOfBytes.ToString & units
        End If

    End Function
#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim result As DialogResult = FolderBrowserDialog1.ShowDialog()
            If FolderBrowserDialog1.SelectedPath <> "" And Not IsDBNull(FolderBrowserDialog1.SelectedPath) Then TxtDuongdan.Text = FolderBrowserDialog1.SelectedPath
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TxtDuongdan_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDuongdan.TextChanged
        Try
            ListLocalFiles(TxtDuongdan.Text)
        Catch ex As Exception
        End Try
    End Sub
#End Region
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If MsgBox("Bạn muốn thoát phải không ?", MsgBoxStyle.OkCancel, "Thông báo") = MsgBoxResult.Ok Then
            Me.Close()
        End If
    End Sub
    Private Sub lvwLocalFiles_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lvwLocalFiles.ItemSelectionChanged
        If e.IsSelected Then
            TextBox2.Text = lvwLocalFiles.SelectedItems(0).SubItems.Item(0).Text
        End If
    End Sub
    Private Sub ManHinhDocExcel_NhanVien_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TxtDuongdan.Text = Application.StartupPath
        ToolStripProgressBar1.Value = 0
        ToolStripProgressBar1.Maximum = 100
        Donvi.ValueMember = "MaDV"
        Donvi.DisplayMember = "TenDV"
        Donvi.DataSource = busdonvi.LayBangTable
        Chucvu.ValueMember = "CVid"
        Chucvu.DisplayMember = "chucvu"
        Chucvu.DataSource = busChucvu.LayBangTable
    End Sub
    Public Sub DocHH(Optional ByVal index As Integer = 1)
        Try
            Dim str, STR2
            Dim EXC As New Microsoft.Office.Interop.Excel.Application
            Dim Shet As Microsoft.Office.Interop.Excel.Worksheet
            Dim Wbook As Microsoft.Office.Interop.Excel.Workbook
            Dim HANG As Integer
            Dim cot As Integer
            Try
                Wbook = EXC.Workbooks.Open(TxtDuongdan.Text & "\" & TextBox2.Text)
            Catch ex As Exception
                Exit Sub
            End Try
            Shet = Wbook.Worksheets(index)
            Shet.Activate()
            str = Shet.Cells(1, 1).value()
            cot = 1
            Me.DataGridView1.Rows.Clear()
            Me.DataGridView1.Columns.Clear()
            Me.DataGridView1.Columns.Add("CKhong", "Không")
            While str <> ""
                str = Shet.Cells(1, cot).value()
                Me.DataGridView1.Columns.Add("Cot " & cot, str)
                cot += 1
            End While
            STR2 = CStr(Shet.Cells(2, 1).value())
            HANG = 2
            While STR2 <> ""
                Me.DataGridView1.Rows.Add(STR2)
                Try
                    Me.DataGridView1.Item(0, HANG - 2).Value = 0
                    For I As Integer = 1 To cot - 1
                        Me.DataGridView1.Item(I, HANG - 2).Value = Shet.Cells(HANG, I).value()
                    Next
                Catch ex As Exception
                End Try
                HANG += 1
                STR2 = CStr(Shet.Cells(HANG, 1).value())
                Try
                    ToolStripProgressBar1.Value += 1
                Catch ex As Exception
                    ToolStripProgressBar1.Maximum *= 3
                End Try
            End While
            Wbook.Close()
            EXC.Quit()
            'DocOP(CMND)
            ToolStripProgressBar1.Maximum = 100
            ToolStripProgressBar1.Value = ToolStripProgressBar1.Maximum
        Catch ex As Exception
            MsgBox("Thông báo lổi" & vbNewLine & "Bạn chưa chọn File excel", , "Thông báo")
        End Try
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If lvwLocalFiles.Items.Count <= 0 Or TextBox2.Text = "" Then
            MsgBox("Thông báo lổi" & vbNewLine & "Bạn chưa chọn File excel", , "Thông báo")
            Exit Sub
        End If
        StatusStrip1.Visible = True
        DocHH()
        Try
            Dim ctr As Control
            For Each ctr In Panel3.Controls
                If ctr.Tag = "1" Then
                    Dim com As ComboBox = ctr
                    com.Items.Clear()
                    For i As Integer = 0 To DataGridView1.ColumnCount - 1
                        com.Items.Add(DataGridView1.Columns(i).HeaderText)
                    Next
                    com.SelectedIndex = 0
                End If
            Next
        Catch ex As Exception
        End Try
        StatusStrip1.Visible = False
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim thongbao As String = ""
        Try
            StatusStrip1.Visible = True
            ToolStripProgressBar1.Maximum = DataGridView1.Rows.Count
            Dim loi As String = ""
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                Dim dtoNhanvien As New nhanviendto
                Dim ctr As New Control
                For Each ctr In Panel3.Controls
                    If TypeOf ctr Is ComboBox Then
                        If ctr.Tag = "1" Then
                            Dim com As ComboBox = ctr
                            If com.SelectedIndex <> 0 Then
                                loi = dtoNhanvien.HoTro(ctr.Name, DataGridView1.Rows(i).Cells("Cot " & com.SelectedIndex).Value)
                            ElseIf com.Name = "MaNV" And com.SelectedIndex = 0 Then
                                loi = "Mã chấm công phải có dử liệu"
                                ErrorProvider1.SetError(ctr, "Mã chấm công phải có dử liệu")
                            End If
                        Else
                            Dim com As ComboBox = ctr
                            loi = dtoNhanvien.HoTro(ctr.Name, com.SelectedValue)
                        End If
                        If loi <> "" And Not CheckBox1.Checked Then
                            ErrorProvider1.SetError(ctr, loi)
                        Else
                            ErrorProvider1.SetError(ctr, "")
                        End If
                    End If
                Next
                If loi <> "" And Not CheckBox1.Checked Then
                    Exit Sub
                End If
                ToolStripProgressBar1.Value = i + 1
                If loi = "" Then
                    Try
                        bus.Them(dtoNhanvien)
                    Catch ex As Exception
                        thongbao = thongbao & "dong " & i & vbNewLine
                    End Try
                End If
            Next
            If thongbao <> "" Then
                MsgBox(" Danh sách dòng bị lổi không thêm được: " & vbNewLine & thongbao)
            Else
                MsgBox(" Chuyển dử liệu thành công ")
            End If
            StatusStrip1.Visible = False
        Catch ex As Exception
        End Try
    End Sub
End Class