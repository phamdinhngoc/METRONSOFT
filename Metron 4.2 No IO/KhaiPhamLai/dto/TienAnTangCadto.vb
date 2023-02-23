Public Class TienAnTangCadto
    Inherits AbstractDto
#Region "Các Thuộc Tính"
    Private _ID As System.Int32
    Private _GioTC As System.Int32
    Private _TienAnTC As System.Int32
#End Region
#Region "Khai báo các phương thức truy xuất"
    Public Property ID() As System.Int32
        Get
            Return _ID
        End Get
        Set(ByVal value As System.Int32)
            _ID = value
        End Set
    End Property
    Public Property GioTC() As System.Int32
        Get
            Return _GioTC
        End Get
        Set(ByVal value As System.Int32)
            _GioTC = value
        End Set
    End Property
    Public Property TienAnTC() As System.Int32
        Get
            Return _TienAnTC
        End Get
        Set(ByVal value As System.Int32)
            _TienAnTC = value
        End Set
    End Property
#End Region
    Public Sub New()
        ID = 0
        GioTC = 0
        TienAnTC = 0
       
    End Sub
    Public Function HoTro(ByVal tencolumn As String) As String
        Select Case Convert.ToString(tencolumn)
            Case UCase("ID")
                If IsDBNull(ID) = True Then
                    Return "0"
                End If
                Return Convert.ToString(ID)
            Case UCase("GioTC")
                If IsDBNull(GioTC) = True Then
                    Return "0"
                End If
                Return Convert.ToString(GioTC)
            Case UCase("TienAnTC")
                If IsDBNull(TienAnTC) = True Then
                    Return "0"
                End If
                Return Convert.ToString(TienAnTC)
            Case Else
                Return ""
        End Select
    End Function
    Public Function HoTro(ByVal tencolumn As String, ByVal value As String, Optional ByVal TT As String = "sua") As String
        Select Case Convert.ToString(tencolumn)
            Case UCase("ID")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                ID = Convert.ToInt32(value)
            Case UCase("GioTC")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                GioTC = Convert.ToInt32(value)
            Case UCase("TienAnTC")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                TienAnTC = Convert.ToInt32(value)

            Case Else
                Return ""
        End Select
        Return ""
    End Function
End Class
