Public Class ManHinhMatKhau
    Public str As String = ""
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        str = TextBox1.Text
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyData = Keys.Enter Then
            Button1.Focus()
        End If
    End Sub

    Private Sub ManHinhMatKhau_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        str = ""
        TextBox1.Text = ""
    End Sub

    Private Sub ManHinhMatKhau_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        TextBox1.Focus()
    End Sub
End Class