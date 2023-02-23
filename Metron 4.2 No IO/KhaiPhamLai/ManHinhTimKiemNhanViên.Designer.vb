<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManHinhTimKiemNhanViên
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ManHinhTimKiemNhanViên))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TìmKiếmToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SửaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.InToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ThoátToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.ColMaNV = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colNVSP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTenNV = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTenHT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colChucvu = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDonvi = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colQuyen = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colMathe = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colGioiTinh = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDiachi = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCMND = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colNgayvaolam = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Button4 = New System.Windows.Forms.Button
        Me.chkNgayVaoLam = New System.Windows.Forms.CheckBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.chkGioitinh = New System.Windows.Forms.CheckBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.chkTenHT = New System.Windows.Forms.CheckBox
        Me.chkTenNV = New System.Windows.Forms.CheckBox
        Me.chkNVSP = New System.Windows.Forms.CheckBox
        Me.chkMaNV = New System.Windows.Forms.CheckBox
        Me.dtpNgayvaolam2 = New System.Windows.Forms.DateTimePicker
        Me.cbogioitinh2 = New System.Windows.Forms.ComboBox
        Me.TxtTenHT2 = New System.Windows.Forms.TextBox
        Me.TxtMaNV2 = New System.Windows.Forms.TextBox
        Me.TxtTenNV2 = New System.Windows.Forms.TextBox
        Me.TxtNVSP2 = New System.Windows.Forms.TextBox
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TìmKiếmToolStripMenuItem, Me.SửaToolStripMenuItem, Me.InToolStripMenuItem, Me.ThoátToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(206, 92)
        '
        'TìmKiếmToolStripMenuItem
        '
        Me.TìmKiếmToolStripMenuItem.Name = "TìmKiếmToolStripMenuItem"
        Me.TìmKiếmToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.TìmKiếmToolStripMenuItem.Text = "Tìm kiếm"
        '
        'SửaToolStripMenuItem
        '
        Me.SửaToolStripMenuItem.Name = "SửaToolStripMenuItem"
        Me.SửaToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.SửaToolStripMenuItem.Text = "Sửa Thông Tin Nhân viên"
        '
        'InToolStripMenuItem
        '
        Me.InToolStripMenuItem.Name = "InToolStripMenuItem"
        Me.InToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.InToolStripMenuItem.Text = "In Thông Tin Nhân Viên"
        '
        'ThoátToolStripMenuItem
        '
        Me.ThoátToolStripMenuItem.Name = "ThoátToolStripMenuItem"
        Me.ThoátToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.ThoátToolStripMenuItem.Text = "Thoát"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        Me.ErrorProvider1.Icon = CType(resources.GetObject("ErrorProvider1.Icon"), System.Drawing.Icon)
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
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColMaNV, Me.colNVSP, Me.colTenNV, Me.colTenHT, Me.colChucvu, Me.colDonvi, Me.colQuyen, Me.colMathe, Me.colGioiTinh, Me.colDiachi, Me.colCMND, Me.colNgayvaolam, Me.Column1})
        Me.DataGridView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 125)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(848, 441)
        Me.DataGridView1.TabIndex = 44
        '
        'ColMaNV
        '
        Me.ColMaNV.DataPropertyName = "Manv"
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ColMaNV.DefaultCellStyle = DataGridViewCellStyle2
        Me.ColMaNV.HeaderText = "Mã Cc"
        Me.ColMaNV.Name = "ColMaNV"
        Me.ColMaNV.ReadOnly = True
        '
        'colNVSP
        '
        Me.colNVSP.DataPropertyName = "nvsp"
        Me.colNVSP.HeaderText = "Mã NV"
        Me.colNVSP.Name = "colNVSP"
        Me.colNVSP.ReadOnly = True
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
        Me.colDonvi.DataPropertyName = "TENDV"
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
        Me.colNgayvaolam.HeaderText = "Ngày vào làm"
        Me.colNgayvaolam.Name = "colNgayvaolam"
        Me.colNgayvaolam.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "ngaysinh"
        Me.Column1.HeaderText = "ngày sinh"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Controls.Add(Me.chkNgayVaoLam)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.chkGioitinh)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.chkTenHT)
        Me.GroupBox1.Controls.Add(Me.chkTenNV)
        Me.GroupBox1.Controls.Add(Me.chkNVSP)
        Me.GroupBox1.Controls.Add(Me.chkMaNV)
        Me.GroupBox1.Controls.Add(Me.dtpNgayvaolam2)
        Me.GroupBox1.Controls.Add(Me.cbogioitinh2)
        Me.GroupBox1.Controls.Add(Me.TxtTenHT2)
        Me.GroupBox1.Controls.Add(Me.TxtMaNV2)
        Me.GroupBox1.Controls.Add(Me.TxtTenNV2)
        Me.GroupBox1.Controls.Add(Me.TxtNVSP2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(848, 125)
        Me.GroupBox1.TabIndex = 43
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tìm Kiếm Nhân Viên"
        '
        'Button4
        '
        Me.Button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Image = Global.KhaiPhamLai.My.Resources.Resources.remove1
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.Location = New System.Drawing.Point(761, 96)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 45
        Me.Button4.Tag = "Thoát Khỏi Màn Hình"
        Me.Button4.Text = "T&hoát"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.UseVisualStyleBackColor = True
        '
        'chkNgayVaoLam
        '
        Me.chkNgayVaoLam.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.chkNgayVaoLam.AutoSize = True
        Me.chkNgayVaoLam.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkNgayVaoLam.Location = New System.Drawing.Point(365, 78)
        Me.chkNgayVaoLam.Name = "chkNgayVaoLam"
        Me.chkNgayVaoLam.Size = New System.Drawing.Size(91, 17)
        Me.chkNgayVaoLam.TabIndex = 51
        Me.chkNgayVaoLam.Text = "Ngày vào làm"
        Me.chkNgayVaoLam.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(761, 72)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 44
        Me.Button3.Tag = "In Nhân viện trên Danh Sách ra Giấy"
        Me.Button3.Text = "&Xuất EXCEL"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = Global.KhaiPhamLai.My.Resources.Resources.users
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(761, 41)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 43
        Me.Button2.Tag = "Mở Giao Diện Chi Tiết Nhân Viên Với các Nhân Viên này"
        Me.Button2.Text = "&Sửa NV"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = True
        '
        'chkGioitinh
        '
        Me.chkGioitinh.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.chkGioitinh.AutoSize = True
        Me.chkGioitinh.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkGioitinh.Location = New System.Drawing.Point(365, 48)
        Me.chkGioitinh.Name = "chkGioitinh"
        Me.chkGioitinh.Size = New System.Drawing.Size(66, 17)
        Me.chkGioitinh.TabIndex = 50
        Me.chkGioitinh.Text = "Giới Tính"
        Me.chkGioitinh.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = Global.KhaiPhamLai.My.Resources.Resources.Search
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(761, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 42
        Me.Button1.Tag = "Tìm Kiếm Nhân Viên Theo Điều Kiện"
        Me.Button1.Text = "&Tìm Kiếm"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'chkTenHT
        '
        Me.chkTenHT.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.chkTenHT.AutoSize = True
        Me.chkTenHT.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTenHT.Location = New System.Drawing.Point(15, 80)
        Me.chkTenHT.Name = "chkTenHT"
        Me.chkTenHT.Size = New System.Drawing.Size(85, 17)
        Me.chkTenHT.TabIndex = 49
        Me.chkTenHT.Text = "Tên Hiển Thị"
        Me.chkTenHT.UseVisualStyleBackColor = True
        '
        'chkTenNV
        '
        Me.chkTenNV.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.chkTenNV.AutoSize = True
        Me.chkTenNV.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTenNV.Location = New System.Drawing.Point(13, 51)
        Me.chkTenNV.Name = "chkTenNV"
        Me.chkTenNV.Size = New System.Drawing.Size(95, 17)
        Me.chkTenNV.TabIndex = 48
        Me.chkTenNV.Text = "Tên Nhân Viên"
        Me.chkTenNV.UseVisualStyleBackColor = True
        '
        'chkNVSP
        '
        Me.chkNVSP.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.chkNVSP.AutoSize = True
        Me.chkNVSP.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkNVSP.Location = New System.Drawing.Point(365, 20)
        Me.chkNVSP.Name = "chkNVSP"
        Me.chkNVSP.Size = New System.Drawing.Size(91, 17)
        Me.chkNVSP.TabIndex = 47
        Me.chkNVSP.Text = "Mã Nhân Viên"
        Me.chkNVSP.UseVisualStyleBackColor = True
        '
        'chkMaNV
        '
        Me.chkMaNV.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.chkMaNV.AutoSize = True
        Me.chkMaNV.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMaNV.Location = New System.Drawing.Point(13, 23)
        Me.chkMaNV.Name = "chkMaNV"
        Me.chkMaNV.Size = New System.Drawing.Size(98, 17)
        Me.chkMaNV.TabIndex = 46
        Me.chkMaNV.Text = "Mã Chấm Công"
        Me.chkMaNV.UseVisualStyleBackColor = True
        '
        'dtpNgayvaolam2
        '
        Me.dtpNgayvaolam2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.dtpNgayvaolam2.CalendarFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpNgayvaolam2.Enabled = False
        Me.dtpNgayvaolam2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpNgayvaolam2.Location = New System.Drawing.Point(475, 75)
        Me.dtpNgayvaolam2.Name = "dtpNgayvaolam2"
        Me.dtpNgayvaolam2.Size = New System.Drawing.Size(200, 21)
        Me.dtpNgayvaolam2.TabIndex = 45
        Me.dtpNgayvaolam2.Tag = "1"
        '
        'cbogioitinh2
        '
        Me.cbogioitinh2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cbogioitinh2.BackColor = System.Drawing.Color.White
        Me.cbogioitinh2.Enabled = False
        Me.cbogioitinh2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbogioitinh2.FormattingEnabled = True
        Me.cbogioitinh2.Location = New System.Drawing.Point(475, 44)
        Me.cbogioitinh2.Name = "cbogioitinh2"
        Me.cbogioitinh2.Size = New System.Drawing.Size(50, 21)
        Me.cbogioitinh2.TabIndex = 44
        Me.cbogioitinh2.Tag = "1"
        Me.cbogioitinh2.Text = "Nam"
        '
        'TxtTenHT2
        '
        Me.TxtTenHT2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TxtTenHT2.BackColor = System.Drawing.SystemColors.Window
        Me.TxtTenHT2.Enabled = False
        Me.TxtTenHT2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTenHT2.Location = New System.Drawing.Point(130, 76)
        Me.TxtTenHT2.Name = "TxtTenHT2"
        Me.TxtTenHT2.Size = New System.Drawing.Size(141, 21)
        Me.TxtTenHT2.TabIndex = 43
        Me.TxtTenHT2.Tag = "1"
        '
        'TxtMaNV2
        '
        Me.TxtMaNV2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TxtMaNV2.BackColor = System.Drawing.SystemColors.Window
        Me.TxtMaNV2.Enabled = False
        Me.TxtMaNV2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMaNV2.Location = New System.Drawing.Point(130, 20)
        Me.TxtMaNV2.Name = "TxtMaNV2"
        Me.TxtMaNV2.Size = New System.Drawing.Size(71, 21)
        Me.TxtMaNV2.TabIndex = 40
        Me.TxtMaNV2.Tag = "1"
        '
        'TxtTenNV2
        '
        Me.TxtTenNV2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TxtTenNV2.BackColor = System.Drawing.SystemColors.Window
        Me.TxtTenNV2.Enabled = False
        Me.TxtTenNV2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTenNV2.Location = New System.Drawing.Point(130, 48)
        Me.TxtTenNV2.Name = "TxtTenNV2"
        Me.TxtTenNV2.Size = New System.Drawing.Size(141, 21)
        Me.TxtTenNV2.TabIndex = 42
        Me.TxtTenNV2.Tag = "1"
        '
        'TxtNVSP2
        '
        Me.TxtNVSP2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TxtNVSP2.BackColor = System.Drawing.SystemColors.Window
        Me.TxtNVSP2.Enabled = False
        Me.TxtNVSP2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNVSP2.Location = New System.Drawing.Point(475, 17)
        Me.TxtNVSP2.Name = "TxtNVSP2"
        Me.TxtNVSP2.Size = New System.Drawing.Size(71, 21)
        Me.TxtNVSP2.TabIndex = 41
        Me.TxtNVSP2.Tag = "1"
        '
        'ManHinhTimKiemNhanViên
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(848, 566)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ManHinhTimKiemNhanViên"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tìm Kiem Nhân Viên"
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TìmKiếmToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SửaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ThoátToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkNgayVaoLam As System.Windows.Forms.CheckBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents chkGioitinh As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents chkTenHT As System.Windows.Forms.CheckBox
    Friend WithEvents chkTenNV As System.Windows.Forms.CheckBox
    Friend WithEvents chkNVSP As System.Windows.Forms.CheckBox
    Friend WithEvents chkMaNV As System.Windows.Forms.CheckBox
    Friend WithEvents dtpNgayvaolam2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbogioitinh2 As System.Windows.Forms.ComboBox
    Friend WithEvents TxtTenHT2 As System.Windows.Forms.TextBox
    Friend WithEvents TxtMaNV2 As System.Windows.Forms.TextBox
    Friend WithEvents TxtTenNV2 As System.Windows.Forms.TextBox
    Friend WithEvents TxtNVSP2 As System.Windows.Forms.TextBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents ColMaNV As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNVSP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTenNV As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTenHT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colChucvu As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDonvi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colQuyen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMathe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colGioiTinh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDiachi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCMND As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNgayvaolam As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
End Class
