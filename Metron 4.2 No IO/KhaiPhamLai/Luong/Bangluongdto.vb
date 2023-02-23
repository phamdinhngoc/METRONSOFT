Public Class Bangluongdto
    Inherits AbstractDto
#Region "Các Thuộc Tính"
    Private _Manv As System.Int32
    Private _Thang As System.Int32
    Private _Nam As System.Int32
    Private _LuongThang As System.Double
    Private _Luongngay As System.Double
    Private _Socong As System.Double
    Private _Songay As System.Int32
    Private _Luongngaycong As System.Double
    Private _Phucap1 As System.Double
    Private _Tamung1 As System.Double
    Private _SoGioTC As System.Double
    Private _TienTcGio As System.Double
    Private _TienTangca As Double
    Private _TienAnTC As Double
    Private _NgayCN As Double
    Private _LuongCN As Double
    Private _Solanditre As System.Int32
    Private _Phatditre As System.Double
    Private _Solannghikophep As System.Double
    Private _phatnghikophep As System.Double
    Private _PhantramBH As Double
    Private _TienBH As Double
    Public _Thuclanh As Double
    Private _Trangthai As System.Int32
    Private _TienComTrua As System.Int32
    Private _SuatAnTrua As System.Int32
    Private _phuCap2 As System.Int32
    Private _tongTienXe As System.Double
    Private _ngayGuixe As System.Double
    Private _tienGuiXe As System.Double
    Private _chuyenCan As System.Double

