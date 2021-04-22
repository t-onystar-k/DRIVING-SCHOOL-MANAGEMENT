Imports System.Data.SqlClient
Public Class Form11
    Dim con As New SqlConnection
    Dim table As New DataTable

    Private Sub Form11_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Detailed Report"

        ''opens connection to db
        con.ConnectionString = "Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\DRIVING-SCHOOL-MANAGEMENT\Driving School Management\Driving School Management\Database0.mdf;Integrated Security=True"
        con.Open()
        '' DO NOT DELETE ABOVE CODE

        Dim da As New SqlDataAdapter("SELECT * FROM status", con)

        da.Fill(table)

        DataGridView1.DataSource = table

        DataGridView1.Columns(0).HeaderText = "User Id"
        DataGridView1.Columns(1).HeaderText = "Payment Status"
        DataGridView1.Columns(2).HeaderText = "Admin Review"
        DataGridView1.Columns(3).HeaderText = "Application Submission"

    End Sub
End Class