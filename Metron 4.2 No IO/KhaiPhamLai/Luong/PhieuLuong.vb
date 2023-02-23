Imports System.Drawing.Drawing2D
Public Class PhieuLuong
    Public RongA4_PORTRAIT As Integer = 850
    Public CaoA4_PORTRAIT As Integer = 1100
    Public RongA4_LANDSCAPE As Integer = 1100
    Public CaoA4_LANDSCAPE As Integer = 850
    Public RONG As Integer = 0
    Public CAO As Integer = 0
    Public f As Font
    Public fLon As Font
    Public Khoangcach2dong As Integer = 12
    Public Ds_NhanVien As New ArrayList
    Public soNhanvien As Integer = 0
    Public Duongdanfilehinh As New ArrayList
    Public ChieucaoLettrang As Integer = 0
#Region "Thong tin cong ty"
    Public X_Congty As Integer = 100
    Public Y_Congty As Integer = 100
    Public Tencongty As String = ""
    Public Diachi1 As String = ""
    Public diachi2 As String = ""
    Public Sodt As String = ""
#End Region
#Region "Tieu đề Phieu luong "
    Public X_Tieude As Integer = RongA4_PORTRAIT / 2
    Public Y_Tieude As Integer = 30
    Public Ten_tieude1 As String = "PHIẾU LƯƠNG "
    Public Ten_tieude2 As String = ""
    Public X_logo As Integer = 50
    Public Y_logo As Integer = 10
   
#End Region
#Region "Ngày phát"
    Public X_ngayphat As Integer = RongA4_PORTRAIT * 3 / 4 + 30
    Public Y_ngayphat As Integer = 70
    Public Ten_ngayphat As String = "Ngày phát: "
#End Region
#Region "Thông tin nhan vien"
    Public X_TTnhanvien As Integer = RongA4_PORTRAIT / 8
    Public Y_TTnhanvien As Integer = CaoA4_PORTRAIT / 4
    Public TT_nhanvien As String = "Thông tin nhân viên"
    Public Manv As String = "Mã NV  :"
    Public Tennv As String = "Tên NV :"
    Public Chucvu As String = "Chức vụ:"
    Public bophan As String = "Bộ phận:"
#End Region
#Region "Thông tin Lương"
    Public X_TTluong As Integer = RongA4_PORTRAIT / 2 + 30
    Public Y_TTluong As Integer = CaoA4_PORTRAIT / 4
    Public TT_luong As String = "Thông tin lương"
    Public Ds_TTluongTD As New ArrayList
    Public Ds_TTluong As New ArrayList
#End Region
#Region "Công luong"
    Public X_CongLuong As Integer = RongA4_PORTRAIT / 8
    Public Y_CongLuong As Integer = CaoA4_PORTRAIT / 2
    Public CongLuong As String = "Cộng lương"
    Public Ds_CongLuongTD As New ArrayList
    Public Ds_CongLuong As New ArrayList
#End Region
#Region "tru luong"
    Public X_TruLuong As Integer = RongA4_PORTRAIT / 2 + 30
    Public Y_TruLuong As Integer = CaoA4_PORTRAIT / 2
    Public truluong As String = "Trừ lương"
    Public Ds_TruLuongTD As New ArrayList
    Public Ds_TruLuong As New ArrayList
#End Region
#Region "Thanh tien va thuc lanh"
    Public X_thanhtien As Integer = RongA4_PORTRAIT / 2 + 30
    Public Y_thanhtien As Integer = CaoA4_PORTRAIT * 3 / 4
    Public Thanhtien1TD As String = ""
    Public Thanhtien1 As String = ""
    Public Thanhtien2TD As String = ""
    Public Thanhtien2 As String = ""
    Public ThuclanhTD As String = ""
    Public Thuclanh As String = ""
    Public Docso As String = ""
    Public X_kyNhan As Integer = 80
    Public Y_KyNhan As Integer = 350
    Public X_DuyetChi As Integer = 380
    Public Y_Duyet As Integer = 350
