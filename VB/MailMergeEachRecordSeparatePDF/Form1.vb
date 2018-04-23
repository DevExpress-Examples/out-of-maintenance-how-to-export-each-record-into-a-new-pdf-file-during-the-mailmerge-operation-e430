Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraRichEdit.API.Native
Imports DevExpress.XtraRichEdit
Imports System.IO

Namespace MailMergeEachRecordSeparatePDF
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()

			Dim datasource = DataHelper.GenerateEmployeeList()
			dataNavigator1.DataSource = datasource
			richEditControl1.Options.MailMerge.DataSource = datasource
			richEditControl1.Options.MailMerge.ViewMergedData = True
			richEditControl1.LoadDocument("MailMergeSimple.rtf")
		End Sub

		Private Sub barButtonItem1_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles barButtonItem1.ItemClick
			Dim count As Integer = (CType(richEditControl1.Options.MailMerge.DataSource, List(Of Employee))).Count

			Dim saveFileDialog1 As New SaveFileDialog()
			saveFileDialog1.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*"
			saveFileDialog1.FilterIndex = 1
			saveFileDialog1.RestoreDirectory = True

			If saveFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
				Using docServer As New RichEditDocumentServer()
					Dim options As MailMergeOptions = richEditControl1.CreateMailMergeOptions()

					For i As Integer = 0 To count - 1
						Dim filename As String = String.Format("{0}{1}.pdf", saveFileDialog1.FileName, (i + 1).ToString())
						options.LastRecordIndex = i
						options.FirstRecordIndex = options.LastRecordIndex

						Using fs As New FileStream(filename, FileMode.Create, System.IO.FileAccess.Write)
							richEditControl1.MailMerge(options, docServer.Document)
							docServer.ExportToPdf(fs)
						End Using
					Next i
				End Using
			End If
		End Sub
	End Class
End Namespace
