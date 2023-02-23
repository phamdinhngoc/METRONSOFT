 Public Class Ngayledto
 Inherits AbstractDto 
 #Region "Các Thuộc Tính" 
 Private _Ngay as System.DateTime
 Private _ChuThich as System.String
 #End Region 
 #Region "Khai báo các phương thức truy xuất" 
 Public Property Ngay() as System.DateTime
 Get
 Return _Ngay
 End Get
 Set(ByVal value As System.DateTime)
 _Ngay=Value
 End Set
 End Property
 Public Property ChuThich() as System.String
 Get
 Return _ChuThich
 End Get
 Set(ByVal value As System.String)
 _ChuThich=Value
 End Set
 End Property
 #End Region 
 Public Sub New()
Ngay = #1/1/1900#
ChuThich = "
 End Sub
 public Function HoTro(ByVal tencolumn As String) As String
 Select Case Convert.ToString(tencolumn)
 Case Ucase("Ngay")
 if IsDBNull(Ngay)=true then 
 return "#1/1/1900#"
 end if
 Return Convert.ToString(Ngay)
 Case Ucase("ChuThich")
 if IsDBNull(ChuThich)=true then 
 return """
 end if
 Return Convert.ToString(ChuThich)
 Case Else
 Return ""
 End Select
 End Function
 public function HoTro(ByVal tencolumn As String,Byval value as string,Optional ByVal TT As String = "sua") as string 
 Select Case Convert.ToString(tencolumn)
 Case UCase("Ngay")
 If IsDBNull(value) = true Then
 return "Bạn chưa nhập dử liệu"
 End if
 If value = ""  Then
 return "Bạn chưa nhập dử liệu"
 End if
 If IsDate(value) = False Then
 return "Không phải ngày đề nghị nhập lại"
end if
Ngay=Convert.ToDateTime(value)
 Case UCase("ChuThich")
 If IsDBNull(value) = true Then
 return "Bạn chưa nhập dử liệu"
 End if
 If value = ""  Then
 return "Bạn chưa nhập dử liệu"
 End if
ChuThich=Convert.ToString(value)
 Case Else
 return ""
 End Select
 return ""
 End function
 End class
