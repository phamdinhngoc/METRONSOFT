Public Class ManHinhNhatKy
    Dim bus As New NhatkyBus(DTOKetnoi, False)
    Dim dto As New Nhatkydto

    Private Sub ManHinhNhatKy_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        ManHinhChinh.CửaSổHoạtĐộngToolStripMenuItem.DropDownItems.Remove(ManHinhChinh.CửaSổHoạtĐộngToolStripMenuItem.DropDownItems(Me.Name))
    End Sub
    Private Sub ManHinhNhatKy_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ManHinhChinh.CửaSổHoạtĐộngToolStripMenuItem.DropDownItems.Add("Giao Diện Nhật Ký").Name = Me.Name
        Dim busQ As New QuyenBus(DTOKetnoi, False)
        Dim ma As Integer = busQ.MaQuyen(QuyenNguoiDangNhap)
        cacNutNhan(Me, ma, Me.Name)
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Dim sql As String = "select * from nhatky where ngay >= #" & DateTimePicker1.Value.Date & "# and ngay <= #" & DateTimePicker2.Value.Date & "#" & IIf(CheckBox1.Checked, " and Tacvu like '%" & TextBox1.Text & "%'", "") & IIf(CheckBox2.Checked, " and User like '%" & TextBox2.Text & "%'", "")
        'DataGridView1.DataSource = bus.LayBangTableSQL(sql)
        Dim data As OleDb.OleDbDataReader = bus.xemNhatky(DateTimePicker1.Value.Date, DateTimePicker2.Value.Date, IIf(CheckBox2.Checked, TextBox2.Text, ""), IIf(CheckBox1.Checked, TextBox1.Text, ""))
        Dim i As Integer = 0
        DataGridView1.Rows.Clear()
        While data.Read
            'MsgBox(data("ID"))
            DataGridView1.Rows.Add()
            DataGridView1.Item(0, i).Value = data("ID")
            DataGridView1.Item(1, i).Value = data("User")
            DataGridView1.Item(2, i).Value = data("Ngay")
            DataGridView1.Item(3, i).Value = data("Gio")
            DataGridView1.Item(4, i).Value = data("Tacvu")
            i += 1
        End While
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        TextBox1.Enabled = CheckBox1.Checked
        TextBox1.Focus()
    End Sub
    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        TextBox2.Enabled = CheckBox2.Checked
        TextBox2.Focus()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
End Class