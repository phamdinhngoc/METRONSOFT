Public Class LoaiChuky
    Private _ID As System.Int32
    Private _Tenck As System.String
    Public Property ID() As System.Int32
        Get
            Return _ID
        End Get
        Set(ByVal value As System.Int32)
            _ID = value
        End Set
    End Property
    Public Property TenCk() As System.String
        Get
            Return _Tenck
        End Get
        Set(ByVal value As System.String)
            _Tenck = value
        End Set
    End Property
    Public Sub New()
        ID = 0
        TenCk = ""
    End Sub
    Public Sub New(ByVal i As Integer, ByVal ten As String)
        ID = i
        TenCk = ten
    End Sub
End Class
