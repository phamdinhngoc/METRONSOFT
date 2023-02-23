Imports BrightIdeasSoftware
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Windows.Forms

Public Class ManhinhLuong
    Dim bus As New nhanvienBus(DTOKetnoi, False)
    Dim dto As New nhanviendto
    Dim busnvbc As New NVBCBus(DTOKetnoi, False)
    Dim busChucvu As New chucvuBus(DTOKetnoi, False)
    Dim dtochucvu As New chucvudto
    Dim busdonvi As New donviBus(DTOKetnoi, False)
    Dim dtodonvi As New donvidto
    Dim busnhanvien As New nhanvienBus(DTOKetnoi, False)
    Dim BUSBANGLUONG As New BangluongBus(DTOKetnoi, False)
    Dim dataTungaydenngay As New DataTable
    Dim PtDitrevesom As Double
    Dim Ptnghikophep As Double
    Dim Tenphongban As String = ""
    Dim tuyY As Boolean = False
    Dim I As Integer = 0
    Dim sotrang As Integer
    Dim busPhucapluong As New PhucapluongBus(DTOKetnoi, False)
    Dim dtoPhucapluong As New Phucapluongdto

#Region "TreeView"
    Private Sub cay()
        Dim tvRoot As TreeNode
        dtodonvi = busdonvi.LayBangDTo(1)
        tvRoot = Me.TreeView1.Nodes.Add(dtodonvi.MaDV, dtodonvi.TenDV)
        TaoCay(tvRoot, 1)
        TreeView1.ExpandAll()
    End Sub
    Private Sub TaoCay(ByVal tvRoot As TreeNode, Optional ByVal nhanh As Integer = 1)
        Dim cay As DataTable = busdonvi.LayBangTableTheoNhanh(nhanh)
        Dim tvNode As TreeNode
        If cay.Rows.Count <= 0 Then Exit Sub
        For i As Integer = 0 To cay.Rows.Count - 1
            tvNode = tvRoot.Nodes.Add(cay.Rows(i)("madv"), cay.Rows(i)("tendv"), 1, 0)
            TaoCay(tvNode, cay.Rows(i)("madv"))
        Next
    End Sub
    Private Sub lamtronThanhTien(ByRef Number As Integer)
        If (Number Mod 1000) >= 500 Then
            Number = ((Number \ 1000) + 1) * 1000
        Else
            Number = (Number \ 1000) * 1000
        End If
    End Sub
    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        Try
            Tenphongban = TreeView1.SelectedNode.Text
        Catch ex As Exception
        End Try
    End Sub
