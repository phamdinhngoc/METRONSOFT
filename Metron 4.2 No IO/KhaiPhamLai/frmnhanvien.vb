
Public Class Frmnhanvien
    Dim bus As New nhanvienBus(DTOKetnoi, False)
    Dim dto As New nhanviendto
    Public Trangthai As String = ""
    'Public str As String = ""
    Dim busChucvu As New chucvuBus(DTOKetnoi, False)
    Dim dtochucvu As New chucvudto
    Dim busdonvi As New donviBus(DTOKetnoi, False)
    Dim dtodonvi As New donvidto
#Region "Các Hàm hổ trợ"
    Private Function NapdulieuDTO(ByVal macc As Integer) As nhanviendto
        Dim dto As New nhanviendto
        dto = bus.LayBangDTo(macc)
        Return dto
    End Function
    Private Sub AllColumns(Optional ByVal Hien As Boolean = True)
        Dim j As Integer = 0
        If Not Hien Then
            bttBoPhan.Columns(0).Visible = True
            j = 1
        End If
        For i As Integer = j To bttBoPhan.Columns.Count - 1
            bttBoPhan.Columns(i).Visible = Hien
        Next
    End Sub
    Private Sub XoaTrang(ByVal Group As Control)
        Dim ValControl As New Control
        For Each ValControl In Group.Controls
            If ValControl.Tag = "1" Then
                If Microsoft.VisualBasic.Strings.Left(ValControl.Name, 3) = "cbo" Then
                    Dim cbo As ComboBox = ValControl
                    cbo.SelectedValue = 0
                Else
                    ValControl.Text = ""
                End If
            End If
        Next
    End Sub
    Private Sub AnMo(ByVal a As Boolean, ByVal Group As Control)
        Dim ValControl As New Control
        For Each ValControl In Group.Controls
            If ValControl.Tag = "1" Then
                ValControl.Enabled = a
            End If
        Next
        Button1.Enabled = a
        Button2.Enabled = a
    End Sub
    Private Function Hienthidulieu(ByVal a As Integer, ByVal Group As Control, Optional ByVal TT As String = "sua") As Integer
        Dim ValControl As New Control
        Dim b As Integer = 0
        Dim loi As String = ""
        If a = 1 Then
            For Each ValControl In Group.Controls
                If ValControl.Tag = "1" Then
                    If ValControl.Name = "cboChucvu" Then
                        Dim cbo As ComboBox = ValControl
                        cbo.SelectedValue = dto.HoTro(UCase(Mid(cbo.Name, 4)))
                    Else
                        ValControl.Text = dto.HoTro(UCase(Mid(ValControl.Name, 4)))
                    End If
                End If
            Next
        Else
            For Each ValControl In Group.Controls
                If ValControl.Tag = "1" Then
                    If ValControl.Name = "cboChucvu" Then
                        Dim cbo As ComboBox = ValControl
                        loi = dto.HoTro(UCase(Mid(cbo.Name, 4)), cbo.SelectedValue)
                    Else
                        loi = dto.HoTro(UCase(Mid(ValControl.Name, 4)), ValControl.Text)
                    End If
                    If loi <> "" Then
                        ValControl.Focus()
                        b = 1 'có loi
                    End If
                    ErrorProvider1.SetError(ValControl, loi)
                End If
            Next
        End If
        Return b
    End Function
    Dim str As String = ""
    Private Function DuyetCayDK(ByVal tvRoot As TreeNode) As String
        Try

            For i As Integer = 0 To tvRoot.Nodes.Count - 1
                If tvRoot.Nodes(i).Nodes.Count > 0 Then
                    DuyetCayDK(tvRoot.Nodes(i))
                End If
                str = str & " or donvi= " & tvRoot.Nodes(i).Name
            Next
            Return str
        Catch ex As Exception
            Return ""
        End Try

    End Function
