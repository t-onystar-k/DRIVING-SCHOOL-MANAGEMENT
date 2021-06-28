Imports System.Data.SqlClient
Public Class Form9
    Dim con As New SqlConnection
    Dim cmd, cmd1 As New SqlCommand

    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        con.ConnectionString = "Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database0.mdf;Integrated Security=True"
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
        cmd1.Parameters.Clear() ''important
        cmd2.Parameters.Clear() ''important

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
        cmd2.CommandText = "SELECT * from status where id=@uid"
        cmd2.Parameters.Clear() ''important
        cmd2.Parameters.Add(paramuid)
        dr3 = cmd2.ExecuteReader
        Do While dr3.Read
            Label10.Text = dr3("admin_rev")
        Loop
        dr3.Close()



        If Label1.Text <> "NULL" Then
            Label11.Text = "Applied"
        Else
            Label11.Text = "Not Applied"
        End If

        If IsNumeric(Label7.Text) Then
            label12.Text = "Paid"
        Else
            label12.Text = "Not Paid"
        End If


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        cmd1.Connection = con
        cmd1.Parameters.Clear() ''important

        cmd1.CommandText = "UPDATE status SET admin_rev = @admin_rev WHERE id = @id"
        Dim paraid As New SqlParameter("@id", SqlDbType.VarChar, 15)
        paraid.Value = ComboBox1.SelectedItem
        Dim paradrev As New SqlParameter("@admin_rev", SqlDbType.VarChar, 10)
        If RadioButton1.Checked = True Then
            paradrev.Value = RadioButton1.Text
        ElseIf RadioButton2.Checked = True Then
            paradrev.Value = RadioButton2.Text
        End If

        cmd1.Parameters.Add(paraid)
        cmd1.Parameters.Add(paradrev)

        Dim da1 As New SqlDataAdapter
        da1.InsertCommand = cmd1
        cmd1.ExecuteNonQuery()
        MsgBox("Status Updated")




    End Sub
End Class
