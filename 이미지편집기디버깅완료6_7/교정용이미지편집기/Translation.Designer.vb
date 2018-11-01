<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Translation
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
        Me.PictureBoxTrans = New System.Windows.Forms.PictureBox()
        Me.ButtonClose = New System.Windows.Forms.Button()
        CType(Me.PictureBoxTrans, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBoxTrans
        '
        Me.PictureBoxTrans.Location = New System.Drawing.Point(21, 19)
        Me.PictureBoxTrans.Name = "PictureBoxTrans"
        Me.PictureBoxTrans.Size = New System.Drawing.Size(300, 300)
        Me.PictureBoxTrans.TabIndex = 0
        Me.PictureBoxTrans.TabStop = False
        '
        'ButtonClose
        '
        Me.ButtonClose.Location = New System.Drawing.Point(379, 459)
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.Size = New System.Drawing.Size(75, 23)
        Me.ButtonClose.TabIndex = 1
        Me.ButtonClose.Text = "닫기"
        Me.ButtonClose.UseVisualStyleBackColor = True
        '
        'Translation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(525, 503)
        Me.Controls.Add(Me.ButtonClose)
        Me.Controls.Add(Me.PictureBoxTrans)
        Me.Name = "Translation"
        Me.Text = "Trans"
        CType(Me.PictureBoxTrans, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBoxTrans As System.Windows.Forms.PictureBox
    Friend WithEvents ButtonClose As System.Windows.Forms.Button
End Class
