import datetime
import os

time = datetime.datetime.now().strftime('%Y%m%d_%H%M%S')
path = "/log_yaw/{}.txt".format( time)
f = open(os.getcwd()+path, 'w')
# f = open(os.getcwd()+"/log_yaw/test.txt", 'w')
header = "Log for response of yaw\n{}\n".format(time)
f.write(header)

f.close()