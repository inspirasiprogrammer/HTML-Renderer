Imports TheArtOfDev.HtmlRenderer.WinForms

Namespace TheArtOfDev.HtmlRenderer.Demo.WinForms
	Partial Public Class PerfForm
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
			Me._splitContainer1 = New System.Windows.Forms.SplitContainer()
			Me._clearLink = New System.Windows.Forms.LinkLabel()
			Me._iterations = New System.Windows.Forms.NumericUpDown()
			Me.label1 = New System.Windows.Forms.Label()
			Me._runTestButton = New System.Windows.Forms.Button()
			Me._samplesTreeView = New System.Windows.Forms.TreeView()
			Me._htmlPanel = New HtmlPanel()
			CType(Me._splitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me._splitContainer1.Panel1.SuspendLayout()
			Me._splitContainer1.Panel2.SuspendLayout()
			Me._splitContainer1.SuspendLayout()
			CType(Me._iterations, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' _splitContainer1
			' 
			Me._splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
			Me._splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
			Me._splitContainer1.Location = New System.Drawing.Point(4, 4)
			Me._splitContainer1.Name = "_splitContainer1"
			' 
			' _splitContainer1.Panel1
			' 
			Me._splitContainer1.Panel1.Controls.Add(Me._clearLink)
			Me._splitContainer1.Panel1.Controls.Add(Me._iterations)
			Me._splitContainer1.Panel1.Controls.Add(Me.label1)
			Me._splitContainer1.Panel1.Controls.Add(Me._runTestButton)
			Me._splitContainer1.Panel1.Controls.Add(Me._samplesTreeView)
			' 
			' _splitContainer1.Panel2
			' 
			Me._splitContainer1.Panel2.Controls.Add(Me._htmlPanel)
			Me._splitContainer1.Size = New System.Drawing.Size(667, 439)
			Me._splitContainer1.SplitterDistance = 146
			Me._splitContainer1.TabIndex = 0
			Me._splitContainer1.TabStop = False
			' 
			' _clearLink
			' 
			Me._clearLink.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me._clearLink.AutoSize = True
			Me._clearLink.BackColor = System.Drawing.Color.White
			Me._clearLink.Location = New System.Drawing.Point(111, 365)
			Me._clearLink.Name = "_clearLink"
			Me._clearLink.Size = New System.Drawing.Size(31, 13)
			Me._clearLink.TabIndex = 18
			Me._clearLink.TabStop = True
			Me._clearLink.Text = "Clear"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this._clearLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnClearLinkClicked);
			' 
			' _iterations
			' 
			Me._iterations.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me._iterations.Location = New System.Drawing.Point(65, 386)
			Me._iterations.Name = "_iterations"
			Me._iterations.Size = New System.Drawing.Size(77, 20)
			Me._iterations.TabIndex = 16
			Me._iterations.Value = New Decimal(New Integer() { 12, 0, 0, 0})
			' 
			' label1
			' 
			Me.label1.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.label1.AutoSize = True
			Me.label1.BackColor = System.Drawing.Color.White
			Me.label1.Location = New System.Drawing.Point(6, 389)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(53, 13)
			Me.label1.TabIndex = 17
			Me.label1.Text = "Iterations:"
			' 
			' _runTestButton
			' 
			Me._runTestButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me._runTestButton.Location = New System.Drawing.Point(4, 411)
			Me._runTestButton.Name = "_runTestButton"
			Me._runTestButton.Size = New System.Drawing.Size(138, 23)
			Me._runTestButton.TabIndex = 15
			Me._runTestButton.TabStop = False
			Me._runTestButton.Text = "Run Test"
			Me._runTestButton.UseVisualStyleBackColor = True
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this._runTestButton.Click += new System.EventHandler(this.OnRunTestButtonClick);
			' 
			' _samplesTreeView
			' 
			Me._samplesTreeView.Dock = System.Windows.Forms.DockStyle.Fill
			Me._samplesTreeView.HideSelection = False
			Me._samplesTreeView.Location = New System.Drawing.Point(0, 0)
			Me._samplesTreeView.Name = "_samplesTreeView"
			Me._samplesTreeView.Size = New System.Drawing.Size(146, 439)
			Me._samplesTreeView.TabIndex = 14
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this._samplesTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OnSamplesTreeViewAfterSelect);
			' 
			' _htmlPanel
			' 
			Me._htmlPanel.AutoScroll = True
			Me._htmlPanel.AvoidGeometryAntialias = False
			Me._htmlPanel.AvoidImagesLateLoading = False
			Me._htmlPanel.BackColor = System.Drawing.SystemColors.Window
			Me._htmlPanel.BaseStylesheet = Nothing
			Me._htmlPanel.Dock = System.Windows.Forms.DockStyle.Fill
			Me._htmlPanel.Location = New System.Drawing.Point(0, 0)
			Me._htmlPanel.Name = "_htmlPanel"
			Me._htmlPanel.Padding = New System.Windows.Forms.Padding(0, 4, 0, 0)
			Me._htmlPanel.Size = New System.Drawing.Size(517, 439)
			Me._htmlPanel.TabIndex = 9
			' 
			' PerfForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = System.Drawing.Color.FromArgb((CInt((CByte(191)))), (CInt((CByte(219)))), (CInt((CByte(255)))))
			Me.ClientSize = New System.Drawing.Size(675, 447)
			Me.Controls.Add(Me._splitContainer1)
			Me.KeyPreview = True
			Me.Name = "PerfForm"
			Me.Padding = New System.Windows.Forms.Padding(4)
			Me.Text = "HTML Renderer Demo"
			Me._splitContainer1.Panel1.ResumeLayout(False)
			Me._splitContainer1.Panel1.PerformLayout()
			Me._splitContainer1.Panel2.ResumeLayout(False)
			CType(Me._splitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
			Me._splitContainer1.ResumeLayout(False)
			CType(Me._iterations, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private _splitContainer1 As System.Windows.Forms.SplitContainer
		Private WithEvents _runTestButton As System.Windows.Forms.Button
		Private WithEvents _samplesTreeView As System.Windows.Forms.TreeView
		Private _htmlPanel As HtmlPanel
		Private _iterations As System.Windows.Forms.NumericUpDown
		Private label1 As System.Windows.Forms.Label
		Private WithEvents _clearLink As System.Windows.Forms.LinkLabel

	End Class
End Namespace

