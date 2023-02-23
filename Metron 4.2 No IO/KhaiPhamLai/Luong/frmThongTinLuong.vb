Public Class frmThongTinLuong
    Public DtoLuong As New Bangluongdto
    Dim Busluong As New BangluongBus(DTOKetnoi, False)
    Dim DtoNhanVien As New nhanviendto
    Dim BusNhanvien As New nhanvienBus(DTOKetnoi, False)
    Private Sub frmThongTinLuong_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DtoNhanVien = BusNhanvien.LayBangDTo(DtoLuong.Manv)
        txtManv.Text = DtoLuong.Manv
        txtHoten.Text = DtoNhanVien.TenNV
        txtLuongthang.Text = Format(DtoLuong.LuongThang, "#,##0")
        TxtBaoHiem.Text = DtoLuong.TienBH
        txtTienTCgio.Text = DtoLuong.TienTcGio
        txtPhatDitre.Text = Format(DtoLuong.Phatditre, "#,##0")
        txtPhatNghiKhongphep.Text = Format(DtoLuong.phatnghikophep, "#,##0")
        txtTamUng1.Text = Format(DtoLuong.Tamung1, "#,##0")
        txtPhucap1.Text = Format(DtoLuong.Phucap1, "#,##0")
        txtTienTCgio.Text = Format(DtoLuong.TienTcGio, "#,##0")
        txtTienXe.Text = Format(DtoLuong.TienGuiXe, "#,##0")
        'txtComtrua.Text = Format(DtoLuong.TienComTrua, "#,##0")
        txtPhucap2.Text = Format(DtoLuong.Phucap2, "#,##0")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim a As Integer = DtoLuong.Thang
            DtoLuong.Thang = ManhinhLuong.ToolStripComboBoxThang.Text
            DtoLuong.Nam = ManhinhLuong.ToolStripcomboboxNam.Text
            DtoLuong.Phucap1 = txtPhucap1.Text
            DtoLuong.Tamung1 = txtTamUng1.Text
            DtoLuong.LuongThang = txtLuongthang.Text
            DtoLuong.TienBH = TxtBaoHiem.Text
            DtoLuong.TienTcGio = txtTienTCgio.Text
            DtoLuong.TienGuiXe = txtTienXe.Text
            DtoLuong.Phucap2 = txtPhucap2.Text
            DtoLuong.ChuyenCan = txtChuyencan.Text
            If a = 0 Then
                Busluong.Them(DtoLuong)
            Else
                Busluong.sua(DtoLuong)
            End If

            ManhinhLuong.REfreshF5()
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Thông báo")
        End Try
    End Sub

    Private Sub KiemTraSo(ByVal pchuoi As String)
        If pchuoi.Length > 0 Then
            If IsNumeric(pchuoi) = False Then
                MsgBox("Bạn phải nhập số", MsgBoxStyle.Information, "Thông báo")
            End If
        End If
    End Sub

    Private Sub txtLuongthang_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLuongThang.KeyDown
        If e.KeyData = Keys.Enter Then
            TxtBaoHiem.Focus()
        End If
    End Sub



    Private Sub txtLuongthang_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLuongThang.TextChanged
        Try
            KiemTraSo(txtLuongThang.Text)
            If txtLuongThang.Text.Length > 3 Then
                txtLuongThang.Text = FormatNumber(txtLuongThang.Text, 0)
                txtLuongThang.SelectionStart = txtLuongThang.TextLength
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtTamUng1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTamUng1.KeyDown
        Try
            If e.KeyData = Keys.Enter Then
                txtPhucap1.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txttamung1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTamUng1.TextChanged
        Try
            KiemTraSo(txtTamUng1.Text)
            If txtTamUng1.Text.Length > 3 Then
                txtTamUng1.Text = FormatNumber(txtTamUng1.Text, 0)
                txtTamUng1.SelectionStart = txtTamUng1.TextLength
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtPhucap1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPhucap1.KeyDown
        Try
            If e.KeyData = Keys.Enter Then
                txtPhucap2.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtPhucap1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPhucap1.TextChanged
        Try
            KiemTraSo(txtPhucap1.Text)
            If txtPhucap1.Text.Length > 3 Then
                txtPhucap1.Text = FormatNumber(txtPhucap1.Text, 0)
                txtPhucap1.SelectionStart = txtTamUng1.TextLength
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtTienTCgio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTienTCgio.KeyDown
        Try
            If e.KeyData = Keys.Enter Then
                txtTamUng1.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtTienTCgio_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTienTCgio.TextChanged
        Try
            KiemTraSo(txtTienTCgio.Text)
            If txtTienTCgio.Text.Length > 3 Then
                txtTienTCgio.Text = FormatNumber(txtTienTCgio.Text, 0)
                txtTienTCgio.SelectionStart = txtTienTCgio.TextLength
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmThongTinLuong_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        txtLuongthang.Focus()
    End Sub

    Private Sub TxtBaoHiem_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBaoHiem.KeyDown
        Try
            If e.KeyData = Keys.Enter Then
                txtTienTCgio.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtBaoHiem_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBaoHiem.TextChanged
        Try
            KiemTraSo(TxtBaoHiem.Text)
            If TxtBaoHiem.Text.Length > 3 Then
                TxtBaoHiem.Text = FormatNumber(TxtBaoHiem.Text, 0)
                TxtBaoHiem.SelectionStart = TxtBaoHiem.TextLength
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtComtrua_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            If e.KeyData = Keys.Enter Then
                Button1.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtComtrua_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            'KiemTraSo(txtComtrua.Text)
            'If txtComtrua.Text.Length > 3 Then
            '    txtComtrua.Text = FormatNumber(txtComtrua.Text, 0)
            '    txtComtrua.SelectionStart = txtComtrua.TextLength
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtPhucap2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPhucap2.KeyDown
        Try
            If e.KeyData = Keys.Enter Then
                'txtComtrua.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtPhucap2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPhucap2.TextChanged
        Try
            KiemTraSo(txtPhucap2.Text)
            If txtPhucap2.Text.Length > 3 Then
                txtPhucap2.Text = FormatNumber(txtPhucap2.Text, 0)
                txtPhucap2.SelectionStart = txtPhucap2.TextLength
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtChuyencan_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtChuyencan.TextChanged
        Try
            KiemTraSo(txtChuyencan.Text)
            If txtChuyencan.Text.Length > 3 Then
                txtChuyencan.Text = FormatNumber(txtChuyencan.Text, 0)
                txtChuyencan.SelectionStart = txtChuyencan.TextLength
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtChuyencan_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtChuyencan.KeyDown
        Try
            If e.KeyData = Keys.Enter Then
                txtTienXe.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtTienXe_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTienXe.TextChanged
        Try
            KiemTraSo(txtTienXe.Text)
            If txtTienXe.Text.Length > 3 Then
                txtTienXe.Text = FormatNumber(txtTienXe.Text, 0)
                txtTienXe.SelectionStart = txtTienXe.TextLength
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtTienXe_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTienXe.KeyDown
        Try
            If e.KeyData = Keys.Enter Then
                Button1.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class