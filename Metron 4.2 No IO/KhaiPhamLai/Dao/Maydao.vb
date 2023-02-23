 Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class MayDao
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
        MyBase.New("May", connection, MSsql)
    End Sub
    Public Sub New(ByVal ma As Integer, ByVal connection As KetNoiDto, ByVal MSsql As Boolean)
        MyBase.New("May", "select * from May where ID=" & ma & "", connection, MSsql)
    End Sub
#End Region
    Public Sub Them(ByVal Dto As Maydto, ByVal MSsql As Boolean)
        Dim strsql As String
        strsql = "Insert into May(ID,MaySO,Loaimay,Pass,Tenmay,Vtri,Kieu,IP,Cong,Rate) values (?,?,?,?,?,?,?,?,?,?)"
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            Dim cmd As New OleDbCommand(strsql, Ket_noi)
            cmd.Parameters.Add("@ID", OleDbType.Integer)
            cmd.Parameters.Add("@MaySO", OleDbType.Integer)
            cmd.Parameters.Add("@Loaimay", OleDbType.Integer)
            cmd.Parameters.Add("@Pass", OleDbType.WChar)
            cmd.Parameters.Add("@Tenmay", OleDbType.WChar)
            cmd.Parameters.Add("@Vtri", OleDbType.WChar)
            cmd.Parameters.Add("@Kieu", OleDbType.Integer)
            cmd.Parameters.Add("@IP", OleDbType.WChar)
            cmd.Parameters.Add("@Cong", OleDbType.Integer)
            cmd.Parameters.Add("@Rate", OleDbType.Integer)
            cmd.Parameters("@ID").Value = Dto.ID
            cmd.Parameters("@MaySO").Value = Dto.MaySO
            cmd.Parameters("@Loaimay").Value = Dto.Loaimay
            cmd.Parameters("@Pass").Value = Dto.Pass
            cmd.Parameters("@Tenmay").Value = Dto.Tenmay
            cmd.Parameters("@Vtri").Value = Dto.Vtri
            cmd.Parameters("@Kieu").Value = Dto.Kieu
            cmd.Parameters("@IP").Value = Dto.IP
            cmd.Parameters("@Cong").Value = Dto.Cong
            cmd.Parameters("@Rate").Value = Dto.Rate
            cmd.ExecuteNonQuery()
            'strsql = "Select @@IDENTITY"
            'cmd = New OleDbCommand(strsql, Ket_noi)
            'Dto.ID = cmd.ExecuteScalar()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            strsql = "Insert into May(ID,MaySO,Loaimay,Pass,Tenmay,Vtri,Kieu,IP,Cong,Rate) values (" & Dto.ID & "," & Dto.MaySO & "," & Dto.Loaimay & ",'" & Dto.Pass & "','" & Dto.Tenmay & "','" & Dto.Vtri & "'," & Dto.Kieu & ",'" & Dto.IP & "'," & Dto.Cong & "," & Dto.Rate & ")"
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
            strSQL = "Delete From May Where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@ma", OleDbType.Integer)
            cmd.Parameters("@ma").Value = ma
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            Ket_noi1.Open()
            strSQL = "Delete From May Where ID=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub sua(ByVal dto As Maydto, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            strSQL = "Update May Set MaySO=? ,Loaimay=? ,Pass=? ,Tenmay=? ,Vtri=? ,Kieu=? ,IP=? ,Cong=? ,Rate= ? where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@MaySO", OleDbType.Integer)
            cmd.Parameters.Add("@Loaimay", OleDbType.Integer)
            cmd.Parameters.Add("@Pass", OleDbType.WChar)
            cmd.Parameters.Add("@Tenmay", OleDbType.WChar)
            cmd.Parameters.Add("@Vtri", OleDbType.WChar)
            cmd.Parameters.Add("@Kieu", OleDbType.Integer)
            cmd.Parameters.Add("@IP", OleDbType.WChar)
            cmd.Parameters.Add("@Cong", OleDbType.Integer)
            cmd.Parameters.Add("@Rate", OleDbType.Integer)
            cmd.Parameters.Add("@ID", OleDbType.Integer)
            cmd.Parameters("@MaySO").Value = dto.MaySO
            cmd.Parameters("@Loaimay").Value = dto.Loaimay
            cmd.Parameters("@Pass").Value = dto.Pass
            cmd.Parameters("@Tenmay").Value = dto.Tenmay
            cmd.Parameters("@Vtri").Value = dto.Vtri
            cmd.Parameters("@Kieu").Value = dto.Kieu
            cmd.Parameters("@IP").Value = dto.IP
            cmd.Parameters("@Cong").Value = dto.Cong
            cmd.Parameters("@Rate").Value = dto.Rate
            cmd.Parameters("@ID").Value = dto.ID
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            Ket_noi1.Open()
            strSQL = "Update May Set MaySO= " & dto.MaySO & ",Loaimay= " & dto.Loaimay & ",Pass= '" & dto.Pass & "',Tenmay= '" & dto.Tenmay & "',Vtri= '" & dto.Vtri & "',Kieu= " & dto.Kieu & ",IP= '" & dto.IP & "',Cong= " & dto.Cong & ",Rate= " & dto.Rate & " where ID=" & dto.ID & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaMaySO(ByVal MaySO As Integer, ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            Ket_noi.Open()
            strSQL = "Update May Set MaySO = ?  where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@MaySO", OleDbType.Integer)
            cmd.Parameters.Add("@ID", OleDbType.Integer)
            cmd.Parameters("@MaySO").Value = MaySO
            cmd.Parameters("@ID").Value = ma
            cmd.ExecuteNonQuery()
            Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update May Set MaySO =" & MaySO & "  where ID=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaLoaimay(ByVal Loaimay As Integer, ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            Ket_noi.Open()
            strSQL = "Update May Set Loaimay = ?  where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@Loaimay", OleDbType.Integer)
            cmd.Parameters.Add("@ID", OleDbType.Integer)
            cmd.Parameters("@Loaimay").Value = Loaimay
            cmd.Parameters("@ID").Value = ma
            cmd.ExecuteNonQuery()
            Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update May Set Loaimay =" & Loaimay & "  where ID=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaKieu(ByVal Kieu As Integer, ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            Ket_noi.Open()
            strSQL = "Update May Set Kieu = ?  where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@Kieu", OleDbType.Integer)
            cmd.Parameters.Add("@ID", OleDbType.Integer)
            cmd.Parameters("@Kieu").Value = Kieu
            cmd.Parameters("@ID").Value = ma
            cmd.ExecuteNonQuery()
            Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update May Set Kieu =" & Kieu & "  where ID=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaCong(ByVal Cong As Integer, ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            Ket_noi.Open()
            strSQL = "Update May Set Cong = ?  where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@Cong", OleDbType.Integer)
            cmd.Parameters.Add("@ID", OleDbType.Integer)
            cmd.Parameters("@Cong").Value = Cong
            cmd.Parameters("@ID").Value = ma
            cmd.ExecuteNonQuery()
            Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update May Set Cong =" & Cong & "  where ID=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaRate(ByVal Rate As Integer, ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            Ket_noi.Open()
            strSQL = "Update May Set Rate = ?  where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@Rate", OleDbType.Integer)
            cmd.Parameters.Add("@ID", OleDbType.Integer)
            cmd.Parameters("@Rate").Value = Rate
            cmd.Parameters("@ID").Value = ma
            cmd.ExecuteNonQuery()
            Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update May Set Rate =" & Rate & "  where ID=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
End Class

