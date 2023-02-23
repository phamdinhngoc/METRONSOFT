Imports System.Data
Public Class MayBus
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
    Public Sub Them(ByVal Dto As Maydto, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenGhi = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As MayDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New MayDao(ketnoiConnection)
        Else
            Dao = New MayDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.Them(Dto, MSsql)
    End Sub
    Public Sub Xoa(ByVal ma As Integer, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenXoa = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As MayDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New MayDao(ketnoiConnection)
        Else
            Dao = New MayDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.Xoa(ma, MSsql)
    End Sub
    Public Sub sua(ByVal Dto As Maydto, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenSua = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As MayDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New MayDao(ketnoiConnection)
        Else
            Dao = New MayDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.sua(Dto, MSsql)
    End Sub
#End Region
    Public Function LayBangTable() As DataTable
        Dim Dao As New MayDao(ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangTableSQL(ByVal sql As String) As DataTable
        Dim Dao As New AbstractDao(sql, sql, ketnoi, MSsql)
        Return Dao
    End Function
    Public Sub suaMaySO(ByVal MaySO As Integer, ByVal ma As String)
        Dim dao As New MayDao
        dao.SuaMaySO(MaySO, ma, MSsql)
    End Sub
    Public Sub suaLoaimay(ByVal Loaimay As Integer, ByVal ma As String)
        Dim dao As New MayDao
        dao.SuaLoaimay(Loaimay, ma, MSsql)
    End Sub
    Public Sub suaKieu(ByVal Kieu As Integer, ByVal ma As String)
        Dim dao As New MayDao
        dao.SuaKieu(Kieu, ma, MSsql)
    End Sub
    Public Sub suaCong(ByVal Cong As Integer, ByVal ma As String)
        Dim dao As New MayDao
        dao.SuaCong(Cong, ma, MSsql)
    End Sub
    Public Sub suaRate(ByVal Rate As Integer, ByVal ma As String)
        Dim dao As New MayDao
        dao.SuaRate(Rate, ma, MSsql)
    End Sub
    Public Function LayBangTable(ByVal ma As Integer) As DataTable
        Dim Dao As New MayDao(ma, ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangDTo(ByVal dong As Integer, ByVal dao As DataTable) As Maydto
        Dim dto As New Maydto
        If IsDBNull(dao.Rows(dong)("ID")) = False Then
            dto.ID = dao.Rows(dong)("ID")
        End If
        If IsDBNull(dao.Rows(dong)("MaySO")) = False Then
            dto.MaySO = dao.Rows(dong)("MaySO")
        End If
        If IsDBNull(dao.Rows(dong)("Loaimay")) = False Then
            dto.Loaimay = dao.Rows(dong)("Loaimay")
        End If
        If IsDBNull(dao.Rows(dong)("Pass")) = False Then
            dto.Pass = dao.Rows(dong)("Pass")
        End If
        If IsDBNull(dao.Rows(dong)("Tenmay")) = False Then
            dto.Tenmay = dao.Rows(dong)("Tenmay")
        End If
        If IsDBNull(dao.Rows(dong)("Vtri")) = False Then
            dto.Vtri = dao.Rows(dong)("Vtri")
        End If
        If IsDBNull(dao.Rows(dong)("Kieu")) = False Then
            dto.Kieu = dao.Rows(dong)("Kieu")
        End If
        If IsDBNull(dao.Rows(dong)("IP")) = False Then
            dto.IP = dao.Rows(dong)("IP")
        End If
        If IsDBNull(dao.Rows(dong)("Cong")) = False Then
            dto.Cong = dao.Rows(dong)("Cong")
        End If
        If IsDBNull(dao.Rows(dong)("Rate")) = False Then
            dto.Rate = dao.Rows(dong)("Rate")
        End If
        Return dto
    End Function
    Public Function LayBangDTo(ByVal ma As Integer) As Maydto
        Dim Dao As New MayDao(ma, ketnoi, MSsql)
        Dim dto As New Maydto
        If IsDBNull(Dao.Rows(0)("ID")) = False Then
            dto.ID = Dao.Rows(0)("ID")
        End If
        If IsDBNull(Dao.Rows(0)("MaySO")) = False Then
            dto.MaySO = Dao.Rows(0)("MaySO")
        End If
        If IsDBNull(Dao.Rows(0)("Loaimay")) = False Then
            dto.Loaimay = Dao.Rows(0)("Loaimay")
        End If
        If IsDBNull(Dao.Rows(0)("Pass")) = False Then
            dto.Pass = Dao.Rows(0)("Pass")
        End If
        If IsDBNull(Dao.Rows(0)("Tenmay")) = False Then
            dto.Tenmay = Dao.Rows(0)("Tenmay")
        End If
        If IsDBNull(Dao.Rows(0)("Vtri")) = False Then
            dto.Vtri = Dao.Rows(0)("Vtri")
        End If
        If IsDBNull(Dao.Rows(0)("Kieu")) = False Then
            dto.Kieu = Dao.Rows(0)("Kieu")
        End If
        If IsDBNull(Dao.Rows(0)("IP")) = False Then
            dto.IP = Dao.Rows(0)("IP")
        End If
        If IsDBNull(Dao.Rows(0)("Cong")) = False Then
            dto.Cong = Dao.Rows(0)("Cong")
        End If
        If IsDBNull(Dao.Rows(0)("Rate")) = False Then
            dto.Rate = Dao.Rows(0)("Rate")
        End If
        Return dto
    End Function
End Class

