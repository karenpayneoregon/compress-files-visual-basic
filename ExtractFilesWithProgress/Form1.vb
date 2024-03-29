﻿Imports System.IO
Imports System.IO.Compression
Imports ExtractFilesWithProgress.Classes
Imports ExtractFilesWithProgress.Delegates
Imports ExtractFilesWithProgress.LanguageExtensions

Public Class Form1
    ''' <summary>
    ''' Event for passing information from a Task responsible
    ''' for extracting files to the user interface which is
    ''' in a different context.
    ''' </summary>
    Public Event ZipEventHandler As ZipEventHandler

    Private _extractedCount As Integer = 0
    ''' <summary>
    ''' Code to select zip file to work with
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub SelectZipFileButton_Click(sender As Object, e As EventArgs) _
        Handles SelectZipFileButton.Click

        If SelectZipFileDialog.ShowDialog() = DialogResult.OK Then
            CompressionFileNameTextBox.Text = SelectZipFileDialog.FileName
        End If

    End Sub
    ''' <summary>
    ''' Code to select folder to extract zip file 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub SelectFolderButton_Click(sender As Object, e As EventArgs) _
        Handles SelectFolderButton.Click

        If Not String.IsNullOrWhiteSpace(CompressionFileNameTextBox.Text) Then
            If ExtractFolderBrowser.ShowDialog(Me) = DialogResult.OK Then
                ExtractionFolderTextBox.Text = ExtractFolderBrowser.SelectedFolder
            End If
        Else
            MessageBox.Show("Select a .zip file first")
        End If

    End Sub

    Private Async Sub ExtractButton_Click(sender As Object, e As EventArgs) _
        Handles ExtractButton.Click

        If Not String.IsNullOrWhiteSpace(CompressionFileNameTextBox.Text) AndAlso
           Not String.IsNullOrWhiteSpace(ExtractionFolderTextBox.Text) Then

            _extractedCount = 0
            ProgressBar1.Value = 0

            ExtractButton.Enabled = False
            ListBox1.Items.Clear()

            Await Task.Delay(100)

            Try

                If UseProgressBarCheckBox.Checked Then

                    ProgressBar1.Visible = True

                    Await ExtractAllAsync(
                        CompressionFileNameTextBox.Text,
                        ExtractionFolderTextBox.Text,
                        ProgressBar1)

                Else

                    ProgressBar1.Visible = False

                    Await ExtractAllAsync(
                        CompressionFileNameTextBox.Text,
                        ExtractionFolderTextBox.Text)

                End If

            Finally
                ExtractButton.Enabled = True
            End Try

        End If
    End Sub
    ''' <summary>
    ''' Extract files from a zip file
    ''' </summary>
    ''' <param name="zipFileName">compressed file with path</param>
    ''' <param name="extractPath">folder to extract file too</param>
    ''' <param name="progressBar">optional ProgressBar</param>
    ''' <returns>Nothing, Task is used to be awaitable</returns>
    Private Async Function ExtractAllAsync(
        zipFileName As String,
        extractPath As String,
        Optional progressBar As ProgressBar = Nothing) As Task

        Try

            Dim extractCount As Integer = 0
            Dim skipCount As Integer = 0
            Dim errorCount As Integer = 0
            Dim progressValue As Integer = 0

            Using zipZrchive As ZipArchive = ZipFile.OpenRead(zipFileName)

                '
                ' reset progressbar is used
                '
                If progressBar IsNot Nothing Then
                    progressBar.Minimum = 0
                    progressBar.Maximum = zipZrchive.Entries.Count
                End If

                Dim extracted As Boolean = False

                Await Task.Run(
                    Sub()

                        Dim count As Integer = zipZrchive.Entries.Count
                        Dim currentFileName As String = ""
                        Dim currentFileLength As Long = 0

                        '
                        ' Iterate files in compressed file
                        '
                        For index As Integer = 0 To count - 1
                            Try

                                Dim entry As ZipArchiveEntry = zipZrchive.Entries(index)
                                currentFileName = entry.FullName

                                '
                                ' Bypass existing file, optional logic can be used
                                ' to overwrite an existing file
                                '
                                If Not File.Exists(Path.Combine(extractPath, entry.FullName)) Then
                                    entry.ExtractToFile(Path.Combine(extractPath, entry.FullName))
                                    currentFileLength = entry.Length
                                    extractCount += 1
                                    extracted = True
                                Else
                                    extracted = False
                                End If

                            Catch ioex As IOException
                                '
                                ' By removing the logic above for File.Exists an exception
                                ' would be thrown. To get around this the file must first
                                ' be removed
                                '
                                If ioex.Message.EndsWith("already exists.") Then
                                    skipCount += 1
                                Else
                                    errorCount += 1
                                End If
                            Catch ex As Exception
                                '
                                ' Unknown error
                                ' Should not be ignored, for a production app
                                ' consider writing to a log file
                                '
                                errorCount += 1
                            End Try


                            progressValue += 1

                            If progressBar IsNot Nothing Then
                                Invoke(Sub() progressBar.Value += 1)
                            End If

                            Task.Delay(100).Wait() ' REMOVE FOR PRODUCTION

                            '
                            ' Pass current file name without path,
                            ' file size of current file,
                            ' percent done and if the file was extracted
                            '
                            ' Room here for customizing what is passed
                            ' by modifying ZipArgs class.
                            '
                            RaiseEvent ZipEventHandler(
                                           Me,
                                           New ZipArgs(
                                               currentFileName,
                                               currentFileLength,
                                               progressValue.PercentageOf(count),
                                               extracted))

                        Next

                    End Sub)
            End Using

        Catch ex As Exception

            MessageBox.Show(
                ex.Message,
                "Error Opening Zip File",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        End Try

    End Function
    ''' <summary>
    ''' Receive information from extraction process. Note use of Invoke
    ''' to prevent cross thread violations as the async operations are
    ''' performed in a different thread then the calling code in this form.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Async Sub Form1_TheFolderEventHandler(sender As Object, e As ZipArgs) Handles Me.ZipEventHandler

        If e.Extracted Then
            _extractedCount += 1
            Invoke(Sub() ListBox1.Items.Add($"{e.FileName}, {e.FileLength.ToEnglishKb}"))
        End If

        If e.PercentDone = 100 Then
            Await Task.Delay(800) ' Ensure progressbar has time to finishing painting
            MessageBox.Show($"Extracted {_extractedCount} files.")
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SelectZipFileDialog.InitialDirectory = "C:\"
        CompressionFileNameTextBox.Text = ""
        ExtractionFolderTextBox.Text = ""

        If Environment.UserName = "Karens" Then
            SelectZipFileDialog.InitialDirectory = "C:\Data"
            CompressionFileNameTextBox.Text = "C:\data\data.zip"
            ExtractionFolderTextBox.Text = "C:\data\testextract"
        End If

    End Sub
    ''' <summary>
    ''' Used to delete all files from target extract folder
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub PurgeTargetFolderButton_Click(sender As Object, e As EventArgs) _
        Handles PurgeTargetFolderButton.Click

        If Not String.IsNullOrWhiteSpace(ExtractionFolderTextBox.Text) Then

            Dim zipFiles = Directory.GetFiles(ExtractionFolderTextBox.Text)

            If zipFiles.Length > 0 Then
                If My.Dialogs.Question($"Remove {zipFiles.Length}") Then
                    Try
                        zipFiles.ToList().ForEach(Sub(currentFile)
                                                      File.Delete(currentFile)
                                                  End Sub)
                    Catch ex As Exception
                        MessageBox.Show("Failed to remove files")
                    End Try
                End If
            Else
                MessageBox.Show("No files found")
            End If
        Else
            MessageBox.Show("Please select a folder first")
        End If

    End Sub


End Class