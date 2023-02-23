Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Odbc
Imports System.IO
Imports System.Security.Cryptography

Public Class ManHinhDangNhap


    Dim ketnoiaccess As New AccessDto
#Region "Ma hoa mat khau"
    Public Function MD5Encrypt(ByVal str As String) As String
        Dim md5 As MD5CryptoServiceProvider
        Dim bytValue() As Byte
        Dim bytHash() As Byte
        Dim strOutput As String = ""
        Dim i As Integer

        ' Create New Crypto Service Provider Object
        md5 = New MD5CryptoServiceProvider

        ' Convert the original string to array of Bytes
        bytValue = System.Text.Encoding.UTF8.GetBytes(str)

        ' Compute the Hash, returns an array of Bytes
        bytHash = md5.ComputeHash(bytValue)
        md5.Clear()

        For i = 0 To bytHash.Length - 1
            'don't lose the leading 0
            strOutput &= bytHash(i).ToString("x").PadLeft(2, "0")
        Next
        MD5Encrypt = strOutput
    End Function
#End Region
#Region "Ham Lien Quan File Config"
    Private Function TaoFile(ByVal duongdanFile As String, ByVal NoidungFile As String) As String
        Dim file As FileStream
        Dim writer As StreamWriter
        Try
            file = New FileStream(duongdanFile, FileMode.CreateNew)
            writer = New StreamWriter(file)
            writer.WriteLine(NoidungFile)
            writer.Close()
            file.Close()
        Catch EX As Exception
            Return (EX.Message)
        End Try
        Return "1"
    End Function
    Private Function GhiFile(ByVal duongdanFile As String, ByVal NoidungFile As String) As String
        Dim file As FileStream
        Dim writer As StreamWriter
        Try
            file = New FileStream(duongdanFile, FileMode.Open)
            writer = New StreamWriter(file)
            writer.WriteLine(NoidungFile)
            writer.Close()
            file.Close()
        Catch EX As Exception
            Return EX.Message
        End Try
        Return "1"
    End Function
    Private Function DocFile(ByVal duongdanFile As String) As String
        Dim file As FileStream
        Dim reader As StreamReader
        Dim a As String = ""
        Try
            file = New FileStream(duongdanFile, FileMode.Open)
            reader = New StreamReader(file)
            a = reader.ReadLine
            reader.Close()
            file.Close()
        Catch EX As Exception
            Return ""
        End Try
        Return a
    End Function
#End Region
#Region "Kiem tra Nguoi dung"
    Private WithEvents mBo_doc_ghi As OleDb.OleDbDataAdapter
    Private Function kiemtra() As Boolean
        Try
            Dim sql As String = "select * from nguoidung"
            Dim Data As New DataTable
            mBo_doc_ghi = New OleDbDataAdapter(sql, Ketnoi)
            mBo_doc_ghi.FillSchema(Data, SchemaType.Mapped)
            mBo_doc_ghi.Fill(Data)
            Return Data.Rows.Count <= 0
        Catch ex As OleDb.OleDbException
            Return False
            Exit Function
        End Try
    End Function
    Private Function kiemtra(ByVal Tennguoidung As String, ByVal matkhau As String) As String
        Try
            Dim sql As String = "select * from nguoidung" & _
            " WHERE userID='" & Tennguoidung & "' AND pass='" & matkhau & "' "
            If matkhau = "" Then
                sql = "select * from nguoidung" & _
                " WHERE userID='" & Tennguoidung & "' AND pass is null "
            End If
            Dim Data As New DataTable
            mBo_doc_ghi = New OleDbDataAdapter(sql, Ketnoi)
            mBo_doc_ghi.FillSchema(Data, SchemaType.Mapped)
            mBo_doc_ghi.Fill(Data)
            If Data.Rows.Count > 0 Then
                Dim Thongbao As String = ""
                Dim bus As New QuyenBus(DTOKetnoi, False)
                QuyenNguoiDangNhap = bus.LayBangDTo(Data.Rows(0)(2).ToString).TenQuyen
                TenNguoiDangNhap = Data.Rows(0)(0).ToString
                If QuyenNguoiDangNhap = ChuoiQL Then
                    Thongbao = "Chào Quản Lý : " & Data.Rows(0)(0)
                ElseIf QuyenNguoiDangNhap = ChuoiNV Then
                    Thongbao = "Tên Người Dùng Hợp Lệ "
                ElseIf QuyenNguoiDangNhap = ChuoiTQL Then
                    Thongbao = "Chào Tổng Quản Lý : " & Data.Rows(0)(0)
                Else
                    Thongbao = "Chào : " & Data.Rows(0)(0)
                End If
                MsgBox(Thongbao, MsgBoxStyle.Information, "ThôngBáo")
                ManHinhChinh.Show()
                Close()
                Return Thongbao
            End If
            MsgBox("Tên Người Dùng Hoặc Mật Khẩu Không Hợp Lệ", MsgBoxStyle.Critical, "ThôngBáo")
            Return "Tên Người Dùng Hoặc Mật Khẩu Không Hợp Lệ"
        Catch ex As OleDb.OleDbException
            Return ex.Message
            Exit Function
        End Try
    End Function
