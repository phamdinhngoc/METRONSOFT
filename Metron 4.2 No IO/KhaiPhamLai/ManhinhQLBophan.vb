Imports System.Windows.Forms

Public Class ManhinhQLBophan
    Dim bus As New nhanvienBus(DTOKetnoi, False)
    Dim dto As New nhanviendto
    Dim busdonvi As New donviBus(DTOKetnoi, False)
    Dim dtodonvi As New donvidto
    Public TenDV As String
    Public MaDV As Integer

#Region "TreeView"
    Private Sub cay()
        Me.TreeView1.Nodes.Clear()
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
#End Region
#Region "Thêm xoá sửa đơn vị"
    Private Sub themDonvi()
        dtodonvi.TenDV = InputBox("Nhập tên phòng ban mới", "Thông báo")
        If dtodonvi.TenDV = "" Then
            Exit Sub
        End If
        dtodonvi.Nhanh = TreeView1.SelectedNode.Name
        busdonvi.Them(dtodonvi)
        TreeView1.Nodes.Clear()
        cay()
    End Sub
    Private Sub xoaDonvi()
        Try
            If TreeView1.SelectedNode.Nodes.Count > 0 Then
                MsgBox("Không thể xóa " & vbNewLine & "Vì Phòng ban : " & TreeView1.SelectedNode.Text & vbNewLine & "                   có đơn vị con" & vbNewLine & "Đơn vị chỉ xóa được khi không có đơn vị con và không có nhân viên", , "Thông báo")
                Exit Sub
            End If
            If TreeView1.SelectedNode.Name = 1 Then
                MsgBox("Bạn không được xóa bộ phận này.", MsgBoxStyle.Information, "Thông báo")
                Exit Sub
            End If
            If bus.LayBangTabletheodonvi(TreeView1.SelectedNode.Name).Rows.Count > 0 Then
                Dim Msg As MsgBoxResult = MsgBox("Đơn vị này : " & TreeView1.SelectedNode.Text & vbNewLine & "                   có Nhân Viên" & vbNewLine & "Yes:Xoá Tất Cả Nhân Viên " & vbNewLine & "No:Chuyển Nhân Viên sang bộ phận khác" & vbNewLine & "Cancel:Trở về ban đầu ,Không xóa", MsgBoxStyle.YesNoCancel, "Thông báo")
                If Msg = MsgBoxResult.Yes Then
                    bus.Xoatheodonvi(TreeView1.SelectedNode.Name)
                ElseIf Msg = MsgBoxResult.No Then
                    frmTree.ShowDialog()
                Else
                End If
                Exit Sub
            End If
            If MsgBox("Bạn muốn xoá phòng ban :" & TreeView1.SelectedNode.Text, MsgBoxStyle.OkCancel, "Thông báo") = MsgBoxResult.Ok Then
                busdonvi.Xoa(TreeView1.SelectedNode.Name)
                TreeView1.Nodes.Clear()
                cay()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub suaDonvi()
        Try
            dtodonvi.TenDV = InputBox("Nhập tên phòng ban mới", "Thông báo", TreeView1.SelectedNode.Text)
            If dtodonvi.TenDV = "" Then
                Exit Sub
            End If
            dtodonvi.MaDV = TreeView1.SelectedNode.Name
            busdonvi.sua(dtodonvi)
            TreeView1.Nodes.Clear()
            cay()
            TreeView1.Focus()
        Catch ex As Exception
            MsgBox("Bạn chưa Chọn đơn vị muốn sửa")
        End Try
    End Sub
    Private Sub ThêmToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ThêmToolStripMenuItem.Click, ToolStripButton1.Click
        If TreeView1.Visible = False Then Exit Sub
        themDonvi()
    End Sub

    Private Sub SửaBộPhậnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SửaBộPhậnToolStripMenuItem.Click, ToolStripButton3.Click
        If TreeView1.Visible = False Then Exit Sub
        suaDonvi()
    End Sub

    Private Sub XóaBộPhậnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XóaBộPhậnToolStripMenuItem.Click, ToolStripButton2.Click
        If TreeView1.Visible = False Then Exit Sub
        xoaDonvi()
    End Sub
#End Region

    Private Sub ManhinhQLBophan_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            Frmnhanvien.TreeView1.Nodes.Clear()
            Frmnhanvien.cay()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ManhinhQLBophan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cay()
    End Sub

    Private Sub TreeView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TreeView1.DoubleClick
        MaDV = Me.TreeView1.SelectedNode.Name
        TenDV = Me.TreeView1.SelectedNode.Text
        If MsgBox("Bạn có chắc là muốn chọn bộ phận " & Me.TreeView1.SelectedNode.Text & " để báo cáo không?", _
            MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Thông báo") = MsgBoxResult.Yes Then Close()
    End Sub
End Class