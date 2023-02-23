Imports System.Windows.Forms

Public Class ManhinhUSB
    Dim daoNK As New NhatkyBus(DTOKetnoi, False)
    Dim dtoNK As New Nhatkydto
#Region "TreeView"
    Dim dtoDonvi As New donvidto
    Dim BusDonvi As New donviBus(DTOKetnoi, False)
    Dim BusNhanvien As New nhanvienBus(DTOKetnoi, False)



    Private Sub cay()
        Dim tvRoot As TreeNode
        dtoDonvi = BusDonvi.LayBangDTo(1)
        tvRoot = Me.TreeView1.Nodes.Add(dtoDonvi.MaDV, dtoDonvi.TenDV)
        TaoCay(tvRoot, 1)
    End Sub
    Private Sub TaoCay(ByVal tvRoot As TreeNode, Optional ByVal nhanh As Integer = 1)
        Dim cay As DataTable = BusDonvi.LayBangTableTheoNhanh(nhanh)
        Dim tvNode As TreeNode
        If cay.Rows.Count <= 0 Then Exit Sub
        For i As Integer = 0 To cay.Rows.Count - 1
            tvNode = tvRoot.Nodes.Add(cay.Rows(i)("madv"), cay.Rows(i)("tendv"), 1, 0)
            TaoCay(tvNode, cay.Rows(i)("madv"))
        Next
    End Sub
    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect

        Dim data As DataTable
        If Me.TreeView1.SelectedNode.Name = 1 Then
            data = BusNhanvien.LocNhanVienUSBAll
        Else
            data = BusNhanvien.LocNhanVienUSB(e.Node.Name)
        End If

        dgvNhanVien.DataSource = data
        TreeView1.Focus()


    End Sub
#End Region

#Region "Cac ham ho tro chuyen doi"


