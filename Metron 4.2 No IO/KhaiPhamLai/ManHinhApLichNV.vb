Public Class ManHinhApLichNV
    Dim bus As New nhanvienBus(DTOKetnoi, False)
    Dim dto As New nhanviendto

    Dim busdonvi As New donviBus(DTOKetnoi, False)
    Dim dtodonvi As New donvidto
    Dim BusTT As New lichtamBus(DTOKetnoi, False)
    Dim dtoTT As New lichtamdto


#Region "TreeView"
    Private Function DuyetCayDK(ByVal tvRoot As TreeNode) As String
        Try
            Dim str As String = ""
            For i As Integer = 0 To tvRoot.Nodes.Count - 1
                If tvRoot.Nodes(i).Nodes.Count > 0 Then
                    DuyetCayDK(tvRoot.Nodes(i))
                End If
                str = str & " or donvi= " & tvRoot.Nodes(i).Name
            Next
            Return str
        Catch ex As Exception
            Return ""
        End Try
    End Function
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
        showlichlamviec()
    End Sub
    Private Sub showlichlamviec()
        
        Dim StrNhanVien = "SELECT MaNV,NVSP, TenNV, Chucvu FROM TimNV WHERE Donvi = " & Me.TreeView1.SelectedNode.Name

        Me.dgvNV.DataSource = bus.LayBangTableSQL(StrNhanVien)
       
    End Sub
