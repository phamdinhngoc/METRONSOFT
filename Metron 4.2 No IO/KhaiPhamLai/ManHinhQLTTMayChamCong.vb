Imports KhaiPhamLai.ClassGDMay
Public Class ManHinhQLTTMayChamCong


    Dim BusMay As New MayBus(DTOKetnoi, False)
    Dim dtomay As New Maydto
    Dim GDMay As New ClassGDMay
    Dim daoNK As New NhatkyBus(DTOKetnoi, False)
    Dim dtoNK As New Nhatkydto


    Private Sub SetUpListViewColumns()
        ListView1.Columns.Add("Tên máy", 150)
        ListView1.Columns.Add("Vị trí", 110)
        ListView1.Columns.Add("MM", 30)
        ListView1.Columns.Add("MS", 30)
        ListView1.Columns.Add("LS", 30)
        SetView(View.Details)
    End Sub

    Private Sub SetView(ByVal View As System.Windows.Forms.View)
        ListView1.View = View
    End Sub
    Private Sub ManHinhQLTTMayChamCong_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If TaoCSMay(Me.ListView1) = False Then Close()
            SetUpListViewColumns()

        Catch ex As Exception
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        GDMay.DongBoTG(Me.ListView1)

    End Sub
    Private Sub ListView1_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles ListView1.ItemSelectionChanged
        If e.IsSelected Then
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        GDMay.XoaAdmin(Me.ListView1)

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If MsgBox("Reset sẽ mất hết dữ liệu trên máy CC. Bạn có chắc muốn Reset?", MsgBoxStyle.OkCancel, "Thông báo") = MsgBoxResult.Ok Then
            GDMay.XoaDL(Me.ListView1)
            dtoNK.User = TenNguoiDangNhap
            dtoNK.Ngay = Date.Now.Date
            dtoNK.Gio = Date.Now
            dtoNK.Tacvu = "Reset máy chấm công"
            daoNK.Them(dtoNK)
        Else
            Exit Sub
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If MsgBox("Bạn cần tải dữ liệu về trước khi xóa. Bạn có chắc muốn xóa?", MsgBoxStyle.OkCancel, "Thông báo") = MsgBoxResult.Ok Then
            GDMay.XoaDLCC(Me.ListView1)
            dtoNK.User = TenNguoiDangNhap
            dtoNK.Ngay = Date.Now.Date
            dtoNK.Gio = Date.Now
            dtoNK.Tacvu = "Xóa dữ liệu chấm công"
            daoNK.Them(dtoNK)
        Else
            Exit Sub
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Close()
    End Sub
 
 

    Private Sub Button6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        SeriNoMCC = ""
        Dim DLNV, DLQL, DLVT, DLCC As Integer
        GDMay.DocTTMay(Me.ListView1, Me.tgcc.Text, DLNV, DLQL, DLCC, DLVT, SeriNoMCC)
        Me.dlnv.Text = DLNV
        Me.dlql.Text = DLQL
        Me.dlcc.Text = DLCC
        Me.dlvt.Text = DLVT
        lblSeri.Text = SeriNoMCC

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.tgmt.Text = Now
    End Sub
 
End Class