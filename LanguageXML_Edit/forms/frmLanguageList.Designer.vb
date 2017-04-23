<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLanguageList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLanguageList))
        Me.lx_grpMain = New System.Windows.Forms.GroupBox
        Me.lx_lblIntNameInfo = New System.Windows.Forms.Label
        Me.lx_btnDeleteLang = New System.Windows.Forms.Button
        Me.lx_lblNewLang = New System.Windows.Forms.Label
        Me.lx_btnAddLang = New System.Windows.Forms.Button
        Me.tbxNewLangName = New System.Windows.Forms.TextBox
        Me.lstLanguages = New System.Windows.Forms.ListBox
        Me.lx_grpMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'lx_grpMain
        '
        Me.lx_grpMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_grpMain.Controls.Add(Me.lx_lblIntNameInfo)
        Me.lx_grpMain.Controls.Add(Me.lx_btnDeleteLang)
        Me.lx_grpMain.Controls.Add(Me.lx_lblNewLang)
        Me.lx_grpMain.Controls.Add(Me.lx_btnAddLang)
        Me.lx_grpMain.Controls.Add(Me.tbxNewLangName)
        Me.lx_grpMain.Controls.Add(Me.lstLanguages)
        Me.lx_grpMain.Location = New System.Drawing.Point(12, 13)
        Me.lx_grpMain.Name = "lx_grpMain"
        Me.lx_grpMain.Size = New System.Drawing.Size(318, 172)
        Me.lx_grpMain.TabIndex = 0
        Me.lx_grpMain.TabStop = False
        Me.lx_grpMain.Text = "languages"
        '
        'lx_lblIntNameInfo
        '
        Me.lx_lblIntNameInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_lblIntNameInfo.Location = New System.Drawing.Point(9, 146)
        Me.lx_lblIntNameInfo.Name = "lx_lblIntNameInfo"
        Me.lx_lblIntNameInfo.Size = New System.Drawing.Size(303, 23)
        Me.lx_lblIntNameInfo.TabIndex = 5
        Me.lx_lblIntNameInfo.Text = "... this dialog shows only the internal name(s) ..."
        Me.lx_lblIntNameInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lx_btnDeleteLang
        '
        Me.lx_btnDeleteLang.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lx_btnDeleteLang.Location = New System.Drawing.Point(6, 94)
        Me.lx_btnDeleteLang.Name = "lx_btnDeleteLang"
        Me.lx_btnDeleteLang.Size = New System.Drawing.Size(94, 21)
        Me.lx_btnDeleteLang.TabIndex = 1
        Me.lx_btnDeleteLang.Text = "delete"
        Me.lx_btnDeleteLang.UseVisualStyleBackColor = True
        '
        'lx_lblNewLang
        '
        Me.lx_lblNewLang.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lx_lblNewLang.Location = New System.Drawing.Point(6, 126)
        Me.lx_lblNewLang.Name = "lx_lblNewLang"
        Me.lx_lblNewLang.Size = New System.Drawing.Size(94, 13)
        Me.lx_lblNewLang.TabIndex = 2
        Me.lx_lblNewLang.Text = "new language"
        Me.lx_lblNewLang.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lx_btnAddLang
        '
        Me.lx_btnAddLang.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_btnAddLang.Location = New System.Drawing.Point(218, 123)
        Me.lx_btnAddLang.Name = "lx_btnAddLang"
        Me.lx_btnAddLang.Size = New System.Drawing.Size(94, 21)
        Me.lx_btnAddLang.TabIndex = 4
        Me.lx_btnAddLang.Text = "add"
        Me.lx_btnAddLang.UseVisualStyleBackColor = True
        '
        'tbxNewLangName
        '
        Me.tbxNewLangName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxNewLangName.Location = New System.Drawing.Point(106, 123)
        Me.tbxNewLangName.Name = "tbxNewLangName"
        Me.tbxNewLangName.Size = New System.Drawing.Size(106, 21)
        Me.tbxNewLangName.TabIndex = 3
        '
        'lstLanguages
        '
        Me.lstLanguages.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstLanguages.FormattingEnabled = True
        Me.lstLanguages.Location = New System.Drawing.Point(6, 19)
        Me.lstLanguages.Name = "lstLanguages"
        Me.lstLanguages.Size = New System.Drawing.Size(306, 69)
        Me.lstLanguages.TabIndex = 0
        '
        'frmLanguageList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(342, 197)
        Me.Controls.Add(Me.lx_grpMain)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmLanguageList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmLanguageList"
        Me.lx_grpMain.ResumeLayout(False)
        Me.lx_grpMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lx_grpMain As System.Windows.Forms.GroupBox
    Friend WithEvents lx_btnDeleteLang As System.Windows.Forms.Button
    Friend WithEvents lx_lblNewLang As System.Windows.Forms.Label
    Friend WithEvents lx_btnAddLang As System.Windows.Forms.Button
    Friend WithEvents tbxNewLangName As System.Windows.Forms.TextBox
    Friend WithEvents lstLanguages As System.Windows.Forms.ListBox
    Friend WithEvents lx_lblIntNameInfo As System.Windows.Forms.Label
End Class
