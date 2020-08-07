<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTextArea
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
        Me.txtTextArea = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'txtTextArea
        '
        Me.txtTextArea.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTextArea.Location = New System.Drawing.Point(0, 0)
        Me.txtTextArea.Name = "txtTextArea"
        Me.txtTextArea.Size = New System.Drawing.Size(800, 450)
        Me.txtTextArea.TabIndex = 0
        Me.txtTextArea.Text = ""
        '
        'frmTextArea
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.txtTextArea)
        Me.Name = "frmTextArea"
        Me.Text = "Text Area"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents txtTextArea As RichTextBox
End Class
