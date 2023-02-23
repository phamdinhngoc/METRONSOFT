Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class thamsoDao
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
        MyBase.New("thamso", connection, MSsql)
    End Sub
    Public Sub New(ByVal ma As Integer, ByVal connection As KetNoiDto, ByVal MSsql As Boolean)
        MyBase.New("thamso", "select * from thamso where id=" & ma & "", connection, MSsql)
    End Sub
#End Region
    Public Sub Them(ByVal Dto As thamsodto, ByVal MSsql As Boolean)
        Dim strsql As String
        strsql = "Insert into thamso(Tenthamso,Maso,Maso1,Maso2,Maso3,GhiChu) values (?,?,?,?,?,?)"
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            Dim cmd As New OleDbCommand(strsql, Ket_noi)
            cmd.Parameters.Add("@Tenthamso", OleDbType.WChar)
            cmd.Parameters.Add("@Maso", OleDbType.Integer)
            cmd.Parameters.Add("@Maso1", OleDbType.Integer)
            cmd.Parameters.Add("@Maso2", OleDbType.Integer)
            cmd.Parameters.Add("@Maso3", OleDbType.Integer)
            cmd.Parameters.Add("@GhiChu", OleDbType.WChar)
            cmd.Parameters("@Tenthamso").Value = Dto.Tenthamso
            cmd.Parameters("@Maso").Value = Dto.Maso
            cmd.Parameters("@Maso1").Value = Dto.Maso1
            cmd.Parameters("@Maso2").Value = Dto.Maso2
            cmd.Parameters("@Maso3").Value = Dto.Maso3
            cmd.Parameters("@GhiChu").Value = Dto.GhiChu
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            strsql = "Insert into thamso(id,Tenthamso,Maso,Maso1,Maso2,Maso3,GhiChu) values (" & Dto.id & ",'" & Dto.Tenthamso & "'," & Dto.Maso & "," & Dto.Maso1 & "," & Dto.Maso2 & "," & Dto.Maso3 & ",'" & Dto.GhiChu & "')"
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
            strSQL = "Delete From thamso Where id= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@ma", OleDbType.Integer)
            cmd.Parameters("@ma").Value = ma
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            Ket_noi1.Open()
            strSQL = "Delete From thamso Where id=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub sua(ByVal dto As thamsodto, ByVal MSsql As Boolean)
        Dim strSQL As String
        Dim BatTat As Boolean = False
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            strSQL = "Update thamso Set Tenthamso=? ,Maso=? ,Maso1=? ,Maso2=? ,Maso3=? ,GhiChu= ? where id= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@Tenthamso", OleDbType.WChar)
            cmd.Parameters.Add("@Maso", OleDbType.Integer)
            cmd.Parameters.Add("@Maso1", OleDbType.Integer)
            cmd.Parameters.Add("@Maso2", OleDbType.Integer)
            cmd.Parameters.Add("@Maso3", OleDbType.Integer)
            cmd.Parameters.Add("@GhiChu", OleDbType.WChar)
            cmd.Parameters.Add("@id", OleDbType.Integer)
            cmd.Parameters("@Tenthamso").Value = dto.Tenthamso
            cmd.Parameters("@Maso").Value = dto.Maso
            cmd.Parameters("@Maso1").Value = dto.Maso1
            cmd.Parameters("@Maso2").Value = dto.Maso2
            cmd.Parameters("@Maso3").Value = dto.Maso3
            cmd.Parameters("@GhiChu").Value = dto.GhiChu
            cmd.Parameters("@id").Value = dto.id
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            Ket_noi1.Open()
            strSQL = "Update thamso Set Tenthamso= '" & dto.Tenthamso & "',Maso= " & dto.Maso & ",Maso1= " & dto.Maso1 & ",Maso2= " & dto.Maso2 & ",Maso3= " & dto.Maso3 & ",GhiChu= '" & dto.GhiChu & "' where id=" & dto.id & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaMaso(ByVal Maso As Integer, ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            Ket_noi.Open()
            strSQL = "Update thamso Set Maso = ?  where id= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@Maso", OleDbType.Integer)
            cmd.Parameters.Add("@id", OleDbType.Integer)
            cmd.Parameters("@Maso").Value = Maso
            cmd.Parameters("@id").Value = ma
            cmd.ExecuteNonQuery()
            Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update thamso Set Maso =" & Maso & "  where id=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaMaso1(ByVal Maso1 As Integer, ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            Ket_noi.Open()
            strSQL = "Update thamso Set Maso1 = ?  where id= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@Maso1", OleDbType.Integer)
            cmd.Parameters.Add("@id", OleDbType.Integer)
            cmd.Parameters("@Maso1").Value = Maso1
            cmd.Parameters("@id").Value = ma
            cmd.ExecuteNonQuery()
            Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update thamso Set Maso1 =" & Maso1 & "  where id=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaMaso2(ByVal Maso2 As Integer, ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            Ket_noi.Open()
            strSQL = "Update thamso Set Maso2 = ?  where id= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@Maso2", OleDbType.Integer)
            cmd.Parameters.Add("@id", OleDbType.Integer)
            cmd.Parameters("@Maso2").Value = Maso2
            cmd.Parameters("@id").Value = ma
            cmd.ExecuteNonQuery()
            Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update thamso Set Maso2 =" & Maso2 & "  where id=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaMaso3(ByVal Maso3 As Integer, ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            Ket_noi.Open()
            strSQL = "Update thamso Set Maso3 = ?  where id= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@Maso3", OleDbType.Integer)
            cmd.Parameters.Add("@id", OleDbType.Integer)
            cmd.Parameters("@Maso3").Value = Maso3
            cmd.Parameters("@id").Value = ma
            cmd.ExecuteNonQuery()
            Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update thamso Set Maso3 =" & Maso3 & "  where id=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
End Class

