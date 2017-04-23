<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub


    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.menuMain = New System.Windows.Forms.MenuStrip
        Me.lx_mnFile = New System.Windows.Forms.ToolStripMenuItem
        Me.lx_mniNewFile = New System.Windows.Forms.ToolStripMenuItem
        Me.lx_mniOpenFile = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.lx_mniSaveFile = New System.Windows.Forms.ToolStripMenuItem
        Me.lx_mniSaveFileAs = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.lx_mniFileProperties = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.lx_mniRecentFiles = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.lx_mniExitTool = New System.Windows.Forms.ToolStripMenuItem
        Me.lx_mnView = New System.Windows.Forms.ToolStripMenuItem
        Me.lx_mniShowLangData = New System.Windows.Forms.ToolStripMenuItem
        Me.lx_mniShowLangList = New System.Windows.Forms.ToolStripMenuItem
        Me.lx_mniShowLangItems = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.lx_mniSettings = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.lx_mniAboutTool = New System.Windows.Forms.ToolStripMenuItem
        Me.mnBetaInfo = New System.Windows.Forms.ToolStripMenuItem
        Me.statMain = New System.Windows.Forms.StatusStrip
        Me.sblCurrentAction = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.sdrpLanguageSelect = New System.Windows.Forms.ToolStripDropDownButton
        Me.tipMain = New System.Windows.Forms.ToolTip(Me.components)
        Me.menuMain.SuspendLayout()
        Me.statMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'menuMain
        '
        Me.menuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lx_mnFile, Me.lx_mnView, Me.mnBetaInfo})
        Me.menuMain.Location = New System.Drawing.Point(0, 0)
        Me.menuMain.Name = "menuMain"
        Me.menuMain.Size = New System.Drawing.Size(592, 24)
        Me.menuMain.TabIndex = 5
        Me.menuMain.Text = "MenuStrip"
        '
        'lx_mnFile
        '
        Me.lx_mnFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lx_mniNewFile, Me.lx_mniOpenFile, Me.ToolStripSeparator3, Me.lx_mniSaveFile, Me.lx_mniSaveFileAs, Me.ToolStripSeparator4, Me.lx_mniFileProperties, Me.ToolStripSeparator5, Me.lx_mniRecentFiles, Me.ToolStripSeparator2, Me.lx_mniExitTool})
        Me.lx_mnFile.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder
        Me.lx_mnFile.Name = "lx_mnFile"
        Me.lx_mnFile.Size = New System.Drawing.Size(33, 20)
        Me.lx_mnFile.Text = "file"
        '
        'lx_mniNewFile
        '
        Me.lx_mniNewFile.Image = CType(resources.GetObject("lx_mniNewFile.Image"), System.Drawing.Image)
        Me.lx_mniNewFile.ImageTransparentColor = System.Drawing.Color.Black
        Me.lx_mniNewFile.Name = "lx_mniNewFile"
        Me.lx_mniNewFile.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.lx_mniNewFile.Size = New System.Drawing.Size(239, 22)
        Me.lx_mniNewFile.Text = "new"
        '
        'lx_mniOpenFile
        '
        Me.lx_mniOpenFile.Image = CType(resources.GetObject("lx_mniOpenFile.Image"), System.Drawing.Image)
        Me.lx_mniOpenFile.ImageTransparentColor = System.Drawing.Color.Black
        Me.lx_mniOpenFile.Name = "lx_mniOpenFile"
        Me.lx_mniOpenFile.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.lx_mniOpenFile.Size = New System.Drawing.Size(239, 22)
        Me.lx_mniOpenFile.Text = "open"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(236, 6)
        '
        'lx_mniSaveFile
        '
        Me.lx_mniSaveFile.Image = CType(resources.GetObject("lx_mniSaveFile.Image"), System.Drawing.Image)
        Me.lx_mniSaveFile.ImageTransparentColor = System.Drawing.Color.Black
        Me.lx_mniSaveFile.Name = "lx_mniSaveFile"
        Me.lx_mniSaveFile.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.lx_mniSaveFile.Size = New System.Drawing.Size(239, 22)
        Me.lx_mniSaveFile.Text = "save"
        '
        'lx_mniSaveFileAs
        '
        Me.lx_mniSaveFileAs.Name = "lx_mniSaveFileAs"
        Me.lx_mniSaveFileAs.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                    Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.lx_mniSaveFileAs.Size = New System.Drawing.Size(239, 22)
        Me.lx_mniSaveFileAs.Text = "save as"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(236, 6)
        '
        'lx_mniFileProperties
        '
        Me.lx_mniFileProperties.Image = CType(resources.GetObject("lx_mniFileProperties.Image"), System.Drawing.Image)
        Me.lx_mniFileProperties.Name = "lx_mniFileProperties"
        Me.lx_mniFileProperties.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.I), System.Windows.Forms.Keys)
        Me.lx_mniFileProperties.Size = New System.Drawing.Size(239, 22)
        Me.lx_mniFileProperties.Text = "file properties"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(236, 6)
        '
        'lx_mniRecentFiles
        '
        Me.lx_mniRecentFiles.Name = "lx_mniRecentFiles"
        Me.lx_mniRecentFiles.Size = New System.Drawing.Size(239, 22)
        Me.lx_mniRecentFiles.Text = "recent files"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(236, 6)
        '
        'lx_mniExitTool
        '
        Me.lx_mniExitTool.Image = CType(resources.GetObject("lx_mniExitTool.Image"), System.Drawing.Image)
        Me.lx_mniExitTool.Name = "lx_mniExitTool"
        Me.lx_mniExitTool.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Q), System.Windows.Forms.Keys)
        Me.lx_mniExitTool.Size = New System.Drawing.Size(239, 22)
        Me.lx_mniExitTool.Text = "exit"
        '
        'lx_mnView
        '
        Me.lx_mnView.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lx_mniShowLangData, Me.lx_mniShowLangList, Me.lx_mniShowLangItems, Me.ToolStripSeparator1, Me.lx_mniSettings, Me.ToolStripSeparator6, Me.lx_mniAboutTool})
        Me.lx_mnView.Name = "lx_mnView"
        Me.lx_mnView.Size = New System.Drawing.Size(41, 20)
        Me.lx_mnView.Text = "view"
        '
        'lx_mniShowLangData
        '
        Me.lx_mniShowLangData.Image = CType(resources.GetObject("lx_mniShowLangData.Image"), System.Drawing.Image)
        Me.lx_mniShowLangData.Name = "lx_mniShowLangData"
        Me.lx_mniShowLangData.ShortcutKeys = System.Windows.Forms.Keys.F6
        Me.lx_mniShowLangData.Size = New System.Drawing.Size(176, 22)
        Me.lx_mniShowLangData.Text = "lang-data"
        '
        'lx_mniShowLangList
        '
        Me.lx_mniShowLangList.Image = CType(resources.GetObject("lx_mniShowLangList.Image"), System.Drawing.Image)
        Me.lx_mniShowLangList.Name = "lx_mniShowLangList"
        Me.lx_mniShowLangList.ShortcutKeys = System.Windows.Forms.Keys.F7
        Me.lx_mniShowLangList.Size = New System.Drawing.Size(176, 22)
        Me.lx_mniShowLangList.Text = "lang-list"
        '
        'lx_mniShowLangItems
        '
        Me.lx_mniShowLangItems.Image = CType(resources.GetObject("lx_mniShowLangItems.Image"), System.Drawing.Image)
        Me.lx_mniShowLangItems.Name = "lx_mniShowLangItems"
        Me.lx_mniShowLangItems.ShortcutKeys = System.Windows.Forms.Keys.F8
        Me.lx_mniShowLangItems.Size = New System.Drawing.Size(176, 22)
        Me.lx_mniShowLangItems.Text = "lang-base"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(173, 6)
        '
        'lx_mniSettings
        '
        Me.lx_mniSettings.Image = CType(resources.GetObject("lx_mniSettings.Image"), System.Drawing.Image)
        Me.lx_mniSettings.Name = "lx_mniSettings"
        Me.lx_mniSettings.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F11), System.Windows.Forms.Keys)
        Me.lx_mniSettings.Size = New System.Drawing.Size(176, 22)
        Me.lx_mniSettings.Text = "settings"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(173, 6)
        '
        'lx_mniAboutTool
        '
        Me.lx_mniAboutTool.Image = CType(resources.GetObject("lx_mniAboutTool.Image"), System.Drawing.Image)
        Me.lx_mniAboutTool.Name = "lx_mniAboutTool"
        Me.lx_mniAboutTool.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F12), System.Windows.Forms.Keys)
        Me.lx_mniAboutTool.Size = New System.Drawing.Size(176, 22)
        Me.lx_mniAboutTool.Text = "about"
        '
        'mnBetaInfo
        '
        Me.mnBetaInfo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.mnBetaInfo.Enabled = False
        Me.mnBetaInfo.Name = "mnBetaInfo"
        Me.mnBetaInfo.Size = New System.Drawing.Size(100, 20)
        Me.mnBetaInfo.Text = "! BETA-Release !"
        Me.mnBetaInfo.Visible = False
        '
        'statMain
        '
        Me.statMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sblCurrentAction, Me.ToolStripStatusLabel1, Me.sdrpLanguageSelect})
        Me.statMain.Location = New System.Drawing.Point(0, 399)
        Me.statMain.Name = "statMain"
        Me.statMain.Size = New System.Drawing.Size(592, 22)
        Me.statMain.TabIndex = 7
        Me.statMain.Text = "StatusStrip"
        '
        'sblCurrentAction
        '
        Me.sblCurrentAction.Name = "sblCurrentAction"
        Me.sblCurrentAction.Size = New System.Drawing.Size(503, 17)
        Me.sblCurrentAction.Spring = True
        Me.sblCurrentAction.Text = "start..."
        Me.sblCurrentAction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(10, 17)
        Me.ToolStripStatusLabel1.Text = " "
        '
        'sdrpLanguageSelect
        '
        Me.sdrpLanguageSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.sdrpLanguageSelect.Image = CType(resources.GetObject("sdrpLanguageSelect.Image"), System.Drawing.Image)
        Me.sdrpLanguageSelect.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.sdrpLanguageSelect.Name = "sdrpLanguageSelect"
        Me.sdrpLanguageSelect.Size = New System.Drawing.Size(64, 20)
        Me.sdrpLanguageSelect.Text = "language"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(592, 421)
        Me.Controls.Add(Me.menuMain)
        Me.Controls.Add(Me.statMain)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.menuMain
        Me.MinimumSize = New System.Drawing.Size(600, 450)
        Me.Name = "frmMain"
        Me.Text = "frmMain"
        Me.menuMain.ResumeLayout(False)
        Me.menuMain.PerformLayout()
        Me.statMain.ResumeLayout(False)
        Me.statMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tipMain As System.Windows.Forms.ToolTip
    Friend WithEvents sblCurrentAction As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents statMain As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lx_mniExitTool As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lx_mniSaveFileAs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lx_mniNewFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lx_mnFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lx_mniOpenFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lx_mniSaveFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuMain As System.Windows.Forms.MenuStrip
    Friend WithEvents lx_mnView As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lx_mniShowLangList As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lx_mniShowLangData As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lx_mniShowLangItems As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sdrpLanguageSelect As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents mnBetaInfo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lx_mniSettings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lx_mniFileProperties As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lx_mniRecentFiles As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lx_mniAboutTool As System.Windows.Forms.ToolStripMenuItem

End Class
