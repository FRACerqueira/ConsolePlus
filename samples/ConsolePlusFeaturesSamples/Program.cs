// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using ConsolePlusLibrary;

namespace ConsolePlusFeaturesSamples
{
    internal class Program
    {
        static void Main()
        {
            ConsolePlus.EnabledEmacs = true;

            static void Pause(string message = "[Yellow]Press any key to continue[/]")
            {
                ConsolePlus.WriteLine("");
                ConsolePlus.WriteLine(message);
                ConsolePlus.ReadKey();
                ConsolePlus.WriteLine();
            }

            ConsolePlus.ResetColor();
            ConsolePlus.Clear();

            ConsolePlus.Banner("ConsolePlus", Color.Bisque, DashOptions.SingleBorder);

            ConsolePlus.Dash("01 - Basic Markup (foreground/background)", Color.Yellow, DashOptions.DoubleBorderUpDown, 1);
            ConsolePlus.WriteLine("[RGB(255,0,0) ON WHITE]Test[GREEN] COLOR[/] BACK COLOR [/] other text");
            ConsolePlus.WriteLine("[RGB(255,0,0):WHITE]Test[GREEN] COLOR[/] BACK COLOR [/] other text");
            ConsolePlus.WriteLine("[RED:WHITE]Test[bLUE] COLOR[/] BACK COLOR[/] other text");
            ConsolePlus.WriteLine("[TEAL]Named CSS color[/] and [#FF8C00]HEX color[/]");
            ConsolePlus.WriteLine("[Darkseagreen810]Named CSS color Darkseagreen with weight 810[/]");

            Pause();

            ConsolePlus.WriteLines(2);

            ConsolePlus.Dash("02 - Common Cases and Markup Escape", Color.Yellow, DashOptions.DoubleBorderUpDown, 1);
            ConsolePlus.WriteLine("[RED]ERROR:[/] Wrong format! (/x/g/[My Folder Name Has Brackets]/[[BracketFile]].xml)");
            ConsolePlus.WriteLine("[RED]ERROR:[/] Wrong format! (/x/g/[My Folder Name Has Brackets]/[BracketFile].xml)");
            ConsolePlus.WriteLine("[RED].xml");
            ConsolePlus.WriteLine("[RED].xml".EscapeMarkup());
            ConsolePlus.WriteLine("[RED:WHITE]Test[/][bLUE] missing token but ok!");
            ConsolePlus.WriteLine("Test[/] missing token but ok!");
            ConsolePlus.WriteLine("[[RED]]Test escape token", ConsolePlus.CurrentStyle.ForeGround(Color.Aqua));
            ConsolePlus.WriteLine("[RED]Test escape token".EscapeMarkup(), ConsolePlus.CurrentStyle.ForeGround(Color.Aqua));
            ConsolePlus.WriteLine("[RED]Test[/] with Style", ConsolePlus.CurrentStyle.ForeGround(Color.Yellow));
            ConsolePlus.WriteLine("[RED]Test.xml {1}", ConsolePlus.CurrentStyle.Background(Color.White));
            ConsolePlus.WriteLine("Array[1][2]", ConsolePlus.CurrentStyle.Background(Color.White));
            ConsolePlus.WriteLine("Array[[RED]1][[BLUE]2]");
            Pause();

            ConsolePlus.WriteLine("Emoji Icons - 2 equivalent approaches:");
            ConsolePlus.WriteLine();
            ConsolePlus.WriteLine(":red_heart:  Red Heart");
            ConsolePlus.WriteLine($"{(EmojiValue)EmojiName.RedHeart}  Red Heart");

            ConsolePlus.WriteLine();
            ConsolePlus.WriteLine(":thumbs_up: Thumbs Up");
            ConsolePlus.WriteLine($"{(EmojiValue)EmojiName.ThumbsUp} Thumbs Up");

            ConsolePlus.WriteLine();
            ConsolePlus.WriteLine(":fire: Fire");
            ConsolePlus.WriteLine($"{(EmojiValue)EmojiName.Fire} Fire");

            ConsolePlus.WriteLine();
            ConsolePlus.WriteLine($"Emoji Icons with markup:");
            ConsolePlus.WriteLine();
            ConsolePlus.WriteLine($"[BLUE]:RabbitFace: Rabbit");
            ConsolePlus.WriteLine($"[BLUE]:Tangerine: Tangerine");
            ConsolePlus.WriteLine($"[BLUE]:FaxMachine: Fax Machine");
            ConsolePlus.WriteLine($"[RED]:xxxx: Invalid Emoji");

            ConsolePlus.WriteLine();
            ConsolePlus.WriteLine($"Emoji Icons by group (EmojiGroup.Name):");
            ConsolePlus.WriteLine();
            ConsolePlus.WriteLine($"{EmojiActivities.Balloon} Balloon (Activities)");
            ConsolePlus.WriteLine($"{EmojiSymbols.CheckMarkButton} Check Mark (Symbols)");
            ConsolePlus.WriteLine($"{EmojiTravelAndPlaces.Rocket} Rocket (Travel & Places)");

            ConsolePlus.WriteLine();
            ConsolePlus.WriteLine("Emoji Icons by typed name (EmojiName + EmojiValue):");
            ConsolePlus.WriteLine();
            ConsolePlus.WriteLine($"{(EmojiValue)EmojiName.Balloon} Balloon (Activities)");
            ConsolePlus.WriteLine($"{(EmojiValue)EmojiName.CheckMarkButton} Check Mark (Symbols)");
            ConsolePlus.WriteLine($"{(EmojiValue)EmojiName.Rocket} Rocket (Travel & Places)");

            ConsolePlus.WriteLines(2);

            Pause();

            ConsolePlus.Dash("03 - Dash styles", Color.Yellow, DashOptions.DoubleBorderUpDown, 1);

            var aux = Enum.GetValues<DashOptions>();
            foreach (var item in aux)
            {
                ConsolePlus.Dash("Test Dash", Color.Yellow, item, 1);
                ConsolePlus.Dash("[RGB(255,0,0) ON WHITE]Test[GREEN] COLOR[/] BACK COLOR [/] other text", null, item, 1);
            }

            ConsolePlus.Dash("04 - Writing to standard error", Color.Yellow, DashOptions.DoubleBorderUpDown, 1);
            using (ConsolePlus.OutputError())
            {
                ConsolePlus.WriteLine("Test Output Error");
                ConsolePlus.WriteLine("[RED]Test Output Error[/]");
            }
            ConsolePlus.WriteLine("");

            ConsolePlus.WriteLine("");
            ConsolePlus.Dash($"05 - Overflow: Ellipsis", Color.Yellow, DashOptions.DoubleBorderUpDown, 1);
            ConsolePlus.WriteLine("asdajsdkldksdkasasdadasdadjashkjdahsdashdjkashdkashdkashdkashdakshdkashdkashdaskhdaskdhaskdhaskdhaskdhaskdhsakdhaskdhaskjdj", ConsolePlus.CurrentStyle.Overflow(Overflow.Ellipsis));
            ConsolePlus.WriteLine("[red]asda[/]jsdkldksdkasasdadasdadjashkjdahsdashdjkashdkashdkashdkashdakshdkashdkashdaskhdaskdhaskdhaskdhaskdhaskdhsakdhaskdhaskjdj", ConsolePlus.CurrentStyle.Overflow(Overflow.Ellipsis));

            ConsolePlus.WriteLine("");
            ConsolePlus.Dash($"06 - Overflow: Crop", Color.Yellow, DashOptions.DoubleBorderUpDown, 1);
            ConsolePlus.WriteLine("asdajsdkldksdkasasdadasdadjashkjdahsdashdjkashdkashdkashdkashdakshdkashdkashdaskhdaskdhaskdhaskdhaskdhaskdhsakdhaskdhaskjdj", ConsolePlus.CurrentStyle.Overflow(Overflow.Crop));
            ConsolePlus.WriteLine("[red]asda[/]jsdkldksdkasasdadasdadjashkjdahsdashdjkashdkashdkashdkashdakshdkashdkashdaskhdaskdhaskdhaskdhaskdhaskdhsakdhaskdhaskjdj", ConsolePlus.CurrentStyle.Overflow(Overflow.Crop));

            ConsolePlus.WriteLine("");
            ConsolePlus.Dash($"07 - Overflow: Default", Color.Yellow, DashOptions.DoubleBorderUpDown, 1);
            ConsolePlus.WriteLine("asdajsdkldksdkasasdadasdadjashkjdahsdashdjkashdkashdkashdkashdakshdkashdkashdaskhdaskdhaskdhaskdhaskdhaskdhsakdhaskdhaskjdj");
            ConsolePlus.WriteLine("[red]asda[/]jsdkldksdkasasdadasdadjashkjdahsdashdjkashdkashdkashdkashdakshdkashdkashdaskhdaskdhaskdhaskdhaskdhaskdhsakdhaskdhaskjdj");


            Pause();
            ConsolePlus.Clear(ConsoleColor.Blue);
            ConsolePlus.Dash($"08 - Console Information", Color.Yellow, DashOptions.SingleBorder, 1 /*extra lines*/);
            ConsolePlus.WriteLine($"Profile Name : {ConsolePlus.Profile.ProfileName}");
            ConsolePlus.WriteLine($"Current Buffer: {ConsolePlus.CurrentBuffer}");
            ConsolePlus.WriteLine($"IsTerminal: {ConsolePlus.Profile.IsTerminal}");
            ConsolePlus.WriteLine($"IsUnicodeSupported: {ConsolePlus.Profile.SupportUnicode}");
            ConsolePlus.WriteLine($"OutputEncoding: {ConsolePlus.OutputEncoding.EncodingName}");
            ConsolePlus.WriteLine($"ColorDepth: {ConsolePlus.Profile.ColorDepth}");
            ConsolePlus.WriteLine($"BackgroundColor: {ConsolePlus.BackgroundColor}");
            ConsolePlus.WriteLine($"ForegroundColor: {ConsolePlus.ForegroundColor}");
            ConsolePlus.WriteLine($"SupportsAnsi: {ConsolePlus.Profile.SupportsAnsi}");
            ConsolePlus.WriteLine($"Buffers(Width/Height): {ConsolePlus.Width}/{ConsolePlus.Height}");

            Pause();

            ConsolePlus.WriteLine("");
            ConsolePlus.Dash($"09 - Palette: Legacy (0..7)", Color.Yellow, DashOptions.DoubleBorderUpDown, 1);
            ConsolePlus.Write('|');
            for (var i = 0; i < 8; i++)
            {
                var backgroundColor = Color.FromInt32(i);
                var foregroundColor = backgroundColor.GetInvertedColor();
                ConsolePlus.Write(string.Format(" {0,-9}", i), new Style(foregroundColor, backgroundColor));
                if ((i + 1) % 8 == 0)
                {
                    ConsolePlus.WriteLine('|');
                }
            }

            if (ConsolePlus.ColorDepth >= ColorSystem.FourBit)
            {
                ConsolePlus.WriteLine("");
                ConsolePlus.Dash($"10 - Palette: Standard (0..15)", Color.Yellow, DashOptions.DoubleBorderUpDown, 1);
                ConsolePlus.Write("|");
                for (var i = 0; i < 16; i++)
                {
                    var backgroundColor = Color.FromInt32(i);
                    var foregroundColor = backgroundColor.GetInvertedColor();
                    ConsolePlus.Write(string.Format(" {0,-9}", i), new Style(foregroundColor, backgroundColor));
                    if ((i + 1) % 8 == 0)
                    {
                        ConsolePlus.WriteLine('|');
                        if ((i + 1) % 16 != 0)
                        {
                            ConsolePlus.Write('|');
                        }
                    }
                }
                Pause();
            }

            if (ConsolePlus.ColorDepth >= ColorSystem.FourBit)
            {
                ConsolePlus.WriteLine("");
                ConsolePlus.Dash($"11 - Weighted CSS Colors", Color.Yellow, DashOptions.DoubleBorderUpDown, 1);
                ConsolePlus.WriteLine("[silver]How to use:[/] [aqua]Color.Red.Weighted(500)[/]");
                ConsolePlus.WriteLine("");

                int[] sampleWeights = [100, 200, 300, 400, 500, 600, 700, 800, 900];
                Color[] baseColors = [Color.Red, Color.Green, Color.Blue, Color.Teal, Color.Purple, Color.Orange];

                foreach (Color baseColor in baseColors)
                {
                    ConsolePlus.Write("| ");
                    foreach (int weight in sampleWeights)
                    {
                        Color weighted = baseColor.Weighted(weight);
                        Color foreground = weighted.GetInvertedColor();
                        ConsolePlus.Write($" {weight,3} ", new Style(foreground, weighted));
                    }
                    ConsolePlus.WriteLine(" |");
                }

                ConsolePlus.WriteLine("");
                ConsolePlus.WriteLine($"Example Weighted(844) -> {Color.Blue.Weighted(844)}", new Style(Color.Blue.Weighted(844).GetInvertedColor(), Color.Blue.Weighted(844)));
                Pause();

            }

            ConsolePlus.WriteLine("");
            ConsolePlus.Dash($"11.1 - Color Utility Methods (extras)", Color.Yellow, DashOptions.DoubleBorderUpDown, 1);

            Color fromHex = Color.FromHex("#1E90FF");
            ConsolePlus.WriteLine($"FromHex('#1E90FF') -> {fromHex} / ToHex()={fromHex.ToHex()}");

            if (Color.TryFromHex("#FF69B4", out var hotPink))
            {
                ConsolePlus.WriteLine($"TryFromHex('#FF69B4') -> {hotPink}", new Style(hotPink.GetInvertedColor(), hotPink));
            }

            Color? fromName = Color.FromName("rebeccapurple");
            if (fromName != null)
            {
                ConsolePlus.WriteLine($"FromName('rebeccapurple') -> {fromName.Value} / ToMarkup()={fromName.Value.ToMarkup()}");
            }

            Color blended = Color.Red.Blend(Color.Blue, 0.5f);
            ConsolePlus.WriteLine($"Blend(Red, Blue, 0.5) -> {blended}", new Style(blended.GetInvertedColor(), blended));

            double contrast = Color.White.GetContrast(Color.Navy);
            ConsolePlus.WriteLine($"GetContrast(White, Navy) -> {contrast:F2}");

            Color fgByLuminance = Color.GetContrastForegroundColor(Color.Gold);
            ConsolePlus.WriteLine($"GetContrastForegroundColor(Gold) -> {fgByLuminance}");

            Color adjusted = Color.Yellow.AdjustForegroundColorForContrast(Color.White, 4.5);
            ConsolePlus.WriteLine($"AdjustForegroundColorForContrast(Yellow on White, 4.5) -> {adjusted}", new Style(adjusted, Color.White));

            Color closestStandard = fromHex.ExactOrClosest(ColorSystem.FourBit);
            ConsolePlus.WriteLine($"ExactOrClosest(Standard) for #1E90FF -> {closestStandard}", new Style(closestStandard.GetInvertedColor(), closestStandard));

            Pause();


            if (ConsolePlus.ColorDepth >= ColorSystem.TrueColor)
            {
                ConsolePlus.WriteLine("");
                ConsolePlus.Dash($"12 - TrueColor gradient", Color.Yellow, DashOptions.DoubleBorderUpDown, 1);
                for (var y = 0; y < 15; y++)
                {
                    ConsolePlus.Write('|');
                    for (var x = 0; x < 90; x++)
                    {
                        var l = 0.1f + ((y / (float)15) * 0.7f);
                        var h = x / (float)80;
                        var (r1, g1, b1) = ColorFromHSL(h, l, 1.0f);
                        var (r2, g2, b2) = ColorFromHSL(h, l + (0.7f / 10), 1.0f);
                        var background = new Color((byte)(r1 * 255), (byte)(g1 * 255), (byte)(b1 * 255));
                        var foreground = new Color((byte)(r2 * 255), (byte)(g2 * 255), (byte)(b2 * 255));
                        ConsolePlus.Write('▄', new Style(foreground, background));
                    }
                    ConsolePlus.WriteLine('|');
                }
            }

            Pause("[Yellow]Press any key to end[/]");

            ConsolePlus.ResetColor();
            ConsolePlus.Clear();
        }

