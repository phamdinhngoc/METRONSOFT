Public Class ManHinhXoaDLCC
 
    Private Sub cmdall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdall.Click
        If MsgBox("Bạn có chắc là muốn xóa tất cả dữ liệu chấm công này không?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Thông báo") = MsgBoxResult.No Then Exit Sub

        Dim BusVR As New VaoraBus(DTOKetnoi, False)
        BusVR.XoatheoThoigianAll(Me.sngay.Value, Me.ENgay.Value)
        MsgBox("Hoàn thành quá trình xóa dữ liệu", MsgBoxStyle.Information, "Thông báo")


    End Sub

    Private Sub cmdsua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsua.Click
        If MsgBox("Bạn có chắc là muốn xóa tất cả dữ liệu chấm công đã chỉnh sửa này không?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Thông báo") = MsgBoxResult.No Then Exit Sub
        Dim BusVR As New VaoraBus(DTOKetnoi, False)
        BusVR.XoatheoThoigian(Me.sngay.Value, Me.ENgay.Value)
        MsgBox("Hoàn thành quá trình xóa dữ liệu", MsgBoxStyle.Information, "Thông báo")

    End Sub

    Private Sub ManHinhXoaDLCC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.sngay.Value = DateSerial(Now.Year, Now.Month, 1)
        Me.ENgay.Value = Now.Date
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MsgBox("Bạn có chắc là muốn xóa dữ liệu về mặc định không?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Thông báo") = MsgBoxResult.No Then Exit Sub

        Dim BusCaTD As New caTDBus(DTOKetnoi, False)
        BusCaTD.XoaAll()
        Dim BusLichTam As New lichtamBus(DTOKetnoi, False)
        BusLichTam.XoaAll()
        MsgBox("Hoàn thành quá trình xóa dữ liệu", MsgBoxStyle.Information, "Thông báo")


    End Sub
End Class