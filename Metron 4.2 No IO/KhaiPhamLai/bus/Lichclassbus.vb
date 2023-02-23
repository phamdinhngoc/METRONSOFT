
Imports System.Data

Public Class LichclassBus
    Inherits AbstractBus
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
#Region "Xử Lý"
    Public Sub Them(ByVal Dto As Lichclassdto, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenGhi = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As LichclassDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New LichclassDao(ketnoiConnection)
        Else
            Dao = New LichclassDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.Them(Dto, MSsql)
    End Sub
    Public Sub Xoa(ByVal ma As Integer, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenXoa = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As LichclassDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New LichclassDao(ketnoiConnection)
        Else
            Dao = New LichclassDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.Xoa(ma, MSsql)
    End Sub
    Public Sub XoatheoLich(ByVal Lichid As Integer, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenXoa = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As LichclassDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New LichclassDao(ketnoiConnection)
        Else
            Dao = New LichclassDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.XoaTheoLich(Lichid, MSsql)
    End Sub
    Public Sub sua(ByVal Dto As Lichclassdto, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenSua = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As LichclassDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New LichclassDao(ketnoiConnection)
        Else
            Dao = New LichclassDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.sua(Dto, MSsql)
    End Sub
#End Region
    Public Function LayBangTable() As DataTable
        Dim Dao As New LichclassDao(ketnoi, MSsql)
        Return Dao
    End Function
    Public Function laybangTableTheoCaid(ByVal caid As Integer) As DataTable
        Dim sql As String = "Select * from lichclass where caid=" & caid
        Dim Dao As New AbstractDao(Sql, Sql, ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangTableSQL(ByVal sql As String) As DataTable
        Dim Dao As New AbstractDao(sql, sql, ketnoi, MSsql)
        Return Dao
    End Function
    Public Sub suaLichID(ByVal LichID As Integer, ByVal ma As String)
        Dim dao As New LichclassDao
        dao.SuaLichID(LichID, ma, MSsql)
    End Sub
    Public Sub suaSThu(ByVal SThu As Integer, ByVal ma As String)
        Dim dao As New LichclassDao
        dao.SuaSThu(SThu, ma, MSsql)
    End Sub
    Public Sub suaEThu(ByVal EThu As Integer, ByVal ma As String)
        Dim dao As New LichclassDao
        dao.SuaEThu(EThu, ma, MSsql)
    End Sub
    Public Sub suacaid(ByVal caid As Integer, ByVal ma As String)
        Dim dao As New LichclassDao
        dao.Suacaid(caid, ma, MSsql)
    End Sub
    Public Function LayBangTable(ByVal ma As Integer) As DataTable
        Dim Dao As New LichclassDao(ma, ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangDTo(ByVal ma As Integer) As Lichclassdto
        Dim Dao As New LichclassDao(ma, ketnoi, MSsql)
        Dim dto As New Lichclassdto
        If IsDBNull(Dao.Rows(0)("ID")) = False Then
            dto.ID = Dao.Rows(0)("ID")
        End If
        If IsDBNull(Dao.Rows(0)("LichID")) = False Then
            dto.LichID = Dao.Rows(0)("LichID")
        End If
        If IsDBNull(Dao.Rows(0)("SThu")) = False Then
            dto.SThu = Dao.Rows(0)("SThu")
        End If
        If IsDBNull(Dao.Rows(0)("EThu")) = False Then
            dto.EThu = Dao.Rows(0)("EThu")
        End If
        If IsDBNull(Dao.Rows(0)("caid")) = False Then
            dto.caid = Dao.Rows(0)("caid")
        End If
        Return dto
    End Function
    Public Function LayBangDTo(ByVal daoLich As DataTable, ByVal dong As Integer) As Lichclassdto
        Dim dto As New Lichclassdto
        If IsDBNull(daoLich.Rows(dong)("ID")) = False Then
            dto.ID = daoLich.Rows(dong)("ID")
        End If
        If IsDBNull(daoLich.Rows(dong)("LichID")) = False Then
            dto.LichID = daoLich.Rows(dong)("LichID")
        End If
        If IsDBNull(daoLich.Rows(dong)("SThu")) = False Then
            dto.SThu = daoLich.Rows(dong)("SThu")
        End If
        If IsDBNull(daoLich.Rows(dong)("EThu")) = False Then
            dto.EThu = daoLich.Rows(dong)("EThu")
        End If
        If IsDBNull(daoLich.Rows(dong)("caid")) = False Then
            dto.caid = daoLich.Rows(dong)("caid")
        End If
        Return dto
    End Function
End Class

