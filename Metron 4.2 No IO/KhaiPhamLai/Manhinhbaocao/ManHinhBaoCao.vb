'Cọ Việt Mỹ
Imports System.Runtime.InteropServices
Imports System.IO

Public Class ManHinhBaoCao
    ''''"""""""""""#############################################Cọ Việt Mỹ ##################################
    '#############################################################################################################33
    Dim busnvbc As New NVBCBus(DTOKetnoi, False)
    Dim busVaoRa As New VaoraBus(DTOKetnoi, False)
    Dim busca As New caBus(DTOKetnoi, False)
    Dim buscatd As New caTDBus(DTOKetnoi, False)
    Dim busNgayLe As New NgayleBus(DTOKetnoi, False)
    Dim busNVnghiphep As New NVnghiphepBus(DTOKetnoi, False)
    Dim mauThemca As Color = Color.Red
    Dim mauThemcanghi As Color = Color.Gray
    Dim DataCaLV As System.Data.DataTable
    Dim busThamso As New thamsoBus(DTOKetnoi, False)
    Dim daoNK As New NhatkyBus(DTOKetnoi, False)
    Dim dtoNK As New Nhatkydto
    Dim BusLichTam As New lichtamBus(DTOKetnoi, False)
    Dim busBangluong As New BangluongBus(DTOKetnoi, False)
    Dim dtoLichTam As New lichtamdto
    Dim tienantrua As Integer = 1
    Const CSCa1 = 1
    Const CSCa2 = 2
    Const CSCa3 = 3
    Const CSHC = 4
    Const CSHC1 = 5
    Const CSNgay = 6
    Const CSDem = 7
    Dim busphucapluong As New PhucapluongBus(DTOKetnoi, False)
    Dim dtoPhucapluong As New Phucapluongdto

#Region "Menu"
#Region "Hổ trợ"
    Private Sub ChepDongtrangNhatky()
        For i As Integer = 0 To DataGridViewNhatky.RowCount - 1
            Dim data As OleDb.OleDbDataReader = busVaoRa.LayBangtheoMACCvaNGAy(DataGridViewNhatky.Rows(i).Cells("DataGridViewTextBoxColumn56").Value, DataGridViewNhatky.Rows(i).Cells("DataGridViewTextBoxColumn61").Value)
            Try
                While data.Read
                    DataGridViewNhatky.Rows.InsertCopy(i, i + 1)
                    i += 1
                    DataGridViewNhatky.Rows(i).Cells(1).Value = DataGridViewNhatky.Rows(i - 1).Cells(1).Value
                    DataGridViewNhatky.Rows(i).Cells(2).Value = DataGridViewNhatky.Rows(i - 1).Cells(2).Value
                    DataGridViewNhatky.Rows(i).Cells(3).Value = DataGridViewNhatky.Rows(i - 1).Cells(3).Value
                    DataGridViewNhatky.Rows(i).Cells(4).Value = DataGridViewNhatky.Rows(i - 1).Cells(4).Value
                    DataGridViewNhatky.Rows(i).Cells(5).Value = DataGridViewNhatky.Rows(i - 1).Cells(5).Value
                    DataGridViewNhatky.Rows(i).Cells(6).Value = DataGridViewNhatky.Rows(i - 1).Cells(6).Value
                    DataGridViewNhatky.Rows(i).Cells(7).Value = data("thoigian")
                    DataGridViewNhatky.Rows(i).DefaultCellStyle.BackColor = DataGridViewNhatky.Rows(i - 1).DefaultCellStyle.BackColor
                    ToolStripProgressBar1.Value += 1
                    If ToolStripProgressBar1.Value = ToolStripProgressBar1.Maximum Then ToolStripProgressBar1.Value = 1
                End While
            Catch ex As Exception
                MsgBox(ex.Message, , "Thông báo")
            End Try
            ToolStripProgressBar1.Value += 1
            If ToolStripProgressBar1.Value = ToolStripProgressBar1.Maximum Then ToolStripProgressBar1.Value = 1
            data.Close()
        Next
    End Sub
#End Region
    
    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        'If MsgBox("Bạn muốn thoát ?", MsgBoxStyle.OkCancel, "Thông báo") Then
        Dim duongdan As String = ""
        'File tham so
        duongdan = My.Application.Info.DirectoryPath & "\Thamso.dll"
        Try
            File.Delete(duongdan)
        Catch ex As Exception
        End Try
        TaoFileBut(duongdan)
        'File Cot Tong hop
        duongdan = My.Application.Info.DirectoryPath & "\Datagridviewtonghop.dll"
        Try
            File.Delete(duongdan)
        Catch ex As Exception
        End Try
        TaoFileButBaocaoTonghop(duongdan)
        'File Cot chi tiet
        duongdan = My.Application.Info.DirectoryPath & "\Datagridviewchitiet.dll"
        Try
            File.Delete(duongdan)
        Catch ex As Exception
        End Try
        TaoFileButBaocaochitiet(duongdan)
        Me.Close()
        'End If
    End Sub
    Public Sub XemNVDCChon(Optional ByVal LuonMo As Boolean = False)
        If LuonMo = False Then
            Me.SplitContainer1.Panel1Collapsed = Not ToolStripButton5.Checked
            ToolStripButton5.Checked = Not ToolStripButton5.Checked
        Else
            Me.SplitContainer1.Panel1Collapsed = False
            ToolStripButton5.Checked = False
        End If
    End Sub
    Private Sub QuetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuetToolStripMenuItem.Click

        TabControl1.SelectedIndex = 5

        DataGridViewNhatky.DataSource = busVaoRa.laybangBaocaotuNGayvadenngay(DateTimePickerTungay.Value.Date, DateTimePickerDenngay.Value.Date)
    End Sub
    Private Sub NhậtKýNgàyNghĩToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NhậtKýNgàyNghĩToolStripMenuItem.Click
        DataGridViewNghi.DataSource = busNVnghiphep.LaybangTheoTungayDenNgayVaDieuKien(DateTimePickerTungay.Value, DateTimePickerDenngay.Value)
        TabControl1.SelectedIndex = 6
    End Sub
#End Region
#Region "Hổ trợ doc,ghi file"
    Private Sub DocFileBut(ByVal duongdanFile As String)
        Dim file As FileStream
        Dim reader As StreamReader
        Try
            file = New FileStream(duongdanFile, FileMode.Open)
            reader = New StreamReader(file)
            TextBoxHesoNCT.Text = reader.ReadLine()
            TextBoxtHesoNL.Text = reader.ReadLine()
            reader.Close()
            file.Close()
        Catch EX As Exception
        End Try
    End Sub
    Private Sub DocFileCotBaocaoTonghop(ByVal duongdanFile As String)
        Dim file As FileStream
        Dim reader As StreamReader
        Try
            file = New FileStream(duongdanFile, FileMode.Open)
            reader = New StreamReader(file)
            For i As Integer = 0 To DataGridViewTonghop.Columns.Count - 1
                DataGridViewTonghop.Columns(i).Visible = reader.ReadLine
            Next
            reader.Close()
            file.Close()
        Catch EX As Exception
        End Try
    End Sub
    Private Sub DocFileCotBaocaoChiTiet(ByVal duongdanFile As String)
        Dim file As FileStream
        Dim reader As StreamReader
        Try
            file = New FileStream(duongdanFile, FileMode.Open)
            reader = New StreamReader(file)
            For i As Integer = 0 To DataGridViewChiTiet.Columns.Count - 2
                DataGridViewChiTiet.Columns(i).Visible = reader.ReadLine
                DataGridViewNgayThuong.Columns(i).Visible = DataGridViewChiTiet.Columns(i).Visible
                DataGridViewNgayLe.Columns(i).Visible = DataGridViewChiTiet.Columns(i).Visible
                DataGridViewNgayCuoiTuan.Columns(i).Visible = DataGridViewChiTiet.Columns(i).Visible
            Next
            reader.Close()
            file.Close()
        Catch EX As Exception
        End Try
    End Sub
    Private Function TaoFileBut(ByVal duongdanFile As String) As String
        Dim file As FileStream
        Dim writer As StreamWriter
        Try
            file = New FileStream(duongdanFile, FileMode.CreateNew)
            writer = New StreamWriter(file)
            If IsNumeric(TextBoxHesoNCT.Text) Then
                writer.WriteLine(TextBoxHesoNCT.Text)
            Else
                writer.WriteLine(1.5)
            End If
            If IsNumeric(TextBoxtHesoNL.Text) Then
                writer.WriteLine(TextBoxtHesoNL.Text)
            Else
                writer.WriteLine(3)
            End If
            writer.Close()
            file.Close()
        Catch EX As Exception
            Return (EX.Message)
        End Try
        Return "1"
    End Function
    Private Function TaoFileButBaocaoTonghop(ByVal duongdanFile As String) As String
        Dim file As FileStream
        Dim writer As StreamWriter
        Try
            file = New FileStream(duongdanFile, FileMode.CreateNew)
            writer = New StreamWriter(file)
            For i As Integer = 0 To DataGridViewTonghop.Columns.Count - 1
                writer.WriteLine(DataGridViewTonghop.Columns(i).Visible)
            Next
            writer.Close()
            file.Close()
        Catch EX As Exception
            Return (EX.Message)
        End Try
        Return "1"
    End Function
    Private Function TaoFileButBaocaochitiet(ByVal duongdanFile As String) As String
        Dim file As FileStream
        Dim writer As StreamWriter
        Try
            file = New FileStream(duongdanFile, FileMode.CreateNew)
            writer = New StreamWriter(file)
            For i As Integer = 0 To DataGridViewChiTiet.Columns.Count - 2
                writer.WriteLine(DataGridViewChiTiet.Columns(i).Visible)
            Next
            writer.Close()
            file.Close()
        Catch EX As Exception
            Return (EX.Message)
        End Try
        Return "1"
    End Function
    Private Function Taobaocao1Excel(ByVal duongdanFile As String) As String
        ToolStripProgressBar1.Value = 1
        Dim file As FileStream
        Dim writer As StreamWriter
        Try
            file = New FileStream(duongdanFile, FileMode.CreateNew)
            writer = New StreamWriter(file, System.Text.Encoding.Unicode)
            DuaDLBaoCao()
            StatusStrip1.Visible = True
            ToolStripProgressBar1.Value = 0
            Dim Table1 As System.Data.DataTable
            Table1 = Me.DataSetTam1.Tables("DataTable1")
            ToolStripProgressBar1.Maximum = Table1.Rows.Count + 1
            writer.Write("STT" & vbTab)
            writer.Write("Tên nhân viên" & vbTab)
            writer.Write("Mã NV" & vbTab)
            writer.Write("Bộ phận" & vbTab)
            Dim MNgay As Date
            For i As Integer = 0 To 30
                MNgay = DateAdd(DateInterval.Day, i, Me.DateTimePickerTungay.Value)
                writer.Write(MNgay.Day & vbTab)
            Next
            writer.WriteLine()
            For i As Integer = 0 To Table1.Rows.Count - 1
                writer.Write(i + 1 & vbTab)
                For j As Integer = 0 To Table1.Columns.Count - 1
                    writer.Write(Table1.Rows(i).Item(j) & vbTab)
                Next
                writer.WriteLine()
                Try
                    ToolStripProgressBar1.Value += 1
                Catch ex As Exception
                    ToolStripProgressBar1.Value = 0
                End Try
            Next
            writer.Close()
            file.Close()
        Catch EX As Exception
            Return (EX.Message)
        End Try
        Return "1"
    End Function
    Private Function TaobaocaoExcel(ByVal duongdanFile As String, ByVal dGrid As DataGridView) As String
        ToolStripProgressBar1.Value = 1
        Dim file As FileStream
        Dim writer As StreamWriter
        Try
            file = New FileStream(duongdanFile, FileMode.CreateNew)
            writer = New StreamWriter(file, System.Text.Encoding.Unicode)
            For i As Integer = 0 To dGrid.Columns.Count - 2
                If dGrid.Columns(i).Visible Then writer.Write(dGrid.Columns(i).HeaderText & vbTab)
            Next
            writer.WriteLine("")
            For i As Integer = 0 To dGrid.Rows.Count - 1
                For j As Integer = 0 To dGrid.Columns.Count - 2
                    If dGrid.Columns(j).Visible Then writer.Write(dGrid.Rows(i).Cells(j).Value & vbTab)
                Next
                writer.WriteLine("")
                Try
                    ToolStripProgressBar1.Value += 1
                Catch ex As Exception
                    ToolStripProgressBar1.Value = 0
                End Try
            Next
            writer.Close()
            file.Close()
        Catch EX As Exception
            Return (EX.Message)
        End Try
        Return "1"
    End Function
    Private Function TaobaocaoExcelChitiet(ByVal duongdanFile As String, ByVal dGrid As DataGridView) As String
        ToolStripProgressBar1.Value = 1
        Dim file As FileStream
        Dim writer As StreamWriter
        Try
            file = New FileStream(duongdanFile, FileMode.CreateNew)
            writer = New StreamWriter(file, System.Text.Encoding.Unicode)
            For i As Integer = 0 To dGrid.Columns.Count - 2
                If dGrid.Columns(i).Visible Then writer.Write(dGrid.Columns(i).HeaderText & vbTab)
            Next
            writer.WriteLine("")
            For i As Integer = 0 To dGrid.Rows.Count - 1
                For j As Integer = 0 To dGrid.Columns.Count - 2
                    If j = 7 Or j = 8 Then
                        If dGrid.Columns(j).Visible And CStr(dGrid.Rows(i).Cells(j).Value) <> "" Then
                            'writer.Write(dGrid.Rows(i).Cells(j).Value.ToLongTimeString & vbTab)
                            writer.Write(dGrid.Rows(i).Cells(j).Value & vbTab)
                        End If
                    Else
                        If dGrid.Columns(j).Visible Then writer.Write(dGrid.Rows(i).Cells(j).Value & vbTab)
                    End If
                Next
                writer.WriteLine("")
                Try
                    ToolStripProgressBar1.Value += 1
                Catch ex As Exception
                    ToolStripProgressBar1.Value = 0
                End Try


            Next
            writer.Close()
            file.Close()
        Catch EX As Exception
            Return (EX.Message)
        End Try
        Return "1"
    End Function
#End Region


#Region "Kiem loi"
    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxHesoNCT.TextChanged
        ToolStrip1.Enabled = IsNumeric(TextBoxHesoNCT.Text)
        If Not ToolStrip1.Enabled Then
            ErrorProvider1.SetError(TextBoxHesoNCT, "Bạn phải nhập số")
        Else
            ErrorProvider1.SetError(TextBoxHesoNCT, "")
        End If
    End Sub
    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxtHesoNL.TextChanged
        ToolStrip1.Enabled = IsNumeric(TextBoxtHesoNL.Text)
        If Not ToolStrip1.Enabled Then
            ErrorProvider1.SetError(TextBoxtHesoNL, "Bạn phải nhập số")
        Else
            ErrorProvider1.SetError(TextBoxtHesoNL, "")
        End If
    End Sub
#End Region
#Region "Tính Công"
#Region "Hô trơ tính công tổng hợp"
    Private Sub TinhCongBaoCao(ByVal dong As Integer, ByRef BaoCaoTH As BaoCaoTongHop)
        If (dong = 0) Then
            If (Strings.Len(Strings.Trim(DataGridViewChiTiet.Rows(dong).Cells("giovao").Value)) > 0) Then BaoCaoTH.songay += 1

        ElseIf (DataGridViewChiTiet.Rows(dong).Cells("ngaychamcong").Value <> DataGridViewChiTiet.Rows(dong - 1).Cells("ngaychamcong").Value) And _
                (DataGridViewChiTiet.Rows(dong - 1).Cells("macc").Value = DataGridViewChiTiet.Rows(dong).Cells("macc").Value) _
                And (Strings.Len(Strings.Trim(DataGridViewChiTiet.Rows(dong).Cells("giovao").Value)) > 0) Then
            BaoCaoTH.songay += 1

        ElseIf (DataGridViewChiTiet.Rows(dong - 1).Cells("macc").Value <> DataGridViewChiTiet.Rows(dong).Cells("macc").Value) Then
            If (Strings.Len(Strings.Trim(DataGridViewChiTiet.Rows(dong).Cells("giovao").Value)) > 0) Then BaoCaoTH.songay += 1
        End If
        If IsDBNull(DataGridViewChiTiet.Rows(dong).Cells("giovao").Value) Or CStr(DataGridViewChiTiet.Rows(dong).Cells("giovao").Value) = "" Then

        Else
            BaoCaoTH.sogio += DataGridViewChiTiet.Rows(dong).Cells("sogio").Value
            If DataGridViewChiTiet.Rows(dong).Cells("ditre").Value > 0 Then BaoCaoTH.solanditre += 1
            BaoCaoTH.ditre += DataGridViewChiTiet.Rows(dong).Cells("ditre").Value
            If DataGridViewChiTiet.Rows(dong).Cells("vesom").Value > 0 Then BaoCaoTH.solanvesom += 1
            BaoCaoTH.vesom += DataGridViewChiTiet.Rows(dong).Cells("vesom").Value
            BaoCaoTH.tangca += DataGridViewChiTiet.Rows(dong).Cells("tangca").Value ' + DataGridViewChiTiet.Rows(dong).Cells("tangcaT").Value
            'BaoCaoTH.TangcaTruoc += DataGridViewChiTiet.Rows(dong).Cells("tangcaT").Value ' Có tính tổng nhưng chưa show
            BaoCaoTH.socong += DataGridViewChiTiet.Rows(dong).Cells("socong").Value
        End If
    End Sub
    Private Sub TinhCongBaoCaoNT(ByVal dong As Integer, ByRef BaoCaoTH As BaoCaoTongHop)

        If (dong = 0) Then
            If (Strings.Len(Strings.Trim(DataGridViewChiTiet.Rows(dong).Cells("giovao").Value)) > 0) Then BaoCaoTH.songaythuong += 1

        ElseIf (DataGridViewChiTiet.Rows(dong).Cells("ngaychamcong").Value <> DataGridViewChiTiet.Rows(dong - 1).Cells("ngaychamcong").Value) And _
                (DataGridViewChiTiet.Rows(dong - 1).Cells("macc").Value = DataGridViewChiTiet.Rows(dong).Cells("macc").Value) _
                And (Strings.Len(Strings.Trim(DataGridViewChiTiet.Rows(dong).Cells("giovao").Value)) > 0) Then
            BaoCaoTH.songaythuong += 1

        ElseIf (DataGridViewChiTiet.Rows(dong - 1).Cells("macc").Value <> DataGridViewChiTiet.Rows(dong).Cells("macc").Value) Then
            If (Strings.Len(Strings.Trim(DataGridViewChiTiet.Rows(dong).Cells("giovao").Value)) > 0) Then BaoCaoTH.songaythuong += 1
        End If
        BaoCaoTH.SoNgayNghiKoPhep += DataGridViewChiTiet.Rows(dong).Cells("NghiNuaBuoi").Value
        If IsDBNull(DataGridViewChiTiet.Rows(dong).Cells("giovao").Value) Or CStr(DataGridViewChiTiet.Rows(dong).Cells("giovao").Value) = "" Then
            'BaoCaoTH.SoNgayNghiKoPhep += 1
        Else
            BaoCaoTH.sogioNT += DataGridViewChiTiet.Rows(dong).Cells("sogio").Value
            If DataGridViewChiTiet.Rows(dong).Cells("ditre").Value > 0 Then BaoCaoTH.solanditreNT += 1
            BaoCaoTH.ditreNT += DataGridViewChiTiet.Rows(dong).Cells("ditre").Value
            If DataGridViewChiTiet.Rows(dong).Cells("vesom").Value > 0 Then BaoCaoTH.solanvesomNT += 1
            BaoCaoTH.vesomNT += DataGridViewChiTiet.Rows(dong).Cells("vesom").Value
            BaoCaoTH.tangcaNT += DataGridViewChiTiet.Rows(dong).Cells("tangca").Value ' + DataGridViewChiTiet.Rows(dong).Cells("tangcaT").Value
            BaoCaoTH.TongTienAn += DataGridViewChiTiet.Rows(dong).Cells("TienAnTC").Value
            BaoCaoTH.socongNT += DataGridViewChiTiet.Rows(dong).Cells("socong").Value
            BaoCaoTH.TienComTrua += CInt(DataGridViewChiTiet.Rows(dong).Cells("TienAn").Value)
            BaoCaoTH.NgayGuiXe += CInt(DataGridViewChiTiet.Rows(dong).Cells("tienxe").Value)
        End If
    End Sub

    Private Sub TinhCongBaoCaoNL(ByVal dong As Integer, ByRef BaoCaoTH As BaoCaoTongHop)
        If (dong = 0) Then
            If (Strings.Len(Strings.Trim(DataGridViewChiTiet.Rows(dong).Cells("giovao").Value)) > 0) Then BaoCaoTH.songayle += 1

        ElseIf (DataGridViewChiTiet.Rows(dong).Cells("ngaychamcong").Value <> DataGridViewChiTiet.Rows(dong - 1).Cells("ngaychamcong").Value) And _
                (DataGridViewChiTiet.Rows(dong - 1).Cells("macc").Value = DataGridViewChiTiet.Rows(dong).Cells("macc").Value) _
                And (Strings.Len(Strings.Trim(DataGridViewChiTiet.Rows(dong).Cells("giovao").Value)) > 0) Then
            BaoCaoTH.songayle += 1

        ElseIf (DataGridViewChiTiet.Rows(dong - 1).Cells("macc").Value <> DataGridViewChiTiet.Rows(dong).Cells("macc").Value) Then
            If (Strings.Len(Strings.Trim(DataGridViewChiTiet.Rows(dong).Cells("giovao").Value)) > 0) Then BaoCaoTH.songayle += 1

        End If


        If IsDBNull(DataGridViewChiTiet.Rows(dong).Cells("giovao").Value) Or CStr(DataGridViewChiTiet.Rows(dong).Cells("giovao").Value) = "" Then
        Else
            BaoCaoTH.sogioNL += DataGridViewChiTiet.Rows(dong).Cells("sogio").Value
            If DataGridViewChiTiet.Rows(dong).Cells("ditre").Value > 0 Then BaoCaoTH.solanditreNL += 1
            BaoCaoTH.ditreNL += DataGridViewChiTiet.Rows(dong).Cells("ditre").Value
            If DataGridViewChiTiet.Rows(dong).Cells("vesom").Value > 0 Then BaoCaoTH.solanvesomNL += 1
            BaoCaoTH.vesomNL += DataGridViewChiTiet.Rows(dong).Cells("vesom").Value
            BaoCaoTH.tangcaNL += DataGridViewChiTiet.Rows(dong).Cells("tangca").Value ' + DataGridViewChiTiet.Rows(dong).Cells("tangcaT").Value
            BaoCaoTH.TongTienAn += DataGridViewChiTiet.Rows(dong).Cells("TienAnTC").Value
            BaoCaoTH.socongNL += DataGridViewChiTiet.Rows(dong).Cells("socong").Value
            BaoCaoTH.TienComTrua += CInt(DataGridViewChiTiet.Rows(dong).Cells("TienAn").Value)
            BaoCaoTH.NgayGuiXe += CInt(DataGridViewChiTiet.Rows(dong).Cells("tienxe").Value)
        End If
        ToolStripProgressBar1.Value += 1
        If ToolStripProgressBar1.Value = ToolStripProgressBar1.Maximum Then ToolStripProgressBar1.Value = 1
    End Sub
    Private Sub TinhCongBaoCaoNCT(ByVal dong As Integer, ByRef BaoCaoTH As BaoCaoTongHop)

        If (dong = 0) Then
            If (Strings.Len(Strings.Trim(DataGridViewChiTiet.Rows(dong).Cells("giovao").Value)) > 0) Then BaoCaoTH.songaycuoituan += 1

        ElseIf (DataGridViewChiTiet.Rows(dong).Cells("ngaychamcong").Value <> DataGridViewChiTiet.Rows(dong - 1).Cells("ngaychamcong").Value) And _
                (DataGridViewChiTiet.Rows(dong - 1).Cells("macc").Value = DataGridViewChiTiet.Rows(dong).Cells("macc").Value) _
                And (Strings.Len(Strings.Trim(DataGridViewChiTiet.Rows(dong).Cells("giovao").Value)) > 0) Then
            BaoCaoTH.songaycuoituan += 1

        ElseIf (DataGridViewChiTiet.Rows(dong - 1).Cells("macc").Value <> DataGridViewChiTiet.Rows(dong).Cells("macc").Value) Then
            If (Strings.Len(Strings.Trim(DataGridViewChiTiet.Rows(dong).Cells("giovao").Value)) > 0) Then BaoCaoTH.songaycuoituan += 1

        End If


        If IsDBNull(DataGridViewChiTiet.Rows(dong).Cells("giovao").Value) Or CStr(DataGridViewChiTiet.Rows(dong).Cells("giovao").Value) = "" Then
        Else
            BaoCaoTH.sogioNCT += DataGridViewChiTiet.Rows(dong).Cells("sogio").Value
            If DataGridViewChiTiet.Rows(dong).Cells("ditre").Value > 0 Then BaoCaoTH.solanditreNCT += 1
            BaoCaoTH.ditreNCT += DataGridViewChiTiet.Rows(dong).Cells("ditre").Value
            If DataGridViewChiTiet.Rows(dong).Cells("vesom").Value > 0 Then BaoCaoTH.solanvesomNCT += 1
            BaoCaoTH.vesomNCT += DataGridViewChiTiet.Rows(dong).Cells("vesom").Value
            BaoCaoTH.tangcaNCT += DataGridViewChiTiet.Rows(dong).Cells("tangca").Value '+ DataGridViewChiTiet.Rows(dong).Cells("tangcaT").Value
            BaoCaoTH.TongTienAn += DataGridViewChiTiet.Rows(dong).Cells("TienAnTC").Value
            BaoCaoTH.socongNCT += DataGridViewChiTiet.Rows(dong).Cells("socong").Value
            BaoCaoTH.TienComTrua += CInt(DataGridViewChiTiet.Rows(dong).Cells("TienAn").Value)
            BaoCaoTH.NgayGuiXe += CInt(DataGridViewChiTiet.Rows(dong).Cells("tienxe").Value)
        End If
    End Sub
    Private Sub ganBangtonghop(ByVal k As Integer, ByVal baocaoth As BaoCaoTongHop)
        DataGridViewTonghop.Rows(k).Cells(0).Value = k + 1
        DataGridViewTonghop.Rows(k).Cells("Column6").Value = baocaoth.songay
        DataGridViewTonghop.Rows(k).Cells("Column7").Value = baocaoth.songaythuong
        DataGridViewTonghop.Rows(k).Cells("Column8").Value = baocaoth.songayle
        DataGridViewTonghop.Rows(k).Cells("Column9").Value = baocaoth.songaycuoituan
        DataGridViewTonghop.Rows(k).Cells("Column38").Value = baocaoth.Songaynghiphep
        DataGridViewTonghop.Rows(k).Cells("Column46").Value = baocaoth.SoNgayNghiKoPhep
        DataGridViewTonghop.Rows(k).Cells("Column10").Value = baocaoth.sogio
        DataGridViewTonghop.Rows(k).Cells("Column11").Value = baocaoth.sogioNT
        DataGridViewTonghop.Rows(k).Cells("Column12").Value = baocaoth.sogioNL
        DataGridViewTonghop.Rows(k).Cells("Column13").Value = baocaoth.sogioNCT
        DataGridViewTonghop.Rows(k).Cells("Column14").Value = baocaoth.solanditre
        DataGridViewTonghop.Rows(k).Cells("Column15").Value = baocaoth.solanditreNT
        DataGridViewTonghop.Rows(k).Cells("Column16").Value = baocaoth.solanditreNL
        DataGridViewTonghop.Rows(k).Cells("Column17").Value = baocaoth.solanditreNCT
        DataGridViewTonghop.Rows(k).Cells("Column18").Value = baocaoth.ditre
        DataGridViewTonghop.Rows(k).Cells("Column19").Value = baocaoth.ditreNT
        DataGridViewTonghop.Rows(k).Cells("Column20").Value = baocaoth.ditreNL
        DataGridViewTonghop.Rows(k).Cells("Column21").Value = baocaoth.ditreNCT
        DataGridViewTonghop.Rows(k).Cells("Column22").Value = baocaoth.solanvesom
        DataGridViewTonghop.Rows(k).Cells("Column23").Value = baocaoth.solanvesomNT
        DataGridViewTonghop.Rows(k).Cells("Column24").Value = baocaoth.solanvesomNL
        DataGridViewTonghop.Rows(k).Cells("Column25").Value = baocaoth.solanvesomNCT
        DataGridViewTonghop.Rows(k).Cells("Column26").Value = baocaoth.vesom
        DataGridViewTonghop.Rows(k).Cells("Column27").Value = baocaoth.vesomNT
        DataGridViewTonghop.Rows(k).Cells("Column28").Value = baocaoth.vesomNL
        DataGridViewTonghop.Rows(k).Cells("Column29").Value = baocaoth.vesomNCT
        DataGridViewTonghop.Rows(k).Cells("Column30").Value = baocaoth.tangca
        DataGridViewTonghop.Rows(k).Cells("Column31").Value = baocaoth.tangcaNT
        DataGridViewTonghop.Rows(k).Cells("Column32").Value = baocaoth.tangcaNL
        DataGridViewTonghop.Rows(k).Cells("Column33").Value = baocaoth.tangcaNCT
        DataGridViewTonghop.Rows(k).Cells("Column34").Value = Format(baocaoth.socong, "##0.##")
        DataGridViewTonghop.Rows(k).Cells("Column35").Value = Format(baocaoth.socongNT, "##0.##")
        DataGridViewTonghop.Rows(k).Cells("Column36").Value = Format(baocaoth.socongNL, "##0.##")
        DataGridViewTonghop.Rows(k).Cells("Column37").Value = Format(baocaoth.socongNCT, "##0.##")
        DataGridViewTonghop.Rows(k).Cells("Column39").Value = Format(baocaoth.socongNghiPhep, "##0.##")
        DataGridViewTonghop.Rows(k).Cells("Column40").Value = Format(baocaoth.socongSaucong, "##0.##")
        DataGridViewTonghop.Rows(k).Cells("TienAnTangCa").Value = Format(baocaoth.TongTienAn, "#,##0")
        DataGridViewTonghop.Rows(k).Cells("TienComTrua").Value = baocaoth.TienComTrua
        DataGridViewTonghop.Rows(k).Cells("Column52").Value = baocaoth.NgayGuiXe
    End Sub
    Private Sub ThemDongtrangNhatky()
        For i As Integer = 0 To DataGridViewNhanVien.RowCount - 1
            Dim ngay As Date = DateTimePickerTungay.Value.Date
            Do
                Dim j As Integer = DataGridViewNhatky.Rows.Add()
                DataGridViewNhatky.Rows(j).Cells(1).Value = DataGridViewNhanVien.Rows(i).Cells("Column1").Value
                DataGridViewNhatky.Rows(j).Cells(2).Value = DataGridViewNhanVien.Rows(i).Cells("Column2").Value
                DataGridViewNhatky.Rows(j).Cells(3).Value = DataGridViewNhanVien.Rows(i).Cells("Column3").Value
                DataGridViewNhatky.Rows(j).Cells(4).Value = DataGridViewNhanVien.Rows(i).Cells("Column4").Value
                DataGridViewNhatky.Rows(j).Cells(5).Value = DataGridViewNhanVien.Rows(i).Cells("Column5").Value
                DataGridViewNhatky.Rows(j).Cells(6).Value = ngay
                ToolStripProgressBar1.Value += 1
                If ToolStripProgressBar1.Value = ToolStripProgressBar1.Maximum Then ToolStripProgressBar1.Value = 1
                If i Mod 2 = 0 Then
                    DataGridViewNhatky.Rows(j).DefaultCellStyle.BackColor = Color.White
                Else
                    DataGridViewNhatky.Rows(j).DefaultCellStyle.BackColor = Color.LightGray
                End If
                If ngay = DateTimePickerDenngay.Value.Date Then Exit Do
                ngay = DateAdd(DateInterval.DayOfYear, 1, ngay)
            Loop
        Next
    End Sub
#End Region
#Region "Hổ trợ tính công chi tiết"
    Private Function Laybangca(ByVal ca As Integer, ByVal data As IList) As cadto
        Dim dto As New cadto
        For i As Integer = 0 To data.Count - 1
            If data.Item(i).ID = ca Then Return data.Item(i)
        Next
        Return dto
    End Function
    Private Sub ThemLuoiKhac()
        DataGridViewNgayLe.Rows.Clear()
        DataGridViewNgayCuoiTuan.Rows.Clear()
        DataGridViewNgayThuong.Rows.Clear()
        Dim data As System.Data.DataTable = busNgayLe.LayBangTable(DateTimePickerTungay.Value, DateTimePickerDenngay.Value)
        For i As Integer = 0 To DataGridViewChiTiet.Rows.Count - 1
            'Tạo dòng bảng Khác
            If kiemtrangayle(DataGridViewChiTiet.Rows(i).Cells("ngaychamcong").Value, data) Then
                ChepDong(DataGridViewNgayLe, i)
                DataGridViewChiTiet.Rows(i).Cells("ghichu").Value = 2
            ElseIf Weekday(DataGridViewChiTiet.Rows(i).Cells("ngaychamcong").Value) = 1 Then
                ChepDong(DataGridViewNgayCuoiTuan, i)
                DataGridViewChiTiet.Rows(i).Cells("ghichu").Value = 1
            Else
                ChepDong(DataGridViewNgayThuong, i)
                DataGridViewChiTiet.Rows(i).Cells("ghichu").Value = 0
            End If
            Try
                ToolStripProgressBar1.Value += 1
            Catch ex As Exception
                ToolStripProgressBar1.Value = 0
            End Try

            If ToolStripProgressBar1.Value = ToolStripProgressBar1.Maximum Then ToolStripProgressBar1.Value = 1
        Next
    End Sub
    Private Sub ChepDong(ByVal DGV As DataGridView, ByVal dong As Integer)
        Dim j As Integer = DGV.Rows.Add()
        For i As Integer = 0 To DataGridViewChiTiet.ColumnCount - 5
            DGV.Rows(j).Cells(i).Value = DataGridViewChiTiet.Rows(dong).Cells(i).Value
        Next
        DGV.Rows(j).DefaultCellStyle.BackColor = DataGridViewChiTiet.Rows(dong).DefaultCellStyle.BackColor
    End Sub
    Private Function kiemtrangayle(ByVal Ngay As Date, ByVal data As System.Data.DataTable) As Boolean
        For i As Integer = 0 To data.Rows.Count - 1
            Dim dto As Ngayledto = busNgayLe.LayBangDTo(i, data)
            If dto.Ngay.Date = Ngay.Date Then Return True
        Next
        Return False
    End Function

    Private Sub KiemTraLichTam(ByVal DataLichTam As IList, ByVal NgayKT As Date, ByRef TTCa As ThongTinLichTam, ByRef KQ As Integer)
        KQ = -1
        For VitriTam As Integer = 0 To DataLichTam.Count - 1

            If (NgayKT >= DataLichTam.Item(VitriTam).tungay.date) And _
                (NgayKT <= DataLichTam.Item(VitriTam).denngay.date) Then
                If DataLichTam.Item(VitriTam).cadem = True Then
                    If DataLichTam.Item(VitriTam).tungay.date = NgayKT.Date Then
                        KQ = 1
                    Else
                        KQ = 2
                    End If
                    
                Else
                    KQ = 0
                End If
                TTCa = DataLichTam.Item(VitriTam)
                VitriTam += 1
                Exit For
            End If
        Next

    End Sub
    Private Function KiemTraCaTuDongQuaDem(ByVal macc As Integer) As Boolean
        Dim quadem As Boolean = False
        Dim dt As IList
        dt = buscatd.LayBangTableCaTheonvId(macc)
        For i As Integer = 0 To dt.Count - 1
            If dt.Item(i).batdau > dt.Item(i).ketthuc Then
                quadem = True
                Exit For
            Else
                quadem = False
            End If
        Next
        Return quadem
    End Function
    Private Function ChuyenGioThanhCong(ByVal Gio As Double) As Double
        If Gio >= 7 Then
            ChuyenGioThanhCong = 1
        ElseIf Gio > 6 Then
            ChuyenGioThanhCong = 0.75
        ElseIf Gio > 2 Then
            ChuyenGioThanhCong = 0.5
        Else
            ChuyenGioThanhCong = 0
        End If
    End Function
    'Private Sub XacDinhGioVao(ByVal dataca As ArrayList)
    '    For k As Integer = 0 To dataca.Count - 1
    '        If dataca.Item(j).Id <> 0 Then
    '            khoangcach = kiemtraKhoangCach2(i, dataca.Item(j))
    '            'khoangcach = kiemtraKhoangCach1(i, datachon.Item(j))
    '            If khoangcach < min Then
    '                min = khoangcach
    '                cachon.ID = datachon.Item(j).id
    '                cachon.TenCa = datachon.Item(j).tenca
    '                cachon.BatDau = datachon.Item(j).BatDau
    '                cachon.KetThuc = datachon.Item(j).Ketthuc
    '                cachon.Tgvao1 = datachon.Item(j).tgvao1
    '                cachon.Tgvao2 = datachon.Item(j).tgvao2
    '                cachon.Som = datachon.Item(j).som
    '                cachon.Tre = datachon.Item(j).tre
    '                cachon.SoPhut = datachon.Item(j).sophut
    '                cachon.NgayCong = datachon.Item(j).NgayCong
    '                cachon.mau = datachon.Item(j).mau
    '                cachon.TangCa = datachon.Item(j).tangca
    '                cachon.TangCaS = datachon.Item(j).tangcaS
    '                cachon.GHTangCa = datachon.Item(j).ghTangca

    '            End If
    '        End If
    '    Next
    'End Sub
    Private Sub ThemDongtrang()

        Dim VtriData As Integer = 0
        Dim data As IList
        Dim j As Integer
        Dim DataLichTam As IList
        Dim TTVao As Boolean
        Me.ToolStripProgressBar1.Value = 0
        Dim KQKTTam As Integer
        Dim TGTruoc As Date = #1/1/1900#
        Dim TTCa As New ThongTinLichTam
        Me.ToolStripProgressBar1.Maximum = Me.DataGridViewNhanVien.RowCount * (DateDiff(DateInterval.Day, Me.DateTimePickerTungay.Value, Me.DateTimePickerDenngay.Value) + 1)
        Dim DataBC As Data.DataRow
        ManhinhBCCong.DataSetTam.Tables("BaoCaoBT").Rows.Clear()

        For i As Integer = 0 To DataGridViewNhanVien.RowCount - 1

            DataLichTam = BusLichTam.LayLichTamTheoBangArrayThoiGian(CInt(Me.DataGridViewNhanVien.Item("Column1", i).Value), Me.DateTimePickerTungay.Value, DateAdd(DateInterval.Day, 1, Me.DateTimePickerDenngay.Value))

            TTVao = True
            Dim ngay As Date = DateTimePickerTungay.Value.Date
            VtriData = 0
            data = busVaoRa.LayBangArrayListtheoMACCvaTUNGAYvaDENNGAY(CInt(Me.DataGridViewNhanVien.Item("Column1", i).Value), Me.DateTimePickerTungay.Value, DateAdd(DateInterval.Day, 1, Me.DateTimePickerDenngay.Value))
            Try
                Me.ToolStripProgressBar1.Value += 1
            Catch ex As Exception
                Me.ToolStripProgressBar1.Value = 0
            End Try
            'Dim dataca As ArrayList = buscatd.LayBangTableCaTheonvId(DataGridViewChiTiet.Rows(i).Cells("macc").Value)

            DataBC = ManhinhBCCong.DataSetTam.Tables("BaoCaoBT").NewRow

            Do
ThemDong:
                j = DataGridViewChiTiet.Rows.Add()
                DataGridViewChiTiet.Rows(j).Cells("Macc").Value = DataGridViewNhanVien.Rows(i).Cells("Column1").Value
                DataGridViewChiTiet.Rows(j).Cells("manv").Value = DataGridViewNhanVien.Rows(i).Cells("Column2").Value
                DataGridViewChiTiet.Rows(j).Cells("tennv").Value = DataGridViewNhanVien.Rows(i).Cells("Column3").Value
                DataGridViewChiTiet.Rows(j).Cells("chucvu").Value = DataGridViewNhanVien.Rows(i).Cells("Column4").Value
                DataGridViewChiTiet.Rows(j).Cells("bophan").Value = DataGridViewNhanVien.Rows(i).Cells("Column5").Value
                DataGridViewChiTiet.Rows(j).Cells("ngaychamcong").Value = ngay

                KiemTraLichTam(DataLichTam, ngay, TTCa, KQKTTam)
                TTVao = True
                TGTruoc = #1/1/1900#

BDDocDL:
                If VtriData > data.Count - 1 Then GoTo Thoat

                If KQKTTam = 2 Then
LocTam1:            If data.Count - 1 > VtriData Then
                        If data.Item(VtriData + 1).Thoigian.date = ngay Then
                            VtriData += 1
                            GoTo LocTam1
                            TTVao = True
                        End If

                    End If
                End If
            
                If TGTruoc = #1/1/1900# Then
                    TTVao = True
                Else
                    If DateDiff(DateInterval.Minute, TGTruoc, data.Item(VtriData).thoigian) <= 5 Then
                        VtriData += 1
                        GoTo BDDocDL
                    End If
                End If
                ''****'''''
                'For k As Integer = 0 To dataca.Count - 1
                '    If dataca.Item(k).Id <> 0 Then
                '        'Dim a As Integer = Math.Abs(DateDiff(DateInterval.Minute, data.Item(VtriData).Thoigian.date & " " & dataca.Item(k)..ToLongTimeString, DataGridViewChiTiet.Rows(dong).Cells("giovao").Value))

                '    End If
                'Next


                ''''*****''''
                Select Case TTVao
                    Case True
                        'kiemtraKhoangCach2(j, DataBC)
                        Dim a As Date = data.Item(VtriData).Thoigian.date
                        If ngay.Date = data.Item(VtriData).Thoigian.date Then
                            If Strings.Len(Strings.Trim(DataGridViewChiTiet.Item("giovao", j).Value)) = 0 Then
                                DataGridViewChiTiet.Item("giovao", j).Value = data.Item(VtriData).Thoigian
                                TGTruoc = data.Item(VtriData).Thoigian
                                If data.Item(VtriData).kieu < 0 Then
                                    DataGridViewChiTiet.Item("giovao", j).Style.BackColor = Color.Red
                                    DataGridViewChiTiet.Item("giovao", j).Style.ForeColor = Color.White
                                End If
                                VtriData += 1
                                TTVao = False
                                GoTo BDDocDL
                            Else
                                If ngay.Date > Me.DateTimePickerDenngay.Value.Date Then GoTo Thoat
                                GoTo ThemDong
                            End If
                        End If

                    Case False

                        If KQKTTam < 0 And (data.Item(VtriData).Thoigian.date <> Me.DataGridViewChiTiet.Item("ngaychamcong", j).Value.date) Then
                            TTVao = True
                            GoTo BDDocDL
                        End If

                        If DateDiff(DateInterval.Hour, TGTruoc, data.Item(VtriData).Thoigian) > 18 Then
                            TTVao = True
                            GoTo BDDocDL
                        End If
                        'If (data.Item(VtriData).Thoigian.date <> Me.DataGridViewChiTiet.Item("ngaychamcong", j).Value.date) Then
                        '    If KiemTraCaTuDongQuaDem(DataGridViewChiTiet.Item("macc", j).Value) = False Then
                        '        GoTo ThemDong
                        '    End If
                        'End If
                        'If DateDiff(DateInterval.Hour, TGTruoc, data.Item(VtriData).Thoigian) > 23 Then
                        '    TTVao = True
                        '    'MsgBox(DateDiff(DateInterval.Hour, TGTruoc, data.Item(VtriData).Thoigian))
                        '    GoTo BDDocDL
                        'End If
                        Me.DataGridViewChiTiet.Item("giora", j).Value = data.Item(VtriData).Thoigian
                        TGTruoc = data.Item(VtriData).Thoigian

                        If data.Item(VtriData).kieu < 0 Then
                            DataGridViewChiTiet.Item("giora", j).Style.BackColor = Color.Red
                            DataGridViewChiTiet.Item("giora", j).Style.ForeColor = Color.White
                        End If


                        If Strings.Len(Strings.Trim(Me.DataGridViewChiTiet.Item("giovao", j).Value)) <> 0 Then

                            If KQKTTam >= 0 Then
                                gangiatriCaTam(j, TTCa, IIf(KQKTTam > 0, True, False), DataLichTam)
                            Else
                                gangiatri(j, DataBC)

                            End If
                        End If
                        VtriData += 1
                        TTVao = True
                        If data.Count - 1 <= VtriData Then
                            GoTo Thoat
                        Else
                            If data.Item(VtriData - 1).Thoigian.date = data.Item(VtriData).Thoigian.date Then
                                If KQKTTam >= 0 Then
                                    GoTo Thoat
                                Else

                                    GoTo ThemDong
                                End If

                            Else
                                GoTo Thoat
                            End If
                        End If
                        'If data.Count - 1 < VtriData Then
                        '    GoTo Thoat
                        'Else
                        '    If data.Item(VtriData - 1).Thoigian.date = data.Item(VtriData).Thoigian.date And data.Item(VtriData).Thoigian.date = ngay Then
                        '        If DateDiff(DateInterval.Minute, TGTruoc, data.Item(VtriData).thoigian) <= 15 Then
                        '            TTVao = True
                        '            GoTo BDDocDL
                        '        Else
                        '            GoTo ThemDong
                        '        End If
                        '        'GoTo ThemDong
                        '    Else
                        '        If DateDiff(DateInterval.Minute, TGTruoc, data.Item(VtriData).thoigian) <= 15 Then
                        '            TTVao = True
                        '            GoTo BDDocDL
                        '        Else
                        '            'GoTo ThemDong
                        '            GoTo Thoat
                        '        End If
                        '        'GoTo Thoat
                        '    End If
                        '    'GoTo BDDocDL
                        'End If

                End Select