#End Region
#Region "Khai báo các phương thức truy xuất"
    Public Property Manv() As System.Int32
        Get
            Return _Manv
        End Get
        Set(ByVal value As System.Int32)
            _Manv = value
        End Set
    End Property
    Public Property Thang() As System.Int32
        Get
            Return _Thang
        End Get
        Set(ByVal value As System.Int32)
            _Thang = value
        End Set
    End Property
    Public Property Nam() As System.Int32
        Get
            Return _Nam
        End Get
        Set(ByVal value As System.Int32)
            _Nam = value
        End Set
    End Property
    Public Property LuongThang() As Double
        Get
            Return _LuongThang
        End Get
        Set(ByVal value As Double)
            _LuongThang = value
        End Set
    End Property
    Public Property Luongngay() As Double
        Get
            Return _Luongngay
        End Get
        Set(ByVal value As Double)
            _Luongngay = value
        End Set
    End Property
    Public Property Socong() As System.Double
        Get
            Return _Socong
        End Get
        Set(ByVal value As System.Double)
            _Socong = value
        End Set
    End Property
    Public Property Songay() As System.Int32
        Get
            Return _Songay
        End Get
        Set(ByVal value As System.Int32)
            _Songay = value
        End Set
    End Property
    Public Property Luongngaycong() As Double
        Get
            Return _Luongngaycong
        End Get
        Set(ByVal value As Double)
            _Luongngaycong = value
        End Set
    End Property
    Public Property Phucap1() As Double
        Get
            Return _Phucap1
        End Get
        Set(ByVal value As Double)
            _Phucap1 = value
        End Set
    End Property
    Public Property Tamung1() As System.Double
        Get
            Return _Tamung1
        End Get
        Set(ByVal value As System.Double)
            _Tamung1 = value
        End Set
    End Property
    Public Property SoGioTc As System.Double
        Get
            Return _SoGioTC
        End Get
        Set(ByVal value As System.Double)
            _SoGioTC = value
        End Set
    End Property
    Public Property TienTcGio() As System.Double
        Get
            Return _TienTcGio
        End Get
        Set(ByVal value As System.Double)
            _TienTcGio = value
        End Set
    End Property
    Public Property TienTangca As System.Double
        Get
            Return _TienTangca
        End Get
        Set(ByVal value As System.Double)
            _TienTangca = value
        End Set
    End Property
    Public Property TienAnTC() As System.Double
        Get
            Return _TienAnTC
        End Get
        Set(ByVal value As System.Double)
            _TienAnTC = value
        End Set
    End Property
    
    Public Property NgayCN() As System.Double
        Get
            Return _NgayCN
        End Get
        Set(ByVal value As System.Double)
            _NgayCN = value
        End Set
    End Property
    Public Property LuongCN As Double
        Get
            Return _LuongCN
        End Get
        Set(ByVal value As Double)
            _LuongCN = value
        End Set
    End Property
    Public Property Solanditre() As System.Int32
        Get
            Return _Solanditre
        End Get
        Set(ByVal value As System.Int32)
            _Solanditre = value
        End Set
    End Property
    Public Property Phatditre() As System.Double
        Get
            Return _Phatditre
        End Get
        Set(ByVal value As System.Double)
            _Phatditre = value
        End Set
    End Property
  
    Public Property Solannghikophep() As System.Double
        Get
            Return _Solannghikophep
        End Get
        Set(ByVal value As System.Double)
            _Solannghikophep = value
        End Set
    End Property
   
    Public Property phatnghikophep() As System.Double
        Get
            Return _phatnghikophep
        End Get
        Set(ByVal value As System.Double)
            _phatnghikophep = value
        End Set
    End Property
    Public Property PhanTramBH As Double
        Get
            Return _PhantramBH
        End Get
        Set(ByVal value As Double)
            _PhantramBH = value
        End Set
    End Property
    Public Property TienBH As Double
        Get
            Return _TienBH
        End Get
        Set(ByVal value As Double)
            _TienBH = value
        End Set
    End Property
    Public Property ThucLanh() As System.Double
        Get
            Return _Thuclanh
        End Get
        Set(ByVal value As System.Double)
            _Thuclanh = value
        End Set
    End Property

    Public Property Trangthai() As System.Int32
        Get
            Return _Trangthai
        End Get
        Set(ByVal value As System.Int32)
            _Trangthai = value
        End Set
    End Property
    Public Property TienComTrua() As System.Int32
        Get
            Return _TienComTrua
        End Get
        Set(ByVal value As System.Int32)
            _TienComTrua = value
        End Set
    End Property
    Public Property SuatAnTrua() As System.Int32
        Get
            Return _SuatAnTrua
        End Get
        Set(ByVal value As System.Int32)
            _SuatAnTrua = value
        End Set
    End Property
    Public Property Phucap2() As Double
        Get
            Return _phuCap2
        End Get
        Set(ByVal value As Double)
            _phuCap2 = value
        End Set
    End Property
    Public Property TongTienXe() As Double
        Get
            Return _tongTienXe
        End Get
        Set(ByVal value As Double)
            _tongTienXe = value
        End Set
    End Property
    Public Property NgayGuiXe() As Double
        Get
            Return _ngayGuixe
        End Get
        Set(ByVal value As Double)
            _ngayGuixe = value
        End Set
    End Property
    Public Property TienGuiXe() As Double
        Get
            Return _tienGuiXe
        End Get
        Set(ByVal value As Double)
            _tienGuiXe = value
        End Set
    End Property
    Public Property ChuyenCan() As Double
        Get
            Return _chuyenCan
        End Get
        Set(ByVal value As Double)
            _chuyenCan = value
        End Set
    End Property
    
