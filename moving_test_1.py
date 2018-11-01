from dronekit import connect, VehicleMode, LocationGlobal, LocationGlobalRelative
from pymavlink import mavutil
import time
import math
import pygame
from pygame.locals import *


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
		degree,											# param 1, yaw in degrees
		0, 										# param 2, yaw speed deg/s
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


def rtl_and_quit(output="Interrupted... RTL"):
	vehicle.mode = VehicleMode("RTL")
	vehicle.close()
	print(output)

def go_forward(speed, duration):
	print ("FORWARD")

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
		time.sleep(1)



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
	time.sleep(2)
	return vehicle.attitude.yaw

def turn_right(speed, duration):
	print("RIGHT TURN")
	condition_yaw_speed(speed, True, 1)
	time.sleep(2)
	return vehicle.attitude.yaw

def go_down(speed, duration):
	print("DOWN")
	send_ned_velocity(0, 0, speed, duration)
	time.sleep(2)

def go_up(speed, duration):
	print("UP")
	send_ned_velocity(0, 0, -speed, duration)
	time.sleep(2)

def set_attitude(roll_angle = 0.0, pitch_angle = 0.0, yaw_rate = 0.0, thrust = 0.5, duration = 0):
    """
    Note that from AC3.3 the message should be re-sent every second (after about 3 seconds
    with no message the velocity will drop back to zero). In AC3.2.1 and earlier the specified
    velocity persists until it is canceled. The code below should work on either version
    (sending the message multiple times does not cause problems).
    """
    
    """
    The roll and pitch rate cannot be controllbed with rate in radian in AC3.4.4 or earlier,
    so you must use quaternion to control the pitch and roll for those vehicles.
    """
    
    # Thrust >  0.5: Ascend
    # Thrust == 0.5: Hold the altitude
    # Thrust <  0.5: Descend
    msg = vehicle.message_factory.set_attitude_target_encode(
        0, # time_boot_ms
        1, # Target system
        1, # Target component
        0b00000000, # Type mask: bit 1 is LSB
        to_quaternion(roll_angle, pitch_angle), # Quaternion
        0, # Body roll rate in radian
        0, # Body pitch rate in radian
        math.radians(yaw_rate), # Body yaw rate in radian
        thrust  # Thrust
    )
    vehicle.send_mavlink(msg)

    start = time.time()
    while time.time() - start < duration:
        vehicle.send_mavlink(msg)
        time.sleep(0.1)

def to_quaternion(roll = 0.0, pitch = 0.0, yaw = 0.0):
    """
    Convert degrees to quaternions
    """
    t0 = math.cos(math.radians(yaw * 0.5))
    t1 = math.sin(math.radians(yaw * 0.5))
    t2 = math.cos(math.radians(roll * 0.5))
    t3 = math.sin(math.radians(roll * 0.5))
    t4 = math.cos(math.radians(pitch * 0.5))
    t5 = math.sin(math.radians(pitch * 0.5))

    w = t0 * t2 * t4 + t1 * t3 * t5
    x = t0 * t3 * t4 - t1 * t2 * t5
    y = t0 * t2 * t5 + t1 * t3 * t4
    z = t1 * t2 * t4 - t0 * t3 * t5

    return [w, x, y, z]

# <------------ Main --------------->
connection_string = "127.0.0.1:14552"

# Connect to the Vehicle.
vehicle = connect(connection_string, wait_ready=True)


# arm_and_takeoff(5)

SPEED = 5
DURATION = 5
D_YAW = 20

# heading = vehicle.attitude.yaw *180/math.pi
# condition_yaw(40, True, True)
# vehicle.flush()

# # time.sleep(5)
# set_attitude(roll_angle = 0.0, pitch_angle = 5.0, yaw_rate = 0.0, thrust = 0.5, duration = 5)

# condition_yaw(40, True, False)
# vehicle.flush()

set_attitude(yaw_rate = 10, duration = 10)

heading = vehicle.attitude.yaw *180/math.pi
if (heading < 0):
	heading += 360
print(heading)
go_forward(SPEED, DURATION)
vehicle.flush();


# go_backward(SPEED, DURATION)
# vehicle.flush();

# go_left(SPEED, DURATION)
# vehicle.flush();

# go_right(SPEED, DURATION)
# vehicle.flush();


# Close vehicle object before exiting script
vehicle.close()

print("Completed")
