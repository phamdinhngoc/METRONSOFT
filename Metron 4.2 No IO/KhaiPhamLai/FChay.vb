Public Class FChay
    Public Kieu As Integer
    Private Sub FChay_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Dim GDMay As New ClassGDMay
        Select Case Kieu
            Case 1
                GDMay.TaiDLMoi(ManHinhChinh.ListView, ManHinhChinh.ListView1, Pb)
                Close()
            Case 2
                GDMay.TaiTCDL(ManHinhChinh.ListView, ManHinhChinh.ListView1, Pb)
                Close()
        End Select
    End Sub
End Class