#End Region
    Public Sub New()
        Manv = 0 '1
        Thang = 0 '2
        Nam = 0 '3
        LuongThang = 0 '4
        Luongngay = 0 '5
        Socong = 0 '6
        Songay = 0 '7
        Luongngaycong = 0 '8
        Phucap1 = 0 '9
        Tamung1 = 0 '10

        SoGioTc = 0 '11
        TienTcGio = 0 '12
        TienTangca = 0 '13
        TienAnTC = 0

        NgayCN = 0
        LuongCN = 0
        Solanditre = 0 '14
        Phatditre = 0 '16
        Solannghikophep = 0 '15
        phatnghikophep = 0 '17
        PhanTramBH = 0 '18
        TienBH = 0 '19
        ThucLanh = 0 '20
        Trangthai = 0 '21
        TienComTrua = 0
        SuatAnTrua = 0
        Phucap2 = 0
        TienGuiXe = 0
        NgayGuiXe = 0
        TongTienXe = 0
        ChuyenCan = 0

    End Sub
    Public Sub New(ByVal thang As Integer, ByVal nam As Integer)
        Manv = 0 '1
        thang = 0 '2
        nam = 0 '3
        LuongThang = 0 '4
        Luongngay = 0 '5
        Socong = 0 '6
        Songay = 0 '7
        Luongngaycong = 0 '8
        Phucap1 = 0 '9
        Tamung1 = 0 '10

        SoGioTc = 0 '11
        TienTcGio = 0 '12
        TienTangca = 0 '13
        TienAnTC = 0

        NgayCN = 0
        LuongCN = 0
        Solanditre = 0 '14
        Phatditre = 0 '16
        Solannghikophep = 0 '15
        phatnghikophep = 0 '17
        PhanTramBH = 0 '18
        TienBH = 0 '19
        ThucLanh = 0 '20
        Trangthai = 0 '21
        TienComTrua = 0
        SuatAnTrua = 0
        Phucap2 = 0
        TienGuiXe = 0
        NgayGuiXe = 0
        TongTienXe = 0
        ChuyenCan = 0

    End Sub
    Public Function HoTro(ByVal tencolumn As String) As String
        Select Case UCase(Convert.ToString(tencolumn))
            Case UCase("Manv")
                If IsDBNull(Manv) = True Then
                    Return "0"
                End If
                Return Convert.ToString(Manv)
            Case UCase("Thang")
                If IsDBNull(Thang) = True Then
                    Return "0"
                End If
                Return Convert.ToString(Thang)
            Case UCase("Nam")
                If IsDBNull(Nam) = True Then
                    Return "0"
                End If
                Return Convert.ToString(Nam)
            Case UCase("LuongThang")
                If IsDBNull(LuongThang) = True Then
                    Return "0"
                End If
                Return Convert.ToString(LuongThang)
            Case UCase("Luongngay")
                If IsDBNull(Luongngay) = True Then
                    Return "0"
                End If
                Return Convert.ToString(Luongngay)
            Case UCase("Socong")
                If IsDBNull(Socong) = True Then
                    Return "0"
                End If
                Return Convert.ToString(Socong)
            Case UCase("Songay")
                If IsDBNull(Songay) = True Then
                    Return "0"
                End If
                Return Convert.ToString(Songay)
            Case UCase("Luongngaycong")
                If IsDBNull(Luongngaycong) = True Then
                    Return "0"
                End If
                Return Convert.ToString(Luongngaycong)
            Case UCase("Phucap1")
                If IsDBNull(Phucap1) = True Then
                    Return "0"
                End If
                Return Convert.ToString(Phucap1)
            Case UCase("Tamung1")
                If IsDBNull(Tamung1) = True Then
                    Return "0"
                End If
                Return Convert.ToString(Tamung1)
            Case UCase("SoGioTC")
                If IsDBNull(SoGioTc) = True Then
                    Return "0"
                End If
                Return Convert.ToString(SoGioTc)
            Case UCase("TienTCGio")
                If IsDBNull(TienTcGio) = True Then
                    Return "0"
                End If
                Return Convert.ToString(TienTcGio)
            Case UCase("Tientangca")
                If IsDBNull(TienTangca) = True Then
                    Return "0"
                End If
                Return Convert.ToString(TienTangca)
            Case UCase("NgayCN")
                If IsDBNull(NgayCN) = True Then
                    Return "0"
                End If
                Return Convert.ToString(NgayCN)
            Case UCase("LuongCN")
                If IsDBNull(LuongCN) = True Then
                    Return "0"
                End If
                Return Convert.ToString(LuongCN)
            Case UCase("Solanditre")
                If IsDBNull(Solanditre) = True Then
                    Return "0"
                End If
                Return Convert.ToString(Solanditre)
            Case UCase("Phatditre")
                If IsDBNull(Phatditre) = True Then
                    Return "0"
                End If
                Return Convert.ToString(Phatditre)
            Case UCase("Solannghikophep")
                If IsDBNull(Solannghikophep) = True Then
                    Return "0"
                End If
                Return Convert.ToString(Solannghikophep)
            Case UCase("phatnghikophep")
                If IsDBNull(phatnghikophep) = True Then
                    Return "0"
                End If
                Return Convert.ToString(phatnghikophep)
            Case UCase("PhanTramBH")
                If IsDBNull(PhanTramBH) = True Then
                    Return "0"
                End If
                Return Convert.ToString(PhanTramBH)
            Case UCase("TienBH")
                If IsDBNull(TienBH) = True Then
                    Return "0"
                End If
                Return Convert.ToString(TienBH)
            Case UCase("ThucLanh")
                If IsDBNull(ThucLanh) = True Then
                    Return "0"
                End If
                Return Convert.ToString(ThucLanh)
            Case UCase("TrangThai")
                If IsDBNull(Trangthai) = True Then
                    Return "0"
                End If
                Return Convert.ToString(Trangthai)
            Case UCase("TienComTrua")
                If IsDBNull(TienComTrua) = True Then
                    Return "0"
                End If
                Return Convert.ToString(TienComTrua)
            Case UCase("SuatAnTrua")
                If IsDBNull(SuatAnTrua) = True Then
                    Return "0"
                End If
                Return Convert.ToString(SuatAnTrua)
            Case UCase("Phucap2")
                If IsDBNull(Phucap2) = True Then
                    Return "0"
                End If
                Return Convert.ToString(Phucap2)
            Case UCase("NgayGuiXe")
                If IsDBNull(NgayGuiXe) = True Then
                    Return "0"
                End If
                Return Convert.ToString(NgayGuiXe)
            Case UCase("TienGuiXe")
                If IsDBNull(TienGuiXe) = True Then
                    Return "0"
                End If
                Return Convert.ToString(TienGuiXe)
            Case UCase("TongTienXe")
                If IsDBNull(TongTienXe) = True Then
                    Return "0"
                End If
                Return Convert.ToString(TongTienXe)
            Case UCase("ChuyenCan")
                If IsDBNull(ChuyenCan) = True Then
                    Return "0"
                End If
                Return Convert.ToString(ChuyenCan)
           
            Case Else
                Return ""
        End Select
    End Function
    Public Function HoTro(ByVal tencolumn As String, ByVal value As String, Optional ByVal TT As String = "sua") As String
        Select Case UCase(Convert.ToString(tencolumn))
            Case UCase("Manv")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                Manv = CInt(value)
            Case UCase("Thang")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                Thang = CInt(value)
            Case UCase("Nam")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                Nam = CInt(value)
            Case UCase("LuongThang")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                LuongThang = Convert.ToDouble(value)
            Case UCase("Luongngay")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                Luongngay = Convert.ToDouble(value)
            Case UCase("Socong")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                Socong = Convert.ToDouble(value)
            Case UCase("Songay")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                Songay = CInt(value)
            Case UCase("Luongngaycong")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                Luongngaycong = Convert.ToDouble(value)
            Case UCase("Phucap1")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                Phucap1 = Convert.ToDouble(value)
            Case UCase("Tamung1")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                Tamung1 = Convert.ToDouble(value)
            Case UCase("SogioTc")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                SoGioTc = Convert.ToDouble(value)
            Case UCase("TienTCGio")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                TienTcGio = Convert.ToDouble(value)
            Case UCase("TienTangCa")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                TienTangca = Convert.ToDouble(value)
            Case UCase("TienAnTC")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                TienAnTC = Convert.ToDouble(value)
           
            Case UCase("NgayCN")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                NgayCN = CInt(value)
            Case UCase("LuongCN")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                LuongCN = Convert.ToDouble(value)
            Case UCase("Solanditre")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                Solanditre = CInt(value)
            Case UCase("Phatditre")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                Phatditre = Convert.ToDouble(value)
            Case UCase("Solannghikophep")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                Solannghikophep = CInt(value)
          
            Case UCase("phatnghikophep")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                phatnghikophep = Convert.ToDouble(value)
            Case UCase("PhamtramBH")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                PhanTramBH = Convert.ToDouble(value)
            Case UCase("TienBH")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                TienBH = Convert.ToDouble(value)
            Case UCase("ThucLanh")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                ThucLanh = Convert.ToDouble(value)
            Case UCase("TrangThai")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                Trangthai = CInt(value)
            Case UCase("TienComTrua")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                TienComTrua = Convert.ToDouble(value)
            Case UCase("SuatAnTrua")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                SuatAnTrua = Convert.ToDouble(value)
            Case UCase("Phucap2")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                Phucap2 = Convert.ToDouble(value)
            Case UCase("NgayGuiXe")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                NgayGuiXe = Convert.ToDouble(value)
            Case UCase("TienGuiXe")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                TienGuiXe = Convert.ToDouble(value)
            Case UCase("TongTienXe")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                TongTienXe = Convert.ToDouble(value)
            Case UCase("ChuyenCan")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                ChuyenCan = Convert.ToDouble(value)
            
            Case Else
                Return ""
        End Select
        Return ""
    End Function
End Class
