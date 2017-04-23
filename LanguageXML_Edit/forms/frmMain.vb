' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' |   Language XML Editor  |   http://lxml.codeplex.com   |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' | Authors:                                              |
' | ========                                              |
' | - Manuel a.k.a. Dade [DD-Productions]                 |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' |    visit the CodePlex-Page for License and Details    |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
Imports System.Windows.Forms

''' <summary>Main MDI Form - Application Body</summary>
Public Class frmMain

    ' ToDo: add reminder for selected cell in grid in value-edit --> restore on next open
    ' ToDo: remind complete Grid-Layouts?

    ' ToDo: add form to add new Value more easy --> TextBox for Name and Description, Grid for Values for Languages
    ' add-Form:
    ' - NameSpaces - Select (defined as user-settings) --> auto-add if new Name does not StartsWith NameSpace
    ' - Name --> with online-check if values are ok or not (use background-worker for that compare --> show by icon at right side of input-box)
    ' - Description (text) --> optional replace-Values by little grid (added to Description by tool)
    ' - Radio-Buttons to copy a) nothing  or b)Name of last created Item with or c) without NameSpace-Part to clipboard after create --> paste back to Develop-Environment
    ' - CodeHelper alternate to just the name in clipboard --> pre-defined Code in VB / C# to request a value / a messagebox for the new value using all defined parameters...

#Region " Status-Messages "

    ''' <summary>
    ''' Class for Status-Messages displayed by this the Tool
    ''' </summary>
    Friend WithEvents cStatus As New DDPro.Software.Net20.Library.StatusMessages

    ''' <summary>
    ''' internal Event-Handler for the Status-Message-Class
    ''' </summary>
    ''' <param name="Message">LabelSettings to apply (Message and Format)</param>
    Private Sub _stat_NewMessage(ByVal Message As DDPro.Software.Net20.Library.StatusMessages.LabelSettings) Handles cStatus.NewMessage
        _SetLabelText(Message) ' call self-delegating Method
    End Sub
    ''' <summary>
    ''' delegate to invoke _SetLabelText from other Thread
    ''' </summary>
    ''' <param name="Message">Message-Data to apply</param>
    Delegate Sub SetLabelDelegate(ByVal Message As DDPro.Software.Net20.Library.StatusMessages.LabelSettings)
    ''' <summary>
    ''' self-delegating Method to set Status-Text
    ''' </summary>
    ''' <param name="Message">Message-Data to apply</param>
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
    Private Sub _init_status()
        Dim _defSet As New DDPro.Software.Net20.Library.StatusMessages.LabelSettings
        _defSet.Text = ""
        _defSet.ForeColor = Me.sblCurrentAction.ForeColor
        _defSet.BackColor = Me.sblCurrentAction.BackColor
        _defSet.Font = Me.sblCurrentAction.Font
        cStatus.DefaultLabelSettings = _defSet
        cStatus.AddTimestamp = True
        cStatus.AutoDeleteTime = 15000
        cStatus.AutoDelete = True
    End Sub

#End Region

