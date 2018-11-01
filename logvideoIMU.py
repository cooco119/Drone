from dronekit import connect, VehicleMode, LocationGlobal, LocationGlobalRelative
from pymavlink import mavutil
import time
import math
import signal
import sys
import subprocess
import datetime
import os

def signal_handler(signal, frame):
        print('Closing vehicle and log file')
        vehicle.close()
        f.close()
        sys.exit(0)

connection_string = "tcp:127.0.0.1:5760"

# Connect to the Vehicle.
vehicle = connect(connection_string, wait_ready=False)

# Open log file for writing
print "Opening log file"
cur_time = datetime.datetime.now().strftime('%Y%m%d_%H%M%S')
path = "{}/log/{}.txt".format(os.getcwd(),cur_time)
f = open(path, 'w')
f.write("Time,Roll,Pitch,Yaw\n")


# initialize time
start_time = time.time()
time.sleep(0.001)

# Begin camera recording
print "Start Camera recording..."
callCameraPhrase = "sudo gst-launch-1.0 -e v4l2src device=/dev/video13 num-buffers=2000 ! autovideoconvert \
format=i420 width=1920 height=1080 framerate=30/1 ! vaapih264enc rate-control=cbr tune=high-compression ! qtmux !\
 filesink location={}/video/{}.mp4".format(os.getcwd(),cur_time)
subprocess.Popen(callCameraPhrase, shell=True)

# loggin loop
while True:
	signal.signal(signal.SIGINT, signal_handler)

	yawData = vehicle.attitude.yaw*180/math.pi
	pitchData = vehicle.attitude.pitch*180/math.pi
	rollData = vehicle.attitude.roll*180/math.pi

	op_time = time.time() - start_time
	data = "{},{},{},{}\n".format(op_time, rollData, pitchData, yawData)
	f.write(data)
	time.sleep(0.01)

