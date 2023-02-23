Public Class ThongTinLichTam
    Public MaCa As Integer
    Public TenCa As String
    Public TuNgay As Date
    Public DenNgay As Date
    Public Tgvao1 As Date
    Public Tgvao2 As Date
    Public TangCa As Boolean
    Public GHTangCa As Integer
    Public TangCaS As Integer
    Public BatDau As Date
    Public KetThuc As Date
    Public Som As Integer
    Public Tre As Integer
    Public SoPhut As Integer
    Public SoCong As Double
    Public CaDem As Boolean
    Public mau As Integer


    Public Sub New()
        MaCA = 0
        TenCa = "..."
        TuNgay = #1/1/1900#
        DenNgay = #1/1/1900#
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
        SoCong = 0
        CaDem = False
    End Sub
End Class
