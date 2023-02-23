Public Class ManHinhLydo
    Dim bus As New lydoBus(DTOKetnoi, False)
    Private Sub ManHinhLydo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            DataGridView1.DataSource = bus.LayBangTable
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub ThêmToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ThêmToolStripMenuItem.Click
        ManHinhThemSuaLydo.IDLD = 0
        ManHinhThemSuaLydo.TextBox1.Text = ""
        ManHinhThemSuaLydo.TextBox2.Text = 0
        ManHinhThemSuaLydo.TextBox3.Text = 0
        ManHinhThemSuaLydo.ShowDialog()
        DataGridView1.DataSource = bus.LayBangTable
    End Sub
    Private Sub SửaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SửaToolStripMenuItem.Click
        Try
            ManHinhThemSuaLydo.IDLD = DataGridView1.SelectedRows(0).Cells("IDLD").Value
            If Not IsDBNull(DataGridView1.SelectedRows(0).Cells("Lydo").Value) Then
                ManHinhThemSuaLydo.TextBox1.Text = DataGridView1.SelectedRows(0).Cells("Lydo").Value
            End If
            If IsNumeric(DataGridView1.SelectedRows(0).Cells("NgayQD").Value) Then
                ManHinhThemSuaLydo.TextBox2.Text = DataGridView1.SelectedRows(0).Cells("NgayQD").Value
            End If
            If IsNumeric(DataGridView1.SelectedRows(0).Cells("SoCong").Value) Then
                ManHinhThemSuaLydo.TextBox3.Text = DataGridView1.SelectedRows(0).Cells("SoCong").Value
            End If
            ManHinhThemSuaLydo.ShowDialog()
            DataGridView1.DataSource = bus.LayBangTable
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub XóaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XóaToolStripMenuItem.Click
        Try
            If MsgBox("Bạn có muốn xóa lý do đang chọn không ? ", MsgBoxStyle.OkCancel, "Thộng báo") = MsgBoxResult.Cancel Then Exit Sub
            Dim row As New DataGridViewRow
            For Each row In DataGridView1.SelectedRows
                bus.Xoa(row.Cells("IDLD").Value)
            Next
            DataGridView1.DataSource = bus.LayBangTable
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class