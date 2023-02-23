Public Class Phucapluongdto
    Inherits AbstractDto
#Region "Các Thuộc Tính"
    Private _ID As System.Int32
    Private _TienComTrua As System.Double
    Private _TienXe As System.Double
    Private _TienAnTC1 As System.Double
    Private _TienAnTC2 As System.Double
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
   
    Public Property TienComTrua() As System.Double
        Get
            Return _TienComTrua
        End Get
        Set(ByVal value As System.Double)
            _TienComTrua = value
        End Set
    End Property
    Public Property TienXe() As System.Double
        Get
            Return _TienXe
        End Get
        Set(ByVal value As System.Double)
            _TienXe = value
        End Set
    End Property
    Public Property TienAnTC1() As System.Double
        Get
            Return _TienAnTC1
        End Get
        Set(ByVal value As System.Double)
            _TienAnTC1 = value
        End Set
    End Property
    Public Property TienAnTC2() As System.Double
        Get
            Return _TienAnTC2
        End Get
        Set(ByVal value As System.Double)
            _TienAnTC2 = value
        End Set
    End Property
    
#End Region
    Public Sub New()
        ID = 0

        TienComTrua = 0
        TienXe = 0
        TienAnTC1 = 0
        TienAnTC2 = 0

    End Sub
    Public Function HoTro(ByVal tencolumn As String) As String
        Select Case UCase(Convert.ToString(tencolumn))
            Case UCase("ID")
                If IsDBNull(ID) = True Then
                    Return "0"
                End If
                Return Convert.ToString(ID)
            
            Case UCase("TienComTrua")
                If IsDBNull(TienComTrua) = True Then
                    Return "0"
                End If
                Return Convert.ToString(TienComTrua)
            Case UCase("TienXe")
                If IsDBNull(TienXe) = True Then
                    Return "0"
                End If
                Return Convert.ToString(TienXe)
            Case UCase("TienAnTC1")
                If IsDBNull(TienAnTC1) = True Then
                    Return "0"
                End If
                Return Convert.ToString(TienAnTC1)
            Case UCase("TienAnTC2")
                If IsDBNull(TienAnTC2) = True Then
                    Return "0"
                End If
                Return Convert.ToString(TienAnTC2)
            Case Else
                Return ""
        End Select
    End Function
    Public Function HoTro(ByVal tencolumn As String, ByVal value As String, Optional ByVal TT As String = "sua") As String
        Select Case UCase(Convert.ToString(tencolumn))
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
                ID = CInt(value)
            
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
                TienComTrua = CInt(value)
            Case UCase("TienXe")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                TienXe = Convert.ToDouble(value)
            Case UCase("TienAnTC1")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                TienAnTC1 = Convert.ToDouble(value)
            Case UCase("TienAnTC2")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                TienAnTC2 = Convert.ToDouble(value)
            
            Case Else
                Return ""
        End Select
        Return ""
    End Function
End Class
