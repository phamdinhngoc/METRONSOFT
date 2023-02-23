Public Class Maydto
    Inherits AbstractDto
#Region "Các Thuộc Tính"
    Private _ID As System.Int32
    Private _MaySO As System.Int32
    Private _Loaimay As System.Int32
    Private _Pass As System.String
    Private _Tenmay As System.String
    Private _Vtri As System.String
    Private _Kieu As System.Int32
    Private _IP As System.String
    Private _Cong As System.Int32
    Private _Rate As System.Int32
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
    Public Property MaySO() As System.Int32
        Get
            Return _MaySO
        End Get
        Set(ByVal value As System.Int32)
            _MaySO = value
        End Set
    End Property
    Public Property Loaimay() As System.Int32
        Get
            Return _Loaimay
        End Get
        Set(ByVal value As System.Int32)
            _Loaimay = value
        End Set
    End Property
    Public Property Pass() As System.String
        Get
            Return _Pass
        End Get
        Set(ByVal value As System.String)
            _Pass = value
        End Set
    End Property
    Public Property Tenmay() As System.String
        Get
            Return _Tenmay
        End Get
        Set(ByVal value As System.String)
            _Tenmay = value
        End Set
    End Property
    Public Property Vtri() As System.String
        Get
            Return _Vtri
        End Get
        Set(ByVal value As System.String)
            _Vtri = value
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
    Public Property IP() As System.String
        Get
            Return _IP
        End Get
        Set(ByVal value As System.String)
            _IP = value
        End Set
    End Property
    Public Property Cong() As System.Int32
        Get
            Return _Cong
        End Get
        Set(ByVal value As System.Int32)
            _Cong = value
        End Set
    End Property
    Public Property Rate() As System.Int32
        Get
            Return _Rate
        End Get
        Set(ByVal value As System.Int32)
            _Rate = value
        End Set
    End Property
#End Region
    Public Sub New()
        ID = 0
        MaySO = 0
        Loaimay = 0
        Pass = ""
        Tenmay = ""
        Vtri = ""
        Kieu = 0
        IP = ""
        Cong = 0
        Rate = 0
    End Sub
    Public Function HoTro(ByVal tencolumn As String) As String
        Select Case Convert.ToString(tencolumn)
            Case UCase("ID")
                If IsDBNull(ID) = True Then
                    Return "0"
                End If
                Return Convert.ToString(ID)
            Case UCase("MaySO")
                If IsDBNull(MaySO) = True Then
                    Return "0"
                End If
                Return Convert.ToString(MaySO)
            Case UCase("Loaimay")
                If IsDBNull(Loaimay) = True Then
                    Return "0"
                End If
                Return Convert.ToString(Loaimay)
            Case UCase("Pass")
                If IsDBNull(Pass) = True Then
                    Return """"
                End If
                Return Convert.ToString(Pass)
            Case UCase("Tenmay")
                If IsDBNull(Tenmay) = True Then
                    Return """"
                End If
                Return Convert.ToString(Tenmay)
            Case UCase("Vtri")
                If IsDBNull(Vtri) = True Then
                    Return """"
                End If
                Return Convert.ToString(Vtri)
            Case UCase("Kieu")
                If IsDBNull(Kieu) = True Then
                    Return "0"
                End If
                Return Convert.ToString(Kieu)
            Case UCase("IP")
                If IsDBNull(IP) = True Then
                    Return """"
                End If
                Return Convert.ToString(IP)
            Case UCase("Cong")
                If IsDBNull(Cong) = True Then
                    Return "0"
                End If
                Return Convert.ToString(Cong)
            Case UCase("Rate")
                If IsDBNull(Rate) = True Then
                    Return "0"
                End If
                Return Convert.ToString(Rate)
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
            Case UCase("MaySO")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                MaySO = Convert.ToInt32(value)
            Case UCase("Loaimay")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                Loaimay = Convert.ToInt32(value)
            Case UCase("Pass")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                Pass = Convert.ToString(value)
            Case UCase("Tenmay")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                Tenmay = Convert.ToString(value)
            Case UCase("Vtri")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                Vtri = Convert.ToString(value)
            Case UCase("Kieu")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                Kieu = Convert.ToInt32(value)
            Case UCase("IP")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                IP = Convert.ToString(value)
            Case UCase("Cong")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                Cong = Convert.ToInt32(value)
            Case UCase("Rate")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                Rate = Convert.ToInt32(value)
            Case Else
                Return ""
        End Select
        Return ""
    End Function
End Class