#End Region
#Region "Key up"

    Private Sub txtUsername_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUsername.KeyUp
        If e.KeyCode = Keys.Enter Then
            txtPassword.Focus()
        End If
    End Sub

    Private Sub txtPassword_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyUp
        If e.KeyCode = Keys.Enter Then
            btnOk.Focus()
        End If
    End Sub
#End Region
#Region "Button"



    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If IO.File.Exists(Application.StartupPath & "\CC.mdb") = False Then
            IO.File.Copy(Application.StartupPath & "\DATA\CC.mdb", Application.StartupPath & "\CC.mdb")
        End If

        Application.DoEvents()

        If IO.File.Exists(Application.StartupPath & "\Connfig.dat") = False Then
            duongdanCSDL = My.Application.Info.DirectoryPath & "\CC.mdb"
            TaoFile(Application.StartupPath & "\Connfig.dat", duongdanCSDL)
            GoTo Tiep
        End If

        duongdanCSDL = DocFile(Application.StartupPath & "\Connfig.dat")
Tiep:

        Dim Loi As String = Connection()
        If Loi <> "1" Then
            txtResults.Clear()
            Dim Loifile As String = TaoFile(Application.StartupPath & "\Connfig.dat", "")
            If Loifile <> "1" Then
                txtResults.Text &= "File Config Chưa bị xoá(Nội dung File co thể bị sửa)" & ControlChars.CrLf
                txtResults.Text &= Loifile & ControlChars.CrLf
            Else
                txtResults.Text &= "File Config đã được tạo mới" & ControlChars.CrLf
            End If
            txtResults.Text &= "Kết Nối Thất Bại" & ControlChars.CrLf
            txtResults.Text &= Loi & ControlChars.CrLf
            OpenFileDialog1.DefaultExt = "mdb"
            OpenFileDialog1.Filter = "mdb files (*.mdb)|*.mdb"
            If MsgBox("Kết Nối Thất Bại " & vbNewLine & "Đề Nghị Bạn Chọn File CSDL", MsgBoxStyle.Information + MsgBoxStyle.OkCancel, "Thông Báo") = MsgBoxResult.Ok Then
                If (OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK) Then
                    duongdanCSDL = OpenFileDialog1.FileName
                    Dim loighifile As String = GhiFile(Application.StartupPath & "\Connfig.dat", duongdanCSDL)
                    If loighifile <> "1" Then
                        txtResults.Text &= "Ghi File Config thất bại" & ControlChars.CrLf
                        txtResults.Text &= loighifile & ControlChars.CrLf
                    Else
                        txtResults.Text &= "File Config đã ghi xong" & ControlChars.CrLf
                    End If
                Else
                    Exit Sub
                End If
            Else
                Exit Sub
            End If
        End If
        If txtUsername.Text = "" Then
            ErrorProvider1.SetError(txtUsername, " Bạn chưa nhập tên ngưòi dùng")
            txtResults.Text &= "Bạn chưa nhập tên ngưòi dùng" & ControlChars.CrLf
            txtUsername.Focus()
            Exit Sub
        Else
            ErrorProvider1.SetError(txtUsername, "")
        End If
        'If txtPassword.Text = "" Then
        '    ErrorProvider1.SetError(txtPassword, " Bạn chưa nhập mật khẩu")
        '    txtResults.Text &= "Bạn chưa nhập mật khẩu" & ControlChars.CrLf
        '    txtPassword.Focus()
        '    Exit Sub
        'Else
        '    ErrorProvider1.SetError(txtUsername, "")
        'End If
        'txtResults.Text &= kiemtra(txtUsername.Text, MD5Encrypt(txtPassword.Text)) & ControlChars.CrLf
        ketnoiaccess.DuongdanAccess = duongdanCSDL
        ketnoiaccess.ChuoiKetNoiAccess()
        DTOKetnoi = ketnoiaccess
        txtResults.Text &= kiemtra(txtUsername.Text, txtPassword.Text) & ControlChars.CrLf
        txtUsername.Focus()
    End Sub
    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        If Ketnoi.State = ConnectionState.Open Then
            Ketnoi.Close()
        End If
        Me.Close()
        Dim dtoca As New cadto
    End Sub
