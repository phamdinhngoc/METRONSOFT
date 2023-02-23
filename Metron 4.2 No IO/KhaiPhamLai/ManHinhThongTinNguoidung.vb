Imports System.Windows.Forms

Public Class ManHinhThongTinNguoidung

    Dim bus As New NguoidungBus(DTOKetnoi, False)
    Dim dto As New Nguoidungdto
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
    Private Sub hienthidulieu(ByVal group As Control)
        Dim valcontrol As New Control
        For Each valcontrol In group.Controls
            If valcontrol.Tag = "1" Then
                valcontrol.Text = dto.HoTro(UCase(Mid(valcontrol.Name, 4)))
            End If
            If valcontrol.Controls.Count > 0 Then
                hienthidulieu(valcontrol)
            End If
        Next
    End Sub

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
    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If DuyetTextBox(Me) Then
        Else
            Exit Sub
        End If
        HotroThem(Me)
        bus.sua(dto)
        MsgBox("Thông tin người dùng đã sửa xong", , "Thông báo")
        txtuserID.Focus()
    End Sub

    Private Sub ManHinhThongTinNguoidung_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        ManHinhChinh.CửaSổHoạtĐộngToolStripMenuItem.DropDownItems.Remove(ManHinhChinh.CửaSổHoạtĐộngToolStripMenuItem.DropDownItems(Me.Name))
    End Sub

    Private Sub ManHinhThongTinNguoidung_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ManHinhChinh.CửaSổHoạtĐộngToolStripMenuItem.DropDownItems.Add("Giao Diện Thông Tin Người Dùng").Name = Me.Name
        Dim busQ As New QuyenBus(DTOKetnoi, False)
        Dim ma As Integer = busQ.MaQuyen(QuyenNguoiDangNhap)
        cacNutNhan(Me, ma, Me.Name)
        cboQuyen.Items.Add("Tùy chọn")
        cboQuyen.Items.Add("Nhân Viên")
        cboQuyen.Items.Add("Quản Lý")
        cboQuyen.Items.Add("Tổng Quản Lý")
        cboQuyen.SelectedIndex = 1
        cauhoi1(CBoCauhoi1)
        cauhoi2(cboCauhoi2)
        CBoCauhoi1.SelectedIndex = 0
        cboCauhoi2.SelectedIndex = 0
        Try
            dto = bus.LayBangDTo(TenNguoiDangNhap)
            hienthidulieu(Me)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class