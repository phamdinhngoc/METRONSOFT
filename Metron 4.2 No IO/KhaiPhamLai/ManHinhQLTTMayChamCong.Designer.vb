<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManHinhQLTTMayChamCong
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ManHinhQLTTMayChamCong))
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dlql = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dlvt = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dlnv = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dlcc = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tgmt = New System.Windows.Forms.TextBox()
        Me.tgcc = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lblSeri = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.BackColor = System.Drawing.Color.White
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Left
        Me.ListView1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(0, 0)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(167, 370)
        Me.ListView1.SmallImageList = Me.ImageList
        Me.ListView1.StateImageList = Me.ImageList
        Me.ListView1.TabIndex = 1
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'ImageList
        '
        Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList.Images.SetKeyName(0, "")
        Me.ImageList.Images.SetKeyName(1, "")
        Me.ImageList.Images.SetKeyName(2, "MayCCNho12.JPG")
        Me.ImageList.Images.SetKeyName(3, "MayCCNho13.JPG")
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.dlql)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.lblSeri)
        Me.GroupBox1.Controls.Add(Me.dlvt)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.dlnv)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.dlcc)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.tgmt)
        Me.GroupBox1.Controls.Add(Me.tgcc)
        Me.GroupBox1.Location = New System.Drawing.Point(177, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(319, 216)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Thông tin"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 131)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Số lượng quản lý"
        '
        'dlql
        '
        Me.dlql.Location = New System.Drawing.Point(131, 128)
        Me.dlql.Name = "dlql"
        Me.dlql.ReadOnly = True
        Me.dlql.Size = New System.Drawing.Size(168, 21)
        Me.dlql.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 158)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Số lượng vân tay"
        '
        'dlvt
        '
        Me.dlvt.Location = New System.Drawing.Point(131, 155)
        Me.dlvt.Name = "dlvt"
        Me.dlvt.ReadOnly = True
        Me.dlvt.Size = New System.Drawing.Size(168, 21)
        Me.dlvt.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Số lượng người dùng"
        '
        'dlnv
        '
        Me.dlnv.Location = New System.Drawing.Point(131, 101)
        Me.dlnv.Name = "dlnv"
        Me.dlnv.ReadOnly = True
        Me.dlnv.Size = New System.Drawing.Size(168, 21)
        Me.dlnv.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Số lần chấm công"
        '
        'dlcc
        '
        Me.dlcc.Location = New System.Drawing.Point(131, 74)
        Me.dlcc.Name = "dlcc"
        Me.dlcc.ReadOnly = True
        Me.dlcc.Size = New System.Drawing.Size(168, 21)
        Me.dlcc.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Thời gian máy tính"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Thời gian của MCC"
        '
        'tgmt
        '
        Me.tgmt.Location = New System.Drawing.Point(131, 47)
        Me.tgmt.Name = "tgmt"
        Me.tgmt.ReadOnly = True
        Me.tgmt.Size = New System.Drawing.Size(168, 21)
        Me.tgmt.TabIndex = 1
        '
        'tgcc
        '
        Me.tgcc.Location = New System.Drawing.Point(131, 20)
        Me.tgcc.Name = "tgcc"
        Me.tgcc.ReadOnly = True
        Me.tgcc.Size = New System.Drawing.Size(168, 21)
        Me.tgcc.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(285, 259)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 41)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "   Đồng bộ     thời gian"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(388, 259)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(88, 41)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Xóa admin"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(182, 306)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(88, 41)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Reset"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(285, 306)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(88, 41)
        Me.Button4.TabIndex = 3
        Me.Button4.Text = "Xóa DLCC"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(388, 306)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(88, 41)
        Me.Button5.TabIndex = 3
        Me.Button5.Text = "Trở về"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(182, 259)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(88, 41)
        Me.Button6.TabIndex = 4
        Me.Button6.Text = "Đọc dữ liệu"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 500
        '
        'lblSeri
        '
        Me.lblSeri.Location = New System.Drawing.Point(131, 185)
        Me.lblSeri.Name = "lblSeri"
        Me.lblSeri.ReadOnly = True
        Me.lblSeri.Size = New System.Drawing.Size(168, 21)
        Me.lblSeri.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(15, 188)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Số seri"
        '
        'ManHinhQLTTMayChamCong
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(508, 370)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ListView1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ManHinhQLTTMayChamCong"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Quản lý thông tin máy chấm công(MCC)"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tgmt As System.Windows.Forms.TextBox
    Friend WithEvents tgcc As System.Windows.Forms.TextBox
    Friend WithEvents ImageList As System.Windows.Forms.ImageList
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dlvt As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dlnv As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dlcc As System.Windows.Forms.TextBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dlql As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblSeri As System.Windows.Forms.TextBox
End Class
