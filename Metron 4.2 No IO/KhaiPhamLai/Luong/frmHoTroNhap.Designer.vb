<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHoTroNhap
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgvLuong = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.MaNV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HoTen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Chucvu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BoPhan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LuongCoBan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ptBaoHiem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TienTcgio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbLuuThongTin = New System.Windows.Forms.ToolStripButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvLuong, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.TreeView1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvLuong)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1201, 549)
        Me.SplitContainer1.SplitterDistance = 205
        Me.SplitContainer1.TabIndex = 0
        '
        'TreeView1
        '
        Me.TreeView1.CheckBoxes = True
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView1.Location = New System.Drawing.Point(0, 70)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(205, 479)
        Me.TreeView1.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(205, 70)
        Me.Panel1.TabIndex = 0
        '
        'dgvLuong
        '
        Me.dgvLuong.AllowUserToAddRows = False
        Me.dgvLuong.AllowUserToDeleteRows = False
        Me.dgvLuong.BackgroundColor = System.Drawing.Color.White
        Me.dgvLuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLuong.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MaNV, Me.HoTen, Me.Chucvu, Me.BoPhan, Me.LuongCoBan, Me.ptBaoHiem, Me.TienTcgio})
        Me.dgvLuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvLuong.Location = New System.Drawing.Point(0, 70)
        Me.dgvLuong.Name = "dgvLuong"
        Me.dgvLuong.Size = New System.Drawing.Size(992, 479)
        Me.dgvLuong.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.ToolStrip1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(992, 70)
        Me.Panel2.TabIndex = 1
        '
        'MaNV
        '
        Me.MaNV.HeaderText = "MNV"
        Me.MaNV.Name = "MaNV"
        Me.MaNV.Width = 50
        '
        'HoTen
        '
        Me.HoTen.HeaderText = "Họ Tên"
        Me.HoTen.Name = "HoTen"
        Me.HoTen.Width = 150
        '
        'Chucvu
        '
        Me.Chucvu.HeaderText = "Chức vụ"
        Me.Chucvu.Name = "Chucvu"
        Me.Chucvu.Width = 120
        '
        'BoPhan
        '
        Me.BoPhan.HeaderText = "Bộ Phận"
        Me.BoPhan.Name = "BoPhan"
        Me.BoPhan.Width = 120
        '
        'LuongCoBan
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "{#,##0}"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.LuongCoBan.DefaultCellStyle = DataGridViewCellStyle1
        Me.LuongCoBan.HeaderText = "Lương cơ bản"
        Me.LuongCoBan.Name = "LuongCoBan"
        '
        'ptBaoHiem
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.ptBaoHiem.DefaultCellStyle = DataGridViewCellStyle2
        Me.ptBaoHiem.HeaderText = "% bảo hiểm"
        Me.ptBaoHiem.Name = "ptBaoHiem"
        '
        'TienTcgio
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "C0"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.TienTcgio.DefaultCellStyle = DataGridViewCellStyle3
        Me.TienTcgio.HeaderText = "Tiền tăng ca / h"
        Me.TienTcgio.Name = "TienTcgio"
        Me.TienTcgio.Width = 110
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(53, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "BỘ PHẬN"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbLuuThongTin})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(992, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbLuuThongTin
        '
        Me.tsbLuuThongTin.Image = Global.KhaiPhamLai.My.Resources.Resources.ghi
        Me.tsbLuuThongTin.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbLuuThongTin.Name = "tsbLuuThongTin"
        Me.tsbLuuThongTin.Size = New System.Drawing.Size(91, 22)
        Me.tsbLuuThongTin.Text = "Lưu thông tin"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(333, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(205, 19)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "DANH SÁCH NHÂN VIÊN"
        '
        'frmHoTroNhap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1201, 549)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmHoTroNhap"
        Me.Text = "Hỗ trợ nhập thông tin lương"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvLuong, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents dgvLuong As System.Windows.Forms.DataGridView
    Friend WithEvents MaNV As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HoTen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Chucvu As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BoPhan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LuongCoBan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ptBaoHiem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TienTcgio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbLuuThongTin As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
