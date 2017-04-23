' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' |   Language XML Editor  |   http://lxml.codeplex.com   |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' | Authors:                                              |
' | ========                                              |
' | - Manuel a.k.a. Dade [DD-Productions]                 |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' |    visit the CodePlex-Page for License and Details    |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =

''' <summary>Form for Application-Settings</summary>
Public Class frmSettings

    Private Sub frmSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        frmMain.cLangXML.ApplyTextToForm(ApplyTo:=Me, FormElementPrefix:="lx_", lxmlElementPrefix:="as_ts_") ' set language
        ' apply settings:
        ' read custom-values - correct them before load if needed...

        ' Start X-Pos
        If frmMain.cSettings.GetValue("StartX", 25) < Me.numStartPosX.Minimum Then
            frmMain.cSettings.SaveValue("StartX", Short.Parse(Me.numStartPosX.Minimum))
        End If
        If frmMain.cSettings.GetValue("StartX", 25) > Me.numStartPosX.Maximum Then
            frmMain.cSettings.SaveValue("StartX", Short.Parse(Me.numStartPosX.Maximum))
        End If
        Me.numStartPosX.Value = frmMain.cSettings.GetValue("StartX", 25)

        ' Start Y-Pos
        If frmMain.cSettings.GetValue("StartY", 25) < Me.numStartPosY.Minimum Then
            frmMain.cSettings.SaveValue("StartY", Short.Parse(Me.numStartPosY.Minimum))
        End If
        If frmMain.cSettings.GetValue("StartY", 25) > Me.numStartPosY.Maximum Then
            frmMain.cSettings.SaveValue("StartY", Short.Parse(Me.numStartPosY.Maximum))
        End If
        Me.numStartPosY.Value = frmMain.cSettings.GetValue("StartY", 25)

        ' Start Height
        If frmMain.cSettings.GetValue("StartHeight", 450) < Me.numStartSizeHeight.Minimum Then
            frmMain.cSettings.SaveValue("StartHeight", Short.Parse(Me.numStartSizeHeight.Minimum))
        End If
        If frmMain.cSettings.GetValue("StartHeight", 450) > Me.numStartSizeHeight.Maximum Then
            frmMain.cSettings.SaveValue("StartHeight", Short.Parse(Me.numStartSizeHeight.Maximum))
        End If
        Me.numStartSizeHeight.Value = frmMain.cSettings.GetValue("StartHeight", 450)

        ' Start Width
        If frmMain.cSettings.GetValue("StartWidth", 600) < Me.numStartSizeWidth.Minimum Then
            frmMain.cSettings.SaveValue("StartWidth", Short.Parse(Me.numStartSizeWidth.Minimum))
        End If
        If frmMain.cSettings.GetValue("StartWidth", 600) > Me.numStartSizeWidth.Maximum Then
            frmMain.cSettings.SaveValue("StartWidth", Short.Parse(Me.numStartSizeWidth.Maximum))
        End If
        Me.numStartSizeWidth.Value = frmMain.cSettings.GetValue("StartWidth", 600)

        ' set Option-Buttons
        Select Case frmMain.cSettings.GetValue("DefaultForm", 0) ' AutoOpenForm
            Case 1
                Me.lx_rbtAutoOpenValues.Checked = True
            Case 2
                Me.lx_rbtAutoOpenItems.Checked = True
            Case 3
                Me.lx_rbtAutoOpenLanguages.Checked = True
            Case Else ' default on unknown (and 0)
                Me.lx_rbtAutoOpenNothing.Checked = True
        End Select

        Select Case frmMain.cSettings.GetValue("StartPos", 0) ' StartPosition
            Case 1
                Me.lx_rbtStartPosCenter.Checked = True
            Case 2
                Me.lx_rbtStartPosCustom.Checked = True
            Case Else ' default on unknown (and 0)
                Me.lx_rbtStartPosRegular.Checked = True
        End Select

        Select Case frmMain.cSettings.GetValue("StartSize", 0) ' StartSize
            Case 1
                Me.lx_rbtStartSizeSaveOnClose.Checked = True
            Case 2
                Me.lx_rbtStartSizeCustom.Checked = True
            Case Else ' default on unknown (and 0)
                Me.lx_rbtStartSizeStandard.Checked = True
        End Select

        ' Number of Recent Files
        If frmMain.cSettings.GetValue("RecentFileMax", 8) < Me.numRecentFiles.Minimum Then
            frmMain.cSettings.SaveValue("RecentFileMax", Short.Parse(Me.numRecentFiles.Minimum))
        End If
        If frmMain.cSettings.GetValue("RecentFileMax", 8) > Me.numRecentFiles.Maximum Then
            frmMain.cSettings.SaveValue("RecentFileMax", Short.Parse(Me.numRecentFiles.Maximum))
        End If
        Me.numRecentFiles.Value = frmMain.cSettings.GetValue("RecentFileMax", 8)

        ' Duration for StatusMessages
        If frmMain.cSettings.GetValue("StatMsgDuration", 15) < Me.numStatMsgDuration.Minimum Then
            frmMain.cSettings.SaveValue("StatMsgDuration", Short.Parse(Me.numStatMsgDuration.Minimum))
        End If
        If frmMain.cSettings.GetValue("StatMsgDuration", 15) > Me.numStatMsgDuration.Maximum Then
            frmMain.cSettings.SaveValue("StatMsgDuration", Short.Parse(Me.numStatMsgDuration.Maximum))
        End If
        Me.numStatMsgDuration.Value = frmMain.cSettings.GetValue("StatMsgDuration", 15)


    End Sub

    ' ok
    Private Sub lx_btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lx_btnOk.Click
        ' save settings:

        ' Custom-Values
        frmMain.cSettings.SaveValue("StartX", Short.Parse(Me.numStartPosX.Value.ToString))
        frmMain.cSettings.SaveValue("StartY", Short.Parse(Me.numStartPosY.Value.ToString))
        frmMain.cSettings.SaveValue("StartHeight", Short.Parse(Me.numStartSizeHeight.Value.ToString))
        frmMain.cSettings.SaveValue("StartWidth", Short.Parse(Me.numStartSizeWidth.Value.ToString))

        ' Start Pos
        If Me.lx_rbtStartPosCenter.Checked Then
            frmMain.cSettings.SaveValue("StartPos", Short.Parse("1"))
        ElseIf Me.lx_rbtStartPosCustom.Checked Then
            frmMain.cSettings.SaveValue("StartPos", Short.Parse("2"))
        Else ' default on any other
            frmMain.cSettings.SaveValue("StartPos", Short.Parse("0"))
        End If

        ' Start Size
        If Me.lx_rbtStartSizeSaveOnClose.Checked Then
            frmMain.cSettings.SaveValue("StartSize", Short.Parse("1"))
        ElseIf Me.lx_rbtStartSizeCustom.Checked Then
            frmMain.cSettings.SaveValue("StartSize", Short.Parse("2"))
        Else ' default on any other
            frmMain.cSettings.SaveValue("StartSize", Short.Parse("0"))
        End If

        ' AutoOpen Form
        If Me.lx_rbtAutoOpenValues.Checked Then
            frmMain.cSettings.SaveValue("DefaultForm", Short.Parse("1"))
        ElseIf Me.lx_rbtAutoOpenItems.Checked Then
            frmMain.cSettings.SaveValue("DefaultForm", Short.Parse("2"))
        ElseIf Me.lx_rbtAutoOpenLanguages.Checked Then
            frmMain.cSettings.SaveValue("DefaultForm", Short.Parse("3"))
        Else ' default on any other
            frmMain.cSettings.SaveValue("DefaultForm", Short.Parse("0"))
        End If

        ' other settings
        frmMain.cSettings.SaveValue("RecentFileMax", Short.Parse(Me.numRecentFiles.Value.ToString))
        frmMain.cSettings.SaveValue("StatMsgDuration", Short.Parse(Me.numStatMsgDuration.Value.ToString))

        ' close
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    ' cancel
    Private Sub lx_btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lx_btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    ' "logic" for enable / disable custom value-inputs
    Private Sub lx_rbtStartPosCustom_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lx_rbtStartPosCustom.CheckedChanged
        Me.tlpCustomStartPos.Enabled = Me.lx_rbtStartPosCustom.Checked
    End Sub
    Private Sub lx_rbtStartSizeCustom_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lx_rbtStartSizeCustom.CheckedChanged
        Me.tlpCustomStartSize.Enabled = Me.lx_rbtStartSizeCustom.Checked
    End Sub

End Class