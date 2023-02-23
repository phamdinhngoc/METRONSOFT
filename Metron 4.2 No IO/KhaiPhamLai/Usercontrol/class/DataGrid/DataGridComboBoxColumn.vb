Public Class DataGridComboBoxColumn
    Inherits DataGridTextBoxColumn
    ' Hosted combobox control
    Private m_comboBox As ComboBox
    Private cmanager As CurrencyManager
    Private iCurrentRow As Integer

    ' Constructor - create combobox, 
    ' register selection change event handler,
    ' register lose focus event handler
    Public Sub New()
        Me.cmanager = Nothing
        ' Create combobox and force DropDownList style
        Me.m_comboBox = New ComboBox()
        Me.m_comboBox.DropDownStyle = ComboBoxStyle.DropDownList
        ' Add event handler for notification when combobox loses focus
        AddHandler Me.m_comboBox.Leave, AddressOf comboBox_Leave
    End Sub

    ' Property to provide access to combobox 
    Public ReadOnly Property ComboBox() As ComboBox
        Get
            Return m_comboBox
        End Get
    End Property

    ' On edit, add scroll event handler, and display combobox
    Protected Overloads Overrides Sub Edit(ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal bounds As System.Drawing.Rectangle, ByVal [readOnly] As Boolean, ByVal instantText As String, ByVal cellIsVisible As Boolean)
        MyBase.Edit(source, rowNum, bounds, [readOnly], instantText, cellIsVisible)

        If Not [readOnly] AndAlso cellIsVisible Then
            ' Save current row in the DataGrid and currency manager 
            ' associated with the data source for the DataGrid
            Me.iCurrentRow = rowNum
            Me.cmanager = source

            ' Add event handler for DataGrid scroll notification
            AddHandler Me.DataGridTableStyle.DataGrid.Scroll, AddressOf DataGrid_Scroll

            ' Site the combobox control within the current cell
            Me.m_comboBox.Parent = Me.TextBox.Parent
            Dim rect As Rectangle = Me.DataGridTableStyle.DataGrid.GetCurrentCellBounds()
            Me.m_comboBox.Location = rect.Location
            Me.m_comboBox.Size = New Size(Me.TextBox.Size.Width, Me.m_comboBox.Size.Height)

            ' Set combobox selection to given text
            Me.m_comboBox.SelectedIndex = Me.m_comboBox.FindStringExact(Me.TextBox.Text)

            ' Make the combobox visible and place on top textbox control
            Me.m_comboBox.Show()
            Me.m_comboBox.BringToFront()
            Me.m_comboBox.Focus()
        End If
    End Sub

    ' Given a row, get the value member associated with a row.  Use the
    ' value member to find the associated display member by iterating 
    ' over bound data source
    Protected Overloads Overrides Function GetColumnValueAtRow(ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer) As Object
        Try
            ' Given a row number in the DataGrid, get the display member
            Dim obj As Object = MyBase.GetColumnValueAtRow(source, rowNum)
            ' Iterate through the data source bound to the ColumnComboBox
            Dim cmanager As CurrencyManager = DirectCast((Me.DataGridTableStyle.DataGrid.BindingContext(Me.m_comboBox.DataSource)), CurrencyManager)
            ' Assumes the associated DataGrid is bound to a DataView or 
            ' DataTable 
            Dim dataview As DataView = DirectCast(cmanager.List, DataView)
            Dim i As Integer
            For i = 0 To dataview.Count - 1
                If Val(obj) = Val(dataview(i)(Me.m_comboBox.ValueMember)) Then
                    Exit For
                End If
            Next
            If i < dataview.Count Then
                Return dataview(i)(Me.m_comboBox.DisplayMember)
            End If
            Return DBNull.Value
        Catch ex As Exception
            Return DBNull.Value
        End Try
    End Function

    ' Given a row and a display member, iterate over bound data source to 
    ' find the associated value member.  Set this value member.
    Protected Overloads Overrides Sub SetColumnValueAtRow(ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal value As Object)
        Try
            Dim s As Object = value
            ' Iterate through the data source bound to the ColumnComboBox
            Dim cmanager As CurrencyManager = DirectCast((Me.DataGridTableStyle.DataGrid.BindingContext(Me.m_comboBox.DataSource)), CurrencyManager)
            ' Assumes the associated DataGrid is bound to a DataView or 
            ' DataTable 
            Dim dataview As DataView = DirectCast(cmanager.List, DataView)
            Dim i As Integer

            For i = 0 To dataview.Count - 1
                If s = dataview(i)(Me.m_comboBox.DisplayMember) Then
                    Exit For
                End If
            Next

            ' If set item was found return corresponding value, 
            ' otherwise return DbNull.Value
            If i < dataview.Count Then
                s = dataview(i)(Me.m_comboBox.ValueMember)
            Else
                s = DBNull.Value
            End If
            MyBase.SetColumnValueAtRow(source, rowNum, s)
        Catch ex As Exception

        End Try
    End Sub

    ' On DataGrid scroll, hide the combobox
    Private Sub DataGrid_Scroll(ByVal sender As Object, ByVal e As EventArgs)
        Me.m_comboBox.Hide()
    End Sub

    ' On combobox losing focus, set the column value, hide the combobox,
    ' and unregister scroll event handler
    Private Sub comboBox_Leave(ByVal sender As Object, ByVal e As EventArgs)
        Dim rowView As DataRowView = DirectCast(Me.m_comboBox.SelectedItem, DataRowView)
        Dim s As String = Nothing
        'in case the selected value is null.
        Try
            If Not rowView.Row(Me.m_comboBox.DisplayMember).[GetType]().FullName.Equals("System.DBNull") Then
                s = DirectCast(rowView.Row(Me.m_comboBox.DisplayMember), String)
            Else
                s = ""
            End If
        Catch ex As Exception
            's="";
            MessageBox.Show(ex.Message)
        End Try

        SetColumnValueAtRow(Me.cmanager, Me.iCurrentRow, s)
        Invalidate()

        Me.m_comboBox.Hide()
        RemoveHandler Me.DataGridTableStyle.DataGrid.Scroll, AddressOf DataGrid_Scroll
    End Sub
End Class