#Region " Language Handling (using LanguageXML) "

    ''' <summary>Langauge-Object for the Tool</summary>
    Friend cLangXML As New DDPro.Software.Net20.Library.LanguageXML

    ''' <summary>initialize the Language-Handling</summary>
    ''' <returns>TRUE on success, FALSE on error</returns>
    Private Function _init_lang() As Boolean
        ' try to load Data
        If Not System.IO.File.Exists(Application.StartupPath & "\" & My.Settings.app_FileLanguageFile) Then
            Return False
        End If
        If Not cLangXML.LoadFromXmlFile(Application.StartupPath & "\" & My.Settings.app_FileLanguageFile) Then
            Return False
        End If
        ' apply language from settings
        cLangXML.ActiveLanguage = cSettings.GetValue("AppLang", "DEFAULT")
        ' set MessageBox-Prefixes
        _initLangSelList() ' init Language-Selection
        ' more init of the Class
        'cLangXML.MsgBox_LxmlTitleItemPrefix = ""
        cLangXML.MsgBox_LxmMessageHeaderPrefix = "msg_title_" ' prefix for MessageTitles
        cLangXML.MsgBox_LxmMessageTextPrefix = "err_msg_" ' prefix for (Error)-Messages
        ' apply language
        _performLanguageSwitch()
        Return True
    End Function

    ''' <summary>apply the language that is active in the class</summary>
    Private Sub _performLanguageSwitch()
        cLangXML.ApplyTextToForm(Me, "lx_", "as_mf_")
        If _openFileName.Trim <> "" Then
            Me.Text = cLangXML.ReadValue("as_mf_frmMain") & " | " & _openFileName.Substring(_openFileName.LastIndexOf("\") + 1)
        End If
        ' look for other open an knwon form(s)
        For Each _form As System.Windows.Forms.Form In Me.MdiChildren
            Select Case _form.Name
                Case "frmLanguageList"
                    cLangXML.ApplyTextToForm(ApplyTo:=_form, FormElementPrefix:="lx_", lxmlElementPrefix:="as_ls_")
                Case "frmBaseData"
                    cLangXML.ApplyTextToForm(ApplyTo:=_form, FormElementPrefix:="lx_", lxmlElementPrefix:="as_li_")
                    Dim _tmp As frmBaseData = _form
                    _tmp.PerformLanguageChange() ' call Language-Updater in Form
                Case "frmLanguageData"
                    cLangXML.ApplyTextToForm(ApplyTo:=_form, FormElementPrefix:="lx_", lxmlElementPrefix:="as_ld_")
                    Dim _tmp As frmLanguageData = _form
                    _tmp.PerformLanguageChange() ' call Language-Updater in Form
                Case "frmAbout"
                    cLangXML.ApplyTextToForm(ApplyTo:=_form, FormElementPrefix:="lx_", lxmlElementPrefix:="as_af_")
                    Dim _tmp As frmAbout = _form
                    _tmp.PerformLanguageChange() ' call Language-Updater in Form
            End Select
        Next
    End Sub

    ''' <summary>init Language-Selection</summary>
    Private Sub _initLangSelList()
        Dim _tmpObj As System.Windows.Forms.ToolStripMenuItem ' temporary MenuItem
        Dim _langList() As DDPro.Software.Net20.Library.LanguageXML.langBaseInfo = cLangXML.LanguageDetails ' get Langaues in Tool-LXML
        For Each _language As DDPro.Software.Net20.Library.LanguageXML.langBaseInfo In _langList ' for each Language-Item in Tool-Data
            _tmpObj = New System.Windows.Forms.ToolStripMenuItem ' create new Item
            _tmpObj.Name = "smniLang_" & _language.InternalName ' set Name of Item
            _tmpObj.Text = _language.DisplayName & " (" & _language.IsoString & ")" ' set Text on Item
            If _language.InternalName = cLangXML.ActiveLanguage Then ' if selected-Language
                Me.sdrpLanguageSelect.Text = _tmpObj.Text ' set Text on LanguageSelector
            End If
            AddHandler _tmpObj.Click, AddressOf LanguageSelect_Click ' add Event-Handler
            Me.sdrpLanguageSelect.DropDownItems.Add(_tmpObj) ' add Item to DropDown in StatusStrip
        Next
    End Sub

    ''' <summary>Method for change Language by dynamic created Menu-Items</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>used by the Items that are created at runtime</remarks>
    Private Sub LanguageSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.sdrpLanguageSelect.Text = sender.Text Then ' if lang is not changed then exit
            Exit Sub
        End If
        ' new language set
        If sender.Name.ToString.StartsWith("smniLang_") Then
            Cursor.Current = Cursors.WaitCursor
            Dim _NewLang As String = sender.Name.ToString.Substring(sender.Name.ToString.IndexOf("_") + 1)
            cLangXML.ActiveLanguage = _NewLang
            cSettings.SaveValue("AppLang", _NewLang)
            _performLanguageSwitch() ' change Language in GUI
            Me.sdrpLanguageSelect.Text = sender.Text ' set new active Language to Select-Button
            cStatus.DisplayMessage(cLangXML.ReadValue("stat_msg_LangChanged"), DDPro.Software.Net20.Library.StatusMessages.MessageType.Default)
            Cursor.Current = Cursors.Default
        End If
    End Sub

#End Region

#Region " User-Handling "

    ''' <summary>User-Object for the Tool</summary>
    Friend cUsers As New DDPro.Software.Net20.Library.UserList

    ''' <summary>read the current LockLevel of GUI (Role)</summary>
    Friend ReadOnly Property CurrentRoleinfo() As eGuiLockLevel
        Get
            Return _activeRole
        End Get
    End Property

    Private _activeRole As eGuiLockLevel

    ''' <summary>Enumeration for a GUI-Lock Type</summary>
    Friend Enum eGuiLockLevel
        ''' <summary>GUI enabled (for example after temporary lock without restrictions)</summary>
        NoLock = 0
        ''' <summary>GUI enabled (for example after temporary lock without editing language-items)</summary>
        LanguageAdmin = 100
        ''' <summary>GUI enabled (for example after temporary lock without langauge-list or language-items)</summary>
        Editor = 200
        ''' <summary>GUI disabled (only file --> exit is possible)</summary>
        Full = 500
    End Enum

    ''' <summary>initialize the User-Handling</summary>
    ''' <returns>TRUE on success, FALSE on error</returns>
    Private Function _init_users() As Boolean
        ' is file existing?
        If Not System.IO.File.Exists(Application.StartupPath & "\" & My.Settings.app_FileUserList) Then
            Return False
        End If
        ' file exists - set path in class
        If Not cUsers.Load(Application.StartupPath & "\" & My.Settings.app_FileUserList, False) Then
            Return False
        End If
        Return True
    End Function

    ''' <summary>check the rights for the current User compared to the User-List and apply to GUI</summary>
    Private Sub _internalRightsCheck()
        ' "Roles":
        ' username "admin": new file, show items, add / delete languages
        ' username "langedit": add / delete languages
        ' username "editor": editor-use for existing languages

        ' nt-name "*": all users that were not found

        Dim _found As Boolean = False
        Dim _users As List(Of DDPro.Software.Net20.Library.UserList.UserInfo) = cUsers.GetUsers
        Dim _level As eGuiLockLevel = eGuiLockLevel.Full
        Dim _roleName As String = ""
        Dim _defaultLevel As eGuiLockLevel = eGuiLockLevel.Full ' set Default for all users
        Dim _defaultRoleName As String = ""
        For Each _user As DDPro.Software.Net20.Library.UserList.UserInfo In _users ' check if user is in list
            ' check for "all users"
            If _user.NT_User = "*" Then
                Select Case _user.Username.ToLower ' get "role"
                    Case "admin"
                        _defaultLevel = eGuiLockLevel.NoLock
                        _defaultRoleName = cLangXML.ReadValue("stat_txt_RightsAdmin")
                    Case "langedit"
                        _defaultLevel = eGuiLockLevel.LanguageAdmin
                        _defaultRoleName = cLangXML.ReadValue("stat_txt_RightsLangAdmin")
                    Case Else
                        _defaultLevel = eGuiLockLevel.Editor
                        _defaultRoleName = cLangXML.ReadValue("stat_txt_RightsEditor")
                End Select
            End If
            ' check current user
            If _user.NT_User = (Environment.UserDomainName.ToLower & "\" & Environment.UserName.ToLower) Then ' name match
                Select Case _user.Username.ToLower ' get "role"
                    Case "admin"
                        _level = eGuiLockLevel.NoLock
                        _roleName = cLangXML.ReadValue("stat_txt_RightsAdmin")
                    Case "langedit"
                        _level = eGuiLockLevel.LanguageAdmin
                        _roleName = cLangXML.ReadValue("stat_txt_RightsLangAdmin")
                    Case Else
                        _level = eGuiLockLevel.Editor
                        _roleName = cLangXML.ReadValue("stat_txt_RightsEditor")
                End Select
                _found = True
            End If
        Next
        ' check if found - else check for default
        If Not _found Then ' no defined User-Role
            _level = _defaultLevel ' apply default-level
            ' display Message with Role
            cStatus.DisplayMessage(cLangXML.ReadProcessedValue("stat_msg_UserRights", "{rights}", _defaultRoleName), DDPro.Software.Net20.Library.StatusMessages.MessageType.Green_ForeColor)
        Else ' defined User-Role 
            ' display Message with Role
            cStatus.DisplayMessage(cLangXML.ReadProcessedValue("stat_msg_UserRights", "{rights}", _roleName), DDPro.Software.Net20.Library.StatusMessages.MessageType.Green_ForeColor)
        End If
        ' remind level (for later... ;-)
        _activeRole = _level
        If _level = eGuiLockLevel.Full Then ' info to user that he was not found on status
            cStatus.DisplayMessage(cLangXML.ReadProcessedValue("stat_msg_userNotInList", "{user}", (Environment.UserDomainName.ToLower & "\" & Environment.UserName.ToLower)), DDPro.Software.Net20.Library.StatusMessages.MessageType.Red_BackColor)
        End If
        ' apply GUI-Level
        _internal_GuiLock(_level)
    End Sub

    ''' <summary>set the LockLevel for the GUI</summary>
    ''' <param name="Level">the Level to Apply</param>
    Private Sub _internal_GuiLock(ByVal Level As eGuiLockLevel)
        Select Case Level
            Case eGuiLockLevel.NoLock ' prepare for admin-use
                Me.lx_mnFile.Enabled = True
                Me.lx_mniNewFile.Enabled = True
                Me.lx_mniOpenFile.Enabled = True
                Me.lx_mniSaveFile.Enabled = True
                Me.lx_mniSaveFileAs.Enabled = True
                Me.lx_mniExitTool.Enabled = True
                Me.lx_mnView.Visible = True ' hide / show
                Me.lx_mnView.Enabled = True ' lock (shortcuts)
                Me.lx_mniShowLangData.Visible = True ' hide / show
                Me.lx_mniShowLangData.Enabled = True ' lock (shortcuts)
                Me.lx_mniShowLangItems.Visible = True ' hide / show
                Me.lx_mniShowLangItems.Enabled = True ' lock (shortcuts)
                Me.lx_mniShowLangList.Visible = True ' hide / show
                Me.lx_mniShowLangList.Enabled = True ' lock (shortcuts)
            Case eGuiLockLevel.LanguageAdmin ' prepare for LanguageAdmin-Use
                Me.lx_mnFile.Enabled = True
                Me.lx_mniNewFile.Enabled = False
                Me.lx_mniOpenFile.Enabled = True
                Me.lx_mniSaveFile.Enabled = True
                Me.lx_mniSaveFileAs.Enabled = True
                Me.lx_mniExitTool.Enabled = True
                Me.lx_mnView.Visible = True ' hide / show
                Me.lx_mnView.Enabled = True ' lock (shortcuts)
                Me.lx_mniShowLangData.Visible = True ' hide / show
                Me.lx_mniShowLangData.Enabled = True ' lock (shortcuts)
                Me.lx_mniShowLangItems.Visible = False ' hide / show
                Me.lx_mniShowLangItems.Enabled = False ' lock (shortcuts)
                Me.lx_mniShowLangList.Visible = True ' hide / show
                Me.lx_mniShowLangList.Enabled = True ' lock (shortcuts)
            Case eGuiLockLevel.Editor ' prepare for Editor-Use
                Me.lx_mnFile.Enabled = True
                Me.lx_mniNewFile.Enabled = False
                Me.lx_mniOpenFile.Enabled = True
                Me.lx_mniSaveFile.Enabled = True
                Me.lx_mniSaveFileAs.Enabled = True
                Me.lx_mniExitTool.Enabled = True
                Me.lx_mnView.Visible = True ' hide / show
                Me.lx_mnView.Enabled = True ' lock (shortcuts)
                Me.lx_mniShowLangData.Visible = True ' hide / show
                Me.lx_mniShowLangData.Enabled = True ' lock (shortcuts)
                Me.lx_mniShowLangItems.Visible = False ' hide / show
                Me.lx_mniShowLangItems.Enabled = False ' lock (shortcuts)
                Me.lx_mniShowLangList.Visible = False ' hide / show
                Me.lx_mniShowLangList.Enabled = False ' lock (shortcuts)
            Case eGuiLockLevel.Full ' lock GUI complete
                Me.lx_mnFile.Enabled = True
                Me.lx_mniNewFile.Enabled = False
                Me.lx_mniOpenFile.Enabled = False
                Me.lx_mniSaveFile.Enabled = False
                Me.lx_mniSaveFileAs.Enabled = False
                Me.lx_mniExitTool.Enabled = True
                Me.lx_mnView.Visible = False ' hide / show
                Me.lx_mnView.Enabled = False ' lock (shortcuts)
                Me.lx_mniShowLangData.Visible = False ' hide / show
                Me.lx_mniShowLangData.Enabled = False ' lock (shortcuts)
                Me.lx_mniShowLangItems.Visible = False ' hide / show
                Me.lx_mniShowLangItems.Enabled = False ' lock (shortcuts)
                Me.lx_mniShowLangList.Visible = False ' hide / show
                Me.lx_mniShowLangList.Enabled = False ' lock (shortcuts)
        End Select
        ' ToDo: handle child-forms here..!?
    End Sub

#End Region

#Region " User-Settings "

    ''' <summary>internal Class for the UserSettinsg (to keep File readable over diffrent versions)</summary>
    Friend cSettings As New DDPro.Software.Net20.Library.UserSettings("DD-Productions\LxmlEdit")

    Private Function _init_UserSettings() As Boolean
        ' if file is not existing then create defaults from My.Settings
        cSettings.ThrowExceptions = False ' do not thow exceptions
        If Not cSettings.ConfigFileExists Then ' first run of tool for user
            Dim _srt As Short
            Dim _txt As String

            ' init String-Settings
            _txt = "DEFAULT"
            cSettings.SaveValue("AppLang", _txt)
            _txt = ""
            cSettings.SaveValue("RecentFiles", _txt)

            ' Init Short-Settings
            _srt = 0
            cSettings.SaveValue("DefaultForm", _srt)
            _srt = 8
            cSettings.SaveValue("RecentFileMax", _srt)
            _srt = 0
            cSettings.SaveValue("StartPos", _srt)
            _srt = 0
            cSettings.SaveValue("StartSize", _srt)
            _srt = 450
            cSettings.SaveValue("StartHeight", _srt)
            _srt = 600
            cSettings.SaveValue("StartWidth", _srt)
            _srt = 25
            cSettings.SaveValue("StartX", _srt)
            _srt = 25
            cSettings.SaveValue("StartY", _srt)
            _srt = 15
            cSettings.SaveValue("StatMsgDuration", _srt)


            ' save configuration for next run
            Return cSettings.SaveConfig()
        Else ' file present - load
            Return cSettings.LoadConfig()
        End If
    End Function

#End Region

#Region " editor Basics "

    ''' <summary>
    ''' internal Class with Basic Elements for editing
    ''' </summary>
    Friend cEditor As New clsEditorBase

#End Region

#Region " Open File Handling "

    ''' <summary>
    ''' reminder for FileName of open File
    ''' </summary>
    Private _openFileName As String = ""

    ''' <summary>
    ''' save the current Data to File
    ''' </summary>
    ''' <param name="SaveAs">Set TRUE to enforce a SaveAs-Dialog even if FileName is set</param>
    ''' <returns>TRUE on success, FALSE on error</returns>
    Private Function _File_Save(ByVal SaveAs As Boolean) As Boolean
        ' rights-check
        If _activeRole > eGuiLockLevel.NoLock And _openFileName = "" Then
            ' if not Admin (create Items) and no open file, then exit
            Return False
        End If
        ' start save
        cStatus.DisplayMessage(cLangXML.ReadValue("stat_msg_FileSaveStarted"))
        Dim _tmpFile As String = _openFileName ' set TempFileName to current FileName for init
        Dim _useFormat As Integer = cEditor.OpenFileVersion
        If _useFormat = 0 Then _useFormat = 2 ' ToDO: read from Settings
        If (_openFileName.Trim = "") Or SaveAs Then ' if File-Selection is needed / wished
            ' set File-Format to use
            If _activeRole = eGuiLockLevel.NoLock Then ' Format-Selection only for admins
                Dim _frm As New frmFileFormat
                _frm.FileVersion = _useFormat
                If _frm.ShowDialog(Me) <> Windows.Forms.DialogResult.OK Then
                    ' no version selected
                    cStatus.DisplayMessage(cLangXML.ReadValue("stat_msg_FileSaveNoVersionSelect"), DDPro.Software.Net20.Library.StatusMessages.MessageType.Red_ForeColor)
                    Return False
                End If
                ' read seletced version
                _useFormat = _frm.FileVersion
            End If

            Dim _dia As New SaveFileDialog ' create and configure Dialog
            If SaveAs Then ' if Save As: set Title
                _dia.Title = cLangXML.ReadValue("dia_title_SaveFileAs")
            Else ' if Save: set Title
                _dia.Title = cLangXML.ReadValue("dia_title_SaveFile")
            End If
            _dia.Filter = cLangXML.ReadValue("str_name_LxmlFiles") & " (*.lxml)|*.lxml|" & cLangXML.ReadValue("str_name_XmlFiles") & " (*.xml)|*.xml|" & cLangXML.ReadValue("str_name_AllFiles") & " (*.*)|*.*"
            _dia.FilterIndex = 0
            _dia.CheckPathExists = True
            _dia.AddExtension = True
            _dia.OverwritePrompt = True
            _dia.DefaultExt = "lxml"
            If _openFileName.Trim <> "" Then ' a FileName is set
                If System.IO.File.Exists(_openFileName) Then ' if file exists
                    _dia.FileName = _openFileName ' set as default-file
                End If
            End If
            If (_dia.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
                _tmpFile = _dia.FileName ' remind selected filename
            Else ' user cancelled File-Selection
                cStatus.DisplayMessage(cLangXML.ReadValue("stat_msg_FileSaveCancelFileSelect"), DDPro.Software.Net20.Library.StatusMessages.MessageType.Red_ForeColor)
                Return False
            End If
        End If
        ' save the Data from the open Form(s) to DataSet
        Dim _tRes As Boolean = False
        Dim _tCont As Boolean = False
        _GetChangeInfoFromFormsAndDataSet(_tRes, _tCont)
        If Not _tCont Then ' user-Cancel because of Save-Error
            cStatus.DisplayMessage(cLangXML.ReadValue("stat_msg_NoSaveAfterFormSaveError"), DDPro.Software.Net20.Library.StatusMessages.MessageType.Red_ForeColor)
            Return False
        End If
        ' try to save Data to file
        If _useFormat = 1 Then ' save as version 1
            Try
                cEditor.LXML_DataSet.WriteXml(_tmpFile)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, cLangXML.ReadValue("msg_title_Error"))
                cStatus.DisplayMessage(cLangXML.ReadValue("stat_msg_FileSaveWriteXmlError"), DDPro.Software.Net20.Library.StatusMessages.MessageType.Red_BackColor)
                Return False
            End Try
        Else ' save as version 2
            If Not _SaveDataFormatVersion2(_tmpFile) Then
                cStatus.DisplayMessage(cLangXML.ReadValue("stat_msg_FileSaveWriteXmlError"), DDPro.Software.Net20.Library.StatusMessages.MessageType.Red_BackColor)
                Return False
            End If
        End If
        cEditor.OpenFileVersion = _useFormat
        If _openFileName <> _tmpFile Then ' if file has changed
            _openFileName = _tmpFile ' remind new FileName
            _recentFileAddToList(_openFileName, True) ' remind file in Recent-List
            Me.Text = cLangXML.ReadValue("as_mf_frmMain") & " | " & _openFileName.Substring(_openFileName.LastIndexOf("\") + 1) ' apply new FileName to Form-Name
        End If
        cEditor.LXML_DataSet.AcceptChanges()
        cStatus.DisplayMessage(cLangXML.ReadValue("stat_msg_FileSaveSuccess"), DDPro.Software.Net20.Library.StatusMessages.MessageType.Green_ForeColor)
        ' return success
        Return True
    End Function

    ''' <summary>
    ''' open / load Data from selected File
    ''' </summary>
    ''' <param name="NoChangesCheck">optional set to TRUE to skip the ChangesCheck</param>
    ''' <returns>TRUE on success, FALSE on error</returns>
    Private Function _File_Open(Optional ByVal NoChangesCheck As Boolean = False, Optional ByVal OpenFileName As String = "") As Boolean
        cStatus.DisplayMessage(cLangXML.ReadValue("stat_msg_FileOpenStarted"))
        If Not NoChangesCheck Then ' check for changes only if not skipped
            ' check for unsaved Changes and save if needed
            If Not _CheckForChangesHandling() Then
                Return False
            End If
        End If
        ' close open form(s) of file
        For Each _form As System.Windows.Forms.Form In Me.MdiChildren
            _form.Close()
        Next
        ' only use dialog if no file is passed
        If OpenFileName.Trim = "" Then
            ' create and configure Dialog
            Dim _dia As New System.Windows.Forms.OpenFileDialog
            _dia.Title = cLangXML.ReadValue("dia_title_OpenFile")
            _dia.Filter = cLangXML.ReadValue("str_name_LxmlFiles") & " (*.lxml)|*.lxml|" & cLangXML.ReadValue("str_name_XmlFiles") & " (*.xml)|*.xml|" & cLangXML.ReadValue("str_name_AllFiles") & " (*.*)|*.*"
            _dia.FilterIndex = 0
            _dia.FileName = ""
            _dia.Multiselect = False
            _dia.CheckFileExists = True
            If _dia.ShowDialog(Me) <> Windows.Forms.DialogResult.OK Then ' no file selected
                cStatus.DisplayMessage(cLangXML.ReadValue("stat_msg_FileOpenCancelNoFile"), DDPro.Software.Net20.Library.StatusMessages.MessageType.Green_ForeColor)
                Return False
            End If
            OpenFileName = _dia.FileName ' save selected FileName
        End If
        ' open-file procedure:
        ' clear form-name
        Me.Text = cLangXML.ReadValue("as_mf_frmMain")
        ' try to load file
        If cEditor.LoadLanguageXmlFile(OpenFileName) Then ' file loaded
            _openFileName = OpenFileName ' remind FileName
            _recentFileAddToList(_openFileName, True) ' remind file in Recent-List
            Me.Text = cLangXML.ReadValue("as_mf_frmMain") & " | " & _openFileName.Substring(_openFileName.LastIndexOf("\") + 1) ' apply FileName to Form-Name
        Else ' file could not be loaded
            cStatus.DisplayMessage(cLangXML.ReadValue("stat_msg_FileOpenErrorOpen"), DDPro.Software.Net20.Library.StatusMessages.MessageType.Red_ForeColor)
            Return False
        End If
        cEditor.LXML_DataSet.AcceptChanges()
        ' reset View-Option reminder
        ValEdit_GridRowNumber = 0
        ValEdit_Language = ""
        ValEdit_HelperLang = ""

        cStatus.DisplayMessage(cLangXML.ReadValue("stat_msg_FileOpenSuccess"), DDPro.Software.Net20.Library.StatusMessages.MessageType.Green_ForeColor)
        _CheckForAutoOpenForm()
        Return True
    End Function

    ''' <summary>
    ''' create a new File in Memory
    ''' </summary>
    ''' <param name="NoChangesCheck">optional set to TRUE to skip the ChangesCheck</param>
    ''' <returns>TRUE on success, FALSE on error</returns>
    Private Function _File_New(Optional ByVal NoChangesCheck As Boolean = False) As Boolean
        ' start create file
        cStatus.DisplayMessage(cLangXML.ReadValue("stat_msg_FileNewStarted"))
        If Not NoChangesCheck Then ' check for changes only if not skipped
            ' check for unsaved Changes and save if needed
            If Not _CheckForChangesHandling() Then
                Return False
            End If
        End If
        ' close open form(s) of file
        For Each _form As System.Windows.Forms.Form In Me.MdiChildren
            _form.Close()
        Next

        ' init DatatSet as new file
        _openFileName = ""
        cEditor.BaseInitDataSet()
        ' ToDO: read from Settings
        cEditor.OpenFileVersion = 2 ' init new File in FormatVersion 2 
        ' reset File-MetaData
        cEditor.OpenFileMetaData.Program = ""
        cEditor.OpenFileMetaData.Description = ""
        cEditor.OpenFileMetaData.SetNowAsUpDate()
        cEditor.OpenFileMetaData.AcceptChanges() ' remind that there are no changes
        ' set Text on Form
        Me.Text = cLangXML.ReadValue("as_mf_frmMain") & " | " & cLangXML.ReadValue("str_name_NewFile")
        ' reset View-Option reminder
        ValEdit_GridRowNumber = 0
        ValEdit_Language = ""
        ValEdit_HelperLang = ""
        ' reset Change-Reminder in DataSet
        cEditor.LXML_DataSet.AcceptChanges()
        ' info to user
        cStatus.DisplayMessage(cLangXML.ReadValue("stat_msg_FileNewSuccess"), DDPro.Software.Net20.Library.StatusMessages.MessageType.Green_ForeColor)
        Return True
    End Function

    ''' <summary>
    ''' Check for unsaved changes in open Forms and DataSet, save or ignore them if user wants
    ''' </summary>
    ''' <returns>TRUE if everything was ok / User wants to continue, FALSE if User wants to cancel</returns>
    Private Function _CheckForChangesHandling() As Boolean
        Dim _HasChanges As Boolean = False
        Dim _Continue As Boolean = False
        _GetChangeInfoFromFormsAndDataSet(_HasChanges, _Continue)
        If Not _Continue Then ' Error in DataSave - user cancelled
            cStatus.DisplayMessage(cLangXML.ReadValue("stat_msg_ChangesCheckDataReadFail"), DDPro.Software.Net20.Library.StatusMessages.MessageType.Red_ForeColor)
            Return False
        End If
        If _HasChanges Then ' there are Changes to Save
            Select Case cLangXML.MessageBox("OpenFileHasUnsavedChanges", DDPro.Software.Net20.Library.LanguageXML.MessageType.Confirm, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                Case Windows.Forms.DialogResult.Yes ' User wants to save
                    If Not _File_Save(False) Then
                        ' ask user for ignore error
                        If cLangXML.MessageBox("OpenFileSaveUnsavedChangesError", DDPro.Software.Net20.Library.LanguageXML.MessageType.ErrorMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then
                            ' user wants to cancel
                            cStatus.DisplayMessage(cLangXML.ReadValue("stat_msg_ChangesCheckCancelAfterSaveFail"), DDPro.Software.Net20.Library.StatusMessages.MessageType.Red_ForeColor)
                            Return False
                        End If
                    End If
                Case Windows.Forms.DialogResult.No ' User wants to skip the save
                    ' do nothing then display status-info...
                    cStatus.DisplayMessage(cLangXML.ReadValue("stat_msg_ChangesCheckUserSkipSave"))
                Case Else ' User wants to cancel
                    cStatus.DisplayMessage(cLangXML.ReadValue("stat_msg_ChangesCheckUserCancel"))
                    Return False
            End Select
        End If
        Return True
    End Function

    ''' <summary>
    ''' check for Changes in open File
    ''' </summary>
    ''' <param name="HasChanges">referenced Parameter for the Main Result - TRUE if there are Changes in DataSet, FALSE if no changes were made</param>
    ''' <param name="ContinueRun">referenced Parameter for Continue after check (FALSE if Save-To-Data Error occured)</param>
    Private Sub _GetChangeInfoFromFormsAndDataSet(ByRef HasChanges As Boolean, ByRef ContinueRun As Boolean)
        ' step 0: init ContinueValue to TRUE
        ContinueRun = True
        ' first: (try to) save all changes to internal data
        If Not _SaveDataFromOpenForms() Then
            ContinueRun = False
        End If
        ' second: (try to) save metadata to dataset - if needed
        If cEditor.OpenFileMetaData.HasChanges Then
            Dim _wasErr As Boolean = False
            If Not cEditor.SaveMetaValue(Declarations.MetaData.File.Fields.Program.Name, cEditor.OpenFileMetaData.Program) Then _wasErr = True
            If Not cEditor.SaveMetaValue(Declarations.MetaData.File.Fields.Description.Name, cEditor.OpenFileMetaData.Description) Then _wasErr = True
            If Not cEditor.SaveMetaValue(Declarations.MetaData.File.Fields.LastUpdate.Name, cEditor.OpenFileMetaData.LastUpdate.ToString(System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat)) Then _wasErr = True
            If _wasErr Then ' at least one value was not saved - stop run after this function
                ContinueRun = False
            Else '  all values were saved to the dataset - remind that in Object
                cEditor.OpenFileMetaData.AcceptChanges()
            End If
        End If
        ' third: check dataset for changes (may still be unchanged if n changes occured)
        HasChanges = cEditor.LXML_DataSet.HasChanges
    End Sub

    ''' <summary>
    ''' check if the Form-Open-Setting is active and apply
    ''' </summary>
    Private Sub _CheckForAutoOpenForm()
        Select Case cSettings.GetValue("DefaultForm", 0)
            Case 1 ' open values
                _ShowViewWindow(_ViewWindowType.LanguageData)
            Case 2 ' open items
                _ShowViewWindow(_ViewWindowType.LanguageItems)
            Case 3 ' open languages
                _ShowViewWindow(_ViewWindowType.LanguageList)
        End Select
    End Sub

    ''' <summary>
    ''' Method to show Properties-Dialog for open file
    ''' </summary>
    Private Sub _DisplayOpenFileProperties()
        If _openFileName <> "" Then ' file opened / saved
            If System.IO.File.Exists(_openFileName) Then ' if file exists
                '_callDisplayFileProperties(_openFileName) ' show Properties
                clsFilePropertiesDialog.OpenFileProperties(_openFileName)
            Else ' file not found
                cLangXML.MessageBox("OpenFileNotFound", Library.LanguageXML.MessageType.ErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else ' no file open
            cStatus.DisplayMessage(cLangXML.ReadValue("stat_msg_FileNotSavedNoProperties"), Library.StatusMessages.MessageType.Red_ForeColor)
        End If
    End Sub

    ''' <summary>Function to save Data as Fiel in Format Version 2</summary>
    ''' <returns>TRUE on success, FALSE on error</returns>
    Private Function _SaveDataFormatVersion2(ByVal FileName As String) As Boolean
        ' write file using class for that
        Dim _v2Save As New clsFileWriterV2(cEditor, FileName)
        Return _v2Save.SaveFile
    End Function

#End Region

#Region " Recent Files Handling "

    ''' <summary>internal List for recent files</summary>
    Private _recentFile_List As List(Of String)

    ''' <summary>init the recent files</summary>
    Private Sub _init_recentFiles()
        _recentFile_List = New List(Of String)
        _recentFileLoadList()
    End Sub

    ''' <summary>load the recent files from Settings...</summary>
    ''' <remarks>adding files in reverse order to keep order of items using the default-adder</remarks>
    Private Sub _recentFileLoadList()
        Dim _tmpVal As String = cSettings.GetValue("RecentFiles", "").Trim
        If _tmpVal <> "" Then ' there is data to load
            Dim _tmp() As String = _tmpVal.Split("|")
            Dim _max As Integer = _tmp.Length ' get number of items
            Dim _isMax As Integer = cSettings.GetValue("RecentFileMax", 8)
            If _max > _isMax Then ' if more then max-items
                For i As Integer = (_max - 1) To (_max - _isMax - 1) Step -1
                    _recentFileAddToList(_tmp(i), False) ' add without changing menu
                Next
            Else ' all items can be displayed
                For i As Integer = (_max - 1) To 0 Step -1
                    _recentFileAddToList(_tmp(i), False) ' add without changing menu
                Next
            End If
        End If
        ' update GUI
        _recentFilesCreateMenuItems()
    End Sub
    ''' <summary>save the recent files to Settings...</summary>
    Private Sub _recentFileSaveList()
        Dim _out As New System.Text.StringBuilder
        Dim _cnt As Integer = -1
        Dim _isMax As Integer = cSettings.GetValue("RecentFileMax", 8)
        For Each _file As String In _recentFile_List
            _cnt += 1
            If _cnt < _isMax Then
                _out.Append(_file)
                If (_cnt < (_isMax - 1)) And (_cnt < _recentFile_List.Count - 1) Then ' if not last item
                    _out.Append("|") ' add separator
                End If
            Else
                Exit For
            End If
        Next
        ' save to settings
        cSettings.SaveValue("RecentFiles", _out.ToString)
    End Sub

    ''' <summary>event-Handler for the Items in the Recent-Files-Menu</summary>
    ''' <remarks>used for the dynamic added items in the menu</remarks>
    Private Sub _recentFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim _tmpItem As System.Windows.Forms.ToolStripMenuItem = sender
        ' check if file present
        If System.IO.File.Exists(_tmpItem.Tag.ToString) Then
            'open
            _File_Open(True, _tmpItem.Tag.ToString) ' open file
        Else ' file not found - remove ? - ask user...
            If cLangXML.MessageBox("RecentFileNotFoundDelAsk", Library.LanguageXML.MessageType.Confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                'delete file from list
                _recentFileRemoveFromList(_tmpItem.Tag.ToString, True)
            End If
        End If
    End Sub

    ''' <summary>add a File to the List of recent Items - call moves Item to Position one if already in List</summary>
    ''' <param name="FileName">Full Path for the File to add</param>
    ''' <param name="GuiUpdate">set TRUE if Item should be displayed in menu directly after adding</param>
    Private Sub _recentFileAddToList(ByVal FileName As String, ByVal GuiUpdate As Boolean)
        Dim _tmpList As New List(Of String)
        _tmpList.Add(FileName)
        For Each _file As String In _recentFile_List
            If Not _tmpList.Contains(_file) Then ' add if not already in list
                _tmpList.Add(_file)
            End If
        Next
        _recentFile_List = _tmpList
        ' new list created - set menu if wished
        If GuiUpdate Then _recentFilesCreateMenuItems()
    End Sub

    ''' <summary>delete a File from the List of recent Items</summary>
    ''' <param name="FileName">>Full Path for the File to delete</param>
    ''' <param name="GuiUpdate">set TRUE if Item should be displayed in menu directly after adding</param>
    Private Sub _recentFileRemoveFromList(ByVal FileName As String, ByVal GuiUpdate As Boolean)
        _recentFile_List.Remove(FileName)
        ' new list created - set menu if wished
        If GuiUpdate Then _recentFilesCreateMenuItems()
    End Sub

    ''' <summary>create Menu-Items from current List of recent Files</summary>
    Private Sub _recentFilesCreateMenuItems()
        Dim _cnt As Integer = -1
        Dim _tmpItem As System.Windows.Forms.ToolStripMenuItem
        Dim _numString As String
        Me.lx_mniRecentFiles.DropDownItems.Clear() ' delete current list
        For Each _file As String In _recentFile_List
            _cnt += 1
            If _cnt < cSettings.GetValue("RecentFileMax", 8) Then ' as long as max. number of items is not reached
                _tmpItem = New System.Windows.Forms.ToolStripMenuItem
                If _cnt < 9 Then ' between 1 and 9
                    _numString = "&" & (_cnt + 1).ToString & ": "
                ElseIf _cnt = 9 Then ' Item 10
                    _numString = "1&0: "
                Else ' greater then 10
                    _numString = (_cnt + 1).ToString & ": "
                End If
                If _file.LastIndexOf("\") > -1 Then
                    _tmpItem.Text = _numString & _file.Substring(_file.LastIndexOf("\") + 1) ' only FileName in Menu
                Else
                    _tmpItem.Text = _numString & _file ' full item FileName in Menu because no \ found
                End If
                _tmpItem.Tag = _file ' full FileName in Tag
                _tmpItem.ToolTipText = _file ' full FileName in ToolTip
                Me.lx_mniRecentFiles.DropDownItems.Add(_tmpItem)
                AddHandler _tmpItem.Click, AddressOf _recentFile_Click
            Else
                Exit For
            End If
        Next
        ' if no items in list: add info-item
        If _cnt = -1 Then
            _tmpItem = New System.Windows.Forms.ToolStripMenuItem
            _tmpItem.Text = cLangXML.ReadValue("str_name_DummyRecentFile") ' create dummy-item
            _tmpItem.Enabled = False
            Me.lx_mniRecentFiles.DropDownItems.Add(_tmpItem)
        End If
    End Sub

#End Region

#Region " Form-Basics "

    ''' <summary>
    ''' initialize form on Load
    ''' </summary>
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = Cursors.AppStarting
        ' initialize Status-Message handling
        _init_status()

        ' initialize user-settings
        If Not _init_UserSettings() Then
            MsgBox("User-Settings could not be initialized...", MsgBoxStyle.Exclamation, "Error:")
        End If
        ' apply status-display-duration
        cStatus.AutoDeleteTime = (cSettings.GetValue("StatMsgDuration", 15) * 1000)
        ' initialize Language
        If Not _init_lang() Then ' language-init failed - full gui-lock
            _internal_GuiLock(eGuiLockLevel.Full)
            cStatus.DisplayMessage("Language-Data could not be initialized...", DDPro.Software.Net20.Library.StatusMessages.MessageType.Red_BackColor)
            Cursor.Current = Cursors.Default
            MsgBox("Language-Data could not be initialized...", MsgBoxStyle.Critical, "Error:")
            Exit Sub
        End If
        ' initialize RecentFiles
        _init_recentFiles()
        ' init Editor with new file - without change-check
        _File_New(True)
        ' initialize User-Handling
        If Not _init_users() Then
            _internal_GuiLock(eGuiLockLevel.Full)
            cStatus.DisplayMessage(cLangXML.ReadValue("stat_err_UserInitFail"), DDPro.Software.Net20.Library.StatusMessages.MessageType.Red_BackColor)
            Cursor.Current = Cursors.Default
            cLangXML.MessageBox("UserInitFail", DDPro.Software.Net20.Library.LanguageXML.MessageType.ErrorMessage)
            Exit Sub
        Else
            _internalRightsCheck() ' check rights
        End If
        ' set size and position by settings
        _frmInit_ApplyStartSize()
        _frmInit_ApplyStartPos()
        ' Display-Beta-Info and Version
        Me.mnBetaInfo.Text = "! Beta-Test ! V.: " & My.Application.Info.Version.ToString
        ' check for passed file
        If My.Application.CommandLineArgs.Count = 1 Then ' exact one argument

            ' ToDo: check for Settings-Reset as Argument - to restore default-settings (like form-position) if needed !!!

            If System.IO.File.Exists(My.Application.CommandLineArgs.Item(0)) Then ' check for valid file
                _File_Open(True, My.Application.CommandLineArgs.Item(0)) ' open file
            End If
        ElseIf My.Application.CommandLineArgs.Count > 1 Then ' only one file can be opened
            cLangXML.MessageBox("TooManyCommandLineArguments", Library.LanguageXML.MessageType.ErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else ' no file opened
            If _activeRole = eGuiLockLevel.NoLock Then ' if admin, then check if a form should be opened
                _CheckForAutoOpenForm()
            End If
        End If


        ' basic init done...
        Cursor.Current = Cursors.Default
    End Sub

    ''' <summary>
    ''' init the Form-Size using My.Settings
    ''' </summary>
    Private Sub _frmInit_ApplyStartSize()
        ' use custom-values for non-default
        Dim _startSize As Integer = cSettings.GetValue("StartSize", 0)
        If _startSize = 1 Or _startSize = 2 Then
            Me.Height = cSettings.GetValue("StartHeight", 450)
            Me.Width = cSettings.GetValue("StartWidth", 600)
        End If
    End Sub

    ''' <summary>
    ''' init Form-Position using My.Settings
    ''' </summary>
    Private Sub _frmInit_ApplyStartPos()
        Select Case cSettings.GetValue("StartPos", 0)
            Case 1 ' center on screen 1
                Dim _newX As Integer = 0
                Dim _newY As Integer = 0
                _newY = (My.Computer.Screen.Bounds.Height / 2) - (Me.Height / 2)
                If _newY < 0 Then _newY = 0 ' stay on screen
                _newX = (My.Computer.Screen.Bounds.Width / 2) - (Me.Width / 2)
                If _newX < 0 Then _newX = 0 ' stay on screen
                Me.Location = New System.Drawing.Point(_newX, _newY)
            Case 2 ' custom
                Me.Location = New System.Drawing.Point(cSettings.GetValue("StartX", 25), cSettings.GetValue("StartY", 25))
        End Select
    End Sub

    ''' <summary>
    ''' on App-Close do...
    ''' </summary>
    Private Sub frmMain_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        ' check for unsaved Changes and save if needed
        If Not _CheckForChangesHandling() Then ' save not possible --> cancel whished
            ' message to status
            cStatus.DisplayMessage(cLangXML.ReadValue("stat_msg_ToolCloseCancelAfterSaveErr"), DDPro.Software.Net20.Library.StatusMessages.MessageType.Red_ForeColor)
            e.Cancel = True
            Exit Sub
        End If
        ' other Close-Actions
        _recentFileSaveList() ' save recent Files
        If cSettings.GetValue("StartSize", 0) = 1 Then ' if size should be saved on exit
            cSettings.SaveValue("StartHeight", Short.Parse(Me.Height.ToString))
            cSettings.SaveValue("StartWidth", Short.Parse(Me.Width.ToString))
        End If
        If Not cSettings.SaveConfig() Then ' save settings
            ' message to status
            cStatus.DisplayMessage(cLangXML.ReadValue("stat_msg_ToolCloseCancelAfterConfigSaveErr"), DDPro.Software.Net20.Library.StatusMessages.MessageType.Red_ForeColor)
            e.Cancel = True
            Exit Sub
        End If
    End Sub

#End Region

#Region " Menu-Events "

    ' File - Operations
    Private Sub lx_mniNewFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lx_mniNewFile.Click
        If _File_New() Then _CheckForAutoOpenForm()
    End Sub
    Private Sub lx_mniOpenFile_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lx_mniOpenFile.Click
        _File_Open()
    End Sub
    Private Sub lx_mniSaveFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lx_mniSaveFile.Click
        _File_Save(False)
    End Sub
    Private Sub lx_mniSaveFileAs_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lx_mniSaveFileAs.Click
        _File_Save(True)
    End Sub
    ' File - Properties
    Private Sub lx_mniFileProperties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lx_mniFileProperties.Click
        _DisplayOpenFileProperties()
    End Sub

    ' Tool - Exit
    Private Sub lx_mniExitToolClick(ByVal sender As Object, ByVal e As EventArgs) Handles lx_mniExitTool.Click
        Application.Exit()
    End Sub

    ' View - Select Window
    Private Sub lx_mniShowLangData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lx_mniShowLangData.Click
        _ShowViewWindow(_ViewWindowType.LanguageData)
    End Sub
    Private Sub lx_mniShowLangList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lx_mniShowLangList.Click
        _ShowViewWindow(_ViewWindowType.LanguageList)
    End Sub
    Private Sub lx_mniShowLangItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lx_mniShowLangItems.Click
        _ShowViewWindow(_ViewWindowType.LanguageItems)
    End Sub
    Private Sub lx_mniAboutTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lx_mniAboutTool.Click
        _ShowViewWindow(_ViewWindowType.AboutTool)
    End Sub
    ' View - Settings
    Private Sub lx_mniSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lx_mniSettings.Click
        Dim _frm As New frmSettings
        If _frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            ' refresh auto-delete-time
            cStatus.AutoDeleteTime = (cSettings.GetValue("StatMsgDuration", 15) * 1000)
        End If
    End Sub

#End Region

#Region " Window-Handling "

    ''' <summary>reminder for size of Help-Column in Value-Edit</summary>
    Public ValEdit_HelpColSliderValue As Integer = frmLanguageData.tbHelperWidth.Maximum

    ''' <summary>reminder for selected Row of Help-Column in Value-Edit</summary>
    Public ValEdit_GridRowNumber As Integer = 0

    ''' <summary>reminder for the selected Language in Value-Edit</summary>
    Public ValEdit_Language As String = ""

    ''' <summary>reminder for the selected Helper-Language in Value-Edit</summary>
    Public ValEdit_HelperLang As String = ""

    ''' <summary>enum for definition of Window to show</summary>
    Private Enum _ViewWindowType
        ''' <summary>Language-Data (the Values for a Language)</summary>
        LanguageData = 100
        ''' <summary>Language-List Editor</summary>
        LanguageList = 200
        ''' <summary>Language-Items (for the Programmers ;-) --> create Values, set Names</summary>
        LanguageItems = 300
        ''' <summary>About-Dialog</summary>
        AboutTool = 900
    End Enum

    ''' <summary>open / show View-Window</summary>
    ''' <param name="Type">WindowType to open / show</param>
    Private Sub _ShowViewWindow(ByVal Type As _ViewWindowType)
        If Not _SaveDataFromOpenForms() Then ' Save data in open forms
            ' message to status
            cStatus.DisplayMessage(cLangXML.ReadValue("stat_msg_FormCloseDataNotSavedCancel"), DDPro.Software.Net20.Library.StatusMessages.MessageType.Red_ForeColor)
            Exit Sub
        End If
        Cursor.Current = Cursors.WaitCursor
        ' check if open
        Dim _frm_Open As System.Windows.Forms.Form
        Dim _frm_Found As Boolean = False
        Dim _frm_Name As String = ""
        ' defnine Form-Name (and check if role allows opening!)
        Select Case Type
            Case _ViewWindowType.LanguageList
                If _activeRole <= eGuiLockLevel.LanguageAdmin Then _frm_Name = "frmLanguageList"
            Case _ViewWindowType.LanguageItems
                If _activeRole = eGuiLockLevel.NoLock Then _frm_Name = "frmBaseData"
            Case _ViewWindowType.AboutTool
                _frm_Name = "frmAbout"
            Case Else ' Language-Data
                If _activeRole <= eGuiLockLevel.Editor Then _frm_Name = "frmLanguageData"
        End Select
        If _frm_Name = "" Then ' no name set - exit beacuse of right-error
            Cursor.Current = Cursors.Default
            cStatus.DisplayMessage(cLangXML.ReadValue("stat_msg_NoRightsToOpenForm"), Library.StatusMessages.MessageType.Red_ForeColor)
            Exit Sub
        End If

        ' check if open - or other form open (that should be closed)
        For Each _form As System.Windows.Forms.Form In Me.MdiChildren
            If _form.Name = _frm_Name Then ' form is open
                _frm_Open = _form
                _frm_Found = True
            Else ' not the form the user wants - close
                ' some forms need save-to-data before close
                _form.Close()
            End If
        Next
        ' chek if need to open
        If _frm_Found Then ' form is open
            _frm_Open.BringToFront()
        Else ' form must be opened
            Select Case Type
                Case _ViewWindowType.LanguageList
                    Dim _frm As New frmLanguageList
                    cLangXML.ApplyTextToForm(ApplyTo:=_frm, FormElementPrefix:="lx_", lxmlElementPrefix:="as_ls_")
                    _frm.MdiParent = Me
                    _frm.Location = New Point(0, 0)
                    _frm.Show()
                    _frm.WindowState = FormWindowState.Maximized
                Case _ViewWindowType.LanguageItems
                    Dim _frm As New frmBaseData
                    cLangXML.ApplyTextToForm(ApplyTo:=_frm, FormElementPrefix:="lx_", lxmlElementPrefix:="as_li_")
                    _frm.MdiParent = Me
                    _frm.Location = New Point(0, 0)
                    _frm.Show()
                    _frm.WindowState = FormWindowState.Maximized
                Case _ViewWindowType.AboutTool
                    Dim _frm As New frmAbout
                    cLangXML.ApplyTextToForm(ApplyTo:=_frm, FormElementPrefix:="lx_", lxmlElementPrefix:="as_af_")
                    _frm.MdiParent = Me
                    _frm.Location = New Point(0, 0)
                    _frm.Show()
                    _frm.WindowState = FormWindowState.Maximized
                Case Else ' Language-Data
                    Dim _frm As New frmLanguageData
                    cLangXML.ApplyTextToForm(ApplyTo:=_frm, FormElementPrefix:="lx_", lxmlElementPrefix:="as_ld_")
                    _frm.MdiParent = Me
                    _frm.Location = New Point(0, 0)
                    _frm.Show()
                    _frm.WindowState = FormWindowState.Maximized
            End Select
        End If
        Cursor.Current = Cursors.Default
    End Sub

    ''' <summary>save the Values from open forms to internal Data that can be saved</summary>
    ''' <returns>TRUE on success, FALSE on error</returns>
    Private Function _SaveDataFromOpenForms() As Boolean
        Dim _result As Boolean
        For Each _form As System.Windows.Forms.Form In Me.MdiChildren
            ' some forms need save-to-data before close
            _result = False
            Select Case _form.Name
                Case "frmBaseData" ' language-items
                    Dim _tmp As frmBaseData = _form
                    _result = _tmp.SaveInputsToInternalData()
                Case "frmLanguageData" ' language-values
                    Dim _tmp As frmLanguageData = _form
                    _result = _tmp.SaveInputsToInternalData()
                Case Else ' every other form that is not specified returns true... ;-)
                    _result = True
            End Select
            If Not _result Then ' not saved - no message if wished
                If cLangXML.MessageBox("FormDataNotSaved", Library.LanguageXML.MessageType.ErrorMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2, "{form}", _form.Text) <> Windows.Forms.DialogResult.Yes Then
                    Return False
                End If
            End If
        Next
        Return True
    End Function

#End Region

End Class