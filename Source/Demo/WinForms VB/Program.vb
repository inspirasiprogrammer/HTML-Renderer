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
Imports System.Globalization
Imports System.IO
Imports System.Reflection
Imports System.Windows.Forms

Namespace TheArtOfDev.HtmlRenderer.Demo.WinForms
	Friend Module Program
		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		<STAThread>
		Public Sub Main()
			AddHandler AppDomain.CurrentDomain.AssemblyResolve, AddressOf OnResolveAssembly

			Application.EnableVisualStyles()
			Application.SetCompatibleTextRenderingDefault(False)
			Application.Run(New DemoForm())

			' Application.Run(new PerfForm());
			'  PerfForm.Run();
		End Sub

		Private Function OnResolveAssembly(ByVal sender As Object, ByVal args As ResolveEventArgs) As System.Reflection.Assembly
			Dim executingAssembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
			Dim assemblyName As New AssemblyName(args.Name)

			Dim path As String = assemblyName.Name & ".dll"
			If assemblyName.CultureInfo.Equals(CultureInfo.InvariantCulture) = False Then
				path = String.Format("{0}\{1}", assemblyName.CultureInfo, path)
			End If

			Using stream As Stream = executingAssembly.GetManifestResourceStream(path)
				If stream IsNot Nothing Then
					Dim assemblyRawBytes(stream.Length - 1) As Byte
					stream.Read(assemblyRawBytes, 0, assemblyRawBytes.Length)
					Return System.Reflection.Assembly.Load(assemblyRawBytes)
				End If
				Return Nothing
			End Using
		End Function
	End Module
End Namespace