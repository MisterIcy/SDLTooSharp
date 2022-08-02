namespace SDLTooSharp.Bindings;

public static partial class SDL2
{
    /// <summary>
    /// The SDL Keyboard scancode representation
    /// </summary>
    /// <remarks>
    /// The values in this enumeration are based on the USB usage page standard:
    /// https://www.usb.org/sites/default/files/documents/hut1_12v2.pdf
    /// </remarks>
    public enum SDL_Scancode
    {
        /// <summary>
        /// Reserved
        /// </summary>
        SDL_SCANCODE_UNKNOWN = 0,

        /// <summary>
        /// A and a
        /// </summary>
        SDL_SCANCODE_A = 4,

        /// <summary>
        /// B and b
        /// </summary>
        SDL_SCANCODE_B = 5,

        /// <summary>
        /// C and c
        /// </summary>
        SDL_SCANCODE_C = 6,

        /// <summary>
        /// D and d
        /// </summary>
        SDL_SCANCODE_D = 7,

        /// <summary>
        /// E and e
        /// </summary>
        SDL_SCANCODE_E = 8,

        /// <summary>
        /// F and f
        /// </summary>
        SDL_SCANCODE_F = 9,

        /// <summary>
        /// G and g
        /// </summary>
        SDL_SCANCODE_G = 10,

        /// <summary>
        /// H and h
        /// </summary>
        SDL_SCANCODE_H = 11,

        /// <summary>
        /// I and i
        /// </summary>
        SDL_SCANCODE_I = 12,

        /// <summary>
        /// J and j
        /// </summary>
        SDL_SCANCODE_J = 13,

        /// <summary>
        /// K and k
        /// </summary>
        SDL_SCANCODE_K = 14,

        /// <summary>
        /// L and l
        /// </summary>
        SDL_SCANCODE_L = 15,

        /// <summary>
        /// M and m
        /// </summary>
        SDL_SCANCODE_M = 16,

        /// <summary>
        /// N and n
        /// </summary>
        SDL_SCANCODE_N = 17,

        /// <summary>
        /// O and o
        /// </summary>
        SDL_SCANCODE_O = 18,

        /// <summary>
        /// P and p
        /// </summary>
        SDL_SCANCODE_P = 19,

        /// <summary>
        /// Q and q
        /// </summary>
        SDL_SCANCODE_Q = 20,

        /// <summary>
        /// R and r
        /// </summary>
        SDL_SCANCODE_R = 21,

        /// <summary>
        /// S and s
        /// </summary>
        SDL_SCANCODE_S = 22,

        /// <summary>
        /// T and t
        /// </summary>
        SDL_SCANCODE_T = 23,

        /// <summary>
        /// U and u
        /// </summary>
        SDL_SCANCODE_U = 24,

        /// <summary>
        /// V and v
        /// </summary>
        SDL_SCANCODE_V = 25,

        /// <summary>
        /// W and w
        /// </summary>
        SDL_SCANCODE_W = 26,

        /// <summary>
        /// X and x
        /// </summary>
        SDL_SCANCODE_X = 27,

        /// <summary>
        /// Y and y
        /// </summary>
        SDL_SCANCODE_Y = 28,

        /// <summary>
        /// Z and z
        /// </summary>
        SDL_SCANCODE_Z = 29,

        /// <summary>
        /// Number 1
        /// </summary>
        SDL_SCANCODE_1 = 30,

        /// <summary>
        /// Number 2
        /// </summary>
        SDL_SCANCODE_2 = 31,

        /// <summary>
        /// Number 3
        /// </summary>
        SDL_SCANCODE_3 = 32,

        /// <summary>
        /// Number 4
        /// </summary>
        SDL_SCANCODE_4 = 33,

        /// <summary>
        /// Number 5
        /// </summary>
        SDL_SCANCODE_5 = 34,

        /// <summary>
        /// Number 6
        /// </summary>
        SDL_SCANCODE_6 = 35,

        /// <summary>
        /// Number 7
        /// </summary>
        SDL_SCANCODE_7 = 36,

        /// <summary>
        /// Number 8
        /// </summary>
        SDL_SCANCODE_8 = 37,

        /// <summary>
        /// Number 9
        /// </summary>
        SDL_SCANCODE_9 = 38,

        /// <summary>
        /// Number 0
        /// </summary>
        SDL_SCANCODE_0 = 39,

        /// <summary>
        /// Return (Enter)
        /// </summary>
        SDL_SCANCODE_RETURN = 40,

        /// <summary>
        /// Escape
        /// </summary>
        SDL_SCANCODE_ESCAPE = 41,

