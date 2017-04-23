' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' |   Language XML Editor  |   http://lxml.codeplex.com   |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' | Authors:                                              |
' | ========                                              |
' | - Manuel a.k.a. Dade [DD-Productions]                 |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' |    visit the CodePlex-Page for License and Details    |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =

''' <summary>Form for the About-Dialog</summary>
Public Class frmAbout

    ''' <summary>Function to trigger a Language-Update of the GUI (all Elements that are not applied by Name-Prefix)</summary>
    ''' <returns>TRUE on success, FALSE on error</returns>
    Public Function PerformLanguageChange() As Boolean
        Dim _frm As frmMain = Me.MdiParent ' get parent
        Dim _level As frmMain.eGuiLockLevel = _frm.CurrentRoleinfo ' get Role
        Select Case _level
            Case frmMain.eGuiLockLevel.Editor ' editor
                Me.lblDetCurrentRole.Text = _frm.cLangXML.ReadValue("stat_txt_RightsEditor")
            Case frmMain.eGuiLockLevel.LanguageAdmin ' lang-admin
                Me.lblDetCurrentRole.Text = _frm.cLangXML.ReadValue("stat_txt_RightsLangAdmin")
            Case frmMain.eGuiLockLevel.NoLock ' admin
                Me.lblDetCurrentRole.Text = _frm.cLangXML.ReadValue("stat_txt_RightsAdmin")
            Case Else ' no role
                Me.lblDetCurrentRole.Text = _frm.cLangXML.ReadValue("stat_txt_UnknownRole")
        End Select
        Return True
    End Function

    ' form - init
    Private Sub frmAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' load License-Text
        Me.rtbLicense.Rtf = My.Resources.MSPL.ToString
        ' ceate instances from all Libraries
        Dim _lxml As New DDPro.Software.Net20.Library.LanguageXML
        Dim _aes As New DDPro.Software.Net20.Library.Rijndael
        Dim _statMsg As New DDPro.Software.Net20.Library.StatusMessages
        Dim _lcux As New DDPro.Software.Net20.Library.UserList
        Dim _set As New DDPro.Software.Net20.Library.UserSettings("TestApp")
        ' show Version-Infos
        Me.lblDetToolVersion.Text = My.Application.Info.Version.ToString
        Me.lblDetLxmlVersion.Text = _lxml.DllVersion.ToString
        Me.lblDetStatMsgVersion.Text = _statMsg.DllVersion.ToString
        Me.lblDetLcuxVersion.Text = _lcux.DllVersion.ToString
        Me.lblDetRijndaelVersion.Text = _aes.DllVersion.ToString
        Me.lblDetSettingsVersion.Text = _set.DllVersion.ToString
        ' set dynamic Language-Vars
        PerformLanguageChange()
    End Sub

End Class