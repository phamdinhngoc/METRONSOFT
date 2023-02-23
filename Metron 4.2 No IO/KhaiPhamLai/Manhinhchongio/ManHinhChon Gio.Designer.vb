<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManHinhChon_Gio
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
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.MonthCalendar1 = New System.Windows.Forms.MonthCalendar
        Me.ButtonLuu = New System.Windows.Forms.Button
        Me.ButtonKhong = New System.Windows.Forms.Button
        Me.ButtonXoa = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DateTimePicker1.Location = New System.Drawing.Point(29, 165)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.ShowUpDown = True
        Me.DateTimePicker1.Size = New System.Drawing.Size(171, 21)
        Me.DateTimePicker1.TabIndex = 0
        '
        'MonthCalendar1
        '
        Me.MonthCalendar1.Enabled = False
        Me.MonthCalendar1.Location = New System.Drawing.Point(5, 2)
        Me.MonthCalendar1.Name = "MonthCalendar1"
        Me.MonthCalendar1.TabIndex = 1
        '
        'ButtonLuu
        '
        Me.ButtonLuu.Image = Global.KhaiPhamLai.My.Resources.Resources.user_add
        Me.ButtonLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonLuu.Location = New System.Drawing.Point(29, 188)
        Me.ButtonLuu.Name = "ButtonLuu"
        Me.ButtonLuu.Size = New System.Drawing.Size(55, 23)
        Me.ButtonLuu.TabIndex = 1
        Me.ButtonLuu.Text = "&Thêm"
        Me.ButtonLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonLuu.UseVisualStyleBackColor = True
        '
        'ButtonKhong
        '
        Me.ButtonKhong.Image = Global.KhaiPhamLai.My.Resources.Resources.remove1
        Me.ButtonKhong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonKhong.Location = New System.Drawing.Point(141, 188)
        Me.ButtonKhong.Name = "ButtonKhong"
        Me.ButtonKhong.Size = New System.Drawing.Size(59, 23)
        Me.ButtonKhong.TabIndex = 2
        Me.ButtonKhong.Text = "&Không"
        Me.ButtonKhong.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonKhong.UseVisualStyleBackColor = True
        '
        'ButtonXoa
        '
        Me.ButtonXoa.Image = Global.KhaiPhamLai.My.Resources.Resources.user_remove
        Me.ButtonXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonXoa.Location = New System.Drawing.Point(90, 188)
        Me.ButtonXoa.Name = "ButtonXoa"
        Me.ButtonXoa.Size = New System.Drawing.Size(45, 23)
        Me.ButtonXoa.TabIndex = 1
        Me.ButtonXoa.Text = "&Xóa"
        Me.ButtonXoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonXoa.UseVisualStyleBackColor = True
        '
        'ManHinhChon_Gio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(235, 213)
        Me.ControlBox = False
        Me.Controls.Add(Me.ButtonKhong)
        Me.Controls.Add(Me.ButtonXoa)
        Me.Controls.Add(Me.ButtonLuu)
        Me.Controls.Add(Me.MonthCalendar1)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ManHinhChon_Gio"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Chọn"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents MonthCalendar1 As System.Windows.Forms.MonthCalendar
    Friend WithEvents ButtonLuu As System.Windows.Forms.Button
    Friend WithEvents ButtonKhong As System.Windows.Forms.Button
    Friend WithEvents ButtonXoa As System.Windows.Forms.Button
End Class
