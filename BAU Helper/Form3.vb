Imports BAU_Helper.MyData
Public Class Form3
    Dim year As Year
    Dim scientific As New List(Of String)
    Dim post3 As Boolean
    Sub New(ByVal year_ As Year, ByVal scientific_ As List(Of String), ByVal post3 As Boolean)
        year = year_
        scientific = scientific_

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not post3 Then

            For Each s In year.Semester1.Subjects
                Try
                    CheckedListBox1.Items.Add(s.Name)
                    If scientific.Contains(s.id) Then
                        CheckedListBox1.SetItemCheckState((CheckedListBox1.Items.Count - 1), CheckState.Checked)
                    Else

                    End If
                Catch ex As Exception

                End Try
            Next
            For Each s In year.Semester2.Subjects
                Try
                    CheckedListBox1.Items.Add(s.Name)
                    If scientific.Contains(s.id) Then
                        CheckedListBox1.SetItemCheckState((CheckedListBox1.Items.Count - 1), CheckState.Checked)
                    Else

                    End If
                Catch ex As Exception

                End Try
            Next
            For Each s In year.Summer.Subjects
                Try
                    CheckedListBox1.Items.Add(s.Name)
                    If scientific.Contains(s.id) Then
                        CheckedListBox1.SetItemCheckState((CheckedListBox1.Items.Count - 1), CheckState.Checked)
                    Else

                    End If
                Catch ex As Exception

                End Try
            Next
        Else
            For Each s In year.Semester1.Subjects
                Try
                    CheckedListBox1.Items.Add(s.Name)
                    CheckedListBox1.SetItemCheckState((CheckedListBox1.Items.Count - 1), CheckState.Checked)

                Catch ex As Exception

                End Try
            Next
            For Each s In year.Semester2.Subjects
                Try
                    CheckedListBox1.Items.Add(s.Name)
                    CheckedListBox1.SetItemCheckState((CheckedListBox1.Items.Count - 1), CheckState.Checked)

                Catch ex As Exception

                End Try
            Next
            For Each s In year.Summer.Subjects
                Try
                    CheckedListBox1.Items.Add(s.Name)
                    CheckedListBox1.SetItemCheckState((CheckedListBox1.Items.Count - 1), CheckState.Checked)

                Catch ex As Exception

                End Try
            Next
        End If

        calc()
    End Sub
    Sub calc()
        Dim hours As Integer = 0
        Dim tot As Double = 0
        For Each it In CheckedListBox1.CheckedItems
            Try : hours += year.Semester1.Subjects.Find(Function(c) c.Name = it.ToString).HourCredit : Catch : End Try
            Try : hours += year.Semester2.Subjects.Find(Function(c) c.Name = it.ToString).HourCredit : Catch : End Try
            Try : hours += year.Summer.Subjects.Find(Function(c) c.Name = it.ToString).HourCredit : Catch : End Try
            Try : tot += LetterToNum(year.Semester1.Subjects.Find(Function(c) c.Name = it.ToString).Mark) * year.Semester1.Subjects.Find(Function(c) c.Name = it.ToString).HourCredit : Catch : End Try
            Try : tot += LetterToNum(year.Semester2.Subjects.Find(Function(c) c.Name = it.ToString).Mark) * year.Semester2.Subjects.Find(Function(c) c.Name = it.ToString).HourCredit : Catch : End Try
            Try : tot += LetterToNum(year.Summer.Subjects.Find(Function(c) c.Name = it.ToString).Mark) * year.Summer.Subjects.Find(Function(c) c.Name = it.ToString).HourCredit : Catch : End Try

        Next
        Label3.Text = Math.Round(tot / hours, 2)
    End Sub
    Function LetterToNum(l As String) As Double

        If l = "A" Then
            Return 4
        ElseIf l = "A-" Then
            Return 3.75

        ElseIf l = "B+" Then
            Return 3.5

        ElseIf l = "B" Then
            Return 3

        ElseIf l = "B-" Then
            Return 2.75

        ElseIf l = "C+" Then
            Return 2.5

        ElseIf l = "C" Then
            Return 2

        ElseIf l = "C-" Then
            Return 1.75

        ElseIf l = "D+" Then
            Return 1.5

        ElseIf l = "D" Then
            Return 1

        ElseIf l = "D-" Then
            Return 0.75

        ElseIf l = "F" Then
            Return 0.5
        ElseIf l = "F*" Then
            Return 0.5
        Else
            Return 0
        End If
    End Function

    Private Sub CheckedListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CheckedListBox1.SelectedIndexChanged
        ' calc()
    End Sub

    Private Sub CheckedListBox1_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles CheckedListBox1.ItemCheck
        'calc()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.Enabled = False
        calc()
        Button1.Enabled = True
    End Sub
End Class