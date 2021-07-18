Imports System.Windows.Forms

Public Class search
    Private Sub search_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        main()

        cmd.CommandText = "SELECT stdid FROM addstd"
        cmd.Connection = conn
        ds.Tables.Clear()
        adp.SelectCommand = cmd
        adp.Fill(ds, "tbl")
        For Each dr In ds.Tables("tbl").Rows
            Me.ComboBox4.Items.Add(dr("stdid"))
        Next

        Me.ListView1.Columns.Add("S.no", Convert.ToInt32(Me.ListView1.Width / 15), HorizontalAlignment.Center)
        Me.ListView1.Columns.Add("Name", Convert.ToInt32(Me.ListView1.Width / 15), HorizontalAlignment.Center)
        Me.ListView1.Columns.Add("Section", Convert.ToInt32(Me.ListView1.Width / 17), HorizontalAlignment.Center)
        Me.ListView1.Columns.Add("Address", Convert.ToInt32(Me.ListView1.Width / 11), HorizontalAlignment.Center)
        Me.ListView1.Columns.Add("E-Mail", Convert.ToInt32(Me.ListView1.Width / 11), HorizontalAlignment.Center)
        Me.ListView1.Columns.Add("Contact", Convert.ToInt32(Me.ListView1.Width / 11), HorizontalAlignment.Center)
        Me.ListView1.Columns.Add("Father's Name", Convert.ToInt32(Me.ListView1.Width / 10), HorizontalAlignment.Center)
        Me.ListView1.Columns.Add("Mother's Name", Convert.ToInt32(Me.ListView1.Width / 11), HorizontalAlignment.Center)
        Me.ListView1.Columns.Add("Gaurdian Number", Convert.ToInt32(Me.ListView1.Width / 11), HorizontalAlignment.Center)
        Me.ListView1.Columns.Add("Course", Convert.ToInt32(Me.ListView1.Width / 13), HorizontalAlignment.Center)
        Me.ListView1.Columns.Add("Specialization", Convert.ToInt32(Me.ListView1.Width / 13), HorizontalAlignment.Center)
        Me.ListView1.Columns.Add("Student ID", Convert.ToInt32(Me.ListView1.Width / 13), HorizontalAlignment.Center)
        Me.ListView1.Columns.Add("Semester", Convert.ToInt32(Me.ListView1.Width / 11), HorizontalAlignment.Center)
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox4.SelectedIndexChanged
        main()
        Dim i, j As Integer
        cmd.CommandText = "select * from addstd where addstd.stdid='" & Me.ComboBox4.Text & "'"
        cmd.Connection = conn
        ds.Tables.Clear()
        adp.SelectCommand = cmd
        adp.Fill(ds, "tbl")
        For Each dr In ds.Tables("tbl").Rows

            TextBox1.Text = dr("stdname")
            TextBox2.Text = dr("stdsection")
            TextBox3.Text = dr("stdadd")
            TextBox4.Text = dr("stdemail")
            TextBox5.Text = dr("stdnum")
            TextBox6.Text = dr("stdfather")
            TextBox7.Text = dr("stdmother")
            TextBox8.Text = dr("stdmother")
            TextBox9.Text = dr("stdgaurdian")
            DateTimePicker1.Text = dr("dateofregistration")
            TextBox10.Text = dr("timeofregistration")
            ComboBox1.Text = dr("course")
            ComboBox2.Text = dr("specialization")
            TextBox9.Text = dr("stdid")
            ComboBox3.Text = dr("sem")
        Next

        cmd.CommandText = "select stdname,stdsection,stdadd,stdemail,stdnum,stdfather,stdmother,stdgaurdian,dateofregistration,timeofregistration,course,specialization,stdid,sem from addstd where addstd.stdid='" & Me.ComboBox4.Text & "'"
        cmd.Connection = conn
        ds.Tables.Clear()
        adp.SelectCommand = cmd
        adp.Fill(ds, "tbl")
        i = 0
        Me.ListView1.Items.Clear()
        j = 1
        For Each dr In ds.Tables("tbl").Rows
            Me.ListView1.Items.Add(j)
            Me.ListView1.Items(i).SubItems.Add(dr("stdname"))
            Me.ListView1.Items(i).SubItems.Add(dr("stdsection"))
            Me.ListView1.Items(i).SubItems.Add(dr("stdadd"))
            Me.ListView1.Items(i).SubItems.Add(dr("stdemail"))
            Me.ListView1.Items(i).SubItems.Add(dr("stdnum"))
            Me.ListView1.Items(i).SubItems.Add(dr("stdfather"))
            Me.ListView1.Items(i).SubItems.Add(dr("stdmother"))
            Me.ListView1.Items(i).SubItems.Add(dr("stdgaurdian"))
            Me.ListView1.Items(i).SubItems.Add(dr("course"))
            Me.ListView1.Items(i).SubItems.Add(dr("specialization"))
            Me.ListView1.Items(i).SubItems.Add(dr("stdid"))
            Me.ListView1.Items(i).SubItems.Add(dr("sem"))
            i = i + 1
            j = j + 1
        Next


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        main()
        cmd.CommandText = "update addstd set stdname='" & Trim(Me.TextBox1.Text) & "',stdsection='" & Trim(Me.TextBox2.Text) & "',stdadd='" & Trim(Me.TextBox3.Text) & "',stdemail='" & Trim(Me.TextBox4.Text) & "',stdnum='" & Trim(Me.TextBox5.Text) & "',stdfather='" & Trim(Me.TextBox6.Text) & "',stdmother='" & Trim(Me.TextBox7.Text) & "',stdgaurdian='" & Trim(Me.TextBox8.Text) & "',course='" & Trim(Me.ComboBox1.Text) & "',specialization='" & Trim(Me.ComboBox2.Text) & "',stdid='" & Trim(Me.TextBox9.Text) & "',sem='" & Trim(Me.ComboBox3.Text) & "' where stdid='" & Trim(Me.TextBox9.Text) & "'"
        cmd.Connection = conn
        cmd.ExecuteNonQuery()
        MsgBox("Record Successfully Updated!!", MsgBoxStyle.Information, "Graphic Era University")

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        TextBox9.Text = ""
        ComboBox3.Text = ""
        ComboBox4.Text = ""
        ListView1.Items.Clear()
    End Sub
End Class
