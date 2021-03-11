Imports System.Data.SqlClient
Public Class Form1
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim con1 As New SqlConnection
    Dim cmd1 As New SqlCommand

    Private Sub Checkbox1_CheckedChanged(sender As Object, e As EventArgs) Handles Checkbox1.CheckedChanged
        Label3.Visible = True
        Label4.Visible = True
    End Sub
    Private Sub Checkbox2_CheckedChanged(sender As Object, e As EventArgs) Handles Checkbox2.CheckedChanged
        Label3.Visible = False
        Label4.Visible = False
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        ''IF Individual Login selected
        If Checkbox1.Checked = True Then
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
                form5.Show()
                Me.Refresh()
                Me.Hide()
                TextBox1.Text = ""
                TextBox2.Text = ""


            Else
                MessageBox.Show("invalid Username and Password")
                Me.Controls.Clear() 'removes all the controls on the form
                InitializeComponent() 'load all the controls again

            End If
        Else
            ''IF Admin Login Selected
            If TextBox1.Text = "Admin2021" And TextBox2.Text = "pass2021" Then
                MessageBox.Show("Logged in succesfully")
                form6.Show()
                Me.Hide()
            Else
                MessageBox.Show("invalid Username and Password")
                Me.Controls.Clear() 'removes all the controls on the form
                InitializeComponent() 'load all the controls again
            End If
        End If
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Form7.Show()
        Me.Hide()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ControlBox = False
        Label3.Visible = True
        Label4.Visible = True


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked = True Then
            TextBox2.PasswordChar = ""
        Else
            TextBox2.PasswordChar = "*"
        End If
    End Sub



    ''Textbox help Text


    Private Sub TextBox1_MouseEnter(sender As Object, e As EventArgs) Handles TextBox1.MouseEnter
        If TextBox1.Text = "Enter Aadhar UID" Or TextBox1.Text = "Enter Admin ID" Then
            TextBox1.Text = ""
            TextBox1.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TextBox1_MouseLeave(sender As Object, e As EventArgs) Handles TextBox1.MouseLeave
        If TextBox1.Text = "" Then
            If Checkbox1.Checked = True Then
                TextBox1.Text = "Enter Aadhar UID"
            Else
                TextBox1.Text = "Enter Admin ID"
            End If
            TextBox1.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub TextBox2_MouseEnter(sender As Object, e As EventArgs) Handles TextBox2.MouseEnter
        If TextBox2.Text = "Enter Password" Then
            TextBox2.Text = ""
            TextBox2.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TextBox2_MouseLeave(sender As Object, e As EventArgs) Handles TextBox2.MouseLeave
        If TextBox2.Text = "" Then
            TextBox2.Text = "Enter Password"
            TextBox2.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If TextBox1.Text = "Enter Aadhar UID" Or TextBox1.Text = "Enter Admin ID" Then
            TextBox1.Text = ""
            TextBox1.ForeColor = Color.Black
        End If
    End Sub
    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If TextBox2.Text = "Enter Password" Then
            TextBox2.Text = ""
            TextBox2.ForeColor = Color.Black
            TextBox2.PasswordChar = "*"
        End If
    End Sub
End Class
