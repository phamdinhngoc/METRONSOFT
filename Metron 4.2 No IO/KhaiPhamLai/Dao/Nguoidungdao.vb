 Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class NguoidungDao
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
        MyBase.New("Nguoidung", connection, MSsql)
    End Sub
    Public Sub New(ByVal ma As String, ByVal connection As KetNoiDto, ByVal MSsql As Boolean)
        MyBase.New("Nguoidung", "select * from Nguoidung where userID='" & ma & "'", connection, MSsql)
    End Sub
#End Region
    Public Sub Them(ByVal Dto As Nguoidungdto, ByVal MSsql As Boolean)
        Dim strsql As String
        strsql = "Insert into Nguoidung(userID,pass,Quyen,Cauhoi1,Traloi1,Cauhoi2,Traloi2) values (?,?,?,?,?,?,?)"
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then Ket_noi.Open()
            Dim cmd As New OleDbCommand(strsql, Ket_noi)
            cmd.Parameters.Add("@userID", OleDbType.WChar)
            cmd.Parameters.Add("@pass", OleDbType.WChar)
            cmd.Parameters.Add("@Quyen", OleDbType.WChar)
            cmd.Parameters.Add("@Cauhoi1", OleDbType.WChar)
            cmd.Parameters.Add("@Traloi1", OleDbType.WChar)
            cmd.Parameters.Add("@Cauhoi2", OleDbType.WChar)
            cmd.Parameters.Add("@Traloi2", OleDbType.WChar)
            cmd.Parameters("@userID").Value = Dto.userID
            cmd.Parameters("@pass").Value = Dto.pass
            cmd.Parameters("@Quyen").Value = Dto.Quyen
            cmd.Parameters("@Cauhoi1").Value = Dto.Cauhoi1
            cmd.Parameters("@Traloi1").Value = Dto.Traloi1
            cmd.Parameters("@Cauhoi2").Value = Dto.Cauhoi2
            cmd.Parameters("@Traloi2").Value = Dto.Traloi2
            cmd.ExecuteNonQuery()
            'strsql = "Select @@IDENTITY"
            'cmd = New OleDbCommand(strsql, Ket_noi)
            'Dto.userID = cmd.ExecuteScalar()
            If Ket_noi.State = ConnectionState.Open Then Ket_noi.Close()
        Else
            strsql = "Insert into Nguoidung(userID,pass,Quyen,Cauhoi1,Traloi1,Cauhoi2,Traloi2) values ('" & Dto.userID & "','" & Dto.pass & "','" & Dto.Quyen & "','" & Dto.Cauhoi1 & "','" & Dto.Traloi1 & "','" & Dto.Cauhoi2 & "','" & Dto.Traloi2 & "')"
            Ket_noi1.Open()
            Dim cmd1 As New SqlCommand(strsql, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
        Dim daoNK As New NhatkyDao
        Dim dtoNK As New Nhatkydto

        dtoNK.User = TenNguoiDangNhap
        dtoNK.Ngay = Date.Now.Date
        dtoNK.Gio = Date.Now
        dtoNK.Tacvu = "Thêm Người dùng mới với tên là:" & Dto.userID
        daoNK.Them(dtoNK, False)
    End Sub
    Public Sub Xoa(ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then Ket_noi.Open()
            strSQL = "Delete From Nguoidung Where userID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@ma", OleDbType.WChar)
            cmd.Parameters("@ma").Value = ma
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Delete From Nguoidung Where userID='" & ma & "'"
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
        Dim daoNK As New NhatkyDao
        Dim dtoNK As New Nhatkydto

        dtoNK.User = TenNguoiDangNhap
        dtoNK.Ngay = Date.Now.Date
        dtoNK.Gio = Date.Now
        dtoNK.Tacvu = "Xoá Người dùng có tên là " & ma
        daoNK.Them(dtoNK, False)
    End Sub
    Public Sub sua(ByVal dto As Nguoidungdto, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then Ket_noi.Open()
            strSQL = "Update Nguoidung Set pass=? ,Quyen=? ,Cauhoi1=? ,Traloi1=? ,Cauhoi2=? ,Traloi2= ? where userID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@pass", OleDbType.WChar)
            cmd.Parameters.Add("@Quyen", OleDbType.WChar)
            cmd.Parameters.Add("@Cauhoi1", OleDbType.WChar)
            cmd.Parameters.Add("@Traloi1", OleDbType.WChar)
            cmd.Parameters.Add("@Cauhoi2", OleDbType.WChar)
            cmd.Parameters.Add("@Traloi2", OleDbType.WChar)
            cmd.Parameters.Add("@userID", OleDbType.WChar)
            cmd.Parameters("@pass").Value = dto.pass
            cmd.Parameters("@Quyen").Value = dto.Quyen
            cmd.Parameters("@Cauhoi1").Value = dto.Cauhoi1
            cmd.Parameters("@Traloi1").Value = dto.Traloi1
            cmd.Parameters("@Cauhoi2").Value = dto.Cauhoi2
            cmd.Parameters("@Traloi2").Value = dto.Traloi2
            cmd.Parameters("@userID").Value = dto.userID
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update Nguoidung Set pass= '" & dto.pass & "',Quyen= '" & dto.Quyen & "',Cauhoi1= '" & dto.Cauhoi1 & "',Traloi1= '" & dto.Traloi1 & "',Cauhoi2= '" & dto.Cauhoi2 & "',Traloi2= '" & dto.Traloi2 & "' where userID='" & dto.userID & "'"
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
        Dim daoNK As New NhatkyDao
        Dim dtoNK As New Nhatkydto

        dtoNK.User = TenNguoiDangNhap
        dtoNK.Ngay = Date.Now.Date
        dtoNK.Gio = Date.Now
        dtoNK.Tacvu = "Sửa Người dùng có mã là " & dto.userID
        daoNK.Them(dtoNK, False)
    End Sub
    Public Function KiemtraQuyen(ByVal quyen As String) As Integer
        Try
            Dim cmd As New OleDbCommand
            Dim strsql As String = "Select count(*) from nguoidung where quyen='" & quyen & "'"
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            cmd = New OleDbCommand(strsql, Ket_noi)
            Return cmd.ExecuteScalar()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If

        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
End Class

