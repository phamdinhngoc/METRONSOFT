 
Module ModuleKN

    Dim BusNV As New nhanvienBus(DTOKetnoi, False)
    Dim lvt As ListViewItem
    Dim DTONV As New nhanviendto
    Dim BusVR As New VaoraBus(DTOKetnoi, False)
    Dim DtoVR As New Vaoradto

    Dim STT As Integer

    Public Const LTenMay = 0
    Public Const LViTri = 1
    Public Const LTrangThai = 2
    Public Const LIP = 3
    Public Const LMayID = 4
    Public Const LCom = 5
    Public Const LRate = 6
    Public Const LKieu = 7
    Public Const LLoaiMay = 8
    Public Const LMaySo = 9

    Public Const LTenMay1 = 0
    Public Const LVitri1 = 1
    Public Const LMayID1 = 2
    Public Const LMaySo1 = 3
    Public Const LLoaiMay1 = 4
    Public SeriNoMCC As String = ""


    Structure StMay
        Public Mayso As Integer
        Public TenMay As String
        Public KieuKN As Integer
        Public IP As String
        Public Cong As Integer
        Public Rate As Integer
        Public LoaiMay As Integer
        Public MaMay As Integer
    End Structure

    Private Function KetNoiZK(ByVal ZKem1 As Axzkemkeeper.AxCZKEM, ByVal MaySo As Integer, ByVal KieuKN As Integer, ByVal IP As String, ByVal Cong As Integer, ByVal Rate As Integer) As Boolean

        KetNoiZK = False
        If KieuKN = 1 Then
            KetNoiZK = ZKem1.Connect_Net(IP, Cong)
        ElseIf KieuKN = 2 Then
            KetNoiZK = ZKem1.Connect_Com(Cong, MaySo, Rate)
        Else
            KetNoiZK = ZKem1.Connect_USB(MaySo)
        End If

        If KetNoiZK Then
            KTSeriZK(ZKem1, MaySo, KetNoiZK)
        Else
            MsgBox("Kết nối thất bại! Vui lòng kiểm tra lại địa chỉ IP", MsgBoxStyle.Critical, "Thông báo")
        End If
    End Function


    Private Function KetNoiHanVon(ByVal HanVon As AxMr_Lam_HV.Axusr_MrLam_HV, ByVal MaySo As Integer, ByVal KieuKN As Integer, ByVal IP As String, ByVal Cong As Integer, ByVal Rate As Integer) As Boolean

        KetNoiHanVon = False
        If KieuKN = 1 Then
            KetNoiHanVon = HanVon.KetNoi(MaySo, IP)
        Else
            MsgBox("Khong ho tro ket noi", MsgBoxStyle.Critical, "Loi")
            KetNoiHanVon = False
            Exit Function
        End If

        If KetNoiHanVon = True Then
            KTSeriHanVon(HanVon, MaySo, KetNoiHanVon)
        Else
            MsgBox("Kết nối thất bại! Vui lòng kiểm tra lại địa chỉ IP", MsgBoxStyle.Critical, "Thông báo")
        End If
    End Function

    Private Sub KTSeriZK(ByVal Zkem1 As Axzkemkeeper.AxCZKEM, ByVal MaySo As Integer, ByRef KQ As Boolean)
        KQ = False
        Dim Seri As String = ""
        Zkem1.GetSerialNumber(MaySo, Seri)

        If AllSeri.IndexOf(Seri) >= 0 Then
            KQ = True
            Zkem1.RegEvent(MaySo, 32767)
            Zkem1.EnableDevice(MaySo, True)
            MsgBox("Kết nối thành công", MsgBoxStyle.Information, "Thông báo")
        Else
            KQ = False
            MsgBox("Bạn đã sử dụng sai phiên bản phần mềm!" & Chr(13) & _
            "Vui lòng liên hệ công ty Khải Phàm để biết thêm chi tiết!" & Chr(13) _
            & "(08) 3849 8622 - (08) 3849 8625.", MsgBoxStyle.Critical, "Loi phien ban")
            MsgBox("Số Seri: " & Seri, MsgBoxStyle.Information, "Thông báo")
            Zkem1.Disconnect()
        End If

    End Sub

    Private Sub KTSeriHanVon(ByVal HanVon As AxMr_Lam_HV.Axusr_MrLam_HV, ByVal MaySo As Integer, ByRef KQ As Boolean)
        KQ = False
        Dim Seri As String = HanVon.DocSeriMay()

         
        If AllSeri.IndexOf(Seri) >= 0 Then
            KQ = True
           
            MsgBox("Kết nối thành công", MsgBoxStyle.Information, "Thông báo")
        Else
            KQ = False
            MsgBox("Bạn đã sử dụng sai phiên bản phần mềm!" & Chr(13) & _
            "Vui lòng liên hệ công ty Khải Phàm để biết thêm chi tiết!" & Chr(13) _
            & "(08) 3849 8622 - (08) 3849 8625.", MsgBoxStyle.Critical, "Loi phien ban")
            MsgBox("Số Seri: " & Seri, MsgBoxStyle.Information, "Thông báo")
        End If

    End Sub


    Public Function KetnoiT58(ByVal T58 As AxFKAttendLib.AxFKAttend, ByVal MaySo As Integer, ByVal KieuKN As Integer, ByVal IP As String, ByVal Cong As Integer, ByVal Rate As Integer) As Boolean


        Try

            If Not Char.IsDigit(Strings.Left(IP, 1)) Then
                Dim IPA() As System.Net.IPAddress
                IPA = System.Net.Dns.GetHostAddresses(IP)
                IP = IPA(0).ToString
            End If

        Catch ex As Exception

        End Try

        If KieuKN = 1 Then
            Dim kqkn As Integer = T58.ConnectNet(MaySo, IP, Cong, 5000, 0, 0, 1262)
            If kqkn = 1 Then
                KetnoiT58 = True
            Else
                KetnoiT58 = False
            End If
            ' Ket noi bang cong COM
        ElseIf KieuKN = 2 Then
            Dim kqkn As Integer = T58.ConnectComm(MaySo, Cong, Rate, 801, 20, 1262)
            If kqkn = 1 Then
                KetnoiT58 = True
            Else
                KetnoiT58 = False
            End If
        Else
            Dim kqkn As Integer = T58.ConnectUSB(MaySo, 1262)
            If kqkn = 1 Then
                KetnoiT58 = True
            Else
                KetnoiT58 = False
            End If
        End If

        If KetnoiT58 = True Then
            KTSeriT58(T58, MaySo, KetnoiT58)
        Else
            MsgBox("Kết nối thất bại! Vui lòng kiểm tra lại địa chỉ IP", MsgBoxStyle.Critical, "Thông báo")
        End If
    End Function


    Public Function KetnoiF80(ByVal mF80 As AxSB100BPCLib.AxSB100BPC, ByVal MaySo As Integer, ByVal KieuKN As Integer, ByVal IP As String, ByVal Cong As Integer, ByVal Rate As Integer) As Boolean
        Try
            If Not Char.IsDigit(Strings.Left(IP, 1)) Then
                Dim IPA() As System.Net.IPAddress
                IPA = System.Net.Dns.GetHostAddresses(IP)
                IP = IPA(0).ToString
            End If
        Catch ex As Exception
        End Try
        If KieuKN = 1 Then
            KetnoiF80 = mF80.ConnectTcpip(MaySo, IP, Cong, 0)
        ElseIf KieuKN = 2 Then
            Dim kqkn As Boolean = mF80.ConnectSerial(MaySo, Cong, Rate)
            If kqkn = True Then
                KetnoiF80 = True
            Else
                KetnoiF80 = False
            End If
        Else
            Dim kqkn As Boolean = mF80.ConnectSerial(MaySo, 0, 115200)
            If kqkn = True Then
                KetnoiF80 = True
            Else
                KetnoiF80 = False
            End If
        End If
        If KetnoiF80 = True Then
            KTSeriF80(mF80, MaySo, KetnoiF80)
        Else
            MsgBox("Kết nối thất bại! Vui lòng kiểm tra lại địa chỉ IP.", MsgBoxStyle.Critical, "Thông báo")
        End If
    End Function

    Public Function KetnoiND(ByVal NDK1 As AxFK524PXNLib.AxFK524PXN, ByVal MaySo As Integer, ByVal KieuKN As Integer, ByVal IP As String, ByVal Cong As Integer, ByVal Rate As Integer) As Boolean
        KetnoiND = False
        Try
            If Not Char.IsDigit(Strings.Left(IP, 1)) Then
                Dim IPA() As System.Net.IPAddress
                IPA = System.Net.Dns.GetHostAddresses(IP)
                IP = IPA(0).ToString
            End If
        Catch ex As Exception
        End Try
        If KieuKN = 1 Then
            NDK1.SetIPAddress(IP, Cong, 0)
            If NDK1.OpenCommPort(MaySo, 3, 0) Then
                Dim COMC As Integer
                NDK1.GetCommCode(MaySo, COMC)
                If COMC = 21066 Then
                    KetnoiND = True
                Else
                    KetnoiND = False
                End If
            End If
            ' Ket noi bang cong COM
        Else
            NDK1.Baudrate = Rate
            NDK1.CommPort = Cong
            NDK1.Baudrate = Rate
            If NDK1.OpenCommPort(MaySo, 3, Rate) Then
                Dim COMC As Integer
                NDK1.GetCommCode(MaySo, COMC)
                If COMC = 21066 Then
                    KetnoiND = True
                Else
                    KetnoiND = False
                End If
            End If
        End If
        If KetnoiND = True Then
            KTSeriND(NDK1, MaySo, KetnoiND)
        Else
            MsgBox("Kết nối thất bại! Vui lòng kiểm tra lại địa chỉ IP", MsgBoxStyle.Critical, "Thông báo")
        End If
    End Function
    Private Sub KTSeriT58(ByVal T58 As AxFKAttendLib.AxFKAttend, ByVal MaySo As Integer, ByRef KQ As Boolean)
        KQ = False
        Dim Seri As String = ""
        T58.GetProductData(1, Seri)
        If AllSeri.IndexOf(Seri) >= 0 Then
            KQ = True
            T58.EnableDevice(True)
            MsgBox("Kết nối thành công", MsgBoxStyle.Information, "Thông báo")
        Else
            KQ = False
            MsgBox("Bạn đã sử dụng sai phiên bản phần mềm!" & Chr(13) & _
            "Vui lòng liên hệ công ty Khải Phàm để biết thêm chi tiết!" & Chr(13) _
            & "(08) 3849 8622 - (08) 3849 8625.", MsgBoxStyle.Critical, "Loi phien ban")
            MsgBox("Số Seri: " & Seri, MsgBoxStyle.Information, "Thông báo")
            T58.DisConnect()
        End If
    End Sub

    Private Function ChuyenIPtoLong(ByVal txtIP As String) As Integer
        Dim dwIP As Double
        Dim k As Long
        Dim szTmp As String
        k = InStr(1, txtIP, ".", vbTextCompare)
        If k = 0 Then
            ChuyenIPtoLong = 0
            Exit Function
        End If
        szTmp = Left(txtIP, k - 1)
        txtIP = Mid(txtIP, k + 1)
        dwIP = Val(szTmp)
        k = InStr(1, txtIP, ".", vbTextCompare)
        If k = 0 Then
            ChuyenIPtoLong = 0
            Exit Function
        End If
        szTmp = Left(txtIP, k - 1)
        txtIP = Mid(txtIP, k + 1)
        dwIP = dwIP * 256 + Val(szTmp)
        k = InStr(1, txtIP, ".", vbTextCompare)
        If k = 0 Then
            ChuyenIPtoLong = 0
            Exit Function
        End If
        szTmp = Left(txtIP, k - 1)
        txtIP = Mid(txtIP, k + 1)
        dwIP = dwIP * 256 + Val(szTmp)
        dwIP = dwIP * 256 + Val(txtIP)
        If dwIP > 2147483647 Then dwIP = dwIP - 4294967296.0#
        ChuyenIPtoLong = dwIP
    End Function

    Private Sub KTSeriF80(ByVal mF80 As AxSB100BPCLib.AxSB100BPC, ByVal MaySo As Integer, ByRef KQ As Boolean)
        KQ = False
        Dim Seri As String = ""
        mF80.GetSerialNumber(MaySo, Seri)
        Seri = Strings.Mid(Seri, 4)
        If AllSeri.IndexOf(Seri) >= 0 Then
            KQ = True
            mF80.EnableDevice(MaySo, True)
            MsgBox("Kết nối thành công", MsgBoxStyle.Information, "Thông báo")
        Else
            KQ = False
            MsgBox("Bạn đã sử dụng sai phiên bản phần mềm!" & Chr(13) & _
            "Vui lòng liên hệ công ty Khải Phàm để biết thêm chi tiết!" & Chr(13) _
            & "(08) 3849 8622 - (08) 3849 8625.", MsgBoxStyle.Critical, "Lỗi phiên bản")
            MsgBox("Số Seri: " & Seri, MsgBoxStyle.Information, "Thông báo")
            mF80.Disconnect()
        End If
    End Sub

    Private Sub KTSeriND(ByVal NDK1 As AxFK524PXNLib.AxFK524PXN, ByVal MaySo As Integer, ByRef KQ As Boolean)
        KQ = False
        Dim Seri As String = ""
        NDK1.GetSerialNumber(MaySo, Seri)

        'If AllSeri.IndexOf(Seri) >= 0 Then
        If 1 > 0 Then
            KQ = True
            NDK1.EnableDevice(MaySo, True)
            MsgBox("Kết nối thành công", MsgBoxStyle.Information, "Thông báo")
        Else
            KQ = False
            MsgBox("Bạn đã sử dụng sai phiên bản phần mềm!" & Chr(13) & _
            "Vui lòng liên hệ công ty Khải Phàm để biết thêm chi tiết!" & Chr(13) _
            & "(08) 3849 8622 - (08) 3849 8625.", MsgBoxStyle.Critical, "Loi phien ban")
            MsgBox("Số Seri: " & Seri, MsgBoxStyle.Information, "Thông báo")
            NDK1.CloseCommPort()
        End If
    End Sub

    Public Sub TaoMay()
        Dim TTMayCC As StMay
        Dim KQKN As Boolean
        Dim Lst As ListViewItem
        With ManHinhChinh
            If .ListView.SelectedItems.Count <= 0 Then
                MsgBox("Bạn Chưa Chọn Máy Chấm Công", MsgBoxStyle.Critical, "Thông Báo")
                Exit Sub
            End If
            Lst = ManHinhChinh.ListView.SelectedItems(0)

            '  For i As Integer = 0 To .ListView.SelectedItems.Count - 1
            TTMayCC.Mayso = Lst.SubItems(LMaySo).Text
            TTMayCC.KieuKN = Lst.SubItems(LKieu).Text
            TTMayCC.IP = Lst.SubItems(LIP).Text
            TTMayCC.Cong = Lst.SubItems(LCom).Text
            TTMayCC.Rate = Lst.SubItems(LRate).Text
            TTMayCC.LoaiMay = Lst.SubItems(LLoaiMay).Text
            TTMayCC.MaMay = Lst.SubItems(LMayID).Text
            KQKN = False
            Application.DoEvents()
            If TTMayCC.LoaiMay = 2 Then

                TaoMayZK(TTMayCC.MaMay, TTMayCC.Mayso, TTMayCC.KieuKN, TTMayCC.IP, TTMayCC.Cong, TTMayCC.Rate, KQKN)
                If KQKN = True Then
                    Lst.Tag = "2"
                    Lst.ImageIndex = 2
                    Lst.SubItems.Item(LTrangThai).Text = "Kết nối"
                    .TrangThai("2")
                End If

            ElseIf TTMayCC.LoaiMay = 1 Then

                TaoMayND(TTMayCC.MaMay, TTMayCC.Mayso, TTMayCC.KieuKN, TTMayCC.IP, TTMayCC.Cong, TTMayCC.Rate, KQKN)
                If KQKN = True Then
                    Lst.Tag = "2"
                    Lst.ImageIndex = 2
                    Lst.SubItems.Item(LTrangThai).Text = "Kết nối"
                    .TrangThai("2")
                End If

            ElseIf TTMayCC.LoaiMay = 3 Then
                TaoMayT58(TTMayCC.MaMay, TTMayCC.Mayso, TTMayCC.KieuKN, TTMayCC.IP, TTMayCC.Cong, TTMayCC.Rate, KQKN)
                If KQKN = True Then
                    Lst.Tag = "2"
                    Lst.ImageIndex = 2
                    Lst.SubItems.Item(LTrangThai).Text = "Kết nối"
                    .TrangThai("2")
                    '  ManHinhChinh.T58real.OpenNetwork(7005)
                End If

            ElseIf TTMayCC.LoaiMay = 4 Then
                TaoMayF80(TTMayCC.MaMay, TTMayCC.Mayso, TTMayCC.KieuKN, TTMayCC.IP, TTMayCC.Cong, TTMayCC.Rate, KQKN)
                If KQKN = True Then
                    Lst.Tag = "2"
                    Lst.ImageIndex = 2
                    Lst.SubItems.Item(LTrangThai).Text = "Kết nối"
                    .TrangThai("2")
                End If

            ElseIf TTMayCC.LoaiMay = 5 Then
                TaoMayHanVon(TTMayCC.MaMay, TTMayCC.Mayso, TTMayCC.KieuKN, TTMayCC.IP, TTMayCC.Cong, TTMayCC.Rate, KQKN)
                If KQKN = True Then
                    Lst.Tag = "2"
                    Lst.ImageIndex = 2
                    Lst.SubItems.Item(LTrangThai).Text = "Kết nối"
                    .TrangThai("2")
                End If

            End If

            '    Next
            .ListView.Focus()
        End With

        If TTMayCC.LoaiMay = 1 And KQKN = True Then
            Dim ND1 As AxFK524PXNLib.AxFK524PXN = ManHinhChinh.Controls("May" & Lst.SubItems(LMayID).Text)
            My.Application.DoEvents()
            ND1.TabIndex = 1
        End If
    End Sub

    Private Sub TaoMayND(ByVal MaMay As Integer, ByVal MaySo As Integer, ByVal KieuKN As Integer, ByVal IP As String, ByVal Cong As Integer, ByVal Rate As Integer, ByRef KQKN As Boolean)

        Dim NDK1 As New AxFK524PXNLib.AxFK524PXN
        NDK1.Name = "May" & MaMay
        NDK1.TabIndex = 0
        AddHandler NDK1.TabIndexChanged, AddressOf NDOnLine
        ManHinhChinh.Controls.Add(NDK1)
        Application.DoEvents()
        KQKN = KetnoiND(ManHinhChinh.Controls(NDK1.Name), MaySo, KieuKN, IP, Cong, Rate)

    End Sub

    Private Sub TaoMayT58(ByVal MaMay As Integer, ByVal MaySo As Integer, ByVal KieuKN As Integer, ByVal IP As String, ByVal Cong As Integer, ByVal Rate As Integer, ByRef KQKN As Boolean)

        Dim T58 As New AxFKAttendLib.AxFKAttend
        T58.Name = "May" & MaMay

        ManHinhChinh.Controls.Add(T58)
        Application.DoEvents()
        KQKN = KetnoiT58(ManHinhChinh.Controls(T58.Name), MaySo, KieuKN, IP, Cong, Rate)

    End Sub

    Private Sub mF80_OnReceiveEvent(ByVal sender As Object, ByVal e As AxSB100BPCLib._DSB100BPCEvents_OnReceiveEventEvent)

        ' If e.evType = 3 Then MsgBox(e.evData)

        If e.evData = 0 Then Exit Sub


        With ManHinhChinh
            STT = .ListView1.Items.Count
            DTONV = BusNV.LayBangDTo(e.evData)

            '       MsgBox(DTONV.TenNV)

            Dim lvt2 As ListViewItem = .ListView1.Items.Add(STT + 1)
            '.ListView1.Items.AddRange(lvt2)
            '.ListView1.Items.AddRange(lis
            'lvt2.SubItems.AddRange(New String() {STT + 1, 111, DTONV.TenNV, "llll", "Vao", 1})
            lvt2.SubItems.AddRange(New String() {STT + 1, e.evData, DTONV.TenNV, "llll", "Vao", 1})
             
            Exit Sub

            .PHinh.ImageLocation = DTONV.Hinh
            .LbMa.Text = DTONV.NVSP
            .LbTen.Text = DTONV.TenNV

        End With

    End Sub

    Private Sub TaoMayF80(ByVal MaMay As Integer, ByVal MaySo As Integer, ByVal KieuKN As Integer, ByVal IP As String, ByVal Cong As Integer, ByVal Rate As Integer, ByRef KQKN As Boolean)

        Dim mF80 As New AxSB100BPCLib.AxSB100BPC
        mF80.Name = "May" & MaMay
        AddHandler mF80.OnReceiveEvent, AddressOf mF80_OnReceiveEvent
        ManHinhChinh.Controls.Add(mF80)
        Application.DoEvents()
        KQKN = KetnoiF80(ManHinhChinh.Controls(mF80.Name), MaySo, KieuKN, IP, Cong, Rate)
        If KQKN = True Then
            ' Dim ipa As String = ""
            'ipa = New System.Net.IPAddress(System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName).AddressList(0).Address).ToString
            mF80.StartEventCapture_EXT(ChuyenIPtoLong(IP))
        End If

        ManHinhChinh.ListView1.Items.Clear()

    End Sub

    Private Sub TaoMayHanVon(ByVal MaMay As Integer, ByVal MaySo As Integer, ByVal KieuKN As Integer, ByVal IP As String, ByVal Cong As Integer, ByVal Rate As Integer, ByRef KQKN As Boolean)

        Dim HanVon As New AxMr_Lam_HV.Axusr_MrLam_HV
        HanVon.Name = "May" & MaMay

        ManHinhChinh.Controls.Add(HanVon)
        Application.DoEvents()
        KQKN = KetNoiHanVon(ManHinhChinh.Controls(HanVon.Name), MaySo, KieuKN, IP, Cong, Rate)

    End Sub

    Private Sub TaoMayZK(ByVal MaMay As Integer, ByVal MaySo As Integer, ByVal KieuKN As Integer, ByVal IP As String, ByVal Cong As Integer, ByVal Rate As Integer, ByRef KQKN As Boolean)
        Dim Zkem1 As New Axzkemkeeper.AxCZKEM

        Zkem1.Name = "May" & MaMay

        AddHandler Zkem1.OnAttTransaction, AddressOf ZKEMT_OnAttTransaction
        ManHinhChinh.Controls.Add(Zkem1)
        Application.DoEvents()
        KQKN = KetNoiZK(ManHinhChinh.Controls(Zkem1.Name), MaySo, KieuKN, IP, Cong, Rate)

    End Sub


    Private Sub ZKEMT_OnAttTransaction(ByVal sender As System.Object, ByVal e As Axzkemkeeper._IZKEMEvents_OnAttTransactionEvent)


        With ManHinhChinh
            STT = .ListView1.Items.Count
            lvt = .ListView1.Items.Add(STT + 1)

            DTONV = BusNV.LayBangDTo(e.enrollNumber)

            lvt.SubItems.AddRange(New String() {e.enrollNumber, DTONV.TenNV, _
                DateSerial(e.year, e.month, e.day) & " " & TimeSerial(e.hour, e.minute, e.second), _
                IIf(e.attState = 0, "Vào", "Ra"), 1})
            .PHinh.ImageLocation = DTONV.Hinh
            .LbMa.Text = DTONV.NVSP
            .LbTen.Text = DTONV.TenNV

        End With
    End Sub

    Public Sub NgatKNZK()
        With ManHinhChinh

            If .ListView.SelectedItems.Count <= 0 Then
                MsgBox("Bạn Chưa Chọn Máy Chấm Công", MsgBoxStyle.Information, "Thông Báo")
                Exit Sub
            End If
            .TrangThai("3")
            '  For i As Integer = 0 To .ListView.SelectedItems.Count - 1
            Dim lst As ListViewItem = .ListView.SelectedItems(0)
            If lst.Tag = "2" Then
                lst.Tag = "3"
                lst.ImageIndex = 3
                lst.SubItems.Item(2).Text = "Ngắt kết nối"
                Application.DoEvents()
                If lst.SubItems(LLoaiMay).Text = 1 Then
                    Dim NDK1 As AxFK524PXNLib.AxFK524PXN = .Controls("May" & lst.SubItems(LMayID).Text)
                    NDK1.GetGLogDataOnlineEnd(lst.SubItems(LMaySo).Text)
                    NDK1.EnableDevice(lst.SubItems(LMaySo).Text, True)
                    NDK1.CloseCommPort()
                ElseIf lst.SubItems(LLoaiMay).Text = 2 Then
                    Dim Zkem1 As Axzkemkeeper.AxCZKEM = .Controls("May" & lst.SubItems(LMayID).Text)
                    Zkem1.Disconnect()
                ElseIf lst.SubItems(LLoaiMay).Text = 3 Then
                    Dim T58 As AxFKAttendLib.AxFKAttend = .Controls("May" & lst.SubItems(LMayID).Text)
                    T58.DisConnect()
                ElseIf lst.SubItems(LLoaiMay).Text = 4 Then
                    Dim mF80 As AxSB100BPCLib.AxSB100BPC = .Controls("May" & lst.SubItems(LMayID).Text)
                    mF80.StopEventCapture_EXT()
                    mF80.Disconnect()

                End If

                MsgBox("Bạn đã ngắt kết nối của máy " & lst.SubItems(LTenMay).Text, MsgBoxStyle.Information, "Thông báo")
                Try
                    .Controls.RemoveByKey("May" & lst.SubItems(LMayID).Text)
                Catch ex As Exception

                End Try

            End If
            ' Next
            .ListView.Focus()

        End With

    End Sub

    Public Function TaoCSMay(ByRef ManHinhMay As ListView) As Boolean

        Dim lvItem As ListViewItem
        ManHinhMay.Items.Clear()
        ManHinhMay.MultiSelect = False
        Dim kt As Integer = 0
        For i As Integer = 0 To ManHinhChinh.ListView.Items.Count - 1
            If ManHinhChinh.ListView.Items(i).Tag = "2" Then
                lvItem = ManHinhMay.Items.Add(ManHinhChinh.ListView.Items(i).SubItems(LTenMay).Text)
                lvItem.ImageIndex = ManHinhChinh.ListView.Items(i).ImageIndex
                lvItem.SubItems.AddRange(New String() {ManHinhChinh.ListView.Items(i).SubItems(LViTri).Text, _
                            ManHinhChinh.ListView.Items(i).SubItems(LMayID).Text, _
                            ManHinhChinh.ListView.Items(i).SubItems(LMaySo).Text, ManHinhChinh.ListView.Items(i).SubItems(LLoaiMay).Text})
                lvItem.Tag = ManHinhChinh.ListView.Items(i).Tag
                kt = 1
            End If
        Next
        If kt = 0 Then
            MsgBox("Chưa có máy kết nối", MsgBoxStyle.Critical, "Thông báo")
            TaoCSMay = False
        Else
            TaoCSMay = True
        End If

    End Function

    Private Sub NDOnLine(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ND As AxFK524PXNLib.AxFK524PXN = sender
        Dim MaySo As Integer = 1
        Dim MaMay = Right(ND.Name, Strings.Len(ND.Name) - 3)
        ND.EnableDevice(MaySo, False)
        Dim KNN, Ghi As Boolean
        KNN = ND.GetGLogDataOnlineStart(MaySo)
        ND.EnableDevice(MaySo, True)
        Dim Enrol, Kieu, Vao, Nam, Thang, Ngay, Gio, Phut As Integer
        While KNN = True
            Application.DoEvents()
            Try
                Ghi = ND.GetGLogDataOnline(MaySo, Enrol, Kieu, Vao, Nam, Thang, Ngay, Gio, Phut)
                If Ghi = True Then
                    With ManHinhChinh
                        STT = .ListView1.Items.Count
                        lvt = .ListView1.Items.Add(STT + 1)
                        DTONV = BusNV.LayBangDTo(Enrol)
                        lvt.SubItems.AddRange(New String() {Enrol, DTONV.TenNV, _
                            DateSerial(Nam, Thang, Ngay) & " " & TimeSerial(Gio, Phut, 0), _
                            IIf(Vao = 0, "Vào", "Ra"), MaMay})
                        .PHinh.ImageLocation = DTONV.Hinh
                        .LbMa.Text = DTONV.NVSP
                        .LbTen.Text = DTONV.TenNV
                    End With
                End If
            Catch ex As Exception
                Exit While
            End Try
        End While
    End Sub

End Module
