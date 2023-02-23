Public Class Manhinhchongiols

    Public Cot, Hang As Integer
    Dim busVaoRa As New VaoraBus(DTOKetnoi, False)
    Dim mauThemca As Color = Color.Red
    Dim mauThemcanghi As Color = Color.Gray
    Dim Kieu As Integer
    
    Private Sub RBTG_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBTG.CheckedChanged, RBChuyen.CheckedChanged
        If Me.RBTG.Checked = True Then
            Me.GrTG.Enabled = True
            Me.GRChuyen.Enabled = False
        Else
            Me.GrTG.Enabled = False
            Me.GRChuyen.Enabled = True
        End If
    End Sub

    Private Sub ButtonLuu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonLuu.Click
        Try
            With ManHinhBaoCao
                Dim DTOVAORA As New Vaoradto
                DTOVAORA.MaNV = .DataGridViewChiTiet.Rows(Hang).Cells("macc").Value

                If Cot = 7 Then
                    If CheckBox1.Checked Then
                        DTOVAORA.Kieu = -4
                        .DataGridViewChiTiet.Item(Cot, Hang).Style.BackColor = mauThemcanghi
                    Else
                        DTOVAORA.Kieu = -1
                        .DataGridViewChiTiet.Item(Cot, Hang).Style.BackColor = mauThemca
                    End If
                Else
                    If CheckBox1.Checked Then
                        DTOVAORA.Kieu = -3
                        .DataGridViewChiTiet.Item(Cot, Hang).Style.BackColor = mauThemcanghi
                    Else
                        DTOVAORA.Kieu = -2
                        .DataGridViewChiTiet.Item(Cot, Hang).Style.BackColor = mauThemca
                    End If
                End If
                
                DTOVAORA.Ngay = Me.dtpNgay.Value.Date
                DTOVAORA.Thoigian = Me.dtpNgay.Value.Date & " " & Me.dtpGio.Value.ToLongTimeString

                .DataGridViewChiTiet.Item(Cot, Hang).Value = Me.dtpNgay.Value.Date & " " & Me.dtpGio.Value.ToLongTimeString
                .DataGridViewChiTiet.Item(Cot, Hang).Style.ForeColor = Color.White
                busVaoRa.Them(DTOVAORA)
            End With

        Catch ex As Exception
            MsgBox("Giờ này đã có", , "Thông báo")
            MsgBox(ex.Message)
        End Try
        Close()
    End Sub

    Private Sub ButtonXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonXoa.Click

        With ManHinhBaoCao

            If Not IsDBNull(.DataGridViewChiTiet.Rows(Hang).Cells(Cot).Value) Then

                Dim DTOVAORA As New Vaoradto
                DTOVAORA.MaNV = .DataGridViewChiTiet.Rows(Hang).Cells("macc").Value
                DTOVAORA.Thoigian = .DataGridViewChiTiet.Rows(Hang).Cells(Cot).Value
                busVaoRa.XoatheoManvvaThoigian(DTOVAORA.MaNV, DTOVAORA.Thoigian)
                .DataGridViewChiTiet.Rows(Hang).Cells(Cot).Value = ""
                .DataGridViewChiTiet.Item(Cot, Hang).Style.BackColor = .DataGridViewChiTiet.Rows(Hang).DefaultCellStyle.BackColor
                .DataGridViewChiTiet.Item(Cot, Hang).Style.ForeColor = .DataGridViewChiTiet.Columns(Cot).DefaultCellStyle.ForeColor

            End If

        End With
        Close()

    End Sub
 

    Private Sub Manhinhchongiols_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If Not IsDBNull(ManHinhBaoCao.DataGridViewChiTiet.Rows(Hang).Cells(Cot).Value) Then
            Try
                Me.ButtonXoa.Enabled = True
                Me.ButtonKhong.Enabled = True
                Me.dtpNgay.Value = ManHinhBaoCao.DataGridViewChiTiet.Rows(Hang).Cells(Cot).Value
                Me.dtpGio.Value = ManHinhBaoCao.DataGridViewChiTiet.Rows(Hang).Cells(Cot).Value
            Catch ex As Exception
                GoTo 2
            End Try
            
        Else
2:
            Me.ButtonKhong.Enabled = False
            Me.ButtonXoa.Enabled = False
            Me.dtpNgay.Value = ManHinhBaoCao.DataGridViewChiTiet.Rows(Hang).Cells("ngaychamcong").Value


        End If
        Me.RBTG.Checked = True
        Me.RBVao.Checked = True

        Kieu = -1
    End Sub

    Private Sub ButtonKhong_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonKhong.Click

        busVaoRa.suaKieu(Kieu, ManHinhBaoCao.DataGridViewChiTiet.Item("macc", Hang).Value, ManHinhBaoCao.DataGridViewChiTiet.Item(Cot, Hang).Value)
        ManHinhBaoCao.DataGridViewChiTiet.Rows(Hang).Cells(Cot).Style.BackColor = Color.Green
        Close()

    End Sub
 

    Private Sub RBRa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBRa.CheckedChanged, RBVao.CheckedChanged, RBTamRa.CheckedChanged, RBVoLai.CheckedChanged
        Select Case sender.name
            Case "RBVao"
                Kieu = -1
            Case "RBRa"
                Kieu = -2
            Case "RBTamRa"
                Kieu = -3
            Case "RBVoLai"
                Kieu = -4
        End Select
    End Sub
End Class