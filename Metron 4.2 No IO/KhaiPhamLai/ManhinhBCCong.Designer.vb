<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManhinhBCCong
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
        Me.components = New System.ComponentModel.Container
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.DataSetTam = New KhaiPhamLai.DataSetTam
        Me.BaoCaoBTBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.DataSetTam, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BaoCaoBTBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSetTam_BaoCaoBT"
        ReportDataSource1.Value = Me.BaoCaoBTBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "KhaiPhamLai.BaoCaoCong.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(661, 503)
        Me.ReportViewer1.TabIndex = 0
        '
        'DataSetTam
        '
        Me.DataSetTam.DataSetName = "DataSetTam"
        Me.DataSetTam.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'BaoCaoBTBindingSource
        '
        Me.BaoCaoBTBindingSource.DataMember = "BaoCaoBT"
        Me.BaoCaoBTBindingSource.DataSource = Me.DataSetTam
        '
        'ManhinhBCCong
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(661, 503)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "ManhinhBCCong"
        Me.Text = "ManhinhBCCong"
        CType(Me.DataSetTam, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BaoCaoBTBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents BaoCaoBTBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataSetTam As KhaiPhamLai.DataSetTam
End Class
