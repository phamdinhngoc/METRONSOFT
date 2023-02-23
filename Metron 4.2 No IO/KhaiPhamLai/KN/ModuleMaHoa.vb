Module ModuleMaHoa
 
    Const DATASIZE = 459
    Const NameSize = 54
    Dim Lng() As Integer
 

    Public Function CVTemp(ByVal DL As Object) As String
        Dim Bye(DATASIZE * 5) As Byte
        Try
            Lng = CType(DL, Array)
            For i As Integer = 0 To DATASIZE - 1
                Bye(i * 5) = 1
                If Lng(i) < 0 Then
                    Bye(i * 5) = 0
                    Lng(i) = Math.Abs(Lng(i))
                End If
                Bye(i * 5 + 1) = Lng(i) \ 256 \ 256 \ 256
                Bye(i * 5 + 2) = (Lng(i) \ 256 \ 256) Mod 256
                Bye(i * 5 + 3) = (Lng(i) \ 256) Mod 256
                Bye(i * 5 + 4) = Lng(i) Mod 256
            Next
        Catch ex As Exception
        End Try
        CVTemp = System.Text.ASCIIEncoding.ASCII.GetString(Bye)
    End Function

    Public Function CVITemp(ByVal DL As String) As Object
        Dim VBye() As Byte
        Try
            VBye = System.Text.ASCIIEncoding.ASCII.GetBytes(DL)
            For i As Integer = 0 To DATASIZE - 1
                Lng(i) = VBye(i * 5 + 1)
                Lng(i) = Lng(i) * 256 + VBye(i * 5 + 2)
                Lng(i) = Lng(i) * 256 + VBye(i * 5 + 3)
                Lng(i) = Lng(i) * 256 + VBye(i * 5 + 4)
                If VBye(i * 5) = 0 Then
                    Lng(i) = 0 - Lng(i)
                End If
            Next
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
        CVITemp = Lng
    End Function
End Module
