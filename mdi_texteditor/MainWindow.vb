''''''''''''''''''''''''''''''''''''''''''''''''''''''
''Name: - Rut Patel
''Purpose: - Creating a MDI text editor.
''FileName: - mdi_texteditor
''NETD-2201
''Reference:- Austins Inclass codes and Lab-5 codes.
''''''''''''''''''''''''''''''''''''''''''''''''''''''

Option Strict On   'Option strict on
Imports System.IO


Public Class frmTextEditor
    ''' <summary>
    ''' This event takes place when the new button is clicked.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub New_Click(sender As Object, e As EventArgs) Handles mnuFileNew.Click, ToolStripButtonNew.Click
        'Creating file varaiable with the attributes of the frmTextArea
        Dim file As New frmTextArea
        file.MdiParent = Me
        file.Show()
        lblStripStatus.Text = "New file created"
    End Sub
    ''' <summary>
    ''' This event takes place when the user clicks the cascade button.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Cascade_Click(sender As Object, e As EventArgs) Handles mnuWindowsCascade.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub
    ''' <summary>
    ''' When this event is fired the windows in the file get arranged vertically.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub WindowsTileVertical_Click(sender As Object, e As EventArgs) Handles mnuWindowsTileVertical.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub
    ''' <summary>
    '''  When this event is fired the windows in the file get arranged horizontally.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub WindowsTileHorizontal_Click(sender As Object, e As EventArgs) Handles mnuWindowsTileHorizontal.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub
    ''' <summary>
    ''' This event fires when the user tries to save the files.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Save_Click(sender As Object, e As EventArgs) Handles mnuFileSave.Click, ToolStripButtonSave.Click, mnuFileSaveAs.Click
        'Using the IO in and creating a streamwriter variable.
        Dim outputstream As StreamWriter
        Dim activechild As frmTextArea = DirectCast(Me.ActiveMdiChild, frmTextArea)

        'If the user has not entered anything in the file and tries to save the file then.......
        If activechild.txtTextArea.Text = "" Then

            MessageBox.Show("No content in the file.")

        Else
            If SaveFileDialog.ShowDialog() = DialogResult.OK Then
                outputstream = New StreamWriter(SaveFileDialog.FileName)
                outputstream.Write(activechild.txtTextArea.Text)

                outputstream.Close()  'Closing the outputstream.
                'Displaying the status of the process.
                lblStripStatus.Text = "File Saved " + SaveFileDialog.FileName
            End If
        End If
    End Sub
    ''' <summary>
    ''' This event takes place when the use wants to open a file.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
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
    ''' <summary>
    ''' This event helps to cut the data and stores it into the clipboard.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Cut_Click(sender As Object, e As EventArgs) Handles mnuEditCut.Click
        Dim activechild As frmTextArea = DirectCast(Me.ActiveMdiChild, frmTextArea)
        activechild.txtTextArea.Cut()
    End Sub
    ''' <summary>
    ''' This event copies the data and stores it in the clipboard.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Copy_Click(sender As Object, e As EventArgs) Handles mnuEditCopy.Click
        Dim activechild As frmTextArea = DirectCast(Me.ActiveMdiChild, frmTextArea)
        activechild.txtTextArea.Copy()
    End Sub
    ''' <summary>
    ''' This event paste the data into the file from the clip board.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Paste_Click(sender As Object, e As EventArgs) Handles mnuEditPaste.Click
        Dim activechild As frmTextArea = DirectCast(Me.ActiveMdiChild, frmTextArea)
        activechild.txtTextArea.Paste()
    End Sub
    ''' <summary>
    ''' This event displays the about information to the user.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub About_Click(sender As Object, e As EventArgs) Handles mnuHelpAbout.Click
        Dim aboutModal As New aboutForm

        aboutModal.ShowDialog()
    End Sub
    ''' <summary>
    ''' This event closes the files.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Close_Click(sender As Object, e As EventArgs) Handles mnuFileClose.Click
        Dim activechild As frmTextArea = DirectCast(Me.ActiveMdiChild, frmTextArea)
        activechild.Close()
    End Sub
    ''' <summary>
    ''' This event exits the application.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Exit_Click(sender As Object, e As EventArgs) Handles mnuFileExit.Click
        Dim activechild As frmTextArea = DirectCast(Me.ActiveMdiChild, frmTextArea)
        Application.Exit()
    End Sub


End Class
