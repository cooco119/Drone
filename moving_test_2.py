from dronekit import connect, VehicleMode, LocationGlobal, LocationGlobalRelative
from pymavlink import mavutil
import time
import math
import datetime
import os


def arm_and_takeoff(aTargetAltitude):
	print "Basic pre-arm checks..."
	while not vehicle.is_armable:
		print "  Waiting for vehicle to initialize..."
		time.sleep(1)

	print "Arming motors..."
	vehicle.mode = VehicleMode("GUIDED")
	vehicle.armed = True

	while not vehicle.armed:
		print "  Waiting for arming..."
		time.sleep(1)

	print "Taking off!"
	vehicle.simple_takeoff(aTargetAltitude)

	while True:
		print "  Altitude : ", vehicle.location.global_relative_frame.alt
		if vehicle.location.global_relative_frame.alt >= aTargetAltitude*0.95:
			print " Reached target altitude"
			break
		time.sleep(1)


def condition_yaw_speed(speed, relative=False, cw=True):
	if relative:
		is_relative = 1
	else:
		is_relative = 0

	if cw:
		dir = 1
	else:
		dir = -1

	msg = vehicle.message_factory.command_long_encode(
		0, 0,										# target system, target component
		mavutil.mavlink.MAV_CMD_CONDITION_YAW,		# command
		0, 											# confirmation
		0,											# param 1, yaw in degrees
		speed, 										# param 2, yaw speed deg/s
		dir, 										# param 3, direction -1 ccw, 1 cw
		is_relative,								# param 4, relative offset 1, absolute angle 0
		0, 0, 0)									# param 5 ~ 7 not used

	# send command to vehicle
	vehicle.send_mavlink(msg)

def condition_yaw(degree, relative=False, cw=True):
	if relative:
		is_relative = 1
	else:
		is_relative = 0

	if cw:
		dir = 1
	else:
		dir = -1

	msg = vehicle.message_factory.command_long_encode(
		0, 0,										# target system, target component
		mavutil.mavlink.MAV_CMD_CONDITION_YAW,		# command
		0, 											# confirmation
		degree,										# param 1, yaw in degrees
		0,	 										# param 2, yaw speed deg/s
		dir, 										# param 3, direction -1 ccw, 1 cw
		is_relative,								# param 4, relative offset 1, absolute angle 0
		0, 0, 0)									# param 5 ~ 7 not used

	# send command to vehicle
	vehicle.send_mavlink(msg)

def get_location_metres(original_location, dNorth, dEast):
	'''
	Returns a LocationGlobal object containing the latitude/longitude `dNorth` and `dEast` metres from the 
    specified `original_location`. The returned LocationGlobal has the same `alt` value
    as `original_location`.
	'''
    
    
	earth_radius = 637813.0
	dLat = dNorth/earth_radius
	dLon = dEast/(earth_radius*math.cos(math.pi*original_location.lat/180))

	# New position in decimal degrees
	newlat = original_location.lat + (dLat * 180/math.pi)
	newlon = original_location.lon + (dLon * 180/math.pi)
	if type(original_location) is LocationGlobal:
		targetlocation=LocationGlobal(newlat, newlon, original_location.alt)
	elif type(original_location) is LocationGlobalRelative:
		targetlocation=LocationGlobalRelative(newlat, newlon, original_location.alt)
	else:
		raise Exception("Invalid Location object passed")

	return targetlocation;

def get_distance_metres(aLocation1, aLocation2):
	dlat = aLocation2.lat - aLocation1.lat
	dlong = aLocation2.lon - aLocation1.lon
	result = math.sqrt((dlat*dlat) + (dlong*dlong)) * 1.113195e5
	return result

def get_bearing(aLocation1,aLocation2):
	off_x = aLocation2.lon - aLocation1.lon
	off_y = aLocation2.lat - aLocation1.lat
	bearing = 90.00 + math.atan2(-off_y, off_x) * 57.2957795
	if bearing <  0:
		bearing += 360.00
	return bearing;

