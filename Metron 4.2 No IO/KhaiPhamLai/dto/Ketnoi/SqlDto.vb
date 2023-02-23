Public Class SQLDto
    Inherits KetNoiDto
#Region "Attributes"
    Private _server As String
    Private _database As String
    Private _username As String
    Private _password As String
#End Region
#Region "Property"
    Public Property Server() As String
        Get
            Return _server
        End Get
        Set(ByVal value As String)
            _server = value
        End Set
    End Property
    Public Property Database() As String
        Get
            Return _database
        End Get
        Set(ByVal value As String)
            _database = value
        End Set
    End Property
    Public Property Username() As String
        Get
            Return _username
        End Get
        Set(ByVal value As String)
            _username = value
        End Set
    End Property
    Public Property Password() As String
        Get
            Return _password
        End Get
        Set(ByVal value As String)
            _password = value
        End Set
    End Property
#End Region
#Region "Contructor"
    Public Sub New()
        Server = "localhost"
        Database = ""
        Username = "sa"
        Password = ""
    End Sub
    Public Sub New(ByVal StrServer As String, ByVal StrDatabase As String, ByVal strUsername As String, ByVal strPassword As String)
        Server = StrServer
        Database = StrDatabase
        Username = strUsername
        Password = strPassword
        ChuoiKetNoi = "server=" & Server & ";" & _
       "uid=" & Username & ";pwd=" & Password & ";database=" & Database
    End Sub
    Public Sub New(ByVal StrServer As String, ByVal StrDatabase As String, Optional ByVal strUsername As String = "sa")
        Server = StrServer
        Database = StrDatabase
        Username = strUsername
        Password = ""
        ChuoiKetNoi = "server=" & Server & ";" & _
       "uid=" & Username & ";database=" & Database
    End Sub
    Public Sub ChuoiKetnoiSQL()
        ChuoiKetNoi = "server=" & Server & ";" & _
       "uid=" & Username & ";pwd=" & Password & ";database=" & Database
    End Sub
    Public Sub ChuoiKetnoiSQL_NotPass()
        ChuoiKetNoi = "server=" & Server & ";" & _
       "uid=" & Username & ";database=" & Database
    End Sub
    Public Sub ChuoiKetnoiSQL_NotPass1()
        ChuoiKetNoi = " server=.;database=" & Database & ";integrated security=true;"
    End Sub
#End Region
End Class
