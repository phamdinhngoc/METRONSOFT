Public Class nvvandto
    Inherits AbstractDto
#Region "Các Thuộc Tính"
    Private _MaNV As System.Int32
    Private _VanID As System.Int32
    Private _ma As System.String
    Private _BVan As System.Byte()

#End Region
#Region "Khai báo các phương thức truy xuất"
    Public Property MaNV() As System.Int32
        Get
            Return _MaNV
        End Get
        Set(ByVal value As System.Int32)
            _MaNV = value
        End Set
    End Property
    Public Property VanID() As System.Int32
        Get
            Return _VanID
        End Get
        Set(ByVal value As System.Int32)
            _VanID = value
        End Set
    End Property
    Public Property ma() As System.String
        Get
            Return _ma
        End Get
        Set(ByVal value As System.String)
            _ma = value
        End Set
    End Property

    Public Property BVan() As System.Byte()
        Get
            Return _BVan
        End Get
        Set(ByVal value As System.Byte())
            _BVan = value
        End Set
    End Property


#End Region
    Public Sub New()
        MaNV = 0
        VanID = 0
        ma = ""

    End Sub
    Public Function HoTro(ByVal tencolumn As String) As String
        Select Case Convert.ToString(tencolumn)
            Case UCase("MaNV")
                If IsDBNull(MaNV) = True Then
                    Return "0"
                End If
                Return Convert.ToString(MaNV)
            Case UCase("VanID")
                If IsDBNull(VanID) = True Then
                    Return "0"
                End If
                Return Convert.ToString(VanID)
            Case UCase("ma")
                If IsDBNull(ma) = True Then
                    Return """"
                End If
                Return Convert.ToString(ma)
            Case Else
                Return ""
        End Select
    End Function
    Public Function HoTro(ByVal tencolumn As String, ByVal value As String, Optional ByVal TT As String = "sua") As String
        Select Case Convert.ToString(tencolumn)
            Case UCase("MaNV")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                MaNV = Convert.ToInt32(value)
            Case UCase("VanID")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                VanID = Convert.ToInt32(value)
            Case UCase("ma")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                ma = Convert.ToString(value)
            Case Else
                Return ""
        End Select
        Return ""
    End Function
End Class
