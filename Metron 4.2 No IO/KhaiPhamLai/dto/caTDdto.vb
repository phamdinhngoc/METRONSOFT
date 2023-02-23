Public Class caTDdto
    Inherits AbstractDto
#Region "Các Thuộc Tính"
    Private _ID As System.Int32
    Private _MaNV As System.Int32
    Private _Caid As System.Int32
    Private _TuNgay As System.DateTime
    Private _DenNgay As System.DateTime
    Private _Tangca As System.Boolean
    Private _TangcaS As System.Int32
    Private _GhTangca As System.Int32
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
    Public Property MaNV() As System.Int32
        Get
            Return _MaNV
        End Get
        Set(ByVal value As System.Int32)
            _MaNV = value
        End Set
    End Property
    Public Property Caid() As System.Int32
        Get
            Return _Caid
        End Get
        Set(ByVal value As System.Int32)
            _Caid = value
        End Set
    End Property
    Public Property TuNgay() As System.DateTime
        Get
            Return _TuNgay
        End Get
        Set(ByVal value As System.DateTime)
            _TuNgay = value
        End Set
    End Property
    Public Property DenNgay() As System.DateTime
        Get
            Return _DenNgay
        End Get
        Set(ByVal value As System.DateTime)
            _DenNgay = value
        End Set
    End Property
    Public Property Tangca() As System.Boolean
        Get
            Return _Tangca
        End Get
        Set(ByVal value As System.Boolean)
            _Tangca = value
        End Set
    End Property
    Public Property TangcaS() As System.Int32
        Get
            Return _TangcaS
        End Get
        Set(ByVal value As System.Int32)
            _TangcaS = value
        End Set
    End Property
    Public Property GhTangca() As System.Int32
        Get
            Return _GhTangca
        End Get
        Set(ByVal value As System.Int32)
            _GhTangca = value
        End Set
    End Property
#End Region
    Public Sub New()
        ID = 0
        MaNV = 0
        Caid = 0
        TuNgay = #1/1/1900#
        DenNgay = #1/1/1900#
        Tangca = 0
        TangcaS = 0
        GhTangca = 0
    End Sub
    Public Function HoTro(ByVal tencolumn As String) As String
        Select Case Convert.ToString(tencolumn)
            Case UCase("ID")
                If IsDBNull(ID) = True Then
                    Return "0"
                End If
                Return Convert.ToString(ID)
            Case UCase("MaNV")
                If IsDBNull(MaNV) = True Then
                    Return "0"
                End If
                Return Convert.ToString(MaNV)
            Case UCase("Caid")
                If IsDBNull(Caid) = True Then
                    Return "0"
                End If
                Return Convert.ToString(Caid)
            Case UCase("TuNgay")
                If IsDBNull(TuNgay) = True Then
                    Return "#1/1/1900#"
                End If
                Return Convert.ToString(TuNgay)
            Case UCase("DenNgay")
                If IsDBNull(DenNgay) = True Then
                    Return "#1/1/1900#"
                End If
                Return Convert.ToString(DenNgay)
            Case UCase("Tangca")
                If IsDBNull(Tangca) = True Then
                    Return "0"
                End If
                Return Convert.ToString(Tangca)
            Case UCase("TangcaS")
                If IsDBNull(TangcaS) = True Then
                    Return "0"
                End If
                Return Convert.ToString(TangcaS)
            Case UCase("GhTangca")
                If IsDBNull(GhTangca) = True Then
                    Return "0"
                End If
                Return Convert.ToString(GhTangca)
            Case Else
                Return ""
        End Select
    End Function
    Public Function HoTro(ByVal tencolumn As String, ByVal value As String, Optional ByVal TT As String = "sua") As String
        Select Case Convert.ToString(tencolumn)
            Case UCase("ID")
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
            Case UCase("Caid")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                Caid = Convert.ToInt32(value)
            Case UCase("TuNgay")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsDate(value) = False Then
                    Return "Không phải ngày đề nghị nhập lại"
                End If
                TuNgay = Convert.ToDateTime(value)
            Case UCase("DenNgay")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsDate(value) = False Then
                    Return "Không phải ngày đề nghị nhập lại"
                End If
                DenNgay = Convert.ToDateTime(value)
            Case UCase("Tangca")
                Tangca = value
            Case UCase("TangcaS")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                TangcaS = Convert.ToInt32(value)
            Case UCase("GhTangca")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                GhTangca = Convert.ToInt32(value)
            Case Else
                Return ""
        End Select
        Return ""
    End Function
End Class
