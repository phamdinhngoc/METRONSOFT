<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManHinhNhanVienNghiVanTinhCong
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ManHinhNhanVienNghiVanTinhCong))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
        Me.TreeView1 = New System.Windows.Forms.TreeView
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.ColMaNV = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colNVSP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTenNV = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTenHT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colChucvu = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDonvi = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colQuyen = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colMathe = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colNgaysinh = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colGioiTinh = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDiachi = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCMND = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colNgayvaolam = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.HiểnThịTấtCảCộtToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ẨnTấtCảCácCộtToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HiểnThịCộtThườngDùngToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DanhSáchCộtToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DataGridViewNghi = New System.Windows.Forms.DataGridView
        Me.IDNP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MaNV = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Ngay = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Lydo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SoNgay = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SoCong = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.ButtonXoa = New System.Windows.Forms.Button
        Me.ButtonLuu = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.TextBoxSocong = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TextBoxSongay = New System.Windows.Forms.TextBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.ComboBoxlydo = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.DateTimePickerNgay = New System.Windows.Forms.DateTimePicker
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButtonXoa = New System.Windows.Forms.ToolStripButton
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.DataGridViewNghi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridViewNghi)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ToolStrip1)
        Me.SplitContainer1.Size = New System.Drawing.Size(794, 578)
        Me.SplitContainer1.SplitterDistance = 293
        Me.SplitContainer1.TabIndex = 0
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.TreeView1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.DataGridView1)
        Me.SplitContainer2.Size = New System.Drawing.Size(293, 578)
        Me.SplitContainer2.SplitterDistance = 119
        Me.SplitContainer2.TabIndex = 0
        '
        'TreeView1
        '
        Me.TreeView1.BackColor = System.Drawing.Color.White
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView1.ImageIndex = 1
        Me.TreeView1.ImageList = Me.ImageList1
        Me.TreeView1.Location = New System.Drawing.Point(0, 0)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.SelectedImageIndex = 0
        Me.TreeView1.Size = New System.Drawing.Size(293, 119)
        Me.TreeView1.TabIndex = 2
        Me.TreeView1.Tag = "8"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "classmate_48.ico")
        Me.ImageList1.Images.SetKeyName(1, "architecture_32.ico")
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColMaNV, Me.colNVSP, Me.colTenNV, Me.colTenHT, Me.colChucvu, Me.colDonvi, Me.colQuyen, Me.colMathe, Me.colNgaysinh, Me.colGioiTinh, Me.colDiachi, Me.colCMND, Me.colNgayvaolam})
        Me.DataGridView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(293, 455)
        Me.DataGridView1.TabIndex = 2
        Me.DataGridView1.Tag = "8"
        '
        'ColMaNV
        '
        Me.ColMaNV.DataPropertyName = "Manv"
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ColMaNV.DefaultCellStyle = DataGridViewCellStyle2
        Me.ColMaNV.HeaderText = "Mã Cc"
        Me.ColMaNV.Name = "ColMaNV"
        Me.ColMaNV.ReadOnly = True
        Me.ColMaNV.Width = 40
        '
        'colNVSP
        '
        Me.colNVSP.DataPropertyName = "nvsp"
        Me.colNVSP.HeaderText = "Mã NV"
        Me.colNVSP.Name = "colNVSP"
        Me.colNVSP.ReadOnly = True
        Me.colNVSP.Width = 70
        '
        'colTenNV
        '
        Me.colTenNV.DataPropertyName = "tenNV"
        Me.colTenNV.HeaderText = "Tên NV"
        Me.colTenNV.Name = "colTenNV"
        Me.colTenNV.ReadOnly = True
        '
        'colTenHT
        '
        Me.colTenHT.DataPropertyName = "TenHT"
        Me.colTenHT.HeaderText = "Tên Hiển Thị"
        Me.colTenHT.Name = "colTenHT"
        Me.colTenHT.ReadOnly = True
        '
        'colChucvu
        '
        Me.colChucvu.DataPropertyName = "chucvu"
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colChucvu.DefaultCellStyle = DataGridViewCellStyle3
        Me.colChucvu.HeaderText = "Chức vụ"
        Me.colChucvu.Name = "colChucvu"
        Me.colChucvu.ReadOnly = True
        Me.colChucvu.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'colDonvi
        '
        Me.colDonvi.DataPropertyName = "tendv"
        Me.colDonvi.HeaderText = "Đơn vị"
        Me.colDonvi.Name = "colDonvi"
        Me.colDonvi.ReadOnly = True
        Me.colDonvi.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'colQuyen
        '
        Me.colQuyen.DataPropertyName = "quyen"
        Me.colQuyen.HeaderText = "Quyền"
        Me.colQuyen.Name = "colQuyen"
        Me.colQuyen.ReadOnly = True
        '
        'colMathe
        '
        Me.colMathe.DataPropertyName = "cardno"
        Me.colMathe.HeaderText = "Mã Thẻ"
        Me.colMathe.Name = "colMathe"
        Me.colMathe.ReadOnly = True
        '
        'colNgaysinh
        '
        Me.colNgaysinh.DataPropertyName = "ngaysinh"
        Me.colNgaysinh.HeaderText = "Ngày sinh"
        Me.colNgaysinh.Name = "colNgaysinh"
        Me.colNgaysinh.ReadOnly = True
        '
        'colGioiTinh
        '
        Me.colGioiTinh.DataPropertyName = "gioitinh"
        Me.colGioiTinh.HeaderText = "Giới tính"
        Me.colGioiTinh.Name = "colGioiTinh"
        Me.colGioiTinh.ReadOnly = True
        '
        'colDiachi
        '
        Me.colDiachi.DataPropertyName = "diachi"
        Me.colDiachi.HeaderText = "Địa chỉ"
        Me.colDiachi.Name = "colDiachi"
        Me.colDiachi.ReadOnly = True
        '
        'colCMND
        '
        Me.colCMND.DataPropertyName = "cmnd"
        Me.colCMND.HeaderText = "CMND"
        Me.colCMND.Name = "colCMND"
        Me.colCMND.ReadOnly = True
        '
        'colNgayvaolam
        '
        Me.colNgayvaolam.DataPropertyName = "ngayvaolam"
        Me.colNgayvaolam.HeaderText = "Ngày vào lảm"
        Me.colNgayvaolam.Name = "colNgayvaolam"
        Me.colNgayvaolam.ReadOnly = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.AllowDrop = True
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HiểnThịTấtCảCộtToolStripMenuItem, Me.ẨnTấtCảCácCộtToolStripMenuItem, Me.HiểnThịCộtThườngDùngToolStripMenuItem, Me.DanhSáchCộtToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(212, 92)
        '
        'HiểnThịTấtCảCộtToolStripMenuItem
        '
        Me.HiểnThịTấtCảCộtToolStripMenuItem.Name = "HiểnThịTấtCảCộtToolStripMenuItem"
        Me.HiểnThịTấtCảCộtToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.HiểnThịTấtCảCộtToolStripMenuItem.Text = "Hiển Thị Tất Cả Cột"
        '
        'ẨnTấtCảCácCộtToolStripMenuItem
        '
        Me.ẨnTấtCảCácCộtToolStripMenuItem.Name = "ẨnTấtCảCácCộtToolStripMenuItem"
        Me.ẨnTấtCảCácCộtToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.ẨnTấtCảCácCộtToolStripMenuItem.Text = "Ẩn Tất Cả các Cột"
        '
        'HiểnThịCộtThườngDùngToolStripMenuItem
        '
        Me.HiểnThịCộtThườngDùngToolStripMenuItem.Name = "HiểnThịCộtThườngDùngToolStripMenuItem"
        Me.HiểnThịCộtThườngDùngToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.HiểnThịCộtThườngDùngToolStripMenuItem.Text = "Hiển Thị Cột Thường Dùng"
        '
        'DanhSáchCộtToolStripMenuItem
        '
        Me.DanhSáchCộtToolStripMenuItem.Name = "DanhSáchCộtToolStripMenuItem"
        Me.DanhSáchCộtToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.DanhSáchCộtToolStripMenuItem.Text = "Danh sách cột"
        '
        'DataGridViewNghi
        '
        Me.DataGridViewNghi.AllowUserToAddRows = False
        Me.DataGridViewNghi.AllowUserToDeleteRows = False
        Me.DataGridViewNghi.BackgroundColor = System.Drawing.Color.White
        Me.DataGridViewNghi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewNghi.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDNP, Me.MaNV, Me.Ngay, Me.Lydo, Me.SoNgay, Me.SoCong})
        Me.DataGridViewNghi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridViewNghi.Location = New System.Drawing.Point(0, 119)
        Me.DataGridViewNghi.Name = "DataGridViewNghi"
        Me.DataGridViewNghi.ReadOnly = True
        Me.DataGridViewNghi.Size = New System.Drawing.Size(497, 459)
        Me.DataGridViewNghi.TabIndex = 3
        '
        'IDNP
        '
        Me.IDNP.DataPropertyName = "IDNP"
        Me.IDNP.HeaderText = "IDNP"
        Me.IDNP.Name = "IDNP"
        Me.IDNP.ReadOnly = True
        Me.IDNP.Visible = False
        '
        'MaNV
        '
        Me.MaNV.DataPropertyName = "MaNV"
        Me.MaNV.HeaderText = "MaNV"
        Me.MaNV.Name = "MaNV"
        Me.MaNV.ReadOnly = True
        Me.MaNV.Visible = False
        '
        'Ngay
        '
        Me.Ngay.DataPropertyName = "Ngay"
        Me.Ngay.HeaderText = "Ngày"
        Me.Ngay.Name = "Ngay"
        Me.Ngay.ReadOnly = True
        '
        'Lydo
        '
        Me.Lydo.DataPropertyName = "Lydo"
        Me.Lydo.HeaderText = "Lý do"
        Me.Lydo.Name = "Lydo"
        Me.Lydo.ReadOnly = True
        '
        'SoNgay
        '
        Me.SoNgay.DataPropertyName = "SoNgay"
        Me.SoNgay.HeaderText = "Sồ Ngày"
        Me.SoNgay.Name = "SoNgay"
        Me.SoNgay.ReadOnly = True
        '
        'SoCong
        '
        Me.SoCong.DataPropertyName = "SoCong"
        Me.SoCong.HeaderText = "Số Công"
        Me.SoCong.Name = "SoCong"
        Me.SoCong.ReadOnly = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.Panel2.Controls.Add(Me.ButtonXoa)
        Me.Panel2.Controls.Add(Me.ButtonLuu)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.TextBoxSocong)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.TextBoxSongay)
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Controls.Add(Me.ComboBoxlydo)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.DateTimePickerNgay)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 55)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(497, 64)
        Me.Panel2.TabIndex = 2
        Me.Panel2.Visible = False
        '
        'ButtonXoa
        '
        Me.ButtonXoa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonXoa.Image = Global.KhaiPhamLai.My.Resources.Resources.remove1
        Me.ButtonXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonXoa.Location = New System.Drawing.Point(427, 37)
        Me.ButtonXoa.Name = "ButtonXoa"
        Me.ButtonXoa.Size = New System.Drawing.Size(65, 21)
        Me.ButtonXoa.TabIndex = 8
        Me.ButtonXoa.Tag = "không thêm/sửa"
        Me.ButtonXoa.Text = "&Không"
        Me.ButtonXoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonXoa.UseVisualStyleBackColor = True
        '
        'ButtonLuu
        '
        Me.ButtonLuu.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonLuu.Image = Global.KhaiPhamLai.My.Resources.Resources.ok
        Me.ButtonLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonLuu.Location = New System.Drawing.Point(427, 3)
        Me.ButtonLuu.Name = "ButtonLuu"
        Me.ButtonLuu.Size = New System.Drawing.Size(65, 35)
        Me.ButtonLuu.TabIndex = 7
        Me.ButtonLuu.Tag = "Lưu tăng ca"
        Me.ButtonLuu.Text = "&Lưu"
        Me.ButtonLuu.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(282, 43)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 13)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "Số công"
        '
        'TextBoxSocong
        '
        Me.TextBoxSocong.Location = New System.Drawing.Point(333, 37)
        Me.TextBoxSocong.Name = "TextBoxSocong"
        Me.TextBoxSocong.Size = New System.Drawing.Size(41, 21)
        Me.TextBoxSocong.TabIndex = 6
        Me.TextBoxSocong.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(190, 43)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "Số ngày"
        '
        'TextBoxSongay
        '
        Me.TextBoxSongay.Location = New System.Drawing.Point(238, 37)
        Me.TextBoxSongay.Name = "TextBoxSongay"
        Me.TextBoxSongay.Size = New System.Drawing.Size(38, 21)
        Me.TextBoxSongay.TabIndex = 5
        Me.TextBoxSongay.Text = "0"
        '
        'Button2
        '
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(157, 37)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(27, 19)
        Me.Button2.TabIndex = 20
        Me.Button2.Tag = "Xem lich nhân viên"
        Me.Button2.Text = "..."
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ComboBoxlydo
        '
        Me.ComboBoxlydo.FormattingEnabled = True
        Me.ComboBoxlydo.Location = New System.Drawing.Point(64, 37)
        Me.ComboBoxlydo.Name = "ComboBoxlydo"
        Me.ComboBoxlydo.Size = New System.Drawing.Size(87, 21)
        Me.ComboBoxlydo.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 41)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Lý do"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Ngày"
        '
        'DateTimePickerNgay
        '
        Me.DateTimePickerNgay.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerNgay.Location = New System.Drawing.Point(62, 10)
        Me.DateTimePickerNgay.Name = "DateTimePickerNgay"
        Me.DateTimePickerNgay.Size = New System.Drawing.Size(87, 21)
        Me.DateTimePickerNgay.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.DateTimePicker2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.DateTimePicker1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(497, 30)
        Me.Panel1.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Image = Global.KhaiPhamLai.My.Resources.Resources.cal
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(427, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(65, 21)
        Me.Button1.TabIndex = 19
        Me.Button1.Tag = "Xem lich nhân viên"
        Me.Button1.Text = "Xem"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(183, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "=>"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(227, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Đến ngày"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(287, 6)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(87, 21)
        Me.DateTimePicker2.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Từ ngày"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(62, 6)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(87, 21)
        Me.DateTimePicker1.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButtonXoa})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(497, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = Global.KhaiPhamLai.My.Resources.Resources.user_add
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(103, 22)
        Me.ToolStripButton1.Text = "&Thêm ngày nghỉ"
        '
        'ToolStripButtonXoa
        '
        Me.ToolStripButtonXoa.Image = Global.KhaiPhamLai.My.Resources.Resources.user_remove
        Me.ToolStripButtonXoa.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonXoa.Name = "ToolStripButtonXoa"
        Me.ToolStripButtonXoa.Size = New System.Drawing.Size(95, 22)
        Me.ToolStripButtonXoa.Text = "&Xóa ngày nghỉ"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'ManHinhNhanVienNghiVanTinhCong
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(794, 578)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MinimumSize = New System.Drawing.Size(800, 600)
        Me.Name = "ManHinhNhanVienNghiVanTinhCong"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nhân viên nghỉ tính công"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.DataGridViewNghi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonXoa As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents DataGridViewNghi As System.Windows.Forms.DataGridView
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ComboBoxlydo As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBoxSocong As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBoxSongay As System.Windows.Forms.TextBox
    Friend WithEvents ButtonXoa As System.Windows.Forms.Button
    Friend WithEvents ButtonLuu As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ColMaNV As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNVSP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTenNV As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTenHT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colChucvu As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDonvi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colQuyen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMathe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNgaysinh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colGioiTinh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDiachi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCMND As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNgayvaolam As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents HiểnThịTấtCảCộtToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ẨnTấtCảCácCộtToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HiểnThịCộtThườngDùngToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DanhSáchCộtToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IDNP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MaNV As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ngay As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Lydo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SoNgay As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SoCong As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