        /// <summary>
        /// Delete (Backspace)
        /// </summary>
        SDL_SCANCODE_BACKSPACE = 42,

        /// <summary>
        /// Tab
        /// </summary>
        SDL_SCANCODE_TAB = 43,

        /// <summary>
        /// Spacebar
        /// </summary>
        SDL_SCANCODE_SPACE = 44,

        /// <summary>
        /// Minus and underscore
        /// </summary>
        SDL_SCANCODE_MINUS = 45,

        /// <summary>
        /// Equals and plus
        /// </summary>
        SDL_SCANCODE_EQUALS = 46,

        /// <summary>
        /// Left bracket and curly bracket
        /// </summary>
        SDL_SCANCODE_LEFTBRACKET = 47,

        /// <summary>
        /// Right bracket and curly bracket
        /// </summary>
        SDL_SCANCODE_RIGHTBRACKET = 48,

        /// <summary>
        /// Backslash and pipe
        /// </summary>
        SDL_SCANCODE_BACKSLASH = 49,

        /// <summary>
        /// Non US Hash (#) and ~
        /// </summary>
        SDL_SCANCODE_NONUSHASH = 50,

        /// <summary>
        /// Semi colon
        /// </summary>
        SDL_SCANCODE_SEMICOLON = 51,

        /// <summary>
        /// Apostrophe and double quotes
        /// </summary>
        SDL_SCANCODE_APOSTROPHE = 52,

        /// <summary>
        /// Grave and tilde
        /// </summary>
        SDL_SCANCODE_GRAVE = 53,

        /// <summary>
        /// Comma and les than
        /// </summary>
        SDL_SCANCODE_COMMA = 54,

        /// <summary>
        /// Period and greater than
        /// </summary>
        SDL_SCANCODE_PERIOD = 55,

        /// <summary>
        /// Slash and question mark
        /// </summary>
        SDL_SCANCODE_SLASH = 56,

        /// <summary>
        /// Caps Lock
        /// </summary>
        SDL_SCANCODE_CAPSLOCK = 57,

        /// <summary>
        /// F1
        /// </summary>
        SDL_SCANCODE_F1 = 58,

        /// <summary>
        /// F2
        /// </summary>
        SDL_SCANCODE_F2 = 59,

        /// <summary>
        /// F3
        /// </summary>
        SDL_SCANCODE_F3 = 60,

        /// <summary>
        /// F4
        /// </summary>
        SDL_SCANCODE_F4 = 61,

        /// <summary>
        /// F5
        /// </summary>
        SDL_SCANCODE_F5 = 62,

        /// <summary>
        /// F6
        /// </summary>
        SDL_SCANCODE_F6 = 63,

        /// <summary>
        /// F7
        /// </summary>
        SDL_SCANCODE_F7 = 64,

        /// <summary>
        /// F8
        /// </summary>
        SDL_SCANCODE_F8 = 65,

        /// <summary>
        /// F9
        /// </summary>
        SDL_SCANCODE_F9 = 66,

        /// <summary>
        /// F10
        /// </summary>
        SDL_SCANCODE_F10 = 67,

        /// <summary>
        /// F11
        /// </summary>
        SDL_SCANCODE_F11 = 68,

        /// <summary>
        /// F12
        /// </summary>
        SDL_SCANCODE_F12 = 69,

        /// <summary>
        /// Print Screen
        /// </summary>
        SDL_SCANCODE_PRINTSCREEN = 70,

        /// <summary>
        /// Scroll Lock
        /// </summary>
        SDL_SCANCODE_SCROLLLOCK = 71,

        /// <summary>
        /// Pause
        /// </summary>
        SDL_SCANCODE_PAUSE = 72,

        /// <summary>
        /// Insert
        /// </summary>
        SDL_SCANCODE_INSERT = 73,

        /// <summary>
        /// Home
        /// </summary>
        SDL_SCANCODE_HOME = 74,

        /// <summary>
        /// Page Up
        /// </summary>
        SDL_SCANCODE_PAGEUP = 75,

        /// <summary>
        /// Delete
        /// </summary>
        SDL_SCANCODE_DELETE = 76,

        /// <summary>
        /// End
        /// </summary>
        SDL_SCANCODE_END = 77,

        /// <summary>
        /// Page Down
        /// </summary>
        SDL_SCANCODE_PAGEDOWN = 78,

        /// <summary>
        /// Right Arrow
        /// </summary>
        SDL_SCANCODE_RIGHT = 79,

        /// <summary>
        /// Left arrow
        /// </summary>
        SDL_SCANCODE_LEFT = 80,

