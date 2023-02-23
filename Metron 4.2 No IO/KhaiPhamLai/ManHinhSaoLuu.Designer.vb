<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManHinhSaoLuu
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtDuongdan = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.lvwLocalFiles = New System.Windows.Forms.ListView
        Me.chdrFile = New System.Windows.Forms.ColumnHeader
        Me.chdrSize = New System.Windows.Forms.ColumnHeader
        Me.chdrModified = New System.Windows.Forms.ColumnHeader
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Vị trí Sao Lưu"
        '
        'ComboBox1
        '
        Me.ComboBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(125, 246)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(259, 21)
        Me.ComboBox1.TabIndex = 6
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Image = Global.KhaiPhamLai.My.Resources.Resources.ok
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(342, 276)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 7
        Me.Button2.Tag = "Lưu File Dử Liệu Với Tên khác"
        Me.Button2.Text = "Sao Lưu"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 254)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Tên File Sao Lưu"
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.Image = Global.KhaiPhamLai.My.Resources.Resources.remove1
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(423, 276)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(62, 23)
        Me.Button3.TabIndex = 9
        Me.Button3.Tag = "Thoát Khỏi Giao Diện Sao Lưu"
        Me.Button3.Text = "Thoát"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(128, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(232, 33)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "SAO LƯU DỬ LIỆU"
        '
        'TxtDuongdan
        '
        Me.TxtDuongdan.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDuongdan.Location = New System.Drawing.Point(21, 70)
        Me.TxtDuongdan.Name = "TxtDuongdan"
        Me.TxtDuongdan.Size = New System.Drawing.Size(422, 21)
        Me.TxtDuongdan.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(449, 68)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(49, 23)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "* * *"
        Me.Button1.UseVisualStyleBackColor = True
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
        Me.lvwLocalFiles.Location = New System.Drawing.Point(21, 97)
        Me.lvwLocalFiles.Name = "lvwLocalFiles"
        Me.lvwLocalFiles.Size = New System.Drawing.Size(477, 143)
        Me.lvwLocalFiles.TabIndex = 12
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
        'ManHinhSaoLuu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(510, 311)
        Me.Controls.Add(Me.lvwLocalFiles)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtDuongdan)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ManHinhSaoLuu"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sao lưu dử liệu"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents TxtDuongdan As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lvwLocalFiles As System.Windows.Forms.ListView
    Friend WithEvents chdrFile As System.Windows.Forms.ColumnHeader
    Friend WithEvents chdrModified As System.Windows.Forms.ColumnHeader
    Friend WithEvents chdrSize As System.Windows.Forms.ColumnHeader
End Class
