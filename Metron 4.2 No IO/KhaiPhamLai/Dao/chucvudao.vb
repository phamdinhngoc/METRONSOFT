 Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class chucvuDao
    Inherits AbstractDao
#Region "New"
    Public Sub New()
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
        MyBase.New("chucvu", connection, MSsql)
    End Sub
    Public Sub New(ByVal ma As Integer, ByVal connection As KetNoiDto, ByVal MSsql As Boolean)
        MyBase.New("chucvu", "select * from chucvu where CVID=" & ma & "", connection, MSsql)
    End Sub
#End Region
    Public Sub Them(ByVal Dto As chucvudto, ByVal MSsql As Boolean)
        Dim strsql As String
        Dim BatTat As Boolean = False
        strsql = "Insert into chucvu(Chucvu) values (?)"
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            Dim cmd As New OleDbCommand(strsql, Ket_noi)
            cmd.Parameters.Add("@Chucvu", OleDbType.WChar)
            cmd.Parameters("@Chucvu").Value = Dto.Chucvu
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            strsql = "Insert into chucvu(CVID,Chucvu) values (" & Dto.CVID & ",'" & Dto.Chucvu & "')"
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
        dtoNK.Tacvu = "Thêm chức vụ với Mã Chức vụ:" & Dto.CVID & " và Tên Chức vụ:" & Dto.Chucvu
        daoNK.Them(dtoNK, False)
    End Sub
    Public Sub Xoa(ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            strSQL = "Delete From chucvu Where CVID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@ma", OleDbType.Integer)
            cmd.Parameters("@ma").Value = ma
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            Ket_noi1.Open()
            strSQL = "Delete From chucvu Where CVID=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
        Dim daoNK As New NhatkyDao
        Dim dtoNK As New Nhatkydto

        dtoNK.User = TenNguoiDangNhap
        dtoNK.Ngay = Date.Now.Date
        dtoNK.Gio = Date.Now
        dtoNK.Tacvu = "Xoá chức vụ có Mã là:" & ma
        daoNK.Them(dtoNK, False)
    End Sub
    Public Sub sua(ByVal dto As chucvudto, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            strSQL = "Update chucvu Set Chucvu= ? where CVID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@Chucvu", OleDbType.WChar)
            cmd.Parameters.Add("@CVID", OleDbType.Integer)
            cmd.Parameters("@Chucvu").Value = dto.Chucvu
            cmd.Parameters("@CVID").Value = dto.CVID
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            Ket_noi1.Open()
            strSQL = "Update chucvu Set Chucvu= '" & dto.Chucvu & "' where CVID=" & dto.CVID & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
        Dim daoNK As New NhatkyDao
        Dim dtoNK As New Nhatkydto

        dtoNK.User = TenNguoiDangNhap
        dtoNK.Ngay = Date.Now.Date
        dtoNK.Gio = Date.Now
        dtoNK.Tacvu = "Sửa chức vụ có Mã là " & dto.CVID
        daoNK.Them(dtoNK, False)
    End Sub
End Class

