Imports System.Data
Public Class lichtamBus
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
    Public Sub Them(ByVal Dto As lichtamdto, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenGhi = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As lichtamDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New lichtamDao(ketnoiConnection)
        Else
            Dao = New lichtamDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.Them(Dto, MSsql)
    End Sub
    Public Sub Xoa(ByVal ma As Integer, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenXoa = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As lichtamDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New lichtamDao(ketnoiConnection)
        Else
            Dao = New lichtamDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.Xoa(ma, MSsql)
    End Sub
 
    Public Sub XoaAll(Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenXoa = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As lichtamDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New lichtamDao(ketnoiConnection)
        Else
            Dao = New lichtamDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.XoaALL(MSsql)
    End Sub



    Public Sub Xoa(ByVal MANV As Integer, ByVal TUNGAY As Date, ByVal DENNGAY As Date, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenXoa = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As lichtamDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New lichtamDao(ketnoiConnection)
        Else
            Dao = New lichtamDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.XoaTheoNVvaTUNGAYvaDENNGAY(MANV, TUNGAY, DENNGAY, MSsql)
    End Sub
    Public Sub Xoa(ByVal MANV As Integer, ByVal caid As Integer, ByVal TUNGAY As Date, ByVal DENNGAY As Date, Optional ByVal ChuoiThongBaoLoi As String = "")
        Try
            If QuyenXoa = False Then
                MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
                Exit Sub
            End If
            Dim Dao As lichtamDao
            If ketnoi.ChuoiKetNoi = "" Then
                Dao = New lichtamDao(ketnoiConnection)
            Else
                Dao = New lichtamDao(ketnoi.ChuoiKetNoi)
            End If
            Dao.XoaTheoNVvaCaidvaTUNGAYvaDENNGAY(MANV, caid, TUNGAY, DENNGAY, MSsql)
        Catch ex As Exception
        End Try
    End Sub
    Public Sub sua(ByVal Dto As lichtamdto, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenSua = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As lichtamDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New lichtamDao(ketnoiConnection)
        Else
            Dao = New lichtamDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.sua(Dto, MSsql)
    End Sub
#End Region
    Public Function LayBangTable() As DataTable
        Dim Dao As New lichtamDao(ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangTableTheoCaid(ByVal caid As Integer) As DataTable
        Dim sql As String = " select * from lichtam where caID=" & caid & ""
        Dim Dao As New AbstractDao(sql, sql, ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangTableTheoNVid(ByVal idNV As Integer) As DataTable
        Dim sql As String = " select * from lichtam where NVID=" & idNV
        Dim Dao As New AbstractDao(sql, sql, ketnoi, MSsql)
        Return Dao
    End Function

    Public Function LayLichTamTheoNgay(ByVal MaNV As Integer, ByVal TuNgay As Date, ByVal DenNGay As Date) As DataTable
        'Dim sql As String = " select * from lichtam where NVID=" & idNV
        Dim Dao As New lichtamDao
        Dao.LayLichTamTheoNgay(manv, TuNgay, DenNGay)
        Return Dao
    End Function

    Public Function LayLichTamTheoThoiGian(ByVal MaNV As Integer, ByVal TuNgay As Date, ByVal DenNGay As Date) As DataTable
        'Dim sql As String = " select * from lichtam where NVID=" & idNV
        Dim Dao As New lichtamDao
        Dao.LayLichTamTheoThoiGian(MaNV, TuNgay, DenNGay)
        Return Dao
    End Function


    Public Function LayLichTamTheoBangArrayThoiGian(ByVal MaNV As Integer, ByVal TuNgay As Date, ByVal DenNGay As Date) As IList
        'Dim sql As String = " select * from lichtam where NVID=" & idNV
        Dim Dao As New lichtamDao
        Dao.LayLichTamTheoThoiGian(MaNV, TuNgay, DenNGay)
        Dim array1 As New ArrayList

        For i As Integer = 0 To Dao.Rows.Count - 1
            Dim DataTam As New ThongTinLichTam
            DataTam.MaCa = Dao.Rows(i).Item("ID")
            DataTam.TenCa = Dao.Rows(i).Item("TenCa")
            DataTam.BatDau = Dao.Rows(i).Item("batdau")
            DataTam.KetThuc = Dao.Rows(i).Item("kethuc")
            DataTam.Tgvao1 = Dao.Rows(i).Item("tgvao1")
            DataTam.Tgvao2 = Dao.Rows(i).Item("tgvao2")
            DataTam.Som = Dao.Rows(i).Item("Som")
            DataTam.Tre = Dao.Rows(i).Item("Tre")
            DataTam.SoPhut = Dao.Rows(i).Item("Sophut")
            DataTam.SoCong = Dao.Rows(i).Item("NgayCong")
            DataTam.TangCa = Dao.Rows(i).Item("TangCa")
            DataTam.TangCaS = Dao.Rows(i).Item("TangCaS")
            DataTam.GHTangCa = Dao.Rows(i).Item("GHTangC")
            DataTam.CaDem = Dao.Rows(i).Item("DiLam")
            DataTam.TuNgay = Dao.Rows(i).Item("TuNgay")
            DataTam.DenNgay = Dao.Rows(i).Item("DenNgay")
            DataTam.mau = Dao.Rows(i).Item("Mau")
            array1.Add(DataTam)
        Next

        Return array1
    End Function

    Public Function LayBangTableSQL(ByVal sql As String) As DataTable
        Dim Dao As New AbstractDao(sql, sql, ketnoi, MSsql)
        Return Dao
    End Function
    Public Sub suaNVID(ByVal NVID As Integer, ByVal ma As String)
        Dim dao As New lichtamDao
        dao.SuaNVID(NVID, ma, MSsql)
    End Sub
    Public Sub suaCaID(ByVal CaID As Integer, ByVal ma As String)
        Dim dao As New lichtamDao
        dao.SuaCaID(CaID, ma, MSsql)
    End Sub
    Public Sub suaTangCaS(ByVal TangCaS As Integer, ByVal ma As String)
        Dim dao As New lichtamDao
        dao.SuaTangCaS(TangCaS, ma, MSsql)
    End Sub
    Public Sub suaGHTangC(ByVal GHTangC As Integer, ByVal ma As String)
        Dim dao As New lichtamDao
        dao.SuaGHTangC(GHTangC, ma, MSsql)
    End Sub
    Public Function LayBangTable(ByVal ma As Integer) As DataTable
        Dim Dao As New lichtamDao(ma, ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangDTo(ByVal dong As Integer, ByVal dataLichTam As DataTable) As lichtamdto
        Dim dto As New lichtamdto
        If IsDBNull(dataLichTam.Rows(dong)("ID")) = False Then
            dto.ID = dataLichTam.Rows(dong)("ID")
        End If
        If IsDBNull(dataLichTam.Rows(dong)("NVID")) = False Then
            dto.NVID = dataLichTam.Rows(dong)("NVID")
        End If
        If IsDBNull(dataLichTam.Rows(dong)("CaID")) = False Then
            dto.CaID = dataLichTam.Rows(dong)("CaID")
        End If
        If IsDBNull(dataLichTam.Rows(dong)("Tungay")) = False Then
            dto.Tungay = dataLichTam.Rows(dong)("Tungay")
        End If
        If IsDBNull(dataLichTam.Rows(dong)("Denngay")) = False Then
            dto.Denngay = dataLichTam.Rows(dong)("Denngay")
        End If
        If IsDBNull(dataLichTam.Rows(dong)("Tangca")) = False Then
            dto.Tangca = dataLichTam.Rows(dong)("Tangca")
        End If
        If IsDBNull(dataLichTam.Rows(dong)("TangCaS")) = False Then
            dto.TangCaS = dataLichTam.Rows(dong)("TangCaS")
        End If
        If IsDBNull(dataLichTam.Rows(dong)("GHTangC")) = False Then
            dto.GHTangC = dataLichTam.Rows(dong)("GHTangC")
        End If
        If IsDBNull(dataLichTam.Rows(dong)("Dilam")) = False Then
            dto.Dilam = dataLichTam.Rows(dong)("Dilam")
        End If
        Return dto
    End Function
    Public Function LayBangDTo(ByVal ma As Integer) As lichtamdto
        Dim Dao As New lichtamDao(ma, ketnoi, MSsql)
        Dim dto As New lichtamdto
        If IsDBNull(Dao.Rows(0)("ID")) = False Then
            dto.ID = Dao.Rows(0)("ID")
        End If
        If IsDBNull(Dao.Rows(0)("NVID")) = False Then
            dto.NVID = Dao.Rows(0)("NVID")
        End If
        If IsDBNull(Dao.Rows(0)("CaID")) = False Then
            dto.CaID = Dao.Rows(0)("CaID")
        End If
        If IsDBNull(Dao.Rows(0)("Tungay")) = False Then
            dto.Tungay = Dao.Rows(0)("Tungay")
        End If
        If IsDBNull(Dao.Rows(0)("Denngay")) = False Then
            dto.Denngay = Dao.Rows(0)("Denngay")
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
        If IsDBNull(Dao.Rows(0)("Dilam")) = False Then
            dto.Dilam = Dao.Rows(0)("Dilam")
        End If
        Return dto
    End Function
End Class

