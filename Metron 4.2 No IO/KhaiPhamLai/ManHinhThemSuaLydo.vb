Public Class ManHinhThemSuaLydo
    Dim bus As New lydoBus(DTOKetnoi, False)
    Public IDLD As Integer = 0
    Private Sub ManHinhThemSuaLydo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Focus()
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyData = Keys.Enter Then
            TextBox2.Focus()
        End If
    End Sub
    Private Sub TextBox2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyData = Keys.Enter Then
            TextBox3.Focus()
        End If
    End Sub
    Private Sub TextBox3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox3.KeyDown
        If e.KeyData = Keys.Enter Then
            Button1.Focus()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim DTO As New lydodto
        Dim LOI As Boolean = False
        DTO.IDLD = IDLD
        If Not IsDBNull(TextBox1.Text) Then
            DTO.Lydo = TextBox1.Text
            ErrorProvider1.SetError(TextBox1, "Bạn chưa nhập dử liệu")
        Else
            MsgBox("Bạn chưa nhập dử liệu", , "Thông báo")
            ErrorProvider1.SetError(TextBox1, "")
            TextBox1.Focus()
            LOI = True
        End If
        If IsNumeric(TextBox2.Text) Then
            DTO.NgayQD = TextBox2.Text
            ErrorProvider1.SetError(TextBox2, "Bạn phải nhập số")
        Else
            MsgBox("Bạn phải nhập số", , "Thông báo")
            ErrorProvider1.SetError(TextBox2, "")
            TextBox2.Focus()
            LOI = True
        End If
        If IsNumeric(TextBox3.Text) Then
            DTO.SoCong = TextBox3.Text
            ErrorProvider1.SetError(TextBox3, "Bạn phải nhập số")
        Else
            MsgBox("Bạn phải nhập số", , "Thông báo")
            ErrorProvider1.SetError(TextBox3, "")
            TextBox3.Focus()
            LOI = True
        End If
        If LOI Then Exit Sub
        Try
            If DTO.IDLD = 0 Then
                bus.Them(DTO)
            Else
                bus.sua(DTO)
            End If
        Catch ex As Exception
            MsgBox("Bạn chưa nhập dử liệu " & vbNewLine & "Yêu cầu bạn kiểm tra lại", , "Thông báo")
        End Try
        Me.Close()
    End Sub
End Class