<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManHinhXoaDLCC
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
        Me.sngay = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.ENgay = New System.Windows.Forms.DateTimePicker
        Me.cmdall = New System.Windows.Forms.Button
        Me.cmdsua = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(397, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "XÓA DỮ LIỆU CHẤM CÔNG TRONG CSDL"
        '
        'sngay
        '
        Me.sngay.CustomFormat = "dd/MM/yyyy"
        Me.sngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.sngay.Location = New System.Drawing.Point(133, 52)
        Me.sngay.Name = "sngay"
        Me.sngay.Size = New System.Drawing.Size(85, 20)
        Me.sngay.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(39, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Xóa từ ngày"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(39, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Đến ngày"
        '
        'ENgay
        '
        Me.ENgay.CustomFormat = "dd/MM/yyyy"
        Me.ENgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.ENgay.Location = New System.Drawing.Point(133, 89)
        Me.ENgay.Name = "ENgay"
        Me.ENgay.Size = New System.Drawing.Size(85, 20)
        Me.ENgay.TabIndex = 5
        '
        'cmdall
        '
        Me.cmdall.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdall.Location = New System.Drawing.Point(235, 44)
        Me.cmdall.Name = "cmdall"
        Me.cmdall.Size = New System.Drawing.Size(100, 37)
        Me.cmdall.TabIndex = 6
        Me.cmdall.Text = "Xóa tất cả DL"
        Me.cmdall.UseVisualStyleBackColor = True
        '
        'cmdsua
        '
        Me.cmdsua.Location = New System.Drawing.Point(235, 80)
        Me.cmdsua.Name = "cmdsua"
        Me.cmdsua.Size = New System.Drawing.Size(100, 37)
        Me.cmdsua.TabIndex = 7
        Me.cmdsua.Text = "Xóa DL Sửa"
        Me.cmdsua.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(341, 44)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(85, 73)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Xóa DL" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Thử nghiệm"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ManHinhXoaDLCC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(438, 128)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmdsua)
        Me.Controls.Add(Me.cmdall)
        Me.Controls.Add(Me.ENgay)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.sngay)
        Me.Controls.Add(Me.Label1)
        Me.Name = "ManHinhXoaDLCC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ManHinhXoaDLCC"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents sngay As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ENgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdall As System.Windows.Forms.Button
    Friend WithEvents cmdsua As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
