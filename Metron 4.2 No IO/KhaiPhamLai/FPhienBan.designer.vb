<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FPhienBan
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
        Me.CMDTHOAT = New System.Windows.Forms.Button()
        Me.CMDDOC = New System.Windows.Forms.Button()
        Me.TXT1 = New System.Windows.Forms.TextBox()
        Me.TXT2 = New System.Windows.Forms.TextBox()
        Me.op = New System.Windows.Forms.OpenFileDialog()
        Me.TXT3 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'CMDTHOAT
        '
        Me.CMDTHOAT.Location = New System.Drawing.Point(443, 288)
        Me.CMDTHOAT.Name = "CMDTHOAT"
        Me.CMDTHOAT.Size = New System.Drawing.Size(75, 25)
        Me.CMDTHOAT.TabIndex = 0
        Me.CMDTHOAT.Text = "Thoát"
        Me.CMDTHOAT.UseVisualStyleBackColor = True
        '
        'CMDDOC
        '
        Me.CMDDOC.Location = New System.Drawing.Point(362, 288)
        Me.CMDDOC.Name = "CMDDOC"
        Me.CMDDOC.Size = New System.Drawing.Size(75, 25)
        Me.CMDDOC.TabIndex = 1
        Me.CMDDOC.Text = "Đọc"
        Me.CMDDOC.UseVisualStyleBackColor = True
        '
        'TXT1
        '
        Me.TXT1.Location = New System.Drawing.Point(157, 106)
        Me.TXT1.Multiline = True
        Me.TXT1.Name = "TXT1"
        Me.TXT1.Size = New System.Drawing.Size(134, 25)
        Me.TXT1.TabIndex = 2
        '
        'TXT2
        '
        Me.TXT2.Location = New System.Drawing.Point(157, 137)
        Me.TXT2.Multiline = True
        Me.TXT2.Name = "TXT2"
        Me.TXT2.Size = New System.Drawing.Size(171, 42)
        Me.TXT2.TabIndex = 3
        '
        'TXT3
        '
        Me.TXT3.Location = New System.Drawing.Point(172, 188)
        Me.TXT3.Multiline = True
        Me.TXT3.Name = "TXT3"
        Me.TXT3.Size = New System.Drawing.Size(251, 21)
        Me.TXT3.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Snow
        Me.Label1.Location = New System.Drawing.Point(75, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(367, 25)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "CẬP NHẬT PHIÊN BẢN PHẦN MỀM"
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(27, 64)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(491, 200)
        Me.TextBox1.TabIndex = 9
        Me.TextBox1.Text = ""
        '
        'FPhienBan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(545, 328)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TXT3)
        Me.Controls.Add(Me.TXT2)
        Me.Controls.Add(Me.TXT1)
        Me.Controls.Add(Me.CMDDOC)
        Me.Controls.Add(Me.CMDTHOAT)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FPhienBan"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CMDTHOAT As System.Windows.Forms.Button
    Friend WithEvents CMDDOC As System.Windows.Forms.Button
    Friend WithEvents TXT1 As System.Windows.Forms.TextBox
    Friend WithEvents TXT2 As System.Windows.Forms.TextBox
    Friend WithEvents op As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TXT3 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.RichTextBox
End Class
