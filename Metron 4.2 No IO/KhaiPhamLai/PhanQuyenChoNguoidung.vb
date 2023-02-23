Imports System.IO
Public Class PhanQuyenChoNguoidung
    Dim bus As New QuyenBus(DTOKetnoi, False)
    Dim dto As New Quyendto
#Region "Ham Lien Quan File"
    Private Function TaoFileBut(ByVal duongdanFile As String) As String
        Dim file As FileStream
        Dim writer As StreamWriter
        Try
            file = New FileStream(duongdanFile, FileMode.CreateNew)
            writer = New StreamWriter(file)
            For i As Integer = 0 To TreeView1.Nodes.Count - 1
                If TreeView1.Nodes(i).ImageIndex = 1 Then
                    writer.WriteLine(TreeView1.Nodes(i).Name)
                End If
                For j As Integer = 0 To TreeView1.Nodes(i).Nodes.Count - 1
                    If TreeView1.Nodes(i).Nodes(j).ImageIndex = 1 Then
                        writer.WriteLine(TreeView1.Nodes(i).Nodes(j).Name)
                    End If
                Next
            Next
            writer.Close()
            file.Close()
        Catch EX As Exception
            Return (EX.Message)
        End Try
        Return "1"
    End Function
    Private Function DocFileBut(ByVal duongdanFile As String) As String
        Dim file As FileStream
        Dim reader As StreamReader
        Dim a As String = ""
        Try
            file = New FileStream(duongdanFile, FileMode.Open)
            reader = New StreamReader(file)
            While (reader.EndOfStream = False)
                kiemtrabut(reader.ReadLine)
            End While
            reader.Close()
            file.Close()
        Catch EX As Exception
            Return ""
        End Try
        Return a
    End Function
    Private Function TaoFile(ByVal duongdanFile As String) As String
        Dim file As FileStream
        Dim writer As StreamWriter
        Try
            file = New FileStream(duongdanFile, FileMode.CreateNew)
            writer = New StreamWriter(file)
            For i As Integer = 0 To CheckedListBox1.CheckedItems.Count - 1
                writer.WriteLine(CheckedListBox1.CheckedItems(i))
            Next
            writer.Close()
            file.Close()
        Catch EX As Exception
            Return (EX.Message)
        End Try
        Return "1"
    End Function
    Private Function GhiFile(ByVal duongdanFile As String) As String
        Dim file As FileStream
        Dim writer As StreamWriter
        Try
            file = New FileStream(duongdanFile, FileMode.Open)
            writer = New StreamWriter(file)
            For i As Integer = 0 To CheckedListBox1.CheckedItems.Count - 1
                writer.WriteLine(CheckedListBox1.CheckedItems(i))
            Next
            writer.Close()
            file.Close()
        Catch EX As Exception
            Return EX.Message
        End Try
        Return "1"
    End Function
    Private Function DocFile(ByVal duongdanFile As String) As String
        Dim file As FileStream
        Dim reader As StreamReader
        Dim a As String = ""
        Try
            file = New FileStream(duongdanFile, FileMode.Open)
            reader = New StreamReader(file)
            While (reader.EndOfStream = False)
                kiemtra(reader.ReadLine)
            End While
            reader.Close()
            file.Close()
        Catch EX As Exception
            Return ""
        End Try
        Return a
    End Function
