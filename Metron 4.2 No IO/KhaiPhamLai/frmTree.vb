Public Class frmTree
    Dim bus As New nhanvienBus(DTOKetnoi, False)
    Dim dto As New nhanviendto
    Dim busdonvi As New donviBus(DTOKetnoi, False)
    Dim dtodonvi As New donvidto
    Private Function NapdulieuDTO(ByVal data As DataGridViewRow) As nhanviendto
        Dim dto As New nhanviendto
        dto.MaNV = data.Cells("colmanv").Value
        dto.NVSP = data.Cells("colnvsp").Value
        dto.TenNV = data.Cells("coltenNV").Value
        dto.TenHT = data.Cells("coltenht").Value
        dto.Chucvu = data.Cells("colchucvu").Value
        dto.Quyen = data.Cells("colquyen").Value
        dto.CardNo = data.Cells("colMathe").Value
        dto.Ngaysinh = data.Cells("colNgaysinh").Value
        dto.Gioitinh = data.Cells("colgioitinh").Value
        dto.Diachi = data.Cells("coldiachi").Value
        dto.CMND = data.Cells("colcmnd").Value
        dto.Ngayvaolam = data.Cells("colngayvaolam").Value
        dto.Hinh = data.Cells("colHinh").Value
        Return dto
    End Function
#Region "TreeView"
    Private Sub cay()
        Me.TreeView1.Nodes.Clear()
        Dim tvRoot As TreeNode
        dtodonvi = busdonvi.LayBangDTo(1)
        tvRoot = Me.TreeView1.Nodes.Add(dtodonvi.MaDV, dtodonvi.TenDV)
        TaoCay(tvRoot, 1)
    End Sub
    Private Sub TaoCay(ByVal tvRoot As TreeNode, Optional ByVal nhanh As Integer = 0)
        Dim cay As DataTable = busdonvi.LayBangTableTheoNhanh(nhanh)
        Dim tvNode As TreeNode
        If cay.Rows.Count <= 0 Then Exit Sub
        For i As Integer = 0 To cay.Rows.Count - 1
            tvNode = tvRoot.Nodes.Add(cay.Rows(i)("madv"), cay.Rows(i)("tendv"), 1, 0)
            TaoCay(tvNode, cay.Rows(i)("madv"))
        Next
    End Sub

    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        TextBox1.Text = TreeView1.SelectedNode.Text
    End Sub
#End Region

    Private Sub frmTree_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        ManHinhChinh.CửaSổHoạtĐộngToolStripMenuItem.DropDownItems.Remove(ManHinhChinh.CửaSổHoạtĐộngToolStripMenuItem.DropDownItems(Me.Name))
        ToolStripDropDownButton1.DropDownItems.Clear()
    End Sub
    Private Sub frmTree_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ManHinhChinh.CửaSổHoạtĐộngToolStripMenuItem.DropDownItems.Add("Giao Diện Chuyển Nhân Viên").Name = Me.Name
        cay()
        ToolStripProgressBar1.Value = 0
        ToolStripDropDownButton1.Text = Frmnhanvien.bttBoPhan.SelectedRows.Count
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try

            ToolStripProgressBar1.Value = 0
            ToolStripProgressBar1.Maximum = Frmnhanvien.bttBoPhan.SelectedRows.Count + 1
            If TextBox1.Text = "" Then
                MsgBox("Bạn chưa chọn bộ phận muốn chuyển tới", , "Thông báo")
                Exit Sub
            End If
            If Frmnhanvien.TreeView1.SelectedNode.Name = TreeView1.SelectedNode.Name Then
                MsgBox("Trong cùng 1 bộ phận thì không thể chuyển nhân viên", , "Thông báo")
                Exit Sub
            End If
            For i As Integer = 0 To Frmnhanvien.bttBoPhan.SelectedRows.Count - 1
                dto.MaNV = Frmnhanvien.bttBoPhan.SelectedRows(i).Cells(0).Value
                dto.Donvi = TreeView1.SelectedNode.Name
                bus.suaDonvi(dto.Donvi, dto.MaNV)
                Try
                    ToolStripProgressBar1.Value += 1
                Catch ex As Exception
                    ToolStripProgressBar1.Value = 0
                End Try

            Next
            Frmnhanvien.bttBoPhan.DataSource = bus.LayBangTabletheodonvi(Frmnhanvien.TreeView1.SelectedNode.Name)

            ToolStripProgressBar1.Value = ToolStripProgressBar1.Maximum

            MsgBox("Đã chuyển " & ToolStripProgressBar1.Value - 1 & " nhân viên " & vbNewLine & "từ bộ phận: " & Frmnhanvien.TreeView1.SelectedNode.Text & "  đến bộ phận :" & TreeView1.SelectedNode.Text, , "Thông báo")
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TreeView2_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs)

    End Sub

    Private Sub TreeView1_AfterSelect_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs)

    End Sub
End Class