Public Class Form2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim l As New Form1(TextBox1.Text, TextBox2.Text, ComboBox1.Text)
            Me.Hide()
            l.Show()
        Catch ex As Exception
            Me.Show()
        End Try

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.SelectedIndex = 0
    End Sub

    Private Sub TextBox2_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyUp
        If e.KeyCode = Keys.Enter Then
            Button1_Click(Nothing, Nothing)
        End If
    End Sub
End Class