#End Region
    Public Sub addTree(ByVal Group As MenuStrip)
        Dim node As New TreeNode
        Dim CTr As New ToolStripMenuItem
        For Each CTr In Group.Items
            node = TreeView1.Nodes.Add(CTr.Name, CTr.Text)
            If CTr.DropDownItems.Count > 0 Then
                Dim ctrm As ToolStripItem
                For Each ctrm In CTr.DropDownItems
                    node.Nodes.Add(ctrm.Name, ctrm.Text)
                Next
            End If
        Next
    End Sub

    Private Sub kiemtrabut(ByVal str As String)
        For i As Integer = 0 To TreeView1.Nodes.Count - 1
            If TreeView1.Nodes(i).Name = str Then
                TreeView1.Nodes(i).ImageIndex = 1
                TreeView1.Nodes(i).SelectedImageIndex = 1
                Exit Sub
            End If
            For j As Integer = 0 To TreeView1.Nodes(i).Nodes.Count - 1
                If TreeView1.Nodes(i).Nodes(j).Name = str Then
                    TreeView1.Nodes(i).Nodes(j).ImageIndex = 1
                    TreeView1.Nodes(i).Nodes(j).SelectedImageIndex = 1
                    Exit Sub
                End If
            Next
        Next
    End Sub
    Private Sub kiemtra(ByVal str As String)
        For i As Integer = 0 To 14
            If str = CheckedListBox1.Items(i) Then
                CheckedListBox1.SetItemChecked(i, True)
                Exit Sub
            End If
        Next
    End Sub
    Private Sub Check(ByVal a As Boolean)
        For i As Integer = 0 To 14
            CheckedListBox1.SetItemChecked(i, a)
        Next
    End Sub
    Private Sub checkTreetrue()
        For i As Integer = 0 To TreeView1.Nodes.Count - 1
            TreeView1.Nodes(i).ImageIndex = 0
            TreeView1.Nodes(i).SelectedImageIndex = 0
            For j As Integer = 0 To TreeView1.Nodes(i).Nodes.Count - 1
                TreeView1.Nodes(i).Nodes(j).ImageIndex = 0
                TreeView1.Nodes(i).Nodes(j).SelectedImageIndex = 0
            Next
        Next
    End Sub
    Private Sub combo()
        Dim table As DataTable = bus.LayBangTable()
        ComboBox1.Items.Clear()
        For i As Integer = 0 To table.Rows.Count - 1
            ComboBox1.Items.Add(table.Rows(i).Item(1))
        Next
        ComboBox1.SelectedIndex = 2
    End Sub
    Private Sub CheckedList()
        CheckedListBox1.Items.Add("THÊM Chức Vụ", True)
        CheckedListBox1.Items.Add("XOÁ Chức Vụ", True)
        CheckedListBox1.Items.Add("SỬA Chức Vụ", True)

        CheckedListBox1.Items.Add("THÊM Đơn vị(Phòng ban)", True)
        CheckedListBox1.Items.Add("XOÁ Đơn vị(Phòng ban)", True)
        CheckedListBox1.Items.Add("SỬA Đơn vị(Phòng ban)", True)

        CheckedListBox1.Items.Add("THÊM Máy Chấm Công", True)
        CheckedListBox1.Items.Add("XOÁ Máy Chấm Công", True)
        CheckedListBox1.Items.Add("SỬA Máy Chấm Công", True)

        CheckedListBox1.Items.Add("ĐĂNG KÝ nguời dùng", True)
        CheckedListBox1.Items.Add("XOÁ người dùng", True)
        CheckedListBox1.Items.Add("SỬA người dùng", True)

        CheckedListBox1.Items.Add("THÊM Nhân viên sử dụng máy chấm Công", True)
        CheckedListBox1.Items.Add("XOÁ Nhân viên sử dụng máy chấm Công", True)
        CheckedListBox1.Items.Add("SỬA Nhân viên sử dụng máy chấm Công", True)
    End Sub
    Private Sub PhanQuyenChoNguoidung_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        ManHinhChinh.CửaSổHoạtĐộngToolStripMenuItem.DropDownItems.Remove(ManHinhChinh.CửaSổHoạtĐộngToolStripMenuItem.DropDownItems(Me.Name))
        MsgBox("Bạn nên tắt chương trình rồi bật lại để chương trình nạp thông số mới")
    End Sub
    Private Sub PhanQuyenChoNguoidung_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ManHinhChinh.CửaSổHoạtĐộngToolStripMenuItem.DropDownItems.Add("Giao Diện Phân Quyền Người Dùng").Name = Me.Name
            Directory.CreateDirectory(Application.StartupPath & "\FileDefault")
            Directory.CreateDirectory(Application.StartupPath & "\FileDefault\FlieLuu")
        Catch ex As Exception
        End Try
        combo()
        CheckedList()
        addTree(ManHinhChinh.MenuStrip1)
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim duongdan As String = ""
        If ComboBox1.Text = ChuoiTQL Then
            MsgBox("Phân quyền Tổng Quản Lý KHÔNG thể thây đổi")
            Exit Sub
        End If
        '*********************
        duongdan = Application.StartupPath & "\FileDefault\FlieLuu\" & ComboBox1.Text & "HT.txt"
        Try
            File.Delete(duongdan)
        Catch ex As Exception
        End Try
        TaoFile(duongdan)
        '***********************
        duongdan = Application.StartupPath & "\FileDefault\FlieLuu\" & ComboBox1.Text & "MHChinhHT.txt"
        Try
            File.Delete(duongdan)
        Catch ex As Exception
        End Try
        TaoFileBut(duongdan)
        MsgBox("Đã lưu Phân quyền")
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Check(False)
        DocFile(Application.StartupPath & "\FileDefault\" & ComboBox1.Text & ".txt")
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            Check(False)
            checkTreetrue()
            DocFile(Application.StartupPath & "\FileDefault\FlieLuu\" & ComboBox1.Text & "HT.txt")
            DocFileBut(Application.StartupPath & "\FileDefault\FlieLuu\" & ComboBox1.Text & "MHChinhHT.txt")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub KhôngSửDụngToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KhôngSửDụngToolStripMenuItem.Click
        Try
            TreeView1.SelectedNode.ImageIndex = 1
            TreeView1.SelectedNode.SelectedImageIndex = 1
            If TreeView1.SelectedNode.Nodes.Count > 0 Then
                For i As Integer = 0 To TreeView1.SelectedNode.Nodes.Count - 1
                    TreeView1.SelectedNode.Nodes(i).ImageIndex = 1
                    TreeView1.SelectedNode.Nodes(i).SelectedImageIndex = 1
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub SửDụngToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SửDụngToolStripMenuItem.Click
        Try
            TreeView1.SelectedNode.ImageIndex = 0
            TreeView1.SelectedNode.SelectedImageIndex = 0
            If TreeView1.SelectedNode.Nodes.Count > 0 Then
                For i As Integer = 0 To TreeView1.SelectedNode.Nodes.Count - 1
                    TreeView1.SelectedNode.Nodes(i).ImageIndex = 0
                    TreeView1.SelectedNode.Nodes(i).SelectedImageIndex = 0
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If ComboBox1.Text = ChuoiTC Then
            checkTreetrue()
        Else
            DocFileBut(Application.StartupPath & "\FileDefault\" & ComboBox1.Text & "MHChinh.txt")
        End If
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim TenQuyen As String = InputBox("Nhập Tên Quyền bạn muốn thêm", "Thông báo")
        If TenQuyen = "" Then Exit Sub
        dto.TenQuyen = TenQuyen
        bus.Them(dto)
        combo()
    End Sub
End Class