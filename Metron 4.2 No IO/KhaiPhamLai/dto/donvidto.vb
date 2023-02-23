Public Class donvidto
    Inherits AbstractDto
#Region "Các Thuộc Tính"
    Private _MaDV As System.Int32
    Private _TenDV As System.String
    Private _Nhanh As System.Int32
#End Region
#Region "Khai báo các phương thức truy xuất"
    Public Property MaDV() As System.Int32
        Get
            Return _MaDV
        End Get
        Set(ByVal value As System.Int32)
            _MaDV = value
        End Set
    End Property
    Public Property TenDV() As System.String
        Get
            Return _TenDV
        End Get
        Set(ByVal value As System.String)
            _TenDV = value
        End Set
    End Property
    Public Property Nhanh() As System.Int32
        Get
            Return _Nhanh
        End Get
        Set(ByVal value As System.Int32)
            _Nhanh = value
        End Set
    End Property
#End Region
    Public Sub New()
        MaDV = 0
        TenDV = ""
        Nhanh = 0
    End Sub
    Public Function HoTro(ByVal tencolumn As String) As String
        Select Case Convert.ToString(tencolumn)
            Case UCase("MaDV")
                If IsDBNull(MaDV) = True Then
                    Return "0"
                End If
                Return Convert.ToString(MaDV)
            Case UCase("TenDV")
                If IsDBNull(TenDV) = True Then
                    Return """"
                End If
                Return Convert.ToString(TenDV)
            Case UCase("Nhanh")
                If IsDBNull(Nhanh) = True Then
                    Return "0"
                End If
                Return Convert.ToString(Nhanh)
            Case Else
                Return ""
        End Select
    End Function
    Public Function HoTro(ByVal tencolumn As String, ByVal value As String, Optional ByVal TT As String = "sua") As String
        Select Case Convert.ToString(tencolumn)
            Case UCase("MaDV")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                MaDV = Convert.ToInt32(value)
            Case UCase("TenDV")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                TenDV = Convert.ToString(value)
            Case UCase("Nhanh")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                Nhanh = Convert.ToInt32(value)
            Case Else
                Return ""
        End Select
        Return ""
    End Function
End Class
