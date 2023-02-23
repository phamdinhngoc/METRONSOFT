Imports System.Data
Public Class caBus
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
    Public Sub Them(ByRef Dto As cadto, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenGhi = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As caDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New caDao(ketnoiConnection)
        Else
            Dao = New caDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.Them(Dto, MSsql)
    End Sub
    Public Sub Xoa(ByVal ma As Integer, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenXoa = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As caDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New caDao(ketnoiConnection)
        Else
            Dao = New caDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.Xoa(ma, MSsql)
    End Sub
    Public Sub sua(ByVal Dto As cadto, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenSua = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As caDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New caDao(ketnoiConnection)
        Else
            Dao = New caDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.sua(Dto, MSsql)
    End Sub
#End Region
    Public Function LayBangTable() As DataTable
        Dim Dao As New caDao(ketnoi, MSsql)
        Dim ca As New cadto
        Return Dao
    End Function
    Public Function LayBangArraylist() As IList
        Dim Dao As New caDao(ketnoi, MSsql)
        Dim array As New ArrayList
        For i As Integer = 0 To Dao.Rows.Count - 1
            Dim ca As New cadto
            ca = Me.LayBangDTo(i, Dao)
            array.Add(ca)
        Next
        Return Array
    End Function
    Public Function LayBangTableKHONGTHUOCcaTuDong(ByVal nvID As Integer) As DataTable
        Dim sql As String = "select * from ca where id not in (select caid from caTD where manv= " & nvID & ")"
        Dim Dao As New AbstractDao(sql, sql, ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangTableSQL(ByVal sql As String) As DataTable
        Dim Dao As New AbstractDao(sql, sql, ketnoi, MSsql)
        Return Dao
    End Function
    Public Sub suasom(ByVal som As Integer, ByVal ma As String)
        Dim dao As New caDao
        dao.Suasom(som, ma, MSsql)
    End Sub
    Public Sub suatre(ByVal tre As Integer, ByVal ma As String)
        Dim dao As New caDao
        dao.Suatre(tre, ma, MSsql)
    End Sub
    Public Sub suangaycong(ByVal ngaycong As Integer, ByVal ma As String)
        Dim dao As New caDao
        dao.Suangaycong(ngaycong, ma, MSsql)
    End Sub
    Public Sub suaSophut(ByVal Sophut As Integer, ByVal ma As String)
        Dim dao As New caDao
        dao.SuaSophut(Sophut, ma, MSsql)
    End Sub
    Public Sub suamau(ByVal mau As Integer, ByVal ma As String)
        Dim dao As New caDao
        dao.Suamau(mau, ma, MSsql)
    End Sub
    Public Sub suaCacon(ByVal Cacon As Integer, ByVal ma As String)
        Dim dao As New caDao
        dao.SuaCacon(Cacon, ma, MSsql)
    End Sub
    Public Function LayBangTable(ByVal ma As Integer) As DataTable
        Dim Dao As New caDao(ma, ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangDTo(ByVal dong As Integer, ByVal dao As DataTable) As cadto

        Dim dto As New cadto
        If dao.Rows.Count <= 0 Then Return dto

        If IsDBNull(dao.Rows(dong)("ID")) = False Then
            dto.ID = dao.Rows(dong)("ID")
        End If
        If IsDBNull(dao.Rows(dong)("Tenca")) = False Then
            dto.Tenca = dao.Rows(dong)("Tenca")
        End If
        If IsDBNull(dao.Rows(dong)("batdau")) = False Then
            dto.batdau = dao.Rows(dong)("batdau")
        End If
        If IsDBNull(dao.Rows(dong)("kethuc")) = False Then
            dto.kethuc = dao.Rows(dong)("kethuc")
        End If
        If IsDBNull(dao.Rows(dong)("som")) = False Then
            dto.som = dao.Rows(dong)("som")
        End If
        If IsDBNull(dao.Rows(dong)("tre")) = False Then
            dto.tre = dao.Rows(dong)("tre")
        End If
        If IsDBNull(dao.Rows(dong)("tgvao1")) = False Then
            dto.tgvao1 = dao.Rows(dong)("tgvao1")
        End If
        If IsDBNull(dao.Rows(dong)("tgvao2")) = False Then
            dto.tgvao2 = dao.Rows(dong)("tgvao2")
        End If
        If IsDBNull(dao.Rows(dong)("tgra1")) = False Then
            dto.tgra1 = dao.Rows(dong)("tgra1")
        End If
        If IsDBNull(dao.Rows(dong)("tgra2")) = False Then
            dto.tgra2 = dao.Rows(dong)("tgra2")
        End If
        If IsDBNull(dao.Rows(dong)("ngaycong")) = False Then
            dto.ngaycong = dao.Rows(dong)("ngaycong")
        End If
        If IsDBNull(dao.Rows(dong)("Sophut")) = False Then
            dto.Sophut = dao.Rows(dong)("Sophut")
        End If
        If IsDBNull(dao.Rows(dong)("mau")) = False Then
            dto.mau = dao.Rows(dong)("mau")
        End If
        If IsDBNull(dao.Rows(dong)("Cacon")) = False Then
            dto.Cacon = dao.Rows(dong)("Cacon")
        End If
        Return dto
    End Function
    Public Function LayBangDTo(ByVal ma As Integer) As cadto
        Dim Dao As New caDao(ma, ketnoi, MSsql)
        Dim dto As New cadto

        If Dao.Rows.Count <= 0 Then Return dto

        If IsDBNull(Dao.Rows(0)("ID")) = False Then
            dto.ID = Dao.Rows(0)("ID")
        End If
        If IsDBNull(Dao.Rows(0)("Tenca")) = False Then
            dto.Tenca = Dao.Rows(0)("Tenca")
        End If
        If IsDBNull(Dao.Rows(0)("batdau")) = False Then
            dto.batdau = Dao.Rows(0)("batdau")
        End If
        If IsDBNull(Dao.Rows(0)("kethuc")) = False Then
            dto.kethuc = Dao.Rows(0)("kethuc")
        End If
        If IsDBNull(Dao.Rows(0)("som")) = False Then
            dto.som = Dao.Rows(0)("som")
        End If
        If IsDBNull(Dao.Rows(0)("tre")) = False Then
            dto.tre = Dao.Rows(0)("tre")
        End If
        If IsDBNull(Dao.Rows(0)("tgvao1")) = False Then
            dto.tgvao1 = Dao.Rows(0)("tgvao1")
        End If
        If IsDBNull(Dao.Rows(0)("tgvao2")) = False Then
            dto.tgvao2 = Dao.Rows(0)("tgvao2")
        End If
        If IsDBNull(Dao.Rows(0)("tgra1")) = False Then
            dto.tgra1 = Dao.Rows(0)("tgra1")
        End If
        If IsDBNull(Dao.Rows(0)("tgra2")) = False Then
            dto.tgra2 = Dao.Rows(0)("tgra2")
        End If
        If IsDBNull(Dao.Rows(0)("ngaycong")) = False Then
            dto.ngaycong = Dao.Rows(0)("ngaycong")
        End If
        If IsDBNull(Dao.Rows(0)("Sophut")) = False Then
            dto.Sophut = Dao.Rows(0)("Sophut")
        End If
        If IsDBNull(Dao.Rows(0)("mau")) = False Then
            dto.mau = Dao.Rows(0)("mau")
        End If
        If IsDBNull(Dao.Rows(0)("Cacon")) = False Then
            dto.Cacon = Dao.Rows(0)("Cacon")
        End If
        Return dto
    End Function
End Class

