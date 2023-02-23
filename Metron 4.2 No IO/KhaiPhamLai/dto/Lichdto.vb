Public Class Lichdto
    Inherits AbstractDto
#Region "Các Thuộc Tính"
    Private _ID As System.Int32
    Private _Chedo As System.String
    Private _Batdau As System.DateTime
    Private _SoCK As System.Int32
    Private _KieuCK As System.Int32
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
    Public Property Chedo() As System.String
        Get
            Return _Chedo
        End Get
        Set(ByVal value As System.String)
            _Chedo = value
        End Set
    End Property
    Public Property Batdau() As System.DateTime
        Get
            Return _Batdau
        End Get
        Set(ByVal value As System.DateTime)
            _Batdau = value
        End Set
    End Property
    Public Property SoCK() As System.Int32
        Get
            Return _SoCK
        End Get
        Set(ByVal value As System.Int32)
            _SoCK = value
        End Set
    End Property
    Public Property KieuCK() As System.Int32
        Get
            Return _KieuCK
        End Get
        Set(ByVal value As System.Int32)
            _KieuCK = value
        End Set
    End Property
#End Region
    Public Sub New()
        ID = 0
        Chedo = ""
        Batdau = #1/1/1900#
        SoCK = 0
        KieuCK = 0
    End Sub
    Public Function HoTro(ByVal tencolumn As String) As String
        Select Case Convert.ToString(tencolumn)
            Case UCase("ID")
                If IsDBNull(ID) = True Then
                    Return "0"
                End If
                Return Convert.ToString(ID)
            Case UCase("Chedo")
                If IsDBNull(Chedo) = True Then
                    Return """"
                End If
                Return Convert.ToString(Chedo)
            Case UCase("Batdau")
                If IsDBNull(Batdau) = True Then
                    Return "#1/1/1900#"
                End If
                Return Convert.ToString(Batdau)
            Case UCase("SoCK")
                If IsDBNull(SoCK) = True Then
                    Return "0"
                End If
                Return Convert.ToString(SoCK)
            Case UCase("KieuCK")
                If IsDBNull(KieuCK) = True Then
                    Return "0"
                End If
                Return Convert.ToString(KieuCK)
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
            Case UCase("Chedo")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                Chedo = Convert.ToString(value)
            Case UCase("Batdau")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsDate(value) = False Then
                    Return "Không phải ngày đề nghị nhập lại"
                End If
                Batdau = Convert.ToDateTime(value)
            Case UCase("SoCK")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                SoCK = Convert.ToInt32(value)
            Case UCase("KieuCK")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                KieuCK = Convert.ToInt32(value)
            Case Else
                Return ""
        End Select
        Return ""
    End Function
End Class
