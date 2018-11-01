from dronekit import connect, VehicleMode

connection_string = "/dev/ttyACM0"

# Connect to the Vehicle.
vehicle = connect(connection_string, wait_ready=True)


print "Get some vehicle attribute values:"
print " GPS: %s" % vehicle.gps_0
print " Battery: %s" % vehicle.battery
print " Last Heartbeat: %s" % vehicle.last_heartbeat
print " Is Armable?: %s" % vehicle.is_armable
print " System status: %s" % vehicle. system_status.state
print " Mode: %s" % vehicle.mode.name
# Close vehicle object before exiting script
vehicle.close()



print("Completed")
