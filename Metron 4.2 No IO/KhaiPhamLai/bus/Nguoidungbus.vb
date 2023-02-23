Imports System.Data
Public Class NguoidungBus
    Inherits AbstractBus
    Public Sub New()
        QuyenGhi = ThemND
        QuyenXoa = XoaND
        QuyenSua = SuaND
    End Sub
    Public Sub New(ByVal Connection As OleDb.OleDbConnection, ByVal sqlServer As Boolean)
        ketnoiConnection = Connection
        MSsql = sqlServer
        QuyenGhi = ThemND
        QuyenXoa = XoaND
        QuyenSua = SuaND
    End Sub
    Public Sub New(ByVal Connection As KetNoiDto, ByVal sqlServer As Boolean)
        ketnoi = Connection
        MSsql = sqlServer
        QuyenGhi = ThemND
        QuyenXoa = XoaND
        QuyenSua = SuaND
    End Sub
#Region "Xử Lý"
    Public Sub Them(ByVal Dto As Nguoidungdto, Optional ByVal ChuoiThongBaoLoi As String = "Không có Quyền")
        If QuyenGhi = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As NguoidungDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New NguoidungDao(ketnoiConnection)
        Else
            Dao = New NguoidungDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.Them(Dto, MSsql)
    End Sub
    Public Sub Xoa(ByVal ma As String, Optional ByVal ChuoiThongBaoLoi As String = "Không có Quyền")
        If QuyenXoa = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As NguoidungDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New NguoidungDao(ketnoiConnection)
        Else
            Dao = New NguoidungDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.Xoa(ma, MSsql)
    End Sub
    Public Sub sua(ByVal Dto As Nguoidungdto, Optional ByVal ChuoiThongBaoLoi As String = "Không có Quyền")
        If QuyenSua = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As NguoidungDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New NguoidungDao(ketnoiConnection)
        Else
            Dao = New NguoidungDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.sua(Dto, MSsql)
    End Sub
#End Region
    Public Function kiemtraquyen(ByVal quyen As String) As Integer
        Dim dao As New NguoidungDao
        Return dao.KiemtraQuyen(quyen)
    End Function
    Public Function LayBangTable() As DataTable
        Dim Dao As New NguoidungDao(ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangTableSQL(ByVal sql As String) As DataTable
        Dim Dao As New AbstractDao(sql, sql, ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangTable(ByVal ma As String) As DataTable
        Dim Dao As New NguoidungDao(ma, ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangDTo(ByVal ma As String) As Nguoidungdto
        Dim Dao As New NguoidungDao(ma, ketnoi, MSsql)
        Dim dto As New Nguoidungdto
        If IsDBNull(Dao.Rows(0)("userID")) = False Then
            dto.userID = Dao.Rows(0)("userID")
        End If
        If IsDBNull(Dao.Rows(0)("pass")) = False Then
            dto.pass = Dao.Rows(0)("pass")
        End If
        If IsDBNull(Dao.Rows(0)("Quyen")) = False Then
            dto.Quyen = Dao.Rows(0)("Quyen")
        End If
        If IsDBNull(Dao.Rows(0)("Cauhoi1")) = False Then
            dto.Cauhoi1 = Dao.Rows(0)("Cauhoi1")
        End If
        If IsDBNull(Dao.Rows(0)("Traloi1")) = False Then
            dto.Traloi1 = Dao.Rows(0)("Traloi1")
        End If
        If IsDBNull(Dao.Rows(0)("Cauhoi2")) = False Then
            dto.Cauhoi2 = Dao.Rows(0)("Cauhoi2")
        End If
        If IsDBNull(Dao.Rows(0)("Traloi2")) = False Then
            dto.Traloi2 = Dao.Rows(0)("Traloi2")
        End If
        Return dto
    End Function
End Class

