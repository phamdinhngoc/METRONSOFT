Imports KhaiPhamLai.ClassGDMay
Public Class ManHinhTaiDulieu
    Dim busdonvi As New donviBus(DTOKetnoi, False)
    Dim dtodonvi As New donvidto
    Dim bus As New nhanvienBus(DTOKetnoi, False)
    Dim dto As New nhanviendto
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
    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        Dim data As DataTable = bus.LayBangTabletheodonvi(TreeView1.SelectedNode.Name)
        If data.Rows.Count <= 0 Then
            TreeView1.Enabled = True
            DataGridView1.Enabled = True
        Else
        End If
        DataGridView1.DataSource = data
        TreeView1.Focus()
        'AnMo(False, GroupBox1)
    End Sub
#End Region
    Private Sub SetUpListViewColumns()
        ListView1.Columns.Add("Tên máy", 150)
        ListView1.Columns.Add("Vị trí", 110)
        ListView1.Columns.Add("MM", 30)
        ListView1.Columns.Add("MS", 30)
        ListView1.Columns.Add("LM", 30)

        SetView(View.Details)
    End Sub

    Private Sub SetView(ByVal View As System.Windows.Forms.View)
        ListView1.View = View
    End Sub
    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChọnTấtCảToolStripMenuItem.Click
        Try
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                DataGridView1.Rows(i).Cells(0).Value = True
            Next
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ĐảoChọnToolStripMenuItem.Click
        Try
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                DataGridView1.Rows(i).Cells(0).Value = Not DataGridView1.Rows(i).Cells(0).Value
            Next
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ManHinhTaiDulieu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetUpListViewColumns()
        If TaoCSMay(Me.ListView1) = False Then Close()
        cay()
        TreeView1.Focus()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Close()
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ListView1.Focus()
        Dim GDMay As New ClassGDMay
        GDMay.UpDuLieuNV(Me.ListView1, Me.DataGridView1, Me.chkTaiVT.Checked, Me.Pb)
    End Sub

  
   
    
    Private Sub ManHinhTaiDulieu_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            TreeView1.Focus()
        Catch ex As Exception

        End Try
    End Sub
End Class