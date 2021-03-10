Public Class form5
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Panel6.Controls.Clear()
        Me.Size = New Size(900, 750)

        With Form2
            .TopLevel = False
            .ControlBox = False
            Panel6.Controls.Add(Form2)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Panel6.Controls.Clear()
        Me.Size = New Size(900, 550)

        With Form3
            .TopLevel = False
            .ControlBox = False
            Panel6.Controls.Add(Form3)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Panel6.Controls.Clear()
        Me.Size = New Size(900, 580)

        With Form4
            .TopLevel = False
            .ControlBox = False
            Panel6.Controls.Add(Form4)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class