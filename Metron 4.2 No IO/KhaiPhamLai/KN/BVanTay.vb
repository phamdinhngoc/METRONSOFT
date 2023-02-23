Public Class BVanTay
    Const DATASIZE = 459
    Const F80_DATASIZE = (1404 + 12) / 4
    Const F80_NAMESIZE = 54

    Public Function ChuyenThanhIntBinary(ByVal vbyte() As Byte) As Object
        Dim vnii As Integer
        Dim gl(DATASIZE) As Integer
        For vnii = 0 To DATASIZE - 1
            gl(vnii) = vbyte(vnii * 5 + 1)
            gl(vnii) = gl(vnii) * 256 + vbyte(vnii * 5 + 2)
            gl(vnii) = gl(vnii) * 256 + vbyte(vnii * 5 + 3)
            gl(vnii) = gl(vnii) * 256 + vbyte(vnii * 5 + 4)
            If vbyte(vnii * 5) = 0 Then
                gl(vnii) = 0 - gl(vnii)
            End If
        Next
        Return gl
    End Function

    Public Function ChuyenThanhByteBinary(ByVal glngEnrollData As Object) As Byte()
        Dim vnii As Integer
        Dim gbytEnrollData(DATASIZE * 5) As Byte

        For vnii = 0 To DATASIZE - 1
            gbytEnrollData(vnii * 5) = 1
            If glngEnrollData(vnii) < 0 Then
                gbytEnrollData(vnii * 5) = 0
                glngEnrollData(vnii) = Math.Abs(glngEnrollData(vnii))
            End If
            gbytEnrollData(vnii * 5 + 1) = (glngEnrollData(vnii) \ 256 \ 256 \ 256)
            gbytEnrollData(vnii * 5 + 2) = (glngEnrollData(vnii) \ 256 \ 256) Mod 256
            gbytEnrollData(vnii * 5 + 3) = (glngEnrollData(vnii) \ 256) Mod 256
            gbytEnrollData(vnii * 5 + 4) = glngEnrollData(vnii) Mod 256

        Next
        Return gbytEnrollData
    End Function





    Public Function ChuyenThanhIntBinary_F80(ByVal vbyte() As Byte) As Object
        Dim vnii As Integer
        Dim gl(F80_DATASIZE) As Integer
        For vnii = 0 To F80_DATASIZE - 1
            gl(vnii) = vbyte(vnii * 5 + 1)
            gl(vnii) = gl(vnii) * 256 + vbyte(vnii * 5 + 2)
            gl(vnii) = gl(vnii) * 256 + vbyte(vnii * 5 + 3)
            gl(vnii) = gl(vnii) * 256 + vbyte(vnii * 5 + 4)
            If vbyte(vnii * 5) = 0 Then
                gl(vnii) = 0 - gl(vnii)
            End If
        Next
        Return gl
    End Function

    Public Function ChuyenThanhByteBinary_F80(ByVal glngEnrollData As Object) As Byte()
        Dim vnii As Integer
        Dim gbytEnrollData(F80_DATASIZE * 5) As Byte

        For vnii = 0 To F80_DATASIZE - 1
            gbytEnrollData(vnii * 5) = 1
            If glngEnrollData(vnii) < 0 Then
                gbytEnrollData(vnii * 5) = 0
                glngEnrollData(vnii) = Math.Abs(glngEnrollData(vnii))
            End If
            gbytEnrollData(vnii * 5 + 1) = (glngEnrollData(vnii) \ 256 \ 256 \ 256)
            gbytEnrollData(vnii * 5 + 2) = (glngEnrollData(vnii) \ 256 \ 256) Mod 256
            gbytEnrollData(vnii * 5 + 3) = (glngEnrollData(vnii) \ 256) Mod 256
            gbytEnrollData(vnii * 5 + 4) = glngEnrollData(vnii) Mod 256

        Next
        Return gbytEnrollData
    End Function

End Class
