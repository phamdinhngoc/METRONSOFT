<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Manhinhcanghi
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
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Den_trua = New System.Windows.Forms.DateTimePicker
        Me.Tu_trua = New System.Windows.Forms.DateTimePicker
        Me.Button2 = New System.Windows.Forms.Button
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Den_chieu = New System.Windows.Forms.DateTimePicker
        Me.Tu_chieu = New System.Windows.Forms.DateTimePicker
        Me.Button3 = New System.Windows.Forms.Button
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Den_trua)
        Me.Panel2.Controls.Add(Me.Tu_trua)
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Location = New System.Drawing.Point(4, 10)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(118, 106)
        Me.Panel2.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 13)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "Đến"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(20, 13)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "Từ"
        '
        'Den_trua
        '
        Me.Den_trua.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Den_trua.CustomFormat = "HH:mm:ss"
        Me.Den_trua.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Den_trua.Location = New System.Drawing.Point(42, 70)
        Me.Den_trua.Name = "Den_trua"
        Me.Den_trua.ShowUpDown = True
        Me.Den_trua.Size = New System.Drawing.Size(73, 21)
        Me.Den_trua.TabIndex = 36
        Me.Den_trua.Tag = "6"
        Me.Den_trua.Value = New Date(1900, 1, 1, 13, 0, 0, 0)
        '
        'Tu_trua
        '
        Me.Tu_trua.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tu_trua.CustomFormat = "HH:mm:ss"
        Me.Tu_trua.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Tu_trua.Location = New System.Drawing.Point(42, 43)
        Me.Tu_trua.Name = "Tu_trua"
        Me.Tu_trua.ShowUpDown = True
        Me.Tu_trua.Size = New System.Drawing.Size(73, 21)
        Me.Tu_trua.TabIndex = 35
        Me.Tu_trua.Tag = "6"
        Me.Tu_trua.Value = New Date(1900, 1, 1, 11, 30, 0, 0)
        '
        'Button2
        '
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button2.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Button2.Location = New System.Drawing.Point(0, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(118, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Tag = "Nghỉ trưa"
        Me.Button2.Text = "Lưu  TG Nghỉ trưa"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.Den_chieu)
        Me.Panel3.Controls.Add(Me.Tu_chieu)
        Me.Panel3.Controls.Add(Me.Button3)
        Me.Panel3.Location = New System.Drawing.Point(128, 10)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(118, 106)
        Me.Panel3.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 74)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 13)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "Đến"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(20, 13)
        Me.Label6.TabIndex = 33
        Me.Label6.Text = "Từ"
        '
        'Den_chieu
        '
        Me.Den_chieu.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Den_chieu.CustomFormat = "HH:mm:ss"
        Me.Den_chieu.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Den_chieu.Location = New System.Drawing.Point(42, 70)
        Me.Den_chieu.Name = "Den_chieu"
        Me.Den_chieu.ShowUpDown = True
        Me.Den_chieu.Size = New System.Drawing.Size(73, 21)
        Me.Den_chieu.TabIndex = 36
        Me.Den_chieu.Tag = "6"
        Me.Den_chieu.Value = New Date(1900, 1, 1, 18, 30, 0, 0)
        '
        'Tu_chieu
        '
        Me.Tu_chieu.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tu_chieu.CustomFormat = "HH:mm:ss"
        Me.Tu_chieu.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Tu_chieu.Location = New System.Drawing.Point(42, 43)
        Me.Tu_chieu.Name = "Tu_chieu"
        Me.Tu_chieu.ShowUpDown = True
        Me.Tu_chieu.Size = New System.Drawing.Size(73, 21)
        Me.Tu_chieu.TabIndex = 35
        Me.Tu_chieu.Tag = "6"
        Me.Tu_chieu.Value = New Date(1900, 1, 1, 17, 0, 0, 0)
        '
        'Button3
        '
        Me.Button3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button3.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Button3.Location = New System.Drawing.Point(0, 0)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(118, 23)
        Me.Button3.TabIndex = 1
        Me.Button3.Text = "Lưu  TG Nghỉ chiều"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Manhinhcanghi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(252, 128)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximumSize = New System.Drawing.Size(258, 152)
        Me.MinimumSize = New System.Drawing.Size(258, 152)
        Me.Name = "Manhinhcanghi"
        Me.Text = "Xác định thời gian nghỉ"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Den_trua As System.Windows.Forms.DateTimePicker
    Friend WithEvents Tu_trua As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Den_chieu As System.Windows.Forms.DateTimePicker
    Friend WithEvents Tu_chieu As System.Windows.Forms.DateTimePicker
End Class
