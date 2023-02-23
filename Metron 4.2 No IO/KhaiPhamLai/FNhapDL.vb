Public Class FNhapDL
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        op.Filter = "File DATA Metron|*.DTMT"
        If op.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        Dim Cn As OleDb.OleDbConnection = Ketnoi
        Dim CMd As OleDb.OleDbCommand
        Dim Str As String = "INSERT INTO vaora (MaNV, kieu, May, Thoigian, Ngay) VALUES (PMaNV, PKieu, PMay, PThoigian, PNgay)"
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        CMd = New OleDb.OleDbCommand(Str, Cn)
        CMd.Parameters.Add("PMaNV", OleDb.OleDbType.Integer)
        CMd.Parameters.Add("PKieu", OleDb.OleDbType.Integer)
        CMd.Parameters.Add("PMay", OleDb.OleDbType.Integer)
        CMd.Parameters.Add("PThoigian", OleDb.OleDbType.VarChar)
        CMd.Parameters.Add("PNgay", OleDb.OleDbType.VarChar)
        Dim Doc As IO.StreamReader
        Doc = New IO.StreamReader(op.FileName)
        pb.Maximum = 500
        While Not Doc.EndOfStream
            Try
                CMd.Parameters("PMaNV").Value = Doc.ReadLine
                CMd.Parameters("PKieu").Value = Doc.ReadLine
                CMd.Parameters("PMay").Value = 1
                CMd.Parameters("PThoigian").Value = Doc.ReadLine
                CMd.Parameters("PNgay").Value = Doc.ReadLine
                CMd.ExecuteNonQuery()
            Catch ex As Exception
            End Try
            Try
                pb.Value += 1
            Catch ex As Exception
                pb.Value = 0
            End Try
        End While
        Doc.Close()
        CMd.Dispose()
        Cn.Close()
        pb.Value = pb.Maximum
        MsgBox("Hoàn thành quá trình cập nhật dữ liệu", MsgBoxStyle.Information, "Thông báo")
    End Sub
End Class