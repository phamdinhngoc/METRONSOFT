Imports System.io
Public Class ManHinhTroDuLieu
#Region "file"
    Private Function TaoFile(ByVal duongdanFile As String, ByVal NoidungFile As String) As String
        Dim file As FileStream
        Dim writer As StreamWriter
        Try
            file = New FileStream(duongdanFile, FileMode.CreateNew)
            writer = New StreamWriter(file)
            writer.WriteLine(NoidungFile)
            writer.Close()
            file.Close()
        Catch EX As Exception
            Return (EX.Message)
        End Try
        Return "1"
    End Function
    Private Function GhiFile(ByVal duongdanFile As String, ByVal NoidungFile As String) As String
        Dim file As FileStream
        Dim writer As StreamWriter
        Try
            file = New FileStream(duongdanFile, FileMode.Open)
            writer = New StreamWriter(file)
            writer.WriteLine(NoidungFile)
            writer.Close()
            file.Close()
        Catch EX As Exception
            Return EX.Message
        End Try
        Return "1"
    End Function
    Private Function DocFile(ByVal duongdanFile As String) As String
        Dim file As FileStream
        Dim reader As StreamReader
        Dim a As String = ""
        Try
            file = New FileStream(duongdanFile, FileMode.Open)
            reader = New StreamReader(file)
            a = reader.ReadLine
            reader.Close()
            file.Close()
        Catch EX As Exception
            Return ""
        End Try
        Return a
    End Function
#End Region
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub ManHinhTroDuLieu_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        ManHinhChinh.CửaSổHoạtĐộngToolStripMenuItem.DropDownItems.Remove(ManHinhChinh.CửaSổHoạtĐộngToolStripMenuItem.DropDownItems(Me.Name))
    End Sub

    Private Sub ManHinhTroDuLieu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ManHinhChinh.CửaSổHoạtĐộngToolStripMenuItem.DropDownItems.Add("Giao Diện Trỏ Dử Liệu").Name = Me.Name
        Dim busQ As New QuyenBus(DTOKetnoi, False)
        Dim ma As Integer = busQ.MaQuyen(QuyenNguoiDangNhap)
        cacNutNhan(Me, ma, Me.Name)
        TextBox1.Text = DocFile(Application.StartupPath & "\Connfig.dat")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        OpenFileDialog1.DefaultExt = "mdb"
        OpenFileDialog1.Filter = "mdb files (*.mdb)|*.mdb"
        If (OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK) Then
            TextBox2.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        GhiFile(Application.StartupPath & "\Connfig.dat", TextBox2.Text)
        MsgBox("Hoàn thành quá trình trỏ dữ liệu!" & Chr(14) & _
        "Vui lòng khởi động lại chương trình!", MsgBoxStyle.Information, "Thông báo")
        End
    End Sub
End Class