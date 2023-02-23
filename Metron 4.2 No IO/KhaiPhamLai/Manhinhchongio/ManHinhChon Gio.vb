Public Class ManHinhChon_Gio
    Public ngay As Date = #1/1/1900#
    Public gio As Date = #1/1/1900#
    Public xoa As Boolean = False
    Dim busVaoRa As New VaoraBus(DTOKetnoi, False)
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonLuu.Click
        ngay = MonthCalendar1.SelectionStart
        ngay &= " " & DateTimePicker1.Value.ToLongTimeString
        xoa = False
        Me.Close()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonKhong.Click
        ngay = #1/1/1900#
        xoa = False
        Me.Close()
    End Sub
    Private Sub ManHinhChon_Gio_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        ngay = #1/1/1900#
    End Sub
    Private Sub ManHinhChon_Gio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MonthCalendar1.SetDate(ngay)
        DateTimePicker1.Value = gio
        DateTimePicker1.Focus()
    End Sub
    Private Sub DateTimePicker1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DateTimePicker1.KeyDown
        If e.KeyData = Keys.Enter Then
            ButtonLuu.Focus()
        End If
        If e.KeyData = Keys.Escape Then
            ButtonKhong.Focus()
        End If
    End Sub
    Private Sub ButtonXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonXoa.Click
        xoa = True
        ngay = #1/1/1900#
        Me.Close()
    End Sub
End Class