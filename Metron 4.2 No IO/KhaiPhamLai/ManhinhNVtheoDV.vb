Public Class ManhinhNVtheoDV
    Dim bus As New nhanvienBus(DTOKetnoi, False)
    Dim dto As New nhanviendto
    Public Trangthai As String = ""
    Dim busnvbc As New NVBCBus(DTOKetnoi, False)
    Dim busdonvi As New donviBus(DTOKetnoi, False)
    Dim dtodonvi As New donvidto
    Private Sub ManhinhNVtheoDV_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cay()
        TreeView1.ExpandAll()
    End Sub
#Region "Context menu"
#Region " Hiển Thị cột "
    Private Sub AllColumns(Optional ByVal Hien As Boolean = True)
        Dim j As Integer = 0
        If Not Hien Then
            DataGridView1.Columns(1).Visible = True
            j = 2
        End If
        For i As Integer = j To DataGridView1.ColumnCount - 1
            DataGridView1.Columns(i).Visible = Hien
        Next
        MãCcToolStripMenuItem.Checked = True
        MãNhânViênToolStripMenuItem.Checked = Hien
        TênNhânViênToolStripMenuItem.Checked = Hien
        TênHiểnThịToolStripMenuItem.Checked = Hien
        ChứcVụToolStripMenuItem.Checked = Hien
        ĐơnVịToolStripMenuItem.Checked = Hien
        QuyềnToolStripMenuItem.Checked = Hien
        MãThẻToolStripMenuItem.Checked = Hien
        NgàySinhToolStripMenuItem.Checked = Hien
        GiớiTínhToolStripMenuItem.Checked = Hien
        ĐịaChỉToolStripMenuItem.Checked = Hien
        ChứngMinhNhânDânToolStripMenuItem.Checked = Hien
        NgàyVàoLàmToolStripMenuItem.Checked = Hien
        HinhToolStripMenuItem.Checked = Hien
    End Sub
    Private Sub HiểnThịTấtCảCộtToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HiểnThịTấtCảCộtToolStripMenuItem.Click
        AllColumns()
    End Sub
    Private Sub ẨnTấtCảCácCộtToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ẨnTấtCảCácCộtToolStripMenuItem.Click
        AllColumns(False)
    End Sub
    Private Sub HiểnThịCộtThườngDùngToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HiểnThịCộtThườngDùngToolStripMenuItem.Click
        MãNhânViênToolStripMenuItem.Checked = False
        DataGridView1.Columns(1 + 1).Visible = False
        ĐơnVịToolStripMenuItem.Checked = False
        DataGridView1.Columns(5 + 1).Visible = False
        QuyềnToolStripMenuItem.Checked = False
        DataGridView1.Columns(6 + 1).Visible = False
        MãThẻToolStripMenuItem.Checked = False
        DataGridView1.Columns(7 + 1).Visible = False
        ĐịaChỉToolStripMenuItem.Checked = False
        DataGridView1.Columns(10 + 1).Visible = False
        ChứngMinhNhânDânToolStripMenuItem.Checked = False
        DataGridView1.Columns(11 + 1).Visible = False
        HinhToolStripMenuItem.Checked = False
        DataGridView1.Columns(13 + 1).Visible = False
        MãCcToolStripMenuItem.Checked = True
        DataGridView1.Columns(0 + 1).Visible = True
        TênNhânViênToolStripMenuItem.Checked = True
        DataGridView1.Columns(2 + 1).Visible = True
        TênHiểnThịToolStripMenuItem.Checked = True
        DataGridView1.Columns(3 + 1).Visible = True
        ChứcVụToolStripMenuItem.Checked = True
        DataGridView1.Columns(4 + 1).Visible = True
        NgàySinhToolStripMenuItem.Checked = True
        DataGridView1.Columns(8 + 1).Visible = True
        GiớiTínhToolStripMenuItem.Checked = True
        DataGridView1.Columns(9 + 1).Visible = True
        NgàyVàoLàmToolStripMenuItem.Checked = True
        DataGridView1.Columns(12 + 1).Visible = True
    End Sub
    Private Sub MãCcToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MãCcToolStripMenuItem.Click
        MãCcToolStripMenuItem.Checked = Not MãCcToolStripMenuItem.Checked
        'ColMaNV.Visible = Not ColMaNV.Visible
        DataGridView1.Columns(0 + 1).Visible = Not DataGridView1.Columns(0 + 1).Visible
    End Sub
    Private Sub MãNhânViênToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MãNhânViênToolStripMenuItem.Click
        MãNhânViênToolStripMenuItem.Checked = Not MãNhânViênToolStripMenuItem.Checked
        'colNVSP.Visible = Not colNVSP.Visible
        DataGridView1.Columns(1 + 1).Visible = Not DataGridView1.Columns(1 + 1).Visible
    End Sub
    Private Sub TênNhânViênToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TênNhânViênToolStripMenuItem.Click
        TênNhânViênToolStripMenuItem.Checked = Not TênNhânViênToolStripMenuItem.Checked
        'colTenNV.Visible = Not colTenNV.Visible
        DataGridView1.Columns(2 + 1).Visible = Not DataGridView1.Columns(2 + 1).Visible
    End Sub
    Private Sub TênHiểnThịToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TênHiểnThịToolStripMenuItem.Click
        TênHiểnThịToolStripMenuItem.Checked = Not TênHiểnThịToolStripMenuItem.Checked
        'colTenHT.Visible = Not colTenHT.Visible
        DataGridView1.Columns(3 + 1).Visible = Not DataGridView1.Columns(3 + 1).Visible
    End Sub
    Private Sub ChứcVụToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChứcVụToolStripMenuItem.Click
        ChứcVụToolStripMenuItem.Checked = Not ChứcVụToolStripMenuItem.Checked
        'colChucvu.Visible = Not colChucvu.Visible
        DataGridView1.Columns(4 + 1).Visible = Not DataGridView1.Columns(4 + 1).Visible
    End Sub
    Private Sub ĐơnVịToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ĐơnVịToolStripMenuItem.Click
        ĐơnVịToolStripMenuItem.Checked = Not ĐơnVịToolStripMenuItem.Checked
        'colDonvi.Visible = Not colDonvi.Visible
        DataGridView1.Columns(5 + 1).Visible = Not DataGridView1.Columns(5 + 1).Visible
    End Sub
    Private Sub QuyềnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuyềnToolStripMenuItem.Click
        QuyềnToolStripMenuItem.Checked = Not QuyềnToolStripMenuItem.Checked
        'colQuyen.Visible = Not colQuyen.Visible
        DataGridView1.Columns(6 + 1).Visible = Not DataGridView1.Columns(6 + 1).Visible
    End Sub
    Private Sub MãThẻToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MãThẻToolStripMenuItem.Click
        MãThẻToolStripMenuItem.Checked = Not MãThẻToolStripMenuItem.Checked
        'colMathe.Visible = Not colMathe.Visible
        DataGridView1.Columns(7 + 1).Visible = Not DataGridView1.Columns(7 + 1).Visible
    End Sub
    Private Sub NgàySinhToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NgàySinhToolStripMenuItem.Click
        NgàySinhToolStripMenuItem.Checked = Not NgàySinhToolStripMenuItem.Checked
        'colNgaysinh.Visible = Not colNgaysinh.Visible
        DataGridView1.Columns(8 + 1).Visible = Not DataGridView1.Columns(8 + 1).Visible
    End Sub
    Private Sub GiớiTínhToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GiớiTínhToolStripMenuItem.Click
        GiớiTínhToolStripMenuItem.Checked = Not GiớiTínhToolStripMenuItem.Checked
        'colGioiTinh.Visible = Not colGioiTinh.Visible
        DataGridView1.Columns(9 + 1).Visible = Not DataGridView1.Columns(9 + 1).Visible
    End Sub
    Private Sub ĐịaChỉToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ĐịaChỉToolStripMenuItem.Click
        ĐịaChỉToolStripMenuItem.Checked = Not ĐịaChỉToolStripMenuItem.Checked
        'colDiachi.Visible = Not colDiachi.Visible
        DataGridView1.Columns(10 + 1).Visible = Not DataGridView1.Columns(10 + 1).Visible
    End Sub
    Private Sub ChứngMinhNhânDânToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChứngMinhNhânDânToolStripMenuItem.Click
        ChứngMinhNhânDânToolStripMenuItem.Checked = Not ChứngMinhNhânDânToolStripMenuItem.Checked
        'colCMND.Visible = Not colCMND.Visible
        DataGridView1.Columns(11 + 1).Visible = Not DataGridView1.Columns(11 + 1).Visible
    End Sub
    Private Sub NgàyVàoLàmToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NgàyVàoLàmToolStripMenuItem.Click
        NgàyVàoLàmToolStripMenuItem.Checked = Not NgàyVàoLàmToolStripMenuItem.Checked
        'colNgayvaolam.Visible = Not colNgayvaolam.Visible
        DataGridView1.Columns(12 + 1).Visible = Not DataGridView1.Columns(12 + 1).Visible
    End Sub
    Private Sub HinhToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HinhToolStripMenuItem.Click
        HinhToolStripMenuItem.Checked = Not HinhToolStripMenuItem.Checked
        DataGridView1.Columns(13 + 1).Visible = Not DataGridView1.Columns(13 + 1).Visible
    End Sub
