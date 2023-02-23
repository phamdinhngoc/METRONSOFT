Public Class Nhatkydto
    Inherits AbstractDto
#Region "Các Thuộc Tính"
    Private _ID As System.Int32
    Private _User As System.String
    Private _Ngay As System.DateTime
    Private _Gio As System.DateTime
    Private _Tacvu As System.String
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
    Public Property User() As System.String
        Get
            Return _User
        End Get
        Set(ByVal value As System.String)
            _User = value
        End Set
    End Property
    Public Property Ngay() As System.DateTime
        Get
            Return _Ngay
        End Get
        Set(ByVal value As System.DateTime)
            _Ngay = value
        End Set
    End Property
    Public Property Gio() As System.DateTime
        Get
            Return _Gio
        End Get
        Set(ByVal value As System.DateTime)
            _Gio = value
        End Set
    End Property
    Public Property Tacvu() As System.String
        Get
            Return _Tacvu
        End Get
        Set(ByVal value As System.String)
            _Tacvu = value
        End Set
    End Property
#End Region
    Public Sub New()
        ID = 0
        User = ""
        Ngay = #1/1/1900#
        Gio = #1/1/1900#
        Tacvu = ""
    End Sub
    Public Function HoTro(ByVal tencolumn As String) As String
        Select Case Convert.ToString(tencolumn)
            Case UCase("ID")
                If IsDBNull(ID) = True Then
                    Return "0"
                End If
                Return Convert.ToString(ID)
            Case UCase("User")
                If IsDBNull(User) = True Then
                    Return """"
                End If
                Return Convert.ToString(User)
            Case UCase("Ngay")
                If IsDBNull(Ngay) = True Then
                    Return "#1/1/1900#"
                End If
                Return Convert.ToString(Ngay)
            Case UCase("Gio")
                If IsDBNull(Gio) = True Then
                    Return "#1/1/1900#"
                End If
                Return Convert.ToString(Gio)
            Case UCase("Tacvu")
                If IsDBNull(Tacvu) = True Then
                    Return """"
                End If
                Return Convert.ToString(Tacvu)
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
            Case UCase("User")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                User = Convert.ToString(value)
            Case UCase("Ngay")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsDate(value) = False Then
                    Return "Không phải ngày đề nghị nhập lại"
                End If
                Ngay = Convert.ToDateTime(value)
            Case UCase("Gio")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsDate(value) = False Then
                    Return "Không phải ngày đề nghị nhập lại"
                End If
                Gio = Convert.ToDateTime(value)
            Case UCase("Tacvu")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                Tacvu = Convert.ToString(value)
            Case Else
                Return ""
        End Select
        Return ""
    End Function
End Class
