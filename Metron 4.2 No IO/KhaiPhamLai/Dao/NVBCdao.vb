 Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class NVBCDao
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
        MyBase.New("NVBC", connection, MSsql)
    End Sub
    Public Sub New(ByVal ma As Integer, ByVal connection As KetNoiDto, ByVal MSsql As Boolean)
        MyBase.New("NVBC", "select * from NVBC where MaCC=" & ma & "", connection, MSsql)
    End Sub
#End Region
    Public Sub Them(ByVal Dto As NVBCdto, ByVal MSsql As Boolean)
        Dim strsql As String
        Dim BatTat As Boolean = False
        strsql = "Insert into NVBC(MaCC,MaNV,TenNV,Chucvu,Bophan) values (?,?,?,?,?)"
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            Dim cmd As New OleDbCommand(strsql, Ket_noi)
            cmd.Parameters.Add("@MaCC", OleDbType.Integer)
            cmd.Parameters.Add("@MaNV", OleDbType.WChar)
            cmd.Parameters.Add("@TenNV", OleDbType.WChar)
            cmd.Parameters.Add("@Chucvu", OleDbType.WChar)
            cmd.Parameters.Add("@Bophan", OleDbType.WChar)
            cmd.Parameters("@MaCC").Value = Dto.MaCC
            cmd.Parameters("@MaNV").Value = Dto.MaNV
            cmd.Parameters("@TenNV").Value = Dto.TenNV
            cmd.Parameters("@Chucvu").Value = Dto.Chucvu
            cmd.Parameters("@Bophan").Value = Dto.Bophan
            cmd.ExecuteNonQuery()
            'strsql = "Select @@IDENTITY"
            'cmd = New OleDbCommand(strsql, Ket_noi)
            'Dto.MaCC = cmd.ExecuteScalar()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            strsql = "Insert into NVBC(MaCC,MaNV,TenNV,Chucvu,Bophan) values (" & Dto.MaCC & ",'" & Dto.MaNV & "','" & Dto.TenNV & "','" & Dto.Chucvu & "','" & Dto.Bophan & "')"
            Ket_noi1.Open()
            Dim cmd1 As New SqlCommand(strsql, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub Xoa(ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        Dim BatTat As Boolean = False
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            strSQL = "Delete From NVBC Where MaCC= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@ma", OleDbType.Integer)
            cmd.Parameters("@ma").Value = ma
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            Ket_noi1.Open()
            strSQL = "Delete From NVBC Where MaCC=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub XoaALL(ByVal MSsql As Boolean)
        Dim strSQL As String
        Dim BatTat As Boolean = False
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            strSQL = "Delete * From NVBC "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            Ket_noi1.Open()
            strSQL = "Delete * From NVBC"
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub sua(ByVal dto As NVBCdto, ByVal MSsql As Boolean)
        Dim strSQL As String
        Dim BatTat As Boolean = False
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            strSQL = "Update NVBC Set MaNV=? ,TenNV=? ,Chucvu=? ,Bophan= ? where MaCC= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@MaNV", OleDbType.WChar)
            cmd.Parameters.Add("@TenNV", OleDbType.WChar)
            cmd.Parameters.Add("@Chucvu", OleDbType.WChar)
            cmd.Parameters.Add("@Bophan", OleDbType.WChar)
            cmd.Parameters.Add("@MaCC", OleDbType.Integer)
            cmd.Parameters("@MaNV").Value = dto.MaNV
            cmd.Parameters("@TenNV").Value = dto.TenNV
            cmd.Parameters("@Chucvu").Value = dto.Chucvu
            cmd.Parameters("@Bophan").Value = dto.Bophan
            cmd.Parameters("@MaCC").Value = dto.MaCC
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            Ket_noi1.Open()
            strSQL = "Update NVBC Set MaNV= '" & dto.MaNV & "',TenNV= '" & dto.TenNV & "',Chucvu= '" & dto.Chucvu & "',Bophan= '" & dto.Bophan & "' where MaCC=" & dto.MaCC & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
End Class

