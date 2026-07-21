// ***************************************************************************************
// MIT LICENCE
// Copyright (c) 2014 Philippe AURIOU
// https://github.com/auriou/FIGlet
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace ConsolePlusLibrary.Figlet
{
    internal sealed class FigletFont
    {
        public string Signature { get; private set; } = string.Empty;
        public string HardBlank { get; private set; } = string.Empty;
        public int Height { get; private set; }
        public int BaseLine { get; private set; }
        public int MaxLenght { get; private set; }
        public int OldLayout { get; private set; }
        public int CommentLines { get; private set; }
        public int PrintDirection { get; private set; }
        public int FullLayout { get; private set; }
        public int CodeTagCount { get; private set; }
        public List<string> Lines { get; private set; } = [];
        private char _hardBlankChar;  // cached for allocation-free Replace in GetCharacter

        public FigletFont(string flfFontFile)
        {
            if (string.IsNullOrEmpty(flfFontFile))
            {
                throw new ArgumentNullException(nameof(flfFontFile), "FIGletFont file name is null or empty");
            }
            LoadFont(flfFontFile);
        }

        public FigletFont(Stream flfFontstream)
        {
            LoadFont(flfFontstream);
        }

        public FigletFont  ()
        {
            using Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ConsolePlusLibrary.Figlet.Fonts.Standard.flf")!;
            LoadLines(ReadStreamFont(stream));
        }


        public Fragment[] ToAsciiArtMarkup(string strText, Style style)
        {
            // Use the array directly — no intermediate List<Segment>
            Fragment[] textsegments = Fragment.FromText(strText, style, false);
            var result = new List<Fragment>(Height * (textsegments.Length + 1));
            // Hoist StringBuilder outside both loops: 1 allocation per call instead of Height
            StringBuilder resline = new();
            for (int i = 1; i <= Height; i++)
            {
                foreach (var item in textsegments)
                {
                    foreach (char car in item.Text)
                    {
                        resline.Append(GetCharacter(car, i));
                    }
                    result.Add(new Fragment(resline.ToString(), item.Style, FragmentKind.ContentText));
                    resline.Clear();
                }
                result.Add(new Fragment("", null, FragmentKind.LineBreak));
            }
            return [.. result];
        }


        public string[] ToAsciiArt(string strText)
        {
            // Pre-sized array: Height is fixed at load time — no List + spread needed
            string[] res = new string[Height];
            // Hoist StringBuilder: 1 allocation per call instead of Height
            StringBuilder resline = new();
            for (int i = 1; i <= Height; i++)
            {
                foreach (char car in strText)
                {
                    resline.Append(GetCharacter(car, i));
                }
                res[i - 1] = resline.ToString();
                resline.Clear();
            }
            return res;
        }

        private string GetCharacter(char car, int line)
        {
            int start = CommentLines + ((int)car - 32) * Height;
            string temp = Lines[start + line];
            char lineending = temp[^1];
            temp = temp.TrimEnd(lineending);
            return temp.Replace(_hardBlankChar, ' ');
        }

        private void LoadLines(List<string> fontLines)
        {
            Lines = fontLines;
            string configString = Lines[0];
            string[] configArray = configString.Split(' ');
            Signature = configArray[0][..^1];
            if (Signature != "flf2a")
            {
                throw new ArgumentException("FIGletFont missing signature");
            }
            _hardBlankChar = configArray[0][^1];
            HardBlank = _hardBlankChar.ToString();
            Height = GetIntValue(configArray, 1);
            BaseLine = GetIntValue(configArray, 2);
            MaxLenght = GetIntValue(configArray, 3);
            OldLayout = GetIntValue(configArray, 4);
            CommentLines = GetIntValue(configArray, 5);
            PrintDirection = GetIntValue(configArray, 6);
            FullLayout = GetIntValue(configArray, 7);
            CodeTagCount = GetIntValue(configArray, 8);
        }

        private void LoadFont(string flfFontFile)
        {
            try
            {
                using FileStream fso = File.Open(flfFontFile, FileMode.Open);
                LoadLines(ReadStreamFont(fso));
            }
            catch (Exception ex)
            {
                throw new FileNotFoundException($"FIGletFont Error load {flfFontFile}", ex);
            }
        }

        private void LoadFont(Stream fontStream)
        {
            try
            {
                LoadLines(ReadStreamFont(fontStream));
            }
            catch (Exception ex)
            {
                throw new InvalidDataException($"FIGletFont Error load from stream", ex);
            }
        }

        private static int GetIntValue(string[] arrayStrings, int posi)
        {
            return arrayStrings.Length <= posi ? 0 : int.TryParse(arrayStrings[posi], out int val) ? val : 0;
        }

        private static List<string> ReadStreamFont(Stream fontStream)
        {
            List<string> fontData = [];
            using (StreamReader reader = new(fontStream))
            {
                while (!reader.EndOfStream)
                {
                    fontData.Add(reader.ReadLine()!);
                }
            }
            return fontData;
        }
    }
}