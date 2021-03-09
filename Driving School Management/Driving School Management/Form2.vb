Imports System.Data.SqlClient
Public Class Form2
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand

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
    Private Sub PictureBox1_Click_1(sender As Object, e As EventArgs) Handles PictureBox1.Click
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
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim constring As String = "Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\DRIVING-SCHOOL-MANAGEMENT-main\Driving School Management\Driving School Management\Database0.mdf;Integrated Security=True"
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
        MsgBox("Registered succesfully. Make fee payment now?", MsgBoxStyle.YesNo)

        If MsgBoxResult.Yes Then
            Form4.Show()
            Me.Hide()
        Else
            Me.Close()
        End If

    End Sub


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)



    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox1.Text = " "
        TextBox2.Text = " "
        TextBox3.Text = " "
        TextBox4.Text = " "
        TextBox5.Text = " "
        TextBox6.Text = " "
        TextBox7.Text = " "
        TextBox8.Text = " "
        TextBox9.Text = " "
        TextBox10.Text = " "
        TextBox11.Text = " "
        TextBox12.Text = " "
        TextBox13.Text = " "
        TextBox14.Text = " "

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
End Class