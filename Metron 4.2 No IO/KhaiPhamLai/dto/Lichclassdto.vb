Public Class Lichclassdto
    Inherits AbstractDto
#Region "Các Thuộc Tính"
    Private _ID As System.Int32
    Private _LichID As System.Int32
    Private _SThu As System.Int32
    Private _EThu As System.Int32
    Private _caid As System.Int32
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
    Public Property LichID() As System.Int32
        Get
            Return _LichID
        End Get
        Set(ByVal value As System.Int32)
            _LichID = value
        End Set
    End Property
    Public Property SThu() As System.Int32
        Get
            Return _SThu
        End Get
        Set(ByVal value As System.Int32)
            _SThu = value
        End Set
    End Property
    Public Property EThu() As System.Int32
        Get
            Return _EThu
        End Get
        Set(ByVal value As System.Int32)
            _EThu = value
        End Set
    End Property
    Public Property caid() As System.Int32
        Get
            Return _caid
        End Get
        Set(ByVal value As System.Int32)
            _caid = value
        End Set
    End Property
#End Region
    Public Sub New()
        ID = 0
        LichID = 0
        SThu = 0
        EThu = 0
        caid = 0
    End Sub
    Public Function HoTro(ByVal tencolumn As String) As String
        Select Case Convert.ToString(tencolumn)
            Case UCase("ID")
                If IsDBNull(ID) = True Then
                    Return "0"
                End If
                Return Convert.ToString(ID)
            Case UCase("LichID")
                If IsDBNull(LichID) = True Then
                    Return "0"
                End If
                Return Convert.ToString(LichID)
            Case UCase("SThu")
                If IsDBNull(SThu) = True Then
                    Return "0"
                End If
                Return Convert.ToString(SThu)
            Case UCase("EThu")
                If IsDBNull(EThu) = True Then
                    Return "0"
                End If
                Return Convert.ToString(EThu)
            Case UCase("caid")
                If IsDBNull(caid) = True Then
                    Return "0"
                End If
                Return Convert.ToString(caid)
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
            Case UCase("SThu")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                SThu = Convert.ToInt32(value)
            Case UCase("EThu")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                EThu = Convert.ToInt32(value)
            Case UCase("caid")
                If IsDBNull(value) = True Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If value = "" Then
                    Return "Bạn chưa nhập dử liệu"
                End If
                If IsNumeric(value) = False Then
                    Return "Không phải số dề nghị nhập lại"
                End If
                caid = Convert.ToInt32(value)
            Case Else
                Return ""
        End Select
        Return ""
    End Function
End Class
