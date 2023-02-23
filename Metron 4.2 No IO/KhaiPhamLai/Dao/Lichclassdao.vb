 Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class LichclassDao
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
        MyBase.New("Lichclass", connection, MSsql)
    End Sub
    Public Sub New(ByVal ma As Integer, ByVal connection As KetNoiDto, ByVal MSsql As Boolean)
        MyBase.New("Lichclass", "select * from Lichclass where ID=" & ma & "", connection, MSsql)
    End Sub
#End Region
    Public Sub Them(ByVal Dto As Lichclassdto, ByVal MSsql As Boolean)
        Dim strsql As String
        Dim BatTat As Boolean = False
        strsql = "Insert into Lichclass(LichID,SThu,EThu,caid) values (?,?,?,?)"
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            Dim cmd As New OleDbCommand(strsql, Ket_noi)
            cmd.Parameters.Add("@LichID", OleDbType.Integer)
            cmd.Parameters.Add("@SThu", OleDbType.Integer)
            cmd.Parameters.Add("@EThu", OleDbType.Integer)
            cmd.Parameters.Add("@caid", OleDbType.Integer)
            cmd.Parameters("@LichID").Value = Dto.LichID
            cmd.Parameters("@SThu").Value = Dto.SThu
            cmd.Parameters("@EThu").Value = Dto.EThu
            cmd.Parameters("@caid").Value = Dto.caid
            cmd.ExecuteNonQuery()
            strsql = "Select @@IDENTITY"
            cmd = New OleDbCommand(strsql, Ket_noi)
            Dto.ID = cmd.ExecuteScalar()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            strsql = "Insert into Lichclass(LichID,SThu,EThu,caid) values (" & Dto.LichID & "," & Dto.SThu & "," & Dto.EThu & "," & Dto.caid & ")"
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
            strSQL = "Delete From Lichclass Where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@ma", OleDbType.Integer)
            cmd.Parameters("@ma").Value = ma
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            Ket_noi1.Open()
            strSQL = "Delete From Lichclass Where ID=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub XoaTheoLich(ByVal LichId As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        Dim BatTat As Boolean = False
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            strSQL = "Delete From Lichclass Where LichID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@ma", OleDbType.Integer)
            cmd.Parameters("@ma").Value = LichId
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            Ket_noi1.Open()
            strSQL = "Delete From Lichclass Where LichID=" & LichId & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub sua(ByVal dto As Lichclassdto, ByVal MSsql As Boolean)
        Dim strSQL As String
        Dim BatTat As Boolean = False
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            strSQL = "Update Lichclass Set LichID=? ,SThu=? ,EThu=? ,caid= ? where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@LichID", OleDbType.Integer)
            cmd.Parameters.Add("@SThu", OleDbType.Integer)
            cmd.Parameters.Add("@EThu", OleDbType.Integer)
            cmd.Parameters.Add("@caid", OleDbType.Integer)
            cmd.Parameters.Add("@ID", OleDbType.Integer)
            cmd.Parameters("@LichID").Value = dto.LichID
            cmd.Parameters("@SThu").Value = dto.SThu
            cmd.Parameters("@EThu").Value = dto.EThu
            cmd.Parameters("@caid").Value = dto.caid
            cmd.Parameters("@ID").Value = dto.ID
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            Ket_noi1.Open()
            strSQL = "Update Lichclass Set LichID= " & dto.LichID & ",SThu= " & dto.SThu & ",EThu= " & dto.EThu & ",caid= " & dto.caid & " where ID=" & dto.ID & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaLichID(ByVal LichID As Integer, ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            Ket_noi.Open()
            strSQL = "Update Lichclass Set LichID = ?  where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@LichID", OleDbType.Integer)
            cmd.Parameters.Add("@ID", OleDbType.Integer)
            cmd.Parameters("@LichID").Value = LichID
            cmd.Parameters("@ID").Value = ma
            cmd.ExecuteNonQuery()
            Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update Lichclass Set LichID =" & LichID & "  where ID=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaSThu(ByVal SThu As Integer, ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            Ket_noi.Open()
            strSQL = "Update Lichclass Set SThu = ?  where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@SThu", OleDbType.Integer)
            cmd.Parameters.Add("@ID", OleDbType.Integer)
            cmd.Parameters("@SThu").Value = SThu
            cmd.Parameters("@ID").Value = ma
            cmd.ExecuteNonQuery()
            Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update Lichclass Set SThu =" & SThu & "  where ID=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaEThu(ByVal EThu As Integer, ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            Ket_noi.Open()
            strSQL = "Update Lichclass Set EThu = ?  where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@EThu", OleDbType.Integer)
            cmd.Parameters.Add("@ID", OleDbType.Integer)
            cmd.Parameters("@EThu").Value = EThu
            cmd.Parameters("@ID").Value = ma
            cmd.ExecuteNonQuery()
            Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update Lichclass Set EThu =" & EThu & "  where ID=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub Suacaid(ByVal caid As Integer, ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            Ket_noi.Open()
            strSQL = "Update Lichclass Set caid = ?  where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@caid", OleDbType.Integer)
            cmd.Parameters.Add("@ID", OleDbType.Integer)
            cmd.Parameters("@caid").Value = caid
            cmd.Parameters("@ID").Value = ma
            cmd.ExecuteNonQuery()
            Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update Lichclass Set caid =" & caid & "  where ID=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
End Class

