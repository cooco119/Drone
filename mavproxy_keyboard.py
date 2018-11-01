import pygame, fnmatch
from time import sleep

mpstate = None

from MAVProxy.modules.lib import mp_module

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

class KModule(mp_module.MPModule):
    def __init__(self, mpstate):
        super(KModule, self).__init__(mpstate, "keyboard", "keyboard aircraft control")
        # self.key = None

        #initialize joystick, if available
        pygame.init()
        pygame.event.pump()
        # pygame.joystick.init() # main joystick device system

        # for i in range(pygame.joystick.get_count()):
        #     print("Trying joystick %u" % i)
        #     try:
        #         j = pygame.joystick.Joystick(i)
        #         j.init() # init instance
        #         name = j.get_name()
        #         print('joystick found: ' + name)
        #         for jtype in joymap:
        #             if fnmatch.fnmatch(name, jtype):
        #                 print("Matched type '%s'" % jtype)
        #                 print '%u axes available' % j.get_numaxes()
        #                 self.js = j
        #                 self.num_axes = j.get_numaxes()
        #                 self.map = joymap[jtype]
        #                 break
        #     except pygame.error:
        #         continue

    def idle_task(self):
        '''called in idle time'''
        # if self.js is None:
        #     return
        # for e in pygame.event.get(): # iterate over event stack
        #     #the following is somewhat custom for the specific joystick model:
        #     override = self.module('rc').override[:]
        #     for i in range(len(self.map)):
        #         m = self.map[i]
        #         if m is None:
        #             continue
        #         (axis, mul, add) = m
        #         if axis >= self.num_axes:
        #             continue
        #         v = int(self.js.get_axis(axis)*mul + add)
        #         v = max(min(v, 2000), 1000)
        #         override[i] = v
        #     if override != self.module('rc').override:
        #         self.module('rc').override = override
        #         self.module('rc').override_period.force()

        
		keys = pygame.key.get_pressed()	
        for i in keys:
			if i:
				print("Input key: ")
				print(KEY[i])

def init(mpstate):
    '''initialise module'''
    return KModule(mpstate)