#End Region
    Private Sub ChọnTấtCảToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChọnTấtCảToolStripMenuItem.Click
        sender.Checked = Not sender.Checked
        DataGridView1.EndEdit()
        For i As Integer = 0 To DataGridView1.RowCount - 1
            DataGridView1.Rows(i).Cells(0).Value = sender.Checked
        Next
    End Sub
    Private Sub BỏChọnTấtCảToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BỏChọnTấtCảToolStripMenuItem.Click
        DataGridView1.EndEdit()
        For i As Integer = 0 To DataGridView1.RowCount - 1
            DataGridView1.Rows(i).Cells(0).Value = Not DataGridView1.Rows(i).Cells(0).Value
        Next
    End Sub
#End Region
#Region "TreeView"
    Private Sub cay()
        TreeView1.Nodes.Clear()
        Dim tvRoot As TreeNode
        dtodonvi = busdonvi.LayBangDTo(1)
        tvRoot = Me.TreeView1.Nodes.Add(dtodonvi.MaDV, dtodonvi.TenDV)
        TaoCay(tvRoot, 1)
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
    Private Sub CheckedallChild(ByVal tvRoot As TreeNode)
        For i As Integer = 0 To tvRoot.Nodes.Count - 1
            tvRoot.Nodes(i).Checked = tvRoot.Checked
            CheckedallChild(tvRoot.Nodes(i))
        Next
    End Sub
    Private Sub TreeView1_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterCheck
        Try
            CheckedallChild(e.Node)
            Dim data As DataTable = bus.LayBangTableCodk(ChuoiBoPhanDK())
            DataGridView1.DataSource = data
        Catch ex As Exception
        End Try
    End Sub
