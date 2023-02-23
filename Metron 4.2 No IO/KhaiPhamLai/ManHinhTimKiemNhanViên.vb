Imports System.Runtime.InteropServices
Imports System.IO
'Imports Excel
Imports System.Windows.Forms

Public Class ManHinhTimKiemNhanViên
    Dim bus As New nhanvienBus(DTOKetnoi, False)
    Dim dto As New nhanviendto
    Dim busChucvu As New chucvuBus(DTOKetnoi, False)
    Dim dtochucvu As New chucvudto

    Private Sub ManHinhTimKiemNhanViên_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        ManHinhChinh.CửaSổHoạtĐộngToolStripMenuItem.DropDownItems.Remove(ManHinhChinh.CửaSổHoạtĐộngToolStripMenuItem.DropDownItems(Me.Name))
    End Sub
    Private Sub ManHinhTimKiemNhanViên_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim busQ As New QuyenBus(DTOKetnoi, False)
        Dim ma As Integer = busQ.MaQuyen(QuyenNguoiDangNhap)
        cacNutNhan(Me, ma, Me.Name)
        ManHinhChinh.CửaSổHoạtĐộngToolStripMenuItem.DropDownItems.Add("Giao Diện Tìm Kiếm Người Dùng").Name = Me.Name
        cbogioitinh2.Items.Add("Nam")
        cbogioitinh2.Items.Add("Nữ")
        DataGridView1.DataSource = bus.LayBangTable
    End Sub

#Region "Checkbox"
    Private Sub chkMaNV_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMaNV.CheckedChanged
        TxtMaNV2.Enabled = chkMaNV.Checked
        TxtMaNV2.Focus()
    End Sub

    Private Sub chkNVSP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNVSP.CheckedChanged
        TxtNVSP2.Enabled = chkNVSP.Checked
        TxtNVSP2.Focus()
    End Sub

    Private Sub chkTenNV_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTenNV.CheckedChanged
        TxtTenNV2.Enabled = chkTenNV.Checked
        TxtTenNV2.Focus()
    End Sub

    Private Sub chkTenHT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTenHT.CheckedChanged
        TxtTenHT2.Enabled = chkTenHT.Checked
        TxtTenHT2.Focus()
    End Sub

    Private Sub chkGioitinh_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGioitinh.CheckedChanged
        cbogioitinh2.Enabled = chkGioitinh.Checked
        cbogioitinh2.Focus()
    End Sub

    Private Sub chkNgayVaoLam_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNgayVaoLam.CheckedChanged
        dtpNgayvaolam2.Enabled = chkNgayVaoLam.Checked
        dtpNgayvaolam2.Focus()
    End Sub
