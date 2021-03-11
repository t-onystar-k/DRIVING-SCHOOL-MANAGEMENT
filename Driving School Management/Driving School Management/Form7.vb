Imports System.Data.SqlClient
Public Class Form7
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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

    End Sub

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class