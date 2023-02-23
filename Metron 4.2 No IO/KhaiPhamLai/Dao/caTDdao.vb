 Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class caTDDao
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
        MyBase.New("caTD", connection, MSsql)
    End Sub
    Public Sub New(ByVal ma As Integer, ByVal connection As KetNoiDto, ByVal MSsql As Boolean)
        MyBase.New("caTD", "select * from caTD where ID=" & ma & "", connection, MSsql)
    End Sub
#End Region
    Public Sub Them(ByVal Dto As caTDdto, ByVal MSsql As Boolean)
        Dim strsql As String
        Dim BatTat As Boolean = False
        strsql = "Insert into caTD(MaNV,Caid,TuNgay,DenNgay,Tangca,TangcaS,GhTangca) values (?,?,?,?,?,?,?)"
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            Dim cmd As New OleDbCommand(strsql, Ket_noi)
            'cmd.Parameters.Add("@ID", OleDbType.Integer)
            cmd.Parameters.Add("@MaNV", OleDbType.Integer)
            cmd.Parameters.Add("@Caid", OleDbType.Integer)
            cmd.Parameters.Add("@TuNgay", OleDbType.Date)
            cmd.Parameters.Add("@DenNgay", OleDbType.Date)
            cmd.Parameters.Add("@Tangca", OleDbType.Boolean)
            cmd.Parameters.Add("@TangcaS", OleDbType.Integer)
            cmd.Parameters.Add("@GhTangca", OleDbType.Integer)
            'cmd.Parameters("@ID").Value = Dto.ID
            cmd.Parameters("@MaNV").Value = Dto.MaNV
            cmd.Parameters("@Caid").Value = Dto.Caid
            cmd.Parameters("@TuNgay").Value = Dto.TuNgay
            cmd.Parameters("@DenNgay").Value = Dto.DenNgay
            cmd.Parameters("@Tangca").Value = Dto.Tangca
            cmd.Parameters("@TangcaS").Value = Dto.TangcaS
            cmd.Parameters("@GhTangca").Value = Dto.GhTangca
            cmd.ExecuteNonQuery()
            strsql = "Select @@IDENTITY"
            cmd = New OleDbCommand(strsql, Ket_noi)
            Dto.ID = cmd.ExecuteScalar()
            ' If Ket_noi.State = ConnectionState.Open Then
            ' Ket_noi.Close()
            ' End If
        Else
        strsql = "Insert into caTD(ID,MaNV,Caid,TuNgay,DenNgay,Tangca,TangcaS,GhTangca) values (" & Dto.ID & "," & Dto.MaNV & "," & Dto.Caid & ",'" & Dto.TuNgay & "','" & Dto.DenNgay & "'," & Dto.Tangca & "," & Dto.TangcaS & "," & Dto.GhTangca & ")"
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
            strSQL = "Delete From caTD Where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@ma", OleDbType.Integer)
            cmd.Parameters("@ma").Value = ma
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            Ket_noi1.Open()
            strSQL = "Delete From caTD Where ID=" & ma & ""
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
            strSQL = "Delete* From caTD "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        
        End If
    End Sub

    Public Sub Xoa(ByVal maNV As Integer, ByVal MaCa As Integer, ByVal MSsql As Boolean)
        Dim strSQL As String
        Dim BatTat As Boolean = False
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            strSQL = "Delete From caTD Where (MaNV = PMaNV) and (Caid = PCaid) "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("PMaNV", OleDbType.Integer).Value = maNV
            cmd.Parameters.Add("PCaid", OleDbType.Integer).Value = MaCa
            cmd.ExecuteNonQuery()
            'If Ket_noi.State = ConnectionState.Open Then
            'Ket_noi.Close()
            'End If
        Else
            'Ket_noi1.Open()
            'strSQL = "Delete From caTD Where ID=" & ma & ""
            'Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            'cmd1.ExecuteNonQuery()
            'Ket_noi1.Close()
        End If
    End Sub

    Public Sub sua(ByVal dto As caTDdto, ByVal MSsql As Boolean)
        Dim strSQL As String
        Dim BatTat As Boolean = False
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            strSQL = "Update caTD Set MaNV=? ,Caid=? ,TuNgay=? ,DenNgay=? ,Tangca=? ,TangcaS=? ,GhTangca= ? where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@MaNV", OleDbType.Integer)
            cmd.Parameters.Add("@Caid", OleDbType.Integer)
            cmd.Parameters.Add("@TuNgay", OleDbType.Date)
            cmd.Parameters.Add("@DenNgay", OleDbType.Date)
            cmd.Parameters.Add("@Tangca", OleDbType.Boolean)
            cmd.Parameters.Add("@TangcaS", OleDbType.Integer)
            cmd.Parameters.Add("@GhTangca", OleDbType.Integer)
            cmd.Parameters.Add("@ID", OleDbType.Integer)
            cmd.Parameters("@MaNV").Value = dto.MaNV
            cmd.Parameters("@Caid").Value = dto.Caid
            cmd.Parameters("@TuNgay").Value = dto.TuNgay
            cmd.Parameters("@DenNgay").Value = dto.DenNgay
            cmd.Parameters("@Tangca").Value = dto.Tangca
            cmd.Parameters("@TangcaS").Value = dto.TangcaS
            cmd.Parameters("@GhTangca").Value = dto.GhTangca
            cmd.Parameters("@ID").Value = dto.ID
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            Ket_noi1.Open()
            strSQL = "Update caTD Set MaNV= " & dto.MaNV & ",Caid= " & dto.Caid & ",TuNgay= '" & dto.TuNgay & "',DenNgay= '" & dto.DenNgay & "',Tangca= " & dto.Tangca & ",TangcaS= " & dto.TangcaS & ",GhTangca= " & dto.GhTangca & " where ID=" & dto.ID & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaMaNV(ByVal MaNV As Integer, ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            Ket_noi.Open()
            strSQL = "Update caTD Set MaNV = ?  where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@MaNV", OleDbType.Integer)
            cmd.Parameters.Add("@ID", OleDbType.Integer)
            cmd.Parameters("@MaNV").Value = MaNV
            cmd.Parameters("@ID").Value = ma
            cmd.ExecuteNonQuery()
            Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update caTD Set MaNV =" & MaNV & "  where ID=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaCaid(ByVal Caid As Integer, ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            Ket_noi.Open()
            strSQL = "Update caTD Set Caid = ?  where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@Caid", OleDbType.Integer)
            cmd.Parameters.Add("@ID", OleDbType.Integer)
            cmd.Parameters("@Caid").Value = Caid
            cmd.Parameters("@ID").Value = ma
            cmd.ExecuteNonQuery()
            Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update caTD Set Caid =" & Caid & "  where ID=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaTangcaS(ByVal TangcaS As Integer, ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            Ket_noi.Open()
            strSQL = "Update caTD Set TangcaS = ?  where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@TangcaS", OleDbType.Integer)
            cmd.Parameters.Add("@ID", OleDbType.Integer)
            cmd.Parameters("@TangcaS").Value = TangcaS
            cmd.Parameters("@ID").Value = ma
            cmd.ExecuteNonQuery()
            Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update caTD Set TangcaS =" & TangcaS & "  where ID=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaGhTangca(ByVal GhTangca As Integer, ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            Ket_noi.Open()
            strSQL = "Update caTD Set GhTangca = ?  where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@GhTangca", OleDbType.Integer)
            cmd.Parameters.Add("@ID", OleDbType.Integer)
            cmd.Parameters("@GhTangca").Value = GhTangca
            cmd.Parameters("@ID").Value = ma
            cmd.ExecuteNonQuery()
            Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update caTD Set GhTangca =" & GhTangca & "  where ID=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
End Class

