 Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class caDao
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
        MyBase.New("ca", connection, MSsql)
    End Sub
    Public Sub New(ByVal ma As Integer, ByVal connection As KetNoiDto, ByVal MSsql As Boolean)
        MyBase.New("ca", "select * from ca where ID=" & ma & "", connection, MSsql)
    End Sub
#End Region
    Public Sub Them(ByRef Dto As cadto, ByVal MSsql As Boolean)
        Dim strsql As String
        strsql = "Insert into ca(Tenca,batdau,kethuc,som,tre,tgvao1,tgvao2,tgra1,tgra2,ngaycong,Sophut,mau,Cacon) values (?,?,?,?,?,?,?,?,?,?,?,?,?)"
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            Dim cmd As New OleDbCommand(strsql, Ket_noi)
            cmd.Parameters.Add("@Tenca", OleDbType.WChar)
            cmd.Parameters.Add("@batdau", OleDbType.Date)
            cmd.Parameters.Add("@kethuc", OleDbType.Date)
            cmd.Parameters.Add("@som", OleDbType.Integer)
            cmd.Parameters.Add("@tre", OleDbType.Integer)
            cmd.Parameters.Add("@tgvao1", OleDbType.Date)
            cmd.Parameters.Add("@tgvao2", OleDbType.Date)
            cmd.Parameters.Add("@tgra1", OleDbType.Date)
            cmd.Parameters.Add("@tgra2", OleDbType.Date)
            cmd.Parameters.Add("@ngaycong", OleDbType.Double)
            cmd.Parameters.Add("@Sophut", OleDbType.Integer)
            cmd.Parameters.Add("@mau", OleDbType.Integer)
            cmd.Parameters.Add("@Cacon", OleDbType.Integer)
            cmd.Parameters("@Tenca").Value = Dto.Tenca
            cmd.Parameters("@batdau").Value = Dto.batdau
            cmd.Parameters("@kethuc").Value = Dto.kethuc
            cmd.Parameters("@som").Value = Dto.som
            cmd.Parameters("@tre").Value = Dto.tre
            cmd.Parameters("@tgvao1").Value = Dto.tgvao1
            cmd.Parameters("@tgvao2").Value = Dto.tgvao2
            cmd.Parameters("@tgra1").Value = Dto.tgra1
            cmd.Parameters("@tgra2").Value = Dto.tgra2
            cmd.Parameters("@ngaycong").Value = Dto.ngaycong
            cmd.Parameters("@Sophut").Value = Dto.Sophut
            cmd.Parameters("@mau").Value = Dto.mau
            cmd.Parameters("@Cacon").Value = Dto.Cacon
            cmd.ExecuteNonQuery()
            strsql = "Select @@IDENTITY"
            cmd = New OleDbCommand(strsql, Ket_noi)
            Dto.ID = cmd.ExecuteScalar()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            strsql = "Insert into ca(Tenca,batdau,kethuc,som,tre,tgvao1,tgvao2,tgra1,tgra2,ngaycong,Sophut,mau,Cacon) values ('" & Dto.Tenca & "','" & Dto.batdau & "','" & Dto.kethuc & "'," & Dto.som & "," & Dto.tre & ",'" & Dto.tgvao1 & "','" & Dto.tgvao2 & "','" & Dto.tgra1 & "','" & Dto.tgra2 & "'," & Dto.ngaycong & "," & Dto.Sophut & "," & Dto.mau & "," & Dto.Cacon & ")"
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
            strSQL = "Delete From ca Where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@ma", OleDbType.Integer)
            cmd.Parameters("@ma").Value = ma
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            Ket_noi1.Open()
            strSQL = "Delete From ca Where ID=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub sua(ByVal dto As cadto, ByVal MSsql As Boolean)
        Dim strSQL As String
        Dim BatTat As Boolean = False
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            strSQL = "Update ca Set Tenca=? ,batdau=? ,kethuc=? ,som=? ,tre=? ,tgvao1=? ,tgvao2=? ,tgra1=? ,tgra2=? ,ngaycong=? ,Sophut=? ,mau=? ,Cacon= ? where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@Tenca", OleDbType.WChar)
            cmd.Parameters.Add("@batdau", OleDbType.Date)
            cmd.Parameters.Add("@kethuc", OleDbType.Date)
            cmd.Parameters.Add("@som", OleDbType.Integer)
            cmd.Parameters.Add("@tre", OleDbType.Integer)
            cmd.Parameters.Add("@tgvao1", OleDbType.Date)
            cmd.Parameters.Add("@tgvao2", OleDbType.Date)
            cmd.Parameters.Add("@tgra1", OleDbType.Date)
            cmd.Parameters.Add("@tgra2", OleDbType.Date)
            cmd.Parameters.Add("@ngaycong", OleDbType.Double)
            cmd.Parameters.Add("@Sophut", OleDbType.Integer)
            cmd.Parameters.Add("@mau", OleDbType.Integer)
            cmd.Parameters.Add("@Cacon", OleDbType.Integer)
            cmd.Parameters.Add("@ID", OleDbType.Integer)
            cmd.Parameters("@Tenca").Value = dto.Tenca
            cmd.Parameters("@batdau").Value = dto.batdau
            cmd.Parameters("@kethuc").Value = dto.kethuc
            cmd.Parameters("@som").Value = dto.som
            cmd.Parameters("@tre").Value = dto.tre
            cmd.Parameters("@tgvao1").Value = dto.tgvao1
            cmd.Parameters("@tgvao2").Value = dto.tgvao2
            cmd.Parameters("@tgra1").Value = dto.tgra1
            cmd.Parameters("@tgra2").Value = dto.tgra2
            cmd.Parameters("@ngaycong").Value = dto.ngaycong
            cmd.Parameters("@Sophut").Value = dto.Sophut
            cmd.Parameters("@mau").Value = dto.mau
            cmd.Parameters("@Cacon").Value = dto.Cacon
            cmd.Parameters("@ID").Value = dto.ID
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            Ket_noi1.Open()
            strSQL = "Update ca Set Tenca= '" & dto.Tenca & "',batdau= '" & dto.batdau & "',kethuc= '" & dto.kethuc & "',som= " & dto.som & ",tre= " & dto.tre & ",tgvao1= '" & dto.tgvao1 & "',tgvao2= '" & dto.tgvao2 & "',tgra1= '" & dto.tgra1 & "',tgra2= '" & dto.tgra2 & "',ngaycong= " & dto.ngaycong & ",Sophut= " & dto.Sophut & ",mau= " & dto.mau & ",Cacon= " & dto.Cacon & " where ID=" & dto.ID & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub Suasom(ByVal som As Integer, ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            Ket_noi.Open()
            strSQL = "Update ca Set som = ?  where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@som", OleDbType.Integer)
            cmd.Parameters.Add("@ID", OleDbType.Integer)
            cmd.Parameters("@som").Value = som
            cmd.Parameters("@ID").Value = ma
            cmd.ExecuteNonQuery()
            Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update ca Set som =" & som & "  where ID=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub Suatre(ByVal tre As Integer, ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            Ket_noi.Open()
            strSQL = "Update ca Set tre = ?  where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@tre", OleDbType.Integer)
            cmd.Parameters.Add("@ID", OleDbType.Integer)
            cmd.Parameters("@tre").Value = tre
            cmd.Parameters("@ID").Value = ma
            cmd.ExecuteNonQuery()
            Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update ca Set tre =" & tre & "  where ID=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub Suangaycong(ByVal ngaycong As Integer, ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            Ket_noi.Open()
            strSQL = "Update ca Set ngaycong = ?  where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@ngaycong", OleDbType.Double)
            cmd.Parameters.Add("@ID", OleDbType.Integer)
            cmd.Parameters("@ngaycong").Value = ngaycong
            cmd.Parameters("@ID").Value = ma
            cmd.ExecuteNonQuery()
            Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update ca Set ngaycong =" & ngaycong & "  where ID=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaSophut(ByVal Sophut As Integer, ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            Ket_noi.Open()
            strSQL = "Update ca Set Sophut = ?  where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@Sophut", OleDbType.Integer)
            cmd.Parameters.Add("@ID", OleDbType.Integer)
            cmd.Parameters("@Sophut").Value = Sophut
            cmd.Parameters("@ID").Value = ma
            cmd.ExecuteNonQuery()
            Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update ca Set Sophut =" & Sophut & "  where ID=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub Suamau(ByVal mau As Integer, ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            Ket_noi.Open()
            strSQL = "Update ca Set mau = ?  where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@mau", OleDbType.Integer)
            cmd.Parameters.Add("@ID", OleDbType.Integer)
            cmd.Parameters("@mau").Value = mau
            cmd.Parameters("@ID").Value = ma
            cmd.ExecuteNonQuery()
            Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update ca Set mau =" & mau & "  where ID=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaCacon(ByVal Cacon As Integer, ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            Ket_noi.Open()
            strSQL = "Update ca Set Cacon = ?  where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@Cacon", OleDbType.Integer)
            cmd.Parameters.Add("@ID", OleDbType.Integer)
            cmd.Parameters("@Cacon").Value = Cacon
            cmd.Parameters("@ID").Value = ma
            cmd.ExecuteNonQuery()
            Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update ca Set Cacon =" & Cacon & "  where ID=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
End Class

