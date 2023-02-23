Public Class ManHinhEpCaTD
    Dim bus As New caBus(DTOKetnoi, False)
    Dim dto As New cadto
    Dim busTD As New caTDBus(DTOKetnoi, False)
    Dim dtoTD As New caTDdto
    Public tungay As Date
    Public songay As Integer
    Public NVid As Integer
    Public thoat As Boolean = False
    Public Kieu As Integer

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
        thoat = True
    End Sub
    Private Sub ManHinhEpCaTD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Kieu = 1 Then
            DataGridView1.DataSource = bus.LayBangTableKHONGTHUOCcaTuDong(NVid)
        Else
            DataGridView1.DataSource = bus.LayBangTable()
        End If

        GroupBox2.Enabled = CheckBox1.Checked
    End Sub
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        GroupBox2.Enabled = CheckBox1.Checked
    End Sub
    Private Sub TextBoxTangcas_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxTangcas.TextChanged
        If IsNumeric(TextBoxTangcas.Text) = False Then
            ErrorProvider1.SetError(TextBoxTangcas, "Không phải số")
        Else
            ErrorProvider1.SetError(TextBoxTangcas, "")
        End If
    End Sub
    Private Sub TextBoxGhTangCa_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxGhTangCa.TextChanged
        If IsNumeric(TextBoxGhTangCa.Text) = False Then
            ErrorProvider1.SetError(TextBoxGhTangCa, "Không phải số")
        Else
            ErrorProvider1.SetError(TextBoxGhTangCa, "")
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If Kieu = 1 Then


                For j As Integer = 0 To ManHinhApLichNV.dgvNV.SelectedRows.Count - 1
                    For i As Integer = 0 To DataGridView1.Rows.Count - 1
                        If DataGridView1.Rows.Item(i).Cells(0).Value Then
                            dtoTD.Caid = DataGridView1.Rows.Item(i).Cells("id1").Value
                            dtoTD.MaNV = ManHinhApLichNV.dgvNV.SelectedRows(j).Cells("MaNV").Value
                            dtoTD.TuNgay = DateTimePicker1.Value.Date
                            dtoTD.DenNgay = DateTimePicker2.Value.Date
                            dtoTD.Tangca = CheckBox1.Checked
                            dtoTD.TangcaS = TextBoxTangcas.Text
                            If chbtangcatruoc.Checked = True Then
                                dtoTD.TangcaS = -dtoTD.TangcaS
                            End If


                            dtoTD.GhTangca = TextBoxGhTangCa.Text

                            Try
                                busTD.Them(dtoTD)
                            Catch ex As Exception
                            End Try
                        End If
                    Next
                Next
                Me.Close()

            Else

                Dim DtoTam As New lichtamdto
                Dim BusTam As New lichtamBus(DTOKetnoi, False)

                For j As Integer = 0 To ManHinhApLichNV.dgvNV.SelectedRows.Count - 1
                    For i As Integer = 0 To DataGridView1.Rows.Count - 1
                        If DataGridView1.Rows.Item(i).Cells(0).Value Then
                            DtoTam.CaID = DataGridView1.Rows.Item(i).Cells("id1").Value
                            DtoTam.NVID = ManHinhApLichNV.dgvNV.SelectedRows(j).Cells("MaNV").Value
                            DtoTam.Tungay = DateTimePicker1.Value.Date
                            DtoTam.Denngay = DateTimePicker2.Value.Date
                            DtoTam.Tangca = CheckBox1.Checked
                            DtoTam.TangCaS = TextBoxTangcas.Text
                            DtoTam.GHTangC = TextBoxGhTangCa.Text
                            DtoTam.Dilam = Me.chkquangay.Checked
                            Try
                                BusTam.Them(DtoTam)
                            Catch ex As Exception
                            End Try
                        End If
                    Next
                Next
                Me.Close()

            End If

        Catch ex As Exception
            MsgBox("Có lổi đề nghị bạn kiểm tra lại trước khi lưu")
        End Try
    End Sub
End Class