def send_ned_velocity(velocity_x, velocity_y, velocity_z, duration):
	msg = vehicle.message_factory.set_position_target_local_ned_encode(
		0, 												# time_boot_ms (not used)
		0, 0,											# target system, target component
		mavutil.mavlink.MAV_FRAME_LOCAL_NED,			# frame
		0b0000111111000111,								# type_mask (only speeds enabled)
		0, 0, 0,										# x, y, z, positions (not used)
		velocity_x, velocity_y, velocity_z,				# x, y, z, velocity in m/s
		0, 0, 0,										# accelerations (not supported)
		0, 0)											# yaw, yaw_rate (not supported)

		# send command to vehicle on 1Hz cycle
	for x in range(0, duration):
		vehicle.send_mavlink(msg)
		time.sleep(1)


def rtl_and_quit(output="Interrupted... RTL"):
	vehicle.mode = VehicleMode("RTL")
	vehicle.close()
	print(output)

def go_forward(speed, duration):
	# print ("FORWARD")

	# msg = vehicle.message_factory.set_position_target_local_ned_encode(
	# 	0, 												# time_boot_ms (not used)
	# 	0, 0,											# target system, target component
	# 	mavutil.mavlink.MAV_FRAME_LOCAL_NED,			# frame
	# 	0b0000111111000111,								# type_mask (only speeds enabled)
	# 	0, 0, 0,										# x, y, z, positions (not used)
	# 	velocity_x, velocity_y, velocity_z,				# x, y, z, velocity in m/s
	# 	0, 0, 0,										# accelerations (not supported)
	# 	0, 0)											# yaw, yaw_rate (not supported)

		# send command to vehicle on 1Hz cycle
	# for x in range(0, duration):
	# 	vehicle.send_mavlink(msg)
	# 	time.sleep(1)


	for i in range(0, duration):
		yaw = vehicle.attitude.yaw
		vel_x = math.cos(yaw)*speed
		vel_y = math.sin(yaw)*speed
		msg = vehicle.message_factory.set_position_target_local_ned_encode(
			0, 												# time_boot_ms (not used)
			0, 0,											# target system, target component
			mavutil.mavlink.MAV_FRAME_LOCAL_NED,			# frame
			0b0000111111000111,								# type_mask (only speeds enabled)
			0, 0, 0,										# x, y, z, positions (not used)
			vel_x, vel_y, 0,								# x, y, z, velocity in m/s
			0, 0, 0,										# accelerations (not supported)
			0, 0)											# yaw, yaw_rate (not supported)
		vehicle.send_mavlink(msg)
		time.sleep(0.1)



	# send_ned_velocity(math.cos(yaw)*speed, math.sin(yaw)*speed, 0, duration)
	# time.sleep(duration)

def go_backward(speed, duration):
	print("BACKWARD")
	# send_ned_velocity(-math.cos(yaw)*speed, -math.sin(yaw)*speed, 0, duration)			
	# time.sleep(duration)

	for i in range(0, duration):
		yaw = vehicle.attitude.yaw
		vel_x = -math.cos(yaw)*speed
		vel_y = -math.sin(yaw)*speed
		msg = vehicle.message_factory.set_position_target_local_ned_encode(
			0, 												# time_boot_ms (not used)
			0, 0,											# target system, target component
			mavutil.mavlink.MAV_FRAME_LOCAL_NED,			# frame
			0b0000111111000111,								# type_mask (only speeds enabled)
			0, 0, 0,										# x, y, z, positions (not used)
			vel_x, vel_y, 0,								# x, y, z, velocity in m/s
			0, 0, 0,										# accelerations (not supported)
			0, 0)											# yaw, yaw_rate (not supported)
		vehicle.send_mavlink(msg)
		time.sleep(1)

def go_left(speed, duration):
	print("LEFT")
	# send_ned_velocity(math.sin(yaw)*speed, -math.cos(yaw)*speed, 0, duration)	
	# time.sleep(duration)

	for i in range(0, duration):
		yaw = vehicle.attitude.yaw
		vel_x = math.sin(yaw)*speed
		vel_y = -math.cos(yaw)*speed
		msg = vehicle.message_factory.set_position_target_local_ned_encode(
			0, 												# time_boot_ms (not used)
			0, 0,											# target system, target component
			mavutil.mavlink.MAV_FRAME_LOCAL_NED,			# frame
			0b0000111111000111,								# type_mask (only speeds enabled)
			0, 0, 0,										# x, y, z, positions (not used)
			vel_x, vel_y, 0,								# x, y, z, velocity in m/s
			0, 0, 0,										# accelerations (not supported)
			0, 0)											# yaw, yaw_rate (not supported)
		vehicle.send_mavlink(msg)
		time.sleep(1)

