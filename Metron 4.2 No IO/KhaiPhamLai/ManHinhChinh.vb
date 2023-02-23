'Phần mềm cọ Việt Mỹ.
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Odbc

Public Class ManHinhChinh
    Dim BusMay As New mayBus(DTOKetnoi, False)
    Dim dtomay As New maydto
    Dim busNguoidung As New NguoidungBus(DTOKetnoi, False)
    Dim dtoNguoidung As New Nguoidungdto
    Dim Array As New ArrayList
    Dim daoNK As New NhatkyBus(DTOKetnoi, False)
    Dim dtoNK As New Nhatkydto
#Region "Ho tro View Menu"
    Private WithEvents mBo_doc_ghi As OleDb.OleDbDataAdapter
    Public Function kiemtra(ByVal tennguoidung As String, ByVal matkhau As String) As Boolean
        Dim sql As String = "select * from nguoidung" & _
          " WHERE userID='" & tennguoidung & "' AND pass='" & matkhau & "' "
        Dim Data As DataTable = BusMay.LayBangTableSQL(sql)
        If Data.Rows.Count > 0 Then Return True
        Return False
    End Function
    Private Function kiemtra() As Boolean
        Try
            Dim sql As String = "select * from nguoidung"
            Dim Data As New DataTable
            mBo_doc_ghi = New OleDbDataAdapter(sql, Ketnoi)
            mBo_doc_ghi.FillSchema(Data, SchemaType.Mapped)
            mBo_doc_ghi.Fill(Data)
            Return Data.Rows.Count <= 0
        Catch ex As OleDb.OleDbException
            Return False
            Exit Function
        End Try
    End Function
#Region "Hàm viết thêm"
    Private Sub ToggleVisible()
        MenuCSHoatDong_CCBenTrai.Checked = Not MenuCSHoatDong_CCBenTrai.Checked
        Me.SplitContainer1.Panel1Collapsed = Not MenuCSHoatDong_CCBenTrai.Checked
    End Sub
    Private Sub ToggleVisible1()
        MenuCSHoatDong_CCSoDo.Checked = Not MenuCSHoatDong_CCSoDo.Checked
        Me.SplitContainer3.Panel1Collapsed = Not MenuCSHoatDong_CCSoDo.Checked
    End Sub
    Private Sub ToggleVisible2()
        MenuCSHoatDong_CCdsMayCC.Checked = Not MenuCSHoatDong_CCdsMayCC.Checked
        Me.SplitContainer2.Panel1Collapsed = Not MenuCSHoatDong_CCdsMayCC.Checked
    End Sub
    Private Sub ToggleVisible3()
        MenuCSHoatDong_CCDsNQuet.Checked = Not MenuCSHoatDong_CCDsNQuet.Checked
        Me.SplitContainer4.Panel1Collapsed = Not MenuCSHoatDong_CCDsNQuet.Checked
        If MenuCSHoatDong_CCDsNQuet.Checked = False And MenuCSHoatDong_CCTheNV.Checked = False Then
            MenuCSHoatDong_CCTheNV.Checked = True
        End If
    End Sub
    Private Sub ToggleVisible4()
        MenuCSHoatDong_CCTheNV.Checked = Not MenuCSHoatDong_CCTheNV.Checked
        Me.SplitContainer4.Panel2Collapsed = Not MenuCSHoatDong_CCTheNV.Checked
        If MenuCSHoatDong_CCDsNQuet.Checked = False And MenuCSHoatDong_CCTheNV.Checked = False Then
            MenuCSHoatDong_CCDsNQuet.Checked = True
        End If
    End Sub
#End Region
#Region "Các sự kiện ẩn hiện "

    Private Sub DanhSáchMCCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuCSHoatDong_CCdsMayCC.Click
        ToggleVisible2()
    End Sub
    Private Sub ToolViewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolViewToolStripMenuItem.Click
        ToolViewToolStripMenuItem.Checked = Not ToolViewToolStripMenuItem.Checked
        ToolStrip1.Visible = ToolViewToolStripMenuItem.Checked
    End Sub
   
    Private Sub MenuViewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuCSHoatDong_CCBenTrai.Click
        ToggleVisible()
    End Sub
    Private Sub SơĐồToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuCSHoatDong_CCSoDo.Click
        ToggleVisible1()
    End Sub
    Private Sub ThẻNhânViênToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuCSHoatDong_CCTheNV.Click
        ToggleVisible4()
    End Sub
    Private Sub DanhSáchNgườiQuétToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuCSHoatDong_CCDsNQuet.Click
        ToggleVisible3()
    End Sub

    Private Sub CửaSổCơBảnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CửaSổCơBảnToolStripMenuItem.Click
        CửaSổCơBảnToolStripMenuItem.Checked = True
        CửaSổNângCaoToolStripMenuItem.Checked = False
        Me.SplitContainer1.Panel1Collapsed = True
        Me.SplitContainer1.Panel2Collapsed = False
        Me.SplitContainer2.Panel1Collapsed = False
        Me.SplitContainer2.Panel2Collapsed = False
        Me.SplitContainer3.Panel1Collapsed = False
        Me.SplitContainer3.Panel2Collapsed = False
        Me.SplitContainer4.Panel1Collapsed = False
        Me.SplitContainer4.Panel2Collapsed = False
    End Sub

    Private Sub CửaSổNângCaoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CửaSổNângCaoToolStripMenuItem.Click
        CửaSổCơBảnToolStripMenuItem.Checked = False
        CửaSổNângCaoToolStripMenuItem.Checked = True
        Me.SplitContainer1.Panel1Collapsed = False
        Me.SplitContainer1.Panel2Collapsed = False
        Me.SplitContainer2.Panel1Collapsed = False
        Me.SplitContainer2.Panel2Collapsed = False
        Me.SplitContainer3.Panel1Collapsed = True
        Me.SplitContainer3.Panel2Collapsed = False
        Me.SplitContainer4.Panel1Collapsed = False
        Me.SplitContainer4.Panel2Collapsed = False
    End Sub
