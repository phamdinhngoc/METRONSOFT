Imports System.Data
Public Class lichnvBus
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
    Public Sub Them(ByVal Dto As lichnvdto, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenGhi = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As lichnvDao
        If ketnoi.ChuoiKetNoi = " Then" Then
            Dao = New lichnvDao(ketnoiConnection)
        Else
            Dao = New lichnvDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.Them(Dto, MSsql)
    End Sub
    Public Sub Xoa(ByVal ma As Integer, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenXoa = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As lichnvDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New lichnvDao(ketnoiConnection)
        Else
            Dao = New lichnvDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.Xoa(ma, MSsql)
    End Sub
    Public Sub Xoanvid(ByVal ma As Integer, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenXoa = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As lichnvDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New lichnvDao(ketnoiConnection)
        Else
            Dao = New lichnvDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.XoaNvid(ma, MSsql)
    End Sub
    Public Sub sua(ByVal Dto As lichnvdto, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenSua = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As lichnvDao
        If ketnoi.ChuoiKetNoi = " Then" Then
            Dao = New lichnvDao(ketnoiConnection)
        Else
            Dao = New lichnvDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.sua(Dto, MSsql)
    End Sub
#End Region
    Public Function LayBangDTotheoLichID(ByVal LichID As String) As lichnvdto
        Dim sql As String = "select * from lichnv where lichid=" & LichID
        Dim dao As New AbstractDao("", sql, ketnoi, MSsql)
        Dim dto As New lichnvdto
        If dao.Rows.Count > 0 Then
            If IsDBNull(dao.Rows(0)("ID")) = False Then
                dto.ID = dao.Rows(0)("ID")
            End If
            If IsDBNull(dao.Rows(0)("NVID")) = False Then
                dto.NVID = dao.Rows(0)("NVID")
            End If
            If IsDBNull(dao.Rows(0)("Sngay")) = False Then
                dto.Sngay = dao.Rows(0)("Sngay")
            End If
            If IsDBNull(dao.Rows(0)("LichID")) = False Then
                dto.LichID = dao.Rows(0)("LichID")
            End If
            If IsDBNull(dao.Rows(0)("Engay")) = False Then
                dto.Engay = dao.Rows(0)("Engay")
            End If
            If IsDBNull(dao.Rows(0)("Chay")) = False Then
                dto.Chay = dao.Rows(0)("Chay")
            End If
            If IsDBNull(dao.Rows(0)("Tangca")) = False Then
                dto.Tangca = dao.Rows(0)("Tangca")
            End If
            If IsDBNull(dao.Rows(0)("TangCaS")) = False Then
                dto.TangCaS = dao.Rows(0)("TangCaS")
            End If
            If IsDBNull(dao.Rows(0)("GHTangC")) = False Then
                dto.GHTangC = dao.Rows(0)("GHTangC")
            End If
        End If
        Return dto
    End Function
    Public Function LayBangDTotheoManv(ByVal manv As String) As lichnvdto
        Dim sql As String = "select * from lichnv where nvid=" & manv
        Dim dao As New AbstractDao("", sql, ketnoi, MSsql)
        Dim dto As New lichnvdto
        If dao.Rows.Count > 0 Then
            If IsDBNull(dao.Rows(0)("ID")) = False Then
                dto.ID = dao.Rows(0)("ID")
            End If
            If IsDBNull(dao.Rows(0)("NVID")) = False Then
                dto.NVID = dao.Rows(0)("NVID")
            End If
            If IsDBNull(dao.Rows(0)("Sngay")) = False Then
                dto.Sngay = dao.Rows(0)("Sngay")
            End If
            If IsDBNull(dao.Rows(0)("LichID")) = False Then
                dto.LichID = dao.Rows(0)("LichID")
            End If
            If IsDBNull(dao.Rows(0)("Engay")) = False Then
                dto.Engay = dao.Rows(0)("Engay")
            End If
            If IsDBNull(dao.Rows(0)("Chay")) = False Then
                dto.Chay = dao.Rows(0)("Chay")
            End If
            If IsDBNull(dao.Rows(0)("Tangca")) = False Then
                dto.Tangca = dao.Rows(0)("Tangca")
            End If
            If IsDBNull(dao.Rows(0)("TangCaS")) = False Then
                dto.TangCaS = dao.Rows(0)("TangCaS")
            End If
            If IsDBNull(dao.Rows(0)("GHTangC")) = False Then
                dto.GHTangC = dao.Rows(0)("GHTangC")
            End If
        End If
        Return dto
    End Function
    Public Function LayBangTable() As DataTable
        Dim Dao As New lichnvDao(ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangTableSQL(ByVal sql As String) As DataTable
        Dim Dao As New AbstractDao(sql, sql, ketnoi, MSsql)
        Return Dao
    End Function
    Public Sub suaNVID(ByVal NVID As Integer, ByVal ma As String)
        Dim dao As New lichnvDao
        dao.SuaNVID(NVID, ma, MSsql)
    End Sub
    Public Sub suaLichID(ByVal LichID As Integer, ByVal ma As String)
        Dim dao As New lichnvDao
        dao.SuaLichID(LichID, ma, MSsql)
    End Sub
    Public Sub suaChay(ByVal Chay As Integer, ByVal ma As String)
        Dim dao As New lichnvDao
        dao.SuaChay(Chay, ma, MSsql)
    End Sub
    Public Sub suaTangCaS(ByVal TangCaS As Integer, ByVal ma As String)
        Dim dao As New lichnvDao
        dao.SuaTangCaS(TangCaS, ma, MSsql)
    End Sub
    Public Sub suaGHTangC(ByVal GHTangC As Integer, ByVal ma As String)
        Dim dao As New lichnvDao
        dao.SuaGHTangC(GHTangC, ma, MSsql)
    End Sub
    Public Function LayBangTable(ByVal ma As Integer) As DataTable
        Dim Dao As New lichnvDao(ma, ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangDTo(ByVal ma As Integer) As lichnvdto
        Dim Dao As New lichnvDao(ma, ketnoi, MSsql)
        Dim dto As New lichnvdto
        If IsDBNull(Dao.Rows(0)("ID")) = False Then
            dto.ID = Dao.Rows(0)("ID")
        End If
        If IsDBNull(Dao.Rows(0)("NVID")) = False Then
            dto.NVID = Dao.Rows(0)("NVID")
        End If
        If IsDBNull(Dao.Rows(0)("Sngay")) = False Then
            dto.Sngay = Dao.Rows(0)("Sngay")
        End If
        If IsDBNull(Dao.Rows(0)("LichID")) = False Then
            dto.LichID = Dao.Rows(0)("LichID")
        End If
        If IsDBNull(Dao.Rows(0)("Engay")) = False Then
            dto.Engay = Dao.Rows(0)("Engay")
        End If
        If IsDBNull(Dao.Rows(0)("Chay")) = False Then
            dto.Chay = Dao.Rows(0)("Chay")
        End If
        If IsDBNull(Dao.Rows(0)("Tangca")) = False Then
            dto.Tangca = Dao.Rows(0)("Tangca")
        End If
        If IsDBNull(Dao.Rows(0)("TangCaS")) = False Then
            dto.TangCaS = Dao.Rows(0)("TangCaS")
        End If
        If IsDBNull(Dao.Rows(0)("GHTangC")) = False Then
            dto.GHTangC = Dao.Rows(0)("GHTangC")
        End If
        Return dto
    End Function
End Class

