<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManHinhThietLapMCC
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
        Me.components = New System.ComponentModel.Container()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ThêmMCCToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.XoáMCCToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LưuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.LstDanhSachMcc = New System.Windows.Forms.ListBox()
        Me.RB_USB = New System.Windows.Forms.RadioButton()
        Me.cboLoaimay = New System.Windows.Forms.ComboBox()
        Me.txtMaySO = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPass = New System.Windows.Forms.TextBox()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.rdbIP = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboRate = New System.Windows.Forms.ComboBox()
        Me.cboCong = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtCong = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lstIP = New System.Windows.Forms.ListBox()
        Me.butChuyenIp = New System.Windows.Forms.Button()
        Me.butKTIP = New System.Windows.Forms.Button()
        Me.txtIP = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtvtri = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtTenMay = New System.Windows.Forms.TextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ThêmMCCToolStripMenuItem, Me.XoáMCCToolStripMenuItem, Me.LưuToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(137, 70)
        '
        'ThêmMCCToolStripMenuItem
        '
        Me.ThêmMCCToolStripMenuItem.Image = Global.KhaiPhamLai.My.Resources.Resources.them
        Me.ThêmMCCToolStripMenuItem.Name = "ThêmMCCToolStripMenuItem"
        Me.ThêmMCCToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.ThêmMCCToolStripMenuItem.Text = "Thêm MCC"
        '
        'XoáMCCToolStripMenuItem
        '
        Me.XoáMCCToolStripMenuItem.Image = Global.KhaiPhamLai.My.Resources.Resources.xoa
        Me.XoáMCCToolStripMenuItem.Name = "XoáMCCToolStripMenuItem"
        Me.XoáMCCToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.XoáMCCToolStripMenuItem.Text = "Xoá MCC"
        '
        'LưuToolStripMenuItem
        '
        Me.LưuToolStripMenuItem.Image = Global.KhaiPhamLai.My.Resources.Resources.ghi
        Me.LưuToolStripMenuItem.Name = "LưuToolStripMenuItem"
        Me.LưuToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.LưuToolStripMenuItem.Text = "Lưu MCC"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.SplitContainer1.Panel1.Controls.Add(Me.LstDanhSachMcc)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainer1.Panel2.Controls.Add(Me.RB_USB)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cboLoaimay)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtMaySO)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label9)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label6)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtPass)
        Me.SplitContainer1.Panel2.Controls.Add(Me.RadioButton2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.rdbIP)
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtvtri)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TxtTenMay)
        Me.SplitContainer1.Size = New System.Drawing.Size(527, 406)
        Me.SplitContainer1.SplitterDistance = 204
        Me.SplitContainer1.TabIndex = 2
        '
        'LstDanhSachMcc
        '
        Me.LstDanhSachMcc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LstDanhSachMcc.FormattingEnabled = True
        Me.LstDanhSachMcc.Location = New System.Drawing.Point(0, 0)
        Me.LstDanhSachMcc.Name = "LstDanhSachMcc"
        Me.LstDanhSachMcc.Size = New System.Drawing.Size(204, 406)
        Me.LstDanhSachMcc.TabIndex = 0
        '
        'RB_USB
        '
        Me.RB_USB.AutoSize = True
        Me.RB_USB.Location = New System.Drawing.Point(13, 356)
        Me.RB_USB.Name = "RB_USB"
        Me.RB_USB.Size = New System.Drawing.Size(74, 17)
        Me.RB_USB.TabIndex = 18
        Me.RB_USB.TabStop = True
        Me.RB_USB.Text = "USB Client"
        Me.RB_USB.UseVisualStyleBackColor = True
        '
        'cboLoaimay
        '
        Me.cboLoaimay.FormattingEnabled = True
        Me.cboLoaimay.Location = New System.Drawing.Point(95, 37)
        Me.cboLoaimay.Name = "cboLoaimay"
        Me.cboLoaimay.Size = New System.Drawing.Size(192, 21)
        Me.cboLoaimay.TabIndex = 17
        Me.cboLoaimay.Tag = "1"
        '
        'txtMaySO
        '
        Me.txtMaySO.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMaySO.Location = New System.Drawing.Point(95, 12)
        Me.txtMaySO.Name = "txtMaySO"
        Me.txtMaySO.Size = New System.Drawing.Size(192, 21)
        Me.txtMaySO.TabIndex = 16
        Me.txtMaySO.Tag = "1"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(27, 15)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 13)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Số máy"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(27, 37)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Loại máy"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label4.Location = New System.Drawing.Point(27, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Mật khẩu"
        '
        'txtPass
        '
        Me.txtPass.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPass.Location = New System.Drawing.Point(95, 61)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.Size = New System.Drawing.Size(192, 21)
        Me.txtPass.TabIndex = 11
        Me.txtPass.Tag = "1"
        Me.txtPass.UseSystemPasswordChar = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(13, 264)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(48, 17)
        Me.RadioButton2.TabIndex = 8
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "COM"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'rdbIP
        '
        Me.rdbIP.AutoSize = True
        Me.rdbIP.Location = New System.Drawing.Point(13, 137)
        Me.rdbIP.Name = "rdbIP"
        Me.rdbIP.Size = New System.Drawing.Size(35, 17)
        Me.rdbIP.TabIndex = 8
        Me.rdbIP.TabStop = True
        Me.rdbIP.Text = "IP"
        Me.rdbIP.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboRate)
        Me.GroupBox2.Controls.Add(Me.cboCong)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Location = New System.Drawing.Point(25, 276)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(285, 74)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        '
        'cboRate
        '
        Me.cboRate.FormattingEnabled = True
        Me.cboRate.Location = New System.Drawing.Point(42, 42)
        Me.cboRate.Name = "cboRate"
        Me.cboRate.Size = New System.Drawing.Size(220, 21)
        Me.cboRate.TabIndex = 6
        Me.cboRate.Tag = "1"
        '
        'cboCong
        '
        Me.cboCong.FormattingEnabled = True
        Me.cboCong.Location = New System.Drawing.Point(41, 14)
        Me.cboCong.Name = "cboCong"
        Me.cboCong.Size = New System.Drawing.Size(221, 21)
        Me.cboCong.TabIndex = 5
        Me.cboCong.Tag = "1"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(2, 45)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 13)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Rate:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(2, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "COM:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtCong)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.lstIP)
        Me.GroupBox1.Controls.Add(Me.butChuyenIp)
        Me.GroupBox1.Controls.Add(Me.butKTIP)
        Me.GroupBox1.Controls.Add(Me.txtIP)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(25, 148)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(285, 110)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'txtCong
        '
        Me.txtCong.AutoCompleteCustomSource.AddRange(New String() {"???:???:???:???"})
        Me.txtCong.Location = New System.Drawing.Point(183, 11)
        Me.txtCong.Name = "txtCong"
        Me.txtCong.Size = New System.Drawing.Size(45, 21)
        Me.txtCong.TabIndex = 7
        Me.txtCong.Tag = "1"
        Me.txtCong.Text = "0"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(234, 71)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(28, 24)
        Me.Button1.TabIndex = 6
        Me.Button1.Tag = ""
        Me.Button1.Text = "..."
        Me.ToolTip1.SetToolTip(Me.Button1, "Kiểm tra Toàn Bộ ip trong Khoản")
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lstIP
        '
        Me.lstIP.FormattingEnabled = True
        Me.lstIP.Location = New System.Drawing.Point(39, 42)
        Me.lstIP.Name = "lstIP"
        Me.lstIP.Size = New System.Drawing.Size(189, 56)
        Me.lstIP.TabIndex = 5
        '
        'butChuyenIp
        '
        Me.butChuyenIp.Location = New System.Drawing.Point(234, 42)
        Me.butChuyenIp.Name = "butChuyenIp"
        Me.butChuyenIp.Size = New System.Drawing.Size(28, 24)
        Me.butChuyenIp.TabIndex = 3
        Me.butChuyenIp.Tag = ""
        Me.butChuyenIp.Text = "..?"
        Me.ToolTip1.SetToolTip(Me.butChuyenIp, "Kiểm tra IP trong giới hạn " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Dừng lại Khi Tìm Được")
        Me.butChuyenIp.UseVisualStyleBackColor = True
        '
        'butKTIP
        '
        Me.butKTIP.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butKTIP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.butKTIP.Location = New System.Drawing.Point(234, 14)
        Me.butKTIP.Name = "butKTIP"
        Me.butKTIP.Size = New System.Drawing.Size(28, 23)
        Me.butKTIP.TabIndex = 2
        Me.butKTIP.Tag = ""
        Me.butKTIP.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.butKTIP, "Kiểm tra ip có tồn tại không")
        Me.butKTIP.UseVisualStyleBackColor = True
        '
        'txtIP
        '
        Me.txtIP.AutoCompleteCustomSource.AddRange(New String() {"???:???:???:???"})
        Me.txtIP.Location = New System.Drawing.Point(39, 11)
        Me.txtIP.Name = "txtIP"
        Me.txtIP.Size = New System.Drawing.Size(138, 21)
        Me.txtIP.TabIndex = 1
        Me.txtIP.Tag = "1"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(21, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "IP:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(31, 115)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Vị trí"
        '
        'txtvtri
        '
        Me.txtvtri.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtvtri.Location = New System.Drawing.Point(95, 112)
        Me.txtvtri.Name = "txtvtri"
        Me.txtvtri.Size = New System.Drawing.Size(192, 21)
        Me.txtvtri.TabIndex = 2
        Me.txtvtri.Tag = "1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(27, 92)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Tên máy"
        '
        'TxtTenMay
        '
        Me.TxtTenMay.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTenMay.Location = New System.Drawing.Point(95, 85)
        Me.TxtTenMay.Name = "TxtTenMay"
        Me.TxtTenMay.Size = New System.Drawing.Size(192, 21)
        Me.TxtTenMay.TabIndex = 0
        Me.TxtTenMay.Tag = "1"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripButton3})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(527, 25)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = Global.KhaiPhamLai.My.Resources.Resources.user_add
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(78, 22)
        Me.ToolStripButton1.Tag = "Thêm Máy Chấm Công"
        Me.ToolStripButton1.Text = "Thêm MCC"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Image = Global.KhaiPhamLai.My.Resources.Resources.user_remove
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(70, 22)
        Me.ToolStripButton2.Tag = "Xoá Mấy Chấm Công"
        Me.ToolStripButton2.Text = "Xoá MCC"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Image = Global.KhaiPhamLai.My.Resources.Resources.users
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(70, 22)
        Me.ToolStripButton3.Tag = "Lưu Máy Chấm Công"
        Me.ToolStripButton3.Text = "Lưu MCC"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar1, Me.ToolStripDropDownButton1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 409)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(527, 22)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Maximum = 254
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(420, 16)
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.Image = Global.KhaiPhamLai.My.Resources.Resources.reload
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(88, 20)
        Me.ToolStripDropDownButton1.Text = "Giới Hạn IP"
        Me.ToolStripDropDownButton1.ToolTipText = "Giới Hạn Ip"
        '
        'ManHinhThietLapMCC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(527, 431)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(529, 421)
        Me.Name = "ManHinhThietLapMCC"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Thiết lập thông tin máy chấm công"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtTenMay As System.Windows.Forms.TextBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtvtri As System.Windows.Forms.TextBox
    Friend WithEvents txtIP As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents butKTIP As System.Windows.Forms.Button
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents cboRate As System.Windows.Forms.ComboBox
    Friend WithEvents cboCong As System.Windows.Forms.ComboBox
    Friend WithEvents ThêmMCCToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents XoáMCCToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lstIP As System.Windows.Forms.ListBox
    Friend WithEvents butChuyenIp As System.Windows.Forms.Button
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents rdbIP As System.Windows.Forms.RadioButton
    Friend WithEvents LưuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LstDanhSachMcc As System.Windows.Forms.ListBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPass As System.Windows.Forms.TextBox
    Friend WithEvents txtMaySO As System.Windows.Forms.TextBox
    Friend WithEvents cboLoaimay As System.Windows.Forms.ComboBox
    Friend WithEvents txtCong As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents RB_USB As System.Windows.Forms.RadioButton
End Class
