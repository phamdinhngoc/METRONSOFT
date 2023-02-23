Public Class thamsodto
    Inherits AbstractDto
#Region "Các Thuộc Tính"
    Private _id As System.Int32
    Private _Tenthamso As System.String
    Private _Maso As System.Int32
    Private _Maso1 As System.Int32
    Private _Maso2 As System.Int32
    Private _Maso3 As System.Int32
    Private _GhiChu As System.String
#End Region
#Region "Khai báo các phương thức truy xuất"
    Public Property id() As System.Int32
        Get
            Return _id
        End Get
        Set(ByVal value As System.Int32)
            _id = value
        End Set
    End Property
    Public Property Tenthamso() As System.String
        Get
            Return _Tenthamso
        End Get
        Set(ByVal value As System.String)
            _Tenthamso = value
        End Set
    End Property
    Public Property Maso() As System.Int32
        Get
            Return _Maso
        End Get
        Set(ByVal value As System.Int32)
            _Maso = value
        End Set
    End Property
    Public Property Maso1() As System.Int32
        Get
            Return _Maso1
        End Get
        Set(ByVal value As System.Int32)
            _Maso1 = value
        End Set
    End Property
    Public Property Maso2() As System.Int32
        Get
            Return _Maso2
        End Get
        Set(ByVal value As System.Int32)
            _Maso2 = value
        End Set
    End Property
    Public Property Maso3() As System.Int32
        Get
            Return _Maso3
        End Get
        Set(ByVal value As System.Int32)
            _Maso3 = value
        End Set
    End Property
    Public Property GhiChu() As System.String
        Get
            Return _GhiChu
        End Get
        Set(ByVal value As System.String)
            _GhiChu = value
        End Set
    End Property
#End Region
    Public Sub New()
        id = 0
        Tenthamso = ""
        Maso = 0
        Maso1 = 0
        Maso2 = 0
        Maso3 = 0
        GhiChu = ""
    End Sub
    Public Function HoTro(ByVal tencolumn As String) As String
        Select Case UCase(Convert.ToString(tencolumn))
            Case UCase("id")
                If IsDBNull(id) = True Then
                    Return "0"
                End If
                Return Convert.ToString(id)
            Case UCase("Tenthamso")
                If IsDBNull(Tenthamso) = True Then
                    Return """"
                End If
                Return Convert.ToString(Tenthamso)
            Case UCase("Maso")
                If IsDBNull(Maso) = True Then
                    Return "0"
                End If
                Return Convert.ToString(Maso)
            Case UCase("Maso1")
                If IsDBNull(Maso1) = True Then
                    Return "0"
                End If
                Return Convert.ToString(Maso1)
            Case UCase("Maso2")
                If IsDBNull(Maso2) = True Then
                    Return "0"
                End If
                Return Convert.ToString(Maso2)
            Case UCase("Maso3")
                If IsDBNull(Maso3) = True Then
                    Return "0"
                End If
                Return Convert.ToString(Maso3)
            Case UCase("GhiChu")
                If IsDBNull(GhiChu) = True Then
                    Return """"
                End If
                Return Convert.ToString(GhiChu)
            Case Else
                Return ""
        End Select
    End Function
    Public Function HoTro(ByVal tencolumn As String, ByVal value As String, Optional ByVal TT As String = "sua") As String
        Select Case UCase(Convert.ToString(tencolumn))
            Case UCase("id")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                id = Convert.ToInt32(value)
            Case UCase("Tenthamso")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                Tenthamso = Convert.ToString(value)
            Case UCase("Maso")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                Maso = Convert.ToInt32(value)
            Case UCase("Maso1")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                Maso1 = Convert.ToInt32(value)
            Case UCase("Maso2")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                Maso2 = Convert.ToInt32(value)
            Case UCase("Maso3")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                Maso3 = Convert.ToInt32(value)
            Case UCase("GhiChu")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                GhiChu = Convert.ToString(value)
            Case Else
                Return ""
        End Select
        Return ""
    End Function
End Class
