Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Public Class Perspective
    ''일단 변수를 선언....
    Dim scaleX, scaleY, transX, transY, transZ, rotX, rotY, rotZ, eye_pos, screen_pos As Single
    Dim size_x, size_y As Integer

    ''기존의 notation과 달리 x축 방향을 j로, y축 방향을 i로 했습니다.
    ''행렬에서 열번호에 대해서 i를...행번호를 j로 하기때문입니다.

    Public Function Persp_Trans(ByVal img As Bitmap) As Bitmap

        ''일단 투시변환된 이미지를 정의하면...
        Dim img_pers As New Bitmap(img.Width, img.Height)

        ''이번 변환은 이동, 확대, 회전, 원근변환을 모두 한꺼번에 수행합니다.
        ''바로 동차좌표계를 이용한 행렬곱을 사용하기 때문입니다.
        ''일단 먼저 변환전 지점과 변환후 지점사이의 관계를 알아야 하죠.

        ''텍스트 박스에 입력된 값을 변수에 할당하면....
        With 원근변환창
            scaleX = Val(.TextBoxScaleX.Text)
            scaleY = Val(.TextBoxScaleY.Text)
            transX = Val(.TextBoxTransX.Text)
            transY = Val(.TextBoxTransY.Text)
            transZ = Val(.TextBoxTransZ.Text)
            rotX = Val(.TextBoxRotX.Text)
            rotY = Val(.TextBoxRotY.Text)
            rotZ = Val(.TextBoxRotZ.Text)
            eye_pos = Val(.TextBoxEye.Text)
            screen_pos = Val(.TextBoxScreen.Text)
        End With

        ''그리고 기존에는 원점을 이미지의 좌측상단점으로 했지만 여기서는 이미지의 중앙을
        ''원점으로 합니다. 이는 원근변환과 관련된 원근투시에서 눈의 위치를 이미지의 중앙에
        ''위치시키기 때문입니다...
        size_x = Int(img.Width / 2)
        size_y = Int(img.Height / 2)
        ''따라서 이미지의 중앙이 원점이 되면 그 좌표는(size_x, size_y)가 됩니다.

        ''디버깅을 위해서 출력.......
        원근변환창.RichTextBox2.Text = "scaleX = " & scaleX & vbCrLf & "scaleY = " & scaleY & vbCrLf & " transX = " & transX & vbCrLf & " transY = " & transY & vbCrLf & " transZ = " & transZ & vbCrLf & "eye_pos= " & eye_pos & vbCrLf & "screen_pos = " & screen_pos & vbCrLf & "size_x = " & size_x & vbCrLf & "size_y = " & size_y & vbCrLf

        ''변환전/후 픽셀정보를 담을 배열을 준비
        Dim pixels(img.Height * img.Width - 1) As Integer
        Dim pixels_pers(img.Height * img.Width - 1) As Integer
        Dim pixels_2d(img.Height - 1, img.Width - 1) As Integer
        Dim pixels_pers_2d(img.Height - 1, img.Width - 1) As Integer

        ''먼저 원영상의 이미지정보를 읽어오면...
        Dim bmd As BitmapData = img.LockBits(New Rectangle(0, 0, img.Width, img.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb)
        Dim scan0 As IntPtr = bmd.Scan0
        Marshal.Copy(scan0, pixels, 0, pixels.Length)

        ''변환영상도 준비하고....
        Dim bmd_pers As BitmapData = img_pers.LockBits(New Rectangle(0, 0, img.Width, img.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb)
        Dim scan0_pers As IntPtr = bmd_pers.Scan0
        Marshal.Copy(scan0, pixels_pers, 0, pixels_pers.Length)

        ''그리고 이차원배열로 전환하면...
        ''역시나 여기서도 i와 j를 수정합니다.....
        For i As Integer = 0 To img.Height - 1
            For j As Integer = 0 To img.Width - 1
                pixels_2d(i, j) = pixels(i * img.Width + j)
            Next
        Next

        ''디버깅목적으로....
        원근변환창.RichTextBox2.Text &= "Height = " & img.Height & vbCrLf & "width= " & img.Width & vbCrLf

        ''이제 역방향매핑을 하면....
        ''그 전에 역방향매핑을 위한 계수가 필요한데요...
        ''변환한후 계산하게 됩니다. 
        ''일단 배열 k()를 정의합니다. 9개의 요소를 가지고 있습니다.
        Dim k(8) As Single

        ''아래에서 배열k()를 사용하게 되는데 이것을 계산하기 위한 
        ''서브루틴의 이름을 Calcu_k()로 하고 인수로 배열k()을 사용합니다.
        Calcu_k(k)

        ''디버깅용.....
        For i As Integer = 0 To 8
            원근변환창.RichTextBox1.Text &= k(i) & vbCrLf
        Next

        ''지금은 전과 달리 변환후의 영상의 크기를 변환전의 크기와 동일하게 함..
        ''혹 벗어나면 매핑이 되지 않으나 정보는 사라지겠죠.....흰색으로 대체...
        ''역시나 양선형보간법사용합니다........
        Dim real_x, real_y, p, q, temp_red, temp_green, temp_blue, homo_x, homo_y, w As Single
        Dim x1, y1, x2, y2 As Integer

        ''아래에서도 수정....
        For i As Integer = -size_y To size_y - 1
            For j As Integer = -size_x To size_x - 1
                ''이부분에서 원영상의 좌표와 변환영상의 좌표사이의 관계를 이용하여
                ''역방향매핑을 해야한다.
                ''동차좌표를 사용하여 표현하면....
                w = k(0) * j + k(1) * i + k(2)
                homo_x = k(3) * j + k(4) * i + k(5)
                homo_y = k(6) * j + k(7) * i + k(8)
                ''이를 직교좌표계로 바꾸면....
                ''바로 이부분이 Perspective Divide입니다...
                real_x = homo_x / w
                real_y = homo_y / w

                If real_y > 0 Then
                    y1 = Int(real_y)
                Else
                    y1 = Int(real_y - 1)
                End If

                If real_x > 0 Then
                    x1 = Int(real_x)
                Else
                    x1 = Int(real_x - 1)
                End If
                p = real_x - x1
                q = real_y - y1

                If x1 = img.Width - 1 Then
                    x2 = img.Width - 1
                Else
                    x2 = x1 + 1
                End If

                If y1 = img.Height - 1 Then
                    y2 = img.Height - 1
                Else
                    y2 = y1 + 1
                End If

                If (x1 >= -size_x And x1 < size_x - 1 And y1 >= -size_y And y1 < size_y - 1) Then

                    ' '' ''이제 계산을 위한 변수는 다 정했는데....
                    ' '' ''컬러영상을 처리하므로 약간 복잡해진다. 양선형보간법의 경우
                    ' '' ''해당좌표의 주위 픽셀값에 가중치를 부여하여 계산하므로
                    ' '' ''실제계산은 R,G,B값에서 이루어진다. 따라서 필요한 주위 4개점의
                    ' '' ''각각의 색영역에서의 값을 추출해주어야 한다.....
                    ' '' ''역시나 자세한 설명은 블로그참조... http://blog.daum.net/shksjy/219

                    'R,G,B값을 추출해주는 함수를 따로 만들어야....
                    '그 함수가 Sub_Red(), Sub_Green(), Sub_Blue() 이다....
                    temp_red = (1.0 - p) * (1.0 - q) * Sub_Red(pixels_2d(y1 + size_y, x1 + size_x)) _
                                + p * (1.0 - q) * Sub_Red(pixels_2d(y1 + size_y, x2 + size_x)) _
                                + (1.0 - p) * q * Sub_Red(pixels_2d(y2 + size_y, x1 + size_x)) _
                                + p * q * Sub_Red(pixels_2d(y2 + size_y, x2 + size_x))
                    ' ''아래 조건문은 일단 주석처리....
                    If temp_red < 0 Then
                        temp_red = 0
                    End If
                    If temp_red > 255 Then
                        temp_red = 255
                    End If


                    temp_green = (1.0 - p) * (1.0 - q) * Sub_Green(pixels_2d(y1 + size_y, x1 + size_x)) _
                                  + p * (1.0 - q) * Sub_Green(pixels_2d(y1 + size_y, x2 + size_x)) _
                                  + (1.0 - p) * q * Sub_Green(pixels_2d(y2 + size_y, x1 + size_x)) _
                                  + p * q * Sub_Green(pixels_2d(y2 + size_y, x2 + size_x))
                    If temp_green < 0 Then
                        temp_green = 0
                    End If
                    If temp_green > 255 Then
                        temp_green = 255
                    End If


                    temp_blue = (1.0 - p) * (1.0 - q) * Sub_Blue(pixels_2d(y1 + size_y, x1 + size_x)) _
                                 + p * (1.0 - q) * Sub_Blue(pixels_2d(y1 + size_y, x2 + size_x)) _
                                 + (1.0 - p) * q * Sub_Blue(pixels_2d(y2 + size_y, x1 + size_x)) _
                                 + p * q * Sub_Blue(pixels_2d(y2 + size_y, x2 + size_x))
                    If temp_blue < 0 Then
                        temp_blue = 0
                    End If
                    If temp_blue > 255 Then
                        temp_blue = 255
                    End If

                    '이제 확대영상의 한 점에 대한 색정보를 알고있으므로 다시 이것을 조합하면....

                    '' ''pixels_scale_2d(j, i) = (255 << 24) Or (red << 16) Or (green << 8) Or blue
                    ''그리고 원점이 달라진 것을 상쇄시키는 것이 바로 아래에서 보는 것처럼
                    ''각각에 size_y,size_x 를 더해주는 것이다.
                    ''이것은 마치 translation과 같다.....
                    pixels_pers_2d(i + size_y, j + size_x) = CInt((255 << 24) Or (temp_red << 16) Or _
                                                          (temp_green << 8) Or temp_blue)
                Else
                    pixels_pers_2d(i + size_y, j + size_x) = 255 << 24 Or 255 << 16 Or 255 << 8 Or 255
                End If

            Next
        Next
        ''원영상을 다시 돌려보내고...
        Marshal.Copy(pixels, 0, scan0, pixels.Length)
        img.UnlockBits(bmd)

        ''지금 변환영상의 정보는 pixels_pers_2d()에 들어있죠. 일단 1차원으로 전환하면...
        For j As Integer = 0 To img.Height - 1
            For i As Integer = 0 To img.Width - 1
                pixels_pers(j * img.Width + i) = pixels_pers_2d(j, i)
            Next
        Next
        ''이제 이정보를 img_pers로 복사해주면.....
        ''변환영상도 돌려주고...
        Marshal.Copy(pixels_pers, 0, scan0_pers, pixels_pers.Length)
        img_pers.UnlockBits(bmd_pers)

        Return img_pers

    End Function

    ''아래에서 k값을 계산하는데 ByRef하여 처리....
    Private Sub Calcu_k(ByRef k() As Single)
        ''행렬연산으로 계산합니다.
        ''여기서 추가로 필요한 변수를 선언하면..4 by 4 정방행열 3개가 필요합니다.
        Dim l(3, 3), m(3, 3), n(3, 3) As Single
        Dim K1, K2, K3, K4, K5, K6, K7, K8, K9 As Single

        ''나중에 회전을 처리하기위해서는
        ''먼저 60분법 angle을 호도법(라디언)으로 바꾸어주어야....
        Dim rad_x As Double = rotX * Math.PI / 180.0
        Dim rad_y As Double = rotY * Math.PI / 180.0
        Dim rad_z As Double = rotZ * Math.PI / 180.0
        ''변환식에 사용될 삼각함수값을 미리 구하면...
        Dim x_cos As Double = Math.Cos(rad_x)
        Dim x_sin As Double = Math.Sin(rad_x)
        Dim y_cos As Double = Math.Cos(rad_y)
        Dim y_sin As Double = Math.Sin(rad_y)
        Dim z_cos As Double = Math.Cos(rad_z)
        Dim z_sin As Double = Math.Sin(rad_z)

        ''여기서 약간의 코드길이를 줄이기 위해서...
        ''대부분의 값이 0이므로 초기화를 0으로 합니다. 초기화하는 서브를 만들어서...
        ''먼저 정규화(Normalization)행렬은
        ''바로 아래 부분이 Model-View부분입니다.
        ''그리고 (1,1)요소에서 -부호는 y축의 경우 Up을 양으로 하기때문입니다.
        SetZero(l)
        l(0, 0) = 1.0 / size_x
        l(1, 1) = -1.0 / size_y
        l(2, 2) = 1
        l(3, 3) = 1
        ''확대/축소변환행렬은
        SetZero(m)
        m(0, 0) = scaleX
        m(1, 1) = scaleY
        m(2, 2) = 1
        m(3, 3) = 1
        ''그다음에는 위의 두 행렬 ㅣ과 m을 행렬곱을 해준다.
        ''행렬곱을 처리하는 서브루틴을 만들어서 처리
        MatrixDot(l, m, n)

        ''디버깅용으로 행렬을 출력해야......
        ''출력하는 것을 서브루틴으로 처리하면.....
        행렬출력(n)

        ''그다음은 이동변환행렬....지금 결과는 행렬n에 있음..
        SetZero(l)
        l(0, 0) = 1
        l(1, 1) = 1
        l(2, 2) = 1
        l(3, 3) = 1
        ''이제 이동량을 나타내는 이동벡터
        l(3, 0) = transX
        l(3, 1) = transY
        l(3, 2) = transZ
        ''이제 행렬L은 이동변환을 나타냅니다.
        ''이 L을 행렬 N과 곱해주고 그 결과를 M에....순서에 주의
        MatrixDot(n, l, m)
        행렬출력(m)

        ''다음은 회전행렬...먼저 z축, 그다음 x축, 다음은 y축
        SetZero(n)
        n(0, 0) = z_cos
        n(1, 0) = -z_sin
        n(0, 1) = z_sin
        n(1, 1) = z_cos
        n(2, 2) = 1
        n(3, 3) = 1
        ''이제 행렬 m에 행렬 n을 곱해서 결과를 행렬 l에 저장....
        MatrixDot(m, n, l)
        행렬출력(l)

        ''x축 회전행렬 m을 구하면....
        SetZero(m)
        m(0, 0) = 1
        m(1, 1) = x_cos
        m(2, 1) = -x_sin
        m(1, 2) = x_sin
        m(2, 2) = x_cos
        m(3, 3) = 1
        ''행렬곱...
        MatrixDot(l, m, n)
        행렬출력(n)

        ''y축 회전행렬 l을 구하면...
        SetZero(l)
        l(0, 0) = y_cos
        l(2, 0) = -y_sin
        l(1, 1) = 1
        l(0, 2) = y_sin
        l(2, 2) = y_cos
        l(3, 3) = 1
        ''행렬곱...
        MatrixDot(n, l, m)
        행렬출력(m)

        ''다음은 시점좌표 변환행렬....
        SetZero(n)
        n(0, 0) = 1
        n(1, 1) = 1
        n(2, 2) = -1
        n(3, 2) = eye_pos
        n(3, 3) = 1
        ''행렬곱
        MatrixDot(m, n, l)
        행렬출력(l)

        ''그다음으로 투시변환행렬....
        '
        SetZero(m)
        m(0, 0) = 1
        m(1, 1) = 1
        m(2, 2) = 1 / screen_pos
        m(3, 2) = -1
        m(2, 3) = 1 / screen_pos
        ''행렬곱...
        MatrixDot(l, m, n)
        행렬출력(n)

        ''마지막으로 정규화역행렬....
        SetZero(l)
        l(0, 0) = size_x
        l(1, 1) = -size_y
        l(2, 2) = 1
        l(3, 3) = 1
        ''마지막 행렬곱...
        MatrixDot(n, l, m)
        행렬출력(m)

        ''이제 역행렬을 구해야.....
        ''우리가 필요한 것은 동차좌표계에서 x, y, w이므로 z는 제외하였다.... 
        K1 = m(0, 3)
        K2 = m(1, 3)
        K3 = m(3, 3)
        K4 = m(0, 0)
        K5 = m(1, 0)
        K6 = m(3, 0)
        K7 = m(0, 1)
        K8 = m(1, 1)
        K9 = m(3, 1)

        ''바로 아래의 배열k()에 역행렬의 원소가 들어 있다....
        원근변환창.RichTextBox2.Text &= "k1= " & K1 & vbCrLf & "k2= " & K2 & vbCrLf & "k3= " & K3 & vbCrLf & "k4= " & K4 & vbCrLf & "k5= " & K5 & vbCrLf & "k6= " & K6 & vbCrLf & "k7= " & K7 & vbCrLf & "k8= " & K8 & vbCrLf

        k(0) = K7 * K2 - K8 * K1
        k(1) = K5 * K1 - K4 * K2
        k(2) = K4 * K8 - K7 * K5
        k(3) = K8 * K3 - K9 * K2
        k(4) = K6 * K2 - K5 * K3
        k(5) = K5 * K9 - K8 * K6
        k(6) = K9 * K1 - K7 * K3
        k(7) = K4 * K3 - K6 * K1
        k(8) = K7 * K6 - K4 * K9

    End Sub

    ''행렬을 0으로 초기화....
    Private Sub SetZero(ByRef matrix(,) As Single)
        For j As Integer = 0 To 3
            For i As Integer = 0 To 3
                matrix(j, i) = 0
            Next
        Next
    End Sub
    ''행렬곱을 수행하는 서브...인수순서에 주의 ByRef로 처리....
    ''행l,m,n은 순서대로 입력1, 입력2, 그리고 결과출력행렬....
    Private Sub MatrixDot(ByRef l(,) As Single, ByRef m(,) As Single, ByRef n(,) As Single)
        Dim p As Single
        For i As Integer = 0 To 3
            For j As Integer = 0 To 3
                p = 0
                For k As Integer = 0 To 3
                    p = p + l(i, k) * m(k, j)
                Next
                n(i, j) = p
            Next
        Next
    End Sub


    ''아래에서 pixel은 해당좌표의 정보....
    ''비트연산을 통해서 색정보를 추출......
    Private Function Sub_Red(ByVal pixel As Integer) As Byte
        Dim red As Byte
        red = (pixel >> 16) And &HFF
        Return red
    End Function
    Private Function Sub_Green(ByVal pixel As Integer) As Byte
        Dim green As Byte
        green = (pixel >> 8) And &HFF
        Return green
    End Function
    Private Function Sub_Blue(ByVal pixel As Integer) As Byte
        Dim blue As Byte
        blue = pixel And &HFF
        Return blue
    End Function

    Private Sub 행렬출력(ByVal n As Single(,))
        원근변환창.RichTextBox2.Text &= " n00 =  " & n(0, 0) & "   n01 =  " & n(0, 1) & "  n02 =  " & n(0, 2) & "  n03 =  " & n(0, 3) & vbCrLf
        원근변환창.RichTextBox2.Text &= " n10 =  " & n(1, 0) & "   n11 =  " & n(1, 1) & "  n12 =  " & n(1, 2) & "  n13 =  " & n(1, 3) & vbCrLf
        원근변환창.RichTextBox2.Text &= " n20 =  " & n(2, 0) & "   n21 =  " & n(2, 1) & "  n22 =  " & n(2, 2) & "  n23 =  " & n(2, 3) & vbCrLf
        원근변환창.RichTextBox2.Text &= " n30 =  " & n(3, 0) & "   n31 =  " & n(3, 1) & "  n32 =  " & n(3, 2) & "  n33 =  " & n(3, 3) & vbCrLf & vbCrLf
    End Sub

End Class
