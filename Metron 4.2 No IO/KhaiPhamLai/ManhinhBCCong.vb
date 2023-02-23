Public Class ManhinhBCCong

    Private Sub ManhinhBCCong_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim dr As Data.DataRow
        'Me.DataSetTam.BaoCaoBT 
        'For j As Integer = 0 To 10
        '    dr = Me.DataSetTam.Tables("BaoCaoBT").NewRow
        '    dr(0) = j
        '    dr(1) = "Nguyễn Văn A " & j
        '    For i As Integer = 2 To 31 * 3
        '        dr(i) = i
        '    Next
        '    Me.DataSetTam.Tables("BaoCaoBT").Rows.Add(dr)
        'Next
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class