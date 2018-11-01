Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Public Class Rotation
    '속성값으로 회전각도를 생각하면...
    Public angle As Integer
    ''비베넷에서는 수학함수를 제공하는데 Math 클래스의 메스드로 제공....
    ''원주율 파이는 Math.PI

    Public Function Img_Rotation(ByVal img As Bitmap, ByVal angle As Integer) As Bitmap
        ''기하학적 변환에서는 역방향 매칭을 사용하므로 
        ''가장 먼저 결정해야 할 것은 회전된 영상의 크기이다.
        ''원영상의 네 꼭지점을 회전시킨 후 회전된 좌표에서
        ''x축좌표의 최대값과 최소값의 차이가 회전영상의 너비(즉 Width)가 되고
        ''y축 좌표의 최대, 최소의 차이가 높이(Height)가 된다.
        ''이를 rot_w, rot_h라고 하자.

        RotationForm.TextBoxAngle.Text = angle

        ''먼저 60분법 angle을 호도법(라디언)으로 바꾸어주어야....
        Dim rad As Double = angle * Math.PI / 180.0
        ''변환식에 사용될 삼각함수값을 미리 구하면...
        Dim cos_value As Double = Math.Cos(rad)
        Dim sin_value As Double = Math.Sin(rad)

        ''원영상의 네 꼭지점은....
        ''(0,0), (img.Width,0) , (img.WIdth, img.Height), (0 , img_Height)
        ''이 네점을 angle만큼 회전시키면....
        ''먼저 (img.width, 0)을 회전시키면...좌표값이 (cos_value*img.Width, sin_value*img.Width)
        ''(0, img_Height)를 회전시키면...좌표가 (-sin_value*img_Height, cos_value*img_Height)
        ''(img.Width, img.Height)를 회전시키면 좌표가...
        ''                             (cos_value*img_Width - sin_value*img_Height,
        ''                                sin_value*img_Width + cos_value*img_Height)

        ''x좌표와 y좌표의 최대최소를 정의하고 초기화하면....
        ''초기화라기 보다 원점을 회전이동시켰다고 생각해도 될듯....
        Dim minx As Integer = 0
        Dim miny As Integer = 0
        Dim maxx As Integer = 0
        Dim maxy As Integer = 0

        ''최대/최소값을 구하면.....
        ''각 꼭지점을 회전한후 그 좌표값을 각각 nx,ny라고 하면..
        ''아래에서 정수화하는 부분은 약간 손질이 필요할지도.....
        Dim nx, ny As Integer
        nx = CInt(cos_value * img.Width)
        ny = CInt(sin_value * img.Width)
        If maxx < nx Then maxx = nx
        If minx > nx Then minx = nx
        If maxy < ny Then maxy = ny
        If miny > ny Then miny = ny

        nx = CInt(-sin_value * img.Height)
        ny = CInt(cos_value * img.Height)
        If maxx < nx Then maxx = nx
        If minx > nx Then minx = nx
        If maxy < ny Then maxy = ny
        If miny > ny Then miny = ny

        nx = CInt(cos_value * img.Width - sin_value * img.Height)
        ny = CInt(sin_value * img.Width + cos_value * img.Height)
        If maxx < nx Then maxx = nx
        If minx > nx Then minx = nx
        If maxy < ny Then maxy = ny
        If miny > ny Then miny = ny

        ''이제 회전영상의 크기가 결정되었네요....
        Dim rot_w, rot_h As Integer

        rot_w = maxx - minx
        rot_h = maxy - miny

        ''이 크기를 가지는 이미지를 정의하면...
        ''img_rot이 회전이미지.....
        Dim img_rot As Bitmap = New Bitmap(rot_w, rot_h)

        ''디버깅용...
        RotationForm.TextBoxrot_w.Text = rot_w
        RotationForm.TextBoxrot_h.Text = rot_h

        ''픽셀정보를 담을 배열을 준비하면...
        Dim pixels(img.Height * img.Width - 1) As Integer
        Dim pixels_rot(rot_h * rot_w - 1) As Integer
        ''2차원 배열은...
        ''사실 이동이 아니므로 일차원배열을 사용해도 될 것 같은데...
        ''나중에는 이동/확대/확대가 동시에 이루어져야 하므로 
        ''통일성을 위해서 그냥 그대로...
        Dim pixels_2d(img.Height - 1, img.Width - 1) As Integer
        Dim pixels_rot_2d(rot_h - 1, rot_w - 1) As Integer

        ''이제 원영상과 확대영상을 불러오면....
        Dim bmd As BitmapData = img.LockBits(New Rectangle(0, 0, img.Width, img.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb)
        Dim scan0 As IntPtr = bmd.Scan0

        Dim rot_bmd As BitmapData = img_rot.LockBits(New Rectangle(0, 0, rot_w, rot_h), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb)
        Dim rot_scan0 As IntPtr = rot_bmd.Scan0

        ''정보를 가져오고....
        Marshal.Copy(scan0, pixels, 0, pixels.Length)
        Marshal.Copy(rot_scan0, pixels_rot, 0, pixels_rot.Length)

        ''그리고 이차원배열로 전환하면...
        For j As Integer = 0 To img.Height - 1
            For i As Integer = 0 To img.Width - 1
                pixels_2d(j, i) = pixels(j * img.Width + i)
            Next
        Next

        ''이제 회전한 이미지와 원영상을 역방향매핑을 하면....
        Dim real_x, real_y, p, q, temp_red, temp_green, temp_blue As Single
        Dim x1, x2, y1, y2 As Integer

        For j As Integer = 0 To rot_h - 1
            For i As Integer = 0 To rot_w - 1

                ''원영상에 대응하는 실수좌표는...
                real_x = (i + minx) * cos_value + (j + miny) * sin_value
                real_y = -(i + minx) * sin_value + (j + miny) * cos_value

                ''위의 좌표가 원본영상에 포함되는지 먼저 검사.
                ''포함되지 않으면 넘어가야 하니까...

                If (real_x < 0 Or real_x > img.Width - 1 Or real_y < 0 Or real_y > img.Height - 1) Then
                    Continue For
                End If

                ''이제부터는 선형보간법을 적용.....
                x1 = Int(real_x)
                y1 = Int(real_y)

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

                p = real_x - x1
                q = real_y - y1

                ' '' ''이제 계산을 위한 변수는 다 정했는데....
                ' '' ''컬러영상을 처리하므로 약간 복잡해진다. 양선형보간법의 경우
                ' '' ''해당좌표의 주위 픽셀값에 가중치를 부여하여 계산하므로
                ' '' ''실제계산은 R,G,B값에서 이루어진다. 따라서 필요한 주위 4개점의
                ' '' ''각각의 색영역에서의 값을 추출해주어야 한다.....
                ' '' ''역시나 자세한 설명은 블로그참조... http://blog.daum.net/shksjy/219

                'R,G,B값을 추출해주는 함수를 따로 만들어야....
                '그 함수가 Sub_Red(), Sub_Green(), Sub_Blue() 이다....
                temp_red = (1.0 - p) * (1.0 - q) * Sub_Red(pixels_2d(y1, x1)) _
                            + p * (1.0 - q) * Sub_Red(pixels_2d(y1, x2)) _
                            + (1.0 - p) * q * Sub_Red(pixels_2d(y2, x1)) _
                            + p * q * Sub_Red(pixels_2d(y2, x2))
                ''아래 조건문은 일단 주석처리....
                ''If temp_red < 0 Then
                ''    temp_red = 0
                ''End If
                ''If temp_red > 255 Then
                ''    temp_red = 255
                ''End If


                temp_green = (1.0 - p) * (1.0 - q) * Sub_Green(pixels_2d(y1, x1)) _
                              + p * (1.0 - q) * Sub_Green(pixels_2d(y1, x2)) _
                              + (1.0 - p) * q * Sub_Green(pixels_2d(y2, x1)) _
                              + p * q * Sub_Green(pixels_2d(y2, x2))
                ''If temp_green < 0 Then
                ''    temp_green = 0
                ''End If
                ''If temp_green > 255 Then
                ''    temp_green = 255
                ''End If


                temp_blue = (1.0 - p) * (1.0 - q) * Sub_Blue(pixels_2d(y1, x1)) _
                             + p * (1.0 - q) * Sub_Blue(pixels_2d(y1, x2)) _
                             + (1.0 - p) * q * Sub_Blue(pixels_2d(y2, x1)) _
                             + p * q * Sub_Blue(pixels_2d(y2, x2))
                ''If temp_blue < 0 Then
                ''    temp_blue = 0
                ''End If
                ''If temp_blue > 255 Then
                ''    temp_blue = 255
                ''End If

                '이제 확대영상의 한 점에 대한 색정보를 알고있으므로 다시 이것을 조합하면....

                '' ''pixels_scale_2d(j, i) = (255 << 24) Or (red << 16) Or (green << 8) Or blue
                pixels_rot_2d(j, i) = CInt((255 << 24) Or (temp_red << 16) Or _
                                                      (temp_green << 8) Or temp_blue)
            Next
        Next
        ''원영상을 다시 돌려보내고...
        Marshal.Copy(pixels, 0, scan0, pixels.Length)
        img.UnlockBits(bmd)

        ''회전영상에 정보를 넣으면.....
        For j As Integer = 0 To rot_h - 1
            For i As Integer = 0 To rot_w - 1
                ''잘 생각해보면...ㅋㅋㅋ
                ''억....
                '' '' ''pixels_rot(j * rot_w * i) = pixels_rot_2d(j, i)
                pixels_rot(j * rot_w + i) = pixels_rot_2d(j, i)
            Next
        Next

        Marshal.Copy(pixels_rot, 0, rot_scan0, pixels_rot.Length)
        img_rot.UnlockBits(rot_bmd)

        Return img_rot

    End Function



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

End Class
