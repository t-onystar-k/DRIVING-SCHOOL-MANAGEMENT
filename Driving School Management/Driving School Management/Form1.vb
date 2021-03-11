Imports System.Data.SqlClient
Public Class Form1
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim con1 As New SqlConnection
    Dim cmd1 As New SqlCommand
    Private Sub Checkbox1_CheckedChanged(sender As Object, e As EventArgs) Handles Checkbox1.CheckedChanged
        Label1.Text = "USERNAME"
        Label2.Text = "PASSWORD"
        Label3.Visible = True
        Button2.Visible = True
        Button1.Visible = True
        Button4.Visible = False


    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim constring As String = "Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\DRIVING-SCHOOL-MANAGEMENT-main\Driving School Management\Driving School Management\Database0.mdf;Integrated Security=True"
        con = New SqlConnection(constring)
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "select * from users where aadhar= @uid and password = @password "

        cmd.Parameters.Add("@uid", SqlDbType.VarChar).Value = TextBox1.Text
        cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = TextBox2.Text
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable()
        adapter.Fill(table)
        If table.Rows.Count() <> 0 Then
            MessageBox.Show("Login succesful")
            Form5.Show()
            Me.Refresh()
            Me.Hide()
            TextBox1.Text = ""
            TextBox2.Text = ""


        Else
            MessageBox.Show("invalid Username and Password")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form7.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form3.Show()
        Me.Hide()
    End Sub

    Private Sub Checkbox2_CheckedChanged(sender As Object, e As EventArgs) Handles Checkbox2.CheckedChanged
        Label1.Text = "ADMIN ID"
        Label2.Text = "PASSWORD"
        Label3.Visible = False
        Button2.Visible = False
        Button1.Visible = False
        Button4.Visible = True




    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox1.Text = "Admin2021" And TextBox2.Text = "pass2021" Then
            MessageBox.Show("Logged in succesfully")
            form6.Show()
            Me.Hide()
        End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
