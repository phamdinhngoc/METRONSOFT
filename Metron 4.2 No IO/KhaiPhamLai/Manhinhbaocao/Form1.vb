Imports System.Windows.Forms

Public Class Form1
    Public Dgv As DataGridView
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TreeView1.Nodes.Clear()
        DanhsachCotBaocao(Dgv)
    End Sub
    Dim a As Integer = 0
    Private Sub DanhsachCotBaocao(ByVal dgv As DataGridView)
        For i As Integer = 0 To dgv.ColumnCount - 1
            TreeView1.Nodes.Add(dgv.Columns(i).Name, dgv.Columns(i).HeaderText)
            TreeView1.Nodes(i).Checked = dgv.Columns(i).Visible
        Next

    End Sub


    Private Sub TreeView1_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterCheck
        If e.Node.Checked = True Then
            ManHinhBaoCao.DataGridViewTonghop.Columns(e.Node.Index).Visible = True
        Else
            ManHinhBaoCao.DataGridViewTonghop.Columns(e.Node.Index).Visible = False
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class