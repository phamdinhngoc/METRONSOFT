Imports System.Xml
Public Class KetNoiDto
    Inherits AbstractDto
#Region "Attributes"
    Private _Chuoi_ketnoi As String
#End Region
#Region "Property"
    Public Property ChuoiKetNoi() As String
        Get
            Return _Chuoi_ketnoi
        End Get
        Set(ByVal value As String)
            _Chuoi_ketnoi = value
        End Set
    End Property
#End Region
End Class