#Region "Menu Bên trái"

    Private Sub ToolStripButton23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton23.Click
        ToolStrip7.Visible = Not ToolStrip7.Visible
        ToolStrip8.Visible = Not ToolStrip8.Visible
        ToolStrip9.Visible = Not ToolStrip9.Visible
        If ToolStrip9.Visible Then
            ToolStripButton23.Image = My.Resources.up
        Else
            ToolStripButton23.Image = My.Resources.down
        End If
    End Sub

    Private Sub ToolStripButton24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton24.Click
        ToolStrip11.Visible = Not ToolStrip11.Visible
        'ToolStrip12.Visible = Not ToolStrip12.Visible
        ToolStrip13.Visible = Not ToolStrip13.Visible
        ToolStrip14.Visible = Not ToolStrip14.Visible
        ToolStrip15.Visible = Not ToolStrip15.Visible
        If ToolStrip11.Visible Then
            ToolStripButton24.Image = My.Resources.up
        Else
            ToolStripButton24.Image = My.Resources.down
        End If
    End Sub

    Private Sub ToolStripButton25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton25.Click
        ToolStrip17.Visible = Not ToolStrip17.Visible
        ToolStrip18.Visible = Not ToolStrip18.Visible
        ToolStrip19.Visible = Not ToolStrip19.Visible
        If ToolStrip17.Visible Then
            ToolStripButton25.Image = My.Resources.up
        Else
            ToolStripButton25.Image = My.Resources.down
        End If
    End Sub
    Private Sub ToolStripButton22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton22.Click
        ToolStrip3.Visible = Not ToolStrip3.Visible
        ToolStrip4.Visible = Not ToolStrip4.Visible
        ToolStrip5.Visible = Not ToolStrip5.Visible
        If ToolStrip3.Visible Then
            ToolStripButton22.Image = My.Resources.up
        Else
            ToolStripButton22.Image = My.Resources.down
        End If
    End Sub
#End Region
#End Region
    Private Sub MenuQLDL_TroDL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuQLDL_TroDL.Click
        dtoNK.User = TenNguoiDangNhap
        dtoNK.Ngay = Date.Now.Date
        dtoNK.Gio = Date.Now
        dtoNK.Tacvu = "Xem màn hình trỏ dữ liệu"
        daoNK.Them(dtoNK)
        ManHinhTroDuLieu.Owner = Me
        ManHinhTroDuLieu.Show()
    End Sub
    Private Sub ThôngTinPhầnMềmToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ThôngTinPhầnMềmToolStripMenuItem.Click
        SplashScreen.Show()
    End Sub
    Private Sub MenuQLDL_SaoLuuDL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuQLDL_SaoLuuDL.Click
        dtoNK.User = TenNguoiDangNhap
        dtoNK.Ngay = Date.Now.Date
        dtoNK.Gio = Date.Now
        dtoNK.Tacvu = "Mở màn hình sao lưu dử liệu"
        daoNK.Them(dtoNK)
        If kiemtra() Then
            MsgBox("Không có người dùng đăng ký nên được tùy ý Sao Lưu", , "Thông báo")
        Else
            ManHinhMatKhau.ShowDialog()
            Dim matkhau As String = ManHinhMatKhau.str
            If matkhau = "" Then
                Exit Sub
            ElseIf kiemtra(TenNguoiDangNhap, matkhau) = False Then
                MsgBox("Mật khẩu không chính xác")
                Exit Sub
            End If
        End If
        SuachuaTruocKhiBackUp()
        ManHinhSaoLuu.Owner = Me
        ManHinhSaoLuu.Show()
    End Sub
    Private Sub MenuQLDL_PhucHoiDL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuQLDL_PhucHoiDL.Click
        dtoNK.User = TenNguoiDangNhap
        dtoNK.Ngay = Date.Now.Date
        dtoNK.Gio = Date.Now
        dtoNK.Tacvu = "Mở màn hình phục hồi dử liệu"
        daoNK.Them(dtoNK)
        If kiemtra() Then
            MsgBox("Không có người dùng đăng ký nên được tùy ý phục hồi", , "Thông báo")
        Else
            ManHinhMatKhau.ShowDialog()
            Dim matkhau As String = ManHinhMatKhau.str
            If matkhau = "" Then
                Exit Sub
            ElseIf kiemtra(TenNguoiDangNhap, matkhau) = False Then
                MsgBox("Mật khẩu không chính xác")
                Exit Sub
            End If
        End If

        ManHinhPhucHoi.Owner = Me
        ManHinhPhucHoi.Show()
    End Sub
#End Region
#Region "Ho tro ListView"

