 Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class LichDao
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
        MyBase.New("Lich", connection, MSsql)
    End Sub
    Public Sub New(ByVal ma As Integer, ByVal connection As KetNoiDto, ByVal MSsql As Boolean)
        MyBase.New("Lich", "select * from Lich where ID=" & ma & "", connection, MSsql)
    End Sub
#End Region
    Public Function Kiemtra(ByVal ma As Integer, ByVal MSsql As Boolean) As Boolean
        Dim strsql As String
        strsql = "select * from Lich where id=? "
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            Dim cmd As New OleDbCommand(strsql, Ket_noi)
            cmd.Parameters.Add("@id", OleDbType.Integer)
            cmd.Parameters("@id").Value = ma
            Dim a As Boolean = cmd.ExecuteReader.HasRows
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
            Return a
        End If
        Return False
    End Function

    Public Function Kiemtra(ByVal Dto As Lichdto, ByVal MSsql As Boolean) As Boolean
        Dim strsql As String
        strsql = "select * from Lich where Chedo=? and Batdau=? and SoCK=? and KieuCK=?"
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            Dim cmd As New OleDbCommand(strsql, Ket_noi)
            cmd.Parameters.Add("@Chedo", OleDbType.WChar)
            cmd.Parameters.Add("@Batdau", OleDbType.Date)
            cmd.Parameters.Add("@SoCK", OleDbType.Integer)
            cmd.Parameters.Add("@KieuCK", OleDbType.Integer)
            cmd.Parameters("@Chedo").Value = Dto.Chedo
            cmd.Parameters("@Batdau").Value = Dto.Batdau
            cmd.Parameters("@SoCK").Value = Dto.SoCK
            cmd.Parameters("@KieuCK").Value = Dto.KieuCK
            Dim a As Boolean = cmd.ExecuteReader.HasRows
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
            Return a
        End If
        Return False
    End Function

    Public Sub Them(ByVal Dto As Lichdto, ByVal MSsql As Boolean)
        Dim strsql As String
        strsql = "Insert into Lich(Chedo,Batdau,SoCK,KieuCK) values (?,?,?,?)"
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            Dim cmd As New OleDbCommand(strsql, Ket_noi)
            cmd.Parameters.Add("@Chedo", OleDbType.WChar)
            cmd.Parameters.Add("@Batdau", OleDbType.Date)
            cmd.Parameters.Add("@SoCK", OleDbType.Integer)
            cmd.Parameters.Add("@KieuCK", OleDbType.Integer)
            cmd.Parameters("@Chedo").Value = Dto.Chedo
            cmd.Parameters("@Batdau").Value = Dto.Batdau
            cmd.Parameters("@SoCK").Value = Dto.SoCK
            cmd.Parameters("@KieuCK").Value = Dto.KieuCK
            cmd.ExecuteNonQuery()
            strsql = "Select @@IDENTITY"
            cmd = New OleDbCommand(strsql, Ket_noi)
            Dto.ID = cmd.ExecuteScalar()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            strsql = "Insert into Lich(Chedo,Batdau,SoCK,KieuCK) values ('" & Dto.Chedo & "','" & Dto.Batdau & "'," & Dto.SoCK & "," & Dto.KieuCK & ")"
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
            strSQL = "Delete From Lich Where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@ma", OleDbType.Integer)
            cmd.Parameters("@ma").Value = ma
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            Ket_noi1.Open()
            strSQL = "Delete From Lich Where ID=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub sua(ByVal dto As Lichdto, ByVal MSsql As Boolean)
        Dim strSQL As String
        Dim BatTat As Boolean = False
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            strSQL = "Update Lich Set Chedo=? ,Batdau=? ,SoCK=? ,KieuCK= ? where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@Chedo", OleDbType.WChar)
            cmd.Parameters.Add("@Batdau", OleDbType.Date)
            cmd.Parameters.Add("@SoCK", OleDbType.Integer)
            cmd.Parameters.Add("@KieuCK", OleDbType.Integer)
            cmd.Parameters.Add("@ID", OleDbType.Integer)
            cmd.Parameters("@Chedo").Value = dto.Chedo
            cmd.Parameters("@Batdau").Value = dto.Batdau
            cmd.Parameters("@SoCK").Value = dto.SoCK
            cmd.Parameters("@KieuCK").Value = dto.KieuCK
            cmd.Parameters("@ID").Value = dto.ID
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update Lich Set Chedo= '" & dto.Chedo & "',Batdau= '" & dto.Batdau & "',SoCK= " & dto.SoCK & ",KieuCK= " & dto.KieuCK & " where ID=" & dto.ID & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaSoCK(ByVal SoCK As Integer, ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            Ket_noi.Open()
            strSQL = "Update Lich Set SoCK = ?  where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@SoCK", OleDbType.Integer)
            cmd.Parameters.Add("@ID", OleDbType.Integer)
            cmd.Parameters("@SoCK").Value = SoCK
            cmd.Parameters("@ID").Value = ma
            cmd.ExecuteNonQuery()
            Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update Lich Set SoCK =" & SoCK & "  where ID=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaKieuCK(ByVal KieuCK As Integer, ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            Ket_noi.Open()
            strSQL = "Update Lich Set KieuCK = ?  where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@KieuCK", OleDbType.Integer)
            cmd.Parameters.Add("@ID", OleDbType.Integer)
            cmd.Parameters("@KieuCK").Value = KieuCK
            cmd.Parameters("@ID").Value = ma
            cmd.ExecuteNonQuery()
            Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update Lich Set KieuCK =" & KieuCK & "  where ID=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
End Class

