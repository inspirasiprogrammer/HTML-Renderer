Imports TheArtOfDev.HtmlRenderer.WinForms

Namespace TheArtOfDev.HtmlRenderer.Demo.WinForms
	Partial Public Class DemoForm
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
			Me._toolStrip = New System.Windows.Forms.ToolStrip()
			Me._openSampleFormTSB = New System.Windows.Forms.ToolStripButton()
			Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
			Me._showIEViewTSSB = New System.Windows.Forms.ToolStripButton()
			Me._openInExternalViewTSB = New System.Windows.Forms.ToolStripButton()
			Me._useGeneratedHtmlTSB = New System.Windows.Forms.ToolStripButton()
			Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
			Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
			Me._generateImageSTB = New System.Windows.Forms.ToolStripButton()
			Me._generatePdfTSB = New System.Windows.Forms.ToolStripButton()
			Me._runPerformanceTSB = New System.Windows.Forms.ToolStripButton()
			Me._mainControl = New HtmlRenderer.Demo.WinForms.MainControl()
			Me._toolStrip.SuspendLayout()
			Me.SuspendLayout()
			' 
			' _toolStrip
			' 
			Me._toolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() { Me._openSampleFormTSB, Me.toolStripSeparator3, Me._showIEViewTSSB, Me._openInExternalViewTSB, Me._useGeneratedHtmlTSB, Me.toolStripSeparator1, Me.toolStripSeparator2, Me._generateImageSTB, Me._generatePdfTSB, Me._runPerformanceTSB})
			Me._toolStrip.Location = New System.Drawing.Point(4, 4)
			Me._toolStrip.Name = "_toolStrip"
			Me._toolStrip.Size = New System.Drawing.Size(878, 25)
			Me._toolStrip.TabIndex = 1
			' 
			' _openSampleFormTSB
			' 
			Me._openSampleFormTSB.ImageTransparentColor = System.Drawing.Color.Magenta
			Me._openSampleFormTSB.Name = "_openSampleFormTSB"
			Me._openSampleFormTSB.Size = New System.Drawing.Size(113, 22)
			Me._openSampleFormTSB.Text = "Open Sample Form"
			Me._openSampleFormTSB.ToolTipText = "Open Sample Form to control HtmlPanel, HtmlLabel and HtmlTooltip properties."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this._openSampleFormTSB.Click += new System.EventHandler(this.OnOpenSampleForm_Click);
			' 
			' toolStripSeparator3
			' 
			Me.toolStripSeparator3.Name = "toolStripSeparator3"
			Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 25)
			' 
			' _showIEViewTSSB
			' 
			Me._showIEViewTSSB.ImageTransparentColor = System.Drawing.Color.Magenta
			Me._showIEViewTSSB.Name = "_showIEViewTSSB"
			Me._showIEViewTSSB.Size = New System.Drawing.Size(85, 22)
			Me._showIEViewTSSB.Text = "Show Browser"
			Me._showIEViewTSSB.ToolTipText = "Toggle if to show split view of HtmlPanel and WinForms WebBrowser control."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this._showIEViewTSSB.Click += new System.EventHandler(this.OnShowIEView_ButtonClick);
			' 
			' _openInExternalViewTSB
			' 
			Me._openInExternalViewTSB.ImageTransparentColor = System.Drawing.Color.Magenta
			Me._openInExternalViewTSB.Name = "_openInExternalViewTSB"
			Me._openInExternalViewTSB.Size = New System.Drawing.Size(84, 22)
			Me._openInExternalViewTSB.Text = "Open External"
			Me._openInExternalViewTSB.ToolTipText = "Open the HTML is the machine default browser, external to the demo application."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this._openInExternalViewTSB.Click += new System.EventHandler(this.OnOpenInExternalView_Click);
			' 
			' _useGeneratedHtmlTSB
			' 
			Me._useGeneratedHtmlTSB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
			Me._useGeneratedHtmlTSB.ImageTransparentColor = System.Drawing.Color.Magenta
			Me._useGeneratedHtmlTSB.Name = "_useGeneratedHtmlTSB"
			Me._useGeneratedHtmlTSB.Size = New System.Drawing.Size(23, 22)
			Me._useGeneratedHtmlTSB.Text = "Use Generated HTML"
			Me._useGeneratedHtmlTSB.ToolTipText = "Toggle is to use generated HTML from the HtmlPanel in Browser/External views."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this._useGeneratedHtmlTSB.Click += new System.EventHandler(this.OnUseGeneratedHtml_Click);
			' 
			' toolStripSeparator1
			' 
			Me.toolStripSeparator1.Name = "toolStripSeparator1"
			Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
			' 
			' toolStripSeparator2
			' 
			Me.toolStripSeparator2.Name = "toolStripSeparator2"
			Me.toolStripSeparator2.Size = New System.Drawing.Size(6, 25)
			' 
			' _generateImageSTB
			' 
			Me._generateImageSTB.ImageTransparentColor = System.Drawing.Color.Magenta
			Me._generateImageSTB.Name = "_generateImageSTB"
			Me._generateImageSTB.Size = New System.Drawing.Size(94, 22)
			Me._generateImageSTB.Text = "Generate Image"
			Me._generateImageSTB.ToolTipText = "Open generate image form to show the image generation capabilities of HTML Render" &
	"er."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this._generateImageSTB.Click += new System.EventHandler(this.OnGenerateImage_Click);
			' 
			' _generatePdfTSB
			' 
			Me._generatePdfTSB.ImageTransparentColor = System.Drawing.Color.Magenta
			Me._generatePdfTSB.Name = "_generatePdfTSB"
			Me._generatePdfTSB.Size = New System.Drawing.Size(82, 22)
			Me._generatePdfTSB.Text = "Generate PDF"
			Me._generatePdfTSB.ToolTipText = "Generate PDF from the current HTML using PdfSharp library."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this._generatePdfTSB.Click += new System.EventHandler(this.OnGeneratePdf_Click);
			' 
			' _runPerformanceTSB
			' 
			Me._runPerformanceTSB.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
			Me._runPerformanceTSB.ImageTransparentColor = System.Drawing.Color.Magenta
			Me._runPerformanceTSB.Name = "_runPerformanceTSB"
			Me._runPerformanceTSB.Size = New System.Drawing.Size(103, 22)
			Me._runPerformanceTSB.Text = "Run Performance"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this._runPerformanceTSB.Click += new System.EventHandler(this.OnRunPerformance_Click);
			' 
			' _mainControl
			' 
			Me._mainControl.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me._mainControl.Location = New System.Drawing.Point(4, 32)
			Me._mainControl.Name = "_mainControl"
			Me._mainControl.Size = New System.Drawing.Size(878, 594)
			Me._mainControl.TabIndex = 2
			Me._mainControl.UpdateLock = False
			Me._mainControl.UseGeneratedHtml = False
			' 
			' DemoForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = System.Drawing.Color.FromArgb((CInt((CByte(191)))), (CInt((CByte(219)))), (CInt((CByte(255)))))
			Me.ClientSize = New System.Drawing.Size(886, 630)
			Me.Controls.Add(Me._mainControl)
			Me.Controls.Add(Me._toolStrip)
			Me.KeyPreview = True
			Me.Name = "DemoForm"
			Me.Padding = New System.Windows.Forms.Padding(4)
			Me.Text = "HTML Renderer Demo"
			Me._toolStrip.ResumeLayout(False)
			Me._toolStrip.PerformLayout()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private _toolStrip As System.Windows.Forms.ToolStrip
		Private WithEvents _generatePdfTSB As System.Windows.Forms.ToolStripButton
		Private _mainControl As MainControl
		Private WithEvents _openInExternalViewTSB As System.Windows.Forms.ToolStripButton
		Private toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
		Private WithEvents _runPerformanceTSB As System.Windows.Forms.ToolStripButton
		Private WithEvents _openSampleFormTSB As System.Windows.Forms.ToolStripButton
		Private toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
		Private WithEvents _showIEViewTSSB As System.Windows.Forms.ToolStripButton
		Private WithEvents _useGeneratedHtmlTSB As System.Windows.Forms.ToolStripButton
		Private toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
		Private WithEvents _generateImageSTB As System.Windows.Forms.ToolStripButton

	End Class
End Namespace