Thoat:

                If ngay.Date = DateTimePickerDenngay.Value.Date And KQKTTam > 0 Then
                    ngay = DateAdd(DateInterval.Day, 1, ngay)
                    GoTo BDDocDL
                End If


                ngay = DateAdd(DateInterval.Day, 1, ngay)

            Loop Until ngay.Date > DateTimePickerDenngay.Value.Date

            DataBC("TenNV") = DataGridViewNhanVien.Rows(i).Cells("Column3").Value
            DataBC("MaCC") = DataGridViewNhanVien.Rows(i).Cells("Column1").Value

            ManhinhBCCong.DataSetTam.Tables("BaoCaoBT").Rows.Add(DataBC)


        Next
    End Sub

    Private Function SOPHUT1(ByVal DATE1 As Date, ByVal DATE2 As Date) As Integer
        If DateDiff(DateInterval.Hour, DATE1, DATE2) = 0 Then Return DateDiff(DateInterval.Minute, DATE1, DATE2)
        If DATE2.Hour - DATE1.Hour > 0 Then
            Return DateDiff(DateInterval.Minute, DATE1, DATE2)
        Else
            Dim NGAY1 As Integer = DateDiff(DateInterval.Minute, DATE1, DateSerial(DATE1.Year, DATE1.Month, DATE1.Day + 1))
            Dim NGAY2 As Integer = DateDiff(DateInterval.Minute, DateSerial(DATE1.Year, DATE1.Month, DATE1.Day), DATE2)
            Return NGAY1 + NGAY2
        End If
    End Function
    Private Function Datemin(ByVal a As Date, ByVal b As Date) As Date
        Dim i As Integer = DateDiff(DateInterval.Minute, a, b)
        If i > 0 Then
            Return a
        Else
            Return b
        End If
    End Function
    Private Function datemax(ByVal a As Date, ByVal b As Date) As Date
        Dim i As Integer = DateDiff(DateInterval.Minute, a, b)
        If i > 0 Then
            Return b
        Else
            Return a
        End If
    End Function
    Private Function kiemtraKhoangCach(ByVal dong As Integer, ByVal ca As cadto) As Integer
        Dim a As Integer = Math.Abs(DateDiff(DateInterval.Minute, DataGridViewChiTiet.Rows(dong).Cells("giovao").Value.date & " " & ca.batdau.ToLongTimeString, DataGridViewChiTiet.Rows(dong).Cells("giovao").Value))
        Dim date3 As Date = DataGridViewChiTiet.Rows(dong).Cells("giovao").Value.date & " " & ca.kethuc.ToLongTimeString
        Dim date4 As Date = DataGridViewChiTiet.Rows(dong).Cells("giora").Value
        'If a < 60 Then Return a
        If ca.CaQuaNgay Then date3 = DateAdd(DateInterval.Day, 1, date3)
        Dim b As Integer = Math.Abs(DateDiff(DateInterval.Minute, date3, date4))
        Return a + b
    End Function
    Private Function kiemtraKhoangCach1(ByVal dong As Integer, ByVal ca As ThongTinCaTuDong) As Integer
        Dim a As Integer = Math.Abs(DateDiff(DateInterval.Minute, DataGridViewChiTiet.Rows(dong).Cells("giovao").Value.date & " " & ca.BatDau.ToLongTimeString, DataGridViewChiTiet.Rows(dong).Cells("giovao").Value))
        Dim b As Integer = Math.Abs(DateDiff(DateInterval.Minute, DataGridViewChiTiet.Rows(dong).Cells("giora").Value.date & " " & ca.KetThuc.ToLongTimeString, DataGridViewChiTiet.Rows(dong).Cells("giora").Value))
        Return a + b
    End Function
    Private Function kiemtraKhoangCach2(ByVal dong As Integer, ByVal ca As ThongTinCaTuDong) As Integer
        Dim a As Integer = Math.Abs(DateDiff(DateInterval.Minute, DataGridViewChiTiet.Rows(dong).Cells("giovao").Value.date & " " & ca.BatDau.ToLongTimeString, DataGridViewChiTiet.Rows(dong).Cells("giovao").Value))
        Return a
    End Function
