Public Class cadto
    Inherits AbstractDto
#Region "Các Thuộc Tính"
    Private _ID As System.Int32
    Private _Tenca As System.String
    Private _batdau As System.DateTime
    Private _kethuc As System.DateTime
    Private _som As System.Int32
    Private _tre As System.Int32
    Private _tgvao1 As System.DateTime
    Private _tgvao2 As System.DateTime
    Private _tgra1 As System.DateTime
    Private _tgra2 As System.DateTime
    Private _ngaycong As System.Double
    Private _Sophut As System.Int32
    Private _mau As System.Int32
    Private _Cacon As System.Int32
#End Region
#Region "Khai báo các phương thức truy xuất"
    Public Property ID() As System.Int32
        Get
            Return _ID
        End Get
        Set(ByVal value As System.Int32)
            _ID = value
        End Set
    End Property
    Public Property Tenca() As System.String
        Get
            Return _Tenca
        End Get
        Set(ByVal value As System.String)
            _Tenca = value
        End Set
    End Property
    Public Property batdau() As System.DateTime
        Get
            Return _batdau
        End Get
        Set(ByVal value As System.DateTime)
            _batdau = value
        End Set
    End Property
    Public Property kethuc() As System.DateTime
        Get
            Return _kethuc
        End Get
        Set(ByVal value As System.DateTime)
            _kethuc = value
        End Set
    End Property
    Public Property som() As System.Int32
        Get
            Return _som
        End Get
        Set(ByVal value As System.Int32)
            _som = value
        End Set
    End Property
    Public Property tre() As System.Int32
        Get
            Return _tre
        End Get
        Set(ByVal value As System.Int32)
            _tre = value
        End Set
    End Property
    Public Property tgvao1() As System.DateTime
        Get
            Return _tgvao1
        End Get
        Set(ByVal value As System.DateTime)
            _tgvao1 = value
        End Set
    End Property
    Public Property tgvao2() As System.DateTime
        Get
            Return _tgvao2
        End Get
        Set(ByVal value As System.DateTime)
            _tgvao2 = value
        End Set
    End Property
    Public Property tgra1() As System.DateTime
        Get
            Return _tgra1
        End Get
        Set(ByVal value As System.DateTime)
            _tgra1 = value
        End Set
    End Property
    Public Property tgra2() As System.DateTime
        Get
            Return _tgra2
        End Get
        Set(ByVal value As System.DateTime)
            _tgra2 = value
        End Set
    End Property
    Public Property ngaycong() As System.Double
        Get
            Return _ngaycong
        End Get
        Set(ByVal value As System.Double)
            _ngaycong = value
        End Set
    End Property
    Public Property Sophut() As System.Int32
        Get
            Return _Sophut
        End Get
        Set(ByVal value As System.Int32)
            _Sophut = value
        End Set
    End Property
    Public Property mau() As System.Int32
        Get
            Return _mau
        End Get
        Set(ByVal value As System.Int32)
            _mau = value
        End Set
    End Property
    Public Property Cacon() As System.Int32
        Get
            Return _Cacon
        End Get
        Set(ByVal value As System.Int32)
            _Cacon = value
        End Set
    End Property
