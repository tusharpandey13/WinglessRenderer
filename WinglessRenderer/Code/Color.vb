Imports System
Imports System.Runtime.InteropServices
Imports OpenTK
Imports OpenTK.Graphics

''' <summary>
''' A struct representing a 32bit argb color.
''' </summary>
''' <remarks>
''' The actual order of the components in the struct is RGBA(one byte each), to conform to how shader languages order color components.
''' </remarks>
<StructLayout(LayoutKind.Sequential)>
Public Structure Color
    Implements IEquatable(Of Color)
    Implements IEquatable(Of Color4)
#Region "Static W3C colors"
    ''' <summary>Default transparent color.</summary>
    Public Shared ReadOnly Transparent As New Color(&H0)
    ''' <summary>Default 'Pink' W3C color (FF C0 CB) / (255, 192, 203).</summary>
    Public Shared ReadOnly Pink As New Color(&HFFFFC0CBUI)
    ''' <summary>Default 'LightPink' W3C color (FF B6 C1) / (255, 182, 193).</summary>
    Public Shared ReadOnly LightPink As New Color(&HFFFFB6C1UI)
    ''' <summary>Default 'HotPink' W3C color (FF 69 B4) / (255, 105, 180).</summary>
    Public Shared ReadOnly HotPink As New Color(&HFFFF69B4UI)
    ''' <summary>Default 'DeepPink' W3C color (FF 14 93) / (255, 20, 147).</summary>
    Public Shared ReadOnly DeepPink As New Color(&HFFFF1493UI)
    ''' <summary>Default 'PaleVioletRed' W3C color (DB 70 93) / (219, 112, 147).</summary>
    Public Shared ReadOnly PaleVioletRed As New Color(&HFFDB7093UI)
    ''' <summary>Default 'MediumVioletRed' W3C color (C7 15 85) / (199, 21, 133).</summary>
    Public Shared ReadOnly MediumVioletRed As New Color(&HFFC71585UI)
    ''' <summary>Default 'LightSalmon' W3C color (FF A0 7A) / (255, 160, 122).</summary>
    Public Shared ReadOnly LightSalmon As New Color(&HFFFFA07AUI)
    ''' <summary>Default 'Salmon' W3C color (FA 80 72) / (250, 128, 114).</summary>
    Public Shared ReadOnly Salmon As New Color(&HFFFA8072UI)
    ''' <summary>Default 'DarkSalmon' W3C color (E9 96 7A) / (233, 150, 122).</summary>
    Public Shared ReadOnly DarkSalmon As New Color(&HFFE9967AUI)
    ''' <summary>Default 'LightCoral' W3C color (F0 80 80) / (240, 128, 128).</summary>
    Public Shared ReadOnly LightCoral As New Color(&HFFF08080UI)
    ''' <summary>Default 'IndianRed' W3C color (CD 5C 5C) / (205, 92, 92).</summary>
    Public Shared ReadOnly IndianRed As New Color(&HFFCD5C5CUI)
    ''' <summary>Default 'Crimson' W3C color (DC 14 3C) / (220, 20, 60).</summary>
    Public Shared ReadOnly Crimson As New Color(&HFFDC143CUI)
    ''' <summary>Default 'FireBrick' W3C color (B2 22 22) / (178, 34, 34).</summary>
    Public Shared ReadOnly FireBrick As New Color(&HFFB22222UI)
    ''' <summary>Default 'DarkRed' W3C color (8B 00 00) / (139, 0, 0).</summary>
    Public Shared ReadOnly DarkRed As New Color(&HFF8B0000UI)
    ''' <summary>Default 'Red' W3C color (FF 00 00) / (255, 0, 0).</summary>
    Public Shared ReadOnly Red As New Color(&HFFFF0000UI)
    ''' <summary>Default 'OrangeRed' W3C color (FF 45 00) / (255, 69, 0).</summary>
    Public Shared ReadOnly OrangeRed As New Color(&HFFFF4500UI)
    ''' <summary>Default 'Tomato' W3C color (FF 63 47) / (255, 99, 71).</summary>
    Public Shared ReadOnly Tomato As New Color(&HFFFF6347UI)
    ''' <summary>Default 'Coral' W3C color (FF 7F 50) / (255, 127, 80).</summary>
    Public Shared ReadOnly Coral As New Color(&HFFFF7F50UI)
    ''' <summary>Default 'DarkOrange' W3C color (FF 8C 00) / (255, 140, 0).</summary>
    Public Shared ReadOnly DarkOrange As New Color(&HFFFF8C00UI)
    ''' <summary>Default 'Orange' W3C color (FF A5 00) / (255, 165, 0).</summary>
    Public Shared ReadOnly Orange As New Color(&HFFFFA500UI)
    ''' <summary>Default 'Gold' W3C color (FF D7 00) / (255, 215, 0).</summary>
    Public Shared ReadOnly Gold As New Color(&HFFFFD700UI)
    ''' <summary>Default 'Yellow' W3C color (FF FF 00) / (255, 255, 0).</summary>
    Public Shared ReadOnly Yellow As New Color(&HFFFFFF00UI)
    ''' <summary>Default 'LightYellow' W3C color (FF FF E0) / (255, 255, 224).</summary>
    Public Shared ReadOnly LightYellow As New Color(&HFFFFFFE0UI)
    ''' <summary>Default 'LemonChiffon' W3C color (FF FA CD) / (255, 250, 205).</summary>
    Public Shared ReadOnly LemonChiffon As New Color(&HFFFFFACDUI)
    ''' <summary>Default 'LightGoldenrodYellow' W3C color (FA FA D2) / (250, 250, 210).</summary>
    Public Shared ReadOnly LightGoldenrodYellow As New Color(&HFFFAFAD2UI)
    ''' <summary>Default 'PapayaWhip' W3C color (FF EF D5) / (255, 239, 213).</summary>
    Public Shared ReadOnly PapayaWhip As New Color(&HFFFFEFD5UI)
    ''' <summary>Default 'Moccasin' W3C color (FF E4 B5) / (255, 228, 181).</summary>
    Public Shared ReadOnly Moccasin As New Color(&HFFFFE4B5UI)
    ''' <summary>Default 'PeachPuff' W3C color (FF DA B9) / (255, 218, 185).</summary>
    Public Shared ReadOnly PeachPuff As New Color(&HFFFFDAB9UI)
    ''' <summary>Default 'PaleGoldenrod' W3C color (EE E8 AA) / (238, 232, 170).</summary>
    Public Shared ReadOnly PaleGoldenrod As New Color(&HFFEEE8AAUI)
    ''' <summary>Default 'Khaki' W3C color (F0 E6 8C) / (240, 230, 140).</summary>
    Public Shared ReadOnly Khaki As New Color(&HFFF0E68CUI)
    ''' <summary>Default 'DarkKhaki' W3C color (BD B7 6B) / (189, 183, 107).</summary>
    Public Shared ReadOnly DarkKhaki As New Color(&HFFBDB76BUI)
    ''' <summary>Default 'Cornsilk' W3C color (FF F8 DC) / (255, 248, 220).</summary>
    Public Shared ReadOnly Cornsilk As New Color(&HFFFFF8DCUI)
    ''' <summary>Default 'BlanchedAlmond' W3C color (FF EB CD) / (255, 235, 205).</summary>
    Public Shared ReadOnly BlanchedAlmond As New Color(&HFFFFEBCDUI)
    ''' <summary>Default 'Bisque' W3C color (FF E4 C4) / (255, 228, 196).</summary>
    Public Shared ReadOnly Bisque As New Color(&HFFFFE4C4UI)
    ''' <summary>Default 'NavajoWhite' W3C color (FF DE AD) / (255, 222, 173).</summary>
    Public Shared ReadOnly NavajoWhite As New Color(&HFFFFDEADUI)
    ''' <summary>Default 'Wheat' W3C color (F5 DE B3) / (245, 222, 179).</summary>
    Public Shared ReadOnly Wheat As New Color(&HFFF5DEB3UI)
    ''' <summary>Default 'BurlyWood' W3C color (DE B8 87) / (222, 184, 135).</summary>
    Public Shared ReadOnly BurlyWood As New Color(&HFFDEB887UI)
    ''' <summary>Default 'Tan' W3C color (D2 B4 8C) / (210, 180, 140).</summary>
    Public Shared ReadOnly Tan As New Color(&HFFD2B48CUI)
    ''' <summary>Default 'RosyBrown' W3C color (BC 8F 8F) / (188, 143, 143).</summary>
    Public Shared ReadOnly RosyBrown As New Color(&HFFBC8F8FUI)
    ''' <summary>Default 'SandyBrown' W3C color (F4 A4 60) / (244, 164, 96).</summary>
    Public Shared ReadOnly SandyBrown As New Color(&HFFF4A460UI)
    ''' <summary>Default 'Goldenrod' W3C color (DA A5 20) / (218, 165, 32).</summary>
    Public Shared ReadOnly Goldenrod As New Color(&HFFDAA520UI)
    ''' <summary>Default 'DarkGoldenrod' W3C color (B8 86 0B) / (184, 134, 11).</summary>
    Public Shared ReadOnly DarkGoldenrod As New Color(&HFFB8860BUI)
    ''' <summary>Default 'Peru' W3C color (CD 85 3F) / (205, 133, 63).</summary>
    Public Shared ReadOnly Peru As New Color(&HFFCD853FUI)
    ''' <summary>Default 'Chocolate' W3C color (D2 69 1E) / (210, 105, 30).</summary>
    Public Shared ReadOnly Chocolate As New Color(&HFFD2691EUI)
    ''' <summary>Default 'SaddleBrown' W3C color (8B 45 13) / (139, 69, 19).</summary>
    Public Shared ReadOnly SaddleBrown As New Color(&HFF8B4513UI)
    ''' <summary>Default 'Sienna' W3C color (A0 52 2D) / (160, 82, 45).</summary>
    Public Shared ReadOnly Sienna As New Color(&HFFA0522DUI)
    ''' <summary>Default 'Brown' W3C color (A5 2A 2A) / (165, 42, 42).</summary>
    Public Shared ReadOnly Brown As New Color(&HFFA52A2AUI)
    ''' <summary>Default 'Maroon' W3C color (80 00 00) / (128, 0, 0).</summary>
    Public Shared ReadOnly Maroon As New Color(&HFF800000UI)
    ''' <summary>Default 'DarkOliveGreen' W3C color (55 6B 2F) / (85, 107, 47).</summary>
    Public Shared ReadOnly DarkOliveGreen As New Color(&HFF556B2FUI)
    ''' <summary>Default 'Olive' W3C color (80 80 00) / (128, 128, 0).</summary>
    Public Shared ReadOnly Olive As New Color(&HFF808000UI)
    ''' <summary>Default 'OliveDrab' W3C color (6B 8E 23) / (107, 142, 35).</summary>
    Public Shared ReadOnly OliveDrab As New Color(&HFF6B8E23UI)
    ''' <summary>Default 'YellowGreen' W3C color (9A CD 32) / (154, 205, 50).</summary>
    Public Shared ReadOnly YellowGreen As New Color(&HFF9ACD32UI)
    ''' <summary>Default 'LimeGreen' W3C color (32 CD 32) / (50, 205, 50).</summary>
    Public Shared ReadOnly LimeGreen As New Color(&HFF32CD32UI)
    ''' <summary>Default 'Lime' W3C color (00 FF 00) / (0, 255, 0).</summary>
    Public Shared ReadOnly Lime As New Color(&HFF00FF00UI)
    ''' <summary>Default 'LawnGreen' W3C color (7C FC 00) / (124, 252, 0).</summary>
    Public Shared ReadOnly LawnGreen As New Color(&HFF7CFC00UI)
    ''' <summary>Default 'Chartreuse' W3C color (7F FF 00) / (127, 255, 0).</summary>
    Public Shared ReadOnly Chartreuse As New Color(&HFF7FFF00UI)
    ''' <summary>Default 'GreenYellow' W3C color (AD FF 2F) / (173, 255, 47).</summary>
    Public Shared ReadOnly GreenYellow As New Color(&HFFADFF2FUI)
    ''' <summary>Default 'SpringGreen' W3C color (00 FF 7F) / (0, 255, 127).</summary>
    Public Shared ReadOnly SpringGreen As New Color(&HFF00FF7FUI)
    ''' <summary>Default 'MediumSpringGreen' W3C color (00 FA 9A) / (0, 250, 154).</summary>
    Public Shared ReadOnly MediumSpringGreen As New Color(&HFF00FA9AUI)
    ''' <summary>Default 'LightGreen' W3C color (90 EE 90) / (144, 238, 144).</summary>
    Public Shared ReadOnly LightGreen As New Color(&HFF90EE90UI)
    ''' <summary>Default 'PaleGreen' W3C color (98 FB 98) / (152, 251, 152).</summary>
    Public Shared ReadOnly PaleGreen As New Color(&HFF98FB98UI)
    ''' <summary>Default 'DarkSeaGreen' W3C color (8F BC 8F) / (143, 188, 143).</summary>
    Public Shared ReadOnly DarkSeaGreen As New Color(&HFF8FBC8FUI)
    ''' <summary>Default 'MediumSeaGreen' W3C color (3C B3 71) / (60, 179, 113).</summary>
    Public Shared ReadOnly MediumSeaGreen As New Color(&HFF3CB371UI)
    ''' <summary>Default 'SeaGreen' W3C color (2E 8B 57) / (46, 139, 87).</summary>
    Public Shared ReadOnly SeaGreen As New Color(&HFF2E8B57UI)
    ''' <summary>Default 'ForestGreen' W3C color (22 8B 22) / (34, 139, 34).</summary>
    Public Shared ReadOnly ForestGreen As New Color(&HFF228B22UI)
    ''' <summary>Default 'Green' W3C color (00 80 00) / (0, 128, 0).</summary>
    Public Shared ReadOnly Green As New Color(&HFF008000UI)
    ''' <summary>Default 'DarkGreen' W3C color (00 64 00) / (0, 100, 0).</summary>
    Public Shared ReadOnly DarkGreen As New Color(&HFF006400UI)
    ''' <summary>Default 'MediumAquamarine' W3C color (66 CD AA) / (102, 205, 170).</summary>
    Public Shared ReadOnly MediumAquamarine As New Color(&HFF66CDAAUI)
    ''' <summary>Default 'Aqua' W3C color (00 FF FF) / (0, 255, 255).</summary>
    Public Shared ReadOnly Aqua As New Color(&HFF00FFFFUI)
    ''' <summary>Default 'Cyan' W3C color (00 FF FF) / (0, 255, 255).</summary>
    Public Shared ReadOnly Cyan As New Color(&HFF00FFFFUI)
    ''' <summary>Default 'LightCyan' W3C color (E0 FF FF) / (224, 255, 255).</summary>
    Public Shared ReadOnly LightCyan As New Color(&HFFE0FFFFUI)
    ''' <summary>Default 'PaleTurquoise' W3C color (AF EE EE) / (175, 238, 238).</summary>
    Public Shared ReadOnly PaleTurquoise As New Color(&HFFAFEEEEUI)
    ''' <summary>Default 'Aquamarine' W3C color (7F FF D4) / (127, 255, 212).</summary>
    Public Shared ReadOnly Aquamarine As New Color(&HFF7FFFD4UI)
    ''' <summary>Default 'Turquoise' W3C color (40 E0 D0) / (64, 224, 208).</summary>
    Public Shared ReadOnly Turquoise As New Color(&HFF40E0D0UI)
    ''' <summary>Default 'MediumTurquoise' W3C color (48 D1 CC) / (72, 209, 204).</summary>
    Public Shared ReadOnly MediumTurquoise As New Color(&HFF48D1CCUI)
    ''' <summary>Default 'DarkTurquoise' W3C color (00 CE D1) / (0, 206, 209).</summary>
    Public Shared ReadOnly DarkTurquoise As New Color(&HFF00CED1UI)
    ''' <summary>Default 'LightSeaGreen' W3C color (20 B2 AA) / (32, 178, 170).</summary>
    Public Shared ReadOnly LightSeaGreen As New Color(&HFF20B2AAUI)
    ''' <summary>Default 'CadetBlue' W3C color (5F 9E A0) / (95, 158, 160).</summary>
    Public Shared ReadOnly CadetBlue As New Color(&HFF5F9EA0UI)
    ''' <summary>Default 'DarkCyan' W3C color (00 8B 8B) / (0, 139, 139).</summary>
    Public Shared ReadOnly DarkCyan As New Color(&HFF008B8BUI)
    ''' <summary>Default 'Teal' W3C color (00 80 80) / (0, 128, 128).</summary>
    Public Shared ReadOnly Teal As New Color(&HFF008080UI)
    ''' <summary>Default 'LightSteelBlue' W3C color (B0 C4 DE) / (176, 196, 222).</summary>
    Public Shared ReadOnly LightSteelBlue As New Color(&HFFB0C4DEUI)
    ''' <summary>Default 'PowderBlue' W3C color (B0 E0 E6) / (176, 224, 230).</summary>
    Public Shared ReadOnly PowderBlue As New Color(&HFFB0E0E6UI)
    ''' <summary>Default 'LightBlue' W3C color (AD D8 E6) / (173, 216, 230).</summary>
    Public Shared ReadOnly LightBlue As New Color(&HFFADD8E6UI)
    ''' <summary>Default 'SkyBlue' W3C color (87 CE EB) / (135, 206, 235).</summary>
    Public Shared ReadOnly SkyBlue As New Color(&HFF87CEEBUI)
    ''' <summary>Default 'LightSkyBlue' W3C color (87 CE FA) / (135, 206, 250).</summary>
    Public Shared ReadOnly LightSkyBlue As New Color(&HFF87CEFAUI)
    ''' <summary>Default 'DeepSkyBlue' W3C color (00 BF FF) / (0, 191, 255).</summary>
    Public Shared ReadOnly DeepSkyBlue As New Color(&HFF00BFFFUI)
    ''' <summary>Default 'DodgerBlue' W3C color (1E 90 FF) / (30, 144, 255).</summary>
    Public Shared ReadOnly DodgerBlue As New Color(&HFF1E90FFUI)
    ''' <summary>Default 'CornflowerBlue' W3C color (64 95 ED) / (100, 149, 237).</summary>
    Public Shared ReadOnly CornflowerBlue As New Color(&HFF6495EDUI)
    ''' <summary>Default 'SteelBlue' W3C color (46 82 B4) / (70, 130, 180).</summary>
    Public Shared ReadOnly SteelBlue As New Color(&HFF4682B4UI)
    ''' <summary>Default 'RoyalBlue' W3C color (41 69 E1) / (65, 105, 225).</summary>
    Public Shared ReadOnly RoyalBlue As New Color(&HFF4169E1UI)
    ''' <summary>Default 'Blue' W3C color (00 00 FF) / (0, 0, 255).</summary>
    Public Shared ReadOnly Blue As New Color(&HFF0000FFUI)
    ''' <summary>Default 'MediumBlue' W3C color (00 00 CD) / (0, 0, 205).</summary>
    Public Shared ReadOnly MediumBlue As New Color(&HFF0000CDUI)
    ''' <summary>Default 'DarkBlue' W3C color (00 00 8B) / (0, 0, 139).</summary>
    Public Shared ReadOnly DarkBlue As New Color(&HFF00008BUI)
    ''' <summary>Default 'Navy' W3C color (00 00 80) / (0, 0, 128).</summary>
    Public Shared ReadOnly Navy As New Color(&HFF000080UI)
    ''' <summary>Default 'MidnightBlue' W3C color (19 19 70) / (25, 25, 112).</summary>
    Public Shared ReadOnly MidnightBlue As New Color(&HFF191970UI)
    ''' <summary>Default 'Lavender' W3C color (E6 E6 FA) / (230, 230, 250).</summary>
    Public Shared ReadOnly Lavender As New Color(&HFFE6E6FAUI)
    ''' <summary>Default 'Thistle' W3C color (D8 BF D8) / (216, 191, 216).</summary>
    Public Shared ReadOnly Thistle As New Color(&HFFD8BFD8UI)
    ''' <summary>Default 'Plum' W3C color (DD A0 DD) / (221, 160, 221).</summary>
    Public Shared ReadOnly Plum As New Color(&HFFDDA0DDUI)
    ''' <summary>Default 'Violet' W3C color (EE 82 EE) / (238, 130, 238).</summary>
    Public Shared ReadOnly Violet As New Color(&HFFEE82EEUI)
    ''' <summary>Default 'Orchid' W3C color (DA 70 D6) / (218, 112, 214).</summary>
    Public Shared ReadOnly Orchid As New Color(&HFFDA70D6UI)
    ''' <summary>Default 'Fuchsia' W3C color (FF 00 FF) / (255, 0, 255).</summary>
    Public Shared ReadOnly Fuchsia As New Color(&HFFFF00FFUI)
    ''' <summary>Default 'Magenta' W3C color (FF 00 FF) / (255, 0, 255).</summary>
    Public Shared ReadOnly Magenta As New Color(&HFFFF00FFUI)
    ''' <summary>Default 'MediumOrchid' W3C color (BA 55 D3) / (186, 85, 211).</summary>
    Public Shared ReadOnly MediumOrchid As New Color(&HFFBA55D3UI)
    ''' <summary>Default 'MediumPurple' W3C color (93 70 DB) / (147, 112, 219).</summary>
    Public Shared ReadOnly MediumPurple As New Color(&HFF9370DBUI)
    ''' <summary>Default 'BlueViolet' W3C color (8A 2B E2) / (138, 43, 226).</summary>
    Public Shared ReadOnly BlueViolet As New Color(&HFF8A2BE2UI)
    ''' <summary>Default 'DarkViolet' W3C color (94 00 D3) / (148, 0, 211).</summary>
    Public Shared ReadOnly DarkViolet As New Color(&HFF9400D3UI)
    ''' <summary>Default 'DarkOrchid' W3C color (99 32 CC) / (153, 50, 204).</summary>
    Public Shared ReadOnly DarkOrchid As New Color(&HFF9932CCUI)
    ''' <summary>Default 'DarkMagenta' W3C color (8B 00 8B) / (139, 0, 139).</summary>
    Public Shared ReadOnly DarkMagenta As New Color(&HFF8B008BUI)
    ''' <summary>Default 'Purple' W3C color (80 00 80) / (128, 0, 128).</summary>
    Public Shared ReadOnly Purple As New Color(&HFF800080UI)
    ''' <summary>Default 'Indigo' W3C color (4B 00 82) / (75, 0, 130).</summary>
    Public Shared ReadOnly Indigo As New Color(&HFF4B0082UI)
    ''' <summary>Default 'DarkSlateBlue' W3C color (48 3D 8B) / (72, 61, 139).</summary>
    Public Shared ReadOnly DarkSlateBlue As New Color(&HFF483D8BUI)
    ''' <summary>Default 'SlateBlue' W3C color (6A 5A CD) / (106, 90, 205).</summary>
    Public Shared ReadOnly SlateBlue As New Color(&HFF6A5ACDUI)
    ''' <summary>Default 'MediumSlateBlue' W3C color (7B 68 EE) / (123, 104, 238).</summary>
    Public Shared ReadOnly MediumSlateBlue As New Color(&HFF7B68EEUI)
    ''' <summary>Default 'White' W3C color (FF FF FF) / (255, 255, 255).</summary>
    Public Shared ReadOnly White As New Color(&HFFFFFFFFUI)
    ''' <summary>Default 'Snow' W3C color (FF FA FA) / (255, 250, 250).</summary>
    Public Shared ReadOnly Snow As New Color(&HFFFFFAFAUI)
    ''' <summary>Default 'Honeydew' W3C color (F0 FF F0) / (240, 255, 240).</summary>
    Public Shared ReadOnly Honeydew As New Color(&HFFF0FFF0UI)
    ''' <summary>Default 'MintCream' W3C color (F5 FF FA) / (245, 255, 250).</summary>
    Public Shared ReadOnly MintCream As New Color(&HFFF5FFFAUI)
    ''' <summary>Default 'Azure' W3C color (F0 FF FF) / (240, 255, 255).</summary>
    Public Shared ReadOnly Azure As New Color(&HFFF0FFFFUI)
    ''' <summary>Default 'AliceBlue' W3C color (F0 F8 FF) / (240, 248, 255).</summary>
    Public Shared ReadOnly AliceBlue As New Color(&HFFF0F8FFUI)
    ''' <summary>Default 'GhostWhite' W3C color (F8 F8 FF) / (248, 248, 255).</summary>
    Public Shared ReadOnly GhostWhite As New Color(&HFFF8F8FFUI)
    ''' <summary>Default 'WhiteSmoke' W3C color (F5 F5 F5) / (245, 245, 245).</summary>
    Public Shared ReadOnly WhiteSmoke As New Color(&HFFF5F5F5UI)
    ''' <summary>Default 'Seashell' W3C color (FF F5 EE) / (255, 245, 238).</summary>
    Public Shared ReadOnly Seashell As New Color(&HFFFFF5EEUI)
    ''' <summary>Default 'Beige' W3C color (F5 F5 DC) / (245, 245, 220).</summary>
    Public Shared ReadOnly Beige As New Color(&HFFF5F5DCUI)
    ''' <summary>Default 'OldLace' W3C color (FD F5 E6) / (253, 245, 230).</summary>
    Public Shared ReadOnly OldLace As New Color(&HFFFDF5E6UI)
    ''' <summary>Default 'FloralWhite' W3C color (FF FA F0) / (255, 250, 240).</summary>
    Public Shared ReadOnly FloralWhite As New Color(&HFFFFFAF0UI)
    ''' <summary>Default 'Ivory' W3C color (FF FF F0) / (255, 255, 240).</summary>
    Public Shared ReadOnly Ivory As New Color(&HFFFFFFF0UI)
    ''' <summary>Default 'AntiqueWhite' W3C color (FA EB D7) / (250, 235, 215).</summary>
    Public Shared ReadOnly AntiqueWhite As New Color(&HFFFAEBD7UI)
    ''' <summary>Default 'Linen' W3C color (FA F0 E6) / (250, 240, 230).</summary>
    Public Shared ReadOnly Linen As New Color(&HFFFAF0E6UI)
    ''' <summary>Default 'LavenderBlush' W3C color (FF F0 F5) / (255, 240, 245).</summary>
    Public Shared ReadOnly LavenderBlush As New Color(&HFFFFF0F5UI)
    ''' <summary>Default 'MistyRose' W3C color (FF E4 E1) / (255, 228, 225).</summary>
    Public Shared ReadOnly MistyRose As New Color(&HFFFFE4E1UI)
    ''' <summary>Default 'Gainsboro' W3C color (DC DC DC) / (220, 220, 220).</summary>
    Public Shared ReadOnly Gainsboro As New Color(&HFFDCDCDCUI)
    ''' <summary>Default 'LightGray' W3C color (D3 D3 D3) / (211, 211, 211).</summary>
    Public Shared ReadOnly LightGray As New Color(&HFFD3D3D3UI)
    ''' <summary>Default 'Silver' W3C color (C0 C0 C0) / (192, 192, 192).</summary>
    Public Shared ReadOnly Silver As New Color(&HFFC0C0C0UI)
    ''' <summary>Default 'DarkGray' W3C color (A9 A9 A9) / (169, 169, 169).</summary>
    Public Shared ReadOnly DarkGray As New Color(&HFFA9A9A9UI)
    ''' <summary>Default 'Gray' W3C color (80 80 80) / (128, 128, 128).</summary>
    Public Shared ReadOnly Gray As New Color(&HFF808080UI)
    ''' <summary>Default 'DimGray' W3C color (69 69 69) / (105, 105, 105).</summary>
    Public Shared ReadOnly DimGray As New Color(&HFF696969UI)
    ''' <summary>Default 'LightSlateGray' W3C color (77 88 99) / (119, 136, 153).</summary>
    Public Shared ReadOnly LightSlateGray As New Color(&HFF778899UI)
    ''' <summary>Default 'SlateGray' W3C color (70 80 90) / (112, 128, 144).</summary>
    Public Shared ReadOnly SlateGray As New Color(&HFF708090UI)
    ''' <summary>Default 'DarkSlateGray' W3C color (2F 4F 4F) / (47, 79, 79).</summary>
    Public Shared ReadOnly DarkSlateGray As New Color(&HFF2F4F4FUI)
    ''' <summary>Default 'Black' W3C color (00 00 00) / (0, 0, 0).</summary>
    Public Shared ReadOnly Black As New Color(&HFF000000UI)

#End Region

#Region "Fields"
    Private ReadOnly m_r As Byte, m_g As Byte, m_b As Byte, m_a As Byte

#End Region

#Region "Constructors"

    ''' <summary>
    ''' Constructs a color from a red, green, blue and alpha value.
    ''' </summary>
    ''' <param name="r">The red value.</param>
    ''' <param name="g">The green value.</param>
    ''' <param name="b">The blue value.</param>
    ''' <param name="a">The alpha value.</param>
    Public Sub New(r As Byte, g As Byte, b As Byte, Optional a As Byte = 255)
        Me.m_r = r
        Me.m_g = g
        Me.m_b = b
        Me.m_a = a
    End Sub

    ''' <summary>
    ''' Constructs a color from a 32bit unsigned integer including the color components in the order ARGB.
    ''' </summary>
    ''' <param name="argb">The unsigned integer representing the color.</param>
    Public Sub New(argb As UInteger)
        Me.m_a = CByte((argb >> 24) And 255)
        Me.m_r = CByte((argb >> 16) And 255)
        Me.m_g = CByte((argb >> 8) And 255)
        Me.m_b = CByte(argb And 255)
    End Sub

    ''' <summary>
    ''' Constructs a color from another color and a new alpha value.
    ''' </summary>
    ''' <param name="color__1">The template color.</param>
    ''' <param name="newAlpha">The new alpha value.</param>
    Public Sub New(color__1 As Color, newAlpha As Byte)
        Me.m_r = color__1.R
        Me.m_g = color__1.G
        Me.m_b = color__1.B
        Me.m_a = newAlpha
    End Sub
    Public Sub New(c As Color4)
        m_r = c.R
        m_g = c.G
        m_b = c.B
        m_a = c.A
    End Sub
#End Region

#Region "Static Methods"

#Region "Construction"

    ''' <summary>
    ''' Creates a color from hue, saturation and value.
    ''' </summary>
    ''' <param name="h">Hue of the color (0-2pi).</param>
    ''' <param name="s">Saturation of the color (0-1).</param>
    ''' <param name="v">Value of the color (0-1).</param>
    ''' <param name="a">Alpha of the color.</param>
    ''' <returns>The constructed color.</returns>
    Public Shared Function FromHSVA(h As Single, s As Single, v As Single, Optional a As Byte = 255) As Color
        Dim chroma As Single = v * s
        h /= MathHelper.PiOver3
        Dim x As Single = chroma * (1 - Math.Abs((h Mod 2) - 1))
        Dim m As Single = v - chroma
        Dim r As Single, g As Single, b As Single
        If h > 6 OrElse h < 0 Then
            r = 0
            g = 0
            b = 0
        ElseIf h < 1 Then
            r = chroma
            g = x
            b = 0
        ElseIf h < 2 Then
            r = x
            g = chroma
            b = 0
        ElseIf h < 3 Then
            r = 0
            g = chroma
            b = x
        ElseIf h < 4 Then
            r = 0
            g = x
            b = chroma
        ElseIf h < 5 Then
            r = x
            g = 0
            b = chroma
        Else
            r = chroma
            g = 0
            b = x
        End If
        Return New Color(CByte((r + m) * 255), CByte((g + m) * 255), CByte((b + m) * 255), a)
    End Function

    ''' <summary>
    ''' Creates a new gray color.
    ''' </summary>
    ''' <param name="value">The value (brightness) of the color.</param>
    ''' <param name="alpha">The opacity of the color.</param>
    ''' <returns>A gray color with the given value and transparency.</returns>
    Public Shared Function GrayScale(value As Byte, Optional alpha As Byte = 255) As Color
        Return New Color(value, value, value, alpha)
    End Function

#End Region

#Region "Other"

    ''' <summary>
    ''' Linearly interpolates between two colors and returns the result.
    ''' </summary>
    ''' <param name="color0">The first color.</param>
    ''' <param name="color1">The second color.</param>
    ''' <param name="p">Interpolation parameter, is clamped to [0, 1]</param>
    ''' <returns>The interpolated color</returns>
    Public Shared Function Lerp(color0 As Color, color1 As Color, p As Single) As Color
        If p <= 0 Then
            Return color0
        End If
        If p >= 1 Then
            Return color1
        End If

        Dim q As Single = 1 - p
        Return New Color(CByte(color0.R * q + color1.R * p), CByte(color0.G * q + color1.G * p), CByte(color0.B * q + color1.B * p), CByte(color0.A * q + color1.A * p))
    End Function

