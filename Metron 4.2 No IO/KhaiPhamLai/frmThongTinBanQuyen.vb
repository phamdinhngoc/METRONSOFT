Public Class frmThongTinBanQuyen

    Private Sub frmThongTinBanQuyen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim RD As System.IO.StreamReader


            RD = New IO.StreamReader(My.Application.Info.DirectoryPath & "\PD.MTAP")

            TenCTyBC = RD.ReadLine
            DiaChiBC = RD.ReadLine
            DienThoaiBC = RD.ReadLine
            Dim SNGayBan As String = RD.ReadLine
            Dim SSoLuong As String = RD.ReadLine
            Dim SSoNgay As String = RD.ReadLine
            Dim SSeri As String = RD.ReadLine
            Dim txt2 As String = RD.ReadLine
            RD.Close()
            AllSeri = Strings.Right(SSeri, Strings.Len(SSeri) - 9)

            Dim Songay As Integer
            NgayPBan = DateSerial(Strings.Right(SNGayBan, 4), Mid(SNGayBan, 14, 2), Mid(SNGayBan, 11, 2))
            Songay = CInt(Strings.Right(SSoNgay, Strings.Len(SSoNgay) - Strings.Len("Số ngày: ")))
            txtTenCongTy.Text = Strings.Right(TenCTyBC, Strings.Len(TenCTyBC) - 9)
            txtNgayCap.Text = NgayPBan
            If Songay = 0 Then
                txtBanQuyen.Text = "FULL"
            Else
                txtBanQuyen.Text = Songay & " ngày"
            End If
            Dim Mangseri() As String
            Mangseri = Split(AllSeri, " ")
            For i As Integer = 0 To UBound(Mangseri)
                DgvSeri.Rows.Add(i + 1, Mangseri(i))
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Thông báo")
        End Try
    End Sub

 
End Class