from dronekit import connect, VehicleMode, LocationGlobal, LocationGlobalRelative
from pymavlink import mavutil
import time
import math
import pygame


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


def condition_yaw(heading, relative=False, cw=True):
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
		heading,									# param 1, yaw in degrees
		0, 											# param 2, yaw speed deg/s
		dir, 											# param 3, direction -1 ccw, 1 cw
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
	return math.sqrt((dlat*dlat) + (dlong*dlong)) * 1.113195e5

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

def rtl_and_quit():
	vehicle.mode = VehicleMode(RETURN_TO_LAUNCH)
	vehicle.close()
	print("Interrupted... RTL")


# <------------ Main --------------->
connection_string = "127.0.0.1:14552"

# Connect to the Vehicle.
vehicle = connect(connection_string, wait_ready=True)
pygame.init()
yaw_angle = vehicle.attitude.yaw

NORTH = 2
SOUTH = -2
EAST = 2
WEST = -2
UP = -0.5
DOWN = 0.5
SPEED = 2

print("Start")
print vehicle.battery.level
pygame.event.pump()
while vehicle.battery.level > 20:
	time.sleep(1)
	for event in pygame.event.get():
		print("EVENT MODE")
		if (event.key == pygame.K_ESCAPE):
			print("exit by event")
			if (vehicle.mode() != "RTL"):
				rtl_and_quit()
			vehicle.close()
			exit(0)
	
	# if (keys[pygame.K_w] != 0):
	# 	print("FORWARD")
	# 	send_ned_velocity(-math.sin(yaw_angle)*SPEED, math.cos(yaw_angle)*SPEED, 0, 1)
	# if (keys[pygame.K_s] != 0):
	# 	print("BACKWARD")
	# 	send_ned_velocity(math.sin(yaw_angle)*SPEED, -math.cos(yaw_angle)*SPEED, 0, 1)
	# if (keys[pygame.K_q] != 0):
	# 	print("LEFT TURN")
	# 	condition_yaw(1, True, -1)
	# 	yaw_angle -= 1
	# if (keys[pygame.K_e] != 0):
	# 	print("RIGHT TURN")
	# 	condition_yaw(1, True, 1)
	# 	yaw_angle += 1
	# if (keys[pygame.K_a] != 0):
	# 	print("LEFT")
	# 	send_ned_velocity(math.sin(yaw_angle)*SPEED, math.cos(yaw_angle)*SPEED, 0, 1)
	# if (keys[pygame.K_d] != 0):
	# 	print("RIGHT")
	# 	send_ned_velocity(-math.sin(yaw_angle)*SPEED, -math.cos(yaw_angle)*SPEED, 0, 1)
	# if (keys[pygame.K_j] != 0):
	# 	print("DOWN")
	# 	send_ned_velocity(0, 0, 1, 1)
	# if (keys[pygame.K_k] != 0):
	# 	print("UP")
	# 	send_ned_velocity(0, 0, -1, 1)
	# if (keys[pygame.K_r] != 0):
	# 	print("TAKEOFF")
	# 	arm_and_takeoff(5)







	keys = pygame.key.get_pressed()
	# print(keys)
	for i in keys:
		if i:
			print("Input key: ")
			print(i)
			
	# print("Loop going")
	if (keys[pygame.K_ESCAPE] != 0):
		print("exit")
		rtl_and_quit()
		vehicle.close()
		exit(0)
	
	if (keys[pygame.K_w] != 0):
		print("FORWARD")
		send_ned_velocity(-math.sin(yaw_angle)*SPEED, math.cos(yaw_angle)*SPEED, 0, 1)
	if (keys[pygame.K_s] != 0):
		print("BACKWARD")
		send_ned_velocity(math.sin(yaw_angle)*SPEED, -math.cos(yaw_angle)*SPEED, 0, 1)
	if (keys[pygame.K_q] != 0):
		print("LEFT TURN")
		condition_yaw(1, True, -1)
		yaw_angle -= 1
	if (keys[pygame.K_e] != 0):
		print("RIGHT TURN")
		condition_yaw(1, True, 1)
		yaw_angle += 1
	if (keys[pygame.K_a] != 0):
		print("LEFT")
		send_ned_velocity(math.sin(yaw_angle)*SPEED, math.cos(yaw_angle)*SPEED, 0, 1)
	if (keys[pygame.K_d] != 0):
		print("RIGHT")
		send_ned_velocity(-math.sin(yaw_angle)*SPEED, -math.cos(yaw_angle)*SPEED, 0, 1)
	if (keys[pygame.K_j] != 0):
		print("DOWN")
		send_ned_velocity(0, 0, 1, 1)
	if (keys[pygame.K_k] != 0):
		print("UP")
		send_ned_velocity(0, 0, -1, 1)
	if (keys[pygame.K_r] != 0):
		print("TAKEOFF")
		arm_and_takeoff(5)
	# else:
	# 	print("Not available command")
	# 	time.sleep(0.01)
	pass

	

print("Battery level low.. RTL")
rtl_and_quit()

