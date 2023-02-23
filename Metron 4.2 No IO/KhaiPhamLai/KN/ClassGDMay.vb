Public Class ClassGDMay

    Dim BusTimNV As New nhanvienBus(DTOKetnoi, False)
    Dim BusVanTay As New nvvanBus(DTOKetnoi, False)
    Dim BusVaoRa As New VaoraBus(DTOKetnoi, False)
    Dim datanhanvien As New DataTable
    Dim array As New ArrayList
    Public hienThiTenNV As Boolean = True
    Public Sub New(Optional ByVal nhanvien As Boolean = True)
        If nhanvien Then datanhanvien = BusTimNV.LayBangTableso
    End Sub
    Private Function TimNVnhanh(ByVal manv As Integer) As nhanviendto
        Dim nv As New nhanviendto
        If array.Count > 0 Then
            For j As Integer = 0 To array.Count - 1
                If array.Item(j).Ma = manv Then Return BusTimNV.LayBangDTo(array.Item(j).dong, datanhanvien)
            Next
        End If
        For i As Integer = 0 To datanhanvien.Rows.Count - 1
            If datanhanvien.Rows(i)("MaNV") = manv Then
                Dim iDex As New index
                iDex.dong = i
                iDex.Ma = manv
                array.Add(iDex)
                Return BusTimNV.LayBangDTo(i, datanhanvien)
            End If
        Next
        Return nv
    End Function

