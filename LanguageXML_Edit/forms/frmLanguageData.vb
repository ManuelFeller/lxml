' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' |   Language XML Editor  |   http://lxml.codeplex.com   |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' | Authors:                                              |
' | ========                                              |
' | - Manuel a.k.a. Dade [DD-Productions]                 |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' |    visit the CodePlex-Page for License and Details    |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =

''' <summary>Form to edit the Language-Values</summary>
Public Class frmLanguageData

#Region " internal Fields and Objects "

    ''' <summary>is the form loaded complete / not closing</summary>
    Private _FormActive As Boolean = False
    ''' <summary>the internal Object to handle MetaData for a Language</summary>
    Private _MetaData As clsLanguageMetaData

    ''' <summary>internal Name for the active Language</summary>
    Private _ActiveLanguage As String
    ''' <summary>internal Name for the last loaded Helper-Language</summary>
    Private _HelperLanguage As String = ""
    ''' <summary>internal Name for the initial Helper-Language on Form-Load</summary>
    Private _HelperLanguageLoad As String

    ''' <summary>helper for Change-Dtect in Grid - Value before Edit</summary>
    Private _OpenItemOldVal As String = ""
    '''' <summary>helper for Change-Detect in Grid - changes since last LanguageLoad?</summary>
    'Private _OpenLangChanges As Boolean = False

#End Region

