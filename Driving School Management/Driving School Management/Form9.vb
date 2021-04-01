Imports System.Data.SqlClient
Public Class Form9
    Dim con As New SqlConnection
    Dim cmd, cmd1 As New SqlCommand

    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        con.ConnectionString = "Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\DRIVING-SCHOOL-MANAGEMENT\Driving School Management\Driving School Management\Database0.mdf;Integrated Security=True"
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "select uid from Reg"
        Dim dr1 As SqlDataReader
        dr1 = cmd.ExecuteReader
        Do While dr1.Read
            ComboBox1.Items.Add(dr1("uid"))
        Loop
        dr1.Close()


    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim dr2, dr3 As SqlDataReader
        Dim cmd1 As New SqlCommand '
        Dim cmd2 As New SqlCommand
        Dim a As String = ComboBox1.SelectedItem
        cmd1.Connection = con
        cmd2.Connection = con
        cmd1.CommandText = "Select fname,mname,lname from reg where uid =" & "(@uid)"
        cmd2.CommandText = "select cash,cardno,cardname,upi from pay where id=" & "(@uid)"
        Dim paramid As New SqlParameter("@uid", SqlDbType.VarChar, 15)
        paramid.Direction = ParameterDirection.Input
        paramid.Value = a
        cmd1.Parameters.Add(paramid)
        dr2 = cmd1.ExecuteReader
        Do While dr2.Read
            Label2.Text = dr2("fname")
            Label3.Text = dr2("mname")
            Label4.Text = dr2("lname")

        Loop
        dr2.Close()

        Dim paramuid As New SqlParameter("@uid", SqlDbType.VarChar, 15)
        paramuid.Direction = ParameterDirection.Input
        paramuid.Value = a
        cmd2.Parameters.Add(paramuid)
        dr3 = cmd2.ExecuteReader
        Do While dr3.Read
            Label7.Text = dr3("cash")

        Loop
        dr3.Close()



        If Label1.Text <> "NULL" Then
            TextBox1.Text = "Applied"
        Else
            TextBox1.Text = "Not Applied"
        End If

        If IsNumeric(Label7.Text) Then
            TextBox2.Text = "Paid"
        Else
            TextBox2.Text = "Not Paid"
        End If





    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Label10.Text = "Reviewed"
        Else
            Label10.Text = "Not Reviewed"
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        cmd1.Connection = con

        cmd1.CommandText = "insert into status(payment_sts,admin_rev,app_sub)values(@payment_sts,@admin_rev,@app_sub) where id=" + ComboBox1.SelectedItem + ""
        Dim parpsts As New SqlParameter("@payment_sts", SqlDbType.VarChar, 10)
        parpsts.Value = TextBox2.Text
        Dim paradrev As New SqlParameter("@admin_rev", SqlDbType.VarChar, 10)
        paradrev.Value = Label10.Text
        Dim parapsub As New SqlParameter("@app_sub", SqlDbType.VarChar, 10)
        parapsub.Value = TextBox1.Text

        cmd1.Parameters.Add(parapsub)
        cmd1.Parameters.Add(paradrev)
        cmd1.Parameters.Add(parpsts)

        Dim da1 As New SqlDataAdapter
        da1.InsertCommand = cmd1
        cmd1.ExecuteNonQuery()
        MsgBox("Status Updated")




    End Sub
End Class
