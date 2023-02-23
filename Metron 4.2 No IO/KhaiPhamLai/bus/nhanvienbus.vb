Imports System.Data
Public Class nhanvienBus
    Inherits AbstractBus
    Public Sub New()
        QuyenGhi = ThemNV
        QuyenXoa = XoaNV
        QuyenSua = SuaNV
    End Sub
    Public Sub New(ByVal Connection As OleDb.OleDbConnection, ByVal sqlServer As Boolean)
        ketnoiConnection = Connection
        MSsql = sqlServer
        QuyenGhi = ThemNV
        QuyenXoa = XoaNV
        QuyenSua = SuaNV
    End Sub
    Public Sub New(ByVal Connection As KetNoiDto, ByVal sqlServer As Boolean)
        ketnoi = Connection
        MSsql = sqlServer
        QuyenGhi = ThemNV
        QuyenXoa = XoaNV
        QuyenSua = SuaNV
    End Sub
#Region "Xử Lý"
    Public Sub Them(ByVal Dto As nhanviendto, Optional ByVal ChuoiThongBaoLoi As String = "Không có Quyền")
        If QuyenGhi = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As nhanvienDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New nhanvienDao(ketnoiConnection)
        Else
            Dao = New nhanvienDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.Them(Dto, MSsql)
    End Sub

    Public Sub ThemTTNV(ByVal MaCC As Integer, ByVal TenHT As String, ByVal MaThe As String, ByVal Quyen As String)

        Dim Dao As nhanvienDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New nhanvienDao(ketnoiConnection)
        Else
            Dao = New nhanvienDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.ThemTTNV(MaCC, TenHT, MaThe, Quyen, MSsql)
    End Sub

    Public Sub Xoa(ByVal ma As Integer, Optional ByVal ChuoiThongBaoLoi As String = "Không có Quyền")
        If QuyenXoa = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As nhanvienDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New nhanvienDao(ketnoiConnection)
        Else
            Dao = New nhanvienDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.Xoa(ma, MSsql)
    End Sub
    Public Sub sua(ByVal Dto As nhanviendto, Optional ByVal ChuoiThongBaoLoi As String = "Không có Quyền")
        If QuyenSua = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As nhanvienDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New nhanvienDao(ketnoiConnection)
        Else
            Dao = New nhanvienDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.sua(Dto, MSsql)
    End Sub
