<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSettings))
        Me.lx_grpSettingsBase = New System.Windows.Forms.GroupBox
        Me.lx_btnCancel = New System.Windows.Forms.Button
        Me.lx_btnOk = New System.Windows.Forms.Button
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.lx_grpStartPosition = New System.Windows.Forms.GroupBox
        Me.tlpCustomStartPos = New System.Windows.Forms.TableLayoutPanel
        Me.numStartPosX = New System.Windows.Forms.NumericUpDown
        Me.lx_lblStartPosX = New System.Windows.Forms.Label
        Me.lx_lblStartPosY = New System.Windows.Forms.Label
        Me.numStartPosY = New System.Windows.Forms.NumericUpDown
        Me.lx_rbtStartPosCustom = New System.Windows.Forms.RadioButton
        Me.lx_rbtStartPosRegular = New System.Windows.Forms.RadioButton
        Me.lx_rbtStartPosCenter = New System.Windows.Forms.RadioButton
        Me.lx_grpAutoOpenForm = New System.Windows.Forms.GroupBox
        Me.lx_lblAutoOpenInfo = New System.Windows.Forms.Label
        Me.lx_rbtAutoOpenLanguages = New System.Windows.Forms.RadioButton
        Me.lx_rbtAutoOpenItems = New System.Windows.Forms.RadioButton
        Me.lx_rbtAutoOpenValues = New System.Windows.Forms.RadioButton
        Me.lx_rbtAutoOpenNothing = New System.Windows.Forms.RadioButton
        Me.lx_grpStartSize = New System.Windows.Forms.GroupBox
        Me.tlpCustomStartSize = New System.Windows.Forms.TableLayoutPanel
        Me.numStartSizeWidth = New System.Windows.Forms.NumericUpDown
        Me.lx_lblStartSizeWidth = New System.Windows.Forms.Label
        Me.lx_lblStartSizeHeight = New System.Windows.Forms.Label
        Me.numStartSizeHeight = New System.Windows.Forms.NumericUpDown
        Me.lx_rbtStartSizeCustom = New System.Windows.Forms.RadioButton
        Me.lx_rbtStartSizeStandard = New System.Windows.Forms.RadioButton
        Me.lx_rbtStartSizeSaveOnClose = New System.Windows.Forms.RadioButton
        Me.lx_lblRecentFileNum = New System.Windows.Forms.Label
        Me.lx_lblDurationStatMsg = New System.Windows.Forms.Label
        Me.numStatMsgDuration = New System.Windows.Forms.NumericUpDown
        Me.numRecentFiles = New System.Windows.Forms.NumericUpDown
        Me.lx_grpOtherSettings = New System.Windows.Forms.GroupBox
        Me.lx_grpSettingsBase.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.lx_grpStartPosition.SuspendLayout()
        Me.tlpCustomStartPos.SuspendLayout()
        CType(Me.numStartPosX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numStartPosY, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.lx_grpAutoOpenForm.SuspendLayout()
        Me.lx_grpStartSize.SuspendLayout()
        Me.tlpCustomStartSize.SuspendLayout()
        CType(Me.numStartSizeWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numStartSizeHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numStatMsgDuration, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numRecentFiles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.lx_grpOtherSettings.SuspendLayout()
        Me.SuspendLayout()
        '
        'lx_grpSettingsBase
        '
        Me.lx_grpSettingsBase.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_grpSettingsBase.Controls.Add(Me.lx_grpOtherSettings)
        Me.lx_grpSettingsBase.Controls.Add(Me.lx_btnCancel)
        Me.lx_grpSettingsBase.Controls.Add(Me.lx_btnOk)
        Me.lx_grpSettingsBase.Controls.Add(Me.TableLayoutPanel3)
        Me.lx_grpSettingsBase.Location = New System.Drawing.Point(12, 12)
        Me.lx_grpSettingsBase.Name = "lx_grpSettingsBase"
        Me.lx_grpSettingsBase.Size = New System.Drawing.Size(637, 267)
        Me.lx_grpSettingsBase.TabIndex = 0
        Me.lx_grpSettingsBase.TabStop = False
        Me.lx_grpSettingsBase.Text = "tool settings"
        '
        'lx_btnCancel
        '
        Me.lx_btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.lx_btnCancel.Location = New System.Drawing.Point(556, 238)
        Me.lx_btnCancel.Name = "lx_btnCancel"
        Me.lx_btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.lx_btnCancel.TabIndex = 3
        Me.lx_btnCancel.Text = "cancel"
        Me.lx_btnCancel.UseVisualStyleBackColor = True
        '
        'lx_btnOk
        '
        Me.lx_btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_btnOk.Location = New System.Drawing.Point(475, 238)
        Me.lx_btnOk.Name = "lx_btnOk"
        Me.lx_btnOk.Size = New System.Drawing.Size(75, 23)
        Me.lx_btnOk.TabIndex = 2
        Me.lx_btnOk.Text = "ok"
        Me.lx_btnOk.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel3.Controls.Add(Me.lx_grpStartPosition, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lx_grpAutoOpenForm, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lx_grpStartSize, 1, 0)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(6, 20)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(625, 156)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'lx_grpStartPosition
        '
        Me.lx_grpStartPosition.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_grpStartPosition.Controls.Add(Me.tlpCustomStartPos)
        Me.lx_grpStartPosition.Controls.Add(Me.lx_rbtStartPosCustom)
        Me.lx_grpStartPosition.Controls.Add(Me.lx_rbtStartPosRegular)
        Me.lx_grpStartPosition.Controls.Add(Me.lx_rbtStartPosCenter)
        Me.lx_grpStartPosition.Location = New System.Drawing.Point(3, 3)
        Me.lx_grpStartPosition.MinimumSize = New System.Drawing.Size(200, 146)
        Me.lx_grpStartPosition.Name = "lx_grpStartPosition"
        Me.lx_grpStartPosition.Size = New System.Drawing.Size(202, 150)
        Me.lx_grpStartPosition.TabIndex = 0
        Me.lx_grpStartPosition.TabStop = False
        Me.lx_grpStartPosition.Text = "start position"
        '
        'tlpCustomStartPos
        '
        Me.tlpCustomStartPos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tlpCustomStartPos.ColumnCount = 2
        Me.tlpCustomStartPos.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpCustomStartPos.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpCustomStartPos.Controls.Add(Me.numStartPosX, 0, 1)
        Me.tlpCustomStartPos.Controls.Add(Me.lx_lblStartPosX, 0, 0)
        Me.tlpCustomStartPos.Controls.Add(Me.lx_lblStartPosY, 1, 0)
        Me.tlpCustomStartPos.Controls.Add(Me.numStartPosY, 1, 1)
        Me.tlpCustomStartPos.Enabled = False
        Me.tlpCustomStartPos.Location = New System.Drawing.Point(20, 89)
        Me.tlpCustomStartPos.Name = "tlpCustomStartPos"
        Me.tlpCustomStartPos.RowCount = 2
        Me.tlpCustomStartPos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpCustomStartPos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpCustomStartPos.Size = New System.Drawing.Size(162, 55)
        Me.tlpCustomStartPos.TabIndex = 3
        '
        'numStartPosX
        '
        Me.numStartPosX.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numStartPosX.Location = New System.Drawing.Point(3, 29)
        Me.numStartPosX.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.numStartPosX.Minimum = New Decimal(New Integer() {5000, 0, 0, -2147483648})
        Me.numStartPosX.Name = "numStartPosX"
        Me.numStartPosX.Size = New System.Drawing.Size(75, 21)
        Me.numStartPosX.TabIndex = 1
        '
        'lx_lblStartPosX
        '
        Me.lx_lblStartPosX.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_lblStartPosX.Location = New System.Drawing.Point(3, 0)
        Me.lx_lblStartPosX.Name = "lx_lblStartPosX"
        Me.lx_lblStartPosX.Size = New System.Drawing.Size(75, 25)
        Me.lx_lblStartPosX.TabIndex = 0
        Me.lx_lblStartPosX.Text = "pos left"
        Me.lx_lblStartPosX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lx_lblStartPosY
        '
        Me.lx_lblStartPosY.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_lblStartPosY.Location = New System.Drawing.Point(84, 0)
        Me.lx_lblStartPosY.Name = "lx_lblStartPosY"
        Me.lx_lblStartPosY.Size = New System.Drawing.Size(75, 25)
        Me.lx_lblStartPosY.TabIndex = 2
        Me.lx_lblStartPosY.Text = "pos top"
        Me.lx_lblStartPosY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'numStartPosY
        '
        Me.numStartPosY.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numStartPosY.Location = New System.Drawing.Point(84, 29)
        Me.numStartPosY.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.numStartPosY.Minimum = New Decimal(New Integer() {5000, 0, 0, -2147483648})
        Me.numStartPosY.Name = "numStartPosY"
        Me.numStartPosY.Size = New System.Drawing.Size(75, 21)
        Me.numStartPosY.TabIndex = 3
        '
        'lx_rbtStartPosCustom
        '
        Me.lx_rbtStartPosCustom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_rbtStartPosCustom.Location = New System.Drawing.Point(6, 66)
        Me.lx_rbtStartPosCustom.Name = "lx_rbtStartPosCustom"
        Me.lx_rbtStartPosCustom.Size = New System.Drawing.Size(190, 17)
        Me.lx_rbtStartPosCustom.TabIndex = 2
        Me.lx_rbtStartPosCustom.TabStop = True
        Me.lx_rbtStartPosCustom.Text = "custom"
        Me.lx_rbtStartPosCustom.UseVisualStyleBackColor = True
        '
        'lx_rbtStartPosRegular
        '
        Me.lx_rbtStartPosRegular.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_rbtStartPosRegular.Location = New System.Drawing.Point(6, 20)
        Me.lx_rbtStartPosRegular.Name = "lx_rbtStartPosRegular"
        Me.lx_rbtStartPosRegular.Size = New System.Drawing.Size(190, 17)
        Me.lx_rbtStartPosRegular.TabIndex = 0
        Me.lx_rbtStartPosRegular.TabStop = True
        Me.lx_rbtStartPosRegular.Text = "regular (win default)"
        Me.lx_rbtStartPosRegular.UseVisualStyleBackColor = True
        '
        'lx_rbtStartPosCenter
        '
        Me.lx_rbtStartPosCenter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_rbtStartPosCenter.Location = New System.Drawing.Point(6, 43)
        Me.lx_rbtStartPosCenter.Name = "lx_rbtStartPosCenter"
        Me.lx_rbtStartPosCenter.Size = New System.Drawing.Size(190, 17)
        Me.lx_rbtStartPosCenter.TabIndex = 1
        Me.lx_rbtStartPosCenter.TabStop = True
        Me.lx_rbtStartPosCenter.Text = "center"
        Me.lx_rbtStartPosCenter.UseVisualStyleBackColor = True
        '
        'lx_grpAutoOpenForm
        '
        Me.lx_grpAutoOpenForm.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_grpAutoOpenForm.Controls.Add(Me.lx_lblAutoOpenInfo)
        Me.lx_grpAutoOpenForm.Controls.Add(Me.lx_rbtAutoOpenLanguages)
        Me.lx_grpAutoOpenForm.Controls.Add(Me.lx_rbtAutoOpenItems)
        Me.lx_grpAutoOpenForm.Controls.Add(Me.lx_rbtAutoOpenValues)
        Me.lx_grpAutoOpenForm.Controls.Add(Me.lx_rbtAutoOpenNothing)
        Me.lx_grpAutoOpenForm.Location = New System.Drawing.Point(419, 3)
        Me.lx_grpAutoOpenForm.MinimumSize = New System.Drawing.Size(200, 146)
        Me.lx_grpAutoOpenForm.Name = "lx_grpAutoOpenForm"
        Me.lx_grpAutoOpenForm.Size = New System.Drawing.Size(203, 150)
        Me.lx_grpAutoOpenForm.TabIndex = 2
        Me.lx_grpAutoOpenForm.TabStop = False
        Me.lx_grpAutoOpenForm.Text = "open after file-open"
        '
        'lx_lblAutoOpenInfo
        '
        Me.lx_lblAutoOpenInfo.Location = New System.Drawing.Point(6, 17)
        Me.lx_lblAutoOpenInfo.Name = "lx_lblAutoOpenInfo"
        Me.lx_lblAutoOpenInfo.Size = New System.Drawing.Size(191, 29)
        Me.lx_lblAutoOpenInfo.TabIndex = 0
        Me.lx_lblAutoOpenInfo.Text = "info" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "text"
        Me.lx_lblAutoOpenInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lx_rbtAutoOpenLanguages
        '
        Me.lx_rbtAutoOpenLanguages.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_rbtAutoOpenLanguages.Location = New System.Drawing.Point(6, 120)
        Me.lx_rbtAutoOpenLanguages.Name = "lx_rbtAutoOpenLanguages"
        Me.lx_rbtAutoOpenLanguages.Size = New System.Drawing.Size(191, 17)
        Me.lx_rbtAutoOpenLanguages.TabIndex = 4
        Me.lx_rbtAutoOpenLanguages.TabStop = True
        Me.lx_rbtAutoOpenLanguages.Text = "languages"
        Me.lx_rbtAutoOpenLanguages.UseVisualStyleBackColor = True
        '
        'lx_rbtAutoOpenItems
        '
        Me.lx_rbtAutoOpenItems.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_rbtAutoOpenItems.Location = New System.Drawing.Point(6, 97)
        Me.lx_rbtAutoOpenItems.Name = "lx_rbtAutoOpenItems"
        Me.lx_rbtAutoOpenItems.Size = New System.Drawing.Size(191, 17)
        Me.lx_rbtAutoOpenItems.TabIndex = 3
        Me.lx_rbtAutoOpenItems.TabStop = True
        Me.lx_rbtAutoOpenItems.Text = "items"
        Me.lx_rbtAutoOpenItems.UseVisualStyleBackColor = True
        '
        'lx_rbtAutoOpenValues
        '
        Me.lx_rbtAutoOpenValues.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_rbtAutoOpenValues.Location = New System.Drawing.Point(6, 74)
        Me.lx_rbtAutoOpenValues.Name = "lx_rbtAutoOpenValues"
        Me.lx_rbtAutoOpenValues.Size = New System.Drawing.Size(191, 17)
        Me.lx_rbtAutoOpenValues.TabIndex = 2
        Me.lx_rbtAutoOpenValues.TabStop = True
        Me.lx_rbtAutoOpenValues.Text = "values"
        Me.lx_rbtAutoOpenValues.UseVisualStyleBackColor = True
        '
        'lx_rbtAutoOpenNothing
        '
        Me.lx_rbtAutoOpenNothing.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_rbtAutoOpenNothing.Location = New System.Drawing.Point(6, 51)
        Me.lx_rbtAutoOpenNothing.Name = "lx_rbtAutoOpenNothing"
        Me.lx_rbtAutoOpenNothing.Size = New System.Drawing.Size(191, 17)
        Me.lx_rbtAutoOpenNothing.TabIndex = 1
        Me.lx_rbtAutoOpenNothing.TabStop = True
        Me.lx_rbtAutoOpenNothing.Text = "none"
        Me.lx_rbtAutoOpenNothing.UseVisualStyleBackColor = True
        '
        'lx_grpStartSize
        '
        Me.lx_grpStartSize.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_grpStartSize.Controls.Add(Me.tlpCustomStartSize)
        Me.lx_grpStartSize.Controls.Add(Me.lx_rbtStartSizeCustom)
        Me.lx_grpStartSize.Controls.Add(Me.lx_rbtStartSizeStandard)
        Me.lx_grpStartSize.Controls.Add(Me.lx_rbtStartSizeSaveOnClose)
        Me.lx_grpStartSize.Location = New System.Drawing.Point(211, 3)
        Me.lx_grpStartSize.MinimumSize = New System.Drawing.Size(200, 146)
        Me.lx_grpStartSize.Name = "lx_grpStartSize"
        Me.lx_grpStartSize.Size = New System.Drawing.Size(202, 150)
        Me.lx_grpStartSize.TabIndex = 1
        Me.lx_grpStartSize.TabStop = False
        Me.lx_grpStartSize.Text = "size on start"
        '
        'tlpCustomStartSize
        '
        Me.tlpCustomStartSize.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tlpCustomStartSize.ColumnCount = 2
        Me.tlpCustomStartSize.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpCustomStartSize.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpCustomStartSize.Controls.Add(Me.numStartSizeWidth, 0, 1)
        Me.tlpCustomStartSize.Controls.Add(Me.lx_lblStartSizeWidth, 0, 0)
        Me.tlpCustomStartSize.Controls.Add(Me.lx_lblStartSizeHeight, 1, 0)
        Me.tlpCustomStartSize.Controls.Add(Me.numStartSizeHeight, 1, 1)
        Me.tlpCustomStartSize.Enabled = False
        Me.tlpCustomStartSize.Location = New System.Drawing.Point(20, 89)
        Me.tlpCustomStartSize.Name = "tlpCustomStartSize"
        Me.tlpCustomStartSize.RowCount = 2
        Me.tlpCustomStartSize.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpCustomStartSize.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpCustomStartSize.Size = New System.Drawing.Size(162, 55)
        Me.tlpCustomStartSize.TabIndex = 3
        '
        'numStartSizeWidth
        '
        Me.numStartSizeWidth.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numStartSizeWidth.Location = New System.Drawing.Point(3, 29)
        Me.numStartSizeWidth.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.numStartSizeWidth.Minimum = New Decimal(New Integer() {600, 0, 0, 0})
        Me.numStartSizeWidth.Name = "numStartSizeWidth"
        Me.numStartSizeWidth.Size = New System.Drawing.Size(75, 21)
        Me.numStartSizeWidth.TabIndex = 1
        Me.numStartSizeWidth.Value = New Decimal(New Integer() {600, 0, 0, 0})
        '
        'lx_lblStartSizeWidth
        '
        Me.lx_lblStartSizeWidth.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_lblStartSizeWidth.Location = New System.Drawing.Point(3, 0)
        Me.lx_lblStartSizeWidth.Name = "lx_lblStartSizeWidth"
        Me.lx_lblStartSizeWidth.Size = New System.Drawing.Size(75, 25)
        Me.lx_lblStartSizeWidth.TabIndex = 0
        Me.lx_lblStartSizeWidth.Text = "width"
        Me.lx_lblStartSizeWidth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lx_lblStartSizeHeight
        '
        Me.lx_lblStartSizeHeight.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_lblStartSizeHeight.Location = New System.Drawing.Point(84, 0)
        Me.lx_lblStartSizeHeight.Name = "lx_lblStartSizeHeight"
        Me.lx_lblStartSizeHeight.Size = New System.Drawing.Size(75, 25)
        Me.lx_lblStartSizeHeight.TabIndex = 2
        Me.lx_lblStartSizeHeight.Text = "height"
        Me.lx_lblStartSizeHeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'numStartSizeHeight
        '
        Me.numStartSizeHeight.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numStartSizeHeight.Location = New System.Drawing.Point(84, 29)
        Me.numStartSizeHeight.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.numStartSizeHeight.Minimum = New Decimal(New Integer() {450, 0, 0, 0})
        Me.numStartSizeHeight.Name = "numStartSizeHeight"
        Me.numStartSizeHeight.Size = New System.Drawing.Size(75, 21)
        Me.numStartSizeHeight.TabIndex = 3
        Me.numStartSizeHeight.Value = New Decimal(New Integer() {450, 0, 0, 0})
        '
        'lx_rbtStartSizeCustom
        '
        Me.lx_rbtStartSizeCustom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_rbtStartSizeCustom.Location = New System.Drawing.Point(6, 66)
        Me.lx_rbtStartSizeCustom.Name = "lx_rbtStartSizeCustom"
        Me.lx_rbtStartSizeCustom.Size = New System.Drawing.Size(190, 17)
        Me.lx_rbtStartSizeCustom.TabIndex = 2
        Me.lx_rbtStartSizeCustom.TabStop = True
        Me.lx_rbtStartSizeCustom.Text = "custom"
        Me.lx_rbtStartSizeCustom.UseVisualStyleBackColor = True
        '
        'lx_rbtStartSizeStandard
        '
        Me.lx_rbtStartSizeStandard.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_rbtStartSizeStandard.Location = New System.Drawing.Point(6, 20)
        Me.lx_rbtStartSizeStandard.Name = "lx_rbtStartSizeStandard"
        Me.lx_rbtStartSizeStandard.Size = New System.Drawing.Size(190, 17)
        Me.lx_rbtStartSizeStandard.TabIndex = 0
        Me.lx_rbtStartSizeStandard.TabStop = True
        Me.lx_rbtStartSizeStandard.Text = "standard"
        Me.lx_rbtStartSizeStandard.UseVisualStyleBackColor = True
        '
        'lx_rbtStartSizeSaveOnClose
        '
        Me.lx_rbtStartSizeSaveOnClose.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_rbtStartSizeSaveOnClose.Location = New System.Drawing.Point(6, 43)
        Me.lx_rbtStartSizeSaveOnClose.Name = "lx_rbtStartSizeSaveOnClose"
        Me.lx_rbtStartSizeSaveOnClose.Size = New System.Drawing.Size(190, 17)
        Me.lx_rbtStartSizeSaveOnClose.TabIndex = 1
        Me.lx_rbtStartSizeSaveOnClose.TabStop = True
        Me.lx_rbtStartSizeSaveOnClose.Text = "save on close"
        Me.lx_rbtStartSizeSaveOnClose.UseVisualStyleBackColor = True
        '
        'lx_lblRecentFileNum
        '
        Me.lx_lblRecentFileNum.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lx_lblRecentFileNum.Location = New System.Drawing.Point(57, 22)
        Me.lx_lblRecentFileNum.Name = "lx_lblRecentFileNum"
        Me.lx_lblRecentFileNum.Size = New System.Drawing.Size(196, 13)
        Me.lx_lblRecentFileNum.TabIndex = 0
        Me.lx_lblRecentFileNum.Text = "no of recent files"
        Me.lx_lblRecentFileNum.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lx_lblDurationStatMsg
        '
        Me.lx_lblDurationStatMsg.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lx_lblDurationStatMsg.Location = New System.Drawing.Point(312, 22)
        Me.lx_lblDurationStatMsg.Name = "lx_lblDurationStatMsg"
        Me.lx_lblDurationStatMsg.Size = New System.Drawing.Size(195, 13)
        Me.lx_lblDurationStatMsg.TabIndex = 2
        Me.lx_lblDurationStatMsg.Text = "duration statusmessage"
        Me.lx_lblDurationStatMsg.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'numStatMsgDuration
        '
        Me.numStatMsgDuration.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.numStatMsgDuration.Location = New System.Drawing.Point(513, 20)
        Me.numStatMsgDuration.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.numStatMsgDuration.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numStatMsgDuration.Name = "numStatMsgDuration"
        Me.numStatMsgDuration.Size = New System.Drawing.Size(49, 21)
        Me.numStatMsgDuration.TabIndex = 3
        Me.numStatMsgDuration.Value = New Decimal(New Integer() {15, 0, 0, 0})
        '
        'numRecentFiles
        '
        Me.numRecentFiles.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.numRecentFiles.Location = New System.Drawing.Point(257, 20)
        Me.numRecentFiles.Maximum = New Decimal(New Integer() {25, 0, 0, 0})
        Me.numRecentFiles.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numRecentFiles.Name = "numRecentFiles"
        Me.numRecentFiles.Size = New System.Drawing.Size(49, 21)
        Me.numRecentFiles.TabIndex = 1
        Me.numRecentFiles.Value = New Decimal(New Integer() {8, 0, 0, 0})
        '
        'lx_grpOtherSettings
        '
        Me.lx_grpOtherSettings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_grpOtherSettings.Controls.Add(Me.lx_lblRecentFileNum)
        Me.lx_grpOtherSettings.Controls.Add(Me.numRecentFiles)
        Me.lx_grpOtherSettings.Controls.Add(Me.lx_lblDurationStatMsg)
        Me.lx_grpOtherSettings.Controls.Add(Me.numStatMsgDuration)
        Me.lx_grpOtherSettings.Location = New System.Drawing.Point(9, 179)
        Me.lx_grpOtherSettings.Name = "lx_grpOtherSettings"
        Me.lx_grpOtherSettings.Size = New System.Drawing.Size(619, 53)
        Me.lx_grpOtherSettings.TabIndex = 1
        Me.lx_grpOtherSettings.TabStop = False
        Me.lx_grpOtherSettings.Text = "other"
        '
        'frmSettings
        '
        Me.AcceptButton = Me.lx_btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.lx_btnCancel
        Me.ClientSize = New System.Drawing.Size(661, 291)
        Me.Controls.Add(Me.lx_grpSettingsBase)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSettings"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmSettings"
        Me.lx_grpSettingsBase.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.lx_grpStartPosition.ResumeLayout(False)
        Me.tlpCustomStartPos.ResumeLayout(False)
        CType(Me.numStartPosX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numStartPosY, System.ComponentModel.ISupportInitialize).EndInit()
        Me.lx_grpAutoOpenForm.ResumeLayout(False)
        Me.lx_grpStartSize.ResumeLayout(False)
        Me.tlpCustomStartSize.ResumeLayout(False)
        CType(Me.numStartSizeWidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numStartSizeHeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numStatMsgDuration, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numRecentFiles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.lx_grpOtherSettings.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lx_grpSettingsBase As System.Windows.Forms.GroupBox
    Friend WithEvents lx_grpStartSize As System.Windows.Forms.GroupBox
    Friend WithEvents lx_rbtStartSizeCustom As System.Windows.Forms.RadioButton
    Friend WithEvents lx_rbtStartSizeStandard As System.Windows.Forms.RadioButton
    Friend WithEvents lx_rbtStartSizeSaveOnClose As System.Windows.Forms.RadioButton
    Friend WithEvents lx_grpAutoOpenForm As System.Windows.Forms.GroupBox
    Friend WithEvents lx_rbtAutoOpenLanguages As System.Windows.Forms.RadioButton
    Friend WithEvents lx_rbtAutoOpenItems As System.Windows.Forms.RadioButton
    Friend WithEvents lx_rbtAutoOpenValues As System.Windows.Forms.RadioButton
    Friend WithEvents lx_rbtAutoOpenNothing As System.Windows.Forms.RadioButton
    Friend WithEvents lx_grpStartPosition As System.Windows.Forms.GroupBox
    Friend WithEvents lx_rbtStartPosCustom As System.Windows.Forms.RadioButton
    Friend WithEvents lx_rbtStartPosRegular As System.Windows.Forms.RadioButton
    Friend WithEvents lx_rbtStartPosCenter As System.Windows.Forms.RadioButton
    Friend WithEvents tlpCustomStartPos As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents numStartPosX As System.Windows.Forms.NumericUpDown
    Friend WithEvents lx_lblStartPosX As System.Windows.Forms.Label
    Friend WithEvents lx_lblStartPosY As System.Windows.Forms.Label
    Friend WithEvents numStartPosY As System.Windows.Forms.NumericUpDown
    Friend WithEvents tlpCustomStartSize As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents numStartSizeWidth As System.Windows.Forms.NumericUpDown
    Friend WithEvents lx_lblStartSizeWidth As System.Windows.Forms.Label
    Friend WithEvents lx_lblStartSizeHeight As System.Windows.Forms.Label
    Friend WithEvents numStartSizeHeight As System.Windows.Forms.NumericUpDown
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lx_lblAutoOpenInfo As System.Windows.Forms.Label
    Friend WithEvents lx_btnCancel As System.Windows.Forms.Button
    Friend WithEvents lx_btnOk As System.Windows.Forms.Button
    Friend WithEvents lx_lblRecentFileNum As System.Windows.Forms.Label
    Friend WithEvents lx_lblDurationStatMsg As System.Windows.Forms.Label
    Friend WithEvents numRecentFiles As System.Windows.Forms.NumericUpDown
    Friend WithEvents numStatMsgDuration As System.Windows.Forms.NumericUpDown
    Friend WithEvents lx_grpOtherSettings As System.Windows.Forms.GroupBox
End Class
