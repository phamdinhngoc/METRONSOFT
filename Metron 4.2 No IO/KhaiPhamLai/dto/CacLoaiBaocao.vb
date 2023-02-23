Public Class CacLoaiBaocao
    Public TenLoaibaocao As String
    Public Maso As String
    Public Sub New()
        TenLoaibaocao = ""
        Maso = ""
    End Sub

    Public Function Kiemtra() As Boolean
        Select Case Maso
            Case "1" 'In Out BreakIn BreakOut
                MsgBox("Báo cáo dạng " & vbNewLine & "In , Out , BreakIn , BreakOut", , "Thông báo")
                Return True
            Case "2" 'In Out
                MsgBox("Báo cáo dạng " & vbNewLine & "In=BreakIn , Out=BreakOut ", , "Thông báo")
                Return True
                'Case "3" 'Không phân biệt
                '    MsgBox("Báo cáo dạng " & vbNewLine & "In=BreakIn=Out=BreakOut ", , "Thông báo")
                '    Return True
            Case Else
                MsgBox("???", , "Thông báo")
                Return False
        End Select
    End Function
End Class
