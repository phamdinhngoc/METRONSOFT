Public Class Vaoradto
    Inherits AbstractDto
#Region "Các Thuộc Tính"
    Private _ID As System.Int32
    Private _MaNV As System.Int32
    Private _Thoigian As System.DateTime
    Private _Kieu As System.Int32
    Private _May As System.Int32
    Private _Ngay As System.DateTime
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
    Public Property Thoigian() As System.DateTime
        Get
            Return _Thoigian
        End Get
        Set(ByVal value As System.DateTime)
            _Thoigian = value
        End Set
    End Property
    Public Property Kieu() As System.Int32
        Get
            Return _Kieu
        End Get
        Set(ByVal value As System.Int32)
            _Kieu = value
        End Set
    End Property
    Public Property May() As System.Int32
        Get
            Return _May
        End Get
        Set(ByVal value As System.Int32)
            _May = value
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
#End Region
    Public Sub New()
        ID = 0
        MaNV = 0
        Thoigian = #1/1/1900#
        Kieu = 0
        May = 0
        Ngay = #1/1/1900#
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
            Case UCase("Thoigian")
                If IsDBNull(Thoigian) = True Then
                    Return "#1/1/1900#"
                End If
                Return Convert.ToString(Thoigian)
            Case UCase("Kieu")
                If IsDBNull(Kieu) = True Then
                    Return "0"
                End If
                Return Convert.ToString(Kieu)
            Case UCase("May")
                If IsDBNull(May) = True Then
                    Return "0"
                End If
                Return Convert.ToString(May)
            Case UCase("Ngay")
                If IsDBNull(Ngay) = True Then
                    Return "#1/1/1900#"
                End If
                Return Convert.ToString(Ngay)
            Case Else
                Return ""
        End Select
    End Function
    Public Function HoTro(ByVal tencolumn As String, ByVal value As String, Optional ByVal TT As String = "sua") As String
        Select Case Convert.ToString(tencolumn)
            Case UCase("ID")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dữ liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dữ liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                ID = Convert.ToInt32(value)
            Case UCase("MaNV")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dữ liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dữ liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                MaNV = Convert.ToInt32(value)
            Case UCase("Thoigian")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dữ liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dữ liệu"
                End If
                If IsDate(value) = False Then
                    Return "Không phải ngày đề nghị nhập lại"
                End If
                Thoigian = Convert.ToDateTime(value)
            Case UCase("Kieu")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dữ liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dữ liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                Kieu = Convert.ToInt32(value)
            Case UCase("May")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dữ liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dữ liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                May = Convert.ToInt32(value)
            Case UCase("Ngay")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dữ liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dữ liệu"
                End If
                If IsDate(value) = False Then
                    Return "Không phải ngày đề nghị nhập lại"
                End If
                Ngay = Convert.ToDateTime(value)
            Case Else
                Return ""
        End Select
        Return ""
    End Function
End Class
