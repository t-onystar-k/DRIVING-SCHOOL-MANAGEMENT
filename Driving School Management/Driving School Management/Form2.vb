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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim constring As String = "Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\DRIVING-SCHOOL-MANAGEMENT-main\Driving School Management\Driving School Management\Database0.mdf;Integrated Security=True"
        con = New SqlConnection(constring)
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "INSERT INTO Reg(uid,fname,mname,lname,f_ad,m_ad,l_ad,pin)values(@uid,@fname,@mname,@lname,@f_ad,@m_ad,@l_ad,@pin)"
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
        Dim parama_pic As New SqlParameter("@a_pic", SqlDbType.VarChar, 230)
        parama_pic.Value = TextBox12.Text

        cmd.Parameters.Add(paramuid)
        cmd.Parameters.Add(paramfname)
        cmd.Parameters.Add(parammname)
        cmd.Parameters.Add(paramlname)
        cmd.Parameters.Add(paramf_ad)
        cmd.Parameters.Add(paramm_ad)
        cmd.Parameters.Add(paraml_ad)
        cmd.Parameters.Add(parampin)
        cmd.Parameters.Add(parama_pic)

        Dim da As New SqlDataAdapter
        da.InsertCommand = cmd
        da.InsertCommand.ExecuteNonQuery()
        MsgBox("inserted succesfully")

    End Sub


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click



    End Sub


End Class