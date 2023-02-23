 Public Class Quyendto
 Inherits AbstractDto 
 #Region "Các Thuộc Tính" 
 Private _MaQuyen as System.Int32
 Private _TenQuyen as System.String
 #End Region 
 #Region "Khai báo các phương thức truy xuất" 
 Public Property MaQuyen() as System.Int32
 Get
 Return _MaQuyen
 End Get
 Set(ByVal value As System.Int32)
 _MaQuyen=Value
 End Set
 End Property
 Public Property TenQuyen() as System.String
 Get
 Return _TenQuyen
 End Get
 Set(ByVal value As System.String)
 _TenQuyen=Value
 End Set
 End Property
 #End Region 
 Public Sub New()
MaQuyen = 0
TenQuyen = "
 End Sub
 public Function HoTro(ByVal tencolumn As String) As String
 Select Case Convert.ToString(tencolumn)
 Case Ucase("MaQuyen")
 if IsDBNull(MaQuyen)=true then 
 return "0"
 end if
 Return Convert.ToString(MaQuyen)
 Case Ucase("TenQuyen")
 if IsDBNull(TenQuyen)=true then 
 return """
 end if
 Return Convert.ToString(TenQuyen)
 Case Else
 Return ""
 End Select
 End Function
 public function HoTro(ByVal tencolumn As String,Byval value as string,Optional ByVal TT As String = "sua") as string 
 Select Case Convert.ToString(tencolumn)
 Case UCase("MaQuyen")
 If TT = "sua" Then
 If IsDBNull(value) = true Then
 return "Bạn chưa nhập dử liệu"
 End if
 If value = ""  Then
 return "Bạn chưa nhập dử liệu"
 End if
 If IsNumeric(value) = False Then
 return "Không phải số dề nghị nhập lại"
end if
MaQuyen=Convert.ToInt32(value)
End if
 Case UCase("TenQuyen")
 If IsDBNull(value) = true Then
 return "Bạn chưa nhập dử liệu"
 End if
 If value = ""  Then
 return "Bạn chưa nhập dử liệu"
 End if
TenQuyen=Convert.ToString(value)
 Case Else
 return ""
 End Select
 return ""
 End function
 End class
