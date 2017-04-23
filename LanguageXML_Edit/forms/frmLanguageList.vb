' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' |   Language XML Editor  |   http://lxml.codeplex.com   |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' | Authors:                                              |
' | ========                                              |
' | - Manuel a.k.a. Dade [DD-Productions]                 |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' |    visit the CodePlex-Page for License and Details    |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =

''' <summary>Form for editing the Language-List</summary>
Public Class frmLanguageList

    Private Sub _init_LangList()
        Dim _langList As List(Of String) = frmMain.cEditor.GetInternalLanguageNamesList
        Me.lstLanguages.Items.Clear()
        For Each _language As String In _langList
            Me.lstLanguages.Items.Add(_language)
        Next
    End Sub

    Private Sub frmLanguageList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _init_LangList()
    End Sub

    Private Sub lx_btnDeleteLang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lx_btnDeleteLang.Click
        If Me.lstLanguages.SelectedItems.Count = 1 Then ' language selected
            If Me.lstLanguages.SelectedItem.ToString.ToLower <> "default" Then ' not the Default-Language
                ' ask user to confirm delete
                If frmMain.cLangXML.MessageBox("DeleteLangConfirm", Library.LanguageXML.MessageType.Confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2, "{lang}", Me.lstLanguages.SelectedItem.ToString) <> Windows.Forms.DialogResult.Yes Then
                    ' cancel by user
                    frmMain.cStatus.DisplayMessage(frmMain.cLangXML.ReadProcessedValue("stat_msg_DelLangCancelByUser", "{lang}", Me.lstLanguages.SelectedItem.ToString), DDPro.Software.Net20.Library.StatusMessages.MessageType.Red_ForeColor)
                    Exit Sub
                End If
                ' still running - delete language
                If Not frmMain.cEditor.DeleteLanguageFromDataSet(Me.lstLanguages.SelectedItem.ToString) Then ' delete failed
                    ' language could not be deleted
                    frmMain.cStatus.DisplayMessage(frmMain.cLangXML.ReadProcessedValue("stat_msg_DelLangFailed", "{lang}", Me.lstLanguages.SelectedItem.ToString), DDPro.Software.Net20.Library.StatusMessages.MessageType.Red_ForeColor)
                Else ' delete success
                    frmMain.cStatus.DisplayMessage(frmMain.cLangXML.ReadProcessedValue("stat_msg_LanguageDeleted", "{lang}", Me.lstLanguages.SelectedItem.ToString), DDPro.Software.Net20.Library.StatusMessages.MessageType.Green_ForeColor)
                    _init_LangList() ' refresh language-list
                End If
            Else ' Default-Language can not be deleted - show info on status-bar
                frmMain.cStatus.DisplayMessage(frmMain.cLangXML.ReadValue("stat_msg_NoDelteDefaultLang"), DDPro.Software.Net20.Library.StatusMessages.MessageType.Red_BackColor)
            End If
        Else ' no language selcted - nothing to delete
            frmMain.cStatus.DisplayMessage(frmMain.cLangXML.ReadValue("stat_msg_NoLangToDelSelected"), DDPro.Software.Net20.Library.StatusMessages.MessageType.Red_ForeColor)
        End If
    End Sub

    Private Sub lx_btnAddLang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lx_btnAddLang.Click
        If Me.tbxNewLangName.Text.Trim = "" Then
            ' nothing to add
            frmMain.cStatus.DisplayMessage(frmMain.cLangXML.ReadValue("stat_msg_NoLangToAdd"), DDPro.Software.Net20.Library.StatusMessages.MessageType.Red_ForeColor)
            Exit Sub
        End If
        If Not frmMain.cEditor.AddLanguage2DataSet(Me.tbxNewLangName.Text.Trim) Then
            ' error adding language
            frmMain.cStatus.DisplayMessage(frmMain.cLangXML.ReadProcessedValue("stat_msg_LangNotAdded", "{lang}", Me.tbxNewLangName.Text), DDPro.Software.Net20.Library.StatusMessages.MessageType.Red_BackColor)
        Else ' add was performed
            frmMain.cStatus.DisplayMessage(frmMain.cLangXML.ReadProcessedValue("stat_msg_LangAdded", "{lang}", Me.tbxNewLangName.Text), DDPro.Software.Net20.Library.StatusMessages.MessageType.Green_ForeColor)
            _init_LangList() ' refresh language-list
        End If
    End Sub

End Class