#Region "Hàm viết thêm"
    Private Sub SetUpListViewColumns()
        ListView.Columns.Add("Tên máy", 150)     '0
        ListView.Columns.Add("Vị trí", 110)     '1
        ListView.Columns.Add("Trạng thái", 100)     '2
        ListView.Columns.Add("Địa chỉ Ip", 100)     '3
        ListView.Columns.Add("Mã máy", 70)      '4
        ListView.Columns.Add("Cổng Com", 70)    '5  
        ListView.Columns.Add("Rate", 100)   '6
        ListView.Columns.Add("Kiểu", 50)    '7
        ListView.Columns.Add("LM", 50)    '8
        ListView.Columns.Add("MS", 50)    '9
        SetView(View.LargeIcon)
        'cua so tóm tắt
        ListView1.Columns.Add("TT", 30)     '0
        ListView1.Columns.Add("MCC", 40)    '1
        ListView1.Columns.Add("Tên Nhân Viên", 200)     '2
        ListView1.Columns.Add("Gìơ", 150)    '3
        ListView1.Columns.Add("Kiểu", 50)   '4
        ListView1.Columns.Add("Máy", 50)    '5
        ListView1.View = View.Details
    End Sub
    Public Sub LoadListView()
        Dim lvItem As ListViewItem
        ListView.Items.Clear()
        Dim May As DataTable = BusMay.LayBangTable()
        For i As Integer = 0 To May.Rows.Count - 1
            dtomay = BusMay.LayBangDTo(i, May)
            lvItem = ListView.Items.Add(dtomay.Tenmay)
            lvItem.ImageIndex = 3
            lvItem.SubItems.AddRange(New String() {dtomay.Vtri, "Ngằt kết nối", dtomay.IP, dtomay.ID, dtomay.Cong, dtomay.Rate, dtomay.Kieu, dtomay.Loaimay, dtomay.MaySO})
            lvItem.Tag = "3"
        Next
        'Cua so tóm tắt
        ListView1.Items.Clear()
        'lvItem = ListView1.Items.Add("1")
        'lvItem.SubItems.AddRange(New String() {"1", "Phạm Thị Bé", "7:30", "Vào", "Máy 1"})
        'lvItem = ListView1.Items.Add("2")
        'lvItem.SubItems.AddRange(New String() {"2", "Huỳnh Minh Tuấn", "7:31", "Vào", "Máy 1"})
        'lvItem = ListView1.Items.Add("3")
        'lvItem.SubItems.AddRange(New String() {"3", "Đổ Ngọc Anh", "8:00", "Ra", "Máy 2"})

    End Sub
    Private Sub SetView(ByVal View As System.Windows.Forms.View)
        Dim MenuItemToCheck As ToolStripMenuItem = Nothing
        Dim MenuItemToCheckConText As ToolStripMenuItem = Nothing
        Select Case View
            Case View.Details
                MenuItemToCheck = DetailsToolStripMenuItem
                MenuItemToCheckConText = ToolStripMenuItem2
            Case View.LargeIcon
                MenuItemToCheck = LargeIconsToolStripMenuItem
                MenuItemToCheckConText = ToolStripMenuItem3
            Case View.List
                MenuItemToCheck = ListToolStripMenuItem
            Case View.SmallIcon
                MenuItemToCheck = SmallIconsToolStripMenuItem
            Case Else
                Debug.Fail("Unexpected View")
                View = View.Details
                MenuItemToCheck = DetailsToolStripMenuItem
        End Select

        For Each MenuItem As ToolStripMenuItem In ListViewToolStripButton.DropDownItems
            If MenuItem Is MenuItemToCheck Then
                MenuItem.Checked = True
            Else
                MenuItem.Checked = False
            End If
        Next
        For Each MenuItem As ToolStripMenuItem In ToolStripMenuItem8.DropDownItems
            If MenuItem Is MenuItemToCheckConText Then
                MenuItem.Checked = True
            Else
                MenuItem.Checked = False
            End If

        Next

        'Finally
        ListView.View = View
    End Sub
#End Region
#Region "Các sự kiện ListToolMenuItem "
    Private Sub ListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListToolStripMenuItem.Click
        SetView(View.List)
    End Sub

    Private Sub DetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetailsToolStripMenuItem.Click, ToolStripMenuItem2.Click
        SetView(View.Details)
    End Sub

    Private Sub LargeIconsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LargeIconsToolStripMenuItem.Click, ToolStripMenuItem3.Click
        SetView(View.LargeIcon)
    End Sub

    Private Sub SmallIconsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SmallIconsToolStripMenuItem.Click
        SetView(View.SmallIcon)
    End Sub

    Private Sub TileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SetView(View.Tile)
    End Sub
     
     

#End Region
    Private Sub ListView_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles ListView.ItemSelectionChanged
        If e.IsSelected Then
            TrangThai(e.Item.Tag)
        End If
    End Sub
#End Region
#Region "Hổ trợ Sơ Đồ"
#Region "Hàm Hổ trợ"
    Public Sub AnMo(ByVal index As String, ByVal Group As Control)
        Dim CTr As New Control
        For Each CTr In Group.Controls
            If CTr.Tag = index Then
                CTr.Visible = True
            ElseIf CTr.Tag <> "0" Then
                CTr.Visible = False
            End If
        Next
    End Sub
    Public Sub AnMoMenu(ByVal index As String, ByVal Group As MenuStrip)
        Dim CTr As New ToolStripMenuItem
        For Each CTr In Group.Items
            If Val(CTr.Tag) <= Val(index) Then
                CTr.Visible = True
            ElseIf CTr.Tag <> "0" Then
                CTr.Visible = False
            End If
            If CTr.DropDownItems.Count > 0 Then
                Dim ctrm As ToolStripItem
                For Each ctrm In CTr.DropDownItems
                    If Val(ctrm.Tag) <= Val(index) Then
                        ctrm.Visible = True
                    ElseIf ctrm.Tag <> "0" Then
                        ctrm.Visible = False
                    End If
                Next
            End If
        Next
    End Sub
    Public Sub AnMoAll(ByVal Group As Control)
        Dim CTr As New Control
        For Each CTr In Group.Controls
            If CTr.Tag <> "0" Then
                CTr.Visible = False
            Else
                CTr.Visible = True
            End If
        Next
    End Sub
    Public Sub TrangThai(ByVal Tag As String)
        If Tag = "0" Or Tag = "1" Or Tag = "3" Then
            If Tag = "1" Then
                Button2.Enabled = False
            Else
                Button2.Enabled = True
            End If
            Button3.Enabled = False
            Button4.Enabled = False
            Button5.Enabled = False
            Button6.Enabled = False
            Button8.Enabled = False
            PictureBox2.Image = KhaiPhamLai.My.Resources._13
            PictureBox3.Image = KhaiPhamLai.My.Resources._11
            PictureBox4.Image = KhaiPhamLai.My.Resources._13
        ElseIf Tag = "2" Then
            Button2.Enabled = True
            Button3.Enabled = True
            Button4.Enabled = True
            Button5.Enabled = True
            Button6.Enabled = True
            PictureBox2.Image = KhaiPhamLai.My.Resources._14
            PictureBox3.Image = KhaiPhamLai.My.Resources._12
        End If
    End Sub
