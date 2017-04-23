' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' |   Language XML Editor  |   http://lxml.codeplex.com   |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' | Authors:                                              |
' | ========                                              |
' | - Manuel a.k.a. Dade [DD-Productions]                 |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' |    visit the CodePlex-Page for License and Details    |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =

''' <summary>Dialog to select the File-Format (LXML File-Version)</summary>
Public Class frmFileFormat

    Private _version As Integer = 2

    Public Property FileVersion() As Integer
        Get
            Return _version
        End Get
        Set(ByVal value As Integer)
            _version = value
        End Set
    End Property

    Private Sub frmFileFormat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        frmMain.cLangXML.ApplyTextToForm(ApplyTo:=Me, FormElementPrefix:="lx_", lxmlElementPrefix:="as_fv_") ' set language
        Select Case _version
            Case 1 ' Version 1 if selected
                Me.lx_rbtVersion1.Checked = True
            Case Else ' Version 2 by Default
                Me.lx_rbtVersion2.Checked = True
        End Select
    End Sub

    Private Sub lx_btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lx_btnOK.Click
        ' read selection
        If Me.lx_rbtVersion1.Checked Then ' version 1 selected
            _version = 1
        Else ' default version 2
            _version = 2
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub lx_btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lx_btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class