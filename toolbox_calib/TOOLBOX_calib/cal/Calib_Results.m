% Intrinsic and Extrinsic Camera Parameters
%
% This script file can be directly executed under Matlab to recover the camera intrinsic and extrinsic parameters.
% IMPORTANT: This file contains neither the structure of the calibration objects nor the image coordinates of the calibration points.
%            All those complementary variables are saved in the complete matlab data file Calib_Results.mat.
% For more information regarding the calibration model visit http://www.vision.caltech.edu/bouguetj/calib_doc/


%-- Focal length:
fc = [ 1382.107824756591100 ; 1384.932070793606700 ];

%-- Principal point:
cc = [ 978.643406621055420 ; 587.248964270587750 ];

%-- Skew coefficient:
alpha_c = 0.000000000000000;

%-- Distortion coefficients:
kc = [ 0.098673983402069 ; -0.514133380392586 ; -0.002450172341884 ; -0.001570194810182 ; 0.000000000000000 ];

%-- Focal length uncertainty:
fc_error = [ 18.585941173407065 ; 19.848657711607043 ];

%-- Principal point uncertainty:
cc_error = [ 22.636949607721391 ; 33.457887437319080 ];

%-- Skew coefficient uncertainty:
alpha_c_error = 0.000000000000000;

%-- Distortion coefficients uncertainty:
kc_error = [ 0.038083098588841 ; 0.147382435149145 ; 0.007053051179412 ; 0.005429785807178 ; 0.000000000000000 ];

%-- Image size:
nx = 1920;
ny = 1080;


%-- Various other variables (may be ignored if you do not use the Matlab Calibration Toolbox):
%-- Those variables are used to control which intrinsic parameters should be optimized

n_ima = 31;						% Number of calibration images
est_fc = [ 1 ; 1 ];					% Estimation indicator of the two focal variables
est_aspect_ratio = 1;				% Estimation indicator of the aspect ratio fc(2)/fc(1)
center_optim = 1;					% Estimation indicator of the principal point
est_alpha = 0;						% Estimation indicator of the skew coefficient
est_dist = [ 1 ; 1 ; 1 ; 1 ; 0 ];	% Estimation indicator of the distortion coefficients


%-- Extrinsic parameters:
%-- The rotation (omc_kk) and the translation (Tc_kk) vectors for every calibration image and their uncertainties

%-- Image #1:
omc_1 = [ 2.461606e+00 ; 5.500133e-01 ; -3.409037e-01 ];
Tc_1  = [ -4.098933e+01 ; 2.246814e+01 ; 4.760221e+02 ];
omc_error_1 = [ 2.385992e-02 ; 9.975382e-03 ; 2.285491e-02 ];
Tc_error_1  = [ 7.797337e+00 ; 1.147901e+01 ; 6.538753e+00 ];

%-- Image #2:
omc_2 = [ 2.585588e+00 ; 5.325706e-02 ; -1.684189e-01 ];
Tc_2  = [ 6.344926e+01 ; 3.083575e+01 ; 3.974511e+02 ];
omc_error_2 = [ 2.416199e-02 ; 8.040873e-03 ; 2.762103e-02 ];
Tc_error_2  = [ 6.283111e+00 ; 9.634559e+00 ; 6.515740e+00 ];

%-- Image #3:
omc_3 = [ 1.916432e+00 ; -1.299025e+00 ; 7.758430e-01 ];
Tc_3  = [ -5.233954e+01 ; 9.694055e+01 ; 5.677397e+02 ];
omc_error_3 = [ 2.120862e-02 ; 1.766209e-02 ; 2.221999e-02 ];
Tc_error_3  = [ 9.406921e+00 ; 1.377049e+01 ; 8.768959e+00 ];

%-- Image #4:
omc_4 = [ 1.291998e+00 ; -2.268086e+00 ; 9.725004e-01 ];
Tc_4  = [ -6.739032e+01 ; 1.983877e+01 ; 5.707132e+02 ];
omc_error_4 = [ 1.473313e-02 ; 2.157331e-02 ; 2.897672e-02 ];
Tc_error_4  = [ 9.279361e+00 ; 1.376954e+01 ; 8.951724e+00 ];