#End Region
#Region "TreeView"
    Public Sub cay()
        TreeView1.Nodes.Clear()
        Dim tvRoot As TreeNode
        dtodonvi = busdonvi.LayBangDTo(1)
        tvRoot = Me.TreeView1.Nodes.Add(dtodonvi.MaDV, dtodonvi.TenDV)
        TaoCay(tvRoot, 1)
        TreeView1.ExpandAll()
    End Sub
    Private Sub TaoCay(ByVal tvRoot As TreeNode, Optional ByVal nhanh As Integer = 1)
        Dim cay As DataTable = busdonvi.LayBangTableTheoNhanh(nhanh)
        Dim tvNode As TreeNode
        If cay.Rows.Count <= 0 Then Exit Sub
        For i As Integer = 0 To cay.Rows.Count - 1
            tvNode = tvRoot.Nodes.Add(cay.Rows(i)("madv"), cay.Rows(i)("tendv"), 1, 0)
            TaoCay(tvNode, cay.Rows(i)("madv"))
        Next
    End Sub
    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect

        'Dim data As DataTable = bus.LayBangTabletheodonvi(TreeView1.SelectedNode.Name)
        'If data.Rows.Count <= 0 Then
        '    ThemNhanVien()
        '    TreeView1.Enabled = True
        '    bttBoPhan.Enabled = True
        '    ToolStripButton12.Enabled = False
        'Else
        '    ToolStripButton12.Enabled = True
        'End If
        'bttBoPhan.DataSource = data
        'TreeView1.Focus()
        ''AnMo(False, GroupBox1)
        'Me.thongtin.Text = "Tổng số nhân viên của bộ phận " & Me.TreeView1.SelectedNode.Text & " là: " & Me.bttBoPhan.RowCount
        Dim data As New System.Data.DataTable
        If Me.TreeView1.SelectedNode.Name = 1 Then
            Dim a As String = "SELECT Nhanvien.MaNV, Nhanvien.TenNV, Nhanvien.TenHT, chucvu.Chucvu, Donvi.TenDV, Nhanvien.CardNo, Nhanvien.Gioitinh, Nhanvien.Diachi, Nhanvien.CMND, Nhanvien.Ngayvaolam, Nhanvien.NVSP, Nhanvien.Quyen, Nhanvien.Ngaysinh FROM chucvu INNER JOIN (Donvi INNER JOIN Nhanvien ON Donvi.MaDV = Nhanvien.Donvi) ON chucvu.CVID = Nhanvien.Chucvu"
            data = bus.LayBangTableSQL(a)
        Else

            data = bus.LayBangTabletheodonvi(TreeView1.SelectedNode.Name)
        End If
        If data.Rows.Count <= 0 Then
            ThemNhanVien()
            TreeView1.Enabled = True
            bttBoPhan.Enabled = True
            ToolStripButton12.Enabled = False
        Else
            ToolStripButton12.Enabled = True
        End If
        bttBoPhan.DataSource = data
        TreeView1.Focus()
        'AnMo(False, GroupBox1)
        Me.thongtin.Text = "Tổng số nhân viên của bộ phận " & Me.TreeView1.SelectedNode.Text & " là: " & Me.bttBoPhan.RowCount

    End Sub