        /// <summary>
        /// Down arrow
        /// </summary>
        SDL_SCANCODE_DOWN = 81,

        /// <summary>
        /// Up arrow
        /// </summary>
        SDL_SCANCODE_UP = 82,

        /// <summary>
        /// Num lock
        /// </summary>
        SDL_SCANCODE_NUMLOCKCLEAR = 83,

        /// <summary>
        /// Keypad Divide
        /// </summary>
        SDL_SCANCODE_KP_DIVIDE = 84,

        /// <summary>
        /// Keypad Multiply
        /// </summary>
        SDL_SCANCODE_KP_MULTIPLY = 85,

        /// <summary>
        /// Keypad Minus
        /// </summary>
        SDL_SCANCODE_KP_MINUS = 86,

        /// <summary>
        /// Keypad Plus
        /// </summary>
        SDL_SCANCODE_KP_PLUS = 87,

        /// <summary>
        /// Keypad Enter
        /// </summary>
        SDL_SCANCODE_KP_ENTER = 88,

        /// <summary>
        /// Keypad 1
        /// </summary>
        SDL_SCANCODE_KP_1 = 89,

        /// <summary>
        /// Keypad 2
        /// </summary>
        SDL_SCANCODE_KP_2 = 90,

        /// <summary>
        /// Keypad 3
        /// </summary>
        SDL_SCANCODE_KP_3 = 91,

        /// <summary>
        /// Keypad 4
        /// </summary>
        SDL_SCANCODE_KP_4 = 92,

        /// <summary>
        /// Keypad 5
        /// </summary>
        SDL_SCANCODE_KP_5 = 93,

        /// <summary>
        /// Keypad 6
        /// </summary>
        SDL_SCANCODE_KP_6 = 94,

        /// <summary>
        /// Keypad 7
        /// </summary>
        SDL_SCANCODE_KP_7 = 95,

        /// <summary>
        /// Keypad 8
        /// </summary>
        SDL_SCANCODE_KP_8 = 96,

        /// <summary>
        /// Keypad 9
        /// </summary>
        SDL_SCANCODE_KP_9 = 97,

        /// <summary>
        /// Keypad 0
        /// </summary>
        SDL_SCANCODEKP_0 = 98,

        /// <summary>
        /// Keypad Period
        /// </summary>
        SDL_SCANCODE_KP_PERIOD = 99,

        /// <summary>
        /// Non us backslash and pipe
        /// </summary>
        SDL_SCANCODE_NONUSBACKSLASH = 100,

        /// <summary>
        /// Application
        /// </summary>
        SDL_SCANCODE_APPLICATION = 101,

        /// <summary>
        /// Power
        /// </summary>
        SDL_SCANCODE_POWER = 102,

        /// <summary>
        /// Keypad Equals
        /// </summary>
        SDL_SCANCODE_KP_EQUALS = 103,

        /// <summary>
        /// F13
        /// </summary>
        SDL_SCANCODE_F13 = 104,

        /// <summary>
        /// F14
        /// </summary>
        SDL_SCANCODE_F14 = 105,

        /// <summary>
        /// F15
        /// </summary>
        SDL_SCANCODE_F15 = 106,

        /// <summary>
        /// F16
        /// </summary>
        SDL_SCANCODE_F16 = 107,

        /// <summary>
        /// F17
        /// </summary>
        SDL_SCANCODE_F17 = 108,

        /// <summary>
        /// F18
        /// </summary>
        SDL_SCANCODE_F18 = 109,

        /// <summary>
        /// F19
        /// </summary>
        SDL_SCANCODE_F19 = 110,

        /// <summary>
        /// F20
        /// </summary>
        SDL_SCANCODE_F20 = 111,

        /// <summary>
        /// F21
        /// </summary>
        SDL_SCANCODE_F21 = 112,

        /// <summary>
        /// F22
        /// </summary>
        SDL_SCANCODE_F22 = 113,

        /// <summary>
        /// F23
        /// </summary>
        SDL_SCANCODE_F23 = 114,

        /// <summary>
        /// F24
        /// </summary>
        SDL_SCANCODE_F24 = 115,

        /// <summary>
        /// Execute
        /// </summary>
        SDL_SCANCODE_EXECUTE = 116,

        /// <summary>
        /// Help
        /// </summary>
        SDL_SCANCODE_HELP = 117,

        /// <summary>
        /// Menu
        /// </summary>
        SDL_SCANCODE_MENU = 118,

        /// <summary>
        /// Select
        /// </summary>
        SDL_SCANCODE_SELECT = 119,

        /// <summary>
        /// Stop
        /// </summary>
        SDL_SCANCODE_STOP = 120,

