Imports System.Data.SqlClient
Public Class form5
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand

    Public application_status, payment_status, Admin_review As String '' to store statusses

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Panel6.Controls.Clear()
        Me.Size = New Size(900, 550)
        'centering form
        Me.Location = New Point((Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2)

        With Form3
            .TopLevel = False
            .ControlBox = False
            .Text = ""
            .FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Panel6.Controls.Add(Form3)
            .Label8.Text = Label2.Text
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click ''application submission
        Panel6.Controls.Clear()
        Me.Size = New Size(900, 732)
        'centering form
        Me.Location = New Point((Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2)

        With Form2
            .TopLevel = False
            .ControlBox = False
            .Text = ""
            .FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Panel6.Controls.Add(Form2)
            ''pass aadhar to application
            .TextBox13.Text = Label2.Text
            ''format textbox13
            .TextBox13.ReadOnly = True
            .TextBox13.BackColor = System.Drawing.SystemColors.Window
            .TextBox13.BorderStyle = BorderStyle.None
            .TextBox13.Top = .TextBox13.Top + 4
            ''
            .BringToFront()
            .Show()

            ''disables form if application already submitted already done
            If application_status = "Submitted" And Admin_review <> "Rejected" Then
                .Label1.Text = "Form disabled since application is already submitted"
                .Label1.Visible = True
                .Label1.Left = (.Label1.Parent.Width - .Label1.Width) / 2
                Dim CTL As Control
                For Each CTL In .Controls
                    CTL.Enabled = False
                Next
            ElseIf Admin_review = "Rejected" Then
                Dim CTL As Control
                For Each CTL In .Controls
                    CTL.Enabled = True
                Next
            End If
        End With
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click '' payment
        Panel6.Controls.Clear()
        Me.Size = New Size(900, 550)
        'centering form
        Me.Location = New Point((Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2)

        With Form4
            .TopLevel = False
            .ControlBox = False
            .Text = ""
            .FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Panel6.Controls.Add(Form4)
            ''pass aadhar to application
            .Label8.Text = Label2.Text
            .BringToFront()
            .Show()

            ''disables payment is payment already done
            If payment_status = "paid" Then
                .Label7.Text = ", Options disabled since Payment already done !"
                .Label7.Visible = True
                .Label7.Left = (.Label7.Parent.Width - .Label7.Width) / 2
                Dim CTL As Control
                For Each CTL In .Controls
                    CTL.Enabled = False
                Next
            End If
        End With
    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ControlBox = False
        Me.Text = ""

        ''loads status

        con.ConnectionString = "Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\DRIVING-SCHOOL-MANAGEMENT\Driving School Management\Driving School Management\Database0.mdf;Integrated Security=True"
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "SELECT * FROM status WHERE id = @id"
        cmd.Parameters.Clear()

        Dim paramid As New SqlParameter("@id", SqlDbType.VarChar, 15)
        paramid.Value = Label2.Text
        cmd.Parameters.Add(paramid)

        Dim dr1 As SqlDataReader
        dr1 = cmd.ExecuteReader
        Do While dr1.Read
            application_status = dr1("app_sub")
            payment_status = dr1("payment_sts")
            Admin_review = dr1("admin_rev")
        Loop
        dr1.Close()
        ''status loading -- end
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form1.Show()
        Me.Close()

    End Sub
End Class