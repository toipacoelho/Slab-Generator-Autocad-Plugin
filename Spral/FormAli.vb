Public Class FormAli

    Private pv As String
    Private dc As Double
    Private ac As String
    Private dir As Boolean
    Private mir As Boolean

    Private Sub b1_Click(sender As Object, e As EventArgs) Handles b1.Click
        pv = pvtype.SelectedItem.ToString
        If indc.Text IsNot Nothing Then
            dc = Convert.ToDouble(indc.Text) / 100
            ac = inac.SelectedItem.ToString
        Else
            ac = Nothing
            dc = 0
        End If
        dir = bpar.Checked
        mir = inmr.CheckState

        Me.Close()

        Dim Laje As Spral.LajeAligeirada = New Spral.LajeAligeirada
        Laje.lajeAligeirada(pv, dc, ac, dir, mir)



    End Sub

End Class