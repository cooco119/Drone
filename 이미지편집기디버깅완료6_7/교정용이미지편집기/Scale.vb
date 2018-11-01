Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Public Class Scale
    '먼저 확대비와 확대방법에 관한 속성값을 정의합니다....
    Public sca_ratio As Single
    '그리고 확대와 관련된 메스드를 정의합니다.
    '결과가 비트맵이미지이므로 함수로 처리하죠....
    '인수는 일단 타겟이미지가 되고....
    '확대방법과 관련해서는 함수를 따로 준비하는 걸로 변경....
    '처음의도는 조건문을 사용하려고 했지만....

    ''프로그레스바관련해서는....
    ''각 단계마다 타임스팬을 계산해서 정확하게 하도록 하고
    ''일단 대략 정하면.....

    ''보간법의 경우 준비과정은 같으므로 실제 계산하는 부분만...
    ''case문으로 처리......그럼 일단 이름부터 바꾸면....
    ''그리고 인수로 보간법의 종류까지 넘어와야 하므로...

    Public Function Scale_Inter(ByVal img As Bitmap, ByVal type As Integer) As Bitmap
        '일단 입력영상에 대한 준비부터
        ''여기서 type은 보간법의 종류
        Dim pixels(img.Height * img.Width - 1) As Integer
        Dim pixels_2d(img.Height - 1, img.Width - 1) As Integer
        '그리고 확대이미지에 대한 준비는....
        '먼저 픽셀의 크기를 정하고
        Dim sca_h, sca_w As Integer
        sca_h = CInt(sca_ratio * img.Height)
        sca_w = CInt(sca_ratio * img.Width)
        ''디버깅용
        ''MessageBox.Show("Step1 passed")

        FormMain.TextBox확대치수.Text = "높이= " & sca_h & " ,너비= " & sca_w

        '확대된 이미지의 픽셀을 담을 배열을 정의해주면...
        Dim pixels_scale(sca_h * sca_w - 1) As Integer
        Dim pixels_scale_2d(sca_h - 1, sca_w - 1) As Integer

        '그 다음으로 확대영상 비트맵이미지를 만들죠....
        '여기서 에러가 있는듯....
        '비트맵이미지에서 크기는 width먼저 height
        '' ''Dim img_scale As New Bitmap(sca_h, sca_w)
        Dim img_scale As Bitmap = New Bitmap(sca_w, sca_h)

        ''프로그레스바 관련해서..1단계인 준비단계 
        FormMain.ProgressBarScale.Value = 25
        ''디버깅용
        ''MessageBox.Show("step2 passed")

        '준비는 끝났고....
        '입력영상인 img로부터 픽셀정보를 가져오면....읽어오기만하므로
        Dim bmd As BitmapData = img.LockBits(New Rectangle(0, 0, img.Width, img.Height), _
                                             ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb)
        Dim scan0 As IntPtr = bmd.Scan0
        ''사실 bmd에서 stride도 가져와야 하지만 픽셀당 32bit형식을 사용하므로
        ''stride는 width와 동일하여 굳이 가져오지 않음....

        ''pixels()에 저장하면...
        Marshal.Copy(scan0, pixels, 0, pixels.Length)
        ''그리고 이차원배열로 전환하면...
        For j As Integer = 0 To img.Height - 1
            For i As Integer = 0 To img.Width - 1
                pixels_2d(j, i) = pixels(j * img.Width + i)
            Next
        Next
        ''디버깅용...
        ''MessageBox.Show("Step3 passed")

        ''프로그레스바 관련해서
        ''배열전환반복문에 시간이 소요되므로 한 20%정도추가...
        FormMain.ProgressBarScale.Value += 20

        ''이제 확대영상의 픽셀데이터를 준비하면....
        ''아래부분이 보간법의 종류에 따라 달라진다...
        ''자세한 사항은 http://blog.daum.net/shksjy/219 참고하세요.....

        Try
            ''인수로 넘어온 type의 값에 따라 분기해야 하므로
            ''읽기 쉽게 Select Case문을 사용...
            ''여기서 최근방이웃법을 사용하므로....
            ''0은 최근방법.... 1은 양선형보간법... 
            Select Case type
                Case 0
                    For j As Integer = 0 To sca_h - 1
                        For i As Integer = 0 To sca_w - 1
                            Dim x, y As Integer
                            ''''억....역시 버그는 아주 단순한 곳에 있군요...
                            ''Int대신에 CInt(i/sca_ratio)해서 계속 인덱스초과가....
                            x = Math.Floor(i / sca_ratio)
                            y = Math.Floor(j / sca_ratio)
                            '''''''억억억!!!!!!!!!!!!!!
                            '''''''이런 단순 버그를 ....잡는데 몇시간을....
                            '' '' ''pixels_scale_2d(j, j) = pixels_2d(y, x)
                            pixels_scale_2d(j, i) = pixels_2d(y, x)
                        Next
                    Next
                Case 1
                    For j As Integer = 0 To sca_h - 1
                        For i As Integer = 0 To sca_w - 1
                            ''1은 양선형보간법이므로...
                            ''아래에서 real_x, real_y는 실제 역방향맵핑에서 참조해야할
                            ''실제 원영상의 좌표값...실수형이죠....
                            Dim real_x, real_y, p, q, temp_red, temp_green, temp_blue As Single
                            '' ''Dim red, green, blue As Byte
                            Dim x1, y1, x2, y2 As Integer
                            
                            real_x = i / sca_ratio
                            real_y = j / sca_ratio

                            ''보간법에 필요한 4개의 점의 좌표를 구하면...
                            x1 = Int(real_x)
                            y1 = Int(real_y)

                            ''아래에서 x,y등의 값은 원영상에서의 값인데....
                            ''다음과 같아서 에러....억....

                            '' '' ''If (x1 + 1) = sca_w Then
                            '' '' ''    x2 = sca_w - 1
                            '' '' ''Else
                            '' '' ''    x2 = x1 + 1
                            '' '' ''End If

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

                            ''계산을 위한 소수부분은
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
                            pixels_scale_2d(j, i) = CInt((255 << 24) Or (temp_red << 16) Or _
                                                                  (temp_green << 8) Or temp_blue)
                        Next
                    Next
            End Select

            ''디버깅용...
            ''MessageBox.Show("Step4 passed")

            ''진행과정에서 가장 시간이 많이 소요...
            FormMain.ProgressBarScale.Value += 20
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        ''이제 pixels()쓰임이 다했으므로 다시 돌려주면...
        Marshal.Copy(pixels, 0, scan0, pixels.Length)
        img.UnlockBits(bmd)

        ''암튼 확대영상의 픽셀정보를 준비...
        Dim bmd_scale As BitmapData = img_scale.LockBits(New Rectangle(0, 0, sca_w, sca_h), _
                                        ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb)
        Dim scan0_scale As IntPtr = bmd_scale.Scan0
        Marshal.Copy(scan0_scale, pixels_scale, 0, pixels_scale.Length)

        ''이제 확대영상의 정보를 1차원배열로 전환하면...귀찮긴하네요..ㅋㅋ
        For j As Integer = 0 To sca_h - 1
            For i As Integer = 0 To sca_w - 1
                pixels_scale(j * sca_w + i) = pixels_scale_2d(j, i)
            Next
        Next
        ''디버깅관련
        ''MessageBox.Show("Step5 passed")

        ''프로그레스바 관련
        FormMain.ProgressBarScale.Value += 20

        ''이제 풀어주면...
        Marshal.Copy(pixels_scale, 0, scan0_scale, pixels_scale.Length)
        img_scale.UnlockBits(bmd_scale)

        Return img_scale

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
