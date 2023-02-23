Imports Microsoft.VisualBasic.Strings
Imports System.IO
Imports System.Windows.Forms

Public Class ManHinhThietLapMCC
    Dim bus As New MayBus(DTOKetnoi, False)
    Dim dto As New Maydto
    Public batdau As Integer = 100
    Public ketthuc As Integer = 254
    Dim PKieuKN As Integer
#Region "ho tro"
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
    Private Sub XoaTrang(ByVal group As Control)
        Dim valcontrol As Control
        For Each valcontrol In group.Controls
            If valcontrol.Controls.Count > 0 Then
                XoaTrang(valcontrol)
            End If
            If valcontrol.Tag = "1" Then
                valcontrol.Text = ""
            End If
        Next
    End Sub
    Private Sub HuyBaoLoi(ByVal group As Control)
        Dim valcontrol As Control
        For Each valcontrol In group.Controls
            If valcontrol.Controls.Count > 0 Then
                HuyBaoLoi(valcontrol)
            End If
            If valcontrol.Tag = "1" Then
                ErrorProvider1.SetError(valcontrol, "")
            End If
        Next
    End Sub
    Private Function HotroThem(ByVal group As Control) As Integer
        Dim valcontrol As New Control
        Dim soloi As Integer = 0
        Dim loi As String = ""
        For Each valcontrol In group.Controls
            If valcontrol.Tag = "1" Then
                If valcontrol.Name = "cboCong" Then
                    Dim cbo As ComboBox = valcontrol
                    loi = dto.HoTro(UCase(Mid(valcontrol.Name, 4)), cbo.SelectedIndex)
                Else
                    If TypeOf valcontrol Is ComboBox Then
                        Dim combo As ComboBox = valcontrol
                        If combo.Name = "cboRate" Then
                            loi = dto.HoTro(UCase(Mid(valcontrol.Name, 4)), combo.Text)
                        Else
                            loi = dto.HoTro(UCase(Mid(valcontrol.Name, 4)), combo.SelectedValue)
                        End If
                    Else
                        loi = dto.HoTro(UCase(Mid(valcontrol.Name, 4)), valcontrol.Text)
                    End If

                End If

                If loi <> "" Then
                    valcontrol.Focus()
                    soloi = soloi + 1
                    'có loi
                End If
                ErrorProvider1.SetError(valcontrol, loi)
            End If
        Next
        Return soloi
    End Function
    Private Function maxList() As Integer
        Dim a As DataRowView
        Dim max As Integer = 0
        For i As Integer = 0 To LstDanhSachMcc.Items.Count - 1
            a = Me.LstDanhSachMcc.Items(i)
            If a.Item(0) > max Then max = a.Item(0)
        Next
        Return max
    End Function
    Private Function kiemtraIPList(ByVal ip As String) As Boolean
        Dim a As DataRowView
        For i As Integer = 0 To LstDanhSachMcc.Items.Count - 1
            a = Me.LstDanhSachMcc.Items(i)
            If a.Item(4) = ip Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Function XacDinhKieuKN() As Integer
        If RB_USB.Checked = True Then
            PKieuKN = 3
        ElseIf rdbIP.Checked = True Then
            PKieuKN = 1
        Else
            PKieuKN = 2
        End If
        Return PKieuKN
    End Function
    Private Function KiemTra() As Boolean
        'kiểm tra nhập liệu null,number
        If HotroThem(SplitContainer1.Panel2) > 0 Then
            Return False
        End If
        If rdbIP.Checked Then
            If HotroThem(GroupBox1) > 0 Then
                Return False
            End If
        End If
        If RadioButton2.Checked Then
            If HotroThem(GroupBox2) > 0 Then
                Return False
            End If
        End If
        'kiểm tra trùng khoá
        If LstDanhSachMcc.Enabled = False Then
            dto.ID = maxList() + 1
        End If
        Return True
    End Function


    Private Sub ghi()
        If KiemTra() = False Then Exit Sub
        If rdbIP.Checked Then
            If IsNumeric(txtCong.Text) Then
                dto.Cong = txtCong.Text
                ErrorProvider1.SetError(txtCong, "")
            Else
                ErrorProvider1.SetError(txtCong, "Bạn Phải Nhập Số")
                MsgBox("Bạn Phải Nhập Số", , "Thông báo")
                Exit Sub
            End If
        Else
            dto.Cong = cboCong.SelectedIndex
        End If
        If LstDanhSachMcc.Enabled = False Then
            dto.Kieu = XacDinhKieuKN()
            bus.Them(dto)
            MsgBox("Thêm máy chấm công thành công", , "Thông báo")
        Else
            dto.Kieu = XacDinhKieuKN()
            bus.sua(dto)
            MsgBox("Sửa máy chấm công thành công", , "Thông báo")
        End If
        LstDanhSachMcc.DisplayMember = "tenmay"
        LstDanhSachMcc.ValueMember = "ID"
        LstDanhSachMcc.DataSource = bus.LayBangTable
        LstDanhSachMcc.Enabled = True
    End Sub
    Private Sub xoa()
        If LstDanhSachMcc.Enabled = False Then Exit Sub
        Dim a As DataRowView = Me.LstDanhSachMcc.SelectedItem
        If MsgBox("Bạn muốn xóa máy: " & a.Item(1) & vbNewLine & " phải không ?", MsgBoxStyle.OkCancel, "Thông báo") = MsgBoxResult.Ok Then
            bus.Xoa(a.Item(0))
            LstDanhSachMcc.DisplayMember = "tenmay"
            LstDanhSachMcc.ValueMember = "ID"
            LstDanhSachMcc.DataSource = bus.LayBangTable
        End If
    End Sub
    Private Sub them()
        XoaTrang(SplitContainer1.Panel2)
        TxtTenMay.Focus()
        dto = New Maydto
        LstDanhSachMcc.Enabled = False
    End Sub
    Private Sub ThemCBo()
        cboCong.Items.Add(".")
        cboCong.Items.Add("com1")
        cboCong.Items.Add("com2")
        cboRate.Items.Add("9600")
        cboRate.Items.Add("19200")
        cboRate.Items.Add("38400")
        cboRate.Items.Add("57600")
        cboRate.Items.Add("115200")
    End Sub
    Private Sub hienthidulieu(ByVal group As Control, ByVal classdto As Maydto)
        Dim valcontrol As Control
        For Each valcontrol In group.Controls
            If valcontrol.Controls.Count > 0 Then
                hienthidulieu(valcontrol, classdto)
            End If
            If valcontrol.Tag = "1" Then
                If TypeOf valcontrol Is TextBox Then
                    If rdbIP.Checked = False And valcontrol.Name = "txtCong" Then
                        valcontrol.Text = 0
                    Else
                        valcontrol.Text = classdto.HoTro(UCase(Mid(valcontrol.Name, 4)))
                    End If
                End If
                If TypeOf valcontrol Is ComboBox Then
                    Dim cbo As ComboBox = valcontrol
                    If rdbIP.Checked = False And valcontrol.Name = "cboCong" Then
                        cbo.SelectedIndex = classdto.HoTro(UCase(Mid(valcontrol.Name, 4)))
                    End If
                    If valcontrol.Name = "cboRate" Then
                        cbo.Text = classdto.HoTro(UCase(Mid(valcontrol.Name, 4)))
                    Else
                        cbo.SelectedValue = classdto.HoTro(UCase(Mid(valcontrol.Name, 4)))
                    End If
                End If
            End If
        Next
    End Sub
