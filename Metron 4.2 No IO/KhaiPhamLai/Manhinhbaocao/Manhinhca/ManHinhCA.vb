Public Class ManHinhCA

    Dim bus As New caBus(DTOKetnoi, False)
    Dim dto As New cadto
    Dim buscatd As New caTDBus(DTOKetnoi, False)
    Dim buslichclass As New LichclassBus(DTOKetnoi, False)
    Dim dtolichclass As New Lichclassdto
    Dim buslichtam As New lichtamBus(DTOKetnoi, False)
#Region "Ham ho tro"
    Private Sub showData()
        If DataGridView1.CurrentRow.Index < 0 Then Exit Sub
        For i As Integer = 1 To 13
            Dim ctr As Control = duyetcontrols(i)
            If ctr.Name = "0" Then Exit Sub
            If TypeOf ctr Is DateTimePicker Then
                Dim dtp As DateTimePicker = ctr
                dtp.Value = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(i).Value
            End If
            If TypeOf ctr Is TextBox Then
                Dim txt As TextBox = ctr
                txt.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(i).Value
            End If
            If TypeOf ctr Is ComboBox Then
                Dim txt As ComboBox = ctr
                txt.SelectedValue = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(i).Value
            End If
            If TypeOf ctr Is Button Then
                Dim But As Button = ctr
                But.BackColor = Color.FromArgb(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(i).Value)
            End If
        Next
    End Sub
    Private Function duyetcontrols(ByVal tag As String) As Control
        Dim ctr As New Control
        For Each ctr In Me.Controls
            If ctr.Tag = tag Then
                Return ctr
            End If
        Next
        ctr.Name = "0"
        Return ctr
    End Function
    Private Function SOPHUT(ByVal DATE1 As Date, ByVal DATE2 As Date) As Integer
        If DateDiff(DateInterval.Hour, DATE1, DATE2) = 0 Then Return DateDiff(DateInterval.Minute, DATE1, DATE2)
        If DATE2.Hour - DATE1.Hour > 0 Then
            Return DateDiff(DateInterval.Minute, DATE1, DATE2)
        Else
            Dim NGAY1 As Integer = DateDiff(DateInterval.Minute, DATE1, DateSerial(DATE1.Year, DATE1.Month, DATE1.Day + 1))
            Dim NGAY2 As Integer = DateDiff(DateInterval.Minute, DateSerial(DATE1.Year, DATE1.Month, DATE1.Day), DATE2)
            Return NGAY1 + NGAY2
        End If
    End Function
#End Region
    Private Sub ManHinhCA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = bus.LayBangTable
        If bus.LayBangTable.Rows.Count <= 0 Then CaiDatNhanCalamviec.ShowDialog()
        DataGridView1.DataSource = bus.LayBangTable
        ComboBox1.DisplayMember = "tenca"
        ComboBox1.ValueMember = "id"
        ComboBox1.DataSource = bus.LayBangTable
    End Sub
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        For I As Integer = 1 To 13
            Dim ctr As Control = duyetcontrols(I)
            If ctr.Name = "0" Then Exit For
            ctr.Enabled = True
            If TypeOf ctr Is DateTimePicker Then
                Dim a As DateTimePicker = ctr
                a.Value = #1/1/1900#
            ElseIf TypeOf ctr Is TextBox Then
                ctr.Text = 0
            ElseIf TypeOf ctr Is ComboBox Then
                ctr.Text = 0
            Else
                ctr.BackColor = Color.FromArgb(0)
            End If
        Next

        ToolStripButton1.Enabled = False
        ToolStripButton2.Enabled = False
        ToolStripButton3.Enabled = False
        ToolStripButton4.Enabled = True
        TextBox1.Focus()
        ToolStripButton4.Tag = "THEM"
    End Sub
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        For I As Integer = 1 To 13
            Dim ctr As Control = duyetcontrols(I)
            If ctr.Name = "0" Then Exit For
            ctr.Enabled = True
        Next
        ToolStripButton1.Enabled = False
        ToolStripButton2.Enabled = False
        ToolStripButton3.Enabled = False
        ToolStripButton4.Enabled = True
        TextBox1.Focus()
        ToolStripButton4.Tag = "SUA"



    End Sub
    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        Dim LoiChung As String = ""
        For i As Integer = 1 To 13
            Dim ctr As Control = duyetcontrols(i)
            'If ctr.Tag = "11" And ctr.Text = "0" Then
            '    ctr.Text = SOPHUT(dto.batdau, dto.kethuc)
            'End If
            If TypeOf ctr Is DateTimePicker Then
                Dim a As DateTimePicker = ctr
                Dim loi As String = dto.HoTro(i, a.Value.ToString)
                ErrorProvider1.SetError(a, loi)
                LoiChung = LoiChung & loi
                a.Focus()
            ElseIf TypeOf ctr Is TextBox Then
                Dim loi As String = dto.HoTro(i, ctr.Text)
                ErrorProvider1.SetError(ctr, loi)
                LoiChung = LoiChung & loi
                ctr.Focus()
            ElseIf TypeOf ctr Is ComboBox Then
                Dim cb As ComboBox = ctr
                dto.Cacon = cb.SelectedValue
            End If
        Next
        dto.mau = Button1.BackColor.ToArgb
        If LoiChung <> "" Then Exit Sub
        If ToolStripButton4.Tag = "THEM" Then
            bus.Them(dto)
        ElseIf ToolStripButton4.Tag = "SUA" Then
            dto.ID = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value
            bus.sua(dto)
        End If
        For I As Integer = 1 To 13
            Dim ctr As Control = duyetcontrols(I)
            If ctr.Name = "0" Then Exit For
            ctr.Enabled = False
        Next
        ToolStripButton1.Enabled = True
        ToolStripButton2.Enabled = True
        ToolStripButton3.Enabled = True
        ToolStripButton4.Enabled = False
        DataGridView1.DataSource = bus.LayBangTable
        ComboBox1.DisplayMember = "tenca"
        ComboBox1.ValueMember = "id"
        ComboBox1.DataSource = bus.LayBangTable

    End Sub
    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        If MsgBox("Bạn có muốn xóa ca " & DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(1).Value & " không ?", MsgBoxStyle.OkCancel, "Thông báo") = MsgBoxResult.Ok Then
            If buslichclass.laybangTableTheoCaid(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value).Rows.Count > 0 Then
                MsgBox("Không thể xóa ca,Ca đã được sử dụng trong lịch chính thức .", , "Thông Báo")
                Exit Sub
            End If
            If buslichtam.LayBangTableTheoCaid(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value).Rows.Count > 0 Then
                MsgBox("Không thể xóa ca,Ca đã được sử dụng trong lịch tạm .", , "Thông Báo")
                Exit Sub
            End If
            If buscatd.LayBangTableTheoCaId(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value).Rows.Count > 0 Then
                MsgBox("Không thể xóa ca,Ca đã được sử dụng trong Ca tự động .", , "Thông Báo")
                Exit Sub
            End If
            bus.Xoa(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value)
            DataGridView1.DataSource = bus.LayBangTable
            showData()
            ComboBox1.DisplayMember = "tenca"
            ComboBox1.ValueMember = "id"
            ComboBox1.DataSource = bus.LayBangTable

        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ColorDialog1.ShowDialog()
        Button1.BackColor = ColorDialog1.Color
    End Sub
    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        CaiDatNhanCalamviec.ShowDialog()
        DataGridView1.DataSource = bus.LayBangTable
    End Sub
    Private Sub DataGridView1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.SelectionChanged
        showData()
    End Sub
End Class