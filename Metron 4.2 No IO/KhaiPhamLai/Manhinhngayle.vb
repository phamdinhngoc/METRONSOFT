Public Class Manhinhngayle
    Dim bus As New NgayleBus(DTOKetnoi, False)
    Private Sub Manhinhngayle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = bus.LayBangTable
        Dim dto As Ngayledto = bus.LayBangDTo(Date.Now.Date)
        If dto.Ngay = #1/1/1900# Then
            ToolStripButton2.Enabled = False
        Else
            ToolStripButton2.Enabled = True
        End If
        TextBox1.Text = dto.ChuThich
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim dto As New Ngayledto
        dto.Ngay = MonthCalendar1.SelectionEnd
        dto.ChuThich = TextBox1.Text
        Dim dtotest As Ngayledto = bus.LayBangDTo(dto.Ngay)
        If dtotest.Ngay = #1/1/1900# Then
            bus.Them(dto)
        Else
            bus.sua(dto)
        End If
        DataGridView1.DataSource = bus.LayBangTable
        MonthCalendar1.SetDate(DataGridView1.SelectedRows(0).Cells(0).Value)
    End Sub
    Private Sub MonthCalendar1_DateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles MonthCalendar1.DateChanged
        Dim dto As Ngayledto = bus.LayBangDTo(MonthCalendar1.SelectionEnd)
        TextBox1.Text = dto.ChuThich
        If dto.Ngay = #1/1/1900# Then
            ToolStripButton2.Enabled = False
        Else
            ToolStripButton2.Enabled = True
        End If
        TextBox1.Focus()
    End Sub
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        If MsgBox("Bạn có muốn xóa không? ", MsgBoxStyle.OkCancel, "Thông báo") = MsgBoxResult.Cancel Then Exit Sub
        bus.Xoa(MonthCalendar1.SelectionEnd)
        DataGridView1.DataSource = bus.LayBangTable
        MonthCalendar1.SetDate(DataGridView1.SelectedRows(0).Cells(0).Value)
    End Sub
    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Me.Close()
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If DataGridView1.Rows.Count <= 0 Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        MonthCalendar1.SetDate(DataGridView1.Rows(e.RowIndex).Cells(0).Value)
    End Sub
End Class