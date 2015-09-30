Public Class FormCob

    Private telha As Double
    Private dir As Boolean
    Private mir As Boolean

    Private Sub b1_Click(sender As Object, e As EventArgs) Handles b1.Click
        Dir = bpar.Checked
        mir = inmr.CheckState
        telha = Convert.ToDouble(indc.Text) / 100

        Me.Close()

        Dim Laje As Spral.Coberturas = New Spral.Coberturas
        Laje.Coberturas(telha, dir, mir)
    End Sub
End Class