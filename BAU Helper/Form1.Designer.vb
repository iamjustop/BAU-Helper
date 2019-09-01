<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lbl_name = New System.Windows.Forms.Label()
        Me.lbl_curavg = New System.Windows.Forms.Label()
        Me.lbl_tawjihi = New System.Windows.Forms.Label()
        Me.lbl_uninum = New System.Windows.Forms.Label()
        Me.lbl_nationalnumber = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader5})
        Me.ListView1.Location = New System.Drawing.Point(12, 88)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(1163, 373)
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Name "
        Me.ColumnHeader1.Width = 212
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "ID"
        Me.ColumnHeader2.Width = 143
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Hours"
        Me.ColumnHeader3.Width = 77
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Mark"
        Me.ColumnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_name
        '
        Me.lbl_name.AutoSize = True
        Me.lbl_name.Location = New System.Drawing.Point(13, 13)
        Me.lbl_name.Name = "lbl_name"
        Me.lbl_name.Size = New System.Drawing.Size(44, 13)
        Me.lbl_name.TabIndex = 1
        Me.lbl_name.Text = "Name : "
        '
        'lbl_curavg
        '
        Me.lbl_curavg.AutoSize = True
        Me.lbl_curavg.Location = New System.Drawing.Point(13, 36)
        Me.lbl_curavg.Name = "lbl_curavg"
        Me.lbl_curavg.Size = New System.Drawing.Size(93, 13)
        Me.lbl_curavg.TabIndex = 2
        Me.lbl_curavg.Text = "Current Average : "
        '
        'lbl_tawjihi
        '
        Me.lbl_tawjihi.AutoSize = True
        Me.lbl_tawjihi.Location = New System.Drawing.Point(13, 60)
        Me.lbl_tawjihi.Name = "lbl_tawjihi"
        Me.lbl_tawjihi.Size = New System.Drawing.Size(92, 13)
        Me.lbl_tawjihi.TabIndex = 3
        Me.lbl_tawjihi.Text = "Tawjihi Average : "
        '
        'lbl_uninum
        '
        Me.lbl_uninum.AutoSize = True
        Me.lbl_uninum.Location = New System.Drawing.Point(460, 13)
        Me.lbl_uninum.Name = "lbl_uninum"
        Me.lbl_uninum.Size = New System.Drawing.Size(113, 13)
        Me.lbl_uninum.TabIndex = 4
        Me.lbl_uninum.Text = "University ID Number :"
        '
        'lbl_nationalnumber
        '
        Me.lbl_nationalnumber.AutoSize = True
        Me.lbl_nationalnumber.Location = New System.Drawing.Point(460, 36)
        Me.lbl_nationalnumber.Name = "lbl_nationalnumber"
        Me.lbl_nationalnumber.Size = New System.Drawing.Size(95, 13)
        Me.lbl_nationalnumber.TabIndex = 5
        Me.lbl_nationalnumber.Text = "National Number : "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 479)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 39)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "GPA = "
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(425, 484)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(283, 39)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "حساب المعدل العلمي للسنة الحالي"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1187, 547)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbl_nationalnumber)
        Me.Controls.Add(Me.lbl_uninum)
        Me.Controls.Add(Me.lbl_tawjihi)
        Me.Controls.Add(Me.lbl_curavg)
        Me.Controls.Add(Me.lbl_name)
        Me.Controls.Add(Me.ListView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form1"
        Me.Text = "GPA Calculator By Saeed Karajah"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ListView1 As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents lbl_name As Label
    Friend WithEvents lbl_curavg As Label
    Friend WithEvents lbl_tawjihi As Label
    Friend WithEvents lbl_uninum As Label
    Friend WithEvents lbl_nationalnumber As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
End Class
