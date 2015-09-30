<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAlv
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAlv))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.bpar = New System.Windows.Forms.RadioButton()
        Me.bper = New System.Windows.Forms.RadioButton()
        Me.inmr = New System.Windows.Forms.CheckBox()
        Me.b1 = New System.Windows.Forms.Button()
        Me.pvtype = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.bpar)
        Me.GroupBox1.Controls.Add(Me.bper)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 52)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(157, 63)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Perfis em realação à reta"
        '
        'bpar
        '
        Me.bpar.AutoSize = True
        Me.bpar.Location = New System.Drawing.Point(6, 19)
        Me.bpar.Name = "bpar"
        Me.bpar.Size = New System.Drawing.Size(80, 17)
        Me.bpar.TabIndex = 15
        Me.bpar.TabStop = True
        Me.bpar.Text = "1. Paralelas"
        Me.bpar.UseVisualStyleBackColor = True
        '
        'bper
        '
        Me.bper.AutoSize = True
        Me.bper.Location = New System.Drawing.Point(7, 42)
        Me.bper.Name = "bper"
        Me.bper.Size = New System.Drawing.Size(113, 17)
        Me.bper.TabIndex = 16
        Me.bper.TabStop = True
        Me.bper.Text = "2. Perpendiculares"
        Me.bper.UseVisualStyleBackColor = True
        '
        'inmr
        '
        Me.inmr.AutoSize = True
        Me.inmr.Location = New System.Drawing.Point(12, 121)
        Me.inmr.Name = "inmr"
        Me.inmr.Size = New System.Drawing.Size(86, 17)
        Me.inmr.TabIndex = 19
        Me.inmr.Text = "Espelhar laje"
        Me.inmr.UseVisualStyleBackColor = True
        '
        'b1
        '
        Me.b1.Location = New System.Drawing.Point(12, 144)
        Me.b1.Name = "b1"
        Me.b1.Size = New System.Drawing.Size(157, 23)
        Me.b1.TabIndex = 18
        Me.b1.Text = "Desenhar"
        Me.b1.UseVisualStyleBackColor = True
        '
        'pvtype
        '
        Me.pvtype.FormattingEnabled = True
        Me.pvtype.Items.AddRange(New Object() {"180", "265", "400"})
        Me.pvtype.Location = New System.Drawing.Point(12, 25)
        Me.pvtype.Name = "pvtype"
        Me.pvtype.Size = New System.Drawing.Size(157, 21)
        Me.pvtype.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Tipo de pavimento"
        '
        'FormAlv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(181, 177)
        Me.Controls.Add(Me.pvtype)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.inmr)
        Me.Controls.Add(Me.b1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormAlv"
        Me.Text = "Spral - Alveolares"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents bpar As System.Windows.Forms.RadioButton
    Friend WithEvents bper As System.Windows.Forms.RadioButton
    Friend WithEvents inmr As System.Windows.Forms.CheckBox
    Friend WithEvents b1 As System.Windows.Forms.Button
    Friend WithEvents pvtype As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
