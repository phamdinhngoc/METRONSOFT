<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmThongTinLuong
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
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtManv = New System.Windows.Forms.TextBox
        Me.txtHoten = New System.Windows.Forms.TextBox
        Me.TxtBaoHiem = New System.Windows.Forms.TextBox
        Me.txtPhatDitre = New System.Windows.Forms.TextBox
        Me.txtPhatNghiKhongphep = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtTienTCgio = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtTamUng1 = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtPhucap1 = New System.Windows.Forms.TextBox
        Me.txtLuongThang = New System.Windows.Forms.TextBox
        Me.txtPhucap2 = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtChuyencan = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtTienXe = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(63, 307)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Sửa"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(250, 307)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 0
        Me.Button2.Text = "Thoát"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(79, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "MANV"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(78, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Họ tên"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(49, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Lương tháng"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(41, 122)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Tiền bảo hiểm"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(82, 433)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Phạt đi trễ"
        Me.Label5.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(91, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(167, 19)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "THÔNG TIN LƯƠNG"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(28, 456)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(111, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Phạt nghỉ không phép"
        Me.Label7.Visible = False
        '
        'txtManv
        '
        Me.txtManv.BackColor = System.Drawing.Color.White
        Me.txtManv.Location = New System.Drawing.Point(126, 43)
        Me.txtManv.Name = "txtManv"
        Me.txtManv.ReadOnly = True
        Me.txtManv.Size = New System.Drawing.Size(81, 21)
        Me.txtManv.TabIndex = 2
        '
        'txtHoten
        '
        Me.txtHoten.BackColor = System.Drawing.Color.White
        Me.txtHoten.Location = New System.Drawing.Point(126, 70)
        Me.txtHoten.Name = "txtHoten"
        Me.txtHoten.ReadOnly = True
        Me.txtHoten.Size = New System.Drawing.Size(163, 21)
        Me.txtHoten.TabIndex = 2
        '
        'TxtBaoHiem
        '
        Me.TxtBaoHiem.Location = New System.Drawing.Point(126, 119)
        Me.TxtBaoHiem.Name = "TxtBaoHiem"
        Me.TxtBaoHiem.Size = New System.Drawing.Size(163, 21)
        Me.TxtBaoHiem.TabIndex = 1
        Me.TxtBaoHiem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPhatDitre
        '
        Me.txtPhatDitre.Location = New System.Drawing.Point(148, 429)
        Me.txtPhatDitre.Name = "txtPhatDitre"
        Me.txtPhatDitre.Size = New System.Drawing.Size(163, 21)
        Me.txtPhatDitre.TabIndex = 2
        Me.txtPhatDitre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPhatDitre.Visible = False
        '
        'txtPhatNghiKhongphep
        '
        Me.txtPhatNghiKhongphep.Location = New System.Drawing.Point(148, 431)
        Me.txtPhatNghiKhongphep.Name = "txtPhatNghiKhongphep"
        Me.txtPhatNghiKhongphep.Size = New System.Drawing.Size(163, 21)
        Me.txtPhatNghiKhongphep.TabIndex = 2
        Me.txtPhatNghiKhongphep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPhatNghiKhongphep.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(61, 147)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Tiền TC/h"
        '
        'txtTienTCgio
        '
        Me.txtTienTCgio.BackColor = System.Drawing.Color.White
        Me.txtTienTCgio.Location = New System.Drawing.Point(126, 144)
        Me.txtTienTCgio.Name = "txtTienTCgio"
        Me.txtTienTCgio.ReadOnly = True
        Me.txtTienTCgio.Size = New System.Drawing.Size(163, 21)
        Me.txtTienTCgio.TabIndex = 2
        Me.txtTienTCgio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(67, 172)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 13)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Tạm ứng"
        '
        'txtTamUng1
        '
        Me.txtTamUng1.Location = New System.Drawing.Point(126, 169)
        Me.txtTamUng1.Name = "txtTamUng1"
        Me.txtTamUng1.Size = New System.Drawing.Size(163, 21)
        Me.txtTamUng1.TabIndex = 3
        Me.txtTamUng1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(71, 197)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(45, 13)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Phụ cấp"
        '
        'txtPhucap1
        '
        Me.txtPhucap1.Location = New System.Drawing.Point(126, 194)
        Me.txtPhucap1.Name = "txtPhucap1"
        Me.txtPhucap1.Size = New System.Drawing.Size(163, 21)
        Me.txtPhucap1.TabIndex = 4
        Me.txtPhucap1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLuongThang
        '
        Me.txtLuongThang.Location = New System.Drawing.Point(126, 94)
        Me.txtLuongThang.Name = "txtLuongThang"
        Me.txtLuongThang.Size = New System.Drawing.Size(163, 21)
        Me.txtLuongThang.TabIndex = 5
        Me.txtLuongThang.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPhucap2
        '
        Me.txtPhucap2.Location = New System.Drawing.Point(126, 219)
        Me.txtPhucap2.Name = "txtPhucap2"
        Me.txtPhucap2.Size = New System.Drawing.Size(163, 21)
        Me.txtPhucap2.TabIndex = 9
        Me.txtPhucap2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(63, 222)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(54, 13)
        Me.Label12.TabIndex = 8
        Me.Label12.Text = "Phụ cấp 1"
        '
        'txtChuyencan
        '
        Me.txtChuyencan.Location = New System.Drawing.Point(126, 246)
        Me.txtChuyencan.Name = "txtChuyencan"
        Me.txtChuyencan.Size = New System.Drawing.Size(163, 21)
        Me.txtChuyencan.TabIndex = 13
        Me.txtChuyencan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(30, 250)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(87, 13)
        Me.Label14.TabIndex = 12
        Me.Label14.Text = "Tiền Chuyên cần"
        '
        'txtTienXe
        '
        Me.txtTienXe.Location = New System.Drawing.Point(126, 273)
        Me.txtTienXe.Name = "txtTienXe"
        Me.txtTienXe.Size = New System.Drawing.Size(163, 21)
        Me.txtTienXe.TabIndex = 15
        Me.txtTienXe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(72, 277)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 13)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Tiền Xe"
        '
        'frmThongTinLuong
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(385, 341)
        Me.Controls.Add(Me.txtTienXe)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtChuyencan)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtPhucap2)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtLuongThang)
        Me.Controls.Add(Me.txtPhatNghiKhongphep)
        Me.Controls.Add(Me.txtPhatDitre)
        Me.Controls.Add(Me.txtPhucap1)
        Me.Controls.Add(Me.txtTamUng1)
        Me.Controls.Add(Me.txtTienTCgio)
        Me.Controls.Add(Me.TxtBaoHiem)
        Me.Controls.Add(Me.txtHoten)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtManv)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmThongTinLuong"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Thông tin lương"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtManv As System.Windows.Forms.TextBox
    Friend WithEvents txtHoten As System.Windows.Forms.TextBox
    Friend WithEvents TxtBaoHiem As System.Windows.Forms.TextBox
    Friend WithEvents txtPhatDitre As System.Windows.Forms.TextBox
    Friend WithEvents txtPhatNghiKhongphep As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTienTCgio As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtTamUng1 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtPhucap1 As System.Windows.Forms.TextBox
    Friend WithEvents txtLuongThang As System.Windows.Forms.TextBox
    Friend WithEvents txtPhucap2 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtChuyencan As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtTienXe As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
