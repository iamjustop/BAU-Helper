Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Web
Imports System.Web.Script.Serialization
Imports BAU_Helper.MyData

Public Class Form1
    Dim link As String
    Sub New(user As String, pass As String, url As String)

        ' This call is required by the designer.
        InitializeComponent()
        link = url
        ConnectURL = link & "reg_new/actions/login"
        FunctionURL = link & "reg_new/actions/rmiMethod"
        Login(user, pass)

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim s() As String = {"30203104", "30203114", "30206106", "30206131", "31712216", "31502110", "31502111", "31501100", "31501102", "31501221", "31503203", "31504204", "31504205", "31501261", "31505201", "31505204", "31505291", "31500231", "31500271", "31500251", "31504301", "31500381", "31500341"}
        For Each ss In s
            scientific.Add(ss)
        Next
    End Sub
    Dim CookieJar As New CookieContainer
    Dim ConnectURL
    Dim FunctionURL
    Dim studentsource As String
    Private Function RegularPage(ByVal URL As String, ByVal CookieJar As CookieContainer) As String
        Dim reader As StreamReader

        Dim Request As HttpWebRequest = HttpWebRequest.Create(URL)
        Request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.8.1.14) Gecko/20080404 Firefox/2.0.0.14"
        Request.AllowAutoRedirect = False
        Request.CookieContainer = CookieJar

        Dim Response As HttpWebResponse = Request.GetResponse()

        reader = New StreamReader(Response.GetResponseStream())
        Return HttpUtility.HtmlDecode(reader.ReadToEnd())
        Response.Close()
    End Function
    Private Function DoPost(ByVal URL As String, ByRef CookieJar As CookieContainer, ByVal PostData As String)
        Dim reader As StreamReader

        Dim Request As HttpWebRequest = HttpWebRequest.Create(URL)

        Request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.8.1.14) Gecko/20080404 Firefox/2.0.0.14"
        Request.CookieContainer = CookieJar
        Request.AllowAutoRedirect = False
        Request.ContentType = "application/x-www-form-urlencoded"
        Request.Method = "POST"
        Request.ContentLength = PostData.Length

        Dim requestStream As Stream = Request.GetRequestStream()
        Dim postBytes As Byte() = Encoding.ASCII.GetBytes(PostData)

        requestStream.Write(postBytes, 0, postBytes.Length)
        requestStream.Close()

        Dim Response As HttpWebResponse = Request.GetResponse()

        For Each tempCookie In Response.Cookies
            CookieJar.Add(tempCookie)
        Next

        reader = New StreamReader(Response.GetResponseStream())
        Return HttpUtility.HtmlDecode(reader.ReadToEnd())
        Response.Close()
    End Function
    Private Sub LogonPage(ByVal URL As String, ByRef CookieJar As CookieContainer, ByVal PostData As String)
        Dim reader As StreamReader

        Dim Request As HttpWebRequest = HttpWebRequest.Create(URL)

        Request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.8.1.14) Gecko/20080404 Firefox/2.0.0.14"
        Request.CookieContainer = CookieJar
        Request.AllowAutoRedirect = False
        Request.ContentType = "application/x-www-form-urlencoded"
        Request.Method = "POST"
        Request.ContentLength = PostData.Length

        Dim requestStream As Stream = Request.GetRequestStream()
        Dim postBytes As Byte() = Encoding.ASCII.GetBytes(PostData)

        requestStream.Write(postBytes, 0, postBytes.Length)
        requestStream.Close()

        Dim Response As HttpWebResponse = Request.GetResponse()

        For Each tempCookie In Response.Cookies
            CookieJar.Add(tempCookie)
        Next

        reader = New StreamReader(Response.GetResponseStream())
        Response.Close()
    End Sub
    Dim student As New MyData.Student

    Sub Login(username As String, password As String)
        Dim PostData As String

        Try
            'Login

            PostData = "username=" & username & "&password=" & password
            LogonPage(ConnectURL, CookieJar, PostData)
            Dim source As String = DoPost(FunctionURL, CookieJar, "method=getStudent&paramsCount=0")
            studentsource = source

            Dim studentinfo As StudentInformation = (New JavaScriptSerializer().Deserialize(Of StudentInformation)(source))

            ' Dim data As String = IO.File.ReadAllText(My.Computer.FileSystem.SpecialDirectories.Desktop & "\txt.txt")
            ' Dim studentinfo As StudentInformation = (New JavaScriptSerializer().Deserialize(Of StudentInformation)(data))


            lbl_name.Text = "Name : " & studentinfo.englishName & " - " & studentinfo.arabicName
            lbl_curavg.Text = "Current Average : " & studentinfo.avg
            lbl_tawjihi.Text = "Previous Average : " & studentinfo.secAvg
            lbl_uninum.Text = "University ID Number : " & studentinfo.id
            lbl_nationalnumber.Text = "National ID Number : " & studentinfo.nationalNo

            Dim marksource As String = DoPost(FunctionURL, CookieJar, "method=getStudentSemesters&paramsCount=0")

            '  Dim marksource As String = IO.File.ReadAllText(My.Computer.FileSystem.SpecialDirectories.Desktop & "\mark.txt")
            Dim markinfo As StudentMarkInformation()
            Try
                markinfo = (New JavaScriptSerializer().Deserialize(Of StudentMarkInformation())(marksource))
            Catch
                MsgBox("Wrong Password or Student Number")
                Me.Close()

            End Try
            Dim semcounter As Integer = 1

            Dim semlist As New List(Of MyData.Semester)
            For i As Integer = 0 To markinfo.Count - 1

                Dim sem As New MyData.Semester

                If semcounter = 1 Then
                    sem.Type = "1st Semester"
                    semcounter = 2
                ElseIf semcounter = 2 Then
                    sem.Type = "2nd Semester"
                    semcounter = 3
                Else
                    sem.Type = "Summer Semester"
                    semcounter = 1
                End If


                For Each mark In markinfo(i).marks
                    Dim m As New MyData.Subject
                    m.Name = mark.name
                    m.id = mark.id
                    m.Mark = mark.result
                    m.HourCredit = mark.hours
                    m.status = mark.status

                    sem.Hours += mark.hours
                    sem.Total += LetterToNum(mark.result)

                    sem.Subjects.Add(m)


                    Dim item As New ListViewItem
                    item.Text = mark.name
                    item.SubItems.Add(mark.id)
                    item.SubItems.Add(mark.hours)
                    item.SubItems.Add(mark.result)
                    ListView1.Items.Add(item)
                Next
                Dim itemm As New ListViewItem
                itemm.Text = "------ New Semester ------"
                itemm.SubItems.Add("----")
                itemm.SubItems.Add("----")
                itemm.SubItems.Add("----")

                sem.Avg = markinfo(i).finalAverage
                semlist.Add(sem)
                ListView1.Items.Add(itemm)
            Next

            Dim y As New List(Of MyData.Year)
            For Each s In semlist
                If s.Type = "1st Semester" Then
                    y.Add(New MyData.Year)
                    y(y.Count - 1).Semester1 = s
                ElseIf s.Type = "2nd Semester" Then
                    y(y.Count - 1).Semester2 = s
                Else
                    y(y.Count - 1).Summer = s
                End If
            Next

            student.Years = y

            Label1.Text = "المعدل التراكمي = " & (Math.Round(CalcTotalAvg(student), 2))
        Catch ex As Exception

        End Try
    End Sub
    Function CalcTotalAvg(ByVal student As Student)
        Dim totahours As Double = 0
        Dim totalmarks As Double = 0
        For Each year In student.Years
            For Each s In year.Semester1.Subjects
                If Not LetterToNum(s.Mark) = 0 Then
                    totalmarks += s.HourCredit * LetterToNum(s.Mark)
                    totahours += s.HourCredit
                End If
            Next
            For Each ss In year.Semester2.Subjects
                If Not LetterToNum(ss.Mark) = 0 Then
                    totalmarks += ss.HourCredit * LetterToNum(ss.Mark)
                    totahours += ss.HourCredit

                End If
            Next
            For Each sss In year.Summer.Subjects
                If Not LetterToNum(sss.Mark) = 0 Then
                    totalmarks += sss.HourCredit * LetterToNum(sss.Mark)
                    totahours += sss.HourCredit

                End If
            Next
        Next

        Return totalmarks / totahours
    End Function
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

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Form2.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim b As Boolean = False
        If student.Years.Count > 3 Then b = True

        Dim l As New Form3(student.Years(0), scientific, b)
        l.ShowDialog()




    End Sub

    Dim scientific As New List(Of String)
