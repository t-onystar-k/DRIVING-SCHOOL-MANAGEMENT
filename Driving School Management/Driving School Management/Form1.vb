Imports System.Data.SqlClient
Public Class Form1
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Private Sub Checkbox1_CheckedChanged(sender As Object, e As EventArgs) Handles Checkbox1.CheckedChanged
        Label1.Text = "USERNAME"
        Label2.Text = "PASSWORD"
        Label3.Visible = True
        Button2.Visible = True


    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim constring As String = "Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\DRIVING-SCHOOL-MANAGEMENT-main\Driving School Management\Driving School Management\Database0.mdf;Integrated Security=True"
        con = New SqlConnection(constring)
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "select * from Reg where uid= @uid and fname = @fname "

        cmd.Parameters.Add("@uid", SqlDbType.VarChar).Value = TextBox1.Text
        cmd.Parameters.Add("@fname", SqlDbType.VarChar).Value = TextBox2.Text
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable()
        adapter.Fill(table)
        If table.Rows.Count() = 0 Then
            MessageBox.Show("invalid Username and Password")
        Else
            MessageBox.Show("Login succesful")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form2.Show()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form3.Show()
    End Sub

    Private Sub Checkbox2_CheckedChanged(sender As Object, e As EventArgs) Handles Checkbox2.CheckedChanged
        Label1.Text = "ADMIN ID"
        Label2.Text = "PASSWORD"
        Label3.Visible = False
        Button2.Visible = False
        Dim admin As New TextBox
        Dim pass As New TextBox

        TextBox1.Name = "admin"
        TextBox2.Name = "pass"

        If admin.Text = "Admin2021" And pass.Text = "2020_2021" Then
            MessageBox.Show("LOGIN SUCCESFUL")
        End If

    End Sub

End Class
