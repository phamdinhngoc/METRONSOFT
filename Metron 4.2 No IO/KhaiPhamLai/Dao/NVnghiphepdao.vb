Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class NVnghiphepDao
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
        MyBase.New("NVnghiphep", connection, MSsql)
    End Sub
    Public Sub New(ByVal ma As Integer, ByVal connection As KetNoiDto, ByVal MSsql As Boolean)
        MyBase.New("NVnghiphep", "select * from NVnghiphep where IDNP=" & ma & "", connection, MSsql)
    End Sub
#End Region
    Public Sub Them(ByVal Dto As NVnghiphepdto, ByVal MSsql As Boolean)
        Dim strsql As String
        Dim BatTat As Boolean = False
        strsql = "Insert into NVnghiphep(MaNV,Ngay,Lydo,SoNgay,SoCong) values (?,?,?,?,?)"
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            Dim cmd As New OleDbCommand(strsql, Ket_noi)
            cmd.Parameters.Add("@MaNV", OleDbType.Integer)
            cmd.Parameters.Add("@Ngay", OleDbType.Date)
            cmd.Parameters.Add("@Lydo", OleDbType.WChar)
            cmd.Parameters.Add("@SoNgay", OleDbType.Double)
            cmd.Parameters.Add("@SoCong", OleDbType.Double)
            cmd.Parameters("@MaNV").Value = Dto.MaNV
            cmd.Parameters("@Ngay").Value = Dto.Ngay
            cmd.Parameters("@Lydo").Value = Dto.Lydo
            cmd.Parameters("@SoNgay").Value = Dto.SoNgay
            cmd.Parameters("@SoCong").Value = Dto.SoCong
            cmd.ExecuteNonQuery()
            'strsql = "Select @@IDENTITY"
            'cmd = New OleDbCommand(strsql, Ket_noi)
            'Dto.IDNP = cmd.ExecuteScalar()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            strsql = "Insert into NVnghiphep(IDNP,MaNV,Ngay,Lydo,SoNgay,SoCong) values (" & Dto.IDNP & "," & Dto.MaNV & ",'" & Dto.Ngay & "','" & Dto.Lydo & "'," & Dto.SoNgay & "," & Dto.SoCong & ")"
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
            strSQL = "Delete From NVnghiphep Where IDNP= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@ma", OleDbType.Integer)
            cmd.Parameters("@ma").Value = ma
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            Ket_noi1.Open()
            strSQL = "Delete From NVnghiphep Where IDNP=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub sua(ByVal dto As NVnghiphepdto, ByVal MSsql As Boolean)
        Dim strSQL As String
        Dim BatTat As Boolean = False
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            strSQL = "Update NVnghiphep Set MaNV=? ,Ngay=? ,Lydo=? ,SoNgay=? ,SoCong= ? where IDNP= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@MaNV", OleDbType.Integer)
            cmd.Parameters.Add("@Ngay", OleDbType.Date)
            cmd.Parameters.Add("@Lydo", OleDbType.WChar)
            cmd.Parameters.Add("@SoNgay", OleDbType.Double)
            cmd.Parameters.Add("@SoCong", OleDbType.Double)
            cmd.Parameters.Add("@IDNP", OleDbType.Integer)
            cmd.Parameters("@MaNV").Value = dto.MaNV
            cmd.Parameters("@Ngay").Value = dto.Ngay
            cmd.Parameters("@Lydo").Value = dto.Lydo
            cmd.Parameters("@SoNgay").Value = dto.SoNgay
            cmd.Parameters("@SoCong").Value = dto.SoCong
            cmd.Parameters("@IDNP").Value = dto.IDNP
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            Ket_noi1.Open()
            strSQL = "Update NVnghiphep Set MaNV= " & dto.MaNV & ",Ngay= '" & dto.Ngay & "',Lydo= '" & dto.Lydo & "',SoNgay= " & dto.SoNgay & ",SoCong= " & dto.SoCong & " where IDNP=" & dto.IDNP & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaMaNV(ByVal MaNV As Integer, ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            Ket_noi.Open()
            strSQL = "Update NVnghiphep Set MaNV = ?  where IDNP= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@MaNV", OleDbType.Integer)
            cmd.Parameters.Add("@IDNP", OleDbType.Integer)
            cmd.Parameters("@MaNV").Value = MaNV
            cmd.Parameters("@IDNP").Value = ma
            cmd.ExecuteNonQuery()
            Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update NVnghiphep Set MaNV =" & MaNV & "  where IDNP=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaSoNgay(ByVal SoNgay As Integer, ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            Ket_noi.Open()
            strSQL = "Update NVnghiphep Set SoNgay = ?  where IDNP= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@SoNgay", OleDbType.Double)
            cmd.Parameters.Add("@IDNP", OleDbType.Integer)
            cmd.Parameters("@SoNgay").Value = SoNgay
            cmd.Parameters("@IDNP").Value = ma
            cmd.ExecuteNonQuery()
            Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update NVnghiphep Set SoNgay =" & SoNgay & "  where IDNP=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaSoCong(ByVal SoCong As Integer, ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            Ket_noi.Open()
            strSQL = "Update NVnghiphep Set SoCong = ?  where IDNP= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@SoCong", OleDbType.Double)
            cmd.Parameters.Add("@IDNP", OleDbType.Integer)
            cmd.Parameters("@SoCong").Value = SoCong
            cmd.Parameters("@IDNP").Value = ma
            cmd.ExecuteNonQuery()
            Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update NVnghiphep Set SoCong =" & SoCong & "  where IDNP=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub TongCongTheoNvidTungayDenNgay(ByVal manv As Integer, ByVal tungay As Date, ByVal dengay As Date)
        Dim strsql As String
        Dim BatTat As Boolean = False
        strsql = "Select sum(SoNgay), sum(socong) from NVnghiphep where  MaNV=? and ngay>=? and ngay <=?"
        If Ket_noi.State = ConnectionState.Closed Then
            Ket_noi.Open()
        End If
        Dim cmd As New OleDbCommand(strsql, Ket_noi)
        cmd.Parameters.Add("@MaNV", OleDbType.Integer)
        cmd.Parameters.Add("@NgayTu", OleDbType.Date)
        cmd.Parameters.Add("@NgayDen", OleDbType.Date)
        cmd.Parameters("@MaNV").Value = manv
        cmd.Parameters("@NgayTu").Value = tungay.Date
        cmd.Parameters("@NgayDen").Value = dengay.Date & " " & #11:59:59 PM#
        mBo_doc_ghi = New OleDbDataAdapter(cmd)
        mBo_doc_ghi.FillSchema(Me, SchemaType.Mapped)
        mBo_doc_ghi.Fill(Me)
        If Ket_noi.State = ConnectionState.Open Then
            Ket_noi.Close()
        End If
    End Sub
    Public Sub LaybangTheoNvidTungayDenNgay(ByVal manv As Integer, ByVal tungay As Date, ByVal dengay As Date)
        Dim strsql As String
        Dim BatTat As Boolean = False
        strsql = "Select * from NVnghiphep where  MaNV=? and ngay>=? and ngay <=?"
        If Ket_noi.State = ConnectionState.Closed Then
            Ket_noi.Open()
        End If
        Dim cmd As New OleDbCommand(strsql, Ket_noi)
        cmd.Parameters.Add("@MaNV", OleDbType.Integer)
        cmd.Parameters.Add("@NgayTu", OleDbType.Date)
        cmd.Parameters.Add("@NgayDen", OleDbType.Date)
        cmd.Parameters("@MaNV").Value = manv
        cmd.Parameters("@NgayTu").Value = tungay.Date
        cmd.Parameters("@NgayDen").Value = dengay.Date
        mBo_doc_ghi = New OleDbDataAdapter(cmd)
        mBo_doc_ghi.FillSchema(Me, SchemaType.Mapped)
        mBo_doc_ghi.Fill(Me)
        If Ket_noi.State = ConnectionState.Open Then
            Ket_noi.Close()
        End If
    End Sub
    Public Sub LaybangTheoTungayDenNgay(ByVal tungay As Date, ByVal dengay As Date)
        Dim strsql As String
        Dim BatTat As Boolean = False
        strsql = "Select * from NVnghiphep,nhanvien where nhanvien.manv=NVnghiphep.manv  and ngay>=? and ngay <=?"
        If Ket_noi.State = ConnectionState.Closed Then
            Ket_noi.Open()
        End If
        Dim cmd As New OleDbCommand(strsql, Ket_noi)
        cmd.Parameters.Add("@NgayTu", OleDbType.Date)
        cmd.Parameters.Add("@NgayDen", OleDbType.Date)
        cmd.Parameters("@NgayTu").Value = tungay.Date
        cmd.Parameters("@NgayDen").Value = dengay.Date
        mBo_doc_ghi = New OleDbDataAdapter(cmd)
        mBo_doc_ghi.FillSchema(Me, SchemaType.Mapped)
        mBo_doc_ghi.Fill(Me)
        If Ket_noi.State = ConnectionState.Open Then
            Ket_noi.Close()
        End If
    End Sub
    Public Sub LaybangTheoTungayDenNgayvaDieukien(ByVal tungay As Date, ByVal dengay As Date)
        Dim strsql As String
        Dim BatTat As Boolean = False
        strsql = "SELECT NVBC.MaCC, NVBC.MaNV, NVBC.TenNV, NVBC.Chucvu, NVBC.Bophan, NVNghiPhep.Ngay, NVNghiPhep.Lydo, NVNghiPhep.SoNgay, NVNghiPhep.SoCong FROM NVNghiPhep INNER JOIN NVBC ON NVNghiPhep.MaNV = NVBC.MaCC where ngay>=? and ngay <=?"
        If Ket_noi.State = ConnectionState.Closed Then
            Ket_noi.Open()
        End If
        Dim cmd As New OleDbCommand(strsql, Ket_noi)
        cmd.Parameters.Add("@NgayTu", OleDbType.Date)
        cmd.Parameters.Add("@NgayDen", OleDbType.Date)
        cmd.Parameters("@NgayTu").Value = tungay.Date
        cmd.Parameters("@NgayDen").Value = dengay.Date
        mBo_doc_ghi = New OleDbDataAdapter(cmd)
        mBo_doc_ghi.FillSchema(Me, SchemaType.Mapped)
        mBo_doc_ghi.Fill(Me)
        If Ket_noi.State = ConnectionState.Open Then
            Ket_noi.Close()
        End If
    End Sub
End Class

