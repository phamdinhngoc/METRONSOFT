Imports System.IO
Imports System.Windows.Forms

Public Class ManHinhPhucHoi

#Region "file"
    Private Function TaoFile(ByVal duongdanFile As String, ByVal NoidungFile As String) As String
        Dim file As FileStream
        Dim writer As StreamWriter
        Try
            file = New FileStream(duongdanFile, FileMode.CreateNew)
            writer = New StreamWriter(file)
            writer.WriteLine(NoidungFile)
            writer.Close()
            file.Close()
        Catch EX As Exception
            Return (EX.Message)
        End Try
        Return "1"
    End Function
    Private Function GhiFile(ByVal duongdanFile As String, ByVal NoidungFile As String) As String
        Dim file As FileStream
        Dim writer As StreamWriter
        Try
            file = New FileStream(duongdanFile, FileMode.Open)
            writer = New StreamWriter(file)
            writer.WriteLine(NoidungFile)
            writer.Close()
            file.Close()
        Catch EX As Exception
            Return EX.Message
        End Try
        Return "1"
    End Function
    Private Function DocFile(ByVal duongdanFile As String) As String
        Dim file As FileStream
        Dim reader As StreamReader
        Dim a As String = ""
        Try
            file = New FileStream(duongdanFile, FileMode.Open)
            reader = New StreamReader(file)
            a = reader.ReadLine
            reader.Close()
            file.Close()
        Catch EX As Exception
            Return ""
        End Try
        Return a
    End Function
#End Region
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
#Region " ... ByteUnits "
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
#Region " ... ListLocalFiles "
    Private Sub ListLocalFiles(ByVal ParentPath As String)
        lvwLocalFiles.Items.Clear()
        lvwLocalFiles.BeginUpdate()
        Try
            For Each filePath As String In Directory.GetFiles(ParentPath)
                Select Case (File.GetAttributes(filePath) And FileAttributes.Hidden)
                    Case FileAttributes.Hidden
                    Case Else
                        If Microsoft.VisualBasic.Strings.Right(GetFilenameFromPath(filePath, "\"), 3) = "mdb" Then
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
#End Region
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim result As DialogResult = FolderBrowserDialog1.ShowDialog()
        TxtDuongdan.Text = FolderBrowserDialog1.SelectedPath
        ListLocalFiles(FolderBrowserDialog1.SelectedPath)
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
    Private Function SaoLuu(ByVal tenfile As String) As String
        Try
            File.Copy(DocFile(Application.StartupPath & "\Connfig.dat"), Application.StartupPath & "\SaoLuuDuLieuTuDong\" & tenfile & ".mdb")
        Catch ex As Exception
            Dim number As Integer = 1
            If tenfile.LastIndexOf("_") > 0 Then
                number = Val(Mid(tenfile, tenfile.LastIndexOf("_") + 2)) + 1
                tenfile = (Microsoft.VisualBasic.Strings.Left(tenfile, tenfile.LastIndexOf("_")) & "_" & number)
            Else
                tenfile = tenfile & "_" & number
            End If
            SaoLuu(tenfile)
        End Try
        Return tenfile
    End Function
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim daoNK As New NhatkyDao
        Dim dtoNK As New Nhatkydto
        Try
            If AbstractDao.Ket_noi.State = ConnectionState.Open Then AbstractDao.Ket_noi.Close()
            Ketnoi.Close()
            dtoNK.User = TenNguoiDangNhap
            dtoNK.Ngay = Date.Now.Date
            dtoNK.Gio = Date.Now
            dtoNK.Tacvu = "Phục hồi file  " & TxtDuongdan.Text & "\" & TextBox1.Text
            Directory.CreateDirectory(Application.StartupPath & "\SaoLuuDuLieuTuDong")
            Dim tenfile As String = SaoLuu(Date.Now.Day & "-" & Date.Now.Month & "-" & Date.Now.Year)
            MsgBox("Vì an toàn dử liệu file CC.mdb đươc SAO LƯU vào thư mục " & vbNewLine & Application.StartupPath & "\SaoLuuDuLieuTuDong\" & tenfile & ".mdb", , "Thông Báo")
        Catch ex As Exception
        End Try
        Try
            Dim duongdanCsdl As String = DocFile(Application.StartupPath & "\Connfig.dat")
            If Microsoft.VisualBasic.Strings.Right(TextBox1.Text, 3) <> "mdb" Then
                MsgBox("Đây không phải là file cơ sở dử liệu")
                Exit Sub
            End If
            File.Delete(duongdanCsdl)
            File.Copy(TxtDuongdan.Text & "\" & TextBox1.Text, duongdanCsdl)
            Ketnoi.Open()
            Me.Close()
            MsgBox("Yêu cầu bạn KHỞI ĐỘNG LẠI ứng dụng để không xảy ra lổi" & vbNewLine & "TẮT sau đó BẬT lại ứng dụng", MsgBoxStyle.Critical, "Thông Báo")
        Catch ex As Exception
            MsgBox(" File này đang được sử dụng " & vbNewLine & " Không thể phục hồi", MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End Try
        daoNK.Them(dtoNK, False)
    End Sub
    Private Sub lvwLocalFiles_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lvwLocalFiles.ItemSelectionChanged
        If e.IsSelected Then
            TextBox1.Text = lvwLocalFiles.SelectedItems(0).SubItems.Item(0).Text
        End If
    End Sub

    Private Sub ManHinhPhucHoi_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        ManHinhChinh.CửaSổHoạtĐộngToolStripMenuItem.DropDownItems.Remove(ManHinhChinh.CửaSổHoạtĐộngToolStripMenuItem.DropDownItems(Me.Name))
    End Sub

    Private Sub ManHinhPhucHoi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ManHinhChinh.CửaSổHoạtĐộngToolStripMenuItem.DropDownItems.Add("Giao Diện Phục Hồi Dử Liệu").Name = Me.Name
        Dim busQ As New QuyenBus(DTOKetnoi, False)
        Dim ma As Integer = busQ.MaQuyen(QuyenNguoiDangNhap)
        cacNutNhan(Me, ma, Me.Name)
        Directory.CreateDirectory(Application.StartupPath & "\ThuMucSaoLuu")
        TxtDuongdan.Text = Application.StartupPath & "\ThuMucSaoLuu"
        FolderBrowserDialog1.SelectedPath = TxtDuongdan.Text
    End Sub
    Private Sub TxtDuongdan_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDuongdan.TextChanged
        Try
            ListLocalFiles(TxtDuongdan.Text)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub lvwLocalFiles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwLocalFiles.SelectedIndexChanged

    End Sub
End Class