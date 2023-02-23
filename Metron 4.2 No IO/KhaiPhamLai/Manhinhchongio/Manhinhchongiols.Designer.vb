<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Manhinhchongiols
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
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.ButtonKhong = New System.Windows.Forms.Button
        Me.ButtonXoa = New System.Windows.Forms.Button
        Me.ButtonLuu = New System.Windows.Forms.Button
        Me.dtpGio = New System.Windows.Forms.DateTimePicker
        Me.GrTG = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtpNgay = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.RBTG = New System.Windows.Forms.RadioButton
        Me.RBChuyen = New System.Windows.Forms.RadioButton
        Me.GRChuyen = New System.Windows.Forms.GroupBox
        Me.RBVoLai = New System.Windows.Forms.RadioButton
        Me.RBTamRa = New System.Windows.Forms.RadioButton
        Me.RBRa = New System.Windows.Forms.RadioButton
        Me.RBVao = New System.Windows.Forms.RadioButton
        Me.GrTG.SuspendLayout()
        Me.GRChuyen.SuspendLayout()
        Me.SuspendLayout()
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(80, 74)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(92, 17)
        Me.CheckBox1.TabIndex = 9
        Me.CheckBox1.Text = "Thời gian nghỉ"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'ButtonKhong
        '
        Me.ButtonKhong.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ButtonKhong.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButtonKhong.Image = Global.KhaiPhamLai.My.Resources.Resources.remove1
        Me.ButtonKhong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonKhong.Location = New System.Drawing.Point(193, 20)
        Me.ButtonKhong.Name = "ButtonKhong"
        Me.ButtonKhong.Size = New System.Drawing.Size(75, 40)
        Me.ButtonKhong.TabIndex = 8
        Me.ButtonKhong.Text = "&Chuyển"
        Me.ButtonKhong.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonKhong.UseVisualStyleBackColor = False
        '
        'ButtonXoa
        '
        Me.ButtonXoa.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ButtonXoa.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButtonXoa.Image = Global.KhaiPhamLai.My.Resources.Resources.user_remove
        Me.ButtonXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonXoa.Location = New System.Drawing.Point(213, 47)
        Me.ButtonXoa.Name = "ButtonXoa"
        Me.ButtonXoa.Size = New System.Drawing.Size(55, 23)
        Me.ButtonXoa.TabIndex = 7
        Me.ButtonXoa.Text = "&Xóa"
        Me.ButtonXoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonXoa.UseVisualStyleBackColor = False
        '
        'ButtonLuu
        '
        Me.ButtonLuu.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ButtonLuu.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButtonLuu.Image = Global.KhaiPhamLai.My.Resources.Resources.user_add
        Me.ButtonLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonLuu.Location = New System.Drawing.Point(213, 18)
        Me.ButtonLuu.Name = "ButtonLuu"
        Me.ButtonLuu.Size = New System.Drawing.Size(55, 23)
        Me.ButtonLuu.TabIndex = 5
        Me.ButtonLuu.Text = "&Thêm"
        Me.ButtonLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonLuu.UseVisualStyleBackColor = False
        '
        'dtpGio
        '
        Me.dtpGio.CustomFormat = "HH:mm:ss"
        Me.dtpGio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpGio.Location = New System.Drawing.Point(80, 47)
        Me.dtpGio.Name = "dtpGio"
        Me.dtpGio.ShowUpDown = True
        Me.dtpGio.Size = New System.Drawing.Size(127, 21)
        Me.dtpGio.TabIndex = 4
        '
        'GrTG
        '
        Me.GrTG.Controls.Add(Me.Label2)
        Me.GrTG.Controls.Add(Me.Label1)
        Me.GrTG.Controls.Add(Me.dtpNgay)
        Me.GrTG.Controls.Add(Me.CheckBox1)
        Me.GrTG.Controls.Add(Me.dtpGio)
        Me.GrTG.Controls.Add(Me.ButtonLuu)
        Me.GrTG.Controls.Add(Me.ButtonXoa)
        Me.GrTG.Location = New System.Drawing.Point(49, 67)
        Me.GrTG.Name = "GrTG"
        Me.GrTG.Size = New System.Drawing.Size(294, 103)
        Me.GrTG.TabIndex = 10
        Me.GrTG.TabStop = False
        Me.GrTG.Text = "Thêm thời gian quên ấn"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Chọn giờ"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Chọn ngày"
        '
        'dtpNgay
        '
        Me.dtpNgay.CustomFormat = "dd/MM/yyyy"
        Me.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpNgay.Location = New System.Drawing.Point(80, 20)
        Me.dtpNgay.Name = "dtpNgay"
        Me.dtpNgay.Size = New System.Drawing.Size(127, 21)
        Me.dtpNgay.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(12, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(319, 19)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "THÊM / CHUYỂN THỜI GIAN BẤM THẺ"
        '
        'RBTG
        '
        Me.RBTG.AutoSize = True
        Me.RBTG.Location = New System.Drawing.Point(26, 41)
        Me.RBTG.Name = "RBTG"
        Me.RBTG.Size = New System.Drawing.Size(194, 17)
        Me.RBTG.TabIndex = 12
        Me.RBTG.TabStop = True
        Me.RBTG.Text = "Chế độ thêm/xóa thời gian bấm thẻ"
        Me.RBTG.UseVisualStyleBackColor = True
        '
        'RBChuyen
        '
        Me.RBChuyen.AutoSize = True
        Me.RBChuyen.Location = New System.Drawing.Point(26, 186)
        Me.RBChuyen.Name = "RBChuyen"
        Me.RBChuyen.Size = New System.Drawing.Size(139, 17)
        Me.RBChuyen.TabIndex = 13
        Me.RBChuyen.TabStop = True
        Me.RBChuyen.Text = "Chuyển chế độ bấm thẻ"
        Me.RBChuyen.UseVisualStyleBackColor = True
        '
        'GRChuyen
        '
        Me.GRChuyen.Controls.Add(Me.RBVoLai)
        Me.GRChuyen.Controls.Add(Me.RBTamRa)
        Me.GRChuyen.Controls.Add(Me.RBRa)
        Me.GRChuyen.Controls.Add(Me.RBVao)
        Me.GRChuyen.Controls.Add(Me.ButtonKhong)
        Me.GRChuyen.Location = New System.Drawing.Point(49, 209)
        Me.GRChuyen.Name = "GRChuyen"
        Me.GRChuyen.Size = New System.Drawing.Size(294, 71)
        Me.GRChuyen.TabIndex = 14
        Me.GRChuyen.TabStop = False
        Me.GRChuyen.Text = "Chuyển chế độ bấm"
        '
        'RBVoLai
        '
        Me.RBVoLai.AutoSize = True
        Me.RBVoLai.Location = New System.Drawing.Point(118, 43)
        Me.RBVoLai.Name = "RBVoLai"
        Me.RBVoLai.Size = New System.Drawing.Size(50, 17)
        Me.RBVoLai.TabIndex = 3
        Me.RBVoLai.TabStop = True
        Me.RBVoLai.Text = "Vô lại"
        Me.RBVoLai.UseVisualStyleBackColor = True
        '
        'RBTamRa
        '
        Me.RBTamRa.AutoSize = True
        Me.RBTamRa.Location = New System.Drawing.Point(28, 43)
        Me.RBTamRa.Name = "RBTamRa"
        Me.RBTamRa.Size = New System.Drawing.Size(58, 17)
        Me.RBTamRa.TabIndex = 2
        Me.RBTamRa.TabStop = True
        Me.RBTamRa.Text = "Tạm ra"
        Me.RBTamRa.UseVisualStyleBackColor = True
        '
        'RBRa
        '
        Me.RBRa.AutoSize = True
        Me.RBRa.Location = New System.Drawing.Point(118, 20)
        Me.RBRa.Name = "RBRa"
        Me.RBRa.Size = New System.Drawing.Size(58, 17)
        Me.RBRa.TabIndex = 1
        Me.RBRa.TabStop = True
        Me.RBRa.Text = "Bấm ra"
        Me.RBRa.UseVisualStyleBackColor = True
        '
        'RBVao
        '
        Me.RBVao.AutoSize = True
        Me.RBVao.Location = New System.Drawing.Point(28, 20)
        Me.RBVao.Name = "RBVao"
        Me.RBVao.Size = New System.Drawing.Size(66, 17)
        Me.RBVao.TabIndex = 0
        Me.RBVao.TabStop = True
        Me.RBVao.Text = "Bấm vào"
        Me.RBVao.UseVisualStyleBackColor = True
        '
        'Manhinhchongiols
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(363, 293)
        Me.Controls.Add(Me.GRChuyen)
        Me.Controls.Add(Me.RBChuyen)
        Me.Controls.Add(Me.RBTG)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GrTG)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Manhinhchongiols"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chọn giờ"
        Me.GrTG.ResumeLayout(False)
        Me.GrTG.PerformLayout()
        Me.GRChuyen.ResumeLayout(False)
        Me.GRChuyen.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonKhong As System.Windows.Forms.Button
    Friend WithEvents ButtonXoa As System.Windows.Forms.Button
    Friend WithEvents ButtonLuu As System.Windows.Forms.Button
    Friend WithEvents dtpGio As System.Windows.Forms.DateTimePicker
    Friend WithEvents GrTG As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents RBTG As System.Windows.Forms.RadioButton
    Friend WithEvents RBChuyen As System.Windows.Forms.RadioButton
    Friend WithEvents GRChuyen As System.Windows.Forms.GroupBox
    Friend WithEvents RBVoLai As System.Windows.Forms.RadioButton
    Friend WithEvents RBTamRa As System.Windows.Forms.RadioButton
    Friend WithEvents RBRa As System.Windows.Forms.RadioButton
    Friend WithEvents RBVao As System.Windows.Forms.RadioButton
End Class