#End Region
#Region "In ấn"
    Private Sub InitializeListPrinting()
        ' For some reason the Form Designer loses these settings 
        'Me.PrintPreviewControl1.Zoom = 2
        'Me.printPreviewControl1.AutoZoom = True
        Me.UpdatePrintPreview()
    End Sub
    Private Sub UpdatePrintPreview()
        Me.listViewPrinter1.ListView = Me.ListView1
        Dim Title As String = ""
        Dim Footer As String = "\t\tTrang: {0}"
        Dim Header As String = ToolStripStatusLabel1.Text
        Dim Watermark As String = ""
        Me.listViewPrinter1.DocumentName = Title
        Me.listViewPrinter1.Header = Header.Replace("\t", vbTab)
        Me.listViewPrinter1.Footer = Footer.Replace("\t", vbTab)
        Me.listViewPrinter1.Watermark = Watermark

        Me.ApplyMinimalFormatting()
        Me.listViewPrinter1.ListGridPen = New Pen(Color.DarkGray, 0.5F)

        Me.listViewPrinter1.FirstPage = 1
        Me.listViewPrinter1.LastPage = 100

        Me.PrintPreviewControl1.InvalidatePreview()
    End Sub
    Private Sub ToolStripButton14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton14.Click
        Try
            listViewPrinter1.PrintWithDialog()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Thông báo")
        End Try
    End Sub
    Private Sub TabControl1_Selected(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles TabControl1.Selected
        If (e.TabPageIndex = 1) Then UpdatePrintPreview()
        If (e.TabPageIndex = 2) Then PrintPhieuLuong()
    End Sub
    Private Sub listViewPrinter1_QueryPageSettings(ByVal sender As Object, ByVal e As System.Drawing.Printing.QueryPageSettingsEventArgs) Handles listViewPrinter1.QueryPageSettings
        If tuyY = True Then e.PageSettings.Landscape = True
    End Sub
    Private Sub ToolStripButton22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton22.Click
        listViewPrinter1.PageSetup()
        tuyY = True
        UpdatePrintPreview()
    End Sub
#Region "Màu sắc giao diện"
    Public Sub ApplyMinimalFormatting()
        Me.listViewPrinter1.CellFormat = Nothing
        Me.listViewPrinter1.ListFont = New Font("Tahoma", 9)
        Me.listViewPrinter1.ListView.HeaderStyle = 1
        Me.listViewPrinter1.HeaderFormat = BlockFormat.Header(New Font("Verdana", 12, FontStyle.Bold))
        Me.listViewPrinter1.HeaderFormat.TextBrush = Brushes.Black
        Me.listViewPrinter1.HeaderFormat.BackgroundBrush = Nothing
        Me.listViewPrinter1.HeaderFormat.SetBorderPen(Sides.Bottom, New Pen(Color.Black, 0.2F))

        Me.listViewPrinter1.FooterFormat = BlockFormat.Footer()
        Me.listViewPrinter1.GroupHeaderFormat = BlockFormat.GroupHeader()
        Dim brush As Brush = New LinearGradientBrush(New Point(0, 0), New Point(200, 0), Color.Gray, Color.White)
        Me.listViewPrinter1.GroupHeaderFormat.SetBorder(Sides.Bottom, 2, brush)

        Me.listViewPrinter1.ListHeaderFormat = BlockFormat.ListHeader()
        Me.listViewPrinter1.ListHeaderFormat.BackgroundBrush = Nothing

        Me.listViewPrinter1.WatermarkFont = Nothing
        Me.listViewPrinter1.WatermarkColor = Color.Empty
        Checkall(False)
        ToolStripMenuItem4.Checked = True
        PrintPreviewControl1.Zoom = 1
        ListView1.HeaderStyle = ColumnHeaderStyle.Clickable
    End Sub

#End Region
#Region "Cách thể hiện giấy In"
    Private Sub ToolStripButton20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dòng được chọn 
        UpdatePrintPreview()
    End Sub

    Private Sub ToolStripButton23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Có hình trong báo cáo
        UpdatePrintPreview()
    End Sub
    Private Sub ToolStripButton21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Chỉnh độ rộng cột
        UpdatePrintPreview()
    End Sub
    Private Sub ToolStripButton24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Ve duong bien luoi
        UpdatePrintPreview()
    End Sub
#End Region
#Region "Zoom Bang luong"
    Private Sub Checkall(Optional ByVal check As Boolean = False)
        For i As Integer = 0 To ToolStripButton15.DropDownItems.Count - 1
            Dim toolstrip As ToolStripMenuItem = ToolStripButton15.DropDownItems(i)
            toolstrip.Checked = False
        Next
    End Sub
    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        Checkall(False)
        ToolStripMenuItem2.Checked = True
        '500
        PrintPreviewControl1.Zoom = 5
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        Checkall(False)
        ToolStripMenuItem3.Checked = True
        '200
        PrintPreviewControl1.Zoom = 2
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        Checkall(False)
        ToolStripMenuItem4.Checked = True
        '100
        PrintPreviewControl1.Zoom = 1
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        Checkall(False)
        ToolStripMenuItem5.Checked = True
        '50
        PrintPreviewControl1.Zoom = 0.5
    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        Checkall(False)
        ToolStripMenuItem6.Checked = True
        '25
        PrintPreviewControl1.Zoom = 0.25
    End Sub

    Private Sub AutoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoToolStripMenuItem.Click
        Checkall(False)
        AutoToolStripMenuItem.Checked = True
        'auto
        PrintPreviewControl1.Zoom = 1
    End Sub
#End Region
    Public Sub kiemtracacgiaTri(ByRef dto As Bangluongdto, ByVal songay As Integer, ByVal dtophucapluong As Phucapluongdto)
        'dto.Songay là số ngày chủ nhât

        If dto.LuongThang = 0 Then

        Else
            dto.Luongngay = dto.LuongThang / songay
            dto.Luongngay = CInt(dto.Luongngay) ' - CInt(str) + 1000
            dto.Luongngaycong = dto.LuongThang
            Dim str As String = Microsoft.VisualBasic.Strings.Right(dto.Luongngaycong, 3)
            If CInt(str) >= 500 Then
                dto.Luongngaycong = CInt(dto.Luongngaycong) - CInt(str) + 1000
            Else
                dto.Luongngaycong = CInt(dto.Luongngaycong) - CInt(str)
            End If
            dto.phatnghikophep = 0
            dto.phatnghikophep = dto.Luongngay * dto.Solannghikophep
            str = Microsoft.VisualBasic.Strings.Right(dto.phatnghikophep, 3)
            If CInt(str) >= 500 Then
                dto.phatnghikophep = CInt(dto.phatnghikophep) - CInt(str) + 1000
            Else
                dto.phatnghikophep = CInt(dto.phatnghikophep) - CInt(str)
            End If
            dto.LuongCN = dto.PhanTramBH * dto.Luongngay
            dto.TienTcGio = (dto.LuongThang / 30) / 8
            dto.TienTangca = dto.TienTcGio * dto.SoGioTc
            dto.TienComTrua = dto.SuatAnTrua * dtophucapluong.TienComTrua
            dto.TongTienXe = dto.NgayGuiXe * dto.TienGuiXe
            dto.ThucLanh = dto.Luongngaycong + dto.Phucap1 + dto.TienTangca + dto.TienAnTC - dto.TienBH - dto.Tamung1 - dto.phatnghikophep + dto.LuongCN + dto.TongTienXe + dto.TienComTrua + dto.Phucap2
            dto.ThucLanh = CInt(dto.ThucLanh)
            Dim str1 As String = Microsoft.VisualBasic.Strings.Right(dto.ThucLanh, 3)
            If CInt(str1) >= 500 Then
                dto.ThucLanh = Convert.ToDouble(dto.ThucLanh) - CInt(str1) + 1000
            Else
                dto.ThucLanh = Convert.ToDouble(dto.ThucLanh) - CInt(str1)
            End If
            dto.ThucLanh = Format(CInt(dto.ThucLanh), "#,##0")

        End If
    End Sub
#End Region
#Region "Phieu luong tung nhan vien "
#Region "Print Button Click Event"

    Private Sub PrintPhieuLuong()
        PrintPreviewControl2.InvalidatePreview()
    End Sub
#End Region
#Region "Query setting page"
    Private Sub printDocument1_QueryPageSettings(ByVal sender As Object, ByVal e As System.Drawing.Printing.QueryPageSettingsEventArgs) Handles printDocument1.QueryPageSettings
        e.PageSettings.Landscape = True
        'e.PageSettings.PaperSource=
    End Sub
#End Region
#Region "Begin Print Event Handler"
    ''' <summary>
    ''' Handles the begin print event of print document
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
#End Region
#Region "Print Page Event"

    Private Sub printDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles printDocument1.PrintPage
        Try
            Dim Phieuluong1 As New PhieuLuong
            Phieuluong1.vebien(True, e)
            Dim Col As System.Windows.Forms.ColumnHeader = ListView1.Columns(1)
            Dim dem As Integer = 0

            While dem < 4
                If ListView1.Items(I).SubItems(0).Text <> "" Then
                    Phieuluong1 = New PhieuLuong
                    Phieuluong1.f = New Font(ListView1.Font, FontStyle.Regular)
                    Phieuluong1.fLon = New Font(ListView1.Font, FontStyle.Bold)
                    Phieuluong1.Ten_tieude1 &= ToolStripComboBoxThang.Text & "/" & ToolStripcomboboxNam.Text
                    Phieuluong1.Ten_tieude2 &= "1/" & ToolStripComboBoxThang.Text & "->" & Date.DaysInMonth(ToolStripcomboboxNam.Text, ToolStripComboBoxThang.Text) & "/" & ToolStripComboBoxThang.Text
                    'Thong tin nhan vien
                    Phieuluong1.Manv &= ListView1.Items(I).SubItems(0).Text
                    Phieuluong1.Tennv &= ListView1.Items(I).SubItems(1).Text
                    Phieuluong1.Chucvu &= ListView1.Items(I).SubItems(2).Text
                    Phieuluong1.bophan &= ListView1.Items(I).Tag
                    'Thong tin luong 
                    For j As Integer = 3 To 4
                        Try

                            Phieuluong1.Ds_TTluongTD.Add(ListView1.Columns(j).Text)
                            Phieuluong1.Ds_TTluong.Add(ListView1.Items(I).SubItems(j).Text)
                        Catch ex As Exception
                        End Try
                    Next
                    'Cong tien
                    For j As Integer = 10 To 20
                        Try

                            Phieuluong1.Ds_CongLuongTD.Add(ListView1.Columns(j).Text)
                            Phieuluong1.Ds_CongLuong.Add(ListView1.Items(I).SubItems(j).Text)

                        Catch ex As Exception
                        End Try
                    Next
                    'Tru tien
                    For j As Integer = 5 To 9
                        Try
                            Phieuluong1.Ds_TruLuongTD.Add(ListView1.Columns(j).Text)
                            Phieuluong1.Ds_TruLuong.Add(ListView1.Items(I).SubItems(j).Text)

                        Catch ex As Exception
                        End Try
                    Next
                    'hien thi in an
                    'Phieuluong1.Thanhtien1TD = ListView1.Columns(50).Text
                    'Phieuluong1.Thanhtien1 = ListView1.Items(I).SubItems(50).Text
                    'Phieuluong1.Thanhtien2TD = ListView1.Columns(51).Text
                    'Phieuluong1.Thanhtien2 = ListView1.Items(I).SubItems(51).Text
                    Phieuluong1.ThuclanhTD = ListView1.Columns(21).Text
                    Phieuluong1.Thuclanh = ListView1.Items(I).SubItems(21).Text
                    'Phieuluong1.Docso = Doc_so(CInt(Phieuluong1.Thuclanh))
                    Phieuluong1.Hienthi(6, True, dem, e, PictureBox1.Image)
                    dem += 1
                End If
                I += 1
            End While
            If I <= ListView1.Items.Count - 1 Then
                e.HasMorePages = True
                sotrang += 1
            Else
                I = 0
                e.HasMorePages = False
            End If
        Catch exc As Exception
            'MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            I = 0
            e.HasMorePages = False
        End Try
        PrintPreviewControl2.Zoom = 1

    End Sub
#End Region
#Region "Phieu Luong"
#Region "In an Phieu luong"
    Private Sub ToolStripButton28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton28.Click
        Dim printDialog As New PrintDialog()
        printDialog.Document = printDocument1
        printDialog.UseEXDialog = True
        'Get the document
        If DialogResult.OK = printDialog.ShowDialog() Then
            printDocument1.DocumentName = "Test Page Print"
            printDocument1.PrinterSettings.MinimumPage = 1
            printDocument1.PrinterSettings.MaximumPage = 100
            printDocument1.Print()
        End If
    End Sub
#End Region
#Region "Zoom Phieu luong"
    Private Sub Checkall2(Optional ByVal check As Boolean = False)
        For i As Integer = 0 To ToolStripDropDownButton1.DropDownItems.Count - 1
            Dim toolstrip As ToolStripMenuItem = ToolStripDropDownButton1.DropDownItems(i)
            toolstrip.Checked = False
        Next
    End Sub
    Private Sub ToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem7.Click
        Checkall2(False)
        ToolStripMenuItem7.Checked = True
        '500
        PrintPreviewControl2.Zoom = 5
    End Sub
    Private Sub ToolStripMenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem8.Click
        Checkall2(False)
        ToolStripMenuItem8.Checked = True
        '200
        PrintPreviewControl2.Zoom = 2
    End Sub
    Private Sub ToolStripMenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem9.Click
        Checkall2(False)
        ToolStripMenuItem9.Checked = True
        '100
        PrintPreviewControl2.Zoom = 1
    End Sub
    Private Sub ToolStripMenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem10.Click
        Checkall2(False)
        ToolStripMenuItem10.Checked = True
        '50
        PrintPreviewControl2.Zoom = 0.5
    End Sub
    Private Sub ToolStripMenuItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem11.Click
        Checkall2(False)
        ToolStripMenuItem11.Checked = True
        '25
        PrintPreviewControl2.Zoom = 0.25
    End Sub
    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Checkall2(False)
        ToolStripMenuItem1.Checked = True
        'auto
        PrintPreviewControl2.Zoom = 1
    End Sub
#End Region
#Region "Hien thi"
    Private Sub ToolStripButton29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton29.Click
        Dim A As New PageSetupDialog
        A.Document = printDocument1
        A.EnableMetric = True
        A.ShowDialog()
        PrintPreviewControl2.InvalidatePreview()
    End Sub

    Private Sub ToolStripButton30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton30.Click
        'trang.Items.Clear()
        PrintPreviewControl2.Rows = 1
        PrintPreviewControl2.Columns = 1
        'For p As Integer = 1 To sotrang
        '    trang.Items.Add(p)
        'Next
        PrintPreviewControl2.InvalidatePreview()
    End Sub
    Private Sub ToolStripButton31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton31.Click
        PrintPreviewControl2.Rows = 1
        PrintPreviewControl2.Columns = 2
        'For p As Integer = 1 To sotrang / 2 - 1
        '    trang.Items.Add(p * 2 + 1 & "->" & p * 2 + 2)
        'Next
        PrintPreviewControl2.InvalidatePreview()
    End Sub
    Private Sub ToolStripButton32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton32.Click

        PrintPreviewControl2.Rows = 2
        PrintPreviewControl2.Columns = 2
        'For p As Integer = 1 To sotrang / 4 - 1
        '    trang.Items.Add(p * 4 + 1 & "->" & p * 4 + 2)
        'Next
        PrintPreviewControl2.InvalidatePreview()
    End Sub
    Private Sub ToolStripButton33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton33.Click
        Try
            Dim a As Double = Math.Sqrt(sotrang)
            If a Mod 1 > 0 Then a = a - (a Mod 1) + 1
            PrintPreviewControl2.Rows = a
            PrintPreviewControl2.Columns = a
            'For p As Integer = 1 To sotrang / 9 - 1
            '    trang.Items.Add(p * 9 + 1 & "->" & p * 9 + 2)
            'Next
            PrintPreviewControl2.InvalidatePreview()
        Catch ex As Exception

        End Try

    End Sub
#End Region
#End Region
#End Region

#Region "File"
    Private Sub DocFileBut(ByVal duongdanFile As String)
        Dim file As FileStream
        Dim reader As StreamReader
        Try
            file = New FileStream(duongdanFile, FileMode.Open)
            reader = New StreamReader(file)
            PtDitrevesom = reader.ReadLine()
            Ptnghikophep = reader.ReadLine()
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
            If IsNumeric(PtDitrevesom) Then
                writer.WriteLine(PtDitrevesom)
            Else
                writer.WriteLine(5)
            End If
            If IsNumeric(Ptnghikophep) Then
                writer.WriteLine(Ptnghikophep)
            Else
                writer.WriteLine(10)
            End If
            writer.Close()
            file.Close()
        Catch EX As Exception
            Return (EX.Message)
        End Try
        Return "1"
    End Function
#End Region

    Private Sub ManhinhLuong_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim duongdan As String = ""
        'File tham so
        duongdan = My.Application.Info.DirectoryPath & "\ThamsoLuong.dll"
        Try
            File.Delete(duongdan)
        Catch ex As Exception
        End Try
        TaoFileBut(duongdan)
    End Sub
    Private Sub ManhinhLuong_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If ObjectListView.IsVista Then
            Me.Font = New Font("Segoe UI", 9)
        End If
        cay()
        Dim Thangtruoc As Date = DateAdd(DateInterval.Month, -1, Now)
        ToolStripComboBoxThang.Text = Thangtruoc.Month
        ToolStripcomboboxNam.Text = Thangtruoc.Year
        DocFileBut(My.Application.Info.DirectoryPath & "\ThamsoLuong.dll")
    End Sub
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        SplitContainer2.Panel1Collapsed = ToolStripButton1.Checked
    End Sub
#Region "Tinh luong"
    Private Function ChuoiBoPhanDK() As String
        Dim dk As String = ""
        For I As Integer = 0 To TreeView1.Nodes.Count - 1
            If TreeView1.Nodes(I).Checked Then dk = dk & " or Donvi.MaDV= " & TreeView1.Nodes(I).Name
            If TreeView1.Nodes(I).Nodes.Count > 0 Then ChuoiBpDK(dk, TreeView1.Nodes(I))
        Next
        Return dk
    End Function

    Private Sub ChuoiBpDK(ByRef dk As String, ByVal NODE As TreeNode)
        For I As Integer = 0 To NODE.Nodes.Count - 1
            If NODE.Nodes(I).Checked Then dk = dk & " or Donvi.MaDV= " & NODE.Nodes(I).Name
            If NODE.Nodes(I).Nodes.Count > 0 Then ChuoiBpDK(dk, NODE.Nodes(I))
        Next
    End Sub
    Private Sub KiemTraTreeView(ByRef arr As ArrayList)
        For I As Integer = 0 To TreeView1.Nodes.Count - 1
            If TreeView1.Nodes(I).Checked Then arr.Add(TreeView1.Nodes(I).Name)
            If TreeView1.Nodes(I).Nodes.Count > 0 Then listBoban(arr, TreeView1.Nodes(I))
        Next
    End Sub
    Private Sub listBoban(ByRef Arr As ArrayList, ByVal node As TreeNode)
        For I As Integer = 0 To node.Nodes.Count - 1
            If node.Nodes(I).Checked Then Arr.Add(node.Nodes(I).Name)
            If node.Nodes(I).Nodes.Count > 0 Then listBoban(Arr, node.Nodes(I))
        Next
    End Sub
    Public Sub REfreshF5()
        ToolStripProgressBar1.Visible = True
        ToolStripStatusLabel1.Text = "BẢNG LƯƠNG THÁNG " & ToolStripComboBoxThang.Text & " NĂM " & ToolStripcomboboxNam.Text
        Try
            LoadLuong()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Thông báo")
        End Try
        ToolStripProgressBar1.Visible = False
    End Sub
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        ListView1.Items.Clear()
        ListView1.Groups.Clear()
        REfreshF5()
    End Sub
    Private Sub LoadLuong()
        ListView1.Items.Clear()
        Dim arr As New ArrayList
        KiemTraTreeView(arr)
        Dim TongNV As Integer = 0
        Dim Tongluong As Double = 0
        Dim TongBH As Double = 0
        Dim TongTienXe As Double = 0
        Dim tongLuongNgayCong As Double = 0
        Dim TongSoCong As Double = 0
        Dim TongPhuCap As Double = 0
        Dim TongTamUng As Double = 0
        Dim TongSGTC As Double = 0
        Dim TongtienTC As Double = 0
        Dim TongSoNgayNghi As Integer = 0
        Dim PhatNghi As Double = 0
        Dim NgayChuNhat As Double = 0
        Dim LuongCN As Double = 0
        Dim TongTienAn As Double = 0
        Dim dataPhucapluong As DataTable = busPhucapluong.LayBangTableSQL("select * from phucapluong")
        dtoPhucapluong = busPhucapluong.LayBangDTo(0, dataPhucapluong)
        For I As Integer = 0 To arr.Count - 1
            dtodonvi = busdonvi.LayBangDTo(arr.Item(I))
            Dim grp As New ListViewGroup
            grp.Name = dtodonvi.MaDV
            grp.Header = dtodonvi.TenDV
            ListView1.Groups.Add(grp)
            Dim dataLuong As DataTable = BUSBANGLUONG.LayBangTablebophan1(ToolStripComboBoxThang.Text, ToolStripcomboboxNam.Text, dtodonvi.MaDV)
            'Dim dataPhucapluong As DataTable = busPhucapluong.LayBangTableSQL("select * from phucapluong")
            'dtoPhucapluong = busPhucapluong.LayBangDTo(0, dataPhucapluong)
            If dataLuong.Rows.Count > 0 Then
                Dim tongluongnhom As Double = 0
                For j As Integer = 0 To dataLuong.Rows.Count - 1
                    Dim DTO As New Bangluongdto
                    DTO = BUSBANGLUONG.LayBangDTo(j, dataLuong)
                    kiemtracacgiaTri(DTO, 30, dtoPhucapluong) 'Số ngày 30 theo yêu cầu của khách (chị Lý)
                    Dim item As New ListViewItem
                    item.Name = dataLuong.Rows(j)("NhanVien.Manv")
                    If item.Name < 10 Then
                        item.Text = "00" & item.Name
                    ElseIf item.Name > 9 And item.Name < 100 Then
                        item.Text = "0" & item.Name
                    Else
                        item.Text = item.Name
                    End If
                    item.Tag = grp.Header
                    item.SubItems.AddRange(New String() {dataLuong.Rows(j)("TenNv"), dataLuong.Rows(j)("ChucVu.ChucVu"), Format(DTO.LuongThang, "#,##0"), Format(DTO.Luongngay, "#,##0"), DTO.Solannghikophep, Format(DTO.phatnghikophep, "#,##0"), DTO.Phatditre, Format(DTO.TienBH, "#,##0"), Format(DTO.Tamung1, "#,##0"), DTO.SoGioTc, Format(DTO.TienTcGio, "#,##0"), Format(DTO.TienTangca, "#,##0"), Format(DTO.TienAnTC, "#,##0"), Format(DTO.Phucap1, "#,##0"), Format(DTO.Phucap2, "#,##0"), DTO.PhanTramBH, Format(DTO.LuongCN, "#,##0"), Format(DTO.ChuyenCan, "#,##0"), Format(DTO.TongTienXe, "#,##0"), Format(DTO.TienComTrua, "#,##0"), Format(DTO.ThucLanh, "#,##0")})
                    TongSoCong += DTO.Socong
                    tongLuongNgayCong += DTO.Luongngaycong
                    TongPhuCap += DTO.Phucap1
                    TongTamUng += DTO.Tamung1
                    TongSGTC += DTO.SoGioTc
                    TongtienTC += DTO.TienTangca
                    TongBH += DTO.TienBH
                    TongTienXe += DTO.TongTienXe
                    tongluongnhom += DTO.ThucLanh
                    TongSoNgayNghi += DTO.Solannghikophep
                    PhatNghi += DTO.phatnghikophep
                    NgayChuNhat += DTO.PhanTramBH
                    LuongCN += DTO.LuongCN
                    TongTienAn += DTO.TienAnTC
                    item.Group = grp
                    ListView1.Items.Add(item)
                    BUSBANGLUONG.sua(DTO)
                Next
                grp.Header = UCase(grp.Header) & " - " & " Số nhân viên: " & dataLuong.Rows.Count & ", " & "Tổng thực lãnh: " & Format(tongluongnhom, "#,##0")
                TongNV += dataLuong.Rows.Count
                Tongluong += tongluongnhom
            End If
            If I = arr.Count - 1 Then
                Dim grpTong As New ListViewGroup
                grpTong.Name = "ZK"
                grpTong.Header = "TỔNG CỘNG  " & TongNV & " NV"
                ListView1.Groups.Add(grpTong)
                Dim item7 As New ListViewItem
                item7.Name = "7a"
                item7.Text = ""
                item7.Group = grpTong
                item7.SubItems.AddRange(New String() {"Tổng lương tháng: ", Format(tongLuongNgayCong, "#,##0")})
                ListView1.Items.Add(item7)

                Dim item As New ListViewItem
                item.Name = "lkm"
                item.Text = ""
                item.Group = grpTong
                item.SubItems.AddRange(New String() {"Tổng phạt nghỉ: ", Format(PhatNghi, "#,##0")})
                ListView1.Items.Add(item)
                Dim item1 As New ListViewItem
                item1.Name = "1a"
                item1.Text = ""
                item1.Group = grpTong
                item1.SubItems.AddRange(New String() {"Tổng bảo hiểm: ", Format(TongBH, "#,##0")})
                ListView1.Items.Add(item1)
                Dim item2 As New ListViewItem
                item2.Name = "2a"
                item2.Text = ""
                item2.Group = grpTong
                item2.SubItems.AddRange(New String() {"Tổng tạm ứng: ", Format(TongTamUng, "#,##0")})
                ListView1.Items.Add(item2)
                Dim item3 As New ListViewItem
                item3.Name = "3a"
                item3.Text = ""
                item3.Group = grpTong
                item3.SubItems.AddRange(New String() {"Tổng tiền TC: ", Format(TongtienTC, "#,##0")})
                ListView1.Items.Add(item3)
                Dim item4 As New ListViewItem
                item4.Name = "4a"
                item4.Text = ""
                item4.Group = grpTong
                item4.SubItems.AddRange(New String() {"Tổng tiền ăn: ", Format(TongTienAn, "#,##0")})
                ListView1.Items.Add(item4)
                Dim item5 As New ListViewItem
                item5.Name = "5a"
                item5.Text = ""
                item5.Group = grpTong
                item5.SubItems.AddRange(New String() {"Tổng phụ cấp: ", Format(TongPhuCap, "#,##0")})
                ListView1.Items.Add(item5)
                Dim item6 As New ListViewItem
                item6.Name = "6a"
                item6.Text = ""
                item6.Group = grpTong
                item6.SubItems.AddRange(New String() {"Tổng thực lãnh: ", Format(Tongluong, "#,##0")})
                ListView1.Items.Add(item6)
            End If
        Next
    End Sub



#End Region
#Region "Tinh cong"
    Private Sub Tinhcong()
        Try
            If ListView1.Items.Count <= 1 Then
                MsgBox("Bộ phận bạn chọn không có nhân viên ", MsgBoxStyle.Critical, "Thông báo")
                Exit Sub
            End If
            busnvbc.XoaALL()
            For i As Integer = 0 To ListView1.Items.Count - 1
                Try
                    Dim dtoNVBC As New NVBCdto
                    dtoNVBC.MaCC = ListView1.Items(i).SubItems(0).Text
                    dtoNVBC.MaNV = ListView1.Items(i).SubItems(0).Text
                    dtoNVBC.TenNV = ListView1.Items(i).SubItems(1).Text
                    dtoNVBC.Chucvu = ListView1.Items(i).SubItems(2).Text
                    dtoNVBC.Bophan = ListView1.Items(i).Tag
                    If dtoNVBC.MaCC <> 0 Then busnvbc.Them(dtoNVBC)
                Catch ex As Exception
                End Try
            Next
            ManHinhBaoCao.Owner = ManHinhChinh
            ManHinhBaoCao.Show()
            ManHinhBaoCao.ToolStripButton7.Visible = True
            If Not ManHinhBaoCao.TinhBaocaoTheoluong(ToolStripComboBoxThang.Text, ToolStripcomboboxNam.Text) Then
                MsgBox("Bộ phận bạn chọn không có nhân viên", MsgBoxStyle.Exclamation, "Thông báo")
            Else
                'ManHinhBaoCao.TinhCongCT()
                ManHinhBaoCao.TinhCongTongHop()
                ManHinhBaoCao.luusocong()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Thông báo")
        End Try
    End Sub
    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Tinhcong()
    End Sub
#End Region


    Private Sub tsmXemThongTin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmXemThongTin.Click
        Try

            XemThongTinLuong()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Thông báo")
        End Try
    End Sub
    Private Sub XemThongTinLuong()
        If ListView1.SelectedItems(0) IsNot Nothing Then
            Dim Dto As New Bangluongdto
            Dto = BUSBANGLUONG.LayBangDTo(ListView1.SelectedItems(0).Name, ToolStripComboBoxThang.Text, ToolStripcomboboxNam.Text)
            If Dto.Manv = 0 Then
                Dto.Manv = ListView1.SelectedItems(0).Name
            End If
            frmThongTinLuong.DtoLuong = Dto
            frmThongTinLuong.ShowDialog()
        End If
    End Sub
    'Private Sub XemThongTinPhuCapLuong()

    '    frmPhuCapLuong.ShowDialog()
    'End Sub
    Dim sortColumn As Integer = -1
    Private Sub listView1_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles ListView1.ColumnClick

        If e.Column <> sortColumn Then
            sortColumn = e.Column
            ListView1.Sorting = SortOrder.Ascending
        Else
            If ListView1.Sorting = SortOrder.Ascending Then
                ListView1.Sorting = SortOrder.Descending
            Else
                ListView1.Sorting = SortOrder.Ascending
            End If
        End If
        ListView1.Sort()
        Try
            ListView1.ListViewItemSorter = New ListViewItemComparer(e.Column, ListView1.Sorting)
        Catch ex As Exception

        End Try

    End Sub


    Private Sub ListView1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseDoubleClick
        Try
            XemThongTinLuong()
        Catch ex As Exception

        End Try
    End Sub
    Public columindex As Boolean

    Private Sub tsbHotroNhap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbHotroNhap.Click
        Try

            frmHoTroNhap.Show()
        Catch ex As Exception

        End Try
    End Sub

 
    Private Sub tsb_phucapluong_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsb_phucapluong.Click
        Try

            'XemThongTinPhuCapLuong()
            frmPhuCapLuong.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Thông báo")
        End Try
    End Sub
End Class

Class ListViewItemComparer
    Implements IComparer
    Private col As Integer
    Private order As SortOrder

    Public Sub New()
        col = 0
        order = SortOrder.Ascending
    End Sub

    Public Sub New(ByVal column As Integer, ByVal order As SortOrder)
        col = column
        Me.order = order
    End Sub

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare

        Dim returnVal As Integer = -1
        returnVal = [String].Compare(CType(x, ListViewItem).SubItems(col).Text, CType(y, ListViewItem).SubItems(col).Text)
        If order = SortOrder.Descending Then
            returnVal *= -1
        End If

        Return returnVal
    End Function
End Class