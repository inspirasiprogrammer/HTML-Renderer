Namespace TheArtOfDev.HtmlRenderer.Demo.WinForms
	Partial Public Class GenerateImageForm
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GenerateImageForm))
            Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
            Me._generateImageTSB = New System.Windows.Forms.ToolStripButton()
            Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
            Me._saveToFileTSB = New System.Windows.Forms.ToolStripButton()
            Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
            Me._useGdiPlusTSB = New System.Windows.Forms.ToolStripButton()
            Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
            Me._toolStripLabel = New System.Windows.Forms.ToolStripLabel()
            Me._backgroundColorTSB = New System.Windows.Forms.ToolStripComboBox()
            Me._textRenderingHintTSCB = New System.Windows.Forms.ToolStripComboBox()
            Me._pictureBox = New System.Windows.Forms.PictureBox()
            Me.toolStrip1.SuspendLayout()
            CType(Me._pictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'toolStrip1
            '
            Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._generateImageTSB, Me.toolStripSeparator3, Me._saveToFileTSB, Me.toolStripSeparator2, Me._useGdiPlusTSB, Me.toolStripSeparator1, Me._toolStripLabel, Me._backgroundColorTSB, Me._textRenderingHintTSCB})
            Me.toolStrip1.Location = New System.Drawing.Point(0, 0)
            Me.toolStrip1.Name = "toolStrip1"
            Me.toolStrip1.Size = New System.Drawing.Size(610, 25)
            Me.toolStrip1.TabIndex = 0
            Me.toolStrip1.Text = "toolStrip1"
            '
            '_generateImageTSB
            '
            Me._generateImageTSB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
            Me._generateImageTSB.ImageTransparentColor = System.Drawing.Color.Magenta
            Me._generateImageTSB.Name = "_generateImageTSB"
            Me._generateImageTSB.Size = New System.Drawing.Size(76, 22)
            Me._generateImageTSB.Text = "Re-Generate"
            '
            'toolStripSeparator3
            '
            Me.toolStripSeparator3.Name = "toolStripSeparator3"
            Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 25)
            '
            '_saveToFileTSB
            '
            Me._saveToFileTSB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
            Me._saveToFileTSB.Image = CType(resources.GetObject("_saveToFileTSB.Image"), System.Drawing.Image)
            Me._saveToFileTSB.ImageTransparentColor = System.Drawing.Color.Magenta
            Me._saveToFileTSB.Name = "_saveToFileTSB"
            Me._saveToFileTSB.Size = New System.Drawing.Size(70, 22)
            Me._saveToFileTSB.Text = "Save to File"
            '
            'toolStripSeparator2
            '
            Me.toolStripSeparator2.Name = "toolStripSeparator2"
            Me.toolStripSeparator2.Size = New System.Drawing.Size(6, 25)
            '
            '_useGdiPlusTSB
            '
            Me._useGdiPlusTSB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
            Me._useGdiPlusTSB.ImageTransparentColor = System.Drawing.Color.Magenta
            Me._useGdiPlusTSB.Name = "_useGdiPlusTSB"
            Me._useGdiPlusTSB.Size = New System.Drawing.Size(141, 22)
            Me._useGdiPlusTSB.Text = "Use GDI+ Text Rendering"
            '
            'toolStripSeparator1
            '
            Me.toolStripSeparator1.Name = "toolStripSeparator1"
            Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
            '
            '_toolStripLabel
            '
            Me._toolStripLabel.Name = "_toolStripLabel"
            Me._toolStripLabel.Size = New System.Drawing.Size(77, 22)
            Me._toolStripLabel.Text = "Background: "
            '
            '_backgroundColorTSB
            '
            Me._backgroundColorTSB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me._backgroundColorTSB.Name = "_backgroundColorTSB"
            Me._backgroundColorTSB.Size = New System.Drawing.Size(121, 25)
            '
            '_textRenderingHintTSCB
            '
            Me._textRenderingHintTSCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me._textRenderingHintTSCB.Name = "_textRenderingHintTSCB"
            Me._textRenderingHintTSCB.Size = New System.Drawing.Size(121, 23)
            Me._textRenderingHintTSCB.Visible = False
            '
            '_pictureBox
            '
            Me._pictureBox.BackColor = System.Drawing.Color.Transparent
            Me._pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me._pictureBox.Dock = System.Windows.Forms.DockStyle.Fill
            Me._pictureBox.Location = New System.Drawing.Point(0, 25)
            Me._pictureBox.Name = "_pictureBox"
            Me._pictureBox.Size = New System.Drawing.Size(610, 472)
            Me._pictureBox.TabIndex = 1
            Me._pictureBox.TabStop = False
            '
            'GenerateImageForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(610, 497)
            Me.Controls.Add(Me._pictureBox)
            Me.Controls.Add(Me.toolStrip1)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "GenerateImageForm"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Generate Image"
            Me.toolStrip1.ResumeLayout(False)
            Me.toolStrip1.PerformLayout()
            CType(Me._pictureBox, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

#End Region

        Private toolStrip1 As System.Windows.Forms.ToolStrip
		Private _pictureBox As System.Windows.Forms.PictureBox
		Private WithEvents _useGdiPlusTSB As System.Windows.Forms.ToolStripButton
		Private WithEvents _generateImageTSB As System.Windows.Forms.ToolStripButton
		Private toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
		Private WithEvents _backgroundColorTSB As System.Windows.Forms.ToolStripComboBox
		Private _toolStripLabel As System.Windows.Forms.ToolStripLabel
		Private WithEvents _textRenderingHintTSCB As System.Windows.Forms.ToolStripComboBox
		Private toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
		Private toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
		Private WithEvents _saveToFileTSB As System.Windows.Forms.ToolStripButton
	End Class
End Namespace