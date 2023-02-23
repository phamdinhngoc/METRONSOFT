Public Class frmHoTroNhap
#Region "Khai Báo"
    Dim BusDonVi As New donviBus(DTOKetnoi, False)
    Dim DtoDonvi As New donvidto
    Dim BusLuong As New BangluongBus(DTOKetnoi, False)
    Dim DtoLuong As New Bangluongdto
    Dim Bus As New nhanvienBus(DTOKetnoi, False)
#End Region

#Region "Hàm"
    Private Sub cay()
        TreeView1.Nodes.Clear()
        Dim tvRoot As TreeNode
        DtoDonvi = BusDonVi.LayBangDTo(1)
        tvRoot = Me.TreeView1.Nodes.Add(DtoDonvi.MaDV, DtoDonvi.TenDV)
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
    Private Sub CheckedallChild(ByVal tvRoot As TreeNode)
        For i As Integer = 0 To tvRoot.Nodes.Count - 1
            tvRoot.Nodes(i).Checked = tvRoot.Checked
            CheckedallChild(tvRoot.Nodes(i))
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
    Private Sub LuuThongTin()
        For i As Integer = 0 To dgvLuong.Rows.Count - 1
            DtoLuong.Manv = dgvLuong.Rows(i).Cells(0).Value
            DtoLuong.LuongThang = dgvLuong.Rows(i).Cells(4).Value
            DtoLuong.PhanTramBH = dgvLuong.Rows(i).Cells(5).Value
            DtoLuong.TienTcGio = dgvLuong.Rows(i).Cells(6).Value
            DtoLuong.Thang = Now.Month
            DtoLuong.Nam = Now.Year
            Try
                BusLuong.Them(DtoLuong)
            Catch ex As Exception
                MsgBox("Nhân viên này sẽ bị bỏ qua. Vui lòng kiểm tra lại!", MsgBoxStyle.Information, "Thông báo")
            End Try
        Next
        MsgBox("Đã hoàn thành", MsgBoxStyle.Information, "Thông báo")
    End Sub
#End Region

    Private Sub frmHoTroNhap_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cay()
    End Sub
    Private Sub TreeView1_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterCheck
        Try
            CheckedallChild(e.Node)
            Dim data As DataTable = Bus.LayBangTableCodk(ChuoiBoPhanDK())
            dgvLuong.Rows.Clear()
            For i As Integer = 0 To data.Rows.Count - 1
                dgvLuong.Rows.Add(data.Rows(i)("MaNV"), data.Rows(i)("TenNV"), data.Rows(i)("Chucvu"), data.Rows(i)("TenDV"))
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tsbLuuThongTin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbLuuThongTin.Click
        Try
            LuuThongTin()
        Catch ex As Exception

        End Try
    End Sub
End Class