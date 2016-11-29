<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.txtMain = New System.Windows.Forms.TextBox()
        Me.lblCaption = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtMain
        '
        Me.txtMain.Location = New System.Drawing.Point(86, 85)
        Me.txtMain.Name = "txtMain"
        Me.txtMain.Size = New System.Drawing.Size(100, 20)
        Me.txtMain.TabIndex = 1
        '
        'lblCaption
        '
        Me.lblCaption.AutoSize = True
        Me.lblCaption.Location = New System.Drawing.Point(86, 53)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(94, 13)
        Me.lblCaption.TabIndex = 2
        Me.lblCaption.Text = "How many teams?"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.lblCaption)
        Me.Controls.Add(Me.txtMain)
        Me.Name = "Form1"
        Me.Text = "Drafter"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtMain As System.Windows.Forms.TextBox
    Friend WithEvents lblCaption As System.Windows.Forms.Label
End Class