%-- Image #5:
omc_5 = [ 3.063961e-01 ; -3.056033e+00 ; 4.896948e-01 ];
Tc_5  = [ -1.077556e+02 ; -1.896842e+01 ; 6.179822e+02 ];
omc_error_5 = [ 9.715413e-03 ; 2.630923e-02 ; 4.495031e-02 ];
Tc_error_5  = [ 1.014235e+01 ; 1.491855e+01 ; 1.051978e+01 ];

%-- Image #6:
omc_6 = [ 2.881643e+00 ; -7.738308e-01 ; 7.281445e-02 ];
Tc_6  = [ 5.697727e+01 ; -1.201609e+02 ; 8.046992e+02 ];
omc_error_6 = [ 3.242412e-02 ; 1.469335e-02 ; 4.128544e-02 ];
Tc_error_6  = [ 1.323055e+01 ; 1.958194e+01 ; 1.205862e+01 ];

%-- Image #7:
omc_7 = [ 1.902913e+00 ; -7.182159e-01 ; 6.622795e-01 ];
Tc_7  = [ 9.391960e+01 ; 6.472327e+01 ; 4.227104e+02 ];
omc_error_7 = [ 2.148744e-02 ; 1.648367e-02 ; 1.867690e-02 ];
Tc_error_7  = [ 6.979204e+00 ; 1.038219e+01 ; 7.079694e+00 ];

%-- Image #8:
omc_8 = [ NaN ; NaN ; NaN ];
Tc_8  = [ NaN ; NaN ; NaN ];
omc_error_8 = [ NaN ; NaN ; NaN ];
Tc_error_8  = [ NaN ; NaN ; NaN ];

%-- Image #9:
omc_9 = [ -9.307084e-02 ; 2.885718e+00 ; -1.112364e+00 ];
Tc_9  = [ -1.052341e+02 ; -1.396083e+01 ; 5.334808e+02 ];
omc_error_9 = [ 1.125942e-02 ; 2.049545e-02 ; 3.609723e-02 ];
Tc_error_9  = [ 8.528049e+00 ; 1.285711e+01 ; 8.512980e+00 ];

%-- Image #10:
omc_10 = [ NaN ; NaN ; NaN ];
Tc_10  = [ NaN ; NaN ; NaN ];
omc_error_10 = [ NaN ; NaN ; NaN ];
Tc_error_10  = [ NaN ; NaN ; NaN ];

%-- Image #11:
omc_11 = [ 1.716663e-01 ; 2.672586e+00 ; -1.490025e+00 ];
Tc_11  = [ -6.368182e+01 ; -2.013570e+01 ; 4.476591e+02 ];
omc_error_11 = [ 1.171636e-02 ; 2.144004e-02 ; 3.288702e-02 ];
Tc_error_11  = [ 7.202254e+00 ; 1.076843e+01 ; 6.189609e+00 ];

%-- Image #12:
omc_12 = [ 1.457290e+00 ; -1.540477e+00 ; 1.033940e+00 ];
Tc_12  = [ 4.772288e+01 ; 7.384858e+01 ; 6.100628e+02 ];
omc_error_12 = [ 1.773785e-02 ; 2.174900e-02 ; 2.181235e-02 ];
Tc_error_12  = [ 1.002018e+01 ; 1.479784e+01 ; 9.240228e+00 ];

%-- Image #13:
omc_13 = [ 2.278183e+00 ; -2.141652e+00 ; 1.146399e-01 ];
Tc_13  = [ -3.606802e+00 ; -7.427618e+01 ; 8.965693e+02 ];
omc_error_13 = [ 3.405441e-02 ; 3.506198e-02 ; 7.159350e-02 ];
Tc_error_13  = [ 1.471203e+01 ; 2.165886e+01 ; 1.406880e+01 ];

