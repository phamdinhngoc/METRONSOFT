Imports System.Data
Public Class NhatkyBus
    Inherits AbstractBus
    Public Sub New()
    End Sub
    Public Sub New(ByVal ConnectionString As KetNoiDto, ByVal sqlServer As Boolean)
        ketnoi = ConnectionString
        MSsql = sqlServer
    End Sub
#Region "Xử Lý"
    Public Sub Them(ByVal Dto As Nhatkydto)
        Dim Dao As New NhatkyDao(ketnoi, MSsql)
        Dao.Them(Dto, MSsql)
    End Sub
    Public Sub Xoa(ByVal ma As Integer)
        Dim Dao As New NhatkyDao(ketnoi, MSsql)
        Dao.Xoa(ma, MSsql)
    End Sub
    Public Sub sua(ByVal Dto As Nhatkydto)
        Dim Dao As New NhatkyDao(ketnoi, MSsql)
        Dao.sua(Dto, MSsql)
    End Sub
#End Region
    Public Function xemNhatky(ByVal tungay As DateTime, ByVal dengay As DateTime, Optional ByVal tennguoidung As String = "", Optional ByVal tacvu As String = "") As OleDb.OleDbDataReader
        Dim Dao As New NhatkyDao(ketnoi, MSsql)
        Return Dao.xemNhatky(tungay, dengay, tennguoidung, tacvu)
    End Function
    Public Function LayBangTable() As DataTable
        Dim Dao As New NhatkyDao(ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangTableSQL(ByVal sql As String) As DataTable
        Dim Dao As New AbstractDao(sql, sql, ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangTable(ByVal ma As Integer) As DataTable
        Dim Dao As New NhatkyDao(ma, ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangDTo(ByVal ma As Integer) As Nhatkydto
        Dim Dao As New NhatkyDao(ma, ketnoi, MSsql)
        Dim dto As New Nhatkydto
        If IsDBNull(Dao.Rows(0)("ID")) = False Then
            dto.ID = Dao.Rows(0)("ID")
        End If
        If IsDBNull(Dao.Rows(0)("User")) = False Then
            dto.User = Dao.Rows(0)("User")
        End If
        If IsDBNull(Dao.Rows(0)("Ngay")) = False Then
            dto.Ngay = Dao.Rows(0)("Ngay")
        End If
        If IsDBNull(Dao.Rows(0)("Gio")) = False Then
            dto.Gio = Dao.Rows(0)("Gio")
        End If
        If IsDBNull(Dao.Rows(0)("Tacvu")) = False Then
            dto.Tacvu = Dao.Rows(0)("Tacvu")
        End If
        Return dto
    End Function
End Class

