Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class NgayleDao
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
        MyBase.New("Ngayle", connection, MSsql)
    End Sub
    Public Sub New(ByVal ma As String, ByVal connection As KetNoiDto, ByVal MSsql As Boolean)
        MyBase.New("Ngayle", "select * from Ngayle where Ngay=#" & ma & "#", connection, MSsql)
    End Sub
#End Region
    Public Sub laybang(ByVal ngay As Date, ByVal MSsql As Boolean)
        Dim strsql As String
        strsql = "select * from Ngayle where Ngay=?"
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            Dim cmd As New OleDbCommand(strsql, Ket_noi)
            cmd.Parameters.Add("@Ngay", OleDbType.Date)
            cmd.Parameters("@Ngay").Value = ngay
            mBo_doc_ghi = New OleDbDataAdapter(cmd)
            mBo_doc_ghi.FillSchema(Me, SchemaType.Mapped)
            mBo_doc_ghi.Fill(Me)
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        End If
    End Sub
    Public Sub laybang(ByVal tungay As Date, ByVal denngay As Date, ByVal MSsql As Boolean)
        Dim strsql As String
        strsql = "select * from Ngayle where Ngay >= ? and Ngay <= ?"
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            Dim cmd As New OleDbCommand(strsql, Ket_noi)
            cmd.Parameters.Add("@Tungay", OleDbType.Date)
            cmd.Parameters.Add("@Denngay", OleDbType.Date)
            cmd.Parameters("@Tungay").Value = tungay.ToLongDateString
            cmd.Parameters("@Denngay").Value = denngay.ToLongDateString
            mBo_doc_ghi = New OleDbDataAdapter(cmd)
            mBo_doc_ghi.FillSchema(Me, SchemaType.Mapped)
            mBo_doc_ghi.Fill(Me)
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        End If
    End Sub
    Public Sub Them(ByVal Dto As Ngayledto, ByVal MSsql As Boolean)
        Dim strsql As String
        strsql = "Insert into Ngayle(Ngay,ChuThich) values (?,?)"
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            Dim cmd As New OleDbCommand(strsql, Ket_noi)
            cmd.Parameters.Add("@Ngay", OleDbType.Date)
            cmd.Parameters.Add("@ChuThich", OleDbType.WChar)
            cmd.Parameters("@Ngay").Value = Dto.Ngay
            cmd.Parameters("@ChuThich").Value = Dto.ChuThich
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            strsql = "Insert into Ngayle(Ngay,ChuThich) values ('" & Dto.Ngay & "','" & Dto.ChuThich & "')"
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
            strSQL = "Delete From Ngayle Where Ngay= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@ma", OleDbType.Date)
            cmd.Parameters("@ma").Value = ma
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            Ket_noi1.Open()
            strSQL = "Delete From Ngayle Where Ngay='" & ma & "'"
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub sua(ByVal dto As Ngayledto, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            strSQL = "Update Ngayle Set ChuThich= ? where Ngay= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@ChuThich", OleDbType.WChar)
            cmd.Parameters.Add("@Ngay", OleDbType.Date)
            cmd.Parameters("@ChuThich").Value = dto.ChuThich
            cmd.Parameters("@Ngay").Value = dto.Ngay
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            Ket_noi1.Open()
            strSQL = "Update Ngayle Set ChuThich= '" & dto.ChuThich & "' where Ngay='" & dto.Ngay & "'"
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
End Class