%-- Image #14:
omc_14 = [ 2.383480e+00 ; -9.624124e-01 ; -1.294299e-01 ];
Tc_14  = [ 5.215722e+01 ; 6.807161e+01 ; 5.556277e+02 ];
omc_error_14 = [ 2.412745e-02 ; 1.096401e-02 ; 2.724242e-02 ];
Tc_error_14  = [ 9.156705e+00 ; 1.346474e+01 ; 7.852069e+00 ];

%-- Image #15:
omc_15 = [ -2.190913e+00 ; 2.058358e+00 ; 7.345959e-02 ];
Tc_15  = [ 1.078834e+01 ; -9.115174e+00 ; 5.066119e+02 ];
omc_error_15 = [ 2.849176e-02 ; 2.785593e-02 ; 5.222170e-02 ];
Tc_error_15  = [ 8.285657e+00 ; 1.221916e+01 ; 7.099819e+00 ];

%-- Image #16:
omc_16 = [ NaN ; NaN ; NaN ];
Tc_16  = [ NaN ; NaN ; NaN ];
omc_error_16 = [ NaN ; NaN ; NaN ];
Tc_error_16  = [ NaN ; NaN ; NaN ];

%-- Image #17:
omc_17 = [ 2.083893e+00 ; -1.973378e+00 ; 3.058117e-01 ];
Tc_17  = [ 3.986459e+01 ; -1.713489e+01 ; 8.385978e+02 ];
omc_error_17 = [ 2.069043e-02 ; 2.245268e-02 ; 4.026011e-02 ];
Tc_error_17  = [ 1.373303e+01 ; 2.028678e+01 ; 1.249230e+01 ];

%-- Image #18:
omc_18 = [ 6.958600e-01 ; -3.045361e+00 ; 2.101415e-01 ];
Tc_18  = [ -8.961109e+01 ; -1.478765e+02 ; 8.420268e+02 ];
omc_error_18 = [ 1.149142e-02 ; 3.507173e-02 ; 5.405570e-02 ];
Tc_error_18  = [ 1.398932e+01 ; 2.026633e+01 ; 1.337639e+01 ];

%-- Image #19:
omc_19 = [ 2.099321e+00 ; -2.191293e+00 ; 1.056922e-01 ];
Tc_19  = [ 7.421791e+01 ; -3.483247e+01 ; 1.043420e+03 ];
omc_error_19 = [ 3.521884e-02 ; 4.156679e-02 ; 8.139171e-02 ];
Tc_error_19  = [ 1.710214e+01 ; 2.524318e+01 ; 1.660586e+01 ];

%-- Image #20:
omc_20 = [ 1.980309e+00 ; 2.124966e+00 ; -3.607154e-01 ];
Tc_20  = [ -5.361467e+01 ; 5.060707e+01 ; 7.035382e+02 ];
omc_error_20 = [ 2.941032e-02 ; 2.977374e-02 ; 5.854982e-02 ];
Tc_error_20  = [ 1.150444e+01 ; 1.710416e+01 ; 1.083185e+01 ];

%-- Image #21:
omc_21 = [ 2.044890e+00 ; 2.239189e+00 ; -1.860756e-01 ];
Tc_21  = [ -6.968672e+01 ; 2.450292e+01 ; 6.975091e+02 ];
omc_error_21 = [ 4.333450e-02 ; 4.416503e-02 ; 8.845399e-02 ];
Tc_error_21  = [ 1.140555e+01 ; 1.687176e+01 ; 1.112177e+01 ];

%-- Image #22:
omc_22 = [ -2.064335e+00 ; -2.354948e+00 ; 1.549269e-02 ];
Tc_22  = [ -7.302381e+01 ; -1.891169e+01 ; 7.377569e+02 ];
omc_error_22 = [ 4.116498e-02 ; 4.910799e-02 ; 1.002251e-01 ];
Tc_error_22  = [ 1.208432e+01 ; 1.784815e+01 ; 1.146049e+01 ];

