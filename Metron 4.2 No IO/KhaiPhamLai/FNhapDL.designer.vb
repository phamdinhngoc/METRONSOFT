<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FNhapDL
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
        Me.pb = New System.Windows.Forms.ProgressBar
        Me.Button1 = New System.Windows.Forms.Button
        Me.op = New System.Windows.Forms.OpenFileDialog
        Me.SuspendLayout()
        '
        'pb
        '
        Me.pb.Location = New System.Drawing.Point(12, 24)
        Me.pb.Name = "pb"
        Me.pb.Size = New System.Drawing.Size(415, 23)
        Me.pb.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(434, 23)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Nhập DL"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FNhapDL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(527, 68)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.pb)
        Me.Name = "FNhapDL"
        Me.Text = "FNhapDL"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pb As System.Windows.Forms.ProgressBar
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents op As System.Windows.Forms.OpenFileDialog
End Class