#End Region
#Region "Them xóa sửa Nhan Vien"
    Public Sub suanv()
        If TreeView1.Enabled Then
            AnMo(True, GroupBox1)
            Trangthai = "sua"
            TreeView1.Enabled = False
            TxtMaNV.Enabled = False
            TxtNVSP.Focus()
        Else
            MsgBox("Đang trạng thái : " & Trangthai, , "Thông báo")
        End If
    End Sub
    Private Sub ToolStripButton12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton12.Click
        suanv()
    End Sub
    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click
        ThemNhanVien()
        'ManHinhNhapNHANVIEN.ShowDialog()
    End Sub
    Private Sub ToolStripButton9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton9.Click
        If TxtMaNV.Text = "" Then
            If MsgBox("Bạn không thể ghi" & vbNewLine & "Ok:Thêm mới" & vbNewLine & "Cancel:Trở về", MsgBoxStyle.OkCancel, "Thông báo") = MsgBoxResult.Ok Then
                ThemNhanVien()
            End If
            Exit Sub
        End If
        ghiNhanVien()
    End Sub
    Private Sub ThemNhanVien()
        If TreeView1.Enabled Then
            XoaTrang(GroupBox1)
            TreeView1.Enabled = False
            bttBoPhan.Enabled = False
            AnMo(True, GroupBox1)
            dtpNgaysinh.Value = DateSerial(Date.Now.Year - 20, Date.Now.Month, Date.Now.Day)
            TxtDiachi.Text = "."
            TxtCMND.Text = "."
            TxtCardNo.Text = 0
            Trangthai = "them"
            cbogioitinh.Text = "nam"
            cboChucvu.SelectedIndex = 0
            TxtMaNV.Text = bus.mathem + 1
            TxtNVSP.Focus()
        Else
            MsgBox("Đang trạng thái : " & Trangthai, , "Thông báo")
        End If
    End Sub
    Private Function KiemtraXoaNV() As Boolean
        ToolStripProgressBar1.Maximum = 100
        Dim buscatd As New caTDBus(DTOKetnoi, False)
        Dim BusLichNV As New lichnvBus(DTOKetnoi, False)
        Dim buslichtam As New lichtamBus(DTOKetnoi, False)
        Dim busVaoRa As New VaoraBus(DTOKetnoi, False)
        Dim busNVBC As New NVBCBus(DTOKetnoi, False)
        Dim busnvvan As New nvvanBus(DTOKetnoi, False)
        Dim busnvnghi As New NVnghiphepBus(DTOKetnoi, False)
        If buscatd.LayBangTableTheonvId(dto.MaNV).Rows.Count > 0 Then
            MsgBox("Nhân viên này có ca tự động, không thể xóa", , "Thông báo")
            Return False
        End If
        ToolStripProgressBar1.Value = 10
        If BusLichNV.LayBangDTotheoManv(dto.MaNV).ID <> 0 Then
            MsgBox("Nhân viên này có Lịch làm việc, không thể xóa", , "Thông báo")
            Return False
        End If
        ToolStripProgressBar1.Value = 20
        If buslichtam.LayBangTableTheoNVid(dto.MaNV).Rows.Count > 0 Then
            MsgBox("Nhân viên này có Lịch làm việc, không thể xóa", , "Thông báo")
            Return False
        End If
        ToolStripProgressBar1.Value = 30
        If busVaoRa.LayBangTabletheoNVid(dto.MaNV).Rows.Count > 0 Then
            MsgBox("Nhân viên này có Vào ra, không thể xóa", , "Thông báo")
            Return False
        End If
        ToolStripProgressBar1.Value = 40
        If busNVBC.LayBangTabletheoNv(dto.MaNV).Rows.Count > 0 Then
            MsgBox("Nhân viên này có Nhân viên báo cáo, không thể xóa", , "Thông báo")
            Return False
        End If
        ToolStripProgressBar1.Value = 50
        If busnvvan.LayBangTabletheoNVid(dto.MaNV).Rows.Count > 0 Then
            MsgBox("Nhân viên này có lưu Dấu vân tay, không thể xóa", , "Thông báo")
            Return False
        End If
        ToolStripProgressBar1.Value = 60
        If busnvnghi.LayBangTabletheoNvid(dto.MaNV).Rows.Count > 0 Then
            MsgBox("Nhân viên này có trong Lịch nghỉ, không thể xóa", , "Thông báo")
            Return False
        End If
        ToolStripProgressBar1.Value = 70
        Return True
    End Function
    Private Sub XoaNhanVien()
        If TreeView1.Enabled Then
            If MsgBox("Bạn có muốn xóa nhân viên ?" & vbNewLine & " tên nhân viên: " & TxtTenNV.Text & vbNewLine & "Mã Chấm Công: " & TxtMaNV.Text, MsgBoxStyle.OkCancel, "Thông báo") = MsgBoxResult.Ok Then
                If KiemtraXoaNV() = False Then Exit Sub
                bus.Xoa(Val(TxtMaNV.Text))
                bttBoPhan.DataSource = bus.LayBangTabletheodonvi(TreeView1.SelectedNode.Name)
            End If
        End If
    End Sub
    Private Sub XóaNhânViênCóKiểmTraToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XóaNhânViênCóKiểmTraToolStripMenuItem.Click
        XoaNhanVien()
        bttBoPhan.Focus()
    End Sub
    Private Sub SuaQuyenNhanVien(ByVal Quyen As Integer)
        For i As Integer = 0 To bttBoPhan.SelectedRows.Count - 1
            dto = NapdulieuDTO(bttBoPhan.SelectedRows.Item(i).Cells("ColMaNV").Value)
            dto.Quyen = Quyen
            bus.sua(dto)
        Next
    End Sub
    Private Sub ghiNhanVien()
        Try
            Dim loi As String = ""
            If Hienthidulieu(2, GroupBox1, Trangthai) = 1 Then
                Exit Sub
            End If
            If TreeView1.Enabled = False And Trangthai = "them" Then
                Dim sql As String = ""
                If bus.LayBangTable(Val(TxtMaNV.Text)).Rows.Count > 0 Then
                    ErrorProvider1.SetError(TxtMaNV, "Trùng Khóa chính")
                    Exit Sub
                Else
                    ErrorProvider1.SetError(TxtMaNV, "")
                End If
                dto.Donvi = TreeView1.SelectedNode.Name
                bus.Them(dto)
                Trangthai = ""
                TreeView1.Enabled = True
                bttBoPhan.Enabled = True
                MsgBox("Thêm nhân viên hoàn thành ", , "Thông báo")
                'AnMo(False, Me)
            ElseIf TreeView1.Enabled = False Then
                bus.sua(dto)
                Trangthai = ""
                TreeView1.Enabled = True
                MsgBox("Sửa nhân viên hoàn thành ", , "Thông báo")
                'AnMo(False, Me)
            End If
        Catch ex As Exception
            MsgBox("Lổi xin bạn hay thử lại" & vbNewLine & "Bạn không thể sửa mã Chấm Công", , "Thông báo")
        End Try
        bttBoPhan.DataSource = bus.LayBangTabletheodonvi(TreeView1.SelectedNode.Name)
        AnMo(False, GroupBox1)
        bttBoPhan.Focus()
    End Sub
