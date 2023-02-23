 Imports System.Data.OleDb
 Imports System.Data
 Imports System.Data.SqlClient 
Public Class AbstractDao
    Inherits DataTable
    Public Ketnoi As KetNoiDto
    Public ConnectionThanhcong As Boolean = False
#Region "Khai báo cục bộ"
    Public WithEvents mBo_doc_ghi As OleDbDataAdapter
    Private WithEvents mBo_doc_ghi1 As SqlDataAdapter
    Private mChuoi_SQL As String
    Private mTen_bang As String
    Private Shared WithEvents mKet_noi As OleDbConnection
    Private Shared WithEvents mKet_noi1 As SqlConnection
#End Region
#Region "Khai báo thuộc tính"
    Public Property Chuoi_SQL() As String
        Get
            Return mChuoi_SQL
        End Get
        Set(ByVal Value As String)
            mChuoi_SQL = Value
        End Set
    End Property
    Public Property Ten_bang() As String
        Get
            Return mTen_bang
        End Get
        Set(ByVal Value As String)
            mTen_bang = Value
        End Set
    End Property
    Public Shared Property Ket_noi() As OleDbConnection
        Get
            Return mKet_noi
        End Get
        Set(ByVal Value As OleDbConnection)
            mKet_noi = Value
        End Set
    End Property
    Public Shared Property Ket_noi1() As SqlConnection
        Get
            Return mKet_noi1
        End Get
        Set(ByVal Value As SqlConnection)
            mKet_noi1 = Value
        End Set
    End Property
    Public ReadOnly Property So_dong() As Long
        Get
            Return Me.DefaultView.Count
        End Get
    End Property
#End Region
#Region "Khai báo phương thức khởi tạo"
    Public Sub New()
        MyBase.New()
    End Sub
    Public Sub New(ByVal Connection As KetNoiDto)
        Ketnoi = Connection
    End Sub
    Public Sub New(ByVal pTen_bang As String, ByVal Connection As KetNoiDto, Optional ByVal MSsql As Boolean = True)
        MyBase.New(pTen_bang)
        mTen_bang = pTen_bang
        Ketnoi = Connection
        Doc_bang(MSsql)
        'mbo_doc_ghi.
    End Sub
    Public Sub New(ByVal pTen_bang As String, ByVal pChuoi_SQL As String, ByVal Connection As KetNoiDto, Optional ByVal MSsql As Boolean = True)
        MyBase.New()
        mTen_bang = pTen_bang
        mChuoi_SQL = pChuoi_SQL
        Ketnoi = Connection
        Doc_bang(MSsql)
    End Sub
