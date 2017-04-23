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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dgvUserList = New System.Windows.Forms.DataGridView
        Me.colID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colUsername = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colNtUser = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.statMain = New System.Windows.Forms.StatusStrip
        Me.sblCurrentAction = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabelSpacer1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.VersionInfromationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmniVersionGui = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmniVersionDllLcux = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmniVersionDllRijndael = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.mnMain = New System.Windows.Forms.MenuStrip
        Me.mnFile = New System.Windows.Forms.ToolStripMenuItem
        Me.mniNewFile = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.mniOpenFile = New System.Windows.Forms.ToolStripMenuItem
        Me.mniSaveFile = New System.Windows.Forms.ToolStripMenuItem
        Me.mniSaveFileAs = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.mniExitTool = New System.Windows.Forms.ToolStripMenuItem
        Me.mnEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.mniUserNew = New System.Windows.Forms.ToolStripMenuItem
        Me.mniUserAddEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.mniUserDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.panElementHolder = New System.Windows.Forms.Panel
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.drpRole = New System.Windows.Forms.ComboBox
        Me.btnUserDelete = New System.Windows.Forms.Button
        Me.btnUserSave = New System.Windows.Forms.Button
        Me.btnUserNew = New System.Windows.Forms.Button
        Me.lblUserId = New System.Windows.Forms.Label
        Me.tbxUserLastName = New System.Windows.Forms.TextBox
        Me.tbxUserFirstName = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.tbxUserNt = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.tbxOpenFileName = New System.Windows.Forms.TextBox
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvUserList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.statMain.SuspendLayout()
        Me.mnMain.SuspendLayout()
        Me.panElementHolder.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.dgvUserList)
        Me.GroupBox2.Location = New System.Drawing.Point(258, 54)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(307, 172)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "User-List:"
        '
        'dgvUserList
        '
        Me.dgvUserList.AllowUserToAddRows = False
        Me.dgvUserList.AllowUserToDeleteRows = False
        Me.dgvUserList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvUserList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUserList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colID, Me.colUsername, Me.colNtUser})
        Me.dgvUserList.Location = New System.Drawing.Point(6, 19)
        Me.dgvUserList.Name = "dgvUserList"
        Me.dgvUserList.ReadOnly = True
        Me.dgvUserList.RowHeadersVisible = False
        Me.dgvUserList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvUserList.Size = New System.Drawing.Size(295, 147)
        Me.dgvUserList.TabIndex = 0
        '
        'colID
        '
        Me.colID.FillWeight = 50.0!
        Me.colID.HeaderText = "ID:"
        Me.colID.Name = "colID"
        Me.colID.ReadOnly = True
        Me.colID.Width = 50
        '
        'colUsername
        '
        Me.colUsername.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colUsername.HeaderText = "Role:"
        Me.colUsername.Name = "colUsername"
        Me.colUsername.ReadOnly = True
        '
        'colNtUser
        '
        Me.colNtUser.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colNtUser.HeaderText = "NT-User:"
        Me.colNtUser.Name = "colNtUser"
        Me.colNtUser.ReadOnly = True
        '
        'statMain
        '
        Me.statMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sblCurrentAction, Me.ToolStripStatusLabelSpacer1, Me.ToolStripDropDownButton1})
        Me.statMain.Location = New System.Drawing.Point(0, 259)
        Me.statMain.Name = "statMain"
        Me.statMain.Size = New System.Drawing.Size(592, 22)
        Me.statMain.TabIndex = 2
        Me.statMain.Text = "StatusStrip1"
        '
        'sblCurrentAction
        '
        Me.sblCurrentAction.AutoSize = False
        Me.sblCurrentAction.Name = "sblCurrentAction"
        Me.sblCurrentAction.Size = New System.Drawing.Size(538, 17)
        Me.sblCurrentAction.Spring = True
        Me.sblCurrentAction.Text = "init"
        Me.sblCurrentAction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabelSpacer1
        '
        Me.ToolStripStatusLabelSpacer1.Name = "ToolStripStatusLabelSpacer1"
        Me.ToolStripStatusLabelSpacer1.Size = New System.Drawing.Size(10, 17)
        Me.ToolStripStatusLabelSpacer1.Text = " "
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator3, Me.VersionInfromationsToolStripMenuItem, Me.tsmniVersionGui, Me.tsmniVersionDllLcux, Me.tsmniVersionDllRijndael, Me.ToolStripSeparator2})
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(29, 20)
        Me.ToolStripDropDownButton1.Text = "ToolStripDropDownButton1"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(186, 6)
        '
        'VersionInfromationsToolStripMenuItem
        '
        Me.VersionInfromationsToolStripMenuItem.Enabled = False
        Me.VersionInfromationsToolStripMenuItem.Name = "VersionInfromationsToolStripMenuItem"
        Me.VersionInfromationsToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.VersionInfromationsToolStripMenuItem.Text = "Version-Informations:"
        '
        'tsmniVersionGui
        '
        Me.tsmniVersionGui.Name = "tsmniVersionGui"
        Me.tsmniVersionGui.Size = New System.Drawing.Size(189, 22)
        Me.tsmniVersionGui.Text = "gui"
        '
        'tsmniVersionDllLcux
        '
        Me.tsmniVersionDllLcux.Name = "tsmniVersionDllLcux"
        Me.tsmniVersionDllLcux.Size = New System.Drawing.Size(189, 22)
        Me.tsmniVersionDllLcux.Text = "dll lcux"
        '
        'tsmniVersionDllRijndael
        '
        Me.tsmniVersionDllRijndael.Name = "tsmniVersionDllRijndael"
        Me.tsmniVersionDllRijndael.Size = New System.Drawing.Size(189, 22)
        Me.tsmniVersionDllRijndael.Text = "dll rijndael"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(186, 6)
        '
        'mnMain
        '
        Me.mnMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnFile, Me.mnEdit})
        Me.mnMain.Location = New System.Drawing.Point(0, 0)
        Me.mnMain.Name = "mnMain"
        Me.mnMain.Size = New System.Drawing.Size(592, 24)
        Me.mnMain.TabIndex = 0
        Me.mnMain.Text = "MenuStrip1"
        '
        'mnFile
        '
        Me.mnFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mniNewFile, Me.ToolStripSeparator4, Me.mniOpenFile, Me.mniSaveFile, Me.mniSaveFileAs, Me.ToolStripSeparator1, Me.mniExitTool})
        Me.mnFile.Name = "mnFile"
        Me.mnFile.Size = New System.Drawing.Size(35, 20)
        Me.mnFile.Text = "&File"
        '
        'mniNewFile
        '
        Me.mniNewFile.Name = "mniNewFile"
        Me.mniNewFile.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.mniNewFile.Size = New System.Drawing.Size(259, 22)
        Me.mniNewFile.Text = "&New File"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(256, 6)
        '
        'mniOpenFile
        '
        Me.mniOpenFile.Name = "mniOpenFile"
        Me.mniOpenFile.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.mniOpenFile.Size = New System.Drawing.Size(259, 22)
        Me.mniOpenFile.Text = "&Open File"
        '
        'mniSaveFile
        '
        Me.mniSaveFile.Name = "mniSaveFile"
        Me.mniSaveFile.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.mniSaveFile.Size = New System.Drawing.Size(259, 22)
        Me.mniSaveFile.Text = "&Save File"
        '
        'mniSaveFileAs
        '
        Me.mniSaveFileAs.Name = "mniSaveFileAs"
        Me.mniSaveFileAs.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                    Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.mniSaveFileAs.Size = New System.Drawing.Size(259, 22)
        Me.mniSaveFileAs.Text = "Save File &as"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(256, 6)
        '
        'mniExitTool
        '
        Me.mniExitTool.Name = "mniExitTool"
        Me.mniExitTool.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Q), System.Windows.Forms.Keys)
        Me.mniExitTool.Size = New System.Drawing.Size(259, 22)
        Me.mniExitTool.Text = "&Exit Tool"
        '
        'mnEdit
        '
        Me.mnEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mniUserNew, Me.mniUserAddEdit, Me.mniUserDelete})
        Me.mnEdit.Name = "mnEdit"
        Me.mnEdit.Size = New System.Drawing.Size(37, 20)
        Me.mnEdit.Text = "&Edit"
        '
        'mniUserNew
        '
        Me.mniUserNew.Name = "mniUserNew"
        Me.mniUserNew.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Alt) _
                    Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.mniUserNew.Size = New System.Drawing.Size(218, 22)
        Me.mniUserNew.Text = "&new User"
        '
        'mniUserAddEdit
        '
        Me.mniUserAddEdit.Name = "mniUserAddEdit"
        Me.mniUserAddEdit.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Alt) _
                    Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.mniUserAddEdit.Size = New System.Drawing.Size(218, 22)
        Me.mniUserAddEdit.Text = "&add / edit User"
        '
        'mniUserDelete
        '
        Me.mniUserDelete.Name = "mniUserDelete"
        Me.mniUserDelete.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Alt) _
                    Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.mniUserDelete.Size = New System.Drawing.Size(218, 22)
        Me.mniUserDelete.Text = "&delete User"
        '
        'panElementHolder
        '
        Me.panElementHolder.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panElementHolder.Controls.Add(Me.GroupBox3)
        Me.panElementHolder.Controls.Add(Me.GroupBox1)
        Me.panElementHolder.Controls.Add(Me.GroupBox2)
        Me.panElementHolder.Location = New System.Drawing.Point(12, 27)
        Me.panElementHolder.Name = "panElementHolder"
        Me.panElementHolder.Size = New System.Drawing.Size(568, 229)
        Me.panElementHolder.TabIndex = 1
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.drpRole)
        Me.GroupBox3.Controls.Add(Me.btnUserDelete)
        Me.GroupBox3.Controls.Add(Me.btnUserSave)
        Me.GroupBox3.Controls.Add(Me.btnUserNew)
        Me.GroupBox3.Controls.Add(Me.lblUserId)
        Me.GroupBox3.Controls.Add(Me.tbxUserLastName)
        Me.GroupBox3.Controls.Add(Me.tbxUserFirstName)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.tbxUserNt)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 54)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(249, 172)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "User Details:"
        '
        'drpRole
        '
        Me.drpRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drpRole.FormattingEnabled = True
        Me.drpRole.Items.AddRange(New Object() {"admin", "langedit", "editor"})
        Me.drpRole.Location = New System.Drawing.Point(116, 34)
        Me.drpRole.Name = "drpRole"
        Me.drpRole.Size = New System.Drawing.Size(127, 21)
        Me.drpRole.TabIndex = 3
        '
        'btnUserDelete
        '
        Me.btnUserDelete.Location = New System.Drawing.Point(168, 143)
        Me.btnUserDelete.Name = "btnUserDelete"
        Me.btnUserDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnUserDelete.TabIndex = 12
        Me.btnUserDelete.Text = "delete"
        Me.btnUserDelete.UseVisualStyleBackColor = True
        '
        'btnUserSave
        '
        Me.btnUserSave.Location = New System.Drawing.Point(87, 143)
        Me.btnUserSave.Name = "btnUserSave"
        Me.btnUserSave.Size = New System.Drawing.Size(75, 23)
        Me.btnUserSave.TabIndex = 11
        Me.btnUserSave.Text = "add / edit"
        Me.btnUserSave.UseVisualStyleBackColor = True
        '
        'btnUserNew
        '
        Me.btnUserNew.Location = New System.Drawing.Point(6, 143)
        Me.btnUserNew.Name = "btnUserNew"
        Me.btnUserNew.Size = New System.Drawing.Size(75, 23)
        Me.btnUserNew.TabIndex = 10
        Me.btnUserNew.Text = "new"
        Me.btnUserNew.UseVisualStyleBackColor = True
        '
        'lblUserId
        '
        Me.lblUserId.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblUserId.Location = New System.Drawing.Point(116, 14)
        Me.lblUserId.Name = "lblUserId"
        Me.lblUserId.Size = New System.Drawing.Size(127, 13)
        Me.lblUserId.TabIndex = 1
        Me.lblUserId.Text = "init"
        '
        'tbxUserLastName
        '
        Me.tbxUserLastName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxUserLastName.Location = New System.Drawing.Point(116, 115)
        Me.tbxUserLastName.Name = "tbxUserLastName"
        Me.tbxUserLastName.Size = New System.Drawing.Size(127, 21)
        Me.tbxUserLastName.TabIndex = 9
        '
        'tbxUserFirstName
        '
        Me.tbxUserFirstName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxUserFirstName.Location = New System.Drawing.Point(116, 88)
        Me.tbxUserFirstName.Name = "tbxUserFirstName"
        Me.tbxUserFirstName.Size = New System.Drawing.Size(127, 21)
        Me.tbxUserFirstName.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(6, 118)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Lastname:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbxUserNt
        '
        Me.tbxUserNt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxUserNt.Location = New System.Drawing.Point(116, 61)
        Me.tbxUserNt.Name = "tbxUserNt"
        Me.tbxUserNt.Size = New System.Drawing.Size(127, 21)
        Me.tbxUserNt.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(6, 91)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Firstname:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(6, 14)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "ID:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(6, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Role:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(6, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "NT-User:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.tbxOpenFileName)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(562, 45)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "File:"
        '
        'tbxOpenFileName
        '
        Me.tbxOpenFileName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxOpenFileName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbxOpenFileName.Location = New System.Drawing.Point(9, 20)
        Me.tbxOpenFileName.Name = "tbxOpenFileName"
        Me.tbxOpenFileName.ReadOnly = True
        Me.tbxOpenFileName.Size = New System.Drawing.Size(542, 14)
        Me.tbxOpenFileName.TabIndex = 0
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(592, 281)
        Me.Controls.Add(Me.panElementHolder)
        Me.Controls.Add(Me.statMain)
        Me.Controls.Add(Me.mnMain)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.mnMain
        Me.MinimumSize = New System.Drawing.Size(600, 310)
        Me.Name = "frmMain"
        Me.Text = "LCUX UserList - Editor"
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvUserList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.statMain.ResumeLayout(False)
        Me.statMain.PerformLayout()
        Me.mnMain.ResumeLayout(False)
        Me.mnMain.PerformLayout()
        Me.panElementHolder.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvUserList As System.Windows.Forms.DataGridView
    Friend WithEvents statMain As System.Windows.Forms.StatusStrip
    Friend WithEvents sblCurrentAction As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents mnMain As System.Windows.Forms.MenuStrip
    Friend WithEvents mnFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mniNewFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mniOpenFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mniSaveFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mniExitTool As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabelSpacer1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsmniVersionGui As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmniVersionDllLcux As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VersionInfromationsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents panElementHolder As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents tbxUserLastName As System.Windows.Forms.TextBox
    Friend WithEvents tbxUserFirstName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tbxUserNt As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblUserId As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnUserDelete As System.Windows.Forms.Button
    Friend WithEvents btnUserSave As System.Windows.Forms.Button
    Friend WithEvents btnUserNew As System.Windows.Forms.Button
    Friend WithEvents mnEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mniUserNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mniUserAddEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mniUserDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tbxOpenFileName As System.Windows.Forms.TextBox
    Friend WithEvents mniSaveFileAs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents colID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUsername As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNtUser As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents drpRole As System.Windows.Forms.ComboBox
    Friend WithEvents tsmniVersionDllRijndael As System.Windows.Forms.ToolStripMenuItem

End Class