#End Region
    Public Sub Xoatheodonvi(ByVal madonvi As Integer)
        Dim dao As New nhanvienDao
        dao.XoaTheoDonvi(madonvi, False)
    End Sub
    Public Function mathem() As Integer
        Dim dao As New nhanvienDao
        If ketnoi.ChuoiKetNoi = "" Then
            Return dao.MaThem(ketnoiConnection)
        Else
            Return dao.MaThem()
        End If
    End Function
    Public Function LayBangTable() As DataTable
        Dim a As String = "SELECT Nhanvien.MaNV, Nhanvien.TenNV, Nhanvien.TenHT, chucvu.Chucvu, Donvi.TenDV, Nhanvien.CardNo, Nhanvien.Gioitinh, Nhanvien.Diachi, Nhanvien.CMND, Nhanvien.Ngayvaolam, Nhanvien.NVSP, Nhanvien.Quyen, Nhanvien.Ngaysinh FROM chucvu INNER JOIN (Donvi INNER JOIN Nhanvien ON Donvi.MaDV = Nhanvien.Donvi) ON chucvu.CVID = Nhanvien.Chucvu ORDER BY Nhanvien.MaNV"
        Dim Dao As New AbstractDao("", a, ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangTableCodk(ByVal dk As String) As DataTable
        Dim a As String = "SELECT Nhanvien.MaNV, Nhanvien.TenNV, Nhanvien.TenHT, chucvu.Chucvu, Donvi.TenDV, Nhanvien.CardNo, Nhanvien.Gioitinh, Nhanvien.Diachi, Nhanvien.CMND, Nhanvien.Ngayvaolam, Nhanvien.NVSP, Nhanvien.Quyen, Nhanvien.Ngaysinh FROM chucvu INNER JOIN (Donvi INNER JOIN Nhanvien ON Donvi.MaDV = Nhanvien.Donvi) ON chucvu.CVID = Nhanvien.Chucvu  where 0=1" & dk
        Dim Dao As New AbstractDao("", a, ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangTableso() As DataTable
        Dim Dao As New nhanvienDao(ketnoi, MSsql)
        Return Dao
    End Function

    Public Function LayBangTabletheodonviCoLich(ByVal madv As Integer) As DataTable
        Dim a As String = "SELECT Nhanvien.MaNV, Nhanvien.TenNV, Nhanvien.TenHT, chucvu.Chucvu, Donvi.TenDV, Nhanvien.CardNo, Nhanvien.Gioitinh, Nhanvien.Diachi, Nhanvien.CMND, Nhanvien.Ngayvaolam, Nhanvien.NVSP, Nhanvien.Quyen, Nhanvien.Ngaysinh FROM chucvu INNER JOIN (Donvi INNER JOIN Nhanvien ON Donvi.MaDV = Nhanvien.Donvi) ON chucvu.CVID = Nhanvien.Chucvu,lichnv where  nhanvien.MaNV = lichnv.NVID and donvi=" & madv
        Dim Dao As New AbstractDao("", a, ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangTabletheodonviKhongCoLich(ByVal madv As Integer) As DataTable
        Dim a As String = "SELECT Nhanvien.MaNV, Nhanvien.TenNV, Nhanvien.TenHT, chucvu.Chucvu, Donvi.TenDV, Nhanvien.CardNo, Nhanvien.Gioitinh, Nhanvien.Diachi, Nhanvien.CMND, Nhanvien.Ngayvaolam, Nhanvien.NVSP, Nhanvien.Quyen, Nhanvien.Ngaysinh FROM chucvu INNER JOIN (Donvi INNER JOIN Nhanvien ON Donvi.MaDV = Nhanvien.Donvi) ON chucvu.CVID = Nhanvien.Chucvu WHERE Nhanvien.Donvi=" & madv & " and  manv not in (select NVID from lichnv)"
        Dim Dao As New AbstractDao("", a, ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangTabletheodonvi(ByVal madv As Integer) As DataTable
        Dim a As String = "SELECT Nhanvien.MaNV, Nhanvien.TenNV, Nhanvien.TenHT, chucvu.Chucvu, Donvi.TenDV, Nhanvien.CardNo, Nhanvien.Gioitinh, Nhanvien.Diachi, Nhanvien.CMND, Nhanvien.Ngayvaolam, Nhanvien.NVSP, Nhanvien.Quyen, Nhanvien.Ngaysinh FROM chucvu INNER JOIN (Donvi INNER JOIN Nhanvien ON Donvi.MaDV = Nhanvien.Donvi) ON chucvu.CVID = Nhanvien.Chucvu where (donvi = " & madv & ")"
        '  Dim a As String = "SELECT Nhanvien.MaNV, Nhanvien.TenNV, Nhanvien.TenHT, chucvu.Chucvu, Donvi.TenDV, Nhanvien.CardNo, Nhanvien.Gioitinh, Nhanvien.Diachi, Nhanvien.CMND, Nhanvien.Ngayvaolam, Nhanvien.NVSP, Nhanvien.Quyen, Nhanvien.Ngaysinh, NVvan.VanID FROM (chucvu INNER JOIN (Donvi INNER JOIN Nhanvien ON Donvi.MaDV = Nhanvien.Donvi) ON chucvu.CVID = Nhanvien.Chucvu) INNER JOIN NVvan ON Nhanvien.MaNV = NVvan.MaNV where (donvi = " & madv & ")"
        Dim Dao As New AbstractDao("", a, ketnoi, MSsql)
        Return Dao
    End Function

    Public Function LocNhanVienUSB(ByVal madv As Integer) As DataTable
        'Dim a As String = "SELECT Nhanvien.MaNV, Nhanvien.NVSP, Nhanvien.TenNV , NVVan.Ma FROM chucvu INNER JOIN (Donvi INNER JOIN Nhanvien ON Donvi.MaDV = Nhanvien.Donvi) ON chucvu.CVID = Nhanvien.Chucvu INNER JOIN NVVan ON NhanVien.MaNV = NVVan.MaNV where(donvi = " & madv & ")"
        Dim a As String = "SELECT Nhanvien.MaNV, Nhanvien.NVSP, Nhanvien.TenNV, chucvu.Chucvu, Donvi.TenDV, NVvan.*" & _
                     " FROM NVvan INNER JOIN (Donvi INNER JOIN (chucvu INNER JOIN Nhanvien ON chucvu.CVID = Nhanvien.Chucvu) ON Donvi.MaDV = Nhanvien.Donvi) ON NVvan.MaNV = Nhanvien.MaNV where NhanVien.DonVi = " & madv & "; "
        Dim Dao As New AbstractDao("", a, ketnoi, MSsql)
        Return Dao
    End Function

    Public Function LocNhanVienUSBAll() As DataTable
        Dim a As String = "SELECT Nhanvien.MaNV, Nhanvien.NVSP, Nhanvien.TenNV, chucvu.Chucvu, Donvi.TenDV, NVvan.ma" & _
                            " FROM NVvan INNER JOIN (Donvi INNER JOIN (chucvu INNER JOIN Nhanvien ON chucvu.CVID = Nhanvien.Chucvu) ON Donvi.MaDV = Nhanvien.Donvi) ON NVvan.MaNV = Nhanvien.MaNV; "

        Dim Dao As New AbstractDao("", a, ketnoi, MSsql)
        Return Dao
    End Function


    Public Function LayBangTabletheodonviDemo(ByVal madv As Integer) As DataTable
        Dim a As String = "SELECT Nhanvien.MaNV,Nhanvien.TenHT,CardNo,Nhanvien.Quyen FROM Nhanvien where(donvi = " & madv & ")"
        Dim Dao As New AbstractDao("", a, ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangTabletheochucvu(ByVal macv As Integer) As DataTable
        Dim a As String = "SELECT * FROM Nhanvien where chucvu = " & macv
        Dim Dao As New AbstractDao("", a, ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangTableSQL(ByVal sql As String) As DataTable
        Dim Dao As New AbstractDao(sql, sql, ketnoi, MSsql)
        Return Dao
    End Function
    Public Sub suaChucvu(ByVal Chucvu As Integer, ByVal ma As String)
        Dim dao As New nhanvienDao
        dao.SuaChucvu(Chucvu, ma, MSsql)
    End Sub
    Public Sub suaDonvi(ByVal Donvi As Integer, ByVal ma As String)
        Dim dao As New nhanvienDao
        dao.SuaDonvi(Donvi, ma, MSsql)
    End Sub
    Public Sub suaQuyen(ByVal Quyen As Integer, ByVal ma As String)
        Dim dao As New nhanvienDao
        dao.SuaQuyen(Quyen, ma, MSsql)
    End Sub

    Public Sub upDateTTMay(ByVal Quyen As Integer, ByVal tenHT As String, ByVal MaThe As String, ByVal ma As String)
        Dim dao As New nhanvienDao
        dao.upDateTTMay(Quyen, tenHT, MaThe, ma, MSsql)
    End Sub

    Public Function LayBangTable(ByVal ma As Integer) As DataTable
        Dim Dao As New nhanvienDao(ma, ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangDTo(ByVal dong As Integer, ByVal dao As DataTable) As nhanviendto
        Dim dto As New nhanviendto
        If Dao.Rows.Count <= 0 Then Return dto
        If IsDBNull(dao.Rows(dong)("MaNV")) = False Then
            dto.MaNV = dao.Rows(dong)("MaNV")
        End If
        If IsDBNull(dao.Rows(dong)("NVSP")) = False Then
            dto.NVSP = dao.Rows(dong)("NVSP")
        End If
        If IsDBNull(dao.Rows(dong)("TenNV")) = False Then
            dto.TenNV = dao.Rows(dong)("TenNV")
        End If
        If IsDBNull(dao.Rows(dong)("TenHT")) = False Then
            dto.TenHT = dao.Rows(dong)("TenHT")
        End If
        If IsDBNull(dao.Rows(dong)("Chucvu")) = False Then
            dto.Chucvu = dao.Rows(dong)("Chucvu")
        End If
        If IsDBNull(dao.Rows(dong)("Donvi")) = False Then
            dto.Donvi = dao.Rows(dong)("Donvi")
        End If
        If IsDBNull(dao.Rows(dong)("Quyen")) = False Then
            dto.Quyen = dao.Rows(dong)("Quyen")
        End If
        If IsDBNull(dao.Rows(dong)("CardNo")) = False Then
            dto.CardNo = dao.Rows(dong)("CardNo")
        End If
        If IsDBNull(dao.Rows(dong)("Ngaysinh")) = False Then
            dto.Ngaysinh = dao.Rows(dong)("Ngaysinh")
        End If
        If IsDBNull(dao.Rows(dong)("Gioitinh")) = False Then
            dto.Gioitinh = dao.Rows(dong)("Gioitinh")
        End If
        If IsDBNull(dao.Rows(dong)("Diachi")) = False Then
            dto.Diachi = dao.Rows(dong)("Diachi")
        End If
        If IsDBNull(dao.Rows(dong)("CMND")) = False Then
            dto.CMND = dao.Rows(dong)("CMND")
        End If
        If IsDBNull(dao.Rows(dong)("Ngayvaolam")) = False Then
            dto.Ngayvaolam = dao.Rows(dong)("Ngayvaolam")
        End If
        If IsDBNull(dao.Rows(dong)("Hinh")) = False Then
            dto.Hinh = dao.Rows(dong)("Hinh")
        End If
        Return dto
    End Function
    Public Function LayBangDTo(ByVal ma As Integer) As nhanviendto
        Dim Dao As New nhanvienDao(ma, ketnoi, MSsql)
        Dim dto As New nhanviendto
        If Dao.Rows.Count <= 0 Then Return dto
        If IsDBNull(Dao.Rows(0)("MaNV")) = False Then
            dto.MaNV = Dao.Rows(0)("MaNV")
        End If
        If IsDBNull(Dao.Rows(0)("NVSP")) = False Then
            dto.NVSP = Dao.Rows(0)("NVSP")
        End If
        If IsDBNull(Dao.Rows(0)("TenNV")) = False Then
            dto.TenNV = Dao.Rows(0)("TenNV")
        End If
        If IsDBNull(Dao.Rows(0)("TenHT")) = False Then
            dto.TenHT = Dao.Rows(0)("TenHT")
        End If
        If IsDBNull(Dao.Rows(0)("Chucvu")) = False Then
            dto.Chucvu = Dao.Rows(0)("Chucvu")
        End If
        If IsDBNull(Dao.Rows(0)("Donvi")) = False Then
            dto.Donvi = Dao.Rows(0)("Donvi")
        End If
        If IsDBNull(Dao.Rows(0)("Quyen")) = False Then
            dto.Quyen = Dao.Rows(0)("Quyen")
        End If
        If IsDBNull(Dao.Rows(0)("CardNo")) = False Then
            dto.CardNo = Dao.Rows(0)("CardNo")
        End If
        If IsDBNull(Dao.Rows(0)("Ngaysinh")) = False Then
            dto.Ngaysinh = Dao.Rows(0)("Ngaysinh")
        End If
        If IsDBNull(Dao.Rows(0)("Gioitinh")) = False Then
            dto.Gioitinh = Dao.Rows(0)("Gioitinh")
        End If
        If IsDBNull(Dao.Rows(0)("Diachi")) = False Then
            dto.Diachi = Dao.Rows(0)("Diachi")
        End If
        If IsDBNull(Dao.Rows(0)("CMND")) = False Then
            dto.CMND = Dao.Rows(0)("CMND")
        End If
        If IsDBNull(Dao.Rows(0)("Ngayvaolam")) = False Then
            dto.Ngayvaolam = Dao.Rows(0)("Ngayvaolam")
        End If
        If IsDBNull(Dao.Rows(0)("Hinh")) = False Then
            dto.Hinh = Dao.Rows(0)("Hinh")
        End If
        Return dto
    End Function
End Class

