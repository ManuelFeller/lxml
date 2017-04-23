<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbout
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAbout))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.lx_tpgGeneral = New System.Windows.Forms.TabPage
        Me.lx_lblGenInfoText = New System.Windows.Forms.Label
        Me.lx_lblGenHeadline = New System.Windows.Forms.Label
        Me.lx_tpgDetails = New System.Windows.Forms.TabPage
        Me.Label1 = New System.Windows.Forms.Label
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.lx_lblDetRoleInfo = New System.Windows.Forms.Label
        Me.lx_lblDetRoleDetailText = New System.Windows.Forms.Label
        Me.lx_lblDetCurrentRole = New System.Windows.Forms.Label
        Me.lx_tbxDetRoleDetailText = New System.Windows.Forms.TextBox
        Me.lblDetCurrentRole = New System.Windows.Forms.Label
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.lx_lblDetVersionInfo = New System.Windows.Forms.Label
        Me.lx_lblDetStatMsgVersion = New System.Windows.Forms.Label
        Me.lx_lblDetComponents = New System.Windows.Forms.Label
        Me.lx_lblDetToolVersion = New System.Windows.Forms.Label
        Me.lx_lblDetLxmlVersion = New System.Windows.Forms.Label
        Me.lblDetToolVersion = New System.Windows.Forms.Label
        Me.lblDetLxmlVersion = New System.Windows.Forms.Label
        Me.lx_lblDetRijndaelVersion = New System.Windows.Forms.Label
        Me.lblDetRijndaelVersion = New System.Windows.Forms.Label
        Me.lx_lblDetLcuxVersion = New System.Windows.Forms.Label
        Me.lblDetLcuxVersion = New System.Windows.Forms.Label
        Me.lblDetStatMsgVersion = New System.Windows.Forms.Label
        Me.lx_tpgLicense = New System.Windows.Forms.TabPage
        Me.lx_lblLicHeadline = New System.Windows.Forms.Label
        Me.rtbLicense = New System.Windows.Forms.RichTextBox
        Me.lx_lblDetSettingsVersion = New System.Windows.Forms.Label
        Me.lblDetSettingsVersion = New System.Windows.Forms.Label
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.lx_tpgGeneral.SuspendLayout()
        Me.lx_tpgDetails.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.lx_tpgLicense.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(278, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(256, 256)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.lx_tpgGeneral)
        Me.TabControl1.Controls.Add(Me.lx_tpgDetails)
        Me.TabControl1.Controls.Add(Me.lx_tpgLicense)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(548, 297)
        Me.TabControl1.TabIndex = 0
        '
        'lx_tpgGeneral
        '
        Me.lx_tpgGeneral.Controls.Add(Me.lx_lblGenInfoText)
        Me.lx_tpgGeneral.Controls.Add(Me.lx_lblGenHeadline)
        Me.lx_tpgGeneral.Controls.Add(Me.PictureBox1)
        Me.lx_tpgGeneral.Location = New System.Drawing.Point(4, 22)
        Me.lx_tpgGeneral.Name = "lx_tpgGeneral"
        Me.lx_tpgGeneral.Padding = New System.Windows.Forms.Padding(3)
        Me.lx_tpgGeneral.Size = New System.Drawing.Size(540, 271)
        Me.lx_tpgGeneral.TabIndex = 0
        Me.lx_tpgGeneral.Text = "general"
        Me.lx_tpgGeneral.UseVisualStyleBackColor = True
        '
        'lx_lblGenInfoText
        '
        Me.lx_lblGenInfoText.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_lblGenInfoText.Location = New System.Drawing.Point(6, 36)
        Me.lx_lblGenInfoText.Name = "lx_lblGenInfoText"
        Me.lx_lblGenInfoText.Size = New System.Drawing.Size(266, 226)
        Me.lx_lblGenInfoText.TabIndex = 1
        Me.lx_lblGenInfoText.Text = "infotext"
        '
        'lx_lblGenHeadline
        '
        Me.lx_lblGenHeadline.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_lblGenHeadline.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lx_lblGenHeadline.Location = New System.Drawing.Point(6, 6)
        Me.lx_lblGenHeadline.Name = "lx_lblGenHeadline"
        Me.lx_lblGenHeadline.Size = New System.Drawing.Size(266, 30)
        Me.lx_lblGenHeadline.TabIndex = 0
        Me.lx_lblGenHeadline.Text = "headline"
        Me.lx_lblGenHeadline.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lx_tpgDetails
        '
        Me.lx_tpgDetails.Controls.Add(Me.Label1)
        Me.lx_tpgDetails.Controls.Add(Me.TableLayoutPanel2)
        Me.lx_tpgDetails.Controls.Add(Me.TableLayoutPanel1)
        Me.lx_tpgDetails.Location = New System.Drawing.Point(4, 22)
        Me.lx_tpgDetails.Name = "lx_tpgDetails"
        Me.lx_tpgDetails.Padding = New System.Windows.Forms.Padding(3)
        Me.lx_tpgDetails.Size = New System.Drawing.Size(540, 271)
        Me.lx_tpgDetails.TabIndex = 1
        Me.lx_tpgDetails.Text = "details"
        Me.lx_tpgDetails.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 241)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(220, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "DD-Productions Software"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.lx_lblDetRoleInfo, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lx_lblDetRoleDetailText, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.lx_lblDetCurrentRole, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lx_tbxDetRoleDetailText, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.lblDetCurrentRole, 1, 1)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(229, 6)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 4
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(305, 259)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'lx_lblDetRoleInfo
        '
        Me.lx_lblDetRoleInfo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_lblDetRoleInfo.AutoSize = True
        Me.TableLayoutPanel2.SetColumnSpan(Me.lx_lblDetRoleInfo, 2)
        Me.lx_lblDetRoleInfo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lx_lblDetRoleInfo.Location = New System.Drawing.Point(3, 0)
        Me.lx_lblDetRoleInfo.Name = "lx_lblDetRoleInfo"
        Me.lx_lblDetRoleInfo.Size = New System.Drawing.Size(299, 30)
        Me.lx_lblDetRoleInfo.TabIndex = 0
        Me.lx_lblDetRoleInfo.Text = "role-infos"
        Me.lx_lblDetRoleInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lx_lblDetRoleDetailText
        '
        Me.lx_lblDetRoleDetailText.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_lblDetRoleDetailText.AutoSize = True
        Me.TableLayoutPanel2.SetColumnSpan(Me.lx_lblDetRoleDetailText, 2)
        Me.lx_lblDetRoleDetailText.Location = New System.Drawing.Point(3, 60)
        Me.lx_lblDetRoleDetailText.Name = "lx_lblDetRoleDetailText"
        Me.lx_lblDetRoleDetailText.Size = New System.Drawing.Size(299, 30)
        Me.lx_lblDetRoleDetailText.TabIndex = 3
        Me.lx_lblDetRoleDetailText.Text = "about roles"
        Me.lx_lblDetRoleDetailText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lx_lblDetCurrentRole
        '
        Me.lx_lblDetCurrentRole.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_lblDetCurrentRole.AutoSize = True
        Me.lx_lblDetCurrentRole.Location = New System.Drawing.Point(3, 30)
        Me.lx_lblDetCurrentRole.Name = "lx_lblDetCurrentRole"
        Me.lx_lblDetCurrentRole.Size = New System.Drawing.Size(146, 30)
        Me.lx_lblDetCurrentRole.TabIndex = 1
        Me.lx_lblDetCurrentRole.Text = "current role"
        Me.lx_lblDetCurrentRole.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lx_tbxDetRoleDetailText
        '
        Me.lx_tbxDetRoleDetailText.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.SetColumnSpan(Me.lx_tbxDetRoleDetailText, 2)
        Me.lx_tbxDetRoleDetailText.Location = New System.Drawing.Point(3, 93)
        Me.lx_tbxDetRoleDetailText.Multiline = True
        Me.lx_tbxDetRoleDetailText.Name = "lx_tbxDetRoleDetailText"
        Me.lx_tbxDetRoleDetailText.ReadOnly = True
        Me.lx_tbxDetRoleDetailText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.lx_tbxDetRoleDetailText.Size = New System.Drawing.Size(299, 163)
        Me.lx_tbxDetRoleDetailText.TabIndex = 4
        '
        'lblDetCurrentRole
        '
        Me.lblDetCurrentRole.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDetCurrentRole.AutoSize = True
        Me.lblDetCurrentRole.Location = New System.Drawing.Point(155, 30)
        Me.lblDetCurrentRole.Name = "lblDetCurrentRole"
        Me.lblDetCurrentRole.Size = New System.Drawing.Size(147, 30)
        Me.lblDetCurrentRole.TabIndex = 2
        Me.lblDetCurrentRole.Text = "current role"
        Me.lblDetCurrentRole.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lx_lblDetVersionInfo, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lx_lblDetStatMsgVersion, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lx_lblDetComponents, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lx_lblDetToolVersion, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lx_lblDetLxmlVersion, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDetToolVersion, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDetLxmlVersion, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lx_lblDetRijndaelVersion, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDetRijndaelVersion, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.lx_lblDetLcuxVersion, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDetLcuxVersion, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDetStatMsgVersion, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lx_lblDetSettingsVersion, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDetSettingsVersion, 1, 7)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(6, 6)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 9
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(217, 232)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'lx_lblDetVersionInfo
        '
        Me.lx_lblDetVersionInfo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_lblDetVersionInfo.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.lx_lblDetVersionInfo, 2)
        Me.lx_lblDetVersionInfo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lx_lblDetVersionInfo.Location = New System.Drawing.Point(3, 0)
        Me.lx_lblDetVersionInfo.Name = "lx_lblDetVersionInfo"
        Me.lx_lblDetVersionInfo.Size = New System.Drawing.Size(211, 25)
        Me.lx_lblDetVersionInfo.TabIndex = 0
        Me.lx_lblDetVersionInfo.Text = "version infos"
        Me.lx_lblDetVersionInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lx_lblDetStatMsgVersion
        '
        Me.lx_lblDetStatMsgVersion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_lblDetStatMsgVersion.AutoSize = True
        Me.lx_lblDetStatMsgVersion.Location = New System.Drawing.Point(3, 110)
        Me.lx_lblDetStatMsgVersion.Name = "lx_lblDetStatMsgVersion"
        Me.lx_lblDetStatMsgVersion.Size = New System.Drawing.Size(102, 30)
        Me.lx_lblDetStatMsgVersion.TabIndex = 6
        Me.lx_lblDetStatMsgVersion.Text = "status version"
        Me.lx_lblDetStatMsgVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lx_lblDetComponents
        '
        Me.lx_lblDetComponents.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_lblDetComponents.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.lx_lblDetComponents, 2)
        Me.lx_lblDetComponents.Location = New System.Drawing.Point(3, 55)
        Me.lx_lblDetComponents.Name = "lx_lblDetComponents"
        Me.lx_lblDetComponents.Size = New System.Drawing.Size(211, 25)
        Me.lx_lblDetComponents.TabIndex = 3
        Me.lx_lblDetComponents.Text = "components"
        Me.lx_lblDetComponents.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lx_lblDetToolVersion
        '
        Me.lx_lblDetToolVersion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_lblDetToolVersion.AutoSize = True
        Me.lx_lblDetToolVersion.Location = New System.Drawing.Point(3, 25)
        Me.lx_lblDetToolVersion.Name = "lx_lblDetToolVersion"
        Me.lx_lblDetToolVersion.Size = New System.Drawing.Size(102, 30)
        Me.lx_lblDetToolVersion.TabIndex = 1
        Me.lx_lblDetToolVersion.Text = "tool version"
        Me.lx_lblDetToolVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lx_lblDetLxmlVersion
        '
        Me.lx_lblDetLxmlVersion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_lblDetLxmlVersion.AutoSize = True
        Me.lx_lblDetLxmlVersion.Location = New System.Drawing.Point(3, 80)
        Me.lx_lblDetLxmlVersion.Name = "lx_lblDetLxmlVersion"
        Me.lx_lblDetLxmlVersion.Size = New System.Drawing.Size(102, 30)
        Me.lx_lblDetLxmlVersion.TabIndex = 4
        Me.lx_lblDetLxmlVersion.Text = "lxml version"
        Me.lx_lblDetLxmlVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDetToolVersion
        '
        Me.lblDetToolVersion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDetToolVersion.AutoSize = True
        Me.lblDetToolVersion.Location = New System.Drawing.Point(111, 25)
        Me.lblDetToolVersion.Name = "lblDetToolVersion"
        Me.lblDetToolVersion.Size = New System.Drawing.Size(103, 30)
        Me.lblDetToolVersion.TabIndex = 2
        Me.lblDetToolVersion.Text = "tool version"
        Me.lblDetToolVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDetLxmlVersion
        '
        Me.lblDetLxmlVersion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDetLxmlVersion.AutoSize = True
        Me.lblDetLxmlVersion.Location = New System.Drawing.Point(111, 80)
        Me.lblDetLxmlVersion.Name = "lblDetLxmlVersion"
        Me.lblDetLxmlVersion.Size = New System.Drawing.Size(103, 30)
        Me.lblDetLxmlVersion.TabIndex = 5
        Me.lblDetLxmlVersion.Text = "lxml version"
        Me.lblDetLxmlVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lx_lblDetRijndaelVersion
        '
        Me.lx_lblDetRijndaelVersion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_lblDetRijndaelVersion.AutoSize = True
        Me.lx_lblDetRijndaelVersion.Location = New System.Drawing.Point(3, 170)
        Me.lx_lblDetRijndaelVersion.Name = "lx_lblDetRijndaelVersion"
        Me.lx_lblDetRijndaelVersion.Size = New System.Drawing.Size(102, 30)
        Me.lx_lblDetRijndaelVersion.TabIndex = 10
        Me.lx_lblDetRijndaelVersion.Text = "rijndael version"
        Me.lx_lblDetRijndaelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDetRijndaelVersion
        '
        Me.lblDetRijndaelVersion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDetRijndaelVersion.AutoSize = True
        Me.lblDetRijndaelVersion.Location = New System.Drawing.Point(111, 170)
        Me.lblDetRijndaelVersion.Name = "lblDetRijndaelVersion"
        Me.lblDetRijndaelVersion.Size = New System.Drawing.Size(103, 30)
        Me.lblDetRijndaelVersion.TabIndex = 11
        Me.lblDetRijndaelVersion.Text = "rijndael version"
        Me.lblDetRijndaelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lx_lblDetLcuxVersion
        '
        Me.lx_lblDetLcuxVersion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_lblDetLcuxVersion.AutoSize = True
        Me.lx_lblDetLcuxVersion.Location = New System.Drawing.Point(3, 140)
        Me.lx_lblDetLcuxVersion.Name = "lx_lblDetLcuxVersion"
        Me.lx_lblDetLcuxVersion.Size = New System.Drawing.Size(102, 30)
        Me.lx_lblDetLcuxVersion.TabIndex = 8
        Me.lx_lblDetLcuxVersion.Text = "lcux version"
        Me.lx_lblDetLcuxVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDetLcuxVersion
        '
        Me.lblDetLcuxVersion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDetLcuxVersion.AutoSize = True
        Me.lblDetLcuxVersion.Location = New System.Drawing.Point(111, 140)
        Me.lblDetLcuxVersion.Name = "lblDetLcuxVersion"
        Me.lblDetLcuxVersion.Size = New System.Drawing.Size(103, 30)
        Me.lblDetLcuxVersion.TabIndex = 9
        Me.lblDetLcuxVersion.Text = "lcux version"
        Me.lblDetLcuxVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDetStatMsgVersion
        '
        Me.lblDetStatMsgVersion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDetStatMsgVersion.AutoSize = True
        Me.lblDetStatMsgVersion.Location = New System.Drawing.Point(111, 110)
        Me.lblDetStatMsgVersion.Name = "lblDetStatMsgVersion"
        Me.lblDetStatMsgVersion.Size = New System.Drawing.Size(103, 30)
        Me.lblDetStatMsgVersion.TabIndex = 7
        Me.lblDetStatMsgVersion.Text = "status version"
        Me.lblDetStatMsgVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lx_tpgLicense
        '
        Me.lx_tpgLicense.Controls.Add(Me.lx_lblLicHeadline)
        Me.lx_tpgLicense.Controls.Add(Me.rtbLicense)
        Me.lx_tpgLicense.Location = New System.Drawing.Point(4, 22)
        Me.lx_tpgLicense.Name = "lx_tpgLicense"
        Me.lx_tpgLicense.Size = New System.Drawing.Size(540, 271)
        Me.lx_tpgLicense.TabIndex = 2
        Me.lx_tpgLicense.Text = "license"
        Me.lx_tpgLicense.UseVisualStyleBackColor = True
        '
        'lx_lblLicHeadline
        '
        Me.lx_lblLicHeadline.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_lblLicHeadline.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lx_lblLicHeadline.Location = New System.Drawing.Point(4, 6)
        Me.lx_lblLicHeadline.Name = "lx_lblLicHeadline"
        Me.lx_lblLicHeadline.Size = New System.Drawing.Size(533, 30)
        Me.lx_lblLicHeadline.TabIndex = 0
        Me.lx_lblLicHeadline.Text = "license-info"
        Me.lx_lblLicHeadline.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'rtbLicense
        '
        Me.rtbLicense.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbLicense.DetectUrls = False
        Me.rtbLicense.Location = New System.Drawing.Point(4, 39)
        Me.rtbLicense.Name = "rtbLicense"
        Me.rtbLicense.ReadOnly = True
        Me.rtbLicense.Size = New System.Drawing.Size(533, 229)
        Me.rtbLicense.TabIndex = 1
        Me.rtbLicense.Text = ""
        '
        'lx_lblDetSettingsVersion
        '
        Me.lx_lblDetSettingsVersion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_lblDetSettingsVersion.AutoSize = True
        Me.lx_lblDetSettingsVersion.Location = New System.Drawing.Point(3, 200)
        Me.lx_lblDetSettingsVersion.Name = "lx_lblDetSettingsVersion"
        Me.lx_lblDetSettingsVersion.Size = New System.Drawing.Size(102, 30)
        Me.lx_lblDetSettingsVersion.TabIndex = 10
        Me.lx_lblDetSettingsVersion.Text = "settings version"
        Me.lx_lblDetSettingsVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDetSettingsVersion
        '
        Me.lblDetSettingsVersion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDetSettingsVersion.AutoSize = True
        Me.lblDetSettingsVersion.Location = New System.Drawing.Point(111, 200)
        Me.lblDetSettingsVersion.Name = "lblDetSettingsVersion"
        Me.lblDetSettingsVersion.Size = New System.Drawing.Size(103, 30)
        Me.lblDetSettingsVersion.TabIndex = 11
        Me.lblDetSettingsVersion.Text = "settings version"
        Me.lblDetSettingsVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmAbout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(572, 321)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(580, 350)
        Me.Name = "frmAbout"
        Me.Text = "frmAbout"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.lx_tpgGeneral.ResumeLayout(False)
        Me.lx_tpgDetails.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.lx_tpgLicense.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents lx_tpgGeneral As System.Windows.Forms.TabPage
    Friend WithEvents lx_lblGenInfoText As System.Windows.Forms.Label
    Friend WithEvents lx_lblGenHeadline As System.Windows.Forms.Label
    Friend WithEvents lx_tpgDetails As System.Windows.Forms.TabPage
    Friend WithEvents lx_tpgLicense As System.Windows.Forms.TabPage
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lx_lblDetVersionInfo As System.Windows.Forms.Label
    Friend WithEvents lx_lblDetStatMsgVersion As System.Windows.Forms.Label
    Friend WithEvents lx_lblDetComponents As System.Windows.Forms.Label
    Friend WithEvents lx_lblDetToolVersion As System.Windows.Forms.Label
    Friend WithEvents lx_lblDetLxmlVersion As System.Windows.Forms.Label
    Friend WithEvents lblDetToolVersion As System.Windows.Forms.Label
    Friend WithEvents lblDetLxmlVersion As System.Windows.Forms.Label
    Friend WithEvents lx_lblDetRijndaelVersion As System.Windows.Forms.Label
    Friend WithEvents lblDetRijndaelVersion As System.Windows.Forms.Label
    Friend WithEvents lx_lblDetLcuxVersion As System.Windows.Forms.Label
    Friend WithEvents lblDetLcuxVersion As System.Windows.Forms.Label
    Friend WithEvents lblDetStatMsgVersion As System.Windows.Forms.Label
    Friend WithEvents lx_lblDetRoleInfo As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lx_lblDetRoleDetailText As System.Windows.Forms.Label
    Friend WithEvents lx_lblDetCurrentRole As System.Windows.Forms.Label
    Friend WithEvents lx_tbxDetRoleDetailText As System.Windows.Forms.TextBox
    Friend WithEvents lblDetCurrentRole As System.Windows.Forms.Label
    Friend WithEvents rtbLicense As System.Windows.Forms.RichTextBox
    Friend WithEvents lx_lblLicHeadline As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lx_lblDetSettingsVersion As System.Windows.Forms.Label
    Friend WithEvents lblDetSettingsVersion As System.Windows.Forms.Label
End Class
