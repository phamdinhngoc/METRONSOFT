Imports System.Data
Public Class lydoBus
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
    Public Sub Them(ByVal Dto As lydodto, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenGhi = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As lydoDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New lydoDao(ketnoiConnection)
        Else
            Dao = New lydoDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.Them(Dto, MSsql)
    End Sub
    Public Sub Xoa(ByVal ma As Integer, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenXoa = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As lydoDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New lydoDao(ketnoiConnection)
        Else
            Dao = New lydoDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.Xoa(ma, MSsql)
    End Sub
    Public Sub sua(ByVal Dto As lydodto, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenSua = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As lydoDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New lydoDao(ketnoiConnection)
        Else
            Dao = New lydoDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.sua(Dto, MSsql)
    End Sub
#End Region
    Public Function LayBangTable() As DataTable
        Dim Dao As New lydoDao(ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangTableSQL(ByVal sql As String) As DataTable
        Dim Dao As New AbstractDao(sql, sql, ketnoi, MSsql)
        Return Dao
    End Function
    Public Sub suaNgayQD(ByVal NgayQD As Integer, ByVal ma As String)
        Dim dao As New lydoDao
        dao.SuaNgayQD(NgayQD, ma, MSsql)
    End Sub
    Public Sub suaSoCong(ByVal SoCong As Integer, ByVal ma As String)
        Dim dao As New lydoDao
        dao.SuaSoCong(SoCong, ma, MSsql)
    End Sub
    Public Function LayBangTable(ByVal ma As Integer) As DataTable
        Dim Dao As New lydoDao(ma, ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangDTo(ByVal ma As Integer) As lydodto
        Dim Dao As New lydoDao(ma, ketnoi, MSsql)
        Dim dto As New lydodto
        If IsDBNull(Dao.Rows(0)("IDLD")) = False Then
            dto.IDLD = Dao.Rows(0)("IDLD")
        End If
        If IsDBNull(Dao.Rows(0)("Lydo")) = False Then
            dto.Lydo = Dao.Rows(0)("Lydo")
        End If
        If IsDBNull(Dao.Rows(0)("NgayQD")) = False Then
            dto.NgayQD = Dao.Rows(0)("NgayQD")
        End If
        If IsDBNull(Dao.Rows(0)("SoCong")) = False Then
            dto.SoCong = Dao.Rows(0)("SoCong")
        End If
        Return dto
    End Function
    Public Function LayBangDTo(ByVal dong As Integer, ByVal dao As DataTable) As lydodto
        Dim dto As New lydodto
        If IsDBNull(dao.Rows(dong)("IDLD")) = False Then
            dto.IDLD = dao.Rows(dong)("IDLD")
        End If
        If IsDBNull(dao.Rows(dong)("Lydo")) = False Then
            dto.Lydo = dao.Rows(dong)("Lydo")
        End If
        If IsDBNull(dao.Rows(dong)("NgayQD")) = False Then
            dto.NgayQD = dao.Rows(dong)("NgayQD")
        End If
        If IsDBNull(dao.Rows(dong)("SoCong")) = False Then
            dto.SoCong = dao.Rows(dong)("SoCong")
        End If
        Return dto
    End Function
End Class

