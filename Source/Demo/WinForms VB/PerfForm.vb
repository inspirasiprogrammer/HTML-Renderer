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
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Reflection
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms
Imports TheArtOfDev.HtmlRenderer.WinForms

Namespace TheArtOfDev.HtmlRenderer.Demo.WinForms
	Partial Public Class PerfForm
		Inherits Form

		#Region "Fields and Consts"

		''' <summary>
		''' the html samples to show in the demo
		''' </summary>
		Private ReadOnly _samples As New Dictionary(Of String, String)()

		''' <summary>
		''' the HTML samples to run on
		''' </summary>
		Private Shared ReadOnly _perfTestSamples As New List(Of String)()

		Private Const Iterations As Integer = 3

		#End Region


		''' <summary>
		''' Init.
		''' </summary>
		Public Sub New()
			InitializeComponent()

			Icon = DemoForm.GetIcon()

			StartPosition = FormStartPosition.CenterScreen
			Size = New Size(1200, 800)

			LoadSamples()
		End Sub


		''' <summary>
		''' Used to execute performance test run for memory profiler so the form is not loaded, 
		''' only html container is working.
		''' </summary>
		Public Shared Sub Run(ByVal layout As Boolean, ByVal paint As Boolean)
			Try
				LoadRunSamples()

				Dim htmlContainer = New HtmlContainer()
				htmlContainer.MaxSize = New SizeF(800, 0)

				GC.Collect()
				Thread.Sleep(3000)

				Using img = New Bitmap(1, 1)
				Using g = Graphics.FromImage(img)
					For i As Integer = 0 To Iterations - 1
						For Each html In _perfTestSamples
							htmlContainer.SetHtml(html)

							If layout Then
								htmlContainer.PerformLayout(g)
							End If

							If paint Then
								htmlContainer.PerformPaint(g)
							End If
						Next html
					Next i
				End Using
				End Using
			Catch ex As Exception
				MessageBox.Show(ex.ToString(), "Error")
			End Try
		End Sub


		#Region "Private methods"

		''' <summary>
		''' Loads the tree of document samples
		''' </summary>
		Private Shared Sub LoadRunSamples()
			Dim names = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceNames()
			Array.Sort(names)
'INSTANT VB NOTE: The variable name was renamed since Visual Basic does not handle local variables named the same as class members well:
			For Each name_Renamed As String In names
				Dim extPos As Integer = name_Renamed.LastIndexOf("."c)
				Dim ext As String = name_Renamed.Substring(If(extPos >= 0, extPos, 0))

				If ".htm".IndexOf(ext, StringComparison.Ordinal) >= 0 Then
					Dim resourceStream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(name_Renamed)
					If resourceStream IsNot Nothing Then
						Using sreader = New StreamReader(resourceStream, Encoding.Default)
							Dim html = sreader.ReadToEnd()
							_perfTestSamples.Add(html)
						End Using
					End If
				End If
			Next name_Renamed
		End Sub

		''' <summary>
		''' Loads the tree of document samples
		''' </summary>
		Private Sub LoadSamples()
			Dim root = New TreeNode("HTML Renderer")
			_samplesTreeView.Nodes.Add(root)

			Dim names = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceNames()
			Array.Sort(names)
'INSTANT VB NOTE: The variable name was renamed since Visual Basic does not handle local variables named the same as class members well:
			For Each name_Renamed As String In names
				Dim extPos As Integer = name_Renamed.LastIndexOf("."c)
				Dim namePos As Integer = If(extPos > 0 AndAlso name_Renamed.Length > 1, name_Renamed.LastIndexOf("."c, extPos - 1), 0)
				Dim ext As String = name_Renamed.Substring(If(extPos >= 0, extPos, 0))
				Dim shortName As String = If(namePos > 0 AndAlso name_Renamed.Length > 2, name_Renamed.Substring(namePos + 1, name_Renamed.Length - namePos - ext.Length - 1), name_Renamed)

				If ".htm".IndexOf(ext, StringComparison.Ordinal) >= 0 Then
					If name_Renamed.IndexOf("PerfSamples", StringComparison.OrdinalIgnoreCase) > -1 Then
						Dim resourceStream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(name_Renamed)
						If resourceStream IsNot Nothing Then
							Using sreader = New StreamReader(resourceStream, Encoding.Default)
								_samples(name_Renamed) = sreader.ReadToEnd()
							End Using

							Dim nameWithSzie As String = String.Format("{0} ({1:N0} KB)", shortName, _samples(name_Renamed).Length * 2 \ 1024)
							Dim node = New TreeNode(nameWithSzie)
							root.Nodes.Add(node)
							node.Tag = name_Renamed
						End If
					End If
				End If
			Next name_Renamed

			root.Expand()
		End Sub

		''' <summary>
		''' On tree view node click load the html to the html panel and html editor.
		''' </summary>
		Private Sub OnSamplesTreeViewAfterSelect(ByVal sender As Object, ByVal e As TreeViewEventArgs) Handles _samplesTreeView.AfterSelect