#End Region
#Region "Thêm xoá sửa đơn vị"
    Private Sub themDonvi()
        dtodonvi.TenDV = InputBox("Nhập tên phòng ban mới", "Thông báo")
        If dtodonvi.TenDV = "" Then
            Exit Sub
        End If
        dtodonvi.Nhanh = TreeView1.SelectedNode.Name
        busdonvi.Them(dtodonvi)
        TreeView1.Nodes.Clear()
        cay()
    End Sub
    Private Sub xoaDonvi()
        Try
            If TreeView1.SelectedNode.Nodes.Count > 0 Then
                MsgBox("Không thể xóa " & vbNewLine & "Vì Phòng ban : " & TreeView1.SelectedNode.Text & vbNewLine & "                   có đơn vị con" & vbNewLine & "Đơn vị chỉ xóa được khi không có đơn vị con và không có nhân viên", , "Thông báo")
                Exit Sub
            End If
            If bttBoPhan.Rows.Count > 0 Then
                Dim Msg As MsgBoxResult = MsgBox("Đơn vị này : " & TreeView1.SelectedNode.Text & vbNewLine & "                   có Nhân Viên" & vbNewLine & "Yes:Xoá Tất Cả Nhân Viên " & vbNewLine & "No:Chuyển Nhân Viên sang bộ phận khác" & vbNewLine & "Cancel:Trở về ban đầu ,Không xóa", MsgBoxStyle.YesNoCancel, "Thông báo")
                If Msg = MsgBoxResult.Yes Then
                    bus.Xoatheodonvi(TreeView1.SelectedNode.Name)
                ElseIf Msg = MsgBoxResult.No Then
                    frmTree.ShowDialog()
                Else
                End If
                Exit Sub
            End If
            If MsgBox("Bạn muốn xoá phòng ban :" & TreeView1.SelectedNode.Text, MsgBoxStyle.OkCancel, "Thông báo") = MsgBoxResult.Ok Then
                busdonvi.Xoa(TreeView1.SelectedNode.Name)
                TreeView1.Nodes.Clear()
                cay()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub suaDonvi()
        Try
            dtodonvi.TenDV = InputBox("Nhập tên phòng ban mới", "Thông báo", TreeView1.SelectedNode.Text)
            If dtodonvi.TenDV = "" Then
                Exit Sub
            End If
            dtodonvi.MaDV = TreeView1.SelectedNode.Name
            busdonvi.sua(dtodonvi)
            TreeView1.Nodes.Clear()
            cay()
            TreeView1.Focus()
        Catch ex As Exception
            MsgBox("Bạn chưa Chọn đơn vị muốn sửa")
        End Try
    End Sub
    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click, ToolStripButton19.Click
        Try
            Str = ""
            Dim a As String
            If Me.TreeView1.SelectedNode.Name = 1 Then
                a = "SELECT Nhanvien.MaNV, Nhanvien.TenNV, Nhanvien.TenHT, chucvu.Chucvu, Donvi.TenDV, Nhanvien.CardNo, Nhanvien.Gioitinh, Nhanvien.Diachi, Nhanvien.CMND, Nhanvien.Ngayvaolam, Nhanvien.NVSP, Nhanvien.Quyen, Nhanvien.Ngaysinh FROM chucvu INNER JOIN (Donvi INNER JOIN Nhanvien ON Donvi.MaDV = Nhanvien.Donvi) ON chucvu.CVID = Nhanvien.Chucvu"
            Else

                a = "SELECT Nhanvien.MaNV, Nhanvien.TenNV, Nhanvien.TenHT, chucvu.Chucvu, Donvi.TenDV, Nhanvien.CardNo, Nhanvien.Gioitinh, Nhanvien.Diachi, Nhanvien.CMND, Nhanvien.Ngayvaolam, Nhanvien.NVSP, Nhanvien.Quyen, Nhanvien.Ngaysinh FROM chucvu INNER JOIN (Donvi INNER JOIN Nhanvien ON Donvi.MaDV = Nhanvien.Donvi) ON chucvu.CVID = Nhanvien.Chucvu where donvi = " & TreeView1.SelectedNode.Name
                Dim str1 As String = DuyetCayDK(TreeView1.SelectedNode)
                a = a & str1
            End If

            bttBoPhan.DataSource = bus.LayBangTableSQL(a)

            Me.thongtin.Text = "Tổng số nhân viên của bộ phận " & Me.TreeView1.SelectedNode.Text & " là: " & Me.bttBoPhan.RowCount

        Catch ex As Exception

        End Try

    End Sub
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If TreeView1.Visible = False Then Exit Sub
        themDonvi()
        TxtMaNV.Focus()
        'Dim daoNK As New NhatkyDao
        'Dim dtoNK As New Nhatkydto
    End Sub
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        If TreeView1.Visible = False Then Exit Sub
        xoaDonvi()
    End Sub
    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        If TreeView1.Visible = False Then Exit Sub
        suaDonvi()
        TxtMaNV.Focus()
    End Sub
