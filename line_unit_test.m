clear
% screen size
L = 160;
H = 90;

% Camera spec
HFOV = deg2rad(70);
VFOV = deg2rad(43);

% Camera state
incl = 0;
incl = deg2rad(incl);

% calculation of stretched angle
theta = atan(cos(incl)*tan(1/2*HFOV));


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
    x(i) = line_x(i) * L/(L+(H+line_y(i))*tan(theta));
    y(i) = line_y(i);   

end

p = polyfit(x, y, 1);
yfit= polyval(p, x);

figure(2)
plot(x,y)
% h = line(line_x, line_y);
% direction = [0 0 1];
% rotate(h, direction, rad2deg(theta), [line_x(1),-H,0]);
axis equal
xlim([-L, L]);
ylim([-H, H]);
hold on
plot(x, yfit);
disp(rad2deg(tan(p(1))))


