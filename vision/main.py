import time


DEBUG = True
alt = 10															# altitude objective 10m


# <--------------------- Initialize --------------------------->
print("Initializing.....")

# Debug mode
if (DEBUG):
	print("Entering degub mode.....")
	time.sleep(1)
	alt = input("Altitude objective: ")								# user defined altitude objective

	# PID tuning while moving to the waypoint set by input
	print("Calibrating with input displacement vector")
	dx = input("Enter vector x component: ")
	dy = input("Enter vector y component: ")

	# PIDtune: 	gets waypoint vector and vehicle object to tune PID while 
	#			moving to the waypoint
	pid_const = PIDtune(dx, dy, vehicle)

takeoff(alt)														# Take off to altitude objective


# <----------------------- Main Loop ----------------------------->

while (1):			# this loop always runs while the copter is in AUTO mode

	# <----------------------- Processing data ------------------------>

	# get image from camera feed
	img = getImage()

	# proccessImg: extracts the line from the image and process into 
	# 			 the distance from the copter and the angle difference 
	#			 with respect to the yaw angle
	lineInfo = processImg(img)			
	
	# extract the data
	line_dist = lineInfo[0]
	line_yaw = lineInfo[1]

	# get current copter state 
	current_state = getState()


	# <----------------------- Controller ------------------------------->


	# getWaypoint: 	from the line data and the current state of the copter,
	#				this method returns the most efficient waypoint
	wp = getWaypoint(line_dist, line_yaw, current_state)

	# PIDcontrol: 	gets waypoint and current state to control the copter
	#
	# + This method should run only one step of the pid control 
	# + to continuously update the waypoint, which means 
	# + one call of this method sends only one MAVlink commmand
	PIDcontrol(wp, current_state, pid_const)