def go_right(speed, duration):
	print("RIGHT")
	# send_ned_velocity(-math.sin(yaw)*speed, math.cos(yaw)*speed, 0, duration)
	# time.sleep(duration)

	for i in range(0, duration):
		yaw = vehicle.attitude.yaw
		vel_x = -math.sin(yaw)*speed
		vel_y = math.cos(yaw)*speed
		msg = vehicle.message_factory.set_position_target_local_ned_encode(
			0, 												# time_boot_ms (not used)
			0, 0,											# target system, target component
			mavutil.mavlink.MAV_FRAME_LOCAL_NED,			# frame
			0b0000111111000111,								# type_mask (only speeds enabled)
			0, 0, 0,										# x, y, z, positions (not used)
			vel_x, vel_y, 0,								# x, y, z, velocity in m/s
			0, 0, 0,										# accelerations (not supported)
			0, 0)											# yaw, yaw_rate (not supported)
		vehicle.send_mavlink(msg)
		time.sleep(1)
def turn_left(speed, duration):
	print("LEFT TURN")
	condition_yaw_speed(speed, True, -1)
	time.sleep(duration)
	return vehicle.attitude.yaw

def turn_right(speed, duration):
	print("RIGHT TURN")
	condition_yaw_speed(speed, True, 1)
	time.sleep(duration)
	return vehicle.attitude.yaw

def go_down(speed, duration):
	print("DOWN")
	send_ned_velocity(0, 0, speed, duration)
	time.sleep(duration)

def go_up(speed, duration):
	print("UP")
	send_ned_velocity(0, 0, -speed, duration)
	time.sleep(duration)

def go_in_relative_frame(vel_x, vel_y, vel_z, heading, duration):
	# print("Moving in ", vel_x, ", ", vel_y, ", ", vel_z, "for ", duration, "seconds in direction ", heading)
	vel_forward = math.cos(heading)*vel_y - math.sin(heading)*vel_x
	vel_right = math.cos(heading)*vel_x + math.sin(heading)*vel_y
	vel_up = -vel_z
	send_ned_velocity(vel_forward, vel_right, vel_up, duration)
	time.sleep(duration)
	
def stop():
	print("STOP")
	send_ned_velocity(0, 0, 0, 1)
	time.sleep(2)

def PID_goto(targetlocation, dist_standard= 3):

	Kp = 100
	Kd = 30
	Ki = 0

	Kp_v = 25
	Kd_v = 1

	heading = vehicle.attitude.yaw *180/math.pi
	current_location = vehicle.location.global_relative_frame
	dist = get_distance_metres(current_location, targetlocation)
	last_e = heading
	e = last_e
	e_int = 0
	last_dist = dist

	while(dist >= dist_standard):
		current_location = vehicle.location.global_relative_frame
		dist = get_distance_metres(current_location, targetlocation)
		target_bearing = get_bearing(current_location, targetlocation)
		if (target_bearing >180):
			target_bearing -= 360
		heading = vehicle.attitude.yaw *180/math.pi
		# if (heading < 0):
		# 	heading += 360

		e = target_bearing - heading
		if (e > 180):
			e -= 360
		elif (e < -180):
			e += 360
		e_dot = e - last_e
		e_int += e
		u =  Kp*e + Kd*e_dot + Ki*e_int

		e_v = dist
		e_dot_v = dist - last_dist

		u_v = Kp_v * e_v + Kd_v * e_dot_v

		u_v /= 100.0

		if (u_v > SPEED):
			u_v = SPEED
		elif (u_v < 1):
			u_v = 1

		
		if (u > 0):
			cw = True
		else:
			cw = False
		abs_u = math.fabs(u)
		if abs_u > 350:
			abs_u = 350
		# print ("Absolute value of u: {}").format(abs_u)
		# if (cw == True):
			# print ("Direction: Clockwise\n\n")
		# else:
			# print ("Direction: Counter Clockwise\n\n")
		condition_yaw(abs_u, True, not cw)
		go_forward(u_v, 1)

		last_e = e
		
		print ("Distance to target: {}\n\n\n").format(dist)
		# print("target_bearing: {}").format(target_bearing)
		# print("Current heading: {}").format(heading)
		# print ("Yaw error: {}").format(e)
		# print ("")
		# print ("")
		vehicle.flush()


