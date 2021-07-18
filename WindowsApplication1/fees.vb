﻿Imports System.Windows.Forms

Public Class fees

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
        ' Create a new instance of the child form.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub fees_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedItem > 1 Then
            TextBox4.ReadOnly = True
            TextBox5.ReadOnly = True
            TextBox6.ReadOnly = True

        End If
    End Sub

    Private Sub Label17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label17.Click

    End Sub

    Private Sub TextBox14_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox14.TextChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        main()

        cmd.CommandText = "select * from stdfee where sem='" & Trim(Me.ComboBox1.Text) & "' and stdid='" & Trim(Me.TextBox1.Text) & "' and hostel='" & Trim(Me.ComboBox2.Text) & "' and hostelfee='" & Trim(Me.TextBox2.Text) & "' and tfee='" & Trim(Me.TextBox3.Text) & "' and addfee='" & Trim(Me.TextBox4.Text) & "' and enrollfee='" & Trim(Me.TextBox5.Text) & "' and cautionfee='" & Trim(Me.TextBox6.Text) & "' and examfee='" & Trim(Me.TextBox7.Text) & "' and libfee='" & Trim(Me.TextBox8.Text) & "' and insurefee='" & Trim(Me.TextBox9.Text) & "' and stdfee='" & Trim(Me.TextBox10.Text) & "' and sportfee='" & Trim(Me.TextBox11.Text) & "' and infofee='" & Trim(Me.TextBox12.Text) & "' and scholarship='" & Trim(Me.TextBox13.Text) & "' and total='" & Trim(Me.TextBox14.Text) & "'"
        cmd.Connection = conn
        ds.Tables.Clear()
        adp.SelectCommand = cmd
        adp.Fill(ds, "tbl")
        If (ds.Tables("tbl").Rows.Count > 0) Then
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            TextBox6.Text = ""
            TextBox7.Text = ""
            TextBox8.Text = ""
            TextBox10.Text = ""
            TextBox11.Text = ""
            TextBox12.Text = ""
            TextBox13.Text = ""
            TextBox14.Text = ""
            ComboBox1.Text = ""
            ComboBox2.Text = ""

            Exit Sub
        End If

        If (TextBox14.Text = Nothing) Then
            MsgBox("Calculate Total First !", MsgBoxStyle.Information, "GRAPHIC ERA")
        Else
            cmd.CommandText = "insert into stdfee(sem,stdid,hostel,hostelfee,tfee,addfee,enrollfee,cautionfee,examfee,libfee,insurefee,stdfee,sportfee,infofee,scholarship,total)values('" & Trim(Me.ComboBox1.Text) & "','" & Trim(Me.TextBox1.Text) & "','" & Trim(Me.ComboBox2.Text) & "','" & Trim(Me.TextBox2.Text) & "','" & Trim(Me.TextBox3.Text) & "','" & Trim(Me.TextBox4.Text) & "','" & Trim(Me.TextBox5.Text) & "','" & Trim(Me.TextBox6.Text) & "','" & Trim(Me.TextBox7.Text) & "','" & Trim(Me.TextBox8.Text) & "','" & Trim(Me.TextBox9.Text) & "','" & Trim(Me.TextBox10.Text) & "','" & Trim(Me.TextBox11.Text) & "','" & Trim(Me.TextBox12.Text) & "','" & Trim(Me.TextBox13.Text) & "','" & Trim(Me.TextBox14.Text) & "')"
            cmd.Connection = conn
            cmd.ExecuteNonQuery()
            MsgBox("Record Successfully Saved!!", MsgBoxStyle.Information, "GRAPHIC ERA")
            Dim frm = New fees              'Clear Form' Change the class name if necessary
            frm.Show()
            Me.Close()
            Me.TextBox1.Focus()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        main()
        TextBox14.Text = Val(Me.TextBox2.Text) + Val(Me.TextBox3.Text) + Val(Me.TextBox4.Text) + Val(Me.TextBox5.Text) + Val(Me.TextBox6.Text) + Val(Me.TextBox7.Text) + Val(Me.TextBox8.Text) + Val(Me.TextBox9.Text) + Val(Me.TextBox10.Text) + Val(Me.TextBox11.Text) + Val(Me.TextBox12.Text) - Val(Me.TextBox13.Text)
        TextBox14.Visible = True
        Label17.Visible = True
    End Sub
End Class
