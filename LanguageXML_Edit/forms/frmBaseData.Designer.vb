<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBaseData
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBaseData))
        Me.tbxProgramName = New System.Windows.Forms.TextBox
        Me.lx_lblHeadProgram = New System.Windows.Forms.Label
        Me.tbxDescription = New System.Windows.Forms.TextBox
        Me.lx_lblHeadDescription = New System.Windows.Forms.Label
        Me.lx_lblHeadLastUpdate = New System.Windows.Forms.Label
        Me.lblLastUpdateInfo = New System.Windows.Forms.Label
        Me.lx_grpHeader = New System.Windows.Forms.GroupBox
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.lx_grpData = New System.Windows.Forms.GroupBox
        Me.lx_btnDeleteItems = New System.Windows.Forms.Button
        Me.dgvBaseItems = New System.Windows.Forms.DataGridView
        Me.lx_grpHeader.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.lx_grpData.SuspendLayout()
        CType(Me.dgvBaseItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbxProgramName
        '
        Me.tbxProgramName.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxProgramName.Location = New System.Drawing.Point(103, 5)
        Me.tbxProgramName.Name = "tbxProgramName"
        Me.tbxProgramName.Size = New System.Drawing.Size(85, 21)
        Me.tbxProgramName.TabIndex = 1
        '
        'lx_lblHeadProgram
        '
        Me.lx_lblHeadProgram.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_lblHeadProgram.Location = New System.Drawing.Point(3, 0)
        Me.lx_lblHeadProgram.Name = "lx_lblHeadProgram"
        Me.lx_lblHeadProgram.Size = New System.Drawing.Size(94, 32)
        Me.lx_lblHeadProgram.TabIndex = 0
        Me.lx_lblHeadProgram.Text = "progam"
        Me.lx_lblHeadProgram.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbxDescription
        '
        Me.tbxDescription.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxDescription.Location = New System.Drawing.Point(194, 35)
        Me.tbxDescription.Multiline = True
        Me.tbxDescription.Name = "tbxDescription"
        Me.tbxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbxDescription.Size = New System.Drawing.Size(165, 36)
        Me.tbxDescription.TabIndex = 5
        '
        'lx_lblHeadDescription
        '
        Me.lx_lblHeadDescription.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_lblHeadDescription.Location = New System.Drawing.Point(194, 0)
        Me.lx_lblHeadDescription.Name = "lx_lblHeadDescription"
        Me.lx_lblHeadDescription.Size = New System.Drawing.Size(165, 32)
        Me.lx_lblHeadDescription.TabIndex = 4
        Me.lx_lblHeadDescription.Text = "description"
        Me.lx_lblHeadDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lx_lblHeadLastUpdate
        '
        Me.lx_lblHeadLastUpdate.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_lblHeadLastUpdate.Location = New System.Drawing.Point(3, 32)
        Me.lx_lblHeadLastUpdate.Name = "lx_lblHeadLastUpdate"
        Me.lx_lblHeadLastUpdate.Size = New System.Drawing.Size(94, 42)
        Me.lx_lblHeadLastUpdate.TabIndex = 2
        Me.lx_lblHeadLastUpdate.Text = "last update"
        Me.lx_lblHeadLastUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLastUpdateInfo
        '
        Me.lblLastUpdateInfo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLastUpdateInfo.Location = New System.Drawing.Point(103, 32)
        Me.lblLastUpdateInfo.Name = "lblLastUpdateInfo"
        Me.lblLastUpdateInfo.Size = New System.Drawing.Size(85, 42)
        Me.lblLastUpdateInfo.TabIndex = 3
        Me.lblLastUpdateInfo.Text = "init"
        Me.lblLastUpdateInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lx_grpHeader
        '
        Me.lx_grpHeader.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_grpHeader.Controls.Add(Me.TableLayoutPanel1)
        Me.lx_grpHeader.Location = New System.Drawing.Point(12, 12)
        Me.lx_grpHeader.Name = "lx_grpHeader"
        Me.lx_grpHeader.Size = New System.Drawing.Size(368, 94)
        Me.lx_grpHeader.TabIndex = 0
        Me.lx_grpHeader.TabStop = False
        Me.lx_grpHeader.Text = "meta-data"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lx_lblHeadLastUpdate, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.tbxDescription, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLastUpdateInfo, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lx_lblHeadDescription, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lx_lblHeadProgram, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.tbxProgramName, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 17)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(362, 74)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'lx_grpData
        '
        Me.lx_grpData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_grpData.Controls.Add(Me.lx_btnDeleteItems)
        Me.lx_grpData.Controls.Add(Me.dgvBaseItems)
        Me.lx_grpData.Location = New System.Drawing.Point(12, 112)
        Me.lx_grpData.Name = "lx_grpData"
        Me.lx_grpData.Size = New System.Drawing.Size(368, 147)
        Me.lx_grpData.TabIndex = 1
        Me.lx_grpData.TabStop = False
        Me.lx_grpData.Text = "item-list"
        '
        'lx_btnDeleteItems
        '
        Me.lx_btnDeleteItems.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_btnDeleteItems.Location = New System.Drawing.Point(9, 118)
        Me.lx_btnDeleteItems.Name = "lx_btnDeleteItems"
        Me.lx_btnDeleteItems.Size = New System.Drawing.Size(353, 23)
        Me.lx_btnDeleteItems.TabIndex = 1
        Me.lx_btnDeleteItems.Text = "delete"
        Me.lx_btnDeleteItems.UseVisualStyleBackColor = True
        '
        'dgvBaseItems
        '
        Me.dgvBaseItems.AllowUserToDeleteRows = False
        Me.dgvBaseItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvBaseItems.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
        Me.dgvBaseItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBaseItems.Location = New System.Drawing.Point(9, 19)
        Me.dgvBaseItems.Name = "dgvBaseItems"
        Me.dgvBaseItems.RowHeadersVisible = False
        Me.dgvBaseItems.Size = New System.Drawing.Size(353, 93)
        Me.dgvBaseItems.TabIndex = 0
        '
        'frmBaseData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(392, 271)
        Me.Controls.Add(Me.lx_grpData)
        Me.Controls.Add(Me.lx_grpHeader)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(400, 300)
        Me.Name = "frmBaseData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmBaseData"
        Me.lx_grpHeader.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.lx_grpData.ResumeLayout(False)
        CType(Me.dgvBaseItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbxProgramName As System.Windows.Forms.TextBox
    Friend WithEvents lx_lblHeadProgram As System.Windows.Forms.Label
    Friend WithEvents tbxDescription As System.Windows.Forms.TextBox
    Friend WithEvents lx_lblHeadDescription As System.Windows.Forms.Label
    Friend WithEvents lx_lblHeadLastUpdate As System.Windows.Forms.Label
    Friend WithEvents lblLastUpdateInfo As System.Windows.Forms.Label
    Friend WithEvents lx_grpHeader As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lx_grpData As System.Windows.Forms.GroupBox
    Friend WithEvents dgvBaseItems As System.Windows.Forms.DataGridView
    Friend WithEvents lx_btnDeleteItems As System.Windows.Forms.Button
End Class
