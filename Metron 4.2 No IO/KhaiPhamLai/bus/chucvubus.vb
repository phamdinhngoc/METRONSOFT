Imports System.Data
Public Class chucvuBus
    Inherits AbstractBus
    Public Sub New()
        QuyenGhi = ThemCV
        QuyenXoa = XoaCV
        QuyenSua = SuaCV
    End Sub
    Public Sub New(ByVal Connection As OleDb.OleDbConnection, ByVal sqlServer As Boolean)
        ketnoiConnection = Connection
        MSsql = sqlServer
        QuyenGhi = ThemCV
        QuyenXoa = XoaCV
        QuyenSua = SuaCV
    End Sub
    Public Sub New(ByVal Connection As KetNoiDto, ByVal sqlServer As Boolean)
        ketnoi = Connection
        MSsql = sqlServer
        QuyenGhi = ThemCV
        QuyenXoa = XoaCV
        QuyenSua = SuaCV
    End Sub
#Region "Xử Lý"
    Public Sub Them(ByVal Dto As chucvudto, Optional ByVal ChuoiThongBaoLoi As String = "Không có Quyền")
        If QuyenGhi = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As chucvuDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New chucvuDao(ketnoiConnection)
        Else
            Dao = New chucvuDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.Them(Dto, MSsql)
    End Sub
    Public Sub Xoa(ByVal ma As Integer, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenXoa = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As chucvuDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New chucvuDao(ketnoiConnection)
        Else
            Dao = New chucvuDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.xoa(ma, MSsql)
    End Sub
    Public Sub sua(ByVal Dto As chucvudto, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenSua = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As chucvuDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New chucvuDao(ketnoiConnection)
        Else
            Dao = New chucvuDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.sua(Dto, MSsql)
    End Sub
#End Region
    Public Function LayBangTable() As DataTable
        Dim Dao As New chucvuDao(ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangTableSQL(ByVal sql As String) As DataTable
        Dim Dao As New AbstractDao(sql, sql, ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangTable(ByVal ma As Integer) As DataTable
        Dim Dao As New chucvuDao(ma, ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangDTo(ByVal ma As Integer) As chucvudto
        Dim Dao As New chucvuDao(ma, ketnoi, MSsql)
        Dim dto As New chucvudto
        If IsDBNull(Dao.Rows(0)("CVID")) = False Then
            dto.CVID = Dao.Rows(0)("CVID")
        End If
        If IsDBNull(Dao.Rows(0)("Chucvu")) = False Then
            dto.Chucvu = Dao.Rows(0)("Chucvu")
        End If
        Return dto
    End Function
End Class

