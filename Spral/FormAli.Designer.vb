<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAli
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAli))
        Me.b1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pvtype = New System.Windows.Forms.ComboBox()
        Me.inmr = New System.Windows.Forms.CheckBox()
        Me.bpar = New System.Windows.Forms.RadioButton()
        Me.bper = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.inac = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.indc = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'b1
        '
        Me.b1.Location = New System.Drawing.Point(12, 223)
        Me.b1.Name = "b1"
        Me.b1.Size = New System.Drawing.Size(157, 23)
        Me.b1.TabIndex = 0
        Me.b1.Text = "Desenhar"
        Me.b1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Tipo de pavimento"
        '
        'pvtype
        '
        Me.pvtype.FormattingEnabled = True
        Me.pvtype.Items.AddRange(New Object() {"B2-22x25", "B2-22x30", "B2-33x12", "B2-33x16", "B2-33x20", "B2-33x25", "B2-40x09", "B2-40x12", "B2-40x16", "B2-40x20", "B2-40x25", "B2-48x12", "B2-48x16", "B2-48x20", "B3-22x25", "B3-22x30", "B3-33x12", "B3-33x16", "B3-33x20", "B3-33x25", "B3-40x09", "B3-40x12", "B3-40x16", "B3-40x20", "B3-40x25", "B3-48x12", "B3-48x16", "B3-48x20", "B4-22x25", "B4-22x30", "B4-33x16", "B4-33x20", "B4-33x25", "B4-40x16", "B4-40x20", "B4-40x25", "B4-48x16", "B4-48x20", "2B3-22x25", "2B3-22x30", "2B3-33x12", "2B3-33x16", "2B3-33x20", "2B3-33x25", "2B3-40x12", "2B3-40x16", "2B3-40x20", "2B3-40x25", "2B3-48x16", "2B3-48x20", "2B4-22x25", "2B4-22x30", "2B4-33x16", "2B4-33x20", "2B4-33x25", "2B4-40x16", "2B4-40x20", "2B4-40x25", "2B4-48x16", "2B4-48x20", "3B3-22x22", "3B3-22x25", "3B3-22x30", "3B4-22x25", "3B4-22x30"})
        Me.pvtype.Location = New System.Drawing.Point(12, 25)
        Me.pvtype.Name = "pvtype"
        Me.pvtype.Size = New System.Drawing.Size(157, 21)
        Me.pvtype.TabIndex = 6
        '
        'inmr
        '
        Me.inmr.AutoSize = True
        Me.inmr.Location = New System.Drawing.Point(15, 200)
        Me.inmr.Name = "inmr"
        Me.inmr.Size = New System.Drawing.Size(86, 17)
        Me.inmr.TabIndex = 14
        Me.inmr.Text = "Espelhar laje"
        Me.inmr.UseVisualStyleBackColor = True
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.bpar)
        Me.GroupBox1.Controls.Add(Me.bper)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 131)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(157, 63)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Vigotas em relação à reta"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(147, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Distância de contrabalanço * "
        '
        'inac
        '
        Me.inac.DisplayMember = "0"
        Me.inac.FormattingEnabled = True
        Me.inac.Items.AddRange(New Object() {"22x25", "22x30", "33x12", "33x16", "33x20", "33x25", "40x09", "40x12", "40x16", "40x20", "40x25", "48x12", "48x16", "48x20"})
        Me.inac.Location = New System.Drawing.Point(12, 104)
        Me.inac.Name = "inac"
        Me.inac.Size = New System.Drawing.Size(157, 21)
        Me.inac.TabIndex = 21
        Me.inac.SelectedIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(154, 13)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Abobadilha de Contrabalanço *"
        '
        'indc
        '
        Me.indc.Location = New System.Drawing.Point(12, 65)
        Me.indc.Name = "indc"
        Me.indc.Size = New System.Drawing.Size(157, 20)
        Me.indc.TabIndex = 19
        Me.indc.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 249)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 13)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "* Obrigatório preencher"
        '
        'FormAli
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(181, 271)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.inac)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.indc)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.inmr)
        Me.Controls.Add(Me.pvtype)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.b1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormAli"
        Me.Text = "Spral - Aligeiradas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents b1 As Windows.Forms.Button
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents pvtype As Windows.Forms.ComboBox
    Friend WithEvents inmr As Windows.Forms.CheckBox
    Friend WithEvents bpar As Windows.Forms.RadioButton
    Friend WithEvents bper As Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents inac As Windows.Forms.ComboBox
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents indc As Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
