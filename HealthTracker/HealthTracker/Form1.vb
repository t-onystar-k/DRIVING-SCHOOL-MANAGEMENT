Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If RadioButton1.Checked = True Then
            Form2.Show()
        End If
        If RadioButton2.Checked = True Then
            Form3.Show()
        End If
    End Sub
End Class