'INSTANT VB NOTE: The variable name was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim name_Renamed = TryCast(e.Node.Tag, String)
			If Not String.IsNullOrEmpty(name_Renamed) Then
				_htmlPanel.Text = _samples(name_Renamed)
			End If
		End Sub

		''' <summary>
		''' Clear the html in the renderer
		''' </summary>
		Private Sub OnClearLinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) Handles _clearLink.LinkClicked
			_samplesTreeView.SelectedNode = Nothing
			_htmlPanel.Text = Nothing
			GC.Collect()
		End Sub

		''' <summary>
		''' Execute performance test by setting all sample htmls in a loop.
		''' </summary>
		Private Sub OnRunTestButtonClick(ByVal sender As Object, ByVal e As EventArgs) Handles _runTestButton.Click
			If _samplesTreeView.SelectedNode IsNot Nothing AndAlso _samplesTreeView.SelectedNode.Tag IsNot Nothing Then
				_runTestButton.Text = "Running.."
				_runTestButton.Enabled = False
				Application.DoEvents()

'INSTANT VB NOTE: The variable iterations was renamed since Visual Basic does not handle local variables named the same as class members well:
				Dim iterations_Renamed = CSng(_iterations.Value)
				Dim html = _samples(DirectCast(_samplesTreeView.SelectedNode.Tag, String))

				GC.Collect()

				Dim totalMem As Double = 0
				Dim startMemory As Long = 0
				If Environment.Version.Major >= 4 Then
					GetType(AppDomain).GetProperty("MonitoringIsEnabled").SetValue(Nothing, True, Nothing)
					startMemory = CLng(Math.Truncate(AppDomain.CurrentDomain.GetType().GetProperty("MonitoringTotalAllocatedMemorySize").GetValue(AppDomain.CurrentDomain, Nothing)))
				End If

				Dim sw = Stopwatch.StartNew()

				For i As Integer = 0 To _iterations.Value - 1
					_htmlPanel.Text = html
					Application.DoEvents() ' so paint will be called
				Next i

				sw.Stop()

				If Environment.Version.Major >= 4 Then
					Dim endMemory = CLng(Math.Truncate(AppDomain.CurrentDomain.GetType().GetProperty("MonitoringTotalAllocatedMemorySize").GetValue(AppDomain.CurrentDomain, Nothing)))
					totalMem = (endMemory - startMemory) / 1024F
				End If

				Dim htmlSize As Single = html.Length * 2 / 1024F

				Dim msg = String.Format("1 HTML ({0:N0} KB)" & vbCrLf & "{1} Iterations", htmlSize, _iterations.Value)
				msg &= vbCrLf & vbCrLf
				msg &= String.Format("CPU:" & vbCrLf & "Total: {0} msec" & vbCrLf & "IterationAvg: {1:N2} msec", sw.ElapsedMilliseconds, sw.ElapsedMilliseconds / iterations_Renamed)
				msg &= vbCrLf & vbCrLf
				msg &= String.Format("Memory:" & vbCrLf & "Total: {0:N0} KB" & vbCrLf & "IterationAvg: {1:N0} KB" & vbCrLf & "Overhead: {2:N0}%", totalMem, totalMem / iterations_Renamed, 100 * (totalMem / iterations_Renamed) / htmlSize)

				Clipboard.SetDataObject(msg)
				MessageBox.Show(msg, "Test run results")

				_runTestButton.Text = "Run Tests"
				_runTestButton.Enabled = True
			End If
		End Sub

		#End Region
	End Class
End Namespace