#End Region
    Dim songayCN As Integer = 0
    Private Sub TinhCongCT()

        'Try
        ToolStripProgressBar1.Visible = True
        dtoNK.User = TenNguoiDangNhap
        dtoNK.Ngay = Date.Now.Date
        dtoNK.Gio = Date.Now
        dtoNK.Tacvu = "Tính công chi tiết:" & DateTimePickerTungay.Value.Date & " -> " & DateTimePickerDenngay.Value.Date
        daoNK.Them(dtoNK)
        DataGridViewChiTiet.Rows.Clear()
       
        ToolStripProgressBar1.Value = 0
        ToolStripProgressBar1.Maximum = Me.DataGridViewNhanVien.RowCount + 1
        Dim dataca As IList = busca.LayBangArraylist
        Dim datacatd As IList = buscatd.LayBangArrayList
        Dim GioTam As Date = #1/1/1900#
        DataCaLV = busca.LayBangTable

        ThemDongtrang()


        For k As Integer = 0 To DataGridViewChiTiet.Rows.Count - 1
            DataGridViewChiTiet.Rows(k).Cells("STT").Value = k + 1
        Next
        TabControl1.SelectedIndex = 0
        ToolStripLabel1.Visible = False

        ThemLuoiKhac()


        dgvTH_Ngay.Rows.Clear()
        dgvTH_Ngay.Columns.Clear()

        dgvTH_Ngay.Columns.Add("C_MaCC_TheoNgay", "Mã CC")
        dgvTH_Ngay.Columns.Add("C_MaNV_TheoNgay", "Mã NV")
        dgvTH_Ngay.Columns.Add("C_TenNV_TheoNgay", "Tên Nhân Viên")
        dgvTH_Ngay.Columns.Add("C_ChucVu_TheoNgay", "Chức vụ")
        dgvTH_Ngay.Columns.Add("C_BoPhan_TheoNgay", "Bộ phận")
        Dim Ngay As Date = DateTimePickerTungay.Value.Date
        NgayTruoc = Ngay
        While Ngay <= DateTimePickerDenngay.Value.Date
            dgvTH_Ngay.Columns.Add("C_TheoNgay_" & Ngay.Date, Ngay.Day)
            dgvTH_Ngay.Columns("C_TheoNgay_" & Ngay.Date).Width = 30
            dgvTH_Ngay.Columns("C_TheoNgay_" & Ngay.Date).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvTH_Ngay.Columns("C_TheoNgay_" & Ngay.Date).Tag = Ngay.Date
            Ngay = DateAdd(DateInterval.Day, 1, Ngay)
        End While
        dgvTH_Ngay.Columns.Add("C_TongCong_TheoNgay", "Tổng công")
        dgvTH_Ngay.Columns.Add("C_tangca_TheoNgay", "Tổng giờ tăng ca")
        dgvTH_Ngay.Columns("C_TongCong_TheoNgay").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvTH_Ngay.Columns("C_tangca_TheoNgay").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvTH_Ngay.Columns.Add("C_TTT111", "")
        dgvTH_Ngay.Columns("C_TTT111").Visible = False


        Dim PointTH_TheoNgay As Integer = 0

        Dim MaCC_Truoc As Integer = 0
        For i As Integer = 0 To DataGridViewChiTiet.Rows.Count - 1
            If MaCC_Truoc = DataGridViewChiTiet.Item("macc", i).Value Then
                TinhTH_TheoNgay(False, i, PointTH_TheoNgay)
            Else
                TinhTH_TheoNgay(True, i, PointTH_TheoNgay)
            End If

            If DataGridViewChiTiet.Rows(i).Cells("ghichu").Value = 1 And TôMàuNgàyCuốiTuầnToolStripMenuItem.Checked Then
                DataGridViewChiTiet.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
            ElseIf DataGridViewChiTiet.Rows(i).Cells("ghichu").Value = 2 And TôMàuNgàyLểToolStripMenuItem.Checked Then
                DataGridViewChiTiet.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
            End If
            Try
                ToolStripProgressBar1.Value += 1
            Catch ex As Exception
                ToolStripProgressBar1.Value = 0
            End Try

            MaCC_Truoc = DataGridViewChiTiet.Item("macc", i).Value
        Next
        ToolStripProgressBar1.Value = ToolStripProgressBar1.Maximum
        DataGridViewChiTiet.Focus()

        NhanVienChuaCCHN()

        DataGridViewNhatky.DataSource = busVaoRa.laybangBaocaotuNGayvadenngay(DateTimePickerTungay.Value.Date, DateTimePickerDenngay.Value.Date)
        DataGridViewNghi.DataSource = busNVnghiphep.LaybangTheoTungayDenNgayVaDieuKien(DateTimePickerTungay.Value, DateTimePickerDenngay.Value)

        MsgBox("Tính công chi tiết hoàn thành", MsgBoxStyle.Information, "Thông báo")

        ToolStripProgressBar1.Visible = False


    End Sub
    Private Function kiemtraVaoRaQuadem(ByVal i As Integer) As Boolean
        Dim KTgiovao As Date = DataGridViewChiTiet.Rows(i).Cells("giovao").Value
        Dim KTgiora As Date = DataGridViewChiTiet.Rows(i).Cells("giora").Value
        Dim Avao As Date = KTgiovao
        Dim ARa As Date = KTgiora
        If KTgiora.Date <> KTgiovao.Date Then Return True
        If ARa.Date <> KTgiora.Date Then Return True
        Return False
    End Function
    Private Sub gangiatriCaTam(ByVal i As Integer, ByVal TTCa As ThongTinLichTam, ByVal QuaDem As Boolean, ByVal arraytam As ArrayList)

        Dim min As Integer = 10000
        Dim cachon As New cadto

        ' Xác định ca đi làm
        Dim GioVao1, GioRa1 As Date
        Dim GioVao, GioRa As Date
        GioVao1 = DataGridViewChiTiet.Rows(i).Cells("giovao").Value
        GioVao = DataGridViewChiTiet.Rows(i).Cells("giovao").Value
        GioRa1 = DataGridViewChiTiet.Rows(i).Cells("giora").Value
        GioRa = DataGridViewChiTiet.Rows(i).Cells("giora").Value
        Dim khoangcach As Integer = 0
        Try

            QuaDem = kiemtraVaoRaQuadem(i)

            For j As Integer = 0 To arraytam.Count - 1
                If arraytam.Item(j).TuNgay >= DataGridViewChiTiet.Rows(i).Cells("Ngaychamcong").Value And arraytam.Item(j).DenNgay <= DataGridViewChiTiet.Rows(i).Cells("Ngaychamcong").Value Then
                    Dim caLichtam As lichtamdto = BusLichTam.LayBangDTo(arraytam.Item(j).Maca)
                    Dim dtoca As cadto = busca.LayBangDTo(caLichtam.CaID)
                    If dtoca.ID <> 0 Then
                        khoangcach = kiemtraKhoangCach(i, dtoca)
                        If khoangcach < min Then
                            min = khoangcach
                            cachon = dtoca
                            'CATAM = caLichtam
                            TTCa = arraytam.Item(j)
                            'quadem = caLichtam.Dilam
                        End If
                    End If
                End If
            Next

            DataGridViewChiTiet.Rows(i).Cells("calamviec").Value = TTCa.TenCa
            DataGridViewChiTiet.Rows(i).Cells("calamviec").ToolTipText = "Thời gian của " & TTCa.TenCa & ":" & TTCa.BatDau.ToLongTimeString & "->" & TTCa.KetThuc.ToLongTimeString & IIf(TTCa.Tgvao1.ToLongTimeString <> TTCa.Tgvao2.ToLongTimeString, vbNewLine & "Thời gian nghỉ lần 1 : " & TTCa.Tgvao1.ToLongTimeString & " -> " & TTCa.Tgvao2.ToLongTimeString, "")
            DataGridViewChiTiet.Rows(i).Cells("calamviec").Style.BackColor = Color.FromArgb(TTCa.mau)
            Dim sophut As Integer
            Dim QDvao, QDRa As Date
            QDvao = GioVao1.ToLongDateString & " " & DateAdd(DateInterval.Minute, TTCa.Tre, TTCa.BatDau).ToLongTimeString
            QDRa = GioRa1.ToLongDateString & " " & DateAdd(DateInterval.Minute, -TTCa.Som, TTCa.KetThuc).ToLongTimeString
            If (GioVao1 <= QDvao) Then
                GioVao1 = GioVao1.ToLongDateString & " " & TTCa.BatDau.ToLongTimeString
                GioVao = GioVao1.ToLongDateString & " " & TTCa.BatDau.ToLongTimeString
            End If
            If (GioRa1 >= QDRa) Then _
                    GioRa1 = GioRa1.ToLongDateString & " " & TTCa.KetThuc.ToLongTimeString

            If QuaDem Then
                sophut = DateDiff(DateInterval.Minute, GioVao1, GioRa1)
                DataGridViewChiTiet.Rows(i).Cells("cadem").Value = 1
            Else

                If TTCa.Tgvao1 = TTCa.Tgvao2 Then
                    ' NEU KHONG CO THOI GIAN NGHI TRUA
                    sophut = DateDiff(DateInterval.Minute, GioVao1, GioRa1)
                Else

                    Dim BDnghi As Date = DataGridViewChiTiet.Rows(i).Cells("giovao").Value.date & " " & TTCa.Tgvao1.ToLongTimeString
                    Dim ktnghi As Date = DataGridViewChiTiet.Rows(i).Cells("giovao").Value.date & " " & TTCa.Tgvao2.ToLongTimeString
                    If DataGridViewChiTiet.Rows(i).Cells("giovao").Value <= BDnghi And DataGridViewChiTiet.Rows(i).Cells("giora").Value >= ktnghi Then
                        sophut = DateDiff(DateInterval.Minute, GioVao1, GioRa1) - TTCa.SoPhut
                    ElseIf DataGridViewChiTiet.Rows(i).Cells("giovao").Value <= BDnghi And DataGridViewChiTiet.Rows(i).Cells("giora").Value <= ktnghi And DataGridViewChiTiet.Rows(i).Cells("giora").Value >= BDnghi Then
                        sophut = DateDiff(DateInterval.Minute, GioVao1, GioRa1) - DateDiff(DateInterval.Minute, BDnghi, DataGridViewChiTiet.Rows(i).Cells("giora").Value)
                    ElseIf DataGridViewChiTiet.Rows(i).Cells("giovao").Value >= BDnghi And DataGridViewChiTiet.Rows(i).Cells("giovao").Value <= ktnghi And DataGridViewChiTiet.Rows(i).Cells("giora").Value >= ktnghi Then
                        sophut = DateDiff(DateInterval.Minute, GioVao1, GioRa1) - DateDiff(DateInterval.Minute, DataGridViewChiTiet.Rows(i).Cells("giovao").Value, ktnghi)
                    ElseIf DataGridViewChiTiet.Rows(i).Cells("giovao").Value >= BDnghi And DataGridViewChiTiet.Rows(i).Cells("giovao").Value <= ktnghi And DataGridViewChiTiet.Rows(i).Cells("giora").Value >= BDnghi And DataGridViewChiTiet.Rows(i).Cells("giora").Value <= ktnghi Then
                        sophut = 0
                    Else
                        sophut = DateDiff(DateInterval.Minute, GioVao1, GioRa1)
                    End If
                End If
                If sophut < 0 Then sophut = 0
            End If
            '****************

            DataGridViewChiTiet.Rows(i).Cells("sophut").Value = sophut 'IIf(sophut < 0, 0, IIf(cachonsophut < sophut + IIf(ditrePhut <= cachon.tre And ditrePhut > 0, ditrePhut, 0) + IIf(vesomPhut <= cachon.som And vesomPhut > 0, vesomPhut, 0), cachonsophut, sophut + IIf(ditrePhut <= cachon.tre And ditrePhut > 0, ditrePhut, 0) + IIf(vesomPhut <= cachon.som And vesomPhut > 0, vesomPhut, 0)))
            Dim GioLam As Integer = sophut Mod 60
            If GioLam >= 50 Then
                DataGridViewChiTiet.Rows(i).Cells("sogio").Value = Math.Round(sophut / 60)
            ElseIf GioLam >= 25 And GioLam < 50 Then
                DataGridViewChiTiet.Rows(i).Cells("sogio").Value = (sophut \ 60) + 0.5
            Else
                DataGridViewChiTiet.Rows(i).Cells("sogio").Value = (sophut \ 60)
            End If


            If (DateDiff(DateInterval.Minute, QDvao, GioVao) > 0) Then
                DataGridViewChiTiet.Rows(i).Cells("ditre").Value = DateDiff(DateInterval.Minute, CDate(GioVao.Date & " " & TTCa.BatDau.ToLongTimeString), GioVao)
                DataGridViewChiTiet.Rows(i).Cells("ditre").Style.BackColor = Color.Red
                DataGridViewChiTiet.Rows(i).Cells("ditre").Style.ForeColor = Color.White
            Else
                DataGridViewChiTiet.Rows(i).Cells("ditre").Value = 0
            End If

            If (DateDiff(DateInterval.Minute, GioRa, QDRa) > 0) Then
                DataGridViewChiTiet.Rows(i).Cells("vesom").Value = DateDiff(DateInterval.Minute, GioRa, CDate(GioRa.Date & " " & TTCa.KetThuc.ToLongTimeString))
                DataGridViewChiTiet.Rows(i).Cells("vesom").Style.BackColor = Color.Red
                DataGridViewChiTiet.Rows(i).Cells("vesom").Style.ForeColor = Color.White
            Else
                DataGridViewChiTiet.Rows(i).Cells("vesom").Value = 0
            End If
            'Bắt đầu tính tăng ca


            GioRa1 = GioRa1.ToLongDateString & " " & TTCa.KetThuc.ToLongTimeString
            If TTCa.TangCa = True Then
                'If TTCa.TangCaS < 0 Then 'Tăng ca trước
                '    Dim Vao As Date = DataGridViewChiTiet.Rows(i).Cells("giovao").Value
                '    Dim VaoChuan As Date = Vao.ToLongDateString & " " & TTCa.BatDau.ToLongTimeString
                '    Dim tct As Integer = DateDiff(DateInterval.Minute, Vao, VaoChuan)
                '    If tct >= Math.Abs(TTCa.GHTangCa) Then tct = Math.Abs(TTCa.GHTangCa)
                '    If tct > Math.Abs(TTCa.TangCaS) Then
                '        Dim giotc As Integer = tct Mod 60
                '        If giotc >= 50 Then
                '            DataGridViewChiTiet.Rows(i).Cells("Tangcat").Value = Math.Round(tct / 60)
                '        ElseIf giotc >= 25 And giotc < 50 Then
                '            DataGridViewChiTiet.Rows(i).Cells("Tangcat").Value = (tct \ 60) + 0.5
                '        Else
                '            DataGridViewChiTiet.Rows(i).Cells("Tangcat").Value = (tct \ 60)
                '        End If
                '    End If
                'End If
                'Tang ca sau
                If DateDiff(DateInterval.Minute, GioRa1, GioRa) >= Math.Abs(TTCa.TangCaS) Then
                    Dim SoPhutTC As Integer = DateDiff(DateInterval.Minute, GioRa1, GioRa) - Math.Abs(TTCa.TangCaS)
                    If SoPhutTC > Math.Abs(TTCa.GHTangCa) Then
                        SoPhutTC = Math.Abs(TTCa.GHTangCa)

                    End If
                    DataGridViewChiTiet.Rows(i).Cells("Tangca").Value = Math.Round((SoPhutTC / 60), 1) * 1.5
                    DataGridViewChiTiet.Rows(i).Cells("Tangca").Style.BackColor = Color.Green
                    DataGridViewChiTiet.Rows(i).Cells("Tangca").Style.ForeColor = Color.White
                    If DataGridViewChiTiet.Rows(i).Cells("Tangca").Value <= 0 Then
                        DataGridViewChiTiet.Rows(i).Cells("Tangca").Style.BackColor = Color.White
                        DataGridViewChiTiet.Rows(i).Cells("Tangca").Style.ForeColor = Color.Black
                        DataGridViewChiTiet.Rows(i).Cells("Tangca").Value = 0
                    End If
                Else
                    DataGridViewChiTiet.Rows(i).Cells("Tangca").Value = 0
                End If
                If DataGridViewChiTiet.Rows(i).Cells("Tangca").Value >= 3 And DataGridViewChiTiet.Rows(i).Cells("Tangca").Value < 4 Then
                    DataGridViewChiTiet.Rows(i).Cells("TienAnTC").Value = 7500
                ElseIf DataGridViewChiTiet.Rows(i).Cells("Tangca").Value >= 4 Then
                    DataGridViewChiTiet.Rows(i).Cells("TienAnTC").Value = 15000
                End If
            Else
                DataGridViewChiTiet.Rows(i).Cells("Tangca").Value = 0
            End If
            Dim socong As Double = (sophut / (SOPHUT1(TTCa.BatDau, TTCa.KetThuc) - TTCa.SoPhut)) * TTCa.SoCong
            ' If socong > TTCa.SoCong Then socong = TTCa.SoCong
            'DataGridViewChiTiet.Rows(i).Cells("socong").Value = Math.Round(socong, 1)
            DataGridViewChiTiet.Rows(i).Cells("socong").Value = TTCa.SoCong

        Catch ex As Exception

        End Try

    End Sub
    Private Sub gangiatri(ByVal i As Integer, ByRef dataBC As Data.DataRow)
        Dim min As Integer = 10000
        Dim cachon As New ThongTinCaTuDong
        Dim CaThu As New cadto
        Dim dt_phucapluong As New DataTable


        Dim GioVao1, GioRa1 As Date
        Dim GioVao, GioRa As Date
        GioVao1 = DataGridViewChiTiet.Rows(i).Cells("giovao").Value
        GioVao = DataGridViewChiTiet.Rows(i).Cells("giovao").Value
        GioRa1 = DataGridViewChiTiet.Rows(i).Cells("giora").Value
        GioRa = DataGridViewChiTiet.Rows(i).Cells("giora").Value
        'SoCa = 0

        Dim khoangcach As Integer
        Dim quadem As Boolean = False
        If DataGridViewChiTiet.Rows(i).Cells("giovao").Value.date <> DataGridViewChiTiet.Rows(i).Cells("giora").Value.date Then quadem = True
        Dim datachon As ArrayList
        Dim dataTienAnTC As ArrayList
        ' If ÁpDụngCaĐươcChọnToolStripMenuItem.Checked Then
        Dim dataca As ArrayList = buscatd.LayBangTableCaTheonvId(DataGridViewChiTiet.Rows(i).Cells("macc").Value)
        If dataca.Count > 0 Then
            datachon = dataca
        Else
            'datachon = DataCaLV
            DataGridViewChiTiet.Rows(i).Cells("calamviec").Value = "Nhân viên chưa có ca"
            DataGridViewChiTiet.Rows(i).DefaultCellStyle.BackColor = Color.Red
            Exit Sub
        End If
        'Else
        'datachon = DataCaLV
        'End If
        dt_phucapluong = busphucapluong.LayBangTableSQL("Select * from Phucapluong")
        Try

            If datachon.Count <= 0 Then Exit Sub

            For j As Integer = 0 To datachon.Count - 1
                If datachon.Item(j).Id <> 0 Then
                    'khoangcach = kiemtraKhoangCach2(i, datachon.Item(j))
                    khoangcach = kiemtraKhoangCach1(i, datachon.Item(j))
                    If khoangcach < min Then
                        min = khoangcach
                        cachon.ID = datachon.Item(j).id
                        cachon.TenCa = datachon.Item(j).tenca
                        cachon.BatDau = datachon.Item(j).BatDau
                        cachon.KetThuc = datachon.Item(j).Ketthuc
                        cachon.Tgvao1 = datachon.Item(j).tgvao1
                        cachon.Tgvao2 = datachon.Item(j).tgvao2
                        cachon.Som = datachon.Item(j).som
                        cachon.Tre = datachon.Item(j).tre
                        cachon.SoPhut = datachon.Item(j).sophut
                        cachon.NgayCong = datachon.Item(j).NgayCong
                        cachon.mau = datachon.Item(j).mau
                        cachon.TangCa = datachon.Item(j).tangca
                        cachon.TangCaS = datachon.Item(j).tangcaS
                        cachon.GHTangCa = datachon.Item(j).ghTangca

                    End If
                End If
            Next

            '*****************
            If cachon.ID <> 0 Then
                DataGridViewChiTiet.Rows(i).Cells("calamviec").Value = cachon.TenCa
                DataGridViewChiTiet.Rows(i).Cells("calamviec").ToolTipText = "Thời gian của " & cachon.TenCa & ":" & cachon.BatDau.ToLongTimeString & "->" & cachon.KetThuc.ToLongTimeString & IIf(cachon.Tgvao1.ToLongTimeString <> cachon.Tgvao2.ToLongTimeString, vbNewLine & "Thời gian nghỉ lần 1 : " & cachon.Tgvao1.ToLongTimeString & " -> " & cachon.Tgvao2.ToLongTimeString, "")
                DataGridViewChiTiet.Rows(i).Cells("calamviec").Style.ForeColor = Color.FromArgb(cachon.mau)
                Dim sophut As Integer
                Dim QDvao, QDRa As Date

                QDvao = GioVao1.ToLongDateString & " " & DateAdd(DateInterval.Minute, cachon.Tre, cachon.BatDau).ToLongTimeString
                If DateDiff(DateInterval.Minute, cachon.BatDau, cachon.KetThuc) < 0 Then
                    quadem = True
                Else
                    quadem = False
                End If
                If quadem = False Then
                    QDRa = GioVao1.ToLongDateString & " " & DateAdd(DateInterval.Minute, -cachon.Som, cachon.KetThuc).ToLongTimeString
                Else
                    QDRa = GioRa1.ToLongDateString & " " & DateAdd(DateInterval.Minute, -cachon.Som, cachon.KetThuc).ToLongTimeString
                End If

                'QDvao = GioVao1.ToLongDateString & " " & DateAdd(DateInterval.Minute, cachon.Tre, cachon.BatDau).ToLongTimeString
                'QDRa = GioRa1.ToLongDateString & " " & DateAdd(DateInterval.Minute, -cachon.Som, cachon.KetThuc).ToLongTimeString
                'If (GioVao1 <= QDvao) Then
                '    GioVao1 = GioVao1.ToLongDateString & " " & cachon.BatDau.ToLongTimeString
                '    GioVao = GioVao1.ToLongDateString & " " & cachon.BatDau.ToLongTimeString
                'End If
                'If (GioRa1 >= QDRa) Then _
                '        GioRa1 = GioRa1.ToLongDateString & " " & cachon.KetThuc.ToLongTimeString
                If cachon.CaquaNgay Then
                    sophut = DateDiff(DateInterval.Minute, GioVao1, GioRa1)
                Else
                    If cachon.Tgvao1 = cachon.Tgvao2 Then
                        sophut = DateDiff(DateInterval.Minute, GioVao1, GioRa1)
                    Else
                        Dim BDnghi As Date = DataGridViewChiTiet.Rows(i).Cells("giovao").Value.date & " " & cachon.Tgvao1.ToLongTimeString
                        Dim ktnghi As Date = DataGridViewChiTiet.Rows(i).Cells("giovao").Value.date & " " & cachon.Tgvao2.ToLongTimeString
                        If DataGridViewChiTiet.Rows(i).Cells("giovao").Value <= BDnghi And DataGridViewChiTiet.Rows(i).Cells("giora").Value >= ktnghi Then
                            sophut = DateDiff(DateInterval.Minute, GioVao1, QDRa) - cachon.SoPhut
                        ElseIf DataGridViewChiTiet.Rows(i).Cells("giovao").Value <= BDnghi And DataGridViewChiTiet.Rows(i).Cells("giora").Value <= ktnghi And DataGridViewChiTiet.Rows(i).Cells("giora").Value >= BDnghi Then
                            sophut = DateDiff(DateInterval.Minute, GioVao1, GioRa1) - DateDiff(DateInterval.Minute, BDnghi, DataGridViewChiTiet.Rows(i).Cells("giora").Value)
                        ElseIf DataGridViewChiTiet.Rows(i).Cells("giovao").Value >= BDnghi And DataGridViewChiTiet.Rows(i).Cells("giovao").Value <= ktnghi And DataGridViewChiTiet.Rows(i).Cells("giora").Value >= ktnghi Then
                            sophut = DateDiff(DateInterval.Minute, GioVao1, GioRa1) - DateDiff(DateInterval.Minute, DataGridViewChiTiet.Rows(i).Cells("giovao").Value, ktnghi)
                        ElseIf DataGridViewChiTiet.Rows(i).Cells("giovao").Value >= BDnghi And DataGridViewChiTiet.Rows(i).Cells("giovao").Value <= ktnghi And DataGridViewChiTiet.Rows(i).Cells("giora").Value >= BDnghi And DataGridViewChiTiet.Rows(i).Cells("giora").Value <= ktnghi Then
                            sophut = 0
                        Else
                            sophut = DateDiff(DateInterval.Minute, GioVao1, GioRa1)
                        End If
                        'sophut = DateDiff(DateInterval.Minute, GioVao1, GioRa1) - DateDiff(DateInterval.Minute, BDnghi, ktnghi)
                    End If
                    If sophut < 0 Then sophut = 0
                End If
                '****************

                DataGridViewChiTiet.Rows(i).Cells("sophut").Value = sophut 'IIf(sophut < 0, 0, IIf(cachonsophut < sophut + IIf(ditrePhut <= cachon.tre And ditrePhut > 0, ditrePhut, 0) + IIf(vesomPhut <= cachon.som And vesomPhut > 0, vesomPhut, 0), cachonsophut, sophut + IIf(ditrePhut <= cachon.tre And ditrePhut > 0, ditrePhut, 0) + IIf(vesomPhut <= cachon.som And vesomPhut > 0, vesomPhut, 0)))
                DataGridViewChiTiet.Rows(i).Cells("sogio").Value = Math.Round(sophut / 60, 1) 'DataGridViewChiTiet.Rows(i).Cells("sophut").Value / 60

                If (DateDiff(DateInterval.Minute, QDvao, GioVao) > 0) Then
                    DataGridViewChiTiet.Rows(i).Cells("ditre").Value = DateDiff(DateInterval.Minute, CDate(GioVao.Date & " " & cachon.BatDau.ToLongTimeString), GioVao)
                    DataGridViewChiTiet.Rows(i).Cells("ditre").Style.BackColor = Color.Red
                    DataGridViewChiTiet.Rows(i).Cells("ditre").Style.ForeColor = Color.White
                Else
                    DataGridViewChiTiet.Rows(i).Cells("ditre").Value = 0
                End If
                'If(cachon.CaquaNgay==True)
                If (DateDiff(DateInterval.Minute, GioRa, QDRa) > 0) Then
                    DataGridViewChiTiet.Rows(i).Cells("vesom").Value = DateDiff(DateInterval.Minute, GioRa, CDate(GioRa.Date & " " & cachon.KetThuc.ToLongTimeString))
                    DataGridViewChiTiet.Rows(i).Cells("vesom").Style.BackColor = Color.Red
                    DataGridViewChiTiet.Rows(i).Cells("vesom").Style.ForeColor = Color.White
                Else
                    DataGridViewChiTiet.Rows(i).Cells("vesom").Value = 0
                End If
                'MsgBox(cachon.KetThuc)
                GioRa1 = GioRa1.ToLongDateString & " " & cachon.KetThuc.ToLongTimeString
                If cachon.TangCa = True Then
                    'Dim SoPhutTC As Integer
                    'If cachon.GHTangCa = 0 Then
                    '    'QDRa = GioVao.ToLongDateString & " " & " 22:00:00"
                    '    If DateDiff(DateInterval.Minute, QDRa, DataGridViewChiTiet.Rows(i).Cells("giora").Value) > 0 Then
                    '        GioRa = QDRa
                    '    Else
                    '        GioRa = DataGridViewChiTiet.Rows(i).Cells("giora").Value
                    '    End If
                    '    If GioVao < QDvao Then
                    '        GioVao = QDvao
                    '        SoPhutTC = DateDiff(DateInterval.Minute, GioVao, GioRa)
                    '    Else
                    '        SoPhutTC = DateDiff(DateInterval.Minute, GioVao, GioRa)
                    '    End If
                    '    DataGridViewChiTiet.Rows(i).Cells("sophut").Value = SoPhutTC
                    '    DataGridViewChiTiet.Rows(i).Cells("sogio").Value = Math.Round((SoPhutTC / 60), 1)
                    '    DataGridViewChiTiet.Rows(i).Cells("Tangca").Value = Math.Round((SoPhutTC / 60), 1) * 1.5
                    '    DataGridViewChiTiet.Rows(i).Cells("Tangca").Style.BackColor = Color.Green
                    '    DataGridViewChiTiet.Rows(i).Cells("Tangca").Style.ForeColor = Color.White
                    '    If DataGridViewChiTiet.Rows(i).Cells("Tangca").Value <= 0 Then
                    '        DataGridViewChiTiet.Rows(i).Cells("Tangca").Style.BackColor = Color.White
                    '        DataGridViewChiTiet.Rows(i).Cells("Tangca").Style.ForeColor = Color.Black
                    '        DataGridViewChiTiet.Rows(i).Cells("Tangca").Value = 0
                    '    End If
                    'ElseIf cachon.GHTangCa <> 0 Then

                    'End If
                    'If cachon.TangCaS < 0 Then 'Tăng ca trước
                    '    Dim Vao As Date = DataGridViewChiTiet.Rows(i).Cells("giovao").Value
                    '    Dim VaoChuan As Date = Vao.ToLongDateString & " " & cachon.BatDau.ToLongTimeString
                    '    Dim tct As Integer = DateDiff(DateInterval.Minute, Vao, VaoChuan)
                    '    If tct > Math.Abs(cachon.GHTangCa) Then tct = Math.Abs(cachon.GHTangCa)
                    '    If tct >= Math.Abs(cachon.TangCaS) Then
                    '        Dim giotc As Integer = tct Mod 60
                    '        If giotc >= 50 Then
                    '            DataGridViewChiTiet.Rows(i).Cells("Tangcat").Value = Math.Round(tct / 60)
                    '        ElseIf giotc >= 25 And giotc < 50 Then
                    '            DataGridViewChiTiet.Rows(i).Cells("Tangcat").Value = (tct \ 60) + 0.5
                    '        Else
                    '            DataGridViewChiTiet.Rows(i).Cells("Tangcat").Value = (tct \ 60)
                    '        End If
                    '    End If
                    'End If
                    'Tang ca sau
                    If DateDiff(DateInterval.Minute, QDRa, GioRa) >= Math.Abs(cachon.TangCaS) Then
                        If GioVao < QDvao Then
                            GioVao = QDvao
                        End If
                        Dim SoPhutTC = DateDiff(DateInterval.Minute, GioVao, GioRa) ' - Math.Abs(cachon.TangCaS)
                        If SoPhutTC > Math.Abs(cachon.GHTangCa) Then
                            If cachon.GHTangCa <> 0 Then
                                SoPhutTC = Math.Abs(cachon.GHTangCa)
                            End If
                        End If
                        If (SoPhutTC >= 420) Then
                            DataGridViewChiTiet.Rows(i).Cells("Tangca").Value = Math.Round((SoPhutTC / 60), 1) * 1.5 + 1
                            DataGridViewChiTiet.Rows(i).Cells("sophut").Value = SoPhutTC
                        Else
                            DataGridViewChiTiet.Rows(i).Cells("Tangca").Value = Math.Round(SoPhutTC / 60 * 1.5, 1)
                            DataGridViewChiTiet.Rows(i).Cells("sophut").Value = SoPhutTC
                        End If
                        'DataGridViewChiTiet.Rows(i).Cells("Tangca").Value = Math.Round((SoPhutTC / 60), 1) * 1.5
                        DataGridViewChiTiet.Rows(i).Cells("Tangca").Style.BackColor = Color.Green
                        DataGridViewChiTiet.Rows(i).Cells("Tangca").Style.ForeColor = Color.White
                        If DataGridViewChiTiet.Rows(i).Cells("Tangca").Value <= 0 Then
                            DataGridViewChiTiet.Rows(i).Cells("Tangca").Style.BackColor = Color.White
                            DataGridViewChiTiet.Rows(i).Cells("Tangca").Style.ForeColor = Color.Black
                            DataGridViewChiTiet.Rows(i).Cells("Tangca").Value = 0
                        End If
                    Else
                        DataGridViewChiTiet.Rows(i).Cells("Tangca").Value = 0
                    End If

                    'Else
                    '    DataGridViewChiTiet.Rows(i).Cells("Tangca").Value = 0
                End If
                If DataGridViewChiTiet.Rows(i).Cells("Tangca").Value >= 3 And DataGridViewChiTiet.Rows(i).Cells("Tangca").Value < 5.5 Then
                    DataGridViewChiTiet.Rows(i).Cells("TienAnTC").Value = dt_phucapluong.Rows(0).Item("TienAnTC1")
                ElseIf DataGridViewChiTiet.Rows(i).Cells("Tangca").Value >= 5.5 Then
                    DataGridViewChiTiet.Rows(i).Cells("TienAnTC").Value = dt_phucapluong.Rows(0).Item("TienAnTC2")
                End If
                Dim socong As Double = (sophut / (SOPHUT1(cachon.BatDau, cachon.KetThuc) - cachon.SoPhut)) * cachon.NgayCong
                ' If socong > cachon.NgayCong Then socong = cachon.NgayCong
                ' DataGridViewChiTiet.Rows(i).Cells("socong").Value = Math.Round(socong, 1)
                DataGridViewChiTiet.Rows(i).Cells("socong").Value = cachon.NgayCong
            End If
            If i = 0 Then
                'MsgBox(DataGridViewChiTiet.Rows(i).Cells("nghinuabuoi").Value = 0)
                If DataGridViewChiTiet.Rows(i).Cells("socong").Value >= 1 Then
                    DataGridViewChiTiet.Rows(i).Cells("tienan").Value = 1
                    DataGridViewChiTiet.Rows(i).Cells("tienxe").Value = 1
                Else
                    DataGridViewChiTiet.Rows(i).Cells("tienan").Value = 0
                    DataGridViewChiTiet.Rows(i).Cells("tienxe").Value = 0
                End If
            Else
                If DataGridViewChiTiet.Rows(i).Cells("socong").Value >= 1 Then
                    DataGridViewChiTiet.Rows(i).Cells("tienan").Value = 1
                    DataGridViewChiTiet.Rows(i).Cells("tienxe").Value = 1
                Else
                    If DataGridViewChiTiet.Rows(i).Cells("macc").Value <> DataGridViewChiTiet.Rows(i - 1).Cells("macc").Value Or DataGridViewChiTiet.Rows(i).Cells("ngaychamcong").Value <> DataGridViewChiTiet.Rows(i - 1).Cells("ngaychamcong").Value Or DataGridViewChiTiet.Rows(i).Cells("socong").Value = 0 Then
                        DataGridViewChiTiet.Rows(i).Cells("tienan").Value = 0
                        DataGridViewChiTiet.Rows(i).Cells("tienxe").Value = 0
                    Else
                        DataGridViewChiTiet.Rows(i).Cells("tienan").Value = 1
                        DataGridViewChiTiet.Rows(i).Cells("tienxe").Value = 1
                    End If
                End If
                'If DataGridViewChiTiet.Rows(i).Cells("macc").Value <> DataGridViewChiTiet.Rows(i - 1).Cells("macc").Value Or DataGridViewChiTiet.Rows(i).Cells("ngaychamcong").Value <> DataGridViewChiTiet.Rows(i - 1).Cells("ngaychamcong").Value And DataGridViewChiTiet.Rows(i).Cells("socong").Value = 0 Then
                '    DataGridViewChiTiet.Rows(i - 1).Cells("tienan").Value = 0
                'ElseIf DataGridViewChiTiet.Rows(i).Cells("macc").Value = DataGridViewChiTiet.Rows(i - 1).Cells("macc").Value Or DataGridViewChiTiet.Rows(i).Cells("ngaychamcong").Value = DataGridViewChiTiet.Rows(i - 1).Cells("ngaychamcong").Value Then
                '    DataGridViewChiTiet.Rows(i - 1).Cells("tienan").Value = 1
                'ElseIf DataGridViewChiTiet.Rows(i).Cells("socong").Value >= 1 Then
                '    DataGridViewChiTiet.Rows(i - 1).Cells("tienan").Value = 1
                'End If
            End If

        Catch ex As Exception

        End Try

    End Sub

    Dim NgayTruoc As Date
    Private Sub TinhTH_TheoNgay(ByVal TaoMoi As Boolean, ByVal PointCT As Integer, ByRef PointTH As Integer)

        Dim dgv As DataGridView = DataGridViewChiTiet
        
        If TaoMoi = True Then
            If PointCT = 0 Then
                NgayTruoc = DateTimePickerTungay.Value.Date
            End If


            PointTH = dgvTH_Ngay.Rows.Add
            With dgvTH_Ngay.Rows(PointTH)
                .Cells("C_MaCC_TheoNgay").Value = dgv.Item("macc", PointCT).Value
                .Cells("C_MaNV_TheoNgay").Value = dgv.Item("manv", PointCT).Value
                .Cells("C_TenNV_TheoNgay").Value = dgv.Item("tennv", PointCT).Value
                .Cells("C_ChucVu_TheoNgay").Value = dgv.Item("chucvu", PointCT).Value
                .Cells("C_BoPhan_TheoNgay").Value = dgv.Item("bophan", PointCT).Value
            End With
            'If PointCT > 0 Then
            '    If dgvTH_Ngay.Item("C_TheoNgay_" & NgayTruoc.Date, PointTH).Value <= 0.5 Then
            '        DataGridViewChiTiet.Item("NghiNuaBuoi", PointCT - 1).Value = 0.5
            '    End If
            'End If
        End If
        Dim Ngay As Date = dgv.Item("ngaychamcong", PointCT).Value
        'MsgBox(Ngay)
        If Val(dgv.Item("socong", PointCT).Value) >= 0 Or Val(dgv.Item("Tangca", PointCT).Value) >= 0 Then
            dgvTH_Ngay.Item("C_TheoNgay_" & Ngay.Date, PointTH).Value = Val(dgvTH_Ngay.Item("C_TheoNgay_" & Ngay.Date, PointTH).Value) + Math.Round(Val(dgv.Item("socong", PointCT).Value), 1)
            dgvTH_Ngay.Item("C_TongCong_TheoNgay", PointTH).Value = Val(dgvTH_Ngay.Item("C_TongCong_TheoNgay", PointTH).Value) + Math.Round(Val(dgv.Item("socong", PointCT).Value), 1)
            dgvTH_Ngay.Item("C_TangCa_TheoNgay", PointTH).Value = Val(dgvTH_Ngay.Item("C_TangCa_TheoNgay", PointTH).Value) + (Val(dgv.Item("tangca", PointCT).Value))
            If NgayTruoc <> Ngay Then
                If NgayTruoc = DateTimePickerDenngay.Value.Date Then
                    If dgvTH_Ngay.Item("C_TheoNgay_" & NgayTruoc.Date, PointTH - 1).Value = 0 Then 'And DataGridViewChiTiet.Item("tangca", PointCT - 1).Value > 0 Then
                        If DataGridViewChiTiet.Item("ghichu", PointCT - 1).Value <> 1 Then
                            DataGridViewChiTiet.Item("NghiNuaBuoi", PointCT - 1).Value = 1
                        End If
                    ElseIf dgvTH_Ngay.Item("C_TheoNgay_" & NgayTruoc.Date, PointTH - 1).Value <= 0.5 And Strings.Len(DataGridViewChiTiet.Item("giovao", PointCT - 1).Value) > 0 Then
                        If TaoMoi = True Then
                            If dgvTH_Ngay.Item("C_TheoNgay_" & NgayTruoc.Date, PointTH - 1).Value <= 0.5 And Strings.Len(DataGridViewChiTiet.Item("giovao", PointCT - 1).Value) > 0 Then
                                If DataGridViewChiTiet.Item("ghichu", PointCT).Value <> 1 Then
                                    DataGridViewChiTiet.Item("NghiNuaBuoi", PointCT - 1).Value = 0.5
                                End If
                            End If
                        Else
                            If DataGridViewChiTiet.Item("ghichu", PointCT).Value <> 1 Then
                                DataGridViewChiTiet.Item("NghiNuaBuoi", PointCT - 1).Value = 0.5
                            End If
                        End If
                    End If
                Else
                    If dgvTH_Ngay.Item("C_TheoNgay_" & NgayTruoc.Date, PointTH).Value = 0 Then 'And DataGridViewChiTiet.Item("tangca", PointCT - 1).Value > 0 Then
                        If DataGridViewChiTiet.Item("ghichu", PointCT - 1).Value <> 1 Then
                            DataGridViewChiTiet.Item("NghiNuaBuoi", PointCT - 1).Value = 1
                        End If
                    ElseIf dgvTH_Ngay.Item("C_TheoNgay_" & NgayTruoc.Date, PointTH).Value <= 0.5 And Strings.Len(DataGridViewChiTiet.Item("giovao", PointCT - 1).Value) > 0 Then
                        If TaoMoi = True Then
                            If dgvTH_Ngay.Item("C_TheoNgay_" & NgayTruoc.Date, PointTH - 1).Value <= 0.5 And Strings.Len(DataGridViewChiTiet.Item("giovao", PointCT - 1).Value) > 0 Then
                                If DataGridViewChiTiet.Item("ghichu", PointCT - 1).Value <> 1 Then
                                    DataGridViewChiTiet.Item("NghiNuaBuoi", PointCT - 1).Value = 0.5
                                End If
                            End If
                        Else
                            If DataGridViewChiTiet.Item("ghichu", PointCT - 1).Value <> 1 Then
                                DataGridViewChiTiet.Item("NghiNuaBuoi", PointCT - 1).Value = 0.5
                            End If
                        End If
                    End If
                End If
            End If
            NgayTruoc = Ngay
        End If

        'Dim Ngay As Date = dgv.Item("ngaychamcong", PointCT).Value

        'If Val(dgv.Item("socong", PointCT).Value) >= 0 Or Val(dgv.Item("Tangca", PointCT).Value) >= 0 Then
        '    dgvTH_Ngay.Item("C_TheoNgay_" & Ngay.Date, PointTH).Value = Val(dgvTH_Ngay.Item("C_TheoNgay_" & Ngay.Date, PointTH).Value) + Math.Round(Val(dgv.Item("socong", PointCT).Value), 1)
        '    dgvTH_Ngay.Item("C_TongCong_TheoNgay", PointTH).Value = Val(dgvTH_Ngay.Item("C_TongCong_TheoNgay", PointTH).Value) + Math.Round(Val(dgv.Item("socong", PointCT).Value), 1)
        '    dgvTH_Ngay.Item("C_TangCa_TheoNgay", PointTH).Value = Val(dgvTH_Ngay.Item("C_TangCa_TheoNgay", PointTH).Value) + (Val(dgv.Item("tangca", PointCT).Value))

        '    If NgayTruoc <> Ngay Then

        '        If dgvTH_Ngay.Item("C_TongCong_TheoNgay", PointTH).Value = 0 And DataGridViewChiTiet.Item("tangca", PointCT - 1).Value > 0 Then
        '            DataGridViewChiTiet.Item("NghiNuaBuoi", PointCT - 1).Value = 1
        '        ElseIf dgvTH_Ngay.Item("C_TheoNgay_" & NgayTruoc.Date, PointTH).Value <= 0.5 And Strings.Len(DataGridViewChiTiet.Item("giovao", PointCT - 1).Value) > 0 Then
        '            If TaoMoi = True Then
        '                If dgvTH_Ngay.Item("C_TheoNgay_" & NgayTruoc.Date, PointTH - 1).Value <= 0.5 And Strings.Len(DataGridViewChiTiet.Item("giovao", PointCT - 1).Value) > 0 Then
        '                    DataGridViewChiTiet.Item("NghiNuaBuoi", PointCT - 1).Value = 0.5
        '                End If
        '            Else
        '                DataGridViewChiTiet.Item("NghiNuaBuoi", PointCT - 1).Value = 0.5
        '            End If
        '        End If
        '    End If

        '    NgayTruoc = Ngay
        'Else
        '    NgayTruoc = Ngay
        'End If

        'NgayTruoc = Ngay
        If PointCT = dgv.RowCount - 1 Then
            If dgvTH_Ngay.Item("C_TheoNgay_" & Ngay.Date, PointTH).Value = 0 Then 'And DataGridViewChiTiet.Item("tangca", PointCT).Value > 0 Then
                If Weekday(DataGridViewChiTiet.Item("ngaychamcong", PointCT).Value) <> 1 Then
                    DataGridViewChiTiet.Item("NghiNuaBuoi", PointCT).Value = 1
                End If
            ElseIf dgvTH_Ngay.Item("C_TheoNgay_" & Ngay.Date, PointTH).Value <= 0.5 And Strings.Len(DataGridViewChiTiet.Item("giovao", PointCT).Value) > 0 Then
                If Weekday(DataGridViewChiTiet.Item("ngaychamcong", PointCT).Value) <> 1 Then
                    DataGridViewChiTiet.Item("NghiNuaBuoi", PointCT).Value = 0.5
                End If
            End If
        End If

    End Sub
    Private Sub TínhCôngTổngHợpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TínhCôngTổngHợpToolStripMenuItem.Click
        Try
            TinhCongTongHop()
        Catch ex As Exception
        End Try
    End Sub
    Public Sub TinhCongTongHop()
        ToolStripProgressBar1.Visible = True
        dtoNK.User = TenNguoiDangNhap
        dtoNK.Ngay = Date.Now.Date
        dtoNK.Gio = Date.Now
        dtoNK.Tacvu = "Tính công tổng hợp: " & DateTimePickerTungay.Value.Date & " -> " & DateTimePickerDenngay.Value.Date
        daoNK.Them(dtoNK)
        DataGridViewTonghop.Rows.Clear()
        Dim BaoCaoTH As New BaoCaoTongHop
        ToolStripProgressBar1.Value = 0
        songayCN = 0
        For h As Integer = 0 To DateDiff(DateInterval.Day, DateTimePickerTungay.Value, DateTimePickerDenngay.Value) - 1
            Dim dt As New DateTime
            dt = DateAdd(DateInterval.Day, h, DateTimePickerTungay.Value)
            If dt.DayOfWeek = DayOfWeek.Sunday Then
                songayCN += 1
            End If
        Next
        For i As Integer = 0 To DataGridViewChiTiet.Rows.Count - 1
            If (DataGridViewChiTiet.Rows(i).Cells("MaCC").Value = 48) Then
                'MsgBox(i)
                ' MsgBox(BaoCaoTH.TienComTrua)
            End If
            'Tạo dòng mới bản tổng hợp
            'MsgBox(DataGridViewChiTiet.Rows(i).Cells("TienAn").Value)
            'If (DataGridViewChiTiet.Rows(i).Cells("TienAn").Value = 1) Then
            '    BaoCaoTH.TienComTrua += CInt(DataGridViewChiTiet.Rows(i).Cells("TienAn").Value)
            'Else
            '    BaoCaoTH.TienComTrua += 0
            'End If
            'BaoCaoTH.TienComTrua += CInt(DataGridViewChiTiet.Rows(i).Cells("TienAn").Value)
            If i > 0 Then
                If DataGridViewChiTiet.Rows(i - 1).Cells("macc").Value <> DataGridViewChiTiet.Rows(i).Cells("macc").Value Then
                    'BaoCaoTH.TienComTrua = 0
                    'BaoCaoTH.TienComTrua += CInt(DataGridViewChiTiet.Rows(i).Cells("TienAn").Value)
                    Dim k As Integer = DataGridViewTonghop.Rows.Add()
                    For j As Integer = 1 To 5
                        DataGridViewTonghop.Rows(k).Cells(j).Value = DataGridViewChiTiet.Rows(i - 1).Cells(j).Value
                    Next
                    Dim data As System.Data.DataTable = busNVnghiphep.Tong_socongTheoNvidTungayDenNgay(DataGridViewChiTiet.Rows(i - 1).Cells("macc").Value, DateTimePickerTungay.Value, DateTimePickerDenngay.Value)

                    If Not data.Rows(0).IsNull(0) Then
                        BaoCaoTH.Songaynghiphep = data.Rows(0).Item(0).ToString
                        BaoCaoTH.socongNghiPhep = data.Rows(0).Item(1).ToString
                    End If
                    '*************
                    BaoCaoTH.socongSaucong = BaoCaoTH.socongNT + BaoCaoTH.socongNghiPhep + BaoCaoTH.socongNL * Val(TextBoxtHesoNL.Text) + BaoCaoTH.socongNCT * Val(TextBoxHesoNCT.Text)

                    If BaoCaoTH.SoNgayNghiKoPhep >= 1 Then
                        BaoCaoTH.SoNgayNghiKoPhep -= 1
                        BaoCaoTH.Songaynghiphep = 1
                    ElseIf BaoCaoTH.SoNgayNghiKoPhep > 0 And BaoCaoTH.SoNgayNghiKoPhep < 1 Then

                        BaoCaoTH.Songaynghiphep = BaoCaoTH.SoNgayNghiKoPhep
                        BaoCaoTH.SoNgayNghiKoPhep = 0
                    End If
                    ganBangtonghop(k, BaoCaoTH)
                    BaoCaoTH = New BaoCaoTongHop
                    BaoCaoTH.mau = DataGridViewChiTiet.Rows(i).DefaultCellStyle.BackColor
                    If DataGridViewChiTiet.Rows(i - 1).DefaultCellStyle.BackColor = Color.LightGray Then DataGridViewTonghop.Rows(k).DefaultCellStyle.BackColor = DataGridViewChiTiet.Rows(i - 1).DefaultCellStyle.BackColor

                    Try
                        ToolStripProgressBar1.Value += 1
                    Catch ex As Exception
                        ToolStripProgressBar1.Value = 0
                    End Try
                Else
                    'BaoCaoTH.TienComTrua += CInt(DataGridViewChiTiet.Rows(i).Cells("TienAn").Value)
                End If
            Else
                'BaoCaoTH.TienComTrua += CInt(DataGridViewChiTiet.Rows(i).Cells("TienAn").Value)
            End If

            TinhCongBaoCao(i, BaoCaoTH)

            Select Case DataGridViewChiTiet.Rows(i).Cells("ghichu").Value
                Case 2
                    TinhCongBaoCaoNL(i, BaoCaoTH)
                Case 1
                    TinhCongBaoCaoNCT(i, BaoCaoTH)
                Case 0
                    TinhCongBaoCaoNT(i, BaoCaoTH)
            End Select
            Try
                ToolStripProgressBar1.Value += 1
            Catch ex As Exception
                ToolStripProgressBar1.Value = 0
            End Try
            'Tạo dòng mới bản tổng hợp
            If i = DataGridViewChiTiet.Rows.Count - 1 Then
                Dim k As Integer = DataGridViewTonghop.Rows.Add
                BaoCaoTH.mau = DataGridViewChiTiet.Rows(i).DefaultCellStyle.BackColor
                For j As Integer = 1 To 5
                    DataGridViewTonghop.Rows(k).Cells(j).Value = DataGridViewChiTiet.Rows(i).Cells(j).Value
                Next
                Dim data As System.Data.DataTable = busNVnghiphep.Tong_socongTheoNvidTungayDenNgay(DataGridViewChiTiet.Rows(i).Cells("macc").Value, DateTimePickerTungay.Value, DateTimePickerDenngay.Value)
                If Not data.Rows(0).IsNull(0) Then
                    BaoCaoTH.Songaynghiphep = data.Rows(0).Item(0).ToString
                    BaoCaoTH.socongNghiPhep = data.Rows(0).Item(1).ToString
                End If

                BaoCaoTH.socongSaucong = BaoCaoTH.socongNT + BaoCaoTH.socongNghiPhep + BaoCaoTH.socongNL * Val(TextBoxtHesoNL.Text) + BaoCaoTH.socongNCT * Val(TextBoxHesoNCT.Text)
                If BaoCaoTH.SoNgayNghiKoPhep >= 1 Then
                    BaoCaoTH.SoNgayNghiKoPhep -= 1
                    BaoCaoTH.Songaynghiphep = 1
                ElseIf BaoCaoTH.SoNgayNghiKoPhep > 0 And BaoCaoTH.SoNgayNghiKoPhep < 1 Then
                    BaoCaoTH.Songaynghiphep = BaoCaoTH.SoNgayNghiKoPhep
                    BaoCaoTH.SoNgayNghiKoPhep = 0
                End If
                ganBangtonghop(k, BaoCaoTH)
                If DataGridViewChiTiet.Rows(i).DefaultCellStyle.BackColor = Color.LightGray Then DataGridViewTonghop.Rows(k).DefaultCellStyle.BackColor = DataGridViewChiTiet.Rows(i).DefaultCellStyle.BackColor
                Try
                    ToolStripProgressBar1.Value += 1
                Catch ex As Exception
                    ToolStripProgressBar1.Value = 0
                End Try

            End If
        Next
        ToolStripProgressBar1.Value = ToolStripProgressBar1.Maximum
        TabControl1.SelectedIndex = 1
        DataGridViewTonghop.Focus()
        ToolStripProgressBar1.Value = 0

        MsgBox("Tính công tổng hợp hoàn thành", , "Thông báo")
      
        ToolStripProgressBar1.Visible = False
        TsbLuuSoCong.Visible = True
        TsbLuuSoCong.Enabled = True
    End Sub
    Private Sub TôMàuNgàyLểToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TôMàuNgàyLểToolStripMenuItem.Click
        TôMàuNgàyLểToolStripMenuItem.Checked = Not TôMàuNgàyLểToolStripMenuItem.Checked
    End Sub
    Private Sub TôMàuNgàyCuốiTuầnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TôMàuNgàyCuốiTuầnToolStripMenuItem.Click
        TôMàuNgàyCuốiTuầnToolStripMenuItem.Checked = Not TôMàuNgàyCuốiTuầnToolStripMenuItem.Checked
    End Sub