#End Region
#Region "Sự Kiện"
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click, ToolStripButton5.Click, ToolStripMenuItem6.Click
        TaoMay()
        dtoNK.User = TenNguoiDangNhap
        dtoNK.Ngay = Date.Now.Date
        dtoNK.Gio = Date.Now
        dtoNK.Tacvu = "Kết nối máy chấm công"
        daoNK.Them(dtoNK)
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click, ToolStripButton6.Click, ToolStripMenuItem7.Click
        NgatKNZK()
        dtoNK.User = TenNguoiDangNhap
        dtoNK.Ngay = Date.Now.Date
        dtoNK.Gio = Date.Now
        dtoNK.Tacvu = "Ngắt kết nối máy chấm công"
        daoNK.Them(dtoNK)
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click, MenuQLMay_TaiDLMCC_MayTinh.Click
        Button8.Enabled = True
        PictureBox4.Image = KhaiPhamLai.My.Resources._14
        ListView.Focus()
        FChay.Kieu = 1
        FChay.Show()
        dtoNK.User = TenNguoiDangNhap
        dtoNK.Ngay = Date.Now.Date
        dtoNK.Gio = Date.Now
        dtoNK.Tacvu = "Tải dử liệu mới từ máy chấm công xuống máy tính"
        daoNK.Them(dtoNK)
        'DanhsachvaoraDemo()
    End Sub
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If Button2.Visible = True Then
            AnMoAll(SplitContainer3.Panel1)
        Else
            AnMo(1, SplitContainer3.Panel1)
        End If
        Me.ListView.Focus()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Button18.Visible = True Then
            AnMoAll(SplitContainer3.Panel1)
        Else
            AnMo(2, SplitContainer3.Panel1)
        End If
    End Sub
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        If Button13.Visible = True Then
            AnMoAll(SplitContainer3.Panel1)
        Else
            AnMo(3, SplitContainer3.Panel1)
        End If
    End Sub
#End Region
#End Region
#Region "menu"
    Private Sub MenuQLMay_MenuQLMCC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuQLMay_MenuQLMCC.Click
        ManHinhQLTTMayChamCong.Owner = Me
        ManHinhQLTTMayChamCong.Show()
        Me.ListView.Focus()
    End Sub
    Private Sub MenuQLTaiKhoan_XemNKySDung_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuQLTaiKhoan_XemNKySDung.Click
        ManHinhNhatKy.Owner = Me
        ManHinhNhatKy.Show()
        Me.ListView.Focus()
    End Sub
    Private Sub MenuQLTaiKhoan_XemTTTaiKhoan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuQLTaiKhoan_XemTTTaiKhoan.Click
        ManHinhThongTinNguoidung.Owner = Me
        ManHinhThongTinNguoidung.Show()
        Me.ListView.Focus()
    End Sub
    Private Sub MenuQLTaiKhoan_TaoTK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuQLTaiKhoan_TaoTK.Click
        ManHinhDangKy.Owner = Me
        ManHinhDangKy.Show()
        Me.ListView.Focus()
    End Sub
    Private Sub MenuQLTaiKhoan_ThayDoiPass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuQLTaiKhoan_ThayDoiPass.Click
        ManHinhSuaMatKhau.Owner = Me
        ManHinhSuaMatKhau.Show()
        Me.ListView.Focus()
    End Sub
    Private Sub PhânQuyềnNgườiDùngToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PhânQuyềnNgườiDùngToolStripMenuItem.Click
        PhanQuyenChoNguoiDung_2_.Owner = Me
        PhanQuyenChoNguoiDung_2_.Show()
        Me.ListView.Focus()
    End Sub
    Private Sub MenuQLTaiKhoan_XemTatCaTK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuQLTaiKhoan_XemTatCaTK.Click
        ManHinhXemNguoidung.Owner = Me
        ManHinhXemNguoidung.Show()
        Me.ListView.Focus()
    End Sub
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click, MenuQLHS_TimKiemNV.Click
        ManHinhTimKiemNhanViên.Owner = Me
        ManHinhTimKiemNhanViên.Show()
        Me.ListView.Focus()
    End Sub
    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click, XemToolStripMenuItem.Click, XoáToolStripMenuItem.Click
        ManHinhThietLapMCC.Owner = Me
        ManHinhThietLapMCC.Show()
        Me.ListView.Focus()
    End Sub

    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click
        Me.Close()
    End Sub
    Private Sub ToolStripButton13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton13.Click, MenuQLNDung_QLNVien.Click, ToolStripButton1.Click, ToolStrip9.Click
        Frmnhanvien.Owner = Me
        Frmnhanvien.Show()
        Me.ListView.Focus()
    End Sub
    Private Sub ToolStripButton14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton14.Click, MenuQLNDung_TLCa.Click, ToolStrip11.Click
        ManHinhCAKhac.Owner = Me
        ManHinhCAKhac.Show()
        Me.ListView.Focus()
    End Sub
    Private Sub ToolStripButton16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton16.Click, MenuQLNDung_TLLichNV.Click, ToolStrip13.Click
        ManHinhApLichNV.Owner = Me
        ManHinhApLichNV.Show()
        Me.ListView.Focus()

    End Sub
    Private Sub MenuQLNDung_NgayNghi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuQLNDung_NgayNghi.Click, ToolStripButton17.Click, ToolStrip14.Click
        ManHinhNhanVienNghiVanTinhCong.Owner = Me
        ManHinhNhanVienNghiVanTinhCong.Show()
        Me.ListView.Focus()
    End Sub
    Private Sub MenuQLNDung_BaoCaoCong_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuQLNDung_BaoCaoCong.Click, ToolStripButton18.Click, ToolStripButton3.Click, ToolStrip15.Click, Button18.Click
        ManHinhBaoCao.Owner = Me
        ManHinhBaoCao.Show()
        Me.ListView.Focus()
    End Sub
    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Manhinhngayle.Owner = Me
        Manhinhngayle.Show()
        Me.ListView.Focus()
    End Sub
    Private Sub MenuQLNDung_QLChucVu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuQLNDung_QLChucVu.Click, ToolStrip8.Click, ToolStripButton12.Click
        ManhinhChucvu.Owner = Me
        ManhinhChucvu.Show()
        Me.ListView.Focus()
    End Sub
    Private Sub MenuQLMay_TaiDLMayTinh_MCC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuQLMay_TaiDLMayTinh_MCC.Click, ToolStripButton8.Click, ToolStrip3.Click, Button3.Click
        ManHinhTaiDulieu.Owner = Me
        ManHinhTaiDulieu.Show()
        Me.ListView.Focus()
        dtoNK.User = TenNguoiDangNhap
        dtoNK.Ngay = Date.Now.Date
        dtoNK.Gio = Date.Now
        dtoNK.Tacvu = "Tải dử liệu lên máy chấm công"
        daoNK.Them(dtoNK)
    End Sub
    Private Sub MenuQLMay_KTNDungMCC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuQLMay_KTNDungMCC.Click, ToolStrip5.Click, Button5.Click
        ManHinhQlNVtrenMCC.Owner = Me
        ManHinhQlNVtrenMCC.Show()
    End Sub
