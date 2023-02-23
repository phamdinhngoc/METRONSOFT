Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class TienAnTangCadao
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
        MyBase.New("TienAnTangCa", connection, MSsql)
    End Sub
    Public Sub New(ByVal ma As Integer, ByVal connection As KetNoiDto, ByVal MSsql As Boolean)
        MyBase.New("TienAnTangCa", "select * from TienAnTangCa where ID=" & ma & "", connection, MSsql)
    End Sub
#End Region
    Public Sub Them(ByVal Dto As TienAnTangCadto, ByVal MSsql As Boolean)
        Dim strsql As String
        Dim BatTat As Boolean = False
        strsql = "Insert into TienAnTangCa(GioTC,TienAnTC) values (?,?)"
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            Dim cmd As New OleDbCommand(strsql, Ket_noi)
            'cmd.Parameters.Add("@ID", OleDbType.Integer)
            cmd.Parameters.Add("@GioTC", OleDbType.Integer)
            cmd.Parameters.Add("@TienAnTC", OleDbType.Integer)
            
            'cmd.Parameters("@ID").Value = Dto.ID
            cmd.Parameters("@GioTC").Value = Dto.GioTC
            cmd.Parameters("@TienAnTC").Value = Dto.TienAnTC
            
            cmd.ExecuteNonQuery()
            strsql = "Select @@IDENTITY"
            cmd = New OleDbCommand(strsql, Ket_noi)
            Dto.ID = cmd.ExecuteScalar()
            ' If Ket_noi.State = ConnectionState.Open Then
            ' Ket_noi.Close()
            ' End If
        Else
            strsql = "Insert into TienAnTangCa(GioTC,TienAnTC) values (" & Dto.GioTC & "," & Dto.TienAnTC & ")"
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
            strSQL = "Delete From TienAnTangCa Where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@ma", OleDbType.Integer)
            cmd.Parameters("@ma").Value = ma
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            Ket_noi1.Open()
            strSQL = "Delete From TienAnTangCa Where ID=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub

    Public Sub XoaAll(ByVal MSsql As Boolean)
        Dim strSQL As String
        Dim BatTat As Boolean = False
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            strSQL = "Delete* From TienAnTangCa "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)

            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If

        End If
    End Sub

    Public Sub sua(ByVal dto As TienAnTangCadto, ByVal MSsql As Boolean)
        Dim strSQL As String
        Dim BatTat As Boolean = False
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            strSQL = "Update TienAnTangCa Set GioTC=? ,TienAnTC=? where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@GioTC", OleDbType.Integer)
            cmd.Parameters.Add("@TienAnTC", OleDbType.Integer)
            cmd.Parameters.Add("@ID", OleDbType.Integer)
            cmd.Parameters("@GioTC").Value = dto.GioTC
            cmd.Parameters("@TienAnTC").Value = dto.TienAnTC
            cmd.Parameters("@ID").Value = dto.ID
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            Ket_noi1.Open()
            strSQL = "Update TienAnTangCa Set GioTC= " & dto.GioTC & ",TienAnTC= " & dto.TienAnTC & " where ID=" & dto.ID & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
End Class
