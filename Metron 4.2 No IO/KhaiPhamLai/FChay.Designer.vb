<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FChay
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
        Me.Pb = New System.Windows.Forms.ProgressBar
        Me.SuspendLayout()
        '
        'Pb
        '
        Me.Pb.Location = New System.Drawing.Point(12, 12)
        Me.Pb.Name = "Pb"
        Me.Pb.Size = New System.Drawing.Size(429, 23)
        Me.Pb.TabIndex = 0
        '
        'FChay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(453, 46)
        Me.Controls.Add(Me.Pb)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FChay"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FChay"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pb As System.Windows.Forms.ProgressBar
End Class
