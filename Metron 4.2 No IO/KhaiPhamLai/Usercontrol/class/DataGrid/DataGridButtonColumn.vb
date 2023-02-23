Public Class DataGridButtonColumn
    Inherits DataGridTextBoxColumn
    Public Event CellButtonClicked As DataGridCellButtonClickEventHandler
    Private _button As Bitmap
    Private _buttonPressed As Bitmap
    Private _columnNum As Integer
    Private _pressedRow As Integer
    Public value As Integer = 1

    Public Sub AddPictureButton(ByVal duongdan As String)
        Try
            Dim hinh As New Bitmap(duongdan)
            _button = hinh
        Catch ex As Exception
        End Try
    End Sub

    Public Sub New(ByVal colNum As Integer)
        _columnNum = colNum
        _pressedRow = -1
        Try
            Dim c As Char() = {","c}
            Dim strm As String = Application.StartupPath & "\Pictures\button.bmp"
            _button = New Bitmap(strm)
            strm = Application.StartupPath & "\Pictures\buttonpressed.bmp"
            _buttonPressed = New Bitmap(strm)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Protected Overloads Overrides Sub Edit(ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal bounds As System.Drawing.Rectangle, ByVal [readOnly] As Boolean, ByVal instantText As String, ByVal cellIsVisible As Boolean)
        ' dont call the baseclass so no editing done...
        ' base.Edit(source, rowNum, bounds, readOnly, instantText, cellIsVisible); 
    End Sub

    Private Sub DrawButton(ByVal g As Graphics, ByVal bm As Bitmap, ByVal bounds As Rectangle, ByVal row As Integer)

        Dim dg As DataGrid = Me.DataGridTableStyle.DataGrid
        Dim s As String = dg(row, Me._columnNum).ToString()

        Dim sz As SizeF = g.MeasureString(s, dg.Font, bounds.Width - 4, StringFormat.GenericTypographic)

        Dim x As Integer = bounds.Left + Math.Max(0, (bounds.Width - CInt(sz.Width)) / 2)
        g.DrawImage(bm, bounds, 0, 0, bm.Width, bm.Height, _
         GraphicsUnit.Pixel)

        If sz.Height < bounds.Height Then
            Dim y As Integer = bounds.Top + (bounds.Height - CInt(sz.Height)) / 2
            If _buttonPressed.Size = bm.Size Then
                x += 1
            End If

            g.DrawString(s, dg.Font, New SolidBrush(dg.ForeColor), x, y)

        End If
    End Sub

    Public Sub HandleMouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)

        Dim dg As DataGrid = Me.DataGridTableStyle.DataGrid
        Dim hti As DataGrid.HitTestInfo = dg.HitTest(New Point(e.X, e.Y))
        Dim isClickInCell As Boolean = (hti.Column = Me._columnNum AndAlso hti.Row > -1)

        _pressedRow = -1

        Dim rect As New Rectangle(0, 0, 0, 0)

        If isClickInCell Then
            rect = dg.GetCellBounds(hti.Row, hti.Column)
            isClickInCell = (e.X > rect.Right - Me._button.Width)
        End If
        If isClickInCell Then
            Dim g As Graphics = Graphics.FromHwnd(dg.Handle)
            '	g.DrawImage(this._button, rect.Right - this._button.Width, rect.Y);
            DrawButton(g, Me._button, rect, hti.Row)
            g.Dispose()
            RaiseEvent CellButtonClicked(Me, New DataGridCellButtonClickEventArgs(hti.Row, hti.Column))
        End If
    End Sub

    Public Sub HandleMouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        Dim dg As DataGrid = Me.DataGridTableStyle.DataGrid
        Dim hti As DataGrid.HitTestInfo = dg.HitTest(New Point(e.X, e.Y))
        Dim isClickInCell As Boolean = (hti.Column = Me._columnNum AndAlso hti.Row > -1)

        Dim rect As New Rectangle(0, 0, 0, 0)
        If isClickInCell Then
            rect = dg.GetCellBounds(hti.Row, hti.Column)
            isClickInCell = (e.X > rect.Right - Me._button.Width)
        End If

        If isClickInCell Then
            'Console.WriteLine("HandleMouseDown " + hti.Row.ToString());
            Dim g As Graphics = Graphics.FromHwnd(dg.Handle)
            'g.DrawImage(this._buttonPressed, rect.Right - this._buttonPressed.Width, rect.Y);
            DrawButton(g, _buttonPressed, rect, hti.Row)
            g.Dispose()
            _pressedRow = hti.Row
        End If
    End Sub

    Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal backBrush As System.Drawing.Brush, ByVal foreBrush As System.Drawing.Brush, _
     ByVal alignToRight As Boolean)
        'base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);

        Dim parent As DataGrid = Me.DataGridTableStyle.DataGrid
        Dim current As Boolean = parent.IsSelected(rowNum) OrElse (parent.CurrentRowIndex = rowNum AndAlso parent.CurrentCell.ColumnNumber = Me._columnNum)



        'draw the button
        Dim bm As Bitmap = IIf(_pressedRow = rowNum, Me._buttonPressed, Me._button)

        'font.Dispose();

        Me.DrawButton(g, bm, bounds, rowNum)
    End Sub


    Private Sub DataGridButtonColumn_CellButtonClicked(ByVal sender As Object, ByVal e As DataGridCellButtonClickEventArgs) Handles Me.CellButtonClicked

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class

Public Delegate Sub DataGridCellButtonClickEventHandler(ByVal sender As Object, ByVal e As DataGridCellButtonClickEventArgs)

Public Class DataGridCellButtonClickEventArgs
    Inherits EventArgs
    Private _row As Integer
    Private _col As Integer

    Public Sub New(ByVal row As Integer, ByVal col As Integer)
        _row = row
        _col = col
    End Sub

    Public ReadOnly Property RowIndex() As Integer
        Get
            Return _row
        End Get
    End Property
    Public ReadOnly Property ColIndex() As Integer
        Get
            Return _col
        End Get
    End Property

End Class
