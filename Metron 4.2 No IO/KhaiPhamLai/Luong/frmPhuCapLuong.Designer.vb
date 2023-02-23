<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPhuCapLuong
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
        Me.txtComtrua = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.txttienantc1 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txttienantc2 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txttienxe = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'txtComtrua
        '
        Me.txtComtrua.Location = New System.Drawing.Point(127, 60)
        Me.txtComtrua.Name = "txtComtrua"
        Me.txtComtrua.Size = New System.Drawing.Size(189, 22)
        Me.txtComtrua.TabIndex = 32
        Me.txtComtrua.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(35, 63)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 14)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "Tiền cơm trưa"
        '
        'Label6
        '
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(0, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(337, 46)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "PHỤ CẤP LƯƠNG"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(229, 149)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(87, 25)
        Me.Button2.TabIndex = 14
        Me.Button2.Text = "Thoát"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(127, 149)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 25)
        Me.Button1.TabIndex = 15
        Me.Button1.Text = "Sửa"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txttienantc1
        '
        Me.txttienantc1.Location = New System.Drawing.Point(127, 88)
        Me.txttienantc1.Name = "txttienantc1"
        Me.txttienantc1.Size = New System.Drawing.Size(189, 22)
        Me.txttienantc1.TabIndex = 40
        Me.txttienantc1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 92)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 14)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "Tiền Ăn TC >=3h"
        '
        'txttienantc2
        '
        Me.txttienantc2.Location = New System.Drawing.Point(127, 116)
        Me.txttienantc2.Name = "txttienantc2"
        Me.txttienantc2.Size = New System.Drawing.Size(189, 22)
        Me.txttienantc2.TabIndex = 42
        Me.txttienantc2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 120)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 14)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Tiền Ăn TC >= 5.5h"
        '
        'txttienxe
        '
        Me.txttienxe.Location = New System.Drawing.Point(116, 254)
        Me.txttienxe.Name = "txttienxe"
        Me.txttienxe.Size = New System.Drawing.Size(189, 22)
        Me.txttienxe.TabIndex = 36
        Me.txttienxe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txttienxe.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(60, 257)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(48, 14)
        Me.Label13.TabIndex = 35
        Me.Label13.Text = "Tiền xe"
        Me.Label13.Visible = False
        '
        'frmPhuCapLuong
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(337, 181)
        Me.Controls.Add(Me.txttienantc2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txttienantc1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txttienxe)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtComtrua)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmPhuCapLuong"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Phụ cấp lương"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtComtrua As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txttienantc1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txttienantc2 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txttienxe As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
End Class