#End Region
#Region "Context menu"
#Region "ContextMenustripTonghop"
    Private Sub ToolStripMenuItem1_DropDownItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStripMenuItem1.DropDownItemClicked
        DataGridViewTonghop.Columns(e.ClickedItem.Name).Visible = Not DataGridViewTonghop.Columns(e.ClickedItem.Name).Visible

    End Sub
    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        'ToolStripMenuItem2.Checked = Not ToolStripMenuItem2.Checked
        DataGridViewTonghop.Columns("Column14").Visible = ToolStripMenuItem2.Checked
        DataGridViewTonghop.Columns("Column15").Visible = ToolStripMenuItem2.Checked
        DataGridViewTonghop.Columns("Column16").Visible = ToolStripMenuItem2.Checked
        DataGridViewTonghop.Columns("Column17").Visible = ToolStripMenuItem2.Checked
        DataGridViewTonghop.Columns("Column18").Visible = ToolStripMenuItem2.Checked
        DataGridViewTonghop.Columns("Column19").Visible = ToolStripMenuItem2.Checked
        DataGridViewTonghop.Columns("Column20").Visible = ToolStripMenuItem2.Checked
        DataGridViewTonghop.Columns("Column21").Visible = ToolStripMenuItem2.Checked
    End Sub
    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        'ToolStripMenuItem3.Checked = Not ToolStripMenuItem3.Checked
        DataGridViewTonghop.Columns("Column22").Visible = ToolStripMenuItem3.Checked
        DataGridViewTonghop.Columns("Column23").Visible = ToolStripMenuItem3.Checked
        DataGridViewTonghop.Columns("Column24").Visible = ToolStripMenuItem3.Checked
        DataGridViewTonghop.Columns("Column25").Visible = ToolStripMenuItem3.Checked
        DataGridViewTonghop.Columns("Column26").Visible = ToolStripMenuItem3.Checked
        DataGridViewTonghop.Columns("Column27").Visible = ToolStripMenuItem3.Checked
        DataGridViewTonghop.Columns("Column28").Visible = ToolStripMenuItem3.Checked
        DataGridViewTonghop.Columns("Column29").Visible = ToolStripMenuItem3.Checked
    End Sub
    Private Sub CôngToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CôngToolStripMenuItem.Click
        'CôngToolStripMenuItem.Checked = Not CôngToolStripMenuItem.Checked
        DataGridViewTonghop.Columns("Column34").Visible = CôngToolStripMenuItem.Checked
        DataGridViewTonghop.Columns("Column35").Visible = CôngToolStripMenuItem.Checked
        DataGridViewTonghop.Columns("Column36").Visible = CôngToolStripMenuItem.Checked
        DataGridViewTonghop.Columns("Column37").Visible = CôngToolStripMenuItem.Checked
        DataGridViewTonghop.Columns("Column39").Visible = CôngToolStripMenuItem.Checked
        DataGridViewTonghop.Columns("Column40").Visible = CôngToolStripMenuItem.Checked
    End Sub
    Private Sub TăngCaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TăngCaToolStripMenuItem.Click
        'TăngCaToolStripMenuItem.Checked = Not TăngCaToolStripMenuItem.Checked
        DataGridViewTonghop.Columns("Column30").Visible = TăngCaToolStripMenuItem.Checked
        DataGridViewTonghop.Columns("Column31").Visible = TăngCaToolStripMenuItem.Checked
        DataGridViewTonghop.Columns("Column32").Visible = TăngCaToolStripMenuItem.Checked
        DataGridViewTonghop.Columns("Column33").Visible = TăngCaToolStripMenuItem.Checked
    End Sub
    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        'ToolStripMenuItem4.Checked = Not ToolStripMenuItem4.Checked
        DataGridViewTonghop.Columns("Column9").Visible = ToolStripMenuItem4.Checked
        DataGridViewTonghop.Columns("Column13").Visible = ToolStripMenuItem4.Checked
        DataGridViewTonghop.Columns("Column17").Visible = ToolStripMenuItem4.Checked
        DataGridViewTonghop.Columns("Column21").Visible = ToolStripMenuItem4.Checked
        DataGridViewTonghop.Columns("Column25").Visible = ToolStripMenuItem4.Checked
        DataGridViewTonghop.Columns("Column29").Visible = ToolStripMenuItem4.Checked
        DataGridViewTonghop.Columns("Column33").Visible = ToolStripMenuItem4.Checked
        DataGridViewTonghop.Columns("Column37").Visible = ToolStripMenuItem4.Checked
    End Sub
    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        'ToolStripMenuItem5.Checked = Not ToolStripMenuItem5.Checked
        DataGridViewTonghop.Columns("Column8").Visible = ToolStripMenuItem5.Checked
        DataGridViewTonghop.Columns("Column12").Visible = ToolStripMenuItem5.Checked
        DataGridViewTonghop.Columns("Column16").Visible = ToolStripMenuItem5.Checked
        DataGridViewTonghop.Columns("Column20").Visible = ToolStripMenuItem5.Checked
        DataGridViewTonghop.Columns("Column24").Visible = ToolStripMenuItem5.Checked
        DataGridViewTonghop.Columns("Column28").Visible = ToolStripMenuItem5.Checked
        DataGridViewTonghop.Columns("Column32").Visible = ToolStripMenuItem5.Checked
        DataGridViewTonghop.Columns("Column36").Visible = ToolStripMenuItem5.Checked
    End Sub
    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        'ToolStripMenuItem6.Checked = Not ToolStripMenuItem6.Checked
        DataGridViewTonghop.Columns("Column7").Visible = ToolStripMenuItem6.Checked
        DataGridViewTonghop.Columns("Column11").Visible = ToolStripMenuItem6.Checked
        DataGridViewTonghop.Columns("Column15").Visible = ToolStripMenuItem6.Checked
        DataGridViewTonghop.Columns("Column19").Visible = ToolStripMenuItem6.Checked
        DataGridViewTonghop.Columns("Column23").Visible = ToolStripMenuItem6.Checked
        DataGridViewTonghop.Columns("Column27").Visible = ToolStripMenuItem6.Checked
        DataGridViewTonghop.Columns("Column31").Visible = ToolStripMenuItem6.Checked
        DataGridViewTonghop.Columns("Column35").Visible = ToolStripMenuItem6.Checked
    End Sub
    Private Sub ThôngTinNhânViênTốiThiểuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ThôngTinNhânViênTốiThiểuToolStripMenuItem.Click
        'ThôngTinNhânViênTốiThiểuToolStripMenuItem.Checked = Not ThôngTinNhânViênTốiThiểuToolStripMenuItem.Checked
        DataGridViewTonghop.Columns("DataGridViewTextBoxColumn50").Visible = Not ThôngTinNhânViênTốiThiểuToolStripMenuItem.Checked
        DataGridViewTonghop.Columns("DataGridViewTextBoxColumn51").Visible = Not ThôngTinNhânViênTốiThiểuToolStripMenuItem.Checked
        DataGridViewTonghop.Columns("DataGridViewTextBoxColumn53").Visible = Not ThôngTinNhânViênTốiThiểuToolStripMenuItem.Checked
        DataGridViewTonghop.Columns("DataGridViewTextBoxColumn54").Visible = Not ThôngTinNhânViênTốiThiểuToolStripMenuItem.Checked
    End Sub
