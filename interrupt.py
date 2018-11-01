from dronekit import connect, VehicleMode, LocationGlobalRelative

connection_string = '127.0.0.1:14550'

# Connect to the Vehicle.
print('connecting to %s' % connection_string)
vehicle = connect('127.0.0.1:14550', wait_ready=True)

# Read current location
curLocation = vehicle.location.global_relative_frame

# Set target to current location
vehicle.simple_goto(curLocation)

# Close vehicle object before exiting script
vehicle.close()


