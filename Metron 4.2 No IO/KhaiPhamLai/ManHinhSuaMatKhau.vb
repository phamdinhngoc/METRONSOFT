Public Class ManHinhSuaMatKhau
    Dim bus As New NguoidungBus(DTOKetnoi, False)
    Dim dto As New Nguoidungdto
    Private Sub ManHinhSuaMatKhau_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        ManHinhChinh.CửaSổHoạtĐộngToolStripMenuItem.DropDownItems.Remove(ManHinhChinh.CửaSổHoạtĐộngToolStripMenuItem.DropDownItems(Me.Name))
    End Sub
    Private Sub ManHinhSuaMatKhau_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim busQ As New QuyenBus(DTOKetnoi, False)
        Dim ma As Integer = busQ.MaQuyen(QuyenNguoiDangNhap)
        cacNutNhan(Me, ma, Me.Name)
        ManHinhChinh.CửaSổHoạtĐộngToolStripMenuItem.DropDownItems.Add("Giao Diện Sửa Mật Khẩu").Name = Me.Name
        txtuserID.Text = TenNguoiDangNhap
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Public Function kiemtra(ByVal tennguoidung As String, ByVal matkhau As String) As Boolean
        Dim sql As String = "select * from nguoidung" & _
          " WHERE userID='" & tennguoidung & "' AND pass='" & matkhau & "' "
        Dim Data As DataTable = bus.LayBangTableSQL(sql)
        If Data.Rows.Count > 0 Then Return True
        Return False
    End Function
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If kiemtra(txtuserID.Text, txtpass.Text) = False Then
            MsgBox("Mật khẩu không chính xác", , "Thông báo")
            txtpass.Focus()
            Exit Sub
        End If
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("Bạn chưa nhập mật khẩu mới", , "Thông báo")
            TextBox1.Focus()
            Exit Sub
        End If
        If TextBox1.Text <> TextBox2.Text Then
            MsgBox("Mật khẩu nhập lại không giống mật khẩu mới", , "Thông báo")
            TextBox2.Focus()
            Exit Sub
        End If
        dto = bus.LayBangDTo(TenNguoiDangNhap)
        dto.pass = TextBox2.Text
        bus.sua(dto)
        MsgBox("Mật khẩu cửa Người Dùng: " & txtuserID.Text & " đã thây đổi" & vbNewLine, MsgBoxStyle.Information, "Thông Báo")
        Me.Close()
    End Sub
End Class