#End Region
#Region "Khai báo phương thức xử lý - Nhóm cung cấp thông tin"
    Private Sub Doc_bang(Optional ByVal MSsql As Boolean = True)
        ConnectionThanhcong = True
        If mChuoi_SQL = "" Then mChuoi_SQL = "SELECT * FROM " & mTen_bang
        If MSsql = False Then
            Try
                If mKet_noi Is Nothing Then
                    mKet_noi = New OleDbConnection
                    mKet_noi.ConnectionString = Ketnoi.ChuoiKetNoi
                    'mKet_noi.ResetState()
                End If
                If mKet_noi.State = ConnectionState.Closed Then
                    'mKet_noi = New OleDbConnection()
                    'mKet_noi.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source =D:\METRON SOFT\30 -  MTV Co Viet My (Chuẩn + Lương Acces)\Metron 4.2 No IO\KhaiPhamLai\bin\x86\Debug\CC.mdb;Persist Security Info=True;Jet OLEDB:Database Password=MinhLam20"
                    mKet_noi.Open()
                End If
                mBo_doc_ghi = New OleDbDataAdapter(mChuoi_SQL, mKet_noi)
                mBo_doc_ghi.FillSchema(Me, SchemaType.Mapped)
                mBo_doc_ghi.Fill(Me)
                mBo_doc_ghi.SelectCommand.CommandText = "select * FROM " & mTen_bang
                Dim Bo_phat_sinh As New OleDbCommandBuilder(mBo_doc_ghi)
                'If mKet_noi.State = ConnectionState.Open Or mKet_noi.State = ConnectionState.Connecting Then
                'mKet_noi.Close()
                'End If
            Catch ex As OleDbException
                ConnectionThanhcong = False
                Exit Sub
            End Try
        Else
            Try
                If mKet_noi1 Is Nothing Then
                    mKet_noi1 = New SqlConnection
                End If
                mKet_noi1.ConnectionString = Ketnoi.ChuoiKetNoi
                mKet_noi1.Open()
                mBo_doc_ghi1 = New SqlDataAdapter(mChuoi_SQL, mKet_noi1)
                mBo_doc_ghi1.FillSchema(Me, SchemaType.Mapped)
                mBo_doc_ghi1.Fill(Me)
                mBo_doc_ghi1.SelectCommand.CommandText = "select * FROM " & mTen_bang
                Dim Bo_phat_sinh1 As New SqlCommandBuilder(mBo_doc_ghi1)
                ' If mKet_noi1.State = ConnectionState.Open Or mKet_noi1.State = ConnectionState.Connecting Then
                'mKet_noi1.Close()
                ' End If
            Catch ex As SqlException
                ConnectionThanhcong = False
                If mKet_noi1.State = ConnectionState.Open Or mKet_noi1.State = ConnectionState.Connecting Then
                    mKet_noi1.Close()
                End If
                Exit Sub
            End Try
        End If
    End Sub
#End Region
#Region "Khai báo phương thức xử lý - Nhóm cập nhật thông tin"
    Public Function Ghi_du_lieu() As Boolean
        Dim ketqua As Boolean = True
        Try
            mBo_doc_ghi.Update(Me)
            Me.AcceptChanges()
        Catch ex As Exception
            Me.RejectChanges()
            ketqua = False
        End Try
        Return ketqua
    End Function
    Public Sub Loc_du_lieu(ByVal Bieu_thuc_loc As String)
        Try
            Me.DefaultView.RowFilter = Bieu_thuc_loc
        Catch ex As Exception
        End Try
    End Sub
#End Region
#Region "Khai báo các phương thức thực hiện lệnh"
    Public Function Thuc_hien_lenh(ByVal Lenh As String) As Integer
        Try
            Dim Cau_lenh As New OleDbCommand(Lenh, mKet_noi)
            mKet_noi.Open()
            Dim ket_qua As Integer = Cau_lenh.ExecuteNonQuery()
            mKet_noi.Close()
            Return ket_qua
        Catch ex As OleDbException
            Return -1
        End Try
    End Function
    Public Function Thuc_hien_lenh_tinh_toan(ByVal Lenh As String) As Object
        Try
            Dim Cau_lenh As New OleDbCommand(Lenh, mKet_noi)
            mKet_noi.Open()
            Dim ket_qua As Object = Cau_lenh.ExecuteScalar
            mKet_noi.Close()
            Return ket_qua
        Catch ex As OleDbException
            Return -1
        End Try
    End Function
#End Region
#Region "Xử lý sự kiện"
    Private Sub mBo_doc_ghi_RowUpdated(ByVal sender As Object, ByVal e As _
         System.Data.OleDb.OleDbRowUpdatedEventArgs) Handles mBo_doc_ghi.RowUpdated
        If Me.PrimaryKey(0).AutoIncrement Then
            If e.Status = UpdateStatus.[Continue] And e.StatementType = StatementType.Insert Then
                Dim cmd As New OleDbCommand("Select @@IDENTITY", mKet_noi)
                e.Row.Item(0) = cmd.ExecuteScalar
                Me.AcceptChanges()
            End If
        End If
    End Sub
#End Region
End Class

