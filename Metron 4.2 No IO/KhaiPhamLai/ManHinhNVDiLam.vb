Public Class ManHinhNVDiLam
 

#Region "Ho tro goi du lieu"
    Dim BusVaoRa As New VaoraBus(DTOKetnoi, False)
    Dim dtoVaoRa As New Vaoradto
    Dim DataVaoRa As DataTable
    Dim BusCa As New caBus(DTOKetnoi, False)
    Dim dtoCaSang As New cadto
    Dim dtoCaChieu As New cadto
    Dim BusDonVi As New donviBus(DTOKetnoi, False)
    Dim dtoDonVi As New donvidto
    Dim BusNhanVien As New nhanvienBus(DTOKetnoi, False)
    Dim dtoNhanVien As New nhanviendto
    Dim MaDV As Integer = 1


    Private Sub TinhToan()
        If MaDV = 1 Then
            Me.dgvChiTiet.DataSource = BusVaoRa.LayBangTableThoigian(Me.sNgay.Value, Me.eNgay.Value, MaDV)
            Me.DGVRA.DataSource = BusVaoRa.LayBangTableThoigianraALL(sNgay.Value, eNgay.Value)
            Me.DGVVAO.DataSource = BusVaoRa.LayBangTableThoigianVaoALL(sNgay.Value, eNgay.Value)
        Else
            Me.dgvChiTiet.DataSource = BusVaoRa.LayBangTableThoigian(Me.sNgay.Value, Me.eNgay.Value, MaDV)
            Me.DGVRA.DataSource = BusVaoRa.LayBangTableThoigianRa(sNgay.Value, eNgay.Value, MaDV)
            Me.DGVVAO.DataSource = BusVaoRa.LayBangTableThoigianVao(sNgay.Value, eNgay.Value, MaDV)
        End If
        MsgBox("Hoàn thành quá trình tính toán!", MsgBoxStyle.Information, "Thông báo")

    End Sub

#End Region


    

    Private Sub btchon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btchon.Click
        ManhinhQLBophan.ShowDialog()
        Me.txtbophan.Text = ManhinhQLBophan.TenDV
        MaDV = ManhinhQLBophan.MaDV
    End Sub
 

    Private Sub CmdTinh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdTinh.Click
        TinhToan()
    End Sub

    Private Sub ManHinhNVDiLam_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtoDonVi = BusDonVi.LayBangDTo(1)
        Me.txtbophan.Text = dtoDonVi.TenDV
    End Sub
End Class