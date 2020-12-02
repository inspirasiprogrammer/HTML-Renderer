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
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports TheArtOfDev.HtmlRenderer.Demo.Common

Namespace TheArtOfDev.HtmlRenderer.Demo.WinForms
	Partial Public Class SampleForm
		Inherits Form

		Private ReadOnly _background As Bitmap

		Public Sub New()
			InitializeComponent()

			Icon = DemoForm.GetIcon()

			_htmlLabel.Text = DemoUtils.SampleHtmlLabelText
			_htmlPanel.Text = DemoUtils.SampleHtmlPanelText

			_background = HtmlRenderingHelper.CreateImageForTransparentBackground()
		End Sub

		Private Sub OnHtmlLabelClick(ByVal sender As Object, ByVal e As EventArgs) Handles _htmlLabel.Click
			_pGrid.SelectedObject = _htmlLabel
		End Sub

		Private Sub OnHtmlPanelClick(ByVal sender As Object, ByVal e As EventArgs) Handles _htmlPanel.Click
			_pGrid.SelectedObject = _htmlPanel
		End Sub

		Private Sub OnHtmlLabelHostingPanelPaint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles _htmlLabelHostingPanel.Paint
			Using b = New TextureBrush(_background, WrapMode.Tile)
				e.Graphics.FillRectangle(b, _htmlLabelHostingPanel.ClientRectangle)
			End Using
		End Sub

		Private Sub OnButtonClick(ByVal sender As Object, ByVal e As EventArgs) Handles _changeTooltipButton.Click
			_htmlToolTip.SetToolTip(_changeTooltipButton, _htmlLabel.Text)
		End Sub

		Private Sub OnPropertyValueChanged(ByVal s As Object, ByVal e As PropertyValueChangedEventArgs) Handles _pGrid.PropertyValueChanged
			DirectCast(_pGrid.SelectedObject, Control).Refresh()
			Refresh()
		End Sub
	End Class
End Namespace