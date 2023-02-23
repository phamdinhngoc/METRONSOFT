<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManHinhXemNguoidung
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.UserID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Pass = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ThêmToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.XoáNgườiDùngToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MậtKhẩuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.QuyềnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CâuHỏi1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TrảLời1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CâuHỏi2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TrảLời2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.UserID, Me.Pass, Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5})
        Me.DataGridView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(742, 566)
        Me.DataGridView1.TabIndex = 0
        '
        'UserID
        '
        Me.UserID.DataPropertyName = "userID"
        Me.UserID.HeaderText = "Tên Đăng Nhập"
        Me.UserID.Name = "UserID"
        Me.UserID.ReadOnly = True
        Me.UserID.Width = 150
        '
        'Pass
        '
        Me.Pass.DataPropertyName = "pass"
        Me.Pass.HeaderText = "Mật Khẩu"
        Me.Pass.Name = "Pass"
        Me.Pass.ReadOnly = True
        Me.Pass.Visible = False
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "quyen"
        Me.Column1.HeaderText = "Quyền Sử Dụng"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 150
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "cauhoi1"
        Me.Column2.HeaderText = "Câu Hỏi 1"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "traloi1"
        Me.Column3.HeaderText = "Trả Lời 1"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "cauhoi2"
        Me.Column4.HeaderText = "Câu Hỏi 2"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.DataPropertyName = "traloi2"
        Me.Column5.HeaderText = "Trả Lời 2"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ThêmToolStripMenuItem, Me.XoáNgườiDùngToolStripMenuItem, Me.DaToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(174, 70)
        '
        'ThêmToolStripMenuItem
        '
        Me.ThêmToolStripMenuItem.Name = "ThêmToolStripMenuItem"
        Me.ThêmToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.ThêmToolStripMenuItem.Text = "Thêm  Người Dùng"
        '
        'XoáNgườiDùngToolStripMenuItem
        '
        Me.XoáNgườiDùngToolStripMenuItem.Name = "XoáNgườiDùngToolStripMenuItem"
        Me.XoáNgườiDùngToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.XoáNgườiDùngToolStripMenuItem.Text = "Xoá Người Dùng"
        '
        'DaToolStripMenuItem
        '
        Me.DaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MậtKhẩuToolStripMenuItem, Me.QuyềnToolStripMenuItem, Me.CâuHỏi1ToolStripMenuItem, Me.TrảLời1ToolStripMenuItem, Me.CâuHỏi2ToolStripMenuItem, Me.TrảLời2ToolStripMenuItem})
        Me.DaToolStripMenuItem.Name = "DaToolStripMenuItem"
        Me.DaToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.DaToolStripMenuItem.Text = "Danh Sách Cột"
        '
        'MậtKhẩuToolStripMenuItem
        '
        Me.MậtKhẩuToolStripMenuItem.Name = "MậtKhẩuToolStripMenuItem"
        Me.MậtKhẩuToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
        Me.MậtKhẩuToolStripMenuItem.Text = "Mật Khẩu"
        '
        'QuyềnToolStripMenuItem
        '
        Me.QuyềnToolStripMenuItem.Checked = True
        Me.QuyềnToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.QuyềnToolStripMenuItem.Name = "QuyềnToolStripMenuItem"
        Me.QuyềnToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
        Me.QuyềnToolStripMenuItem.Text = "Quyền"
        '
        'CâuHỏi1ToolStripMenuItem
        '
        Me.CâuHỏi1ToolStripMenuItem.Checked = True
        Me.CâuHỏi1ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CâuHỏi1ToolStripMenuItem.Name = "CâuHỏi1ToolStripMenuItem"
        Me.CâuHỏi1ToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
        Me.CâuHỏi1ToolStripMenuItem.Text = "Câu hỏi 1"
        '
        'TrảLời1ToolStripMenuItem
        '
        Me.TrảLời1ToolStripMenuItem.Checked = True
        Me.TrảLời1ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TrảLời1ToolStripMenuItem.Name = "TrảLời1ToolStripMenuItem"
        Me.TrảLời1ToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
        Me.TrảLời1ToolStripMenuItem.Text = "Trả Lời 1"
        '
        'CâuHỏi2ToolStripMenuItem
        '
        Me.CâuHỏi2ToolStripMenuItem.Checked = True
        Me.CâuHỏi2ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CâuHỏi2ToolStripMenuItem.Name = "CâuHỏi2ToolStripMenuItem"
        Me.CâuHỏi2ToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
        Me.CâuHỏi2ToolStripMenuItem.Text = "Câu hỏi 2"
        '
        'TrảLời2ToolStripMenuItem
        '
        Me.TrảLời2ToolStripMenuItem.Checked = True
        Me.TrảLời2ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TrảLời2ToolStripMenuItem.Name = "TrảLời2ToolStripMenuItem"
        Me.TrảLời2ToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
        Me.TrảLời2ToolStripMenuItem.Text = "Trả Lời 2"
        '
        'ManHinhXemNguoidung
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(742, 566)
        Me.Controls.Add(Me.DataGridView1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ManHinhXemNguoidung"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Danh sách tài khoản người sử dụng trong phần mềm"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ThêmToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents XoáNgườiDùngToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UserID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pass As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MậtKhẩuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents QuyềnToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CâuHỏi1ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TrảLời1ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CâuHỏi2ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TrảLời2ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
