Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class QuyenChiTietDao
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
        MyBase.New("QuyenChiTiet", connection, MSsql)
    End Sub
    Public Sub New(ByVal max As Boolean, ByVal connection As KetNoiDto, ByVal MSsql As Boolean)
        MyBase.New("QuyenChiTiet", "select max(id) from QuyenChiTiet", connection, MSsql)
    End Sub
    Public Sub New(ByVal ma As Integer, ByVal connection As KetNoiDto, ByVal MSsql As Boolean)
        MyBase.New("QuyenChiTiet", "select * from QuyenChiTiet where iD=" & ma & "", connection, MSsql)
    End Sub
#End Region
    Public Sub Them(ByVal Dto As QuyenChiTietdto, ByVal MSsql As Boolean)
        Dim strsql As String
        Dim BatTat As Boolean = False
        strsql = "Insert into QuyenChiTiet(Quyen,TenForm,TenButon) values (?,?,?)"
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            Dim cmd As New OleDbCommand(strsql, Ket_noi)
            cmd.Parameters.Add("@Quyen", OleDbType.Integer)
            cmd.Parameters.Add("@TenForm", OleDbType.WChar)
            cmd.Parameters.Add("@TenButon", OleDbType.WChar)
            cmd.Parameters("@Quyen").Value = Dto.Quyen
            cmd.Parameters("@TenForm").Value = Dto.TenForm
            cmd.Parameters("@TenButon").Value = Dto.TenButon
            cmd.ExecuteNonQuery()
            strsql = "Select @@IDENTITY"
            cmd = New OleDbCommand(strsql, Ket_noi)
            Dto.iD = cmd.ExecuteScalar()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            strsql = "Insert into QuyenChiTiet(Quyen,TenForm,TenButon) values (" & Dto.Quyen & ",'" & Dto.TenForm & "','" & Dto.TenButon & "')"
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
            strSQL = "Delete From QuyenChiTiet Where iD= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@ma", OleDbType.Integer)
            cmd.Parameters("@ma").Value = ma
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            Ket_noi1.Open()
            strSQL = "Delete From QuyenChiTiet Where iD=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub Xoa(ByVal Quyen As String, ByVal Tenform As String, ByVal tenbutton As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        Dim BatTat As Boolean = False
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            strSQL = "Delete From QuyenChiTiet Where Quyen= ? and TenForm=? and TenButon=?"
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@Quyen", OleDbType.Integer)
            cmd.Parameters.Add("@TenForm", OleDbType.WChar)
            cmd.Parameters.Add("@TenButon", OleDbType.WChar)
            cmd.Parameters("@Quyen").Value = Quyen
            cmd.Parameters("@TenForm").Value = Tenform
            cmd.Parameters("@TenButon").Value = tenbutton
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            Ket_noi1.Open()
            strSQL = "Delete From QuyenChiTiet Where Quyen= " & Quyen & " and TenForm='" & Tenform & "' and TenButon='" & tenbutton & "'"
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub XoaQuyen(ByVal Quyen As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        Dim BatTat As Boolean = False
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            strSQL = "Delete From QuyenChiTiet Where quyen= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@ma", OleDbType.Integer)
            cmd.Parameters("@ma").Value = Quyen
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            Ket_noi1.Open()
            strSQL = "Delete From QuyenChiTiet Where quyen=" & Quyen & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub sua(ByVal dto As QuyenChiTietdto, ByVal MSsql As Boolean)
        Dim strSQL As String
        Dim BatTat As Boolean = False
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            strSQL = "Update QuyenChiTiet Set Quyen=? ,TenForm=? ,TenButon= ? where iD= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@Quyen", OleDbType.Integer)
            cmd.Parameters.Add("@TenForm", OleDbType.WChar)
            cmd.Parameters.Add("@TenButon", OleDbType.WChar)
            cmd.Parameters.Add("@iD", OleDbType.Integer)
            cmd.Parameters("@Quyen").Value = dto.Quyen
            cmd.Parameters("@TenForm").Value = dto.TenForm
            cmd.Parameters("@TenButon").Value = dto.TenButon
            cmd.Parameters("@iD").Value = dto.iD
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            Ket_noi1.Open()
            strSQL = "Update QuyenChiTiet Set Quyen= " & dto.Quyen & ",TenForm= '" & dto.TenForm & "',TenButon= '" & dto.TenButon & "' where iD=" & dto.iD & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaQuyen(ByVal Quyen As Integer, ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            Ket_noi.Open()
            strSQL = "Update QuyenChiTiet Set Quyen = ?  where iD= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@Quyen", OleDbType.Integer)
            cmd.Parameters.Add("@iD", OleDbType.Integer)
            cmd.Parameters("@Quyen").Value = Quyen
            cmd.Parameters("@iD").Value = ma
            cmd.ExecuteNonQuery()
            Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update QuyenChiTiet Set Quyen =" & Quyen & "  where iD=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
End Class