        /// <summary>
        /// Again
        /// </summary>
        SDL_SCANCODE_AGAIN = 121,

        /// <summary>
        /// Undo
        /// </summary>
        SDL_SCANCODE_UNDO = 122,

        /// <summary>
        /// Cut
        /// </summary>
        SDL_SCANCODE_CUT = 123,

        /// <summary>
        /// Copy
        /// </summary>
        SDL_SCANCODE_COPY = 124,

        /// <summary>
        /// Paste
        /// </summary>
        SDL_SCANCODE_PASTE = 125,

        /// <summary>
        /// Find    
        /// </summary>
        SDL_SCANCODE_FIND = 126,

        /// <summary>
        /// Mute
        /// </summary>
        SDL_SCANCODE_MUTE = 127,

        /// <summary>
        /// Volume Up
        /// </summary>
        SDL_SCANCODE_VOLUMEUP = 128,

        /// <summary>
        /// Volume down
        /// </summary>
        SDL_SCANCODE_VOLUMEDOWN = 129,


        /// <summary>
        /// Keypad Comma
        /// </summary>
        SDL_SCANCODE_KP_COMMA = 133,

        /// <summary>
        /// Keypad Equal Sign
        /// </summary>
        SDL_SCANCODE_KP_EQUALSAS400 = 134,

        SDL_SCANCODE_INTERNATIONAL1 = 135,
        SDL_SCANCODE_INTERNATIONAL2 = 136,
        SDL_SCANCODE_INTERNATIONAL3 = 137,
        SDL_SCANCODE_INTERNATIONAL4 = 138,
        SDL_SCANCODE_INTERNATIONAL5 = 139,
        SDL_SCANCODE_INTERNATIONAL6 = 140,
        SDL_SCANCODE_INTERNATIONAL7 = 141,
        SDL_SCANCODE_INTERNATIONAL8 = 142,
        SDL_SCANCODE_INTERNATIONAL9 = 143,
        SDL_SCANCODE_LANG1 = 144,
        SDL_SCANCODE_LANG2 = 145,
        SDL_SCANCODE_LANG3 = 146,
        SDL_SCANCODE_LANG4 = 147,
        SDL_SCANCODE_LANG5 = 148,
        SDL_SCANCODE_LANG6 = 149,
        SDL_SCANCODE_LANG7 = 150,
        SDL_SCANCODE_LANG8 = 151,
        SDL_SCANCODE_LANG9 = 152,

        SDL_SCANCODE_ALTERASE = 153,
        SDL_SCANCODE_SYSREQ = 154,
        SDL_SCANCODE_CANCEL = 155,
        SDL_SCANCODE_CLEAR = 156,
        SDL_SCANCODE_PRIOR = 157,
        SDL_SCANCODE_RETURN2 = 158,
        SDL_SCANCODE_SEPARATOR = 159,
        SDL_SCANCODE_OUT = 160,
        SDL_SCANCODE_OPER = 161,
        SDL_SCANCODE_CLEARAGAIN = 162,
        SDL_SCANCODE_CRSEL = 163,
        SDL_SCANCODE_EXSEL = 164,
        SDL_SCANCODE_KP_00 = 176,
        SDL_SCANCODE_KP_000 = 177,
        SDL_SCANCODE_THOUSANDSSEPARATOR = 178,
        SDL_SCANCODE_DECIMALSEPARATOR = 179,
        SDL_SCANCODE_CURRENCYUNIT = 180,
        SDL_SCANCODE_CURRENCYSUBUNIT = 181,
        SDL_SCANCODE_KP_LEFTPAREN = 182,
        SDL_SCANCODE_KP_RIGHTPAREN = 183,
        SDL_SCANCODE_KP_LEFTBRACE = 184,
        SDL_SCANCODE_KP_RIGHTBRACE = 185,
        SDL_SCANCODE_KP_TAB = 186,
        SDL_SCANCODE_KP_BACKSPACE = 187,
        SDL_SCANCODE_KP_A = 188,
        SDL_SCANCODE_KP_B = 189,
        SDL_SCANCODE_KP_C = 190,
        SDL_SCANCODE_KP_D = 191,
        SDL_SCANCODE_KP_E = 192,
        SDL_SCANCODE_KP_F = 193,
        SDL_SCANCODE_KP_XOR = 194,
        SDL_SCANCODE_KP_POWER = 195,
        SDL_SCANCODE_KP_PERCENT = 196,
        SDL_SCANCODE_KP_LESS = 197,
        SDL_SCANCODE_KP_GREATER = 198,
        SDL_SCANCODE_KP_AMPERSAND = 199,
        SDL_SCANCODE_KP_DBLAMPERSAND = 200,
        SDL_SCANCODE_KP_VERTICALBAR = 201,
        SDL_SCANCODE_KP_DBLVERTICALBAR = 202,
        SDL_SCANCODE_KP_COLON = 203,
        SDL_SCANCODE_KP_HASH = 204,
        SDL_SCANCODE_KP_SPACE = 205,
        SDL_SCANCODE_KP_AT = 206,
        SDL_SCANCODE_KP_EXCLAM = 207,
        SDL_SCANCODE_KP_MEMSTORE = 208,
        SDL_SCANCODE_KP_MEMRECALL = 209,
        SDL_SCANCODE_KP_MEMCLEAR = 210,
        SDL_SCANCODE_KP_MEMADD = 211,
        SDL_SCANCODE_KP_MEMSUBTRACT = 212,
        SDL_SCANCODE_KP_MEMMULTIPLY = 213,
        SDL_SCANCODE_KP_MEMDIVIDE = 214,
        SDL_SCANCODE_KP_PLUSMINUS = 215,
        SDL_SCANCODE_KP_CLEAR = 216,
        SDL_SCANCODE_KP_CLEARENTRY = 217,
        SDL_SCANCODE_KP_BINARY = 218,
        SDL_SCANCODE_KP_OCTAL = 219,
        SDL_SCANCODE_KP_DECIMAL = 220,
        SDL_SCANCODE_KP_HEXADECIMAL = 221,

