<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManHinhTaiDulieu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ManHinhTaiDulieu))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Chon = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.BVan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColMaNV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNVSP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTenNV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTenHT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colChucvu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDonvi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQuyen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMathe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNgaysinh = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colGioiTinh = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDiachi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCMND = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNgayvaolam = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VanId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ChọnTấtCảToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ĐảoChọnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Pb = New System.Windows.Forms.ProgressBar()
        Me.chkTaiVT = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageList
        '
        Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList.Images.SetKeyName(0, "")
        Me.ImageList.Images.SetKeyName(1, "")
        Me.ImageList.Images.SetKeyName(2, "MayCCNho12.JPG")
        Me.ImageList.Images.SetKeyName(3, "MayCCNho13.JPG")
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AllowDrop = True
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.52023!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.47977!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TreeView1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.DataGridView1, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ListView1, 2, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 32)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(794, 463)
        Me.TableLayoutPanel1.TabIndex = 4
        '
        'TreeView1
        '
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView1.ImageIndex = 1
        Me.TreeView1.ImageList = Me.ImageList1
        Me.TreeView1.Location = New System.Drawing.Point(3, 3)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.SelectedImageIndex = 0
        Me.TreeView1.Size = New System.Drawing.Size(133, 457)
        Me.TreeView1.TabIndex = 6
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
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Chon, Me.BVan, Me.ColMaNV, Me.colNVSP, Me.colTenNV, Me.colTenHT, Me.colChucvu, Me.colDonvi, Me.colQuyen, Me.colMathe, Me.colNgaysinh, Me.colGioiTinh, Me.colDiachi, Me.colCMND, Me.colNgayvaolam, Me.VanId})
        Me.DataGridView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(142, 3)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(535, 457)
        Me.DataGridView1.TabIndex = 7
        Me.DataGridView1.Tag = "8"
        '
        'Chon
        '
        Me.Chon.HeaderText = ""
        Me.Chon.Name = "Chon"
        Me.Chon.Width = 20
        '
        'BVan
        '
        Me.BVan.HeaderText = "BVan"
        Me.BVan.Name = "BVan"
        '
        'ColMaNV
        '
        Me.ColMaNV.DataPropertyName = "Manv"
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ColMaNV.DefaultCellStyle = DataGridViewCellStyle2
        Me.ColMaNV.HeaderText = "Mã Cc"
        Me.ColMaNV.Name = "ColMaNV"
        Me.ColMaNV.Width = 50
        '
        'colNVSP
        '
        Me.colNVSP.DataPropertyName = "nvsp"
        Me.colNVSP.HeaderText = "Mã NV"
        Me.colNVSP.Name = "colNVSP"
        Me.colNVSP.Width = 50
        '
        'colTenNV
        '
        Me.colTenNV.DataPropertyName = "tenNV"
        Me.colTenNV.HeaderText = "Tên NV"
        Me.colTenNV.Name = "colTenNV"
        '
        'colTenHT
        '
        Me.colTenHT.DataPropertyName = "TenHT"
        Me.colTenHT.HeaderText = "Tên Hiển Thị"
        Me.colTenHT.Name = "colTenHT"
        '
        'colChucvu
        '
        Me.colChucvu.DataPropertyName = "chucvu"
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colChucvu.DefaultCellStyle = DataGridViewCellStyle3
        Me.colChucvu.HeaderText = "Chức vụ"
        Me.colChucvu.Name = "colChucvu"
        Me.colChucvu.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'colDonvi
        '
        Me.colDonvi.DataPropertyName = "TenDV"
        Me.colDonvi.HeaderText = "Đơn vị"
        Me.colDonvi.Name = "colDonvi"
        Me.colDonvi.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'colQuyen
        '
        Me.colQuyen.DataPropertyName = "quyen"
        Me.colQuyen.HeaderText = "Quyền"
        Me.colQuyen.Name = "colQuyen"
        Me.colQuyen.Visible = False
        '
        'colMathe
        '
        Me.colMathe.DataPropertyName = "cardno"
        Me.colMathe.HeaderText = "Mã Thẻ"
        Me.colMathe.Name = "colMathe"
        '
        'colNgaysinh
        '
        Me.colNgaysinh.DataPropertyName = "ngaysinh"
        Me.colNgaysinh.HeaderText = "Ngày sinh"
        Me.colNgaysinh.Name = "colNgaysinh"
        '
        'colGioiTinh
        '
        Me.colGioiTinh.DataPropertyName = "gioitinh"
        Me.colGioiTinh.HeaderText = "Giới tính"
        Me.colGioiTinh.Name = "colGioiTinh"
        '
        'colDiachi
        '
        Me.colDiachi.DataPropertyName = "diachi"
        Me.colDiachi.HeaderText = "Địa chỉ"
        Me.colDiachi.Name = "colDiachi"
        '
        'colCMND
        '
        Me.colCMND.DataPropertyName = "cmnd"
        Me.colCMND.HeaderText = "CMND"
        Me.colCMND.Name = "colCMND"
        '
        'colNgayvaolam
        '
        Me.colNgayvaolam.DataPropertyName = "ngayvaolam"
        Me.colNgayvaolam.HeaderText = "Ngày vào lảm"
        Me.colNgayvaolam.Name = "colNgayvaolam"
        '
        'VanId
        '
        Me.VanId.HeaderText = "VanId"
        Me.VanId.Name = "VanId"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChọnTấtCảToolStripMenuItem, Me.ĐảoChọnToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(131, 48)
        '
        'ChọnTấtCảToolStripMenuItem
        '
        Me.ChọnTấtCảToolStripMenuItem.Name = "ChọnTấtCảToolStripMenuItem"
        Me.ChọnTấtCảToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
        Me.ChọnTấtCảToolStripMenuItem.Text = "Chọn tất cả"
        '
        'ĐảoChọnToolStripMenuItem
        '
        Me.ĐảoChọnToolStripMenuItem.Name = "ĐảoChọnToolStripMenuItem"
        Me.ĐảoChọnToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
        Me.ĐảoChọnToolStripMenuItem.Text = "Đảo chọn"
        '
        'ListView1
        '
        Me.ListView1.BackColor = System.Drawing.Color.White
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(683, 3)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(108, 457)
        Me.ListView1.SmallImageList = Me.ImageList
        Me.ListView1.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.ListView1.TabIndex = 5
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'ToolTip1
        '
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        '
        'Button3
        '
        Me.Button3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Button3.Location = New System.Drawing.Point(715, 6)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(67, 49)
        Me.Button3.TabIndex = 0
        Me.Button3.Text = "Thoát"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Pb
        '
        Me.Pb.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pb.Location = New System.Drawing.Point(0, 60)
        Me.Pb.Name = "Pb"
        Me.Pb.Size = New System.Drawing.Size(794, 23)
        Me.Pb.TabIndex = 3
        '
        'chkTaiVT
        '
        Me.chkTaiVT.AutoSize = True
        Me.chkTaiVT.Location = New System.Drawing.Point(12, 18)
        Me.chkTaiVT.Name = "chkTaiVT"
        Me.chkTaiVT.Size = New System.Drawing.Size(181, 17)
        Me.chkTaiVT.TabIndex = 2
        Me.chkTaiVT.Text = "Đưa vân tay lên máy chấm công"
        Me.chkTaiVT.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.Pb)
        Me.Panel1.Controls.Add(Me.chkTaiVT)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 495)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(794, 83)
        Me.Panel1.TabIndex = 3
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Button1.Location = New System.Drawing.Point(512, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(187, 49)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Đưa lên máy chấm công"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(682, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 28)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Máy chấm công"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(201, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(266, 28)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Danh sách nhân viên"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(0, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(139, 28)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Bộ phận"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ManHinhTaiDulieu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(794, 578)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(800, 600)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(800, 600)
        Me.Name = "ManHinhTaiDulieu"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tải dử liệu lên máy chấm công"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ImageList As System.Windows.Forms.ImageList
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ChọnTấtCảToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ĐảoChọnToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Pb As System.Windows.Forms.ProgressBar
    Friend WithEvents chkTaiVT As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Chon As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents BVan As System.Windows.Forms.DataGridViewTextBoxColumn
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
    Friend WithEvents VanId As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