#End Region

    Private Sub ManHinhApLichNV_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cay()
        TreeView1.ExpandAll()
        SNgay.Value = DateSerial(Now.Year, Now.Month, 1)
        ENgay.Value = Now
    End Sub
 
    Private Sub dgvNV_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvNV.SelectionChanged

        If Me.dgvNV.SelectedRows.Count = 0 Then Exit Sub
        Dim sql As String = "select ca.ID, ca.tenca , ca.batdau,ca.kethuc,catd.TangCa, catd.TangcaS, catd.GHTangCa from catd,ca where catd.caid=ca.id and manv=" & Me.dgvNV.Item("MaNV", dgvNV.SelectedRows(0).Index).Value
        Me.dgvCaLV.DataSource = bus.LayBangTableSQL(sql)
        'Dim StrCaTT As String = "SELECT LichTam.ID, ca.TenCa, LichTam.TuNgay, LichTam.DenNgay WHERE ((LichTam.CaID = Ca.ID) AND (LichTam.TuNgay) ) "
        Dim LichTam As New lichtamBus(DTOKetnoi, False)
        Me.dgvCaTam.DataSource = LichTam.LayLichTamTheoNgay(dgvNV.Item("MaNV", dgvNV.SelectedRows(0).Index).Value, SNgay.Value, ENgay.Value)

    End Sub

   
   

    Private Sub ThêmCaLàmViệcToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ThêmCaLàmViệcToolStripMenuItem.Click, ToolStripButton2.Click
        Try
            ManHinhEpCaTD.Kieu = 1
            ManHinhEpCaTD.NVid = dgvNV.SelectedRows(0).Cells("MaNV").Value
            ManHinhEpCaTD.Label1.Text = "THÊM CA TỰ ĐỘNG"
            'ManHinhEpCaTD.chkquangay.Visible = False
            ManHinhEpCaTD.ShowDialog()
            Dim sql As String = "select ca.ID, ca.tenca , ca.batdau,ca.kethuc,catd.TangCa , catd.TangcaS, catd.GhTangCa from catd,ca where catd.caid=ca.id and manv=" & Me.dgvNV.Item("MaNV", dgvNV.SelectedRows(0).Index).Value
            Me.dgvCaLV.DataSource = bus.LayBangTableSQL(sql)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub XóaCaLàmViệcĐangChọnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XóaCaLàmViệcĐangChọnToolStripMenuItem.Click, ToolStripButton1.Click
        If dgvCaLV.SelectedRows.Count - 1 >= 0 Then
            If MsgBox("Bạn muốn xóa ca tự động phải không?", MsgBoxStyle.OkCancel, "Thông báo") = MsgBoxResult.Ok Then
                Dim buscatd As New caTDBus(DTOKetnoi, False)
                For i As Integer = 0 To Me.dgvNV.SelectedRows.Count - 1
                    For j As Integer = 0 To Me.dgvCaLV.SelectedRows.Count - 1
                        buscatd.Xoa(CInt(Me.dgvNV.SelectedRows(i).Cells("MaNV").Value), CInt(dgvCaLV.SelectedRows.Item(j).Cells("IDTD").Value))
                    Next
                Next

                'If Ket_noi.State = ConnectionState.Open Then Ket_noi.Close()
                Dim sql As String = "select ca.ID, ca.tenca , ca.batdau,ca.kethuc,catd.TangCa , catd.TangcaS, Catd.GHTangCa  from catd,ca where catd.caid=ca.id and manv=" & Me.dgvNV.Item("MaNV", dgvNV.SelectedRows(0).Index).Value
                Me.dgvCaLV.DataSource = bus.LayBangTableSQL(sql)

            End If
        Else
            MsgBox("Bạn chưa chọn ca cần xóa", MsgBoxStyle.Information, "Thông báo")
        End If
        
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click, ToolStripButton4.Click
        Try
            ManHinhEpCaTD.Kieu = 0
            ManHinhEpCaTD.NVid = dgvNV.SelectedRows(0).Cells("MaNV").Value
            ManHinhEpCaTD.Label1.Text = "THÊM CA TẠM THỜI"
            'ManHinhEpCaTD.chkquangay.Visible = True
            ManHinhEpCaTD.ShowDialog()

            Dim LichTam As New lichtamBus(DTOKetnoi, False)
            Me.dgvCaTam.DataSource = LichTam.LayLichTamTheoNgay(dgvNV.Item("MaNV", dgvNV.SelectedRows(0).Index).Value, SNgay.Value, ENgay.Value)
        Catch ex As Exception
        End Try
    End Sub

 
    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click, ToolStripButton3.Click
        If dgvCaTam.SelectedRows.Count - 1 >= 0 Then
            If MsgBox("Bạn muốn xóa ca tạm thời này không?", MsgBoxStyle.OkCancel, "Thông báo") = MsgBoxResult.Ok Then
                Dim TNgayT, DNgayT As Date
                For i As Integer = 0 To Me.dgvNV.SelectedRows.Count - 1

                    For j As Integer = 0 To Me.dgvCaTam.SelectedRows.Count - 1
                        TNgayT = Me.dgvCaTam.SelectedRows(j).Cells("CTuNgay").Value
                        DNgayT = Me.dgvCaTam.SelectedRows(j).Cells("CDenNgay").Value
                        BusTT.Xoa(CInt(Me.dgvNV.SelectedRows(i).Cells("MaNV").Value), CInt(dgvCaTam.SelectedRows.Item(j).Cells("IDTT").Value), TNgayT, DNgayT)
                    Next

                Next

                Me.dgvCaTam.DataSource = BusTT.LayLichTamTheoNgay(dgvNV.Item("MaNV", dgvNV.SelectedRows(0).Index).Value, SNgay.Value, ENgay.Value)

            End If
        Else
            MsgBox("Bạn chưa chọn ca cần xóa", MsgBoxStyle.Information, "Thông báo")
        End If
    End Sub
 
   
    Private Sub dgvCaTam_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCaTam.CellContentClick

    End Sub

   

    Private Sub tsbChonTatCa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbChonTatCa.Click
        Try
            dgvNV.SelectAll()
        Catch ex As Exception

        End Try
    End Sub

   
    Private Sub ManHinhApLichNV_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            TreeView1.SelectedNode = TreeView1.Nodes(0)
        Catch ex As Exception

        End Try
    End Sub
End Class