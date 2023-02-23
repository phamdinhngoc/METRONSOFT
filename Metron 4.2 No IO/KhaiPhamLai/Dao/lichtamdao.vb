 Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class lichtamDao
    Inherits AbstractDao
#Region "New"
    Public Sub New()
        MyBase.New()
    End Sub
    Public Sub New(ByVal connection As OleDb.OleDbConnection)
        If Ket_noi.State = ConnectionState.Closed Then
            Ket_noi = connection
        End If
    End Sub
    Public Sub New(ByVal connectionString As String)
        If Ket_noi.State = ConnectionState.Closed Then
            Ket_noi.ConnectionString = connectionString
        End If
    End Sub
    Public Sub New(ByVal connection As KetNoiDto, ByVal MSsql As Boolean)
        MyBase.New("lichtam", connection, MSsql)
    End Sub
    Public Sub New(ByVal ma As Integer, ByVal connection As KetNoiDto, ByVal MSsql As Boolean)
        MyBase.New("lichtam", "select * from lichtam where ID=" & ma & "", connection, MSsql)
    End Sub
#End Region

    Public Sub LayLichTamTheoNgay(ByVal MaNV As Integer, ByVal TuNgay As Date, ByVal DenNGay As Date)
        Dim Str As String = "SELECT ca.ID, ca.TenCa, LichTam.Tungay, LichTam.Denngay, LichTam.Tangca, LichTam.TangcaS, LichTam.GhTangC FROM LichTam, Ca WHERE (LichTam.CaID = Ca.ID)  AND (NVID = PMaNV) AND (TuNgay>=PTuNgay) AND (TuNgay<=PDenNgay)"
        If Ket_noi.State = ConnectionState.Closed Then Ket_noi.Open()
        Dim cmd As New OleDb.OleDbCommand(Str, Ket_noi)

        cmd.Parameters.Add("PMaNV", OleDbType.Integer).Value = MaNV
        'MsgBox(cmd.Parameters("PMaNV").Value)
        cmd.Parameters.Add("PTuNgay", OleDbType.Date).Value = TuNgay.Date
        'MsgBox(cmd.Parameters("PTuNgay").Value)
        cmd.Parameters.Add("PDenNgay", OleDbType.Date).Value = DenNGay.Date
        'MsgBox(cmd.Parameters("PDenNgay").Value)

        mBo_doc_ghi = New OleDbDataAdapter(cmd)
        mBo_doc_ghi.FillSchema(Me, SchemaType.Mapped)
        mBo_doc_ghi.Fill(Me)

    End Sub


    Public Sub LayLichTamTheoThoiGian(ByVal MaNV As Integer, ByVal TuNGay As Date, ByVal DenNGay As Date)
        Dim Str As String = "SELECT ca.ID, ca.TenCa, ca.batdau, ca.kethuc,ca.tgvao1, ca.tgvao2, ca.som, ca.tre, ca.sophut, ca.NgayCong, ca.mau, LichTam.NVID, LichTam.CAID, LichTam.Tungay, LichTam.Denngay, LichTam.Tangca, LichTam.TangcaS, LichTam.GhTangC, LichTam.DiLam FROM LichTam, Ca WHERE (LichTam.CaID = Ca.ID)  AND (NVID = PMaNV) AND (DenNgay >= PTuNgay) AND (TuNgay<=PDenNgay) ORDER BY TuNgay"
        If Ket_noi.State = ConnectionState.Closed Then Ket_noi.Open()
        Dim cmd As New OleDb.OleDbCommand(Str, Ket_noi)

        cmd.Parameters.Add("PMaNV", OleDbType.Integer).Value = MaNV
        'MsgBox(cmd.Parameters("PMaNV").Value)
        cmd.Parameters.Add("PTuNgay", OleDbType.Date).Value = TuNgay.Date
        'MsgBox(cmd.Parameters("PTuNgay").Value)
        cmd.Parameters.Add("PDenNgay", OleDbType.Date).Value = DenNGay.Date
        'MsgBox(cmd.Parameters("PDenNgay").Value)

        mBo_doc_ghi = New OleDbDataAdapter(cmd)
        mBo_doc_ghi.FillSchema(Me, SchemaType.Mapped)
        mBo_doc_ghi.Fill(Me)

    End Sub


    Public Sub Them(ByVal Dto As lichtamdto, ByVal MSsql As Boolean)
        Dim strsql As String
        Dim BatTat As Boolean = False
        strsql = "Insert into lichtam(NVID,CaID,Tungay,Denngay,Tangca,TangCaS,GHTangC,Dilam) values (?,?,?,?,?,?,?,?)"
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            Dim cmd As New OleDbCommand(strsql, Ket_noi)
            'cmd.Parameters.Add("@ID", OleDbType.Integer)
            cmd.Parameters.Add("@NVID", OleDbType.Integer)
            cmd.Parameters.Add("@CaID", OleDbType.Integer)
            cmd.Parameters.Add("@Tungay", OleDbType.Date)
            cmd.Parameters.Add("@Denngay", OleDbType.Date)
            cmd.Parameters.Add("@Tangca", OleDbType.Boolean)
            cmd.Parameters.Add("@TangCaS", OleDbType.Integer)
            cmd.Parameters.Add("@GHTangC", OleDbType.Integer)
            cmd.Parameters.Add("@Dilam", OleDbType.Boolean)
            'cmd.Parameters("@ID").Value = Dto.ID
            cmd.Parameters("@NVID").Value = Dto.NVID
            cmd.Parameters("@CaID").Value = Dto.CaID
            cmd.Parameters("@Tungay").Value = Dto.Tungay
            cmd.Parameters("@Denngay").Value = Dto.Denngay
            cmd.Parameters("@Tangca").Value = Dto.Tangca
            cmd.Parameters("@TangCaS").Value = Dto.TangCaS
            cmd.Parameters("@GHTangC").Value = Dto.GHTangC
            cmd.Parameters("@Dilam").Value = Dto.Dilam
            cmd.ExecuteNonQuery()
            ''      If Ket_noi.State = ConnectionState.Open Then
            'Ket_noi.Close()
            'End If
        Else
        strsql = "Insert into lichtam(ID,NVID,CaID,Tungay,Denngay,Tangca,TangCaS,GHTangC,Dilam) values (" & Dto.ID & "," & Dto.NVID & "," & Dto.CaID & ",'" & Dto.Tungay & "','" & Dto.Denngay & "'," & Dto.Tangca & "," & Dto.TangCaS & "," & Dto.GHTangC & "," & Dto.Dilam & ")"
        Ket_noi1.Open()
        Dim cmd1 As New SqlCommand(strsql, Ket_noi1)
        cmd1.ExecuteNonQuery()
        Ket_noi1.Close()
        End If
    End Sub
    Public Sub XoaTheoNVvaTUNGAYvaDENNGAY(ByVal maNV As Integer, ByVal tungay As Date, ByVal denngay As Date, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            strSQL = "Delete From lichtam Where NVID= ? and Tungay= ? and Denngay = ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@NVID", OleDbType.Integer)
            cmd.Parameters.Add("@TUNGAY", OleDbType.Date)
            cmd.Parameters.Add("@DENNGAY", OleDbType.Date)
            cmd.Parameters("@NVID").Value = maNV
            cmd.Parameters("@TUNGAY").Value = tungay
            cmd.Parameters("@DENNGAY").Value = denngay
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        End If
    End Sub
    Public Sub XoaTheoNVvaCaidvaTUNGAYvaDENNGAY(ByVal maNV As Integer, ByVal CaID As Integer, ByVal tungay As Date, ByVal denngay As Date, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            strSQL = "Delete From lichtam Where NVID= ? and Tungay= ? and Denngay = ? and CaID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@NVID", OleDbType.Integer)
            cmd.Parameters.Add("@TUNGAY", OleDbType.Date)
            cmd.Parameters.Add("@DENNGAY", OleDbType.Date)
            cmd.Parameters.Add("@CaID", OleDbType.Integer)
            cmd.Parameters("@NVID").Value = maNV
            cmd.Parameters("@TUNGAY").Value = tungay
            cmd.Parameters("@DENNGAY").Value = denngay
            cmd.Parameters("@CaID").Value = CaID
            cmd.ExecuteNonQuery()
            ' If Ket_noi.State = ConnectionState.Open Then
            'Ket_noi.Close()
            'End If
        End If
    End Sub
    Public Sub Xoa(ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            strSQL = "Delete From lichtam Where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@ma", OleDbType.Integer)
            cmd.Parameters("@ma").Value = ma
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            Ket_noi1.Open()
            strSQL = "Delete From lichtam Where ID=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub


    Public Sub XoaALL(ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            strSQL = "Delete * From lichtam "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        
        End If
    End Sub


    Public Sub Xoa(ByVal MaNV As Integer, ByVal MaCa As Integer, ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            strSQL = "Delete From lichtam Where (NVID = PMaNV) AND (Caid = PMaCa) AND (TuNgay = PTuNgay) AND (DenNgay = PDenNgay)"
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("PMaNV", OleDbType.Integer).Value = MaNV
            cmd.Parameters.Add("PMaCa", OleDbType.Integer).Value = MaCa
            cmd.Parameters.Add("PTuNgay", OleDbType.Date).Value = TuNgay.Date
            cmd.Parameters.Add("PDenNgay", OleDbType.Date).Value = DenNgay.Date
            cmd.ExecuteNonQuery()
            'If Ket_noi.State = ConnectionState.Open Then
            'Ket_noi.Close()
            'End If
        Else
            'Ket_noi1.Open()
            'strSQL = "Delete From lichtam Where ID=" & ma & ""
            'Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            'cmd1.ExecuteNonQuery()
            'Ket_noi1.Close()
        End If
    End Sub

    Public Sub sua(ByVal dto As lichtamdto, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            If Ket_noi.State = ConnectionState.Closed Then
                Ket_noi.Open()
            End If
            strSQL = "Update lichtam Set NVID=? ,CaID=? ,Tungay=? ,Denngay=? ,Tangca=? ,TangCaS=? ,GHTangC=? ,Dilam= ? where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@NVID", OleDbType.Integer)
            cmd.Parameters.Add("@CaID", OleDbType.Integer)
            cmd.Parameters.Add("@Tungay", OleDbType.Date)
            cmd.Parameters.Add("@Denngay", OleDbType.Date)
            cmd.Parameters.Add("@Tangca", OleDbType.Boolean)
            cmd.Parameters.Add("@TangCaS", OleDbType.Integer)
            cmd.Parameters.Add("@GHTangC", OleDbType.Integer)
            cmd.Parameters.Add("@Dilam", OleDbType.Boolean)
            cmd.Parameters.Add("@ID", OleDbType.Integer)
            cmd.Parameters("@NVID").Value = dto.NVID
            cmd.Parameters("@CaID").Value = dto.CaID
            cmd.Parameters("@Tungay").Value = dto.Tungay
            cmd.Parameters("@Denngay").Value = dto.Denngay
            cmd.Parameters("@Tangca").Value = dto.Tangca
            cmd.Parameters("@TangCaS").Value = dto.TangCaS
            cmd.Parameters("@GHTangC").Value = dto.GHTangC
            cmd.Parameters("@Dilam").Value = dto.Dilam
            cmd.Parameters("@ID").Value = dto.ID
            cmd.ExecuteNonQuery()
            If Ket_noi.State = ConnectionState.Open Then
                Ket_noi.Close()
            End If
        Else
            Ket_noi1.Open()
            strSQL = "Update lichtam Set NVID= " & dto.NVID & ",CaID= " & dto.CaID & ",Tungay= '" & dto.Tungay & "',Denngay= '" & dto.Denngay & "',Tangca= " & dto.Tangca & ",TangCaS= " & dto.TangCaS & ",GHTangC= " & dto.GHTangC & ",Dilam= " & dto.Dilam & " where ID=" & dto.ID & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaNVID(ByVal NVID As Integer, ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            Ket_noi.Open()
            strSQL = "Update lichtam Set NVID = ?  where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@NVID", OleDbType.Integer)
            cmd.Parameters.Add("@ID", OleDbType.Integer)
            cmd.Parameters("@NVID").Value = NVID
            cmd.Parameters("@ID").Value = ma
            cmd.ExecuteNonQuery()
            Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update lichtam Set NVID =" & NVID & "  where ID=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaCaID(ByVal CaID As Integer, ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            Ket_noi.Open()
            strSQL = "Update lichtam Set CaID = ?  where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@CaID", OleDbType.Integer)
            cmd.Parameters.Add("@ID", OleDbType.Integer)
            cmd.Parameters("@CaID").Value = CaID
            cmd.Parameters("@ID").Value = ma
            cmd.ExecuteNonQuery()
            Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update lichtam Set CaID =" & CaID & "  where ID=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaTangCaS(ByVal TangCaS As Integer, ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            Ket_noi.Open()
            strSQL = "Update lichtam Set TangCaS = ?  where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@TangCaS", OleDbType.Integer)
            cmd.Parameters.Add("@ID", OleDbType.Integer)
            cmd.Parameters("@TangCaS").Value = TangCaS
            cmd.Parameters("@ID").Value = ma
            cmd.ExecuteNonQuery()
            Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update lichtam Set TangCaS =" & TangCaS & "  where ID=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
    Public Sub SuaGHTangC(ByVal GHTangC As Integer, ByVal ma As String, ByVal MSsql As Boolean)
        Dim strSQL As String
        If MSsql = False Then
            Ket_noi.Open()
            strSQL = "Update lichtam Set GHTangC = ?  where ID= ? "
            Dim cmd As New OleDbCommand(strSQL, Ket_noi)
            cmd.Parameters.Add("@GHTangC", OleDbType.Integer)
            cmd.Parameters.Add("@ID", OleDbType.Integer)
            cmd.Parameters("@GHTangC").Value = GHTangC
            cmd.Parameters("@ID").Value = ma
            cmd.ExecuteNonQuery()
            Ket_noi.Close()
        Else
            Ket_noi1.Open()
            strSQL = "Update lichtam Set GHTangC =" & GHTangC & "  where ID=" & ma & ""
            Dim cmd1 As New SqlCommand(strSQL, Ket_noi1)
            cmd1.ExecuteNonQuery()
            Ket_noi1.Close()
        End If
    End Sub
End Class

