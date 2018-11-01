Fs = 10;
T = 1/Fs;

m1 = csvread('20180123_103802.csv');
m2 = csvread('Kp_190.csv');
m3 = csvread('Kp_200.csv');
m4 = csvread('Kp_210.csv');
m5 = csvread('Kp_220.csv');

t1 = m1(:,1);
y1 = m1(:,2);

t2 = m2(:,1);
y2 = m2(:,2);

t3 = m3(:,1);
y3 = m3(:,2);

t4 = m4(:,1);
y4 = m4(:,2);

t5 = m5(:,1);
y5 = m5(:,2);

Y1 = fft(y1);
Y2 = fft(y2);
Y3 = fft(y3);
Y4 = fft(y4);
Y5 = fft(y5);

L1 = length(t1);
L2 = length(t2);
L3 = length(t3);
L4 = length(t4);
L5 = length(t5);

P2_1 = abs(Y1/L1);
P1_1 = P2_1(1:L1/2+1);
P1_1(2:end-1) = 2*P1_1(2:end-1);

P2_2 = abs(Y2/L2);
P1_2 = P2_2(1:L2/2+1);
P1_2(2:end-1) = 2*P1_2(2:end-1);

P2_3 = abs(Y3/L3);
P1_3 = P2_3(1:L3/2+1);
P1_3(2:end-1) = 2*P1_3(2:end-1);

P2_4 = abs(Y4/L4);
P1_4 = P2_4(1:L4/2+1);
P1_4(2:end-1) = 2*P1_4(2:end-1);

P2_5 = abs(Y5/L5);
P1_5 = P2_5(1:L5/2+1);
P1_5(2:end-1) = 2*P1_5(2:end-1);

f1 = Fs*(0:(L1/2))/L1;
f2 = Fs*(0:(L2/2))/L2;
f3 = Fs*(0:(L3/2))/L3;
f4 = Fs*(0:(L4/2))/L4;
f5 = Fs*(0:(L5/2))/L5;

figure();
plot(f1,P1_1)
title('kp180')
figure();
plot(f2,P1_2)
title('kp190')
figure();
plot(f3,P1_3)
title('kp200')
figure();
plot(f4,P1_4)
title('kp210')
figure();
plot(f5,P1_5)
title('kp220')

% % plotting
% figure();
% plot(t1,y1);
% title('kp100');
% figure();
% plot(t2,y2);
% title('kp200');
% figure();
% plot(t3,y3);
% title('kp300');
% figure();
% plot(t4,y4);
% title('kp400');
% % figure();
% % plot(t5,y5);
% % title('kp100');