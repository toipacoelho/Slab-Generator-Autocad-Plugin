Public Class FormAlv

    Private pv As String
    Private dir As Boolean
    Private mir As Boolean

    Private Sub b1_Click(sender As Object, e As EventArgs) Handles b1.Click
        pv = pvtype.SelectedItem.ToString
        dir = bpar.Checked
        mir = inmr.CheckState

        Me.Close()

        Dim Laje As Spral.LajeAlveolar = New Spral.LajeAlveolar
        Laje.lajeAlveolar(pv, dir, mir)
    End Sub
End Class