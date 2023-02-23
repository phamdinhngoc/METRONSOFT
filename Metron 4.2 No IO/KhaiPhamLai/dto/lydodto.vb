 Public Class lydodto
 Inherits AbstractDto 
 #Region "Các Thuộc Tính" 
 Private _IDLD as System.Int32
 Private _Lydo as System.String
 Private _NgayQD as System.Int32
 Private _SoCong as System.Int32
 #End Region 
 #Region "Khai báo các phương thức truy xuất" 
 Public Property IDLD() as System.Int32
 Get
 Return _IDLD
 End Get
 Set(ByVal value As System.Int32)
 _IDLD=Value
 End Set
 End Property
 Public Property Lydo() as System.String
 Get
 Return _Lydo
 End Get
 Set(ByVal value As System.String)
 _Lydo=Value
 End Set
 End Property
 Public Property NgayQD() as System.Int32
 Get
 Return _NgayQD
 End Get
 Set(ByVal value As System.Int32)
 _NgayQD=Value
 End Set
 End Property
 Public Property SoCong() as System.Int32
 Get
 Return _SoCong
 End Get
 Set(ByVal value As System.Int32)
 _SoCong=Value
 End Set
 End Property
 #End Region 
 Public Sub New()
IDLD = 0
Lydo = "
NgayQD = 0
SoCong = 0
 End Sub
 public Function HoTro(ByVal tencolumn As String) As String
 Select Case Convert.ToString(tencolumn)
 Case Ucase("IDLD")
 if IsDBNull(IDLD)=true then 
 return "0"
 end if
 Return Convert.ToString(IDLD)
 Case Ucase("Lydo")
 if IsDBNull(Lydo)=true then 
 return """
 end if
 Return Convert.ToString(Lydo)
 Case Ucase("NgayQD")
 if IsDBNull(NgayQD)=true then 
 return "0"
 end if
 Return Convert.ToString(NgayQD)
 Case Ucase("SoCong")
 if IsDBNull(SoCong)=true then 
 return "0"
 end if
 Return Convert.ToString(SoCong)
 Case Else
 Return ""
 End Select
 End Function
 public function HoTro(ByVal tencolumn As String,Byval value as string,Optional ByVal TT As String = "sua") as string 
 Select Case Convert.ToString(tencolumn)
 Case UCase("IDLD")
 If IsDBNull(value) = true Then
 return "Bạn chưa nhập dử liệu"
 End if
 If value = ""  Then
 return "Bạn chưa nhập dử liệu"
 End if
 If IsNumeric(value) = False Then
 return "Không phải số dề nghị nhập lại"
end if
IDLD=Convert.ToInt32(value)
 Case UCase("Lydo")
 If IsDBNull(value) = true Then
 return "Bạn chưa nhập dử liệu"
 End if
 If value = ""  Then
 return "Bạn chưa nhập dử liệu"
 End if
Lydo=Convert.ToString(value)
 Case UCase("NgayQD")
 If IsDBNull(value) = true Then
 return "Bạn chưa nhập dử liệu"
 End if
 If value = ""  Then
 return "Bạn chưa nhập dử liệu"
 End if
 If IsNumeric(value) = False Then
 return "Không phải số dề nghị nhập lại"
end if
NgayQD=Convert.ToInt32(value)
 Case UCase("SoCong")
 If IsDBNull(value) = true Then
 return "Bạn chưa nhập dử liệu"
 End if
 If value = ""  Then
 return "Bạn chưa nhập dử liệu"
 End if
 If IsNumeric(value) = False Then
 return "Không phải số dề nghị nhập lại"
end if
SoCong=Convert.ToInt32(value)
 Case Else
 return ""
 End Select
 return ""
 End function
 End class