#End Region
#Region "radio button"

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged, RB_USB.CheckedChanged, rdbIP.CheckedChanged
        Dim RB As RadioButton = sender

        Select Case RB.Name
            Case "rdbIP"
                GroupBox1.Enabled = rdbIP.Checked
                GroupBox2.Enabled = RadioButton2.Checked
            Case "RadioButton2"
                GroupBox1.Enabled = rdbIP.Checked
                GroupBox2.Enabled = RadioButton2.Checked
                cboRate.SelectedIndex = 3
                cboCong.SelectedIndex = 2
            Case "RB_USB"
                GroupBox1.Enabled = rdbIP.Checked
                GroupBox2.Enabled = RadioButton2.Checked
        End Select



    End Sub
#End Region
#Region "Them ,xoa ,sua"
    Private Sub ThêmMCCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ThêmMCCToolStripMenuItem.Click
        them()
    End Sub

    Private Sub XoáMCCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XoáMCCToolStripMenuItem.Click
        xoa()
    End Sub

    Private Sub LưuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LưuToolStripMenuItem.Click
        ghi()
    End Sub
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        them()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        xoa()
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        ghi()
    End Sub
    Private Sub cboCong_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCong.KeyPress
        e.Handled = True
    End Sub
    Private Sub cboRate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboRate.KeyPress
        e.Handled = True
    End Sub
#End Region
#Region "key up"
    Private Sub TxtTenMay_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtTenMay.KeyUp
        If e.KeyCode = Keys.Enter Then
            txtvtri.Focus()
        End If
    End Sub

    Private Sub txtvtri_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtvtri.KeyUp
        If e.KeyCode = Keys.Enter Then
            txtIP.Focus()
        End If
    End Sub
