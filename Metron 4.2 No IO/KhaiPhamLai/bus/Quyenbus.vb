Imports System.Data
Public Class QuyenBus
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
    Public Sub Them(ByVal Dto As Quyendto, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenGhi = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As QuyenDao
        If ketnoi.ChuoiKetNoi = " " Then
            Dao = New QuyenDao(ketnoiConnection)
        Else
            Dao = New QuyenDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.Them(Dto, MSsql)
    End Sub
    Public Sub Xoa(ByVal ma As Integer, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenXoa = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As QuyenDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New QuyenDao(ketnoiConnection)
        Else
            Dao = New QuyenDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.Xoa(ma, MSsql)
    End Sub
    Public Sub sua(ByVal Dto As Quyendto, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenSua = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As QuyenDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New QuyenDao(ketnoiConnection)
        Else
            Dao = New QuyenDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.sua(Dto, MSsql)
    End Sub
#End Region
    Public Function MaQuyen(ByVal tenquyen As String) As Integer
        Dim dao As DataTable = LayBangTableSQL("Select maquyen from quyen where tenquyen='" & tenquyen & "'")
        Return dao.Rows(0)(0)
    End Function
    Public Function LayBangTable() As DataTable
        Dim Dao As New QuyenDao(ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangTableSQL(ByVal sql As String) As DataTable
        Dim Dao As New AbstractDao(sql, sql, ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangTable(ByVal ma As Integer) As DataTable
        Dim Dao As New QuyenDao(ma, ketnoi, MSsql)
        Return Dao
    End Function

    Public Function LayBangDTo(ByVal ma As Integer) As Quyendto
        Dim Dao As New QuyenDao(ma, ketnoi, MSsql)
        Dim dto As New Quyendto
        If IsDBNull(Dao.Rows(0)("MaQuyen")) = False Then
            dto.MaQuyen = Dao.Rows(0)("MaQuyen")
        End If
        If IsDBNull(Dao.Rows(0)("TenQuyen")) = False Then
            dto.TenQuyen = Dao.Rows(0)("TenQuyen")
        End If
        Return dto
    End Function
End Class

