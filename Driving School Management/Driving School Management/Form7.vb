Imports System.Data.SqlClient
Public Class Form7
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "Enter Aadhar UID" Or TextBox2.Text = "Enter Password" Then
            MsgBox("Please enter necessary details")
        ElseIf TextBox2.Text <> TextBox3.Text Then
            MsgBox("Password doesn't match confirm password!")
        Else
            Dim constring As String = "Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\DRIVING-SCHOOL-MANAGEMENT-main\Driving School Management\Driving School Management\Database0.mdf;Integrated Security=True"
            con = New SqlConnection(constring)
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "INSERT INTO users(aadhar,password)values(@aadhar,@password)"
            Dim paramaadhar As New SqlParameter("@aadhar", SqlDbType.VarChar, 15)
            paramaadhar.Value = TextBox1.Text
            Dim parampassword As New SqlParameter("@password", SqlDbType.VarChar, 20)
            parampassword.Value = TextBox2.Text


            cmd.Parameters.Add(paramaadhar)
            cmd.Parameters.Add(parampassword)


            Dim da As New SqlDataAdapter
            da.InsertCommand = cmd
            da.InsertCommand.ExecuteNonQuery()
            MsgBox("Registered succesfully")
            Form1.Show()
            Me.Close()
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.Show()
        Me.Close()
    End Sub


    ''Textbox help Text
    Private Sub TextBox1_MouseEnter(sender As Object, e As EventArgs) Handles TextBox1.MouseEnter
        If TextBox1.Text = "Enter Aadhar UID" Then
            TextBox1.Text = ""
            TextBox1.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TextBox1_MouseLeave(sender As Object, e As EventArgs) Handles TextBox1.MouseLeave
        If TextBox1.Text = "" Then
            TextBox1.Text = "Enter Aadhar UID"
            TextBox1.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If TextBox1.Text = "Enter Aadhar UID" Or TextBox1.Text = "Enter Admin ID" Then
            TextBox1.Text = ""
            TextBox1.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TextBox2_MouseEnter(sender As Object, e As EventArgs) Handles TextBox2.MouseEnter
        If TextBox2.Text = "Enter Password" Then
            TextBox2.Text = ""
            TextBox2.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TextBox2_MouseLeave(sender As Object, e As EventArgs) Handles TextBox2.MouseLeave
        If TextBox2.Text = "" Then
            TextBox2.Text = "Enter Password"
            TextBox2.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If TextBox2.Text = "Enter Password" Then
            TextBox2.Text = ""
            TextBox2.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TextBox3_MouseEnter(sender As Object, e As EventArgs) Handles TextBox3.MouseEnter
        If TextBox3.Text = "Confirm Password" Then
            TextBox3.Text = ""
            TextBox3.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TextBox3_MouseLeave(sender As Object, e As EventArgs) Handles TextBox3.MouseLeave
        If TextBox3.Text = "" Then
            TextBox3.Text = "Confirm Password"
            TextBox3.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If TextBox3.Text = "Confirm Password" Then
            TextBox3.Clear()
        End If
        TextBox3.ForeColor = Color.Black
        TextBox3.PasswordChar = "*"
    End Sub
End Class