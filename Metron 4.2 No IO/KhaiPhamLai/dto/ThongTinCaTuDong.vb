Public Class ThongTinCaTuDong
    Public ID As Integer
    Public TenCa As String
    Public BatDau As Date
    Public KetThuc As Date
    Public Tgvao1 As Date
    Public Tgvao2 As Date
    Public Som As Integer
    Public Tre As Integer
    Public SoPhut As Integer
    Public NgayCong As Double
    Public mau As Integer
    Public TangCa As Boolean
    Public GHTangCa As Integer
    Public TangCaS As Integer
    Public CaquaNgay As Boolean
    Public Sub New()
        ID = 0
        TenCa = "..."
        Tgvao1 = #1/1/1900#
        Tgvao2 = #1/1/1900#
        TangCa = False
        GHTangCa = 0
        TangCaS = 0
        BatDau = #1/1/1900#
        KetThuc = #1/1/1900#
        Som = 0
        Tre = 0
        SoPhut = 0
        NgayCong = 0
        CaquaNgay = False
    End Sub
End Class
