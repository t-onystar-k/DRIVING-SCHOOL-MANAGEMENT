Public Class form5
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Panel6.Controls.Clear()
        Me.Size = New Size(900, 550)
        'centering form
        Me.Location = New Point((Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2)

        With Form3
            .TopLevel = False
            .ControlBox = False
            .Text = ""
            .FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Panel6.Controls.Add(Form3)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Panel6.Controls.Clear()
        Me.Size = New Size(900, 732)
        'centering form
        Me.Location = New Point((Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2)

        With Form2
            .TopLevel = False
            .ControlBox = False
            .Text = ""
            .FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Panel6.Controls.Add(Form2)
            .BringToFront()
            .Show()
        End With
    End Sub

   
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Panel6.Controls.Clear()
        Me.Size = New Size(900, 550)
        'centering form
        Me.Location = New Point((Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2)

        With Form4
            .TopLevel = False
            .ControlBox = False
            .Text = ""
            .FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Panel6.Controls.Add(Form4)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ControlBox = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form1.Show()
        Me.Close()

    End Sub
End Class