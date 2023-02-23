Public Class chucvudto
    Inherits AbstractDto
#Region "Các Thuộc Tính"
    Private _CVID As System.Int32
    Private _Chucvu As System.String
#End Region
#Region "Khai báo các phương thức truy xuất"
    Public Property CVID() As System.Int32
        Get
            Return _CVID
        End Get
        Set(ByVal value As System.Int32)
            _CVID = value
        End Set
    End Property
    Public Property Chucvu() As System.String
        Get
            Return _Chucvu
        End Get
        Set(ByVal value As System.String)
            _Chucvu = value
        End Set
    End Property
#End Region
    Public Sub New()
        CVID = 0
        Chucvu = ""
    End Sub
    Public Function HoTro(ByVal tencolumn As String) As String
        Select Case Convert.ToString(tencolumn)
            Case UCase("CVID")
                If IsDBNull(CVID) = True Then
                    Return "0"
                End If
                Return Convert.ToString(CVID)
            Case UCase("Chucvu")
                If IsDBNull(Chucvu) = True Then
                    Return """"
                End If
                Return Convert.ToString(Chucvu)
            Case Else
                Return ""
        End Select
    End Function
    Public Function HoTro(ByVal tencolumn As String, ByVal value As String, Optional ByVal TT As String = "sua") As String
        Select Case Convert.ToString(tencolumn)
            Case UCase("CVID")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                CVID = Convert.ToInt32(value)
            Case UCase("Chucvu")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                Chucvu = Convert.ToString(value)
            Case Else
                Return ""
        End Select
        Return ""
    End Function
End Class
