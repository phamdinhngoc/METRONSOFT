 Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class nhanvienDao
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
        MyBase.New("nhanvien", "SELECT * FROM NHANVIEN ORDER BY MaNV", connection, MSsql)
    End Sub
    Public Sub New(ByVal ma As Integer, ByVal connection As KetNoiDto, ByVal MSsql As Boolean)
        MyBase.New("nhanvien", "SELECT * FROM NHANVIEN where MaNV=" & ma & "", connection, MSsql)
    End Sub
#End Region
    Public Sub Them(ByVal Dto As nhanviendto, ByVal MSsql As Boolean)
        Dim strsql As String
        'strsql = "Insert into nhanvien(MaNV,NVSP,TenNV,TenHT,Chucvu,Donvi,Quyen,CardNo,Ngaysinh,Gioitinh,Diachi,CMND,Ngayvaolam,Hinh) values (" & Dto.MaNV & ",'" & Dto.NVSP & "','" & Dto.TenNV & "','" & Dto.TenHT & "'," & Dto.Chucvu & "," & Dto.Donvi & "," & Dto.Quyen & ",'" & Dto.CardNo & "','" & Dto.Ngaysinh & "','" & Dto.Gioitinh & "','" & Dto.Diachi & "','" & Dto.CMND & "','" & Dto.Ngayvaolam & "','" & Dto.Hinh & "')"
        strsql = "Insert into nhanvien(MaNV,NVSP,TenNV,TenHT,Chucvu,Donvi,Quyen,CardNo,Ngaysinh,Gioitinh,Diachi,CMND,Ngayvaolam,Hinh) values (?,?,?,?,?,?,?,?,?,?,?,?,?,?)"
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            Dim cmd As New OleDbCommand(strsql, Ket_noi)
            cmd.Parameters.Add("@MaNV", OleDbType.Integer)
            cmd.Parameters.Add("@NVSP", OleDbType.WChar)
            cmd.Parameters.Add("@TenNV", OleDbType.WChar)
            cmd.Parameters.Add("@TenHT", OleDbType.WChar)
            cmd.Parameters.Add("@Chucvu", OleDbType.Integer)
            cmd.Parameters.Add("@Donvi", OleDbType.Integer)
            cmd.Parameters.Add("@Quyen", OleDbType.Integer)
            cmd.Parameters.Add("@CardNo", OleDbType.WChar)
            cmd.Parameters.Add("@Ngaysinh", OleDbType.Date)
            cmd.Parameters.Add("@Gioitinh", OleDbType.WChar)
            cmd.Parameters.Add("@Diachi", OleDbType.WChar)
            cmd.Parameters.Add("@CMND", OleDbType.WChar)
            cmd.Parameters.Add("@Ngayvaolam", OleDbType.Date)
            cmd.Parameters.Add("@Hinh", OleDbType.WChar)
            cmd.Parameters("@MaNV").Value = Dto.MaNV
            cmd.Parameters("@NVSP").Value = Dto.NVSP
            cmd.Parameters("@TenNV").Value = Dto.TenNV
            cmd.Parameters("@TenHT").Value = Dto.TenHT
            cmd.Parameters("@Chucvu").Value = Dto.Chucvu
            cmd.Parameters("@Donvi").Value = Dto.Donvi
            cmd.Parameters("@Quyen").Value = Dto.Quyen
            cmd.Parameters("@CardNo").Value = Dto.CardNo
            cmd.Parameters("@Ngaysinh").Value = Dto.Ngaysinh
            cmd.Parameters("@Gioitinh").Value = Dto.Gioitinh
            cmd.Parameters("@Diachi").Value = Dto.Diachi
            cmd.Parameters("@CMND").Value = Dto.CMND
            cmd.Parameters("@Ngayvaolam").Value = Dto.Ngayvaolam
            cmd.Parameters("@Hinh").Value = Dto.Hinh
            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception

            End Try

            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            strsql = "Insert into nhanvien(MaNV,NVSP,TenNV,TenHT,Chucvu,Donvi,Quyen,CardNo,Ngaysinh,Gioitinh,Diachi,CMND,Ngayvaolam,Hinh) values (" & Dto.MaNV & ",'" & Dto.NVSP & "','" & Dto.TenNV & "','" & Dto.TenHT & "'," & Dto.Chucvu & "," & Dto.Donvi & "," & Dto.Quyen & ",'" & Dto.CardNo & "','" & Dto.Ngaysinh & "','" & Dto.Gioitinh & "','" & Dto.Diachi & "','" & Dto.CMND & "','" & Dto.Ngayvaolam & "','" & Dto.Hinh & "')"
            Ket_noi1.Open()
            Dim cmd1 As New SqlCommand(strsql, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
        Dim daoNK As New NhatkyDao
        Dim dtoNK As New Nhatkydto

        dtoNK.User = TenNguoiDangNhap
        dtoNK.Ngay = Date.Now.Date
        dtoNK.Gio = Date.Now
        dtoNK.Tacvu = "thêm nhân viên có mã chấm công là :" & Dto.MaNV
        daoNK.Them(dtoNK, False)
    End Sub

    Public Sub ThemTTNV(ByVal MaCC As Integer, ByVal TenHT As String, ByVal MaThe As String, ByVal Quyen As Integer, ByVal MSsql As Boolean)
        Dim strsql As String
        'strsql = "Insert into nhanvien(MaNV,NVSP,TenNV,TenHT,Chucvu,Donvi,Quyen,CardNo,Ngaysinh,Gioitinh,Diachi,CMND,Ngayvaolam,Hinh) values (" & Dto.MaNV & ",'" & Dto.NVSP & "','" & Dto.TenNV & "','" & Dto.TenHT & "'," & Dto.Chucvu & "," & Dto.Donvi & "," & Dto.Quyen & ",'" & Dto.CardNo & "','" & Dto.Ngaysinh & "','" & Dto.Gioitinh & "','" & Dto.Diachi & "','" & Dto.CMND & "','" & Dto.Ngayvaolam & "','" & Dto.Hinh & "')"
        strsql = "Insert into nhanvien(MaNV,NVSP,TenNV,TenHT,Chucvu,Donvi,Quyen,CardNo,Ngaysinh,Gioitinh,Diachi,CMND,Ngayvaolam,Hinh) values (?,?,?,?,?,?,?,?,?,?,?,?,?,?)"
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            Dim cmd As New OleDbCommand(strsql, Ket_noi)
            cmd.Parameters.Add("@MaNV", OleDbType.Integer)
            cmd.Parameters.Add("@NVSP", OleDbType.WChar)
            cmd.Parameters.Add("@TenNV", OleDbType.WChar)
            cmd.Parameters.Add("@TenHT", OleDbType.WChar)
            cmd.Parameters.Add("@Chucvu", OleDbType.Integer)
            cmd.Parameters.Add("@Donvi", OleDbType.Integer)
            cmd.Parameters.Add("@Quyen", OleDbType.Integer)
            cmd.Parameters.Add("@CardNo", OleDbType.WChar)
            cmd.Parameters.Add("@Ngaysinh", OleDbType.Date)
            cmd.Parameters.Add("@Gioitinh", OleDbType.WChar)
            cmd.Parameters.Add("@Diachi", OleDbType.WChar)
            cmd.Parameters.Add("@CMND", OleDbType.WChar)
            cmd.Parameters.Add("@Ngayvaolam", OleDbType.Date)
            cmd.Parameters.Add("@Hinh", OleDbType.WChar)
            cmd.Parameters("@MaNV").Value = MaCC
            cmd.Parameters("@NVSP").Value = "NV " & MaCC
            cmd.Parameters("@TenNV").Value = TenHT
            cmd.Parameters("@TenHT").Value = TenHT
            cmd.Parameters("@Chucvu").Value = 1
            cmd.Parameters("@Donvi").Value = 1
            cmd.Parameters("@Quyen").Value = Quyen
            cmd.Parameters("@CardNo").Value = MaThe
            cmd.Parameters("@Ngaysinh").Value = #1/1/1900#
            cmd.Parameters("@Gioitinh").Value = "Nam"
            cmd.Parameters("@Diachi").Value = "..."
            cmd.Parameters("@CMND").Value = "..."
            cmd.Parameters("@Ngayvaolam").Value = #1/1/1900#
            cmd.Parameters("@Hinh").Value = "..."
            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception

            End Try

            'strsql = "Select @@IDENTITY"
            'cmd = New OleDbCommand(strsql, Ket_noi)
            'cmd.ExecuteScalar()
            '  If Ket_noi.State = ConnectionState.Open Then
            'Ket_noi.Close()
            'End If
            'Else
            '    strsql = "Insert into nhanvien(MaNV,NVSP,TenNV,TenHT,Chucvu,Donvi,Quyen,CardNo,Ngaysinh,Gioitinh,Diachi,CMND,Ngayvaolam,Hinh) values (" & Dto.MaNV & ",'" & Dto.NVSP & "','" & Dto.TenNV & "','" & Dto.TenHT & "'," & Dto.Chucvu & "," & Dto.Donvi & "," & Dto.Quyen & ",'" & Dto.CardNo & "','" & Dto.Ngaysinh & "','" & Dto.Gioitinh & "','" & Dto.Diachi & "','" & Dto.CMND & "','" & Dto.Ngayvaolam & "','" & Dto.Hinh & "')"
            '    Ket_noi1.Open()
            '    Dim cmd1 As New SqlCommand(strsql, Ket_noi1)
            '    cmd1.ExecuteNonQuery()
            '    Ket_noi1.Close()
        End If

    End Sub

    Public Sub Xoa(ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then Ket_noi.Open()
            strSQL = "Delete From nhanvien Where MaNV= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@ma", OleDbType.Integer)
            cmd.Parameters("@ma").Value = ma
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then Ket_noi.Close()
        Else
            If Ket_noi1.State = ConnectionState.Closed Then Ket_noi1.Open()
            strSQL = "Delete From nhanvien Where MaNV=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
        Dim daoNK As New NhatkyDao
        Dim dtoNK As New Nhatkydto

        dtoNK.User = TenNguoiDangNhap
        dtoNK.Ngay = Date.Now.Date
        dtoNK.Gio = Date.Now
        dtoNK.Tacvu = "Xoá nhân viên có mã chấm công là :" & ma
        daoNK.Them(dtoNK, False)
    End Sub
    Public Sub XoaTheoDonvi(ByVal madonvi As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then Ket_noi.Open()
            strSQL = "Delete From nhanvien Where donvi= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@donvi", OleDbType.Integer)
            cmd.Parameters("@donvi").Value = madonvi
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then Ket_noi.Close()
        Else
            If Ket_noi.State = ConnectionState.Closed Then Ket_noi.Open()
            strSQL = "Delete From nhanvien Where donvi=" & madonvi & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
        Dim daoNK As New NhatkyDao
        Dim dtoNK As New Nhatkydto

        dtoNK.User = TenNguoiDangNhap
        dtoNK.Ngay = Date.Now.Date
        dtoNK.Gio = Date.Now
        dtoNK.Tacvu = "Xoá nhân viên có mã đơn vị là :" & madonvi
        daoNK.Them(dtoNK, False)
    End Sub
    Public Sub sua(ByVal dto As nhanviendto, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then Ket_noi.Open()
            strSQL = "Update nhanvien Set NVSP=? ,TenNV=? ,TenHT=? ,Chucvu=? ,Donvi=? ,Quyen=? ,CardNo=? ,Ngaysinh=? ,Gioitinh=? ,Diachi=? ,CMND=? ,Ngayvaolam=? ,Hinh= ? where MaNV= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@NVSP", OleDbType.WChar)
            cmd.Parameters.Add("@TenNV", OleDbType.WChar)
            cmd.Parameters.Add("@TenHT", OleDbType.WChar)
            cmd.Parameters.Add("@Chucvu", OleDbType.Integer)
            cmd.Parameters.Add("@Donvi", OleDbType.Integer)
            cmd.Parameters.Add("@Quyen", OleDbType.Integer)
            cmd.Parameters.Add("@CardNo", OleDbType.WChar)
            cmd.Parameters.Add("@Ngaysinh", OleDbType.Date)
            cmd.Parameters.Add("@Gioitinh", OleDbType.WChar)
            cmd.Parameters.Add("@Diachi", OleDbType.WChar)
            cmd.Parameters.Add("@CMND", OleDbType.WChar)
            cmd.Parameters.Add("@Ngayvaolam", OleDbType.Date)
            cmd.Parameters.Add("@Hinh", OleDbType.WChar)
            cmd.Parameters.Add("@MaNV", OleDbType.Integer)
            cmd.Parameters("@NVSP").Value = dto.NVSP
            cmd.Parameters("@TenNV").Value = dto.TenNV
            cmd.Parameters("@TenHT").Value = dto.TenHT
            cmd.Parameters("@Chucvu").Value = dto.Chucvu
            cmd.Parameters("@Donvi").Value = dto.Donvi
            cmd.Parameters("@Quyen").Value = dto.Quyen
            cmd.Parameters("@CardNo").Value = dto.CardNo
            cmd.Parameters("@Ngaysinh").Value = dto.Ngaysinh
            cmd.Parameters("@Gioitinh").Value = dto.Gioitinh
            cmd.Parameters("@Diachi").Value = dto.Diachi
            cmd.Parameters("@CMND").Value = dto.CMND
            cmd.Parameters("@Ngayvaolam").Value = dto.Ngayvaolam
            cmd.Parameters("@Hinh").Value = dto.Hinh
            cmd.Parameters("@MaNV").Value = dto.MaNV
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then Ket_noi.Close()
        Else
            If Ket_noi.State = ConnectionState.Closed Then Ket_noi.Open()
            strSQL = "Update nhanvien Set NVSP= '" & dto.NVSP & "',TenNV= '" & dto.TenNV & "',TenHT= '" & dto.TenHT & "',Chucvu= " & dto.Chucvu & ",Donvi= " & dto.Donvi & ",Quyen= " & dto.Quyen & ",CardNo= '" & dto.CardNo & "',Ngaysinh= '" & dto.Ngaysinh & "',Gioitinh= '" & dto.Gioitinh & "',Diachi= '" & dto.Diachi & "',CMND= '" & dto.CMND & "',Ngayvaolam= '" & dto.Ngayvaolam & "',Hinh= '" & dto.Hinh & "' where MaNV=" & dto.MaNV & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
        Dim daoNK As New NhatkyDao
        Dim dtoNK As New Nhatkydto

        dtoNK.User = TenNguoiDangNhap
        dtoNK.Ngay = Date.Now.Date
        dtoNK.Gio = Date.Now
        dtoNK.Tacvu = "Sửa nhân viên có mã chấm công là " & dto.MaNV
        daoNK.Them(dtoNK, False)
    End Sub
    Public Sub SuaChucvu(ByVal Chucvu As Integer, ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then Ket_noi.Open()
            strSQL = "Update nhanvien Set Chucvu = ?  where MaNV= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@Chucvu", OleDbType.Integer)
            cmd.Parameters.Add("@MaNV", OleDbType.Integer)
            cmd.Parameters("@Chucvu").Value = Chucvu
            cmd.Parameters("@MaNV").Value = ma
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update nhanvien Set Chucvu =" & Chucvu & "  where MaNV=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaDonvi(ByVal Donvi As Integer, ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then Ket_noi.Open()
            strSQL = "Update nhanvien Set Donvi = ?  where MaNV= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@Donvi", OleDbType.Integer)
            cmd.Parameters.Add("@MaNV", OleDbType.Integer)
            cmd.Parameters("@Donvi").Value = Donvi
            cmd.Parameters("@MaNV").Value = ma
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update nhanvien Set Donvi =" & Donvi & "  where MaNV=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaQuyen(ByVal Quyen As Integer, ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then Ket_noi.Open()
            strSQL = "Update nhanvien Set Quyen = ?  where MaNV= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@Quyen", OleDbType.Integer)
            cmd.Parameters.Add("@MaNV", OleDbType.Integer)
            cmd.Parameters("@Quyen").Value = Quyen
            cmd.Parameters("@MaNV").Value = ma
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update nhanvien Set Quyen =" & Quyen & "  where MaNV=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub

    Public Sub upDateTTMay(ByVal Quyen As Integer, ByVal TenHT As String, ByVal MaThe As String, ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then Ket_noi.Open()
            strSQL = "Update nhanvien Set Quyen = ?, TenHT = ? , CardNo = ?  where MaNV= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@Quyen", OleDbType.Integer)
            cmd.Parameters.Add("@TenHT", OleDbType.VarChar)
            cmd.Parameters.Add("@CardNo", OleDbType.VarChar)
            cmd.Parameters.Add("@MaNV", OleDbType.Integer)

            cmd.Parameters("@Quyen").Value = Quyen
            cmd.Parameters("@TenHT").Value = TenHT
            cmd.Parameters("@CardNo").Value = MaThe
            cmd.Parameters("@MaNV").Value = ma
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update nhanvien Set Quyen =" & Quyen & " , TenHT = " & TenHT & ", CardNo = " & MaThe & "   where MaNV=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub


    Public Function MaThem(ByVal ketnoi As OleDbConnection) As Integer
        Try
            If ketnoi.State = ConnectionState.Closed Then ketnoi.Open()
            Dim cmd As New OleDbCommand
            Dim strsql As String = "Select max(manv) from nhanvien"
            cmd = New OleDbCommand(strsql, ketnoi)
            Return cmd.ExecuteScalar()
        Catch ex As Exception
        End Try
    End Function
    Public Function MaThem() As Integer
        Try
            Dim cmd As New OleDbCommand
            Dim strsql As String = "Select max(manv) from nhanvien"
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