#Region "Cac ham ho tro doc ghi du lieu cham cong"

    Private Sub docDLCC()
        Dim DLZK As Integer = 0
        open1.Title = "Mở File "
        open1.DefaultExt = "AGL_001"
        open1.FileName = "AGL_001"
        open1.Filter = "METRON F202/K400 |*.txt|METRON F80/2088 |*.txt|HanVon|*.txt|METRON ZK|*.Dat"
        open1.FilterIndex = 1
        If open1.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub


        DLZK = open1.FilterIndex

        Dim DocF As New IO.StreamReader(open1.FileName)

        Dim MaCC, KieuVR As Integer
        Dim TG As Date
        Dim BusNhanVien As New nhanvienBus(DTOKetnoi, False)
        Dim dtoNhanVien As New nhanviendto

        Dim STT As Integer = 1
        dgvDLCC.Rows.Clear()
        PbCC.Value = 0
        PbCC.Maximum = 500
        Select Case DLZK

            Case 1
                If Not DocF.EndOfStream Then DocF.ReadLine()
                While Not DocF.EndOfStream
                    mahoaND(DocF.ReadLine, MaCC, TG, KieuVR)
                    dtoNhanVien = BusNhanVien.LayBangDTo(MaCC)
                    Me.dgvDLCC.Rows.Add(STT, MaCC, dtoNhanVien.TenNV, dtoNhanVien.TenHT, TG, TG, KieuVR)
                    STT += 1

                    Try
                        PbCC.Value += 1
                    Catch ex As Exception
                        PbCC.Value = 0
                    End Try

                End While
            Case 2
                If Not DocF.EndOfStream Then DocF.ReadLine()
                While Not DocF.EndOfStream
                    mahoaNDF80(DocF.ReadLine, MaCC, TG, KieuVR)
                    dtoNhanVien = BusNhanVien.LayBangDTo(MaCC)
                    Me.dgvDLCC.Rows.Add(STT, MaCC, dtoNhanVien.TenNV, dtoNhanVien.TenHT, TG, TG, KieuVR)
                    STT += 1

                    Try
                        PbCC.Value += 1
                    Catch ex As Exception
                        PbCC.Value = 0
                    End Try

                End While

            Case 3
                If Not DocF.EndOfStream Then DocF.ReadLine()
                While Not DocF.EndOfStream
                    Dim tenht As String = ""

                    If MaHoaHanVon(DocF.ReadLine, tenht, MaCC, TG, KieuVR) = False Then Exit While

                    dtoNhanVien = BusNhanVien.LayBangDTo(MaCC)
                    Me.dgvDLCC.Rows.Add(STT, MaCC, dtoNhanVien.TenNV, tenht, TG, TG, KieuVR)
                    STT += 1

                    Try
                        PbCC.Value += 1
                    Catch ex As Exception
                        PbCC.Value = 0
                    End Try

                End While
            Case 4
                While Not DocF.EndOfStream
                    mahoaZK(DocF.ReadLine, MaCC, TG, KieuVR)
                    dtoNhanVien = BusNhanVien.LayBangDTo(MaCC)
                    Me.dgvDLCC.Rows.Add(STT, MaCC, dtoNhanVien.TenNV, dtoNhanVien.TenHT, TG, TG, KieuVR)
                    STT += 1
                    Try
                        PbCC.Value += 1
                    Catch ex As Exception
                        PbCC.Value = 0
                    End Try
                End While

        End Select



        PbCC.Value = PbCC.Maximum
        MsgBox("Hoàn thành quá trình đọc dữ liệu chấm công từ USB", MsgBoxStyle.Information, "Thông báo")


    End Sub

    Private Function MaHoaHanVon(ByVal chuoi As String, ByRef TenHT As String, ByRef MaCC As Integer, ByRef ThoiGian As Date, ByRef KieuCC As Integer) As Boolean
        Dim Arr2() As String

        Arr2 = Strings.Split(chuoi, """")
        If Arr2.Length = 1 Then Return False
        MaCC = Arr2(3)
        TenHT = Arr2(5)
        ThoiGian = CDate(Arr2(1))
        KieuCC = Arr2(9)
        KieuCC = IIf(KieuCC = 2, 1, 0)
        Return True
    End Function
    Private Sub mahoaND(ByVal str As String, ByRef MaNV As Integer, ByRef Tg As DateTime, ByRef kieu As Integer)
        Try
            MaNV = CInt(Strings.Mid(str, 9, 8))
            Tg = DateSerial(CInt(Strings.Mid(str, 34, 4)), CInt(Strings.Mid(str, 39, 2)), CInt(Strings.Mid(str, 42, 2))) & " " & _
                TimeSerial(CInt(Strings.Mid(str, 46, 2)), CInt(Strings.Mid(str, 49, 2)), 0)
            kieu = Strings.Mid(str, 32, 1)
        Catch ex As Exception

        End Try


    End Sub
    Private Sub mahoaNDF80(ByVal str As String, ByRef MaNV As Integer, ByRef Tg As DateTime, ByRef kieu As Integer)
        Dim ArrStr() As String

        ArrStr = str.Split(vbTab)
        Try
            MaNV = ArrStr(2)
            Tg = ArrStr(8)
            kieu = Val(ArrStr(6))
        Catch ex As Exception

        End Try


        ' Tg = DateSerial(CInt(Strings.Mid(str, 34, 4)), CInt(Strings.Mid(str, 39, 2)), CInt(Strings.Mid(str, 42, 2))) & " " & _
        'TimeSerial(CInt(Strings.Mid(str, 46, 2)), CInt(Strings.Mid(str, 49, 2)), 0)
        '  kieu = Strings.Mid(str, 32, 1)

    End Sub

    Private Sub mahoaZK(ByVal str As String, ByRef MaNV As Integer, ByRef Tg As DateTime, ByRef kieu As Integer)
        Try
            Dim tg2 As String
            MaNV = CInt(Strings.Left(str, 5))
            tg2 = Mid(str, 6, 20)
            Tg = CDate(tg2)
            kieu = Mid(str, 29, 1)
        Catch ex As Exception

        End Try


    End Sub

    Private Sub LuuTTChamCong()
        Dim BusVaoRa As New VaoraBus(DTOKetnoi, False)
        Dim dtoVaoRa As New Vaoradto
        PbCC.Value = 0
        PbCC.Maximum = Me.dgvDLCC.RowCount + 1
        For i As Integer = 0 To Me.dgvDLCC.RowCount - 1
            dtoVaoRa.MaNV = Me.dgvDLCC.Item("MaCCVR", i).Value
            dtoVaoRa.Thoigian = Me.dgvDLCC.Item("TGVR", i).Value
            dtoVaoRa.Ngay = CDate(Me.dgvDLCC.Item("TGVR", i).Value).Date
            dtoVaoRa.Kieu = Me.dgvDLCC.Item("TTVR", i).Value
            dtoVaoRa.Kieu = 1
            BusVaoRa.Them(dtoVaoRa)
            Try
                PbCC.Value += 1
            Catch ex As Exception
                PbCC.Value = 0
            End Try
        Next
        PbCC.Value = PbCC.Maximum
        MsgBox("Hoàn thành quá trình cập nhật dữ liệu chấm công từ USB", MsgBoxStyle.Information, "Thông báo")

    End Sub

#End Region


    '*********************
    '*********************

#Region "Cac ham ho tro doc du lieu nhan vien may Nideka"
    Private Sub DocDLNV()


        open1.Title = "Mở File "
        open1.DefaultExt = "AGL_001"
        open1.FileName = "AGL_001"
        open1.Filter = "Dữ liệu nhân viên (METRON ND) |*.DAT"
        open1.FilterIndex = 1
        MsgBox("Lưu ý [ĐỌC DỮ LIỆU NHÂN VIÊN] chỉ áp dụng được với máy METRON ND", MsgBoxStyle.Exclamation, "Thông báo")
        If open1.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub
        Dim NDK1 As AxFK524PXNLib.AxFK524PXN = ManHinhChinh.AxFK524PXN1
        If NDK1.USBReadAllEnrollDataFromFile(open1.FileName) = False Then
            MsgBox("Không đọc được file này!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        PbNV.Value = 0
        PbNV.Maximum = NDK1.USBReadAllEnrollDataCount
        Dim MaCC, NVBack, QuyenCC, Pass, HoatDong As Integer
        Dim DataNV As Object = DBNull.Value
        Dim TenHT As String = ""

        Dim STT As Integer = 1

        Dim BusNhanVien As New nhanvienBus(DTOKetnoi, False)
        Dim dtoNhanVien As New nhanviendto

        While NDK1.USBSetOneEnrollData(MaCC, NVBack, QuyenCC, DataNV, Pass, HoatDong, TenHT)
            dtoNhanVien = BusNhanVien.LayBangDTo(MaCC)
            Me.dgvTTNV.Rows.Add(STT, 1, MaCC, dtoNhanVien.TenNV, TenHT, QuyenCC, Pass, NVBack, CVTemp(DataNV))
            STT += 1
            DataNV = DBNull.Value

            Try
                PbNV.Value += 1
            Catch ex As Exception
                PbNV.Value = 0
            End Try

        End While


    End Sub





#End Region

#End Region


    Private Sub cmdDocCC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDocCC.Click
        docDLCC()
    End Sub

    Private Sub cmdLuuCC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLuuCC.Click
        LuuTTChamCong()
    End Sub

    Private Sub ManhinhUSB_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtoNK.User = TenNguoiDangNhap
        dtoNK.Ngay = Date.Now.Date
        dtoNK.Gio = Date.Now
        dtoNK.Tacvu = "Mở quản lý dử liệu từ USB"
        daoNK.Them(dtoNK)
        cay()

    End Sub

    Private Sub cmdDocNV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDocNV.Click
        Dim op As New OpenFileDialog

        Dim DLZK As Integer = 0
        op.Title = "Mở File "
        op.Filter = "HanVon|*.txt"
        op.FilterIndex = 1
        If op.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub


        DLZK = op.FilterIndex
        Dim docfile As New IO.StreamReader(op.FileName)

        Dim chuoi As String = docfile.ReadToEnd

        Dim str As String = "Return(result=""success"""


        Dim ArrChuoi() As String = Strings.Split(chuoi, str)
        Dim i As Integer = 1
        Dim MaNV As Integer, MaFace As String = ""

        Try
            Do
                MaHoaNhanVienHanVon(ArrChuoi(i), MaNV, MaFace)
                Dim pointnv As Integer = dgvTTNV.Rows.Add()
                With dgvTTNV.Rows(pointnv)
                    .Cells("C_ChonNV_NV1").Value = True
                    .Cells("C_STT_NV1").Value = pointnv + 1
                    .Cells("C_MaCC_NV1").Value = MaNV
                    .Cells("C_VanTay_NV1").Value = MaFace
                End With
                i += 1
            Loop
        Catch ex As Exception

        End Try

        PbCC.Value = PbCC.Maximum
        MsgBox("Hoàn thành quá trình đọc dữ liệu chấm công từ USB", MsgBoxStyle.Information, "Thông báo")


    End Sub
    'Dim op As New OpenFileDialog
    'op.Filter = "METRON F202/K400 |*.txt|METRON F80/2088 |*.txt|HanVon|*.txt|METRON ZK|*.Dat"
    'op.FilterIndex = 1

    'If op.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub
    'Dim docfile As New IO.StreamReader(op.FileName)

    'Dim chuoi As String = docfile.ReadToEnd

    'Dim str As String = "Return(result=""success"""


    'Dim ArrChuoi() As String = Strings.Split(chuoi, str)
    'Dim i As Integer = 1
    'Dim MaNV As Integer, MaFace As String

    'Try
    '    Do
    '        MaHoaNhanVienHanVon(ArrChuoi(i), MaNV, MaFace)
    '        Dim pointnv As Integer = dgvTTNV.Rows.Add()
    '        With dgvTTNV.Rows(pointnv)
    '            .Cells("C_ChonNV_NV1").Value = True
    '            .Cells("C_STT_NV1").Value = pointnv + 1
    '            .Cells("C_MaCC_NV1").Value = MaNV
    '            .Cells("C_VanTay_NV1").Value = MaFace
    '        End With
    '        i += 1
    '    Loop
    'Catch ex As Exception

    'End Try

    ''Return(result="success"
    'End Sub

    Private Sub MaHoaNhanVienHanVon(ByVal arr As String, ByRef MaNV As String, ByRef MaFace As String)
        Dim a As String = Strings.Trim(arr)
        Dim Str As String = ")"
        Dim b() As String = Strings.Split(a, Str)
        MaFace = b(0)
        b = Strings.Split(b(0), "id=""")
        b = Strings.Split(b(1), """")
        MaNV = b(0)
    End Sub

    Private Sub cmdLuuNV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLuuNV.Click
        If MsgBox("Bạn có chắc là muốn lưu thông tin của những nhân viên này không?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        Dim BusNV As New nhanvienBus(DTOKetnoi, False)

        Dim busFaceNV As New nvvanBus(DTOKetnoi, False)

        For i As Integer = 0 To dgvTTNV.Rows.Count - 1
            Dim dto As New nhanviendto
            With dgvTTNV.Rows(i)
                dto.MaNV = .Cells("C_MaCC_NV1").Value
                dto.NVSP = .Cells("C_MaCC_NV1").Value
                dto.TenNV = "NV " & .Cells("C_MaCC_NV1").Value
                dto.TenHT = "NV " & .Cells("C_MaCC_NV1").Value
                dto.Donvi = 1
                dto.Chucvu = 1
                BusNV.Them(dto)

                Dim dtoface As New nvvandto
                dtoface.MaNV = .Cells("C_MaCC_NV1").Value
                dtoface.VanID = 0
                dtoface.ma = .Cells("C_VanTay_NV1").Value
                busFaceNV.ThemNoBinary(dtoface)
            End With

        Next

    End Sub

    Private Sub tt_chonAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tt_chonAll.Click
        For i As Integer = 0 To dgvNhanVien.Rows.Count - 1
            dgvNhanVien.Rows(i).Cells("C_Chon_NV2").Value = True
        Next
    End Sub

    Private Sub tt_daochon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tt_daochon.Click
        For i As Integer = 0 To dgvNhanVien.Rows.Count - 1
            If dgvNhanVien.Rows(i).Cells("C_Chon_NV2").Value = True Then
                dgvNhanVien.Rows(i).Cells("C_Chon_NV2").Value = False
            Else

                dgvNhanVien.Rows(i).Cells("C_Chon_NV2").Value = True


            End If
        Next
    End Sub

    Private Sub tt_xuatdl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tt_xuatdl.Click
        Dim sa As New SaveFileDialog
        sa.Filter = "Hanvon's user|*.txt"
        sa.FileName = "USERALL"
        If sa.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub
        Dim str As String = ""
        For i As Integer = 0 To dgvNhanVien.Rows.Count - 1
            If dgvNhanVien.Rows(i).Cells("C_Chon_NV2").Value = False Then Continue For
            str &= "Return(result=""success"" " & dgvNhanVien.Rows(i).Cells("C_MaVan_NV2").Value & ")" & Chr(13)
        Next

        Dim ghifile As New IO.StreamWriter(sa.FileName)
        ghifile.Write(str)
        ghifile.Dispose()
        ghifile.Close()
        MsgBox("Hoàn thành quá trình xuất dữ liệu!", MsgBoxStyle.Information, "Thông báo")

    End Sub
End Class