        private static (float, float, float) ColorFromHSL(double h, double l, double s)
        {
            double r = 0, g = 0, b = 0;
            if (l != 0)
            {
                if (s == 0)
                {
                    r = g = b = l;
                }
                else
                {
                    double temp2;
                    if (l < 0.5)
                    {
                        temp2 = l * (1.0 + s);
                    }
                    else
                    {
                        temp2 = l + s - (l * s);
                    }

                    var temp1 = 2.0 * l - temp2;

                    r = GetColorComponent(temp1, temp2, h + 1.0 / 3.0);
                    g = GetColorComponent(temp1, temp2, h);
                    b = GetColorComponent(temp1, temp2, h - 1.0 / 3.0);
                }
            }

            return ((float)r, (float)g, (float)b);

        }

        private static double GetColorComponent(double temp1, double temp2, double temp3)
        {
            if (temp3 < 0.0)
            {
                temp3 += 1.0;
            }
            else if (temp3 > 1.0)
            {
                temp3 -= 1.0;
            }

            if (temp3 < 1.0 / 6.0)
            {
                return temp1 + (temp2 - temp1) * 6.0 * temp3;
            }
            else if (temp3 < 0.5)
            {
                return temp2;
            }
            else if (temp3 < 2.0 / 3.0)
            {
                return temp1 + ((temp2 - temp1) * ((2.0 / 3.0) - temp3) * 6.0);
            }
            else
            {
                return temp1;
            }
        }
    }
}