#End Region
    Public Sub New()
        ID = 0
        Tenca = ""
        batdau = #1/1/1900#
        kethuc = #1/1/1900#
        som = 0
        tre = 0
        tgvao1 = #1/1/1900#
        tgvao2 = #1/1/1900#
        tgra1 = #1/1/1900#
        tgra2 = #1/1/1900#
        ngaycong = 0
        Sophut = 0
        mau = 0
        Cacon = 0
    End Sub
    Public Function CaQuaNgay() As Boolean
        If batdau > kethuc Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function HoTro(ByVal tencolumn As String) As String
        Select Case Convert.ToString(tencolumn)
            Case UCase("ID")
                If IsDBNull(ID) = True Then
                    Return "0"
                End If
                Return Convert.ToString(ID)
            Case UCase("Tenca")
                If IsDBNull(Tenca) = True Then
                    Return """"
                End If
                Return Convert.ToString(Tenca)
            Case UCase("batdau")
                If IsDBNull(batdau) = True Then
                    Return "#1/1/1900#"
                End If
                Return Convert.ToString(batdau)
            Case UCase("kethuc")
                If IsDBNull(kethuc) = True Then
                    Return "#1/1/1900#"
                End If
                Return Convert.ToString(kethuc)
            Case UCase("som")
                If IsDBNull(som) = True Then
                    Return "0"
                End If
                Return Convert.ToString(som)
            Case UCase("tre")
                If IsDBNull(tre) = True Then
                    Return "0"
                End If
                Return Convert.ToString(tre)
            Case UCase("tgvao1")
                If IsDBNull(tgvao1) = True Then
                    Return "#1/1/1900#"
                End If
                Return Convert.ToString(tgvao1)
            Case UCase("tgvao2")
                If IsDBNull(tgvao2) = True Then
                    Return "#1/1/1900#"
                End If
                Return Convert.ToString(tgvao2)
            Case UCase("tgra1")
                If IsDBNull(tgra1) = True Then
                    Return "#1/1/1900#"
                End If
                Return Convert.ToString(tgra1)
            Case UCase("tgra2")
                If IsDBNull(tgra2) = True Then
                    Return "#1/1/1900#"
                End If
                Return Convert.ToString(tgra2)
            Case UCase("ngaycong")
                If IsDBNull(ngaycong) = True Then
                    Return "0"
                End If
                Return Convert.ToString(ngaycong)
            Case UCase("Sophut")
                If IsDBNull(Sophut) = True Then
                    Return "0"
                End If
                Return Convert.ToString(Sophut)
            Case UCase("mau")
                If IsDBNull(mau) = True Then
                    Return "0"
                End If
                Return Convert.ToString(mau)
            Case UCase("Cacon")
                If IsDBNull(Cacon) = True Then
                    Return "0"
                End If
                Return Convert.ToString(Cacon)
            Case Else
                Return ""
        End Select
    End Function
    Public Function HoTro(ByVal tencolumn As String, ByVal value As String, Optional ByVal TT As String = "sua") As String
        Select Case Convert.ToString(tencolumn)
            Case UCase("ID")
                If TT = "sua" Then
                    If IsDBNull(value) = True Then
                        Return "Bạn chưa nhập dử liệu"
                    End If
                    If value = "" Then
                        Return "Bạn chưa nhập dử liệu"
                    End If
                    If IsNumeric(value) = False Then
                        Return "Không phải số dề nghị nhập lại"
                    End If
                    ID = Convert.ToInt32(value)
                End If
            Case UCase("Tenca")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                Tenca = Convert.ToString(value)
            Case UCase("batdau")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsDate(value) = False Then
                    Return "Không phải ngày đề nghị nhập lại"
                End If
                batdau = Convert.ToDateTime(value)
            Case UCase("kethuc")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsDate(value) = False Then
                    Return "Không phải ngày đề nghị nhập lại"
                End If
                kethuc = Convert.ToDateTime(value)
            Case UCase("som")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                som = Convert.ToInt32(value)
            Case UCase("tre")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                tre = Convert.ToInt32(value)
            Case UCase("tgvao1")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsDate(value) = False Then
                    Return "Không phải ngày đề nghị nhập lại"
                End If
                tgvao1 = Convert.ToDateTime(value)
            Case UCase("tgvao2")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsDate(value) = False Then
                    Return "Không phải ngày đề nghị nhập lại"
                End If
                tgvao2 = Convert.ToDateTime(value)
            Case UCase("tgra1")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsDate(value) = False Then
                    Return "Không phải ngày đề nghị nhập lại"
                End If
                tgra1 = Convert.ToDateTime(value)
            Case UCase("tgra2")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsDate(value) = False Then
                    Return "Không phải ngày đề nghị nhập lại"
                End If
                tgra2 = Convert.ToDateTime(value)
            Case UCase("ngaycong")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                ngaycong = Convert.ToInt32(value)
            Case UCase("Sophut")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                Sophut = Convert.ToInt32(value)
            Case UCase("mau")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                mau = Convert.ToInt32(value)
            Case UCase("Cacon")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                Cacon = Convert.ToInt32(value)
            Case Else
                Return ""
        End Select
        Return ""
    End Function
    Public Function HoTro(ByVal index As Integer, ByVal value As String) As String
        Select Case index
            Case 0
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                ID = Convert.ToInt32(value)        
            Case 1
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                Tenca = Convert.ToString(value)
            Case 2
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsDate(value) = False Then
                    Return "Không phải ngày đề nghị nhập lại"
                End If
                batdau = Convert.ToDateTime(value)
            Case 3
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsDate(value) = False Then
                    Return "Không phải ngày đề nghị nhập lại"
                End If
                kethuc = Convert.ToDateTime(value)
            Case 4
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                som = Convert.ToInt32(value)
            Case 5
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                tre = Convert.ToInt32(value)
            Case 6
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsDate(value) = False Then
                    Return "Không phải ngày đề nghị nhập lại"
                End If
                tgvao1 = Convert.ToDateTime(value)
            Case 7
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsDate(value) = False Then
                    Return "Không phải ngày đề nghị nhập lại"
                End If
                tgvao2 = Convert.ToDateTime(value)
            Case 8
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsDate(value) = False Then
                    Return "Không phải ngày đề nghị nhập lại"
                End If
                tgra1 = Convert.ToDateTime(value)
            Case 9
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsDate(value) = False Then
                    Return "Không phải ngày đề nghị nhập lại"
                End If
                tgra2 = Convert.ToDateTime(value)
            Case 10
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                ngaycong = Convert.ToDouble(value)
            Case 11
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                Sophut = Convert.ToInt32(value)
            Case 12
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                mau = Convert.ToInt32(value)
            Case 13
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                Cacon = Convert.ToInt32(value)
            Case Else
                Return ""
        End Select
        Return ""
    End Function

End Class
