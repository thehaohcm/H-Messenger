Imports System.Windows.Forms

Public Class temp
    Dim user, pass, host, webs, nick, strc1, strc2 As String
    Dim AClient, BClient As New Net.WebClient
    Public Athread, Bthread, Cthread As Threading.Thread

    Public Sub xoa()
        AClient.UploadString(host, "")
        Cthread.abort()
    End Sub

    Private Sub temp_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'Athread.Abort()
        'Bthread.Abort()
        Bthread.Abort()
        'Form1.AThread.Abort()
    End Sub

    Private Sub temp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False

        user = My.Resources.username
        pass = My.Resources.pass
        host = My.Resources.host
        webs = My.Resources.web
        nick = My.Settings.nick

        AClient.Credentials = New Net.NetworkCredential(user, pass)
        'Athread = New Threading.Thread(AddressOf downstringhost)
        'Athread.Start()

        'Cthread = New Threading.Thread(AddressOf xoa)
        'Cthread.Start()

        Bthread = New Threading.Thread(AddressOf upstringhost)
        Bthread.Start()
    End Sub

    'Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
    '    Try
    '        If TextBox1.Text <> Nothing And TextBox1.Text <> strc1 Then
    '            AClient.UploadString(host, TextBox1.Text)
    '            strc1 = TextBox1.Text
    '            TextBox1.Text = Nothing
    '        End If
    '    Catch ex As Exception
    '    End Try
    'End Sub

    Public Sub upstringhost()
        Do
            Try
                Threading.Thread.Sleep(1)
                If TextBox1.Text <> Nothing And TextBox1.Text <> strc1 Then
                    AClient.UploadString(host, TextBox1.Text)
                    strc1 = TextBox1.Text
                    TextBox1.Text = Nothing
                End If
                'Bthread.Abort()
            Catch ex As Exception
            End Try
        Loop
    End Sub

    'Private Sub downstringhost()
    '    Do
    '        Try
    '            Threading.Thread.Sleep(3000)
    '            Dim str As String = BClient.DownloadString(webs)
    '            If strc2 <> str Then
    '                Form1.ListBox1.Items.Add(str)
    '                Form1.ListBox1.TopIndex = Form1.ListBox1.Items.Count - 1
    '                strc2 = str
    '            End If
    '        Catch ex As Exception

    '        End Try
    '    Loop
    'End Sub

    'Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
    '    Try
    '        Dim str As String = BClient.DownloadString(webs)
    '        If strc2 <> str Then
    '            Form1.ListBox1.Items.Add(str)
    '            Form1.ListBox1.TopIndex = Form1.ListBox1.Items.Count - 1
    '            strc2 = str
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub
End Class