#End Region
    Public Sub New()
        RONG = 0
        CAO = 0
        Tencongty = "CÔNG TY TNHH MTV CỌ VIỆT MỸ"
        Diachi1 = "90 Chợ Lớn, phường 11, quận 6, HCM"
        diachi2 = ""
        Sodt = ""
        Ten_tieude1 = "PHIẾU LƯƠNG "
        Ten_tieude2 = ""
        Thanhtien1TD = ""
        Thanhtien1 = ""
        Thanhtien2TD = ""
        Thanhtien2 = ""
        ThuclanhTD = ""
        Thuclanh = ""
        Ten_ngayphat = "Ngày phát: "
        Manv = "Mã NV  : "
        Tennv = "Tên NV : "
        Chucvu = "Chức vụ: "
        bophan = "Bộ phận: "
        TT_luong = "Thông tin lương"
        Ds_TTluongTD = New ArrayList
        Ds_TTluong = New ArrayList
        CongLuong = "Cộng lương"
        Ds_CongLuongTD = New ArrayList
        Ds_CongLuong = New ArrayList
        truluong = "Trừ lương"
        Ds_TruLuongTD = New ArrayList
        Ds_TruLuong = New ArrayList
    End Sub
    Private Sub THONGSOTOADO(ByVal g As Integer, ByVal LANDSCAPE As Boolean)
        Dim rongphu As Integer = 0
        Dim caophu As Integer = 0
        If LANDSCAPE Then
            rongphu = (g Mod 2) * (RongA4_LANDSCAPE / 2)
            caophu = (g \ 2) * (CaoA4_LANDSCAPE / 2)
        Else
            rongphu = (g Mod 2) * (RongA4_PORTRAIT / 2)
            caophu = (g \ 2) * (CaoA4_PORTRAIT / 2)
        End If
        X_Congty = 10 + rongphu 'RONG / 8 
        Y_Congty = 40 + caophu
        X_logo = 40 + rongphu
        Y_logo = 10 + caophu
        X_kyNhan = 100 + rongphu
        Y_KyNhan = 300 + caophu
        X_DuyetChi = 380 + rongphu
        Y_Duyet = 300 + caophu
        X_Tieude = RONG / 2 + rongphu
        Y_Tieude = 40 + caophu
        X_ngayphat = RONG * 3 / 4 + rongphu - 50
        Y_ngayphat = 75 + caophu
        X_TTnhanvien = RONG / 16 + rongphu
        Y_TTnhanvien = CAO / 4 + 30 + caophu - 20
        X_TTluong = RONG / 2 + 30 + rongphu
        Y_TTluong = CAO / 4 + 30 + caophu - 20
        X_CongLuong = RONG / 16 + rongphu
        Y_CongLuong = CAO / 2 + 30 + caophu - 35
        X_TruLuong = RONG / 2 + 30 + rongphu
        Y_TruLuong = CAO / 2 + 30 + caophu - 35
        X_thanhtien = RONG / 2 + 30 + rongphu
        Y_thanhtien = CAO * 3 / 4 + 30 + caophu - 35
    End Sub
    Public Sub vebien(ByVal LANDSCAPE As Boolean, ByRef e As System.Drawing.Printing.PrintPageEventArgs)
        If LANDSCAPE Then
            CaoA4_LANDSCAPE = e.PageSettings.PaperSize.Width
            RongA4_LANDSCAPE = e.PageSettings.PaperSize.Height

            e.Graphics.DrawLine(Pens.Black, 0, CInt(CaoA4_LANDSCAPE / 2), RongA4_LANDSCAPE, CInt(CaoA4_LANDSCAPE / 2))
            e.Graphics.DrawLine(Pens.Black, CInt(RongA4_LANDSCAPE / 2), 0, CInt(RongA4_LANDSCAPE / 2), CaoA4_LANDSCAPE)

            e.Graphics.DrawLine(Pens.Black, CInt(RongA4_LANDSCAPE / 4), CInt(CaoA4_LANDSCAPE / 8), CInt(RongA4_LANDSCAPE / 4), CInt(CaoA4_LANDSCAPE * 3 / 8))
            e.Graphics.DrawLine(Pens.Black, CInt(RongA4_LANDSCAPE * 3 / 4), CInt(CaoA4_LANDSCAPE / 8), CInt(RongA4_LANDSCAPE * 3 / 4), CInt(CaoA4_LANDSCAPE * 3 / 8))
            e.Graphics.DrawLine(Pens.Black, CInt(RongA4_LANDSCAPE / 4), CInt(CaoA4_LANDSCAPE * 5 / 8), CInt(RongA4_LANDSCAPE / 4), CInt(CaoA4_LANDSCAPE * 7 / 8))
            e.Graphics.DrawLine(Pens.Black, CInt(RongA4_LANDSCAPE * 3 / 4), CInt(CaoA4_LANDSCAPE * 5 / 8), CInt(RongA4_LANDSCAPE * 3 / 4), CInt(CaoA4_LANDSCAPE * 7 / 8))
        Else
            CaoA4_PORTRAIT = e.PageSettings.PaperSize.Width
            RongA4_PORTRAIT = e.PageSettings.PaperSize.Height
            e.Graphics.DrawLine(Pens.Black, 0, CInt(CaoA4_PORTRAIT / 2), RongA4_PORTRAIT, CInt(CaoA4_PORTRAIT / 2))
            e.Graphics.DrawLine(Pens.Black, CInt(RongA4_PORTRAIT / 2), 0, CInt(RongA4_PORTRAIT / 2), CaoA4_PORTRAIT)

            e.Graphics.DrawLine(Pens.Black, CInt(RongA4_PORTRAIT / 4), CInt(CaoA4_PORTRAIT / 8), CInt(RongA4_PORTRAIT / 4), CInt(CaoA4_PORTRAIT * 3 / 8))
            e.Graphics.DrawLine(Pens.Black, CInt(RongA4_PORTRAIT * 3 / 4), CInt(CaoA4_PORTRAIT / 8), CInt(RongA4_PORTRAIT * 3 / 4), CInt(CaoA4_PORTRAIT * 3 / 8))
            e.Graphics.DrawLine(Pens.Black, CInt(RongA4_PORTRAIT / 4), CInt(CaoA4_PORTRAIT / 8), CInt(RongA4_PORTRAIT / 4), CInt(CaoA4_PORTRAIT * 3 / 8))
            e.Graphics.DrawLine(Pens.Black, CInt(RongA4_PORTRAIT * 3 / 4), CInt(CaoA4_PORTRAIT / 8), CInt(RongA4_PORTRAIT * 3 / 4), CInt(CaoA4_PORTRAIT * 3 / 8))
        End If
    End Sub
    Public Sub Hienthi(ByVal A_ As Integer, ByVal LANDSCAPE As Boolean, ByVal g As Integer, ByRef e As System.Drawing.Printing.PrintPageEventArgs, ByVal Logo As Image)
        CaoA4_LANDSCAPE = e.PageSettings.PaperSize.Width
        RongA4_LANDSCAPE = e.PageSettings.PaperSize.Height
        CaoA4_PORTRAIT = e.PageSettings.PaperSize.Width
        RongA4_PORTRAIT = e.PageSettings.PaperSize.Height
        Select Case A_
            Case 4
                If LANDSCAPE Then
                    RONG = RongA4_LANDSCAPE
                    CAO = CaoA4_LANDSCAPE
                Else
                    RONG = RongA4_PORTRAIT
                    CAO = CaoA4_PORTRAIT
                End If
            Case 5
                If LANDSCAPE Then
                    RONG = CaoA4_LANDSCAPE
                    CAO = (RongA4_LANDSCAPE / 2)
                    'ChieucaoLettrang = trang * RongA4_LANDSCAPE
                Else
                    RONG = RongA4_PORTRAIT / 2
                    CAO = CaoA4_PORTRAIT
                    'ChieucaoLettrang = trang * CaoA4_PORTRAIT
                End If
            Case 6
                If LANDSCAPE Then
                    RONG = RongA4_LANDSCAPE / 2
                    CAO = CaoA4_LANDSCAPE / 2
                    'ChieucaoLettrang = trang * CaoA4_LANDSCAPE
                Else
                    RONG = RongA4_PORTRAIT / 2
                    CAO = CaoA4_PORTRAIT / 2
                    'ChieucaoLettrang = trang * CaoA4_PORTRAIT
                End If
            Case Else
        End Select
        THONGSOTOADO(g, LANDSCAPE)
        'Thong tin cong ty
        Dim Width_Tencongty As Integer = e.Graphics.MeasureString(Tencongty, f, e.MarginBounds.Width).Width
        Dim Width_Diachi1 As Integer = e.Graphics.MeasureString(Diachi1, f, e.MarginBounds.Width).Width
        Dim Width_Diachi2 As Integer = e.Graphics.MeasureString(diachi2, f, e.MarginBounds.Width).Width
        Dim Width_Sodt As Integer = e.Graphics.MeasureString(Sodt, f, e.MarginBounds.Width).Width
        e.Graphics.DrawString(Tencongty, f, Brushes.Black, X_Congty, Y_Congty + ChieucaoLettrang, New StringFormat())
        'e.Graphics.DrawImage(Logo, X_logo, Y_logo, 126, 30)
        If X_Congty + Width_Diachi1 + IIf(X_Tieude > RONG / 2, RONG / 2, 0) < X_Tieude Then
        e.Graphics.DrawString(Diachi1, f, Brushes.Black, X_Congty, Y_Congty + Khoangcach2dong + ChieucaoLettrang)
        Else
            'diachi2 = Diachi1.Substring(Diachi1.Length / 2)
            'Diachi1 = Diachi1.Substring(0, Diachi1.Length / 2 + diachi2.IndexOf(",") + 1)
            'diachi2 = diachi2.Substring(diachi2.IndexOf(",") + 1)
        e.Graphics.DrawString(Diachi1, f, Brushes.Black, X_Congty, Y_Congty + Khoangcach2dong + ChieucaoLettrang)
        e.Graphics.DrawString(diachi2, f, Brushes.Black, X_Congty, Y_Congty + 2 * Khoangcach2dong + ChieucaoLettrang)
        End If
        If X_Congty + Width_Sodt + IIf(X_Tieude > RONG / 2, RONG / 2, 0) < X_Tieude Then
            e.Graphics.DrawString(Sodt, f, Brushes.Black, X_Congty, Y_Congty + 3 * Khoangcach2dong + ChieucaoLettrang)
        Else
            Do
                Width_Sodt = e.Graphics.MeasureString(Sodt, f, e.MarginBounds.Width).Width
                If X_Congty + Width_Sodt + IIf(X_Tieude > RONG / 2, RONG / 2, 0) > X_Tieude Then
                    Try
                        Sodt = Sodt.Substring(0, Sodt.LastIndexOf(",") - 1)
                    Catch ex As Exception
                        Exit Do
                    End Try
                Else
                    Exit Do
                End If
            Loop
            e.Graphics.DrawString(Sodt, f, Brushes.Black, X_Congty, Y_Congty + 3 * Khoangcach2dong + ChieucaoLettrang)
        End If

        'Tieu de phieuluong
        Dim Width_Tieude1 As Integer = e.Graphics.MeasureString(Ten_tieude1, fLon, e.MarginBounds.Width).Width
        Dim Width_Tieude2 As Integer = e.Graphics.MeasureString(Ten_tieude2, fLon, e.MarginBounds.Width).Width
        e.Graphics.DrawString(Ten_tieude1, fLon, Brushes.Black, X_Tieude, Y_Tieude)
        e.Graphics.DrawString(Ten_tieude2, fLon, Brushes.Black, X_Tieude + (Width_Tieude1 - Width_Tieude2) / 2, Y_Tieude + Khoangcach2dong * 2 + ChieucaoLettrang)

        'Ngay phat
        e.Graphics.DrawString(Ten_ngayphat & Now.Date, f, Brushes.Black, X_ngayphat, Y_ngayphat)
        'Thông tin nhân viên
        e.Graphics.DrawString(TT_nhanvien, fLon, Brushes.Black, X_TTnhanvien, Y_TTnhanvien - Khoangcach2dong * 2 + ChieucaoLettrang)
        e.Graphics.DrawString(Manv, f, Brushes.Black, X_TTnhanvien, Y_TTnhanvien + ChieucaoLettrang)
        e.Graphics.DrawString(Tennv, f, Brushes.Black, X_TTnhanvien, Y_TTnhanvien + Khoangcach2dong + ChieucaoLettrang)
        e.Graphics.DrawString(bophan, f, Brushes.Black, X_TTnhanvien, Y_TTnhanvien + Khoangcach2dong * 2 + ChieucaoLettrang)
        e.Graphics.DrawString(Chucvu, f, Brushes.Black, X_TTnhanvien, Y_TTnhanvien + Khoangcach2dong * 3 + ChieucaoLettrang)
        'Thong tin luong
        Dim width_ttluongmax As Integer = 160
        e.Graphics.DrawString(TT_luong, fLon, Brushes.Black, X_TTluong, Y_TTluong - Khoangcach2dong * 2 + ChieucaoLettrang)
        For i As Integer = 0 To Ds_TTluong.Count - 1
            e.Graphics.DrawString(Ds_TTluongTD.Item(i).ToString, f, Brushes.Black, X_TTluong, Y_TTluong + ChieucaoLettrang)
            e.Graphics.DrawString(":", f, Brushes.Black, X_TTluong + width_ttluongmax / 2, Y_TTluong + ChieucaoLettrang)
            Dim width_TT_luong As Integer = e.Graphics.MeasureString(Ds_TTluong.Item(i).ToString, f, e.MarginBounds.Width).Width
            e.Graphics.DrawString(Ds_TTluong.Item(i).ToString, f, Brushes.Black, X_TTluong + width_ttluongmax - width_TT_luong, Y_TTluong + ChieucaoLettrang)
            Y_TTluong += Khoangcach2dong
        Next
        'Cong luong
        Dim width_CongluongMax As Integer = 160
        e.Graphics.DrawString(CongLuong, fLon, Brushes.Black, X_CongLuong, Y_CongLuong - Khoangcach2dong * 2 + ChieucaoLettrang)
        For i As Integer = 0 To Ds_CongLuong.Count - 1
            e.Graphics.DrawString(Ds_CongLuongTD.Item(i).ToString, f, Brushes.Black, X_CongLuong, Y_CongLuong + ChieucaoLettrang)
            e.Graphics.DrawString(":", f, Brushes.Black, X_CongLuong + width_CongluongMax / 2, Y_CongLuong + ChieucaoLettrang)
            Dim width_congluong As Integer = e.Graphics.MeasureString(Ds_CongLuong.Item(i).ToString, f, e.MarginBounds.Width).Width
            e.Graphics.DrawString(Ds_CongLuong.Item(i).ToString, f, Brushes.Black, X_CongLuong + width_CongluongMax - width_congluong, Y_CongLuong + ChieucaoLettrang)
            Y_CongLuong += Khoangcach2dong
        Next
        'Tru luong
        Dim width_truluongMax As Integer = 160
        e.Graphics.DrawString(truluong, fLon, Brushes.Black, X_TruLuong, Y_TruLuong - Khoangcach2dong * 2 + ChieucaoLettrang)
        For i As Integer = 0 To Ds_TruLuong.Count - 1
            e.Graphics.DrawString(Ds_TruLuongTD.Item(i).ToString, f, Brushes.Black, X_TruLuong, Y_TruLuong + ChieucaoLettrang)
            e.Graphics.DrawString(":", f, Brushes.Black, X_TruLuong + width_truluongMax / 2, Y_TruLuong + ChieucaoLettrang)
            Dim width_truluong As Integer = e.Graphics.MeasureString(Ds_TruLuong.Item(i).ToString, f, e.MarginBounds.Width).Width
            e.Graphics.DrawString(Ds_TruLuong.Item(i).ToString, f, Brushes.Black, X_TruLuong + width_truluongMax - width_truluong, Y_TruLuong + ChieucaoLettrang)
            Y_TruLuong += Khoangcach2dong
        Next
        'thanh tien
        Dim width_ThanhTienMax As Integer = 200

        'e.Graphics.DrawString(Thanhtien2TD, fLon, Brushes.Black, X_thanhtien, Y_thanhtien)
        'e.Graphics.DrawString(":", fLon, Brushes.Black, X_thanhtien + width_ThanhTienMax / 2, Y_thanhtien)
        'Dim width_ThanhTien2 As Integer = e.Graphics.MeasureString(Thanhtien1, f, e.MarginBounds.Width).Width
        'e.Graphics.DrawString(Thanhtien2, fLon, Brushes.Black, X_thanhtien + width_ThanhTienMax - width_ThanhTien2, Y_thanhtien)

        e.Graphics.DrawString(":", fLon, Brushes.Black, X_thanhtien - 20 + width_ThanhTienMax / 2, Y_thanhtien + Khoangcach2dong - 43)
        fLon = New Font(fLon, FontStyle.Bold)
        e.Graphics.DrawString(ThuclanhTD, fLon, Brushes.Black, X_thanhtien, Y_thanhtien + Khoangcach2dong - 43)
        Dim width_Thuclanh As Integer = e.Graphics.MeasureString(Thuclanh, f, e.MarginBounds.Width).Width
        e.Graphics.DrawString(Thuclanh, fLon, Brushes.Black, X_thanhtien + width_ThanhTienMax - width_Thuclanh - 30, Y_thanhtien + Khoangcach2dong - 43)
        e.Graphics.DrawString("Ký nhận", fLon, Brushes.Black, X_kyNhan, Y_KyNhan + 40)
        e.Graphics.DrawString("Duyệt chi", fLon, Brushes.Black, X_DuyetChi, Y_Duyet)

    End Sub
End Class
