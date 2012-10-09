<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HintedTextBoxTestForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.HintedTextBox1 = New HintTextBox.HintedTextBox()
        Me.HintTextBox1 = New HintTextBox.HintedTextBox()
        Me.Process1 = New System.Diagnostics.Process()
        Me.SuspendLayout()
        '
        'HintedTextBox1
        '
        Me.HintedTextBox1.FocusSelect = True
        Me.HintedTextBox1.HideHintOnFocus = False
        Me.HintedTextBox1.HintFont = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HintedTextBox1.HintForeColor = System.Drawing.SystemColors.GrayText
        Me.HintedTextBox1.HintText = "HideHintOnFocus = False"
        Me.HintedTextBox1.Location = New System.Drawing.Point(70, 86)
        Me.HintedTextBox1.Name = "HintedTextBox1"
        Me.HintedTextBox1.Size = New System.Drawing.Size(194, 23)
        Me.HintedTextBox1.TabIndex = 1
        '
        'HintTextBox1
        '
        Me.HintTextBox1.FocusSelect = True
        Me.HintTextBox1.HintFont = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HintTextBox1.HintForeColor = System.Drawing.SystemColors.GrayText
        Me.HintTextBox1.HintText = "HideHintOnFocus = True"
        Me.HintTextBox1.Location = New System.Drawing.Point(70, 57)
        Me.HintTextBox1.Name = "HintTextBox1"
        Me.HintTextBox1.Size = New System.Drawing.Size(194, 23)
        Me.HintTextBox1.TabIndex = 0
        '
        'Process1
        '
        Me.Process1.StartInfo.Domain = ""
        Me.Process1.StartInfo.LoadUserProfile = False
        Me.Process1.StartInfo.Password = Nothing
        Me.Process1.StartInfo.StandardErrorEncoding = Nothing
        Me.Process1.StartInfo.StandardOutputEncoding = Nothing
        Me.Process1.StartInfo.UserName = ""
        Me.Process1.SynchronizingObject = Me
        '
        'HintedTextBoxTestForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(331, 302)
        Me.Controls.Add(Me.HintedTextBox1)
        Me.Controls.Add(Me.HintTextBox1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "HintedTextBoxTestForm"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents HintTextBox1 As HintedTextBox
    Friend WithEvents HintedTextBox1 As HintTextBox.HintedTextBox
    Friend WithEvents Process1 As System.Diagnostics.Process

End Class
