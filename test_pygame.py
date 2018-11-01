import pygame, time

KEY = ("K_BACKSPACE","K_TAB","K_CLEAR","K_RETURN","K_PAUSE","K_ESCAPE", "K_SPACE",
	"K_EXCLAIM", "K_QUOTEDBL", "K_HASH", "K_DOLLAR", "K_AMPERSAND", "K_QUOTE", 
	"K_LEFTPAREN", "K_RIGHTPAREN", "K_ASTERISK", "K_PLUS", "K_COMMA", "K_MINUS",
	"K_PERIOD", "K_SLASH", "K_0", "K_1", "K_2", "K_3", "K_4", "K_5", "K_6", "K_7",
	"K_8", "K_9", "K_COLON", "K_SEMICOLON", "K_LESS", "K_EQUALS", "K_GREATER",
	"K_AT", "K_LEFTBRACKET", "K_BACKSLASH", "K_RIGHTBRACKET", "K_CARET", "K_UNDERSCORE",
	"K_BACCKQUOTE", "K_a", "K_b", "K_c", "K_d", "K_e", "K_f", "K_g", "K_h", "K_i", "K_j",
	"K_k", "K_l", "K_m", "K_n", "K_o", "K_p", "K_q", "K_r", "K_s", "K_t", "K_u", "K_v",
	"K_w", "K_x", "K_y", "K_z", "K_DELETE", "K_KP0", "K_KP1", "K_KP2", "K_KP3",
	"K_KP4", "K_KP5", "K_KP6", "K_KP7", "K_KP8", "K_KP9", "K_KP_PERIOD", "K_KP_DIVIDE",
	"K_KP_MULTIPLY", "K_KP_MINUS", "K_KP_PLUS", "K_KP_ENTER", "K_KP_EQUALS",
	"K_UP", "K_DOWN", "K_RIGHT", "K_LEFT", "K_INSERT", "K_HOME", "K_END", "K_PAGEUP",
	"K_PAGEDOWN", "K_F1", "K_F2", "K_F3", "K_F4", "K_F5", "K_F6", "K_F7", "K_F8",
	"K_F9", "K_F10", "K_F11", "K_F12", "K_F13", "K_F14", "K_F15", "K_NUMLOCK", 
	"K_CAPSLOCK", "K_SCROLLOCK", "K_RSHIFT", "K_LSHIFT", "K_RCTRL", "K_LCTRL", 
	"K_RALT", "K_LALT", "K_RMETA", "K_LMETA", "K_LSUPER", "K_RSUPER", "K_MODE",
	"K_HELP", "K_PRINT", "K_SYSREQ", "K_BREAK", "K_MENU", "K_POWER", "K_EURO")

pygame.init()

while 1:
	time.sleep(1)
	for event in pygame.event.get():
		print("EVENT MODE")
		if event.type == pygame.KEYDOWN:
			if event.unicode.isalpha():
				print(event.unicode)
			if event.type == QUIT:
				print("exit by quit")
		if (event.key == pygame.K_ESCAPE):
			print("exit by event")
			exit(0)

	# keys = pygame.key.get_pressed()
	# # print(keys)
	# for i in keys:
	# 	if i:
	# 		print("Input key: ")
	# 		print(KEY[i])
			
	# print("Loop going")
	if (pygame.key.get_pressed()[pygame.K_ESCAPE] != 0):
		print("exit by key input")
		exit(0)
	
	if (pygame.key.get_pressed()[pygame.K_w] != 0):
		print("FORWARD")
		# send_ned_velocity(-math.sin(yaw_angle)*SPEED, math.cos(yaw_angle)*SPEED, 0, 1)
	if (pygame.key.get_pressed()[pygame.K_s] != 0):
		print("BACKWARD")
		# send_ned_velocity(math.sin(yaw_angle)*SPEED, -math.cos(yaw_angle)*SPEED, 0, 1)
	if (pygame.key.get_pressed()[pygame.K_q] != 0):
		print("LEFT TURN")
		# condition_yaw(1, True, -1)
		# yaw_angle -= 1
	if (pygame.key.get_pressed()[pygame.K_e] != 0):
		print("RIGHT TURN")
		# condition_yaw(1, True, 1)
		# yaw_angle += 1
	if (pygame.key.get_pressed()[pygame.K_a] != 0):
		print("LEFT")
		# send_ned_velocity(math.sin(yaw_angle)*SPEED, math.cos(yaw_angle)*SPEED, 0, 1)
	if (pygame.key.get_pressed()[pygame.K_d] != 0):
		print("RIGHT")
		# send_ned_velocity(-math.sin(yaw_angle)*SPEED, -math.cos(yaw_angle)*SPEED, 0, 1)
	if (pygame.key.get_pressed()[pygame.K_j] != 0):
		print("DOWN")
		# send_ned_velocity(0, 0, 1, 1)
	if (pygame.key.get_pressed()[pygame.K_k] != 0):
		print("UP")
		# send_ned_velocity(0, 0, -1, 1)
	if (pygame.key.get_pressed()[pygame.K_r] != 0):
		print("TAKEOFF")
		# arm_and_takeoff(5)
	# else:
	# 	print("Not available command")
	# 	time.sleep(0.01)
	pass