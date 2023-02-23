Imports System.Data
Public Class NgayleBus
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
    Public Sub Them(ByVal Dto As Ngayledto, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenGhi = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As NgayleDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New NgayleDao(ketnoiConnection)
        Else
            Dao = New NgayleDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.Them(Dto, MSsql)
    End Sub
    Public Sub Xoa(ByVal ma As String, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenXoa = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As NgayleDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New NgayleDao(ketnoiConnection)
        Else
            Dao = New NgayleDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.Xoa(ma, MSsql)
    End Sub
    Public Sub sua(ByVal Dto As Ngayledto, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenSua = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As NgayleDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New NgayleDao(ketnoiConnection)
        Else
            Dao = New NgayleDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.sua(Dto, MSsql)
    End Sub
#End Region
    Public Function LayBangTable() As DataTable
        Dim Dao As New NgayleDao(ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangTable(ByVal tungay As Date, ByVal denngay As Date) As DataTable
        Dim Dao As New NgayleDao()
        Dao.laybang(tungay, denngay, MSsql)
        Return Dao
    End Function
    Public Function LayBangTableSQL(ByVal sql As String) As DataTable
        Dim Dao As New AbstractDao(sql, sql, ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangTable(ByVal ma As String) As DataTable
        Dim Dao As New NgayleDao(ma, ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangDTo(ByVal ngay As String) As Ngayledto
        Dim Dao As New NgayleDao
        Dao.laybang(Convert.ToDateTime(ngay), MSsql)
        Dim dto As New Ngayledto
        If Dao.Rows.Count <= 0 Then Return dto
        If IsDBNull(Dao.Rows(0)("Ngay")) = False Then
            dto.Ngay = Dao.Rows(0)("Ngay")
        End If
        If IsDBNull(Dao.Rows(0)("ChuThich")) = False Then
            dto.ChuThich = Dao.Rows(0)("ChuThich")
        End If
        Return dto
    End Function
    Public Function LayBangDTo(ByVal dong As Integer, ByVal dao As DataTable) As Ngayledto
        Dim dto As New Ngayledto
        If IsDBNull(dao.Rows(dong)("Ngay")) = False Then
            dto.Ngay = dao.Rows(dong)("Ngay")
        End If
        If IsDBNull(dao.Rows(dong)("ChuThich")) = False Then
            dto.ChuThich = dao.Rows(dong)("ChuThich")
        End If
        Return dto
    End Function
End Class