#End Region

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        ManHinhQuenMatKhau.Show()
    End Sub

    Private Sub ManHinhDangNhap_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        txtUsername.Focus()
        If IO.File.Exists(Application.StartupPath & "\CC.mdb") = False Then
            IO.File.Copy(Application.StartupPath & "\DATA\CC.mdb", Application.StartupPath & "\CC.mdb")
        End If
        Application.DoEvents()

        If IO.File.Exists(Application.StartupPath & "\Connfig.dat") = False Then
            duongdanCSDL = My.Application.Info.DirectoryPath & "\CC.mdb"
            TaoFile(Application.StartupPath & "\Connfig.dat", duongdanCSDL)
            GoTo Tiep
        End If

        duongdanCSDL = DocFile(Application.StartupPath & "\Connfig.dat")
Tiep:

        Dim Loi As String = Connection()
        If Loi <> "1" Then
            txtResults.Clear()
            Dim Loifile As String = TaoFile(Application.StartupPath & "\Connfig.dat", "")
            If Loifile <> "1" Then
                txtResults.Text &= "File Config Chưa bị xoá(Nội dung File co thể bị sửa)" & ControlChars.CrLf
                txtResults.Text &= Loifile & ControlChars.CrLf
            Else
                txtResults.Text &= "File Config đã được tạo mới" & ControlChars.CrLf
            End If
            txtResults.Text &= "Kết Nối Thất Bại" & ControlChars.CrLf
            txtResults.Text &= Loi & ControlChars.CrLf
            OpenFileDialog1.DefaultExt = "mdb"
            OpenFileDialog1.Filter = "mdb files (*.mdb)|*.mdb"
            If MsgBox("Kết Nối Thất Bại " & vbNewLine & "Đề Nghị Bạn Chọn File CSDL", MsgBoxStyle.Information + MsgBoxStyle.OkCancel, "Thông Báo") = MsgBoxResult.Ok Then
                If (OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK) Then
                    duongdanCSDL = OpenFileDialog1.FileName
                    Dim loighifile As String = GhiFile(Application.StartupPath & "\Connfig.dat", duongdanCSDL)
                    If loighifile <> "1" Then
                        txtResults.Text &= "ghi File Config thất bại" & ControlChars.CrLf
                        txtResults.Text &= loighifile & ControlChars.CrLf
                    Else
                        txtResults.Text &= "File Config đã ghi xong" & ControlChars.CrLf
                        Connection()
                    End If
                Else
                    Exit Sub
                End If
            Else
                Exit Sub
            End If
        End If
        txtResults.Clear()
        Dim dd As String = ""
        txtResults.Text &= "Kết Nối Thành Công" & ControlChars.CrLf
        tssDuongdan.ToolTipText = duongdanCSDL
        txtUsername.Focus()
        ketnoiaccess.DuongdanAccess = duongdanCSDL
        ketnoiaccess.ChuoiKetNoiAccess()
        DTOKetnoi = ketnoiaccess
        If kiemtra() Then
            ManHinhChinh.Show()
            Me.Dispose()
        End If
        txtUsername.Focus()
    End Sub
    Private Function TaoFileButNhanVien(ByVal duongdanFile As String) As String
        Dim file As FileStream
        Dim writer As StreamWriter
        Try
            file = New FileStream(duongdanFile, FileMode.CreateNew)
            writer = New StreamWriter(file)
            writer.WriteLine("MenuQLDL_SaoLuuDL")
            writer.WriteLine("MenuQLDL_PhucHoiDL")
            writer.WriteLine("ToolStripSeparator5")
            writer.WriteLine("MenuQLDL_TroDL")
            writer.WriteLine("QLDLMayChamToolStripMenuItem")
            writer.WriteLine("NhậpDửLiệuChấmCôngToolStripMenuItem")
            writer.WriteLine("XuấtDửLiệuChấmCôngToolStripMenuItem")
            writer.WriteLine("ToolStripSeparator14")
            writer.WriteLine("MenuQLHS")
            writer.WriteLine("MenuQLHS_TimKiemNV")
            writer.WriteLine("MenuQLNDung_QLBoPhan")
            writer.WriteLine("MenuQLNDung_QLChucVu")
            writer.WriteLine("MenuQLNDung_QLNVien")
            writer.WriteLine("ToolStripSeparator6")
            writer.WriteLine("MenuQLNDung_TLCa")
            writer.WriteLine("MenuQLNDung_TLLichLV")
            writer.WriteLine("MenuQLNDung_TLLichNV")
            writer.WriteLine("MenuQLNDung_NgayNghi")
            writer.WriteLine("ToolStripMenuItem1")
            writer.WriteLine("ToolStripSeparator7")
            writer.WriteLine("MenuQLMay_TaiDLMayTinh_MCC")
            writer.WriteLine("MenuQLMay_KTNDungMCC")
            writer.WriteLine("ToolStripSeparator9")
            writer.WriteLine("MenuQLMay_MenuQLMCC")
            writer.WriteLine("ToolStripSeparator11")
            writer.WriteLine("MenuQLTaiKhoan_XemNKySDung")
            writer.WriteLine("MenuQLTaiKhoan_XemTatCaTK")
            writer.WriteLine("ToolStripSeparator12")
            writer.WriteLine("PhânQuyềnNgườiDùngToolStripMenuItem")
            writer.WriteLine("MenuQLTaiKhoan_TaoTK")
            writer.WriteLine("ToolViewToolStripMenuItem")
            writer.WriteLine("MenuCSHoatDong_CCBenTrai")
            writer.WriteLine("ToolStripSeparator3")
            writer.WriteLine("ToolStripSeparator4")
            writer.WriteLine("CửaSổCơBảnToolStripMenuItem")
            writer.WriteLine("CửaSổNângCaoToolStripMenuItem")
            writer.Close()
            file.Close()
        Catch EX As Exception
            Return (EX.Message)
        End Try
        Return "1"
    End Function
    Private Function TaoFileButquanly(ByVal duongdanFile As String) As String
        Dim file As FileStream
        Dim writer As StreamWriter
        Try
            file = New FileStream(duongdanFile, FileMode.CreateNew)
            writer = New StreamWriter(file)
            writer.WriteLine("MenuQLDL_PhucHoiDL")
            writer.WriteLine("MenuQLDL_TroDL")
            writer.WriteLine("ToolStripSeparator9")
            writer.WriteLine("MenuQLMay_MenuQLMCC")
            writer.WriteLine("MenuQLTaiKhoan_XemTatCaTK")
            writer.WriteLine("ToolStripSeparator12")
            writer.WriteLine("PhânQuyềnNgườiDùngToolStripMenuItem")
            writer.WriteLine("MenuQLTaiKhoan_TaoTK")
            writer.Close()
            file.Close()
        Catch EX As Exception
            Return (EX.Message)
        End Try
        Return "1"
    End Function
    Private Sub ManHinhDangNhap_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Directory.CreateDirectory(Application.StartupPath & "\FileDefault")
            Directory.CreateDirectory(Application.StartupPath & "\FileDefault\FlieLuu")
            Dim duongdan As String = Application.StartupPath & "\FileDefault\FlieLuu\Nhân ViênMHChinhHT.txt"
            Try
                File.Delete(duongdan)
            Catch ex As Exception
            End Try
            TaoFileButNhanVien(duongdan)
            duongdan = Application.StartupPath & "\FileDefault\FlieLuu\Quản LýMHChinhHT.txt"
            Try
                File.Delete(duongdan)
            Catch ex As Exception
            End Try
            TaoFileButquanly(duongdan)
        Catch ex As Exception
        End Try
    End Sub


End Class