        /// <summary>
        /// Left control
        /// </summary>
        SDL_SCANCODE_LCTRL = 224,

        /// <summary>
        /// Left shift
        /// </summary>
        SDL_SCANCODE_LSHIFT = 225,

        /// <summary>
        /// Left alt
        /// </summary>
        SDL_SCANCODE_LALT = 226,

        /// <summary>
        /// Left GUI
        /// </summary>
        SDL_SCANCODE_LGUI = 227,

        /// <summary>
        /// Right control
        /// </summary>
        SDL_SCANCODE_RCTRL = 228,

        /// <summary>
        /// Right shift
        /// </summary>
        SDL_SCANCODE_RSHIFT = 229,

        /// <summary>
        /// Right alt
        /// </summary>
        SDL_SCANCODE_RALT = 230,

        /// <summary>
        /// Right Gui
        /// </summary>
        SDL_SCANCODE_RGUI = 231,
        SDL_SCANCODE_MODE = 257,
        SDL_SCANCODE_AUDIONEXT = 258,
        SDL_SCANCODE_AUDIOPREV = 259,
        SDL_SCANCODE_AUDIOSTOP = 260,
        SDL_SCANCODE_AUDIOPLAY = 261,
        SDL_SCANCODE_AUDIOMUTE = 262,
        SDL_SCANCODE_MEDIASELECT = 263,
        SDL_SCANCODE_WWW = 264,
        SDL_SCANCODE_MAIL = 265,
        SDL_SCANCODE_CALCULATOR = 266,
        SDL_SCANCODE_COMPUTER = 267,
        SDL_SCANCODE_AC_SEARCH = 268,
        SDL_SCANCODE_AC_HOME = 269,
        SDL_SCANCODE_AC_BACK = 270,
        SDL_SCANCODE_AC_FORWARD = 271,
        SDL_SCANCODE_AC_STOP = 272,
        SDL_SCANCODE_AC_REFRESH = 273,
        SDL_SCANCODE_AC_BOOKMARKS = 274,
        SDL_SCANCODE_BRIGHTNESSDOWN = 275,
        SDL_SCANCODE_BRIGHTNESSUP = 276,
        SDL_SCANCODE_DISPLAYSWITCH = 277,
        SDL_SCANCODE_KBDILLUMTOGGLE = 278,
        SDL_SCANCODE_KBDILLUMDOWN = 279,
        SDL_SCANCODE_KBDILLUMUP = 280,
        SDL_SCANCODE_EJECT = 281,
        SDL_SCANCODE_SLEEP = 282,
        SDL_SCANCODE_APP1 = 283,
        SDL_SCANCODE_APP2 = 284,
        SDL_SCANCODE_AUDIOREWIND = 285,
        SDL_SCANCODE_AUDIOFASTFORWARD = 286,
        SDL_SCANCODE_SOFTLEFT = 287,
        SDL_SCANCODE_SOFTRIGHT = 288,
        SDL_SCANCODE_CALL = 289,
        SDL_SCANCODE_ENDCALL = 290,
        SDL_NUM_SCANCODES = 512
    }
}