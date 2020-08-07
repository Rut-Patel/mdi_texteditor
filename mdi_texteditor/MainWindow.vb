''''''''''''''''''''''''''''''''''''''''''''''''''''''
''Name: - Rut Patel
''
''
''
''''''''''''''''''''''''''''''''''''''''''''''''''''''

Option Strict On
Imports System.IO


Public Class frmTextEditor
    Private Sub New_Click(sender As Object, e As EventArgs) Handles mnuFileNew.Click, ToolStripButtonNew.Click
        Dim file As New frmTextArea
        file.MdiParent = Me
        file.Show()
        lblStripStatus.Text = "New file created"
    End Sub

    Private Sub Cascade_Click(sender As Object, e As EventArgs) Handles mnuWindowsCascade.Click

        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub WindowsTileVertical_Click(sender As Object, e As EventArgs) Handles mnuWindowsTileVertical.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub WindowsTileHorizontal_Click(sender As Object, e As EventArgs) Handles mnuWindowsTileHorizontal.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub Save_Click(sender As Object, e As EventArgs) Handles mnuFileSave.Click, ToolStripButtonSave.Click, mnuFileSaveAs.Click
        Dim outputstream As StreamWriter
        Dim activechild As frmTextArea = DirectCast(Me.ActiveMdiChild, frmTextArea)

        If activechild.txtTextArea.Text = "" Then

            MessageBox.Show("No content in the file.")

        Else
            If SaveFileDialog.ShowDialog() = DialogResult.OK Then
                outputstream = New StreamWriter(SaveFileDialog.FileName)
                outputstream.Write(activechild.txtTextArea.Text)

                outputstream.Close()

                lblStripStatus.Text = "File Saved " + SaveFileDialog.FileName
            End If
        End If
    End Sub

    Private Sub Open_Click(sender As Object, e As EventArgs) Handles mnuFileOpen.Click, ToolStripButtonOpen.Click
        Dim activechild As frmTextArea = DirectCast(Me.ActiveMdiChild, frmTextArea)


        Dim open As New OpenFileDialog()
            open.Title = "Open"
            open.ShowDialog()
            Dim newChild As New frmTextArea
            newChild.Text = "Document"
            newChild.MdiParent = Me
            newChild.txtTextArea.Text = My.Computer.FileSystem.ReadAllText(open.FileName)
            newChild.Show()
            lblStripStatus.Text = "Loaded " + OpenFileDialog.FileName

    End Sub

    Private Sub Cut_Click(sender As Object, e As EventArgs) Handles mnuEditCut.Click
        Dim activechild As frmTextArea = DirectCast(Me.ActiveMdiChild, frmTextArea)
        activechild.txtTextArea.Cut()
    End Sub

    Private Sub Copy_Click(sender As Object, e As EventArgs) Handles mnuEditCopy.Click
        Dim activechild As frmTextArea = DirectCast(Me.ActiveMdiChild, frmTextArea)
        activechild.txtTextArea.Copy()
    End Sub

    Private Sub Paste_Click(sender As Object, e As EventArgs) Handles mnuEditPaste.Click
        Dim activechild As frmTextArea = DirectCast(Me.ActiveMdiChild, frmTextArea)
        activechild.txtTextArea.Paste()
    End Sub

    Private Sub About_Click(sender As Object, e As EventArgs) Handles mnuHelpAbout.Click
        Dim aboutModal As New aboutForm

        aboutModal.ShowDialog()
    End Sub

    Private Sub Close_Click(sender As Object, e As EventArgs) Handles mnuFileClose.Click
        Dim activechild As frmTextArea = DirectCast(Me.ActiveMdiChild, frmTextArea)
        activechild.Close()
    End Sub

    Private Sub Exit_Click(sender As Object, e As EventArgs) Handles mnuFileExit.Click
        Dim activechild As frmTextArea = DirectCast(Me.ActiveMdiChild, frmTextArea)
        Application.Exit()
    End Sub


End Class