#End Region

#End Region

#Region "Properties"

    ''' <summary>
    ''' The color's red value
    ''' </summary>
    Public ReadOnly Property R() As Byte
        Get
            Return Me.m_r
        End Get
    End Property
    ''' <summary>
    ''' The color's green value
    ''' </summary>
    Public ReadOnly Property G() As Byte
        Get
            Return Me.m_g
        End Get
    End Property
    ''' <summary>
    ''' The color's blue value
    ''' </summary>
    Public ReadOnly Property B() As Byte
        Get
            Return Me.m_b
        End Get
    End Property
    ''' <summary>
    ''' The color's alpha value (0 = fully transparent, 255 = fully opaque)
    ''' </summary>
    Public ReadOnly Property A() As Byte
        Get
            Return Me.m_a
        End Get
    End Property


    ''' <summary>
    ''' The color, represented as 32bit unsigned integer, with its color components in the order ARGB.
    ''' </summary>
    Public ReadOnly Property ARGB() As UInteger
        Get
            Return (CUInt(Me.m_a) << 24) Or (CUInt(Me.m_r) << 16) Or (CUInt(Me.m_g) << 8) Or Me.m_b
        End Get
    End Property

    ''' <summary>
    ''' Returns the value (lightness) of the color in the range 0 to 1.
    ''' </summary>
    Public ReadOnly Property Value() As Single
        Get
            Return Math.Max(Me.m_r, Math.Max(Me.m_g, Me.m_b)) / 255.0F
        End Get
    End Property

    ''' <summary>
    ''' Returns the saturation of the color in the range 0 to 1.
    ''' </summary>
    Public ReadOnly Property Saturation() As Single
        Get
            Dim max = Math.Max(Me.m_r, Math.Max(Me.m_g, Me.m_b))
            If max = 0 Then
                Return 0
            End If

            Dim min = Math.Min(Me.m_r, Math.Min(Me.m_g, Me.m_b))

            Return CSng(max - min) / max
        End Get
    End Property

    ''' <summary>
    ''' Returns the hue of the color in the range 0 to 2pi.
    ''' </summary>
    Public ReadOnly Property Hue() As Single
        Get
            Dim r As Single = Me.m_r / 255.0F
            Dim g As Single = Me.m_g / 255.0F
            Dim b As Single = Me.m_b / 255.0F

            Dim h As Single

            Dim max = Math.Max(r, Math.Max(g, b))
            If max = 0 Then
                Return 0
            End If

            Dim min = Math.Min(r, Math.Min(g, b))
            Dim delta = max - min

            If r = max Then
                h = (g - b) / delta
            ElseIf g = max Then
                h = 2 + (b - r) / delta
            Else
                h = 4 + (r - g) / delta
            End If

            h *= CSng(Math.PI / 3)
            If h < 0 Then
                h += CSng(Math.PI * 2)
            End If

            Return h
        End Get
    End Property

    ''' <summary>
    ''' Converts the color to a float vector with components Hue, Saturation, Value in that order.
    ''' The range of the hue is 0 to 2pi, the range of all over components is 0 to 1.
    ''' </summary>
    Public ReadOnly Property AsHSVAVector() As Vector4
        Get
            Dim r As Single = Me.m_r / 255.0F
            Dim g As Single = Me.m_g / 255.0F
            Dim b As Single = Me.m_b / 255.0F
            Dim a As Single = Me.m_a / 255.0F

            Dim max = Math.Max(r, Math.Max(g, b))
            If max = 0 Then
                Return New Vector4(0, 0, 0, a)
            End If

            Dim v = max
            Dim min = Math.Min(r, Math.Min(g, b))
            Dim delta = max - min

            Dim s = delta / max

            Dim h As Single

            If r = max Then
                h = (g - b) / delta
            ElseIf g = max Then
                h = 2 + (b - r) / delta
            Else
                h = 4 + (r - g) / delta
            End If

            h *= CSng(Math.PI / 3)
            If h < 0 Then
                h += CSng(Math.PI * 2)
            End If

            Return New Vector4(h, s, v, a)
        End Get
    End Property

    ''' <summary>
    ''' Converts the color to a float vector with components RGBA in that order.
    ''' The range of each component is 0 to 1.
    ''' </summary>
    Public ReadOnly Property AsRGBAVector() As Vector4
        Get
            Return New Vector4(Me.m_r / 255.0F, Me.m_g / 255.0F, Me.m_b / 255.0F, Me.m_a / 255.0F)
        End Get
    End Property


    ''' <summary>
    ''' The color, pre-multiplied with its alpha value.
    ''' </summary>
    Public ReadOnly Property Premultiplied() As Color
        Get
            Dim a As Single = Me.m_a / 255.0F
            Return New Color(CByte(Me.m_r * a), CByte(Me.m_g * a), CByte(Me.m_b * a), Me.m_a)
        End Get
    End Property

    Public ReadOnly Property Color4 As Color4
        Get
            Return New Color4(CSng(m_r / 255), CSng(m_g / 255), CSng(m_b / 255), CSng(m_a / 255))
        End Get
    End Property
#End Region

#Region "Methods"

    ''' <summary>
    ''' Returns a new color with the same RGB values, but a different alpha value.
    ''' </summary>
    ''' <param name="alpha">The new alpha value (0-255).</param>
    Public Function WithAlpha(Optional alpha As Byte = 0) As Color
        Return New Color(Me, alpha)
    End Function

    ''' <summary>
    ''' Returns a new color with the same RGB values, but a different alpha value.
    ''' </summary>
    ''' <param name="alpha">The new alpha value (0-1).</param>
    ''' <remarks>
    ''' This expects alpha values in the range 0 to 1.
    ''' Values outside that range will result in overflow of the valid range and may lead to undesirable values.</remarks>
    Public Function WithAlpha(alpha As Single) As Color
        Return Me.WithAlpha(CByte(255 * alpha))
    End Function

