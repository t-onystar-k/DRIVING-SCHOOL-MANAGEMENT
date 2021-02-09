Imports System.Data.SqlClient

Public Class Form1
    Dim LoginIndex As Integer

    Dim con As New SqlConnection
    Dim cmd As New SqlCommand

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RadioButton1.Checked = True
        Label4.Visible = False
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        Label1.Text = "Aadhar UID :"
        LoginIndex = 1
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        Label1.Text = "Hospital ID :"
        LoginIndex = 2
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim UserId, Password, AuthPass As String

        UserId = TextBox1.Text


        Password = TextBox2.Text

        If LoginIndex = 1 Then
            con.ConnectionString = "Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Bobin\Desktop\Vb.Net Project\Health-Tracker\HealthTracker\HealthTracker\Database1.mdf;Integrated Security=True"
            con.Open()

            cmd.Connection = con
            cmd.CommandText = "select Password from UserAuth where UserId=@UserId"

            Dim paramId As New SqlParameter("@UserId", SqlDbType.VarChar, 50)
            paramId.Value = UserId
            cmd.Parameters.Add(paramId)

            Dim dr1 As SqlDataReader
            dr1 = cmd.ExecuteReader
            Do While dr1.Read
                AuthPass = dr1("Password")
            Loop
            dr1.Close()

            If Password = AuthPass Then

                Form2.userId = UserId 'to pass userid to form2
                Form2.Show()


            Else
                Label4.Visible = True
            End If

            con.Close()

        ElseIf LoginIndex = 2 Then
            con.ConnectionString = "Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Bobin\Desktop\Vb.Net Project\Health-Tracker\HealthTracker\HealthTracker\Database1.mdf;Integrated Security=True"
            con.Open()

            cmd.Connection = con
            cmd.CommandText = "select Password from HospitalAuth where HospitalId=@UserId"

            Dim paramId As New SqlParameter("@UserId", SqlDbType.VarChar, 50)
            paramId.Value = UserId
            cmd.Parameters.Add(paramId)

            Dim dr2 As SqlDataReader
            dr2 = cmd.ExecuteReader
            Do While dr2.Read
                AuthPass = dr2("Password")
            Loop
            dr2.Close()

            If Password = AuthPass Then

                Form3.userId = UserId 'to pass userid to form2
                Form3.Show()

            Else
                Label4.Visible = True
            End If

            con.Close()
        End If


    End Sub
End Class
