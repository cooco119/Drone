<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RotationForm
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
        Me.ProgressBarRotation = New System.Windows.Forms.ProgressBar()
        Me.PictureBoxRotation = New System.Windows.Forms.PictureBox()
        Me.ButtonClose = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBoxrot_w = New System.Windows.Forms.TextBox()
        Me.TextBoxrot_h = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBoxAngle = New System.Windows.Forms.TextBox()
        CType(Me.PictureBoxRotation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ProgressBarRotation
        '
        Me.ProgressBarRotation.Location = New System.Drawing.Point(114, 585)
        Me.ProgressBarRotation.Name = "ProgressBarRotation"
        Me.ProgressBarRotation.Size = New System.Drawing.Size(479, 10)
        Me.ProgressBarRotation.TabIndex = 0
        '
        'PictureBoxRotation
        '
        Me.PictureBoxRotation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBoxRotation.Location = New System.Drawing.Point(26, 27)
        Me.PictureBoxRotation.Name = "PictureBoxRotation"
        Me.PictureBoxRotation.Size = New System.Drawing.Size(659, 525)
        Me.PictureBoxRotation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBoxRotation.TabIndex = 1
        Me.PictureBoxRotation.TabStop = False
        '
        'ButtonClose
        '
        Me.ButtonClose.Location = New System.Drawing.Point(612, 667)
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.Size = New System.Drawing.Size(73, 36)
        Me.ButtonClose.TabIndex = 2
        Me.ButtonClose.Text = "닫 기"
        Me.ButtonClose.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(91, 654)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "이미지 너비"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(91, 622)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "이미지 높이"
        '
        'TextBoxrot_w
        '
        Me.TextBoxrot_w.Location = New System.Drawing.Point(166, 651)
        Me.TextBoxrot_w.Name = "TextBoxrot_w"
        Me.TextBoxrot_w.Size = New System.Drawing.Size(100, 21)
        Me.TextBoxrot_w.TabIndex = 5
        '
        'TextBoxrot_h
        '
        Me.TextBoxrot_h.Location = New System.Drawing.Point(166, 619)
        Me.TextBoxrot_h.Name = "TextBoxrot_h"
        Me.TextBoxrot_h.Size = New System.Drawing.Size(100, 21)
        Me.TextBoxrot_h.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(320, 619)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "회전각도"
        '
        'TextBoxAngle
        '
        Me.TextBoxAngle.Location = New System.Drawing.Point(379, 616)
        Me.TextBoxAngle.Name = "TextBoxAngle"
        Me.TextBoxAngle.Size = New System.Drawing.Size(100, 21)
        Me.TextBoxAngle.TabIndex = 8
        '
        'RotationForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(722, 715)
        Me.Controls.Add(Me.TextBoxAngle)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBoxrot_h)
        Me.Controls.Add(Me.TextBoxrot_w)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ButtonClose)
        Me.Controls.Add(Me.PictureBoxRotation)
        Me.Controls.Add(Me.ProgressBarRotation)
        Me.Name = "RotationForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "RotationForm"
        CType(Me.PictureBoxRotation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ProgressBarRotation As System.Windows.Forms.ProgressBar
    Friend WithEvents PictureBoxRotation As System.Windows.Forms.PictureBox
    Friend WithEvents ButtonClose As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBoxrot_w As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxrot_h As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBoxAngle As System.Windows.Forms.TextBox
End Class
