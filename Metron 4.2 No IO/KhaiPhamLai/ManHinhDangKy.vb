Imports System.Windows.Forms

Public Class ManHinhDangKy
    Dim bus As New NguoidungBus(DTOKetnoi, False)
    Dim dto As New Nguoidungdto
    Dim busquyen As New QuyenBus(DTOKetnoi, False)
    Dim dtoQuyen As New Quyendto
#Region "Nhập liệu nội dung cậu hỏi"
    Private Sub cauhoi1(ByVal combo As ComboBox)
        combo.Items.Add("1+1=?")
        combo.Items.Add("Tên trường cấp 1 của bạn là gì?")
        combo.Items.Add("Tên trường cấp 2 của bạn là gì?")
        combo.Items.Add("Tên trường cấp 3 của bạn là gì?")
        combo.Items.Add("Tên trường đại học của bạn là gì?")
        combo.Items.Add("Tên công ty thứ 1 của bạn đã làm là gì?")
        combo.Items.Add("Tên công ty thứ 2 của bạn đã làm là gì?")
        combo.Items.Add("Tên công ty thứ 3 của bạn đã làm là gì?")
    End Sub
    Private Sub cauhoi2(ByVal combo As ComboBox)
        combo.Items.Add("Tên của bạn là gì?")
        combo.Items.Add("Tên cha của bạn là gì? ")
        combo.Items.Add("Tên mẹ của bạn là gì?")
        combo.Items.Add("Tên người anh của bạn là gì?")
        combo.Items.Add("Tên người chị của bạn là gì?")
        combo.Items.Add("Tên em trai của bạn là gì?")
        combo.Items.Add("Tên em gái của bạn là gì?")
        combo.Items.Add("Tên vợ/tên chồng của bạn?")
    End Sub
#End Region
#Region "Key up"

    Private Sub txtUsername_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtuserID.KeyUp
        If e.KeyCode = Keys.Enter Then
            txtpass.Focus()
        End If
    End Sub

    Private Sub txtPassword_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtpass.KeyUp
        If e.KeyCode = Keys.Enter Then
            txtNhaplaiMatKhau.Focus()
        End If
    End Sub

    Private Sub txtNhaplaiMatKhau_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNhaplaiMatKhau.KeyUp
        If e.KeyCode = Keys.Enter Then
            CBoCauhoi1.Focus()
        End If
    End Sub

    Private Sub ComboBox1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CBoCauhoi1.KeyUp
        If e.KeyCode = Keys.Enter Then
            txtTraloi1.Focus()
        End If
    End Sub

    Private Sub TextBox1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTraloi1.KeyUp
        If e.KeyCode = Keys.Enter Then
            cboCauhoi2.Focus()
        End If
    End Sub

    Private Sub ComboBox2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCauhoi2.KeyUp
        If e.KeyCode = Keys.Enter Then
            txtTraloi2.Focus()
        End If
    End Sub

    Private Sub TextBox2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTraloi2.KeyUp
        If e.KeyCode = Keys.Enter Then
            btnOk.Focus()
        End If
    End Sub


#End Region
    'false: co loi      True :ko loi
    Private Function DuyetTextBox(ByVal frm As Control) As Boolean
        Dim ctr As New Control
        Dim a As Boolean = True
        For Each ctr In frm.Controls
            If ctr.Text = "" Then
                ErrorProvider1.SetError(ctr, "Thông Tin Này Bắt Buộc")
                a = False
            Else
                ErrorProvider1.SetError(ctr, "")
            End If
        Next
        Return a
    End Function
    Private Function HotroThem(ByVal group As Control)
        Dim valcontrol As New Control
        Dim loi As String = ""
        For Each valcontrol In group.Controls
            If valcontrol.Tag = "1" Then
                loi = dto.HoTro(UCase(Mid(valcontrol.Name, 4)), valcontrol.Text)
                If loi <> "" Then
                    valcontrol.Focus()
                    'có loi
                End If
                ErrorProvider1.SetError(valcontrol, loi)
            End If
            If valcontrol.Controls.Count > 0 Then
                HotroThem(valcontrol)
            End If
        Next
        Return loi
    End Function
    Private Sub combo()
        cboQuyen.DisplayMember = "tenquyen"
        cboQuyen.ValueMember = "maquyen"
        cboQuyen.DataSource = busquyen.LayBangTable()
    End Sub

    Private Sub ManHinhDangKy_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        ManHinhChinh.CửaSổHoạtĐộngToolStripMenuItem.DropDownItems.Remove(ManHinhChinh.CửaSổHoạtĐộngToolStripMenuItem.DropDownItems(Me.Name))
    End Sub
    Private Sub ManHinhDangKy_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ManHinhChinh.CửaSổHoạtĐộngToolStripMenuItem.DropDownItems.Add("Giao Diện Tạo Tài Khoản Người Sử Dụng").Name = Me.Name
        Dim busQ As New QuyenBus(DTOKetnoi, False)
        Dim ma As Integer = busQ.MaQuyen(QuyenNguoiDangNhap)
        cacNutNhan(Me, ma, Me.Name)
        combo()
        cauhoi1(CBoCauhoi1)
        cauhoi2(cboCauhoi2)
        CBoCauhoi1.SelectedIndex = 0
        cboCauhoi2.SelectedIndex = 0
        txtuserID.Focus()
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If DuyetTextBox(GroupBox2) And DuyetTextBox(GroupBox4) Then
        Else
            Exit Sub
        End If
        If bus.LayBangTable(txtuserID.Text).Rows.Count > 0 Then
            ErrorProvider1.SetError(txtuserID, "Tài khoản không hợp lệ")
            Exit Sub
        End If
        HotroThem(Me)
        dto.Quyen = cboQuyen.SelectedValue
        bus.Them(dto)
        MsgBox("Người Dùng: " & txtuserID.Text & "  Đã Tạo Xong" & vbNewLine, MsgBoxStyle.Information, "Thông Báo")
        txtuserID.Focus()
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim TenQuyen As String = InputBox("Nhập Tên Quyền bạn muốn thêm", "Thông báo")
        If TenQuyen = "" Then Exit Sub
        dtoQuyen.TenQuyen = TenQuyen
        busquyen.Them(dtoQuyen)
        combo()
        PhanQuyenChoNguoiDung_2_.Show()
        PhanQuyenChoNguoiDung_2_.ComboBox1.SelectedIndex = busquyen.LayBangTable.Rows.Count - 1
    End Sub
End Class