#End Region
#Region "Load"
    Private Sub LstDanhSachMcc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstDanhSachMcc.SelectedIndexChanged
        If LstDanhSachMcc.Items.Count <= 0 Then Exit Sub
        Dim a As DataRowView = Me.LstDanhSachMcc.SelectedItem
        dto = bus.LayBangDTo(a.Item(0))
        DocKieuKN(dto.Kieu)
        butKTIP.Image = Nothing
        hienthidulieu(SplitContainer1.Panel2, dto)
    End Sub

    Private Sub DocKieuKN(ByVal kieu As Integer)
        Select Case kieu
            Case 1
                rdbIP.Checked = True
            Case 2
                RadioButton2.Checked = True
            Case 3
                RB_USB.Checked = True
        End Select
    End Sub
    Private Sub cboLoaimay_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLoaimay.SelectedIndexChanged
        If cboLoaimay.SelectedValue = 1 Then
            txtCong.Text = 5005
        ElseIf cboLoaimay.SelectedValue = 2 Then
            txtCong.Text = 4370
        End If
    End Sub
#End Region
#Region "Kiemtra IP"
    Private Sub butKTIP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butKTIP.Click
        Try
            If My.Computer.Network.Ping(txtIP.Text, 10) Then
                butKTIP.Image = KhaiPhamLai.My.Resources.ok
                MsgBox("Ping thành công " & vbNewLine & "bạn có thể sử dụng ip này", , "Thông báo")
            Else
                butKTIP.Image = KhaiPhamLai.My.Resources.remove1
                MsgBox("Ping thất bại " & vbNewLine & "bạn nên chọn ip khác", , "Thông báo")
            End If
        Catch ex As Exception
            butKTIP.Image = KhaiPhamLai.My.Resources.remove1
        End Try
    End Sub
    Private Sub butChuyenIp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butChuyenIp.Click
        ToolStripDropDownButton1.Enabled = False
        butChuyenIp.Enabled = False
        butKTIP.Enabled = False
        Button1.Enabled = False
        Dim ip As String = DocFile(Application.StartupPath & "\configIp.dat")
        Dim An() As System.Net.IPAddress = System.Net.Dns.GetHostAddresses(System.Net.Dns.GetHostName())
        If ip = "" Then
            ip = An(0).ToString()
        End If
        Try
            ToolStripProgressBar1.Value = batdau
            For j As Integer = batdau To ketthuc
                ip = Microsoft.VisualBasic.Strings.Left(ip, ip.LastIndexOf(".")) & "." & batdau
                batdau = j
                ToolStripProgressBar1.Value = batdau
                Try
                    If ManhinhIP.TextBox4.Text = "" Then
                        If My.Computer.Network.Ping(ip, 6) Then
                            If kiemtraIPList(ip) = False And ip <> An(0).ToString() Then lstIP.Items.Add(ip)
                            'lstIP.Items.Add(ip)
                            If MsgBox("Bạn muốn tìm tiếp hay ko?", MsgBoxStyle.YesNo, "Thông báo") = MsgBoxResult.No Then
                                ToolStripDropDownButton1.Enabled = True
                                butChuyenIp.Enabled = True
                                butKTIP.Enabled = True
                                Button1.Enabled = True
                                Exit Sub
                            End If
                        End If
                    Else
                        If My.Computer.Network.Ping(ManhinhIP.TextBox4.Text & "." & batdau, 6) Then
                            If kiemtraIPList(ManhinhIP.TextBox4.Text & "." & batdau) = False And ManhinhIP.TextBox4.Text & "." & batdau <> An(0).ToString() Then lstIP.Items.Add(ManhinhIP.TextBox4.Text & "." & batdau)
                            'lstIP.Items.Add(ip)
                            If MsgBox("Bạn muốn tìm tiếp hay ko?", MsgBoxStyle.YesNo, "Thông báo") = MsgBoxResult.No Then
                                ToolStripDropDownButton1.Enabled = True
                                butChuyenIp.Enabled = True
                                butKTIP.Enabled = True
                                Button1.Enabled = True
                                Exit Sub
                            End If
                        End If
                    End If
                Catch ex As Exception
                End Try
            Next
            'ToolStripProgressBar1.Value = 1
        Catch ex As Exception
        End Try
        ToolStripDropDownButton1.Enabled = True
        butChuyenIp.Enabled = True
        butKTIP.Enabled = True
        Button1.Enabled = True
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ToolStripDropDownButton1.Enabled = False
        butChuyenIp.Enabled = False
        butKTIP.Enabled = False
        Button1.Enabled = False
        Dim ip As String = DocFile(Application.StartupPath & "\configIp.dat")
        Dim An() As System.Net.IPAddress = System.Net.Dns.GetHostAddresses(System.Net.Dns.GetHostName())
        If ip = "" Then
            ip = An(0).ToString()
        End If
        Try
            ToolStripProgressBar1.Value = batdau
            For j As Integer = batdau To ketthuc
                ip = Microsoft.VisualBasic.Strings.Left(ip, ip.LastIndexOf(".")) & "." & batdau
                batdau = j
                ToolStripProgressBar1.Value += 1
                Try
                    If ManhinhIP.TextBox4.Text = "" Then
                        If My.Computer.Network.Ping(ip, 6) Then
                            If kiemtraIPList(ip) = False And ip <> An(0).ToString() Then lstIP.Items.Add(ip)
                            'lstIP.Items.Add(ip)
                        End If
                    Else
                        If My.Computer.Network.Ping(ManhinhIP.TextBox4.Text & "." & batdau, 6) Then
                            If kiemtraIPList(ManhinhIP.TextBox4.Text & "." & batdau) = False And ManhinhIP.TextBox4.Text & "." & batdau <> An(0).ToString() Then lstIP.Items.Add(ManhinhIP.TextBox4.Text & "." & batdau)
                            'lstIP.Items.Add(ip)
                        End If
                    End If
                Catch ex As Exception
                End Try
            Next
        Catch ex As Exception
        End Try
        ToolStripDropDownButton1.Enabled = True
        butChuyenIp.Enabled = True
        butKTIP.Enabled = True
        Button1.Enabled = True
    End Sub
    Private Sub lstIP_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstIP.SelectedIndexChanged
        If lstIP.SelectedIndex < 0 Then Exit Sub
        txtIP.Text = lstIP.SelectedItem
    End Sub
    Private Sub ToolStripDropDownButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripDropDownButton1.Click
        lstIP.Items.Clear()
        ManhinhIP.Show()
    End Sub
