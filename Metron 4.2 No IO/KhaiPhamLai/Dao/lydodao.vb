Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class lydoDao
    Inherits AbstractDao
#Region "New"
    Public Sub New()
        MyBase.New()
    End Sub
    Public Sub New(ByVal connection As OleDb.OleDbConnection)
        Ket_noi = connection
    End Sub
    Public Sub New(ByVal connectionString As String)
        If Ket_noi.State = ConnectionState.Closed Then
            Ket_noi.ConnectionString = connectionString
        End If
    End Sub
    Public Sub New(ByVal connection As KetNoiDto, ByVal MSsql As Boolean)
        MyBase.New("lydo", connection, MSsql)
    End Sub
    Public Sub New(ByVal ma As Integer, ByVal connection As KetNoiDto, ByVal MSsql As Boolean)
        MyBase.New("lydo", "select * from lydo where IDLD=" & ma & "", connection, MSsql)
    End Sub
#End Region
    Public Sub Them(ByVal Dto As lydodto, ByVal MSsql As Boolean)
        Dim strsql As String
        strsql = "Insert into lydo(Lydo,NgayQD,SoCong) values (?,?,?)"
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            Dim cmd As New OleDbCommand(strsql, Ket_noi)
            cmd.Parameters.Add("@Lydo", OleDbType.WChar)
            cmd.Parameters.Add("@NgayQD", OleDbType.Double)
            cmd.Parameters.Add("@SoCong", OleDbType.Double)
            cmd.Parameters("@Lydo").Value = Dto.Lydo
            cmd.Parameters("@NgayQD").Value = Dto.NgayQD
            cmd.Parameters("@SoCong").Value = Dto.SoCong
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            strsql = "Insert into lydo(Lydo,NgayQD,SoCong) values ('" & Dto.Lydo & "'," & Dto.NgayQD & "," & Dto.SoCong & ")"
            Ket_noi1.Open()
            Dim cmd1 As New SqlCommand(strsql, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub Xoa(ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            strSQL = "Delete From lydo Where IDLD= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@ma", OleDbType.Integer)
            cmd.Parameters("@ma").Value = ma
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            Ket_noi1.Open()
            strSQL = "Delete From lydo Where IDLD=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub sua(ByVal dto As lydodto, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            strSQL = "Update lydo Set Lydo=? ,NgayQD=? ,SoCong= ? where IDLD= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@Lydo", OleDbType.WChar)
            cmd.Parameters.Add("@NgayQD", OleDbType.Double)
            cmd.Parameters.Add("@SoCong", OleDbType.Double)
            cmd.Parameters.Add("@IDLD", OleDbType.Integer)
            cmd.Parameters("@Lydo").Value = dto.Lydo
            cmd.Parameters("@NgayQD").Value = dto.NgayQD
            cmd.Parameters("@SoCong").Value = dto.SoCong
            cmd.Parameters("@IDLD").Value = dto.IDLD
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            Ket_noi1.Open()
            strSQL = "Update lydo Set Lydo= '" & dto.Lydo & "',NgayQD= " & dto.NgayQD & ",SoCong= " & dto.SoCong & " where IDLD=" & dto.IDLD & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaNgayQD(ByVal NgayQD As Integer, ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            Ket_noi.Open()
            strSQL = "Update lydo Set NgayQD = ?  where IDLD= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@NgayQD", OleDbType.Integer)
            cmd.Parameters.Add("@IDLD", OleDbType.Integer)
            cmd.Parameters("@NgayQD").Value = NgayQD
            cmd.Parameters("@IDLD").Value = ma
            cmd.ExecuteNonQuery()
            Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update lydo Set NgayQD =" & NgayQD & "  where IDLD=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaSoCong(ByVal SoCong As Integer, ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            Ket_noi.Open()
            strSQL = "Update lydo Set SoCong = ?  where IDLD= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@SoCong", OleDbType.Integer)
            cmd.Parameters.Add("@IDLD", OleDbType.Integer)
            cmd.Parameters("@SoCong").Value = SoCong
            cmd.Parameters("@IDLD").Value = ma
            cmd.ExecuteNonQuery()
            Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update lydo Set SoCong =" & SoCong & "  where IDLD=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
End Class

