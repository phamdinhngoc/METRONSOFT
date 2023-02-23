Public Class ManHinhXemNguoidung
    Dim bus As New NguoidungBus(DTOKetnoi, False)
    Dim dto As New Nguoidungdto

    Private Sub ManHinhXemNguoidung_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        ManHinhChinh.CửaSổHoạtĐộngToolStripMenuItem.DropDownItems.Remove(ManHinhChinh.CửaSổHoạtĐộngToolStripMenuItem.DropDownItems(Me.Name))
    End Sub
    Private Sub ManHinhXemNguoidung_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ManHinhChinh.CửaSổHoạtĐộngToolStripMenuItem.DropDownItems.Add("Giao Diện Tất Cả Người Dùng").Name = Me.Name
        Dim busQ As New QuyenBus(DTOKetnoi, False)
        Dim ma As Integer = busQ.MaQuyen(QuyenNguoiDangNhap)
        cacNutNhan(Me, ma, Me.Name)
        DataGridView1.DataSource = bus.LayBangTable
    End Sub

    Private Sub ThêmToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ThêmToolStripMenuItem.Click
        ManHinhDangKy.ShowDialog()
        DataGridView1.DataSource = bus.LayBangTable
    End Sub
    Private Sub XoáNgườiDùngToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XoáNgườiDùngToolStripMenuItem.Click
        Try
            If DataGridView1.RowCount <= 0 Then Exit Sub
            If MsgBox("Bạn có muốn xoá người dùng " & DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value & " này hay không?", MsgBoxStyle.OkCancel, "Thông báo") = MsgBoxResult.Cancel Then Exit Sub
            If QuyenNguoiDangNhap <> ChuoiTQL Then
                MsgBox("Bạn không có quyền xóa người dùng này ,chỉ có tổng quản lý mới có quyền này", , "Thông báo")
                Exit Sub
            End If
            If DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value = TenNguoiDangNhap Then
                MsgBox("Bạn không thể xoá tài khoản của chính bạn", , "Thông báo")
                Exit Sub
            End If
            bus.Xoa(DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value)
            DataGridView1.DataSource = bus.LayBangTable
        Catch ex As Exception
        End Try
    End Sub

    Private Sub MậtKhẩuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MậtKhẩuToolStripMenuItem.Click
        MậtKhẩuToolStripMenuItem.Checked = Not MậtKhẩuToolStripMenuItem.Checked
        DataGridView1.Columns(1).Visible = Not DataGridView1.Columns(1).Visible
    End Sub

    Private Sub QuyềnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuyềnToolStripMenuItem.Click
        QuyềnToolStripMenuItem.Checked = Not QuyềnToolStripMenuItem.Checked
        DataGridView1.Columns(2).Visible = Not DataGridView1.Columns(2).Visible
    End Sub

    Private Sub CâuHỏi1ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CâuHỏi1ToolStripMenuItem.Click
        CâuHỏi1ToolStripMenuItem.Checked = Not CâuHỏi1ToolStripMenuItem.Checked
        DataGridView1.Columns(3).Visible = Not DataGridView1.Columns(3).Visible
    End Sub

    Private Sub TrảLời1ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrảLời1ToolStripMenuItem.Click
        TrảLời1ToolStripMenuItem.Checked = Not TrảLời1ToolStripMenuItem.Checked
        DataGridView1.Columns(4).Visible = Not DataGridView1.Columns(4).Visible
    End Sub

    Private Sub CâuHỏi2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CâuHỏi2ToolStripMenuItem.Click
        CâuHỏi2ToolStripMenuItem.Checked = Not CâuHỏi2ToolStripMenuItem.Checked
        DataGridView1.Columns(5).Visible = Not DataGridView1.Columns(5).Visible
    End Sub

    Private Sub TrảLời2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrảLời2ToolStripMenuItem.Click
        TrảLời2ToolStripMenuItem.Checked = Not TrảLời2ToolStripMenuItem.Checked
        DataGridView1.Columns(6).Visible = Not DataGridView1.Columns(6).Visible
    End Sub
End Class