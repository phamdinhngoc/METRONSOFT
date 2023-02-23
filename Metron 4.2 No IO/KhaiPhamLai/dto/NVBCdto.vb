 Public Class NVBCdto
 Inherits AbstractDto 
 #Region "Các Thuộc Tính" 
 Private _MaCC as System.Int32
 Private _MaNV as System.String
 Private _TenNV as System.String
 Private _Chucvu as System.String
 Private _Bophan as System.String
 #End Region 
 #Region "Khai báo các phương thức truy xuất" 
 Public Property MaCC() as System.Int32
 Get
 Return _MaCC
 End Get
 Set(ByVal value As System.Int32)
 _MaCC=Value
 End Set
 End Property
 Public Property MaNV() as System.String
 Get
 Return _MaNV
 End Get
 Set(ByVal value As System.String)
 _MaNV=Value
 End Set
 End Property
 Public Property TenNV() as System.String
 Get
 Return _TenNV
 End Get
 Set(ByVal value As System.String)
 _TenNV=Value
 End Set
 End Property
 Public Property Chucvu() as System.String
 Get
 Return _Chucvu
 End Get
 Set(ByVal value As System.String)
 _Chucvu=Value
 End Set
 End Property
 Public Property Bophan() as System.String
 Get
 Return _Bophan
 End Get
 Set(ByVal value As System.String)
 _Bophan=Value
 End Set
 End Property
 #End Region 
 Public Sub New()
MaCC = 0
MaNV = "
TenNV = "
Chucvu = "
Bophan = "
 End Sub
 public Function HoTro(ByVal tencolumn As String) As String
 Select Case Convert.ToString(tencolumn)
 Case Ucase("MaCC")
 if IsDBNull(MaCC)=true then 
 return "0"
 end if
 Return Convert.ToString(MaCC)
 Case Ucase("MaNV")
 if IsDBNull(MaNV)=true then 
 return """
 end if
 Return Convert.ToString(MaNV)
 Case Ucase("TenNV")
 if IsDBNull(TenNV)=true then 
 return """
 end if
 Return Convert.ToString(TenNV)
 Case Ucase("Chucvu")
 if IsDBNull(Chucvu)=true then 
 return """
 end if
 Return Convert.ToString(Chucvu)
 Case Ucase("Bophan")
 if IsDBNull(Bophan)=true then 
 return """
 end if
 Return Convert.ToString(Bophan)
 Case Else
 Return ""
 End Select
 End Function
 public function HoTro(ByVal tencolumn As String,Byval value as string,Optional ByVal TT As String = "sua") as string 
 Select Case Convert.ToString(tencolumn)
 Case UCase("MaCC")
 If IsDBNull(value) = true Then
 return "Bạn chưa nhập dử liệu"
 End if
 If value = ""  Then
 return "Bạn chưa nhập dử liệu"
 End if
 If IsNumeric(value) = False Then
 return "Không phải số dề nghị nhập lại"
end if
MaCC=Convert.ToInt32(value)
 Case UCase("MaNV")
 If IsDBNull(value) = true Then
 return "Bạn chưa nhập dử liệu"
 End if
 If value = ""  Then
 return "Bạn chưa nhập dử liệu"
 End if
MaNV=Convert.ToString(value)
 Case UCase("TenNV")
 If IsDBNull(value) = true Then
 return "Bạn chưa nhập dử liệu"
 End if
 If value = ""  Then
 return "Bạn chưa nhập dử liệu"
 End if
TenNV=Convert.ToString(value)
 Case UCase("Chucvu")
 If IsDBNull(value) = true Then
 return "Bạn chưa nhập dử liệu"
 End if
 If value = ""  Then
 return "Bạn chưa nhập dử liệu"
 End if
Chucvu=Convert.ToString(value)
 Case UCase("Bophan")
 If IsDBNull(value) = true Then
 return "Bạn chưa nhập dử liệu"
 End if
 If value = ""  Then
 return "Bạn chưa nhập dử liệu"
 End if
Bophan=Convert.ToString(value)
 Case Else
 return ""
 End Select
 return ""
 End function
 End class