#Region "Cac ham trong man hinh quan ly nhan vien tren may cham cong"

    Public Sub DocDLNV(ByVal ListV As ListView, ByRef dgvCo As DataGridView, ByRef dgvKo As DataGridView, ByVal pb As ProgressBar)
        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần kiểm tra thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        If ListV.SelectedItems(0).SubItems(LLoaiMay1).Text = 1 Then
            DocDLNVND(ListV, dgvCo, dgvKo, pb)
        ElseIf ListV.SelectedItems(0).SubItems(LLoaiMay1).Text = 2 Then
            DocDLNVZK(ListV, dgvCo, dgvKo, pb)
        ElseIf ListV.SelectedItems(0).SubItems(LLoaiMay1).Text = 3 Then
            DocDLNVT58(ListV, dgvCo, dgvKo, pb)

        ElseIf ListV.SelectedItems(0).SubItems(LLoaiMay1).Text = 4 Then
            DocDLNVF80(ListV, dgvCo, dgvKo, pb)

        ElseIf ListV.SelectedItems(0).SubItems(LLoaiMay1).Text = 5 Then
            DocDLNVHanVon(ListV, dgvCo, dgvKo, pb)

        End If
    End Sub

    Private Sub DocDLNVZK(ByVal ListV As ListView, ByRef dgvCo As DataGridView, ByRef dgvKo As DataGridView, ByVal pb As ProgressBar)
        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần kiểm tra thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        'If MsgBox("Bạn có chắc là muốn xóa hết quyền Quản Lý trên máy " & ListV.SelectedItems(0).SubItems(0).Text & " không?" _
        '    , MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Xoa quyen Quan Ly") = MsgBoxResult.No Then Exit Function
        Dim Zkem1 As Axzkemkeeper.AxCZKEM = ManHinhChinh.Controls("May" & ListV.SelectedItems(0).SubItems(2).Text)
        Dim MaNV, Quyen As Integer
        Dim SD As Boolean
        Dim Pas As String = ""
        Dim TenHT As String = ""
        pb.Value = 0
        Dim SttC As Integer = 0
        Dim STTK As Integer = 0
        Dim DTONhanVien As New nhanviendto
        dgvCo.Rows.Clear()
        dgvKo.Rows.Clear()
        Zkem1.EnableDevice(ListV.SelectedItems(0).SubItems(3).Text, False)
        Dim MaX1, Max2 As Integer
        Zkem1.GetDeviceStatus(ListV.SelectedItems(0).SubItems(3).Text, 1, MaX1)
        Zkem1.GetDeviceStatus(ListV.SelectedItems(0).SubItems(3).Text, 2, Max2)
        pb.Maximum = MaX1 + Max2 + 2
        Zkem1.ReadAllUserID(ListV.SelectedItems(0).SubItems(3).Text)
        While Zkem1.GetAllUserInfo(ListV.SelectedItems(0).SubItems(3).Text, MaNV, TenHT, Pas, Quyen, SD)
            If hienThiTenNV Then DTONhanVien = TimNVnhanh(MaNV)
            If Strings.Len(Strings.Trim(TenHT)) <= 0 Then TenHT = "NV " & MaNV
            Try
                Pas = Zkem1.get_CardNumber(0)
            Catch ex As Exception

            End Try

            If DTONhanVien.MaNV = 0 Then
                STTK += 1
                dgvKo.Rows.Add(0, STTK, MaNV, TenHT, Pas, Quyen)
            Else
                SttC += 1
                dgvCo.Rows.Add(0, SttC, MaNV, DTONhanVien.TenNV, TenHT, Pas, Quyen)
            End If
            TenHT = ""
            Pas = ""
            Try
                pb.Value += 1
            Catch ex As Exception
                pb.Value = 0
            End Try
        End While

        Zkem1.EnableDevice(ListV.SelectedItems(0).SubItems(3).Text, True)

        pb.Value = pb.Maximum
        MsgBox("Hoàn thành quá trình kiểm tra dữ liệu", MsgBoxStyle.Information, "Thông báo")

    End Sub

    Private Sub DocDLNVHanVon(ByVal ListV As ListView, ByRef dgvCo As DataGridView, ByRef dgvKo As DataGridView, ByVal pb As ProgressBar)
        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần kiểm tra thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If

        Dim HanVon As AxMr_Lam_HV.Axusr_MrLam_HV = ManHinhChinh.Controls("May" & ListV.SelectedItems(0).SubItems(2).Text)
        Dim MaNV As Integer
        Dim TenHT As String = ""
        pb.Value = 0
        Dim SttC As Integer = 0
        Dim STTK As Integer = 0
        Dim DTONhanVien As New nhanviendto
        dgvCo.Rows.Clear()
        dgvKo.Rows.Clear()


        pb.Value = 0
        Dim DLNhanVien As String = HanVon.DocDuLieuNhanVien()
        DLNhanVien = Strings.Mid(DLNhanVien, 6)
        DLNhanVien = Strings.Trim(DLNhanVien)
        Dim ArrNhanVien() As String = Strings.Split(DLNhanVien, """")

        pb.Maximum = ArrNhanVien(1)

        For i As Integer = 3 To ArrNhanVien.Length - 1 Step 2

            MaNV = ArrNhanVien(i)

            If hienThiTenNV Then DTONhanVien = TimNVnhanh(MaNV)
            TenHT = "NV " & MaNV

            If DTONhanVien.MaNV = 0 Then
                STTK += 1
                dgvKo.Rows.Add(0, STTK, MaNV, TenHT, 0, 0)
            Else
                SttC += 1
                dgvCo.Rows.Add(0, SttC, MaNV, DTONhanVien.TenNV, TenHT, 0, 0)
            End If

            Try
                pb.Value += 1
            Catch ex As Exception
                pb.Value = 0
            End Try
        Next

        pb.Value = 0
        MsgBox("Hoàn thành quá trình kiểm tra dữ liệu", MsgBoxStyle.Information, "Thông báo")

    End Sub

    Private Sub DocDLNVND(ByVal ListV As ListView, ByRef dgvCo As DataGridView, ByRef dgvKo As DataGridView, ByVal pb As ProgressBar)
        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần kiểm tra thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If

        Dim NDK1 As AxFK524PXNLib.AxFK524PXN = ManHinhChinh.Controls("May" & ListV.SelectedItems(0).SubItems(LMayID1).Text)
        Dim MaNV, Kieu, Quyen As Integer

        Dim SD As Boolean
        Dim Pas As String = ""
        Dim TenHT As String = ""

        pb.Value = 0

        Dim SttC As Integer = 0
        Dim STTK As Integer = 0
        Dim DTONhanVien As New nhanviendto

        dgvCo.Rows.Clear()
        dgvKo.Rows.Clear()

        NDK1.EnableDevice(ListV.SelectedItems(0).SubItems(LMaySo1).Text, False)
        Dim MaX1, Max2 As Integer
        NDK1.GetDeviceStatus(ListV.SelectedItems(0).SubItems(LMaySo1).Text, 1, MaX1)
        NDK1.GetDeviceStatus(ListV.SelectedItems(0).SubItems(LMaySo1).Text, 2, Max2)
        pb.Maximum = MaX1 + Max2 + 2

        NDK1.ReadAllUserID(ListV.SelectedItems(0).SubItems(LMaySo1).Text)

        While NDK1.GetAllUserID(ListV.SelectedItems(0).SubItems(LMaySo1).Text, MaNV, Kieu, Quyen, SD)
            NDK1.GetUserName(ListV.SelectedItems(0).SubItems(LMaySo1).Text, MaNV, TenHT)
            If Strings.Len(Strings.Trim(TenHT)) <= 0 Then TenHT = "NV " & MaNV

            If hienThiTenNV Then DTONhanVien = TimNVnhanh(MaNV)
            If DTONhanVien.MaNV = 0 Then
                STTK += 1
                dgvKo.Rows.Add(0, STTK, MaNV, TenHT, Kieu, Quyen)
            Else
                SttC += 1
                dgvCo.Rows.Add(0, SttC, MaNV, DTONhanVien.TenNV, TenHT, Kieu, Quyen)
            End If
            TenHT = ""
            Pas = ""
            Try
                pb.Value += 1
            Catch ex As Exception
                pb.Value = 0
            End Try
        End While

        NDK1.EnableDevice(ListV.SelectedItems(0).SubItems(LMaySo1).Text, True)

        pb.Value = pb.Maximum
        MsgBox("Hoàn thành quá trình kiểm tra dữ liệu", MsgBoxStyle.Information, "Thông báo")

    End Sub


    Private Sub DocDLNVF80(ByVal ListV As ListView, ByRef dgvCo As DataGridView, ByRef dgvKo As DataGridView, ByVal pb As ProgressBar)
        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần kiểm tra thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If


        Dim mF80 As AxSB100BPCLib.AxSB100BPC = ManHinhChinh.Controls("May" & ListV.SelectedItems(0).SubItems(LMayID1).Text)
        Dim MaNV, Kieu, Quyen As Integer

        Dim SD As Boolean
        Dim Pas As String = ""
        Dim TenHT As String = ""

        pb.Value = 0

        Dim SttC As Integer = 0
        Dim STTK As Integer = 0
        Dim DTONhanVien As New nhanviendto

        dgvCo.Rows.Clear()
        dgvKo.Rows.Clear()

        mF80.EnableDevice(ListV.SelectedItems(0).SubItems(LMaySo1).Text, False)
        Dim MaX1, Max2 As Integer
        mF80.GetDeviceStatus(ListV.SelectedItems(0).SubItems(LMaySo1).Text, 1, MaX1)
        mF80.GetDeviceStatus(ListV.SelectedItems(0).SubItems(LMaySo1).Text, 2, Max2)
        pb.Maximum = MaX1 + Max2 + 2


        mF80.ReadAllUserID(ListV.SelectedItems(0).SubItems(LMaySo1).Text)

        Dim VMay As Integer = 1
        While mF80.GetAllUserID(ListV.SelectedItems(0).SubItems(LMaySo1).Text, MaNV, VMay, Kieu, Quyen, SD)
            mF80.GetUserName1(ListV.SelectedItems(0).SubItems(LMaySo1).Text, MaNV, TenHT)

            If Strings.Len(Strings.Trim(TenHT)) <= 0 Then TenHT = "NV " & MaNV

            If hienThiTenNV Then DTONhanVien = TimNVnhanh(MaNV)
            If DTONhanVien.MaNV = 0 Then
                STTK += 1
                dgvKo.Rows.Add(0, STTK, MaNV, TenHT, Kieu, Quyen)
            Else
                SttC += 1
                dgvCo.Rows.Add(0, SttC, MaNV, DTONhanVien.TenNV, TenHT, Kieu, Quyen)
            End If
            TenHT = ""
            Pas = ""
            Try
                pb.Value += 1
            Catch ex As Exception
                pb.Value = 0
            End Try
        End While

        mF80.EnableDevice(ListV.SelectedItems(0).SubItems(LMaySo1).Text, True)

        pb.Value = pb.Maximum
        MsgBox("Hoàn thành quá trình kiểm tra dữ liệu", MsgBoxStyle.Information, "Thông báo")

    End Sub

    Private Sub DocDLNVT58(ByVal ListV As ListView, ByRef dgvCo As DataGridView, ByRef dgvKo As DataGridView, ByVal pb As ProgressBar)
        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần kiểm tra thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If


        Dim T58 As AxFKAttendLib.AxFKAttend = ManHinhChinh.Controls("May" & ListV.SelectedItems(0).SubItems(LMayID1).Text)
        Dim MaNV, Kieu, Quyen As Integer

        Dim SD As Boolean
        Dim Pas As String = ""
        Dim TenHT As String = ""

        pb.Value = 0

        Dim SttC As Integer = 0
        Dim STTK As Integer = 0
        Dim DTONhanVien As New nhanviendto

        dgvCo.Rows.Clear()
        dgvKo.Rows.Clear()


        T58.EnableDevice(False)
        Dim MaX1, Max2 As Integer
        T58.GetDeviceStatus(3, MaX1)
        T58.GetDeviceStatus(9, Max2)
        pb.Maximum = MaX1 + Max2 + 2

        T58.ReadAllUserID()

        While True
            Dim kq As Integer = T58.GetAllUserID(MaNV, Kieu, Quyen, SD)
            If kq <= 0 Then Exit While
            T58.GetUserName(MaNV, TenHT)
            If Strings.Len(Strings.Trim(TenHT)) <= 0 Then TenHT = "NV " & MaNV

            If hienThiTenNV Then DTONhanVien = TimNVnhanh(MaNV)
            If DTONhanVien.MaNV = 0 Then
                STTK += 1
                dgvKo.Rows.Add(0, STTK, MaNV, TenHT, Kieu, Quyen)
            Else
                SttC += 1
                dgvCo.Rows.Add(0, SttC, MaNV, DTONhanVien.TenNV, TenHT, Kieu, Quyen)
            End If
            TenHT = ""
            Pas = ""
            Try
                pb.Value += 1
            Catch ex As Exception
                pb.Value = 0
            End Try
        End While

        T58.EnableDevice(True)

        pb.Value = 0
        MsgBox("Hoàn thành quá trình kiểm tra dữ liệu", MsgBoxStyle.Information, "Thông báo")

    End Sub


    Public Sub UpdateNV(ByVal dgvCo As DataGridView, ByVal ListV As ListView, ByVal TaiVan As Boolean, ByVal PB As ProgressBar)
        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần kiểm tra thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        If ListV.SelectedItems(0).SubItems(LLoaiMay1).Text = 1 Then
            UpDateNVND(dgvCo, ListV, TaiVan, PB)
        ElseIf ListV.SelectedItems(0).SubItems(LLoaiMay1).Text = 2 Then
            UpDateNVZK(dgvCo, ListV, TaiVan, PB)
        ElseIf ListV.SelectedItems(0).SubItems(LLoaiMay1).Text = 3 Then
            UpDateNVT58(dgvCo, ListV, TaiVan, PB)

        ElseIf ListV.SelectedItems(0).SubItems(LLoaiMay1).Text = 4 Then
            UpDateNVF80(dgvCo, ListV, TaiVan, PB)
        ElseIf ListV.SelectedItems(0).SubItems(LLoaiMay1).Text = 5 Then
            UpDateNVHanVon(dgvCo, ListV, TaiVan, PB)
        End If

    End Sub
    Private Sub UpDateNVZK(ByVal dgvCo As DataGridView, ByVal ListV As ListView, ByVal TaiVan As Boolean, ByVal PB As ProgressBar)

        Dim DTOVanTay As New nvvandto

        PB.Value = 0
        PB.Maximum = dgvCo.RowCount + 1

        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần kiểm tra thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If

        Dim Zkem1 As Axzkemkeeper.AxCZKEM = ManHinhChinh.Controls("May" & ListV.SelectedItems(0).SubItems(2).Text)
        Zkem1.EnableDevice(ListV.SelectedItems(0).SubItems(3).Text, False)
        Zkem1.ReadAllTemplate(ListV.SelectedItems(0).SubItems(3).Text)
        For i As Integer = 0 To dgvCo.Rows.Count - 1
            If dgvCo.Item("Chon1", i).Value = 1 Or dgvCo.Item("Chon1", i).Value = True Then

                BusTimNV.upDateTTMay(dgvCo.Item("Quyen1", i).Value, dgvCo.Item("TenHT1", i).Value.ToString, dgvCo.Item("MaThe1", i).Value, dgvCo.Item("MaCC1", i).Value)
                If TaiVan = True Then
                    TaiDauVTZK(Zkem1, DTOVanTay, ListV.SelectedItems(0).SubItems(3).Text, dgvCo.Item("MaCC1", i).Value)
                End If
            End If

            Try
                PB.Value += 1
            Catch ex As Exception
                PB.Value = 0
            End Try
        Next
        PB.Value = PB.Maximum
        Zkem1.EnableDevice(ListV.SelectedItems(0).SubItems(3).Text, True)
        MsgBox("Hoàn thành quá trình tải dữ liệu!", MsgBoxStyle.Information, "Thông báo")

    End Sub


    Private Sub UpDateNVHanVon(ByVal dgvCo As DataGridView, ByVal ListV As ListView, ByVal TaiVan As Boolean, ByVal PB As ProgressBar)

        Dim DTOVanTay As New nvvandto

        PB.Value = 0
        PB.Maximum = dgvCo.RowCount + 1

        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần kiểm tra thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If

        Dim HanVon As AxMr_Lam_HV.Axusr_MrLam_HV = ManHinhChinh.Controls("May" & ListV.SelectedItems(0).SubItems(2).Text)

        For i As Integer = 0 To dgvCo.Rows.Count - 1
            If dgvCo.Item("Chon1", i).Value = 1 Or dgvCo.Item("Chon1", i).Value = True Then

                BusTimNV.upDateTTMay(dgvCo.Item("Quyen1", i).Value, dgvCo.Item("TenHT1", i).Value.ToString, dgvCo.Item("MaThe1", i).Value, dgvCo.Item("MaCC1", i).Value)
                If TaiVan = True Then
                    TaiFaceHanVon(HanVon, DTOVanTay, dgvCo.Item("MaCC1", i).Value)
                End If
            End If

            Try
                PB.Value += 1
            Catch ex As Exception
                PB.Value = 0
            End Try
        Next
        PB.Value = PB.Maximum

        MsgBox("Hoàn thành quá trình tải dữ liệu!", MsgBoxStyle.Information, "Thông báo")

    End Sub





    Private Sub UpDateNVND(ByVal dgvCo As DataGridView, ByVal ListV As ListView, ByVal TaiVan As Boolean, ByVal PB As ProgressBar)
        Dim DTOVanTay As New nvvandto

        PB.Value = 0
        PB.Maximum = dgvCo.RowCount + 1

        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần kiểm tra thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If

        Dim NDK1 As AxFK524PXNLib.AxFK524PXN = ManHinhChinh.Controls("May" & ListV.SelectedItems(0).SubItems(LMayID1).Text)
        NDK1.EnableDevice(ListV.SelectedItems(0).SubItems(3).Text, False)
        For i As Integer = 0 To dgvCo.Rows.Count - 1
            If dgvCo.Item("Chon1", i).Value = 1 Or dgvCo.Item("Chon1", i).Value = True Then
                If TaiVan = True Then
                    TaiDauVTND(NDK1, DTOVanTay, ListV.SelectedItems(0).SubItems(LMaySo1).Text, dgvCo.Item("MaCC1", i).Value, dgvCo.Item("MaThe1", i).Value)
                End If
                BusTimNV.upDateTTMay(dgvCo.Item("Quyen1", i).Value, dgvCo.Item("TenHT1", i).Value.ToString, dgvCo.Item("MaThe1", i).Value, dgvCo.Item("MaCC1", i).Value)
            End If
            Try
                PB.Value += 1
            Catch ex As Exception
                PB.Value = 0
            End Try
        Next
        PB.Value = PB.Maximum
        NDK1.EnableDevice(ListV.SelectedItems(0).SubItems(LMaySo1).Text, True)
        MsgBox("Hoàn thành quá trình tải dữ liệu!", MsgBoxStyle.Information, "Thông báo")

    End Sub

    Private Sub UpDateNVF80(ByVal dgvCo As DataGridView, ByVal ListV As ListView, ByVal TaiVan As Boolean, ByVal PB As ProgressBar)
        Dim DTOVanTay As New nvvandto

        PB.Value = 0
        PB.Maximum = dgvCo.RowCount + 1

        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần kiểm tra thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If

        Dim mF80 As AxSB100BPCLib.AxSB100BPC = ManHinhChinh.Controls("May" & ListV.SelectedItems(0).SubItems(LMayID1).Text)
        mF80.EnableDevice(ListV.SelectedItems(0).SubItems(3).Text, False)
        For i As Integer = 0 To dgvCo.Rows.Count - 1
            If dgvCo.Item("Chon1", i).Value = 1 Or dgvCo.Item("Chon1", i).Value = True Then
                If TaiVan = True Then
                    TaiDauVTF80(mF80, DTOVanTay, ListV.SelectedItems(0).SubItems(LMaySo1).Text, dgvCo.Item("MaCC1", i).Value, dgvCo.Item("MaThe1", i).Value)
                End If
                BusTimNV.upDateTTMay(dgvCo.Item("Quyen1", i).Value, dgvCo.Item("TenHT1", i).Value.ToString, dgvCo.Item("MaThe1", i).Value, dgvCo.Item("MaCC1", i).Value)
            End If
            Try
                PB.Value += 1
            Catch ex As Exception
                PB.Value = 0
            End Try
        Next
        PB.Value = PB.Maximum
        mF80.EnableDevice(ListV.SelectedItems(0).SubItems(LMaySo1).Text, True)
        MsgBox("Hoàn thành quá trình tải dữ liệu!", MsgBoxStyle.Information, "Thông báo")

    End Sub


    Private Sub UpDateNVT58(ByVal dgvCo As DataGridView, ByVal ListV As ListView, ByVal TaiVan As Boolean, ByVal PB As ProgressBar)
        Dim DTOVanTay As New nvvandto

        PB.Value = 0
        PB.Maximum = dgvCo.RowCount + 1

        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần kiểm tra thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If

        Dim T58 As AxFKAttendLib.AxFKAttend = ManHinhChinh.Controls("May" & ListV.SelectedItems(0).SubItems(LMayID1).Text)
        T58.EnableDevice(False)
        For i As Integer = 0 To dgvCo.Rows.Count - 1
            If dgvCo.Item("Chon1", i).Value = 1 Or dgvCo.Item("Chon1", i).Value = True Then
                If TaiVan = True Then
                    TaiDauVTT58(T58, DTOVanTay, ListV.SelectedItems(0).SubItems(LMaySo1).Text, dgvCo.Item("MaCC1", i).Value, dgvCo.Item("MaThe1", i).Value)
                End If
                BusTimNV.upDateTTMay(dgvCo.Item("Quyen1", i).Value, dgvCo.Item("TenHT1", i).Value.ToString, dgvCo.Item("MaThe1", i).Value, dgvCo.Item("MaCC1", i).Value)
            End If
            Try
                PB.Value += 1
            Catch ex As Exception
                PB.Value = 0
            End Try
        Next
        PB.Value = 0
        T58.EnableDevice(True)
        MsgBox("Hoàn thành quá trình tải dữ liệu!", MsgBoxStyle.Information, "Thông báo")

    End Sub


    Public Sub ThemNVMay(ByVal dgvKo As DataGridView, ByVal ListV As ListView, ByVal TaiVan As Boolean, ByVal PB As ProgressBar)

        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần kiểm tra thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If

        If ListV.SelectedItems(0).SubItems(LLoaiMay1).Text = 1 Then
            ThemNVMayND(dgvKo, ListV, TaiVan, PB)
        ElseIf ListV.SelectedItems(0).SubItems(LLoaiMay1).Text = 2 Then
            ThemNVMayZK(dgvKo, ListV, TaiVan, PB)
        ElseIf ListV.SelectedItems(0).SubItems(LLoaiMay1).Text = 3 Then
            ThemNVMayT58(dgvKo, ListV, TaiVan, PB)

        ElseIf ListV.SelectedItems(0).SubItems(LLoaiMay1).Text = 4 Then
            ThemNVMayF80(dgvKo, ListV, TaiVan, PB)

        ElseIf ListV.SelectedItems(0).SubItems(LLoaiMay1).Text = 5 Then
            ThemNVMayHanVon(dgvKo, ListV, TaiVan, PB)

        End If
    End Sub
    Private Sub ThemNVMayZK(ByVal dgvKo As DataGridView, ByVal ListV As ListView, ByVal TaiVan As Boolean, ByVal PB As ProgressBar)
        Dim DTOVanTay As New nvvandto

        PB.Value = 0
        PB.Maximum = dgvKo.RowCount + 1

        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần kiểm tra thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        Dim Zkem1 As Axzkemkeeper.AxCZKEM = ManHinhChinh.Controls("May" & ListV.SelectedItems(0).SubItems(2).Text)
        Zkem1.EnableDevice(ListV.SelectedItems(0).SubItems(3).Text, False)
        Zkem1.ReadAllTemplate(ListV.SelectedItems(0).SubItems(3).Text)
        For i As Integer = 0 To dgvKo.Rows.Count - 1
            If dgvKo.Item("Chon2", i).Value = 1 Or dgvKo.Item("Chon2", i).Value = True Then
                BusTimNV.ThemTTNV(dgvKo.Item("MaCC2", i).Value, dgvKo.Item("TenHT2", i).Value, dgvKo.Item("MaThe2", i).Value, dgvKo.Item("Quyen2", i).Value)
                If TaiVan = True Then
                    TaiDauVTZK(Zkem1, DTOVanTay, ListV.SelectedItems(0).SubItems(3).Text, dgvKo.Item("MaCC2", i).Value)
                End If
            End If
            Try
                PB.Value += 1
            Catch ex As Exception
                PB.Value = 0
            End Try
        Next
        PB.Value = PB.Maximum
        Zkem1.EnableDevice(ListV.SelectedItems(0).SubItems(3).Text, True)
        MsgBox("Hoàn thành quá trình tải dữ liệu!", MsgBoxStyle.Information, "Thông báo")
    End Sub


    Private Sub ThemNVMayHanVon(ByVal dgvKo As DataGridView, ByVal ListV As ListView, ByVal TaiVan As Boolean, ByVal PB As ProgressBar)
        Dim DTOVanTay As New nvvandto

        PB.Value = 0
        PB.Maximum = dgvKo.RowCount + 1

        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần kiểm tra thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        Dim HanVon As AxMr_Lam_HV.Axusr_MrLam_HV = ManHinhChinh.Controls("May" & ListV.SelectedItems(0).SubItems(2).Text)

        For i As Integer = 0 To dgvKo.Rows.Count - 1
            If dgvKo.Item("Chon2", i).Value = 1 Or dgvKo.Item("Chon2", i).Value = True Then
                BusTimNV.ThemTTNV(dgvKo.Item("MaCC2", i).Value, dgvKo.Item("TenHT2", i).Value, dgvKo.Item("MaThe2", i).Value, dgvKo.Item("Quyen2", i).Value)
                If TaiVan = True Then
                    TaiFaceHanVon(HanVon, DTOVanTay, dgvKo.Item("MaCC2", i).Value)
                End If
            End If
            Try
                PB.Value += 1
            Catch ex As Exception
                PB.Value = 0
            End Try
        Next
        PB.Value = PB.Maximum

        MsgBox("Hoàn thành quá trình tải dữ liệu!", MsgBoxStyle.Information, "Thông báo")
    End Sub


    Private Sub ThemNVMayND(ByVal dgvKo As DataGridView, ByVal ListV As ListView, ByVal TaiVan As Boolean, ByVal PB As ProgressBar)
        Dim DTOVanTay As New nvvandto

        PB.Value = 0
        PB.Maximum = dgvKo.RowCount + 1

        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần kiểm tra thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If

        Dim NDK1 As AxFK524PXNLib.AxFK524PXN = ManHinhChinh.Controls("May" & ListV.SelectedItems(0).SubItems(LMayID1).Text)
        NDK1.EnableDevice(ListV.SelectedItems(0).SubItems(LMaySo1).Text, False)

        For i As Integer = 0 To dgvKo.Rows.Count - 1
            If dgvKo.Item("Chon2", i).Value = 1 Or dgvKo.Item("Chon2", i).Value = True Then
                If TaiVan = True Then
                    TaiDauVTND(NDK1, DTOVanTay, ListV.SelectedItems(0).SubItems(3).Text, dgvKo.Item("MaCC2", i).Value, dgvKo.Item("MaThe2", i).Value)
                End If
                BusTimNV.ThemTTNV(dgvKo.Item("MaCC2", i).Value, dgvKo.Item("TenHT2", i).Value, dgvKo.Item("MaThe2", i).Value, dgvKo.Item("Quyen2", i).Value)

            End If

            Try
                PB.Value += 1
            Catch ex As Exception
                PB.Value = 0
            End Try
        Next
        PB.Value = PB.Maximum
        NDK1.EnableDevice(ListV.SelectedItems(0).SubItems(3).Text, True)
        MsgBox("Hoàn thành quá trình tải dữ liệu!", MsgBoxStyle.Information, "Thông báo")

    End Sub

    Private Sub ThemNVMayF80(ByVal dgvKo As DataGridView, ByVal ListV As ListView, ByVal TaiVan As Boolean, ByVal PB As ProgressBar)
        Dim DTOVanTay As New nvvandto

        PB.Value = 0
        PB.Maximum = dgvKo.RowCount + 1

        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần kiểm tra thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If

        Dim mF80 As AxSB100BPCLib.AxSB100BPC = ManHinhChinh.Controls("May" & ListV.SelectedItems(0).SubItems(LMayID1).Text)
        mF80.EnableDevice(ListV.SelectedItems(0).SubItems(LMaySo1).Text, False)

        For i As Integer = 0 To dgvKo.Rows.Count - 1
            If dgvKo.Item("Chon2", i).Value = 1 Or dgvKo.Item("Chon2", i).Value = True Then
                If TaiVan = True Then
                    TaiDauVTF80(mF80, DTOVanTay, ListV.SelectedItems(0).SubItems(3).Text, dgvKo.Item("MaCC2", i).Value, dgvKo.Item("MaThe2", i).Value)
                End If
                BusTimNV.ThemTTNV(dgvKo.Item("MaCC2", i).Value, dgvKo.Item("TenHT2", i).Value, dgvKo.Item("MaThe2", i).Value, dgvKo.Item("Quyen2", i).Value)

            End If

            Try
                PB.Value += 1
            Catch ex As Exception
                PB.Value = 0
            End Try
        Next
        PB.Value = PB.Maximum
        mF80.EnableDevice(ListV.SelectedItems(0).SubItems(3).Text, True)
        MsgBox("Hoàn thành quá trình tải dữ liệu!", MsgBoxStyle.Information, "Thông báo")

    End Sub


    Private Sub ThemNVMayT58(ByVal dgvKo As DataGridView, ByVal ListV As ListView, ByVal TaiVan As Boolean, ByVal PB As ProgressBar)
        Dim DTOVanTay As New nvvandto

        PB.Value = 0
        PB.Maximum = dgvKo.RowCount + 1

        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần kiểm tra thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If

        Dim T58 As AxFKAttendLib.AxFKAttend = ManHinhChinh.Controls("May" & ListV.SelectedItems(0).SubItems(LMayID1).Text)
        T58.EnableDevice(False)

        For i As Integer = 0 To dgvKo.Rows.Count - 1
            If dgvKo.Item("Chon2", i).Value = 1 Or dgvKo.Item("Chon2", i).Value = True Then
                If TaiVan = True Then
                    TaiDauVTT58(T58, DTOVanTay, ListV.SelectedItems(0).SubItems(3).Text, dgvKo.Item("MaCC2", i).Value, dgvKo.Item("MaThe2", i).Value)
                End If
                BusTimNV.ThemTTNV(dgvKo.Item("MaCC2", i).Value, dgvKo.Item("TenHT2", i).Value, dgvKo.Item("MaThe2", i).Value, dgvKo.Item("Quyen2", i).Value)

            End If

            Try
                PB.Value += 1
            Catch ex As Exception
                PB.Value = 0
            End Try
        Next
        PB.Value = 0
        T58.EnableDevice(True)
        MsgBox("Hoàn thành quá trình tải dữ liệu!", MsgBoxStyle.Information, "Thông báo")

    End Sub

    Public Sub XoaDLKo(ByVal ListV As ListView, ByVal dgvKo As DataGridView, ByVal XoaVtay As Boolean, ByVal Pb As ProgressBar)

        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần xóa thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If

        If ListV.SelectedItems(0).SubItems(LLoaiMay1).Text = 1 Then
            XoaDLKoND(ListV, dgvKo, XoaVtay, Pb)
        ElseIf ListV.SelectedItems(0).SubItems(LLoaiMay1).Text = 2 Then
            XoaDLKoZK(ListV, dgvKo, XoaVtay, Pb)
        ElseIf ListV.SelectedItems(0).SubItems(LLoaiMay1).Text = 3 Then
            XoaDLKoT58(ListV, dgvKo, XoaVtay, Pb)
        ElseIf ListV.SelectedItems(0).SubItems(LLoaiMay1).Text = 4 Then
            XoaDLKoF80(ListV, dgvKo, XoaVtay, Pb)
        ElseIf ListV.SelectedItems(0).SubItems(LLoaiMay1).Text = 5 Then
            XoaDLKoHanVon(ListV, dgvKo, XoaVtay, Pb)
        End If
    End Sub
    Private Sub XoaDLKoZK(ByVal ListV As ListView, ByVal dgvKo As DataGridView, ByVal XoaVtay As Boolean, ByVal Pb As ProgressBar)

        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần xóa thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        If MsgBox("Bạn có chắc là muốn xóa những nhân viên này trên máy " & ListV.SelectedItems(0).SubItems(0).Text & " không?" _
            , MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Xoa du lieu nhan vien") = MsgBoxResult.No Then Exit Sub

        Dim Zkem1 As Axzkemkeeper.AxCZKEM = ManHinhChinh.Controls("May" & ListV.SelectedItems(0).SubItems(2).Text)
        Pb.Value = 0
        Pb.Maximum = dgvKo.RowCount + 1
        Zkem1.EnableDevice(ListV.SelectedItems(0).SubItems(3).Text, False)
        Dim j As Integer = 0
        Dim KQ1 As Boolean
        For i As Integer = 0 To dgvKo.RowCount - 1
            If dgvKo.Item("Chon2", i).Value = 1 Or dgvKo.Item("Chon2", i).Value = True Then
                Do
                    KQ1 = Zkem1.DelUserTmp(ListV.SelectedItems(0).SubItems(3).Text, dgvKo.Item("MaCC2", i).Value, j)
                    j += 1
                Loop Until KQ1 = False
                Zkem1.DeleteEnrollData(ListV.SelectedItems(0).SubItems(3).Text, dgvKo.Item("MaCC2", i).Value, _
                            ListV.SelectedItems(0).SubItems(3).Text, 12)
                If XoaVtay = True Then
                    BusVanTay.Xoa(dgvKo.Item("MaCC2", i).Value)
                End If
            End If
            Try
                Pb.Value += 1
            Catch ex As Exception
                Pb.Value = 0
            End Try
        Next
        Zkem1.RefreshData(ListV.SelectedItems(0).SubItems(3).Text)
        Zkem1.EnableDevice(ListV.SelectedItems(0).SubItems(3).Text, True)
        Pb.Value = Pb.Maximum
        MsgBox("Hoàn thành quá trình xóa dữ liệu nhân viên trên máy " & ListV.SelectedItems(0).SubItems(0).Text, MsgBoxStyle.Information, "Thông báo")

    End Sub


    Private Sub XoaDLKoHanVon(ByVal ListV As ListView, ByVal dgvKo As DataGridView, ByVal XoaVtay As Boolean, ByVal Pb As ProgressBar)

        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần xóa thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        If MsgBox("Bạn có chắc là muốn xóa những nhân viên này trên máy " & ListV.SelectedItems(0).SubItems(0).Text & " không?" _
            , MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Xoa du lieu nhan vien") = MsgBoxResult.No Then Exit Sub

        Dim HanVon As AxMr_Lam_HV.Axusr_MrLam_HV = ManHinhChinh.Controls("May" & ListV.SelectedItems(0).SubItems(2).Text)
        Pb.Value = 0
        Pb.Maximum = dgvKo.RowCount + 1

        Dim j As Integer = 0
        For i As Integer = 0 To dgvKo.RowCount - 1
            If dgvKo.Item("Chon2", i).Value = 1 Or dgvKo.Item("Chon2", i).Value = True Then

                HanVon.XoaNhanVien(dgvKo.Item("MaCC2", i).Value)
                If XoaVtay = True Then
                    BusVanTay.Xoa(dgvKo.Item("MaCC2", i).Value)
                End If
            End If
            Try
                Pb.Value += 1
            Catch ex As Exception
                Pb.Value = 0
            End Try
        Next

        Pb.Value = Pb.Maximum
        MsgBox("Hoàn thành quá trình xóa dữ liệu nhân viên trên máy " & ListV.SelectedItems(0).SubItems(0).Text, MsgBoxStyle.Information, "Thông báo")

    End Sub


    Private Sub XoaDLKoND(ByVal ListV As ListView, ByVal dgvKo As DataGridView, ByVal XoaVtay As Boolean, ByVal Pb As ProgressBar)

        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần xóa thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        If MsgBox("Bạn có chắc là muốn xóa những nhân viên này trên máy " & ListV.SelectedItems(0).SubItems(0).Text & " không?" _
            , MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Xoa du lieu nhan vien") = MsgBoxResult.No Then Exit Sub

        Dim NDK1 As AxFK524PXNLib.AxFK524PXN = ManHinhChinh.Controls("May" & ListV.SelectedItems(0).SubItems(LMayID1).Text)
        Pb.Value = 0
        Pb.Maximum = dgvKo.RowCount + 1
        NDK1.EnableDevice(ListV.SelectedItems(0).SubItems(LMaySo1).Text, False)



        Dim j As Integer = 0
        For i As Integer = 0 To dgvKo.RowCount - 1
            If dgvKo.Item("Chon2", i).Value = 1 Or dgvKo.Item("Chon2", i).Value = True Then
                'Do

                '    KQ1 = NDK1.DeleteEnrollData(ListV.SelectedItems(0).SubItems(3).Text, dgvKo.Item("MaCC2", i).Value, j)
                '    j += 1
                'Loop Until KQ1 = False

                If CInt(dgvKo.Item("MaThe2", i).Value) < 10 Then
                    NDK1.DeleteEnrollData(ListV.SelectedItems(0).SubItems(3).Text, dgvKo.Item("MaCC2", i).Value, dgvKo.Item("MaThe2", i).Value)
                Else
                    NDK1.DeleteEnrollData(ListV.SelectedItems(0).SubItems(3).Text, dgvKo.Item("MaCC2", i).Value, 10)
                    NDK1.DeleteEnrollData(ListV.SelectedItems(0).SubItems(3).Text, dgvKo.Item("MaCC2", i).Value, 11)
                End If
                If XoaVtay = True Then
                    BusVanTay.Xoa(dgvKo.Item("MaCC2", i).Value)
                End If
            End If
            Try
                Pb.Value += 1
            Catch ex As Exception
                Pb.Value = 0
            End Try
        Next
        NDK1.Refresh()
        NDK1.EnableDevice(ListV.SelectedItems(0).SubItems(LMaySo1).Text, True)
        Pb.Value = Pb.Maximum
        MsgBox("Hoàn thành quá trình xóa dữ liệu nhân viên trên máy " & ListV.SelectedItems(0).SubItems(0).Text, MsgBoxStyle.Information, "Thông báo")

    End Sub

    Private Sub XoaDLKoF80(ByVal ListV As ListView, ByVal dgvKo As DataGridView, ByVal XoaVtay As Boolean, ByVal Pb As ProgressBar)

        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần xóa thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        If MsgBox("Bạn có chắc là muốn xóa những nhân viên này trên máy " & ListV.SelectedItems(0).SubItems(0).Text & " không?" _
            , MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Xoa du lieu nhan vien") = MsgBoxResult.No Then Exit Sub

        Dim mF80 As AxSB100BPCLib.AxSB100BPC = ManHinhChinh.Controls("May" & ListV.SelectedItems(0).SubItems(LMayID1).Text)
        Pb.Value = 0
        Pb.Maximum = dgvKo.RowCount + 1
        mF80.EnableDevice(ListV.SelectedItems(0).SubItems(LMaySo1).Text, False)



        Dim j As Integer = 0
        For i As Integer = 0 To dgvKo.RowCount - 1
            If dgvKo.Item("Chon2", i).Value = 1 Or dgvKo.Item("Chon2", i).Value = True Then
                'Do

                '    KQ1 = NDK1.DeleteEnrollData(ListV.SelectedItems(0).SubItems(3).Text, dgvKo.Item("MaCC2", i).Value, j)
                '    j += 1
                'Loop Until KQ1 = False
                Dim VMay As Integer = 1
                If CInt(dgvKo.Item("MaThe2", i).Value) < 10 Then
                    mF80.DeleteEnrollData(ListV.SelectedItems(0).SubItems(3).Text, dgvKo.Item("MaCC2", i).Value, VMay, dgvKo.Item("MaThe2", i).Value)
                Else
                    mF80.DeleteEnrollData(ListV.SelectedItems(0).SubItems(3).Text, dgvKo.Item("MaCC2", i).Value, VMay, 10)
                    mF80.DeleteEnrollData(ListV.SelectedItems(0).SubItems(3).Text, dgvKo.Item("MaCC2", i).Value, VMay, 11)
                End If
                If XoaVtay = True Then
                    BusVanTay.Xoa(dgvKo.Item("MaCC2", i).Value)
                End If
            End If
            Try
                Pb.Value += 1
            Catch ex As Exception
                Pb.Value = 0
            End Try
        Next
        mF80.Refresh()
        mF80.EnableDevice(ListV.SelectedItems(0).SubItems(LMaySo1).Text, True)
        Pb.Value = Pb.Maximum
        MsgBox("Hoàn thành quá trình xóa dữ liệu nhân viên trên máy " & ListV.SelectedItems(0).SubItems(0).Text, MsgBoxStyle.Information, "Thông báo")

    End Sub


    Private Sub XoaDLKoT58(ByVal ListV As ListView, ByVal dgvKo As DataGridView, ByVal XoaVtay As Boolean, ByVal Pb As ProgressBar)

        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần xóa thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        If MsgBox("Bạn có chắc là muốn xóa những nhân viên này trên máy " & ListV.SelectedItems(0).SubItems(0).Text & " không?" _
            , MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Xoa du lieu nhan vien") = MsgBoxResult.No Then Exit Sub

        Dim T58 As AxFKAttendLib.AxFKAttend = ManHinhChinh.Controls("May" & ListV.SelectedItems(0).SubItems(LMayID1).Text)
        Pb.Value = 0
        Pb.Maximum = dgvKo.RowCount + 1
        T58.EnableDevice(False)



        Dim j As Integer = 0
        For i As Integer = 0 To dgvKo.RowCount - 1
            If dgvKo.Item("Chon2", i).Value = 1 Or dgvKo.Item("Chon2", i).Value = True Then

                If CInt(dgvKo.Item("MaThe2", i).Value) < 10 Then
                    T58.DeleteEnrollData(dgvKo.Item("MaCC2", i).Value, dgvKo.Item("MaThe2", i).Value)
                Else
                    T58.DeleteEnrollData(dgvKo.Item("MaCC2", i).Value, 10)
                    T58.DeleteEnrollData(dgvKo.Item("MaCC2", i).Value, 11)
                End If
                If XoaVtay = True Then
                    BusVanTay.Xoa(dgvKo.Item("MaCC2", i).Value)
                End If
            End If
            Try
                Pb.Value += 1
            Catch ex As Exception
                Pb.Value = 0
            End Try
        Next

        T58.EnableDevice(True)
        Pb.Value = 0
        MsgBox("Hoàn thành quá trình xóa dữ liệu nhân viên trên máy " & ListV.SelectedItems(0).SubItems(0).Text, MsgBoxStyle.Information, "Thông báo")

    End Sub


    Public Sub XoaDLCo(ByVal ListV As ListView, ByVal dgvCo As DataGridView, ByVal XoaVTay As Boolean, ByVal Pb As ProgressBar)


        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần xóa thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        If ListV.SelectedItems(0).SubItems(LLoaiMay1).Text = 1 Then
            XoaDLCoND(ListV, dgvCo, XoaVTay, Pb)
        ElseIf ListV.SelectedItems(0).SubItems(LLoaiMay1).Text = 2 Then
            XoaDLCoZK(ListV, dgvCo, XoaVTay, Pb)
        ElseIf ListV.SelectedItems(0).SubItems(LLoaiMay1).Text = 3 Then
            XoaDLCoT58(ListV, dgvCo, XoaVTay, Pb)
        ElseIf ListV.SelectedItems(0).SubItems(LLoaiMay1).Text = 4 Then
            XoaDLCoF80(ListV, dgvCo, XoaVTay, Pb)

        ElseIf ListV.SelectedItems(0).SubItems(LLoaiMay1).Text = 5 Then
            XoaDLCoHanVon(ListV, dgvCo, XoaVTay, Pb)
        End If
    End Sub
    Private Sub XoaDLCoZK(ByVal ListV As ListView, ByVal dgvCo As DataGridView, ByVal XoaVTay As Boolean, ByVal Pb As ProgressBar)

        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần xóa thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        If MsgBox("Bạn có chắc là muốn xóa những nhân viên này trên máy " & ListV.SelectedItems(0).SubItems(0).Text & " không?" _
            , MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Xoa du lieu nhan vien") = MsgBoxResult.No Then Exit Sub
        Dim Zkem1 As Axzkemkeeper.AxCZKEM = ManHinhChinh.Controls("May" & ListV.SelectedItems(0).SubItems(2).Text)
        Pb.Value = 0
        Pb.Maximum = dgvCo.RowCount + 1
        Zkem1.EnableDevice(ListV.SelectedItems(0).SubItems(3).Text, False)
        Dim j As Integer = 0
        Dim Kq1 As Boolean
        For i As Integer = 0 To dgvCo.RowCount - 1
            If dgvCo.Item("Chon1", i).Value = 1 Or dgvCo.Item("Chon1", i).Value = True Then
                j = 0
                Do
                    Kq1 = Zkem1.DelUserTmp(ListV.SelectedItems(0).SubItems(3).Text, dgvCo.Item("MaCC1", i).Value, j)
                    j += 1
                Loop Until Kq1 = False
                Zkem1.DeleteEnrollData(ListV.SelectedItems(0).SubItems(3).Text, dgvCo.Item("MaCC1", i).Value, j, 12)
                If XoaVTay = True Then
                    BusVanTay.Xoa(dgvCo.Item("MaCC1", i).Value)
                End If
            End If
            Try
                Pb.Value += 1
            Catch ex As Exception
                Pb.Value = 0
            End Try
        Next
        Zkem1.RefreshData(ListV.SelectedItems(0).SubItems(3).Text)
        Zkem1.EnableDevice(ListV.SelectedItems(0).SubItems(3).Text, True)
        Pb.Value = Pb.Maximum
        MsgBox("Hoàn thành quá trình xóa dữ liệu nhân viên trên máy " & ListV.SelectedItems(0).SubItems(0).Text, MsgBoxStyle.Information, "Thông báo")
    End Sub


    Private Sub XoaDLCoHanVon(ByVal ListV As ListView, ByVal dgvCo As DataGridView, ByVal XoaVTay As Boolean, ByVal Pb As ProgressBar)

        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần xóa thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        If MsgBox("Bạn có chắc là muốn xóa những nhân viên này trên máy " & ListV.SelectedItems(0).SubItems(0).Text & " không?" _
            , MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Xoa du lieu nhan vien") = MsgBoxResult.No Then Exit Sub
        Dim HanVon As AxMr_Lam_HV.Axusr_MrLam_HV = ManHinhChinh.Controls("May" & ListV.SelectedItems(0).SubItems(2).Text)
        Pb.Value = 0
        Pb.Maximum = dgvCo.RowCount + 1

        Dim j As Integer = 0

        For i As Integer = 0 To dgvCo.RowCount - 1
            If dgvCo.Item("Chon1", i).Value = 1 Or dgvCo.Item("Chon1", i).Value = True Then
                HanVon.XoaNhanVien(dgvCo.Item("MaCC1", i).Value)
                If XoaVTay = True Then
                    BusVanTay.Xoa(dgvCo.Item("MaCC1", i).Value)
                End If
            End If
            Try
                Pb.Value += 1
            Catch ex As Exception
                Pb.Value = 0
            End Try
        Next

        Pb.Value = Pb.Maximum
        MsgBox("Hoàn thành quá trình xóa dữ liệu nhân viên trên máy " & ListV.SelectedItems(0).SubItems(0).Text, MsgBoxStyle.Information, "Thông báo")
    End Sub


    Private Sub XoaDLCoND(ByVal ListV As ListView, ByVal dgvCo As DataGridView, ByVal XoaVTay As Boolean, ByVal Pb As ProgressBar)

        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần xóa thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        If MsgBox("Bạn có chắc là muốn xóa những nhân viên này trên máy " & ListV.SelectedItems(0).SubItems(0).Text & " không?" _
            , MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Xoa du lieu nhan vien") = MsgBoxResult.No Then Exit Sub

        Dim NDK1 As AxFK524PXNLib.AxFK524PXN = ManHinhChinh.Controls("May" & ListV.SelectedItems(0).SubItems(LMayID1).Text)
        Pb.Value = 0
        Pb.Maximum = dgvCo.RowCount + 1
        NDK1.EnableDevice(ListV.SelectedItems(0).SubItems(LMaySo1).Text, False)
        Dim j As Integer = 0
        For i As Integer = 0 To dgvCo.RowCount - 1
            If dgvCo.Item("Chon1", i).Value = 1 Or dgvCo.Item("Chon1", i).Value = True Then
                j = 0
                'Do
                '    Kq1 = NDK1.DeleteEnrollData(ListV.SelectedItems(0).SubItems(3).Text, dgvCo.Item("MaCC1", i).Value, j)
                '    j += 1
                'Loop Until Kq1 = False
                'NDK1.DeleteEnrollData(ListV.SelectedItems(0).SubItems(3).Text, dgvCo.Item("MaCC1", i).Value, 12)


                If CInt(dgvCo.Item("MaThe1", i).Value) < 10 Then
                    NDK1.DeleteEnrollData(ListV.SelectedItems(0).SubItems(3).Text, dgvCo.Item("MaCC1", i).Value, dgvCo.Item("MaThe1", i).Value)
                Else
                    NDK1.DeleteEnrollData(ListV.SelectedItems(0).SubItems(3).Text, dgvCo.Item("MaCC1", i).Value, 10)
                    NDK1.DeleteEnrollData(ListV.SelectedItems(0).SubItems(3).Text, dgvCo.Item("MaCC1", i).Value, 11)
                End If
                If XoaVTay = True Then
                    BusVanTay.Xoa(dgvCo.Item("MaCC1", i).Value)
                End If
            End If
            Try
                Pb.Value += 1
            Catch ex As Exception
                Pb.Value = 0
            End Try
        Next
        NDK1.Refresh()
        NDK1.EnableDevice(ListV.SelectedItems(0).SubItems(LMaySo1).Text, True)
        Pb.Value = Pb.Maximum
        MsgBox("Hoàn thành quá trình xóa dữ liệu nhân viên trên máy " & ListV.SelectedItems(0).SubItems(0).Text, MsgBoxStyle.Information, "Thông báo")
    End Sub

    Private Sub XoaDLCoF80(ByVal ListV As ListView, ByVal dgvCo As DataGridView, ByVal XoaVTay As Boolean, ByVal Pb As ProgressBar)

        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần xóa thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        If MsgBox("Bạn có chắc là muốn xóa những nhân viên này trên máy " & ListV.SelectedItems(0).SubItems(0).Text & " không?" _
            , MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Xoa du lieu nhan vien") = MsgBoxResult.No Then Exit Sub

        Dim mF80 As AxSB100BPCLib.AxSB100BPC = ManHinhChinh.Controls("May" & ListV.SelectedItems(0).SubItems(LMayID1).Text)
        Pb.Value = 0
        Pb.Maximum = dgvCo.RowCount + 1
        mF80.EnableDevice(ListV.SelectedItems(0).SubItems(LMaySo1).Text, False)
        Dim j As Integer = 0
        For i As Integer = 0 To dgvCo.RowCount - 1
            If dgvCo.Item("Chon1", i).Value = 1 Or dgvCo.Item("Chon1", i).Value = True Then
                j = 0
                'Do
                '    Kq1 = NDK1.DeleteEnrollData(ListV.SelectedItems(0).SubItems(3).Text, dgvCo.Item("MaCC1", i).Value, j)
                '    j += 1
                'Loop Until Kq1 = False
                'NDK1.DeleteEnrollData(ListV.SelectedItems(0).SubItems(3).Text, dgvCo.Item("MaCC1", i).Value, 12)
                Dim VMay As Integer = 1

                If CInt(dgvCo.Item("MaThe1", i).Value) < 10 Then
                    mF80.DeleteEnrollData(ListV.SelectedItems(0).SubItems(3).Text, dgvCo.Item("MaCC1", i).Value, 1, dgvCo.Item("MaThe1", i).Value)
                Else
                    mF80.DeleteEnrollData(ListV.SelectedItems(0).SubItems(3).Text, dgvCo.Item("MaCC1", i).Value, 1, 10)
                    mF80.DeleteEnrollData(ListV.SelectedItems(0).SubItems(3).Text, dgvCo.Item("MaCC1", i).Value, 1, 11)
                End If
                If XoaVTay = True Then
                    BusVanTay.Xoa(dgvCo.Item("MaCC1", i).Value)
                End If
            End If
            Try
                Pb.Value += 1
            Catch ex As Exception
                Pb.Value = 0
            End Try
        Next
        mF80.Refresh()
        mF80.EnableDevice(ListV.SelectedItems(0).SubItems(LMaySo1).Text, True)
        Pb.Value = Pb.Maximum
        MsgBox("Hoàn thành quá trình xóa dữ liệu nhân viên trên máy " & ListV.SelectedItems(0).SubItems(0).Text, MsgBoxStyle.Information, "Thông báo")
    End Sub

    Private Sub XoaDLCoT58(ByVal ListV As ListView, ByVal dgvCo As DataGridView, ByVal XoaVTay As Boolean, ByVal Pb As ProgressBar)

        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần xóa thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        If MsgBox("Bạn có chắc là muốn xóa những nhân viên này trên máy " & ListV.SelectedItems(0).SubItems(0).Text & " không?" _
            , MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Xoa du lieu nhan vien") = MsgBoxResult.No Then Exit Sub

        Dim T58 As AxFKAttendLib.AxFKAttend = ManHinhChinh.Controls("May" & ListV.SelectedItems(0).SubItems(LMayID1).Text)
        Pb.Value = 0
        Pb.Maximum = dgvCo.RowCount + 1
        T58.EnableDevice(False)
        Dim j As Integer = 0
        For i As Integer = 0 To dgvCo.RowCount - 1
            If dgvCo.Item("Chon1", i).Value = 1 Or dgvCo.Item("Chon1", i).Value = True Then
                j = 0


                If CInt(dgvCo.Item("MaThe1", i).Value) < 10 Then
                    T58.DeleteEnrollData(dgvCo.Item("MaCC1", i).Value, dgvCo.Item("MaThe1", i).Value)
                Else
                    T58.DeleteEnrollData(dgvCo.Item("MaCC1", i).Value, 10)
                    T58.DeleteEnrollData(dgvCo.Item("MaCC1", i).Value, 11)
                End If
                If XoaVTay = True Then
                    BusVanTay.Xoa(dgvCo.Item("MaCC1", i).Value)
                End If
            End If
            Try
                Pb.Value += 1
            Catch ex As Exception
                Pb.Value = 0
            End Try
        Next

        T58.EnableDevice(True)
        Pb.Value = Pb.Maximum
        MsgBox("Hoàn thành quá trình xóa dữ liệu nhân viên trên máy " & ListV.SelectedItems(0).SubItems(0).Text, MsgBoxStyle.Information, "Thông báo")
    End Sub




    Private Sub TaiDauVTZK(ByVal Zkem1 As Axzkemkeeper.AxCZKEM, ByVal DTOvanTay As nvvandto, ByVal MaySo As Integer, ByVal MaNV As Integer)
        Dim KQ As Boolean
        Dim DDai, SoVan As Integer
        Dim MaVan As String = ""
        SoVan = 0
        Do
            'DTOvanTay = BusVanTay.LayBangDTo(MaNV, SoVan)
            'If DTOvanTay.MaNV = MaNV Then Exit Sub
            KQ = Zkem1.GetUserTmpStr(MaySo, MaNV, SoVan, MaVan, DDai)
            DTOvanTay.MaNV = MaNV
            DTOvanTay.ma = MaVan
            DTOvanTay.VanID = SoVan
            BusVanTay.ThemNoBinary(DTOvanTay)
            SoVan += 1
            MaVan = ""
        Loop Until KQ = False
    End Sub



    Private Sub TaiFaceHanVon(ByVal HanVon As AxMr_Lam_HV.Axusr_MrLam_HV, ByVal DTOvanTay As nvvandto, ByVal MaNV As Integer)


        DTOvanTay.ma = HanVon.DocThongTinCuaNhanVien(MaNV)
        DTOvanTay.MaNV = MaNV

        DTOvanTay.VanID = 0
        BusVanTay.ThemNoBinary(DTOvanTay)


    End Sub
    Private Sub TaiDauVTND(ByVal NDK1 As AxFK524PXNLib.AxFK524PXN, ByVal DTOvanTay As nvvandto, ByVal MaySo As Integer, ByVal MaNV As Integer, ByRef MaThe As String)
        Dim DATA As Object
        DATA = Nothing
        Dim MaVan As String = ""
        Dim QUyen As Integer
        Dim MaTheTam As Integer
        'DTOvanTay = BusVanTay.LayBangDTo(MaNV, SoVan)
        'If DTOvanTay.MaNV = MaNV Then Exit Sub
        NDK1.GetEnrollData(MaySo, MaNV, MaThe, QUyen, DATA, MaTheTam)
        If MaThe < 10 Then
            Dim a As New BVanTay
            DTOvanTay.MaNV = MaNV
            DTOvanTay.ma = "a"
            DTOvanTay.VanID = MaThe
            DTOvanTay.BVan = a.ChuyenThanhByteBinary(DATA)
            BusVanTay.Them(DTOvanTay)
            MaVan = ""
        Else
            MaThe = MaTheTam
        End If


    End Sub


    Private Sub TaiDauVTF80(ByVal mF80 As AxSB100BPCLib.AxSB100BPC, ByVal DTOvanTay As nvvandto, ByVal MaySo As Integer, ByVal MaNV As Integer, ByRef MaThe As String)

        Dim DATA As New Object

        Dim MaVan As String = ""
        Dim QUyen As Integer
        Dim MaTheTam As Integer
        Dim Vmay As Integer = MaySo
        mF80.GetEnrollData(MaySo, MaNV, Vmay, MaThe, QUyen, DATA, MaTheTam)
        If MaThe < 10 Then
            Dim a As New BVanTay
            DTOvanTay.MaNV = MaNV
            DTOvanTay.ma = "a"
            DTOvanTay.VanID = MaThe
            DTOvanTay.BVan = a.ChuyenThanhByteBinary_F80(DATA)
            BusVanTay.Them(DTOvanTay)

            MaVan = ""
        Else
            MaThe = MaTheTam
        End If


    End Sub



    Private Sub TaiDauVTT58(ByVal T58 As AxFKAttendLib.AxFKAttend, ByVal DTOvanTay As nvvandto, ByVal MaySo As Integer, ByVal MaNV As Integer, ByRef MaThe As String)

        Dim MaVan As String = ""
        Dim QUyen As Integer
        Dim MaTheTam As Integer
        'DTOvanTay = BusVanTay.LayBangDTo(MaNV, SoVan)
        'If DTOvanTay.MaNV = MaNV Then Exit Sub
        T58.GetEnrollDataWithString(MaNV, MaThe, QUyen, MaVan)
        If MaThe < 10 Then
            Dim a As New BVanTay
            DTOvanTay.MaNV = MaNV
            DTOvanTay.ma = MaVan
            DTOvanTay.VanID = MaThe
            BusVanTay.ThemNoBinary(DTOvanTay)
            MaVan = ""
        Else
            MaThe = MaTheTam
        End If
    End Sub
#End Region

#Region "Cac ham trong man hinh Up du lieu len may cham cong"
    Public Sub UpDuLieuNV(ByVal ListV As ListView, ByVal Dgv As DataGridView, ByVal UpVanTay As Boolean, ByVal Pb As ProgressBar)
        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần kiểm tra thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        If ListV.SelectedItems(0).SubItems(LLoaiMay1).Text = 1 Then
            UpDuLieuNVND(ListV, Dgv, UpVanTay, Pb)
        ElseIf ListV.SelectedItems(0).SubItems(LLoaiMay1).Text = 2 Then
            UpDuLieuNVZK(ListV, Dgv, UpVanTay, Pb)
        ElseIf ListV.SelectedItems(0).SubItems(LLoaiMay1).Text = 3 Then
            UpDuLieuNVT58(ListV, Dgv, UpVanTay, Pb)
        ElseIf ListV.SelectedItems(0).SubItems(LLoaiMay1).Text = 4 Then
            UpDuLieuNVF80(ListV, Dgv, UpVanTay, Pb)
        ElseIf ListV.SelectedItems(0).SubItems(LLoaiMay1).Text = 5 Then
            UpDuLieuNVHanVon(ListV, Dgv, UpVanTay, Pb)
        End If

    End Sub
    Private Sub UpDuLieuNVZK(ByVal ListV As ListView, ByVal Dgv As DataGridView, ByVal UpVanTay As Boolean, ByVal Pb As ProgressBar)
        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần kiểm tra thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        Pb.Value = 0
        Pb.Maximum = Dgv.Rows.Count + 1
        Dim Data As DataTable

        Dim Zkem1 As Axzkemkeeper.AxCZKEM = ManHinhChinh.Controls("May" & ListV.SelectedItems(0).SubItems(2).Text)
        Zkem1.EnableDevice(ListV.SelectedItems(0).SubItems(3).Text, False)
        For i As Integer = 0 To Dgv.RowCount - 1
            If Dgv.Item("Chon", i).Value = 1 Or Dgv.Item("Chon", i).Value = True Then

                If Strings.Len(Dgv.Item("ColMaThe", i).Value) > 3 Then _
                    Zkem1.SetStrCardNumber(Dgv.Item("ColMaThe", i).Value)
                Try
                    Zkem1.SetUserInfo(ListV.SelectedItems(0).SubItems(3).Text, Dgv.Item("ColMaNV", i).Value, _
                        Dgv.Item("ColTenHT", i).Value, 0, Dgv.Item("ColQuyen", i).Value, True)
                Catch ex As Exception

                End Try

                If UpVanTay = True Then
                    Data = BusVanTay.LayBangTable(Dgv.Item("ColMaNV", i).Value)
                    For j As Integer = 0 To Data.Rows.Count - 1
                        Zkem1.SetUserTmpStr(ListV.SelectedItems(0).SubItems(3).Text, Dgv.Item("ColMaNV", i).Value, Data.Rows(j).Item("VanID"), Data.Rows(j).Item("ma"))
                    Next
                End If

            End If
            Try
                Pb.Value += 1
            Catch ex As Exception
                Pb.Value = 0
            End Try
        Next

        Zkem1.EnableDevice(ListV.SelectedItems(0).SubItems(3).Text, True)
        Zkem1.RefreshData(ListV.SelectedItems(0).SubItems(3).Text)
        Pb.Value = Pb.Maximum
        MsgBox("Hoàn thành quá trình đưa dữ liệu lên máy chấm công", MsgBoxStyle.Information, "Thông báo")

    End Sub


    Private Sub UpDuLieuNVHanVon(ByVal ListV As ListView, ByVal Dgv As DataGridView, ByVal UpVanTay As Boolean, ByVal Pb As ProgressBar)
        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần kiểm tra thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        Pb.Value = 0
        Pb.Maximum = Dgv.Rows.Count + 1
        Dim Data As DataTable

        Dim HanVon As AxMr_Lam_HV.Axusr_MrLam_HV = ManHinhChinh.Controls("May" & ListV.SelectedItems(0).SubItems(2).Text)

        For i As Integer = 0 To Dgv.RowCount - 1
            If Dgv.Item("Chon", i).Value = 1 Or Dgv.Item("Chon", i).Value = True Then


                If UpVanTay = True Then
                    Data = BusVanTay.LayBangTable(Dgv.Item("ColMaNV", i).Value)
                    Try
                        HanVon.UpFacestr(Data.Rows(0).Item("ma"))
                    Catch ex As Exception

                    End Try

                Else
                    MsgBox("Chi co the up khuan mat len may hanvon!!!", MsgBoxStyle.Critical, "Loi")
                    Exit For
                End If

            End If
            Try
                Pb.Value += 1
            Catch ex As Exception
                Pb.Value = 0
            End Try
        Next

        Pb.Value = Pb.Maximum
        MsgBox("Hoàn thành quá trình đưa dữ liệu lên máy chấm công", MsgBoxStyle.Information, "Thông báo")

    End Sub



    Private Sub UpDuLieuNVND(ByVal ListV As ListView, ByVal Dgv As DataGridView, ByVal UpVanTay As Boolean, ByVal Pb As ProgressBar)
        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần kiểm tra thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        Pb.Value = 0
        Pb.Maximum = Dgv.Rows.Count + 1
        Dim Data As DataTable


        Dim NDK1 As AxFK524PXNLib.AxFK524PXN = ManHinhChinh.Controls("May" & ListV.SelectedItems(0).SubItems(LMayID1).Text)
        NDK1.EnableDevice(ListV.SelectedItems(0).SubItems(LMaySo1).Text, False)
        For i As Integer = 0 To Dgv.RowCount - 1
            If Dgv.Item("Chon", i).Value = 1 Or Dgv.Item("Chon", i).Value = True Then
                Dim DataP As New Object
                If UpVanTay = True Then
                    Data = BusVanTay.LayBangTable(Dgv.Item("ColMaNV", i).Value)
                    For j As Integer = 0 To Data.Rows.Count - 1
                        Dim a As New BVanTay
                        Dim c As Boolean = NDK1.SetEnrollData(ListV.SelectedItems(0).SubItems(LMaySo1).Text, Dgv.Item("ColMaNV", i).Value, _
                                                                     Data.Rows(j).Item("VanID"), Dgv.Item("ColQuyen", i).Value, _
                                                                a.ChuyenThanhIntBinary(Data.Rows(j).Item("BVan")), Dgv.Item("ColMaThe", i).Value)
                        'MsgBox("C:" & c)
                    Next
                End If
                If Strings.Len(Dgv.Item("ColMaThe", i).Value) > 3 Then
                    'Dim d As Boolean = NDK1.DeleteEnrollData(1, Dgv.Item("ColMaNV", i).Value, 11)
                    'MsgBox("d" & d)
                    Dim a As Boolean = NDK1.SetEnrollData(ListV.SelectedItems(0).SubItems(LMaySo1).Text, Dgv.Item("ColMaNV", i).Value, _
                                                11, Dgv.Item("ColQuyen", i).Value, DataP, CInt(Dgv.Item("ColMaThe", i).Value))
                    'MsgBox("11a:" & a & "ma the " & CInt(Dgv.Item("ColMaThe", i).Value))
                Else
                    NDK1.SetEnrollData(ListV.SelectedItems(0).SubItems(LMaySo1).Text, Dgv.Item("ColMaNV", i).Value, _
                                             10, Val(Dgv.Item("ColQuyen", i).Value), DataP, Val(Dgv.Item("ColMaThe", i).Value))
                End If
                'Application.DoEvents()
                Dim b As Boolean = NDK1.SetUserName(CInt(ListV.SelectedItems(0).SubItems(LMaySo1).Text), CInt(Dgv.Item("ColMaNV", i).Value), Dgv.Item("ColTenHT", i).Value.ToString)
                'MsgBox("b" & b)
            End If
            Try
                Pb.Value += 1
            Catch ex As Exception
                Pb.Value = 0
            End Try
        Next

        NDK1.EnableDevice(ListV.SelectedItems(0).SubItems(LMaySo1).Text, True)
        NDK1.Refresh()
        Pb.Value = Pb.Maximum
        MsgBox("Hoàn thành quá trình đưa dữ liệu lên máy chấm công", MsgBoxStyle.Information, "Thông báo")

    End Sub

    Private Sub UpDuLieuNVT58(ByVal ListV As ListView, ByVal Dgv As DataGridView, ByVal UpVanTay As Boolean, ByVal Pb As ProgressBar)
        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần kiểm tra thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        Pb.Value = 0
        Pb.Maximum = Dgv.Rows.Count + 1
        Dim Data As DataTable


        Dim T58 As AxFKAttendLib.AxFKAttend = ManHinhChinh.Controls("May" & ListV.SelectedItems(0).SubItems(LMayID1).Text)
        T58.EnableDevice(False)
        For i As Integer = 0 To Dgv.RowCount - 1
            If Dgv.Item("Chon", i).Value = 1 Or Dgv.Item("Chon", i).Value = True Then

                Dim DataP As New Object

                If UpVanTay = True Then
                    Data = BusVanTay.LayBangTable(Dgv.Item("ColMaNV", i).Value)
                    For j As Integer = 0 To Data.Rows.Count - 1
                        Dim a As New BVanTay
                        T58.PutEnrollDataWithString(Dgv.Item("ColMaNV", i).Value, _
                                                                      Data.Rows(j).Item("VanID"), Dgv.Item("ColQuyen", i).Value, _
                                                                Data.Rows(j).Item("ma"))
                    Next
                End If


                If Strings.Len(Dgv.Item("ColMaThe", i).Value) > 3 Then
                    T58.PutEnrollData(Dgv.Item("ColMaNV", i).Value, _
                                                11, Dgv.Item("ColQuyen", i).Value, DataP, Val(Dgv.Item("ColMaThe", i).Value))
                Else
                    T58.PutEnrollData(Dgv.Item("ColMaNV", i).Value, _
                                              10, Val(Dgv.Item("ColQuyen", i).Value), DataP, Val(Dgv.Item("ColMaThe", i).Value))

                End If


                T58.SetUserName(Dgv.Item("ColMaNV", i).Value, Dgv.Item("ColTenHT", i).Value)

            End If
            Try
                Pb.Value += 1
            Catch ex As Exception
                Pb.Value = 0
            End Try
        Next

        T58.EnableDevice(True)

        Pb.Value = 0
        MsgBox("Hoàn thành quá trình đưa dữ liệu lên máy chấm công", MsgBoxStyle.Information, "Thông báo")

    End Sub


    Private Sub UpDuLieuNVF80(ByVal ListV As ListView, ByVal Dgv As DataGridView, ByVal UpVanTay As Boolean, ByVal Pb As ProgressBar)
        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần kiểm tra thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        Pb.Value = 0
        Pb.Maximum = Dgv.Rows.Count + 1
        Dim Data As DataTable


        Dim mF80 As AxSB100BPCLib.AxSB100BPC = ManHinhChinh.Controls("May" & ListV.SelectedItems(0).SubItems(LMayID1).Text)
        Dim MaySo As Integer = ListV.SelectedItems(0).SubItems(LMaySo1).Text
        mF80.EnableDevice(1, False)
        For i As Integer = 0 To Dgv.RowCount - 1
            If Dgv.Item("Chon", i).Value = 1 Or Dgv.Item("Chon", i).Value = True Then

                Dim DataP As Object

                If UpVanTay = True Then
                    Data = BusVanTay.LayBangTable(Dgv.Item("ColMaNV", i).Value)
                    For j As Integer = 0 To Data.Rows.Count - 1
                        Dim a As New BVanTay
                        '  mF80.set()

                        DataP = a.ChuyenThanhIntBinary_F80(Data.Rows(j).Item("BVan"))
                        '     mF80.SetEnrollData()
                        mF80.SetEnrollData(MaySo, Dgv.Item("ColMaNV", i).Value, 1, _
                              Data.Rows(j).Item("VanID"), Dgv.Item("ColQuyen", i).Value, _
                                    DataP, 0)
                        'mF80 .SetEnrollData (MaySo 

                    Next
                End If


                'If Strings.Len(Dgv.Item("ColMaThe", i).Value) > 3 Then

                '    T58.PutEnrollData(Dgv.Item("ColMaNV", i).Value, _
                '                                11, Dgv.Item("ColQuyen", i).Value, DataP, Val(Dgv.Item("ColMaThe", i).Value))
                'Else
                '    T58.PutEnrollData(Dgv.Item("ColMaNV", i).Value, _
                '                              10, Val(Dgv.Item("ColQuyen", i).Value), DataP, Val(Dgv.Item("ColMaThe", i).Value))

                'End If

                mF80.SetUserName1(MaySo, Dgv.Item("ColMaNV", i).Value, Dgv.Item("ColTenHT", i).Value)
                ' T58.SetUserName(Dgv.Item("ColMaNV", i).Value, Dgv.Item("ColTenHT", i).Value)

            End If
            Try
                Pb.Value += 1
            Catch ex As Exception
                Pb.Value = 0
            End Try
        Next

        mF80.EnableDevice(MaySo, True)

        Pb.Value = 0
        MsgBox("Hoàn thành quá trình đưa dữ liệu lên máy chấm công", MsgBoxStyle.Information, "Thông báo")

    End Sub


#End Region

#Region "Cac ham trong man hinh tai du lieu mcc ve pm"
    Public Sub TaiDLMoi(ByVal ListV As ListView, ByVal ListH As ListView, ByVal PB As ProgressBar)
        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần kiểm tra thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        If ListV.SelectedItems(0).SubItems(LLoaiMay).Text = 1 Then
            TaiDLMoiND(ListV, ListH, PB)
        ElseIf ListV.SelectedItems(0).SubItems(LLoaiMay).Text = 2 Then
            TaiDLMoiZK(ListV, ListH, PB)
        ElseIf ListV.SelectedItems(0).SubItems(LLoaiMay).Text = 3 Then
            TaiDLMoiT58(ListV, ListH, PB)
        ElseIf ListV.SelectedItems(0).SubItems(LLoaiMay).Text = 4 Then
            TaiDLMoiF80(ListV, ListH, PB)
        ElseIf ListV.SelectedItems(0).SubItems(LLoaiMay).Text = 5 Then
            TaiDLMoiHanVon(ListV, ListH, PB)

        End If
    End Sub
    Private Sub TaiDLMoiZK(ByVal ListV As ListView, ByVal ListH As ListView, ByVal PB As ProgressBar)
        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần kiểm tra thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        PB.Value = 0


        Dim KieuCC As Integer
        Dim TG As String = ""

        Dim DTOvaoRa As New Vaoradto
        Dim DTONhanVien As New nhanviendto

        Dim NgayLN As Date

        Dim MaMay As Integer = ListV.SelectedItems(0).SubItems(4).Text
        Dim MaySo As Integer = ListV.SelectedItems(0).SubItems(9).Text

        Dim Zkem1 As Axzkemkeeper.AxCZKEM = ManHinhChinh.Controls("May" & MaMay)

        Zkem1.EnableDevice(MaySo, False)
        Zkem1.GetDeviceStatus(ListV.SelectedItems(0).SubItems(LMaySo).Text, 6, PB.Maximum)
        PB.Maximum += 1

        Zkem1.ReadAllGLogData(MaySo)
        Try
            If BusVaoRa.DuLieuLN(MaMay).Rows.Count > 0 Then
                NgayLN = BusVaoRa.DuLieuLN(MaMay).Rows(0).Item(0)
            Else
                NgayLN = #1/1/1900#
            End If

        Catch ex As Exception
            NgayLN = #1/1/1900#
        End Try

        Dim STT As Integer = 0
        ListH.Items.Clear()
        While Zkem1.GetGeneralLogDataStr(MaySo, DTOvaoRa.MaNV, KieuCC, DTOvaoRa.Kieu, TG)

            If CDate(TG) <= NgayLN Then Continue While
            DTOvaoRa.May = MaMay
            DTOvaoRa.Ngay = CDate(TG).Date
            DTOvaoRa.Thoigian = CDate(TG)
            BusVaoRa.Them(DTOvaoRa)
            '            If hienThiTenNV Then DTONhanVien = TimNVnhanh(DTOvaoRa.MaNV)
            '           lvt = ListH.Items.Add(STT + 1)
            '          lvt.SubItems.AddRange(New String() {DTOvaoRa.MaNV, DTONhanVien.TenNV, DTOvaoRa.Thoigian, IIf(DTOvaoRa.Kieu = 0, "Vào", "Ra"), MaySo})

            STT += 1
            Try
                PB.Value += 1
            Catch ex As Exception
                PB.Value = 0
            End Try
        End While
        Zkem1.EnableDevice(MaySo, True)
        PB.Value = PB.Maximum
        MsgBox("Đã tải " & STT & " từ máy " & ListV.SelectedItems(0).SubItems(LTenMay).Text, MsgBoxStyle.Information, "Thông báo")

    End Sub

    Private Sub TaiDLMoiHanVon(ByVal ListV As ListView, ByVal ListH As ListView, ByVal PB As ProgressBar)
        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần kiểm tra thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        PB.Value = 0
        Dim DTOvaoRa As New Vaoradto
        Dim DTONhanVien As New nhanviendto
        Dim NgayLN As Date
        Dim MaMay As Integer = ListV.SelectedItems(0).SubItems(4).Text
        Dim MaySo As Integer = ListV.SelectedItems(0).SubItems(9).Text
        Dim HanVon As AxMr_Lam_HV.Axusr_MrLam_HV = ManHinhChinh.Controls("May" & MaMay)
        PB.Value = 0
        PB.Maximum = 100
        Dim DuLieuCC As String = ""
        DuLieuCC = HanVon.DocDuLieuChamCong()
        Dim lvt As ListViewItem
        Dim ArrVaoRa() As String
        ArrVaoRa = Strings.Split(DuLieuCC, "time=")
        PB.Maximum = ArrVaoRa.Length
        ListH.Items.Clear()
        For i As Integer = 1 To ArrVaoRa.Length - 1
            lvt = ListH.Items.Add(i + 1)
            Dim Arr2() As String
            Arr2 = Strings.Split(ArrVaoRa(i), """")
            Dim MaCC As Integer = Arr2(3)
            Dim TenHT As String = Arr2(5)
            Dim TG As Date = CDate(Arr2(1))

            Try
                If BusVaoRa.DuLieuLN(MaMay).Rows.Count > 0 Then
                    NgayLN = BusVaoRa.DuLieuLN(MaMay).Rows(0).Item(0)
                Else
                    NgayLN = #1/1/1900#
                End If

            Catch ex As Exception
                NgayLN = #1/1/1900#
            End Try



            If CDate(TG) <= NgayLN Then Continue For
            DTOvaoRa.MaNV = MaCC
            DTOvaoRa.May = MaMay
            DTOvaoRa.Ngay = CDate(TG).Date
            DTOvaoRa.Thoigian = CDate(TG)
            BusVaoRa.Them(DTOvaoRa)


            lvt.SubItems.AddRange(New String() {MaCC, TenHT, CDate(TG)})
            Try
                PB.Value += 1
            Catch ex As Exception
                PB.Value = 0
            End Try
        Next

        MsgBox("Đã tải " & ListH.Items.Count & " từ máy " & ListV.SelectedItems(0).SubItems(LTenMay).Text, MsgBoxStyle.Information, "Thông báo")

    End Sub

    Private Sub TaiTCDLHanVon(ByVal ListV As ListView, ByVal ListH As ListView, ByVal PB As ProgressBar)
        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần kiểm tra thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        PB.Value = 0
        Dim DTOvaoRa As New Vaoradto
        Dim DTONhanVien As New nhanviendto
        Dim MaMay As Integer = ListV.SelectedItems(0).SubItems(4).Text
        Dim MaySo As Integer = ListV.SelectedItems(0).SubItems(9).Text
        Dim HanVon As AxMr_Lam_HV.Axusr_MrLam_HV = ManHinhChinh.Controls("May" & MaMay)

        PB.Value = 0
        PB.Maximum = 100
        Dim DuLieuCC As String = ""
        DuLieuCC = HanVon.DocDuLieuChamCong()

        Dim lvt As ListViewItem
        Dim ArrVaoRa() As String
        ArrVaoRa = Strings.Split(DuLieuCC, "time=")

        PB.Maximum = ArrVaoRa.Length
        ListH.Items.Clear()

        For i As Integer = 1 To ArrVaoRa.Length - 1
            lvt = ListH.Items.Add(i + 1)
            Dim Arr2() As String
            Arr2 = Strings.Split(ArrVaoRa(i), """")
            Dim MaCC As Integer = Arr2(3)
            Dim TenHT As String = Arr2(5)
            Dim TG As Date = CDate(Arr2(1))
            DTOvaoRa.MaNV = MaCC
            DTOvaoRa.May = MaMay
            DTOvaoRa.Ngay = CDate(TG).Date
            DTOvaoRa.Thoigian = CDate(TG)
            BusVaoRa.Them(DTOvaoRa)
            lvt.SubItems.AddRange(New String() {MaCC, TenHT, CDate(TG)})
            Try
                PB.Value += 1
            Catch ex As Exception
                PB.Value = 0
            End Try
        Next

        MsgBox("Đã tải " & ListH.Items.Count & " từ máy " & ListV.SelectedItems(0).SubItems(LTenMay).Text, MsgBoxStyle.Information, "Thông báo")

    End Sub



    Private Sub TaiDLMoiND(ByVal ListV As ListView, ByVal ListH As ListView, ByVal PB As ProgressBar)
        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần kiểm tra thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        PB.Value = 0
        Dim KieuCC As Integer
        Dim TG As Date
        Dim DTOvaoRa As New Vaoradto
        Dim DTONhanVien As New nhanviendto
        Dim NgayLN As Date
        Dim MaMay As Integer = ListV.SelectedItems(0).SubItems(LMayID).Text
        Dim MaySo As Integer = ListV.SelectedItems(0).SubItems(LMaySo).Text
        Dim NDK1 As AxFK524PXNLib.AxFK524PXN = ManHinhChinh.Controls("May" & MaMay)
        NDK1.EnableDevice(MaySo, False)
        NDK1.GetDeviceStatus(MaySo, 6, PB.Maximum)
        PB.Maximum += 1

        Try
            If BusVaoRa.DuLieuLN(MaMay).Rows.Count > 0 Then
                NgayLN = BusVaoRa.DuLieuLN(MaMay).Rows(0).Item(0)
            Else
                NgayLN = #1/1/1900#
            End If

        Catch ex As Exception
            NgayLN = #1/1/1900#
        End Try


        Dim STT As Integer = 0
        ListH.Items.Clear()
        Dim Nam, Thang, Ngay, Gio, Phut As Integer

        NDK1.ReadAllGLogData(MaySo)
        While NDK1.GetAllGLogData(MaySo, DTOvaoRa.MaNV, KieuCC, DTOvaoRa.Kieu, Nam, Thang, Ngay, Gio, Phut)
            Dim temp As Integer = 0
            'If Gio = 24 And Phut > 0 Then

            'ElseIf Gio > 24 Then
            'Else

            'End If
           

            If Gio < 24 Then
                ' MsgBox(Nam & " " & Thang & " " & Ngay & " " & Gio & " " & Phut)
                TG = DateSerial(Nam, Thang, Ngay) & " " & TimeSerial(Gio, Phut, 0)
                KTNgayHH(CDate(TG))
                If CDate(TG) <= NgayLN Then Continue While
                KTNgayHH(CDate(TG))
                DTOvaoRa.May = MaMay
                DTOvaoRa.Ngay = CDate(TG).Date
                DTOvaoRa.Thoigian = CDate(TG)
                BusVaoRa.Them(DTOvaoRa)
                '  If hienThiTenNV Then DTONhanVien = TimNVnhanh(DTOvaoRa.MaNV)
                ' lvt = ListH.Items.Add(STT + 1)
                '  lvt.SubItems.AddRange(New String() {DTOvaoRa.MaNV, DTONhanVien.TenNV, DTOvaoRa.Thoigian, IIf(DTOvaoRa.Kieu = 0, "Vào", "Ra"), MaySo})

                STT += 1
            End If
            Try
                PB.Value += 1
            Catch ex As Exception
                PB.Value = 0
            End Try
        End While
        NDK1.EnableDevice(MaySo, True)
        PB.Value = PB.Maximum
        MsgBox("Đã tải " & STT & " từ máy " & ListV.SelectedItems(0).SubItems(LTenMay).Text, MsgBoxStyle.Information, "Thông báo")

    End Sub

    Private Sub TaiDLMoiT58(ByVal ListV As ListView, ByVal ListH As ListView, ByVal PB As ProgressBar)
        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần kiểm tra thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        PB.Value = 0
        Dim KieuCC As Integer
        Dim TG As Date
        Dim DTOvaoRa As New Vaoradto
        Dim DTONhanVien As New nhanviendto
        Dim NgayLN As Date
        Dim MaMay As Integer = ListV.SelectedItems(0).SubItems(LMayID).Text
        Dim MaySo As Integer = ListV.SelectedItems(0).SubItems(LMaySo).Text
        Dim T58 As AxFKAttendLib.AxFKAttend = ManHinhChinh.Controls("May" & MaMay)
        T58.EnableDevice(False)
        T58.GetDeviceStatus(6, PB.Maximum)
        PB.Maximum += 1

        Try
            If BusVaoRa.DuLieuLN(MaMay).Rows.Count > 0 Then
                NgayLN = BusVaoRa.DuLieuLN(MaMay).Rows(0).Item(0)
            Else
                NgayLN = #1/1/1900#
            End If

        Catch ex As Exception
            NgayLN = #1/1/1900#
        End Try

        Dim STT As Integer = 0
        ListH.Items.Clear()
        Dim lvt As ListViewItem

        T58.LoadGeneralLogData(1)
        While True
            Dim kq As Integer = T58.GetGeneralLogData(DTOvaoRa.MaNV, KieuCC, DTOvaoRa.Kieu, TG)
            If kq <= 0 Then Exit While
            KTNgayHH(CDate(TG))
            If CDate(TG) <= NgayLN Then Continue While
            KTNgayHH(CDate(TG))
            DTOvaoRa.May = MaMay
            DTOvaoRa.Ngay = TG
            DTOvaoRa.Thoigian = TG
            BusVaoRa.Them(DTOvaoRa)
            If hienThiTenNV Then DTONhanVien = TimNVnhanh(DTOvaoRa.MaNV)
            lvt = ListH.Items.Add(STT + 1)
            lvt.SubItems.AddRange(New String() {DTOvaoRa.MaNV, DTONhanVien.TenNV, DTOvaoRa.Thoigian, IIf(DTOvaoRa.Kieu = 0, "Vào", "Ra"), MaySo})

            STT += 1
            Try
                PB.Value += 1
            Catch ex As Exception
                PB.Value = 0
            End Try
        End While
        T58.EnableDevice(True)
        PB.Value = 0
        MsgBox("Đã tải " & STT & " từ máy " & ListV.SelectedItems(0).SubItems(LTenMay).Text, MsgBoxStyle.Information, "Thông báo")

    End Sub

    Private Sub TaiDLMoiF80(ByVal ListV As ListView, ByVal ListH As ListView, ByVal PB As ProgressBar)
        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần kiểm tra thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        PB.Value = 0
        Dim TG As String
        Dim DTOvaoRa As New Vaoradto
        Dim DTONhanVien As New nhanviendto
        Dim NgayLN As Date
        Dim MaMay As Integer = ListV.SelectedItems(0).SubItems(LMayID).Text
        Dim MaySo As Integer = ListV.SelectedItems(0).SubItems(LMaySo).Text
        Dim mF80 As AxSB100BPCLib.AxSB100BPC = ManHinhChinh.Controls("May" & MaMay)
        mF80.EnableDevice(MaySo, False)
        mF80.GetDeviceStatus(MaySo, 6, PB.Maximum)
        PB.Maximum += 1

        Try
            If BusVaoRa.DuLieuLN(MaMay).Rows.Count > 0 Then
                NgayLN = BusVaoRa.DuLieuLN(MaMay).Rows(0).Item(0)
            Else
                NgayLN = #1/1/1900#
            End If

        Catch ex As Exception
            NgayLN = #1/1/1900#
        End Try


        Dim STT As Integer = 0
        ListH.Items.Clear()
        Dim lvt As ListViewItem
        Dim Nam, Thang, Ngay, Gio, Phut As Integer

        mF80.ReadAllGLogData(MaySo)
        Dim VMay As Integer = 0
        While mF80.GetGeneralLogData(MaySo, VMay, DTOvaoRa.MaNV, VMay, DTOvaoRa.Kieu, Nam, Thang, Ngay, Gio, Phut)
            If Gio < 24 Then
                TG = DateSerial(Nam, Thang, Ngay) & " " & TimeSerial(Gio, Phut, 0)
                KTNgayHH(CDate(TG))
                If CDate(TG) <= NgayLN Then Continue While
                KTNgayHH(CDate(TG))
                DTOvaoRa.May = MaMay
                DTOvaoRa.Ngay = CDate(TG).Date
                DTOvaoRa.Thoigian = CDate(TG)
                BusVaoRa.Them(DTOvaoRa)
                'If hienThiTenNV Then DTONhanVien = TimNVnhanh(DTOvaoRa.MaNV)
                lvt = ListH.Items.Add(STT + 1)
                lvt.SubItems.AddRange(New String() {DTOvaoRa.MaNV, DTONhanVien.TenNV, DTOvaoRa.Thoigian, IIf(DTOvaoRa.Kieu = 0, "Vào", "Ra"), MaySo})

                STT += 1
            End If

            Try
                PB.Value += 1
            Catch ex As Exception
                PB.Value = 0
            End Try
        End While
        mF80.EnableDevice(MaySo, True)
        PB.Value = PB.Maximum
        MsgBox("Đã tải " & STT & " từ máy " & ListV.SelectedItems(0).SubItems(LTenMay).Text, MsgBoxStyle.Information, "Thông báo")

    End Sub

    Public Sub TaiTCDL(ByVal ListV As ListView, ByVal ListH As ListView, ByVal PB As ProgressBar)
        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần kiểm tra thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        If ListV.SelectedItems(0).SubItems(LLoaiMay).Text = 1 Then
            TaiTCDLND(ListV, ListH, PB)
        ElseIf ListV.SelectedItems(0).SubItems(LLoaiMay).Text = 2 Then
            TaiTCDLZK(ListV, ListH, PB)
        ElseIf ListV.SelectedItems(0).SubItems(LLoaiMay).Text = 3 Then
            TaiTCDLT58(ListV, ListH, PB)
        ElseIf ListV.SelectedItems(0).SubItems(LLoaiMay).Text = 4 Then
            TaiTCDLF80(ListV, ListH, PB)
        ElseIf ListV.SelectedItems(0).SubItems(LLoaiMay).Text = 5 Then
            TaiTCDLHanVon(ListV, ListH, PB)
        End If
    End Sub

    Private Sub TaiTCDLZK(ByVal ListV As ListView, ByVal ListH As ListView, ByVal PB As ProgressBar)
        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần kiểm tra thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        PB.Value = 0
        Dim KieuCC As Integer
        Dim TG As String = ""
        Dim DTOvaoRa As New Vaoradto
        Dim DTONhanVien As New nhanviendto
        Dim MaMay As Integer = ListV.SelectedItems(0).SubItems(4).Text
        Dim MaySo As Integer = ListV.SelectedItems(0).SubItems(9).Text
        Dim Zkem1 As Axzkemkeeper.AxCZKEM = ManHinhChinh.Controls("May" & MaMay)
        Zkem1.EnableDevice(MaySo, False)
        Zkem1.GetDeviceStatus(MaySo, 6, PB.Maximum)
        PB.Maximum += 1
        Zkem1.ReadAllGLogData(MaySo)
        Dim STT As Integer = 0
        ListH.Items.Clear()
        While Zkem1.GetGeneralLogDataStr(MaySo, DTOvaoRa.MaNV, KieuCC, DTOvaoRa.Kieu, TG)
            DTOvaoRa.May = MaMay
            DTOvaoRa.Ngay = CDate(TG).Date
            DTOvaoRa.Thoigian = CDate(TG)
            KTNgayHH(CDate(TG))
            BusVaoRa.Them(DTOvaoRa)
            'If hienThiTenNV Then DTONhanVien = TimNVnhanh(DTOvaoRa.MaNV)
            'lvt = ListH.Items.Add(STT + 1)
            'lvt.SubItems.AddRange(New String() {DTOvaoRa.MaNV, DTONhanVien.TenNV, DTOvaoRa.Thoigian, IIf(DTOvaoRa.Kieu = 0, "Vào", "Ra"), MaySo})
            STT += 1
            Try
                PB.Value += 1
            Catch ex As Exception
                PB.Value = 0
            End Try
        End While
        Zkem1.EnableDevice(MaySo, True)
        PB.Value = PB.Maximum
        MsgBox("Đã tải " & STT & " từ máy " & ListV.SelectedItems(0).SubItems(LTenMay).Text, MsgBoxStyle.Information, "Thông báo")
    End Sub

    Private Sub TaiTCDLND(ByVal ListV As ListView, ByVal ListH As ListView, ByVal PB As ProgressBar)
        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần kiểm tra thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        PB.Value = 0


        Dim KieuCC As Integer
        Dim TG As String
        Dim DTOvaoRa As New Vaoradto
        Dim DTONhanVien As New nhanviendto
        'Dim ngaya As Date



        Dim MaMay As Integer = ListV.SelectedItems(0).SubItems(4).Text
        Dim MaySo As Integer = ListV.SelectedItems(0).SubItems(9).Text

        Dim NDK1 As AxFK524PXNLib.AxFK524PXN = ManHinhChinh.Controls("May" & MaMay)

        NDK1.EnableDevice(MaySo, False)
        NDK1.GetDeviceStatus(ListV.SelectedItems(0).SubItems(LMaySo).Text, 6, PB.Maximum)
        PB.Maximum += 1

        NDK1.ReadAllGLogData(MaySo)

        Dim STT As Integer = 0
        ListH.Items.Clear()
        Dim Nam, Thang, Ngay, Gio, Phut As Integer

        While NDK1.GetAllGLogData(MaySo, DTOvaoRa.MaNV, KieuCC, DTOvaoRa.Kieu, Nam, Thang, Ngay, Gio, Phut)
            If Gio < 24 Then
                'ngaya = DateSerial(Nam, Thang, Ngay) & " " & TimeSerial(Gio, Phut, 0)
                TG = DateSerial(Nam, Thang, Ngay) & " " & TimeSerial(Gio, Phut, 0)
                KTNgayHH(CDate(TG))
                'Dim ngayb As Date
                'ngayb = ngaya
                DTOvaoRa.May = MaMay
                DTOvaoRa.Ngay = CDate(TG).Date
                DTOvaoRa.Thoigian = CDate(TG)
                BusVaoRa.Them(DTOvaoRa)
                'If hienThiTenNV Then DTONhanVien = TimNVnhanh(DTOvaoRa.MaNV)
                'lvt = ListH.Items.Add(STT + 1)
                'lvt.SubItems.AddRange(New String() {DTOvaoRa.MaNV, DTONhanVien.TenNV, DTOvaoRa.Thoigian, IIf(DTOvaoRa.Kieu = 0, "Vào", "Ra"), MaySo})
                STT += 1
            End If
            Try
                PB.Value += 1
            Catch ex As Exception
                PB.Value = 0
            End Try
        End While
        NDK1.EnableDevice(MaySo, True)
        PB.Value = PB.Maximum
        MsgBox("Đã tải " & STT & " từ máy " & ListV.SelectedItems(0).SubItems(LTenMay).Text, MsgBoxStyle.Information, "Thông báo")

    End Sub

    Private Sub TaiTCDLT58(ByVal ListV As ListView, ByVal ListH As ListView, ByVal PB As ProgressBar)
        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần kiểm tra thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        PB.Value = 0


        Dim KieuCC As Integer
        Dim TG As Date
        Dim DTOvaoRa As New Vaoradto
        Dim DTONhanVien As New nhanviendto



        Dim MaMay As Integer = ListV.SelectedItems(0).SubItems(4).Text
        Dim MaySo As Integer = ListV.SelectedItems(0).SubItems(9).Text

        Dim T58 As AxFKAttendLib.AxFKAttend = ManHinhChinh.Controls("May" & MaMay)

        T58.EnableDevice(False)
        T58.GetDeviceStatus(8, PB.Maximum)
        PB.Maximum += 1


        T58.LoadGeneralLogData(0)

        Dim STT As Integer = 0
        ListH.Items.Clear()
        Dim lvt As ListViewItem

        While True
            Dim kq As Integer = T58.GetGeneralLogData(DTOvaoRa.MaNV, KieuCC, DTOvaoRa.Kieu, TG)
            If kq <= 0 Then Exit While
            KTNgayHH(CDate(TG))
            DTOvaoRa.May = MaMay
            DTOvaoRa.Ngay = TG.Date
            DTOvaoRa.Thoigian = TG
            BusVaoRa.Them(DTOvaoRa)
            If hienThiTenNV Then DTONhanVien = TimNVnhanh(DTOvaoRa.MaNV)
            lvt = ListH.Items.Add(STT + 1)
            lvt.SubItems.AddRange(New String() {DTOvaoRa.MaNV, DTONhanVien.TenNV, DTOvaoRa.Thoigian, IIf(DTOvaoRa.Kieu = 0, "Vào", "Ra"), MaySo})

            STT += 1
            Try
                PB.Value += 1
            Catch ex As Exception
                PB.Value = 0
            End Try
        End While
        T58.EnableDevice(True)
        PB.Value = 0
        MsgBox("Đã tải " & STT & " từ máy " & ListV.SelectedItems(0).SubItems(LTenMay).Text, MsgBoxStyle.Information, "Thông báo")

    End Sub

    Private Sub TaiTCDLF80(ByVal ListV As ListView, ByVal ListH As ListView, ByVal PB As ProgressBar)
        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần kiểm tra thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        PB.Value = 0
        Dim TG As Date
        Dim DTOvaoRa As New Vaoradto
        Dim DTONhanVien As New nhanviendto
        Dim MaMay As Integer = ListV.SelectedItems(0).SubItems(4).Text
        Dim MaySo As Integer = ListV.SelectedItems(0).SubItems(9).Text
        Dim mF80 As AxSB100BPCLib.AxSB100BPC = ManHinhChinh.Controls("May" & MaMay)
        mF80.EnableDevice(MaySo, False)
        mF80.GetDeviceStatus(MaySo, 6, PB.Maximum)
        PB.Maximum += 1
        mF80.ReadAllGLogData(MaySo)
        Dim STT As Integer = 0
        ListH.Items.Clear()
        Dim lvt As ListViewItem
        Dim Vmay As Integer = 0
        Dim Nam, thang, ngay, gio, phut As Integer
        While mF80.GetAllGLogData(MaySo, Vmay, DTOvaoRa.MaNV, Vmay, DTOvaoRa.Kieu, Nam, thang, ngay, gio, phut)
            If gio < 24 Then
                TG = CDate(DateSerial(Nam, thang, ngay) & " " & TimeSerial(gio, phut, 0))
                KTNgayHH(TG)
                DTOvaoRa.May = MaMay
                DTOvaoRa.Ngay = TG.Date
                DTOvaoRa.Thoigian = TG
                BusVaoRa.Them(DTOvaoRa)
                If hienThiTenNV Then DTONhanVien = TimNVnhanh(DTOvaoRa.MaNV)
                lvt = ListH.Items.Add(STT + 1)
                lvt.SubItems.AddRange(New String() {DTOvaoRa.MaNV, DTONhanVien.TenNV, DTOvaoRa.Thoigian, IIf(DTOvaoRa.Kieu = 0, "Vào", "Ra"), MaySo})

                STT += 1
            End If

            Try
                PB.Value += 1
            Catch ex As Exception
                PB.Value = 0
            End Try
        End While
        mF80.EnableDevice(MaySo, True)
        PB.Value = 0
        MsgBox("Đã tải " & STT & " từ máy " & ListV.SelectedItems(0).SubItems(LTenMay).Text, MsgBoxStyle.Information, "Thông báo")

    End Sub


#End Region

#Region "Cac ham trong man hinh Quan ly thong tin may cham cong"


    Public Sub DocTTMay(ByVal ListV As ListView, ByRef TGMay As String, ByRef DLNV As Integer, ByRef DLQL As Integer, ByRef DLCC As Integer, ByRef DLVT As Integer, ByRef Seri As String)

        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần đọc thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        If ListV.SelectedItems(0).SubItems(LLoaiMay1).Text = 1 Then
            DocTTMayND(ListV, TGMay, DLNV, DLQL, DLCC, DLVT, Seri)
        ElseIf ListV.SelectedItems(0).SubItems(LLoaiMay1).Text = 2 Then
            DocTTMayZK(ListV, TGMay, DLNV, DLQL, DLCC, DLVT, Seri)
        ElseIf ListV.SelectedItems(0).SubItems(LLoaiMay1).Text = 3 Then
            DocTTMayT58(ListV, TGMay, DLNV, DLQL, DLCC, DLVT, Seri)
        ElseIf ListV.SelectedItems(0).SubItems(LLoaiMay1).Text = 4 Then
            DocTTMayF80(ListV, TGMay, DLNV, DLQL, DLCC, DLVT, Seri)
        End If

    End Sub

    Private Sub DocTTMayZK(ByVal ListV As ListView, ByRef TGMay As String, ByRef DLNV As Integer, ByRef DLQL As Integer, ByRef DLCC As Integer, ByRef DLVT As Integer, ByVal seri As String)
        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần đọc thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        Dim Zkem1 As Axzkemkeeper.AxCZKEM = ManHinhChinh.Controls("May" & ListV.SelectedItems(0).SubItems(LMayID1).Text)
        Zkem1.EnableDevice(ListV.SelectedItems(0).SubItems(LMaySo1).Text, False)
        If Zkem1.EnableDevice(ListV.SelectedItems(0).SubItems(LMaySo1).Text, False) Then
            Zkem1.GetDeviceStatus(ListV.SelectedItems(0).SubItems(LMaySo1).Text, 1, DLQL)
            Zkem1.GetDeviceStatus(ListV.SelectedItems(0).SubItems(LMaySo1).Text, 2, DLNV)
            Zkem1.GetDeviceStatus(ListV.SelectedItems(0).SubItems(LMaySo1).Text, 3, DLVT)
            Zkem1.GetDeviceStatus(ListV.SelectedItems(0).SubItems(LMaySo1).Text, 6, DLCC)
            Zkem1.GetSerialNumber(ListV.SelectedItems(0).SubItems(LMaySo1).Text, seri)
            Dim Nam, Thang, NGay, Gio, Phut, Giay As Integer
            Zkem1.GetDeviceTime(ListV.SelectedItems(0).SubItems(LMaySo1).Text, Nam, Thang, NGay, Gio, Phut, Giay)
            TGMay = CStr(DateSerial(Nam, Thang, NGay) & " " & TimeSerial(Gio, Phut, Giay))

            MsgBox("Hoàn thành quá trình đọc dữ liệu", MsgBoxStyle.Information, "Thông báo")
        Else
            MsgBox("Đọc dữ liệu từ máy chấm công thất bại!", MsgBoxStyle.Exclamation, "Lỗi kết nối")
        End If
        Zkem1.EnableDevice(ListV.SelectedItems(0).SubItems(LMaySo1).Text, True)
    End Sub


    Private Sub DocTTMayND(ByVal ListV As ListView, ByRef TGMay As String, ByRef DLNV As Integer, ByRef DLQL As Integer, ByRef DLCC As Integer, ByRef DLVT As Integer, ByRef Seri As String)
        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần đọc thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        Dim NDK1 As AxFK524PXNLib.AxFK524PXN = ManHinhChinh.Controls("May" & ListV.SelectedItems(0).SubItems(LMayID1).Text)
        NDK1.EnableDevice(ListV.SelectedItems(0).SubItems(LMaySo1).Text, False)

        If NDK1.EnableDevice(ListV.SelectedItems(0).SubItems(LMaySo1).Text, False) Then
            '
            'ndk1.GetDeviceInfo 

            NDK1.GetDeviceStatus(ListV.SelectedItems(0).SubItems(LMaySo1).Text, 1, DLQL)
            NDK1.GetDeviceStatus(ListV.SelectedItems(0).SubItems(LMaySo1).Text, 2, DLNV)
            NDK1.GetDeviceStatus(ListV.SelectedItems(0).SubItems(LMaySo1).Text, 3, DLVT)
            NDK1.GetDeviceStatus(ListV.SelectedItems(0).SubItems(LMaySo1).Text, 6, DLCC)
            NDK1.GetSerialNumber(ListV.SelectedItems(0).SubItems(LMaySo1).Text, Seri)
            Dim Nam, Thang, NGay, Gio, Phut, Giay As Integer
            Dim TuanThu As Integer
            NDK1.GetDeviceTime(ListV.SelectedItems(0).SubItems(LMaySo1).Text, Nam, Thang, NGay, Gio, Phut, Giay, TuanThu)
            TGMay = CStr(DateSerial(Nam, Thang, NGay) & " " & TimeSerial(Gio, Phut, Giay))

            MsgBox("Hoàn thành quá trình đọc dữ liệu", MsgBoxStyle.Information, "Thông báo")
        Else
            MsgBox("Đọc dữ liệu từ máy chấm công thất bại!", MsgBoxStyle.Exclamation, "Lỗi kết nối")
        End If
        NDK1.EnableDevice(ListV.SelectedItems(0).SubItems(LMaySo1).Text, True)
    End Sub

    Private Sub DocTTMayF80(ByVal ListV As ListView, ByRef TGMay As String, ByRef DLNV As Integer, ByRef DLQL As Integer, ByRef DLCC As Integer, ByRef DLVT As Integer, ByRef seri As String)
        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần đọc thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        Dim mF80 As AxSB100BPCLib.AxSB100BPC = ManHinhChinh.Controls("May" & ListV.SelectedItems(0).SubItems(LMayID1).Text)
        mF80.EnableDevice(ListV.SelectedItems(0).SubItems(LMaySo1).Text, False)

        If mF80.EnableDevice(ListV.SelectedItems(0).SubItems(LMaySo1).Text, False) Then
            '
            'ndk1.GetDeviceInfo 
            mF80.GetDeviceStatus(ListV.SelectedItems(0).SubItems(LMaySo1).Text, 1, DLQL)
            mF80.GetDeviceStatus(ListV.SelectedItems(0).SubItems(LMaySo1).Text, 2, DLNV)
            mF80.GetDeviceStatus(ListV.SelectedItems(0).SubItems(LMaySo1).Text, 3, DLVT)
            mF80.GetDeviceStatus(ListV.SelectedItems(0).SubItems(LMaySo1).Text, 6, DLCC)
            mF80.GetSerialNumber(ListV.SelectedItems(0).SubItems(LMaySo1).Text, seri)
            Dim Nam, Thang, NGay, Gio, Phut As Integer
            Dim TuanThu As Integer
            mF80.GetDeviceTime(ListV.SelectedItems(0).SubItems(LMaySo1).Text, Nam, Thang, NGay, Gio, Phut, TuanThu)
            TGMay = CStr(DateSerial(Nam, Thang, NGay) & " " & TimeSerial(Gio, Phut, 0))

            MsgBox("Hoàn thành quá trình đọc dữ liệu", MsgBoxStyle.Information, "Thông báo")
        Else
            MsgBox("Đọc dữ liệu từ máy chấm công thất bại!", MsgBoxStyle.Exclamation, "Lỗi kết nối")
        End If
        mF80.EnableDevice(ListV.SelectedItems(0).SubItems(LMaySo1).Text, True)
    End Sub



    Private Sub DocTTMayT58(ByVal ListV As ListView, ByRef TGMay As String, ByRef DLNV As Integer, ByRef DLQL As Integer, ByRef DLCC As Integer, ByRef DLVT As Integer, ByRef seri As String)
        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần đọc thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        Dim T58 As AxFKAttendLib.AxFKAttend = ManHinhChinh.Controls("May" & ListV.SelectedItems(0).SubItems(LMayID1).Text)
        T58.EnableDevice(False)

        If T58.EnableDevice(False) Then


            T58.GetDeviceStatus(1, DLQL)
            T58.GetDeviceStatus(2, DLNV)
            T58.GetDeviceStatus(3, DLVT)
            T58.GetDeviceStatus(8, DLCC)
            T58.GetProductData(1, seri)
            Dim tg As Date
            T58.GetDeviceTime(tg)
            TGMay = tg

            MsgBox("Hoàn thành quá trình đọc dữ liệu", MsgBoxStyle.Information, "Thông báo")
        Else
            MsgBox("Đọc dữ liệu từ máy chấm công thất bại!", MsgBoxStyle.Exclamation, "Lỗi kết nối")
        End If
        T58.EnableDevice(True)
    End Sub

    Public Sub DongBoTG(ByVal ListV As ListView)

        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần đọc thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        If ListV.SelectedItems(0).SubItems(LLoaiMay1).Text = 1 Then
            DongBoTGND(ListV)
        ElseIf ListV.SelectedItems(0).SubItems(LLoaiMay1).Text = 2 Then
            DongBoTGZK(ListV)
        ElseIf ListV.SelectedItems(0).SubItems(LLoaiMay1).Text = 3 Then
            DongBoTGT58(ListV)
        ElseIf ListV.SelectedItems(0).SubItems(LLoaiMay1).Text = 4 Then
            DongBoTGF80(ListV)
        End If


    End Sub

    Private Sub DongBoTGZK(ByVal ListV As ListView)
        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần đồng bộ thời gian!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        Dim Zkem1 As Axzkemkeeper.AxCZKEM = ManHinhChinh.Controls("May" & ListV.SelectedItems(0).SubItems(LMayID1).Text)
        Zkem1.EnableDevice(ListV.SelectedItems(0).SubItems(LMaySo1).Text, False)
        If Zkem1.SetDeviceTime(ListV.SelectedItems(0).SubItems(LMaySo1).Text) Then
            MsgBox("Đồng bộ thời gian thành công!", MsgBoxStyle.Information, "Thông báo")
        Else
            MsgBox("Đồng bộ thời gian thất bại!", MsgBoxStyle.Exclamation, "Thông báo")
        End If
        Zkem1.EnableDevice(ListV.SelectedItems(0).SubItems(LMaySo1).Text, True)

    End Sub


    Private Sub DongBoTGND(ByVal ListV As ListView)
        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần đồng bộ thời gian!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        Dim NDK1 As AxFK524PXNLib.AxFK524PXN = ManHinhChinh.Controls("May" & ListV.SelectedItems(0).SubItems(LMayID1).Text)
        NDK1.EnableDevice(ListV.SelectedItems(0).SubItems(LMaySo1).Text, False)
        If NDK1.SetDeviceTime(ListV.SelectedItems(0).SubItems(LMaySo1).Text) Then
            MsgBox("Đồng bộ thời gian thành công!", MsgBoxStyle.Information, "Thông báo")
        Else
            MsgBox("Đồng bộ thời gian thất bại!", MsgBoxStyle.Exclamation, "Thông báo")
        End If
        NDK1.EnableDevice(ListV.SelectedItems(0).SubItems(LMaySo1).Text, True)

    End Sub

    Private Sub DongBoTGF80(ByVal ListV As ListView)
        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần đồng bộ thời gian!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        Dim mF80 As AxSB100BPCLib.AxSB100BPC = ManHinhChinh.Controls("May" & ListV.SelectedItems(0).SubItems(LMayID1).Text)
        mF80.EnableDevice(ListV.SelectedItems(0).SubItems(LMaySo1).Text, False)
        If mF80.SetDeviceTime(ListV.SelectedItems(0).SubItems(LMaySo1).Text) Then
            MsgBox("Đồng bộ thời gian thành công!", MsgBoxStyle.Information, "Thông báo")
        Else
            MsgBox("Đồng bộ thời gian thất bại!", MsgBoxStyle.Exclamation, "Thông báo")
        End If
        mF80.EnableDevice(ListV.SelectedItems(0).SubItems(LMaySo1).Text, True)

    End Sub

    Private Sub DongBoTGT58(ByVal ListV As ListView)
        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần đồng bộ thời gian!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        Dim T58 As AxFKAttendLib.AxFKAttend = ManHinhChinh.Controls("May" & ListV.SelectedItems(0).SubItems(LMayID1).Text)
        T58.EnableDevice(False)
        If T58.SetDeviceTime(Now) Then
            MsgBox("Đồng bộ thời gian thành công!", MsgBoxStyle.Information, "Thông báo")
        Else
            MsgBox("Đồng bộ thời gian thất bại!", MsgBoxStyle.Exclamation, "Thông báo")
        End If
        T58.EnableDevice(True)

    End Sub


    Public Sub XoaAdmin(ByVal ListV As ListView)

        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần đọc thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        If ListV.SelectedItems(0).SubItems(LLoaiMay1).Text = 2 Then
            XoaQAdminZK(ListV)
        ElseIf ListV.SelectedItems(0).SubItems(LLoaiMay1).Text = 5 Then
            XoaQAdminHanVon(ListV)
        Else


            MsgBox("Bạn không thể xóa admin với máy METRON ND", MsgBoxStyle.Critical, "Thông báo")
        End If
    End Sub
    Private Sub XoaQAdminZK(ByVal ListV As ListView)
        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần đồng bộ thời gian!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        If MsgBox("Bạn có chắc là muốn xóa hết quyền Quản Lý trên máy " & ListV.SelectedItems(0).SubItems(LTenMay1).Text & " không?" _
            , MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Xoa quyen Quan Ly") = MsgBoxResult.No Then Exit Sub


        Dim Zkem1 As Axzkemkeeper.AxCZKEM = ManHinhChinh.Controls("May" & ListV.SelectedItems(0).SubItems(LMayID1).Text)
        Zkem1.EnableDevice(ListV.SelectedItems(0).SubItems(LMaySo1).Text, False)
        If Zkem1.ClearAdministrators(ListV.SelectedItems(0).SubItems(LMaySo1).Text) Then
            MsgBox("Xóa quyền Quản Lý trên máy " & ListV.SelectedItems(0).SubItems(LTenMay1).Text & " thành công!", MsgBoxStyle.Information, "Thông báo")
        Else
            MsgBox("Xóa quyền Quản Lý trên máy " & ListV.SelectedItems(0).SubItems(LTenMay1).Text & " thất bại!", MsgBoxStyle.Exclamation, "Thông báo")
        End If
        Zkem1.EnableDevice(ListV.SelectedItems(0).SubItems(LMaySo1).Text, True)

    End Sub

    Private Sub XoaQAdminHanVon(ByVal ListV As ListView)
        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần đồng bộ thời gian!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        If MsgBox("Bạn có chắc là muốn xóa hết quyền Quản Lý trên máy " & ListV.SelectedItems(0).SubItems(LTenMay1).Text & " không?" _
            , MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Xoa quyen Quan Ly") = MsgBoxResult.No Then Exit Sub


        Dim HanVon As AxMr_Lam_HV.Axusr_MrLam_HV = ManHinhChinh.Controls("May" & ListV.SelectedItems(0).SubItems(LMayID1).Text)

        HanVon.XoaAdmin()
        MsgBox("Xóa quyền Quản Lý trên máy " & ListV.SelectedItems(0).SubItems(LTenMay1).Text & " thành công!", MsgBoxStyle.Information, "Thông báo")



    End Sub




    Public Sub XoaDLCC(ByVal ListV As ListView)

        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần đọc thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        If ListV.SelectedItems(0).SubItems(LLoaiMay1).Text = 1 Then
            XoaDLCCND(ListV)
        ElseIf ListV.SelectedItems(0).SubItems(LLoaiMay1).Text = 2 Then
            XoaDLCCZK(ListV)
        ElseIf ListV.SelectedItems(0).SubItems(LLoaiMay1).Text = 3 Then
            XoaDLCCT58(ListV)
        ElseIf ListV.SelectedItems(0).SubItems(LLoaiMay1).Text = 4 Then
            XoaDLCCF80(ListV)
        ElseIf ListV.SelectedItems(0).SubItems(LLoaiMay1).Text = 5 Then
            XoaDLCCHanVon(ListV)


        End If
    End Sub
    Private Sub XoaDLCCZK(ByVal ListV As ListView)
        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần đồng bộ thời gian!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If

        If MsgBox("Bạn có chắc là muốn xóa hết dữ liệu chấm công trên máy " & ListV.SelectedItems(0).SubItems(LTenMay1).Text & " không?" _
            , MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Xoa Du Lieu Cham Cong") = MsgBoxResult.No Then Exit Sub


        Dim Zkem1 As Axzkemkeeper.AxCZKEM = ManHinhChinh.Controls("May" & ListV.SelectedItems(0).SubItems(LMayID1).Text)
        Zkem1.EnableDevice(ListV.SelectedItems(0).SubItems(LMaySo1).Text, False)
        If Zkem1.ClearGLog(ListV.SelectedItems(0).SubItems(LMaySo1).Text) Then
            MsgBox("Xóa dữ liệu chấm công trên máy " & ListV.SelectedItems(0).SubItems(LMayID1).Text & " thành công!", MsgBoxStyle.Information, "Thông báo")
        Else
            MsgBox("Xóa dữ liệu chấm công trên máy " & ListV.SelectedItems(0).SubItems(LMayID1).Text & " thất bại!", MsgBoxStyle.Exclamation, "Thông báo")
        End If
        Zkem1.EnableDevice(ListV.SelectedItems(0).SubItems(LMaySo1).Text, True)

    End Sub


    Private Sub XoaDLCCHanVon(ByVal ListV As ListView)
        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần đồng bộ thời gian!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If

        If MsgBox("Bạn có chắc là muốn xóa hết dữ liệu chấm công trên máy " & ListV.SelectedItems(0).SubItems(LTenMay1).Text & " không?" _
            , MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Xoa Du Lieu Cham Cong") = MsgBoxResult.No Then Exit Sub


        Dim HanVon As AxMr_Lam_HV.Axusr_MrLam_HV = ManHinhChinh.Controls("May" & ListV.SelectedItems(0).SubItems(LMayID1).Text)

        HanVon.XoaDuLieuChamCong()
        MsgBox("Xóa dữ liệu chấm công trên máy " & ListV.SelectedItems(0).SubItems(LMayID1).Text & " thành công!", MsgBoxStyle.Information, "Thông báo")


    End Sub



    Private Sub XoaDLCCND(ByVal ListV As ListView)
        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần đồng bộ thời gian!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If

        If MsgBox("Bạn có chắc là muốn xóa hết dữ liệu chấm công trên máy " & ListV.SelectedItems(0).SubItems(LTenMay1).Text & " không?" _
            , MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Xoa Du Lieu Cham Cong") = MsgBoxResult.No Then Exit Sub


        Dim NDK1 As AxFK524PXNLib.AxFK524PXN = ManHinhChinh.Controls("May" & ListV.SelectedItems(0).SubItems(LMayID1).Text)
        NDK1.EnableDevice(ListV.SelectedItems(0).SubItems(LMaySo1).Text, False)

        If NDK1.EmptyGeneralLogData(ListV.SelectedItems(0).SubItems(LMaySo1).Text) Then
            MsgBox("Xóa dữ liệu chấm công trên máy " & ListV.SelectedItems(0).SubItems(LMayID1).Text & " thành công!", MsgBoxStyle.Information, "Thông báo")
        Else
            MsgBox("Xóa dữ liệu chấm công trên máy " & ListV.SelectedItems(0).SubItems(LMayID1).Text & " thất bại!", MsgBoxStyle.Exclamation, "Thông báo")
        End If
        NDK1.EnableDevice(ListV.SelectedItems(0).SubItems(LMaySo1).Text, True)

    End Sub

    Private Sub XoaDLCCF80(ByVal ListV As ListView)
        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần đồng bộ thời gian!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If

        If MsgBox("Bạn có chắc là muốn xóa hết dữ liệu chấm công trên máy " & ListV.SelectedItems(0).SubItems(LTenMay1).Text & " không?" _
            , MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Xoa Du Lieu Cham Cong") = MsgBoxResult.No Then Exit Sub


        Dim mF80 As AxSB100BPCLib.AxSB100BPC = ManHinhChinh.Controls("May" & ListV.SelectedItems(0).SubItems(LMayID1).Text)
        mF80.EnableDevice(ListV.SelectedItems(0).SubItems(LMaySo1).Text, False)

        If mF80.EmptyGeneralLogData(ListV.SelectedItems(0).SubItems(LMaySo1).Text) Then
            MsgBox("Xóa dữ liệu chấm công trên máy " & ListV.SelectedItems(0).SubItems(LMayID1).Text & " thành công!", MsgBoxStyle.Information, "Thông báo")
        Else
            MsgBox("Xóa dữ liệu chấm công trên máy " & ListV.SelectedItems(0).SubItems(LMayID1).Text & " thất bại!", MsgBoxStyle.Exclamation, "Thông báo")
        End If
        mF80.EnableDevice(ListV.SelectedItems(0).SubItems(LMaySo1).Text, True)

    End Sub

    Private Sub XoaDLCCT58(ByVal ListV As ListView)
        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần đồng bộ thời gian!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If

        If MsgBox("Bạn có chắc là muốn xóa hết dữ liệu chấm công trên máy " & ListV.SelectedItems(0).SubItems(LTenMay1).Text & " không?" _
            , MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Xoa Du Lieu Cham Cong") = MsgBoxResult.No Then Exit Sub


        Dim T58 As AxFKAttendLib.AxFKAttend = ManHinhChinh.Controls("May" & ListV.SelectedItems(0).SubItems(LMayID1).Text)
        T58.EnableDevice(False)

        If T58.EmptyGeneralLogData() Then
            T58.EmptySuperLogData()
            MsgBox("Xóa dữ liệu chấm công trên máy " & ListV.SelectedItems(0).SubItems(LMayID1).Text & " thành công!", MsgBoxStyle.Information, "Thông báo")
        Else
            MsgBox("Xóa dữ liệu chấm công trên máy " & ListV.SelectedItems(0).SubItems(LMayID1).Text & " thất bại!", MsgBoxStyle.Exclamation, "Thông báo")
        End If
        T58.EnableDevice(True)
    End Sub


    Public Sub XoaDL(ByVal ListV As ListView)

        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần đọc thông tin!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        If ListV.SelectedItems(0).SubItems(LLoaiMay1).Text = 1 Then
            XoaDLND(ListV)
        ElseIf ListV.SelectedItems(0).SubItems(LLoaiMay1).Text = 2 Then
            XoaDLZK(ListV)
        ElseIf ListV.SelectedItems(0).SubItems(LLoaiMay1).Text = 3 Then
            XoaDLT58(ListV)
        ElseIf ListV.SelectedItems(0).SubItems(LLoaiMay1).Text = 4 Then
            XoaDLF80(ListV)
        ElseIf ListV.SelectedItems(0).SubItems(LLoaiMay1).Text = 5 Then
            XoaDLCCHanVon(ListV)


        End If
    End Sub
    Private Sub XoaDLZK(ByVal ListV As ListView)
        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần đồng bộ thời gian!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If

        If MsgBox("Bạn có chắc là muốn xóa hết dữ liệu chấm công trên máy " & ListV.SelectedItems(0).SubItems(LTenMay1).Text & " không?" _
            , MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Xoa Du Lieu Cham Cong") = MsgBoxResult.No Then Exit Sub


        Dim Zkem1 As Axzkemkeeper.AxCZKEM = ManHinhChinh.Controls("May" & ListV.SelectedItems(0).SubItems(LMayID1).Text)
        Zkem1.EnableDevice(ListV.SelectedItems(0).SubItems(LMaySo1).Text, False)
        If Zkem1.ClearKeeperData(ListV.SelectedItems(0).SubItems(LMaySo1).Text) Then
            MsgBox("Xóa dữ liệu chấm công trên máy " & ListV.SelectedItems(0).SubItems(LTenMay1).Text & " thành công!", MsgBoxStyle.Information, "Thông báo")
        Else
            MsgBox("Xóa dữ liệu chấm công trên máy " & ListV.SelectedItems(0).SubItems(LTenMay1).Text & " thất bại!", MsgBoxStyle.Exclamation, "Thông báo")
        End If
        Zkem1.EnableDevice(ListV.SelectedItems(0).SubItems(LMaySo1).Text, True)

    End Sub



    Private Sub XoaDLND(ByVal ListV As ListView)
        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần đồng bộ thời gian!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If

        If MsgBox("Bạn có chắc là muốn xóa hết dữ liệu chấm công trên máy " & ListV.SelectedItems(0).SubItems(LTenMay1).Text & " không?" _
            , MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Xoa Du Lieu Cham Cong") = MsgBoxResult.No Then Exit Sub


        Dim NDK1 As AxFK524PXNLib.AxFK524PXN = ManHinhChinh.Controls("May" & ListV.SelectedItems(0).SubItems(LMayID1).Text)
        NDK1.EnableDevice(ListV.SelectedItems(0).SubItems(LMaySo1).Text, False)
        If NDK1.ClearKeeperData(ListV.SelectedItems(0).SubItems(LMaySo1).Text) Then
            MsgBox("Xóa dữ liệu chấm công trên máy " & ListV.SelectedItems(0).SubItems(LTenMay1).Text & " thành công!", MsgBoxStyle.Information, "Thông báo")
        Else
            MsgBox("Xóa dữ liệu chấm công trên máy " & ListV.SelectedItems(0).SubItems(LTenMay1).Text & " thất bại!", MsgBoxStyle.Exclamation, "Thông báo")
        End If
        NDK1.EnableDevice(ListV.SelectedItems(0).SubItems(LMaySo1).Text, True)

    End Sub

    Private Sub XoaDLF80(ByVal ListV As ListView)
        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần đồng bộ thời gian!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If

        If MsgBox("Bạn có chắc là muốn xóa hết dữ liệu chấm công trên máy " & ListV.SelectedItems(0).SubItems(LTenMay1).Text & " không?" _
            , MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Xoa Du Lieu Cham Cong") = MsgBoxResult.No Then Exit Sub


        Dim mF80 As AxSB100BPCLib.AxSB100BPC = ManHinhChinh.Controls("May" & ListV.SelectedItems(0).SubItems(LMayID1).Text)
        mF80.EnableDevice(ListV.SelectedItems(0).SubItems(LMaySo1).Text, False)
        If mF80.ClearKeeperData(ListV.SelectedItems(0).SubItems(LMaySo1).Text) Then
            MsgBox("Xóa dữ liệu chấm công trên máy " & ListV.SelectedItems(0).SubItems(LTenMay1).Text & " thành công!", MsgBoxStyle.Information, "Thông báo")
        Else
            MsgBox("Xóa dữ liệu chấm công trên máy " & ListV.SelectedItems(0).SubItems(LTenMay1).Text & " thất bại!", MsgBoxStyle.Exclamation, "Thông báo")
        End If
        mF80.EnableDevice(ListV.SelectedItems(0).SubItems(LMaySo1).Text, True)

    End Sub


    Private Sub XoaDLHanVon(ByVal ListV As ListView)
        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần xóa dữ liệu!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If

        If MsgBox("Bạn có chắc là muốn xóa hết dữ liệu chấm công trên máy " & ListV.SelectedItems(0).SubItems(LTenMay1).Text & " không?" _
            , MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Xoa Du Lieu Cham Cong") = MsgBoxResult.No Then Exit Sub


        Dim HanVon As AxMr_Lam_HV.Axusr_MrLam_HV = ManHinhChinh.Controls("May" & ListV.SelectedItems(0).SubItems(LMayID1).Text)

        HanVon.XoaTatCaDL()
        MsgBox("Xóa dữ liệu chấm công trên máy " & ListV.SelectedItems(0).SubItems(LTenMay1).Text & " thành công!", MsgBoxStyle.Information, "Thông báo")

    End Sub


    Private Sub XoaDLT58(ByVal ListV As ListView)
        If ListV.SelectedItems.Count = 0 Then
            MsgBox("Vui lòng chọn máy cần đồng bộ thời gian!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If

        If MsgBox("Bạn có chắc là muốn xóa hết dữ liệu chấm công trên máy " & ListV.SelectedItems(0).SubItems(LTenMay1).Text & " không?" _
            , MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Xoa Du Lieu Cham Cong") = MsgBoxResult.No Then Exit Sub


        Dim T58 As AxFKAttendLib.AxFKAttend = ManHinhChinh.Controls("May" & ListV.SelectedItems(0).SubItems(LMayID1).Text)
        T58.EnableDevice(False)
        If T58.ClearKeeperData() Then
            MsgBox("Xóa dữ liệu chấm công trên máy " & ListV.SelectedItems(0).SubItems(LTenMay1).Text & " thành công!", MsgBoxStyle.Information, "Thông báo")
        Else
            MsgBox("Xóa dữ liệu chấm công trên máy " & ListV.SelectedItems(0).SubItems(LTenMay1).Text & " thất bại!", MsgBoxStyle.Exclamation, "Thông báo")
        End If
        T58.EnableDevice(True)

    End Sub


#End Region
End Class
