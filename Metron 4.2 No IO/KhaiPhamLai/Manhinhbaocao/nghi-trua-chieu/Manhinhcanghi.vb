Imports System.IO
Public Class Manhinhcanghi
#Region "Hổ trợ doc,ghi file"
    Private Sub DocFileBut(ByVal duongdanFile As String)
        Dim file As FileStream
        Dim reader As StreamReader
        Try
            file = New FileStream(duongdanFile, FileMode.Open)
            reader = New StreamReader(file)
            Tu_trua.Value = reader.ReadLine()
            Den_trua.Value = reader.ReadLine()
            Tu_chieu.Value = reader.ReadLine()
            Den_chieu.Value = reader.ReadLine()
            reader.Close()
            file.Close()
        Catch EX As Exception
        End Try
    End Sub
    Private Function TaoFileBut(ByVal duongdanFile As String) As String
        Dim file As FileStream
        Dim writer As StreamWriter
        Try
            file = New FileStream(duongdanFile, FileMode.CreateNew)
            writer = New StreamWriter(file)
            writer.WriteLine(Tu_trua.Value)
            writer.WriteLine(Den_trua.Value)
            writer.WriteLine(Tu_chieu.Value)
            writer.WriteLine(Den_chieu.Value)
            writer.Close()
            file.Close()
        Catch EX As Exception
            Return (EX.Message)
        End Try
        Return "1"
    End Function
#End Region
    Private Sub Manhinhcanghi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DocFileBut(Application.StartupPath & "\Thamsonghilamson.dll")
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click, Button3.Click
        Dim duongdan As String = Application.StartupPath & "\Thamsonghilamson.dll"
        Try
            File.Delete(duongdan)
        Catch ex As Exception
        End Try
        TaoFileBut(duongdan)
        Me.Close()
    End Sub
End Class