#End Region
#Region "file"
    Private Function DocFileBut(ByVal duongdanFile As String) As String
        Dim file As FileStream
        Dim reader As StreamReader
        Dim a As String = ""
        Try
            file = New FileStream(duongdanFile, FileMode.Open)
            reader = New StreamReader(file)
            While (reader.EndOfStream = False)
                kiemtrabut(reader.ReadLine, MenuStrip1)
            End While
            reader.Close()
            file.Close()
        Catch EX As Exception
            Return ""
        End Try
        Return a
    End Function
    Private Sub addArray()
        Array.Add("THÊM Chức Vụ")
        Array.Add("XOÁ Chức Vụ")
        Array.Add("SỬA Chức Vụ")

        Array.Add("THÊM Đơn vị(Phòng ban)")
        Array.Add("XOÁ Đơn vị(Phòng ban)")
        Array.Add("SỬA Đơn vị(Phòng ban)")

        Array.Add("THÊM Máy Chấm Công")
        Array.Add("XOÁ Máy Chấm Công")
        Array.Add("SỬA Máy Chấm Công")

        Array.Add("ĐĂNG KÝ nguời dùng")
        Array.Add("XOÁ người dùng")
        Array.Add("SỬA người dùng")

        Array.Add("THÊM Nhân viên sử dụng máy chấm Công")
        Array.Add("XOÁ Nhân viên sử dụng máy chấm Công")
        Array.Add("SỬA Nhân viên sử dụng máy chấm Công")
    End Sub
    Public Sub gan(ByVal i As Integer, Optional ByVal ds As Boolean = True)
        Select Case i
            Case 0
                ThemCV = ds
            Case 1
                XoaCV = ds
            Case 2
                SuaCV = ds
            Case 3
                ThemDV = ds
            Case 4
                XoaDV = ds
            Case 5
                SuaDV = ds
            Case 6
                ThemMCC = ds
            Case 7
                XoaMCC = ds
            Case 8
                SuaMCC = ds
            Case 9
                ThemND = ds
            Case 10
                XoaND = ds
            Case 11
                SuaND = ds
            Case 12
                ThemNV = ds
            Case 13
                XoaNV = ds
            Case 14
                SuaNV = ds
            Case Else
        End Select
    End Sub
    Private Sub kiemtraQuyen(ByVal str As String)
        For i As Integer = 0 To 14
            If str = Array(i) Then
                gan(i)
            End If
        Next
    End Sub
    Private Function TaoFile(ByVal duongdanFile As String, ByVal NoidungFile As String) As String
        Dim file As FileStream
        Dim writer As StreamWriter
        Try
            file = New FileStream(duongdanFile, FileMode.CreateNew)
            writer = New StreamWriter(file)
            writer.WriteLine(NoidungFile)
            writer.Close()
            file.Close()
        Catch EX As Exception
            Return (EX.Message)
        End Try
        Return "1"
    End Function
    Private Function GhiFile(ByVal duongdanFile As String, ByVal NoidungFile As String) As String
        Dim file As FileStream
        Dim writer As StreamWriter
        Try
            file = New FileStream(duongdanFile, FileMode.Open)
            writer = New StreamWriter(file)
            writer.WriteLine(NoidungFile)
            writer.Close()
            file.Close()
        Catch EX As Exception
            Return EX.Message
        End Try
        Return "1"
    End Function
    Private Function DocFile(ByVal duongdanFile As String) As String
        Dim file As FileStream
        Dim reader As StreamReader
        Dim a As String = ""
        Try
            file = New FileStream(duongdanFile, FileMode.Open)
            reader = New StreamReader(file)
            a = reader.ReadLine
            reader.Close()
            file.Close()
        Catch EX As Exception
            Return ""
        End Try
        Return a
    End Function
    Private Sub DocFileQuyen(ByVal duongdanFile As String)
        addArray()
        For j As Integer = 0 To 14
            gan(j, False)
        Next
        Dim file As FileStream
        Dim reader As StreamReader
        Try
            file = New FileStream(duongdanFile, FileMode.Open)
            reader = New StreamReader(file)
            While (reader.EndOfStream = False)
                kiemtraQuyen(reader.ReadLine)
            End While
            reader.Close()
            file.Close()
        Catch EX As Exception
        End Try
    End Sub
