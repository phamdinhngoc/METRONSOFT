Imports System.Data
Public Class LichBus
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
    Public Function Kiemtra(ByVal dto As Lichdto) As Boolean
        Dim dao As New LichDao
        Return dao.Kiemtra(dto, MSsql)
    End Function
    Public Function Kiemtra(ByVal ma As Integer) As Boolean
        Dim dao As New LichDao
        Return dao.Kiemtra(ma, MSsql)
    End Function
#Region "Xử Lý"
    Public Sub Them(ByVal Dto As Lichdto, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenGhi = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As LichDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New LichDao(ketnoiConnection)
        Else
            Dao = New LichDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.Them(Dto, MSsql)
    End Sub
    Public Sub Xoa(ByVal ma As Integer, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenXoa = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As LichDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New LichDao(ketnoiConnection)
        Else
            Dao = New LichDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.Xoa(ma, MSsql)
    End Sub
    Public Sub sua(ByVal Dto As Lichdto, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenSua = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As LichDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New LichDao(ketnoiConnection)
        Else
            Dao = New LichDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.sua(Dto, MSsql)
    End Sub
#End Region
    Public Function LayBangTable() As DataTable
        Dim Dao As New LichDao(ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangTableSQL(ByVal sql As String) As DataTable
        Dim Dao As New AbstractDao(sql, sql, ketnoi, MSsql)
        Return Dao
    End Function
    Public Sub suaSoCK(ByVal SoCK As Integer, ByVal ma As String)
        Dim dao As New LichDao
        dao.SuaSoCK(SoCK, ma, MSsql)
    End Sub
    Public Sub suaKieuCK(ByVal KieuCK As Integer, ByVal ma As String)
        Dim dao As New LichDao
        dao.SuaKieuCK(KieuCK, ma, MSsql)
    End Sub
    Public Function LayBangTable(ByVal ma As Integer) As DataTable
        Dim Dao As New LichDao(ma, ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangDTo(ByVal ma As Integer) As Lichdto
        Dim Dao As New LichDao(ma, ketnoi, MSsql)
        Dim dto As New Lichdto
        If IsDBNull(Dao.Rows(0)("ID")) = False Then
            dto.ID = Dao.Rows(0)("ID")
        End If
        If IsDBNull(Dao.Rows(0)("Chedo")) = False Then
            dto.Chedo = Dao.Rows(0)("Chedo")
        End If
        If IsDBNull(Dao.Rows(0)("Batdau")) = False Then
            dto.Batdau = Dao.Rows(0)("Batdau")
        End If
        If IsDBNull(Dao.Rows(0)("SoCK")) = False Then
            dto.SoCK = Dao.Rows(0)("SoCK")
        End If
        If IsDBNull(Dao.Rows(0)("KieuCK")) = False Then
            dto.KieuCK = Dao.Rows(0)("KieuCK")
        End If
        Return dto
    End Function
End Class