#End Region
#Region "ContextMenustripchitiet"
    Private Sub ContextMenuStrip2_Closed(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripDropDownClosedEventArgs) Handles ContextMenuStrip2.Closed
        For i As Integer = 0 To DataGridViewChiTiet.Columns.Count - 3
            DataGridViewNgayThuong.Columns(i).Visible = DataGridViewChiTiet.Columns(i).Visible
            DataGridViewNgayLe.Columns(i).Visible = DataGridViewChiTiet.Columns(i).Visible
            DataGridViewNgayCuoiTuan.Columns(i).Visible = DataGridViewChiTiet.Columns(i).Visible
        Next
    End Sub

    Private Sub ContextMenuStrip2_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ContextMenuStrip2.ItemClicked
        DataGridViewChiTiet.Columns(e.ClickedItem.Name).Visible = Not DataGridViewChiTiet.Columns(e.ClickedItem.Name).Visible
    End Sub
    Private Sub ContextMenuStrip2_Opened(ByVal sender As Object, ByVal e As System.EventArgs) Handles ContextMenuStrip2.Opened
        Dim M As System.Windows.Forms.ToolStripMenuItem
        Me.ContextMenuStrip2.Items.Clear()
        For i As Integer = 0 To DataGridViewChiTiet.ColumnCount - 1
            M = Me.ContextMenuStrip2.Items.Add(DataGridViewChiTiet.Columns(i).HeaderText)
            M.Name = DataGridViewChiTiet.Columns(i).Name
            M.Tag = i
            M.CheckOnClick = True
            M.Checked = DataGridViewChiTiet.Columns(i).Visible
        Next
    End Sub

