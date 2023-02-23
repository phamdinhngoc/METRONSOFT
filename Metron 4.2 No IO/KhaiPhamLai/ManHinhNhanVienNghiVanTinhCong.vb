Imports System.Windows.Forms

Public Class ManHinhNhanVienNghiVanTinhCong
    Dim bus As New nhanvienBus(DTOKetnoi, False)
    Dim dto As New nhanviendto
    Dim busdonvi As New donviBus(DTOKetnoi, False)
    Dim dtodonvi As New donvidto
    Dim busNVnghi As New NVnghiphepBus(DTOKetnoi, False)
    Dim buslydo As New lydoBus(DTOKetnoi, False)

#Region "TreeView"
    Private Sub cay()
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
#Region "Xem nhan vien"
    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        Dim data As DataTable = bus.LayBangTabletheodonvi(TreeView1.SelectedNode.Name)
        DataGridView1.DataSource = data
        If data.Rows.Count <= 0 Then
            TreeView1.Enabled = True
            DataGridView1.Enabled = True
            Dim data1 As DataTable = busNVnghi.LayBangTable(-1)
            DataGridViewNghi.DataSource = data1
        Else
        End If

        'AnMo(False, GroupBox1)
    End Sub
#End Region
#End Region
#Region "Luoi nhan vien"
#Region "Xem ngay nghi"
    Private Sub DataGridView1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.SelectionChanged
        Dim data As New DataTable
        If DataGridView1.Rows.Count <= 0 Then
            Exit Sub
        End If
        data = busNVnghi.LayBangTabletheoNvid(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("ColMaNV").Value)
        DataGridViewNghi.DataSource = data
        If data.Rows.Count > 0 Then
            ToolStripButtonXoa.Enabled = True
        Else
            ToolStripButtonXoa.Enabled = False
        End If
    End Sub
#End Region

#End Region
#Region "Luoi ngay nghi"
    Private Sub ComboBoxlydo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBoxlydo.KeyDown
        If e.KeyData = Keys.Enter Then
            TextBoxSongay.Focus()
        End If
    End Sub
    Private Sub TextBoxSongay_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxSongay.KeyDown
        If e.KeyData = Keys.Enter Then
            TextBoxSocong.Focus()
        End If
    End Sub
    Private Sub TextBoxSocong_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxSocong.KeyDown
        If e.KeyData = Keys.Enter Then
            ButtonLuu.Focus()
        End If
    End Sub
    Private Sub TextBoxSongay_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxSongay.TextChanged
        If Not IsNumeric(TextBoxSongay.Text) Then
            ErrorProvider1.SetError(TextBoxSongay, "Yêu cầu nhập số")
            ButtonLuu.Enabled = False
        Else
            ErrorProvider1.SetError(TextBoxSongay, "")
            ButtonLuu.Enabled = True
        End If
    End Sub
    Private Sub TextBoxSocong_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxSocong.TextChanged
        If Not IsNumeric(TextBoxSocong.Text) Then
            ErrorProvider1.SetError(TextBoxSocong, "Yêu cầu nhập số")
            ButtonLuu.Enabled = False
        Else
            ErrorProvider1.SetError(TextBoxSocong, "")
            ButtonLuu.Enabled = True
        End If
    End Sub
