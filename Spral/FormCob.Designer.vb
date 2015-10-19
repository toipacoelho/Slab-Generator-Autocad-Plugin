<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCob
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCob))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.bpar = New System.Windows.Forms.RadioButton()
        Me.bper = New System.Windows.Forms.RadioButton()
        Me.inmr = New System.Windows.Forms.CheckBox()
        Me.b1 = New System.Windows.Forms.Button()
        Me.indc = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.bpar)
        Me.GroupBox1.Controls.Add(Me.bper)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 51)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(157, 63)
        Me.GroupBox1.TabIndex = 23
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
        Me.inmr.Location = New System.Drawing.Point(12, 120)
        Me.inmr.Name = "inmr"
        Me.inmr.Size = New System.Drawing.Size(86, 17)
        Me.inmr.TabIndex = 22
        Me.inmr.Text = "Espelhar laje"
        Me.inmr.UseVisualStyleBackColor = True
        '
        'b1
        '
        Me.b1.Location = New System.Drawing.Point(12, 143)
        Me.b1.Name = "b1"
        Me.b1.Size = New System.Drawing.Size(157, 23)
        Me.b1.TabIndex = 21
        Me.b1.Text = "Desenhar"
        Me.b1.UseVisualStyleBackColor = True
        '
        'indc
        '
        Me.indc.Location = New System.Drawing.Point(12, 25)
        Me.indc.Name = "indc"
        Me.indc.Size = New System.Drawing.Size(157, 20)
        Me.indc.TabIndex = 25
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 13)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Tamanho da telha (cm)"
        '
        'FormCob
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(183, 179)
        Me.Controls.Add(Me.indc)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.inmr)
        Me.Controls.Add(Me.b1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormCob"
        Me.Text = "Spral - Coberturas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents bpar As Windows.Forms.RadioButton
    Friend WithEvents bper As Windows.Forms.RadioButton
    Friend WithEvents inmr As Windows.Forms.CheckBox
    Friend WithEvents b1 As Windows.Forms.Button
    Friend WithEvents indc As Windows.Forms.TextBox
    Friend WithEvents Label2 As Windows.Forms.Label
End Class
