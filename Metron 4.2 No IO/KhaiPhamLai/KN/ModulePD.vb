Module ModulePD
    Public PhienBan As Boolean
    Public NgayPBan As Date

    Public TenCTyBC, DiaChiBC, DienThoaiBC As String
    Public Sub KTPBPD()
        If Not (IO.File.Exists(My.Application.Info.DirectoryPath & "\PD.MTAP")) Then
            MsgBox("Yêu cầu cập nhật phiên bản phần mềm!" & Chr(13) & _
                "Vui lòng liên hệ công ty Khải Phàm để biết thêm chi tiết!" & vbNewLine & _
                "ĐT: (08) 3849 8622 - (08) 3849 8625.", MsgBoxStyle.Critical, "Thông báo")
            ManHinhChinh.Hide()
            FPhienBan.ShowDialog()
            Exit Sub
        End If

        Dim Ten As String

        Dim RD As System.IO.StreamReader

        RD = New IO.StreamReader(My.Application.Info.DirectoryPath & "\PD.MTAP")
        Ten = RD.ReadLine
        TenCTyBC = Ten
        DiaChiBC = RD.ReadLine
        DienThoaiBC = RD.ReadLine
        Dim SNGayBan As String = RD.ReadLine
        Dim SSoLuong As String = RD.ReadLine
        Dim SSoNgay As String = RD.ReadLine
        Dim SSeri As String = RD.ReadLine
        Dim txt2 As String = RD.ReadLine
        ManHinhChinh.Text = Strings.Right(Ten, Strings.Len(Ten) - 9) & " ** METRON 4.2 NO-IO Pro ** "
        RD.Close()
        Dim txt1 As String = TenCTyBC & DiaChiBC & DienThoaiBC & SNGayBan & SSoLuong & SSoNgay & SSeri
        Dim txt3 As String = ""
        Dim Tam2 As String = ""
        For I As Integer = 1 To txt1.Length
            Tam2 = Tam2 & Hex(Oct(Asc(Strings.Mid(txt1, I, 1))))
        Next
        For I As Integer = 1 To Strings.Len(Tam2)
            txt3 = txt3 & Chr(Hex(Asc(Strings.Mid(Tam2, I, 1))))
        Next
        If txt2 <> txt3 Then
            MsgBox("Bạn đã sử dụng sai phiên bản phần mềm!" & Chr(13) & _
                "Vui lòng liên hệ công ty Khải Phàm để biết thêm chi tiết" & vbNewLine & _
                "ĐT: (08) 3849 8622 - (08) 3849 8625.", MsgBoxStyle.Critical, "Thông báo")
            GoTo sai
        End If
        AllSeri = Strings.Right(SSeri, Strings.Len(SSeri) - 9)
        Dim Songay As Integer
        NgayPBan = DateSerial(Strings.Right(SNGayBan, 4), Mid(SNGayBan, 14, 2), Mid(SNGayBan, 11, 2))
        Songay = CInt(Strings.Right(SSoNgay, Strings.Len(SSoNgay) - Strings.Len("Số ngày: ")))
        If Songay = 0 Then
            PhienBan = True
            Exit Sub
        Else
            NgayPBan = DateAdd(DateInterval.Day, Songay, NgayPBan)
            ManHinhChinh.Text = "** METRON 4.2 NO-IO Pro **  PHIEN BAN DUNG THU - CHUA DANG KY "
            If NgayPBan < Now() Then
                MsgBox("Bạn đã hết thời gian sử dụng phần mềm!" & vbNewLine & _
                "Vui lòng liên hệ công ty Khải Phàm để biết thêm chi tiết!" & vbNewLine & _
                "ĐT: (08) 3849 8622 - (08) 3849 8625.", MsgBoxStyle.Critical, "Thông báo")
sai:
                ManHinhChinh.Hide()
                FPhienBan.ShowDialog()
                Exit Sub
            End If
        End If
    End Sub

    Public Sub KTNgayHH(ByVal TG As Date)
        If PhienBan = False Then
            If TG > NgayPBan Then
                MsgBox("Bạn đã hết thời gian sử dụng phần mềm!" & vbNewLine _
                & "Vui lòng liên hệ công ty Khải Phàm để biết thêm chi tiết!" & vbNewLine & _
                "ĐT: (08) 3849 8622 - (08) 3849 8625.", MsgBoxStyle.Critical, "Hết thời gian sử dụng")
                End
            End If
        End If
    End Sub

End Module
