Imports System.Data
Public Class QuyenChiTietBus
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
    Public Sub Them(ByVal Dto As QuyenChiTietdto, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenGhi = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As QuyenChiTietDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New QuyenChiTietDao(ketnoiConnection)
        Else
            Dao = New QuyenChiTietDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.Them(Dto, MSsql)
    End Sub
    Public Sub Xoa(ByVal ma As Integer, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenXoa = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As QuyenChiTietDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New QuyenChiTietDao(ketnoiConnection)
        Else
            Dao = New QuyenChiTietDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.Xoa(ma, MSsql)
    End Sub
    Public Sub Xoa(ByVal Quyen As Integer, ByVal Tenform As String, ByVal tenbutton As String, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenXoa = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As QuyenChiTietDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New QuyenChiTietDao(ketnoiConnection)
        Else
            Dao = New QuyenChiTietDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.Xoa(Quyen, Tenform, tenbutton, MSsql)
    End Sub
    Public Sub XoaQuyen(ByVal quyen As Integer, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenXoa = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As QuyenChiTietDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New QuyenChiTietDao(ketnoiConnection)
        Else
            Dao = New QuyenChiTietDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.Xoaquyen(quyen, MSsql)
    End Sub
    Public Sub sua(ByVal Dto As QuyenChiTietdto, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenSua = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As QuyenChiTietDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New QuyenChiTietDao(ketnoiConnection)
        Else
            Dao = New QuyenChiTietDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.sua(Dto, MSsql)
    End Sub
#End Region
    Public Function KiemTraCo(ByVal Quyen As Integer, ByVal TenForm As String, ByVal tenbutton As String) As Boolean
        Dim t As DataTable = LayBangTableSQL("select * from Quyenchitiet where Quyen= " & Quyen & " and TenForm='" & TenForm & "' and TenButon='" & tenbutton & "'")
        If t.Rows.Count > 0 Then Return True
        Return False
    End Function
    Public Function LayBangTable() As DataTable
        Dim Dao As New QuyenChiTietDao(ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangTableSQL(ByVal sql As String) As DataTable
        Dim Dao As New AbstractDao(sql, sql, ketnoi, MSsql)
        Return Dao
    End Function
    Public Sub suaQuyen(ByVal Quyen As Integer, ByVal ma As String)
        Dim dao As New QuyenChiTietDao
        dao.SuaQuyen(Quyen, ma, MSsql)
    End Sub
    Public Function LayBangTable(ByVal ma As Integer) As DataTable
        Dim Dao As New QuyenChiTietDao(ma, ketnoi, MSsql)
        Return Dao
    End Function
    Public Function MAX()
        Dim dao As New QuyenChiTietDao(True, ketnoi, MSsql)
        Return dao.Rows(0)(0)
    End Function
    Public Function LayBangDTo(ByVal ma As Integer) As QuyenChiTietdto
        Dim Dao As New QuyenChiTietDao(ma, ketnoi, MSsql)
        Dim dto As New QuyenChiTietdto
        If IsDBNull(Dao.Rows(0)("iD")) = False Then
            dto.iD = Dao.Rows(0)("iD")
        End If
        If IsDBNull(Dao.Rows(0)("Quyen")) = False Then
            dto.Quyen = Dao.Rows(0)("Quyen")
        End If
        If IsDBNull(Dao.Rows(0)("TenForm")) = False Then
            dto.TenForm = Dao.Rows(0)("TenForm")
        End If
        If IsDBNull(Dao.Rows(0)("TenButon")) = False Then
            dto.TenButon = Dao.Rows(0)("TenButon")
        End If
        Return dto
    End Function
End Class

