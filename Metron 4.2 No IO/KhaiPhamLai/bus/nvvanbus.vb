Imports System.Data
Public Class nvvanBus
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
    Public Sub Them(ByVal Dto As nvvandto, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenGhi = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As nvvanDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New nvvanDao(ketnoiConnection)
        Else
            Dao = New nvvanDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.Them(Dto, MSsql)
    End Sub

    Public Sub ThemNoBinary(ByVal Dto As nvvandto, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenGhi = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As nvvanDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New nvvanDao(ketnoiConnection)
        Else
            Dao = New nvvanDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.ThemNoBinary(Dto, MSsql)
    End Sub
    Public Sub Xoa(ByVal ma1 As Integer, ByVal ma2 As Integer, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenXoa = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As nvvanDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New nvvanDao(ketnoiConnection)
        Else
            Dao = New nvvanDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.Xoa(ma1, ma2, MSsql)
    End Sub
    Public Sub Xoa(ByVal ma1 As Integer, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenXoa = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As nvvanDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New nvvanDao(ketnoiConnection)
        Else
            Dao = New nvvanDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.Xoa(ma1, MSsql)
    End Sub
    Public Sub sua(ByVal Dto As nvvandto, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenSua = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As nvvanDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New nvvanDao(ketnoiConnection)
        Else
            Dao = New nvvanDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.sua(Dto, MSsql)
    End Sub
#End Region
    Public Function LayBangTabletheoNVid(ByVal manv As Integer) As DataTable
        Dim sql As String = "select * from nvvan where manv=" & manv
        Dim Dao As New AbstractDao(Sql, Sql, ketnoi, MSsql)
        Return Dao
    End Function

    Public Function LayBangTable() As DataTable
        Dim Dao As New nvvanDao(ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangTableSQL(ByVal sql As String) As DataTable
        Dim Dao As New AbstractDao(sql, sql, ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangTable(ByVal ma As Integer) As DataTable
        Dim Dao As New nvvanDao(ma, ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangTable(ByVal ma1 As Integer, ByVal ma2 As Integer) As DataTable
        Dim Dao As New nvvanDao(ma1, ma2, ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangDTo(ByVal ma1 As Integer, ByVal ma2 As Integer) As nvvandto
        Dim Dao As New nvvanDao(ma1, ma2, ketnoi, MSsql)
        Dim dto As New nvvandto
        If IsDBNull(Dao.Rows(0)("MaNV")) = False Then
            dto.MaNV = Dao.Rows(0)("MaNV")
        End If
        If IsDBNull(Dao.Rows(0)("VanID")) = False Then
            dto.VanID = Dao.Rows(0)("VanID")
        End If
        If IsDBNull(Dao.Rows(0)("ma")) = False Then
            dto.ma = Dao.Rows(0)("ma")
        End If
        Return dto
    End Function
    Public Function LayBangDTo(ByVal dong As Integer, ByVal dao As DataTable) As nvvandto
        Dim dto As New nvvandto
        If IsDBNull(dao.Rows(dong)("MaNV")) = False Then
            dto.MaNV = dao.Rows(dong)("MaNV")
        End If
        If IsDBNull(dao.Rows(dong)("VanID")) = False Then
            dto.VanID = dao.Rows(dong)("VanID")
        End If
        If IsDBNull(dao.Rows(dong)("ma")) = False Then
            dto.ma = dao.Rows(dong)("ma")
        End If
        Return dto
    End Function
End Class