#End Region
#End Region
    Private Sub ManHinhBaoCao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        tsbLuuSoCong.Enabled = False
        dtoNK.User = TenNguoiDangNhap
        dtoNK.Ngay = Date.Now.Date
        dtoNK.Gio = Date.Now
        dtoNK.Tacvu = "Mở màn hình báo cáo"
        daoNK.Them(dtoNK)
        DataGridViewNhanVien.DataSource = busnvbc.LayBangTable
        Me.SplitContainer1.Panel1Collapsed = Not ToolStripButton5.Checked
        ToolStripButton5.Checked = Not ToolStripButton5.Checked
        dtoPhucapluong = busphucapluong.LayBangDTo(0, busphucapluong.LayBangTableSQL("select * from phucapluong"))
        DateTimePickerTungay.Value = DateSerial(Now.Year, Now.Month, 1)
        Me.DateTimePickerDenngay.Value = Now.Date & " " & #11:59:59 PM#

        DocFileBut(My.Application.Info.DirectoryPath & "\Thamso.dll")
        DocFileCotBaocaoTonghop(My.Application.Info.DirectoryPath & "\DataGridViewTonghop.Dll")
        DocFileCotBaocaoChiTiet(My.Application.Info.DirectoryPath & "\DataGridViewChiTiet.Dll")
        ToolStripStatusLabel1.Text = "Số nhân viên báo cáo là : " & DataGridViewNhanVien.Rows.Count
    End Sub
    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        XemNVDCChon()
    End Sub