#End Region
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        ToolStripProgressBar1.Visible = True
        DataGridView1.EndEdit()
        busnvbc.XoaALL()
        ToolStripProgressBar1.Value = 0
        ToolStripProgressBar1.Maximum = DataGridView1.RowCount + 10
        For i As Integer = 0 To DataGridView1.RowCount - 1
            If DataGridView1.Rows(i).Cells(0).Value Then
                Dim dtoNVBC As New NVBCdto
                dtoNVBC.MaCC = DataGridView1.Rows(i).Cells("ColMaNV").Value
                dtoNVBC.MaNV = DataGridView1.Rows(i).Cells("colNVSP").Value
                dtoNVBC.TenNV = DataGridView1.Rows(i).Cells("colTenNV").Value
                dtoNVBC.Chucvu = DataGridView1.Rows(i).Cells("colChucvu").Value
                dtoNVBC.Bophan = DataGridView1.Rows(i).Cells("colDonvi").Value
                busnvbc.Them(dtoNVBC)
            End If
            ToolStripProgressBar1.Value += 1
        Next
        ToolStripProgressBar1.Maximum = 100
        ToolStripProgressBar1.Visible = False
        Me.Close()
    End Sub
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        ToolStripProgressBar1.Visible = True
        ToolStripProgressBar1.Value = 0
        ToolStripProgressBar1.Maximum = DataGridView1.RowCount + 10
        For i As Integer = 0 To DataGridView1.RowCount - 1
            If DataGridView1.Rows(i).Cells(0).Value Then
                If busnvbc.LayBangTabletheoMaCC(DataGridView1.Rows(i).Cells("ColMaNV").Value).Rows.Count <= 0 Then
                    Dim dtoNVBC As New NVBCdto
                    dtoNVBC.MaCC = DataGridView1.Rows(i).Cells("ColMaNV").Value
                    dtoNVBC.MaNV = DataGridView1.Rows(i).Cells("colNVSP").Value
                    dtoNVBC.TenNV = DataGridView1.Rows(i).Cells("colTenNV").Value
                    dtoNVBC.Chucvu = DataGridView1.Rows(i).Cells("colChucvu").Value
                    dtoNVBC.Bophan = DataGridView1.Rows(i).Cells("colDonvi").Value
                    busnvbc.Them(dtoNVBC)
                End If
            End If
            ToolStripProgressBar1.Value += 1
        Next
        ToolStripProgressBar1.Visible = False
        Me.Close()
        ' If MsgBox("Bạn có muốn chọn tiếp nhân viên báo cáo không?", MsgBoxStyle.YesNo, "Thông báo") = MsgBoxResult.No Then Close()

    End Sub



    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        If DataGridView1.CurrentRow.Cells(0).Value = False Then
            DataGridView1.CurrentRow.Cells(0).Value = True
        Else
            DataGridView1.CurrentRow.Cells(0).Value = False
        End If
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        For i As Integer = 0 To DataGridView1.RowCount - 1
            DataGridView1.Rows(i).Cells(0).Value = sender.Checked
        Next
    End Sub
End Class