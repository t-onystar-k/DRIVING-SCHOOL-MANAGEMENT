Public Class Form8
    Public Property str As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.AxAcroPDF1.src = str
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class