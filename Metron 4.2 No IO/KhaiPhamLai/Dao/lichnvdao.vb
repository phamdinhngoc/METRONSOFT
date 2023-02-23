 Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class lichnvDao
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
        MyBase.New("lichnv", connection, MSsql)
    End Sub
    Public Sub New(ByVal ma As Integer, ByVal connection As KetNoiDto, ByVal MSsql As Boolean)
        MyBase.New("lichnv", "select * from lichnv where ID=" & ma & "", connection, MSsql)
    End Sub
#End Region
    Public Sub Them(ByVal Dto As lichnvdto, ByVal MSsql As Boolean)
        Dim strsql As String
        strsql = "Insert into lichnv(NVID,Sngay,LichID,Engay,Chay,Tangca,TangCaS,GHTangC) values (?,?,?,?,?,?,?,?)"
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            Dim cmd As New OleDbCommand(strsql, Ket_noi)
            cmd.Parameters.Add("@NVID", OleDbType.Integer)
            cmd.Parameters.Add("@Sngay", OleDbType.Date)
            cmd.Parameters.Add("@LichID", OleDbType.Integer)
            cmd.Parameters.Add("@Engay", OleDbType.Date)
            cmd.Parameters.Add("@Chay", OleDbType.Integer)
            cmd.Parameters.Add("@Tangca", OleDbType.Boolean)
            cmd.Parameters.Add("@TangCaS", OleDbType.Integer)
            cmd.Parameters.Add("@GHTangC", OleDbType.Integer)
            cmd.Parameters("@NVID").Value = Dto.NVID
            cmd.Parameters("@Sngay").Value = Dto.Sngay
            cmd.Parameters("@LichID").Value = Dto.LichID
            cmd.Parameters("@Engay").Value = Dto.Engay
            cmd.Parameters("@Chay").Value = Dto.Chay
            cmd.Parameters("@Tangca").Value = Dto.Tangca
            cmd.Parameters("@TangCaS").Value = Dto.TangCaS
            cmd.Parameters("@GHTangC").Value = Dto.GHTangC
            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                If Ket_noi.State = ConnectionState.Open Then
                    Ket_noi.Close()
                End If
            End Try
            'strsql = "Select @@IDENTITY"
            'cmd = New OleDbCommand(strsql, Ket_noi)
            'Dto.ID = cmd.ExecuteScalar()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            strsql = "Insert into lichnv(NVID,Sngay,LichID,Engay,Chay,Tangca,TangCaS,GHTangC) values (" & Dto.NVID & ",'" & Dto.Sngay & "'," & Dto.LichID & ",'" & Dto.Engay & "'," & Dto.Chay & "," & Dto.Tangca & "," & Dto.TangCaS & "," & Dto.GHTangC & ")"
            Ket_noi1.Open()
            Dim cmd1 As New SqlCommand(strsql, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub Xoa(ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If Ket_noi.State = ConnectionState.Closed Then
            Ket_noi.Open()
        End If
        strSQL = "Delete From lichnv Where ID= ? "
        Dim cmd As New OleDbCommand(strSQL, Ket_noi)
        cmd.Parameters.Add("@ma", OleDbType.Integer)
        cmd.Parameters("@ma").Value = ma
        cmd.ExecuteNonQuery()
        If Ket_noi.State = ConnectionState.Open Then
            Ket_noi.Close()
        End If
    End Sub
    Public Sub XoaNvid(ByVal nvid As Integer, ByVal MSsql As Boolean)
        Dim strSQL As String
        If Ket_noi.State = ConnectionState.Closed Then
            Ket_noi.Open()
        End If
        strSQL = "Delete From lichnv Where nvid= ? "
        Dim cmd As New OleDbCommand(strSQL, Ket_noi)
        cmd.Parameters.Add("@ma", OleDbType.Integer)
        cmd.Parameters("@ma").Value = nvid
        cmd.ExecuteNonQuery()
        If Ket_noi.State = ConnectionState.Open Then
            Ket_noi.Close()
        End If
    End Sub
    Public Sub sua(ByVal dto As lichnvdto, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            strSQL = "Update lichnv Set NVID=? ,Sngay=? ,LichID=? ,Engay=? ,Chay=? ,Tangca=? ,TangCaS=? ,GHTangC= ? where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@NVID", OleDbType.Integer)
            cmd.Parameters.Add("@Sngay", OleDbType.Date)
            cmd.Parameters.Add("@LichID", OleDbType.Integer)
            cmd.Parameters.Add("@Engay", OleDbType.Date)
            cmd.Parameters.Add("@Chay", OleDbType.Integer)
            cmd.Parameters.Add("@Tangca", OleDbType.Boolean)
            cmd.Parameters.Add("@TangCaS", OleDbType.Integer)
            cmd.Parameters.Add("@GHTangC", OleDbType.Integer)
            cmd.Parameters.Add("@ID", OleDbType.Integer)
            cmd.Parameters("@NVID").Value = dto.NVID
            cmd.Parameters("@Sngay").Value = dto.Sngay
            cmd.Parameters("@LichID").Value = dto.LichID
            cmd.Parameters("@Engay").Value = dto.Engay
            cmd.Parameters("@Chay").Value = dto.Chay
            cmd.Parameters("@Tangca").Value = dto.Tangca
            cmd.Parameters("@TangCaS").Value = dto.TangCaS
            cmd.Parameters("@GHTangC").Value = dto.GHTangC
            cmd.Parameters("@ID").Value = dto.ID
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            Ket_noi1.Open()
            strSQL = "Update lichnv Set NVID= " & dto.NVID & ",Sngay= '" & dto.Sngay & "',LichID= " & dto.LichID & ",Engay= '" & dto.Engay & "',Chay= " & dto.Chay & ",Tangca= " & dto.Tangca & ",TangCaS= " & dto.TangCaS & ",GHTangC= " & dto.GHTangC & " where ID=" & dto.ID & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaNVID(ByVal NVID As Integer, ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            Ket_noi.Open()
            strSQL = "Update lichnv Set NVID = ?  where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@NVID", OleDbType.Integer)
            cmd.Parameters.Add("@ID", OleDbType.Integer)
            cmd.Parameters("@NVID").Value = NVID
            cmd.Parameters("@ID").Value = ma
            cmd.ExecuteNonQuery()
            Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update lichnv Set NVID =" & NVID & "  where ID=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaLichID(ByVal LichID As Integer, ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            Ket_noi.Open()
            strSQL = "Update lichnv Set LichID = ?  where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@LichID", OleDbType.Integer)
            cmd.Parameters.Add("@ID", OleDbType.Integer)
            cmd.Parameters("@LichID").Value = LichID
            cmd.Parameters("@ID").Value = ma
            cmd.ExecuteNonQuery()
            Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update lichnv Set LichID =" & LichID & "  where ID=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaChay(ByVal Chay As Integer, ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            Ket_noi.Open()
            strSQL = "Update lichnv Set Chay = ?  where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@Chay", OleDbType.Integer)
            cmd.Parameters.Add("@ID", OleDbType.Integer)
            cmd.Parameters("@Chay").Value = Chay
            cmd.Parameters("@ID").Value = ma
            cmd.ExecuteNonQuery()
            Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update lichnv Set Chay =" & Chay & "  where ID=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaTangCaS(ByVal TangCaS As Integer, ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            Ket_noi.Open()
            strSQL = "Update lichnv Set TangCaS = ?  where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@TangCaS", OleDbType.Integer)
            cmd.Parameters.Add("@ID", OleDbType.Integer)
            cmd.Parameters("@TangCaS").Value = TangCaS
            cmd.Parameters("@ID").Value = ma
            cmd.ExecuteNonQuery()
            Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update lichnv Set TangCaS =" & TangCaS & "  where ID=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaGHTangC(ByVal GHTangC As Integer, ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            Ket_noi.Open()
            strSQL = "Update lichnv Set GHTangC = ?  where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@GHTangC", OleDbType.Integer)
            cmd.Parameters.Add("@ID", OleDbType.Integer)
            cmd.Parameters("@GHTangC").Value = GHTangC
            cmd.Parameters("@ID").Value = ma
            cmd.ExecuteNonQuery()
            Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update lichnv Set GHTangC =" & GHTangC & "  where ID=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
End Class

