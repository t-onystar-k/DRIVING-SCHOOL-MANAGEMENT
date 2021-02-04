Public Class Form1
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Private Sub form1(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Visible = False
        TextBox2.Visible = False
        Label1.Visible = False
        Label2.Visible = False

        con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\test1\test1\Database1.mdf;Integrated Security=True"
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "input aadhar id"
        Dim dr1 As SqlDataReader
        Dim dr2 As SqlDataReader
        dr1 = cmd.ExecuteReader
        Do While dr1.Read And dr2.Read
            TextBox1.Text.Add(dr1("uid"))
            TextBox2.Text.Add(dr2("name"))

        Loop
        dr1.Close()
        dr2.Close()
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        Label1.Text = "Aadhar Number"
        Label2.Text = "Name"
        TextBox1.Visible = True
        TextBox2.Visible = True
        Label1.Visible = True
        Label2.Visible = True


    End Sub
    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        Label1.Text = "Username"
        Label2.Text = "Password"
        TextBox1.Visible = True
        TextBox2.Visible = True
        Label1.Visible = True
        Label2.Visible = True
    End Sub


End Class