#Region " basic Elements for Triggers (Save, Language-Update and MetaUpdate-Handler)"

    ''' <summary>
    ''' Function to trigger Save-Data-To-DataModel
    ''' </summary>
    ''' <returns>TRUE on success, FALSE on error</returns>
    Public Function SaveInputsToInternalData() As Boolean
        ' exit Edit-Mode in Grid if Cell in edit...
        If Me.dgvLangData.IsCurrentCellInEditMode Then
            Me.dgvLangData.EndEdit()
        End If
        ' call Save-Function for active Language
        Return _SaveChangedValues()
    End Function
    ''' <summary>
    ''' Function to trigger a Language-Update of the GUI (all Elements that are not applied by Name-Prefix)
    ''' </summary>
    ''' <returns>TRUE on success, FALSE on error</returns>
    Public Function PerformLanguageChange() As Boolean
        For Each _column As DataGridViewColumn In Me.dgvLangData.Columns
            Select Case _column.Name
                Case Declarations.LangEditGrid.Columns.ID.Name
                    _column.HeaderText = frmMain.cLangXML.ReadValue("dgv_headBase_ID")
                Case Declarations.LangEditGrid.Columns.Name.Name
                    _column.HeaderText = frmMain.cLangXML.ReadValue("dgv_headBase_Name")
                Case Declarations.LangEditGrid.Columns.Description.Name
                    _column.HeaderText = frmMain.cLangXML.ReadValue("dgv_headBase_Description")
                Case Declarations.LangEditGrid.Columns.Value.Name
                    _column.HeaderText = frmMain.cLangXML.ReadValue("dgv_headLang_Value")
                Case Declarations.LangEditGrid.Columns.HelperValue.Name
                    _column.HeaderText = frmMain.cLangXML.ReadValue("dgv_headLang_HelperValue")
            End Select
        Next
        Return True
    End Function
    ''' <summary>
    ''' Method to trigger the Update of the Language-MetaData "last Update" on GUI
    ''' </summary>
    Public Sub PerformMetaUpDate(Optional ByVal SkipGlobalUpdate As Boolean = False)
        Me.lblLastUpdate.Text = _MetaData.LastUpdate.ToString
        Me.lblLastUpdate.Tag = _MetaData.LastUpdate.ToString
        ' save lastUpdate to File-MetaData - if not supressed (to avoid update-errors on initial load-to-gui of value)
        If Not SkipGlobalUpdate Then frmMain.cEditor.OpenFileMetaData.LastUpdate = _MetaData.LastUpdate
    End Sub

#End Region

#Region " Basic events for Form (open / close) "

    ' loading
    Private Sub frmLanguageData_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim _frm As frmMain = Me.MdiParent ' get reference of MainForm

        ' alway first - set current language
        If _frm.ValEdit_Language.Trim <> "" Then
            _ActiveLanguage = _frm.ValEdit_Language
        Else
            _ActiveLanguage = "DEFAULT"
        End If
        ' then Helper-Language
        If _frm.ValEdit_HelperLang.Trim <> "" Then
            _HelperLanguageLoad = _frm.ValEdit_HelperLang
        Else
            _HelperLanguageLoad = "DEFAULT"
        End If
        ' initialize ISO-Strings
        Dim _IsoList() As String = My.Settings.app_IsoStrings.Split("|")
        For Each _iso As String In _IsoList
            Me.cbxIsoString.Items.Add(_iso)
        Next


        ' initialize Language-List
        _InitializeLangDropDowns()
        ' init grid
        _InitializeGrid()
        ' load active Language to GUI
        _SetActiveEditLanguage(_ActiveLanguage)
        ' init the Helper-Column if needed
        _UpdateHelperData()
        ' set Values for selected cell in grid and slider-value for help-column width
        Me.tbHelperWidth.Value = _frm.ValEdit_HelpColSliderValue ' read old value to TrackBar
        tbHelperWidth_Scroll(Me, Nothing) ' Set Value to Grid by Event-Fire


        Me.Show()
        If (Me.dgvLangData.Rows.Count - 1) >= _frm.ValEdit_GridRowNumber And _frm.ValEdit_GridRowNumber < -1 Then ' if valid row in grid
            'Me.dgvLangData.Rows(0).Cells(0).Selected = False
            'Me.dgvLangData.Rows(_frm.ValEdit_GridRowNumber).Cells(0).Selected = True
            Me.dgvLangData.FirstDisplayedScrollingRowIndex = _frm.ValEdit_GridRowNumber
        End If

        ' remind that form is prepared
        _FormActive = True
    End Sub
    ' closing
    Private Sub frmBaseData_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        ' save "dynamic" values for next open
        Dim _frm As frmMain = Me.MdiParent
        _frm.ValEdit_GridRowNumber = Me.dgvLangData.FirstDisplayedScrollingRowIndex ' ToDO: change to current cell -> row of it...
        _frm.ValEdit_HelpColSliderValue = Me.tbHelperWidth.Value ' save width of Helper-Column
        _frm.ValEdit_Language = Me.drpActiveLang.Text ' save the selected Language
        _frm.ValEdit_HelperLang = Me.drpHelperLang.Text ' save the selected helper Language
        ' inputs in Text-Boxes are saved by leave if there are changes
        _FormActive = False
    End Sub

#End Region

#Region " Form-Events for Editor "

    ' active language changed
    Private Sub drpActiveLang_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpActiveLang.SelectedIndexChanged
        If Not _FormActive Then Exit Sub
        If Me.drpActiveLang.Text <> _ActiveLanguage And _FormActive Then
            _SetActiveEditLanguage(Me.drpActiveLang.Text) ' set language
            Cursor.Current = Cursors.WaitCursor
            _UpdateHelperData() ' apply HelperData
            Cursor.Current = Cursors.Default
        End If
    End Sub
    ' helper language changed
    Private Sub drpHelperLang_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpHelperLang.SelectedIndexChanged
        If Not _FormActive Then Exit Sub
        Cursor.Current = Cursors.WaitCursor
        _UpdateHelperData()
        Cursor.Current = Cursors.Default
    End Sub

    ' set width of Helper-Value Column
    Private Sub tbHelperWidth_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbHelperWidth.Scroll
        Me.dgvLangData.Columns(Declarations.LangEditGrid.Columns.HelperValue.Name).Width = 500 - Me.tbHelperWidth.Value
    End Sub

    ' save changes in cell to dataset
    Private Sub dgvLangData_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLangData.CellValueChanged
        If Not _FormActive Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub ' Header-Change fires this Event..!
        If e.ColumnIndex < 0 Then Exit Sub
        ' run only on Value-Column-Change
        If Me.dgvLangData.Columns(e.ColumnIndex).Name = Declarations.LangEditGrid.Columns.Value.Name Then
            Dim _tabName As String = Declarations.LXML_DataSet.Tables.LangData.NamePrefix & _ActiveLanguage
            ' check if empty - the delete from language
            With Me.dgvLangData.Rows(e.RowIndex)
                ' value can be nothing: delete content trigger
                Dim _delTrigger As Boolean = False
                If IsNothing(Me.dgvLangData.CurrentCell.Value) Then
                    _delTrigger = True
                Else ' value is present - empty?
                    If Me.dgvLangData.CurrentCell.Value.ToString = "" Then
                        _delTrigger = True
                    End If
                End If
                If _delTrigger Then ' delete-value
                    If Not frmMain.cEditor.DeleteLangValueByID(.Cells(Declarations.LangEditGrid.Columns.ID.Name).Value, _tabName) Then
                        ' value not "saved" (deleted)
                        frmMain.cStatus.DisplayMessage(frmMain.cLangXML.ReadValue("stat_msg_NewValueNotSaved"), DDPro.Software.Net20.Library.StatusMessages.MessageType.Red_BackColor)
                    Else ' value "saved" (deleted)
                        frmMain.cStatus.DisplayMessage(frmMain.cLangXML.ReadValue("stat_msg_NewValueSaved"))
                        Me._MetaData.SetNowAsUpDate() ' remind change in Data
                    End If
                Else ' add / update
                    If Not frmMain.cEditor.SaveLangValue(.Cells(Declarations.LangEditGrid.Columns.ID.Name).Value, .Cells(Declarations.LangEditGrid.Columns.Value.Name).Value, _tabName) Then
                        ' value not saved
                        frmMain.cStatus.DisplayMessage(frmMain.cLangXML.ReadValue("stat_msg_NewValueNotSaved"), DDPro.Software.Net20.Library.StatusMessages.MessageType.Red_BackColor)
                    Else ' value saved
                        frmMain.cStatus.DisplayMessage(frmMain.cLangXML.ReadValue("stat_msg_NewValueSaved"))
                        Me._MetaData.SetNowAsUpDate() ' remind change in Data
                    End If
                End If
            End With
        End If
    End Sub

    ' Meta-Data: Change-Detect and Save for Iso-String
    Private Sub cbxIsoString_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxIsoString.Leave
        _metaIsoStringUpdater()
    End Sub
    ' Meta-Data: Change-Detect and Save for Display-Name
    Private Sub tbxDisplayName_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbxDisplayName.Leave
        _metaDisplayNameUpdater()
    End Sub
    ' Meta-Data: Change-Detect and Save for Author
    Private Sub tbxAuthor_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbxAuthor.Leave
        _metaAuthorUpdater()
    End Sub
    ' Meta-Data: Change-Detect and Save for Version
    Private Sub tbxVersion_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbxVersion.Leave
        _metaVersionUpdater()
    End Sub
    ' Meta-Data: Change-Detect and Save for InfoText
    Private Sub tbxInfoText_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbxInfoText.Leave
        _metaInfoTextUpdater()
    End Sub

#End Region

#Region " internal Worker "

    ''' <summary>
    ''' initialize the Edit-Grid: create Columns, load base-Data (Items), set format
    ''' </summary>
    Private Sub _InitializeGrid()
        Me.dgvLangData.Rows.Clear()
        Me.dgvLangData.Columns.Clear()
        ' initialize Columns for Edit-Grid
        Dim MultiLineStyle As New System.Windows.Forms.DataGridViewCellStyle
        MultiLineStyle.WrapMode = DataGridViewTriState.True
        ' initial create with language-set
        Me.dgvLangData.Columns.Add(Declarations.LangEditGrid.Columns.ID.Name, frmMain.cLangXML.ReadValue("dgv_headBase_ID"))
        Me.dgvLangData.Columns.Add(Declarations.LangEditGrid.Columns.Name.Name, frmMain.cLangXML.ReadValue("dgv_headBase_Name"))
        Me.dgvLangData.Columns.Add(Declarations.LangEditGrid.Columns.Description.Name, frmMain.cLangXML.ReadValue("dgv_headBase_Description"))
        Me.dgvLangData.Columns.Add(Declarations.LangEditGrid.Columns.Value.Name, frmMain.cLangXML.ReadValue("dgv_headLang_Value"))
        Me.dgvLangData.Columns.Add(Declarations.LangEditGrid.Columns.HelperValue.Name, frmMain.cLangXML.ReadValue("dgv_headLang_HelperValue"))
        ' set size and other properties
        Me.dgvLangData.Columns(Declarations.LangEditGrid.Columns.ID.Name).Width = 50
        Me.dgvLangData.Columns(Declarations.LangEditGrid.Columns.ID.Name).ReadOnly = True
        Me.dgvLangData.Columns(Declarations.LangEditGrid.Columns.Name.Name).Width = 100
        Me.dgvLangData.Columns(Declarations.LangEditGrid.Columns.Name.Name).ReadOnly = True
        Me.dgvLangData.Columns(Declarations.LangEditGrid.Columns.Description.Name).Width = 100
        Me.dgvLangData.Columns(Declarations.LangEditGrid.Columns.Description.Name).ReadOnly = True
        Me.dgvLangData.Columns(Declarations.LangEditGrid.Columns.Value.Name).MinimumWidth = 250
        Me.dgvLangData.Columns(Declarations.LangEditGrid.Columns.Value.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Me.dgvLangData.Columns(Declarations.LangEditGrid.Columns.Value.Name).DefaultCellStyle = MultiLineStyle
        Me.dgvLangData.Columns(Declarations.LangEditGrid.Columns.HelperValue.Name).Width = 500 - Me.tbHelperWidth.Value
        Me.dgvLangData.Columns(Declarations.LangEditGrid.Columns.HelperValue.Name).ReadOnly = True
        Me.dgvLangData.Columns(Declarations.LangEditGrid.Columns.HelperValue.Name).DefaultCellStyle = MultiLineStyle
        Me.dgvLangData.Columns(Declarations.LangEditGrid.Columns.HelperValue.Name).Visible = False ' init column hidden - show later by code
        ' initialize Items of Language:
        Dim _tmpIdx As Integer ' index of new Row
        For Each _row As DataRow In frmMain.cEditor.LXML_DataSet.Tables(Declarations.LXML_DataSet.Tables.ItemData.Name).Rows
            _tmpIdx = Me.dgvLangData.Rows.Add()
            Me.dgvLangData.Rows(_tmpIdx).Cells(Declarations.LangEditGrid.Columns.ID.Name).Value = _row.Item(Declarations.LXML_DataSet.Tables.ItemData.Columns.iID.Name)
            Me.dgvLangData.Rows(_tmpIdx).Cells(Declarations.LangEditGrid.Columns.Name.Name).Value = _row.Item(Declarations.LXML_DataSet.Tables.ItemData.Columns.iName.Name)
            Me.dgvLangData.Rows(_tmpIdx).Cells(Declarations.LangEditGrid.Columns.Description.Name).Value = _row.Item(Declarations.LXML_DataSet.Tables.ItemData.Columns.iDescription.Name)
            ' format for readonly cells
            Me.dgvLangData.Rows(_tmpIdx).Cells(Declarations.LangEditGrid.Columns.ID.Name).Style.BackColor = Me.BackColor
            Me.dgvLangData.Rows(_tmpIdx).Cells(Declarations.LangEditGrid.Columns.Name.Name).Style.BackColor = Me.BackColor
            Me.dgvLangData.Rows(_tmpIdx).Cells(Declarations.LangEditGrid.Columns.Description.Name).Style.BackColor = Me.BackColor
            Me.dgvLangData.Rows(_tmpIdx).Cells(Declarations.LangEditGrid.Columns.HelperValue.Name).Style.BackColor = Me.BackColor
        Next
    End Sub
    ''' <summary>
    ''' set the List of available Languages to the DropDown-Controls for active and Helper-Language
    ''' </summary>
    Private Sub _InitializeLangDropDowns()
        Dim _languages As List(Of String) = frmMain.cEditor.GetInternalLanguageNamesList
        Me.drpActiveLang.Items.Clear()
        Me.drpHelperLang.Items.Clear()
        Dim _cnt As Integer = -1
        Dim _posLang As Integer = -1
        Dim _posHelper As Integer = -1
        ' check if defined languages are (still) available - else set to default
        Dim _foundLang As Boolean = False
        Dim _foundHelper As Boolean = False
        For Each _lang As String In _languages
            If _lang = _ActiveLanguage Then
                _foundLang = True
                If _foundHelper Then Exit For ' exit if both are found
            End If
            If _lang = _HelperLanguageLoad Then
                _foundHelper = True
                If _foundLang Then Exit For ' exit if both are found
            End If
        Next
        If Not _foundLang Then ' if active not found then set default
            _ActiveLanguage = "DEFAULT"
        End If
        If Not _foundHelper Then ' if active not found then set default
            _HelperLanguageLoad = "DEFAULT"
        End If
        ' add all items
        For Each _lang As String In _languages
            If _posLang = -1 Or _posHelper = _cnt = -1 Then ' defined Languages not found yet
                _cnt += 1
            End If
            If _lang = _ActiveLanguage Then ' active Language (DEFAULT at start)
                _posLang = _cnt
            End If
            If _lang = _HelperLanguageLoad Then ' helper Language (DEFAULT at start)
                _posHelper = _cnt
            End If
            ' add to DropDowns
            Me.drpActiveLang.Items.Add(_lang)
            Me.drpHelperLang.Items.Add(_lang)
        Next
        If _posLang <> -1 Then ' set active Language if found in List
            Me.drpActiveLang.SelectedIndex = _posLang
        End If
        If _posHelper <> -1 Then ' set helper Language if found in List
            Me.drpHelperLang.SelectedIndex = _posHelper
        End If
    End Sub
    ''' <summary>
    ''' apply new Language to Editor
    ''' </summary>
    ''' <param name="NewLanguage">internal Name for language to switch to</param>
    Private Sub _SetActiveEditLanguage(ByVal NewLanguage As String)
        _FormActive = False
        ' Check for Data-Changes before change of Language
        If Not _SaveChangedValues() Then
            frmMain.cStatus.DisplayMessage(frmMain.cLangXML.ReadValue("stat_msg_EditLangChangeCancelAfterError"), DDPro.Software.Net20.Library.StatusMessages.MessageType.Red_BackColor)
            _FormActive = True
            Exit Sub
        End If
        ' still running - apply new language to editor
        Cursor.Current = Cursors.WaitCursor
        _ActiveLanguage = NewLanguage

        'set Name for Language-Table
        Dim _tblName As String = Declarations.LXML_DataSet.Tables.LangData.NamePrefix & _ActiveLanguage

        ' init MetaData
        _InitMetaObejctForLang(_tblName)
        ' Display MetaData in GUI
        _ApplyMetaDataToGui()
        ' set current Langauge-Values to Grid
        _FormActive = False
        For Each _row As DataGridViewRow In Me.dgvLangData.Rows ' for each row in Grid
            ' set Value to Grid
            _row.Cells(Declarations.LangEditGrid.Columns.Value.Name).Value = frmMain.cEditor.GetLangValueByID(_row.Cells(Declarations.LangEditGrid.Columns.ID.Name).Value, _tblName, False)
        Next
        _FormActive = True
        Cursor.Current = Cursors.Default
    End Sub
    ''' <summary>
    ''' read MetaData from Language to internal Object
    ''' </summary>
    ''' <param name="LangTable">Name of Language-Table to use</param>
    Private Sub _InitMetaObejctForLang(ByVal LangTable As String)
        ' init MetaData
        _MetaData = New clsLanguageMetaData()
        ' set Language MetaData-Object
        _MetaData.IsoString = frmMain.cEditor.GetLangValueByID(Declarations.MetaData.Language.Fields.IsoString.Name, LangTable)
        _MetaData.DisplayName = frmMain.cEditor.GetLangValueByID(Declarations.MetaData.Language.Fields.DisplayName.Name, LangTable)
        _MetaData.InfoText = frmMain.cEditor.GetLangValueByID(Declarations.MetaData.Language.Fields.InfoText.Name, LangTable)
        _MetaData.Author = frmMain.cEditor.GetLangValueByID(Declarations.MetaData.Language.Fields.Author.Name, LangTable)
        _MetaData.Version = frmMain.cEditor.GetLangValueByID(Declarations.MetaData.Language.Fields.Version.Name, LangTable)
        ' set Date as last Item to avoid errors with last Update
        _MetaData.ApplyLastUpdate(frmMain.cEditor.GetLangValueByID(Declarations.MetaData.Language.Fields.lastUpdate.Name, LangTable))
        ' set HasChanges to FALSE...
        _MetaData.AcceptChanges()
        ' add Event for Date-Update
        AddHandler _MetaData.UpDateChanged, AddressOf PerformMetaUpDate
    End Sub
    ''' <summary>
    ''' load the Meta-Data into GUI-Fields
    ''' </summary>
    ''' <remarks>sets Tag to compare if value has changed</remarks>
    Private Sub _ApplyMetaDataToGui()
        Me.tbxAuthor.Text = _MetaData.Author
        Me.tbxAuthor.Tag = _MetaData.Author
        Me.tbxDisplayName.Text = _MetaData.DisplayName
        Me.tbxDisplayName.Tag = _MetaData.DisplayName
        Me.tbxInfoText.Text = _MetaData.InfoText
        Me.tbxInfoText.Tag = _MetaData.InfoText
        Me.tbxVersion.Text = _MetaData.Version
        Me.tbxVersion.Tag = _MetaData.Version
        Me.cbxIsoString.Text = _MetaData.IsoString
        Me.cbxIsoString.Tag = _MetaData.IsoString
        PerformMetaUpDate(True) ' set last Update - without affecting the global update-date of file
    End Sub
    ''' <summary>
    ''' Check if Helper-Language is other then active Language --> then display Helper-Values
    ''' </summary>
    Private Sub _UpdateHelperData()
        If Me.drpActiveLang.Text <> Me.drpHelperLang.Text Then ' Helper-Lang activated
            If Not Me.tbHelperWidth.Visible Then ' if helper-column not visible, then show
                Me.dgvLangData.Columns(Declarations.LangEditGrid.Columns.HelperValue.Name).Visible = True
                Me.dgvLangData.Height -= 28
                Me.lx_lblHelpSizeSlide.Visible = True
                Me.tbHelperWidth.Visible = True
                _HelperLanguage = Me.drpHelperLang.Text
                Dim _tblName As String = Declarations.LXML_DataSet.Tables.LangData.NamePrefix & _HelperLanguage
                ' set Langauge-Values
                For Each _row As DataGridViewRow In Me.dgvLangData.Rows ' for each row in Grid
                    ' set Value to Grid
                    _row.Cells(Declarations.LangEditGrid.Columns.HelperValue.Name).Value = frmMain.cEditor.GetLangValueByID(_row.Cells(Declarations.LangEditGrid.Columns.ID.Name).Value, _tblName, False)
                Next
            End If
        Else ' Helper-Lang deactivated - same as active
            If Me.lx_lblHelpSizeSlide.Visible Or Me.tbHelperWidth.Visible Then ' if items are visible (not initial load)
                Me.dgvLangData.Columns(Declarations.LangEditGrid.Columns.HelperValue.Name).Visible = False
                Me.lx_lblHelpSizeSlide.Visible = False
                Me.tbHelperWidth.Visible = False
                Me.dgvLangData.Height += 28
            End If
        End If
    End Sub
    ''' <summary>
    ''' save changed Values in GUI
    ''' </summary>
    ''' <returns>TRUE on succes / ignore error, FALSE on error without ignore</returns>
    Private Function _SaveChangedValues() As Boolean
        If IsNothing(_MetaData) Then Return True ' exit TRUE if MetaData not initialized - nothing to save...
        Cursor.Current = Cursors.WaitCursor
        Dim _langTabName As String = Declarations.LXML_DataSet.Tables.LangData.NamePrefix & _ActiveLanguage
        Dim _wasErr As Boolean
        'take over changes text-boxes that were not leaved until this point
        _metaIsoStringUpdater()
        _metaDisplayNameUpdater()
        _metaAuthorUpdater()
        _metaVersionUpdater()
        _metaInfoTextUpdater()
        If _MetaData.HasChanges Then
            ' save to dataset
            _wasErr = False
            If Not frmMain.cEditor.SaveLangValue(Declarations.MetaData.Language.Fields.Author.Name, _MetaData.Author, _langTabName) Then _wasErr = True
            If Not frmMain.cEditor.SaveLangValue(Declarations.MetaData.Language.Fields.DisplayName.Name, _MetaData.DisplayName, _langTabName) Then _wasErr = True
            If Not frmMain.cEditor.SaveLangValue(Declarations.MetaData.Language.Fields.InfoText.Name, _MetaData.InfoText, _langTabName) Then _wasErr = True
            If Not frmMain.cEditor.SaveLangValue(Declarations.MetaData.Language.Fields.IsoString.Name, _MetaData.IsoString, _langTabName) Then _wasErr = True
            If Not frmMain.cEditor.SaveLangValue(Declarations.MetaData.Language.Fields.lastUpdate.Name, _MetaData.LastUpdate.ToString(System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat), _langTabName) Then _wasErr = True
            If Not frmMain.cEditor.SaveLangValue(Declarations.MetaData.Language.Fields.Version.Name, _MetaData.Version, _langTabName) Then _wasErr = True
            ' remind save if no error
            If Not _wasErr Then _MetaData.AcceptChanges()
        End If

        Cursor.Current = Cursors.Default
        If _MetaData.HasChanges Then ' MetaData contains still unsaved changes
            Dim _ItemText As String = ""
            ' let user confirm that errors should be ignored
            If frmMain.cLangXML.MessageBox("SaveBeforeLangChangeFail", DDPro.Software.Net20.Library.LanguageXML.MessageType.Confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then
                ' cancel by user after error
                Return False
            End If
        End If
        Return True
    End Function
    ''' <summary>
    ''' Meta-Data: Change-Detect and Save for Iso-String
    ''' </summary>
    Private Sub _metaIsoStringUpdater()
        If Me.cbxIsoString.Text <> Me.cbxIsoString.Tag.ToString Then
            _MetaData.IsoString = Me.cbxIsoString.Text
            Me.cbxIsoString.Tag = Me.cbxIsoString.Text
        End If
    End Sub
    ''' <summary>
    ''' Meta-Data: Change-Detect and Save for Display-Name
    ''' </summary>
    Private Sub _metaDisplayNameUpdater()
        If Me.tbxDisplayName.Text <> Me.tbxDisplayName.Tag.ToString Then
            _MetaData.DisplayName = Me.tbxDisplayName.Text
            Me.tbxDisplayName.Tag = Me.tbxDisplayName.Text
        End If
    End Sub
    ''' <summary>
    ''' Meta-Data: Change-Detect and Save for Author
    ''' </summary>
    Private Sub _metaAuthorUpdater()
        If Me.tbxAuthor.Text <> Me.tbxAuthor.Tag.ToString Then
            _MetaData.Author = Me.tbxAuthor.Text
            Me.tbxAuthor.Tag = Me.tbxAuthor.Text
        End If
    End Sub
    ''' <summary>
    ''' Meta-Data: Change-Detect and Save for Version
    ''' </summary>
    Private Sub _metaVersionUpdater()
        If Me.tbxVersion.Text <> Me.tbxVersion.Tag.ToString Then
            _MetaData.Version = Me.tbxVersion.Text
            Me.tbxVersion.Tag = Me.tbxVersion.Text
        End If
    End Sub
    ''' <summary>
    '''  Meta-Data: Change-Detect and Save for InfoText
    ''' </summary>
    Private Sub _metaInfoTextUpdater()
        If Me.tbxInfoText.Text <> Me.tbxInfoText.Tag.ToString Then
            _MetaData.InfoText = Me.tbxInfoText.Text
            Me.tbxInfoText.Tag = Me.tbxInfoText.Text
        End If
    End Sub

#End Region

End Class