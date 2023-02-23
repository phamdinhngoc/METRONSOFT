Imports System.Data
Public Class caTDBus
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
    Public Sub Them(ByVal Dto As caTDdto, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenGhi = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As caTDDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New caTDDao(ketnoiConnection)
        Else
            Dao = New caTDDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.Them(Dto, MSsql)
    End Sub
    Public Sub Xoa(ByVal ma As Integer, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenXoa = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As caTDDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New caTDDao(ketnoiConnection)
        Else
            Dao = New caTDDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.Xoa(ma, MSsql)
    End Sub

    Public Sub XoaAll(Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenXoa = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As caTDDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New caTDDao(ketnoiConnection)
        Else
            Dao = New caTDDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.XoaAll(MSsql)
    End Sub


    Public Sub Xoa(ByVal MaNV As Integer, ByVal MaCa As Integer)

        Dim Dao As caTDDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New caTDDao(ketnoiConnection)
        Else
            Dao = New caTDDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.Xoa(maNV, MaCa, MSsql)
    End Sub

    Public Sub sua(ByVal Dto As caTDdto, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenSua = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As caTDDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New caTDDao(ketnoiConnection)
        Else
            Dao = New caTDDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.sua(Dto, MSsql)
    End Sub
#End Region
    Public Function LayBangTable() As DataTable
        Dim Dao As New caTDDao(ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangArrayList() As IList
        Dim Dao As New caTDDao(ketnoi, MSsql)
        Dim array As New ArrayList
        For i As Integer = 0 To Dao.Rows.Count - 1
            Dim ca As New caTDdto
            ca = Me.LayBangDTo(i, Dao)
            array.Add(ca)
        Next
        Return array
    End Function
    Public Function LayBangTableCaTheonvId(ByVal manvid As Integer) As IList
        Dim sql As String = "SELECT Ca.ID, Ca.Tenca, Ca.batdau, Ca.kethuc, Ca.tgvao1, Ca.tgvao2, Ca.som, Ca.tre, Ca.Sophut, Ca.ngaycong, Ca.mau, catd.Manv, catd.Tangca, catd.TangcaS, catd.GhTangCa FROM catd, Ca WHERE Catd.caid = ca.id and Catd.MaNV = " & manvid

        Dim Dao As New AbstractDao(sql, sql, ketnoi, MSsql)
        Dim array1 As New ArrayList

        For i As Integer = 0 To Dao.Rows.Count - 1
            Dim DataTam As New ThongTinCaTuDong
            DataTam.ID = Dao.Rows(i).Item("ID")
            DataTam.TenCa = Dao.Rows(i).Item("TenCa")
            DataTam.BatDau = Dao.Rows(i).Item("batdau")
            DataTam.KetThuc = Dao.Rows(i).Item("kethuc")
            DataTam.Tgvao1 = Dao.Rows(i).Item("tgvao1")
            DataTam.Tgvao2 = Dao.Rows(i).Item("tgvao2")
            DataTam.Som = Dao.Rows(i).Item("Som")
            DataTam.Tre = Dao.Rows(i).Item("Tre")
            DataTam.SoPhut = Dao.Rows(i).Item("Sophut")
            DataTam.NgayCong = Dao.Rows(i).Item("NgayCong")
            DataTam.TangCa = Dao.Rows(i).Item("TangCa")
            DataTam.TangCaS = Dao.Rows(i).Item("TangCaS")
            DataTam.GHTangCa = Dao.Rows(i).Item("GHTangCa")
            DataTam.mau = Dao.Rows(i).Item("Mau")
            array1.Add(DataTam)
        Next

        Return array1
    End Function
    Public Function LayBangTableTheonvId(ByVal manvid As Integer) As DataTable
        Dim sql As String = "Select * from catd where manv=" & manvid
        Dim Dao As New AbstractDao(sql, sql, ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangTableTheoCaId(ByVal macaid As Integer) As DataTable
        Dim sql As String = "Select * from catd where caid=" & macaid
        Dim Dao As New AbstractDao(Sql, Sql, ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangTableSQL(ByVal sql As String) As DataTable
        Dim Dao As New AbstractDao(sql, sql, ketnoi, MSsql)
        Return Dao
    End Function
    Public Sub suaMaNV(ByVal MaNV As Integer, ByVal ma As String)
        Dim dao As New caTDDao
        dao.SuaMaNV(MaNV, ma, MSsql)
    End Sub
    Public Sub suaCaid(ByVal Caid As Integer, ByVal ma As String)
        Dim dao As New caTDDao
        dao.SuaCaid(Caid, ma, MSsql)
    End Sub
    Public Sub suaTangcaS(ByVal TangcaS As Integer, ByVal ma As String)
        Dim dao As New caTDDao
        dao.SuaTangcaS(TangcaS, ma, MSsql)
    End Sub
    Public Sub suaGhTangca(ByVal GhTangca As Integer, ByVal ma As String)
        Dim dao As New caTDDao
        dao.SuaGhTangca(GhTangca, ma, MSsql)
    End Sub
    Public Function LayBangTable(ByVal ma As Integer) As DataTable
        Dim Dao As New caTDDao(ma, ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangDTo(ByVal ma As Integer) As caTDdto
        Dim Dao As New caTDDao(ma, ketnoi, MSsql)
        Dim dto As New caTDdto
        If IsDBNull(Dao.Rows(0)("ID")) = False Then
            dto.ID = Dao.Rows(0)("ID")
        End If
        If IsDBNull(Dao.Rows(0)("MaNV")) = False Then
            dto.MaNV = Dao.Rows(0)("MaNV")
        End If
        If IsDBNull(Dao.Rows(0)("Caid")) = False Then
            dto.Caid = Dao.Rows(0)("Caid")
        End If
        If IsDBNull(Dao.Rows(0)("TuNgay")) = False Then
            dto.TuNgay = Dao.Rows(0)("TuNgay")
        End If
        If IsDBNull(Dao.Rows(0)("DenNgay")) = False Then
            dto.DenNgay = Dao.Rows(0)("DenNgay")
        End If
        If IsDBNull(Dao.Rows(0)("Tangca")) = False Then
            dto.Tangca = Dao.Rows(0)("Tangca")
        End If
        If IsDBNull(Dao.Rows(0)("TangcaS")) = False Then
            dto.TangcaS = Dao.Rows(0)("TangcaS")
        End If
        If IsDBNull(Dao.Rows(0)("GhTangca")) = False Then
            dto.GhTangca = Dao.Rows(0)("GhTangca")
        End If
        Return dto
    End Function
    Public Function LayBangDTo(ByVal dong As Integer, ByVal dao As DataTable) As caTDdto
        Dim dto As New caTDdto
        If IsDBNull(dao.Rows(dong)("ID")) = False Then
            dto.ID = dao.Rows(dong)("ID")
        End If
        If IsDBNull(dao.Rows(dong)("MaNV")) = False Then
            dto.MaNV = dao.Rows(dong)("MaNV")
        End If
        If IsDBNull(dao.Rows(dong)("Caid")) = False Then
            dto.Caid = dao.Rows(dong)("Caid")
        End If
        If IsDBNull(dao.Rows(dong)("TuNgay")) = False Then
            dto.TuNgay = dao.Rows(dong)("TuNgay")
        End If
        If IsDBNull(dao.Rows(dong)("DenNgay")) = False Then
            dto.DenNgay = dao.Rows(dong)("DenNgay")
        End If
        If IsDBNull(dao.Rows(dong)("Tangca")) = False Then
            dto.Tangca = dao.Rows(dong)("Tangca")
        End If
        If IsDBNull(dao.Rows(dong)("TangcaS")) = False Then
            dto.TangcaS = dao.Rows(dong)("TangcaS")
        End If
        If IsDBNull(dao.Rows(dong)("GhTangca")) = False Then
            dto.GhTangca = dao.Rows(dong)("GhTangca")
        End If
        Return dto
    End Function
End Class

