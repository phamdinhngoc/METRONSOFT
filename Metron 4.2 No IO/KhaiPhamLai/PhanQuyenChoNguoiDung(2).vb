Imports System.IO
Public Class PhanQuyenChoNguoiDung_2_
    Dim bus As New QuyenBus(DTOKetnoi, False)
    Dim dto As New Quyendto
    Dim busChitiet As New QuyenChiTietBus(DTOKetnoi, False)
    Dim dtochitiet As New QuyenChiTietdto
    Dim busnd As New NguoidungBus(DTOKetnoi, False)
    Dim dtond As New Nguoidungdto
#Region "HoTro"
    Private Function DocFileBut(ByVal duongdanFile As String) As String
        Dim file As FileStream
        Dim reader As StreamReader
        Dim a As String = ""
        Try
            file = New FileStream(duongdanFile, FileMode.Open)
            reader = New StreamReader(file)
            While (reader.EndOfStream = False)
                kiemtrabut(reader.ReadLine)
            End While
            reader.Close()
            file.Close()
        Catch EX As Exception
            Return ""
        End Try
        Return a
    End Function
    Private Function KiemTraForm(ByVal str As String) As Form
        Select Case str
            Case "Frmnhanvien"
                Return Frmnhanvien
            Case "ManHinhDangKy"
                Return ManHinhDangKy
            Case "ManHinhMatKhau"
                Return ManHinhMatKhau
            Case "ManHinhNhatKy"
                Return ManHinhNhatKy
            Case "ManHinhPhucHoi"
                Return ManHinhPhucHoi
            Case "ManHinhSaoLuu"
                Return ManHinhSaoLuu
            Case "ManHinhSuaMatKhau"
                Return ManHinhSuaMatKhau
            Case "ManHinhThietLapMCC"
                Return ManHinhThietLapMCC
            Case "ManHinhThongTinNguoidung"
                Return ManHinhThongTinNguoidung
            Case "ManHinhTimKiemNhanViên"
                Return ManHinhTimKiemNhanViên
            Case "ManHinhTroDuLieu"
                Return ManHinhTroDuLieu
            Case "ManHinhXemNguoidung"
                Return ManHinhXemNguoidung
            Case "PhanQuyenChoNguoidung"
                Return PhanQuyenChoNguoidung
            Case "ManHinhCA"
                Return ManHinhCAKhac
            Case "ManHinhCaTamThoi"
                Return ManHinhCaTamThoi
            Case "ManHinhEpCaTD"
                Return ManHinhEpCaTD
            Case "ManhinhUSB"
                Return ManhinhUSB
            Case "ManHinhNhanVienNghiVanTinhCong"
                Return ManHinhNhanVienNghiVanTinhCong
            Case "FNhapDL"
                Return FNhapDL
            Case "FXuatDL"
                Return FXuatDL
            Case "ManhinhQLBophan"
                Return ManhinhQLBophan
            Case "ManhinhChucvu"
                Return ManhinhChucvu
            Case "Manhinhngayle"
                Return Manhinhngayle
            Case "ManHinhBaoCao"
                Return ManHinhBaoCao
            Case "ManHinhQlNVtrenMCC"
                Return ManHinhQlNVtrenMCC
            Case "ManHinhTaiDulieu"
                Return ManHinhTaiDulieu
            Case "FChay"
                Return FChay
            Case "ManHinhQlNVtrenMCC"
                Return ManHinhQlNVtrenMCC
            Case "ManHinhNVDiLam"
                Return ManHinhNVDiLam
            Case Else
                Return SplashScreen
        End Select
    End Function
    Public Sub addTree(ByVal Group As MenuStrip)
        Dim node As New TreeNode
        Dim node1 As New TreeNode
        Dim CTr As New ToolStripMenuItem
        For Each CTr In Group.Items
            node = TreeView1.Nodes.Add(CTr.Name, CTr.Text)
            node.Tag = CTr.Tag
            If CTr.DropDownItems.Count > 0 Then
                Dim ctrm As ToolStripItem
                For Each ctrm In CTr.DropDownItems
                    node1 = node.Nodes.Add(ctrm.Name, ctrm.Text)
                    node1.Tag = ctrm.Tag
                Next
            End If
        Next
    End Sub
    Private Sub kiemtrabut(ByVal str As String)
        For i As Integer = 0 To TreeView1.Nodes.Count - 1
            If TreeView1.Nodes(i).Name = str Then
                TreeView1.Nodes(i).ImageIndex = 1
                TreeView1.Nodes(i).SelectedImageIndex = 1
                Exit Sub
            End If
            For j As Integer = 0 To TreeView1.Nodes(i).Nodes.Count - 1
                If TreeView1.Nodes(i).Nodes(j).Name = str Then
                    TreeView1.Nodes(i).Nodes(j).ImageIndex = 1
                    TreeView1.Nodes(i).Nodes(j).SelectedImageIndex = 1
                    Exit Sub
                End If
            Next
        Next
    End Sub
    Private Sub checkTreetrue()
        For i As Integer = 0 To TreeView1.Nodes.Count - 1
            TreeView1.Nodes(i).ImageIndex = 0
            TreeView1.Nodes(i).SelectedImageIndex = 0
            For j As Integer = 0 To TreeView1.Nodes(i).Nodes.Count - 1
                TreeView1.Nodes(i).Nodes(j).ImageIndex = 0
                TreeView1.Nodes(i).Nodes(j).SelectedImageIndex = 0
            Next
        Next
    End Sub
    Private Sub combo()
        Dim table As DataTable = bus.LayBangTable()
        ComboBox1.DisplayMember = "tenquyen"
        ComboBox1.ValueMember = "maquyen"
        ComboBox1.DataSource = table
        ComboBox1.SelectedValue = 3
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            checkTreetrue()
            DocFileBut(Application.StartupPath & "\FileDefault\FlieLuu\" & ComboBox1.Text & "MHChinhHT.txt")
            Dim ctr As Control = KiemTraForm(TreeView1.SelectedNode.Tag)
            ListView1.Items.Clear()
            cacNutNhan1(ctr)
        Catch ex As Exception
        End Try
    End Sub

#End Region
#Region "Form"
    Private Sub PhanQuyenChoNguoiDung_2__Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        ManHinhChinh.CửaSổHoạtĐộngToolStripMenuItem.DropDownItems.Remove(ManHinhChinh.CửaSổHoạtĐộngToolStripMenuItem.DropDownItems(Me.Name))
        MsgBox("Bạn nên tắt chương trình rồi bật lại để chương trình nạp thông số mới", , "Thông báo")
    End Sub
    Private Sub PhanQuyenChoNguoiDung_2__Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim busQ As New QuyenBus(DTOKetnoi, False)
            Dim ma As Integer = busQ.MaQuyen(QuyenNguoiDangNhap)
            cacNutNhan(Me, ma, Me.Name)
            ListView1.Columns.Add("Tên Xử Lý", 100)
            ListView1.Columns.Add("Ẩn Xử Lý")
            ListView1.Columns.Add("Ghi Chú", 0)
            ListView1.Columns.Add("Chú Thích Cho Xử Lý", 150)
            ListView1.View = View.Details
            ManHinhChinh.CửaSổHoạtĐộngToolStripMenuItem.DropDownItems.Add("Giao Diện Phân Quyền Người Dùng").Name = Me.Name
        Catch ex As Exception
        End Try
        combo()
        addTree(ManHinhChinh.MenuStrip1)
    End Sub
#End Region
#Region "Context menu"
    Private Sub KhôngSửDụngToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KhôngSửDụngToolStripMenuItem.Click
        Try
            TreeView1.SelectedNode.ImageIndex = 1
            TreeView1.SelectedNode.SelectedImageIndex = 1
            If TreeView1.SelectedNode.Nodes.Count > 0 Then
                For i As Integer = 0 To TreeView1.SelectedNode.Nodes.Count - 1
                    TreeView1.SelectedNode.Nodes(i).ImageIndex = 1
                    TreeView1.SelectedNode.Nodes(i).SelectedImageIndex = 1
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub SửDụngToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SửDụngToolStripMenuItem.Click
        Try
            TreeView1.SelectedNode.ImageIndex = 0
            TreeView1.SelectedNode.SelectedImageIndex = 0
            If TreeView1.SelectedNode.Nodes.Count > 0 Then
                For i As Integer = 0 To TreeView1.SelectedNode.Nodes.Count - 1
                    TreeView1.SelectedNode.Nodes(i).ImageIndex = 0
                    TreeView1.SelectedNode.Nodes(i).SelectedImageIndex = 0
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
#End Region
#Region "Tree View"
    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        Dim ctr As Control = KiemTraForm(TreeView1.SelectedNode.Tag)
        ListView1.Items.Clear()
        cacNutNhan1(ctr)
    End Sub
    Private Sub themListView(ByVal text As String, ByVal an As Boolean, ByVal Name As String, Optional ByVal ChuThich As String = "")
        Dim lvItem As ListViewItem
        lvItem = ListView1.Items.Add(text)
        If an Then
            lvItem.BackColor = Color.White
        Else
            lvItem.BackColor = Color.Red
        End If
        lvItem.SubItems.AddRange(New String() {an, Name, ChuThich})
    End Sub
    Private Sub cacNutNhan1(ByVal Con As Control)
        Try
            Dim ctr As Control
            For Each ctr In Con.Controls
                If TypeOf ctr Is ToolStrip Then
                    Dim tool As ToolStrip = ctr
                    For i As Integer = 0 To tool.Items.Count - 1
                        If busChitiet.KiemTraCo(ComboBox1.SelectedValue, TreeView1.SelectedNode.Tag, tool.Items(i).Name) Then
                            themListView(tool.Items(i).Text, False, tool.Items(i).Name, tool.Items(i).Tag)
                        Else
                            themListView(tool.Items(i).Text, True, tool.Items(i).Name, tool.Items(i).Tag)
                        End If
                    Next
                ElseIf TypeOf ctr Is Button Then
                    Dim but As Button = ctr
                    If busChitiet.KiemTraCo(ComboBox1.SelectedValue, TreeView1.SelectedNode.Tag, but.Name) Then
                        themListView(but.Text, False, but.Name, but.Tag)
                    Else
                        themListView(but.Text, True, but.Name, but.Tag)
                    End If
                End If
                If ctr.Controls.Count > 0 Then
                    cacNutNhan1(ctr)
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub
#End Region
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
    Private Function TaoFileBut(ByVal duongdanFile As String) As String
        Dim file As FileStream
        Dim writer As StreamWriter
        Try
            file = New FileStream(duongdanFile, FileMode.CreateNew)
            writer = New StreamWriter(file)
            For i As Integer = 0 To TreeView1.Nodes.Count - 1
                If TreeView1.Nodes(i).ImageIndex = 1 Then
                    writer.WriteLine(TreeView1.Nodes(i).Name)
                End If
                For j As Integer = 0 To TreeView1.Nodes(i).Nodes.Count - 1
                    If TreeView1.Nodes(i).Nodes(j).ImageIndex = 1 Then
                        writer.WriteLine(TreeView1.Nodes(i).Nodes(j).Name)
                    End If
                Next
            Next
            writer.Close()
            file.Close()
        Catch EX As Exception
            Return (EX.Message)
        End Try
        Return "1"
    End Function
    Private Function TaoFileButNhanVien(ByVal duongdanFile As String) As String
        Dim file As FileStream
        Dim writer As StreamWriter
        Try
            file = New FileStream(duongdanFile, FileMode.CreateNew)
            writer = New StreamWriter(file)
            writer.WriteLine("MenuQLDL_SaoLuuDL")
            writer.WriteLine("MenuQLDL_PhucHoiDL")
            writer.WriteLine("ToolStripSeparator5")
            writer.WriteLine("MenuQLDL_TroDL")
            writer.WriteLine("QLDLMayChamToolStripMenuItem")
            writer.WriteLine("NhậpDửLiệuChấmCôngToolStripMenuItem")
            writer.WriteLine("XuấtDửLiệuChấmCôngToolStripMenuItem")
            writer.WriteLine("ToolStripSeparator14")
            writer.WriteLine("MenuQLHS")
            writer.WriteLine("MenuQLHS_TimKiemNV")
            writer.WriteLine("MenuQLNDung_QLBoPhan")
            writer.WriteLine("MenuQLNDung_QLChucVu")
            writer.WriteLine("MenuQLNDung_QLNVien")
            writer.WriteLine("ToolStripSeparator6")
            writer.WriteLine("MenuQLNDung_TLCa")
            writer.WriteLine("MenuQLNDung_TLLichLV")
            writer.WriteLine("MenuQLNDung_TLLichNV")
            writer.WriteLine("MenuQLNDung_NgayNghi")
            writer.WriteLine("ToolStripMenuItem1")
            writer.WriteLine("ToolStripSeparator7")
            writer.WriteLine("MenuQLMay_TaiDLMayTinh_MCC")
            writer.WriteLine("MenuQLMay_KTNDungMCC")
            writer.WriteLine("ToolStripSeparator9")
            writer.WriteLine("MenuQLMay_MenuQLMCC")
            writer.WriteLine("ToolStripSeparator11")
            writer.WriteLine("MenuQLTaiKhoan_XemNKySDung")
            writer.WriteLine("MenuQLTaiKhoan_XemTatCaTK")
            writer.WriteLine("ToolStripSeparator12")
            writer.WriteLine("PhânQuyềnNgườiDùngToolStripMenuItem")
            writer.WriteLine("MenuQLTaiKhoan_TaoTK")
            writer.WriteLine("ToolViewToolStripMenuItem")
            writer.WriteLine("MenuCSHoatDong_CCBenTrai")
            writer.WriteLine("ToolStripSeparator3")
            writer.WriteLine("ToolStripSeparator4")
            writer.WriteLine("CửaSổCơBảnToolStripMenuItem")
            writer.WriteLine("CửaSổNângCaoToolStripMenuItem")
            writer.Close()
            file.Close()
        Catch EX As Exception
            Return (EX.Message)
        End Try
        Return "1"
    End Function
    Private Function TaoFileButquanly(ByVal duongdanFile As String) As String
        Dim file As FileStream
        Dim writer As StreamWriter
        Try
            file = New FileStream(duongdanFile, FileMode.CreateNew)
            writer = New StreamWriter(file)
            writer.WriteLine("MenuQLDL_PhucHoiDL")
            writer.WriteLine("MenuQLDL_TroDL")
            writer.WriteLine("ToolStripSeparator9")
            writer.WriteLine("MenuQLMay_MenuQLMCC")
            writer.WriteLine("MenuQLTaiKhoan_XemTatCaTK")
            writer.WriteLine("ToolStripSeparator12")
            writer.WriteLine("PhânQuyềnNgườiDùngToolStripMenuItem")
            writer.WriteLine("MenuQLTaiKhoan_TaoTK")
            writer.Close()
            file.Close()
        Catch EX As Exception
            Return (EX.Message)
        End Try
        Return "1"
    End Function
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim duongdan As String = ""
        'If ComboBox1.SelectedValue = 3 Then
        '    MsgBox("Phân quyền Tổng Quản Lý KHÔNG thể thây đổi", , "Thông báo")
        '    Exit Sub
        'End If
        'If ComboBox1.SelectedValue = 2 Then
        '    MsgBox("Phân quyền Quản Lý KHÔNG thể thây đổi", , "Thông báo")
        '    Exit Sub
        'End If
        'If ComboBox1.SelectedValue = 1 Then
        '    MsgBox("Phân quyền Nhân viên KHÔNG thể thây đổi", , "Thông báo")
        '    Exit Sub
        'End If
        '************
        duongdan = Application.StartupPath & "\FileDefault\FlieLuu\" & ComboBox1.Text & "MHChinhHT.txt"
        Try
            File.Delete(duongdan)
        Catch ex As Exception
        End Try
        TaoFileBut(duongdan)
        '************
        MsgBox("Đã Lưu Phân quyền", , "Thông báo")
    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        If ListView1.SelectedItems.Count <= 0 Then Exit Sub
        If UCase(ListView1.SelectedItems(0).SubItems(1).Text) = UCase("True") Then
            ListView1.SelectedItems(0).SubItems(1).Text = "False"
            ListView1.SelectedItems(0).BackColor = Color.Red
            If ComboBox1.SelectedValue = 3 Then
                MsgBox("Không Được Thây Đổi Phân Quyền Của Tổng Quản Lý ", , "Thông báo")
                ListView1.SelectedItems(0).SubItems(1).Text = "True"
                ListView1.SelectedItems(0).BackColor = Color.White
                Exit Sub
            End If
            themArray()
        Else
            ListView1.SelectedItems(0).SubItems(1).Text = "True"
            ListView1.SelectedItems(0).BackColor = Color.White
            XoaArray()
        End If
    End Sub
    Private Sub XoaArray()
        busChitiet.Xoa(ComboBox1.SelectedValue, TreeView1.SelectedNode.Tag, ListView1.SelectedItems(0).SubItems(2).Text)
    End Sub
    Private Sub themArray()
        Dim dtoct As New QuyenChiTietdto
        dtoct.Quyen = ComboBox1.SelectedValue
        dtoct.TenButon = ListView1.SelectedItems(0).SubItems(2).Text
        dtoct.TenForm = TreeView1.SelectedNode.Tag
        busChitiet.Them(dtoct)
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub
    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        If ListView1.SelectedItems.Count <= 0 Then Exit Sub
        For i As Integer = 0 To ListView1.SelectedItems.Count - 1
            If UCase(ListView1.SelectedItems(i).SubItems(1).Text) = UCase("True") Then
                'ListView1.SelectedItems(i).SubItems(1).Text = "False"
                'ListView1.SelectedItems(i).BackColor = Color.Red
                'If ComboBox1.SelectedValue = 3 Then
                '    MsgBox("Không Được Thây Đổi Phân Quyền Của Tổng Quản Lý ")
                '    ListView1.SelectedItems(i).SubItems(1).Text = "True"
                '    ListView1.SelectedItems(i).BackColor = Color.White
                '    Exit Sub
                'End If
                'themArray()
            Else
                ListView1.SelectedItems(i).SubItems(1).Text = "True"
                ListView1.SelectedItems(i).BackColor = Color.White
                XoaArray()
            End If
        Next
    End Sub
    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        If ListView1.SelectedItems.Count <= 0 Then Exit Sub
        For i As Integer = 0 To ListView1.SelectedItems.Count - 1
            If UCase(ListView1.SelectedItems(i).SubItems(1).Text) = UCase("True") Then
                ListView1.SelectedItems(i).SubItems(1).Text = "False"
                ListView1.SelectedItems(i).BackColor = Color.Red
                If ComboBox1.SelectedValue = 3 Then
                    MsgBox("Không Được Thây Đổi Phân Quyền Của Tổng Quản Lý ", , "Thông báo")
                    ListView1.SelectedItems(i).SubItems(1).Text = "True"
                    ListView1.SelectedItems(i).BackColor = Color.White
                    Exit Sub
                End If
                themArray()
            Else
                'ListView1.SelectedItems(i).SubItems(1).Text = "True"
                'ListView1.SelectedItems(i).BackColor = Color.White
                'XoaArray()
            End If
        Next
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim a As MsgBoxResult = MsgBox("Bạn cần gì?" & vbNewLine & "Yes: Tạo Quyền Mới " & vbNewLine & "No: Xóa Quyền đang chọn" & vbNewLine & "Cancel: Khộng làm gì cả", MsgBoxStyle.YesNoCancel, "Thông Báo ")
        If a = MsgBoxResult.Yes Then
            Dim TenQuyen As String = InputBox("Nhập Tên Quyền bạn muốn thêm", "Thông báo")
            If TenQuyen = "" Then Exit Sub
            dto.TenQuyen = TenQuyen
            bus.Them(dto)
            combo()
            ComboBox1.SelectedIndex = bus.LayBangTable.Rows.Count - 1
        ElseIf a = MsgBoxResult.No Then
            If MsgBox("Bạn có thực sự muốn xóa quyền này không ?", MsgBoxStyle.OkCancel, "Thông báo") = MsgBoxResult.Ok Then
                If ComboBox1.Text = ChuoiTQL Then
                    MsgBox("Không đươc xóa quyền tổng quản lý", , "Thông báo")
                    Exit Sub
                End If
                If ComboBox1.Text = ChuoiQL Then
                    MsgBox("Không đươc xóa Quyền quản lý", , "Thông báo")
                    Exit Sub
                End If
                If ComboBox1.Text = ChuoiNV Then
                    MsgBox("Không đươc xóa Nhân Viên", , "Thông báo")
                    Exit Sub
                End If
            End If
            If busnd.kiemtraquyen(ComboBox1.Text) > 0 Then
                MsgBox(" Quyền này có nguời sử dụng Không thể xóa ", , "Thông báo")
                Exit Sub
            End If
            bus.Xoa(ComboBox1.SelectedValue)
        Else
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

    End Sub
End Class