#End Region
#Region "Context menu"
#Region " Hiển Thị cột "
    Private Sub ContextMenuStrip1_Opened(ByVal sender As Object, ByVal e As System.EventArgs) Handles ContextMenuStrip1.Opened
        Dim M As System.Windows.Forms.ToolStripMenuItem
        Me.DanhSáchCộtToolStripMenuItem.DropDownItems.Clear()
        For i As Integer = 0 To bttBoPhan.ColumnCount - 1
            M = Me.DanhSáchCộtToolStripMenuItem.DropDownItems.Add(bttBoPhan.Columns(i).HeaderText)
            M.Name = bttBoPhan.Columns(i).Name
            M.Tag = i
            M.CheckOnClick = True
            M.Checked = bttBoPhan.Columns(i).Visible
        Next
    End Sub
    Private Sub ChiTiếtNhânViênToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChiTiếtNhânViênToolStripMenuItem.Click
        SplitContainer1.Panel2Collapsed = Not SplitContainer1.Panel2Collapsed
        ChiTiếtNhânViênToolStripMenuItem.Checked = Not ChiTiếtNhânViênToolStripMenuItem.Checked
        ToolStripButton7.Visible = Not ToolStripButton7.Visible
        ToolStripButton8.Visible = Not ToolStripButton8.Visible
        ToolStripButton9.Visible = Not ToolStripButton9.Visible
        ToolStripButton12.Visible = Not ToolStripButton12.Visible
    End Sub
    Private Sub HiểnThịTấtCảCộtToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HiểnThịTấtCảCộtToolStripMenuItem.Click
        AllColumns()
    End Sub
    Private Sub ẨnTấtCảCácCộtToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ẨnTấtCảCácCộtToolStripMenuItem.Click
        AllColumns(False)
    End Sub
    Private Sub HiểnThịCộtThườngDùngToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HiểnThịCộtThườngDùngToolStripMenuItem.Click
        For i As Integer = 0 To bttBoPhan.Columns.Count - 1
            If i <> 1 And i <> 2 And i <> 4 Then
                bttBoPhan.Columns(i).Visible = False
            Else
                bttBoPhan.Columns(i).Visible = True
            End If
        Next
    End Sub
#End Region
    Private Sub ChuyểnBộPhậnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChuyểnBộPhậnToolStripMenuItem.Click
        If bttBoPhan.RowCount <= 0 Then
            MsgBox("Bộ phận này không có người " & vbNewLine & "Không thể chuyển", , "Thông báo")
            Exit Sub
        End If
        frmTree.ShowDialog()
        bttBoPhan.Focus()
    End Sub
    Private Sub ToolStripButton10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton10.Click
        If bttBoPhan.RowCount <= 0 Then
            MsgBox("Bộ phận này không có người " & vbNewLine & "Không thể chuyển", , "Thông báo")
            Exit Sub
        End If
        For i As Integer = 0 To bttBoPhan.SelectedRows.Count - 1
            frmTree.ToolStripDropDownButton1.DropDownItems.Add(bttBoPhan.SelectedRows(i).Cells("colTenNV").Value)
        Next
        frmTree.ShowDialog()
        bttBoPhan.Focus()
    End Sub
#End Region
#Region "Keypress"
    Private Sub TxtMaNV_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMaNV.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TxtNVSP.Focus()
        End If
    End Sub
    Private Sub TxtNVSP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNVSP.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TxtTenNV.Focus()
        End If
    End Sub
    Private Sub TxtTenNV_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTenNV.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TxtTenHT.Focus()
        End If
    End Sub

    Private Sub TxtGioitinh_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbogioitinh.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TxtDiachi.Focus()
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub TxtDiachi_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDiachi.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TxtCMND.Focus()
        End If
    End Sub
    Private Sub TxtTenHT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTenHT.KeyPress
        If Asc(e.KeyChar) = 13 Then
            cboChucvu.Focus()
        End If
    End Sub
    Private Sub TxtTenHT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtTenHT.TextChanged
        If TxtTenHT.Text.Length > 8 Then
            ErrorProvider1.SetError(TxtTenHT, "Tên Hiển Thị Phải Nhỏ Hơn 8 Ký Tự và Không có Dấu")
        Else
            ErrorProvider1.SetError(TxtTenHT, "")
        End If
    End Sub
    Private Sub cboChucvu_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboChucvu.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TxtCardNo.Focus()
        End If
    End Sub

    Private Sub TxtCardNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCardNo.KeyPress
        If Asc(e.KeyChar) = 13 Then
            dtpNgaysinh.Focus()
        End If
    End Sub

    Private Sub dtpNgaysinh_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtpNgaysinh.KeyPress
        If Asc(e.KeyChar) = 13 Then
            cbogioitinh.Focus()
        End If
    End Sub

    Private Sub TxtCMND_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCMND.KeyPress
        If Asc(e.KeyChar) = 13 Then
            DTPNgayvaolam.Focus()
        End If
    End Sub

