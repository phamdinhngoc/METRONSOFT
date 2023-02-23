 Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class donviDao
    Inherits AbstractDao
#Region "New"
    Public Sub New()
        MyBase.New()
    End Sub
    Public Sub New(ByVal connection As OleDb.OleDbConnection)
        If Ket_noi.State = ConnectionState.Closed Then
            Ket_noi = connection
        End If
    End Sub
    Public Sub New(ByVal connectionString As String)
        If Ket_noi.State = ConnectionState.Closed Then
            Ket_noi.ConnectionString = connectionString
        End If
    End Sub
    Public Sub New(ByVal connection As KetNoiDto, ByVal MSsql As Boolean)
        MyBase.New("donvi", connection, MSsql)
    End Sub
    Public Sub New(ByVal ma As Integer, ByVal connection As KetNoiDto, ByVal MSsql As Boolean)
        MyBase.New("donvi", "select * from donvi where MaDV=" & ma & "", connection, MSsql)
    End Sub
#End Region
    Public Sub Them(ByVal Dto As donvidto, ByVal MSsql As Boolean)
        Dim strsql As String
        strsql = "Insert into donvi(TenDV,Nhanh) values (?,?)"
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then    Ket_noi.Open()
            Dim cmd As New OleDbCommand(strsql, Ket_noi)
            cmd.Parameters.Add("@TenDV", OleDbType.WChar)
            cmd.Parameters.Add("@Nhanh", OleDbType.Integer)
            cmd.Parameters("@TenDV").Value = Dto.TenDV
            cmd.Parameters("@Nhanh").Value = Dto.Nhanh
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then Ket_noi.Close()
        Else
            strsql = "Insert into donvi(TenDV,Nhanh) values ('" & Dto.TenDV & "'," & Dto.Nhanh & ")"
            Ket_noi1.Open()
            Dim cmd1 As New SqlCommand(strsql, Ket_noi1)
            Dto.MaDV = cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
        Dim daoNK As New NhatkyDao
        Dim dtoNK As New Nhatkydto
        dtoNK.User = TenNguoiDangNhap
        dtoNK.Ngay = Date.Now.Date
        dtoNK.Gio = Date.Now
        dtoNK.Tacvu = "Thêm Đơn vị có tên đơn vị là:" & Dto.TenDV
        daoNK.Them(dtoNK, False)
    End Sub
    Public Sub Xoa(ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then Ket_noi.Open()
            strSQL = "Delete From donvi Where MaDV= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@ma", OleDbType.Integer)
            cmd.Parameters("@ma").Value = ma
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Delete From donvi Where MaDV=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
        Dim daoNK As New NhatkyDao
        Dim dtoNK As New Nhatkydto

        dtoNK.User = TenNguoiDangNhap
        dtoNK.Ngay = Date.Now.Date
        dtoNK.Gio = Date.Now
        dtoNK.Tacvu = "Xoá Đơn vị có mã là :" & ma
        daoNK.Them(dtoNK, False)
    End Sub
    Public Sub sua(ByVal dto As donvidto, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then Ket_noi.Open()
            strSQL = "Update donvi Set TenDV=? where MaDV= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@TenDV", OleDbType.WChar)
            cmd.Parameters.Add("@MaDV", OleDbType.Integer)
            cmd.Parameters("@TenDV").Value = dto.TenDV
            cmd.Parameters("@MaDV").Value = dto.MaDV
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update donvi Set TenDV= '" & dto.TenDV & "' where MaDV=" & dto.MaDV & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
        Dim daoNK As New NhatkyDao
        Dim dtoNK As New Nhatkydto

        dtoNK.User = TenNguoiDangNhap
        dtoNK.Ngay = Date.Now.Date
        dtoNK.Gio = Date.Now
        dtoNK.Tacvu = "Sửa Đơn vị có mã là" & dto.MaDV & "và có tên mới là" & dto.TenDV
        daoNK.Them(dtoNK, False)
    End Sub
    Public Sub SuaNhanh(ByVal Nhanh As Integer, ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            Ket_noi.Open()
            strSQL = "Update donvi Set Nhanh = ?  where MaDV= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@Nhanh", OleDbType.Integer)
            cmd.Parameters.Add("@MaDV", OleDbType.Integer)
            cmd.Parameters("@Nhanh").Value = Nhanh
            cmd.Parameters("@MaDV").Value = ma
            cmd.ExecuteNonQuery()
            Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update donvi Set Nhanh =" & Nhanh & "  where MaDV=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
End Class

