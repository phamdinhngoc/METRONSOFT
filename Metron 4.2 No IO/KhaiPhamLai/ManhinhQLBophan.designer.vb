<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManhinhQLBophan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ManhinhQLBophan))
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ThêmToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SửaBộPhậnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.XóaBộPhậnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ThêmToolStripMenuItem, Me.SửaBộPhậnToolStripMenuItem, Me.XóaBộPhậnToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(133, 70)
        '
        'ThêmToolStripMenuItem
        '
        Me.ThêmToolStripMenuItem.Image = Global.KhaiPhamLai.My.Resources.Resources.user_add
        Me.ThêmToolStripMenuItem.Name = "ThêmToolStripMenuItem"
        Me.ThêmToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.ThêmToolStripMenuItem.Text = "Thêm đơn vị"
        '
        'SửaBộPhậnToolStripMenuItem
        '
        Me.SửaBộPhậnToolStripMenuItem.Image = Global.KhaiPhamLai.My.Resources.Resources.users
        Me.SửaBộPhậnToolStripMenuItem.Name = "SửaBộPhậnToolStripMenuItem"
        Me.SửaBộPhậnToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.SửaBộPhậnToolStripMenuItem.Text = "Sửa đơn vị"
        '
        'XóaBộPhậnToolStripMenuItem
        '
        Me.XóaBộPhậnToolStripMenuItem.Image = Global.KhaiPhamLai.My.Resources.Resources.user_remove
        Me.XóaBộPhậnToolStripMenuItem.Name = "XóaBộPhậnToolStripMenuItem"
        Me.XóaBộPhậnToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.XóaBộPhậnToolStripMenuItem.Text = "Xóa đơn vị"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripSeparator1, Me.ToolStripButton3, Me.ToolStripSeparator2, Me.ToolStripButton2})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(284, 25)
        Me.ToolStrip2.TabIndex = 3
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = Global.KhaiPhamLai.My.Resources.Resources.insert
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(53, 22)
        Me.ToolStripButton1.Tag = "Thêm Bộ Phận(Phòng Ban)"
        Me.ToolStripButton1.Text = "Thêm"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Image = Global.KhaiPhamLai.My.Resources.Resources.edit
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(46, 22)
        Me.ToolStripButton3.Tag = "Sửa Bộ Phận(Phòng Ban)"
        Me.ToolStripButton3.Text = "Sửa"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Image = Global.KhaiPhamLai.My.Resources.Resources.remove1
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(45, 22)
        Me.ToolStripButton2.Tag = "Xoá Bộ Phận(Phòng Ban)"
        Me.ToolStripButton2.Text = "Xoá"
        '
        'TreeView1
        '
        Me.TreeView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView1.ImageIndex = 1
        Me.TreeView1.ImageList = Me.ImageList1
        Me.TreeView1.Location = New System.Drawing.Point(0, 25)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.SelectedImageIndex = 0
        Me.TreeView1.Size = New System.Drawing.Size(284, 243)
        Me.TreeView1.TabIndex = 4
        Me.TreeView1.Tag = "8"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "classmate_48.ico")
        Me.ImageList1.Images.SetKeyName(1, "architecture_32.ico")
        '
        'ManhinhQLBophan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(284, 268)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximumSize = New System.Drawing.Size(290, 290)
        Me.MinimumSize = New System.Drawing.Size(290, 290)
        Me.Name = "ManhinhQLBophan"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Quản lý đơn vị"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ThêmToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SửaBộPhậnToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents XóaBộPhậnToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
End Class
