Imports System.Data

Public Class thamsoBus
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
    Public Sub Them(ByVal Dto As thamsodto, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenGhi = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As thamsoDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New thamsoDao(ketnoiConnection)
        Else
            Dao = New thamsoDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.Them(Dto, MSsql)
    End Sub
    Public Sub Xoa(ByVal ma As Integer, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenXoa = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As thamsoDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New thamsoDao(ketnoiConnection)
        Else
            Dao = New thamsoDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.Xoa(ma, MSsql)
    End Sub
    Public Sub sua(ByVal Dto As thamsodto, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenSua = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As thamsoDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New thamsoDao(ketnoiConnection)
        Else
            Dao = New thamsoDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.sua(Dto, MSsql)
    End Sub
#End Region
    Public Function LayBangTable() As DataTable
        Dim Dao As New thamsoDao(ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangTableSQL(ByVal sql As String) As DataTable
        Dim Dao As New AbstractDao(sql, sql, ketnoi, MSsql)
        Return Dao
    End Function
    Public Sub suaMaso(ByVal Maso As Integer, ByVal ma As String)
        Dim dao As New thamsoDao
        dao.SuaMaso(Maso, ma, MSsql)
    End Sub
    Public Sub suaMaso1(ByVal Maso1 As Integer, ByVal ma As String)
        Dim dao As New thamsoDao
        dao.SuaMaso1(Maso1, ma, MSsql)
    End Sub
    Public Sub suaMaso2(ByVal Maso2 As Integer, ByVal ma As String)
        Dim dao As New thamsoDao
        dao.SuaMaso2(Maso2, ma, MSsql)
    End Sub
    Public Sub suaMaso3(ByVal Maso3 As Integer, ByVal ma As String)
        Dim dao As New thamsoDao
        dao.SuaMaso3(Maso3, ma, MSsql)
    End Sub
    Public Function LayBangTable(ByVal ma As Integer) As DataTable
        Dim Dao As New thamsoDao(ma, ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangDTo(ByVal ma As Integer) As thamsodto
        Dim Dao As New thamsoDao(ma, ketnoi, MSsql)
        Dim dto As New thamsodto
        If Dao.Rows.Count <= 0 Then Return dto
        If IsDBNull(Dao.Rows(0)("id")) = False Then
            dto.id = Dao.Rows(0)("id")
        End If
        If IsDBNull(Dao.Rows(0)("Tenthamso")) = False Then
            dto.Tenthamso = Dao.Rows(0)("Tenthamso")
        End If
        If IsDBNull(Dao.Rows(0)("Maso")) = False Then
            dto.Maso = Dao.Rows(0)("Maso")
        End If
        If IsDBNull(Dao.Rows(0)("Maso1")) = False Then
            dto.Maso1 = Dao.Rows(0)("Maso1")
        End If
        If IsDBNull(Dao.Rows(0)("Maso2")) = False Then
            dto.Maso2 = Dao.Rows(0)("Maso2")
        End If
        If IsDBNull(Dao.Rows(0)("Maso3")) = False Then
            dto.Maso3 = Dao.Rows(0)("Maso3")
        End If
        If IsDBNull(Dao.Rows(0)("GhiChu")) = False Then
            dto.GhiChu = Dao.Rows(0)("GhiChu")
        End If
        Return dto
    End Function
    Public Function LayBangDTo(ByVal dong As Integer, ByVal dao As DataTable) As thamsodto
        Dim dto As New thamsodto
        If dao.Rows.Count <= 0 Then Return dto
        If IsDBNull(dao.Rows(dong)("id")) = False Then
            dto.id = dao.Rows(dong)("id")
        End If
        If IsDBNull(dao.Rows(dong)("Tenthamso")) = False Then
            dto.Tenthamso = dao.Rows(dong)("Tenthamso")
        End If
        If IsDBNull(dao.Rows(dong)("Maso")) = False Then
            dto.Maso = dao.Rows(dong)("Maso")
        End If
        If IsDBNull(dao.Rows(dong)("Maso1")) = False Then
            dto.Maso1 = dao.Rows(dong)("Maso1")
        End If
        If IsDBNull(dao.Rows(dong)("Maso2")) = False Then
            dto.Maso2 = dao.Rows(dong)("Maso2")
        End If
        If IsDBNull(dao.Rows(dong)("Maso3")) = False Then
            dto.Maso3 = dao.Rows(dong)("Maso3")
        End If
        If IsDBNull(dao.Rows(dong)("GhiChu")) = False Then
            dto.GhiChu = dao.Rows(dong)("GhiChu")
        End If
        Return dto
    End Function
End Class

