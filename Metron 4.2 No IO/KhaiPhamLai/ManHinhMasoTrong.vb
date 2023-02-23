Public Class ManHinhMasoTrong
    Dim dto As New nhanviendto
    Dim bus As New nhanvienBus(DTOKetnoi, False)
    Public Ma As Integer = 0

    Private Sub ManHinhMasoTrong_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        ManHinhChinh.CửaSổHoạtĐộngToolStripMenuItem.DropDownItems.Remove(ManHinhChinh.CửaSổHoạtĐộngToolStripMenuItem.DropDownItems(Me.Name))
    End Sub
    Private Sub ManHinhMasoTrong_Load(ByVal seder As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ManHinhChinh.CửaSổHoạtĐộngToolStripMenuItem.DropDownItems.Add("Giao Diện Hổ Trợ Tìm Mã Nhân Viên Không Sử Dụng").Name = Me.Name
        ListBox1.Items.Clear()
        Dim a As DataTable = bus.LayBangTable
        Dim max As Integer = bus.mathem
        If max - a.Rows.Count <= 0 Then Exit Sub
        For i As Integer = 0 To a.Rows.Count - 2
            If Val(a.Rows(i + 1)("manv")) - Val(a.Rows(i)("manv")) > 1 Then
                For j As Integer = Val(a.Rows(i)("manv")) + 1 To Val(a.Rows(i + 1)("manv")) - 1
                    ListBox1.Items.Add(j)
                Next
            End If
        Next
        ListBox1.Focus()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
        Ma = 0
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Ma = ListBox1.SelectedItem
        Me.Close()
    End Sub
End Class