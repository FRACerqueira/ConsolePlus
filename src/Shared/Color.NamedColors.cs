
// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

namespace ConsolePlusLibrary
{
    public readonly partial struct Color
    {
        #region Predefined Colors

        /// <summary>
        /// Gets CSS named predefined colors.
        /// </summary>

        /// <summary>
        /// Gets the CSS color 'aliceblue' (RGB 240,248,255).
        /// </summary>
        public static Color Aliceblue { get; } = new Color(240, 248, 255);

        /// <summary>
        /// Gets the CSS color 'antiquewhite' (RGB 250,235,215).
        /// </summary>
        public static Color Antiquewhite { get; } = new Color(250, 235, 215);

        /// <summary>
        /// Gets the CSS color 'aqua' (RGB 0,255,255).
        /// </summary>
        public static Color Aqua { get; } = new Color(0, 255, 255);

        /// <summary>
        /// Gets the CSS color 'aquamarine' (RGB 127,255,212).
        /// </summary>
        public static Color Aquamarine { get; } = new Color(127, 255, 212);

        /// <summary>
        /// Gets the CSS color 'azure' (RGB 240,255,255).
        /// </summary>
        public static Color Azure { get; } = new Color(240, 255, 255);

        /// <summary>
        /// Gets the CSS color 'beige' (RGB 245,245,220).
        /// </summary>
        public static Color Beige { get; } = new Color(245, 245, 220);

        /// <summary>
        /// Gets the CSS color 'bisque' (RGB 255,228,196).
        /// </summary>
        public static Color Bisque { get; } = new Color(255, 228, 196);

        /// <summary>
        /// Gets the CSS color 'black' (RGB 0,0,0).
        /// </summary>
        public static Color Black { get; } = new Color(0, 0, 0);

        /// <summary>
        /// Gets the CSS color 'blanchedalmond' (RGB 255,235,205).
        /// </summary>
        public static Color Blanchedalmond { get; } = new Color(255, 235, 205);

        /// <summary>
        /// Gets the CSS color 'blue' (RGB 0,0,255).
        /// </summary>
        public static Color Blue { get; } = new Color(0, 0, 255);

        /// <summary>
        /// Gets the CSS color 'blueviolet' (RGB 138,43,226).
        /// </summary>
        public static Color Blueviolet { get; } = new Color(138, 43, 226);

        /// <summary>
        /// Gets the CSS color 'brown' (RGB 165,42,42).
        /// </summary>
        public static Color Brown { get; } = new Color(165, 42, 42);

        /// <summary>
        /// Gets the CSS color 'burlywood' (RGB 222,184,135).
        /// </summary>
        public static Color Burlywood { get; } = new Color(222, 184, 135);

        /// <summary>
        /// Gets the CSS color 'cadetblue' (RGB 95,158,160).
        /// </summary>
        public static Color Cadetblue { get; } = new Color(95, 158, 160);

        /// <summary>
        /// Gets the CSS color 'chartreuse' (RGB 127,255,0).
        /// </summary>
        public static Color Chartreuse { get; } = new Color(127, 255, 0);

        /// <summary>
        /// Gets the CSS color 'chocolate' (RGB 210,105,30).
        /// </summary>
        public static Color Chocolate { get; } = new Color(210, 105, 30);

        /// <summary>
        /// Gets the CSS color 'coral' (RGB 255,127,80).
        /// </summary>
        public static Color Coral { get; } = new Color(255, 127, 80);

        /// <summary>
        /// Gets the CSS color 'cornflowerblue' (RGB 100,149,237).
        /// </summary>
        public static Color Cornflowerblue { get; } = new Color(100, 149, 237);

        /// <summary>
        /// Gets the CSS color 'cornsilk' (RGB 255,248,220).
        /// </summary>
        public static Color Cornsilk { get; } = new Color(255, 248, 220);

        /// <summary>
        /// Gets the CSS color 'crimson' (RGB 220,20,60).
        /// </summary>
        public static Color Crimson { get; } = new Color(220, 20, 60);

        /// <summary>
        /// Gets the CSS color 'cyan' (RGB 0,255,255).
        /// </summary>
        public static Color Cyan { get; } = new Color(0, 255, 255);

        /// <summary>
        /// Gets the CSS color 'darkblue' (RGB 0,0,139).
        /// </summary>
        public static Color Darkblue { get; } = new Color(0, 0, 139);

        /// <summary>
        /// Gets the CSS color 'darkcyan' (RGB 0,139,139).
        /// </summary>
        public static Color Darkcyan { get; } = new Color(0, 139, 139);

        /// <summary>
        /// Gets the CSS color 'darkgoldenrod' (RGB 184,134,11).
        /// </summary>
        public static Color Darkgoldenrod { get; } = new Color(184, 134, 11);

        /// <summary>
        /// Gets the CSS color 'darkgray' (RGB 169,169,169).
        /// </summary>
        public static Color Darkgray { get; } = new Color(169, 169, 169);

        /// <summary>
        /// Gets the CSS color 'darkgrey' (RGB 169,169,169).
        /// </summary>
        public static Color Darkgrey { get; } = new Color(169, 169, 169);

        /// <summary>
        /// Gets the CSS color 'darkgreen' (RGB 0,100,0).
        /// </summary>
        public static Color Darkgreen { get; } = new Color(0, 100, 0);

        /// <summary>
        /// Gets the CSS color 'darkkhaki' (RGB 189,183,107).
        /// </summary>
        public static Color Darkkhaki { get; } = new Color(189, 183, 107);

        /// <summary>
        /// Gets the CSS color 'darkmagenta' (RGB 139,0,139).
        /// </summary>
        public static Color Darkmagenta { get; } = new Color(139, 0, 139);

        /// <summary>
        /// Gets the CSS color 'darkolivegreen' (RGB 85,107,47).
        /// </summary>
        public static Color Darkolivegreen { get; } = new Color(85, 107, 47);

        /// <summary>
        /// Gets the CSS color 'darkorange' (RGB 255,140,0).
        /// </summary>
        public static Color Darkorange { get; } = new Color(255, 140, 0);

        /// <summary>
        /// Gets the CSS color 'darkorchid' (RGB 153,50,204).
        /// </summary>
        public static Color Darkorchid { get; } = new Color(153, 50, 204);

        /// <summary>
        /// Gets the CSS color 'darkred' (RGB 139,0,0).
        /// </summary>
        public static Color Darkred { get; } = new Color(139, 0, 0);

        /// <summary>
        /// Gets the CSS color 'darksalmon' (RGB 233,150,122).
        /// </summary>
        public static Color Darksalmon { get; } = new Color(233, 150, 122);

        /// <summary>
        /// Gets the CSS color 'darkseagreen' (RGB 143,188,143).
        /// </summary>
        public static Color Darkseagreen { get; } = new Color(143, 188, 143);

        /// <summary>
        /// Gets the CSS color 'darkslateblue' (RGB 72,61,139).
        /// </summary>
        public static Color Darkslateblue { get; } = new Color(72, 61, 139);

        /// <summary>
        /// Gets the CSS color 'darkslategray' (RGB 47,79,79).
        /// </summary>
        public static Color Darkslategray { get; } = new Color(47, 79, 79);

        /// <summary>
        /// Gets the CSS color 'darkslategrey' (RGB 47,79,79).
        /// </summary>
        public static Color Darkslategrey { get; } = new Color(47, 79, 79);

        /// <summary>
        /// Gets the CSS color 'darkturquoise' (RGB 0,206,209).
        /// </summary>
        public static Color Darkturquoise { get; } = new Color(0, 206, 209);

        /// <summary>
        /// Gets the CSS color 'darkviolet' (RGB 148,0,211).
        /// </summary>
        public static Color Darkviolet { get; } = new Color(148, 0, 211);

        /// <summary>
        /// Gets the CSS color 'deeppink' (RGB 255,20,147).
        /// </summary>
        public static Color Deeppink { get; } = new Color(255, 20, 147);

        /// <summary>
        /// Gets the CSS color 'deepskyblue' (RGB 0,191,255).
        /// </summary>
        public static Color Deepskyblue { get; } = new Color(0, 191, 255);

        /// <summary>
        /// Gets the CSS color 'dimgray' (RGB 105,105,105).
        /// </summary>
        public static Color Dimgray { get; } = new Color(105, 105, 105);

        /// <summary>
        /// Gets the CSS color 'dimgrey' (RGB 105,105,105).
        /// </summary>
        public static Color Dimgrey { get; } = new Color(105, 105, 105);

        /// <summary>
        /// Gets the CSS color 'dodgerblue' (RGB 30,144,255).
        /// </summary>
        public static Color Dodgerblue { get; } = new Color(30, 144, 255);

        /// <summary>
        /// Gets the CSS color 'firebrick' (RGB 178,34,34).
        /// </summary>
        public static Color Firebrick { get; } = new Color(178, 34, 34);

        /// <summary>
        /// Gets the CSS color 'floralwhite' (RGB 255,250,240).
        /// </summary>
        public static Color Floralwhite { get; } = new Color(255, 250, 240);

        /// <summary>
        /// Gets the CSS color 'forestgreen' (RGB 34,139,34).
        /// </summary>
        public static Color Forestgreen { get; } = new Color(34, 139, 34);

        /// <summary>
        /// Gets the CSS color 'fuchsia' (RGB 255,0,255).
        /// </summary>
        public static Color Fuchsia { get; } = new Color(255, 0, 255);

        /// <summary>
        /// Gets the CSS color 'gainsboro' (RGB 220,220,220).
        /// </summary>
        public static Color Gainsboro { get; } = new Color(220, 220, 220);

        /// <summary>
        /// Gets the CSS color 'ghostwhite' (RGB 248,248,255).
        /// </summary>
        public static Color Ghostwhite { get; } = new Color(248, 248, 255);

        /// <summary>
        /// Gets the CSS color 'gold' (RGB 255,215,0).
        /// </summary>
        public static Color Gold { get; } = new Color(255, 215, 0);

        /// <summary>
        /// Gets the CSS color 'goldenrod' (RGB 218,165,32).
        /// </summary>
        public static Color Goldenrod { get; } = new Color(218, 165, 32);

        /// <summary>
        /// Gets the CSS color 'gray' (RGB 128,128,128).
        /// </summary>
        public static Color Gray { get; } = new Color(128, 128, 128);

        /// <summary>
        /// Gets the CSS color 'grey' (RGB 128,128,128).
        /// </summary>
        public static Color Grey { get; } = new Color(128, 128, 128);

        /// <summary>
        /// Gets the CSS color 'green' (RGB 0,128,0).
        /// </summary>
        public static Color Green { get; } = new Color(0, 128, 0);

        /// <summary>
        /// Gets the CSS color 'greenyellow' (RGB 173,255,47).
        /// </summary>
        public static Color Greenyellow { get; } = new Color(173, 255, 47);

        /// <summary>
        /// Gets the CSS color 'honeydew' (RGB 240,255,240).
        /// </summary>
        public static Color Honeydew { get; } = new Color(240, 255, 240);

        /// <summary>
        /// Gets the CSS color 'hotpink' (RGB 255,105,180).
        /// </summary>
        public static Color Hotpink { get; } = new Color(255, 105, 180);

        /// <summary>
        /// Gets the CSS color 'indianred' (RGB 205,92,92).
        /// </summary>
        public static Color Indianred { get; } = new Color(205, 92, 92);

        /// <summary>
        /// Gets the CSS color 'indigo' (RGB 75,0,130).
        /// </summary>
        public static Color Indigo { get; } = new Color(75, 0, 130);

        /// <summary>
        /// Gets the CSS color 'ivory' (RGB 255,255,240).
        /// </summary>
        public static Color Ivory { get; } = new Color(255, 255, 240);

        /// <summary>
        /// Gets the CSS color 'khaki' (RGB 240,230,140).
        /// </summary>
        public static Color Khaki { get; } = new Color(240, 230, 140);

        /// <summary>
        /// Gets the CSS color 'lavender' (RGB 230,230,250).
        /// </summary>
        public static Color Lavender { get; } = new Color(230, 230, 250);

        /// <summary>
        /// Gets the CSS color 'lavenderblush' (RGB 255,240,245).
        /// </summary>
        public static Color Lavenderblush { get; } = new Color(255, 240, 245);

        /// <summary>
        /// Gets the CSS color 'lawngreen' (RGB 124,252,0).
        /// </summary>
        public static Color Lawngreen { get; } = new Color(124, 252, 0);

        /// <summary>
        /// Gets the CSS color 'lemonchiffon' (RGB 255,250,205).
        /// </summary>
        public static Color Lemonchiffon { get; } = new Color(255, 250, 205);

        /// <summary>
        /// Gets the CSS color 'lightblue' (RGB 173,216,230).
        /// </summary>
        public static Color Lightblue { get; } = new Color(173, 216, 230);

        /// <summary>
        /// Gets the CSS color 'lightcoral' (RGB 240,128,128).
        /// </summary>
        public static Color Lightcoral { get; } = new Color(240, 128, 128);

        /// <summary>
        /// Gets the CSS color 'lightcyan' (RGB 224,255,255).
        /// </summary>
        public static Color Lightcyan { get; } = new Color(224, 255, 255);

        /// <summary>
        /// Gets the CSS color 'lightgoldenrodyellow' (RGB 250,250,210).
        /// </summary>
        public static Color Lightgoldenrodyellow { get; } = new Color(250, 250, 210);

        /// <summary>
        /// Gets the CSS color 'lightgray' (RGB 211,211,211).
        /// </summary>
        public static Color Lightgray { get; } = new Color(211, 211, 211);

        /// <summary>
        /// Gets the CSS color 'lightgrey' (RGB 211,211,211).
        /// </summary>
        public static Color Lightgrey { get; } = new Color(211, 211, 211);

        /// <summary>
        /// Gets the CSS color 'lightgreen' (RGB 144,238,144).
        /// </summary>
        public static Color Lightgreen { get; } = new Color(144, 238, 144);

        /// <summary>
        /// Gets the CSS color 'lightpink' (RGB 255,182,193).
        /// </summary>
        public static Color Lightpink { get; } = new Color(255, 182, 193);

        /// <summary>
        /// Gets the CSS color 'lightsalmon' (RGB 255,160,122).
        /// </summary>
        public static Color Lightsalmon { get; } = new Color(255, 160, 122);

        /// <summary>
        /// Gets the CSS color 'lightseagreen' (RGB 32,178,170).
        /// </summary>
        public static Color Lightseagreen { get; } = new Color(32, 178, 170);

        /// <summary>
        /// Gets the CSS color 'lightskyblue' (RGB 135,206,250).
        /// </summary>
        public static Color Lightskyblue { get; } = new Color(135, 206, 250);

        /// <summary>
        /// Gets the CSS color 'lightslategray' (RGB 119,136,153).
        /// </summary>
        public static Color Lightslategray { get; } = new Color(119, 136, 153);

        /// <summary>
        /// Gets the CSS color 'lightslategrey' (RGB 119,136,153).
        /// </summary>
        public static Color Lightslategrey { get; } = new Color(119, 136, 153);

        /// <summary>
        /// Gets the CSS color 'lightsteelblue' (RGB 176,196,222).
        /// </summary>
        public static Color Lightsteelblue { get; } = new Color(176, 196, 222);

        /// <summary>
        /// Gets the CSS color 'lightyellow' (RGB 255,255,224).
        /// </summary>
        public static Color Lightyellow { get; } = new Color(255, 255, 224);

        /// <summary>
        /// Gets the CSS color 'lime' (RGB 0,255,0).
        /// </summary>
        public static Color Lime { get; } = new Color(0, 255, 0);

        /// <summary>
        /// Gets the CSS color 'limegreen' (RGB 50,205,50).
        /// </summary>
        public static Color Limegreen { get; } = new Color(50, 205, 50);

        /// <summary>
        /// Gets the CSS color 'linen' (RGB 250,240,230).
        /// </summary>
        public static Color Linen { get; } = new Color(250, 240, 230);

        /// <summary>
        /// Gets the CSS color 'magenta' (RGB 255,0,255).
        /// </summary>
        public static Color Magenta { get; } = new Color(255, 0, 255);

        /// <summary>
        /// Gets the CSS color 'maroon' (RGB 128,0,0).
        /// </summary>
        public static Color Maroon { get; } = new Color(128, 0, 0);

        /// <summary>
        /// Gets the CSS color 'mediumaquamarine' (RGB 102,205,170).
        /// </summary>
        public static Color Mediumaquamarine { get; } = new Color(102, 205, 170);

        /// <summary>
        /// Gets the CSS color 'mediumblue' (RGB 0,0,205).
        /// </summary>
        public static Color Mediumblue { get; } = new Color(0, 0, 205);

        /// <summary>
        /// Gets the CSS color 'mediumorchid' (RGB 186,85,211).
        /// </summary>
        public static Color Mediumorchid { get; } = new Color(186, 85, 211);

        /// <summary>
        /// Gets the CSS color 'mediumpurple' (RGB 147,112,219).
        /// </summary>
        public static Color Mediumpurple { get; } = new Color(147, 112, 219);

        /// <summary>
        /// Gets the CSS color 'mediumseagreen' (RGB 60,179,113).
        /// </summary>
        public static Color Mediumseagreen { get; } = new Color(60, 179, 113);

        /// <summary>
        /// Gets the CSS color 'mediumslateblue' (RGB 123,104,238).
        /// </summary>
        public static Color Mediumslateblue { get; } = new Color(123, 104, 238);

        /// <summary>
        /// Gets the CSS color 'mediumspringgreen' (RGB 0,250,154).
        /// </summary>
        public static Color Mediumspringgreen { get; } = new Color(0, 250, 154);

        /// <summary>
        /// Gets the CSS color 'mediumturquoise' (RGB 72,209,204).
        /// </summary>
        public static Color Mediumturquoise { get; } = new Color(72, 209, 204);

        /// <summary>
        /// Gets the CSS color 'mediumvioletred' (RGB 199,21,133).
        /// </summary>
        public static Color Mediumvioletred { get; } = new Color(199, 21, 133);

        /// <summary>
        /// Gets the CSS color 'midnightblue' (RGB 25,25,112).
        /// </summary>
        public static Color Midnightblue { get; } = new Color(25, 25, 112);

        /// <summary>
        /// Gets the CSS color 'mintcream' (RGB 245,255,250).
        /// </summary>
        public static Color Mintcream { get; } = new Color(245, 255, 250);

        /// <summary>
        /// Gets the CSS color 'mistyrose' (RGB 255,228,225).
        /// </summary>
        public static Color Mistyrose { get; } = new Color(255, 228, 225);

        /// <summary>
        /// Gets the CSS color 'moccasin' (RGB 255,228,181).
        /// </summary>
        public static Color Moccasin { get; } = new Color(255, 228, 181);

        /// <summary>
        /// Gets the CSS color 'navajowhite' (RGB 255,222,173).
        /// </summary>
        public static Color Navajowhite { get; } = new Color(255, 222, 173);

        /// <summary>
        /// Gets the CSS color 'navy' (RGB 0,0,128).
        /// </summary>
        public static Color Navy { get; } = new Color(0, 0, 128);

        /// <summary>
        /// Gets the CSS color 'oldlace' (RGB 253,245,230).
        /// </summary>
        public static Color Oldlace { get; } = new Color(253, 245, 230);

        /// <summary>
        /// Gets the CSS color 'olive' (RGB 128,128,0).
        /// </summary>
        public static Color Olive { get; } = new Color(128, 128, 0);

        /// <summary>
        /// Gets the CSS color 'olivedrab' (RGB 107,142,35).
        /// </summary>
        public static Color Olivedrab { get; } = new Color(107, 142, 35);

        /// <summary>
        /// Gets the CSS color 'orange' (RGB 255,165,0).
        /// </summary>
        public static Color Orange { get; } = new Color(255, 165, 0);

        /// <summary>
        /// Gets the CSS color 'orangered' (RGB 255,69,0).
        /// </summary>
        public static Color Orangered { get; } = new Color(255, 69, 0);

        /// <summary>
        /// Gets the CSS color 'orchid' (RGB 218,112,214).
        /// </summary>
        public static Color Orchid { get; } = new Color(218, 112, 214);

        /// <summary>
        /// Gets the CSS color 'palegoldenrod' (RGB 238,232,170).
        /// </summary>
        public static Color Palegoldenrod { get; } = new Color(238, 232, 170);

        /// <summary>
        /// Gets the CSS color 'palegreen' (RGB 152,251,152).
        /// </summary>
        public static Color Palegreen { get; } = new Color(152, 251, 152);

        /// <summary>
        /// Gets the CSS color 'paleturquoise' (RGB 175,238,238).
        /// </summary>
        public static Color Paleturquoise { get; } = new Color(175, 238, 238);

        /// <summary>
        /// Gets the CSS color 'palevioletred' (RGB 219,112,147).
        /// </summary>
        public static Color Palevioletred { get; } = new Color(219, 112, 147);

        /// <summary>
        /// Gets the CSS color 'papayawhip' (RGB 255,239,213).
        /// </summary>
        public static Color Papayawhip { get; } = new Color(255, 239, 213);

        /// <summary>
        /// Gets the CSS color 'peachpuff' (RGB 255,218,185).
        /// </summary>
        public static Color Peachpuff { get; } = new Color(255, 218, 185);

        /// <summary>
        /// Gets the CSS color 'peru' (RGB 205,133,63).
        /// </summary>
        public static Color Peru { get; } = new Color(205, 133, 63);

        /// <summary>
        /// Gets the CSS color 'pink' (RGB 255,192,203).
        /// </summary>
        public static Color Pink { get; } = new Color(255, 192, 203);

        /// <summary>
        /// Gets the CSS color 'plum' (RGB 221,160,221).
        /// </summary>
        public static Color Plum { get; } = new Color(221, 160, 221);

        /// <summary>
        /// Gets the CSS color 'powderblue' (RGB 176,224,230).
        /// </summary>
        public static Color Powderblue { get; } = new Color(176, 224, 230);

        /// <summary>
        /// Gets the CSS color 'purple' (RGB 128,0,128).
        /// </summary>
        public static Color Purple { get; } = new Color(128, 0, 128);

        /// <summary>
        /// Gets the CSS color 'rebeccapurple' (RGB 102,51,153).
        /// </summary>
        public static Color Rebeccapurple { get; } = new Color(102, 51, 153);

        /// <summary>
        /// Gets the CSS color 'red' (RGB 255,0,0).
        /// </summary>
        public static Color Red { get; } = new Color(255, 0, 0);

        /// <summary>
        /// Gets the CSS color 'rosybrown' (RGB 188,143,143).
        /// </summary>
        public static Color Rosybrown { get; } = new Color(188, 143, 143);

        /// <summary>
        /// Gets the CSS color 'royalblue' (RGB 65,105,225).
        /// </summary>
        public static Color Royalblue { get; } = new Color(65, 105, 225);

        /// <summary>
        /// Gets the CSS color 'saddlebrown' (RGB 139,69,19).
        /// </summary>
        public static Color Saddlebrown { get; } = new Color(139, 69, 19);

        /// <summary>
        /// Gets the CSS color 'salmon' (RGB 250,128,114).
        /// </summary>
        public static Color Salmon { get; } = new Color(250, 128, 114);

        /// <summary>
        /// Gets the CSS color 'sandybrown' (RGB 244,164,96).
        /// </summary>
        public static Color Sandybrown { get; } = new Color(244, 164, 96);

        /// <summary>
        /// Gets the CSS color 'seagreen' (RGB 46,139,87).
        /// </summary>
        public static Color Seagreen { get; } = new Color(46, 139, 87);

        /// <summary>
        /// Gets the CSS color 'seashell' (RGB 255,245,238).
        /// </summary>
        public static Color Seashell { get; } = new Color(255, 245, 238);

        /// <summary>
        /// Gets the CSS color 'sienna' (RGB 160,82,45).
        /// </summary>
        public static Color Sienna { get; } = new Color(160, 82, 45);

        /// <summary>
        /// Gets the CSS color 'silver' (RGB 192,192,192).
        /// </summary>
        public static Color Silver { get; } = new Color(192, 192, 192);

        /// <summary>
        /// Gets the CSS color 'skyblue' (RGB 135,206,235).
        /// </summary>
        public static Color Skyblue { get; } = new Color(135, 206, 235);

        /// <summary>
        /// Gets the CSS color 'slateblue' (RGB 106,90,205).
        /// </summary>
        public static Color Slateblue { get; } = new Color(106, 90, 205);

        /// <summary>
        /// Gets the CSS color 'slategray' (RGB 112,128,144).
        /// </summary>
        public static Color Slategray { get; } = new Color(112, 128, 144);

        /// <summary>
        /// Gets the CSS color 'slategrey' (RGB 112,128,144).
        /// </summary>
        public static Color Slategrey { get; } = new Color(112, 128, 144);

        /// <summary>
        /// Gets the CSS color 'snow' (RGB 255,250,250).
        /// </summary>
        public static Color Snow { get; } = new Color(255, 250, 250);

        /// <summary>
        /// Gets the CSS color 'springgreen' (RGB 0,255,127).
        /// </summary>
        public static Color Springgreen { get; } = new Color(0, 255, 127);

        /// <summary>
        /// Gets the CSS color 'steelblue' (RGB 70,130,180).
        /// </summary>
        public static Color Steelblue { get; } = new Color(70, 130, 180);

        /// <summary>
        /// Gets the CSS color 'tan' (RGB 210,180,140).
        /// </summary>
        public static Color Tan { get; } = new Color(210, 180, 140);

        /// <summary>
        /// Gets the CSS color 'teal' (RGB 0,128,128).
        /// </summary>
        public static Color Teal { get; } = new Color(0, 128, 128);

        /// <summary>
        /// Gets the CSS color 'thistle' (RGB 216,191,216).
        /// </summary>
        public static Color Thistle { get; } = new Color(216, 191, 216);

        /// <summary>
        /// Gets the CSS color 'tomato' (RGB 255,99,71).
        /// </summary>
        public static Color Tomato { get; } = new Color(255, 99, 71);

        /// <summary>
        /// Gets the CSS color 'turquoise' (RGB 64,224,208).
        /// </summary>
        public static Color Turquoise { get; } = new Color(64, 224, 208);

        /// <summary>
        /// Gets the CSS color 'violet' (RGB 238,130,238).
        /// </summary>
        public static Color Violet { get; } = new Color(238, 130, 238);

        /// <summary>
        /// Gets the CSS color 'wheat' (RGB 245,222,179).
        /// </summary>
        public static Color Wheat { get; } = new Color(245, 222, 179);

        /// <summary>
        /// Gets the CSS color 'white' (RGB 255,255,255).
        /// </summary>
        public static Color White { get; } = new Color(255, 255, 255);

        /// <summary>
        /// Gets the CSS color 'whitesmoke' (RGB 245,245,245).
        /// </summary>
        public static Color Whitesmoke { get; } = new Color(245, 245, 245);

        /// <summary>
        /// Gets the CSS color 'yellow' (RGB 255,255,0).
        /// </summary>
        public static Color Yellow { get; } = new Color(255, 255, 0);

        /// <summary>
        /// Gets the CSS color 'yellowgreen' (RGB 154,205,50).
        /// </summary>
        public static Color Yellowgreen { get; } = new Color(154, 205, 50);

        #endregion
    }
}
