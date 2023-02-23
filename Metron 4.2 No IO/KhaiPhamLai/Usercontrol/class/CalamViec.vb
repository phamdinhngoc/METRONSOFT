Public Class CalamViec

    Public Thu As Integer
    Public GioBatDau As Integer
    Public GioKetThuc As Integer
    Public PhutBatDau As Integer
    Public PhutKetThuc As Integer
    Public MaCaID As Integer
    Public TenCa As String
    Public Sub New()
        Thu = 0
        GioBatDau = 0
        GioKetThuc = 0
        PhutBatDau = 0
        PhutKetThuc = 0
        MaCaID = 0
        TenCa = ""
    End Sub
    Public Function giodau() As String
        Return IIf(GioBatDau < 10, "0" & GioBatDau, GioBatDau) & ":" & IIf(PhutBatDau < 10, IIf(PhutBatDau = 0, "00", "0" & PhutBatDau), PhutBatDau)
    End Function
    Public Function gioCuoi() As String
        Return IIf(GioKetThuc < 10, "0" & GioKetThuc, GioKetThuc) & ":" & IIf(PhutKetThuc < 10, IIf(PhutKetThuc = 0, "00", "0" & PhutKetThuc), PhutKetThuc)
    End Function
End Class
