Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Public Class Form2
    Dim con, con1 As New SqlConnection
    Dim cmd, cmd1 As New SqlCommand

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim OpenFileDialog1 As New OpenFileDialog
        OpenFileDialog1.InitialDirectory = "D:\"
        OpenFileDialog1.RestoreDirectory = True
        OpenFileDialog1.ShowDialog()
        If OpenFileDialog1.FileName.Length = 0 Then
        Else
            TextBox12.Text = System.IO.Path.GetFullPath(OpenFileDialog1.FileName)
        End If

    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim pict As String
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            pict = OpenFileDialog1.FileName
            PictureBox1.ImageLocation = pict

        End If


    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim OpenFileDialog1 As New OpenFileDialog
        OpenFileDialog1.InitialDirectory = "D:\"
        OpenFileDialog1.RestoreDirectory = True
        OpenFileDialog1.ShowDialog()
        If OpenFileDialog1.FileName.Length = 0 Then
        Else
            TextBox10.Text = System.IO.Path.GetFullPath(OpenFileDialog1.FileName)
        End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim OpenFileDialog1 As New OpenFileDialog
        OpenFileDialog1.InitialDirectory = "D:\"
        OpenFileDialog1.RestoreDirectory = True
        OpenFileDialog1.ShowDialog()
        If OpenFileDialog1.FileName.Length = 0 Then
        Else
            TextBox11.Text = System.IO.Path.GetFullPath(OpenFileDialog1.FileName)
        End If
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        Dim OpenFileDialog1 As New OpenFileDialog
        OpenFileDialog1.InitialDirectory = "D:\"
        OpenFileDialog1.RestoreDirectory = True
        OpenFileDialog1.ShowDialog()
        If OpenFileDialog1.FileName.Length = 0 Then
        Else
            TextBox15.Text = System.IO.Path.GetFullPath(OpenFileDialog1.FileName)
        End If
    End Sub
    Function IsValidEmailFormat(ByVal s As String) As Boolean
        Dim pattern As String
        pattern = "^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"

        If Regex.IsMatch(s, pattern) Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        ''''''' DATA VALIDATION - START
        Label1.Visible = False

            ''aadhar uid
        If Not IsNumeric(TextBox13.Text) Or TextBox13.Text.Length <> 12 Then
            Label1.Text = "Aadhaar uid must be 12-digit numeric value !"
            Label1.Left = (Label1.Parent.Width - Label1.Width) / 2
            Label1.Visible = True

            ''no photo uploaded
        ElseIf PictureBox1.Image Is Nothing Then
            Label1.Text = "Please upload your photo."
            Label1.Visible = True
            Label1.Left = (Label1.Parent.Width - Label1.Width) / 2

            ''date of birth
        ElseIf System.DateTime.Now.Year - DateTimePicker1.Value.Year < 18 Then '' checks age
            Label1.Text = "You Should be atleast 18yo to apply !"
            Label1.Visible = True
            Label1.Left = (Label1.Parent.Width - Label1.Width) / 2

            ''if any details left unfilled
        ElseIf TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Or TextBox8.Text = "" Or TextBox9.Text = "" Or TextBox10.Text = "" Or TextBox12.Text = "" Or TextBox13.Text = "" Or TextBox14.Text = "" Or TextBox15.Text = "" Then
            Label1.Text = "Please Fill in all details !"
            Label1.Visible = True
            Label1.Left = (Label1.Parent.Width - Label1.Width) / 2

            ''phone number length
        ElseIf TextBox14.Text.Length <> 10 Or Not IsNumeric(TextBox14.Text) Or TextBox14.Text < 1000000000 Then
            Label1.Text = "Please enter a valid 10 digit phone number."
            Label1.Visible = True
            Label1.Left = (Label1.Parent.Width - Label1.Width) / 2

            ''gender
        ElseIf ComboBox1.SelectedIndex = -1 Then
            Label1.Text = "Please Fill in all details !"
            Label1.Visible = True
            Label1.Left = (Label1.Parent.Width - Label1.Width) / 2

            ''email format
        ElseIf IsValidEmailFormat(TextBox9.Text) = False Then
            Label1.Text = "Invalid Email format"
            Label1.Visible = True
            Label1.Left = (Label1.Parent.Width - Label1.Width) / 2

            ''pin number
        ElseIf TextBox7.Text.Length <> 6 Or TextBox7.Text < 100000 Or Not IsNumeric(TextBox7.Text) Then
            Label1.Text = "Invalid PIN"
            Label1.Visible = True
            Label1.Left = (Label1.Parent.Width - Label1.Width) / 2

            '' eye cert
        ElseIf RadioButton1.Checked = True And TextBox11.Text = "" Then
            Label1.Text = "Please upload eye-test result!"
            Label1.Visible = True
            Label1.Left = (Label1.Parent.Width - Label1.Width) / 2

            ''''''' DATA VALIDATION - END
        Else
            Dim constring As String = "Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\DRIVING-SCHOOL-MANAGEMENT\Driving School Management\Driving School Management\Database0.mdf;Integrated Security=True"
            con = New SqlConnection(constring)
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "INSERT INTO Reg(uid,fname,mname,lname,f_ad,m_ad,l_ad,pin,pic,a_pic,b_c,d_c,phone,email,blood,gen,sign)values(@uid,@fname,@mname,@lname,@f_ad,@m_ad,@l_ad,@pin,@pic,@a_pic,@b_c,@d_c,@phone,@email,@blood,@gen,@sign)"
            Dim paramuid As New SqlParameter("@uid", SqlDbType.VarChar, 15)
            paramuid.Value = TextBox13.Text
            Dim paramfname As New SqlParameter("@fname", SqlDbType.VarChar, 20)
            paramfname.Value = TextBox1.Text
            Dim parammname As New SqlParameter("@mname", SqlDbType.VarChar, 20)
            parammname.Value = TextBox2.Text
            Dim paramlname As New SqlParameter("@lname", SqlDbType.VarChar, 20)
            paramlname.Value = TextBox3.Text
            Dim paramf_ad As New SqlParameter("@f_ad", SqlDbType.VarChar, 25)
            paramf_ad.Value = TextBox4.Text
            Dim paramm_ad As New SqlParameter("@m_ad", SqlDbType.VarChar, 25)
            paramm_ad.Value = TextBox5.Text
            Dim paraml_ad As New SqlParameter("@l_ad", SqlDbType.VarChar, 25)
            paraml_ad.Value = TextBox6.Text
            Dim parampin As New SqlParameter("@pin", SqlDbType.NChar, 10)
            parampin.Value = TextBox7.Text
            Dim parampic As New SqlParameter("@pic", SqlDbType.VarChar, 230)
            parampic.Value = PictureBox1.ImageLocation
            Dim parama_pic As New SqlParameter("@a_pic", SqlDbType.VarChar, 230)
            parama_pic.Value = TextBox12.Text
            Dim paramb_c As New SqlParameter("@b_c", SqlDbType.VarChar, 230)
            paramb_c.Value = TextBox10.Text
            Dim paramd_c As New SqlParameter("@d_c", SqlDbType.VarChar, 230)
            paramd_c.Value = TextBox11.Text
            Dim paramphone As New SqlParameter("@phone", SqlDbType.VarChar, 230)
            paramphone.Value = TextBox14.Text
            Dim paramemail As New SqlParameter("@email", SqlDbType.VarChar, 230)
            paramemail.Value = TextBox9.Text
            Dim paramblood As New SqlParameter("@blood", SqlDbType.VarChar, 230)
            paramblood.Value = TextBox8.Text
            Dim paramgen As New SqlParameter("@gen", SqlDbType.VarChar, 230)
            paramgen.Value = ComboBox1.Text
            Dim paramsign As New SqlParameter("@sign", SqlDbType.VarChar, 230)
            paramsign.Value = TextBox15.Text

            cmd.Parameters.Add(paramuid)
            cmd.Parameters.Add(paramfname)
            cmd.Parameters.Add(parammname)
            cmd.Parameters.Add(paramlname)
            cmd.Parameters.Add(paramf_ad)
            cmd.Parameters.Add(paramm_ad)
            cmd.Parameters.Add(paraml_ad)
            cmd.Parameters.Add(parampin)
            cmd.Parameters.Add(parampic)
            cmd.Parameters.Add(parama_pic)
            cmd.Parameters.Add(paramb_c)
            cmd.Parameters.Add(paramd_c)
            cmd.Parameters.Add(paramphone)
            cmd.Parameters.Add(paramemail)
            cmd.Parameters.Add(paramblood)
            cmd.Parameters.Add(paramgen)
            cmd.Parameters.Add(paramsign)

            Dim da As New SqlDataAdapter
            da.InsertCommand = cmd
            da.InsertCommand.ExecuteNonQuery()
            MsgBox("Application Submitted succesfully.")

            ''update status table
            cmd1.Connection = con
            cmd1.Parameters.Clear() ''important
            cmd1.CommandText = "UPDATE status SET app_sub = @application_sts, admin_rev = @admin_rev where id = @id"
            Dim paramid As New SqlParameter("@id", SqlDbType.VarChar, 15)
            paramid.Value = TextBox13.Text
            Dim parsts As New SqlParameter("@application_sts", SqlDbType.VarChar, 10)
            parsts.Value = "Submitted"
            Dim paramadmin_rev As New SqlParameter("@admin_rev", SqlDbType.VarChar, 15)
            paramadmin_rev.Value = "Pending"

            cmd1.Parameters.Add(parsts)
            cmd1.Parameters.Add(paramid)
            cmd1.Parameters.Add(paramadmin_rev)

            cmd1.ExecuteNonQuery()

            form5.Button1.PerformClick() ''shows dashboard after successful submission
        End If


    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox1.Clear()
        TextBox1.Text = "First Name"
        TextBox1.ForeColor = Color.Gray
        TextBox2.Clear()
        TextBox2.Text = "Middle Name"
        TextBox2.ForeColor = Color.Gray
        TextBox3.Clear()
        TextBox3.Text = "Last Name"
        TextBox3.ForeColor = Color.Gray

        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        TextBox11.Clear()
        TextBox12.Clear()
        TextBox14.Clear()
        TextBox15.Clear()
        ComboBox1.SelectedIndex = -1
        DateTimePicker1.Value = Date.Now
        PictureBox1.Image = Nothing
        Label1.Visible = False
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        Label12.Visible = True
        TextBox11.Visible = True
        Button3.Visible = True
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        Label12.Visible = False
        TextBox11.Visible = False
        Button3.Visible = False

    End Sub

    ''accept only numbers 
    Private Sub TextBox7_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox7.KeyPress

        If Asc(e.KeyChar) <> 8 Then '' accept only numbers
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox14_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox14.KeyPress
        
        If Asc(e.KeyChar) <> 8 Then '' accept only numbers
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    ''

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class