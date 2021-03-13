Public Class Form4
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Payment"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If TextBox1.Text = "" Then
            Label7.Show()
        Else
            Label7.Hide()
            MsgBox("Payment Successful")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim AmountPayable = 2000

        If CheckBox1.Checked = True Then
            AmountPayable += 5000
        End If
        If CheckBox2.Checked = True Then
            AmountPayable += 4000
        End If
        If CheckBox3.Checked = True Then
            AmountPayable += 3800
        End If
        If CheckBox4.Checked = True Then
            AmountPayable += 5500
        End If

        Label6.Text = AmountPayable
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        Label4.Text = "Card Number :"
        Label5.Visible = True
        TextBox2.Visible = True
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        Label4.Text = "Upi ID"
        Label5.Visible = False
        TextBox2.Visible = False
    End Sub
End Class