Imports TheArtOfDev.HtmlRenderer.WinForms

Namespace TheArtOfDev.HtmlRenderer.Demo.WinForms
	Partial Public Class SampleForm
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
			Me._htmlToolTip = New TheArtOfDev.HtmlRenderer.WinForms.HtmlToolTip()
			Me._changeTooltipButton = New System.Windows.Forms.Button()
			Me._splitContainer = New System.Windows.Forms.SplitContainer()
			Me._htmlPanel = New TheArtOfDev.HtmlRenderer.WinForms.HtmlPanel()
			Me.label2 = New System.Windows.Forms.Label()
			Me._htmlLabelHostingPanel = New System.Windows.Forms.Panel()
			Me._htmlLabel = New TheArtOfDev.HtmlRenderer.WinForms.HtmlLabel()
			Me.label1 = New System.Windows.Forms.Label()
			Me._pGrid = New System.Windows.Forms.PropertyGrid()
			Me._splitContainer.Panel1.SuspendLayout()
			Me._splitContainer.Panel2.SuspendLayout()
			Me._splitContainer.SuspendLayout()
			Me._htmlLabelHostingPanel.SuspendLayout()
			Me.SuspendLayout()
			' 
			' _htmlToolTip
			' 
			Me._htmlToolTip.BaseStylesheet = Nothing
			Me._htmlToolTip.MaximumSize = New System.Drawing.Size(0, 0)
			Me._htmlToolTip.OwnerDraw = True
			Me._htmlToolTip.TooltipCssClass = "htmltooltip"
			' 
			' _changeTooltipButton
			' 
			Me._changeTooltipButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me._changeTooltipButton.Location = New System.Drawing.Point(7, 461)
			Me._changeTooltipButton.Name = "_changeTooltipButton"
			Me._changeTooltipButton.Size = New System.Drawing.Size(407, 23)
			Me._changeTooltipButton.TabIndex = 11
			Me._changeTooltipButton.Text = "Click me to change tooltip"
			Me._htmlToolTip.SetToolTip(Me._changeTooltipButton, "When you click this button, this tooltip will be replaced for the text of the <b>" & "HtmlLabel</b>")
			Me._changeTooltipButton.UseVisualStyleBackColor = True
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this._changeTooltipButton.Click += new System.EventHandler(this.OnButtonClick);
			' 
			' _splitContainer
			' 
			Me._splitContainer.Dock = System.Windows.Forms.DockStyle.Fill
			Me._splitContainer.Location = New System.Drawing.Point(0, 0)
			Me._splitContainer.Name = "_splitContainer"
			' 
			' _splitContainer.Panel1
			' 
			Me._splitContainer.Panel1.Controls.Add(Me._changeTooltipButton)
			Me._splitContainer.Panel1.Controls.Add(Me._htmlPanel)
			Me._splitContainer.Panel1.Controls.Add(Me.label2)
			Me._splitContainer.Panel1.Controls.Add(Me._htmlLabelHostingPanel)
			Me._splitContainer.Panel1.Controls.Add(Me.label1)
			' 
			' _splitContainer.Panel2
			' 
			Me._splitContainer.Panel2.Controls.Add(Me._pGrid)
			Me._splitContainer.Size = New System.Drawing.Size(719, 496)
			Me._splitContainer.SplitterDistance = 422
			Me._splitContainer.TabIndex = 7
			' 
			' _htmlPanel
			' 
			Me._htmlPanel.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me._htmlPanel.AutoScroll = True
			Me._htmlPanel.BackColor = System.Drawing.SystemColors.Window
			Me._htmlPanel.BaseStylesheet = Nothing
			Me._htmlPanel.Cursor = System.Windows.Forms.Cursors.IBeam
			Me._htmlPanel.Location = New System.Drawing.Point(7, 221)
			Me._htmlPanel.Name = "_htmlPanel"
			Me._htmlPanel.Size = New System.Drawing.Size(407, 225)
			Me._htmlPanel.TabIndex = 10
			Me._htmlPanel.Text = Nothing
			Me._htmlPanel.UseSystemCursors = True
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this._htmlPanel.Click += new System.EventHandler(this.OnHtmlPanelClick);
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(4, 205)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(55, 13)
			Me.label2.TabIndex = 9
			Me.label2.Text = "HtmlPanel"
			' 
			' _htmlLabelHostingPanel
			' 
			Me._htmlLabelHostingPanel.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me._htmlLabelHostingPanel.BackColor = System.Drawing.Color.Transparent
			Me._htmlLabelHostingPanel.Controls.Add(Me._htmlLabel)
			Me._htmlLabelHostingPanel.Location = New System.Drawing.Point(7, 23)
			Me._htmlLabelHostingPanel.Name = "_htmlLabelHostingPanel"
			Me._htmlLabelHostingPanel.Size = New System.Drawing.Size(407, 169)
			Me._htmlLabelHostingPanel.TabIndex = 8
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this._htmlLabelHostingPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.OnHtmlLabelHostingPanelPaint);
			' 
			' _htmlLabel
			' 
			Me._htmlLabel.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me._htmlLabel.AutoSize = False
			Me._htmlLabel.AutoSizeHeightOnly = True
			Me._htmlLabel.BackColor = System.Drawing.Color.Transparent
			Me._htmlLabel.BaseStylesheet = Nothing
			Me._htmlLabel.Location = New System.Drawing.Point(10, 11)
			Me._htmlLabel.Name = "_htmlLabel"
			Me._htmlLabel.Size = New System.Drawing.Size(385, 0)
			Me._htmlLabel.TabIndex = 0
			Me._htmlLabel.Text = Nothing
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this._htmlLabel.Click += new System.EventHandler(this.OnHtmlLabelClick);
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(4, 7)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(54, 13)
			Me.label1.TabIndex = 7
			Me.label1.Text = "HtmlLabel"
			' 
			' _pGrid
			' 
			Me._pGrid.Dock = System.Windows.Forms.DockStyle.Fill
			Me._pGrid.Location = New System.Drawing.Point(0, 0)
			Me._pGrid.Name = "_pGrid"
			Me._pGrid.Size = New System.Drawing.Size(293, 496)
			Me._pGrid.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this._pGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.OnPropertyValueChanged);
			' 
			' SampleForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(719, 496)
			Me.Controls.Add(Me._splitContainer)
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "SampleForm"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "Sample Form"
			Me._splitContainer.Panel1.ResumeLayout(False)
			Me._splitContainer.Panel1.PerformLayout()
			Me._splitContainer.Panel2.ResumeLayout(False)
			Me._splitContainer.ResumeLayout(False)
			Me._htmlLabelHostingPanel.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private _htmlToolTip As HtmlToolTip
		Private _splitContainer As System.Windows.Forms.SplitContainer
		Private WithEvents _changeTooltipButton As System.Windows.Forms.Button
		Private WithEvents _htmlPanel As HtmlPanel
		Private label2 As System.Windows.Forms.Label
		Private WithEvents _htmlLabelHostingPanel As System.Windows.Forms.Panel
		Private WithEvents _htmlLabel As HtmlLabel
		Private label1 As System.Windows.Forms.Label
		Private WithEvents _pGrid As System.Windows.Forms.PropertyGrid
	End Class
End Namespace