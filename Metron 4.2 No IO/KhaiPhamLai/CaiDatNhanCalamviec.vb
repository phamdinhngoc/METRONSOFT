Public Class CaiDatNhanCalamviec
    Dim busCa As New caBus(DTOKetnoi, False)
    Dim dtoCa1 As New cadto
    Dim dtoca2 As New cadto
    Dim dtoca3 As New cadto
    Dim buscatd As New caTDBus(DTOKetnoi, False)
    Private Tieptuc As Boolean = True
    Private TroVe As Boolean = False
    Private tranghienthoi As Integer = 1
    Private trangcuoi As Integer = 4
#Region "Trang 1"
    Private Sub Panel2_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel2.VisibleChanged
        If Panel3.Visible Then
        Else
            Trang1ThemCa()
        End If
    End Sub
    Private Sub Cangay()
        Dim ctr As Control
        For Each ctr In Panel2.Controls
            If ctr.Tag = "1" Then
                ctr.Enabled = CheckBox1.Checked
            ElseIf ctr.Tag = "2" Then
                ctr.Enabled = CheckBox2.Checked
            End If
        Next
    End Sub
    Private Sub checkbox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged, CheckBox2.CheckedChanged
        Cangay()
    End Sub
    Private Sub Trang1ThemCa()
        If CheckBox1.Checked Then
            dtoCa1.batdau = DateTimePicker1.Value
            dtoCa1.kethuc = DateTimePicker2.Value
        End If
        If CheckBox2.Checked Then
            dtoca2.batdau = DateTimePicker3.Value
            dtoca2.kethuc = DateTimePicker4.Value
            dtoca3.batdau = DateTimePicker5.Value
            dtoca3.kethuc = DateTimePicker6.Value
        End If
    End Sub
#End Region
#Region "Trang 2"
    Private Sub Panel3_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel3.VisibleChanged
        If Panel3.Visible Then
            If Tieptuc Then
                If CheckBox1.Checked Then
                    GroupBox1.Visible = True
                    GroupBox1.Text = dtoCa1.batdau.Hour & ":" & dtoCa1.batdau.Minute & " - " & dtoCa1.kethuc.Hour & ":" & dtoCa1.kethuc.Minute
                    DateTimePickerBatdauvao1.Value = dtoCa1.batdau.Date & " 12:00:00 PM "
                    DateTimePickerKetthucvao1.Value = dtoCa1.batdau.Date & " 13:00:00 PM "
                    DateTimePickerBatdauRa1.Value = dtoCa1.kethuc.Date
                    DateTimePickerKetthucRa1.Value = dtoCa1.kethuc.Date
                Else
                    GroupBox1.Visible = False
                End If
                If CheckBox2.Checked Then
                    GroupBox2.Visible = True
                    GroupBox3.Visible = True
                    GroupBox2.Text = dtoca2.batdau.Hour & ":" & dtoca2.batdau.Minute & " - " & dtoca2.kethuc.Hour & ":" & dtoca2.kethuc.Minute
                    GroupBox3.Text = dtoca3.batdau.Hour & ":" & dtoca3.batdau.Minute & " - " & dtoca3.kethuc.Hour & ":" & dtoca3.kethuc.Minute
                    DateTimePickerBatdauvao2.Value = dtoca2.batdau.Date
                    DateTimePickerKetthucvao2.Value = dtoca2.batdau.Date
                    DateTimePickerBatdauRa2.Value = dtoca2.kethuc.Date
                    DateTimePickerKetthucRa2.Value = dtoca2.kethuc.Date
                    DateTimePickerBatdauvao3.Value = dtoca3.batdau.Date
                    DateTimePickerKetthucvao3.Value = dtoca3.batdau.Date
                    DateTimePickerBatdauRa3.Value = dtoca3.kethuc.Date
                    DateTimePickerKetthucRa3.Value = dtoca3.kethuc.Date
                Else
                    GroupBox2.Visible = False
                    GroupBox3.Visible = False
                End If
            ElseIf TroVe Then
            End If
        Else
            Trang2ThemCa()
        End If
    End Sub
    Private Sub Trang2ThemCa()
        If CheckBox1.Checked Then
            dtoCa1.tgvao1 = DateTimePickerBatdauvao1.Value
            dtoCa1.tgvao2 = DateTimePickerKetthucvao1.Value
            dtoCa1.tgra1 = DateTimePickerBatdauRa1.Value
            dtoCa1.tgra2 = DateTimePickerKetthucRa1.Value
        End If
        If CheckBox2.Checked Then
            dtoca2.tgvao1 = DateTimePickerBatdauvao2.Value
            dtoca2.tgvao2 = DateTimePickerKetthucvao2.Value
            dtoca2.tgra1 = DateTimePickerBatdauRa2.Value
            dtoca2.tgra2 = DateTimePickerKetthucRa2.Value


            dtoca3.tgvao1 = DateTimePickerBatdauvao3.Value
            dtoca3.tgvao2 = DateTimePickerKetthucvao3.Value
            dtoca3.tgra1 = DateTimePickerBatdauRa3.Value
            dtoca3.tgra2 = DateTimePickerKetthucRa3.Value
        End If
    End Sub
#End Region
#Region "Trang 3"
    Private Sub Panel4_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel4.VisibleChanged
        If Panel4.Visible Then
        Else
            Trang3ThemCa()
        End If
    End Sub
    Private Sub Trang3ThemCa()
        dtoCa1.som = NumericUpDown1.Value
        dtoCa1.tre = NumericUpDown2.Value
        dtoca2.som = NumericUpDown1.Value
        dtoca2.tre = NumericUpDown2.Value
        dtoca3.som = NumericUpDown1.Value
        dtoca3.tre = NumericUpDown2.Value
    End Sub
