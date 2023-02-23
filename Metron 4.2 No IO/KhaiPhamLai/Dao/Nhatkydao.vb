Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class NhatkyDao
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
        MyBase.New("Nhatky", connection, MSsql)
    End Sub
    Public Sub New(ByVal ma As Integer, ByVal connection As KetNoiDto, ByVal MSsql As Boolean)
        MyBase.New("Nhatky", "select * from Nhatky where ID=" & ma & "", connection, MSsql)
    End Sub
#End Region
    Public Function xemNhatky(ByVal tungay As DateTime, ByVal dengay As DateTime, Optional ByVal tennguoidung As String = "", Optional ByVal tacvu As String = "") As OleDb.OleDbDataReader
        Try
            Dim strsql As String = "select * from nhatky where ngay >= ? and ngay <= ?" & IIf(tacvu <> "", " and Tacvu like '%?%'", "") & IIf(tennguoidung <> "", " and User = ?", "")
            If Ket_noi.State = ConnectionState.Closed Then Ket_noi.Open()
            Dim cmd As New OleDbCommand(strsql, Ket_noi)
            cmd.Parameters.Add("@TuNgay", OleDbType.Date).Value = tungay
            cmd.Parameters.Add("@DenNgay", OleDbType.Date).Value = dengay
            If tacvu <> "" Then cmd.Parameters.Add("@Tacvu", OleDbType.WChar).Value = tacvu
            If tennguoidung <> "" Then cmd.Parameters.Add("@User", OleDbType.WChar).Value = tennguoidung
            Return cmd.ExecuteReader
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Nothing
    End Function
    Public Sub Them(ByVal Dto As Nhatkydto, ByVal MSsql As Boolean)
        Dim strsql As String
        'strsql = "INSERT INTO Nhatky([User],Ngay,Gio,Tacvu) values ('" & Dto.User & "',#" & Dto.Ngay & "#,#" & Dto.Gio & "#,'" & Dto.Tacvu & "')"
        strsql = "Insert into Nhatky([User],Ngay,Gio,Tacvu) values (?,?,?,?)"
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then Ket_noi.Open()
            Dim cmd As New OleDbCommand(strsql, Ket_noi)
            cmd.Parameters.Add("@User", OleDbType.WChar)
            cmd.Parameters.Add("@Ngay", OleDbType.Date)
            cmd.Parameters.Add("@Gio", OleDbType.Date)
            cmd.Parameters.Add("@Tacvu", OleDbType.WChar)
            cmd.Parameters("@User").Value = Dto.User
            cmd.Parameters("@Ngay").Value = Dto.Ngay
            cmd.Parameters("@Gio").Value = Dto.Gio
            cmd.Parameters("@Tacvu").Value = Dto.Tacvu
            cmd.ExecuteNonQuery()
            'strsql = "Select @@IDENTITY"
            'cmd = New OleDbCommand(strsql, Ket_noi)
            'Dto.ID = cmd.ExecuteScalar()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            strsql = "Insert into Nhatky(ID,User,Ngay,Gio,Tacvu) values (" & Dto.ID & ",'" & Dto.User & "','" & Dto.Ngay & "','" & Dto.Gio & "','" & Dto.Tacvu & "')"
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
            strSQL = "Delete From Nhatky Where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@ma", OleDbType.Integer)
            cmd.Parameters("@ma").Value = ma
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            Ket_noi1.Open()
            strSQL = "Delete From Nhatky Where ID=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub sua(ByVal dto As Nhatkydto, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            strSQL = "Update Nhatky Set User=? ,Ngay=? ,Gio=? ,Tacvu= ? where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@User", OleDbType.WChar)
            cmd.Parameters.Add("@Ngay", OleDbType.Date)
            cmd.Parameters.Add("@Gio", OleDbType.Date)
            cmd.Parameters.Add("@Tacvu", OleDbType.WChar)
            cmd.Parameters.Add("@ID", OleDbType.Integer)
            cmd.Parameters("@User").Value = dto.User
            cmd.Parameters("@Ngay").Value = dto.Ngay
            cmd.Parameters("@Gio").Value = dto.Gio
            cmd.Parameters("@Tacvu").Value = dto.Tacvu
            cmd.Parameters("@ID").Value = dto.ID
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            Ket_noi1.Open()
            strSQL = "Update Nhatky Set User= '" & dto.User & "',Ngay= '" & dto.Ngay & "',Gio= '" & dto.Gio & "',Tacvu= '" & dto.Tacvu & "' where ID=" & dto.ID & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Function MaThem(ByVal ketnoi As OleDbConnection) As Integer
        Try
            Dim cmd As New OleDbCommand
            Dim strsql As String = "Select max(id) from nhatky"
            cmd = New OleDbCommand(strsql, ketnoi)
            Return cmd.ExecuteScalar()
        Catch ex As Exception
        End Try
    End Function
    Public Function MaThem() As Integer
        Try
            Dim cmd As New OleDbCommand
            Dim strsql As String = "Select max(id) from nhatky"
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            cmd = New OleDbCommand(strsql, Ket_noi)
            Return cmd.ExecuteScalar()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Catch ex As Exception
        End Try
    End Function
End Class