#End Region
#Region "Linh Tinh"
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        If Button18.Visible = True Then
            AnMoAll(SplitContainer3.Panel1)
        Else
            AnMo(2, SplitContainer3.Panel1)
        End If
    End Sub
    Private Sub CửaSổHoạtĐộngToolStripMenuItem_DropDownItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles CửaSổHoạtĐộngToolStripMenuItem.DropDownItemClicked
        Dim F As FormCollection
        F = My.Application.OpenForms
        F.Item(e.ClickedItem.Name).WindowState = FormWindowState.Normal
        F.Item(e.ClickedItem.Name).Select()
    End Sub
    Private Sub nhanvien()
        AnMoMenu("7", MenuStrip1)
    End Sub
    Private Sub Quanly()
        AnMoMenu("8", MenuStrip1)
    End Sub
    Public Sub kiemtrabut(ByVal str As String, ByVal group As MenuStrip)
        Dim CTr As New ToolStripMenuItem
        For Each CTr In group.Items
            If str = CTr.Name Then
                CTr.Visible = False
            End If
            If CTr.DropDownItems.Count > 0 Then
                Dim ctrm As ToolStripItem
                For Each ctrm In CTr.DropDownItems
                    If str = ctrm.Name Then
                        ctrm.Visible = False
                    End If
                Next
            End If
        Next
    End Sub
#End Region
#Region "AN Hien"
    Private Sub MenuQLMay_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuQLMay.VisibleChanged
        ToolStrip2.Visible = sender.Visible
    End Sub
    Private Sub MenuQLMay_TaiDLMayTinh_MCC_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuQLMay_TaiDLMayTinh_MCC.VisibleChanged
        ToolStrip3.Visible = sender.visible
    End Sub
    Private Sub MenuQLMay_TaiDLMCC_MayTinh_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuQLMay_TaiDLMCC_MayTinh.VisibleChanged
        ToolStrip4.Visible = sender.visible
    End Sub
    Private Sub MenuQLMay_KTNDungMCC_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuQLMay_KTNDungMCC.VisibleChanged
        ToolStrip5.Visible = sender.visible
    End Sub
    Private Sub MenuQLNDung_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuQLNDung.VisibleChanged
        ToolStrip6.Visible = sender.visible
        ToolStrip7.Visible = sender.visible
        ToolStrip8.Visible = sender.visible
        ToolStrip9.Visible = sender.visible
        ToolStrip10.Visible = sender.visible
        ToolStrip11.Visible = sender.visible
        ToolStrip12.Visible = sender.visible
        ToolStrip13.Visible = sender.visible
        ToolStrip14.Visible = sender.visible
        ToolStrip15.Visible = sender.visible
    End Sub
    Private Sub MenuQLNDung_QLBoPhan_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuQLNDung_QLBoPhan.VisibleChanged
        ToolStrip7.Visible = sender.visible
    End Sub

    Private Sub MenuQLNDung_QLChucVu_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuQLNDung_QLChucVu.VisibleChanged
        ToolStrip8.Visible = sender.visible
    End Sub
    Private Sub MenuQLNDung_QLNVien_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuQLNDung_QLNVien.VisibleChanged
        ToolStrip9.Visible = sender.visible
        ToolStripButton1.Visible = sender.visible
    End Sub
    Private Sub MenuQLNDung_TLCa_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuQLNDung_TLCa.VisibleChanged
        ToolStrip11.Visible = sender.visible
    End Sub
    Private Sub MenuQLNDung_TLLichLV_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuQLNDung_TLLichLV.VisibleChanged
        ToolStrip12.Visible = sender.visible
    End Sub
    Private Sub MenuQLNDung_TLLichNV_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuQLNDung_TLLichNV.VisibleChanged
        ToolStrip13.Visible = sender.visible
    End Sub
    Private Sub MenuQLNDung_NgayNghi_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuQLNDung_NgayNghi.VisibleChanged
        ToolStrip14.Visible = sender.visible
    End Sub
    Private Sub MenuQLNDung_BaoCaoCong_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuQLNDung_BaoCaoCong.VisibleChanged
        ToolStrip15.Visible = sender.visible
        ToolStripButton3.Visible = sender.visible
    End Sub
    Private Sub MenuQLHS_TimKiemNV_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuQLHS_TimKiemNV.VisibleChanged
        ToolStripButton2.Visible = sender.visible
    End Sub
    Private Sub QLDLMayChamToolStripMenuItem_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles QLDLMayChamToolStripMenuItem.VisibleChanged
        ToolStrip17.Visible = sender.visible
    End Sub
    Private Sub NhậpDửLiệuChấmCôngToolStripMenuItem_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles NhậpDửLiệuChấmCôngToolStripMenuItem.VisibleChanged
        ToolStrip18.Visible = sender.visible
    End Sub
    Private Sub XuấtDửLiệuChấmCôngToolStripMenuItem_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles XuấtDửLiệuChấmCôngToolStripMenuItem.VisibleChanged
        ToolStrip19.Visible = sender.visible
    End Sub
