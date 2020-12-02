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

Imports PdfSharp.Drawing
Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.IO
Imports System.Threading
Imports TheArtOfDev.HtmlRenderer.Core.Entities
Imports TheArtOfDev.HtmlRenderer.Demo.Common

Namespace TheArtOfDev.HtmlRenderer.Demo.WinForms
	Friend Module HtmlRenderingHelper
		#Region "Fields/Consts"

		''' <summary>
		''' Cache for resource images
		''' </summary>
		Private ReadOnly _imageCache As New Dictionary(Of String, Image)(StringComparer.OrdinalIgnoreCase)

		#End Region


		''' <summary>
		''' Check if currently running in mono.
		''' </summary>
		Public Function IsRunningOnMono() As Boolean
			Return Type.GetType("Mono.Runtime") IsNot Nothing
		End Function

		''' <summary>
		''' Create image to be used to fill background so it will be clear that what's on top is transparent.
		''' </summary>
		Public Function CreateImageForTransparentBackground() As Bitmap
			Dim image = New Bitmap(10, 10)
			Using g = Graphics.FromImage(image)
				g.Clear(Color.White)
				g.FillRectangle(SystemBrushes.Control, New Rectangle(0, 0, 5, 5))
				g.FillRectangle(SystemBrushes.Control, New Rectangle(5, 5, 5, 5))
			End Using
			Return image
		End Function

		''' <summary>
		''' Get image by resource key.
		''' </summary>
		Public Function TryLoadResourceImage(ByVal src As String) As Image
			Dim image As Image = Nothing
			If Not _imageCache.TryGetValue(src, image) Then
				Dim imageStream = DemoUtils.GetImageStream(src)
				If imageStream IsNot Nothing Then
					image = System.Drawing.Image.FromStream(imageStream)
					_imageCache(src) = image
				End If
			End If
			Return image
		End Function

		''' <summary>
		''' Get image by resource key.
		''' </summary>
		Public Function TryLoadResourceXImage(ByVal src As String) As XImage
			Dim img = TryLoadResourceImage(src)
			Dim xImg As XImage

			If img Is Nothing Then
				Return Nothing
			End If

			Using ms = New MemoryStream()
				img.Save(ms, img.RawFormat)
				xImg = If(img IsNot Nothing, XImage.FromStream(ms), Nothing)
			End Using

			Return xImg
		End Function

		''' <summary>
		''' On image load in renderer set the image by event async.
		''' </summary>
		Public Sub OnImageLoad(ByVal sender As Object, ByVal e As HtmlImageLoadEventArgs)
			ImageLoad(e, False)
		End Sub

		''' <summary>
		''' On image load in renderer set the image by event async.
		''' </summary>
		Public Sub OnImageLoadPdfSharp(ByVal sender As Object, ByVal e As HtmlImageLoadEventArgs)
			ImageLoad(e, True)
		End Sub

		''' <summary>
		''' On image load in renderer set the image by event async.
		''' </summary>
		Public Sub ImageLoad(ByVal e As HtmlImageLoadEventArgs, ByVal pdfSharp As Boolean)
			Dim img = TryLoadResourceImage(e.Src)
			Dim xImg As XImage = Nothing

			If img IsNot Nothing Then
				Using ms = New MemoryStream()
					img.Save(ms, img.RawFormat)
					xImg = If(img IsNot Nothing, XImage.FromStream(ms), Nothing)
				End Using
			End If

			Dim imgObj As Object
			If pdfSharp Then
				imgObj = xImg
			Else
				imgObj = img
			End If

			If Not e.Handled AndAlso e.Attributes IsNot Nothing Then
				If e.Attributes.ContainsKey("byevent") Then
					Dim delay As Integer = Nothing
					If Int32.TryParse(e.Attributes("byevent"), delay) Then
						e.Handled = True
						ThreadPool.QueueUserWorkItem(Sub(state)
							Thread.Sleep(delay)
							e.Callback("https://fbcdn-sphotos-a-a.akamaihd.net/hphotos-ak-snc7/c0.44.403.403/p403x403/318890_10151195988833836_1081776452_n.jpg")
						End Sub)
						Return
					Else
						e.Callback("http://sphotos-a.xx.fbcdn.net/hphotos-ash4/c22.0.403.403/p403x403/263440_10152243591765596_773620816_n.jpg")
						Return
					End If
				ElseIf e.Attributes.ContainsKey("byrect") Then
					Dim split = e.Attributes("byrect").Split(","c)
					Dim rect = New Rectangle(Int32.Parse(split(0)), Int32.Parse(split(1)), Int32.Parse(split(2)), Int32.Parse(split(3)))
					e.Callback(If(imgObj, TryLoadResourceImage("htmlicon")), rect.X, rect.Y, rect.Width, rect.Height)
					Return
				End If
			End If

			If img IsNot Nothing Then
				e.Callback(imgObj)
			End If
		End Sub
	End Module
End Namespace