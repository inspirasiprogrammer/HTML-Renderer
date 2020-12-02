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
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.Reflection
Imports System.Windows.Forms
Imports TheArtOfDev.HtmlRenderer.Core
Imports TheArtOfDev.HtmlRenderer.Core.Entities
Imports TheArtOfDev.HtmlRenderer.Demo.Common
Imports TheArtOfDev.HtmlRenderer.WinForms

Namespace TheArtOfDev.HtmlRenderer.Demo.WinForms
	Partial Public Class GenerateImageForm
		Inherits Form

		Private ReadOnly _html As String
		Private ReadOnly _background As Bitmap

		Public Sub New(ByVal html As String)
			_html = html
			InitializeComponent()

			Icon = DemoForm.GetIcon()

			_background = HtmlRenderingHelper.CreateImageForTransparentBackground()

			For Each color In GetColors()
				If color <> System.Drawing.Color.Transparent Then
					_backgroundColorTSB.Items.Add(color.Name)
				End If
			Next color
			_backgroundColorTSB.SelectedItem = Color.White.Name

			For Each hint In System.Enum.GetNames(GetType(TextRenderingHint))
				_textRenderingHintTSCB.Items.Add(hint)
			Next hint
			_textRenderingHintTSCB.SelectedItem = TextRenderingHint.AntiAlias.ToString()

			_useGdiPlusTSB.Enabled = Not HtmlRenderingHelper.IsRunningOnMono()
			_backgroundColorTSB.Enabled = Not HtmlRenderingHelper.IsRunningOnMono()
		End Sub

		Private Sub OnSaveToFile_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _saveToFileTSB.Click
			Using saveDialog = New SaveFileDialog()
				saveDialog.Filter = "Images|*.png;*.bmp;*.jpg"
				saveDialog.FileName = "image"
				saveDialog.DefaultExt = ".png"

'INSTANT VB NOTE: The variable dialogResult was renamed since Visual Basic does not handle local variables named the same as class members well:
				Dim dialogResult_Renamed = saveDialog.ShowDialog(Me)
				If dialogResult_Renamed = System.Windows.Forms.DialogResult.OK Then
					_pictureBox.Image.Save(saveDialog.FileName)
				End If
			End Using
		End Sub

		Private Sub OnUseGdiPlus_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _useGdiPlusTSB.Click
			_useGdiPlusTSB.Checked = Not _useGdiPlusTSB.Checked
			_textRenderingHintTSCB.Visible = _useGdiPlusTSB.Checked
			_backgroundColorTSB.Visible = Not _useGdiPlusTSB.Checked
			_toolStripLabel.Text = If(_useGdiPlusTSB.Checked, "Text Rendering Hint:", "Background:")
			GenerateImage()
		End Sub

		Private Sub OnBackgroundColor_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _backgroundColorTSB.SelectedIndexChanged
			GenerateImage()
		End Sub

		Private Sub _textRenderingHintTSCB_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _textRenderingHintTSCB.SelectedIndexChanged
			GenerateImage()
		End Sub

		Private Sub OnGenerateImage_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _generateImageTSB.Click
			GenerateImage()
		End Sub

		Private Sub GenerateImage()
			If _backgroundColorTSB.SelectedItem IsNot Nothing AndAlso _textRenderingHintTSCB.SelectedItem IsNot Nothing Then
				Dim backgroundColor = Color.FromName(_backgroundColorTSB.SelectedItem.ToString())
				Dim textRenderingHint As TextRenderingHint = DirectCast(System.Enum.Parse(GetType(TextRenderingHint), _textRenderingHintTSCB.SelectedItem.ToString()), TextRenderingHint)

				Dim img As Image
				If _useGdiPlusTSB.Checked OrElse HtmlRenderingHelper.IsRunningOnMono() Then
					img = HtmlRender.RenderToImageGdiPlus(_html, _pictureBox.ClientSize, textRenderingHint, Nothing, AddressOf DemoUtils.OnStylesheetLoad, AddressOf HtmlRenderingHelper.OnImageLoad)
				Else
					Dim stylesheetLoad As EventHandler(Of HtmlStylesheetLoadEventArgs) = AddressOf DemoUtils.OnStylesheetLoad
					Dim imageLoad As EventHandler(Of HtmlImageLoadEventArgs) = AddressOf HtmlRenderingHelper.OnImageLoad
					Dim objects = New Object() { _html, _pictureBox.ClientSize, backgroundColor, Nothing, stylesheetLoad, imageLoad }

					Dim types = { GetType(String), GetType(Size), GetType(Color), GetType(CssData), GetType(EventHandler(Of HtmlStylesheetLoadEventArgs)), GetType(EventHandler(Of HtmlImageLoadEventArgs)) }
					Dim m = GetType(HtmlRender).GetMethod("RenderToImage", BindingFlags.InvokeMethod Or BindingFlags.Static Or BindingFlags.Public, Nothing, types, Nothing)
					img = CType(m.Invoke(Nothing, objects), Image)
				End If
				_pictureBox.Image = img
			End If
		End Sub

		Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
			MyBase.OnPaintBackground(e)
			Using b = New TextureBrush(_background, WrapMode.Tile)
				e.Graphics.FillRectangle(b, ClientRectangle)
			End Using
		End Sub

		Private Shared Function GetColors() As List(Of Color)
			Const attributes As MethodAttributes = MethodAttributes.Static Or MethodAttributes.Public
			Dim properties() As PropertyInfo = GetType(Color).GetProperties()
			Dim list As New List(Of Color)()
			For i As Integer = 0 To properties.Length - 1
				Dim info As PropertyInfo = properties(i)
				If info.PropertyType Is GetType(Color) Then
					Dim getMethod As MethodInfo = info.GetGetMethod()
					If (getMethod IsNot Nothing) AndAlso ((getMethod.Attributes And attributes) = attributes) Then
						list.Add(DirectCast(info.GetValue(Nothing, Nothing), Color))
					End If
				End If
			Next i
			Return list
		End Function
	End Class
End Namespace