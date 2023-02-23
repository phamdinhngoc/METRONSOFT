<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManHinhPhucHoi
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
        Me.lvwLocalFiles = New System.Windows.Forms.ListView
        Me.chdrFile = New System.Windows.Forms.ColumnHeader
        Me.chdrSize = New System.Windows.Forms.ColumnHeader
        Me.chdrModified = New System.Windows.Forms.ColumnHeader
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtDuongdan = New System.Windows.Forms.TextBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.SuspendLayout()
        '
        'lvwLocalFiles
        '
        Me.lvwLocalFiles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwLocalFiles.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chdrFile, Me.chdrSize, Me.chdrModified})
        Me.lvwLocalFiles.FullRowSelect = True
        Me.lvwLocalFiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvwLocalFiles.HideSelection = False
        Me.lvwLocalFiles.Location = New System.Drawing.Point(17, 98)
        Me.lvwLocalFiles.MultiSelect = False
        Me.lvwLocalFiles.Name = "lvwLocalFiles"
        Me.lvwLocalFiles.Size = New System.Drawing.Size(477, 143)
        Me.lvwLocalFiles.TabIndex = 21
        Me.lvwLocalFiles.UseCompatibleStateImageBehavior = False
        Me.lvwLocalFiles.View = System.Windows.Forms.View.Details
        '
        'chdrFile
        '
        Me.chdrFile.Text = "File"
        Me.chdrFile.Width = 150
        '
        'chdrSize
        '
        Me.chdrSize.Text = "Size"
        Me.chdrSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chdrModified
        '
        Me.chdrModified.Text = "Modified"
        Me.chdrModified.Width = 150
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(445, 69)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(49, 23)
        Me.Button1.TabIndex = 20
        Me.Button1.Tag = "Chọn thư Mục có File Dử Liệu"
        Me.Button1.Text = "* * *"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(138, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(246, 33)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "PHỤC HỒI DỬ LIỆU"
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.Image = Global.KhaiPhamLai.My.Resources.Resources.remove1
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(419, 277)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(64, 23)
        Me.Button3.TabIndex = 18
        Me.Button3.Tag = "Thoát Khỏi Giao Diện Phục Hồi"
        Me.Button3.Text = "Thoát"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 255)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Tên File Phục Hồi"
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Image = Global.KhaiPhamLai.My.Resources.Resources.ok
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(338, 277)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 16
        Me.Button2.Tag = "Xác Nhận File Phục Hồi"
        Me.Button2.Text = "Phục hồi"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Vị trí File Phục Hồi"
        '
        'TxtDuongdan
        '
        Me.TxtDuongdan.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDuongdan.BackColor = System.Drawing.Color.White
        Me.TxtDuongdan.Enabled = False
        Me.TxtDuongdan.Location = New System.Drawing.Point(17, 71)
        Me.TxtDuongdan.Name = "TxtDuongdan"
        Me.TxtDuongdan.Size = New System.Drawing.Size(422, 21)
        Me.TxtDuongdan.TabIndex = 13
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.BackColor = System.Drawing.Color.White
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(110, 252)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(245, 21)
        Me.TextBox1.TabIndex = 22
        '
        'ManHinhPhucHoi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(510, 311)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.lvwLocalFiles)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtDuongdan)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ManHinhPhucHoi"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Phục hồi dử liệu "
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvwLocalFiles As System.Windows.Forms.ListView
    Friend WithEvents chdrFile As System.Windows.Forms.ColumnHeader
    Friend WithEvents chdrSize As System.Windows.Forms.ColumnHeader
    Friend WithEvents chdrModified As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtDuongdan As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
End Class
