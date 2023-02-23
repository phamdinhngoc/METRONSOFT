 Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class VaoraDao
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
    Public Sub New(ByVal connection As KetNoiDto)
        MyBase.New(connection)
    End Sub
    Public Sub New(ByVal connection As KetNoiDto, ByVal MSsql As Boolean)
        MyBase.New("Vaora", connection, MSsql)
    End Sub
    Public Sub New(ByVal ma As Integer, ByVal connection As KetNoiDto, ByVal MSsql As Boolean)
        MyBase.New("Vaora", "select * from Vaora where ID=" & ma & "", connection, MSsql)
    End Sub
#End Region
    Public Function laybangtheoNGayvaMacc(ByVal ngay As DateTime, ByVal manv As Integer) As OleDb.OleDbDataReader
        Try
            Dim strsql As String = "select Thoigian,kieu from vaora where ngay = ? and manv = ? order by thoigian"
            If Ket_noi.State = ConnectionState.Closed Then Ket_noi.Open()
            Dim cmd As New OleDbCommand(strsql, Ket_noi)
            cmd.Parameters.Add("@ngay", OleDbType.Date).Value = ngay
            cmd.Parameters.Add("@manv", OleDbType.Integer).Value = manv
            Return cmd.ExecuteReader
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function laybangBaocaoThoiGian(ByVal tungay As DateTime, ByVal denngay As DateTime, ByVal DonVi As Integer) As OleDb.OleDbDataReader
        Try
            Dim strsql As String = "SELECT Nhanvien.MaNV, Nhanvien.NVSP, Nhanvien.TenNV, chucvu.Chucvu as chucvu1, Donvi.TenDV, vaora.Ngay, vaora.Thoigian , iif(((vaora.kieu=0) or (vaora.kieu=2) or (vaora.kieu=-1)),'Vao','Ra') as TThai " & _
                                "FROM vaora INNER JOIN (Donvi INNER JOIN (Nhanvien INNER JOIN chucvu ON Nhanvien.Chucvu = chucvu.CVID) ON Donvi.MaDV = Nhanvien.Donvi) ON vaora.MaNV = Nhanvien.MaNV" & _
                                " WHERE (DonVi.MaDV=PDonVi) and (Vaora.Thoigian>=PTuNgay) and (Vaora.Thoigian<=PDenNgay) ORDER BY Thoigian"

            If Ket_noi.State = ConnectionState.Closed Then Ket_noi.Open()
            Dim cmd As New OleDbCommand(strsql, Ket_noi)
            cmd.Parameters.Add("PDonVi", OleDbType.Integer).Value = DonVi
            cmd.Parameters.Add("PTuNgay", OleDbType.Date).Value = tungay
            cmd.Parameters.Add("PDenNgay", OleDbType.Date).Value = denngay
            mBo_doc_ghi = New OleDbDataAdapter(cmd)
            mBo_doc_ghi.FillSchema(Me, SchemaType.Mapped)
            mBo_doc_ghi.Fill(Me)
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function laybangBaocaoThoiGianALl(ByVal tungay As DateTime, ByVal denngay As DateTime) As OleDb.OleDbDataReader
        Try
            Dim strsql As String = "SELECT Nhanvien.MaNV, Nhanvien.NVSP, Nhanvien.TenNV, chucvu.Chucvu as chucvu1, Donvi.TenDV, vaora.Ngay, vaora.Thoigian , iif(((vaora.kieu=0) or (vaora.kieu=2) or (vaora.kieu=-1)),'Vao','Ra') as TThai " & _
                                "FROM vaora INNER JOIN (Donvi INNER JOIN (Nhanvien INNER JOIN chucvu ON Nhanvien.Chucvu = chucvu.CVID) ON Donvi.MaDV = Nhanvien.Donvi) ON vaora.MaNV = Nhanvien.MaNV" & _
                                " WHERE (Vaora.Thoigian>=PTuNgay) and (Vaora.Thoigian<=PDenNgay) ORDER BY Thoigian"

            If Ket_noi.State = ConnectionState.Closed Then Ket_noi.Open()
            Dim cmd As New OleDbCommand(strsql, Ket_noi)

            cmd.Parameters.Add("PTuNgay", OleDbType.Date).Value = tungay
            cmd.Parameters.Add("PDenNgay", OleDbType.Date).Value = denngay
            mBo_doc_ghi = New OleDbDataAdapter(cmd)
            mBo_doc_ghi.FillSchema(Me, SchemaType.Mapped)
            mBo_doc_ghi.Fill(Me)
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Public Function laybangBaocaoThoiGianVaoALl(ByVal tungay As DateTime, ByVal denngay As DateTime) As OleDb.OleDbDataReader
        Try
            Dim strsql As String = "SELECT Nhanvien.MaNV, Nhanvien.NVSP, Nhanvien.TenNV, chucvu.Chucvu as chucvu1, Donvi.TenDV, vaora.Ngay, vaora.Thoigian " & _
                                "FROM vaora INNER JOIN (Donvi INNER JOIN (Nhanvien INNER JOIN chucvu ON Nhanvien.Chucvu = chucvu.CVID) ON Donvi.MaDV = Nhanvien.Donvi) ON vaora.MaNV = Nhanvien.MaNV" & _
                                " WHERE (Vaora.Thoigian>=PTuNgay) and (Vaora.Thoigian<=PDenNgay) and ((vaora.kieu=0) or (vaora.kieu=2) or (vaora.kieu=-1) or (vaora.kieu=-4)) ORDER BY Thoigian"

            If Ket_noi.State = ConnectionState.Closed Then Ket_noi.Open()
            Dim cmd As New OleDbCommand(strsql, Ket_noi)

            cmd.Parameters.Add("PTuNgay", OleDbType.Date).Value = tungay
            cmd.Parameters.Add("PDenNgay", OleDbType.Date).Value = denngay
            mBo_doc_ghi = New OleDbDataAdapter(cmd)
            mBo_doc_ghi.FillSchema(Me, SchemaType.Mapped)
            mBo_doc_ghi.Fill(Me)
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Public Function laybangBaocaoThoiGianVao(ByVal tungay As DateTime, ByVal denngay As DateTime, ByVal DonVi As Integer) As OleDb.OleDbDataReader
        Try
            Dim strsql As String = "SELECT Nhanvien.MaNV, Nhanvien.NVSP, Nhanvien.TenNV, chucvu.Chucvu as chucvu1, Donvi.TenDV, vaora.Ngay, vaora.Thoigian " & _
                                "FROM vaora INNER JOIN (Donvi INNER JOIN (Nhanvien INNER JOIN chucvu ON Nhanvien.Chucvu = chucvu.CVID) ON Donvi.MaDV = Nhanvien.Donvi) ON vaora.MaNV = Nhanvien.MaNV" & _
                                " WHERE (DonVi.MaDV=PDonVi) and (Vaora.Thoigian>=PTuNgay) and (Vaora.Thoigian<=PDenNgay)  and ((vaora.kieu=0) or (vaora.kieu=2) or (vaora.kieu=-1) or (vaora.kieu=-4)) ORDER BY Thoigian"

            If Ket_noi.State = ConnectionState.Closed Then Ket_noi.Open()
            Dim cmd As New OleDbCommand(strsql, Ket_noi)

            cmd.Parameters.Add("PDonVi", OleDbType.Integer).Value = DonVi
            cmd.Parameters.Add("PTuNgay", OleDbType.Date).Value = tungay
            cmd.Parameters.Add("PDenNgay", OleDbType.Date).Value = denngay
            mBo_doc_ghi = New OleDbDataAdapter(cmd)
            mBo_doc_ghi.FillSchema(Me, SchemaType.Mapped)
            mBo_doc_ghi.Fill(Me)
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Public Function laybangBaocaoThoiGianRaALl(ByVal tungay As DateTime, ByVal denngay As DateTime) As OleDb.OleDbDataReader
        Try
            Dim strsql As String = "SELECT Nhanvien.MaNV, Nhanvien.NVSP, Nhanvien.TenNV, chucvu.Chucvu as chucvu1, Donvi.TenDV, vaora.Ngay, vaora.Thoigian " & _
                                "FROM vaora INNER JOIN (Donvi INNER JOIN (Nhanvien INNER JOIN chucvu ON Nhanvien.Chucvu = chucvu.CVID) ON Donvi.MaDV = Nhanvien.Donvi) ON vaora.MaNV = Nhanvien.MaNV" & _
                                " WHERE (Vaora.Thoigian>=PTuNgay) and (Vaora.Thoigian<=PDenNgay) and ((vaora.kieu=1) or (vaora.kieu=3) or (vaora.kieu=-2) or (vaora.kieu=-3)) ORDER BY Thoigian"

            If Ket_noi.State = ConnectionState.Closed Then Ket_noi.Open()
            Dim cmd As New OleDbCommand(strsql, Ket_noi)

            cmd.Parameters.Add("PTuNgay", OleDbType.Date).Value = tungay
            cmd.Parameters.Add("PDenNgay", OleDbType.Date).Value = denngay
            mBo_doc_ghi = New OleDbDataAdapter(cmd)
            mBo_doc_ghi.FillSchema(Me, SchemaType.Mapped)
            mBo_doc_ghi.Fill(Me)
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Public Function laybangBaocaoThoiGianRa(ByVal tungay As DateTime, ByVal denngay As DateTime, ByVal DonVi As Integer) As OleDb.OleDbDataReader
        Try
            Dim strsql As String = "SELECT Nhanvien.MaNV, Nhanvien.NVSP, Nhanvien.TenNV, chucvu.Chucvu as chucvu1, Donvi.TenDV, vaora.Ngay, vaora.Thoigian " & _
                                "FROM vaora INNER JOIN (Donvi INNER JOIN (Nhanvien INNER JOIN chucvu ON Nhanvien.Chucvu = chucvu.CVID) ON Donvi.MaDV = Nhanvien.Donvi) ON vaora.MaNV = Nhanvien.MaNV" & _
                                " WHERE (DonVi.MaDV=PDonVi) and (Vaora.Thoigian>=PTuNgay) and (Vaora.Thoigian<=PDenNgay)  and ((vaora.kieu=1) or (vaora.kieu=3) or (vaora.kieu=-2) or (vaora.kieu=-3)) ORDER BY Thoigian"

            If Ket_noi.State = ConnectionState.Closed Then Ket_noi.Open()
            Dim cmd As New OleDbCommand(strsql, Ket_noi)

            cmd.Parameters.Add("PDonVi", OleDbType.Integer).Value = DonVi
            cmd.Parameters.Add("PTuNgay", OleDbType.Date).Value = tungay
            cmd.Parameters.Add("PDenNgay", OleDbType.Date).Value = denngay
            mBo_doc_ghi = New OleDbDataAdapter(cmd)
            mBo_doc_ghi.FillSchema(Me, SchemaType.Mapped)
            mBo_doc_ghi.Fill(Me)
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Public Function laybangBaocaoNGay(ByVal tungay As DateTime, ByVal denngay As DateTime) As OleDb.OleDbDataReader
        Try
            Dim strsql As String = "select MaCC, MaNV, TenNV, ChucVu, BoPhan, Ngay, Gio, TMay from QNhatKyCC where  ngay >= ? and ngay <= ? order by ngay"
            If Ket_noi.State = ConnectionState.Closed Then Ket_noi.Open()
            Dim cmd As New OleDbCommand(strsql, Ket_noi)
            cmd.Parameters.Add("@tungay", OleDbType.Date).Value = tungay.Date
            cmd.Parameters.Add("@denngay", OleDbType.Date).Value = denngay.Date & " " & #11:59:59 PM#
            mBo_doc_ghi = New OleDbDataAdapter(cmd)
            mBo_doc_ghi.FillSchema(Me, SchemaType.Mapped)
            mBo_doc_ghi.Fill(Me)
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Public Sub laybangTabletheoNgayvaMacc(ByVal ngay As DateTime, ByVal manv As Integer)
        Try
            Dim strsql As String = "select Thoigian,kieu from vaora where ngay = ? and manv = ? and Kieu<>-10 order by thoigian"
            If Ket_noi.State = ConnectionState.Closed Then Ket_noi.Open()
            Dim cmd As New OleDbCommand(strsql, Ket_noi)
            cmd.Parameters.Add("@ngay", OleDbType.Date).Value = ngay.ToLongDateString
            cmd.Parameters.Add("@manv", OleDbType.Integer).Value = manv
            mBo_doc_ghi = New OleDbDataAdapter(cmd)
            mBo_doc_ghi.FillSchema(Me, SchemaType.Mapped)
            mBo_doc_ghi.Fill(Me)
            'If Ket_noi.State = ConnectionState.Open Then
            'Ket_noi.Close()
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub laybangTabletNgayvaMaccLetgio(ByVal ngay As DateTime, ByVal manv As Integer, ByVal gio As Integer)
        Try
            Dim strsql As String = "select Thoigian,kieu from vaora where Thoigian >= ? and Thoigian <= ? and manv = ? and Kieu <>-10 order by thoigian"
            If Ket_noi.State = ConnectionState.Closed Then Ket_noi.Open()
            Dim cmd As New OleDbCommand(strsql, Ket_noi)
            cmd.Parameters.Add("@tungay", OleDbType.Date).Value = ngay.ToLongDateString & " #" & gio & ":00:00 AM#"
            cmd.Parameters.Add("@denngay", OleDbType.Date).Value = DateAdd(DateInterval.DayOfYear, 1, ngay).ToLongDateString & " #" & gio & ":00:00 AM#"
            cmd.Parameters.Add("@manv", OleDbType.Integer).Value = manv
            mBo_doc_ghi = New OleDbDataAdapter(cmd)
            mBo_doc_ghi.FillSchema(Me, SchemaType.Mapped)
            mBo_doc_ghi.Fill(Me)
            'If Ket_noi.State = ConnectionState.Open Then
            'Ket_noi.Close()
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub laybangTabletheoTuNgayvaDenNgayvaMacc(ByVal tungay As DateTime, ByVal denngay As DateTime, ByVal manv As Integer)
        Try
            Dim strsql As String = "select Thoigian,kieu from vaora where ngay >= PTuNgay and ngay <= PDenNgay and manv = PMaNV and Kieu <>-10 order by thoigian"
            If Ket_noi.State = ConnectionState.Closed Then Ket_noi.Open()
            Dim cmd As New OleDbCommand(strsql, Ket_noi)
            cmd.Parameters.Add("PTuNgay", OleDbType.Date).Value = tungay.ToLongDateString
            cmd.Parameters.Add("PDenNgay", OleDbType.Date).Value = denngay.ToLongDateString & " " & #11:59:59 PM#
            cmd.Parameters.Add("PMaNV", OleDbType.Integer).Value = manv
            mBo_doc_ghi = New OleDbDataAdapter(cmd)
            mBo_doc_ghi.FillSchema(Me, SchemaType.Mapped)
            mBo_doc_ghi.Fill(Me)
            'If Ket_noi.State = ConnectionState.Open Then
            'Ket_noi.Close()
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    
    Public Sub Them(ByVal Dto As Vaoradto, ByVal MSsql As Boolean)
        Dim strsql As String
        Dim BatTat As Boolean = False
        strsql = "Insert into Vaora(MaNV,Thoigian,Kieu,May,Ngay) values (?,?,?,?,?)"
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            Dim cmd As New OleDbCommand(strsql, Ket_noi)
            cmd.Parameters.Add("@MaNV", OleDbType.Integer)
            cmd.Parameters.Add("@Thoigian", OleDbType.Date)
            cmd.Parameters.Add("@Kieu", OleDbType.Integer)
            cmd.Parameters.Add("@May", OleDbType.Integer)
            cmd.Parameters.Add("@Ngay", OleDbType.Date)
            cmd.Parameters("@MaNV").Value = Dto.MaNV
            cmd.Parameters("@Thoigian").Value = Dto.Thoigian
            cmd.Parameters("@Kieu").Value = Dto.Kieu
            cmd.Parameters("@May").Value = Dto.May
            cmd.Parameters("@Ngay").Value = Dto.Ngay
            Try
                cmd.ExecuteNonQuery()
                strsql = "Select @@IDENTITY"
                cmd = New OleDbCommand(strsql, Ket_noi)
                Dto.ID = cmd.ExecuteScalar()
            Catch ex As Exception

            End Try


            '  If Ket_noi.State = ConnectionState.Open Then
            'Ket_noi.Close()
            '  End If

        Else
            strsql = "Insert into Vaora(ID,MaNV,Thoigian,Kieu,May,Ngay) values (" & Dto.ID & "," & Dto.MaNV & ",'" & Dto.Thoigian & "'," & Dto.Kieu & "," & Dto.May & ",'" & Dto.Ngay & "')"
            Ket_noi1.Open()
            Dim cmd1 As New SqlCommand(strsql, Ket_noi1)
            Try
                cmd1.ExecuteNonQuery()
            Catch ex As Exception

            End Try

            Ket_noi1.Close()
        End If
    End Sub
    Public Sub XoatheoMaNVvaThoigian(ByVal MaNV As Integer, ByVal thoigian As Date, ByVal MSsql As Boolean)
        Dim strSQL As String
        Dim BatTat As Boolean = False
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            strSQL = "UPDATE Vaora SET Kieu = -10 Where MaNV=? and Thoigian=? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@manv", OleDbType.Integer)
            cmd.Parameters.Add("@thoigian", OleDbType.Date)
            cmd.Parameters("@manv").Value = manv
            cmd.Parameters("@thoigian").Value = thoigian
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            Ket_noi1.Open()
            strSQL = "Delete From Vaora Where MaNV= " & MaNV & " and Thoigian= #" & thoigian & "#"
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub

    Public Sub XoaTuNgayDenNgayAll(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal MSsql As Boolean)
        Dim strSQL As String
        Dim BatTat As Boolean = False
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            strSQL = "DELETE * FROM Vaora Where Ngay>=PTuNgay and Ngay<=PDenNgay"
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("PTuNgay", OleDbType.Date).Value = TuNgay.Date
            cmd.Parameters.Add("PDenNgay", OleDbType.Date).Value = DenNgay.Date & " " & #11:59:59 PM#

            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If

        End If
    End Sub


    Public Sub XoaTuNgayDenNgay(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal MSsql As Boolean)
        Dim strSQL As String
        Dim BatTat As Boolean = False
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            strSQL = "DELETE * FROM Vaora Where Ngay>=PTuNgay and Ngay<=PDenNgay and Kieu<0"
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("PTuNgay", OleDbType.Date).Value = TuNgay.Date
            cmd.Parameters.Add("PDenNgay", OleDbType.Date).Value = DenNgay.Date & " " & #11:59:59 PM#

            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If

        End If
    End Sub



    Public Sub Xoa(ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        Dim BatTat As Boolean = False
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            strSQL = "Delete From Vaora Where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@ma", OleDbType.Integer)
            cmd.Parameters("@ma").Value = ma
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            Ket_noi1.Open()
            strSQL = "Delete From Vaora Where ID=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub sua(ByVal dto As Vaoradto, ByVal MSsql As Boolean)
        Dim strSQL As String
        Dim BatTat As Boolean = False
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            strSQL = "Update Vaora Set MaNV=? ,Thoigian=? ,Kieu=? ,May=? ,Ngay= ? where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@MaNV", OleDbType.Integer)
            cmd.Parameters.Add("@Thoigian", OleDbType.Date)
            cmd.Parameters.Add("@Kieu", OleDbType.Integer)
            cmd.Parameters.Add("@May", OleDbType.Integer)
            cmd.Parameters.Add("@Ngay", OleDbType.Date)
            cmd.Parameters.Add("@ID", OleDbType.Integer)
            cmd.Parameters("@MaNV").Value = dto.MaNV
            cmd.Parameters("@Thoigian").Value = dto.Thoigian
            cmd.Parameters("@Kieu").Value = dto.Kieu
            cmd.Parameters("@May").Value = dto.May
            cmd.Parameters("@Ngay").Value = dto.Ngay
            cmd.Parameters("@ID").Value = dto.ID
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            Ket_noi1.Open()
            strSQL = "Update Vaora Set MaNV= " & dto.MaNV & ",Thoigian= '" & dto.Thoigian & "',Kieu= " & dto.Kieu & ",May= " & dto.May & ",Ngay= '" & dto.Ngay & "' where ID=" & dto.ID & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaMaNV(ByVal MaNV As Integer, ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then Ket_noi.Open()
            strSQL = "Update Vaora Set MaNV = ?  where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@MaNV", OleDbType.Integer)
            cmd.Parameters.Add("@ID", OleDbType.Integer)
            cmd.Parameters("@MaNV").Value = MaNV
            cmd.Parameters("@ID").Value = ma
            cmd.ExecuteNonQuery()
            Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update Vaora Set MaNV =" & MaNV & "  where ID=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaKieu(ByVal Kieu As Integer, ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then Ket_noi.Open()
            strSQL = "Update Vaora Set Kieu = ?  where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@Kieu", OleDbType.Integer)
            cmd.Parameters.Add("@ID", OleDbType.Integer)
            cmd.Parameters("@Kieu").Value = Kieu
            cmd.Parameters("@ID").Value = ma
            cmd.ExecuteNonQuery()
            Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update Vaora Set Kieu =" & Kieu & "  where ID=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub

    Public Sub SuaKieu(ByVal Kieu As Integer, ByVal MaNV As Integer, ByVal ThoiGian As Date, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then Ket_noi.Open()
            strSQL = "Update Vaora Set Kieu = PKieu  where MaNV= PMaNV and Thoigian = PTG"
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("PKieu", OleDbType.Integer).Value = Kieu
            cmd.Parameters.Add("PMaNV", OleDbType.Integer).Value = MaNV
            cmd.Parameters.Add("PTG", OleDbType.Date).Value = ThoiGian
            cmd.ExecuteNonQuery()
            Ket_noi.Close()
            '   Else
            'Ket_noi1.Open()
            'strSQL = "Update Vaora Set Kieu =" & Kieu & "  where ID=" & ma & ""
            'Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            'cmd1.ExecuteNonQuery()
            'Ket_noi1.Close()
        End If
    End Sub

    Public Sub SuaMay(ByVal May As Integer, ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then Ket_noi.Open()
            strSQL = "Update Vaora Set May = ?  where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@May", OleDbType.Integer)
            cmd.Parameters.Add("@ID", OleDbType.Integer)
            cmd.Parameters("@May").Value = May
            cmd.Parameters("@ID").Value = ma
            cmd.ExecuteNonQuery()
            Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update Vaora Set May =" & May & "  where ID=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
End Class

