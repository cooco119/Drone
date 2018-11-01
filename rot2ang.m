r = [ 0.035185 	 0.999139 	 0.021998; 0.521141 	 0.000439 	 -0.853471;  -0.852745 	 0.041493 	 -0.520676 ];
sy = sqrt(r(1,1)^2 + r(2,1)^2);

x = atan2(r(3,2),r(3,3));
y = atan2(-r(3,1),sy);
z = atan2(r(2,1),r(1,1));