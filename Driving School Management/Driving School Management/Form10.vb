﻿Imports System.Data.SqlClient
Public Class Form10
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader


    Private Sub Form10_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim AcceptedCount, RejectedCount, PendingCount, TotalCount As Integer

        ''opens connection to db
        con.Close()
        con.ConnectionString = "Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\DRIVING-SCHOOL-MANAGEMENT\Driving School Management\Driving School Management\Database0.mdf;Integrated Security=True"
        con.Open()
        '' DO NOT DELETE ABOVE CODE

        cmd.Connection = con

        ''reads totalCount
        cmd.CommandText = "SELECT COUNT(*) AS COUNT FROM status"
        dr = cmd.ExecuteReader()
        Do While dr.Read()
            TotalCount = dr("COUNT")
        Loop
        dr.Close()

        Label2.Text = TotalCount

        ''reads AcceptedCount
        cmd.CommandText = "SELECT COUNT(*) AS COUNT FROM status WHERE admin_rev = 'Reviewed' "
        dr = cmd.ExecuteReader()
        Do While dr.Read()
            AcceptedCount = dr("COUNT")
        Loop
        dr.Close()

        Label4.Text = AcceptedCount

        ''reads rejectedCount
        cmd.CommandText = "SELECT COUNT(*) AS COUNT FROM status where admin_rev = 'Rejected' "
        dr = cmd.ExecuteReader()
        Do While dr.Read()
            RejectedCount = dr("COUNT")
        Loop
        dr.Close()

        Label6.Text = RejectedCount

        ''reads pendingCount
        cmd.CommandText = "SELECT COUNT(*) AS COUNT FROM status where admin_rev = 'Pending'"
        dr = cmd.ExecuteReader()
        Do While dr.Read()
            PendingCount = dr("COUNT")
        Loop
        dr.Close()

        Label8.Text = PendingCount

        ''updating review table

        cmd.Parameters.Clear() ''important
        cmd.CommandText = "UPDATE review SET accepted_count = @accepted_count, rejected_count = @rejected_count, pending_count = @pending_count"

        Dim accepted As New SqlParameter("@accepted_count", SqlDbType.VarChar, 50)
        accepted.Value = AcceptedCount
        Dim rejected As New SqlParameter("@rejected_count", SqlDbType.VarChar, 50)
        rejected.Value = RejectedCount
        Dim pending As New SqlParameter("@pending_count", SqlDbType.VarChar, 50)
        pending.Value = PendingCount

        cmd.Parameters.Add(accepted)
        cmd.Parameters.Add(rejected)
        cmd.Parameters.Add(pending)

        cmd.ExecuteNonQuery()
        con.Close()


    End Sub
End Class