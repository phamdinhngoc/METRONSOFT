Imports System.Data
Public Class TienAnTangCabus
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
    Public Sub Them(ByVal Dto As TienAnTangCadto, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenGhi = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As TienAnTangCadao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New TienAnTangCadao(ketnoiConnection)
        Else
            Dao = New TienAnTangCadao(ketnoi.ChuoiKetNoi)
        End If
        Dao.Them(Dto, MSsql)
    End Sub
    Public Sub Xoa(ByVal ma As Integer, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenXoa = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As TienAnTangCadao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New TienAnTangCadao(ketnoiConnection)
        Else
            Dao = New TienAnTangCadao(ketnoi.ChuoiKetNoi)
        End If
        Dao.Xoa(ma, MSsql)
    End Sub

    Public Sub XoaAll(Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenXoa = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As TienAnTangCadao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New TienAnTangCadao(ketnoiConnection)
        Else
            Dao = New TienAnTangCadao(ketnoi.ChuoiKetNoi)
        End If
        Dao.XoaAll(MSsql)
    End Sub


   

    Public Sub sua(ByVal Dto As TienAnTangCadto, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenSua = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As TienAnTangCadao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New TienAnTangCadao(ketnoiConnection)
        Else
            Dao = New TienAnTangCadao(ketnoi.ChuoiKetNoi)
        End If
        Dao.sua(Dto, MSsql)
    End Sub
#End Region
    Public Function LayBangTable() As DataTable
        Dim Dao As New TienAnTangCadao(ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangArrayList() As IList
        Dim Dao As New TienAnTangCadao(ketnoi, MSsql)
        Dim array As New ArrayList
        For i As Integer = 0 To Dao.Rows.Count - 1
            Dim ca As New TienAnTangCadto
            ca = Me.LayBangDTo(i, Dao)
            array.Add(ca)
        Next
        Return array
    End Function
    Public Function LayBangTableSQL(ByVal sql As String) As DataTable
        Dim Dao As New AbstractDao(sql, sql, ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangTable(ByVal ma As Integer) As DataTable
        Dim Dao As New TienAnTangCadao(ma, ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangDTo(ByVal ma As Integer) As TienAnTangCadto
        Dim Dao As New TienAnTangCadao(ma, ketnoi, MSsql)
        Dim dto As New TienAnTangCadto
        If IsDBNull(Dao.Rows(0)("ID")) = False Then
            dto.ID = Dao.Rows(0)("ID")
        End If
        If IsDBNull(Dao.Rows(0)("GioTC")) = False Then
            dto.GioTC = Dao.Rows(0)("GioTC")
        End If
        If IsDBNull(Dao.Rows(0)("TienAnTC")) = False Then
            dto.TienAnTC = Dao.Rows(0)("TienAnTC")
        End If
        
        Return dto
    End Function
    Public Function LayBangDTo(ByVal dong As Integer, ByVal dao As DataTable) As TienAnTangCadto
        Dim dto As New TienAnTangCadto
        If IsDBNull(dao.Rows(dong)("ID")) = False Then
            dto.ID = dao.Rows(dong)("ID")
        End If
        If IsDBNull(dao.Rows(dong)("GioTC")) = False Then
            dto.GioTC = dao.Rows(dong)("GioTC")
        End If
        If IsDBNull(dao.Rows(dong)("TienAnTC")) = False Then
            dto.TienAnTC = dao.Rows(dong)("TienAnTC")
        End If
        
        Return dto
    End Function
End Class
