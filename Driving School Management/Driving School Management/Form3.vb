Imports System.Data.SqlClient
Public Class Form3
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ''text aligning
        Label1.Left = (Label1.Parent.Width - Label1.Width) / 2
        Label3.Left = (Label3.Parent.Width - Label3.Width) / 2
        Label5.Left = (Label5.Parent.Width - Label5.Width) / 2
        ''

        Dim dr As SqlDataReader
        con.ConnectionString = "Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\DRIVING-SCHOOL-MANAGEMENT\Driving School Management\Driving School Management\Database0.mdf;Integrated Security=True"
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "Select app_sub,payment_sts,admin_rev from status where id = @uid"
        cmd.Parameters.Clear() ''important

        Dim paramid As New SqlParameter("@uid", SqlDbType.VarChar, 15)
        paramid.Value = form5.Label2.Text
        cmd.Parameters.Add(paramid)

        dr = cmd.ExecuteReader()
        Do While dr.Read()
            Label2.Text = dr("app_sub")
            Label2.Left = (Label2.Parent.Width - Label2.Width) / 2

            Label4.Text = dr("payment_sts")
            Label4.Left = (Label4.Parent.Width - Label4.Width) / 2

            Label6.Text = dr("admin_rev")
            Label6.Left = (Label6.Parent.Width - Label6.Width) / 2

        Loop
        dr.Close()

        If Label6.Text = "Reviewed" Then
            Label7.Text = "Your Application have been Accepted !"
            Label7.ForeColor = Color.FromArgb(136, 216, 176)
            Label7.Left = (Label7.Parent.Width - Label7.Width) / 2
        ElseIf Label6.Text = "Rejected" Then
            Label7.Text = "Your Application has been Rejected ! Please resubmit application with correct details !"
            Label7.ForeColor = Color.FromArgb(255, 111, 105)
            Label7.Left = (Label7.Parent.Width - Label7.Width) / 2
        Else
            Label7.Text = "Your Application is pending review ! Please be patient."
            Label7.ForeColor = Color.White
            Label7.Left = (Label7.Parent.Width - Label7.Width) / 2
        End If



    End Sub
End Class