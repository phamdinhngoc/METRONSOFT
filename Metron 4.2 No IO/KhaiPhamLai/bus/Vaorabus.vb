Imports System.Data
Public Class VaoraBus
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
    Public Sub Them(ByVal Dto As Vaoradto, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenGhi = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As VaoraDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New VaoraDao(ketnoiConnection)
        Else
            Dao = New VaoraDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.Them(Dto, MSsql)
    End Sub
    Public Sub Xoa(ByVal ma As Integer, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenXoa = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As VaoraDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New VaoraDao(ketnoiConnection)
        Else
            Dao = New VaoraDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.Xoa(ma, MSsql)
    End Sub
    Public Sub XoatheoManvvaThoigian(ByVal macc As Integer, ByVal thoigian As Date, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenXoa = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As VaoraDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New VaoraDao(ketnoiConnection)
        Else
            Dao = New VaoraDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.XoatheoMaNVvaThoigian(macc, thoigian, MSsql)
    End Sub

    Public Sub XoatheoThoigian(ByVal TuNgay As Date, ByVal DenNgay As Date, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenXoa = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As VaoraDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New VaoraDao(ketnoiConnection)
        Else
            Dao = New VaoraDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.XoaTuNgayDenNgay(TuNgay, DenNgay, MSsql)
    End Sub


    Public Sub XoatheoThoigianAll(ByVal TuNgay As Date, ByVal DenNgay As Date, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenXoa = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As VaoraDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New VaoraDao(ketnoiConnection)
        Else
            Dao = New VaoraDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.XoaTuNgayDenNgayAll(TuNgay, DenNgay, MSsql)
    End Sub

    Public Sub sua(ByVal Dto As Vaoradto, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenSua = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As VaoraDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New VaoraDao(ketnoiConnection)
        Else
            Dao = New VaoraDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.sua(Dto, MSsql)
    End Sub
#End Region
    Public Function laybangBaocaotuNGayvadenngay(ByVal tungay As DateTime, ByVal denngay As DateTime) As DataTable
        Dim Dao As New VaoraDao(ketnoi)
        Dao.laybangBaocaoNGay(tungay, denngay)
        Return Dao
    End Function


    Public Function LayBangtheoMACCvaNGAy(ByVal macc As Integer, ByVal ngay As Date) As OleDb.OleDbDataReader
        Dim Dao As New VaoraDao(ketnoi)
        Return Dao.laybangtheoNGayvaMacc(ngay, macc)
    End Function

    Public Function DuLieuLN(ByVal MaMay As Integer) As DataTable
        Dim sql As String = "SELECT Max (Thoigian) as GTLN FROM vaora WHERE May = " & MaMay
        Dim Dao As New AbstractDao(sql, sql, ketnoi, MSsql)
        Return Dao
    End Function

    Public Function LayBangTabletheoMACCvaNGAy(ByVal macc As Integer, ByVal ngay As Date) As DataTable
        Dim Dao As New VaoraDao(ketnoi)
        Dao.laybangTabletheoNgayvaMacc(ngay, macc)
        Return Dao
    End Function
    Public Function LayBangArrayListtheoMACCvaNGAy(ByVal macc As Integer, ByVal ngay As Date) As IList
        Dim Dao As New VaoraDao(ketnoi)
        Dao.laybangTabletheoNgayvaMacc(ngay, macc)
        Dim array As New ArrayList
        For i As Integer = 0 To Dao.Rows.Count - 1
            Dim vaora As New Vaoradto
            vaora.Kieu = Dao.Rows(i)("kieu")
            vaora.Thoigian = Dao.Rows(i)("thoigian")
            array.Add(vaora)
        Next
        Return array
    End Function
    Public Function LayBangArrayListtheoMACCvaNgay(ByVal macc As Integer, ByVal ngay As Date, ByVal gio As Integer) As IList
        Dim Dao As New VaoraDao(ketnoi)
        Dao.laybangTabletNgayvaMaccLetgio(ngay, macc, gio)
        Dim array As New ArrayList
        For i As Integer = 0 To Dao.Rows.Count - 1
            Dim vaora As New Vaoradto
            vaora.Kieu = Dao.Rows(i)("kieu")
            vaora.Thoigian = Dao.Rows(i)("thoigian")
            array.Add(vaora)
        Next
        Return array
    End Function
    Public Function LayBangArrayListtheoMACCvaTUNGAYvaDENNGAY(ByVal macc As Integer, ByVal Tungay As Date, ByVal Denngay As Date) As IList
        Dim Dao As New VaoraDao(ketnoi)
        Dao.laybangTabletheoTuNgayvaDenNgayvaMacc(Tungay, Denngay, macc)
        Dim array As New ArrayList
        For i As Integer = 0 To Dao.Rows.Count - 1
            Dim vaora As New Vaoradto
            vaora.Kieu = Dao.Rows(i)("kieu")
            vaora.Thoigian = Dao.Rows(i)("thoigian")
            array.Add(vaora)
        Next
        Return array
    End Function
    Public Function LayBangTabletheoNVid(ByVal manv As Integer) As DataTable
        Dim sql As String = "select * from vaora where manv=" & manv
        Dim Dao As New AbstractDao(sql, sql, ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangTabletheoNVidChitiet(ByVal manv As Integer) As DataTable
        Dim sql As String = "select nhanvien.manv,nvsp,tennv,chucvu,donvi,ngay,thoigian from vaora,nhanvien where vaora.manv=nhanvien.manv and manv=" & manv
        Dim Dao As New AbstractDao(sql, sql, ketnoi, MSsql)
        Return Dao
    End Function

    Public Function LayBangTableThoigian(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal DonVi As Integer) As DataTable

        Dim Dao As New VaoraDao(ketnoi)
        Dao.laybangBaocaoThoiGian(TuNgay, DenNgay, DonVi)
        Return Dao
    End Function


    Public Function LayBangTableThoigianALL(ByVal TuNgay As Date, ByVal DenNgay As Date) As DataTable

        Dim Dao As New VaoraDao(ketnoi)
        Dao.laybangBaocaoThoiGianALl(TuNgay, DenNgay)
        Return Dao
    End Function

    Public Function LayBangTable() As DataTable
        Dim Dao As New VaoraDao(ketnoi, MSsql)
        Return Dao
    End Function

    Public Function LayBangTableThoigianVaoALL(ByVal TuNgay As Date, ByVal DenNgay As Date) As DataTable

        Dim Dao As New VaoraDao(ketnoi)
        Dao.laybangBaocaoThoiGianVaoALl(TuNgay, DenNgay)
        Return Dao
    End Function

    Public Function LayBangTableThoigianraALL(ByVal TuNgay As Date, ByVal DenNgay As Date) As DataTable

        Dim Dao As New VaoraDao(ketnoi)
        Dao.laybangBaocaoThoiGianRaALl(TuNgay, DenNgay)
        Return Dao
    End Function


    Public Function LayBangTableThoigianVao(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal DonVi As Integer) As DataTable

        Dim Dao As New VaoraDao(ketnoi)
        Dao.laybangBaocaoThoiGianVao(TuNgay, DenNgay, DonVi)
        Return Dao
    End Function


    Public Function LayBangTableThoigianRa(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal DonVi As Integer) As DataTable

        Dim Dao As New VaoraDao(ketnoi)
        Dao.laybangBaocaoThoiGianRa(TuNgay, DenNgay, DonVi)
        Return Dao
    End Function




 
    Public Function LayBangTableSQL(ByVal sql As String) As DataTable
        Dim Dao As New AbstractDao(sql, sql, ketnoi, MSsql)
        Return Dao
    End Function
    Public Sub suaMaNV(ByVal MaNV As Integer, ByVal ma As String)
        Dim dao As New VaoraDao
        dao.SuaMaNV(MaNV, ma, MSsql)
    End Sub
    Public Sub suaKieu(ByVal Kieu As Integer, ByVal ma As String)
        Dim dao As New VaoraDao
        dao.SuaKieu(Kieu, ma, MSsql)
    End Sub

    Public Sub suaKieu(ByVal Kieu As Integer, ByVal MaNV As Integer, ByVal ThoiGian As Date)
        Dim dao As New VaoraDao
        dao.SuaKieu(Kieu, MaNV, ThoiGian, MSsql)
    End Sub
    Public Sub suaMay(ByVal May As Integer, ByVal ma As String)
        Dim dao As New VaoraDao
        dao.SuaMay(May, ma, MSsql)
    End Sub
    Public Function LayBangTable(ByVal ma As Integer) As DataTable
        Dim Dao As New VaoraDao(ma, ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangDTo(ByVal ma As Integer) As Vaoradto
        Dim Dao As New VaoraDao(ma, ketnoi, MSsql)
        Dim dto As New Vaoradto
        If IsDBNull(Dao.Rows(0)("ID")) = False Then
            dto.ID = Dao.Rows(0)("ID")
        End If
        If IsDBNull(Dao.Rows(0)("MaNV")) = False Then
            dto.MaNV = Dao.Rows(0)("MaNV")
        End If
        If IsDBNull(Dao.Rows(0)("Thoigian")) = False Then
            dto.Thoigian = Dao.Rows(0)("Thoigian")
        End If
        If IsDBNull(Dao.Rows(0)("Kieu")) = False Then
            dto.Kieu = Dao.Rows(0)("Kieu")
        End If
        If IsDBNull(Dao.Rows(0)("May")) = False Then
            dto.May = Dao.Rows(0)("May")
        End If
        If IsDBNull(Dao.Rows(0)("Ngay")) = False Then
            dto.Ngay = Dao.Rows(0)("Ngay")
        End If
        Return dto
    End Function
    Public Function LayBangDTo(ByVal dong As Integer, ByVal dao As DataTable) As Vaoradto
        Dim dto As New Vaoradto
        If IsDBNull(dao.Rows(dong)("ID")) = False Then
            dto.ID = dao.Rows(dong)("ID")
        End If
        If IsDBNull(dao.Rows(dong)("MaNV")) = False Then
            dto.MaNV = dao.Rows(dong)("MaNV")
        End If
        If IsDBNull(dao.Rows(dong)("Thoigian")) = False Then
            dto.Thoigian = dao.Rows(dong)("Thoigian")
        End If
        If IsDBNull(dao.Rows(dong)("Kieu")) = False Then
            dto.Kieu = dao.Rows(dong)("Kieu")
        End If
        If IsDBNull(dao.Rows(dong)("May")) = False Then
            dto.May = dao.Rows(dong)("May")
        End If
        If IsDBNull(dao.Rows(dong)("Ngay")) = False Then
            dto.Ngay = dao.Rows(dong)("Ngay")
        End If
        Return dto
    End Function
End Class

