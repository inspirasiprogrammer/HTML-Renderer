' "Therefore those skilled at the unorthodox
' are infinite as heaven and earth,
' inexhaustible as the great rivers.
' When they come to an end,
' they begin again,
' like the days and months;
' they die and are reborn,
' like the four seasons."
' 
' - Sun Tsu,
' "The Art of War"

Imports System
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports TheArtOfDev.HtmlRenderer.Core.Entities
Imports TheArtOfDev.HtmlRenderer.Demo.Common
Imports Timer = System.Threading.Timer

Namespace TheArtOfDev.HtmlRenderer.Demo.WinForms
	Partial Public Class MainControl
		Inherits UserControl

		#Region "Fields and Consts"

		''' <summary>
		''' the name of the tree node root for all performance samples
		''' </summary>
		Private Const PerformanceSamplesTreeNodeName As String = "Performance Samples"

		''' <summary>
		''' timer to update the rendered html when html in editor changes with delay
		''' </summary>
		Private ReadOnly _updateHtmlTimer As Timer

		''' <summary>
		''' used ignore html editor updates when updating separately
		''' </summary>
		Private _updateLock As Boolean

		''' <summary>
		''' In IE view if to show original html or the html generated from the html control
		''' </summary>
		Private _useGeneratedHtml As Boolean

		#End Region


		Public Sub New()
			InitializeComponent()

			AddHandler _htmlPanel.RenderError, AddressOf OnRenderError
			AddHandler _htmlPanel.LinkClicked, AddressOf OnLinkClicked
			AddHandler _htmlPanel.StylesheetLoad, AddressOf DemoUtils.OnStylesheetLoad
			AddHandler _htmlPanel.ImageLoad, AddressOf HtmlRenderingHelper.OnImageLoad
			AddHandler _htmlToolTip.ImageLoad, AddressOf HtmlRenderingHelper.OnImageLoad
			AddHandler _htmlPanel.LoadComplete, Sub(sender, args) _htmlPanel.ScrollToElement("C4")

			_htmlToolTip.SetToolTip(_htmlPanel, Resources.Tooltip)

			_htmlEditor.Font = New Font(FontFamily.GenericMonospace, 10)

			LoadSamples()

			_updateHtmlTimer = New Timer(AddressOf OnUpdateHtmlTimerTick)
		End Sub

		''' <summary>
		''' used ignore html editor updates when updating separately
		''' </summary>
		Public Property UpdateLock() As Boolean
			Get
				Return _updateLock
			End Get
			Set(ByVal value As Boolean)
				_updateLock = value
			End Set
		End Property

		''' <summary>
		''' In IE view if to show original html or the html generated from the html control
		''' </summary>
		Public Property UseGeneratedHtml() As Boolean
			Get
				Return _useGeneratedHtml
			End Get
			Set(ByVal value As Boolean)
				_useGeneratedHtml = value
			End Set
		End Property

		''' <summary>
		''' Show\Hide the web browser viewer.
		''' </summary>
		Public Sub ShowWebBrowserView(ByVal show As Boolean)
			_webBrowser.Visible = show
			_splitter.Visible = show

			If _webBrowser.Visible Then
				_webBrowser.Width = _splitContainer2.Panel2.Width \ 2
				UpdateWebBrowserHtml()
			End If
		End Sub

		''' <summary>
		''' Update the html shown in the web browser
		''' </summary>
		Public Sub UpdateWebBrowserHtml()
			If _webBrowser.Visible Then
				_webBrowser.DocumentText = If(_useGeneratedHtml, _htmlPanel.GetHtml(), GetFixedHtml())
			End If
		End Sub

		Public Function GetHtml() As String
			Return If(_useGeneratedHtml, _htmlPanel.GetHtml(), _htmlEditor.Text)
		End Function

		Public Sub SetHtml(ByVal html As String)
			_htmlPanel.Text = html
		End Sub


		#Region "Private methods"

		''' <summary>
		''' Loads the tree of document samples
		''' </summary>
		Private Sub LoadSamples()
			Dim showcaseRoot = New TreeNode("HTML Renderer")
			_samplesTreeView.Nodes.Add(showcaseRoot)

			For Each sample In SamplesLoader.ShowcaseSamples
				AddTreeNode(showcaseRoot, sample)
			Next sample

			Dim testSamplesRoot = New TreeNode("Test Samples")
			_samplesTreeView.Nodes.Add(testSamplesRoot)

			For Each sample In SamplesLoader.TestSamples
				AddTreeNode(testSamplesRoot, sample)
			Next sample

			If SamplesLoader.PerformanceSamples.Count > 0 Then
				Dim perfTestSamplesRoot = New TreeNode(PerformanceSamplesTreeNodeName)
				_samplesTreeView.Nodes.Add(perfTestSamplesRoot)

				For Each sample In SamplesLoader.PerformanceSamples
					AddTreeNode(perfTestSamplesRoot, sample)
				Next sample
			End If

			showcaseRoot.Expand()

			If showcaseRoot.Nodes.Count > 0 Then
				_samplesTreeView.SelectedNode = showcaseRoot.Nodes(0)
			End If
		End Sub

		''' <summary>
		''' Add an html sample to the tree and to all samples collection
		''' </summary>
		Private Sub AddTreeNode(ByVal root As TreeNode, ByVal sample As HtmlSample)
			Dim node = New TreeNode(sample.Name)
			node.Tag = New HtmlSample(sample.Name, sample.FullName, sample.Html)
			root.Nodes.Add(node)
		End Sub

		''' <summary>
		''' On tree view node click load the html to the html panel and html editor.
		''' </summary>
		Private Sub OnSamplesTreeViewAfterSelect(ByVal sender As Object, ByVal e As TreeViewEventArgs) Handles _samplesTreeView.AfterSelect
			Dim sample = TryCast(e.Node.Tag, HtmlSample)
			If sample IsNot Nothing Then
				_updateLock = True

				If Not HtmlRenderingHelper.IsRunningOnMono() AndAlso e.Node.Parent.Text <> PerformanceSamplesTreeNodeName Then
					SetColoredText(sample.Html)
				Else
					_htmlEditor.Text = sample.Html
				End If

				Application.UseWaitCursor = True

				Try
					_htmlPanel.AvoidImagesLateLoading = Not sample.FullName.Contains("Many images")

					_htmlPanel.Text = sample.Html
				Catch ex As Exception
					MessageBox.Show(ex.ToString(), "Failed to render HTML")
				End Try

				Application.UseWaitCursor = False
				_updateLock = False

				UpdateWebBrowserHtml()
			End If
		End Sub

		''' <summary>
		''' On text change in the html editor update 
		''' </summary>
		Private Sub OnHtmlEditorTextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _htmlEditor.TextChanged
			If Not _updateLock Then
				_updateHtmlTimer.Change(1000, Integer.MaxValue)
			End If
		End Sub

		''' <summary>
		''' Update the html renderer with text from html editor.
		''' </summary>
		Private Sub OnUpdateHtmlTimerTick(ByVal state As Object)
			BeginInvoke(New MethodInvoker(Sub()
				_updateLock = True

				Try
					_htmlPanel.Text = _htmlEditor.Text
				Catch ex As Exception
					MessageBox.Show(ex.ToString(), "Failed to render HTML")
				End Try

				'SyntaxHilight.AddColoredText(_htmlEditor.Text, _htmlEditor);

				UpdateWebBrowserHtml()

				_updateLock = False
			End Sub))
		End Sub

		''' <summary>
		''' Fix the raw html by replacing bridge object properties calls with path to file with the data returned from the property.
		''' </summary>
		''' <returns>fixed html</returns>
		Private Function GetFixedHtml() As String
			Dim html = _htmlEditor.Text

			html = Regex.Replace(html, "src=\""(\w.*?)\""", Function(match)
				Dim img = HtmlRenderingHelper.TryLoadResourceImage(match.Groups(1).Value)
				If img IsNot Nothing Then
					Dim tmpFile = Path.GetTempFileName()
					img.Save(tmpFile, ImageFormat.Jpeg)
					Return String.Format("src=""{0}""", tmpFile)
				End If
				Return match.Value
			End Function, RegexOptions.IgnoreCase)

			html = Regex.Replace(html, "href=\""(\w.*?)\""", Function(match)
				Dim stylesheet = DemoUtils.GetStylesheet(match.Groups(1).Value)
				If stylesheet IsNot Nothing Then
					Dim tmpFile = Path.GetTempFileName()
					File.WriteAllText(tmpFile, stylesheet)
					Return String.Format("href=""{0}""", tmpFile)
				End If
				Return match.Value
			End Function, RegexOptions.IgnoreCase)

			Return html
		End Function

		''' <summary>
		''' Reload the html shown in the html editor by running coloring again.
		''' </summary>
		Private Sub OnReloadColorsLinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) Handles _reloadColorsLink.LinkClicked
			SetColoredText(_htmlEditor.Text)
		End Sub

		''' <summary>
		''' Show error raised from html renderer.
		''' </summary>
		Private Shared Sub OnRenderError(ByVal sender As Object, ByVal e As HtmlRenderErrorEventArgs)
			MessageBox.Show(e.Message & (IIf(e.Exception IsNot Nothing, e.Exception, Nothing)), "Error in Html Renderer", MessageBoxButtons.OK)
		End Sub

		''' <summary>
		''' On specific link click handle it here.
		''' </summary>
		Private Shared Sub OnLinkClicked(ByVal sender As Object, ByVal e As HtmlLinkClickedEventArgs)
			If e.Link = "SayHello" Then
				MessageBox.Show("Hello you!")
				e.Handled = True
			ElseIf e.Link = "ShowSampleForm" Then
				Using f = New SampleForm()
					f.ShowDialog()
					e.Handled = True
				End Using
			End If
		End Sub

		''' <summary>
		''' Set html syntax color text on the RTF html editor.
		''' </summary>
		Private Sub SetColoredText(ByVal text As String)
			Dim selectionStart = _htmlEditor.SelectionStart
			_htmlEditor.Clear()
			_htmlEditor.Rtf = HtmlSyntaxHighlighter.Process(text)
			_htmlEditor.SelectionStart = selectionStart
		End Sub

		#End Region
	End Class
End Namespace