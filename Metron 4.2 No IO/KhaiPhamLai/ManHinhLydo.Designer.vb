<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManHinhLydo
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
        Me.IDLD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Lydo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NgayQD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SoCong = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ThêmToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.XóaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SửaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
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
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDLD, Me.Lydo, Me.NgayQD, Me.SoCong})
        Me.DataGridView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(352, 246)
        Me.DataGridView1.TabIndex = 0
        '
        'IDLD
        '
        Me.IDLD.DataPropertyName = "IDLD"
        Me.IDLD.HeaderText = "IDLD"
        Me.IDLD.Name = "IDLD"
        Me.IDLD.ReadOnly = True
        Me.IDLD.Visible = False
        '
        'Lydo
        '
        Me.Lydo.DataPropertyName = "Lydo"
        Me.Lydo.HeaderText = "Lý do"
        Me.Lydo.Name = "Lydo"
        Me.Lydo.ReadOnly = True
        '
        'NgayQD
        '
        Me.NgayQD.DataPropertyName = "NgayQD"
        Me.NgayQD.HeaderText = "Số ngày"
        Me.NgayQD.Name = "NgayQD"
        Me.NgayQD.ReadOnly = True
        '
        'SoCong
        '
        Me.SoCong.DataPropertyName = "SoCong"
        Me.SoCong.HeaderText = "Số công"
        Me.SoCong.Name = "SoCong"
        Me.SoCong.ReadOnly = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ThêmToolStripMenuItem, Me.XóaToolStripMenuItem, Me.SửaToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(138, 70)
        '
        'ThêmToolStripMenuItem
        '
        Me.ThêmToolStripMenuItem.Image = Global.KhaiPhamLai.My.Resources.Resources.user_add
        Me.ThêmToolStripMenuItem.Name = "ThêmToolStripMenuItem"
        Me.ThêmToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.ThêmToolStripMenuItem.Text = "Thêm lý do"
        '
        'XóaToolStripMenuItem
        '
        Me.XóaToolStripMenuItem.Image = Global.KhaiPhamLai.My.Resources.Resources.user_remove
        Me.XóaToolStripMenuItem.Name = "XóaToolStripMenuItem"
        Me.XóaToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.XóaToolStripMenuItem.Text = "Xóa lý do"
        '
        'SửaToolStripMenuItem
        '
        Me.SửaToolStripMenuItem.Image = Global.KhaiPhamLai.My.Resources.Resources.users
        Me.SửaToolStripMenuItem.Name = "SửaToolStripMenuItem"
        Me.SửaToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.SửaToolStripMenuItem.Text = "Sửa lý do"
        '
        'ManHinhLydo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(352, 246)
        Me.Controls.Add(Me.DataGridView1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ManHinhLydo"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lý do"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ThêmToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents XóaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SửaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IDLD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Lydo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NgayQD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SoCong As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
