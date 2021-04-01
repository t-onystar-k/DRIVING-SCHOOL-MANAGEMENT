Imports System.Data.SqlClient
Public Class Form3
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dr As SqlDataReader
        con.ConnectionString = "Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\Driving School Management\Driving School Management\Driving School Management\Database0.mdf;Integrated Security=True"
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "Select app_sub,payment_sts,admin_rev from status where id =" + Label8.Text + ""
        dr = cmd.ExecuteReader()
        Do While dr.Read()
            Label2.Text = dr("app_sub")
            Label4.Text = dr("payment_sts")
            Label6.Text = dr("admin_rev")
        Loop
        dr.Close()



    End Sub

End Class