#End Region
    Private Sub ManHinhChinh_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim msg As MsgBoxResult = MsgBox("Bạn có muốn sao lưu trước khi thoát không?" & vbNewLine & "Yes: Sao lưu dữ liệu trước, sau đó thoát." & vbNewLine & "No: Thoát ngay bây giờ." & vbNewLine & "Cancel: Trở lại màn hình, huỷ thoát.", MsgBoxStyle.YesNoCancel, "Thông báo")
        If msg = MsgBoxResult.Yes Then
            e.Cancel = True
            If kiemtra() Then
                MsgBox("Không có người dùng đăng ký nên được tùy ý Sao Lưu", , "Thông báo")
            Else
                ManHinhMatKhau.ShowDialog()
                Dim matkhau As String = ManHinhMatKhau.str
                If matkhau = "" Then
                    Exit Sub
                ElseIf kiemtra(TenNguoiDangNhap, matkhau) = False Then
                    MsgBox("Mật khẩu không chính xác")
                    Exit Sub
                End If
            End If
            SuachuaTruocKhiBackUp()
            ManHinhSaoLuu.ShowDialog()
            Ketnoi.Close()
            dtoNK.User = TenNguoiDangNhap
            dtoNK.Ngay = Date.Now.Date
            dtoNK.Gio = Date.Now
            dtoNK.Tacvu = "Thoát phần mềm "
            daoNK.Them(dtoNK)
            End
        ElseIf msg = MsgBoxResult.No Then
            Ketnoi.Close()

            dtoNK.User = TenNguoiDangNhap
            dtoNK.Ngay = Date.Now.Date
            dtoNK.Gio = Date.Now
            dtoNK.Tacvu = "Thoát phần mềm "
            daoNK.Them(dtoNK)
            End
        Else
            e.Cancel = True
        End If
    End Sub
    Private Sub ManHinhChinh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtoNK.User = TenNguoiDangNhap
        dtoNK.Ngay = Date.Now.Date
        dtoNK.Gio = Date.Now
        dtoNK.Tacvu = "Đăng nhập thành công "
        daoNK.Them(dtoNK)
        'xuat default
        Ketnoi.ResetState()
        SetUpListViewColumns()
        LoadListView()
        Me.SplitContainer1.Panel1Collapsed = False
        Button10.Text = Date.Now.Date
        AnMoAll(SplitContainer3.Panel1)
        ToolStripButton26.Text = ToolStripButton26.Text & vbNewLine & vbNewLine & TenNguoiDangNhap
        'DocFileQuyen(Application.StartupPath & "\FileDefault\FlieLuu\" & QuyenNguoiDangNhap & "HT.txt")
        DocFileBut(Application.StartupPath & "\FileDefault\FlieLuu\" & QuyenNguoiDangNhap & "MHChinhHT.txt")
        Try
            SuachuaTruocKhiBackUp()
            Dim dd As String = Application.StartupPath & "\SaoLuuDuLieuTuDong\" & Date.Now.Day & "-" & Date.Now.Month & "-" & Date.Now.Year & ".mdb"
            Directory.CreateDirectory(Application.StartupPath & "\SaoLuuDuLieuTuDong")
            File.Copy(DocFile(Application.StartupPath & "\Connfig.dat"), dd)
        Catch ex As Exception
        End Try
        'If QuyenNguoiDangNhap = ChuoiNV Or QuyenNguoiDangNhap = ChuoiQL Then
        '    ToggleVisible()
        'End If
        tslDD.Text = "CSDL: " & duongdanCSDL
        'ToggleVisible1()
        'Me.MenuCSHoatDong_CCSoDo.Visible = False
    End Sub
    Private Sub SửaChửaDataBaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SửaChửaDataBaseToolStripMenuItem.Click
        CompactAccessDB()
    End Sub
    Public Shared Sub CompactAccessDB()
        Try
            If Ketnoi.State = ConnectionState.Open Then
                Ketnoi.Close()
            End If
            Dim abs As New AbstractDao
            If AbstractDao.Ket_noi.State = ConnectionState.Open Then
                AbstractDao.Ket_noi.Close()
            End If

            Dim indexPath As Integer = duongdanCSDL.LastIndexOf("\")
            Dim path As String = Microsoft.VisualBasic.Strings.Left(duongdanCSDL, indexPath)
            Dim jro As JRO.JetEngine
            'tạo đối tượng JetEngine
            jro = New JRO.JetEngine
            'gọi hàm CompactDatabase để dọn dẹp database
            jro.CompactDatabase("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & duongdanCSDL & ";Persist Security Info=True;Jet OLEDB:Database Password=MinhLam20", _
                    "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & path & "\ncc.mdb;Jet OLEDB:Engine Type=5;Jet OLEDB:Database Password=MinhLam20")
            File.Delete(duongdanCSDL)
            File.Copy(path & "\ncc.mdb", duongdanCSDL)
            File.Delete(path & "\ncc.mdb")
            Ketnoi.Open()
            MsgBox("Sửa chửa DataBase thành công", , "Thông báo")
        Catch ex As Exception
            MsgBox("Sửa chửa DataBase thất bại", , "Thông báo")
        End Try
    End Sub
    Public Shared Sub SuachuaTruocKhiBackUp()
        Try
            If Ketnoi.State = ConnectionState.Open Then
                Ketnoi.Close()
            End If
            Dim abs As New AbstractDao
            If AbstractDao.Ket_noi.State = ConnectionState.Open Then
                AbstractDao.Ket_noi.Close()
            End If

            Dim indexPath As Integer = duongdanCSDL.LastIndexOf("\")
            Dim path As String = Microsoft.VisualBasic.Strings.Left(duongdanCSDL, indexPath)
            Dim jro As JRO.JetEngine
            'tạo đối tượng JetEngine
            jro = New JRO.JetEngine
            'gọi hàm CompactDatabase để dọn dẹp database
            jro.CompactDatabase("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & duongdanCSDL & ";Persist Security Info=True;Jet OLEDB:Database Password=MinhLam20", _
                    "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & path & "\ncc.mdb;Jet OLEDB:Engine Type=5;Jet OLEDB:Database Password=MinhLam20")
            File.Delete(duongdanCSDL)
            File.Copy(path & "\ncc.mdb", duongdanCSDL)
            File.Delete(path & "\ncc.mdb")
            Ketnoi.Open()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub MenuQLDL_Thoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuQLDL_Thoat.Click
        Dim msg As MsgBoxResult = MsgBox("Bạn có muốn sao lưu trước khi thoát không?" & vbNewLine & "Yes:Sao lưu dữ liệu trước ,sau đó thoát" & vbNewLine & "No:Thoát ngay bây giờ" & vbNewLine & "Cancel: Trở lại màn hình, huỷ thoát", MsgBoxStyle.YesNoCancel, "Thông báo")
        If msg = MsgBoxResult.Yes Then
            ManHinhSaoLuu.Owner = Me
            ManHinhSaoLuu.Show()
            Ketnoi.Close()
            End
        ElseIf msg = MsgBoxResult.No Then
            Ketnoi.Close()
            End
        Else
        End If
    End Sub

    Private Sub ToolStrip3_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStrip3.MouseLeave, ToolStrip4.MouseLeave, ToolStrip5.MouseLeave, ToolStrip7.MouseLeave, ToolStrip8.MouseLeave, ToolStrip9.MouseLeave, ToolStrip11.MouseLeave, ToolStrip12.MouseLeave, ToolStrip13.MouseLeave, ToolStrip14.MouseLeave, ToolStrip15.MouseLeave, ToolStrip17.MouseLeave, ToolStrip18.MouseLeave, ToolStrip19.MouseLeave
        sender.BackColor = Color.White
    End Sub
    Private Sub ToolStrip3_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ToolStrip3.MouseMove, ToolStrip4.MouseMove, ToolStrip5.MouseMove, ToolStrip7.MouseMove, ToolStrip8.MouseMove, ToolStrip9.MouseMove, ToolStrip11.MouseMove, ToolStrip12.MouseMove, ToolStrip13.MouseMove, ToolStrip14.MouseMove, ToolStrip15.MouseMove, ToolStrip17.MouseMove, ToolStrip18.MouseMove, ToolStrip19.MouseMove
        sender.BackColor = Color.Gold
        sender.Cursor = Cursors.Hand
    End Sub
    Private Sub TảiXuốngMớiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TảiXuốngMớiToolStripMenuItem.Click
        FChay.Kieu = 1
        FChay.Show()
    End Sub
    Private Sub TảiXuốngTấtCảToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TảiXuốngTấtCảToolStripMenuItem.Click
        FChay.Kieu = 2
        FChay.Show()
    End Sub

    Private Sub QLDLMayChamToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QLDLMayChamToolStripMenuItem.Click, ToolStrip17.Click, Button12.Click
        ManhinhUSB.Owner = Me
        ManhinhUSB.Show()
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click, NhânViênĐiLàmToolStripMenuItem.Click
        ManHinhNVDiLam.Owner = Me
        ManHinhNVDiLam.Show()
    End Sub

    Private Sub CậpNhậtBảnQuyềnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CậpNhậtBảnQuyềnToolStripMenuItem.Click
        FPhienBan.ShowDialog()
    End Sub

    Private Sub ManHinhChinh_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        KTPBPD()
    End Sub

    Private Sub MenuQLNDung_QLBoPhan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuQLNDung_QLBoPhan.Click, ToolStripButton11.Click, ToolStrip7.Click
        ManhinhQLBophan.Owner = Me
        ManhinhQLBophan.Show()
    End Sub

    Private Sub NhậpDửLiệuChấmCôngToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NhậpDửLiệuChấmCôngToolStripMenuItem.Click, ToolStripButton20.Click, ToolStrip18.Click, Button13.Click
        FNhapDL.Owner = Me
        FNhapDL.Show()
    End Sub

    Private Sub XuấtDửLiệuChấmCôngToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XuấtDửLiệuChấmCôngToolStripMenuItem.Click, ToolStrip19.Click, ToolStripButton21.Click, Button11.Click
        FXuatDL.Owner = Me
        FXuatDL.Show()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

    End Sub

    Private Sub ToolStrip3_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip3.ItemClicked

    End Sub

    Private Sub ToolStrip11_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip11.ItemClicked

    End Sub

    Private Sub XóaDữLiệuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XóaDữLiệuToolStripMenuItem.Click
        ManHinhXoaDLCC.ShowDialog()

    End Sub


    Private Sub ToolStripButton26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton26.Click
        Process.Start("http://metronsoft.com")
    End Sub


    Private Sub T58real_OnReceiveGLogData(ByVal sender As System.Object, ByVal e As AxFKRealSvrLib._DFKRealSvrEvents_OnReceiveGLogDataEvent)
        Dim lvt As ListViewItem

        lvt = ListView1.Items.Add(ListView1.Items.Count + 1)

        lvt.SubItems.AddRange(New String() {e.anSEnrollNumber, e.anSEnrollNumber, e.anLogDate, IIf(e.anInOutMode = 0, "Vào", "Ra"), 1})

    End Sub
#Region "Tính lương mới 4.5 L" 'Ngay 02/06/2011
    Private Sub TsbTinhLuong_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsbTinhLuong.Click
        Try
            ManHinhMatKhau.ShowDialog()
            Dim matkhau As String = ManHinhMatKhau.str
            If matkhau = "" Then
                Exit Sub
            ElseIf kiemtra(TenNguoiDangNhap, matkhau) = False Then
                MsgBox("Mật khẩu không chính xác")
                Exit Sub
            End If
            If QuyenNguoiDangNhap <> ChuoiTQL Then
                MsgBox("Chỉ có tổng quản lý mới có quyền này", , "Thông báo")
                Exit Sub
            End If
            ManhinhLuong.Owner = Me
            ManhinhLuong.Show()
        Catch ex As Exception

        End Try
    End Sub
#End Region


    Private Sub tsmBanQuyen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmBanQuyen.Click
        Try
            frmThongTinBanQuyen.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

   
    
   
    Private Sub TaoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TaoToolStripMenuItem.Click
        Dim sql As String = "ALTER TABLE Bangluong ADD TienComTrua int,SuatAnTrua int"
    End Sub
End Class
