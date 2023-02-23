Public Class FPhienBan
    Dim Ngay As Date
    Dim Songay As Integer


    Private Function DichNgay(ByVal ngay As String) As Date

        DichNgay = DateSerial(Strings.Right(ngay, 4), Mid(ngay, 14, 2), Mid(ngay, 11, 2))

    End Function
    Private Sub CMDTHOAT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDTHOAT.Click

        End
    End Sub

    Private Sub CMDDOC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDOC.Click
        Try

            op.Filter = "METRON ACTIVE PRODUCT|*.MTAP"
            If op.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub

            Me.TextBox1.Text = ""
            Me.TXT1.Text = ""
            Me.TXT2.Text = ""
            Me.TXT3.Text = ""
            Dim TAM, Tam2 As String
            TAM = ""
            Dim RD As IO.StreamReader
            RD = New IO.StreamReader(op.FileName)


            TAM = RD.ReadLine
            Me.TextBox1.Text = TAM
            Me.TXT1.Text = TAM

            '*2
            TAM = RD.ReadLine
            Me.TextBox1.Text = Me.TextBox1.Text & Chr(13) & TAM
            Me.TXT1.Text = Me.TXT1.Text & TAM

            '*3

            TAM = RD.ReadLine
            Me.TextBox1.Text = Me.TextBox1.Text & Chr(13) & TAM
            Me.TXT1.Text = Me.TXT1.Text & TAM


            '*4

            TAM = RD.ReadLine
            Me.TextBox1.Text = Me.TextBox1.Text & Chr(13) & TAM
            Me.TXT1.Text = Me.TXT1.Text & TAM
            Ngay = DichNgay(TAM)


            '5

            TAM = RD.ReadLine
            Me.TextBox1.Text = Me.TextBox1.Text & Chr(13) & TAM
            Me.TXT1.Text = Me.TXT1.Text & TAM


            '*6

            TAM = RD.ReadLine
            Songay = CInt(Strings.Right(TAM, Strings.Len(TAM) - Strings.Len("Số ngày: ")))
            Ngay = DateAdd(DateInterval.Day, Songay, Ngay)
            Me.TXT1.Text = Me.TXT1.Text & TAM


            ' ma hóa seri
            TAM = RD.ReadLine
            Me.TXT1.Text = Me.TXT1.Text & TAM


            'Me.TXT1.Text = Me.TextBox1.
            Me.TXT2.Text = RD.ReadLine
            RD.Close()

            Tam2 = ""
            For I As Integer = 1 To Me.TXT1.TextLength
                Tam2 = Tam2 & Hex(Oct(Asc(Strings.Mid(Me.TXT1.Text, I, 1))))
            Next

            For I As Integer = 1 To Strings.Len(Tam2)
                Me.TXT3.Text = Me.TXT3.Text & Chr(Hex(Asc(Strings.Mid(Tam2, I, 1))))
            Next


            If Songay = 0 Then GoTo 3

            If Ngay < Now() Then
                MsgBox("Bạn đã hết thời gian sử dụng phần mềm!", MsgBoxStyle.Critical, "Hết thời gian sử dụng")
                End

            End If


3:

            KTPB()

        Catch ex As Exception
            Me.TextBox1.Text = ""
            MsgBox("Bạn đang sử dụng bản Demo", MsgBoxStyle.Critical, "Thông báo")
            Exit Sub
        End Try

    End Sub

    Private Function Ham2(ByVal so As Integer) As String
        If so < 10 Then
            Ham2 = "0" & so
        Else
            Ham2 = so

        End If
    End Function
    Private Sub KTPB()

        If Me.TXT2.Text = Me.TXT3.Text Then
            Try

                If IO.File.Exists(My.Application.Info.DirectoryPath & "\PD.MTAP") Then IO.File.Delete(My.Application.Info.DirectoryPath & "\PD.MTAP")

                IO.File.Copy(op.FileName, My.Application.Info.DirectoryPath & "\PD.MTAP")


                MsgBox("Hoàn thành quá trình cập nhật phiên bản." & vbNewLine & _
                        " Vui lòng khởi động lại chương trình.", MsgBoxStyle.Information, "Thông báo")
                End


            Catch ex As Exception
                GoTo 2
            End Try
2:

        Else

            Me.TextBox1.Text = ""
            MsgBox("Bạn đang sử dụng bản Demo!", MsgBoxStyle.Critical, "Thông báo")
        End If

    End Sub

   
End Class