<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 원근변환창
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
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

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기를 사용하여 수정하지 마십시오.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PictureBoxPerspective = New System.Windows.Forms.PictureBox()
        Me.TrackBarTransX = New System.Windows.Forms.TrackBar()
        Me.TrackBarTransY = New System.Windows.Forms.TrackBar()
        Me.TrackBarTransZ = New System.Windows.Forms.TrackBar()
        Me.TrackBarRotX = New System.Windows.Forms.TrackBar()
        Me.TrackBarRotY = New System.Windows.Forms.TrackBar()
        Me.TrackBarRotZ = New System.Windows.Forms.TrackBar()
        Me.TrackBarEye = New System.Windows.Forms.TrackBar()
        Me.TrackBarScreen = New System.Windows.Forms.TrackBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ButtonResetValue = New System.Windows.Forms.Button()
        Me.ButtonClose = New System.Windows.Forms.Button()
        Me.TextBoxTransX = New System.Windows.Forms.TextBox()
        Me.TextBoxTransY = New System.Windows.Forms.TextBox()
        Me.TextBoxTransZ = New System.Windows.Forms.TextBox()
        Me.TextBoxRotX = New System.Windows.Forms.TextBox()
        Me.TextBoxRotY = New System.Windows.Forms.TextBox()
        Me.TextBoxRotZ = New System.Windows.Forms.TextBox()
        Me.TextBoxEye = New System.Windows.Forms.TextBox()
        Me.TextBoxScreen = New System.Windows.Forms.TextBox()
        Me.TextBoxScaleY = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TrackBarScaleY = New System.Windows.Forms.TrackBar()
        Me.TextBoxScaleX = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TrackBarScaleX = New System.Windows.Forms.TrackBar()
        Me.ButtonOriginal = New System.Windows.Forms.Button()
        Me.ButtonPerspec = New System.Windows.Forms.Button()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.RichTextBox2 = New System.Windows.Forms.RichTextBox()
        CType(Me.PictureBoxPerspective, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarTransX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarTransY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarTransZ, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarRotX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarRotY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarRotZ, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarEye, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarScreen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarScaleY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarScaleX, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBoxPerspective
        '
        Me.PictureBoxPerspective.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBoxPerspective.Location = New System.Drawing.Point(12, 32)
        Me.PictureBoxPerspective.Name = "PictureBoxPerspective"
        Me.PictureBoxPerspective.Size = New System.Drawing.Size(500, 517)
        Me.PictureBoxPerspective.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBoxPerspective.TabIndex = 0
        Me.PictureBoxPerspective.TabStop = False
        '
        'TrackBarTransX
        '
        Me.TrackBarTransX.Location = New System.Drawing.Point(618, 147)
        Me.TrackBarTransX.Name = "TrackBarTransX"
        Me.TrackBarTransX.Size = New System.Drawing.Size(104, 45)
        Me.TrackBarTransX.TabIndex = 1
        '
        'TrackBarTransY
        '
        Me.TrackBarTransY.Location = New System.Drawing.Point(618, 198)
        Me.TrackBarTransY.Name = "TrackBarTransY"
        Me.TrackBarTransY.Size = New System.Drawing.Size(104, 45)
        Me.TrackBarTransY.TabIndex = 2
        '
        'TrackBarTransZ
        '
        Me.TrackBarTransZ.Location = New System.Drawing.Point(618, 249)
        Me.TrackBarTransZ.Name = "TrackBarTransZ"
        Me.TrackBarTransZ.Size = New System.Drawing.Size(104, 45)
        Me.TrackBarTransZ.TabIndex = 3
        '
        'TrackBarRotX
        '
        Me.TrackBarRotX.Location = New System.Drawing.Point(618, 300)
        Me.TrackBarRotX.Name = "TrackBarRotX"
        Me.TrackBarRotX.Size = New System.Drawing.Size(104, 45)
        Me.TrackBarRotX.TabIndex = 4
        '
        'TrackBarRotY
        '
        Me.TrackBarRotY.Location = New System.Drawing.Point(618, 351)
        Me.TrackBarRotY.Name = "TrackBarRotY"
        Me.TrackBarRotY.Size = New System.Drawing.Size(104, 45)
        Me.TrackBarRotY.TabIndex = 5
        '
        'TrackBarRotZ
        '
        Me.TrackBarRotZ.Location = New System.Drawing.Point(618, 402)
        Me.TrackBarRotZ.Name = "TrackBarRotZ"
        Me.TrackBarRotZ.Size = New System.Drawing.Size(104, 45)
        Me.TrackBarRotZ.TabIndex = 6
        '
        'TrackBarEye
        '
        Me.TrackBarEye.Location = New System.Drawing.Point(618, 453)
        Me.TrackBarEye.Name = "TrackBarEye"
        Me.TrackBarEye.Size = New System.Drawing.Size(104, 45)
        Me.TrackBarEye.TabIndex = 7
        '
        'TrackBarScreen
        '
        Me.TrackBarScreen.Location = New System.Drawing.Point(618, 504)
        Me.TrackBarScreen.Name = "TrackBarScreen"
        Me.TrackBarScreen.Size = New System.Drawing.Size(104, 45)
        Me.TrackBarScreen.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(532, 149)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 12)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "x축 이동량"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(532, 200)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 12)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "y축 이동량"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(532, 251)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 12)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "z축 이동량"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(532, 302)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 12)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "x축 회전각도"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(532, 353)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 12)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "y축 회전각도"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(532, 404)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 12)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "z축 회전각도"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(532, 455)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 12)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "시점의 위치"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(532, 506)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 12)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "스크린위치"
        '
        'ButtonResetValue
        '
        Me.ButtonResetValue.Location = New System.Drawing.Point(545, 572)
        Me.ButtonResetValue.Name = "ButtonResetValue"
        Me.ButtonResetValue.Size = New System.Drawing.Size(104, 33)
        Me.ButtonResetValue.TabIndex = 17
        Me.ButtonResetValue.Text = "값 원래대로"
        Me.ButtonResetValue.UseVisualStyleBackColor = True
        '
        'ButtonClose
        '
        Me.ButtonClose.Location = New System.Drawing.Point(715, 572)
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.Size = New System.Drawing.Size(91, 33)
        Me.ButtonClose.TabIndex = 18
        Me.ButtonClose.Text = "창닫기"
        Me.ButtonClose.UseVisualStyleBackColor = True
        '
        'TextBoxTransX
        '
        Me.TextBoxTransX.Location = New System.Drawing.Point(732, 152)
        Me.TextBoxTransX.Name = "TextBoxTransX"
        Me.TextBoxTransX.Size = New System.Drawing.Size(74, 21)
        Me.TextBoxTransX.TabIndex = 19
        '
        'TextBoxTransY
        '
        Me.TextBoxTransY.Location = New System.Drawing.Point(732, 202)
        Me.TextBoxTransY.Name = "TextBoxTransY"
        Me.TextBoxTransY.Size = New System.Drawing.Size(74, 21)
        Me.TextBoxTransY.TabIndex = 20
        '
        'TextBoxTransZ
        '
        Me.TextBoxTransZ.Location = New System.Drawing.Point(732, 252)
        Me.TextBoxTransZ.Name = "TextBoxTransZ"
        Me.TextBoxTransZ.Size = New System.Drawing.Size(74, 21)
        Me.TextBoxTransZ.TabIndex = 21
        '
        'TextBoxRotX
        '
        Me.TextBoxRotX.Location = New System.Drawing.Point(732, 302)
        Me.TextBoxRotX.Name = "TextBoxRotX"
        Me.TextBoxRotX.Size = New System.Drawing.Size(74, 21)
        Me.TextBoxRotX.TabIndex = 22
        '
        'TextBoxRotY
        '
        Me.TextBoxRotY.Location = New System.Drawing.Point(732, 352)
        Me.TextBoxRotY.Name = "TextBoxRotY"
        Me.TextBoxRotY.Size = New System.Drawing.Size(74, 21)
        Me.TextBoxRotY.TabIndex = 23
        '
        'TextBoxRotZ
        '
        Me.TextBoxRotZ.Location = New System.Drawing.Point(732, 402)
        Me.TextBoxRotZ.Name = "TextBoxRotZ"
        Me.TextBoxRotZ.Size = New System.Drawing.Size(74, 21)
        Me.TextBoxRotZ.TabIndex = 24
        '
        'TextBoxEye
        '
        Me.TextBoxEye.Location = New System.Drawing.Point(732, 452)
        Me.TextBoxEye.Name = "TextBoxEye"
        Me.TextBoxEye.Size = New System.Drawing.Size(74, 21)
        Me.TextBoxEye.TabIndex = 25
        '
        'TextBoxScreen
        '
        Me.TextBoxScreen.Location = New System.Drawing.Point(732, 502)
        Me.TextBoxScreen.Name = "TextBoxScreen"
        Me.TextBoxScreen.Size = New System.Drawing.Size(74, 21)
        Me.TextBoxScreen.TabIndex = 27
        '
        'TextBoxScaleY
        '
        Me.TextBoxScaleY.Location = New System.Drawing.Point(732, 101)
        Me.TextBoxScaleY.Name = "TextBoxScaleY"
        Me.TextBoxScaleY.Size = New System.Drawing.Size(74, 21)
        Me.TextBoxScaleY.TabIndex = 30
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(532, 98)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 12)
        Me.Label9.TabIndex = 29
        Me.Label9.Text = "x축방향 확대"
        '
        'TrackBarScaleY
        '
        Me.TrackBarScaleY.Location = New System.Drawing.Point(618, 96)
        Me.TrackBarScaleY.Name = "TrackBarScaleY"
        Me.TrackBarScaleY.Size = New System.Drawing.Size(104, 45)
        Me.TrackBarScaleY.TabIndex = 28
        '
        'TextBoxScaleX
        '
        Me.TextBoxScaleX.Location = New System.Drawing.Point(732, 47)
        Me.TextBoxScaleX.Name = "TextBoxScaleX"
        Me.TextBoxScaleX.Size = New System.Drawing.Size(74, 21)
        Me.TextBoxScaleX.TabIndex = 33
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(532, 47)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(76, 12)
        Me.Label10.TabIndex = 32
        Me.Label10.Text = "x축방향 확대"
        '
        'TrackBarScaleX
        '
        Me.TrackBarScaleX.Location = New System.Drawing.Point(618, 42)
        Me.TrackBarScaleX.Name = "TrackBarScaleX"
        Me.TrackBarScaleX.Size = New System.Drawing.Size(104, 45)
        Me.TrackBarScaleX.TabIndex = 31
        '
        'ButtonOriginal
        '
        Me.ButtonOriginal.Location = New System.Drawing.Point(36, 572)
        Me.ButtonOriginal.Name = "ButtonOriginal"
        Me.ButtonOriginal.Size = New System.Drawing.Size(151, 33)
        Me.ButtonOriginal.TabIndex = 34
        Me.ButtonOriginal.Text = "이미지 원래대로"
        Me.ButtonOriginal.UseVisualStyleBackColor = True
        '
        'ButtonPerspec
        '
        Me.ButtonPerspec.Location = New System.Drawing.Point(346, 572)
        Me.ButtonPerspec.Name = "ButtonPerspec"
        Me.ButtonPerspec.Size = New System.Drawing.Size(140, 33)
        Me.ButtonPerspec.TabIndex = 35
        Me.ButtonPerspec.Text = "원근변환 실행"
        Me.ButtonPerspec.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(973, 32)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(124, 593)
        Me.RichTextBox1.TabIndex = 36
        Me.RichTextBox1.Text = ""
        '
        'RichTextBox2
        '
        Me.RichTextBox2.Location = New System.Drawing.Point(827, 32)
        Me.RichTextBox2.Name = "RichTextBox2"
        Me.RichTextBox2.Size = New System.Drawing.Size(124, 593)
        Me.RichTextBox2.TabIndex = 37
        Me.RichTextBox2.Text = ""
        '
        '원근변환창
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1128, 629)
        Me.Controls.Add(Me.RichTextBox2)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.ButtonPerspec)
        Me.Controls.Add(Me.ButtonOriginal)
        Me.Controls.Add(Me.TextBoxScaleX)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TrackBarScaleX)
        Me.Controls.Add(Me.TextBoxScaleY)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TrackBarScaleY)
        Me.Controls.Add(Me.TextBoxScreen)
        Me.Controls.Add(Me.TextBoxEye)
        Me.Controls.Add(Me.TextBoxRotZ)
        Me.Controls.Add(Me.TextBoxRotY)
        Me.Controls.Add(Me.TextBoxRotX)
        Me.Controls.Add(Me.TextBoxTransZ)
        Me.Controls.Add(Me.TextBoxTransY)
        Me.Controls.Add(Me.TextBoxTransX)
        Me.Controls.Add(Me.ButtonClose)
        Me.Controls.Add(Me.ButtonResetValue)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TrackBarScreen)
        Me.Controls.Add(Me.TrackBarEye)
        Me.Controls.Add(Me.TrackBarRotZ)
        Me.Controls.Add(Me.TrackBarRotY)
        Me.Controls.Add(Me.TrackBarRotX)
        Me.Controls.Add(Me.TrackBarTransZ)
        Me.Controls.Add(Me.TrackBarTransY)
        Me.Controls.Add(Me.TrackBarTransX)
        Me.Controls.Add(Me.PictureBoxPerspective)
        Me.Name = "원근변환창"
        Me.Text = "원근변환창"
        CType(Me.PictureBoxPerspective, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarTransX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarTransY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarTransZ, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarRotX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarRotY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarRotZ, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarEye, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarScreen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarScaleY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarScaleX, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBoxPerspective As System.Windows.Forms.PictureBox
    Friend WithEvents TrackBarTransX As System.Windows.Forms.TrackBar
    Friend WithEvents TrackBarTransY As System.Windows.Forms.TrackBar
    Friend WithEvents TrackBarTransZ As System.Windows.Forms.TrackBar
    Friend WithEvents TrackBarRotX As System.Windows.Forms.TrackBar
    Friend WithEvents TrackBarRotY As System.Windows.Forms.TrackBar
    Friend WithEvents TrackBarRotZ As System.Windows.Forms.TrackBar
    Friend WithEvents TrackBarEye As System.Windows.Forms.TrackBar
    Friend WithEvents TrackBarScreen As System.Windows.Forms.TrackBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ButtonResetValue As System.Windows.Forms.Button
    Friend WithEvents ButtonClose As System.Windows.Forms.Button
    Friend WithEvents TextBoxTransX As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxTransY As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxTransZ As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxRotX As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxRotY As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxRotZ As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxEye As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxScreen As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxScaleY As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TrackBarScaleY As System.Windows.Forms.TrackBar
    Friend WithEvents TextBoxScaleX As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TrackBarScaleX As System.Windows.Forms.TrackBar
    Friend WithEvents ButtonOriginal As System.Windows.Forms.Button
    Friend WithEvents ButtonPerspec As System.Windows.Forms.Button
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents RichTextBox2 As System.Windows.Forms.RichTextBox
End Class
