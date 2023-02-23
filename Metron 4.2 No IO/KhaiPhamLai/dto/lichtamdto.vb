Public Class lichtamdto
    Inherits AbstractDto
#Region "Các Thuộc Tính"
    Private _ID As System.Int32
    Private _NVID As System.Int32
    Private _CaID As System.Int32
    Private _Tungay As System.DateTime
    Private _Denngay As System.DateTime
    Private _Tangca As System.Boolean
    Private _TangCaS As System.Int32
    Private _GHTangC As System.Int32
    Private _Dilam As System.Boolean
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
    Public Property NVID() As System.Int32
        Get
            Return _NVID
        End Get
        Set(ByVal value As System.Int32)
            _NVID = value
        End Set
    End Property
    Public Property CaID() As System.Int32
        Get
            Return _CaID
        End Get
        Set(ByVal value As System.Int32)
            _CaID = value
        End Set
    End Property
    Public Property Tungay() As System.DateTime
        Get
            Return _Tungay
        End Get
        Set(ByVal value As System.DateTime)
            _Tungay = value
        End Set
    End Property
    Public Property Denngay() As System.DateTime
        Get
            Return _Denngay
        End Get
        Set(ByVal value As System.DateTime)
            _Denngay = value
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
    Public Property TangCaS() As System.Int32
        Get
            Return _TangCaS
        End Get
        Set(ByVal value As System.Int32)
            _TangCaS = value
        End Set
    End Property
    Public Property GHTangC() As System.Int32
        Get
            Return _GHTangC
        End Get
        Set(ByVal value As System.Int32)
            _GHTangC = value
        End Set
    End Property
    Public Property Dilam() As System.Boolean
        Get
            Return _Dilam
        End Get
        Set(ByVal value As System.Boolean)
            _Dilam = value
        End Set
    End Property
#End Region
    Public Sub New()
        ID = 0
        NVID = 0
        CaID = 0
        Tungay = #1/1/1900#
        Denngay = #1/1/1900#
        Tangca = 0
        TangCaS = 0
        GHTangC = 0
        Dilam = 0
    End Sub
    Public Function HoTro(ByVal tencolumn As String) As String
        Select Case Convert.ToString(tencolumn)
            Case UCase("ID")
                If IsDBNull(ID) = True Then
                    Return "0"
                End If
                Return Convert.ToString(ID)
            Case UCase("NVID")
                If IsDBNull(NVID) = True Then
                    Return "0"
                End If
                Return Convert.ToString(NVID)
            Case UCase("CaID")
                If IsDBNull(CaID) = True Then
                    Return "0"
                End If
                Return Convert.ToString(CaID)
            Case UCase("Tungay")
                If IsDBNull(Tungay) = True Then
                    Return "#1/1/1900#"
                End If
                Return Convert.ToString(Tungay)
            Case UCase("Denngay")
                If IsDBNull(Denngay) = True Then
                    Return "#1/1/1900#"
                End If
                Return Convert.ToString(Denngay)
            Case UCase("Tangca")
                If IsDBNull(Tangca) = True Then
                    Return "0"
                End If
                Return Convert.ToString(Tangca)
            Case UCase("TangCaS")
                If IsDBNull(TangCaS) = True Then
                    Return "0"
                End If
                Return Convert.ToString(TangCaS)
            Case UCase("GHTangC")
                If IsDBNull(GHTangC) = True Then
                    Return "0"
                End If
                Return Convert.ToString(GHTangC)
            Case UCase("Dilam")
                If IsDBNull(Dilam) = True Then
                    Return "0"
                End If
                Return Convert.ToString(Dilam)
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
            Case UCase("NVID")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                NVID = Convert.ToInt32(value)
            Case UCase("CaID")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                CaID = Convert.ToInt32(value)
            Case UCase("Tungay")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsDate(value) = False Then
                    Return "Không phải ngày đề nghị nhập lại"
                End If
                Tungay = Convert.ToDateTime(value)
            Case UCase("Denngay")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsDate(value) = False Then
                    Return "Không phải ngày đề nghị nhập lại"
                End If
                Denngay = Convert.ToDateTime(value)
            Case UCase("Tangca")
                Tangca = value
            Case UCase("TangCaS")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                TangCaS = Convert.ToInt32(value)
            Case UCase("GHTangC")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                GHTangC = Convert.ToInt32(value)
            Case UCase("Dilam")
                Dilam = value
            Case Else
                Return ""
        End Select
        Return ""
    End Function
End Class
