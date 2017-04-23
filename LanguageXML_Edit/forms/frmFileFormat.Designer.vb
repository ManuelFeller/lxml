<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFileFormat
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFileFormat))
        Me.lx_grpSeletcion = New System.Windows.Forms.GroupBox
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.lx_lblVersion1 = New System.Windows.Forms.Label
        Me.lx_rbtVersion1 = New System.Windows.Forms.RadioButton
        Me.lx_lblVersion2 = New System.Windows.Forms.Label
        Me.lx_rbtVersion2 = New System.Windows.Forms.RadioButton
        Me.lx_btnOK = New System.Windows.Forms.Button
        Me.lx_btnCancel = New System.Windows.Forms.Button
        Me.lx_grpSeletcion.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lx_grpSeletcion
        '
        Me.lx_grpSeletcion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_grpSeletcion.Controls.Add(Me.TableLayoutPanel1)
        Me.lx_grpSeletcion.Location = New System.Drawing.Point(12, 12)
        Me.lx_grpSeletcion.Name = "lx_grpSeletcion"
        Me.lx_grpSeletcion.Size = New System.Drawing.Size(320, 220)
        Me.lx_grpSeletcion.TabIndex = 0
        Me.lx_grpSeletcion.TabStop = False
        Me.lx_grpSeletcion.Text = "GroupBox1"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lx_lblVersion1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lx_rbtVersion1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lx_lblVersion2, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lx_rbtVersion2, 0, 2)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(6, 19)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(308, 195)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'lx_lblVersion1
        '
        Me.lx_lblVersion1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_lblVersion1.Location = New System.Drawing.Point(3, 30)
        Me.lx_lblVersion1.Name = "lx_lblVersion1"
        Me.lx_lblVersion1.Size = New System.Drawing.Size(302, 67)
        Me.lx_lblVersion1.TabIndex = 1
        Me.lx_lblVersion1.Text = "info"
        '
        'lx_rbtVersion1
        '
        Me.lx_rbtVersion1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_rbtVersion1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lx_rbtVersion1.Location = New System.Drawing.Point(3, 3)
        Me.lx_rbtVersion1.Name = "lx_rbtVersion1"
        Me.lx_rbtVersion1.Size = New System.Drawing.Size(302, 24)
        Me.lx_rbtVersion1.TabIndex = 0
        Me.lx_rbtVersion1.TabStop = True
        Me.lx_rbtVersion1.Text = "ver 1"
        Me.lx_rbtVersion1.UseVisualStyleBackColor = True
        '
        'lx_lblVersion2
        '
        Me.lx_lblVersion2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_lblVersion2.Location = New System.Drawing.Point(3, 127)
        Me.lx_lblVersion2.Name = "lx_lblVersion2"
        Me.lx_lblVersion2.Size = New System.Drawing.Size(302, 68)
        Me.lx_lblVersion2.TabIndex = 3
        Me.lx_lblVersion2.Text = "info"
        '
        'lx_rbtVersion2
        '
        Me.lx_rbtVersion2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lx_rbtVersion2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lx_rbtVersion2.Location = New System.Drawing.Point(3, 100)
        Me.lx_rbtVersion2.Name = "lx_rbtVersion2"
        Me.lx_rbtVersion2.Size = New System.Drawing.Size(302, 24)
        Me.lx_rbtVersion2.TabIndex = 2
        Me.lx_rbtVersion2.TabStop = True
        Me.lx_rbtVersion2.Text = "ver 2"
        Me.lx_rbtVersion2.UseVisualStyleBackColor = True
        '
        'lx_btnOK
        '
        Me.lx_btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lx_btnOK.Location = New System.Drawing.Point(69, 238)
        Me.lx_btnOK.Name = "lx_btnOK"
        Me.lx_btnOK.Size = New System.Drawing.Size(100, 23)
        Me.lx_btnOK.TabIndex = 1
        Me.lx_btnOK.Text = "ok"
        Me.lx_btnOK.UseVisualStyleBackColor = True
        '
        'lx_btnCancel
        '
        Me.lx_btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lx_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.lx_btnCancel.Location = New System.Drawing.Point(175, 238)
        Me.lx_btnCancel.Name = "lx_btnCancel"
        Me.lx_btnCancel.Size = New System.Drawing.Size(100, 23)
        Me.lx_btnCancel.TabIndex = 2
        Me.lx_btnCancel.Text = "cancel"
        Me.lx_btnCancel.UseVisualStyleBackColor = True
        '
        'frmFileFormat
        '
        Me.AcceptButton = Me.lx_btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.lx_btnCancel
        Me.ClientSize = New System.Drawing.Size(344, 273)
        Me.Controls.Add(Me.lx_btnCancel)
        Me.Controls.Add(Me.lx_btnOK)
        Me.Controls.Add(Me.lx_grpSeletcion)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFileFormat"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmFileFormat"
        Me.lx_grpSeletcion.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lx_grpSeletcion As System.Windows.Forms.GroupBox
    Friend WithEvents lx_lblVersion1 As System.Windows.Forms.Label
    Friend WithEvents lx_rbtVersion1 As System.Windows.Forms.RadioButton
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lx_lblVersion2 As System.Windows.Forms.Label
    Friend WithEvents lx_rbtVersion2 As System.Windows.Forms.RadioButton
    Friend WithEvents lx_btnOK As System.Windows.Forms.Button
    Friend WithEvents lx_btnCancel As System.Windows.Forms.Button
End Class
