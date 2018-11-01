<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
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
        Me.PictureBoxSource = New System.Windows.Forms.PictureBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ButtonOpen = New System.Windows.Forms.Button()
        Me.PictureBoxScale = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBoxScale = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComboBoxScale = New System.Windows.Forms.ComboBox()
        Me.ButtonScale = New System.Windows.Forms.Button()
        Me.TextBox확대치수 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBoxSpan = New System.Windows.Forms.TextBox()
        Me.ProgressBarScale = New System.Windows.Forms.ProgressBar()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.파일ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.이미지열기OToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.이미지저장SToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.회전ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.임의의각도회전ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.특수각도회전ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.투시변환ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ButtonRotation = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBoxAngle = New System.Windows.Forms.TextBox()
        Me.ButtonPersp = New System.Windows.Forms.Button()
        CType(Me.PictureBoxSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxScale, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBoxSource
        '
        Me.PictureBoxSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBoxSource.Location = New System.Drawing.Point(39, 66)
        Me.PictureBoxSource.Name = "PictureBoxSource"
        Me.PictureBoxSource.Size = New System.Drawing.Size(300, 300)
        Me.PictureBoxSource.TabIndex = 0
        Me.PictureBoxSource.TabStop = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'ButtonOpen
        '
        Me.ButtonOpen.Location = New System.Drawing.Point(218, 407)
        Me.ButtonOpen.Name = "ButtonOpen"
        Me.ButtonOpen.Size = New System.Drawing.Size(121, 34)
        Me.ButtonOpen.TabIndex = 1
        Me.ButtonOpen.Text = "소스 이미지 Open"
        Me.ButtonOpen.UseVisualStyleBackColor = True
        '
        'PictureBoxScale
        '
        Me.PictureBoxScale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBoxScale.Location = New System.Drawing.Point(383, 66)
        Me.PictureBoxScale.Name = "PictureBoxScale"
        Me.PictureBoxScale.Size = New System.Drawing.Size(300, 300)
        Me.PictureBoxScale.TabIndex = 7
        Me.PictureBoxScale.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(515, 414)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 12)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "확대비"
        '
        'TextBoxScale
        '
        Me.TextBoxScale.Location = New System.Drawing.Point(583, 405)
        Me.TextBoxScale.Name = "TextBoxScale"
        Me.TextBoxScale.Size = New System.Drawing.Size(100, 21)
        Me.TextBoxScale.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(515, 444)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 12)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "확대방법"
        '
        'ComboBoxScale
        '
        Me.ComboBoxScale.FormattingEnabled = True
        Me.ComboBoxScale.Location = New System.Drawing.Point(583, 441)
        Me.ComboBoxScale.Name = "ComboBoxScale"
        Me.ComboBoxScale.Size = New System.Drawing.Size(121, 20)
        Me.ComboBoxScale.TabIndex = 15
        '
        'ButtonScale
        '
        Me.ButtonScale.Location = New System.Drawing.Point(383, 407)
        Me.ButtonScale.Name = "ButtonScale"
        Me.ButtonScale.Size = New System.Drawing.Size(121, 34)
        Me.ButtonScale.TabIndex = 16
        Me.ButtonScale.Text = "확 대 / 축 소"
        Me.ButtonScale.UseVisualStyleBackColor = True
        '
        'TextBox확대치수
        '
        Me.TextBox확대치수.Location = New System.Drawing.Point(519, 503)
        Me.TextBox확대치수.Name = "TextBox확대치수"
        Me.TextBox확대치수.Size = New System.Drawing.Size(177, 21)
        Me.TextBox확대치수.TabIndex = 19
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(515, 475)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 12)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "경과시간"
        '
        'TextBoxSpan
        '
        Me.TextBoxSpan.Location = New System.Drawing.Point(583, 476)
        Me.TextBoxSpan.Name = "TextBoxSpan"
        Me.TextBoxSpan.Size = New System.Drawing.Size(100, 21)
        Me.TextBoxSpan.TabIndex = 21
        '
        'ProgressBarScale
        '
        Me.ProgressBarScale.Location = New System.Drawing.Point(383, 378)
        Me.ProgressBarScale.Name = "ProgressBarScale"
        Me.ProgressBarScale.Size = New System.Drawing.Size(300, 10)
        Me.ProgressBarScale.TabIndex = 22
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.파일ToolStripMenuItem, Me.회전ToolStripMenuItem, Me.투시변환ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(741, 24)
        Me.MenuStrip1.TabIndex = 23
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '파일ToolStripMenuItem
        '
        Me.파일ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.이미지열기OToolStripMenuItem, Me.이미지저장SToolStripMenuItem})
        Me.파일ToolStripMenuItem.Name = "파일ToolStripMenuItem"
        Me.파일ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.파일ToolStripMenuItem.Text = "파일"
        '
        '이미지열기OToolStripMenuItem
        '
        Me.이미지열기OToolStripMenuItem.Name = "이미지열기OToolStripMenuItem"
        Me.이미지열기OToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.이미지열기OToolStripMenuItem.Text = "이미지 열기(&O)"
        '
        '이미지저장SToolStripMenuItem
        '
        Me.이미지저장SToolStripMenuItem.Name = "이미지저장SToolStripMenuItem"
        Me.이미지저장SToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.이미지저장SToolStripMenuItem.Text = "이미지 저장(&S)"
        '
        '회전ToolStripMenuItem
        '
        Me.회전ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.임의의각도회전ToolStripMenuItem, Me.특수각도회전ToolStripMenuItem})
        Me.회전ToolStripMenuItem.Name = "회전ToolStripMenuItem"
        Me.회전ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.회전ToolStripMenuItem.Text = "회전"
        '
        '임의의각도회전ToolStripMenuItem
        '
        Me.임의의각도회전ToolStripMenuItem.Name = "임의의각도회전ToolStripMenuItem"
        Me.임의의각도회전ToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.임의의각도회전ToolStripMenuItem.Text = "임의의 각도 회전(&R)"
        '
        '특수각도회전ToolStripMenuItem
        '
        Me.특수각도회전ToolStripMenuItem.Name = "특수각도회전ToolStripMenuItem"
        Me.특수각도회전ToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.특수각도회전ToolStripMenuItem.Text = "특수 각도 회전"
        '
        '투시변환ToolStripMenuItem
        '
        Me.투시변환ToolStripMenuItem.Name = "투시변환ToolStripMenuItem"
        Me.투시변환ToolStripMenuItem.Size = New System.Drawing.Size(67, 20)
        Me.투시변환ToolStripMenuItem.Text = "투시변환"
        '
        'ButtonRotation
        '
        Me.ButtonRotation.Location = New System.Drawing.Point(383, 545)
        Me.ButtonRotation.Name = "ButtonRotation"
        Me.ButtonRotation.Size = New System.Drawing.Size(121, 34)
        Me.ButtonRotation.TabIndex = 25
        Me.ButtonRotation.Text = "회 전"
        Me.ButtonRotation.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(517, 561)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 12)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "회전각도"
        '
        'TextBoxAngle
        '
        Me.TextBoxAngle.Location = New System.Drawing.Point(583, 558)
        Me.TextBoxAngle.Name = "TextBoxAngle"
        Me.TextBoxAngle.Size = New System.Drawing.Size(100, 21)
        Me.TextBoxAngle.TabIndex = 27
        '
        'ButtonPersp
        '
        Me.ButtonPersp.Location = New System.Drawing.Point(218, 545)
        Me.ButtonPersp.Name = "ButtonPersp"
        Me.ButtonPersp.Size = New System.Drawing.Size(121, 34)
        Me.ButtonPersp.TabIndex = 28
        Me.ButtonPersp.Text = "투시변환창"
        Me.ButtonPersp.UseVisualStyleBackColor = True
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(741, 661)
        Me.Controls.Add(Me.ButtonPersp)
        Me.Controls.Add(Me.TextBoxAngle)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.ButtonRotation)
        Me.Controls.Add(Me.ProgressBarScale)
        Me.Controls.Add(Me.TextBoxSpan)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TextBox확대치수)
        Me.Controls.Add(Me.ButtonScale)
        Me.Controls.Add(Me.ComboBoxScale)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextBoxScale)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.PictureBoxScale)
        Me.Controls.Add(Me.ButtonOpen)
        Me.Controls.Add(Me.PictureBoxSource)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormMain"
        Me.Text = "교정이미지편집기"
        CType(Me.PictureBoxSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxScale, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBoxSource As System.Windows.Forms.PictureBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ButtonOpen As System.Windows.Forms.Button
    Friend WithEvents PictureBoxScale As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBoxScale As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxScale As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonScale As System.Windows.Forms.Button
    Friend WithEvents TextBox확대치수 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBoxSpan As System.Windows.Forms.TextBox
    Friend WithEvents ProgressBarScale As System.Windows.Forms.ProgressBar
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents 파일ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 이미지열기OToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 이미지저장SToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 회전ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 임의의각도회전ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 특수각도회전ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ButtonRotation As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextBoxAngle As System.Windows.Forms.TextBox
    Friend WithEvents 투시변환ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ButtonPersp As System.Windows.Forms.Button

End Class
