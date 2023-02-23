Imports System.Data
Public Class PhucapluongBus
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
    Public Sub Them(ByVal Dto As Phucapluongdto, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenGhi = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As PhuCapLuongDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New PhuCapLuongDao(ketnoiConnection)
        Else
            Dao = New PhuCapLuongDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.Them(Dto, MSsql)
    End Sub
    Public Sub Xoa(ByVal ma As Integer, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenXoa = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As PhuCapLuongDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New PhuCapLuongDao(ketnoiConnection)
        Else
            Dao = New PhuCapLuongDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.Xoa(ma, MSsql)
    End Sub

    Public Sub XoaAll(Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenXoa = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As PhuCapLuongDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New PhuCapLuongDao(ketnoiConnection)
        Else
            Dao = New PhuCapLuongDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.XoaAll(MSsql)
    End Sub

    Public Sub sua(ByVal Dto As Phucapluongdto, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenSua = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As PhuCapLuongDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New PhuCapLuongDao(ketnoiConnection)
        Else
            Dao = New PhuCapLuongDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.sua(Dto, MSsql)
    End Sub
#End Region
    Public Function LayBangTable() As DataTable
        Dim Dao As New PhuCapLuongDao(ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangArrayList() As IList
        Dim Dao As New PhuCapLuongDao(ketnoi, MSsql)
        Dim array As New ArrayList
        For i As Integer = 0 To Dao.Rows.Count - 1
            Dim phucapdto As New Phucapluongdto
            phucapdto = Me.LayBangDTo(i, Dao)
            array.Add(phucapdto)
        Next
        Return array
    End Function
    Public Function LayBangTableSQL(ByVal sql As String) As DataTable
        Dim Dao As New AbstractDao(sql, sql, ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangDTo(ByVal ma As Integer) As Phucapluongdto
        Dim Dao As New PhuCapLuongDao(ma, ketnoi, MSsql)
        Dim dto As New Phucapluongdto
        If IsDBNull(Dao.Rows(0)("ID")) = False Then
            dto.ID = Dao.Rows(0)("ID")
        End If
       
        If IsDBNull(Dao.Rows(0)("TienComTrua")) = False Then
            dto.TienComTrua = Dao.Rows(0)("TienComTrua")
        End If
        If IsDBNull(Dao.Rows(0)("TienXe")) = False Then
            dto.TienXe = Dao.Rows(0)("TienXe")
        End If
        If IsDBNull(Dao.Rows(0)("TienAnTC1")) = False Then
            dto.TienAnTC1 = Dao.Rows(0)("TienAnTC1")
        End If
        If IsDBNull(Dao.Rows(0)("TienAnTC2")) = False Then
            dto.TienAnTC2 = Dao.Rows(0)("TienAnTC2")
        End If
        Return dto
    End Function
    Public Function LayBangDTo(ByVal dong As Integer, ByVal dao As DataTable) As Phucapluongdto
        Dim dto As New Phucapluongdto
        If IsDBNull(dao.Rows(dong)("ID")) = False Then
            dto.ID = dao.Rows(dong)("ID")
        End If
       
        If IsDBNull(dao.Rows(dong)("TienComTrua")) = False Then
            dto.TienComTrua = dao.Rows(dong)("TienComTrua")
        End If
        If IsDBNull(dao.Rows(dong)("TienXe")) = False Then
            dto.TienXe = dao.Rows(dong)("TienXe")
        End If
        If IsDBNull(dao.Rows(dong)("TienAnTC1")) = False Then
            dto.TienAnTC1 = dao.Rows(dong)("TienAnTC1")
        End If
        If IsDBNull(dao.Rows(dong)("TienAnTC2")) = False Then
            dto.TienAnTC2 = dao.Rows(dong)("TienAnTC2")
        End If
        Return dto
    End Function
End Class
