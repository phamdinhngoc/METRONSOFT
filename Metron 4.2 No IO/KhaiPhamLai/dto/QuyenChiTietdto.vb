Public Class QuyenChiTietdto
    Inherits AbstractDto
#Region "Các Thuộc Tính"
    Private _iD As System.Int32
    Private _Quyen As System.Int32
    Private _TenForm As System.String
    Private _TenButon As System.String
#End Region
#Region "Khai báo các phương thức truy xuất"
    Public Property iD() As System.Int32
        Get
            Return _iD
        End Get
        Set(ByVal value As System.Int32)
            _iD = value
        End Set
    End Property
    Public Property Quyen() As System.Int32
        Get
            Return _Quyen
        End Get
        Set(ByVal value As System.Int32)
            _Quyen = value
        End Set
    End Property
    Public Property TenForm() As System.String
        Get
            Return _TenForm
        End Get
        Set(ByVal value As System.String)
            _TenForm = value
        End Set
    End Property
    Public Property TenButon() As System.String
        Get
            Return _TenButon
        End Get
        Set(ByVal value As System.String)
            _TenButon = value
        End Set
    End Property
#End Region
    Public Sub New()
        iD = 0
        Quyen = 0
        TenForm = ""
        TenButon = ""
    End Sub
    Public Function HoTro(ByVal tencolumn As String) As String
        Select Case Convert.ToString(tencolumn)
            Case UCase("iD")
                If IsDBNull(iD) = True Then
                    Return "0"
                End If
                Return Convert.ToString(iD)
            Case UCase("Quyen")
                If IsDBNull(Quyen) = True Then
                    Return "0"
                End If
                Return Convert.ToString(Quyen)
            Case UCase("TenForm")
                If IsDBNull(TenForm) = True Then
                    Return """"
                End If
                Return Convert.ToString(TenForm)
            Case UCase("TenButon")
                If IsDBNull(TenButon) = True Then
                    Return """"
                End If
                Return Convert.ToString(TenButon)
            Case Else
                Return ""
        End Select
    End Function
    Public Function HoTro(ByVal tencolumn As String, ByVal value As String, Optional ByVal TT As String = "sua") As String
        Select Case Convert.ToString(tencolumn)
            Case UCase("iD")
                If TT = "sua" Then
                    If IsDBNull(value) = True Then
                        Return "Bạn chưa nhập dử liệu"
                    End If
                    If value = "" Then
                        Return "Bạn chưa nhập dử liệu"
                    End If
                    If IsNumeric(value) = False Then
                        Return "Không phải số dề nghị nhập lại"
                    End If
                    iD = Convert.ToInt32(value)
                End If
            Case UCase("Quyen")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                Quyen = Convert.ToInt32(value)
            Case UCase("TenForm")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                TenForm = Convert.ToString(value)
            Case UCase("TenButon")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                TenButon = Convert.ToString(value)
            Case Else
                Return ""
        End Select
        Return ""
    End Function
End Class
