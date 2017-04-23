' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' |  LXML User List Editor  |   http://lxml.codeplex.com  |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' | Authors:                                              |
' | ========                                              |
' | - Manuel a.k.a. Dade [DD-Productions]                 |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' |    visit the CodePlex-Page for License and Details    |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =

''' <summary>Form containing the Editor and the required code</summary>
Public Class frmMain

#Region " Status-Messages "

    ''' <summary>
    ''' internal class for Status-Messages
    ''' </summary>
    Private WithEvents _cStatusMsg As New DDPro.Software.Net20.Library.StatusMessages

    ''' <summary>
    ''' internal Event-Handler for the Status-Message-Class
    ''' </summary>
    ''' <param name="Message">LabelSettings to apply (Message and Format)</param>
    Private Sub _stat_NewMessage(ByVal Message As DDPro.Software.Net20.Library.StatusMessages.LabelSettings) Handles _cStatusMsg.NewMessage
        _SetLabelText(Message) ' call self-delegating Method
    End Sub
    ' code behind NewMessage
    Delegate Sub SetLabelDelegate(ByVal Message As DDPro.Software.Net20.Library.StatusMessages.LabelSettings)
    Private Sub _SetLabelText(ByVal Message As DDPro.Software.Net20.Library.StatusMessages.LabelSettings)
        If Me.statMain.InvokeRequired Then
            Me.Invoke(New SetLabelDelegate(AddressOf _SetLabelText), Message)
        Else
            'Me.sblCurrentAction.AppendText(Message)
            Me.sblCurrentAction.Text = Message.Text
            Me.sblCurrentAction.Font = Message.Font
            Me.sblCurrentAction.ForeColor = Message.ForeColor
            Me.sblCurrentAction.BackColor = Message.BackColor
        End If
    End Sub

    ''' <summary>
    ''' initialize the Status-Message-Handler
    ''' </summary>
    Private Sub _stat_init()
        Dim _defSet As New DDPro.Software.Net20.Library.StatusMessages.LabelSettings
        _defSet.Text = ""
        _defSet.ForeColor = Me.sblCurrentAction.ForeColor
        _defSet.BackColor = Me.sblCurrentAction.BackColor
        _defSet.Font = Me.sblCurrentAction.Font
        _cStatusMsg.DefaultLabelSettings = _defSet
        _cStatusMsg.AddTimestamp = True
        _cStatusMsg.AutoDeleteTime = 10000
        _cStatusMsg.AutoDelete = True
    End Sub

#End Region

#Region " internal Fields and Objects "

    ''' <summary>
    ''' internal Object for User-Handling
    ''' </summary>
    Public _users As New DDPro.Software.Net20.Library.UserList
    ''' <summary>
    ''' internal Object for the Rijndael-Encryption
    ''' </summary>
    Public _aes As New DDPro.Software.Net20.Library.Rijndael

    ''' <summary>
    ''' reminder for open File
    ''' </summary>
    Private _int_OpenFile As String = ""

#End Region