#Region "xuat bao cao excel"
    Public Sub XuatBCEX(ByVal ddanEX As String)
        Dim EXC As New Microsoft.Office.Interop.Excel.Application
        Dim Wbook As New Microsoft.Office.Interop.Excel.Workbook
        Dim Shet As New Microsoft.Office.Interop.Excel.Worksheet
        EXC = New Microsoft.Office.Interop.Excel.Application
        Wbook = EXC.Workbooks.Add
        XuatEXF("Xu ly", Me.DataGridViewChiTiet)
        MsgBox("Xu ly")
        XuatEXF("Nhat ky", Me.DataGridViewNhatky)
        MsgBox("Nhat ky")
        XuatEXF("Ngay thuong", Me.DataGridViewNgayThuong)
        MsgBox("Ngay thuong")
        XuatEXF("Ngay cuoi tuan", Me.DataGridViewNgayCuoiTuan)
        MsgBox("Ngay cuoi tuan")
        XuatEXF("Ngay le", Me.DataGridViewNgayLe)
        MsgBox("Ngay le")
        XuatEXF("Chua CC", Me.DataGridViewChuaCC)
        MsgBox("Chua CC")
        XuatEXF("Nghi phep", Me.DataGridViewNghi)
        MsgBox("Nghi phep")
        XuatEXF("Tong hop", Me.DataGridViewTonghop)
        MsgBox("Tong hop")
        XuatBangTG()
        Wbook.SaveAs(ddanEX)
        Wbook.Close()
        EXC.Workbooks.Close()
        System.Runtime.InteropServices.Marshal.ReleaseComObject(EXC)
        EXC = Nothing
        Dim pro() As Process = System.Diagnostics.Process.GetProcessesByName("EXCEL")
        For Each i As Process In pro
            i.Kill()
        Next
    End Sub
    Private Sub XuatEXF(ByVal Ten As String, ByVal dgv As System.Windows.Forms.DataGridView)
        StatusStrip1.Visible = True
        'ToolStripProgressBar1.Maximum = dgv.RowCount * dgv.ColumnCount + 100

        ToolStripProgressBar1.Value = 0
        ToolStripProgressBar1.Maximum = dgv.RowCount + 1
        Dim EXC As New Microsoft.Office.Interop.Excel.Application
        Dim Wbook As New Microsoft.Office.Interop.Excel.Workbook
        Dim Shet As New Microsoft.Office.Interop.Excel.Worksheet
        Shet = Wbook.Worksheets.Add
        Shet = Wbook.ActiveSheet
        Shet.Name = Ten
        Dim cot, hang As Integer
        cot = 0
        hang = 0
        For i As Integer = 0 To dgv.ColumnCount - 1
            If dgv.Columns(i).Visible Then
                cot += 1
                Shet.Cells(1, cot).value = CStr(dgv.Columns(i).HeaderText)

            End If

            ToolStripProgressBar1.Value += 1
            If ToolStripProgressBar1.Value = ToolStripProgressBar1.Maximum Then ToolStripProgressBar1.Value = 0

        Next
        ' noi dung
        For i As Integer = 0 To dgv.RowCount - 1
            hang += 1
            cot = 0
            For j As Integer = 0 To dgv.ColumnCount - 1
                If dgv.Columns(j).Visible Then
                    cot += 1
                    EXC.Cells(hang + 1, cot).value = CStr(dgv.Item(j, i).Value)
                End If
            Next
            ToolStripProgressBar1.Value += 1
            If ToolStripProgressBar1.Value = ToolStripProgressBar1.Maximum Then ToolStripProgressBar1.Value = 0
            '***************************
        Next
        Shet.Columns.AutoFit()
        ToolStripProgressBar1.Value = ToolStripProgressBar1.Maximum
        StatusStrip1.Visible = False
    End Sub
    Private Sub XuatBangTG()

        DuaDLBaoCao()

        StatusStrip1.Visible = True
        'ToolStripProgressBar1.Maximum = dgv.RowCount * dgv.ColumnCount + 100

        ToolStripProgressBar1.Value = 0

        Dim EXC As New Microsoft.Office.Interop.Excel.Application
        Dim Wbook As New Microsoft.Office.Interop.Excel.Workbook
        Dim Shet As New Microsoft.Office.Interop.Excel.Worksheet
        Shet = Wbook.Worksheets.Add
        Shet = Wbook.ActiveSheet
        Shet.Name = "BangTG"
        Dim cot, hang As Integer
        cot = 0
        hang = 0
        Dim Table1 As System.Data.DataTable
        Table1 = Me.DataSetTam1.Tables("DataTable1")
        ToolStripProgressBar1.Maximum = Table1.Rows.Count + 1
        Shet.Cells(1, 1) = "STT"
        Shet.Cells(1, 2) = "Tên nhân viên"
        Shet.Cells(1, 3) = "Mã NV"
        Shet.Cells(1, 4) = "Bộ phận"
        Dim MNgay As Date
        For i As Integer = 0 To 30
            MNgay = DateAdd(DateInterval.Day, i, Me.DateTimePickerTungay.Value)
            Shet.Cells(1, 5 + i) = MNgay.Day
        Next

        For i As Integer = 0 To Table1.Rows.Count - 1
            Shet.Cells(i + 2, 1) = i + 1
            For j As Integer = 0 To Table1.Columns.Count - 1
                Shet.Cells(i + 2, j + 2) = Table1.Rows(i).Item(j)
            Next

            Try
                ToolStripProgressBar1.Value += 1
            Catch ex As Exception
                ToolStripProgressBar1.Value = 0
            End Try
        Next
        Shet.Columns.AutoFit()
        ToolStripProgressBar1.Value = ToolStripProgressBar1.Maximum
    End Sub
#End Region
#Region "Ham xuat excel moi"
    Private ComDset As New System.Data.DataSet
    Private Sub xuat()
        Dim filename As String
        Dim col, row As Integer
        Dim strname As String = "Name"

        'ComDset = "đổ dữ liệu vào dataset"

        If ComDset.Tables.Count < 0 Or ComDset.Tables(0).Rows.Count <= 0 Then
            Exit Sub
        End If

        Dim Excel As Object = CreateObject("Excel.Application")
        If Excel Is Nothing Then
            MsgBox("It appears that Excel is not installed on this machine. This operation requires MS Excel to be installed on this machine.", MsgBoxStyle.Critical)
            Return
        End If


        If Excel Is Nothing Then
            MsgBox("It appears that Excel is not installed on this machine. This operation requires MS Excel to be installed on this machine.", MsgBoxStyle.Critical)
            Return
        End If


        'Export to Excel process
        Try
            With Excel
                '.

                .SheetsInNewWorkbook = 1
                .Workbooks.Add()
                .Worksheets(1).Select()
                .cells(1, 5).value = strname
                Dim i As Integer = 1
                For col = 0 To ComDset.Tables(0).Columns.Count - 1

                    .cells(3, i).value = ComDset.Tables(0).Columns(col).ColumnName
                    .cells(3, i).EntireRow.Font.Bold = True
                    i += 1
                Next
                i = 4
                Dim k As Integer = 1
                For col = 0 To ComDset.Tables(0).Columns.Count - 1
                    i = 4
                    For row = 0 To ComDset.Tables(0).Rows.Count - 1
                        .Cells(i, k).Value = ComDset.Tables(0).Rows(row).ItemArray(col)
                        i += 1
                    Next
                    k += 1
                Next
                filename = "c:\" & strname & Format(Now(), "dd-MM-yyyy_hh-mm-ss") & ".xls"
                .ActiveCell.Worksheet.SaveAs(filename)

            End With
            System.Runtime.InteropServices.Marshal.ReleaseComObject(Excel)
            Excel = Nothing
            MsgBox("Báo cáo đã được sinh ra file excel: '" & filename & "'", MsgBoxStyle.Information)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        ' The excel is created and opened for insert value. We most close this excel using this system
        Dim pro() As Process = System.Diagnostics.Process.GetProcessesByName("EXCEL")
        For Each i As Process In pro
            i.Kill()
        Next

    End Sub
