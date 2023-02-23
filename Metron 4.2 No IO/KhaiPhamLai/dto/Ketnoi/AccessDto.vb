Public Class AccessDto
    Inherits KetNoiDto
#Region "Attributes"
    Private _Duongdan As String
#End Region
#Region "Property"
    Public Property DuongdanAccess() As String
        Get
            Return _Duongdan
        End Get
        Set(ByVal value As String)
            _Duongdan = value
        End Set
    End Property
#End Region
#Region "Contructor"
    Public Sub New()
        DuongdanAccess = ""
    End Sub
    Public Sub New(ByVal duongdan As String)
        'ChuoiKetNoi = " Provider = Microsoft.Jet.OLEDB.4.0; Data Source =" & duongdan & ";Persist Security Info=True;Jet OLEDB:Database Password=MinhLam20"
        ChuoiKetNoi = " Provider=Microsoft.ACE.OLEDB.12.0; Data Source =" & DuongdanAccess & ";Persist Security Info=True;Jet OLEDB:Database Password=MinhLam20"
    End Sub
    Public Sub ChuoiKetNoiAccess()
        'ChuoiKetNoi = " Provider = Microsoft.Jet.OLEDB.4.0; Data Source =" & DuongdanAccess & ";Persist Security Info=True;Jet OLEDB:Database Password=MinhLam20"
        ChuoiKetNoi = " Provider=Microsoft.ACE.OLEDB.12.0; Data Source =" & DuongdanAccess & ";Persist Security Info=True;Jet OLEDB:Database Password=MinhLam20"

    End Sub
#End Region
End Class
