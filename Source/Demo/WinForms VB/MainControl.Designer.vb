Namespace TheArtOfDev.HtmlRenderer.Demo.WinForms
	Partial Public Class MainControl
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

		#Region "Component Designer generated code"

		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me._splitContainer1 = New System.Windows.Forms.SplitContainer()
			Me._samplesTreeView = New System.Windows.Forms.TreeView()
			Me._splitContainer2 = New System.Windows.Forms.SplitContainer()
			Me._htmlPanel = New HtmlRenderer.WinForms.HtmlPanel()
			Me._splitter = New System.Windows.Forms.Splitter()
			Me._webBrowser = New System.Windows.Forms.WebBrowser()
			Me._reloadColorsLink = New System.Windows.Forms.LinkLabel()
			Me._htmlEditor = New System.Windows.Forms.RichTextBox()
			Me._htmlToolTip = New HtmlRenderer.WinForms.HtmlToolTip()
			Me._splitContainer1.Panel1.SuspendLayout()
			Me._splitContainer1.Panel2.SuspendLayout()
			Me._splitContainer1.SuspendLayout()
			Me._splitContainer2.Panel1.SuspendLayout()
			Me._splitContainer2.Panel2.SuspendLayout()
			Me._splitContainer2.SuspendLayout()
			Me.SuspendLayout()
			' 
			' _splitContainer1
			' 
			Me._splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
			Me._splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
			Me._splitContainer1.Location = New System.Drawing.Point(0, 0)
			Me._splitContainer1.Name = "_splitContainer1"
			' 
			' _splitContainer1.Panel1
			' 
			Me._splitContainer1.Panel1.Controls.Add(Me._samplesTreeView)
			' 
			' _splitContainer1.Panel2
			' 
			Me._splitContainer1.Panel2.Controls.Add(Me._splitContainer2)
			Me._splitContainer1.Size = New System.Drawing.Size(879, 593)
			Me._splitContainer1.SplitterDistance = 146
			Me._splitContainer1.TabIndex = 1
			Me._splitContainer1.TabStop = False
			' 
			' _samplesTreeView
			' 
			Me._samplesTreeView.Dock = System.Windows.Forms.DockStyle.Fill
			Me._samplesTreeView.HideSelection = False
			Me._samplesTreeView.Location = New System.Drawing.Point(0, 0)
			Me._samplesTreeView.Name = "_samplesTreeView"
			Me._samplesTreeView.Size = New System.Drawing.Size(146, 593)
			Me._samplesTreeView.TabIndex = 14
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this._samplesTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OnSamplesTreeViewAfterSelect);
			' 
			' _splitContainer2
			' 
			Me._splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
			Me._splitContainer2.Location = New System.Drawing.Point(0, 0)
			Me._splitContainer2.Name = "_splitContainer2"
			Me._splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
			' 
			' _splitContainer2.Panel1
			' 
			Me._splitContainer2.Panel1.Controls.Add(Me._htmlPanel)
			Me._splitContainer2.Panel1.Controls.Add(Me._splitter)
			Me._splitContainer2.Panel1.Controls.Add(Me._webBrowser)
			' 
			' _splitContainer2.Panel2
			' 
			Me._splitContainer2.Panel2.Controls.Add(Me._reloadColorsLink)
			Me._splitContainer2.Panel2.Controls.Add(Me._htmlEditor)
			Me._splitContainer2.Size = New System.Drawing.Size(729, 593)
			Me._splitContainer2.SplitterDistance = 476
			Me._splitContainer2.TabIndex = 13
			Me._splitContainer2.TabStop = False
			' 
			' _htmlPanel
			' 
			Me._htmlPanel.AutoScroll = True
			Me._htmlPanel.BackColor = System.Drawing.SystemColors.Window
			Me._htmlPanel.BaseStylesheet = Nothing
			Me._htmlPanel.Dock = System.Windows.Forms.DockStyle.Fill
			Me._htmlPanel.Location = New System.Drawing.Point(0, 0)
			Me._htmlPanel.Name = "_htmlPanel"
			Me._htmlPanel.Padding = New System.Windows.Forms.Padding(0, 4, 0, 0)
			Me._htmlPanel.Size = New System.Drawing.Size(485, 476)
			Me._htmlPanel.TabIndex = 8
			Me._htmlPanel.Text = Nothing
			Me._htmlPanel.UseSystemCursors = True
			' 
			' _splitter
			' 
			Me._splitter.Dock = System.Windows.Forms.DockStyle.Right
			Me._splitter.Location = New System.Drawing.Point(485, 0)
			Me._splitter.Name = "_splitter"
			Me._splitter.Size = New System.Drawing.Size(3, 476)
			Me._splitter.TabIndex = 9
			Me._splitter.TabStop = False
			Me._splitter.Visible = False
			' 
			' _webBrowser
			' 
			Me._webBrowser.Dock = System.Windows.Forms.DockStyle.Right
			Me._webBrowser.Location = New System.Drawing.Point(488, 0)
			Me._webBrowser.MinimumSize = New System.Drawing.Size(20, 20)
			Me._webBrowser.Name = "_webBrowser"
			Me._webBrowser.Size = New System.Drawing.Size(241, 476)
			Me._webBrowser.TabIndex = 7
			Me._webBrowser.Visible = False
			' 
			' _reloadColorsLink
			' 
			Me._reloadColorsLink.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me._reloadColorsLink.AutoSize = True
			Me._reloadColorsLink.BackColor = System.Drawing.Color.White
			Me._reloadColorsLink.Location = New System.Drawing.Point(666, 97)
			Me._reloadColorsLink.Name = "_reloadColorsLink"
			Me._reloadColorsLink.Size = New System.Drawing.Size(44, 13)
			Me._reloadColorsLink.TabIndex = 8
			Me._reloadColorsLink.TabStop = True
			Me._reloadColorsLink.Text = "Refresh"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this._reloadColorsLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnReloadColorsLinkClicked);
			' 
			' _htmlEditor
			' 
			Me._htmlEditor.Dock = System.Windows.Forms.DockStyle.Fill
			Me._htmlEditor.Location = New System.Drawing.Point(0, 0)
			Me._htmlEditor.Name = "_htmlEditor"
			Me._htmlEditor.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
			Me._htmlEditor.Size = New System.Drawing.Size(729, 113)
			Me._htmlEditor.TabIndex = 7
			Me._htmlEditor.Text = ""
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this._htmlEditor.TextChanged += new System.EventHandler(this.OnHtmlEditorTextChanged);
			' 
			' _htmlToolTip
			' 
			Me._htmlToolTip.AutoPopDelay = 15000
			Me._htmlToolTip.BaseStylesheet = Nothing
			Me._htmlToolTip.InitialDelay = 500
			Me._htmlToolTip.MaximumSize = New System.Drawing.Size(0, 0)
			Me._htmlToolTip.OwnerDraw = True
			Me._htmlToolTip.ReshowDelay = 100
			Me._htmlToolTip.TooltipCssClass = "htmltooltip"
			' 
			' MainControl
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me._splitContainer1)
			Me.Name = "MainControl"
			Me.Size = New System.Drawing.Size(879, 593)
			Me._splitContainer1.Panel1.ResumeLayout(False)
			Me._splitContainer1.Panel2.ResumeLayout(False)
			Me._splitContainer1.ResumeLayout(False)
			Me._splitContainer2.Panel1.ResumeLayout(False)
			Me._splitContainer2.Panel2.ResumeLayout(False)
			Me._splitContainer2.Panel2.PerformLayout()
			Me._splitContainer2.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private _splitContainer1 As System.Windows.Forms.SplitContainer
		Private WithEvents _samplesTreeView As System.Windows.Forms.TreeView
		Private _splitContainer2 As System.Windows.Forms.SplitContainer
		Private _htmlPanel As HtmlRenderer.WinForms.HtmlPanel
		Private _splitter As System.Windows.Forms.Splitter
		Private _webBrowser As System.Windows.Forms.WebBrowser
		Private WithEvents _reloadColorsLink As System.Windows.Forms.LinkLabel
		Private WithEvents _htmlEditor As System.Windows.Forms.RichTextBox
		Private _htmlToolTip As HtmlRenderer.WinForms.HtmlToolTip
	End Class
End Namespace