#End Region
    Private Function ChuoiDk(ByVal group As Control, Optional ByVal strOr As Boolean = True) As String
        Dim dk As String = " 1=0 "
        Dim quanhe As String = " or "
        If strOr = False Then
            dk = " 1=1 "
            quanhe = " and "
        End If
        Dim valcontrol As Control
        For Each valcontrol In group.Controls
            If valcontrol.Tag = "1" Then
                If valcontrol.Enabled Then
                    If valcontrol.Name = "cboChucvu2" Then
                        Dim cbo As ComboBox = valcontrol
                        dk = dk & quanhe & Mid(cbo.Name, 4, cbo.Name.Length - 4) & " = " & cbo.SelectedValue
                    ElseIf Microsoft.VisualBasic.Strings.Left(valcontrol.Name, 3) = "dtp" Then
                        Dim dtp As DateTimePicker = valcontrol
                        dk = dk & quanhe & Mid(dtp.Name, 4, dtp.Name.Length - 4) & " = " & "#" & dtp.Value.Date & "#"
                    ElseIf valcontrol.Name = "TxtMaNV2" Then
                        dk = dk & quanhe & Mid(valcontrol.Name, 4, valcontrol.Name.Length - 4) & " = " & valcontrol.Text
                    ElseIf valcontrol.Name = "TxtNVSP2" Then
                        dk = dk & quanhe & Mid(valcontrol.Name, 4, valcontrol.Name.Length - 4) & " = '" & valcontrol.Text & "'"
                    Else
                        dk = dk & quanhe & Mid(valcontrol.Name, 4, valcontrol.Name.Length - 4) & " like " & "'%" & valcontrol.Text & "%'"
                    End If
                End If
            End If
        Next
        Return dk
    End Function
    Private Sub TìmKiếmToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TìmKiếmToolStripMenuItem.Click, Button1.Click
        Dim Dieukien As String = ChuoiDk(GroupBox1, False)
        Dim sql As String = "SELECT Nhanvien.MaNV, Nhanvien.TenNV, Nhanvien.TenHT, chucvu.Chucvu, Donvi.TenDV, Nhanvien.CardNo, Nhanvien.Gioitinh, Nhanvien.Diachi, Nhanvien.CMND, Nhanvien.Ngayvaolam, Nhanvien.NVSP, Nhanvien.Quyen FROM chucvu INNER JOIN (Donvi INNER JOIN Nhanvien ON Donvi.MaDV = Nhanvien.Donvi) ON chucvu.CVID = Nhanvien.Chucvu where " & Dieukien
        DataGridView1.DataSource = bus.LayBangTableSQL(sql)
        If DataGridView1.Rows.Count <= 0 Then
            Button2.Enabled = False
            Button3.Enabled = False
        Else
            Button2.Enabled = True
            Button3.Enabled = True
        End If
    End Sub

    Private Sub ThoátToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ThoátToolStripMenuItem.Click, Button4.Click
        Me.Close()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SửaToolStripMenuItem.Click, Button2.Click
        If DataGridView1.RowCount <= 0 Then
            Exit Sub
        End If
        Try
            Frmnhanvien.Show()
            Frmnhanvien.bttBoPhan.DataSource = bus.LayBangTable(Val(DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value))
            Frmnhanvien.SplitContainer1.Panel1Collapsed = True
            Frmnhanvien.suanv()
            For i As Integer = 0 To Frmnhanvien.ToolStrip1.Items.Count - 1
                If Frmnhanvien.ToolStrip1.Items(i).Name <> "ToolStripButton9" Then Frmnhanvien.ToolStrip1.Items(i).Visible = False
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Function TaobaocaoExcel(ByVal duongdanFile As String, ByVal dGrid As DataGridView) As String
        Dim file As FileStream
        Dim writer As StreamWriter
        Try
            file = New FileStream(duongdanFile, FileMode.CreateNew)
            writer = New StreamWriter(file, System.Text.Encoding.Unicode)
            For i As Integer = 0 To dGrid.Columns.Count - 2
                If dGrid.Columns(i).Visible Then writer.Write(dGrid.Columns(i).HeaderText & vbTab)
            Next
            writer.WriteLine("")
            For i As Integer = 0 To dGrid.Rows.Count - 1
                For j As Integer = 0 To dGrid.Columns.Count - 2
                    If dGrid.Columns(j).Visible Then writer.Write(dGrid.Rows(i).Cells(j).Value & vbTab)
                Next
                writer.WriteLine("")
            Next
            writer.Close()
            file.Close()
        Catch EX As Exception
            Return (EX.Message)
        End Try
        Return "1"
    End Function
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        SaveFileDialog1.DefaultExt = "xls"
        SaveFileDialog1.Filter = "xls files (*.xls)|*.xls"
        If (SaveFileDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK) Then
            Try
                Dim duongdan As String = SaveFileDialog1.FileName
                Try
                    File.Delete(duongdan)
                Catch ex As Exception
                End Try
                TaobaocaoExcel(duongdan, DataGridView1)
            Catch ex As Exception
                MsgBox(ex.Message, , "Thông báo")
            End Try
            MsgBox("Xuất dữ liệu thành công", MsgBoxStyle.Information, "Thông báo")
        End If
    End Sub
End Class