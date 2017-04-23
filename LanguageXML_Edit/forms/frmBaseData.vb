' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' |   Language XML Editor  |   http://lxml.codeplex.com   |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' | Authors:                                              |
' | ========                                              |
' | - Manuel a.k.a. Dade [DD-Productions]                 |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' |    visit the CodePlex-Page for License and Details    |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =

''' <summary>Form to edit the Language-Value-Definitions</summary>
Public Class frmBaseData

    ''' <summary>
    ''' is the form loaded complete / not closing
    ''' </summary>
    Private _FormActive As Boolean = False

    ''' <summary>
    ''' Function to trigger Save-Data-To-DataModel
    ''' </summary>
    ''' <returns>TRUE on success, FALSE on error</returns>
    Public Function SaveInputsToInternalData() As Boolean
        ' exit Edit-Mode in Grid if Cell in edit...
        If Me.dgvBaseItems.IsCurrentCellInEditMode Then
            Me.dgvBaseItems.EndEdit()
        End If
        ' if current cell / row has changes that are not in the DataSet 
        If Me.dgvBaseItems.IsCurrentRowDirty Then
            Me.ValidateChildren() ' save Data to bound Table in DataSet
        End If
        ' save MetaValues only only if there are changes
        If Me.tbxProgramName.Text <> Me.tbxProgramName.Tag.ToString Then
            frmMain.cEditor.OpenFileMetaData.Program = Me.tbxProgramName.Text
        End If
        If Me.tbxDescription.Text <> Me.tbxDescription.Tag.ToString Then
            frmMain.cEditor.OpenFileMetaData.Description = Me.tbxDescription.Text
        End If
        ' done...
        Return True
    End Function
    ''' <summary>
    ''' Function to trigger a Language-Update of the GUI (all Elements that are not applied by Name-Prefix)
    ''' </summary>
    ''' <returns>TRUE on success, FALSE on error</returns>
    Public Function PerformLanguageChange() As Boolean
        For Each _column As DataGridViewColumn In Me.dgvBaseItems.Columns
            Select Case _column.Name
                Case Declarations.LXML_DataSet.Tables.ItemData.Columns.iID.Name
                    _column.HeaderText = frmMain.cLangXML.ReadValue("dgv_headBase_ID")
                Case Declarations.LXML_DataSet.Tables.ItemData.Columns.iName.Name
                    _column.HeaderText = frmMain.cLangXML.ReadValue("dgv_headBase_Name")
                Case Declarations.LXML_DataSet.Tables.ItemData.Columns.iDescription.Name
                    _column.HeaderText = frmMain.cLangXML.ReadValue("dgv_headBase_Description")
            End Select
        Next
        Return True
    End Function
    ''' <summary>
    ''' Method to trigger the Update of the File-MetaData "last Update" on GUI
    ''' </summary>
    Public Sub PerformMetaUpDate()
        Me.lblLastUpdateInfo.Text = frmMain.cEditor.OpenFileMetaData.LastUpdate.ToString
        Me.lblLastUpdateInfo.Tag = frmMain.cEditor.OpenFileMetaData.LastUpdate.ToString
    End Sub

    ' loading
    Private Sub frmBaseData_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = Cursors.WaitCursor
        ' init data to display
        _InitDataBinding()
        ' set Header-Text for Columns by using Language-Trigger
        PerformLanguageChange()
        Cursor.Current = Cursors.Default
        _FormActive = True
    End Sub
    ' closing
    Private Sub frmBaseData_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        ' inputs in Text-Boxes are saved by leave if there are changes
        _FormActive = False
    End Sub

    ' init the basic Informations in GUI
    Private Sub _InitDataBinding()
        ' load File Meta-Data
        Me.tbxProgramName.Text = frmMain.cEditor.OpenFileMetaData.Program
        Me.tbxProgramName.Tag = frmMain.cEditor.OpenFileMetaData.Program
        Me.tbxDescription.Text = frmMain.cEditor.OpenFileMetaData.Description
        Me.tbxDescription.Tag = frmMain.cEditor.OpenFileMetaData.Description
        PerformMetaUpDate()
        ' bind DataSet-Table to Grid and set Layout
        Me.dgvBaseItems.DataSource = frmMain.cEditor.LXML_DataSet.Tables(Declarations.LXML_DataSet.Tables.ItemData.Name)
        Me.dgvBaseItems.RowHeadersWidth = 15
        Me.dgvBaseItems.Columns(Declarations.LXML_DataSet.Tables.ItemData.Columns.iID.Name).Width = 50
        Me.dgvBaseItems.Columns(Declarations.LXML_DataSet.Tables.ItemData.Columns.iID.Name).ReadOnly = True
        Me.dgvBaseItems.Columns(Declarations.LXML_DataSet.Tables.ItemData.Columns.iID.Name).DefaultCellStyle.BackColor = Me.BackColor
        Me.dgvBaseItems.Columns(Declarations.LXML_DataSet.Tables.ItemData.Columns.iName.Name).Width = 100
        Me.dgvBaseItems.Columns(Declarations.LXML_DataSet.Tables.ItemData.Columns.iDescription.Name).MinimumWidth = 100
        Me.dgvBaseItems.Columns(Declarations.LXML_DataSet.Tables.ItemData.Columns.iDescription.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

    End Sub

    ' update Meta-Values on leave of cell (if needed)
    Private Sub dgvBaseItems_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBaseItems.CellValueChanged
        If _FormActive Then ' only perform action if form is in active mode (not opening or colsing) to prevent incorrect Update-Date from Grid-Init / Exit
            frmMain.cEditor.OpenFileMetaData.SetNowAsUpDate()
        End If
    End Sub

    ' update Meta-Values on leave of TextBox (if needed)
    Private Sub tbxProgramName_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbxProgramName.Leave
        If Me.tbxProgramName.Text <> Me.tbxProgramName.Tag.ToString Then
            frmMain.cEditor.OpenFileMetaData.Program = Me.tbxProgramName.Text
            Me.tbxProgramName.Tag = Me.tbxProgramName.Text
        End If
    End Sub
    ' update Meta-Values on leave of TextBox (if needed)
    Private Sub tbxDescription_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbxDescription.Leave
        If Me.tbxDescription.Text <> Me.tbxDescription.Tag.ToString Then
            frmMain.cEditor.OpenFileMetaData.Description = Me.tbxDescription.Text
            Me.tbxDescription.Tag = Me.tbxDescription.Text
        End If
    End Sub

    ' item-delete
    Private Sub lx_btnDeleteItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lx_btnDeleteItems.Click
        ' delete selected items here
        If Me.dgvBaseItems.SelectedCells.Count > 0 Then ' if at least one column is selected
            Cursor.Current = Cursors.WaitCursor
            ' get ID's form selected rows...
            Dim _IDs As New List(Of Integer)
            For Each _cell As DataGridViewCell In Me.dgvBaseItems.SelectedCells
                If Not _IDs.Contains(Me.dgvBaseItems.Rows(_cell.RowIndex).Cells(Declarations.LXML_DataSet.Tables.ItemData.Columns.iID.Name).Value) Then
                    _IDs.Add(Me.dgvBaseItems.Rows(_cell.RowIndex).Cells(Declarations.LXML_DataSet.Tables.ItemData.Columns.iID.Name).Value)
                End If
            Next
            ' build string with all selected IDs
            Dim _IdList As New System.Text.StringBuilder
            For i As Integer = 0 To _IDs.Count - 1
                If i > 0 Then ' not first item
                    _IdList.Append(", " & _IDs(i).ToString)
                Else ' first item
                    _IdList.Append(_IDs(i).ToString)
                End If
            Next
            Cursor.Current = Cursors.Default
            ' ask user to confirm delete
            If frmMain.cLangXML.MessageBox("ConfirmLangItemDelete", Library.LanguageXML.MessageType.Confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2, "{id}", _IdList.ToString) <> Windows.Forms.DialogResult.Yes Then
                ' cancel by user
                frmMain.cStatus.DisplayMessage(frmMain.cLangXML.ReadValue("stat_msg_DeleteItemUserCancel"), DDPro.Software.Net20.Library.StatusMessages.MessageType.Red_ForeColor)
                Exit Sub
            End If
            Cursor.Current = Cursors.WaitCursor
            ' ID-List ready and confirmed by user - execute delete
            Dim _Err As New List(Of String) ' item to collect error-id's
            For Each _id As Integer In _IDs ' delete items
                If Not frmMain.cEditor.DeleteLanguageItemFromDataSet(_id) Then ' delete failed
                    _Err.Add(_id.ToString) 'add ID to Error-List
                End If
            Next
            If _Err.Count > 0 Then ' not all itemd deleted
                _IdList = New System.Text.StringBuilder
                For i As Integer = 0 To _Err.Count - 1
                    If i > 0 Then ' not first item
                        _IdList.Append(", " & _Err(i).ToString)
                    Else ' first item
                        _IdList.Append(_Err(i).ToString)
                    End If
                Next
                frmMain.cStatus.DisplayMessage(frmMain.cLangXML.ReadProcessedValue("stat_msg_DeleteItemsFailed", "{id}", _IdList.ToString), DDPro.Software.Net20.Library.StatusMessages.MessageType.Red_BackColor)
            Else ' items deleted
                frmMain.cStatus.DisplayMessage(frmMain.cLangXML.ReadValue("stat_msg_DeleteItemsSuccess"), DDPro.Software.Net20.Library.StatusMessages.MessageType.Green_ForeColor)
            End If
            Cursor.Current = Cursors.Default
        End If
    End Sub

    ' handle DataError in Grid
    Private Sub dgvBaseItems_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvBaseItems.DataError
        frmMain.cLangXML.MessageBox("GridItemsDataError", Library.LanguageXML.MessageType.ErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

End Class