Imports System.Data
Public Class donviBus
    Inherits AbstractBus
    Public Sub New()
        QuyenGhi = ThemDV
        QuyenXoa = XoaDV
        QuyenSua = SuaDV
    End Sub
    Public Sub New(ByVal Connection As OleDb.OleDbConnection, ByVal sqlServer As Boolean)
        ketnoiConnection = Connection
        MSsql = sqlServer
        QuyenGhi = ThemDV
        QuyenXoa = XoaDV
        QuyenSua = SuaDV
    End Sub
    Public Sub New(ByVal Connection As KetNoiDto, ByVal sqlServer As Boolean)
        ketnoi = Connection
        MSsql = sqlServer
        QuyenGhi = ThemDV
        QuyenXoa = XoaDV
        QuyenSua = SuaDV
    End Sub
#Region "Xử Lý"
    Public Sub Them(ByVal Dto As donvidto, Optional ByVal ChuoiThongBaoLoi As String = "Không có Quyền")
        If QuyenGhi = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As donviDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New donviDao(ketnoiConnection)
        Else
            Dao = New donviDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.Them(Dto, MSsql)
    End Sub
    Public Sub Xoa(ByVal ma As Integer, Optional ByVal ChuoiThongBaoLoi As String = "Không có quyền")
        If QuyenXoa = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As donviDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New donviDao(ketnoiConnection)
        Else
            Dao = New donviDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.Xoa(ma, MSsql)
    End Sub
    Public Sub sua(ByVal Dto As donvidto, Optional ByVal ChuoiThongBaoLoi As String = "Không có Quyền")
        If QuyenSua = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As donviDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New donviDao(ketnoiConnection)
        Else
            Dao = New donviDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.sua(Dto, MSsql)
    End Sub
#End Region
    Public Function LayBangTable() As DataTable
        Dim Dao As New donviDao(ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangTableTheoNhanh(ByVal nhanh As Integer) As DataTable
        Dim Dao As New AbstractDao("", "select * from donvi where nhanh=" & nhanh & " ORDER BY TENDV", ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangTableSQL(ByVal sql As String) As DataTable
        Dim Dao As New AbstractDao(sql, sql, ketnoi, MSsql)
        Return Dao
    End Function
    Public Sub suaNhanh(ByVal Nhanh As Integer, ByVal ma As String)
        Dim dao As New donviDao
        dao.SuaNhanh(Nhanh, ma, MSsql)
    End Sub
    Public Function LayBangTable(ByVal ma As Integer) As DataTable
        Dim Dao As New donviDao(ma, ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangDTo(ByVal ma As Integer) As donvidto
        Dim Dao As New donviDao(ma, ketnoi, MSsql)
        Dim dto As New donvidto
        If IsDBNull(Dao.Rows(0)("MaDV")) = False Then
            dto.MaDV = Dao.Rows(0)("MaDV")
        End If
        If IsDBNull(Dao.Rows(0)("TenDV")) = False Then
            dto.TenDV = Dao.Rows(0)("TenDV")
        End If
        If IsDBNull(Dao.Rows(0)("Nhanh")) = False Then
            dto.Nhanh = Dao.Rows(0)("Nhanh")
        End If
        Return dto
    End Function
End Class