# <------------ Main --------------->




connection_string = "127.0.0.1:14552"

# Connect to the Vehicle.
vehicle = connect(connection_string, wait_ready=True)

SPEED = 4
DURATION = 2

heading = vehicle.attitude.yaw*180/math.pi


# arm_and_takeoff(10)

current_location = vehicle.location.global_relative_frame
targetlocation = LocationGlobalRelative(current_location.lat, current_location.lon, current_location.alt)
print(current_location)

# targetlocation.lat += 0.001
targetlocation.lon += 0.001
print(targetlocation)

target_bearing = get_bearing(current_location, targetlocation)
if (target_bearing >180):
	target_bearing -= 360

# condition_yaw(target_bearing, False, False)
# go_forward(1, 1)
heading = vehicle.attitude.yaw *180/math.pi
# if (heading < 0):
# 	heading += 360
print("target_bearing: {}").format(target_bearing)
time.sleep(1)


# PID
Kp = 152
Kd = 95.095
Ki = 0

Kp_v = 25
Kd_v = 1

# open file for log
cur_time = datetime.datetime.now().strftime('%Y%m%d_%H%M%S')
path = "{}\\log_yaw\\{}_Kp_{}.csv".format(os.getcwd(),cur_time, Kp)
f = open(path, 'w')
# header = "Log for response of yaw\n{}\n".format(time)
# f.write(header)

print("Current Kp: {}, Kd: {}\n").format(Kp, Kd)

dist = get_distance_metres(current_location, targetlocation)
# print(last_e)
last_e = heading
e = last_e
e_int = 0
last_dist = dist

# initialize time

start_time = time.time()

while(dist >= 0.5):
	# if (dist <= 20):
	# 	stop()
	# 	f.close()
	# 	cmd = raw_input("Continue? (y/n) ")
	# 	if (cmd=="n"):
	# 		break
	# 	else:
	# 		# open file for log
	# 		Kp = input("Enter new Kp:")
	# 		Kd = input("Enter new Kd:")
	# 		cur_time = datetime.datetime.now().strftime('%Y%m%d_%H%M%S')
	# 		path = "{}\\log_yaw\\Kp_{}.csv".format(os.getcwd(), Kp)
	# 		f = open(path, 'w')
	# 		start_time = time.time()
	# 		print("Current Kp: {}, Kd: {}\n").format(Kp, Kd)
	# 		targetlocation.lat += 0.003
	# 		# targetlocation.lon -= 0.001
	current_location = vehicle.location.global_relative_frame
	dist = get_distance_metres(current_location, targetlocation)
	target_bearing = get_bearing(current_location, targetlocation)
	if (target_bearing >180):
		target_bearing -= 360
	heading = vehicle.attitude.yaw *180/math.pi
	# if (heading < 0):
	# 	heading += 360

	e = target_bearing - heading
	if (e > 180):
		e -= 360
	elif (e < -180):
		e += 360
	e_dot = e - last_e
	e_int += e
	u =  Kp*e + Kd*e_dot + Ki*e_int

	e_v = dist
	e_dot_v = dist - last_dist

	u_v = Kp_v * e_v + Kd_v * e_dot_v

	u_v /= 100.0

	if (u_v > SPEED):
		u_v = SPEED
	elif (u_v < 0.5):
		u_v = 0.5

	
	if (u > 0):
		cw = True
	else:
		cw = False
	abs_u = math.fabs(u)
	if abs_u > 350:
		abs_u = 350
	# print ("Absolute value of u: {}").format(abs_u)
	# if (cw == True):
		# print ("Direction: Clockwise\n\n")
	# else:
		# print ("Direction: Counter Clockwise\n\n")
	condition_yaw(abs_u, True, not cw)
	go_forward(u_v, 1)

	last_e = e
	
	print ("Distance to target: {}").format(dist)
	# print("target_bearing: {}").format(target_bearing)
	# print("Current heading: {}").format(heading)
	# print ("Yaw error: {}").format(e)
	# print ("")
	# print ("")
	vehicle.flush()
	op_time = time.time() - start_time
	yaw_data = heading
	if yaw_data > 180:
		yaw_data -= 360
	data = "{},{}\n".format(op_time, yaw_data)
	f.write(data)

# PID_goto(targetlocation)

stop()
vehicle.close()



