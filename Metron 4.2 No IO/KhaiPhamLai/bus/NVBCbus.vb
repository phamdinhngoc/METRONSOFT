Imports System.Data
Public Class NVBCBus
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
    Public Function LayBangNhanVienBaoCao() As DataTable
        Dim sql As String = "select NhanVien.TenHT, NVBC.* from NhanVien , NVBC where NhanVien.Manv = NVBC.Macc order by NhanVien.TenHt"
        Dim Dao As New AbstractDao(sql, sql, ketnoi, MSsql)
        Return Dao
    End Function
    Public Sub Them(ByVal Dto As NVBCdto, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenGhi = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As NVBCDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New NVBCDao(ketnoiConnection)
        Else
            Dao = New NVBCDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.Them(Dto, MSsql)
    End Sub
    Public Sub Xoa(ByVal ma As Integer, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenXoa = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As NVBCDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New NVBCDao(ketnoiConnection)
        Else
            Dao = New NVBCDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.Xoa(ma, MSsql)
    End Sub
    Public Sub XoaALL(Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenXoa = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As NVBCDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New NVBCDao(ketnoiConnection)
        Else
            Dao = New NVBCDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.XoaALL(MSsql)
    End Sub
    Public Sub sua(ByVal Dto As NVBCdto, Optional ByVal ChuoiThongBaoLoi As String = "")
        If QuyenSua = False Then
            MsgBox(ChuoiThongBaoLoi, MsgBoxStyle.Critical, "Thông Báo")
            Exit Sub
        End If
        Dim Dao As NVBCDao
        If ketnoi.ChuoiKetNoi = "" Then
            Dao = New NVBCDao(ketnoiConnection)
        Else
            Dao = New NVBCDao(ketnoi.ChuoiKetNoi)
        End If
        Dao.sua(Dto, MSsql)
    End Sub
#End Region
    Public Function LayBangTabletheoNv(ByVal manv As Integer) As DataTable
        Dim sql As String = "select * from NVBC where manv=" & manv
        Dim Dao As New AbstractDao(sql, sql, ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangTabletheoMaCC(ByVal macc As Integer) As DataTable
        Dim sql As String = "select * from NVBC where macc=" & macc
        Dim Dao As New AbstractDao(sql, sql, ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangTable() As DataTable
        Dim Dao As New NVBCDao(ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangTableSQL(ByVal sql As String) As DataTable
        Dim Dao As New AbstractDao(sql, sql, ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangTable(ByVal ma As Integer) As DataTable
        Dim Dao As New NVBCDao(ma, ketnoi, MSsql)
        Return Dao
    End Function
    Public Function LayBangDTo(ByVal ma As Integer) As NVBCdto
        Dim Dao As New NVBCDao(ma, ketnoi, MSsql)
        Dim dto As New NVBCdto
        If IsDBNull(Dao.Rows(0)("MaCC")) = False Then
            dto.MaCC = Dao.Rows(0)("MaCC")
        End If
        If IsDBNull(Dao.Rows(0)("MaNV")) = False Then
            dto.MaNV = Dao.Rows(0)("MaNV")
        End If
        If IsDBNull(Dao.Rows(0)("TenNV")) = False Then
            dto.TenNV = Dao.Rows(0)("TenNV")
        End If
        If IsDBNull(Dao.Rows(0)("Chucvu")) = False Then
            dto.Chucvu = Dao.Rows(0)("Chucvu")
        End If
        If IsDBNull(Dao.Rows(0)("Bophan")) = False Then
            dto.Bophan = Dao.Rows(0)("Bophan")
        End If
        Return dto
    End Function
    Public Function LayBangDTo(ByVal dong As Integer, ByVal dao As DataTable) As NVBCdto
        Dim dto As New NVBCdto
        If IsDBNull(dao.Rows(dong)("MaCC")) = False Then
            dto.MaCC = dao.Rows(dong)("MaCC")
        End If
        If IsDBNull(dao.Rows(dong)("MaNV")) = False Then
            dto.MaNV = dao.Rows(dong)("MaNV")
        End If
        If IsDBNull(dao.Rows(dong)("TenNV")) = False Then
            dto.TenNV = dao.Rows(dong)("TenNV")
        End If
        If IsDBNull(dao.Rows(dong)("Chucvu")) = False Then
            dto.Chucvu = dao.Rows(dong)("Chucvu")
        End If
        If IsDBNull(dao.Rows(dong)("Bophan")) = False Then
            dto.Bophan = dao.Rows(dong)("Bophan")
        End If
        Return dto
    End Function
End Class

