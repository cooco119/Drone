Public Class 원근변환창


    Private Sub ButtonClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClose.Click
        Me.Close()
    End Sub

    Private Sub 투시변환창_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PictureBoxPerspective.Image = FormMain.PictureBoxSource.Image
        TextBoxScaleX.Text = 1
        TextBoxScaleY.Text = 1
        TextBoxTransX.Text = 0
        TextBoxTransY.Text = 0
        TextBoxTransZ.Text = 0
        TextBoxRotX.Text = 0
        TextBoxRotY.Text = 0
        TextBoxRotZ.Text = 0
        TextBoxEye.Text = 5
        TextBoxScreen.Text = 5
    End Sub
    ''버튼 이미지 원래대로를 클릭했을때 실행....
    Private Sub ButtonOriginal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOriginal.Click
        PictureBoxPerspective.Image = FormMain.PictureBoxSource.Image
    End Sub

    ''버튼 원근변환실행이 클릭되었을때....
    Private Sub ButtonPerspec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPerspec.Click
        ''일단 클래스 Perspective를 인스턴스화하면...
        Dim img As Bitmap
        Dim myperspective As New Perspective
        img = PictureBoxPerspective.Image
        PictureBoxPerspective.Image = myperspective.Persp_Trans(img)

        ''그리고 myperspective의 메스드인 원근변환함수를 호출하여
        ''픽쳐박스에 뿌려줌.....
    End Sub

    Private Sub ButtonResetValue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonResetValue.Click
        TextBoxScaleX.Text = 1
        TextBoxScaleY.Text = 1
        TextBoxTransX.Text = 0
        TextBoxTransY.Text = 0
        TextBoxTransZ.Text = 0
        TextBoxRotX.Text = 0
        TextBoxRotY.Text = 0
        TextBoxRotZ.Text = 0
        TextBoxEye.Text = 5
        TextBoxScreen.Text = 5
    End Sub
End Class