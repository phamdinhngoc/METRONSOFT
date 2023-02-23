Imports System.ComponentModel


<DefaultEvent("Click"), DefaultProperty("ShapeToDraw"), _
ToolboxBitmap(GetType(ShapeControl), "ShapeControl.bmp")> _
Public Class ShapeControl
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.SetStyle(ControlStyles.ResizeRedraw, True)
    End Sub

    'UserControl1 overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'ShapeControl
        '
        Me.Name = "ShapeControl"
        Me.Size = New System.Drawing.Size(86, 68)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim mType As ShapeType = ShapeType.Ellipse
    Dim mLineWidth As DrawWidth = DrawWidth.Normal
    Dim mDrawColor As Color = Color.Blue

    Public Enum ShapeType
        Ellipse
        Rectangle
        RoundRectangle
        Triangle
        LeftLine
        RightLine
        Line
    End Enum

    Public Enum DrawWidth
        Thin = 2
        Normal = 5
        Wide = 8
    End Enum

    Public Property ShapeToDraw() As ShapeType
        Get
            Return mType
        End Get
        Set(ByVal Value As ShapeType)
            mType = Value
            Invalidate()
        End Set
    End Property

    Public Property ShapeColor() As Color
        Get
            Return mDrawColor
        End Get
        Set(ByVal Value As Color)
            mDrawColor = Value
            Invalidate()
        End Set
    End Property

    Public Property LineWidth() As DrawWidth
        Get
            Return mLineWidth
        End Get
        Set(ByVal Value As DrawWidth)
            mLineWidth = Value
            Invalidate()
        End Set
    End Property

    Private Sub UserControl1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim gp As New Drawing2D.GraphicsPath
        Select Case mType
            Case ShapeType.Ellipse
                gp.AddEllipse(Me.ClientRectangle)
            Case ShapeType.Rectangle
                gp.AddRectangle(Me.ClientRectangle)
            Case ShapeType.Triangle
                Dim pts(3) As Point
                pts(0) = New Point(Me.Width \ 2, 0)
                pts(1) = New Point(0, Me.Height)
                pts(2) = New Point(Me.Width, Me.Height)
                pts(3) = New Point(Me.Width \ 2, 0)
                gp.AddPolygon(pts)
            Case ShapeType.RoundRectangle
                Dim radius As Single
                radius = CType((Me.Width * 0.1), Single)
                gp.AddLine(radius, 0, Width - (radius * 2), 0)
                gp.AddArc(Width - (radius * 2), 0, radius * 2, radius * 2, 270, 90)
                gp.AddLine(Width, radius, Width, Height - (radius * 2))
                gp.AddArc(Width - (radius * 2), Height - (radius * 2), radius * 2, radius * 2, 0, 90)
                gp.AddLine(Width - (radius * 2), Height, radius, Height)
                gp.AddArc(0, Height - (radius * 2), radius * 2, radius * 2, 90, 90)
                gp.AddLine(0, Height - (radius * 2), 0, radius)
                gp.AddArc(0, 0, radius * 2, radius * 2, 180, 90)
                gp.CloseFigure()
            Case ShapeType.LeftLine
                gp.AddLine(mLineWidth, 0, Me.Width, Me.Height - mLineWidth)
                gp.AddLine(Me.Width, Me.Height - mLineWidth, Me.Width - mLineWidth, Me.Height)
                gp.AddLine(Me.Width - mLineWidth, Me.Height, 0, mLineWidth)
                gp.AddLine(0, mLineWidth, mLineWidth, 0)
                gp.CloseFigure()
            Case ShapeType.RightLine
                gp.AddLine(0, Me.Height - mLineWidth, Me.Width - mLineWidth, 0)
                gp.AddLine(Me.Width - mLineWidth, 0, Me.Width, mLineWidth)
                gp.AddLine(Me.Width, mLineWidth, mLineWidth, Me.Height)
                gp.AddLine(mLineWidth, Me.Height, 0, Me.Height - mLineWidth)
                gp.CloseFigure()
            Case ShapeType.Line
                gp.AddLine(0, Me.Height - mLineWidth, Me.Width - mLineWidth, 0)
                gp.AddLine(Me.Width - mLineWidth, 0, Me.Width, mLineWidth)
                gp.AddLine(Me.Width, mLineWidth, mLineWidth, Me.Height)
                gp.AddLine(mLineWidth, Me.Height, 0, Me.Height - mLineWidth)
                gp.CloseFigure()
        End Select
        Dim rgn As New Region(gp)
        Me.Region = rgn
        Dim br As New SolidBrush(mDrawColor)
        e.Graphics.FillRectangle(br, Me.ClientRectangle)
        br.Dispose()
    End Sub

    Private Sub ShapeControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub
End Class
