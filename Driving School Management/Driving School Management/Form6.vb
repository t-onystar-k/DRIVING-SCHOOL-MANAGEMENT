Imports System.Data.SqlClient
Public Class form6
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim counter = 1
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        counter = counter + 1
        Me.Size = New Size(900, 540)

        With Form3
            .TopLevel = False
            .ControlBox = False
            .FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Panel6.Controls.Add(Form3)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If counter <> 1 Then
            counter = 1
            Form3.Close()
            Me.Size = New Size(900, 662)
        End If

    End Sub



    Private Sub form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.ConnectionString = "Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\Driving School Management\Driving School Management\Driving School Management\Database0.mdf;Integrated Security=True"
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "select uid from reg"
        Dim dr1 As SqlDataReader
        dr1 = cmd.ExecuteReader
        Do While dr1.Read
            ComboBox1.Items.Add(dr1("uid"))
        Loop
        dr1.Close()
    End Sub


    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim dr2 As SqlDataReader
        Dim cmd2 As New SqlCommand
        cmd2.Connection = con
        cmd2.CommandText = "select * from reg where uid=" & "(@uid)"
        Dim parameterstate As New SqlParameter("@uid", SqlDbType.VarChar, 15)
        parameterstate.Direction = ParameterDirection.Input
        parameterstate.Value = ComboBox1.SelectedItem
        cmd2.Parameters.Add(parameterstate)
        dr2 = cmd2.ExecuteReader
        Do While dr2.Read
            TextBox1.Text = dr2("fname")
            TextBox2.Text = dr2("mname")
            TextBox3.Text = dr2("lname")
            TextBox4.Text = dr2("f_ad")
            TextBox5.Text = dr2("m_ad")
            TextBox6.Text = dr2("l_ad")
            TextBox7.Text = dr2("pin")
            TextBox8.Text = dr2("a_pic")
            TextBox9.Text = dr2("b_c")
            TextBox10.Text = dr2("sign")
            TextBox11.Text = dr2("blood")
            TextBox12.Text = dr2("email")
            TextBox13.Text = dr2("phone")
            TextBox14.Text = dr2("d_c")
            TextBox15.Text = dr2("gen")

        Loop
        dr2.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim obj As New Form8
        obj.str = TextBox8.Text
        obj.Show()


    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim obj As New Form8
        obj.str = TextBox9.Text
        obj.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim obj As New Form8
        obj.str = TextBox10.Text
        obj.Show()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim obj As New Form8
        obj.str = TextBox14.Text
        obj.Show()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If PrintDialog1.ShowDialog = DialogResult.OK Then
            PrintDocument1.Print()
        End If


    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim dm As New Bitmap(Me.Panel6.Width, Me.Panel6.Height)
        Panel6.DrawToBitmap(dm, New Rectangle(0, 0, Me.Panel6.Width, Me.Panel6.Height))
        e.Graphics.DrawImage(dm, 0, 0)
        Dim aPS As New PageSetupDialog
        aPS.Document = PrintDocument1
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form1.Show()
        Me.Close()

    End Sub
End Class