Imports System.Data.OleDb
Imports System.Windows.Forms

Public Class ManHinhQuenMatKhau
#Region "Nhập liệu nội dung cậu hỏi"
    Private Sub cauhoi1(ByVal combo As ComboBox)
        combo.Items.Add("1+1=?")
        combo.Items.Add("Tên trường cấp 1 của bạn là gì?")
        combo.Items.Add("Tên trường cấp 2 của bạn là gì?")
        combo.Items.Add("Tên trường cấp 3 của bạn là gì?")
        combo.Items.Add("Tên trường đại học của bạn là gì?")
        combo.Items.Add("Tên công ty thứ 1 của bạn đã làm là gì?")
        combo.Items.Add("Tên công ty thứ 2 của bạn đã làm là gì?")
        combo.Items.Add("Tên công ty thứ 3 của bạn đã làm là gì?")
    End Sub
    Private Sub cauhoi2(ByVal combo As ComboBox)
        combo.Items.Add("Tên của bạn là gì?")
        combo.Items.Add("Tên cha của bạn là gì? ")
        combo.Items.Add("Tên mẹ của bạn là gì?")
        combo.Items.Add("Tên người anh của bạn là gì?")
        combo.Items.Add("Tên người chị của bạn là gì?")
        combo.Items.Add("Tên em trai của bạn là gì?")
        combo.Items.Add("Tên em gái của bạn là gì?")
        combo.Items.Add("Tên vợ/tên chồng của bạn?")
    End Sub
#End Region
#Region "key up"
    Private Sub ComboBox1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBox1.KeyUp
        If e.KeyCode = Keys.Enter Then
            TextBox1.Focus()
        End If
    End Sub

    Private Sub TextBox1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyUp
        If e.KeyCode = Keys.Enter Then
            ComboBox2.Focus()
        End If
    End Sub

    Private Sub ComboBox2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBox2.KeyUp
        If e.KeyCode = Keys.Enter Then
            TextBox2.Focus()
        End If
    End Sub

    Private Sub TextBox2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyUp
        If e.KeyCode = Keys.Enter Then
            btnOk.Focus()
        End If
    End Sub

#End Region
#Region "Kiem tra Nguoi dung"
    Private WithEvents mBo_doc_ghi As OleDb.OleDbDataAdapter
    Private Function kiemtra(ByVal cauhoi1 As String, ByVal traloi1 As String, ByVal cauhoi2 As String, ByVal traloi2 As String) As String
        Try
            Dim sql As String = "select * from nguoidung" & _
            " WHERE cauhoi1='" & cauhoi1 & "' AND traloi1='" & traloi1 & "' and " & _
            " cauhoi2='" & cauhoi2 & "' AND traloi2='" & traloi2 & "'"
            Dim Data As New DataTable
            mBo_doc_ghi = New OleDbDataAdapter(sql, Ketnoi)
            mBo_doc_ghi.FillSchema(Data, SchemaType.Mapped)
            mBo_doc_ghi.Fill(Data)
            If Data.Rows.Count > 0 Then
                Return Data.Rows(0)(0).ToString & ":" & Data.Rows(0)(1).ToString()
            End If
            MsgBox("Câu trả lời hoặc câu hỏi không đúng", MsgBoxStyle.Critical, "Thông báo")
            Return ""
        Catch ex As OleDb.OleDbException
            Return ""
            Exit Function
        End Try
    End Function
#End Region
    Private Sub ManHinhQuenMatKhau_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cauhoi1(ComboBox1)
        cauhoi2(ComboBox2)
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Dim kt As String = kiemtra(ComboBox1.Text, TextBox1.Text, ComboBox2.Text, TextBox2.Text)
        If kt <> "" Then
            TextBox3.Text = kt
            TextBox3.Visible = True
        End If
    End Sub
End Class