End Class

Public Class Mark
    Public Property name As String
    Public Property hours As String
    Public Property id As String
    Public Property status As String
    Public Property result As String
End Class

Public Class StudentMarkInformation
    Public Property hours As String
    Public Property year As String
    Public Property id As String
    Public Property marks As Mark()
    Public Property semester As String
    Public Property average As String
    Public Property finalAverage As String
    Public Property accumulativeHours As String
    Public Property accumulativePassHours As String
    Public Property remarks As String
End Class
Public Class StudentInformation
    Public Property type As String
    Public Property hours As String
    Public Property id As String
    Public Property status As Integer
    Public Property avg As String
    Public Property secAvg As String
    Public Property stream As String
    Public Property secYear As String
    Public Property gender As String
    Public Property transfered As Boolean
    Public Property specificationId As String
    Public Property collegeId As String
    Public Property englishName As String
    Public Property arabicName As String
    Public Property degree As String
    Public Property departmentId As String
    Public Property degreeArabicName As String
    Public Property degreeEnglishName As String
    Public Property statusDesc As String
    Public Property financial As String
    Public Property arabicBornName As String
    Public Property englishBornName As String
    Public Property nationalNo As String
    Public Property regStatus As String
End Class
Namespace MyData
    Public Class Student
        Property Years As New List(Of Year)
    End Class
    Public Class Year
        Property Semester1 As New Semester
        Property Semester2 As New Semester
        Property Summer As New Semester
    End Class
    Public Class Semester
        Property Subjects As New List(Of Subject)
        Property Type As String
        Property Hours As Integer
        Property Avg As Double
        Property Total As Double
    End Class
    Public Class Subject
        Property Name As String
        Property Mark As String
        Property HourCredit As Integer
        Property id As String
        Property status As String
    End Class
End Namespace