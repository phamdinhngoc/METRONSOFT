Imports System.Data

Public Class NVnghiphepBus
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
    Public Sub Them(ByVal Dto As NVnghiphepdto, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenGhi = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As NVnghiphepDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New NVnghiphepDao(ketnoiConnection)
        Else
            Dao = New NVnghiphepDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.Them(Dto, MSsql)
    End Sub
    Public Sub Xoa(ByVal ma As Integer, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenXoa = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As NVnghiphepDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New NVnghiphepDao(ketnoiConnection)
        Else
            Dao = New NVnghiphepDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.Xoa(ma, MSsql)
    End Sub
    Public Sub sua(ByVal Dto As NVnghiphepdto, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenSua = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As NVnghiphepDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New NVnghiphepDao(ketnoiConnection)
        Else
            Dao = New NVnghiphepDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.sua(Dto, MSsql)
    End Sub
#End Region
    Public Function LaybangTheoNvidTungayDenNgay(ByVal manv As Integer, ByVal tungay As Date, ByVal dengay As Date) As DataTable
        Dim Dao As New NVnghiphepDao
        Dao.LaybangTheoNvidTungayDenNgay(manv, tungay, dengay)
        Return Dao
    End Function
    Public Function Tong_socongTheoNvidTungayDenNgay(ByVal manv As Integer, ByVal tungay As Date, ByVal dengay As Date) As DataTable
        Dim Dao As New NVnghiphepDao
        Dao.TongCongTheoNvidTungayDenNgay(manv, tungay, dengay)
        Return Dao
    End Function
    Public Function LaybangTheoTungayDenNgay(ByVal tungay As Date, ByVal dengay As Date) As DataTable
        Dim Dao As New NVnghiphepDao
        Dao.LaybangTheoTungayDenNgay(tungay, dengay)
        Return Dao
    End Function
    Public Function LaybangTheoTungayDenNgayVaDieuKien(ByVal tungay As Date, ByVal dengay As Date) As DataTable
        Dim Dao As New NVnghiphepDao
        Dao.LaybangTheoTungayDenNgayvaDieukien(tungay, dengay)
        Return Dao
    End Function
    Public Function LayBangTabletheoNvid(ByVal manv As Integer) As DataTable
        Dim sql As String = "select * from NVnghiphep where manv=" & manv
        Dim Dao As New AbstractDao(sql, sql, ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangTable() As DataTable
        Dim Dao As New NVnghiphepDao(ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangTableSQL(ByVal sql As String) As DataTable
        Dim Dao As New AbstractDao(sql, sql, ketnoi, MSsql)
        Return Dao
    End Function
    Public Sub suaMaNV(ByVal MaNV As Integer, ByVal ma As String)
        Dim dao As New NVnghiphepDao
        dao.SuaMaNV(MaNV, ma, MSsql)
    End Sub
    Public Sub suaSoNgay(ByVal SoNgay As Integer, ByVal ma As String)
        Dim dao As New NVnghiphepDao
        dao.SuaSoNgay(SoNgay, ma, MSsql)
    End Sub
    Public Sub suaSoCong(ByVal SoCong As Integer, ByVal ma As String)
        Dim dao As New NVnghiphepDao
        dao.SuaSoCong(SoCong, ma, MSsql)
    End Sub
    Public Function LayBangTable(ByVal ma As Integer) As DataTable
        Dim Dao As New NVnghiphepDao(ma, ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangDTo(ByVal ma As Integer) As NVnghiphepdto
        Dim Dao As New NVnghiphepDao(ma, ketnoi, MSsql)
        Dim dto As New NVnghiphepdto
        If IsDBNull(Dao.Rows(0)("IDNP")) = False Then
            dto.IDNP = Dao.Rows(0)("IDNP")
        End If
        If IsDBNull(Dao.Rows(0)("MaNV")) = False Then
            dto.MaNV = Dao.Rows(0)("MaNV")
        End If
        If IsDBNull(Dao.Rows(0)("Ngay")) = False Then
            dto.Ngay = Dao.Rows(0)("Ngay")
        End If
        If IsDBNull(Dao.Rows(0)("Lydo")) = False Then
            dto.Lydo = Dao.Rows(0)("Lydo")
        End If
        If IsDBNull(Dao.Rows(0)("SoNgay")) = False Then
            dto.SoNgay = Dao.Rows(0)("SoNgay")
        End If
        If IsDBNull(Dao.Rows(0)("SoCong")) = False Then
            dto.SoCong = Dao.Rows(0)("SoCong")
        End If
        Return dto
    End Function
    Public Function LayBangDTo(ByVal dong As Integer, ByVal dao As DataTable) As NVnghiphepdto
        Dim dto As New NVnghiphepdto
        If IsDBNull(dao.Rows(dong)("IDNP")) = False Then
            dto.IDNP = dao.Rows(dong)("IDNP")
        End If
        If IsDBNull(dao.Rows(dong)("MaNV")) = False Then
            dto.MaNV = dao.Rows(dong)("MaNV")
        End If
        If IsDBNull(dao.Rows(dong)("Ngay")) = False Then
            dto.Ngay = dao.Rows(dong)("Ngay")
        End If
        If IsDBNull(dao.Rows(dong)("Lydo")) = False Then
            dto.Lydo = dao.Rows(dong)("Lydo")
        End If
        If IsDBNull(dao.Rows(dong)("SoNgay")) = False Then
            dto.SoNgay = dao.Rows(dong)("SoNgay")
        End If
        If IsDBNull(dao.Rows(dong)("SoCong")) = False Then
            dto.SoCong = dao.Rows(dong)("SoCong")
        End If
        Return dto
    End Function
End Class

