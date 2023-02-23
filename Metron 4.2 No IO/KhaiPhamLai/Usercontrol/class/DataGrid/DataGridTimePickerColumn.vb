Imports System
Imports System.Data
Imports System.Windows.Forms
Imports System.Drawing

Public Class DataGridTimePickerColumn
    Inherits DataGridTextBoxColumn
    'DataGridColumnStyle 
    Private myDateTimePicker As New DateTimePicker()
    ' The isEditing field tracks whether or not the user is
    ' editing data with the hosted control.
    Private isEditing As Boolean

    Public Sub New()
        MyBase.New()
        myDateTimePicker.Visible = False
    End Sub

    Protected Overloads Overrides Sub Abort(ByVal rowNum As Integer)
        isEditing = False
        RemoveHandler myDateTimePicker.ValueChanged, AddressOf TimePickerValueChanged
        Invalidate()
    End Sub

    Protected Overloads Overrides Function Commit(ByVal dataSource As CurrencyManager, ByVal rowNum As Integer) As Boolean
        myDateTimePicker.Bounds = Rectangle.Empty

        RemoveHandler myDateTimePicker.ValueChanged, AddressOf TimePickerValueChanged

        If Not isEditing Then
            Return True
        End If

        isEditing = False

        Try
            Dim value As DateTime = myDateTimePicker.Value
            SetColumnValueAtRow(dataSource, rowNum, value)
        Catch generatedExceptionName As Exception
            Abort(rowNum)
            Return False
        End Try

        Invalidate()
        Return True
    End Function

    Protected Overloads Overrides Sub Edit(ByVal source As CurrencyManager, ByVal rowNum As Integer, ByVal bounds As Rectangle, ByVal [readOnly] As Boolean, ByVal instantText As String, ByVal cellIsVisible As Boolean)
        If Not [readOnly] AndAlso cellIsVisible Then
            Try
                Dim value As DateTime = DateTime.Parse(GetColumnValueAtRow(source, rowNum).ToString())
                If cellIsVisible Then
                    myDateTimePicker.Bounds = New Rectangle(bounds.X + 2, bounds.Y + 2, bounds.Width - 4, bounds.Height - 4)
                    myDateTimePicker.Value = value
                    myDateTimePicker.Visible = True
                    AddHandler myDateTimePicker.ValueChanged, AddressOf TimePickerValueChanged
                Else
                    myDateTimePicker.Value = value
                    myDateTimePicker.Visible = False
                End If

                If myDateTimePicker.Visible Then
                    DataGridTableStyle.DataGrid.Invalidate(bounds)
                End If
            Catch ex As Exception
                If cellIsVisible Then
                    myDateTimePicker.Bounds = New Rectangle(bounds.X + 2, bounds.Y + 2, bounds.Width - 4, bounds.Height - 4)
                    myDateTimePicker.Value = Date.Today
                    myDateTimePicker.Visible = True
                    AddHandler myDateTimePicker.ValueChanged, AddressOf TimePickerValueChanged
                Else
                    myDateTimePicker.Value = Date.Today
                    myDateTimePicker.Visible = False
                End If
                If myDateTimePicker.Visible Then
                    DataGridTableStyle.DataGrid.Invalidate(bounds)
                End If
            End Try
        End If      
    End Sub

    Protected Overloads Overrides Function GetPreferredSize(ByVal g As Graphics, ByVal value As Object) As Size
        Return New Size(100, myDateTimePicker.PreferredHeight + 4)
    End Function

    Protected Overloads Overrides Function GetMinimumHeight() As Integer
        Return myDateTimePicker.PreferredHeight + 4
    End Function

    Protected Overloads Overrides Function GetPreferredHeight(ByVal g As Graphics, ByVal value As Object) As Integer
        Return myDateTimePicker.PreferredHeight + 4
    End Function

    Protected Overloads Overrides Sub Paint(ByVal g As Graphics, ByVal bounds As Rectangle, ByVal source As CurrencyManager, ByVal rowNum As Integer)
        Paint(g, bounds, source, rowNum, False)
    End Sub
    Protected Overloads Overrides Sub Paint(ByVal g As Graphics, ByVal bounds As Rectangle, ByVal source As CurrencyManager, ByVal rowNum As Integer, ByVal alignToRight As Boolean)
        Paint(g, bounds, source, rowNum, Brushes.Red, Brushes.Blue, _
         alignToRight)
    End Sub
    Protected Overloads Overrides Sub Paint(ByVal g As Graphics, ByVal bounds As Rectangle, ByVal source As CurrencyManager, ByVal rowNum As Integer, ByVal backBrush As Brush, ByVal foreBrush As Brush, _
     ByVal alignToRight As Boolean)
        Try
            Dim [date] As DateTime = DateTime.Parse(GetColumnValueAtRow(source, rowNum).ToString())
            Dim rect As Rectangle = bounds
            g.FillRectangle(backBrush, rect)
            rect.Offset(0, 2)
            rect.Height -= 2
            g.DrawString([date].ToString("d"), Me.DataGridTableStyle.DataGrid.Font, foreBrush, rect)
        Catch ex As Exception
        End Try
    End Sub

    Protected Overloads Overrides Sub SetDataGridInColumn(ByVal value As DataGrid)
        MyBase.SetDataGridInColumn(value)
        If myDateTimePicker.Parent IsNot Nothing Then
            myDateTimePicker.Parent.Controls.Remove(myDateTimePicker)
        End If
        If value IsNot Nothing Then
            value.Controls.Add(myDateTimePicker)
        End If
    End Sub

    Private Sub TimePickerValueChanged(ByVal sender As Object, ByVal e As EventArgs)
        Me.isEditing = True
        MyBase.ColumnStartedEditing(myDateTimePicker)
    End Sub
End Class
