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
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Text
Imports System.IO
Imports System.Windows.Forms
Imports TheArtOfDev.HtmlRenderer.Demo.Common
Imports TheArtOfDev.HtmlRenderer.PdfSharp
Imports TheArtOfDev.HtmlRenderer.WinForms
Imports PdfSharp

Namespace TheArtOfDev.HtmlRenderer.Demo.WinForms
	Partial Public Class DemoForm
		Inherits Form

		#Region "Fields/Consts"

		''' <summary>
		''' the private font used for the demo
		''' </summary>
		Private ReadOnly _privateFont As New PrivateFontCollection()

		#End Region


		''' <summary>
		''' Init.
		''' </summary>
		Public Sub New()
			SamplesLoader.Init(If(HtmlRenderingHelper.IsRunningOnMono(), "Mono", "WinForms"), GetType(HtmlRender).Assembly.GetName().Version.ToString())

			InitializeComponent()

			Icon = GetIcon()
			_openSampleFormTSB.Image = Common.Properties.Resources.form
			_showIEViewTSSB.Image = Common.Properties.Resources.browser
			_openInExternalViewTSB.Image = Common.Properties.Resources.chrome
			_useGeneratedHtmlTSB.Image = Common.Properties.Resources.code
			_generateImageSTB.Image = Common.Properties.Resources.image
			_generatePdfTSB.Image = Common.Properties.Resources.pdf
			_runPerformanceTSB.Image = Common.Properties.Resources.stopwatch

			StartPosition = FormStartPosition.CenterScreen
'INSTANT VB NOTE: The variable size was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim size_Renamed = Screen.GetWorkingArea(Point.Empty)
			Size = New Size(CInt(Math.Truncate(size_Renamed.Width * 0.7)), CInt(Math.Truncate(size_Renamed.Height * 0.8)))

			LoadCustomFonts()

			_showIEViewTSSB.Enabled = Not HtmlRenderingHelper.IsRunningOnMono()
			_generatePdfTSB.Enabled = Not HtmlRenderingHelper.IsRunningOnMono()
		End Sub

		''' <summary>
		''' Load custom fonts to be used by renderer HTMLs
		''' </summary>
		Private Sub LoadCustomFonts()
			' load custom font font into private fonts collection
			Dim file = Path.GetTempFileName()
			System.IO.File.WriteAllBytes(file, Resources.CustomFont)
			_privateFont.AddFontFile(file)

			' add the fonts to renderer
			For Each fontFamily In _privateFont.Families
				HtmlRender.AddFontFamily(fontFamily)
			Next fontFamily
		End Sub

		''' <summary>
		''' Get icon for the demo.
		''' </summary>
		Friend Shared Function GetIcon() As Icon
			Dim stream = GetType(DemoForm).Assembly.GetManifestResourceStream("html.ico")
			Return If(stream IsNot Nothing, New Icon(stream), Nothing)
		End Function

		Private Sub OnOpenSampleForm_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _openSampleFormTSB.Click
			Using f = New SampleForm()
				f.ShowDialog()
			End Using
		End Sub

		''' <summary>
		''' Toggle if to show split view of HtmlPanel and WinForms WebBrowser control.
		''' </summary>
		Private Sub OnShowIEView_ButtonClick(ByVal sender As Object, ByVal e As EventArgs) Handles _showIEViewTSSB.Click
			_showIEViewTSSB.Checked = Not _showIEViewTSSB.Checked
			_mainControl.ShowWebBrowserView(_showIEViewTSSB.Checked)
		End Sub

		''' <summary>
		''' Open the current html is external process - the default user browser.
		''' </summary>
		Private Sub OnOpenInExternalView_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _openInExternalViewTSB.Click
			Dim tmpFile = Path.ChangeExtension(Path.GetTempFileName(), ".htm")
			File.WriteAllText(tmpFile, _mainControl.GetHtml())
			Process.Start(tmpFile)
		End Sub

		''' <summary>
		''' Toggle the use generated html button state.
		''' </summary>
		Private Sub OnUseGeneratedHtml_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _useGeneratedHtmlTSB.Click
			_useGeneratedHtmlTSB.Checked = Not _useGeneratedHtmlTSB.Checked
			_mainControl.UseGeneratedHtml = _useGeneratedHtmlTSB.Checked
			_mainControl.UpdateWebBrowserHtml()
		End Sub

		''' <summary>
		''' Open generate image form for the current html.
		''' </summary>
		Private Sub OnGenerateImage_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _generateImageSTB.Click
			Using f = New GenerateImageForm(_mainControl.GetHtml())
				f.ShowDialog()
			End Using
		End Sub

		''' <summary>
		''' Create PDF using PdfSharp project, save to file and open that file.
		''' </summary>
		Private Sub OnGeneratePdf_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _generatePdfTSB.Click
			Dim config As New PdfGenerateConfig()
			config.PageSize = PageSize.A4
			config.SetMargins(20)

			Dim doc = PdfGenerator.GeneratePdf(_mainControl.GetHtml(), config, Nothing, AddressOf DemoUtils.OnStylesheetLoad, AddressOf HtmlRenderingHelper.OnImageLoadPdfSharp)
			Dim tmpFile = Path.GetTempFileName()
			tmpFile = Path.GetFileNameWithoutExtension(tmpFile) & ".pdf"
			doc.Save(tmpFile)
			Process.Start(tmpFile)
		End Sub

		''' <summary>
		''' Execute performance test by setting all sample HTMLs in a loop.
		''' </summary>
		Private Sub OnRunPerformance_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _runPerformanceTSB.Click
			_mainControl.UpdateLock = True
			_toolStrip.Enabled = False
			Application.DoEvents()

			Dim msg = DemoUtils.RunSamplesPerformanceTest(Sub(html)
				_mainControl.SetHtml(html)
				Application.DoEvents() ' so paint will be called
			End Sub)

			Clipboard.SetDataObject(msg)
			MessageBox.Show(msg, "Test run results")

			_mainControl.UpdateLock = False
			_toolStrip.Enabled = True
		End Sub
	End Class
End Namespace