#End Region
#Region "luoi"
    Private Sub HiểnThịCộtThườngDùngToolStripMenuItem_DropDownItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles DanhSáchCộtToolStripMenuItem.DropDownItemClicked
        bttBoPhan.Columns(e.ClickedItem.Name).Visible = Not bttBoPhan.Columns(e.ClickedItem.Name).Visible
    End Sub
    Private Sub DataGridView1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles bttBoPhan.SelectionChanged
        If bttBoPhan.RowCount <= 0 Then Exit Sub
        Try
            dto = bus.LayBangDTo(Val(bttBoPhan.Item(0, bttBoPhan.CurrentRow.Index).Value))
            Hienthidulieu(1, GroupBox1)
            PictureBox1.ImageLocation = dto.Hinh
        Catch ex As Exception
        End Try
    End Sub
#End Region
#Region "button luoi"
    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        Dim sql As String = "select * from nhanvien where chucvu is null or chucvu=0 "
        bttBoPhan.DataSource = bus.LayBangTableSQL(sql)

    End Sub
    Private Sub ToolStripButton15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton15.Click
        Dim sql As String = "select * from nhanvien where donvi is null or donvi=0 "
        bttBoPhan.DataSource = bus.LayBangTableSQL(sql)

    End Sub
    Private Sub ToolStripButton16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton16.Click
        Dim sql As String = "select * from nhanvien where quyen is null "
        bttBoPhan.DataSource = bus.LayBangTableSQL(sql)

    End Sub
    Private Sub ToolStripButton13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton13.Click
        If IsNumeric(txtTim.Text) = False Then Exit Sub
        Dim sql As String = "select * from nhanvien where manv =" & txtTim.Text
        bttBoPhan.DataSource = bus.LayBangTableSQL(sql)
        bttBoPhan.Focus()
    End Sub
    Private Sub ToolStripButton14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton14.Click
        Dim sql As String = "select * from nhanvien where nvsp = '" & txtTim.Text & "'"
        bttBoPhan.DataSource = bus.LayBangTableSQL(sql)
        bttBoPhan.Focus()
    End Sub
    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        If bttBoPhan.SelectedRows.Count <= 0 Then
            MsgBox("Bạn chưa chọn nhân viên", , "Thông báo")
            Exit Sub
        End If
        Dim msg As MsgBoxResult = MsgBox("Bạn có muốn cấp quyền cho họ không?" & vbNewLine & "Yes: Quản lý" & vbNewLine & "No:Bình Thường " & vbNewLine & "Cancel:Không làm gì cả.Trở về ban đầu", MsgBoxStyle.YesNoCancel, "Thông báo")
        If msg = MsgBoxResult.Yes Then
            SuaQuyenNhanVien(1)
            MsgBox("Cấp quyền QUẢN LÝ cho nhân viên " & vbNewLine & "Tên Nhân Viên:  " & TxtTenNV.Text & vbNewLine & "Mã Chấm Công:  " & TxtMaNV.Text & vbNewLine & "Hoàn Thành", , "Thông báo")
        ElseIf msg = MsgBoxResult.No Then
            SuaQuyenNhanVien(0)
            MsgBox("Cấp quyền Sử Dụng cho nhân viên " & vbNewLine & "Tên Nhân Viên:  " & TxtTenNV.Text & vbNewLine & "Mã Chấm Công:  " & TxtMaNV.Text & vbNewLine & "Hoàn Thành", , "Thông báo")
        Else
            Exit Sub
        End If
        Dim sql As String = "select * from nhanvien where quyen is null "
        bttBoPhan.DataSource = bus.LayBangTableSQL(sql)
    End Sub
