Imports System.ComponentModel

Public Class HintedTextBox
    Inherits System.Windows.Forms.TextBox

    Const WM_SETFOCUS As Integer = 7
    Const WM_KILLFOCUS As Integer = 8
    Const WM_PAINT As Integer = 15

    Private _DrawHint As Boolean = True
    Private _SelectAllOnFocus As Boolean = True
    Private _HideHintOnFocus As Boolean = True

#Region "Control Properties"

    Private _HintText As String = "Search"
    <Browsable(True)> _
    <EditorBrowsable(EditorBrowsableState.Always)> _
    <Category("Appearance")> _
    <Description("The Hint text to display when there is nothing in the Text property.")> _
    Public Property HintText() As String
        Get
            Return _HintText
        End Get
        Set(ByVal value As String)
            _HintText = value.Trim()
            Me.Invalidate()
        End Set
    End Property

    Private _HintColor As Color = SystemColors.GrayText
    <Browsable(True)> _
    <EditorBrowsable(EditorBrowsableState.Always)> _
    <Category("Appearance")> _
    <Description("The ForeColor to use when displaying the HintText.")> _
    Public Property HintForeColor() As Color
        Get
            Return _HintColor
        End Get
        Set(ByVal value As Color)
            _HintColor = value
            Me.Invalidate()
        End Set
    End Property

    Private _HintFont As Font = DefaultFont
    <Browsable(True)> _
    <EditorBrowsable(EditorBrowsableState.Always)> _
    <Category("Appearance")> _
    <Description("The Font to use when displaying the HintText.")> _
    Public Property HintFont() As Font
        Get
            Return _HintFont
        End Get
        Set(ByVal value As Font)
            _HintFont = value
            Me.Invalidate()
        End Set
    End Property

    <Browsable(True)> _
    <EditorBrowsable(EditorBrowsableState.Always)> _
    <Category("Behavior")> _
    <Description("Automatically select the text when control receives the focus.")> _
    Public Property FocusSelect() As Boolean
        Get
            Return _SelectAllOnFocus
        End Get
        Set(ByVal value As Boolean)
            _SelectAllOnFocus = value
        End Set
    End Property

    <Browsable(True)> _
    <EditorBrowsable(EditorBrowsableState.Always)> _
    <Category("Behavior")> _
    <Description("Hide the hint when the textbox has focus")> _
    <DefaultValue(True)> _
    Public Property HideHintOnFocus() As Boolean
        Get
            Return _HideHintOnFocus
        End Get
        Set(ByVal value As Boolean)
            _HideHintOnFocus = value
        End Set
    End Property

#End Region

    Public Sub New()
        Me.HintFont = Me.Font
    End Sub

    ''' <summary>
    ''' When the textbox receives an OnEnter event, select all the text if any text is present
    ''' </summary>
    Protected Overrides Sub OnEnter(ByVal e As EventArgs)
        If Me.Text.Length > 0 AndAlso _SelectAllOnFocus Then
            Me.SelectAll()
        End If

        MyBase.OnEnter(e)
    End Sub

    ''' <summary>
    ''' Redraw the control when the text alignment changes
    ''' </summary>
    Protected Overrides Sub OnTextAlignChanged(ByVal e As EventArgs)
        MyBase.OnTextAlignChanged(e)
        Me.Invalidate()
    End Sub

    ''' <summary>
    ''' Redraw the control with the hint
    ''' </summary>
    ''' <remarks>This event will only fire if ControlStyles.UserPaint is set to true in the constructor</remarks>
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)

        ' Only draw the hint in the OnPaint event and when the Text property is empty
        If _DrawHint AndAlso Me.Text.Length = 0 Then
            DrawHint(e.Graphics)
        End If
    End Sub

    ''' <summary>
    ''' Overrides the default WndProc for the control
    ''' </summary>
    ''' <param name="m">The Windows message structure</param>
    ''' <remarks>
    ''' This technique is necessary because the OnPaint event seems to be doing some
    ''' extra processing that I haven't been able to figure out.
    ''' </remarks>
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Select Case m.Msg
            Case WM_SETFOCUS
                _DrawHint = Not Me.HideHintOnFocus
                Exit Select

            Case WM_KILLFOCUS
                _DrawHint = True
                Exit Select
        End Select

        MyBase.WndProc(m)

        ' Only draw the hint on the WM_PAINT event and when the Text property is empty
        If m.Msg = WM_PAINT AndAlso _DrawHint AndAlso Me.Text.Length = 0 AndAlso Not Me.GetStyle(ControlStyles.UserPaint) Then
            DrawHint()
        End If
    End Sub

    ''' <summary>
    ''' Overload to automatically create the Graphics region before drawing the text hint
    ''' </summary>
    ''' <remarks>The Graphics region is disposed after drawing the hint.</remarks>
    Protected Overridable Sub DrawHint()
        Using g As Graphics = Me.CreateGraphics()
            DrawHint(g)
        End Using
    End Sub

    ''' <summary>
    ''' Draws the HintText in the TextBox.ClientRectangle using the HintFont and HintForeColor
    ''' </summary>
    ''' <param name="g">The Graphics region to draw the Hint on</param>
    Protected Overridable Sub DrawHint(ByVal g As Graphics)
        Dim flags As TextFormatFlags = TextFormatFlags.NoPadding Or TextFormatFlags.Top Or TextFormatFlags.EndEllipsis
        Dim rect As Rectangle = Me.ClientRectangle

        ' Offset the rectangle based on the HorizontalAlignment, 
        ' otherwise the display looks a little strange
        Select Case Me.TextAlign
            Case HorizontalAlignment.Center
                flags = flags Or TextFormatFlags.HorizontalCenter
                rect.Offset(0, 1)
                Exit Select
            Case HorizontalAlignment.Left
                flags = flags Or TextFormatFlags.Left
                rect.Offset(1, 1)
                Exit Select
            Case HorizontalAlignment.Right
                flags = flags Or TextFormatFlags.Right
                rect.Offset(0, 1)
                Exit Select
        End Select

        ' Draw the Hint text using TextRenderer
        TextRenderer.DrawText(g, _HintText, _HintFont, rect, _HintColor, If(Me.Enabled, Me.BackColor, SystemColors.Control), flags)
    End Sub

    Protected Overrides Sub CreateHandle()
        'if this control is being used inside a ToolStripControlHost component, this code fixes a crash in the designer
        If Not Me.IsDisposed Then
            MyBase.CreateHandle()
        End If
    End Sub

End Class