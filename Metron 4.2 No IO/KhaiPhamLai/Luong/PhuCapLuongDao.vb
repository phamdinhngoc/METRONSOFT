Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class PhuCapLuongDao
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
        MyBase.New("PhuCapLuong", connection, MSsql)
    End Sub
    Public Sub New(ByVal ma As Integer, ByVal connection As KetNoiDto, ByVal MSsql As Boolean)
        MyBase.New("PhuCapLuong", "select * from PhuCapLuong where ID=" & ma & "", connection, MSsql)
    End Sub
#End Region
    Public Sub Them(ByVal Dto As Phucapluongdto, ByVal MSsql As Boolean)
        Dim strsql As String
        Dim BatTat As Boolean = False
        strsql = "Insert into PhuCapLuong(TienComTrua,TienXe,TienAnTC1,TienAnTC2) values (?,?,?,?)"
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            Dim cmd As New OleDbCommand(strsql, Ket_noi)
            'cmd.Parameters.Add("@ID", OleDbType.Integer)

            cmd.Parameters.Add("@TienComTrua", OleDbType.Double)
            cmd.Parameters.Add("@TienXe", OleDbType.Double)
            cmd.Parameters.Add("@TienAnTC1", OleDbType.Double)
            cmd.Parameters.Add("@TienAnTC2", OleDbType.Double)
           
            'cmd.Parameters("@ID").Value = Dto.ID

            cmd.Parameters("@TienComTrua").Value = Dto.TienComTrua
            cmd.Parameters("@TienXe").Value = Dto.TienXe
            cmd.Parameters("@TienAnTC1").Value = Dto.TienAnTC1
            cmd.Parameters("@TienAnTC2").Value = Dto.TienAnTC2
           
            cmd.ExecuteNonQuery()
            strsql = "Select @@IDENTITY"
            cmd = New OleDbCommand(strsql, Ket_noi)
            Dto.ID = cmd.ExecuteScalar()
            ' If Ket_noi.State = ConnectionState.Open Then
            ' Ket_noi.Close()
            ' End If
        Else
            'strsql = "Insert into caTD(ID,MaNV,Caid,TuNgay,DenNgay,Tangca,TangcaS,GhTangca) values (" & Dto.ID & "," & Dto.MaNV & "," & Dto.Caid & ",'" & Dto.TuNgay & "','" & Dto.DenNgay & "'," & Dto.Tangca & "," & Dto.TangcaS & "," & Dto.GhTangca & ")"
            'Ket_noi1.Open()
            'Dim cmd1 As New SqlCommand(strsql, Ket_noi1)
            'cmd1.ExecuteNonQuery()
            'Ket_noi1.Close()
        End If
    End Sub
    Public Sub Xoa(ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        Dim BatTat As Boolean = False
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            strSQL = "Delete From PhuCapLuong Where ID= ? "
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
            strSQL = "Delete* From PhuCapLuong "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)

            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If

        End If
    End Sub

   

    Public Sub sua(ByVal dto As Phucapluongdto, ByVal MSsql As Boolean)
        Dim strSQL As String
        Dim BatTat As Boolean = False
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            strSQL = "Update PhuCapLuong Set TienComTrua=? ,TienXe=? ,TienAnTC1=? ,TienAnTC2=? where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)

            cmd.Parameters.Add("@TienComTrua", OleDbType.Double)
            cmd.Parameters.Add("@TienXe", OleDbType.Double)
            cmd.Parameters.Add("@TienAnTC1", OleDbType.Double)
            cmd.Parameters.Add("@TienAnTC2", OleDbType.Double)
            cmd.Parameters.Add("@ID", OleDbType.Integer)

            cmd.Parameters("@TienComTrua").Value = dto.TienComTrua
            cmd.Parameters("@TienXe").Value = dto.TienXe
            cmd.Parameters("@TienAnTC1").Value = dto.TienAnTC1
            cmd.Parameters("@TienAnTC2").Value = dto.TienAnTC2
            cmd.Parameters("@ID").Value = dto.ID
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            Ket_noi1.Open()
            'strSQL = "Update caTD Set MaNV= " & dto.MaNV & ",Caid= " & dto.Caid & ",TuNgay= '" & dto.TuNgay & "',DenNgay= '" & dto.DenNgay & "',Tangca= " & dto.Tangca & ",TangcaS= " & dto.TangcaS & ",GhTangca= " & dto.GhTangca & " where ID=" & dto.ID & ""
            'Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            'cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
End Class