#End Region
    Private Sub Frmnhanvien_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        ManHinhChinh.CửaSổHoạtĐộngToolStripMenuItem.DropDownItems.Remove(ManHinhChinh.CửaSổHoạtĐộngToolStripMenuItem.DropDownItems(Me.Name))
    End Sub

    Private Sub frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim busQ As New QuyenBus(DTOKetnoi, False)
            Dim ma As Integer = busQ.MaQuyen(QuyenNguoiDangNhap)
            cacNutNhan(Me, ma, Me.Name)
            ManHinhChinh.CửaSổHoạtĐộngToolStripMenuItem.DropDownItems.Add("Giao Diện Nhân Viên").Name = Me.Name
            cboChucvu.ValueMember = "cvid"
            cboChucvu.DisplayMember = "chucvu"
            cboChucvu.DataSource = busChucvu.LayBangTable
            cbogioitinh.Items.Add("Nam")
            cbogioitinh.Items.Add("Nữ")
            cay()
            AnMo(False, GroupBox1)
            TreeView1.Focus()
            TreeView1.Nodes(0).Expand()
        Catch
        End Try
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If TreeView1.Enabled = False Then
            ManHinhMasoTrong.ShowDialog()
            If ManHinhMasoTrong.Ma <> 0 Then TxtMaNV.Text = ManHinhMasoTrong.Ma
        Else
            MsgBox("Chức năng tìm mã chấm công trống không sử dụng được" & vbNewLine & "Chức năng này chỉ được sử dụng khi Thêm nhân viên", , "Thông Báo")
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        OpenFileDialog1.DefaultExt = "jpg"
        OpenFileDialog1.Filter = "All files (*.*)|*.*"
        If (OpenFileDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK) Then
            dto.Hinh = OpenFileDialog1.FileName
            Me.PictureBox1.ImageLocation = dto.Hinh
        End If

    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        dto.Hinh = ""
        Me.PictureBox1.ImageLocation = ""
    End Sub
    Private Function XoaChiTietNV() As Boolean
        Dim buscatd As New caTDBus(DTOKetnoi, False)
        Dim BusLichNV As New lichnvBus(DTOKetnoi, False)
        Dim buslichtam As New lichtamBus(DTOKetnoi, False)
        Dim busVaoRa As New VaoraBus(DTOKetnoi, False)
        Dim busNVBC As New NVBCBus(DTOKetnoi, False)
        Dim busnvvan As New nvvanBus(DTOKetnoi, False)
        Dim busnvnghi As New NVnghiphepBus(DTOKetnoi, False)
        Dim dataCaTD As DataTable = buscatd.LayBangTableTheonvId(dto.MaNV)
        If dataCaTD.Rows.Count > 0 Then
            For i As Integer = 0 To dataCaTD.Rows.Count - 1
                buscatd.Xoa(dataCaTD.Rows(i)(0))
            Next
        End If
        Dim malich As Integer = BusLichNV.LayBangDTotheoManv(dto.MaNV).ID
        If malich <> 0 Then
            BusLichNV.Xoa(malich)
        End If
        Dim dataLichtam As DataTable = buslichtam.LayBangTableTheoNVid(dto.MaNV)
        If dataLichtam.Rows.Count > 0 Then
            For i As Integer = 0 To dataLichtam.Rows.Count - 1
                buslichtam.Xoa(dataLichtam.Rows(i)(0))
            Next
        End If
        Dim dataVaoRa As DataTable = busVaoRa.LayBangTabletheoNVid(dto.MaNV)
        If dataVaoRa.Rows.Count > 0 Then
            For i As Integer = 0 To dataVaoRa.Rows.Count - 1
                busVaoRa.Xoa(dataVaoRa.Rows(i)(0))
            Next
        End If
        Dim dataNVBC As DataTable = busNVBC.LayBangTabletheoNv(dto.MaNV)
        If dataNVBC.Rows.Count > 0 Then
            For i As Integer = 0 To dataNVBC.Rows.Count - 1
                busNVBC.Xoa(dataNVBC.Rows(i)(0))
            Next
        End If
        Dim datanvVan As DataTable = busnvvan.LayBangTabletheoNVid(dto.MaNV)
        If datanvVan.Rows.Count > 0 Then
            For i As Integer = 0 To datanvVan.Rows.Count - 1
                busnvvan.Xoa(datanvVan.Rows(i)(0))
            Next
        End If
        Dim datanvghi As DataTable = busnvnghi.LayBangTabletheoNvid(dto.MaNV)
        If datanvghi.Rows.Count > 0 Then
            For i As Integer = 0 To datanvghi.Rows.Count - 1
                busnvnghi.Xoa(datanvghi.Rows(i)(0))
            Next
        End If
    End Function
    Private Sub XóaTấtCảThôngTinLiênQuanĐếnNhaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XóaTấtCảThôngTinLiênQuanĐếnNhaToolStripMenuItem.Click
        If TreeView1.Enabled Then
            If MsgBox("Bạn có muốn xóa nhân viên?" & vbNewLine & " tên nhân viên: " & TxtTenNV.Text & vbNewLine & "Mã Chấm Công: " & TxtMaNV.Text, MsgBoxStyle.OkCancel, "Thông báo") = MsgBoxResult.Ok Then
                XoaChiTietNV()
                bus.Xoa(Val(TxtMaNV.Text))
                bttBoPhan.DataSource = bus.LayBangTabletheodonvi(TreeView1.SelectedNode.Name)
            End If
        End If
        bttBoPhan.Focus()
    End Sub
    Private Sub ToolStripButton11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton11.Click
        ManHinhDocExcel_NhanVien.ShowDialog()
        bttBoPhan.Focus()
    End Sub
