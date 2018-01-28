Public Class Form1
    Public nick As String
    Public chay As Boolean

    Dim strc, strc1, webs, user, pass, host As String
    Dim AThread, BThread As Threading.Thread 'AThread: downloadstring, BThread: uploadstring
    Dim AClient, BClient As Net.WebClient 'AClient: refer to Athread, BClient: refer to BThread
    Dim count As Integer

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim gio, phut, giay As String
        If My.Computer.Clock.LocalTime.Hour < 10 Then
            gio = "0" + My.Computer.Clock.LocalTime.Hour.ToString
        Else
            gio = My.Computer.Clock.LocalTime.Hour.ToString
        End If
        If My.Computer.Clock.LocalTime.Minute < 10 Then
            phut = "0" + My.Computer.Clock.LocalTime.Minute.ToString
        Else
            phut = My.Computer.Clock.LocalTime.Minute.ToString

        End If
        If My.Computer.Clock.LocalTime.Second < 10 Then
            giay = "0" + My.Computer.Clock.LocalTime.Second.ToString
        Else
            giay = My.Computer.Clock.LocalTime.Second.ToString
        End If
        ToolLabel2.Text = "Đồng hồ:  " + gio + " : " + phut + " : " + giay
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        AThread.Abort()
        BThread.Abort()
        GC.Collect()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chay = False
        TextBox2.Hide()
        'My.Settings.Reset()
        Control.CheckForIllegalCrossThreadCalls = False
        webs = My.Resources.web
        host = My.Resources.host
        user = My.Resources.username
        pass = My.Resources.pass

        AClient = New Net.WebClient
        AThread = New Threading.Thread(AddressOf downstringhost)
        AThread.Start()

        BClient = New Net.WebClient
        BClient.Credentials = New Net.NetworkCredential(user, pass)
        BThread = New Threading.Thread(AddressOf upstringhost)
        BThread.Start()

        If My.Settings.nick <> "******000000" Then
            nick = My.Settings.nick
            Label1.Text = nick
        Else
            Dialog1.ShowDialog()
        End If

        count = 0
        chay = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox2.Text = nick + ": " + TextBox1.Text
        TextBox1.Clear()
        TextBox1.Focus()
        Timer2.Start()
        Button1.Enabled = False
    End Sub

    Private Sub GiớiThiệuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GiớiThiệuToolStripMenuItem.Click
        AboutBox1.ShowDialog()
    End Sub

    Private Sub ĐổiTênToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ĐổiTênToolStripMenuItem.Click
        Dialog1.ShowDialog()
    End Sub

    Private Sub downstringhost()
        Do
            Try
                Threading.Thread.Sleep(100)
                Dim str As String = AClient.DownloadString(webs)
                If str <> "" And str <> strc Then
                    ListBox1.Items.Add(str)
                    ListBox1.TopIndex = ListBox1.Items.Count - 1
                    strc = str
                End If

            Catch ex As Exception

            End Try
        Loop
    End Sub

    Private Sub upstringhost()
        Do
            Try
                Threading.Thread.Sleep(100)
                If TextBox2.Text <> "" And TextBox2.Text <> strc1 Then
                    BClient.UploadString(host, TextBox2.Text)
                    strc1 = TextBox2.Text
                    TextBox2.Text = Nothing
                End If
            Catch ex As Exception
            End Try
        Loop
    End Sub

    Private Sub ThoátToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ThoátToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If count = 5 Then
            count = 0
            Button1.Enabled = True
            Timer2.Stop()
        Else
            count += 1
        End If
    End Sub
End Class
