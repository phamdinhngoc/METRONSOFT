Imports System.data
Public Class AbstractBus
    Public MSsql As Boolean = True
    Public ketnoiConnection As New OleDb.OleDbConnection
    Public ketnoi As New KetNoiDto
    Public QuyenGhi As Boolean = True
    Public QuyenXoa As Boolean = True
    Public QuyenSua As Boolean = True
    Public Sub New()
    End Sub
    Public Sub New(ByVal Connection As OleDb.OleDbConnection, ByVal sqlServer As Boolean)
        ketnoiConnection = Connection
        MSsql = sqlServer
    End Sub
    Public Sub New(ByVal Connection As KetNoiDto, ByVal sqlServer As Boolean)
        ketnoi = Connection
        MSsql = sqlServer
    End Sub
    Public Function CreateTable(ByVal TenTable As String) As DataTable
        Dim dao As New AbstractDao(TenTable, ketnoi, MSsql)
        Return dao
    End Function
    Public Function CreateTableQuery(ByVal StringSql As String) As DataTable
        Dim dao As New AbstractDao("LinhTinh", StringSql, ketnoi, MSsql)
        Return dao
    End Function
End Class
