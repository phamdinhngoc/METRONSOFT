Public Class FXuatDL

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Public Function FGioS(ByVal gio As DateTime) As String
        FGioS = TimeSerial(Hour(gio), Minute(gio), Second(gio)).ToString
    End Function
    Public Function FngayS(ByVal ngay As Date) As String
        FngayS = DateSerial(Year(ngay), Month(ngay), Microsoft.VisualBasic.DateAndTime.Day(ngay)).ToString
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        sa.Filter = "File DATA Metron|*.DTMT"
        If sa.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        Dim CN As OleDb.OleDbConnection = Ketnoi
        Dim Cmd As OleDb.OleDbCommand
        Dim Dr As OleDb.OleDbDataReader
        Dim Str As String = "SELECT * FROM vaora WHERE ( Thoigian>=SNGay ) AND (Thoigian<=ENgay)"
        If CN.State = ConnectionState.Closed Then CN.Open()
        Cmd = New OleDb.OleDbCommand(Str, CN)
        Cmd.Parameters.Add("SNgay", OleDb.OleDbType.Date).Value = Me.sngay.Value.Date & " " & #12:00:01 AM#
        Cmd.Parameters.Add("ENgay", OleDb.OleDbType.Date).Value = Me.engay.Value.Date & " " & #11:59:59 PM#
        Dr = Cmd.ExecuteReader
        pg.Maximum = 500
        Dim Ghi As IO.StreamWriter
        Ghi = New IO.StreamWriter(sa.FileName)
        While Dr.Read
            Ghi.Write(Dr("MaNV"))
            Ghi.WriteLine()
            Ghi.Write(Dr("kieu"))
            Ghi.WriteLine()
            Ghi.Write(Dr("Thoigian"))
            Ghi.WriteLine()
            Ghi.Write(FngayS(Dr("Ngay")))
            Ghi.WriteLine()
            Try
                pg.Value += 1
            Catch ex As Exception
                pg.Value = 0
            End Try
        End While
        Ghi.Close()
        Cmd.Dispose()
        CN.Close()
        pg.Value = pg.Maximum
        MsgBox("Hoàn thành quá trình xuất dữ liệu chấm công", MsgBoxStyle.Information, "Thông báo")

    End Sub
End Class