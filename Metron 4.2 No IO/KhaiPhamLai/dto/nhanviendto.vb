Public Class nhanviendto
    Inherits AbstractDto
#Region "Các Thuộc Tính"
    Private _MaNV As System.Int32
    Private _NVSP As System.String
    Private _TenNV As System.String
    Private _TenHT As System.String
    Private _Chucvu As System.Int32
    Private _Donvi As System.Int32
    Private _Quyen As System.Int32
    Private _CardNo As System.String
    Private _Ngaysinh As System.DateTime
    Private _Gioitinh As System.String
    Private _Diachi As System.String
    Private _CMND As System.String
    Private _Ngayvaolam As System.DateTime
    Private _Hinh As System.String
#End Region
#Region "Khai báo các phương thức truy xuất"
    Public Property MaNV() As System.Int32
        Get
            Return _MaNV
        End Get
        Set(ByVal value As System.Int32)
            _MaNV = value
        End Set
    End Property
    Public Property NVSP() As System.String
        Get
            Return _NVSP
        End Get
        Set(ByVal value As System.String)
            _NVSP = value
        End Set
    End Property
    Public Property TenNV() As System.String
        Get
            Return _TenNV
        End Get
        Set(ByVal value As System.String)
            _TenNV = value
        End Set
    End Property
    Public Property TenHT() As System.String
        Get
            Return _TenHT
        End Get
        Set(ByVal value As System.String)
            _TenHT = value
        End Set
    End Property
    Public Property Chucvu() As System.Int32
        Get
            Return _Chucvu
        End Get
        Set(ByVal value As System.Int32)
            _Chucvu = value
        End Set
    End Property
    Public Property Donvi() As System.Int32
        Get
            Return _Donvi
        End Get
        Set(ByVal value As System.Int32)
            _Donvi = value
        End Set
    End Property
    Public Property Quyen() As System.Int32
        Get
            Return _Quyen
        End Get
        Set(ByVal value As System.Int32)
            _Quyen = value
        End Set
    End Property
    Public Property CardNo() As System.String
        Get
            Return _CardNo
        End Get
        Set(ByVal value As System.String)
            _CardNo = value
        End Set
    End Property
    Public Property Ngaysinh() As System.DateTime
        Get
            Return _Ngaysinh
        End Get
        Set(ByVal value As System.DateTime)
            _Ngaysinh = value
        End Set
    End Property
    Public Property Gioitinh() As System.String
        Get
            Return _Gioitinh
        End Get
        Set(ByVal value As System.String)
            _Gioitinh = value
        End Set
    End Property
    Public Property Diachi() As System.String
        Get
            Return _Diachi
        End Get
        Set(ByVal value As System.String)
            _Diachi = value
        End Set
    End Property
    Public Property CMND() As System.String
        Get
            Return _CMND
        End Get
        Set(ByVal value As System.String)
            _CMND = value
        End Set
    End Property
    Public Property Ngayvaolam() As System.DateTime
        Get
            Return _Ngayvaolam
        End Get
        Set(ByVal value As System.DateTime)
            _Ngayvaolam = value
        End Set
    End Property
    Public Property Hinh() As System.String
        Get
            Return _Hinh
        End Get
        Set(ByVal value As System.String)
            _Hinh = value
        End Set
    End Property
#End Region
    Public Sub New()
        MaNV = 0
        NVSP = ""
        TenNV = ""
        TenHT = ""
        Chucvu = 0
        Donvi = 0
        Quyen = 0
        CardNo = "."
        Ngaysinh = #1/1/1900#
        Gioitinh = "."
        Diachi = "."
        CMND = "."
        Ngayvaolam = #1/1/1900#
        Hinh = "."
    End Sub
    Public Function HoTro(ByVal tencolumn As String) As String
        Select Case UCase(Convert.ToString(tencolumn))
            Case UCase("MaNV")
                If IsDBNull(MaNV) = True Then
                    Return "0"
                End If
                Return Convert.ToString(MaNV)
            Case UCase("NVSP")
                If IsDBNull(NVSP) = True Then
                    Return """"
                End If
                Return Convert.ToString(NVSP)
            Case UCase("TenNV")
                If IsDBNull(TenNV) = True Then
                    Return """"
                End If
                Return Convert.ToString(TenNV)
            Case UCase("TenHT")
                If IsDBNull(TenHT) = True Then
                    Return """"
                End If
                Return Convert.ToString(TenHT)
            Case UCase("Chucvu")
                If IsDBNull(Chucvu) = True Then
                    Return "0"
                End If
                Return Convert.ToString(Chucvu)
            Case UCase("Donvi")
                If IsDBNull(Donvi) = True Then
                    Return "0"
                End If
                Return Convert.ToString(Donvi)
            Case UCase("Quyen")
                If IsDBNull(Quyen) = True Then
                    Return "0"
                End If
                Return Convert.ToString(Quyen)
            Case UCase("CardNo")
                If IsDBNull(CardNo) = True Then
                    Return """"
                End If
                Return Convert.ToString(CardNo)
            Case UCase("Ngaysinh")
                If IsDBNull(Ngaysinh) = True Then
                    Return "#1/1/1900#"
                End If
                Return Convert.ToString(Ngaysinh)
            Case UCase("Gioitinh")
                If IsDBNull(Gioitinh) = True Then
                    Return """"
                End If
                Return Convert.ToString(Gioitinh)
            Case UCase("Diachi")
                If IsDBNull(Diachi) = True Then
                    Return """"
                End If
                Return Convert.ToString(Diachi)
            Case UCase("CMND")
                If IsDBNull(CMND) = True Then
                    Return """"
                End If
                Return Convert.ToString(CMND)
            Case UCase("Ngayvaolam")
                If IsDBNull(Ngayvaolam) = True Then
                    Return "#1/1/1900#"
                End If
                Return Convert.ToString(Ngayvaolam)
            Case UCase("Hinh")
                If IsDBNull(Hinh) = True Then
                    Return """"
                End If
                Return Convert.ToString(Hinh)
            Case Else
                Return ""
        End Select
    End Function
    Public Function HoTro(ByVal tencolumn As String, ByVal value As String) As String
        Select Case UCase(Convert.ToString(tencolumn))
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
            Case UCase("NVSP")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                NVSP = Convert.ToString(value)
            Case UCase("TenNV")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                TenNV = Convert.ToString(value)
            Case UCase("TenHT")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                TenHT = Convert.ToString(value)
            Case UCase("Chucvu")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa Chọn dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                Chucvu = Convert.ToInt32(value)
            Case UCase("Donvi")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                Donvi = Convert.ToInt32(value)
            Case UCase("Quyen")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                Quyen = Convert.ToInt32(value)
            Case UCase("CardNo")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                CardNo = Convert.ToString(value)
            Case UCase("Ngaysinh")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsDate(value) = False Then
                    Return "Không phải ngày đề nghị nhập lại"
                End If
                Ngaysinh = Convert.ToDateTime(value)
            Case UCase("Gioitinh")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                Gioitinh = Convert.ToString(value)
            Case UCase("Diachi")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                Diachi = Convert.ToString(value)
            Case UCase("CMND")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                CMND = Convert.ToString(value)
            Case UCase("Ngayvaolam")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsDate(value) = False Then
                    Return "Không phải ngày đề nghị nhập lại"
                End If
                Ngayvaolam = Convert.ToDateTime(value)
            Case UCase("Hinh")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                Hinh = Convert.ToString(value)
            Case Else
                Return ""
        End Select
        Return ""
    End Function
End Class
