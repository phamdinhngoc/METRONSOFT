Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class BangluongDao
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
        MyBase.New("Bangluong", connection, MSsql)
    End Sub
    Public Sub New(ByVal ma As Integer, ByVal connection As KetNoiDto, ByVal MSsql As Boolean)
        MyBase.New("Bangluong", "select * from Bangluong where Manv=" & ma & "", connection, MSsql)
    End Sub
    Public Sub New(ByVal ma1 As Integer, ByVal ma2 As Integer, ByVal connection As KetNoiDto, ByVal MSsql As Boolean)
        MyBase.New("Bangluong", "select * from Bangluong where Manv=" & ma1 & " and Thang=" & ma2 & "", connection, MSsql)
    End Sub
    Public Sub New(ByVal ma1 As Integer, ByVal ma2 As Integer, ByVal ma3 As Integer, ByVal connection As KetNoiDto, ByVal MSsql As Boolean)
        MyBase.New("Bangluong", "select * from Bangluong where Manv=" & ma1 & " and Thang=" & ma2 & " and Nam=" & ma3 & "", connection, MSsql)
    End Sub
#End Region
    Public Sub Them(ByVal Dto As Bangluongdto, ByVal MSsql As Boolean)
        Dim strsql As String
        Dim BatTat As Boolean = False
        strsql = "Insert into Bangluong(Manv,Thang,Nam,LuongThang,Luongngay,Socong,Songay,Luongngaycong,Phucap1,Tamung1,SogioTc,TienTcGio,TienAnTC,TienTangCa,NgayCN,LuongCN,Solanditre,Phatditre,Solannghikophep,phatnghikophep,PhantramBH,TienBH,ThucLanh,TrangThai,SuatAnTrua,PhuCap2,NgayGuiXe,TienGuiXe,TongTienXe,ChuyenCan) values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            Dim cmd As New OleDbCommand(strsql, Ket_noi)
            cmd.Parameters.Add("@Manv", OleDbType.Integer)
            cmd.Parameters.Add("@Thang", OleDbType.Integer)
            cmd.Parameters.Add("@Nam", OleDbType.Integer)
            cmd.Parameters.Add("@LuongThang", OleDbType.Double)
            cmd.Parameters.Add("@Luongngay", OleDbType.Double)
            cmd.Parameters.Add("@Socong", OleDbType.Double)
            cmd.Parameters.Add("@Songay", OleDbType.Integer)
            cmd.Parameters.Add("@Luongngaycong", OleDbType.Double)
            cmd.Parameters.Add("@Phucap1", OleDbType.Double)
            cmd.Parameters.Add("@Tamung1", OleDbType.Double)
            cmd.Parameters.Add("@SoGioTC", OleDbType.Double)
            cmd.Parameters.Add("@TienTCGio", OleDbType.Double)
            cmd.Parameters.Add("@TienTangCa", OleDbType.Double)
            cmd.Parameters.Add("@TienAnTC", OleDbType.Double)

            cmd.Parameters.Add("@NgayCN", OleDbType.Double)
            cmd.Parameters.Add("@LuongCN", OleDbType.Double)
            cmd.Parameters.Add("@Solanditre", OleDbType.Integer)
            cmd.Parameters.Add("@Phatditre", OleDbType.Double)
            cmd.Parameters.Add("@Solannghikophep", OleDbType.Double)
            cmd.Parameters.Add("@phatnghikophep", OleDbType.Double)
            cmd.Parameters.Add("@PhanTramBH", OleDbType.Double)
            cmd.Parameters.Add("@TienBH", OleDbType.Double)
            cmd.Parameters.Add("@ThucLanh", OleDbType.Double)
            cmd.Parameters.Add("@TrangThai", OleDbType.Integer)
            cmd.Parameters.Add("@SuatAnTrua", OleDbType.Double)
            cmd.Parameters.Add("@PhuCap2", OleDbType.Double)
            cmd.Parameters.Add("@NgayGuiXe", OleDbType.Double)
            cmd.Parameters.Add("@TienGuiXe", OleDbType.Double)
            cmd.Parameters.Add("@TongTienXe", OleDbType.Double)
            cmd.Parameters.Add("@ChuyenCan", OleDbType.Double)
            cmd.Parameters("@Manv").Value = Dto.Manv
            cmd.Parameters("@Thang").Value = Dto.Thang
            cmd.Parameters("@Nam").Value = Dto.Nam
            cmd.Parameters("@LuongThang").Value = Dto.LuongThang
            cmd.Parameters("@Luongngay").Value = Dto.Luongngay
            cmd.Parameters("@Socong").Value = Dto.Socong
            cmd.Parameters("@Songay").Value = Dto.Songay
            cmd.Parameters("@Luongngaycong").Value = Dto.Luongngaycong
            cmd.Parameters("@Phucap1").Value = Dto.Phucap1
            cmd.Parameters("@Tamung1").Value = Dto.Tamung1
            cmd.Parameters("@SoGioTc").Value = Dto.SoGioTc
            cmd.Parameters("@TienTCGio").Value = Dto.TienTcGio
            cmd.Parameters("@TienTangCa").Value = Dto.TienTangca
            cmd.Parameters("@TienAnTC").Value = Dto.TienAnTC

            cmd.Parameters("@NgayCN").Value = Dto.NgayCN
            cmd.Parameters("@LuongCN").Value = Dto.LuongCN
            cmd.Parameters("@Solanditre").Value = Dto.Solanditre
            cmd.Parameters("@Phatditre").Value = Dto.Phatditre
            cmd.Parameters("@Solannghikophep").Value = Dto.Solannghikophep
            cmd.Parameters("@phatnghikophep").Value = Dto.phatnghikophep
            cmd.Parameters("@PhanTramBH").Value = Dto.PhanTramBH
            cmd.Parameters("@TienBH").Value = Dto.TienBH
            cmd.Parameters("@ThucLanh").Value = Dto.ThucLanh
            cmd.Parameters("@TrangThai").Value = Dto.Trangthai
            cmd.Parameters("@SuatAnTrua").Value = Dto.SuatAnTrua
            cmd.Parameters("@Phucap2").Value = Dto.Phucap2
            cmd.Parameters("@NgayGuiXe").Value = Dto.NgayGuiXe
            cmd.Parameters("@TienGuiXe").Value = Dto.TienGuiXe
            cmd.Parameters("@TongTienXe").Value = Dto.TongTienXe
            cmd.Parameters("@ChuyenCan").Value = Dto.ChuyenCan
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else

        End If
    End Sub
    Public Sub Xoa(ByVal ma1 As Integer, ByVal ma2 As Integer, ByVal ma3 As Integer, ByVal MSsql As Boolean)
        Dim strSQL As String
        Dim BatTat As Boolean = False
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            strSQL = "Delete From Bangluong Where Manv= ?  and Thang= ?  and Nam= ?  "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@ma1", OleDbType.Integer)
            cmd.Parameters.Add("@ma2", OleDbType.Integer)
            cmd.Parameters.Add("@ma3", OleDbType.Integer)
            cmd.Parameters("@Ma1").Value = ma1
            cmd.Parameters("@Ma2").Value = ma2
            cmd.Parameters("@Ma3").Value = ma3
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            If Ket_noi1.State = ConnectionState.Closed Then Ket_noi1.Open()
            strSQL = "Delete From Bangluong Where Manv=" & ma1 & " and Thang=" & ma2 & " and Nam=" & ma3 & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            If Ket_noi1.State = ConnectionState.Open Then Ket_noi1.Close()
        End If
    End Sub
    Public Sub sua(ByVal dto As Bangluongdto, ByVal MSsql As Boolean)
        Dim strSQL As String
        Dim BatTat As Boolean = False
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            strSQL = "Update Bangluong Set LuongThang=? ,Luongngay=? ,Socong=? ,Songay=? ,Luongngaycong=? ,Phucap1=? ,Tamung1=? ,SoGioTC=?,TienTCGio =?,TienTangca=?,TienAnTC=?,NgayCN =?,LuongCN=?,Solanditre=? ,Phatditre=? ,Solannghikophep=? ,phatnghikophep=?, PhanTramBH = ?,TienBH = ?,ThucLanh = ?, TrangThai = ?, TienComTrua = ?, SuatAnTrua=?,PhuCap2=?,NgayGuiXe=?,TienGuiXe=?,TongTienXe=?,ChuyenCan=? where Manv= ?  and Thang= ?  and Nam= ?  "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)

            cmd.Parameters.Add("@LuongThang", OleDbType.Double)
            cmd.Parameters.Add("@Luongngay", OleDbType.Double)
            cmd.Parameters.Add("@Socong", OleDbType.Double)
            cmd.Parameters.Add("@Songay", OleDbType.Integer)
            cmd.Parameters.Add("@Luongngaycong", OleDbType.Double)
            cmd.Parameters.Add("@Phucap1", OleDbType.Double)
            cmd.Parameters.Add("@Tamung1", OleDbType.Double)
            cmd.Parameters.Add("@SoGioTC", OleDbType.Double)
            cmd.Parameters.Add("@TienTCGio", OleDbType.Double)
            cmd.Parameters.Add("@TienTangCa", OleDbType.Double)
            cmd.Parameters.Add("@TienAnTC", OleDbType.Double)

            cmd.Parameters.Add("@NgayCN", OleDbType.Double)
            cmd.Parameters.Add("@LuongCN", OleDbType.Double)
            cmd.Parameters.Add("@Solanditre", OleDbType.Integer)
            cmd.Parameters.Add("@Phatditre", OleDbType.Double)
            cmd.Parameters.Add("@Solannghikophep", OleDbType.Double)
            cmd.Parameters.Add("@phatnghikophep", OleDbType.Double)
            cmd.Parameters.Add("@PhanTramBH", OleDbType.Double)
            cmd.Parameters.Add("@TienBH", OleDbType.Double)
            cmd.Parameters.Add("@ThucLanh", OleDbType.Double)
            cmd.Parameters.Add("@TrangThai", OleDbType.Integer)
            cmd.Parameters.Add("@TienComTrua", OleDbType.Integer)
            cmd.Parameters.Add("@SuatAnTrua", OleDbType.Integer)
            cmd.Parameters.Add("@Phucap2", OleDbType.Double)
            cmd.Parameters.Add("@NgayGuiXe", OleDbType.Double)
            cmd.Parameters.Add("@TienGuiXe", OleDbType.Double)
            cmd.Parameters.Add("@TongTienXe", OleDbType.Double)
            cmd.Parameters.Add("@ChuyenCan", OleDbType.Double)
            cmd.Parameters.Add("@Manv", OleDbType.Integer)
            cmd.Parameters.Add("@Thang", OleDbType.Integer)
            cmd.Parameters.Add("@Nam", OleDbType.Integer)


            cmd.Parameters("@LuongThang").Value = dto.LuongThang
            cmd.Parameters("@Luongngay").Value = dto.Luongngay
            cmd.Parameters("@Socong").Value = dto.Socong
            cmd.Parameters("@Songay").Value = dto.Songay
            cmd.Parameters("@Luongngaycong").Value = dto.Luongngaycong
            cmd.Parameters("@Phucap1").Value = dto.Phucap1
            cmd.Parameters("@Tamung1").Value = dto.Tamung1
            cmd.Parameters("@SoGioTc").Value = dto.SoGioTc
            cmd.Parameters("@TienTCGio").Value = dto.TienTcGio
            cmd.Parameters("@TienTangCa").Value = dto.TienTangca
            cmd.Parameters("@TienAnTC").Value = dto.TienAnTC

            cmd.Parameters("@NgayCN").Value = dto.NgayCN
            cmd.Parameters("@LuongCN").Value = dto.LuongCN
            cmd.Parameters("@Solanditre").Value = dto.Solanditre
            cmd.Parameters("@Phatditre").Value = dto.Phatditre
            cmd.Parameters("@Solannghikophep").Value = dto.Solannghikophep
            cmd.Parameters("@phatnghikophep").Value = dto.phatnghikophep
            cmd.Parameters("@PhanTramBH").Value = dto.PhanTramBH
            cmd.Parameters("@TienBH").Value = dto.TienBH
            cmd.Parameters("@ThucLanh").Value = dto.ThucLanh
            cmd.Parameters("@TrangThai").Value = dto.Trangthai
            cmd.Parameters("@TienComTrua").Value = dto.TienComTrua
            cmd.Parameters("@SuatAnTrua").Value = dto.SuatAnTrua
            cmd.Parameters("@Phucap2").Value = dto.Phucap2
            cmd.Parameters("@NgayGuiXe").Value = dto.NgayGuiXe
            cmd.Parameters("@TienGuiXe").Value = dto.TienGuiXe
            cmd.Parameters("@TongTienXe").Value = dto.TongTienXe
            cmd.Parameters("@ChuyenCan").Value = dto.ChuyenCan
            cmd.Parameters("@Manv").Value = dto.Manv
            cmd.Parameters("@Thang").Value = dto.Thang
            cmd.Parameters("@Nam").Value = dto.Nam
            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception

            End Try

            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            'If Ket_noi1.State = ConnectionState.Closed Then Ket_noi1.Open()
            'strSQL = "Update Bangluong Set LuongThang= " & dto.LuongThang & ",Luongngay= " & dto.Luongngay & ",Socong= " & dto.Socong & ",Songay= " & dto.Songay & ",Luongngaycong= " & dto.Luongngaycong & ",Phucap1= " & dto.Phucap1 & ",Phucap2= " & dto.Phucap2 & ",Tamung1= " & dto.Tamung1 & ",Tamung2= " & dto.Tamung2 & ",Solanditre= " & dto.Solanditre & ",Solannghikophep= " & dto.Solannghikophep & ",Phatditre= " & dto.Phatditre & ",phatnghikophep= " & dto.phatnghikophep & ",Hinh= '" & dto.Hinh & "' where Manv=" & dto.Manv & " and Thang=" & dto.Thang & " and Nam=" & dto.Nam & ""
            'Dim cmd1 As New sqlCommand(strSQL, Ket_noi1)
            'cmd1.ExecuteNonQuery()
            'If Ket_noi1.State = ConnectionState.Open Then Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaLuongThang(ByVal LuongThang As Integer, ByVal ma1 As Integer, ByVal ma2 As Integer, ByVal ma3 As Integer, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then Ket_noi.Open()
            strSQL = "Update Bangluong Set LuongThang = ?  where Manv= ?  and Thang= ?  and Nam= ?  "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@LuongThang", OleDbType.Integer)
            cmd.Parameters.Add("@Manv", OleDbType.Integer)
            cmd.Parameters.Add("@Thang", OleDbType.Integer)
            cmd.Parameters.Add("@Nam", OleDbType.Integer)
            cmd.Parameters("@LuongThang").Value = LuongThang
            cmd.Parameters("@Manv").Value = ma1
            cmd.Parameters("@Thang").Value = ma2
            cmd.Parameters("@Nam").Value = ma3
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then Ket_noi.Close()
        Else
            If Ket_noi1.State = ConnectionState.Closed Then Ket_noi1.Open()
            strSQL = "Update Bangluong Set LuongThang =" & LuongThang & "  where Manv=" & ma1 & " and Thang=" & ma2 & " and Nam=" & ma3 & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            If Ket_noi1.State = ConnectionState.Open Then Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaLuongngay(ByVal Luongngay As Integer, ByVal ma1 As Integer, ByVal ma2 As Integer, ByVal ma3 As Integer, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then Ket_noi.Open()
            strSQL = "Update Bangluong Set Luongngay = ?  where Manv= ?  and Thang= ?  and Nam= ?  "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@Luongngay", OleDbType.Integer)
            cmd.Parameters.Add("@Manv", OleDbType.Integer)
            cmd.Parameters.Add("@Thang", OleDbType.Integer)
            cmd.Parameters.Add("@Nam", OleDbType.Integer)
            cmd.Parameters("@Luongngay").Value = Luongngay
            cmd.Parameters("@Manv").Value = ma1
            cmd.Parameters("@Thang").Value = ma2
            cmd.Parameters("@Nam").Value = ma3
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then Ket_noi.Close()
        Else
            If Ket_noi1.State = ConnectionState.Closed Then Ket_noi1.Open()
            strSQL = "Update Bangluong Set Luongngay =" & Luongngay & "  where Manv=" & ma1 & " and Thang=" & ma2 & " and Nam=" & ma3 & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            If Ket_noi1.State = ConnectionState.Open Then Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaSocong(ByVal Socong As Integer, ByVal ma1 As Integer, ByVal ma2 As Integer, ByVal ma3 As Integer, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then Ket_noi.Open()
            strSQL = "Update Bangluong Set Socong = ?  where Manv= ?  and Thang= ?  and Nam= ?  "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@Socong", OleDbType.Double)
            cmd.Parameters.Add("@Manv", OleDbType.Integer)
            cmd.Parameters.Add("@Thang", OleDbType.Integer)
            cmd.Parameters.Add("@Nam", OleDbType.Integer)
            cmd.Parameters("@Socong").Value = Socong
            cmd.Parameters("@Manv").Value = ma1
            cmd.Parameters("@Thang").Value = ma2
            cmd.Parameters("@Nam").Value = ma3
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then Ket_noi.Close()
        Else
            If Ket_noi1.State = ConnectionState.Closed Then Ket_noi1.Open()
            strSQL = "Update Bangluong Set Socong =" & Socong & "  where Manv=" & ma1 & " and Thang=" & ma2 & " and Nam=" & ma3 & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            If Ket_noi1.State = ConnectionState.Open Then Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaSongay(ByVal Songay As Integer, ByVal ma1 As Integer, ByVal ma2 As Integer, ByVal ma3 As Integer, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then Ket_noi.Open()
            strSQL = "Update Bangluong Set Songay = ?  where Manv= ?  and Thang= ?  and Nam= ?  "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@Songay", OleDbType.Double)
            cmd.Parameters.Add("@Manv", OleDbType.Integer)
            cmd.Parameters.Add("@Thang", OleDbType.Integer)
            cmd.Parameters.Add("@Nam", OleDbType.Integer)
            cmd.Parameters("@Songay").Value = Songay
            cmd.Parameters("@Manv").Value = ma1
            cmd.Parameters("@Thang").Value = ma2
            cmd.Parameters("@Nam").Value = ma3
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then Ket_noi.Close()
        Else
            If Ket_noi1.State = ConnectionState.Closed Then Ket_noi1.Open()
            strSQL = "Update Bangluong Set Songay =" & Songay & "  where Manv=" & ma1 & " and Thang=" & ma2 & " and Nam=" & ma3 & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            If Ket_noi1.State = ConnectionState.Open Then Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaLuongngaycong(ByVal Luongngaycong As Integer, ByVal ma1 As Integer, ByVal ma2 As Integer, ByVal ma3 As Integer, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then Ket_noi.Open()
            strSQL = "Update Bangluong Set Luongngaycong = ?  where Manv= ?  and Thang= ?  and Nam= ?  "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@Luongngaycong", OleDbType.Integer)
            cmd.Parameters.Add("@Manv", OleDbType.Integer)
            cmd.Parameters.Add("@Thang", OleDbType.Integer)
            cmd.Parameters.Add("@Nam", OleDbType.Integer)
            cmd.Parameters("@Luongngaycong").Value = Luongngaycong
            cmd.Parameters("@Manv").Value = ma1
            cmd.Parameters("@Thang").Value = ma2
            cmd.Parameters("@Nam").Value = ma3
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then Ket_noi.Close()
        Else
            If Ket_noi1.State = ConnectionState.Closed Then Ket_noi1.Open()
            strSQL = "Update Bangluong Set Luongngaycong =" & Luongngaycong & "  where Manv=" & ma1 & " and Thang=" & ma2 & " and Nam=" & ma3 & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            If Ket_noi1.State = ConnectionState.Open Then Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaPhucap1(ByVal Phucap1 As Integer, ByVal ma1 As Integer, ByVal ma2 As Integer, ByVal ma3 As Integer, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then Ket_noi.Open()
            strSQL = "Update Bangluong Set Phucap1 = ?  where Manv= ?  and Thang= ?  and Nam= ?  "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@Phucap1", OleDbType.Integer)
            cmd.Parameters.Add("@Manv", OleDbType.Integer)
            cmd.Parameters.Add("@Thang", OleDbType.Integer)
            cmd.Parameters.Add("@Nam", OleDbType.Integer)
            cmd.Parameters("@Phucap1").Value = Phucap1
            cmd.Parameters("@Manv").Value = ma1
            cmd.Parameters("@Thang").Value = ma2
            cmd.Parameters("@Nam").Value = ma3
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then Ket_noi.Close()
        Else
            If Ket_noi1.State = ConnectionState.Closed Then Ket_noi1.Open()
            strSQL = "Update Bangluong Set Phucap1 =" & Phucap1 & "  where Manv=" & ma1 & " and Thang=" & ma2 & " and Nam=" & ma3 & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            If Ket_noi1.State = ConnectionState.Open Then Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaPhucap2(ByVal Phucap2 As Integer, ByVal ma1 As Integer, ByVal ma2 As Integer, ByVal ma3 As Integer, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then Ket_noi.Open()
            strSQL = "Update Bangluong Set Phucap2 = ?  where Manv= ?  and Thang= ?  and Nam= ?  "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@Phucap2", OleDbType.Integer)
            cmd.Parameters.Add("@Manv", OleDbType.Integer)
            cmd.Parameters.Add("@Thang", OleDbType.Integer)
            cmd.Parameters.Add("@Nam", OleDbType.Integer)
            cmd.Parameters("@Phucap2").Value = Phucap2
            cmd.Parameters("@Manv").Value = ma1
            cmd.Parameters("@Thang").Value = ma2
            cmd.Parameters("@Nam").Value = ma3
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then Ket_noi.Close()
        Else
            If Ket_noi1.State = ConnectionState.Closed Then Ket_noi1.Open()
            strSQL = "Update Bangluong Set Phucap2 =" & Phucap2 & "  where Manv=" & ma1 & " and Thang=" & ma2 & " and Nam=" & ma3 & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            If Ket_noi1.State = ConnectionState.Open Then Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaTamung1(ByVal Tamung1 As Integer, ByVal ma1 As Integer, ByVal ma2 As Integer, ByVal ma3 As Integer, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then Ket_noi.Open()
            strSQL = "Update Bangluong Set Tamung1 = ?  where Manv= ?  and Thang= ?  and Nam= ?  "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@Tamung1", OleDbType.Integer)
            cmd.Parameters.Add("@Manv", OleDbType.Integer)
            cmd.Parameters.Add("@Thang", OleDbType.Integer)
            cmd.Parameters.Add("@Nam", OleDbType.Integer)
            cmd.Parameters("@Tamung1").Value = Tamung1
            cmd.Parameters("@Manv").Value = ma1
            cmd.Parameters("@Thang").Value = ma2
            cmd.Parameters("@Nam").Value = ma3
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then Ket_noi.Close()
        Else
            If Ket_noi1.State = ConnectionState.Closed Then Ket_noi1.Open()
            strSQL = "Update Bangluong Set Tamung1 =" & Tamung1 & "  where Manv=" & ma1 & " and Thang=" & ma2 & " and Nam=" & ma3 & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            If Ket_noi1.State = ConnectionState.Open Then Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaTamung2(ByVal Tamung2 As Integer, ByVal ma1 As Integer, ByVal ma2 As Integer, ByVal ma3 As Integer, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then Ket_noi.Open()
            strSQL = "Update Bangluong Set Tamung2 = ?  where Manv= ?  and Thang= ?  and Nam= ?  "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@Tamung2", OleDbType.Integer)
            cmd.Parameters.Add("@Manv", OleDbType.Integer)
            cmd.Parameters.Add("@Thang", OleDbType.Integer)
            cmd.Parameters.Add("@Nam", OleDbType.Integer)
            cmd.Parameters("@Tamung2").Value = Tamung2
            cmd.Parameters("@Manv").Value = ma1
            cmd.Parameters("@Thang").Value = ma2
            cmd.Parameters("@Nam").Value = ma3
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then Ket_noi.Close()
        Else
            If Ket_noi1.State = ConnectionState.Closed Then Ket_noi1.Open()
            strSQL = "Update Bangluong Set Tamung2 =" & Tamung2 & "  where Manv=" & ma1 & " and Thang=" & ma2 & " and Nam=" & ma3 & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            If Ket_noi1.State = ConnectionState.Open Then Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaSolanditre(ByVal Solanditre As Integer, ByVal ma1 As Integer, ByVal ma2 As Integer, ByVal ma3 As Integer, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then Ket_noi.Open()
            strSQL = "Update Bangluong Set Solanditre = ?  where Manv= ?  and Thang= ?  and Nam= ?  "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@Solanditre", OleDbType.Integer)
            cmd.Parameters.Add("@Manv", OleDbType.Integer)
            cmd.Parameters.Add("@Thang", OleDbType.Integer)
            cmd.Parameters.Add("@Nam", OleDbType.Integer)
            cmd.Parameters("@Solanditre").Value = Solanditre
            cmd.Parameters("@Manv").Value = ma1
            cmd.Parameters("@Thang").Value = ma2
            cmd.Parameters("@Nam").Value = ma3
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then Ket_noi.Close()
        Else
            If Ket_noi1.State = ConnectionState.Closed Then Ket_noi1.Open()
            strSQL = "Update Bangluong Set Solanditre =" & Solanditre & "  where Manv=" & ma1 & " and Thang=" & ma2 & " and Nam=" & ma3 & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            If Ket_noi1.State = ConnectionState.Open Then Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaSolannghikophep(ByVal Solannghikophep As Integer, ByVal ma1 As Integer, ByVal ma2 As Integer, ByVal ma3 As Integer, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then Ket_noi.Open()
            strSQL = "Update Bangluong Set Solannghikophep = ?  where Manv= ?  and Thang= ?  and Nam= ?  "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@Solannghikophep", OleDbType.Integer)
            cmd.Parameters.Add("@Manv", OleDbType.Integer)
            cmd.Parameters.Add("@Thang", OleDbType.Integer)
            cmd.Parameters.Add("@Nam", OleDbType.Integer)
            cmd.Parameters("@Solannghikophep").Value = Solannghikophep
            cmd.Parameters("@Manv").Value = ma1
            cmd.Parameters("@Thang").Value = ma2
            cmd.Parameters("@Nam").Value = ma3
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then Ket_noi.Close()
        Else
            If Ket_noi1.State = ConnectionState.Closed Then Ket_noi1.Open()
            strSQL = "Update Bangluong Set Solannghikophep =" & Solannghikophep & "  where Manv=" & ma1 & " and Thang=" & ma2 & " and Nam=" & ma3 & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            If Ket_noi1.State = ConnectionState.Open Then Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaPhatditre(ByVal Phatditre As Integer, ByVal ma1 As Integer, ByVal ma2 As Integer, ByVal ma3 As Integer, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then Ket_noi.Open()
            strSQL = "Update Bangluong Set Phatditre = ?  where Manv= ?  and Thang= ?  and Nam= ?  "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@Phatditre", OleDbType.Integer)
            cmd.Parameters.Add("@Manv", OleDbType.Integer)
            cmd.Parameters.Add("@Thang", OleDbType.Integer)
            cmd.Parameters.Add("@Nam", OleDbType.Integer)
            cmd.Parameters("@Phatditre").Value = Phatditre
            cmd.Parameters("@Manv").Value = ma1
            cmd.Parameters("@Thang").Value = ma2
            cmd.Parameters("@Nam").Value = ma3
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then Ket_noi.Close()
        Else
            If Ket_noi1.State = ConnectionState.Closed Then Ket_noi1.Open()
            strSQL = "Update Bangluong Set Phatditre =" & Phatditre & "  where Manv=" & ma1 & " and Thang=" & ma2 & " and Nam=" & ma3 & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            If Ket_noi1.State = ConnectionState.Open Then Ket_noi1.Close()
        End If
    End Sub
    Public Sub Suaphatnghikophep(ByVal phatnghikophep As Integer, ByVal ma1 As Integer, ByVal ma2 As Integer, ByVal ma3 As Integer, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then Ket_noi.Open()
            strSQL = "Update Bangluong Set phatnghikophep = ?  where Manv= ?  and Thang= ?  and Nam= ?  "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@phatnghikophep", OleDbType.Integer)
            cmd.Parameters.Add("@Manv", OleDbType.Integer)
            cmd.Parameters.Add("@Thang", OleDbType.Integer)
            cmd.Parameters.Add("@Nam", OleDbType.Integer)
            cmd.Parameters("@phatnghikophep").Value = phatnghikophep
            cmd.Parameters("@Manv").Value = ma1
            cmd.Parameters("@Thang").Value = ma2
            cmd.Parameters("@Nam").Value = ma3
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then Ket_noi.Close()
        Else
            If Ket_noi1.State = ConnectionState.Closed Then Ket_noi1.Open()
            strSQL = "Update Bangluong Set phatnghikophep =" & phatnghikophep & "  where Manv=" & ma1 & " and Thang=" & ma2 & " and Nam=" & ma3 & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            If Ket_noi1.State = ConnectionState.Open Then Ket_noi1.Close()
        End If
    End Sub
End Class

