<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.ExtractButton = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.SelectZipFileButton = New System.Windows.Forms.Button()
        Me.CompressionFileNameTextBox = New System.Windows.Forms.TextBox()
        Me.SelectZipFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.SelectFolderButton = New System.Windows.Forms.Button()
        Me.ExtractionFolderTextBox = New System.Windows.Forms.TextBox()
        Me.ExtractFolderBrowser = New WK.Libraries.BetterFolderBrowserNS.BetterFolderBrowser(Me.components)
        Me.PurgeTargetFolderButton = New System.Windows.Forms.Button()
        Me.UseProgressBarCheckBox = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(120, 81)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(283, 23)
        Me.ProgressBar1.TabIndex = 0
        Me.ProgressBar1.Visible = False
        '
        'ExtractButton
        '
        Me.ExtractButton.Location = New System.Drawing.Point(12, 81)
        Me.ExtractButton.Name = "ExtractButton"
        Me.ExtractButton.Size = New System.Drawing.Size(96, 23)
        Me.ExtractButton.TabIndex = 1
        Me.ExtractButton.Text = "Execute"
        Me.ExtractButton.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(120, 115)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(283, 121)
        Me.ListBox1.TabIndex = 2
        '
        'SelectZipFileButton
        '
        Me.SelectZipFileButton.Location = New System.Drawing.Point(12, 11)
        Me.SelectZipFileButton.Name = "SelectZipFileButton"
        Me.SelectZipFileButton.Size = New System.Drawing.Size(96, 23)
        Me.SelectZipFileButton.TabIndex = 3
        Me.SelectZipFileButton.Text = "Select .zip file"
        Me.SelectZipFileButton.UseVisualStyleBackColor = True
        '
        'CompressionFileNameTextBox
        '
        Me.CompressionFileNameTextBox.BackColor = System.Drawing.Color.Silver
        Me.CompressionFileNameTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CompressionFileNameTextBox.Location = New System.Drawing.Point(120, 13)
        Me.CompressionFileNameTextBox.Name = "CompressionFileNameTextBox"
        Me.CompressionFileNameTextBox.ReadOnly = True
        Me.CompressionFileNameTextBox.Size = New System.Drawing.Size(283, 20)
        Me.CompressionFileNameTextBox.TabIndex = 4
        '
        'SelectZipFileDialog
        '
        Me.SelectZipFileDialog.Filter = "Zip files|*.zip"
        '
        'SelectFolderButton
        '
        Me.SelectFolderButton.Location = New System.Drawing.Point(12, 51)
        Me.SelectFolderButton.Name = "SelectFolderButton"
        Me.SelectFolderButton.Size = New System.Drawing.Size(96, 23)
        Me.SelectFolderButton.TabIndex = 5
        Me.SelectFolderButton.Text = "Select folder"
        Me.SelectFolderButton.UseVisualStyleBackColor = True
        '
        'ExtractionFolderTextBox
        '
        Me.ExtractionFolderTextBox.BackColor = System.Drawing.Color.Silver
        Me.ExtractionFolderTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExtractionFolderTextBox.Location = New System.Drawing.Point(120, 51)
        Me.ExtractionFolderTextBox.Name = "ExtractionFolderTextBox"
        Me.ExtractionFolderTextBox.ReadOnly = True
        Me.ExtractionFolderTextBox.Size = New System.Drawing.Size(283, 20)
        Me.ExtractionFolderTextBox.TabIndex = 6
        '
        'ExtractFolderBrowser
        '
        Me.ExtractFolderBrowser.Multiselect = False
        Me.ExtractFolderBrowser.RootFolder = "C:\"
        Me.ExtractFolderBrowser.Title = "Please select a folder..."
        '
        'PurgeTargetFolderButton
        '
        Me.PurgeTargetFolderButton.Location = New System.Drawing.Point(12, 213)
        Me.PurgeTargetFolderButton.Name = "PurgeTargetFolderButton"
        Me.PurgeTargetFolderButton.Size = New System.Drawing.Size(96, 23)
        Me.PurgeTargetFolderButton.TabIndex = 7
        Me.PurgeTargetFolderButton.Text = "Purge"
        Me.PurgeTargetFolderButton.UseVisualStyleBackColor = True
        '
        'UseProgressBarCheckBox
        '
        Me.UseProgressBarCheckBox.AutoSize = True
        Me.UseProgressBarCheckBox.Location = New System.Drawing.Point(12, 115)
        Me.UseProgressBarCheckBox.Name = "UseProgressBarCheckBox"
        Me.UseProgressBarCheckBox.Size = New System.Drawing.Size(106, 17)
        Me.UseProgressBarCheckBox.TabIndex = 8
        Me.UseProgressBarCheckBox.Text = "Use progress bar"
        Me.UseProgressBarCheckBox.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(415, 258)
        Me.Controls.Add(Me.UseProgressBarCheckBox)
        Me.Controls.Add(Me.PurgeTargetFolderButton)
        Me.Controls.Add(Me.ExtractionFolderTextBox)
        Me.Controls.Add(Me.SelectFolderButton)
        Me.Controls.Add(Me.CompressionFileNameTextBox)
        Me.Controls.Add(Me.SelectZipFileButton)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.ExtractButton)
        Me.Controls.Add(Me.ProgressBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Extract files from compress file"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents ExtractButton As Button
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents SelectZipFileButton As Button
    Friend WithEvents CompressionFileNameTextBox As TextBox
    Friend WithEvents SelectZipFileDialog As OpenFileDialog
    Friend WithEvents SelectFolderButton As Button
    Friend WithEvents ExtractionFolderTextBox As TextBox
    Friend WithEvents ExtractFolderBrowser As WK.Libraries.BetterFolderBrowserNS.BetterFolderBrowser
    Friend WithEvents PurgeTargetFolderButton As Button
    Friend WithEvents UseProgressBarCheckBox As CheckBox
End Class
