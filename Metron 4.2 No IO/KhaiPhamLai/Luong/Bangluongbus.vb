Imports System.Data

Public Class BangluongBus
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
    Public Sub Them(ByVal Dto As Bangluongdto, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenGhi = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As BangluongDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New BangluongDao(ketnoiConnection)
        Else
            Dao = New BangluongDao(ketnoi.ChuoiKetNoi)
        End If
        If Dto.LuongThang = 0 Then
            MsgBox("Xin vui lòng kiểm tra lại Lương Tháng trước của nhân viên có mã: " & Dto.Manv, MsgBoxStyle.Information, "Thông báo")
            Exit Sub
        End If
        Dao.Them(Dto, MSsql)
    End Sub
    Public Sub Xoa(ByVal ma1 As Integer, ByVal ma2 As Integer, ByVal ma3 As Integer, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenXoa = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As BangluongDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New BangluongDao(ketnoiConnection)
        Else
            Dao = New BangluongDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.Xoa(ma1, ma2, ma3, MSsql)
    End Sub
    Public Sub sua(ByVal Dto As Bangluongdto, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenSua = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As BangluongDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New BangluongDao(ketnoiConnection)
        Else
            Dao = New BangluongDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.sua(Dto, MSsql)
    End Sub
#End Region
    Public Function LayBangTable() As DataTable
        Dim Dao As New BangluongDao(ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangTableSQL(ByVal sql As String) As DataTable
        Dim Dao As New AbstractDao(sql, sql, ketnoi, MSsql)
        Return Dao
    End Function
    Public Sub suaLuongThang(ByVal LuongThang As Integer, ByVal ma1 As String, ByVal ma2 As String, ByVal ma3 As String)
        Dim dao As New BangluongDao
        dao.SuaLuongThang(LuongThang, ma1, ma2, ma3, MSsql)
    End Sub
    Public Sub suaLuongngay(ByVal Luongngay As Integer, ByVal ma1 As String, ByVal ma2 As String, ByVal ma3 As String)
        Dim dao As New BangluongDao
        dao.SuaLuongngay(Luongngay, ma1, ma2, ma3, MSsql)
    End Sub
    Public Sub suaSocong(ByVal Socong As Integer, ByVal ma1 As String, ByVal ma2 As String, ByVal ma3 As String)
        Dim dao As New BangluongDao
        dao.SuaSocong(Socong, ma1, ma2, ma3, MSsql)
    End Sub
    Public Sub suaSongay(ByVal Songay As Integer, ByVal ma1 As String, ByVal ma2 As String, ByVal ma3 As String)
        Dim dao As New BangluongDao
        dao.SuaSongay(Songay, ma1, ma2, ma3, MSsql)
    End Sub
    Public Sub suaLuongngaycong(ByVal Luongngaycong As Integer, ByVal ma1 As String, ByVal ma2 As String, ByVal ma3 As String)
        Dim dao As New BangluongDao
        dao.SuaLuongngaycong(Luongngaycong, ma1, ma2, ma3, MSsql)
    End Sub
    Public Sub suaPhucap1(ByVal Phucap1 As Integer, ByVal ma1 As String, ByVal ma2 As String, ByVal ma3 As String)
        Dim dao As New BangluongDao
        dao.SuaPhucap1(Phucap1, ma1, ma2, ma3, MSsql)
    End Sub
    Public Sub suaPhucap2(ByVal Phucap2 As Integer, ByVal ma1 As String, ByVal ma2 As String, ByVal ma3 As String)
        Dim dao As New BangluongDao
        dao.SuaPhucap2(Phucap2, ma1, ma2, ma3, MSsql)
    End Sub
    Public Sub suaTamung1(ByVal Tamung1 As Integer, ByVal ma1 As String, ByVal ma2 As String, ByVal ma3 As String)
        Dim dao As New BangluongDao
        dao.SuaTamung1(Tamung1, ma1, ma2, ma3, MSsql)
    End Sub
    Public Sub suaTamung2(ByVal Tamung2 As Integer, ByVal ma1 As String, ByVal ma2 As String, ByVal ma3 As String)
        Dim dao As New BangluongDao
        dao.SuaTamung2(Tamung2, ma1, ma2, ma3, MSsql)
    End Sub
    Public Sub suaSolanditre(ByVal Solanditre As Integer, ByVal ma1 As String, ByVal ma2 As String, ByVal ma3 As String)
        Dim dao As New BangluongDao
        dao.SuaSolanditre(Solanditre, ma1, ma2, ma3, MSsql)
    End Sub
    Public Sub suaSolannghikophep(ByVal Solannghikophep As Integer, ByVal ma1 As String, ByVal ma2 As String, ByVal ma3 As String)
        Dim dao As New BangluongDao
        dao.SuaSolannghikophep(Solannghikophep, ma1, ma2, ma3, MSsql)
    End Sub
    Public Sub suaPhatditre(ByVal Phatditre As Integer, ByVal ma1 As String, ByVal ma2 As String, ByVal ma3 As String)
        Dim dao As New BangluongDao
        dao.SuaPhatditre(Phatditre, ma1, ma2, ma3, MSsql)
    End Sub
    Public Sub suaphatnghikophep(ByVal phatnghikophep As Integer, ByVal ma1 As String, ByVal ma2 As String, ByVal ma3 As String)
        Dim dao As New BangluongDao
        dao.Suaphatnghikophep(phatnghikophep, ma1, ma2, ma3, MSsql)
    End Sub
    Public Function LayBangTable(ByVal ma As Integer) As DataTable
        Dim Dao As New BangluongDao(ma, ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangTable(ByVal ma1 As Integer, ByVal ma2 As Integer) As DataTable
        Dim Dao As New BangluongDao(ma1, ma2, ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangTable(ByVal ma1 As Integer, ByVal ma2 As Integer, ByVal ma3 As Integer) As DataTable
        Dim Dao As New BangluongDao(ma1, ma2, ma3, ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangTablebophan(ByVal thang As Integer, ByVal nam As Integer, ByVal Bophan As String) As DataTable
        Dim sql As String = "SELECT L.*, Nhanvien.*, TenDV , chucvu.chucvu " & _
        " FROM chucvu inner join ( Donvi INNER JOIN ((select * from bangLuong where thang= " & thang & "and nam= " & nam & ")L RIGHT JOIN Nhanvien ON L.Manv = Nhanvien.MaNV) ON Donvi.MaDV = Nhanvien.Donvi )  on nhanvien.chucvu=chucvu.cvid  " & _
        " WHERE  1=0 " & Bophan & _
        " Order by  Donvi.MaDV"
        Return LayBangTableSQL(sql)
    End Function
    Public Function LayBangTablebophan1(ByVal thang As Integer, ByVal nam As Integer, ByVal Bophan As Integer) As DataTable
        Dim sql As String = "SELECT L.*, Nhanvien.*, TenDV , chucvu.chucvu " & _
        " FROM chucvu inner join ( Donvi INNER JOIN ((select * from bangLuong where thang= " & thang & "and nam= " & nam & ")L RIGHT JOIN Nhanvien ON L.Manv = Nhanvien.MaNV) ON Donvi.MaDV = Nhanvien.Donvi )  on nhanvien.chucvu=chucvu.cvid  " & _
        "WHERE 1= 0 or Donvi.MaDV = " & Bophan & "  order by L.MANV"
        Return LayBangTableSQL(sql)
    End Function
    Public Function LayBangDTo(ByVal manv As Integer, ByVal thang As Integer, ByVal Nam As Integer) As Bangluongdto
        Dim Dao As New BangluongDao(manv, thang, Nam, ketnoi, MSsql)
        Dim dto As New Bangluongdto
        If Dao.Rows.Count <= 0 Then Return dto
        If IsDBNull(Dao.Rows(0)("Manv")) = False Then
            dto.Manv = Dao.Rows(0)("Manv")
        End If
        If IsDBNull(Dao.Rows(0)("Thang")) = False Then
            dto.Thang = Dao.Rows(0)("Thang")
        End If
        If IsDBNull(Dao.Rows(0)("Nam")) = False Then
            dto.Nam = Dao.Rows(0)("Nam")
        End If
        If IsDBNull(Dao.Rows(0)("LuongThang")) = False Then
            dto.LuongThang = Dao.Rows(0)("LuongThang")
        End If
        If IsDBNull(Dao.Rows(0)("Luongngay")) = False Then
            dto.Luongngay = Dao.Rows(0)("Luongngay")
        End If
        If IsDBNull(Dao.Rows(0)("Socong")) = False Then
            dto.Socong = Dao.Rows(0)("Socong")
        End If
        If IsDBNull(Dao.Rows(0)("Songay")) = False Then
            dto.Songay = Dao.Rows(0)("Songay")
        End If
        If IsDBNull(Dao.Rows(0)("Luongngaycong")) = False Then
            dto.Luongngaycong = Dao.Rows(0)("Luongngaycong")
        End If
        If IsDBNull(Dao.Rows(0)("Phucap1")) = False Then
            dto.Phucap1 = Dao.Rows(0)("Phucap1")
        End If
        If IsDBNull(Dao.Rows(0)("Phucap2")) = False Then
            dto.Phucap2 = Dao.Rows(0)("Phucap2")
        End If
        If IsDBNull(Dao.Rows(0)("Tamung1")) = False Then
            dto.Tamung1 = Dao.Rows(0)("Tamung1")
        End If
        If IsDBNull(Dao.Rows(0)("SoGioTC")) = False Then
            dto.SoGioTc = Dao.Rows(0)("SogioTc")
        End If
        If IsDBNull(Dao.Rows(0)("TientcGio")) = False Then
            dto.TienTcGio = Dao.Rows(0)("TientcGio")
        End If
        If IsDBNull(Dao.Rows(0)("Tientangca")) = False Then
            dto.TienTangca = Dao.Rows(0)("Tientangca")
        End If
        If IsDBNull(Dao.Rows(0)("TienAnTC")) = False Then
            dto.TienAnTC = Dao.Rows(0)("TienAnTc")
        End If
        
        If IsDBNull(Dao.Rows(0)("SuatAnTrua")) = False Then
            dto.SuatAnTrua = Dao.Rows(0)("SuatAnTrua")
        End If
        If IsDBNull(Dao.Rows(0)("NgayCN")) = False Then
            dto.TienTangca = Dao.Rows(0)("NgayCN")
        End If
        If IsDBNull(Dao.Rows(0)("LuongCN")) = False Then
            dto.TienTangca = Dao.Rows(0)("LuongCN")
        End If
        If IsDBNull(Dao.Rows(0)("Solanditre")) = False Then
            dto.Solanditre = Dao.Rows(0)("Solanditre")
        End If
        If IsDBNull(Dao.Rows(0)("Phatditre")) = False Then
            dto.Phatditre = Dao.Rows(0)("Phatditre")
        End If
        If IsDBNull(Dao.Rows(0)("Solannghikophep")) = False Then
            dto.Solannghikophep = Dao.Rows(0)("Solannghikophep")
        End If
      
        If IsDBNull(Dao.Rows(0)("phatnghikophep")) = False Then
            dto.phatnghikophep = Dao.Rows(0)("phatnghikophep")
        End If
        If IsDBNull(Dao.Rows(0)("PhanTramBH")) = False Then
            dto.PhanTramBH = Dao.Rows(0)("PhanTramBH")
        End If
        If IsDBNull(Dao.Rows(0)("TienBH")) = False Then
            dto.TienBH = Dao.Rows(0)("TienBH")
        End If
        If IsDBNull(Dao.Rows(0)("TienComTrua")) = False Then
            dto.TienComTrua = Dao.Rows(0)("TienComTrua")
        End If
        If IsDBNull(Dao.Rows(0)("NgayGuiXe")) = False Then
            dto.NgayGuiXe = Dao.Rows(0)("NgayGuiXe")
        End If
        If IsDBNull(Dao.Rows(0)("TienGuiXe")) = False Then
            dto.TienGuiXe = Dao.Rows(0)("TienGuiXe")
        End If
        If IsDBNull(Dao.Rows(0)("TongTienXe")) = False Then
            dto.TongTienXe = Dao.Rows(0)("TongTienXe")
        End If
        If IsDBNull(Dao.Rows(0)("ChuyenCan")) = False Then
            dto.ChuyenCan = Dao.Rows(0)("ChuyenCan")
        End If
        Return dto
    End Function
    Public Function LayBangDTo(ByVal dong As Integer, ByVal dao As DataTable) As Bangluongdto
        Dim dto As New Bangluongdto

        If dao.Rows.Count <= 0 Then Return dto
        If IsDBNull(dao.Rows(dong)("L.Manv")) = False Then
            dto.Manv = dao.Rows(dong)("L.Manv")
        End If
        If IsDBNull(dao.Rows(dong)("Thang")) = False Then
            dto.Thang = dao.Rows(dong)("Thang")
        End If
        If IsDBNull(dao.Rows(dong)("Nam")) = False Then
            dto.Nam = dao.Rows(dong)("Nam")
        End If
        If IsDBNull(dao.Rows(dong)("LuongThang")) = False Then
            dto.LuongThang = dao.Rows(dong)("LuongThang")
        End If
        If IsDBNull(dao.Rows(dong)("Luongngay")) = False Then
            dto.Luongngay = dao.Rows(dong)("Luongngay")
        End If
        If IsDBNull(dao.Rows(dong)("Socong")) = False Then
            dto.Socong = dao.Rows(dong)("Socong")
        End If
        If IsDBNull(dao.Rows(dong)("Songay")) = False Then
            dto.Songay = dao.Rows(dong)("Songay")
        End If
        If IsDBNull(dao.Rows(dong)("Luongngaycong")) = False Then
            dto.Luongngaycong = dao.Rows(dong)("Luongngaycong")
        End If
        If IsDBNull(dao.Rows(dong)("Phucap1")) = False Then
            dto.Phucap1 = dao.Rows(dong)("Phucap1")
        End If
        If IsDBNull(dao.Rows(dong)("Tamung1")) = False Then
            dto.Tamung1 = dao.Rows(dong)("Tamung1")
        End If
        If IsDBNull(dao.Rows(dong)("SoGioTC")) = False Then
            dto.SoGioTc = dao.Rows(dong)("SogioTc")
        End If
        If IsDBNull(dao.Rows(dong)("TientcGio")) = False Then
            dto.TienTcGio = dao.Rows(dong)("TientcGio")
        End If
        If IsDBNull(dao.Rows(dong)("Tientangca")) = False Then
            dto.TienTangca = dao.Rows(dong)("Tientangca")
        End If
        If IsDBNull(dao.Rows(dong)("TienAnTC")) = False Then
            dto.TienAnTC = dao.Rows(dong)("TienAnTc")
        End If
       
        If IsDBNull(dao.Rows(dong)("TienComTrua")) = False Then
            dto.TienComTrua = dao.Rows(dong)("TienComTrua")
        End If
        If IsDBNull(dao.Rows(dong)("SuatAnTrua")) = False Then
            dto.SuatAnTrua = dao.Rows(dong)("SuatAnTrua")
        End If
        If IsDBNull(dao.Rows(dong)("NgayCN")) = False Then
            dto.NgayCN = dao.Rows(dong)("NgayCN")
        End If
        If IsDBNull(dao.Rows(dong)("LuongCN")) = False Then
            dto.LuongCN = dao.Rows(dong)("LuongCN")
        End If
        If IsDBNull(dao.Rows(dong)("Solanditre")) = False Then
            dto.Solanditre = dao.Rows(dong)("Solanditre")
        End If
        If IsDBNull(dao.Rows(dong)("Phatditre")) = False Then
            dto.Phatditre = dao.Rows(dong)("Phatditre")
        End If
        If IsDBNull(dao.Rows(dong)("Solannghikophep")) = False Then
            dto.Solannghikophep = dao.Rows(dong)("Solannghikophep")
        End If

        If IsDBNull(dao.Rows(dong)("phatnghikophep")) = False Then
            dto.phatnghikophep = dao.Rows(dong)("phatnghikophep")
        End If
        If IsDBNull(dao.Rows(dong)("PhanTramBH")) = False Then
            dto.PhanTramBH = dao.Rows(dong)("PhanTramBH")
        End If
        If IsDBNull(dao.Rows(dong)("TienBH")) = False Then
            dto.TienBH = dao.Rows(dong)("TienBH")
        End If
        If IsDBNull(dao.Rows(dong)("Phucap2")) = False Then
            dto.Phucap2 = dao.Rows(dong)("Phucap2")
        End If
        If IsDBNull(dao.Rows(dong)("NgayGuiXe")) = False Then
            dto.NgayGuiXe = dao.Rows(dong)("NgayGuiXe")
        End If
        If IsDBNull(dao.Rows(dong)("TienGuiXe")) = False Then
            dto.TienGuiXe = dao.Rows(dong)("TienGuiXe")
        End If
        If IsDBNull(dao.Rows(dong)("TongTienXe")) = False Then
            dto.TongTienXe = dao.Rows(dong)("TongTienXe")
        End If
        
        If IsDBNull(dao.Rows(dong)("ChuyenCan")) = False Then
            dto.ChuyenCan = dao.Rows(dong)("ChuyenCan")
        End If
        Return dto
    End Function
End Class

