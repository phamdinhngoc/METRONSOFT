Imports KhaiPhamLai.ClassGDMay

Public Class ManHinhQlNVtrenMCC
    Dim BusMay As New MayBus(DTOKetnoi, False)
    Dim dtomay As New Maydto
    Dim Bus As New nhanvienBus(DTOKetnoi, False)
    Dim GDMay As New ClassGDMay



    Private Sub SetUpListViewColumns()
        ListView1.Columns.Add("Tên máy", 150)
        ListView1.Columns.Add("Vị trí", 110)
        ListView1.Columns.Add("MM", 30)
        ListView1.Columns.Add("MS", 30)
        ListView1.Columns.Add("LM", 30)

        SetView(Windows.Forms.View.Details)

    End Sub

    Private Sub SetView(ByVal View As System.Windows.Forms.View)
        ListView1.View = View
    End Sub
    Private Sub ManHinhQlNVtrenMCC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        SetUpListViewColumns()
        If TaoCSMay(Me.ListView1) = False Then Close()
        Me.chkXoaVT.Checked = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.dgvCo.EndEdit()
        If ListView1.Items.Count <= 0 Then
            MsgBox("Không có máy chấm công đã kết nối", , "Thông báo")
            Exit Sub
        End If

        GDMay.DocDLNV(Me.ListView1, Me.dgvCo, Me.dgvKo, pb)
        Me.dgvTT.Rows.Add(Me.dgvTT.Rows.Count, "Kiểm tra người dùng trên máy chấm công")
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
#Region "Context memu"
    Private Sub ChọnTấtCảToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChọnTấtCảToolStripMenuItem.Click, bttcheckall.Click
        Try
            For i As Integer = 0 To dgvCo.Rows.Count - 1
                dgvCo.Rows(i).Cells(0).Value = True
            Next
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ĐảoChọnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ĐảoChọnToolStripMenuItem.Click, bttDaoChon.Click
        Try
            For i As Integer = 0 To dgvCo.Rows.Count - 1
                dgvCo.Rows(i).Cells(0).Value = Not dgvCo.Rows(i).Cells(0).Value
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click, bttcheckall1.Click
        Try
            For i As Integer = 0 To dgvKo.Rows.Count - 1
                dgvKo.Rows(i).Cells(0).Value = True
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click, bttdaochon2.Click
        Try
            For i As Integer = 0 To dgvKo.Rows.Count - 1
                dgvKo.Rows(i).Cells(0).Value = Not dgvKo.Rows(i).Cells(0).Value
            Next
        Catch ex As Exception
        End Try
    End Sub
#End Region

    Private Sub TảiVềToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TảiVềToolStripMenuItem.Click
        GDMay.UpdateNV(Me.dgvCo, Me.ListView1, Me.ChkTaiVT.Checked, pb)

    End Sub
 
    Private Sub TảiVềToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TảiVềToolStripMenuItem1.Click
        GDMay.ThemNVMay(dgvKo, Me.ListView1, Me.ChkTaiVT.Checked, pb)

    End Sub

    Private Sub XóaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XóaToolStripMenuItem.Click
        GDMay.XoaDLCo(Me.ListView1, dgvCo, Me.chkXoaVT.Checked, pb)

    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        GDMay.XoaDLKo(Me.ListView1, dgvKo, Me.chkXoaVT.Checked, pb)
    End Sub

    Private Sub ContextMenuStrip2_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip2.Opening
        dgvCo.Focus()
    End Sub

  
   
   

    Private Sub bttTaiVe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttTaiVe.Click
        GDMay.UpdateNV(Me.dgvCo, Me.ListView1, Me.ChkTaiVT.Checked, pb)
        GDMay.ThemNVMay(dgvKo, Me.ListView1, Me.ChkTaiVT.Checked, pb)

    End Sub
End Class