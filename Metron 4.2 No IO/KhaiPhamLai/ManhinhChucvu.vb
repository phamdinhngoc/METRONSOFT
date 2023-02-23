Public Class ManhinhChucvu
    Dim BUS As New chucvuBus(DTOKetnoi, False)
    Dim busnv As New nhanvienBus(DTOKetnoi, False)
    Private Sub ManhinhChucvu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = BUS.LayBangTable
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim STR As String = InputBox("Nhập tên chức vụ mới vào đây", "Thông báo")
        If STR = "" Then Exit Sub
        Dim dto As New chucvudto
        dto.Chucvu = STR
        Try
            BUS.Them(dto)
        Catch ex As Exception
            MsgBox(ex.Message, , "Thông báo")
        End Try
        MsgBox("Thêm chức vụ thành công", , "Thông báo")
        DataGridView1.DataSource = BUS.LayBangTable
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        If MsgBox("Bạn muốn xóa chức vụ này không ?", MsgBoxStyle.OkCancel, "Thông báo") = MsgBoxResult.Ok Then
            If busnv.LayBangTabletheochucvu(DataGridView1.SelectedRows(0).Cells(0).Value).Rows.Count > 0 Then
                MsgBox("Chức vụ này đã có người sử dụng", , "Thông báo")
                Exit Sub
            End If
            Try
                BUS.Xoa(DataGridView1.SelectedRows(0).Cells(0).Value)
                MsgBox("Xóa chức vụ thành công", , "Thông báo")
            Catch ex As Exception
                MsgBox(ex.Message, , "Thông báo")
            End Try
            DataGridView1.DataSource = BUS.LayBangTable
        End If
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Dim STR As String = InputBox("Sửa tên chức vụ ", "Thông báo", DataGridView1.SelectedRows(0).Cells(1).Value)
        If STR = "" Then Exit Sub
        Dim dto As New chucvudto
        dto.CVID = DataGridView1.SelectedRows(0).Cells(0).Value
        dto.Chucvu = STR
        Try
            BUS.sua(dto)
            MsgBox("Sửa chức vụ thành công", , "Thông báo")
        Catch ex As Exception
            MsgBox(ex.Message, , "Thông báo")
        End Try
        DataGridView1.DataSource = BUS.LayBangTable
    End Sub
End Class