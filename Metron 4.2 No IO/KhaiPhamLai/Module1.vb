Imports System.IO
Module Module1
    Public DTOKetnoi As New KetNoiDto
    Public Ketnoi As New OleDb.OleDbConnection
    Public ChuoiNV As String = "Nhân Viên"
    Public ChuoiQL As String = "Quản Lý"
    Public ChuoiTQL As String = "Tổng Quản Lý"
    Public ChuoiTC As String = "Tùy chọn"
    Public QuyenNguoiDangNhap As String = "Tổng Quản Lý" 'mặc định : quyền Tổng Quản Lý
    Public TenNguoiDangNhap As String = ""
    Public duongdanCSDL As String = ""

    Public ThemCV As Boolean = True
    Public XoaCV As Boolean = True
    Public SuaCV As Boolean = True

    Public ThemDV As Boolean = True
    Public XoaDV As Boolean = True
    Public SuaDV As Boolean = True

    Public ThemMCC As Boolean = True
    Public XoaMCC As Boolean = True
    Public SuaMCC As Boolean = True

    Public ThemND As Boolean = True
    Public XoaND As Boolean = True
    Public SuaND As Boolean = True

    Public ThemNV As Boolean = True
    Public XoaNV As Boolean = True
    Public SuaNV As Boolean = True
    Public Sub cacNutNhan(ByVal Con As Control, ByVal ma As Integer, ByVal tenform As String)
        Try
            Dim buschitiet As New QuyenChiTietBus(DTOKetnoi, False)
            Dim ctr As Control
            For Each ctr In Con.Controls
                If TypeOf ctr Is ToolStrip Then
                    Dim tool As ToolStrip = ctr
                    For i As Integer = 0 To tool.Items.Count - 1
                        If buschitiet.KiemTraCo(ma, tenform, tool.Items(i).Name) Then
                            tool.Items(i).Visible = False
                        End If
                    Next
                ElseIf TypeOf ctr Is Button Then
                    Dim but As Button = ctr
                    If buschitiet.KiemTraCo(ma, tenform, but.Name) Then
                        but.Visible = False
                    End If
                End If
                If ctr.Controls.Count > 0 Then
                    cacNutNhan(ctr, ma, tenform)
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub

    Public Sub LuuCotAn(ByVal DgvName As DataGridView, ByVal DuongDanFile As String)
        Dim file As FileStream
        Dim writer As StreamWriter
        file = New FileStream(DuongDanFile, FileMode.CreateNew)
        writer = New StreamWriter(file)
        For i As Integer = 0 To DgvName.Columns.Count - 1

            writer.WriteLine(DgvName.Columns(i).Visible.ToString)


        Next
        writer.Close()
        file.Close()
    End Sub
    Public Function Connection() As String
         Try
            If Ketnoi.State = ConnectionState.Open Or Ketnoi.State = ConnectionState.Connecting Then
                Ketnoi.Close()
            End If

            Ketnoi.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & duongdanCSDL & ";Persist Security Info=True;Jet OLEDB:Database Password=MinhLam20"
            'Ketnoi.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & duongdanCSDL & ";Password=MinhLam20;"
            'Ketnoi.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & duongdanCSDL & ";Persist Security Info=True;Jet OLEDB:Database Password=MinhLam20"
            Ketnoi.Open()
        Catch ex As OleDb.OleDbException
            Try
                Ketnoi.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & duongdanCSDL & ";Persist Security Info=True;Jet OLEDB:Database Password=MinhLam20"
                Ketnoi.Open()
            Catch ex1 As OleDb.OleDbException
                Ketnoi.Close()
                Return ex.Message
                Exit Function
            End Try
            
        End Try
        Return "1"
    End Function
    Public Function Doc_so(ByVal so As String) As String
        Dim X As Byte, cum As String, i, Solan As Byte
        Dim tri As Boolean
        Dim dolon() As String
        Dim str As String = ""
        dolon = New String() {"", "", " Ngàn", " Triệu,", " Tỷ,", " Ngàn", " Triệu", " Tỷ tỷ", " Ngàn", " Triệu", " Tỷ tỷ tỷ"}
        If so = "" Then
            Return ""
        End If
        so = Trim(so)
        X = Len(so) Mod 3
        so = IIf(X > 0, Space(3 - X), "") & so
        Solan = Len(so) \ 3
        If Solan > 10 Then
            Return ""
        End If
        For i = 1 To Len(so) - 2 Step 3
            cum = Mid(so, i, 3)
            If Val(cum) > 0 Then
                str = str & Doc_3_so(cum, tri) & dolon(Solan)
                tri = True
            Else
                Dim doclai As Boolean
                If (Solan - 1) Mod 3 = 0 Then
                    Select Case i
                        Case Is > 9
                            doclai = Val(Mid(so, i - 6, 9)) > 0
                        Case Else
                            doclai = Val(Left(so, i + 2)) > 0
                    End Select
                    If doclai Then str = str & dolon(Solan)
                End If
            End If
            Solan = Solan - 1
        Next
        Return LTrim(str)
    End Function
    Public Function Doc_3_so(ByVal so As String, ByVal le As Boolean) As String
        Dim so1 As Byte, so2 As Byte, so3 As Byte
        Dim chu() As String
        Dim str As String = ""
        chu = New String() {"", " Một", " Hai", " Ba", " Bốn", " Năm", " Sáu", " Bảy", " Tám", " Chín"}
        'so = Format(so, "000")
        so1 = Val(Left(so, 1))
        so2 = Val(Mid(so, 2, 1))
        so3 = Val(Right(so, 1))
        str = IIf(so1 > 0, chu(so1) & " Trăm", IIf(le, " Không Trăm", ""))
        le = IIf(so2 > 0, False, IIf(so3 > 0, (so1 > 0) Or (so1 = 0 And le), False))
        str = str & IIf(so2 > 1, chu(so2) & " Mươi", IIf(so2 = 1, " Mười", IIf(le, " Lẻ", "")))
        str = str & IIf(so2 > 1 And so3 = 1, " Mốt", IIf(so2 > 0 And so3 = 5, " Lâm", chu(so3)))
        Return str
    End Function
End Module
