Imports System.Data.SqlClient
Public Class Form4
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Payment"
        Label8.Text = form5.Label2.Text
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click



        If TextBox1.Text = "" Then
            Label7.Text = "Please Fill in necessary details !"
            Label7.Visible = True
            Label7.Left = (Label1.Parent.Width - Label1.Width) / 2

            '' if radio btn 1 checked
        ElseIf RadioButton1.Checked = True Then
            If TextBox3.Text.Length <> 16 Then
                Label7.Text = "Please Fill in valid 16-digit card number !"
                Label7.Visible = True
                Label7.Left = (Label1.Parent.Width - Label1.Width) / 2

            ElseIf TextBox3.Text.Length <> 3 Then
                Label7.Text = "Please Fill in valid cvv !"
                Label7.Visible = True
                Label7.Left = (Label1.Parent.Width - Label1.Width) / 2
            End If



        Else
            Label7.Hide()
            Dim constrig As String = "Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\Driving School Management\Driving School Management\Driving School Management\Database0.mdf;Integrated Security=True"
            con = New SqlConnection(constrig)
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "INSERT INTO pay(Id,cash,cardno,cardname,uidno)values(@id,@cash,@cardno,@cardname,@uidno)"
            Dim parid As New SqlParameter("@Id", SqlDbType.VarChar, 15)
            parid.Value = Label8.Text
            Dim parcash As New SqlParameter("@cash", SqlDbType.VarChar, 7)
            parcash.Value = Label6.Text
            Dim parcardno As New SqlParameter("@cardno", SqlDbType.VarChar, 20)
            parcardno.Value = TextBox1.Text
            Dim parcardname As New SqlParameter("@cardname", SqlDbType.VarChar, 50)
            parcardname.Value = TextBox2.Text
            Dim paruidno As New SqlParameter("@uidno", SqlDbType.VarChar, 20)
            paruidno.Value = TextBox1.Text

            cmd.Parameters.Add(parid)
            cmd.Parameters.Add(parcash)
            cmd.Parameters.Add(parcardno)
            cmd.Parameters.Add(parcardname)
            cmd.Parameters.Add(paruidno)

            Dim da As New SqlDataAdapter
            da.InsertCommand = cmd
            da.InsertCommand.ExecuteNonQuery()
            MsgBox("Payment Successful")
            TextBox1.Text = ""
            TextBox2.Text = ""

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
        Label9.Visible = False
        TextBox3.Visible = False
    End Sub
    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If Asc(e.KeyChar) <> 8 Then '' accept only numbers
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Asc(e.KeyChar) <> 8 Then '' accept only numbers
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
End Class