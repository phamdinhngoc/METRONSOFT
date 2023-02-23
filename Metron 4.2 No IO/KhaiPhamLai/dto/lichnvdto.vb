Public Class lichnvdto
    Inherits AbstractDto
#Region "Các Thuộc Tính"
    Private _ID As System.Int32
    Private _NVID As System.Int32
    Private _Sngay As System.DateTime
    Private _LichID As System.Int32
    Private _Engay As System.DateTime
    Private _Chay As System.Int32
    Private _Tangca As System.Boolean
    Private _TangCaS As System.Int32
    Private _GHTangC As System.Int32
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
    Public Property Sngay() As System.DateTime
        Get
            Return _Sngay
        End Get
        Set(ByVal value As System.DateTime)
            _Sngay = value
        End Set
    End Property
    Public Property LichID() As System.Int32
        Get
            Return _LichID
        End Get
        Set(ByVal value As System.Int32)
            _LichID = value
        End Set
    End Property
    Public Property Engay() As System.DateTime
        Get
            Return _Engay
        End Get
        Set(ByVal value As System.DateTime)
            _Engay = value
        End Set
    End Property
    Public Property Chay() As System.Int32
        Get
            Return _Chay
        End Get
        Set(ByVal value As System.Int32)
            _Chay = value
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
#End Region
    Public Sub New()
        ID = 0
        NVID = 0
        Sngay = #1/1/1900#
        LichID = 0
        Engay = #1/1/1900#
        Chay = 0
        Tangca = 0
        TangCaS = 0
        GHTangC = 0
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
            Case UCase("Sngay")
                If IsDBNull(Sngay) = True Then
                    Return "#1/1/1900#"
                End If
                Return Convert.ToString(Sngay)
            Case UCase("LichID")
                If IsDBNull(LichID) = True Then
                    Return "0"
                End If
                Return Convert.ToString(LichID)
            Case UCase("Engay")
                If IsDBNull(Engay) = True Then
                    Return "#1/1/1900#"
                End If
                Return Convert.ToString(Engay)
            Case UCase("Chay")
                If IsDBNull(Chay) = True Then
                    Return "0"
                End If
                Return Convert.ToString(Chay)
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
            Case UCase("Sngay")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsDate(value) = False Then
                    Return "Không phải ngày đề nghị nhập lại"
                End If
                Sngay = Convert.ToDateTime(value)
            Case UCase("LichID")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                LichID = Convert.ToInt32(value)
            Case UCase("Engay")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsDate(value) = False Then
                    Return "Không phải ngày đề nghị nhập lại"
                End If
                Engay = Convert.ToDateTime(value)
            Case UCase("Chay")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                Chay = Convert.ToInt32(value)
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
            Case Else
                Return ""
        End Select
        Return ""
    End Function
End Class
