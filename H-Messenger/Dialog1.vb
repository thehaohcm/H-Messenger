Imports System.Windows.Forms

Public Class Dialog1
    Dim m_isExiting As Boolean
    Private Sub Dialog1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Me.DialogResult = Windows.Forms.DialogResult.Cancel Then
            If m_isExiting = False Then
                If MessageBox.Show("Nếu không nhập tên, chương trình không thể tiếp tục. Nhấn OK để thoát hoàn toàn H-Messenger.", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.OK Then
                    m_isExiting = True
                    Application.Exit()
                Else
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub Dialog1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Clear()
        TextBox1.Select()

        If Form1.chay = False Then
            Me.Text = "Đăng ký"
            Label2.Text = Nothing
        Else
            Me.Text = "Thay đổi tên"
            Label2.Text = "Tên cũ: " + My.Settings.nick
        End If

        m_isExiting = False
    End Sub

    Private Sub Cancel_Button_Click(sender As Object, e As EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub OK_Button_Click(sender As Object, e As EventArgs) Handles OK_Button.Click
        If TextBox1.Text = Nothing Then
            MessageBox.Show("Tên đăng nhập không hợp lệ. Bạn vui lòng nhập lại.", "Tên không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox1.Clear()
            TextBox1.Select()
        Else
            My.Settings.nick = TextBox1.Text
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Form1.nick = My.Settings.nick
            Form1.Label1.Text = TextBox1.Text
            Me.Close()
        End If
    End Sub
End Class
