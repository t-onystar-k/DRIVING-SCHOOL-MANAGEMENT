Imports System.Data.SqlClient
Public Class Form4
    Dim con As New SqlConnection
    Dim cmd, cmd1 As New SqlCommand
    Dim sts1 As String
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Payment"
        sts1 = "Not Paid"
        Label8.Text = form5.Label2.Text
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ''opens connection to db
        con.Close()
        con.ConnectionString = "Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\DRIVING-SCHOOL-MANAGEMENT\Driving School Management\Driving School Management\Database0.mdf;Integrated Security=True"
        con.Open()
        '' DO NOT DELETE ABOVE CODE

        If TextBox1.Text = "" Then
            Label7.Text = "Please Fill in necessary details !"
            Label7.Visible = True
            Label7.Left = (Label1.Parent.Width - Label1.Width) / 2

            '' cardno validatoion
        ElseIf RadioButton1.Checked = True And TextBox1.Text.Length <> 16 Then

            Label7.Text = "Please Fill in valid 16-digit card number !"
            Label7.Visible = True
            Label7.Left = (Label1.Parent.Width - Label1.Width) / 2

            ''cvv validation
        ElseIf RadioButton1.Checked = True And TextBox3.Text.Length <> 3 Then
            Label7.Text = "Please Fill in valid cvv !"
            Label7.Visible = True
            Label7.Left = (Label1.Parent.Width - Label1.Width) / 2


        Else
        cmd.Connection = con
        cmd.Parameters.Clear() ''important

        If RadioButton1.Checked = True Then ''if card is selected
            cmd.CommandText = "UPDATE pay SET cash = @cash,cardno = @cardno, cardname = @cardname, cvv = @cvv WHERE Id = @id"
        ElseIf RadioButton2.Checked = True Then ''if upi is selected
            cmd.CommandText = "UPDATE pay SET cash = @cash, upi = @upi WHERE Id = @id"
        End If

        Dim parid As New SqlParameter("@Id", SqlDbType.VarChar, 15)
        parid.Value = Label8.Text
        Dim parcash As New SqlParameter("@cash", SqlDbType.VarChar, 7)
        parcash.Value = Label6.Text
        Dim parcardno As New SqlParameter("@cardno", SqlDbType.VarChar, 20)
        parcardno.Value = TextBox1.Text
        Dim parcardname As New SqlParameter("@cardname", SqlDbType.VarChar, 50)
        parcardname.Value = TextBox2.Text
        Dim parupi As New SqlParameter("@upi", SqlDbType.VarChar, 20)
        parupi.Value = TextBox1.Text
        Dim parcvv As New SqlParameter("@cvv", SqlDbType.VarChar, 5)
        parcvv.Value = TextBox3.Text

        cmd.Parameters.Add(parid)
        cmd.Parameters.Add(parcash)
        cmd.Parameters.Add(parcardno)
        cmd.Parameters.Add(parcardname)
        cmd.Parameters.Add(parupi)
        cmd.Parameters.Add(parcvv)

        cmd.ExecuteNonQuery()

        MsgBox("Payment Successful")
        sts1 = "paid"

        End If

        cmd1.Connection = con
        cmd1.Parameters.Clear() ''important
        cmd1.CommandText = "UPDATE status SET payment_sts = @payment_sts where id = @id"
        Dim paramid As New SqlParameter("@id", SqlDbType.VarChar, 15)
        paramid.Value = Label8.Text
        Dim parsts As New SqlParameter("@payment_sts", SqlDbType.VarChar, 10)
        parsts.Value = sts1

        cmd1.Parameters.Add(parsts)
        cmd1.Parameters.Add(paramid)

        cmd1.ExecuteNonQuery()


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
        TextBox3.Visible = True
        Label9.Visible = True
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""

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
        If RadioButton1.Checked = True Then ''only if card selected
            If Asc(e.KeyChar) <> 8 Then '' accept only numbers
                If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                    e.Handled = True
                End If
            End If
        End If
    End Sub
End Class