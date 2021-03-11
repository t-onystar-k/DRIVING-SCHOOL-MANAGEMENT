Public Class form6
    Dim counter = 1
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        counter = counter + 1
        Panel6.Controls.Clear()
        Me.Size = New Size(900, 540)

        With Form3
            .TopLevel = False
            .ControlBox = False
            .FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Panel6.Controls.Add(Form3)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If counter <> 1 Then
            counter = 1
            Me.Controls.Clear() 'removes all the controls on the form
            InitializeComponent() 'load all the controls again
        End If

    End Sub
End Class