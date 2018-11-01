clear
% screen size
L = 160;
H = 90;

% Camera spec
HFOV = deg2rad(70);
VFOV = deg2rad(43);

% Camera state
incl = 0:90;
incl = deg2rad(incl);

% calculation of stretched angle
for i = 1:length(incl)
    theta(i) = atan(cos(incl(i))*tan(1/2*HFOV));
end


% line info
line_y = -H:H;
for i = 1:length(line_y)
    line_x(i) = 100;
end

% figure(1)
% plot(line_x, line_y)
% axis equal
% xlim([-300, 300]);
% ylim([-H, H]);

% Transformation
for i = 1:length(line_y)
    for j = 1:length(incl)
        x(i,j) = line_x(i) * L/(L+(H+line_y(i))*tan(theta(j)));
        y(i,j) = line_y(i);   
    end
end

for i = 1:length(incl)
    p(:,i) = polyfit(x(:,i), y(:,i), 1);
    yfit(:,i) = polyval(p(:,i), x(:,i));
end
% figure(2)
% plot(x,y)
% h = line(line_x, line_y);
% direction = [0 0 1];
% rotate(h, direction, rad2deg(theta), [line_x(1),-H,0]);
% axis equal
% xlim([-L, L]);
% ylim([-H, H]);
% hold on
% plot(x, yfit);
% disp(rad2deg(tan(p(1))))

f = fopen('angle.txt', 'a');
for i = 1:length(incl)
    angle(i) = mod(rad2deg(atan(p(1,i)))+180, 360);
    fprintf(f,'angle:%d\t%f\r\n', i-1, angle(i));
end
fclose(f);