#Region "Equals, GetHashCode, ToString"

    ''' <summary>
    ''' Checks whether this color is the same as another.
    ''' </summary>
    Public Overloads Function Equals(other As Color) As Boolean Implements IEquatable(Of Color).Equals
        Return Me.m_r = other.R AndAlso Me.m_g = other.G AndAlso Me.m_b = other.B AndAlso Me.m_a = other.A
    End Function
    Public Overloads Function Equals(other As Color4) As Boolean Implements IEquatable(Of Color4).Equals
        Return Me.m_r / 255.0F = other.R AndAlso Me.m_g / 255.0F = other.G AndAlso Me.m_b / 255.0F = other.B AndAlso Me.m_a / 255.0F = other.A
    End Function
    ''' <summary>
    ''' Checks whether this color is the same as another.
    ''' </summary>
    Public Overrides Function Equals(obj As Object) As Boolean
        If ReferenceEquals(Nothing, obj) Then
            Return False
        End If
        Return TypeOf obj Is Color AndAlso Equals(CType(obj, Color))
    End Function

    ''' <summary>
    ''' Returns the hash code for this instance.
    ''' </summary>
    Public Overrides Function GetHashCode() As Integer
        Dim hashCode As Integer = Me.m_r.GetHashCode()
        hashCode = (hashCode * 397) Xor Me.m_g.GetHashCode()
        hashCode = (hashCode * 397) Xor Me.m_b.GetHashCode()
        hashCode = (hashCode * 397) Xor Me.m_a.GetHashCode()
        Return hashCode

    End Function

    ''' <summary>
    ''' Returns a hexadecimal <see cref="System.String" /> that represents this color.
    ''' </summary>
    ''' <returns>
    ''' A hexadecimal <see cref="System.String" /> that represents this color.
    ''' </returns>
    Public Overrides Function ToString() As String
        Return "#" + Me.ARGB.ToString("X8")
    End Function
#End Region

#End Region

#Region "Operators"

    ''' <summary>
    ''' Casts the color to equivalent <see cref="System.Drawing.Color"/>
    ''' </summary>
    ''' <param name="color">The color.</param>
    ''' <returns><see cref="System.Drawing.Color"/></returns>
    Public Shared Widening Operator CType(color As Color) As System.Drawing.Color
        Return System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B)
    End Operator
    ''' <summary>
    ''' Casts the color to equivalent <see cref="Color4"/>
    ''' </summary>
    ''' <param name="color">The color.</param>
    ''' <returns><see cref="Color4"/></returns>
    Public Shared Widening Operator CType(color As Color) As Color4
        Return New Color4(CSng(color.R / 255), CSng(color.G / 255), CSng(color.B / 255), CSng(color.A / 255))
    End Operator

    ''' <summary>
    ''' Compares two colors for equality.
    ''' </summary>
    Public Shared Operator =(color1 As Color, color2 As Color) As Boolean
        Return color1.Equals(color2)
    End Operator

    ''' <summary>
    ''' Compares two colors for inequality.
    ''' </summary>
    Public Shared Operator <>(color1 As Color, color2 As Color) As Boolean
        Return Not (color1 = color2)
    End Operator

    ''' <summary>
    ''' Multiplies all components of the color by a given scalar.
    ''' Note that scalar values outside the range of 0 to 1 may result in overflow and cause unexpected results.
    ''' </summary>
    Public Shared Operator *(color As Color, scalar As Single) As Color
        Return New Color(CByte(color.R * scalar), CByte(color.G * scalar), CByte(color.B * scalar), CByte(color.A * scalar))
    End Operator

    ''' <summary>
    ''' Multiplies all components of the color by a given scalar.
    ''' Note that scalar values outside the range of 0 to 1 may result in overflow and cause unexpected results.
    ''' </summary>
    Public Shared Operator *(scalar As Single, color As Color) As Color
        Return color * scalar
    End Operator



#End Region

End Structure
Public Module ColorHelper
#Region "Color"
    Friend Function Col(a As Byte, r As Byte, g As Byte, b As Byte, sat!) As Color
        Return New Color(CByte(clamp(r * sat, 0, 255)), CByte(clamp(g * sat, 0, 255)), CByte(clamp(b * sat, 0, 255)), a)
    End Function
    Friend Function Col(a As Byte, r As Byte, g As Byte, b As Byte) As Color
        Return Col(a, r, g, b, 1)
    End Function
    Friend Function Col(r As Byte, g As Byte, b As Byte) As Color
        Return Col(255, r, g, b)
    End Function
    Friend Function Col(c As Color, sat!) As Color
        Return Col(c.A, c.R, c.G, c.B, sat)
    End Function
    Friend Function Col(n As Byte) As Color
        Return Col(n, n, n)
    End Function
    Friend Function Col(a As Byte, n As Byte) As Color
        Return Col(a, n, n, n)
    End Function
    Friend Function Col(a As Byte, c As Color) As Color
        Return Col(a, c.R, c.G, c.B, 1)
    End Function
    Friend Function resCol(c As Color) As Color
        Dim t = (c.R + c.G + c.B) / 3
        If t < 128 Then Return Color.White Else Return Color.Black
    End Function

    'lum = Y=0.3RED+0.59GREEN+0.11Blue   rgb(y,y,y)
    Friend Function invert(c As Color) As Color
        Return Col(CByte(CInt(c.A)), CByte(CInt(255 - c.R)), CByte(CInt(255 - c.G)), CByte(CInt(255 - c.B)))
    End Function

    Friend Function bw(c As Color) As Color
        Dim y = CByte(CInt(c.R) * 0.3) + CByte(CInt(c.G) * 0.59) + CByte(CInt(c.B) * 0.11)
        Return Col(CByte(CInt(c.A)), y)
    End Function
    Friend Function blendCol(c1 As Color, c2 As Color, Optional r! = 0.5) As Color
        Return Color.Lerp(c1, c2, r)
    End Function

#End Region
End Module