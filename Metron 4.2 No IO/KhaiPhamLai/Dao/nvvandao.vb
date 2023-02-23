 Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class nvvanDao
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
        MyBase.New("nvvan", connection, MSsql)
    End Sub
    Public Sub New(ByVal ma As Integer, ByVal connection As KetNoiDto, ByVal MSsql As Boolean)
        MyBase.New("nvvan", "select * from nvvan where MaNV=" & ma & "", connection, MSsql)
    End Sub
    Public Sub New(ByVal ma1 As Integer, ByVal ma2 As Integer, ByVal connection As KetNoiDto, ByVal MSsql As Boolean)
        MyBase.New("nvvan", "select * from nvvan where MaNV=" & ma1 & " and VanID=" & ma2 & "", connection, MSsql)
    End Sub
#End Region
    Public Sub Them(ByVal Dto As nvvandto, ByVal MSsql As Boolean)
        Dim strsql As String
        Dim BatTat As Boolean = False
        strsql = "Insert into nvvan(MaNV,VanID,ma, BVan) values (?,?,?,?)"
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            Dim cmd As New OleDbCommand(strsql, Ket_noi)
            cmd.Parameters.Add("@MaNV", OleDbType.Integer)
            cmd.Parameters.Add("@VanID", OleDbType.Integer)
            cmd.Parameters.Add("@ma", OleDbType.WChar)
            cmd.Parameters.Add("@BVan", OleDbType.Binary)
            cmd.Parameters("@MaNV").Value = Dto.MaNV
            cmd.Parameters("@VanID").Value = Dto.VanID
            cmd.Parameters("@ma").Value = Dto.ma
            cmd.Parameters("@BVan").Value = Dto.BVan
            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception

            End Try

            'strsql = "Select @@IDENTITY"
            'cmd = New OleDbCommand(strsql, Ket_noi)
            'Dto.MaNV = cmd.ExecuteScalar()
             
        Else
            strsql = "Insert into nvvan(MaNV,VanID,ma) values (" & Dto.MaNV & "," & Dto.VanID & ",'" & Dto.ma & "')"
            Ket_noi1.Open()
            Dim cmd1 As New SqlCommand(strsql, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub

    Public Sub ThemNoBinary(ByVal Dto As nvvandto, ByVal MSsql As Boolean)
        Dim strsql As String
        Dim BatTat As Boolean = False
        strsql = "Insert into nvvan(MaNV,VanID,ma ) values (?,?,? )"
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            Dim cmd As New OleDbCommand(strsql, Ket_noi)
            cmd.Parameters.Add("@MaNV", OleDbType.Integer)
            cmd.Parameters.Add("@VanID", OleDbType.Integer)
            cmd.Parameters.Add("@ma", OleDbType.WChar)

            cmd.Parameters("@MaNV").Value = Dto.MaNV
            cmd.Parameters("@VanID").Value = Dto.VanID
            cmd.Parameters("@ma").Value = Dto.ma

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception

            End Try
             
        Else
            strsql = "Insert into nvvan(MaNV,VanID,ma) values (" & Dto.MaNV & "," & Dto.VanID & ",'" & Dto.ma & "')"
            Ket_noi1.Open()
            Dim cmd1 As New SqlCommand(strsql, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub

    Public Sub Xoa(ByVal ma1 As Integer, ByVal MSsql As Boolean)
        Dim strSQL As String
        Dim BatTat As Boolean = False
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            strSQL = "Delete From nvvan Where MaNV= ?"
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@ma1", OleDbType.Integer)
            cmd.Parameters("@Ma1").Value = ma1
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            Ket_noi1.Open()
            strSQL = "Delete From nvvan Where MaNV=" & ma1
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub Xoa(ByVal ma1 As Integer, ByVal ma2 As Integer, ByVal MSsql As Boolean)
        Dim strSQL As String
        Dim BatTat As Boolean = False
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            strSQL = "Delete From nvvan Where MaNV= ?  and VanID= ?  "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@ma1", OleDbType.Integer)
            cmd.Parameters.Add("@ma2", OleDbType.Integer)
            cmd.Parameters("@Ma1").Value = ma1
            cmd.Parameters("@Ma2").Value = ma2
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            Ket_noi1.Open()
            strSQL = "Delete From nvvan Where MaNV=" & ma1 & " and VanID=" & ma2 & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub sua(ByVal dto As nvvandto, ByVal MSsql As Boolean)
        Dim strSQL As String
        Dim BatTat As Boolean = False
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            strSQL = "Update nvvan Set ma= ? where MaNV= ?  and VanID= ?  "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@ma", OleDbType.WChar)
            cmd.Parameters.Add("@MaNV", OleDbType.Integer)
            cmd.Parameters.Add("@VanID", OleDbType.Integer)
            cmd.Parameters("@ma").Value = dto.ma
            cmd.Parameters("@MaNV").Value = dto.MaNV
            cmd.Parameters("@VanID").Value = dto.VanID
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            Ket_noi1.Open()
            strSQL = "Update nvvan Set ma= '" & dto.ma & "' where MaNV=" & dto.MaNV & " and VanID=" & dto.VanID & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
End Class

