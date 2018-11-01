Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices

Public Class FormMain
    Dim refX, refY, transX, transY, trans As Integer
    
    '이미지화일 불러오기.....
    Private Sub ButtonOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                                               Handles ButtonOpen.Click
        Try
            OpenFileDialog1.InitialDirectory = "c:\Users\Adminstrator"
            If OpenFileDialog1.ShowDialog = DialogResult.OK Then
                PictureBoxSource.Image = Image.FromFile(OpenFileDialog1.FileName)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    ''그림이동을 다시 손을 보아야 하는데....


    '그림위에서 마우스를 클릭했을때....
    '그 위치를 기억.....
    Private Sub PictureBoxSource_MouseDown(ByVal sender As System.Object, _
                                           ByVal e As System.Windows.Forms.MouseEventArgs) _
                                                    Handles PictureBoxSource.MouseDown
        '여기서 e는 이벤트가 일어날 당시의 상황정보입니다.
        '여기서는 e가 바로 마우스를 클릭했을때 상황이죠.
        '이 상황정보에는 어떤 단추를 클릭했는지...어디서 클릭했는지 등 여러정보가 있음....
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                refX = e.X
                refY = e.Y
            End If
            'PictureBoxSource.Refresh()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
   
    ''목표는 사진위에서 마우스를 클릭한 후 마우스의 움직임에 따라 그림을 
    ''이동시키는 겁니다.
    Private Sub PictureBoxSource_MouseMove(ByVal sender As System.Object, _
                                           ByVal e As System.Windows.Forms.MouseEventArgs) _
                                             Handles PictureBoxSource.MouseMove
        Try
            If PictureBoxSource.Image Is Nothing Then Exit Sub

            '여기서 마우스 움직임에 따라 그림을 다시 그려야 한다.
            '재빨리 처리하기 위해서는 당연히 LockBits를 사용해야한다.
            '평형이동량은 transX,transY가 된다.
            '먼저 PictureBoxSource로부터 비트맵이미지를 만들면....
            Dim img As Bitmap = New Bitmap(PictureBoxSource.Image, _
                                           PictureBoxSource.Width, PictureBoxSource.Height)

            If e.Button = Windows.Forms.MouseButtons.Left Then
                ''이동량 계산해주고
                transX = e.X - refX
                transY = e.Y - refY
                ' '' ''디버깅용....
                '' ''TextBox1.Text = transX
                '' ''TextBox2.Text = transY

                ''이동량만큼 이미지사이즈가 변한다고 생각하면 되므로...
                ''새로운 크기(nw,nh)의 이미지를 만들면...
                Dim nw, nh As Integer
                nw = img.Width + transX
                nh = img.Height + transY
                Dim img_trans As Bitmap = New Bitmap(nw, nh)

                ''정보를 담을 배열을 준비하면....
                Dim pixels(img.Width * img.Height - 1) As Integer
                Dim pixels_trans(nw * nh - 1) As Integer

                '좌표계 변환을 위해서는 이차원배열로 변환해주어야 하는데 준비하면....
                '둘다 준비해주고.....
                Dim pixels_2d(img.Height - 1, img.Width - 1) As Integer
                Dim pixels_trans_2d(nh - 1, nw - 1) As Integer


                '이제 원본이미지와 이동이미지의 픽셀정보를 가져오면.....
                Dim bmd As BitmapData = img.LockBits(New Rectangle _
                                           (0, 0, img.Width, img.Height), _
                                            Imaging.ImageLockMode.ReadOnly, _
                                              Imaging.PixelFormat.Format32bppArgb)
                Dim scan0 As IntPtr = bmd.Scan0
                Marshal.Copy(scan0, pixels, 0, pixels.Length)

                Dim bmd_trans As BitmapData = img_trans.LockBits(New Rectangle(0, 0, nw, nh), _
                                                       Imaging.ImageLockMode.WriteOnly, _
                                                            PixelFormat.Format32bppArgb)
                Dim scan0_trans As IntPtr = bmd_trans.Scan0
                Marshal.Copy(scan0_trans, pixels_trans, 0, pixels_trans.Length)


                '이제부터 약간 머리가 아픈데....픽셀정보는 일차원배열이고 
                '좌표계변환을 위해서는 사실 이차원배열이 편하죠.....
                '그래서 일차원배열을 이차원배열로 변환해주어야 합니다.
                For j As Integer = 0 To img.Height - 1
                    For i As Integer = 0 To img.Width - 1
                        pixels_2d(j, i) = pixels(j * img.Width + i)
                    Next
                Next

                ''자 이제 정말로 이동하면....
                ''항상 역방향매핑개념으로 처리해야 하므로
                ''이동영상의 입장에서....

                Dim x, y As Integer
                For j As Integer = 0 To nh - 1
                    For i As Integer = 0 To nw - 1
                        ''이제 원영상의 좌표를 구하면....
                        x = i - transX
                        y = j - transY
                        ''구한 좌표가 원영상에 있는지 확인....
                        If (x >= 0 And x < img.Width And y >= 0 And y < img.Height) Then
                            pixels_trans_2d(j, i) = pixels_2d(y, x)
                        End If
                    Next
                Next

                ''이제 이동영상의 정보가 pixels_trans_2d()에 있으니까
                ''이 2차원배열을 일차원배열로 바꾸어주어야.....
                For j As Integer = 0 To nh - 1
                    For i As Integer = 0 To nw - 1
                        pixels_trans(j * nw + i) = pixels_trans_2d(j, i)
                    Next

                Next
                '다시 돌려주면...
                Marshal.Copy(pixels, 0, scan0, pixels.Length)
                img.UnlockBits(bmd)
                Marshal.Copy(pixels_trans, 0, scan0_trans, pixels_trans.Length)
                img_trans.UnlockBits(bmd_trans)

                Translation.PictureBoxTrans.Image = img_trans
                Translation.Show()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    ''마우스를 놓았을때 그림을 이동시키는 코드
    Private Sub PictureBoxSource_MouseUp(ByVal sender As System.Object, _
                                         ByVal e As System.Windows.Forms.MouseEventArgs) _
                                     Handles PictureBoxSource.MouseUp
       
        ''냉무....MouseMove로 전환된 상태....
    End Sub

    '확대......
    Private Sub ButtonScale_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                                                Handles ButtonScale.Click
        '확대비는 입력된 값으로 하고...
        '확대방법은 콤보박스의 선택값으로 합니다...
        ''그리고 확대는 확대클래스를 추가하여 수행합니다...
        ''나중에 사용해야 하니깐....

        Dim img As New Bitmap(PictureBoxSource.Image)
        ''Scale클래스로부터 인스턴스화하면...
        Dim myscale As New Scale

        ''시간경과를 보면..
        Dim dt As DateTime = DateTime.Now
        ''그리고 확대 프로그레스바를 연결시키면...
        ''대부분의 작업은 Scale 클래스에서 진행되므로...
        Try
            myscale.sca_ratio = Val(TextBoxScale.Text)
            Dim interpol As String = ComboBoxScale.Text
            ''여기서 interpol은 보간법의 종류....

            ''''보간법 종류를 인수로 만들어서 함수를 호출하고...
            '''''함수내부에서 이를 처리하는 것이 좋을듯......
            Select Case interpol
                Case "최근방법"
                    PictureBoxScale.Image = myscale.Scale_Inter(img, 0)
                Case "선형보간법"
                    PictureBoxScale.Image = myscale.Scale_Inter(img, 1)
            End Select


            ProgressBarScale.Value += 15
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Dim ts As TimeSpan = dt.Subtract(DateTime.Now)
        TextBoxSpan.Text = ts.ToString

    End Sub

    Private Sub FormMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ''보간법 선택....
        ComboBoxScale.Items.Add("최근방법")
        ComboBoxScale.Items.Add("선형보간법")
        ComboBoxScale.Text = ComboBoxScale.Items.Item(0)
       
    End Sub

    
    Private Sub ButtonRotation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRotation.Click

        Dim img As New Bitmap(PictureBoxSource.Image)
        Dim myrotation As New Rotation

        Dim angle As Integer = Val(TextBoxAngle.Text)
        RotationForm.PictureBoxRotation.Image = myrotation.Img_Rotation(img, angle)

        RotationForm.Show()

    End Sub

    
    Private Sub ButtonPersp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPersp.Click

        원근변환창.Show()

    End Sub
End Class