#Region "Nhap\Xuat file excel"
    Public Sub XuatBCEX(ByVal ddanEX As String)
        Dim exc As New Microsoft.Office.Interop.Excel.Application
        Dim Wbook As New Microsoft.Office.Interop.Excel.Workbook
        Dim shet As New Microsoft.Office.Interop.Excel.Worksheet
        Wbook = exc.Workbooks.Add
        XuatEXF("Xu ly", Me.bttBoPhan)
        Wbook.SaveAs(ddanEX)
        Wbook.Close()
        exc.Workbooks.Close()
    End Sub
    Private Sub ToolStripButton17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton17.Click, ChuyểnDửLiệuRaExcelToolStripMenuItem.Click
        SaveFileDialog1.DefaultExt = "xls"
        SaveFileDialog1.Filter = "xls files (*.xls)|*.xls"
        If (SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK) Then
            Try
                XuatBCEX(SaveFileDialog1.FileName)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            MsgBox("Chuyển dử liệu thành công", , "Thông báo")
        End If
        bttBoPhan.Focus()

    End Sub
    Private Sub XuatEXF(ByVal Ten As String, ByVal dgv As System.Windows.Forms.DataGridView)
        StatusStrip1.Visible = True
        ToolStripProgressBar1.Maximum = dgv.RowCount * dgv.ColumnCount + 100
        ToolStripProgressBar1.Value = 1
        Dim exc As New Microsoft.Office.Interop.Excel.Application
        Dim Wbook As New Microsoft.Office.Interop.Excel.Workbook
        Dim shet As New Microsoft.Office.Interop.Excel.Worksheet
        shet = Wbook.Worksheets.Add
        shet = Wbook.ActiveSheet
        shet.Name = Ten
        Dim cot, hang As Integer
        cot = 0
        hang = 0
        For i As Integer = 0 To dgv.ColumnCount - 1
            If dgv.Columns(i).Visible Then
                cot += 1
                shet.Cells(1, cot) = dgv.Columns(i).HeaderText
                ToolStripProgressBar1.Value += 1
                If ToolStripProgressBar1.Value = 1 Then ToolStripProgressBar1.Value = 1
            End If
        Next
        ' noi dung
        For i As Integer = 0 To dgv.RowCount - 1
            hang += 1
            cot = 0
            For j As Integer = 0 To dgv.ColumnCount - 1
                If dgv.Columns(j).Visible Then
                    cot += 1
                    exc.Cells(hang + 1, cot) = dgv.Item(j, i).Value
                    ToolStripProgressBar1.Value += 1
                    If ToolStripProgressBar1.Value = 1 Then ToolStripProgressBar1.Value = 1
                End If
            Next
            '***************************
        Next
        shet.Columns.AutoFit()
        ToolStripProgressBar1.Value = ToolStripProgressBar1.Maximum
        StatusStrip1.Visible = False
    End Sub
#End Region
    Private Sub TreeView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TreeView1.KeyDown
        If e.KeyData = Keys.Enter Then
            bttBoPhan.Focus()
        End If
    End Sub
    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles bttBoPhan.KeyDown
        If e.Alt = True And e.KeyData = Keys.T Then
            txtTim.Focus()
        End If
        If e.KeyData = Keys.F2 Then
            suanv()
            TxtNVSP.Focus()
        End If
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ManhinhChucvu.ShowDialog()
        cboChucvu.ValueMember = "cvid"
        cboChucvu.DisplayMember = "chucvu"
        cboChucvu.DataSource = busChucvu.LayBangTable
        cboChucvu.Focus()
    End Sub

    Private Sub XóaNhiềuNhânViênToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XóaNhiềuNhânViênToolStripMenuItem.Click
        If TreeView1.Enabled Then
            If MsgBox("Bạn có muốn xóa những nhân viên này?", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "Thông báo") = MsgBoxResult.Ok Then
                For i As Integer = 0 To Me.bttBoPhan.SelectedRows.Count - 1
                    bus.Xoa(Me.bttBoPhan.SelectedRows(i).Cells("ColMaNV").Value)
                Next

                bttBoPhan.DataSource = bus.LayBangTabletheodonvi(TreeView1.SelectedNode.Name)

            End If
        End If
    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton18.Click
        Try
            ManhinhQLBophan.Owner = Me
            ManhinhQLBophan.Show()
        Catch ex As Exception

        End Try
    End Sub

End Class
