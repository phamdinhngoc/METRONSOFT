Public Class frmPhuCapLuong
    Dim DtoPhuCapLuong As New Phucapluongdto
    Dim busPhuCapLuong As New PhucapluongBus(DTOKetnoi, False)


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try


            DtoPhuCapLuong.TienComTrua = txtComtrua.Text
            DtoPhuCapLuong.TienXe = txttienxe.Text
            DtoPhuCapLuong.TienAnTC1 = txttienantc1.Text
            DtoPhuCapLuong.TienAnTC2 = txttienantc2.Text
           
          
            busPhuCapLuong.sua(DtoPhuCapLuong)


            ManhinhLuong.REfreshF5()
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Thông báo")
        End Try
    End Sub

    Private Sub frmPhuCapLuong_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Data As New DataTable
        Data = busPhuCapLuong.LayBangTable()
        For i As Integer = 0 To Data.Rows.Count - 1
            DtoPhuCapLuong = busPhuCapLuong.LayBangDTo(i, Data)

            txtComtrua.Text = Format(DtoPhuCapLuong.TienComTrua, "#.##0")
            txttienxe.Text = Format(DtoPhuCapLuong.TienXe, "#.##0")
            txttienantc1.Text = Format(DtoPhuCapLuong.TienAnTC1, "#.##0")
            txttienantc2.Text = Format(DtoPhuCapLuong.TienAnTC2, "#.##0")
        Next

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Private Sub KiemTraSo(ByVal pchuoi As String)
        If pchuoi.Length > 0 Then
            If IsNumeric(pchuoi) = False Then
                MsgBox("Bạn phải nhập số", MsgBoxStyle.Information, "Thông báo")
            End If
        End If
    End Sub
    Private Sub txtTienTCgio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
       
    End Sub

    Private Sub txtTienTCgio_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyData = Keys.Enter Then
            txtComtrua.Focus()
        End If
    End Sub

    Private Sub txtComtrua_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtComtrua.TextChanged
        Try
            KiemTraSo(txtComtrua.Text)
            If txtComtrua.Text.Length > 3 Then
                txtComtrua.Text = FormatNumber(txtComtrua.Text, 0)
                txtComtrua.SelectionStart = txtComtrua.TextLength
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtComtrua_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtComtrua.KeyDown
        If e.KeyData = Keys.Enter Then
            txttienxe.Focus()
        End If
    End Sub

    Private Sub txttienxe_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttienxe.TextChanged
        Try
            KiemTraSo(txttienxe.Text)
            If txttienxe.Text.Length > 3 Then
                txttienxe.Text = FormatNumber(txttienxe.Text, 0)
                txttienxe.SelectionStart = txttienxe.TextLength
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txttienxe_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txttienxe.KeyDown
        If e.KeyData = Keys.Enter Then
            txttienantc1.Focus()
        End If
    End Sub

    Private Sub txttienantc1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttienantc1.TextChanged
        Try
            KiemTraSo(txttienantc1.Text)
            If txttienantc1.Text.Length > 3 Then
                txttienantc1.Text = FormatNumber(txttienantc1.Text, 0)
                txttienantc1.SelectionStart = txttienantc1.TextLength
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txttienantc1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txttienantc1.KeyDown
        If e.KeyData = Keys.Enter Then
            txttienantc2.Focus()
        End If
    End Sub

    Private Sub txttienantc2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttienantc2.TextChanged
        Try
            KiemTraSo(txttienantc2.Text)
            If txttienantc2.Text.Length > 3 Then
                txttienantc2.Text = FormatNumber(txttienantc2.Text, 0)
                txttienantc2.SelectionStart = txttienantc2.TextLength
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txttienantc2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txttienantc2.KeyDown
        If e.KeyData = Keys.Enter Then
            Button1.Focus()
        End If
    End Sub
End Class