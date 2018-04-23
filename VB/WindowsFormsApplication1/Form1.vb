Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports System.IO
Imports DevExpress.XtraReports.UI
Namespace WindowsFormsApplication1
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim myItems As New List(Of MyObj)()
			Dim ofd As New OpenFileDialog()
			ofd.Multiselect = True
			ofd.Filter = "VCard|*.vcf|All|*.*"
			If ofd.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
				For Each s As String In ofd.FileNames
					myItems.Add(New MyObj() With {.Path = s, .Vcard = File.ReadAllBytes(s)})
				Next s
				Dim report As New XtraReport1()
				report.DataSource = myItems
				report.ShowPreviewDialog()
			End If
		End Sub
	End Class
	Public Class MyObj
		Private path_Renamed As String
		Public Property Path() As String
			Get
				Return path_Renamed
			End Get
			Set(ByVal value As String)
				path_Renamed = value
			End Set
		End Property
		Private vcard_Renamed() As Byte
		Public Property Vcard() As Byte()
			Get
				Return vcard_Renamed
			End Get
			Set(ByVal value As Byte())
				vcard_Renamed = value
			End Set
		End Property

	End Class
End Namespace
