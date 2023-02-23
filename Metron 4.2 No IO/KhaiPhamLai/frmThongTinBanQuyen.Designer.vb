<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmThongTinBanQuyen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmThongTinBanQuyen))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtNgayCap = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DgvSeri = New System.Windows.Forms.DataGridView()
        Me.Stt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Seri = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtBanQuyen = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTenCongTy = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DgvSeri, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtNgayCap)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.DgvSeri)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtBanQuyen)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtTenCongTy)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(323, 302)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'txtNgayCap
        '
        Me.txtNgayCap.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtNgayCap.Location = New System.Drawing.Point(88, 87)
        Me.txtNgayCap.Name = "txtNgayCap"
        Me.txtNgayCap.ReadOnly = True
        Me.txtNgayCap.Size = New System.Drawing.Size(104, 21)
        Me.txtNgayCap.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label1.Location = New System.Drawing.Point(56, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(205, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "THÔNG TIN BẢN QUYỀN"
        '
        'DgvSeri
        '
        Me.DgvSeri.AllowUserToAddRows = False
        Me.DgvSeri.AllowUserToDeleteRows = False
        Me.DgvSeri.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.DgvSeri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvSeri.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Stt, Me.Seri})
        Me.DgvSeri.Location = New System.Drawing.Point(88, 152)
        Me.DgvSeri.Name = "DgvSeri"
        Me.DgvSeri.ReadOnly = True
        Me.DgvSeri.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DgvSeri.RowHeadersVisible = False
        Me.DgvSeri.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvSeri.Size = New System.Drawing.Size(191, 132)
        Me.DgvSeri.TabIndex = 3
        '
        'Stt
        '
        Me.Stt.HeaderText = "Stt"
        Me.Stt.Name = "Stt"
        Me.Stt.ReadOnly = True
        Me.Stt.Width = 40
        '
        'Seri
        '
        Me.Seri.HeaderText = "Số seri"
        Me.Seri.Name = "Seri"
        Me.Seri.ReadOnly = True
        Me.Seri.Width = 130
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Tên công ty"
        '
        'txtBanQuyen
        '
        Me.txtBanQuyen.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtBanQuyen.Location = New System.Drawing.Point(88, 118)
        Me.txtBanQuyen.Name = "txtBanQuyen"
        Me.txtBanQuyen.ReadOnly = True
        Me.txtBanQuyen.Size = New System.Drawing.Size(104, 21)
        Me.txtBanQuyen.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(24, 91)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Ngày cấp"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(37, 156)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "GPSD"
        '
        'txtTenCongTy
        '
        Me.txtTenCongTy.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtTenCongTy.Location = New System.Drawing.Point(88, 55)
        Me.txtTenCongTy.Name = "txtTenCongTy"
        Me.txtTenCongTy.ReadOnly = True
        Me.txtTenCongTy.Size = New System.Drawing.Size(215, 21)
        Me.txtTenCongTy.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(16, 121)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Bản quyền"
        '
        'frmThongTinBanQuyen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(346, 318)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmThongTinBanQuyen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Thông tin bản quyền phần mềm"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DgvSeri, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNgayCap As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DgvSeri As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBanQuyen As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTenCongTy As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Stt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Seri As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