#End Region
    Public Function ArrayList2DataTable(ByVal al As ArrayList) As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("id")
        dt.Columns.Add("TenCk")
        For iRow As Integer = 0 To al.Count - 1
            Dim drow As DataRow = dt.NewRow()
            drow.Item("id") = al(iRow).id
            drow.Item("TenCk") = al(iRow).tenck
            dt.Rows.Add(drow)
        Next
        Return dt
    End Function
    Private Sub ManHinhThietLapMCC_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        ManHinhChinh.CửaSổHoạtĐộngToolStripMenuItem.DropDownItems.Remove(ManHinhChinh.CửaSổHoạtĐộngToolStripMenuItem.DropDownItems(Me.Name))
        ManHinhChinh.LoadListView()
    End Sub


    Private Sub ManHinhThietLapMCC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ManHinhChinh.CửaSổHoạtĐộngToolStripMenuItem.DropDownItems.Add("Giao Diện Thiết Lập Mấy Chấm Công").Name = Me.Name
        Dim busQ As New QuyenBus(DTOKetnoi, False)
        Dim ma As Integer = busQ.MaQuyen(QuyenNguoiDangNhap)
        cacNutNhan(Me, ma, Me.Name)
        Me.LstDanhSachMcc.MultiColumn = True
        ThemCBo()
        rdbIP.Checked = True
        Dim arr As New ArrayList
        Dim c1 As New LoaiChuky
        c1.ID = 1
        c1.TenCk = "Metron ND"
        arr.Add(c1)
        Dim c2 As New LoaiChuky
        c2.ID = 2
        c2.TenCk = "Metron ZK"
        arr.Add(c2)


        Dim c3 As New LoaiChuky
        c3.ID = 3
        c3.TenCk = "Metron T58"
        arr.Add(c3)


        Dim c4 As New LoaiChuky
        c4.ID = 4
        c4.TenCk = "Metron F80/2088"
        arr.Add(c4)

        Dim C5 As New LoaiChuky
        C5.ID = 5
        C5.TenCk = "HanVon"
        arr.Add(C5)





        cboLoaimay.DisplayMember = "TenCk"
        cboLoaimay.ValueMember = "ID"
        cboLoaimay.DataSource = ArrayList2DataTable(arr)
        LstDanhSachMcc.DisplayMember = "tenmay"
        LstDanhSachMcc.ValueMember = "ID"
        LstDanhSachMcc.DataSource = bus.LayBangTable
        cboCong.SelectedIndex = 0
        cboRate.SelectedIndex = 0
    End Sub


End Class