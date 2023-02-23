Public Class Nguoidungdto
    Inherits AbstractDto
#Region "Các Thuộc Tính"
    Private _userID As System.String
    Private _pass As System.String
    Private _Quyen As System.String
    Private _Cauhoi1 As System.String
    Private _Traloi1 As System.String
    Private _Cauhoi2 As System.String
    Private _Traloi2 As System.String
#End Region
#Region "Khai báo các phương thức truy xuất"
    Public Property userID() As System.String
        Get
            Return _userID
        End Get
        Set(ByVal value As System.String)
            _userID = Value
        End Set
    End Property
    Public Property pass() As System.String
        Get
            Return _pass
        End Get
        Set(ByVal value As System.String)
            _pass = Value
        End Set
    End Property
    Public Property Quyen() As System.String
        Get
            Return _Quyen
        End Get
        Set(ByVal value As System.String)
            _Quyen = Value
        End Set
    End Property
    Public Property Cauhoi1() As System.String
        Get
            Return _Cauhoi1
        End Get
        Set(ByVal value As System.String)
            _Cauhoi1 = Value
        End Set
    End Property
    Public Property Traloi1() As System.String
        Get
            Return _Traloi1
        End Get
        Set(ByVal value As System.String)
            _Traloi1 = Value
        End Set
    End Property
    Public Property Cauhoi2() As System.String
        Get
            Return _Cauhoi2
        End Get
        Set(ByVal value As System.String)
            _Cauhoi2 = Value
        End Set
    End Property
    Public Property Traloi2() As System.String
        Get
            Return _Traloi2
        End Get
        Set(ByVal value As System.String)
            _Traloi2 = Value
        End Set
    End Property
#End Region
    Public Sub New()
        userID = ""
        pass = ""
        Quyen = ""
        Cauhoi1 = ""
        Traloi1 = ""
        Cauhoi2 = ""
        Traloi2 = ""
    End Sub
    Public Function HoTro(ByVal tencolumn As String) As String
        Select Case Convert.ToString(tencolumn)
            Case Ucase("userID")
                If IsDBNull(userID) = True Then
                    Return """"
                End If
                Return Convert.ToString(userID)
            Case Ucase("pass")
                If IsDBNull(pass) = True Then
                    Return """"
                End If
                Return Convert.ToString(pass)
            Case Ucase("Quyen")
                If IsDBNull(Quyen) = True Then
                    Return """"
                End If
                Return Convert.ToString(Quyen)
            Case Ucase("Cauhoi1")
                If IsDBNull(Cauhoi1) = True Then
                    Return """"
                End If
                Return Convert.ToString(Cauhoi1)
            Case Ucase("Traloi1")
                If IsDBNull(Traloi1) = True Then
                    Return """"
                End If
                Return Convert.ToString(Traloi1)
            Case Ucase("Cauhoi2")
                If IsDBNull(Cauhoi2) = True Then
                    Return """"
                End If
                Return Convert.ToString(Cauhoi2)
            Case Ucase("Traloi2")
                If IsDBNull(Traloi2) = True Then
                    Return """"
                End If
                Return Convert.ToString(Traloi2)
            Case Else
                Return ""
        End Select
    End Function
    Public Function HoTro(ByVal tencolumn As String, ByVal value As String) As String
        Select Case Convert.ToString(tencolumn)
            Case UCase("userID")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                userID = Convert.ToString(value)
            Case UCase("pass")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                pass = Convert.ToString(value)
            Case UCase("Quyen")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                Quyen = Convert.ToString(value)
            Case UCase("Cauhoi1")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                Cauhoi1 = Convert.ToString(value)
            Case UCase("Traloi1")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                Traloi1 = Convert.ToString(value)
            Case UCase("Cauhoi2")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                Cauhoi2 = Convert.ToString(value)
            Case UCase("Traloi2")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                Traloi2 = Convert.ToString(value)
            Case Else
                Return ""
        End Select
        Return ""
    End Function
End Class
