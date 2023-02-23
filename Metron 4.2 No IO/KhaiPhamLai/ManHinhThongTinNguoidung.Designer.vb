<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManHinhThongTinNguoidung
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ManHinhThongTinNguoidung))
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnOk = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.cboQuyen = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtuserID = New System.Windows.Forms.TextBox
        Me.CBoCauhoi1 = New System.Windows.Forms.ComboBox
        Me.cboCauhoi2 = New System.Windows.Forms.ComboBox
        Me.txtTraloi1 = New System.Windows.Forms.TextBox
        Me.txtTraloi2 = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(56, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(272, 33)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "THÔNG TIN CỦA BẠN"
        '
        'btnOk
        '
        Me.btnOk.BackColor = System.Drawing.Color.Transparent
        Me.btnOk.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Image = Global.KhaiPhamLai.My.Resources.Resources.ok
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(52, 234)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 22
        Me.btnOk.Tag = "Lưu Thông Tin của bạn"
        Me.btnOk.Text = "Xác Nhận"
        Me.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnOk.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = Global.KhaiPhamLai.My.Resources.Resources.remove1
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(253, 234)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(62, 23)
        Me.Button1.TabIndex = 24
        Me.Button1.Tag = "Thoát khỏi màn hình"
        Me.Button1.Text = "Thoát"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'cboQuyen
        '
        Me.cboQuyen.BackColor = System.Drawing.Color.White
        Me.cboQuyen.Enabled = False
        Me.cboQuyen.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboQuyen.FormattingEnabled = True
        Me.cboQuyen.Location = New System.Drawing.Point(115, 207)
        Me.cboQuyen.Name = "cboQuyen"
        Me.cboQuyen.Size = New System.Drawing.Size(261, 21)
        Me.cboQuyen.TabIndex = 20
        Me.cboQuyen.Tag = "1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(9, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Tên Người Dùng"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(13, 210)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 13)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Quyền Người Dùng"
        '
        'txtuserID
        '
        Me.txtuserID.BackColor = System.Drawing.Color.White
        Me.txtuserID.Enabled = False
        Me.txtuserID.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtuserID.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtuserID.Location = New System.Drawing.Point(115, 49)
        Me.txtuserID.Name = "txtuserID"
        Me.txtuserID.Size = New System.Drawing.Size(261, 21)
        Me.txtuserID.TabIndex = 14
        Me.txtuserID.Tag = "1"
        '
        'CBoCauhoi1
        '
        Me.CBoCauhoi1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBoCauhoi1.FormattingEnabled = True
        Me.CBoCauhoi1.Location = New System.Drawing.Point(110, 13)
        Me.CBoCauhoi1.Name = "CBoCauhoi1"
        Me.CBoCauhoi1.Size = New System.Drawing.Size(261, 21)
        Me.CBoCauhoi1.TabIndex = 1
        Me.CBoCauhoi1.Tag = "1"
        '
        'cboCauhoi2
        '
        Me.cboCauhoi2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCauhoi2.FormattingEnabled = True
        Me.cboCauhoi2.Location = New System.Drawing.Point(110, 66)
        Me.cboCauhoi2.Name = "cboCauhoi2"
        Me.cboCauhoi2.Size = New System.Drawing.Size(261, 21)
        Me.cboCauhoi2.TabIndex = 3
        Me.cboCauhoi2.Tag = "1"
        '
        'txtTraloi1
        '
        Me.txtTraloi1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTraloi1.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtTraloi1.Location = New System.Drawing.Point(110, 40)
        Me.txtTraloi1.Name = "txtTraloi1"
        Me.txtTraloi1.Size = New System.Drawing.Size(261, 21)
        Me.txtTraloi1.TabIndex = 2
        Me.txtTraloi1.Tag = "1"
        '
        'txtTraloi2
        '
        Me.txtTraloi2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTraloi2.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtTraloi2.Location = New System.Drawing.Point(110, 94)
        Me.txtTraloi2.Name = "txtTraloi2"
        Me.txtTraloi2.Size = New System.Drawing.Size(261, 21)
        Me.txtTraloi2.TabIndex = 4
        Me.txtTraloi2.Tag = "1"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(8, 17)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(57, 13)
        Me.Label12.TabIndex = 9
        Me.Label12.Text = "Câu Hỏi 1:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(8, 48)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 13)
        Me.Label11.TabIndex = 9
        Me.Label11.Text = "Câu Trả Lời 1"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(6, 74)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 13)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Câu Hỏi 2"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 102)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 13)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Câu Trả Lời 2"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.txtTraloi2)
        Me.GroupBox4.Controls.Add(Me.txtTraloi1)
        Me.GroupBox4.Controls.Add(Me.cboCauhoi2)
        Me.GroupBox4.Controls.Add(Me.CBoCauhoi1)
        Me.GroupBox4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(5, 76)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(385, 125)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Thông tin câu hỏi"
        '
        'ManHinhThongTinNguoidung
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(393, 265)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtuserID)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboQuyen)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(399, 289)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(399, 289)
        Me.Name = "ManHinhThongTinNguoidung"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Thông tin của bạn"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtTraloi2 As System.Windows.Forms.TextBox
    Friend WithEvents txtTraloi1 As System.Windows.Forms.TextBox
    Friend WithEvents cboCauhoi2 As System.Windows.Forms.ComboBox
    Friend WithEvents CBoCauhoi1 As System.Windows.Forms.ComboBox
    Friend WithEvents txtuserID As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboQuyen As System.Windows.Forms.ComboBox
End Class