#End Region
#Region "Trang 4"
    Private Sub Panel5_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel5.VisibleChanged
        If Panel5.Visible Then
        Else
            Trang4ThemCa()
        End If
    End Sub
    Private Sub Trang4ThemCa()
        dtoCa1.Tenca = "Hành chánh"
        dtoCa1.mau = Color.Orange.ToArgb
        dtoCa1.ngaycong = 1
        dtoCa1.Sophut = DateDiff(DateInterval.Month, dtoCa1.batdau, dtoCa1.kethuc)

        dtoca2.Tenca = "Ca Sáng"
        dtoca2.mau = Color.Green.ToArgb
        dtoca2.ngaycong = 0.5
        dtoca2.Sophut = DateDiff(DateInterval.Month, dtoca2.batdau, dtoca2.kethuc)

        dtoca3.Tenca = "Ca Chiều"
        dtoca3.mau = Color.Green.ToArgb
        dtoca3.ngaycong = 0.5
        dtoca3.Sophut = DateDiff(DateInterval.Month, dtoca3.batdau, dtoca3.kethuc)
    End Sub
#End Region
    Private Sub loadTrang1()
        CheckBox1.Checked = True
        DateTimePicker1.Value = #1/1/1900 8:00:00 AM#
        DateTimePicker2.Value = #1/1/1900 5:00:00 PM#

        DateTimePicker3.Value = #1/1/1900 8:00:00 AM#
        DateTimePicker4.Value = #1/1/1900 12:00:00 PM#
        DateTimePicker5.Value = #1/1/1900 1:00:00 PM#
        DateTimePicker6.Value = #1/1/1900 5:30:00 PM#
    End Sub
    Private Sub batPanel()
        Dim ctr As Control
        For Each ctr In Me.Controls
            If ctr.Tag = tranghienthoi Then
                ctr.Visible = True
            Else
                ctr.Visible = False
            End If
        Next
        Panel1.Visible = True
    End Sub
    Private Sub BackNext()
        If tranghienthoi = 1 Then
            Button1.Enabled = False
        Else
            Button1.Enabled = True
        End If
        If tranghienthoi = trangcuoi Then
            Button2.Text = "&Kết Thúc"
        Else
            Button2.Text = "&Tiếp tục >"
        End If
    End Sub
    Private Sub CaiDatNhanCalamviec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Trang 1
        batPanel()
        BackNext()
        loadTrang1()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Tieptuc = False
        TroVe = True
        If tranghienthoi = 1 Then
            Exit Sub
        Else
            tranghienthoi = tranghienthoi - 1
        End If
        batPanel()
        BackNext()
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
    Private Function SOPHUT1(ByVal DATE1 As Date, ByVal DATE2 As Date) As Integer
        If DateDiff(DateInterval.Hour, DATE1, DATE2) = 0 Then Return DateDiff(DateInterval.Minute, DATE1, DATE2)
        If DATE2.Hour - DATE1.Hour > 0 Then
            Return DateDiff(DateInterval.Minute, DATE1, DATE2)
        Else
            'Dim NGAY1 As Integer = DateDiff(DateInterval.Minute, DATE1, DateSerial(DATE1.Year, DATE1.Month, DATE1.Day + 1))
            'Dim NGAY2 As Integer = DateDiff(DateInterval.Minute, DateSerial(DATE1.Year, DATE1.Month, DATE1.Day), DATE2)
            'Return NGAY1 + NGAY2
            Return 0
        End If
    End Function
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Tieptuc = True
        TroVe = False
        If tranghienthoi = trangcuoi Then
            Try
                dtoCa1.Sophut = SOPHUT1(dtoCa1.tgvao1, dtoca2.tgvao2)
                If CheckBox1.Checked Then busCa.Them(dtoCa1)
                If CheckBox2.Checked Then
                    busCa.Them(dtoca2)
                    busCa.Them(dtoca3)
                End If
                If RadioButton1.Checked Then
                    Dim busnv As New nhanvienBus(DTOKetnoi, False)
                    Dim dataNV As DataTable = busnv.LayBangTable
                    For i As Integer = 0 To dataNV.Rows.Count - 1
                        If CheckBox1.Checked Then
                            Dim dtocatd1 As New caTDdto
                            dtocatd1.TuNgay = Date.Now
                            dtocatd1.DenNgay = DateAdd(DateInterval.Year, 5, Date.Now)
                            dtocatd1.Caid = dtoCa1.ID
                            dtocatd1.MaNV = dataNV.Rows(i)(0)
                            buscatd.Them(dtocatd1)
                        End If
                        If CheckBox2.Checked Then
                            Dim dtocatd2 As New caTDdto
                            dtocatd2.TuNgay = Date.Now
                            dtocatd2.DenNgay = DateAdd(DateInterval.Year, 5, Date.Now)
                            dtocatd2.Caid = dtoca2.ID
                            dtocatd2.MaNV = dataNV.Rows(i)(0)
                            buscatd.Them(dtocatd2)
                            Dim dtocatd3 As New caTDdto
                            dtocatd3.TuNgay = Date.Now
                            dtocatd3.DenNgay = DateAdd(DateInterval.Year, 5, Date.Now)
                            dtocatd3.Caid = dtoca3.ID
                            dtocatd3.MaNV = dataNV.Rows(i)(0)
                            buscatd.Them(dtocatd3)
                        End If
                    Next
                End If
            Catch ex As Exception
            End Try
            Me.Close()
        Else
            tranghienthoi = tranghienthoi + 1
        End If
        batPanel()
        BackNext()
    End Sub

   
End Class