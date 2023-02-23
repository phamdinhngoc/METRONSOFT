Imports System.IO
Public Class ManhinhIP
#Region "Ham Lien Quan File Config"
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

    Private Sub ManhinhIP_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        ManHinhChinh.CửaSổHoạtĐộngToolStripMenuItem.DropDownItems.Remove(ManHinhChinh.CửaSổHoạtĐộngToolStripMenuItem.DropDownItems(Me.Name))
    End Sub
    Private Sub ManhinhIP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ManHinhChinh.CửaSổHoạtĐộngToolStripMenuItem.DropDownItems.Add("Giao Diện Hổ Trợ Tìm IP").Name = Me.Name
        Dim ip As String = ""
        Dim An() As System.Net.IPAddress
        An = System.Net.Dns.GetHostAddresses(System.Net.Dns.GetHostName())
        ip = An(0).ToString()
        If TextBox4.Text = "" Then
            TextBox4.Text = Microsoft.VisualBasic.Strings.Left(ip, ip.LastIndexOf(".")) & "."
            TextBox1.Text = Microsoft.VisualBasic.Strings.Left(ip, ip.LastIndexOf(".")) & "."
        End If
        For i As Integer = 2 To 254
            ComboBox1.Items.Add(i)
            ComboBox2.Items.Add(i)
        Next
        ComboBox1.SelectedIndex = 252
        ComboBox2.SelectedIndex = 98
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ManHinhThietLapMCC.batdau = ComboBox2.SelectedItem
        ManHinhThietLapMCC.ketthuc = ComboBox1.SelectedItem

        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged
        TextBox1.Text = TextBox4.Text
    End Sub
End Class