#Region "Thêm,xóa"
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Panel2.Visible = True
        Panel1.Visible = False
        ComboBoxlydo.Focus()
    End Sub
    Private Sub ButtonLuuLichTangCa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonLuu.Click
        Try
            If DataGridView1.SelectedRows.Count <= 0 Then
                MsgBox("Bạn chưa chọn nhân viên không thể thêm", , "Thông báo")
                Exit Sub
            End If
            For i As Integer = 0 To DataGridView1.SelectedRows.Count - 1
                Dim dtoNVnghi As New NVnghiphepdto
                dtoNVnghi.MaNV = DataGridView1.SelectedRows(i).Cells("ColMaNV").Value
                dtoNVnghi.Ngay = DateTimePickerNgay.Value.Date
                dtoNVnghi.Lydo = ComboBoxlydo.Text
                dtoNVnghi.SoCong = TextBoxSocong.Text
                dtoNVnghi.SoNgay = TextBoxSongay.Text
                busNVnghi.Them(dtoNVnghi)
            Next
            DataGridViewNghi.DataSource = busNVnghi.LayBangTabletheoNvid(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("ColMaNV").Value)
            Panel2.Visible = False
            Panel1.Visible = True
            MsgBox("Thêm ngày nghỉ hoàn thành", , "Thông báo")
            ToolStripButtonXoa.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message, , "Thông báo")
        End Try
    End Sub
    Private Sub ButtonXoaLichTangCa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonXoa.Click
        Panel2.Visible = False
        Panel1.Visible = True
    End Sub
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonXoa.Click
        If MsgBox("Bạn có muốn xóa ngày nghỉ này không?", MsgBoxStyle.OkCancel, "Thông báo") = MsgBoxResult.Ok Then
            Try
                For I As Integer = 0 To DataGridViewNghi.SelectedRows.Count - 1
                    busNVnghi.Xoa(DataGridViewNghi.SelectedRows(I).Cells("IDNP").Value)
                Next
                DataGridViewNghi.DataSource = busNVnghi.LayBangTabletheoNvid(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("ColMaNV").Value)
                MsgBox("Xóa ngày nghỉ hoàn thành", , "Thông báo")
                If DataGridViewNghi.Rows.Count = 0 Then ToolStripButtonXoa.Enabled = False
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
#End Region
#Region "Xem lich"
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        DataGridViewNghi.DataSource = busNVnghi.LaybangTheoNvidTungayDenNgay(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("ColMaNV").Value, DateTimePicker1.Value, DateTimePicker2.Value)
    End Sub
#End Region
#End Region
#Region "Context menu"
    Private Sub AllColumns(Optional ByVal Hien As Boolean = True)
        Dim j As Integer = 0
        If Not Hien Then
            DataGridView1.Columns(0).Visible = True
            j = 1
        End If
        For i As Integer = j To DataGridView1.Columns.Count - 1
            DataGridView1.Columns(i).Visible = Hien
        Next
    End Sub
    Private Sub ContextMenuStrip1_Opened(ByVal sender As Object, ByVal e As System.EventArgs) Handles ContextMenuStrip1.Opened
        Dim M As System.Windows.Forms.ToolStripMenuItem
        Me.DanhSáchCộtToolStripMenuItem.DropDownItems.Clear()
        For i As Integer = 0 To DataGridView1.ColumnCount - 1
            M = Me.DanhSáchCộtToolStripMenuItem.DropDownItems.Add(DataGridView1.Columns(i).HeaderText)
            M.Name = DataGridView1.Columns(i).Name
            M.Tag = i
            M.CheckOnClick = True
            M.Checked = DataGridView1.Columns(i).Visible
        Next
    End Sub
#Region " Hiển Thị cột "
    Private Sub HiểnThịTấtCảCộtToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HiểnThịTấtCảCộtToolStripMenuItem.Click
        AllColumns()
    End Sub
    Private Sub ẨnTấtCảCácCộtToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ẨnTấtCảCácCộtToolStripMenuItem.Click
        AllColumns(False)
    End Sub
    Private Sub HiểnThịCộtThườngDùngToolStripMenuItem_DropDownItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles DanhSáchCộtToolStripMenuItem.DropDownItemClicked
        DataGridView1.Columns(e.ClickedItem.Name).Visible = Not DataGridView1.Columns(e.ClickedItem.Name).Visible
    End Sub
    Private Sub HiểnThịCộtThườngDùngToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HiểnThịCộtThườngDùngToolStripMenuItem.Click
        For i As Integer = 0 To DataGridView1.Columns.Count - 1
            If i <> 1 And i <> 2 And i <> 4 Then
                DataGridView1.Columns(i).Visible = False
            Else
                DataGridView1.Columns(i).Visible = True
            End If
        Next
    End Sub
#End Region
#End Region
    Private Sub ManHinhNhanVienNghiVanTinhCong_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cay()
        ComboBoxlydo.ValueMember = "idld"
        ComboBoxlydo.DisplayMember = "lydo"
        ComboBoxlydo.DataSource = buslydo.LayBangTable
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ManHinhLydo.ShowDialog()
        ComboBoxlydo.ValueMember = "idld"
        ComboBoxlydo.DisplayMember = "lydo"
        ComboBoxlydo.DataSource = buslydo.LayBangTable
    End Sub

    Private Sub ComboBoxlydo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxlydo.SelectedIndexChanged
        Dim dto As lydodto = buslydo.LayBangDTo(ComboBoxlydo.SelectedValue)
        TextBoxSongay.Text = dto.NgayQD
        TextBoxSocong.Text = dto.SoCong
    End Sub

    Private Sub TreeView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TreeView1.KeyDown
        If e.KeyData = Keys.Enter Then
            DataGridView1.Focus()
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class