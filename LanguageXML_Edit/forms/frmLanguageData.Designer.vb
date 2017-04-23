<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLanguageData
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLanguageData))
        Me.lx_lblLastUpdate = New System.Windows.Forms.Label
        Me.tbxAuthor = New System.Windows.Forms.TextBox
        Me.drpActiveLang = New System.Windows.Forms.ComboBox
        Me.tbxDisplayName = New System.Windows.Forms.TextBox
        Me.tbxVersion = New System.Windows.Forms.TextBox
        Me.tbxInfoText = New System.Windows.Forms.TextBox
        Me.lx_grpBasics = New System.Windows.Forms.GroupBox
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.lx_lblActiveLanguage = New System.Windows.Forms.Label
        Me.lblLastUpdate = New System.Windows.Forms.Label
        Me.lx_lblInfoText = New System.Windows.Forms.Label
        Me.lx_lblLangVersion = New System.Windows.Forms.Label
        Me.lx_lblAuthorName = New System.Windows.Forms.Label
        Me.lx_lblDisplayName = New System.Windows.Forms.Label
        Me.lx_lblIsoString = New System.Windows.Forms.Label
        Me.drpHelperLang = New System.Windows.Forms.ComboBox
        Me.lx_lblHelperLanguage = New System.Windows.Forms.Label
        Me.cbxIsoString = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lx_grpData = New System.Windows.Forms.GroupBox
        Me.tbHelperWidth = New System.Windows.Forms.TrackBar
        Me.lx_lblHelpSizeSlide = New System.Windows.Forms.Label
        Me.dgvLangData = New System.Windows.Forms.DataGridView
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.lx_grpBasics.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.lx_grpData.SuspendLayout()
        CType(Me.tbHelperWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvLangData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lx_lblLastUpdate
        '
        Me.lx_lblLastUpdate.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_lblLastUpdate.Location = New System.Drawing.Point(3, 230)
        Me.lx_lblLastUpdate.Name = "lx_lblLastUpdate"
        Me.lx_lblLastUpdate.Size = New System.Drawing.Size(119, 25)
        Me.lx_lblLastUpdate.TabIndex = 12
        Me.lx_lblLastUpdate.Text = "last update"
        Me.lx_lblLastUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbxAuthor
        '
        Me.tbxAuthor.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxAuthor.Location = New System.Drawing.Point(128, 101)
        Me.tbxAuthor.Name = "tbxAuthor"
        Me.tbxAuthor.Size = New System.Drawing.Size(115, 21)
        Me.tbxAuthor.TabIndex = 7
        '
        'drpActiveLang
        '
        Me.drpActiveLang.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.drpActiveLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpActiveLang.FormattingEnabled = True
        Me.drpActiveLang.Location = New System.Drawing.Point(128, 5)
        Me.drpActiveLang.Name = "drpActiveLang"
        Me.drpActiveLang.Size = New System.Drawing.Size(115, 21)
        Me.drpActiveLang.TabIndex = 1
        '
        'tbxDisplayName
        '
        Me.tbxDisplayName.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxDisplayName.Location = New System.Drawing.Point(128, 69)
        Me.tbxDisplayName.Name = "tbxDisplayName"
        Me.tbxDisplayName.Size = New System.Drawing.Size(115, 21)
        Me.tbxDisplayName.TabIndex = 5
        '
        'tbxVersion
        '
        Me.tbxVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxVersion.Location = New System.Drawing.Point(128, 133)
        Me.tbxVersion.Name = "tbxVersion"
        Me.tbxVersion.Size = New System.Drawing.Size(115, 21)
        Me.tbxVersion.TabIndex = 9
        '
        'tbxInfoText
        '
        Me.tbxInfoText.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.SetColumnSpan(Me.tbxInfoText, 2)
        Me.tbxInfoText.Location = New System.Drawing.Point(3, 188)
        Me.tbxInfoText.Multiline = True
        Me.tbxInfoText.Name = "tbxInfoText"
        Me.tbxInfoText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbxInfoText.Size = New System.Drawing.Size(240, 39)
        Me.tbxInfoText.TabIndex = 11
        '
        'lx_grpBasics
        '
        Me.lx_grpBasics.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_grpBasics.Controls.Add(Me.TableLayoutPanel1)
        Me.lx_grpBasics.Location = New System.Drawing.Point(0, 0)
        Me.lx_grpBasics.MinimumSize = New System.Drawing.Size(250, 310)
        Me.lx_grpBasics.Name = "lx_grpBasics"
        Me.lx_grpBasics.Size = New System.Drawing.Size(252, 317)
        Me.lx_grpBasics.TabIndex = 0
        Me.lx_grpBasics.TabStop = False
        Me.lx_grpBasics.Text = "basics"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.drpActiveLang, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lx_lblActiveLanguage, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lx_lblLastUpdate, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLastUpdate, 1, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.tbxInfoText, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.lx_lblInfoText, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lx_lblLangVersion, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lx_lblAuthorName, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lx_lblDisplayName, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lx_lblIsoString, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.tbxVersion, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.tbxAuthor, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.tbxDisplayName, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.drpHelperLang, 1, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.lx_lblHelperLanguage, 0, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.cbxIsoString, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 8)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 17)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 10
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(246, 297)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'lx_lblActiveLanguage
        '
        Me.lx_lblActiveLanguage.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_lblActiveLanguage.Location = New System.Drawing.Point(3, 0)
        Me.lx_lblActiveLanguage.Name = "lx_lblActiveLanguage"
        Me.lx_lblActiveLanguage.Size = New System.Drawing.Size(119, 32)
        Me.lx_lblActiveLanguage.TabIndex = 0
        Me.lx_lblActiveLanguage.Text = "active Language"
        Me.lx_lblActiveLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLastUpdate
        '
        Me.lblLastUpdate.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLastUpdate.Location = New System.Drawing.Point(128, 230)
        Me.lblLastUpdate.Name = "lblLastUpdate"
        Me.lblLastUpdate.Size = New System.Drawing.Size(115, 25)
        Me.lblLastUpdate.TabIndex = 13
        Me.lblLastUpdate.Text = "init"
        Me.lblLastUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lx_lblInfoText
        '
        Me.lx_lblInfoText.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.SetColumnSpan(Me.lx_lblInfoText, 2)
        Me.lx_lblInfoText.Location = New System.Drawing.Point(3, 160)
        Me.lx_lblInfoText.Name = "lx_lblInfoText"
        Me.lx_lblInfoText.Size = New System.Drawing.Size(240, 25)
        Me.lx_lblInfoText.TabIndex = 10
        Me.lx_lblInfoText.Text = "info"
        Me.lx_lblInfoText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lx_lblLangVersion
        '
        Me.lx_lblLangVersion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_lblLangVersion.Location = New System.Drawing.Point(3, 128)
        Me.lx_lblLangVersion.Name = "lx_lblLangVersion"
        Me.lx_lblLangVersion.Size = New System.Drawing.Size(119, 32)
        Me.lx_lblLangVersion.TabIndex = 8
        Me.lx_lblLangVersion.Text = "version"
        Me.lx_lblLangVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lx_lblAuthorName
        '
        Me.lx_lblAuthorName.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_lblAuthorName.Location = New System.Drawing.Point(3, 96)
        Me.lx_lblAuthorName.Name = "lx_lblAuthorName"
        Me.lx_lblAuthorName.Size = New System.Drawing.Size(119, 32)
        Me.lx_lblAuthorName.TabIndex = 6
        Me.lx_lblAuthorName.Text = "author"
        Me.lx_lblAuthorName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lx_lblDisplayName
        '
        Me.lx_lblDisplayName.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_lblDisplayName.Location = New System.Drawing.Point(3, 64)
        Me.lx_lblDisplayName.Name = "lx_lblDisplayName"
        Me.lx_lblDisplayName.Size = New System.Drawing.Size(119, 32)
        Me.lx_lblDisplayName.TabIndex = 4
        Me.lx_lblDisplayName.Text = "display name"
        Me.lx_lblDisplayName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lx_lblIsoString
        '
        Me.lx_lblIsoString.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_lblIsoString.Location = New System.Drawing.Point(3, 32)
        Me.lx_lblIsoString.Name = "lx_lblIsoString"
        Me.lx_lblIsoString.Size = New System.Drawing.Size(119, 32)
        Me.lx_lblIsoString.TabIndex = 2
        Me.lx_lblIsoString.Text = "iso-string"
        Me.lx_lblIsoString.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'drpHelperLang
        '
        Me.drpHelperLang.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.drpHelperLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpHelperLang.FormattingEnabled = True
        Me.drpHelperLang.Location = New System.Drawing.Point(128, 270)
        Me.drpHelperLang.Name = "drpHelperLang"
        Me.drpHelperLang.Size = New System.Drawing.Size(115, 21)
        Me.drpHelperLang.TabIndex = 15
        '
        'lx_lblHelperLanguage
        '
        Me.lx_lblHelperLanguage.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_lblHelperLanguage.Location = New System.Drawing.Point(3, 265)
        Me.lx_lblHelperLanguage.Name = "lx_lblHelperLanguage"
        Me.lx_lblHelperLanguage.Size = New System.Drawing.Size(119, 32)
        Me.lx_lblHelperLanguage.TabIndex = 14
        Me.lx_lblHelperLanguage.Text = "helper language"
        Me.lx_lblHelperLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbxIsoString
        '
        Me.cbxIsoString.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbxIsoString.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbxIsoString.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbxIsoString.FormattingEnabled = True
        Me.cbxIsoString.Location = New System.Drawing.Point(128, 37)
        Me.cbxIsoString.MaxDropDownItems = 15
        Me.cbxIsoString.Name = "cbxIsoString"
        Me.cbxIsoString.Size = New System.Drawing.Size(115, 21)
        Me.cbxIsoString.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label1, 2)
        Me.Label1.Location = New System.Drawing.Point(3, 259)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(240, 2)
        Me.Label1.TabIndex = 16
        '
        'lx_grpData
        '
        Me.lx_grpData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_grpData.Controls.Add(Me.tbHelperWidth)
        Me.lx_grpData.Controls.Add(Me.lx_lblHelpSizeSlide)
        Me.lx_grpData.Controls.Add(Me.dgvLangData)
        Me.lx_grpData.Location = New System.Drawing.Point(3, 0)
        Me.lx_grpData.MinimumSize = New System.Drawing.Size(250, 310)
        Me.lx_grpData.Name = "lx_grpData"
        Me.lx_grpData.Size = New System.Drawing.Size(256, 317)
        Me.lx_grpData.TabIndex = 0
        Me.lx_grpData.TabStop = False
        Me.lx_grpData.Text = "language data"
        '
        'tbHelperWidth
        '
        Me.tbHelperWidth.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbHelperWidth.AutoSize = False
        Me.tbHelperWidth.Location = New System.Drawing.Point(125, 286)
        Me.tbHelperWidth.Maximum = 400
        Me.tbHelperWidth.Name = "tbHelperWidth"
        Me.tbHelperWidth.Size = New System.Drawing.Size(125, 28)
        Me.tbHelperWidth.TabIndex = 2
        Me.tbHelperWidth.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbHelperWidth.Value = 400
        Me.tbHelperWidth.Visible = False
        '
        'lx_lblHelpSizeSlide
        '
        Me.lx_lblHelpSizeSlide.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_lblHelpSizeSlide.Location = New System.Drawing.Point(6, 286)
        Me.lx_lblHelpSizeSlide.Name = "lx_lblHelpSizeSlide"
        Me.lx_lblHelpSizeSlide.Size = New System.Drawing.Size(113, 28)
        Me.lx_lblHelpSizeSlide.TabIndex = 1
        Me.lx_lblHelpSizeSlide.Text = "helper-width"
        Me.lx_lblHelpSizeSlide.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lx_lblHelpSizeSlide.Visible = False
        '
        'dgvLangData
        '
        Me.dgvLangData.AllowUserToAddRows = False
        Me.dgvLangData.AllowUserToDeleteRows = False
        Me.dgvLangData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvLangData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
        Me.dgvLangData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLangData.Location = New System.Drawing.Point(6, 17)
        Me.dgvLangData.Name = "dgvLangData"
        Me.dgvLangData.RowHeadersVisible = False
        Me.dgvLangData.Size = New System.Drawing.Size(244, 294)
        Me.dgvLangData.TabIndex = 0
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(12, 12)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.lx_grpBasics)
        Me.SplitContainer1.Panel1MinSize = 5
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.lx_grpData)
        Me.SplitContainer1.Panel2MinSize = 5
        Me.SplitContainer1.Size = New System.Drawing.Size(518, 317)
        Me.SplitContainer1.SplitterDistance = 255
        Me.SplitContainer1.TabIndex = 0
        '
        'frmLanguageData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(542, 341)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(550, 370)
        Me.Name = "frmLanguageData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmLanguageData"
        Me.lx_grpBasics.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.lx_grpData.ResumeLayout(False)
        CType(Me.tbHelperWidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvLangData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lx_lblLastUpdate As System.Windows.Forms.Label
    Friend WithEvents tbxAuthor As System.Windows.Forms.TextBox
    Friend WithEvents drpActiveLang As System.Windows.Forms.ComboBox
    Friend WithEvents tbxDisplayName As System.Windows.Forms.TextBox
    Friend WithEvents tbxVersion As System.Windows.Forms.TextBox
    Friend WithEvents tbxInfoText As System.Windows.Forms.TextBox
    Friend WithEvents lx_grpBasics As System.Windows.Forms.GroupBox
    Friend WithEvents lx_grpData As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lx_lblActiveLanguage As System.Windows.Forms.Label
    Friend WithEvents lblLastUpdate As System.Windows.Forms.Label
    Friend WithEvents lx_lblInfoText As System.Windows.Forms.Label
    Friend WithEvents lx_lblLangVersion As System.Windows.Forms.Label
    Friend WithEvents lx_lblAuthorName As System.Windows.Forms.Label
    Friend WithEvents lx_lblDisplayName As System.Windows.Forms.Label
    Friend WithEvents lx_lblIsoString As System.Windows.Forms.Label
    Friend WithEvents drpHelperLang As System.Windows.Forms.ComboBox
    Friend WithEvents lx_lblHelperLanguage As System.Windows.Forms.Label
    Friend WithEvents cbxIsoString As System.Windows.Forms.ComboBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvLangData As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbHelperWidth As System.Windows.Forms.TrackBar
    Friend WithEvents lx_lblHelpSizeSlide As System.Windows.Forms.Label
End Class
