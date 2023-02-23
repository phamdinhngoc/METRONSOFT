Public Class NVnghiphepdto
    Inherits AbstractDto
#Region "Các Thuộc Tính"
    Private _IDNP As System.Int32
    Private _MaNV As System.Int32
    Private _Ngay As System.DateTime
    Private _Lydo As System.String
    Private _SoNgay As System.Double
    Private _SoCong As System.Double
#End Region
#Region "Khai báo các phương thức truy xuất"
    Public Property IDNP() As System.Int32
        Get
            Return _IDNP
        End Get
        Set(ByVal value As System.Int32)
            _IDNP = value
        End Set
    End Property
    Public Property MaNV() As System.Int32
        Get
            Return _MaNV
        End Get
        Set(ByVal value As System.Int32)
            _MaNV = value
        End Set
    End Property
    Public Property Ngay() As System.DateTime
        Get
            Return _Ngay
        End Get
        Set(ByVal value As System.DateTime)
            _Ngay = value
        End Set
    End Property
    Public Property Lydo() As System.String
        Get
            Return _Lydo
        End Get
        Set(ByVal value As System.String)
            _Lydo = value
        End Set
    End Property
    Public Property SoNgay() As System.Double
        Get
            Return _SoNgay
        End Get
        Set(ByVal value As System.Double)
            _SoNgay = value
        End Set
    End Property
    Public Property SoCong() As System.Double
        Get
            Return _SoCong
        End Get
        Set(ByVal value As System.Double)
            _SoCong = value
        End Set
    End Property
#End Region
    Public Sub New()
        IDNP = 0
        MaNV = 0
        Ngay = #1/1/1900#
        Lydo = ""
        SoNgay = 0
        SoCong = 0
    End Sub
    Public Function HoTro(ByVal tencolumn As String) As String
        Select Case UCase(Convert.ToString(tencolumn))
            Case UCase("IDNP")
                If IsDBNull(IDNP) = True Then
                    Return "0"
                End If
                Return Convert.ToString(IDNP)
            Case UCase("MaNV")
                If IsDBNull(MaNV) = True Then
                    Return "0"
                End If
                Return Convert.ToString(MaNV)
            Case UCase("Ngay")
                If IsDBNull(Ngay) = True Then
                    Return "#1/1/1900#"
                End If
                Return Convert.ToString(Ngay)
            Case UCase("Lydo")
                If IsDBNull(Lydo) = True Then
                    Return """"
                End If
                Return Convert.ToString(Lydo)
            Case UCase("SoNgay")
                If IsDBNull(SoNgay) = True Then
                    Return "0"
                End If
                Return Convert.ToString(SoNgay)
            Case UCase("SoCong")
                If IsDBNull(SoCong) = True Then
                    Return "0"
                End If
                Return Convert.ToString(SoCong)
            Case Else
                Return ""
        End Select
    End Function
    Public Function HoTro(ByVal tencolumn As String, ByVal value As String, Optional ByVal TT As String = "sua") As String
        Select Case UCase(Convert.ToString(tencolumn))
            Case UCase("IDNP")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                IDNP = Convert.ToInt32(value)
            Case UCase("MaNV")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                MaNV = Convert.ToInt32(value)
            Case UCase("Ngay")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsDate(value) = False Then
                    Return "Không phải ngày đề nghị nhập lại"
                End If
                Ngay = Convert.ToDateTime(value)
            Case UCase("Lydo")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                Lydo = Convert.ToString(value)
            Case UCase("SoNgay")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                SoNgay = Convert.ToDouble(value)
            Case UCase("SoCong")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                SoCong = Convert.ToDouble(value)
            Case Else
                Return ""
        End Select
        Return ""
    End Function
End Class