#Region " Main-Events from GUI "

    ' form init
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.tsmniVersionGui.Text = "Editor: " & My.Application.Info.Version.ToString
        Me.tsmniVersionDllLcux.Text = "LCUX: " & _users.DllVersion.ToString
        Me.tsmniVersionDllRijndael.Text = "AES: " & _aes.DllVersion.ToString

        _UpdateGridData()
        _GuiState(False) ' lock Editor-GUI

        _stat_init()

        Me.Show() ' display gui

        If My.Application.CommandLineArgs.Count = 1 Then ' file (?) passed as argument
            _cStatusMsg.DisplayMessage("opening File...", DDPro.Software.Net20.Library.StatusMessages.MessageType.Static)
            If System.IO.File.Exists(My.Application.CommandLineArgs(0).Trim) Then
                _cuxOpener(My.Application.CommandLineArgs(0).Trim)
            Else
                _cStatusMsg.DisplayMessage("File not Found - open or create a File to start working...", DDPro.Software.Net20.Library.StatusMessages.MessageType.Red_ForeColor)
            End If
        Else ' no file passed
            _cStatusMsg.DisplayMessage("Open or create a File to start working...", DDPro.Software.Net20.Library.StatusMessages.MessageType.Static)
        End If

    End Sub
    ' form exit
    Private Sub frmMain_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        ' unsaved changes?
        If _users.HasChanges Then
            If System.Windows.Forms.MessageBox.Show("The current file contains unsaved changes. Do you want discard them?", "Please confirm:", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then
                _cStatusMsg.DisplayMessage("Tool-Exit --> cancel because of unsaved changes...")
                e.Cancel = True
            End If
        End If
    End Sub
    ' menu - exit
    Private Sub mniExitTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniExitTool.Click
        Application.Exit()
    End Sub
    ' menu - file handling
    Private Sub mniNewFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniNewFile.Click
        _CreateNewFile()
    End Sub
    Private Sub mniOpenFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniOpenFile.Click
        _OpenCuxFile()
    End Sub
    Private Sub mniSaveFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniSaveFile.Click
        _SaveCuxFile(_int_OpenFile, False)
    End Sub
    Private Sub mniSaveFileAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniSaveFileAs.Click
        _SaveCuxFile(_int_OpenFile, True)
    End Sub

    ' grid - line select
    Private Sub dgvUserList_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvUserList.SelectionChanged
        _GridSelection()
    End Sub

#End Region

#Region " User-Edit GUI-Events "

    ' menu - User-Edit
    Private Sub mniUserNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniUserNew.Click
        _UserEditAdd()
    End Sub
    Private Sub mniUserAddEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniUserAddEdit.Click
        _UserEditAddEdit()
    End Sub
    Private Sub mniUserDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniUserDelete.Click
        _UserEditDelete()
    End Sub

    ' buttons - User-Edit
    Private Sub btnUserNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUserNew.Click
        _UserEditAdd()
    End Sub
    Private Sub btnUserSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUserSave.Click
        _UserEditAddEdit()
    End Sub
    Private Sub btnUserDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUserDelete.Click
        _UserEditDelete()
    End Sub

#End Region

#Region " internal logic "

    ' User-Edit
    Private Sub _UserEditAdd()
        If Not Me.btnUserNew.Enabled Then Exit Sub
        ' prepare GUI for new User
        Me.lblUserId.Text = "new User"
        Me.drpRole.Text = ""
        Me.tbxUserNt.Text = ""
        Me.tbxUserFirstName.Text = ""
        Me.tbxUserLastName.Text = ""
        Me.drpRole.Enabled = True
        Me.tbxUserNt.Enabled = True
        Me.tbxUserFirstName.Enabled = True
        Me.tbxUserLastName.Enabled = True
        Me.btnUserNew.Enabled = False
        Me.btnUserSave.Enabled = True
        Me.btnUserDelete.Enabled = False
        Me.mniUserNew.Enabled = False
        Me.mniUserAddEdit.Enabled = True
        Me.mniUserDelete.Enabled = False

    End Sub
    Private Sub _UserEditAddEdit()
        If Not Me.btnUserSave.Enabled Then Exit Sub
        ' check for role
        If Me.drpRole.Text.Trim = "" Then
            _cStatusMsg.DisplayMessage("Role can not be empty...", DDPro.Software.Net20.Library.StatusMessages.MessageType.Red_BackColor)
            Exit Sub
        End If
        ' check for nt-user
        If Me.tbxUserNt.Text.Trim = "" Then
            _cStatusMsg.DisplayMessage("NT-User can not be empty...", DDPro.Software.Net20.Library.StatusMessages.MessageType.Red_BackColor)
            Exit Sub
        End If
        ' read basic Data
        Dim _User As New DDPro.Software.Net20.Library.UserList.UserData
        _User.Username = Me.drpRole.Text
        _User.NT_User = Me.tbxUserNt.Text
        _User.FirstName = Me.tbxUserFirstName.Text
        _User.LastName = Me.tbxUserLastName.Text
        ' check mode
        If Not IsNumeric(Me.lblUserId.Text) And Me.lblUserId.Text <> "" Then ' add new user
            Dim _newId As Integer = _users.AddUser(_User)
            If _newId <> -1 Then ' added
                _cStatusMsg.DisplayMessage("User added...", DDPro.Software.Net20.Library.StatusMessages.MessageType.Green_ForeColor)
            Else ' error during add
                _cStatusMsg.DisplayMessage("Error adding User...", DDPro.Software.Net20.Library.StatusMessages.MessageType.Red_BackColor)
                Exit Sub
            End If
        ElseIf IsNumeric(Me.lblUserId.Text) And Me.lblUserId.Text <> "" Then ' edit user
            Dim _isID As Integer = -1
            If Not Integer.TryParse(Me.lblUserId.Text, _isID) Then ' ID is no Integer
                _cStatusMsg.DisplayMessage("Error updating User - ID is no Integer...", DDPro.Software.Net20.Library.StatusMessages.MessageType.Red_BackColor)
                Exit Sub
            End If
            _User.ID = _isID 'Integer.Parse(Me.lblUserId.Text) ' read user-ID from label
            If Not _users.EditUser(_User) Then
                _cStatusMsg.DisplayMessage("Error updating User...", DDPro.Software.Net20.Library.StatusMessages.MessageType.Red_BackColor)
                Exit Sub
            Else
                _cStatusMsg.DisplayMessage("User updated...", DDPro.Software.Net20.Library.StatusMessages.MessageType.Green_ForeColor)
            End If
        End If
        ' update data in grid
        _UpdateGridData()
        ' select user again (?)

    End Sub
    Private Sub _UserEditDelete()
        If Not Me.btnUserDelete.Enabled Then Exit Sub
        If System.Windows.Forms.MessageBox.Show("Do you really want to Delete the User with the ID """ & Me.lblUserId.Text & """ ?" & Environment.NewLine & "The Data can not be restored..!", "Please confirm:", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then
            _cStatusMsg.DisplayMessage("Delete User from List --> cancel by User...")
            Exit Sub
        End If
        ' get user-id
        Dim _isID As Integer = -1 'Me.lblUserId
        If Not Integer.TryParse(Me.lblUserId.Text, _isID) Then
            _cStatusMsg.DisplayMessage("Error reading User-ID...", DDPro.Software.Net20.Library.StatusMessages.MessageType.Red_BackColor)
            Exit Sub
        End If
        ' call delete here
        If Not _users.DeleteUser(_isID) Then
            _cStatusMsg.DisplayMessage("Error deleting User...", DDPro.Software.Net20.Library.StatusMessages.MessageType.Red_BackColor)
        Else
            _cStatusMsg.DisplayMessage("User deleted...", DDPro.Software.Net20.Library.StatusMessages.MessageType.Green_ForeColor)
        End If
        ' update data in grid
        _UpdateGridData()

    End Sub

    ' (un)lock Edit-GUI
    Private Sub _GuiState(ByVal Enabled As Boolean)
        Me.panElementHolder.Enabled = Enabled
        Me.mniSaveFile.Enabled = Enabled
        Me.mniSaveFileAs.Enabled = Enabled
        Me.mnEdit.Enabled = Enabled
    End Sub

    ' update grid
    Private Sub _UpdateGridData()
        ' clear grid
        Me.dgvUserList.Rows.Clear()
        ' read current users
        Dim _userList As List(Of DDPro.Software.Net20.Library.UserList.UserInfo) = _users.GetUsers
        ' add users to grid
        For Each _user As DDPro.Software.Net20.Library.UserList.UserInfo In _userList
            Me.dgvUserList.Rows.Add()
            Me.dgvUserList.Rows(Me.dgvUserList.Rows.Count - 1).Cells("colID").Value = _user.ID.ToString
            Me.dgvUserList.Rows(Me.dgvUserList.Rows.Count - 1).Cells("colUsername").Value = _user.Username
            Me.dgvUserList.Rows(Me.dgvUserList.Rows.Count - 1).Cells("colNtUser").Value = _user.NT_User
        Next
        _GridSelection()
    End Sub

    ' new file
    Private Sub _CreateNewFile()
        ' unsaved changes?
        If _users.HasChanges Then
            If System.Windows.Forms.MessageBox.Show("The current file contains unsaved changes. Do you want to discard them?", "Please confirm:", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then
                _cStatusMsg.DisplayMessage("Create new File --> cancel because of unsaved changes...")
                Exit Sub
            End If
        End If
        _GuiState(False)
        ' start init
        _int_OpenFile = ""
        _users = New DDPro.Software.Net20.Library.UserList(DDPro.Software.Net20.Library.UserList.IndexColumn.NT_User)

        ' unlock GUI
        _GuiState(True)
        _UpdateGridData()
        Me.Text = "LCUX UserList - Editor | new File"
        Me.tbxOpenFileName.Text = "not saved yet..."
        _cStatusMsg.DisplayMessage("New File created...")
    End Sub
    ' open file
    Private Sub _OpenCuxFile()
        ' unsaved changes?
        If _users.HasChanges Then
            If System.Windows.Forms.MessageBox.Show("The current file contains unsaved changes. Do you want to discard them?", "Please confirm:", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then
                _cStatusMsg.DisplayMessage("Open File --> cancel because of unsaved changes...")
                Exit Sub
            End If
        End If

        Dim _dia As New System.Windows.Forms.OpenFileDialog
        _dia.Title = "Please select File to open:"
        _dia.Multiselect = False
        _dia.Filter = "LXML-Editor UserList-Files (*.lcux)|*.lcux|all Files|*.*"
        _dia.FilterIndex = 0
        _dia.CheckFileExists = True
        If _dia.ShowDialog <> Windows.Forms.DialogResult.OK Then
            _cStatusMsg.DisplayMessage("Open File --> cancel by User...")
            Exit Sub ' cancel by user
        End If
        _cuxOpener(_dia.FileName)
    End Sub
    Private Function _cuxOpener(ByVal FileName As String) As Boolean
        _GuiState(False) ' lock gui
        _users.File = FileName
        If Not _users.Load Then
            _cStatusMsg.DisplayMessage("Loading of File failed...", DDPro.Software.Net20.Library.StatusMessages.MessageType.Red_BackColor)
            Return False
        End If
        _int_OpenFile = _users.File
        Me.Text = "CUX-Editor | " & _int_OpenFile
        ' set File-Infos to GUI
        _GuiState(True) ' unlock gui
        _UpdateGridData()
        Me.Text = "LCUX UserList - Editor | " & _int_OpenFile.Substring(_int_OpenFile.LastIndexOf("\") + 1)
        Me.tbxOpenFileName.Text = _int_OpenFile
        _cStatusMsg.DisplayMessage("File loaded...", DDPro.Software.Net20.Library.StatusMessages.MessageType.Green_ForeColor)
        Return True
    End Function

    ' save file
    Private Sub _SaveCuxFile(ByVal FileName As String, ByVal ShowSaveAsDialog As Boolean)
        If FileName.Trim = "" Or ShowSaveAsDialog Then
            ' dialog for file-select
            Dim _dia As New System.Windows.Forms.SaveFileDialog
            _dia.Title = "Please select File:"
            _dia.Filter = "LXML-Editor UserList-Files (*.lcux)|*.lcux|all Files|*.*"
            _dia.FilterIndex = 0
            _dia.CheckPathExists = True
            _dia.OverwritePrompt = True
            _dia.AddExtension = True
            If FileName <> "" Then
                _dia.FileName = FileName
            End If
            If _dia.ShowDialog <> Windows.Forms.DialogResult.OK Then
                _cStatusMsg.DisplayMessage("Save File --> cancel by User...")
                Exit Sub ' cancel by user
            End If
            FileName = _dia.FileName
        End If
        ' save file
        If Not _users.Save(FileName, False) Then
            ' not saved
            _cStatusMsg.DisplayMessage("Save to File failed...", DDPro.Software.Net20.Library.StatusMessages.MessageType.Red_BackColor)
            Exit Sub
        End If
        ' saved
        _int_OpenFile = FileName
        Me.Text = "LCUX UserList - Editor | " & _int_OpenFile.Substring(_int_OpenFile.LastIndexOf("\") + 1)
        Me.tbxOpenFileName.Text = _int_OpenFile
        _cStatusMsg.DisplayMessage("File saved...", DDPro.Software.Net20.Library.StatusMessages.MessageType.Green_ForeColor)
    End Sub

    ' select "from" grid
    Private Sub _GridSelection()
        If Me.dgvUserList.SelectedRows.Count = 1 Then ' one row
            ' exit on empty row
            If IsNothing(Me.dgvUserList.SelectedRows(0).Cells("colID").Value) Then Exit Sub
            ' continue with "read to" edit-area
            Me.lblUserId.Text = Me.dgvUserList.SelectedRows(0).Cells("colID").Value.ToString
            Me.drpRole.Text = Me.dgvUserList.SelectedRows(0).Cells("colUsername").Value.ToString
            Me.tbxUserNt.Text = Me.dgvUserList.SelectedRows(0).Cells("colNtUser").Value.ToString
            Me.tbxUserFirstName.Text = _users.GetUserFirstName(Integer.Parse(Me.dgvUserList.SelectedRows(0).Cells("colID").Value.ToString))
            Me.tbxUserLastName.Text = _users.GetUserLastName(Integer.Parse(Me.dgvUserList.SelectedRows(0).Cells("colID").Value.ToString))
            Me.drpRole.Enabled = True
            Me.tbxUserNt.Enabled = True
            Me.tbxUserFirstName.Enabled = True
            Me.tbxUserLastName.Enabled = True
            Me.btnUserNew.Enabled = True
            Me.btnUserSave.Enabled = True
            Me.btnUserDelete.Enabled = True
            Me.mniUserNew.Enabled = True
            Me.mniUserAddEdit.Enabled = True
            Me.mniUserDelete.Enabled = True
        ElseIf Me.dgvUserList.SelectedRows.Count > 1 Then ' more then one row
            Me.lblUserId.Text = "more then one..."
            Me.drpRole.Text = ""
            Me.tbxUserNt.Text = ""
            Me.tbxUserFirstName.Text = ""
            Me.tbxUserLastName.Text = ""
            Me.drpRole.Enabled = False
            Me.tbxUserNt.Enabled = False
            Me.tbxUserFirstName.Enabled = False
            Me.tbxUserLastName.Enabled = False
            Me.btnUserNew.Enabled = True
            Me.btnUserSave.Enabled = False
            Me.btnUserDelete.Enabled = False
            Me.mniUserNew.Enabled = True
            Me.mniUserAddEdit.Enabled = False
            Me.mniUserDelete.Enabled = False
        Else ' no row
            Me.lblUserId.Text = ""
            Me.drpRole.Text = ""
            Me.tbxUserNt.Text = ""
            Me.tbxUserFirstName.Text = ""
            Me.tbxUserLastName.Text = ""
            Me.drpRole.Enabled = False
            Me.tbxUserNt.Enabled = False
            Me.tbxUserFirstName.Enabled = False
            Me.tbxUserLastName.Enabled = False
            Me.btnUserNew.Enabled = True
            Me.btnUserSave.Enabled = False
            Me.btnUserDelete.Enabled = False
            Me.mniUserNew.Enabled = True
            Me.mniUserAddEdit.Enabled = False
            Me.mniUserDelete.Enabled = False
        End If
    End Sub

#End Region

End Class