#End Region
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ManhinhBCCong.Show()
        Exit Sub

        dtoNK.User = TenNguoiDangNhap
        dtoNK.Ngay = Date.Now.Date
        dtoNK.Gio = Date.Now
        dtoNK.Tacvu = "In báo cáo"
        daoNK.Them(dtoNK)
        If DataGridViewChiTiet.RowCount <= 0 Then
            MsgBox("Không thể làm báo cáo do chưa tính công", , "Thông báo")
            Exit Sub
        End If
        DuaDLBaoCao()
        'Application.DoEvents()


    End Sub
    Private Sub DuaDLBaoCao()
        Dim datarow As DataRow
        Dim Dau As Boolean = True

        Dim VTriKT As Integer = 0
        Dim NguoiMoi As Boolean = True
        Dim NgayTT As Date = Me.DateTimePickerTungay.Value
        Dim SoNgayT As Integer = 3
        Dim SoGio As Double = 0

        ToolStripProgressBar1.Value = 0
        ToolStripProgressBar1.Maximum = Me.DataGridViewChiTiet.RowCount + 1
        Me.DataSetTam1.Tables("DataTable1").Clear()

        For i As Integer = 0 To Me.DataGridViewNhanVien.RowCount - 1
            datarow = Me.DataSetTam1.Tables("DataTable1").NewRow
            datarow.Item("MaNV") = Me.DataGridViewNhanVien.Item("Column2", i).Value
            datarow.Item("TenNV") = Me.DataGridViewNhanVien.Item("Column3", i).Value
            datarow.Item("Phong") = Me.DataGridViewNhanVien.Item("Column5", i).Value
            NgayTT = Me.DateTimePickerTungay.Value.Date
            SoNgayT = 3
            Do
                NguoiMoi = TinhNgay(VTriKT, Me.DataGridViewNhanVien.Item("Column2", i).Value, NgayTT, SoGio)
                datarow(SoNgayT) = SoGio
                SoNgayT += 1
                NgayTT = DateAdd(DateInterval.Day, 1, NgayTT)
            Loop Until (NgayTT.Date > Me.DateTimePickerDenngay.Value.Date) _
                    Or (SoNgayT > 31) Or (NguoiMoi = True)

            Me.DataSetTam1.Tables("DataTable1").Rows.Add(datarow)
            '   MsgBox(Me.DataSetTam1.Tables("DataTable1").Rows(i).Item("MaNV"))
            Try
                ToolStripProgressBar1.Value += 1
            Catch ex As Exception
                ToolStripProgressBar1.Value = 0
            End Try
        Next
        ToolStripProgressBar1.Value = ToolStripProgressBar1.Maximum
    End Sub
    Private Function TinhNgay(ByRef Vtri As Integer, ByVal MaNV As String, ByVal Ngay As Date, ByRef SoGio As Double) As Boolean
        Dim NguoiKe As String = ""
        Dim NgayKe As Date
        SoGio = 0
        Do
            If CStr(Me.DataGridViewChiTiet.Item("SOGIO", Vtri).Value) = "" Then
                SoGio += Me.DataGridViewChiTiet.Item("SOGIO", Vtri).Value
            End If
            If Vtri < Me.DataGridViewChiTiet.RowCount - 1 Then
                NguoiKe = Me.DataGridViewChiTiet.Item("MaNV", Vtri + 1).Value
                NgayKe = Me.DataGridViewChiTiet.Item("ngaychamcong", Vtri + 1).Value.date
            End If
            Vtri += 1
        Loop Until (Ngay.Date <> NgayKe.Date) Or (MaNV <> NguoiKe) Or (Vtri = Me.DataGridViewChiTiet.RowCount)
        TinhNgay = False
        If (MaNV <> NguoiKe) Then TinhNgay = True

    End Function
    Private Sub XuấtBCTẤTCẢToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XuấtBCTẤTCẢToolStripMenuItem.Click
        dtoNK.User = TenNguoiDangNhap
        dtoNK.Ngay = Date.Now.Date
        dtoNK.Gio = Date.Now
        dtoNK.Tacvu = "Xuất tất cả ra File Excel"
        daoNK.Them(dtoNK)
        SaveFileDialog1.DefaultExt = "xls"
        SaveFileDialog1.Filter = "xls files (*.xls)|*.xls"
        If (SaveFileDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK) Then
            Try
                Dim duongdan As String = SaveFileDialog1.FileName
                Try
                    File.Delete(duongdan)
                Catch ex As Exception
                End Try
                TaobaocaoExcelChitiet(Microsoft.VisualBasic.Strings.Left(duongdan, duongdan.LastIndexOf(".")) & "Xu ly" & Microsoft.VisualBasic.Strings.Right(duongdan, duongdan.Length - duongdan.LastIndexOf(".")), DataGridViewChiTiet)
                TaobaocaoExcel(Microsoft.VisualBasic.Strings.Left(duongdan, duongdan.LastIndexOf(".")) & "Nhat ky" & Microsoft.VisualBasic.Strings.Right(duongdan, duongdan.Length - duongdan.LastIndexOf(".")), Me.DataGridViewNhatky)
                TaobaocaoExcelChitiet(Microsoft.VisualBasic.Strings.Left(duongdan, duongdan.LastIndexOf(".")) & "Ngay thuong" & Microsoft.VisualBasic.Strings.Right(duongdan, duongdan.Length - duongdan.LastIndexOf(".")), Me.DataGridViewNgayThuong)
                TaobaocaoExcelChitiet(Microsoft.VisualBasic.Strings.Left(duongdan, duongdan.LastIndexOf(".")) & "Ngay cuoi tuan" & Microsoft.VisualBasic.Strings.Right(duongdan, duongdan.Length - duongdan.LastIndexOf(".")), Me.DataGridViewNgayCuoiTuan)
                TaobaocaoExcelChitiet(Microsoft.VisualBasic.Strings.Left(duongdan, duongdan.LastIndexOf(".")) & "Ngay le" & Microsoft.VisualBasic.Strings.Right(duongdan, duongdan.Length - duongdan.LastIndexOf(".")), Me.DataGridViewNgayLe)
                TaobaocaoExcel(Microsoft.VisualBasic.Strings.Left(duongdan, duongdan.LastIndexOf(".")) & "Chua CC" & Microsoft.VisualBasic.Strings.Right(duongdan, duongdan.Length - duongdan.LastIndexOf(".")), Me.DataGridViewChuaCC)
                TaobaocaoExcel(Microsoft.VisualBasic.Strings.Left(duongdan, duongdan.LastIndexOf(".")) & "Nghi phep" & Microsoft.VisualBasic.Strings.Right(duongdan, duongdan.Length - duongdan.LastIndexOf(".")), Me.DataGridViewNghi)
                TaobaocaoExcel(Microsoft.VisualBasic.Strings.Left(duongdan, duongdan.LastIndexOf(".")) & "Tong hop" & Microsoft.VisualBasic.Strings.Right(duongdan, duongdan.Length - duongdan.LastIndexOf(".")), Me.DataGridViewTonghop)
                TaobaocaoExcel(Microsoft.VisualBasic.Strings.Left(duongdan, duongdan.LastIndexOf(".")) & "Tong Hop Theo Ngay" & Microsoft.VisualBasic.Strings.Right(duongdan, duongdan.Length - duongdan.LastIndexOf(".")), Me.dgvTH_Ngay)
                ' 'Taobaocao1Excel(Microsoft.VisualBasic.Strings.Left(duongdan, duongdan.LastIndexOf(".")) & "Thoi gian" & Microsoft.VisualBasic.Strings.Right(duongdan, duongdan.Length - duongdan.LastIndexOf(".")))
                ToolStripProgressBar1.Value = ToolStripProgressBar1.Maximum
            Catch ex As Exception
                MsgBox(ex.Message, , "Thông báo")
            End Try
            MsgBox("Xuất dữ liệu thành công", MsgBoxStyle.Information, "Thông báo")
        End If
    End Sub
    Private Sub XuấtChiTiếtToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XuấtChiTiếtToolStripMenuItem.Click, XuấtBCToolStripMenuItem.Click, XuấtBCNgàyThườngToolStripMenuItem.Click, XuấtBCNgàyLểToolStripMenuItem.Click, XuấtBCNgàyLểToolStripMenuItem.Click, XuấtBCNgàyCuốiTuầnToolStripMenuItem.Click, XuấtBCToolStripMenuItem1.Click, XuấtBCNhậtKýNgàyNghỉToolStripMenuItem.Click, XuấtBCNVChưaChấmCôngToolStripMenuItem.Click, XuấtBCNVToolStripMenuItem.Click, XuấtBCBảngTổngHợpTheoNgàyToolStripMenuItem.Click

        dtoNK.User = TenNguoiDangNhap
        dtoNK.Ngay = Date.Now.Date
        dtoNK.Gio = Date.Now
        dtoNK.Tacvu = "Xuất " & sender.tag & " ra File Excel"
        daoNK.Them(dtoNK)
        SaveFileDialog1.DefaultExt = "xls"
        SaveFileDialog1.Filter = "xls files (*.xls)|*.xls"
        If (SaveFileDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK) Then
            Try
                Dim duongdan As String = SaveFileDialog1.FileName
                Try
                    File.Delete(duongdan)
                Catch ex As Exception
                End Try
                Select Case UCase(sender.tag)
                    Case UCase("xuly")
                        TaobaocaoExcelChitiet(Microsoft.VisualBasic.Strings.Left(duongdan, duongdan.LastIndexOf(".")) & "Xu ly" & Microsoft.VisualBasic.Strings.Right(duongdan, duongdan.Length - duongdan.LastIndexOf(".")), DataGridViewChiTiet)
                    Case UCase("Nhatky")
                        TaobaocaoExcel(Microsoft.VisualBasic.Strings.Left(duongdan, duongdan.LastIndexOf(".")) & "Nhat ky" & Microsoft.VisualBasic.Strings.Right(duongdan, duongdan.Length - duongdan.LastIndexOf(".")), Me.DataGridViewNhatky)
                    Case UCase("Ngaythuong")
                        TaobaocaoExcelChitiet(Microsoft.VisualBasic.Strings.Left(duongdan, duongdan.LastIndexOf(".")) & "Ngay thuong" & Microsoft.VisualBasic.Strings.Right(duongdan, duongdan.Length - duongdan.LastIndexOf(".")), Me.DataGridViewNgayThuong)
                    Case UCase("Ngaycuoituan")
                        TaobaocaoExcelChitiet(Microsoft.VisualBasic.Strings.Left(duongdan, duongdan.LastIndexOf(".")) & "Ngay cuoi tuan" & Microsoft.VisualBasic.Strings.Right(duongdan, duongdan.Length - duongdan.LastIndexOf(".")), Me.DataGridViewNgayCuoiTuan)
                    Case UCase("Ngayle")
                        TaobaocaoExcelChitiet(Microsoft.VisualBasic.Strings.Left(duongdan, duongdan.LastIndexOf(".")) & "Ngay le" & Microsoft.VisualBasic.Strings.Right(duongdan, duongdan.Length - duongdan.LastIndexOf(".")), Me.DataGridViewNgayLe)
                    Case UCase("ChuaCC")
                        TaobaocaoExcel(Microsoft.VisualBasic.Strings.Left(duongdan, duongdan.LastIndexOf(".")) & "Chua CC" & Microsoft.VisualBasic.Strings.Right(duongdan, duongdan.Length - duongdan.LastIndexOf(".")), Me.DataGridViewChuaCC)
                    Case UCase("Nghiphep")
                        TaobaocaoExcel(Microsoft.VisualBasic.Strings.Left(duongdan, duongdan.LastIndexOf(".")) & "Nghi phep" & Microsoft.VisualBasic.Strings.Right(duongdan, duongdan.Length - duongdan.LastIndexOf(".")), Me.DataGridViewNghi)
                    Case UCase("Tonghop")
                        TaobaocaoExcel(Microsoft.VisualBasic.Strings.Left(duongdan, duongdan.LastIndexOf(".")) & "Tong hop" & Microsoft.VisualBasic.Strings.Right(duongdan, duongdan.Length - duongdan.LastIndexOf(".")), Me.DataGridViewTonghop)
                    Case UCase("thoigian")
                        Taobaocao1Excel(Microsoft.VisualBasic.Strings.Left(duongdan, duongdan.LastIndexOf(".")) & "Thoi gian" & Microsoft.VisualBasic.Strings.Right(duongdan, duongdan.Length - duongdan.LastIndexOf(".")))
                    Case UCase("TongHopTheoNgay")
                        TaobaocaoExcel(Microsoft.VisualBasic.Strings.Left(duongdan, duongdan.LastIndexOf(".")) & "Tong Hop Theo Ngay" & Microsoft.VisualBasic.Strings.Right(duongdan, duongdan.Length - duongdan.LastIndexOf(".")), Me.dgvTH_Ngay)
                End Select
                ToolStripProgressBar1.Value = ToolStripProgressBar1.Maximum
            Catch ex As Exception
                MsgBox(ex.Message, , "Thông báo")
            End Try
            MsgBox("Xuất dữ liệu thành công", MsgBoxStyle.Information, "Thông báo")
        End If
    End Sub
  
    Private Sub ThiếtLậpLoạiBáoCáoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ThiếtLậpLoạiBáoCáoToolStripMenuItem.Click
        Try
            Dim dtothamso As thamsodto = busThamso.LayBangDTo(1)
            Dim kieu As String = InputBox("Nhập loại báo cáo", "Thông báo", dtothamso.Maso)
            Dim a As New CacLoaiBaocao
            a.Maso = kieu
            If a.Kiemtra() Then
                dtothamso.Maso = kieu
                busThamso.sua(dtothamso)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, , "Thông báo")
        End Try
    End Sub

    

    Private Sub TinhBCHN()

        Dim BusNhanVien As New nhanvienBus(DTOKetnoi, False)

        Dim sql As String = "SELECT Nhanvien.MaNV, Nhanvien.NVSP, Nhanvien.TenNV, chucvu.Chucvu, Donvi.TenDV FROM chucvu INNER JOIN (Donvi INNER JOIN Nhanvien ON Donvi.MaDV = Nhanvien.Donvi) ON chucvu.CVID = Nhanvien.Chucvu where MaNV=" & Me.txtMa.Text
        Dim datan1 As Data.DataTable = BusNhanVien.LayBangTableSQL(sql)
        If datan1.Rows.Count <= 0 Then
            MsgBox("Nhân viên này không tồn tại!", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End If
        busnvbc.XoaALL()
        Dim dtoNVBC As New NVBCdto
        dtoNVBC.MaCC = datan1.Rows(0).Item("MaNV")
        dtoNVBC.MaNV = datan1.Rows(0).Item("NVSP")
        dtoNVBC.TenNV = datan1.Rows(0).Item("TenNV")
        dtoNVBC.Chucvu = datan1.Rows(0).Item("ChucVu")
        dtoNVBC.Bophan = datan1.Rows(0).Item("TenDV")
        busnvbc.Them(dtoNVBC)
        Me.DataGridViewNhanVien.DataSource = busnvbc.LayBangTable

        TinhCongCT()



    End Sub

    Private Sub TínhCôngChiTiếtToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TínhCôngChiTiếtToolStripMenuItem.Click
        TinhCongCT()
        ToolStripProgressBar1.Value = 0
    End Sub


    Private Sub txtMa_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMa.KeyUp
        If e.KeyValue = 13 Then
            TinhBCHN()

        End If
    End Sub

    Private Sub BCHNay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCHNay.Click
        TinhBCHN()

    End Sub

    Private Sub NhânViênChưaChấmCôngHômNayToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NhânViênChưaChấmCôngHômNayToolStripMenuItem.Click
        NhanVienChuaCCHN2()
    End Sub
    Private Sub NhanVienChuaCCHN()
        ToolStripProgressBar1.Visible = True
        DataGridViewChuaCC.Rows.Clear()
        ToolStripProgressBar1.Value = 0
        For i As Integer = 0 To DataGridViewNhanVien.Rows.Count - 1
            Dim data As System.Data.DataTable = busVaoRa.LayBangTabletheoMACCvaNGAy(DataGridViewNhanVien.Rows(i).Cells("Column1").Value, Date.Now.Date)
            If data.Rows.Count = 0 Then
                Dim k As Integer = DataGridViewChuaCC.Rows.Add
                DataGridViewChuaCC.Rows(k).Cells(0).Value = k
                For j As Integer = 1 To DataGridViewNhanVien.Columns.Count - 1
                    DataGridViewChuaCC.Rows(k).Cells(j).Value = DataGridViewNhanVien.Rows(i).Cells(j).Value
                    DataGridViewChuaCC.Rows(k).Cells(0).Value = k + 1
                    Try
                        ToolStripProgressBar1.Value += 1
                    Catch ex As Exception
                        ToolStripProgressBar1.Value = 0
                    End Try

                    'If ToolStripProgressBar1.Value = ToolStripProgressBar1.Maximum Then ToolStripProgressBar1.Value = 1
                Next
            End If
        Next
        ToolStripProgressBar1.Value = ToolStripProgressBar1.Maximum
        DataGridViewChuaCC.Focus()

        ToolStripProgressBar1.Visible = False
    End Sub
    Private Sub NhanVienChuaCCHN2()
        ToolStripProgressBar1.Visible = True
        DataGridViewChuaCC.Rows.Clear()
        ToolStripProgressBar1.Value = 0
        For i As Integer = 0 To DataGridViewNhanVien.Rows.Count - 1
            Dim data As System.Data.DataTable = busVaoRa.LayBangTabletheoMACCvaNGAy(DataGridViewNhanVien.Rows(i).Cells(0).Value, Date.Now.Date)
            If data.Rows.Count = 0 Then
                Dim k As Integer = DataGridViewChuaCC.Rows.Add
                DataGridViewChuaCC.Rows(k).Cells(0).Value = k
                For j As Integer = 0 To DataGridViewNhanVien.Columns.Count - 1
                    DataGridViewChuaCC.Rows(k).Cells(j + 1).Value = DataGridViewNhanVien.Rows(i).Cells(j).Value

                    Try
                        ToolStripProgressBar1.Value += 1
                    Catch ex As Exception
                        ToolStripProgressBar1.Value = 0
                    End Try

                Next
            End If
        Next
        ToolStripProgressBar1.Value = ToolStripProgressBar1.Maximum
        DataGridViewChuaCC.Focus()
        TabControl1.SelectedIndex = 7
        ToolStripProgressBar1.Visible = False
    End Sub
#Region "Tinh luong"
    Public Function TinhBaocaoTheoluong(ByVal thang As Integer, ByVal nam As Integer) As Boolean
        Me.DataGridViewNhanVien.DataSource = busnvbc.LayBangTable
        DateTimePickerTungay.Value = DateSerial(nam, thang, 1)
        DateTimePickerDenngay.Value = DateSerial(nam, thang, Date.DaysInMonth(nam, thang))
        TinhCongCT()
        Return True
    End Function

    Public Sub luusocong()
        If DataGridViewTonghop.RowCount <= 0 Then
            MsgBox("Bạn chưa tính công tổng hợp", , "Thông báo")
            Exit Sub
        End If
        Try

            For i As Integer = 0 To DataGridViewTonghop.RowCount - 1
                If Val(DataGridViewTonghop.Item(DataGridViewTonghop.Columns("DataGridViewTextBoxColumn50").Index, i).Value) <> 0 Then
                    Dim dto As Bangluongdto = busBangluong.LayBangDTo(DataGridViewTonghop.Item(DataGridViewTonghop.Columns("DataGridViewTextBoxColumn50").Index, i).Value, DateTimePickerTungay.Value.Month, DateTimePickerTungay.Value.Year)
                    If dto.Manv = 0 Then
                        dto.Manv = DataGridViewTonghop.Item(DataGridViewTonghop.Columns("DataGridViewTextBoxColumn50").Index, i).Value
                        Dim Thangtruoc As Date = DateAdd(DateInterval.Month, -1, DateTimePickerTungay.Value)
                        Dim dto1 As Bangluongdto = busBangluong.LayBangDTo(DataGridViewTonghop.Item(DataGridViewTonghop.Columns("DataGridViewTextBoxColumn50").Index, i).Value, Thangtruoc.Month, Thangtruoc.Year)
                        dto.Thang = DateTimePickerTungay.Value.Month
                        dto.Nam = DateTimePickerTungay.Value.Year
                        dto.LuongThang = dto1.LuongThang
                        dto.Luongngay = dto1.Luongngay
                        dto.TienBH = dto1.TienBH
                        dto.TienComTrua = dto1.TienComTrua
                        dto.Phucap2 = dto1.Phucap2
                        dto.Phucap1 = dto1.Phucap1
                        dto.TienGuiXe = dto1.TienGuiXe

                    End If
                    dto.Socong = DataGridViewTonghop.Rows(i).Cells("Column35").Value
                    dto.Phatditre = DataGridViewTonghop.Rows(i).Cells("Column38").Value ' nghi co phep
                    dto.SoGioTc = DataGridViewTonghop.Rows(i).Cells("Column30").Value
                    dto.NgayGuiXe = DataGridViewTonghop.Rows(i).Cells("Column52").Value
                    'dto.TienGuiXe = DataGridViewTonghop.Rows(i).Cells("Column52").Value * dtoPhucapluong.TienXe
                    dto.Solannghikophep = DataGridViewTonghop.Rows(i).Cells("Column46").Value  ' Dùng cho cả có phép và không phép
                    'dto.PhanTramBH = CDbl(DataGridViewTonghop.Rows(i).Cells("Column37").Value) ' Phan tram bao hiem la so cong ngay chu Nhat
                    dto.TienAnTC = DataGridViewTonghop.Rows(i).Cells("TienAnTangCa").Value
                    dto.Songay = DataGridViewTonghop.Rows(i).Cells("Column6").Value 'songayCN 'số ngày chủ nhật
                    dto.NgayCN = DataGridViewTonghop.Rows(i).Cells("Column9").Value
                    dto.SuatAnTrua = DataGridViewTonghop.Rows(i).Cells("TienComTrua").Value
                    Try
                       
                        busBangluong.Them(dto)

                    Catch ex As Exception
                        busBangluong.sua(dto)
                    End Try
                Else

                End If
            Next
            MsgBox("Lưu sổ công  tháng: " & DateTimePickerTungay.Value.Month & "  Năm: " & DateTimePickerTungay.Value.Year & "  thành công", , "Thông báo")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Thông báo")
        End Try
    End Sub
#End Region
    Private Sub TsbLuuSoCong_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsbLuuSoCong.Click
        Try
            luusocong()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ManHinhBaoCao_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            Dim duongdan As String = ""
            'File tham so
            duongdan = My.Application.Info.DirectoryPath & "\Thamso.dll"
            Try
                File.Delete(duongdan)
            Catch ex As Exception
            End Try
            TaoFileBut(duongdan)
            duongdan = My.Application.Info.DirectoryPath & "\DataGridViewChiTiet.Dll"
            File.Delete(duongdan)
            LuuCotAn(DataGridViewChiTiet, duongdan)
            Dim duongdan1 As String = My.Application.Info.DirectoryPath & "\DataGridViewTonghop.Dll"
            File.Delete(duongdan1)
            LuuCotAn(DataGridViewTonghop, duongdan1)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Form1.Dgv = DataGridViewTonghop
        Form1.ShowDialog()
    End Sub

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        ManhinhNVtheoDV.ShowDialog()
        DataGridViewNhanVien.DataSource = busnvbc.LayBangNhanVienBaoCao
        XemNVDCChon(True)
        ToolStripStatusLabel1.Text = "Số nhân viên báo cáo là: " & DataGridViewNhanVien.Rows.Count
    End Sub

    Private Sub DataGridViewChiTiet_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewChiTiet.CellDoubleClick
        If e.RowIndex = -1 Then Exit Sub
        If e.ColumnIndex = 7 Or e.ColumnIndex = 8 Then
            Manhinhchongiols.Cot = e.ColumnIndex
            Manhinhchongiols.Hang = e.RowIndex
            Manhinhchongiols.Show()
        End If

    End Sub

End Class
'MT4.2