%-- Image #23:
omc_23 = [ 2.159822e+00 ; 4.005342e-01 ; -3.015655e-01 ];
Tc_23  = [ -6.022969e+01 ; 8.679957e+01 ; 3.922559e+02 ];
omc_error_23 = [ 2.372638e-02 ; 9.722934e-03 ; 1.991016e-02 ];
Tc_error_23  = [ 6.491603e+00 ; 9.570663e+00 ; 5.721331e+00 ];

%-- Image #24:
omc_24 = [ 1.944790e+00 ; 2.505895e-01 ; -2.169419e-01 ];
Tc_24  = [ -3.431548e+01 ; 6.592986e+01 ; 2.919348e+02 ];
omc_error_24 = [ 2.346664e-02 ; 1.018786e-02 ; 1.710814e-02 ];
Tc_error_24  = [ 4.837366e+00 ; 7.115275e+00 ; 4.322097e+00 ];

%-- Image #25:
omc_25 = [ 1.869406e+00 ; 2.110035e-01 ; -1.277966e-01 ];
Tc_25  = [ -6.186770e+00 ; 3.822919e+01 ; 2.872124e+02 ];
omc_error_25 = [ 2.375057e-02 ; 1.116709e-02 ; 1.598211e-02 ];
Tc_error_25  = [ 4.732996e+00 ; 6.958687e+00 ; 4.299192e+00 ];

%-- Image #26:
omc_26 = [ 1.500401e+00 ; -1.747979e+00 ; 1.020233e+00 ];
Tc_26  = [ 7.477666e+01 ; 1.982408e+01 ; 5.979351e+02 ];
omc_error_26 = [ 1.615603e-02 ; 2.252658e-02 ; 2.397571e-02 ];
Tc_error_26  = [ 9.778360e+00 ; 1.447590e+01 ; 8.772180e+00 ];

%-- Image #27:
omc_27 = [ 1.651722e+00 ; -1.295304e+00 ; 9.801867e-01 ];
Tc_27  = [ 4.027536e+01 ; 4.362496e+01 ; 7.038537e+02 ];
omc_error_27 = [ 1.967924e-02 ; 2.109103e-02 ; 2.093419e-02 ];
Tc_error_27  = [ 1.153172e+01 ; 1.703317e+01 ; 1.067166e+01 ];

%-- Image #28:
omc_28 = [ 1.815778e+00 ; -6.086047e-01 ; 5.552303e-01 ];
Tc_28  = [ 1.741512e+02 ; 5.061931e+01 ; 7.227399e+02 ];
omc_error_28 = [ 2.242028e-02 ; 1.679518e-02 ; 1.870358e-02 ];
Tc_error_28  = [ 1.196487e+01 ; 1.770099e+01 ; 1.217202e+01 ];

%-- Image #29:
omc_29 = [ 2.161235e+00 ; 2.533134e-02 ; 7.857867e-02 ];
Tc_29  = [ 4.063968e+01 ; 1.409462e+02 ; 7.316513e+02 ];
omc_error_29 = [ 2.515768e-02 ; 1.022058e-02 ; 2.193900e-02 ];
Tc_error_29  = [ 1.214575e+01 ; 1.785242e+01 ; 1.176741e+01 ];

%-- Image #30:
omc_30 = [ 2.773469e+00 ; 1.491022e-01 ; -2.721926e-01 ];
Tc_30  = [ 3.979473e+01 ; 3.619592e+01 ; 7.949252e+02 ];
omc_error_30 = [ 3.112668e-02 ; 7.620809e-03 ; 3.730261e-02 ];
Tc_error_30  = [ 1.311929e+01 ; 1.921706e+01 ; 1.179557e+01 ];

%-- Image #31:
omc_31 = [ 2.558099e+00 ; -1.021803e+00 ; 4.136479e-01 ];
Tc_31  = [ -7.547414e+01 ; -6.538804e+01 ; 6.752887e+02 ];
omc_error_31 = [ 2.476221e-02 ; 1.425520e-02 ; 2.888571e-02 ];
Tc_error_31  = [ 1.106337e+01 ; 1.637773e+01 ; 1.006000e+01 ];

