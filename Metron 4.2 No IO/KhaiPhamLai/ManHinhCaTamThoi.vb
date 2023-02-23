Public Class ManHinhCaTamThoi
    Dim bus As New caBus(DTOKetnoi, False)
    Dim dto As New cadto
    Dim buslichtam As New lichtamBus(DTOKetnoi, False)
    Dim dtolichtam As New lichtamdto
    Public tungay As Date
    Public songay As Integer
    Public NVid As Integer
    Public thoat As Boolean = False
    Private Sub ManHinhCaTamThoi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGridViewCA.DataSource = bus.LayBangTable
        DataGridViewNgay.Rows.Clear()
        For i As Integer = 0 To songay
            DataGridViewNgay.Rows.Add(False, DateAdd(DateInterval.DayOfYear, i, tungay))
        Next
        GroupBox2.Enabled = CheckBox1.Checked
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
        thoat = True
    End Sub
    Private Function KiemTra(ByVal dtolich1 As lichtamdto) As Boolean
        Dim sql As String = "select * from lichtam where NVID= " & dtolich1.NVID & " and CaID=" & dtolich1.CaID & " and tungay=#" & dtolich1.Tungay & "# and denngay=#" & dtolich1.Denngay & "#"
        If buslichtam.LayBangTableSQL(sql).Rows.Count > 0 Then Return False
        sql = "select * from lichtam where NVID= " & dtolich1.NVID & " and year(tungay)=" & dtolich1.Tungay.Year & " and month(tungay)=" & dtolich1.Tungay.Month & " and day(tungay)=" & dtolich1.Tungay.Day & " and year(denngay)=" & dtolich1.Denngay.Year & " and month(denngay)=" & dtolich1.Denngay.Month & " and day(denngay)=" & dtolich1.Denngay.Day
        Dim Table As DataTable = buslichtam.LayBangTableSQL(sql)
        Dim TraVe As Boolean = True
        For i As Integer = 0 To Table.Rows.Count - 1

            Dim dtolich2 As lichtamdto = buslichtam.LayBangDTo(i, Table)
            Dim ca1 As cadto = bus.LayBangDTo(dtolich1.CaID)
            Dim ca2 As cadto = bus.LayBangDTo(dtolich2.CaID)
            If ca1.CaQuaNgay And ca2.CaQuaNgay Then TraVe = False
            If ca1.CaQuaNgay Then
                If ca1.kethuc <= ca2.batdau And ca2.batdau <= ca1.batdau And ca1.kethuc <= ca2.kethuc And ca2.kethuc <= ca1.batdau Then
                Else
                    TraVe = False
                End If
            ElseIf ca2.CaQuaNgay Then
                If ca2.kethuc <= ca1.batdau And ca1.batdau <= ca2.batdau And ca2.kethuc <= ca1.kethuc And ca1.kethuc <= ca2.batdau Then
                Else
                    TraVe = False
                End If
            Else
                Dim min As Integer
                Dim max As Integer
                If ca1.batdau < ca2.batdau Then
                    min = ca1.batdau.Hour * 60 + ca1.batdau.Minute
                Else
                    min = ca2.batdau.Hour * 60 + ca2.batdau.Minute
                End If
                If ca1.kethuc > ca2.kethuc Then
                    max = ca1.kethuc.Hour * 60 + ca1.kethuc.Minute
                Else
                    max = ca2.kethuc.Hour * 60 + ca2.kethuc.Minute
                End If
                Dim Tong2ca As Integer = ca1.Sophut + ca2.Sophut
                Dim ChieudaiMinMax As Integer = max - min
                If ChieudaiMinMax >= Tong2ca Then
                Else
                    TraVe = False
                End If
            End If
        Next
        Return TraVe
    End Function
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Thongbao As String = ""
        If IsNumeric(TextBoxTangcas.Text) = False Or IsNumeric(TextBoxGhTangCa.Text) = False Then
            MsgBox("Thông tin tăng ca có lổi")
            Exit Sub
        End If
        ToolStripProgressBar1.Maximum = DataGridViewCA.Rows.Count * DataGridViewNgay.Rows.Count
        For i As Integer = 0 To DataGridViewCA.Rows.Count - 1
            If DataGridViewCA.Rows(i).Cells(0).Value Then
                For j As Integer = 0 To DataGridViewNgay.Rows.Count - 1
                    ToolStripProgressBar1.Value += 1
                    If DataGridViewNgay.Rows(j).Cells(0).Value Then
                        dtolichtam.CaID = DataGridViewCA.Rows(i).Cells(1).Value
                        dtolichtam.NVID = NVid
                        dtolichtam.Tungay = DataGridViewNgay.Rows(j).Cells(1).Value
                        dtolichtam.Denngay = DataGridViewNgay.Rows(j).Cells(1).Value
                        dtolichtam.Dilam = True
                        dtolichtam.Tangca = CheckBox1.Checked
                        dtolichtam.TangCaS = TextBoxTangcas.Text
                        dtolichtam.GHTangC = TextBoxGhTangCa.Text
                        If KiemTra(dtolichtam) Then
                            buslichtam.Xoa(dtolichtam.NVID, dtolichtam.CaID, dtolichtam.Tungay, dtolichtam.Denngay)
                            buslichtam.Them(dtolichtam)
                        Else
                            If Thongbao = "" Then Thongbao += "Danh sách các ngày bị trùng (Không thể thêm ca):" & vbNewLine
                            Thongbao += DataGridViewNgay.Rows(j).Cells(1).Value & vbNewLine
                        End If
                    End If
                Next
            End If
        Next
        ToolStripProgressBar1.Value = 0
        Me.Close()
        If Thongbao <> "" Then MsgBox(Thongbao, , "Thông báo")
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
End Class