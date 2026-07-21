// ***************************************************************************************
// MIT LICENCE
// Copyright 2020 Patrik Svensson, Phil Scott, Nils Andresen.
// https://spectreconsole.net
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using System;

namespace ConsolePlusLibrary.Core
{
    internal sealed class MarkupColor(MarkupColorKind kind, string value, int position)
    {
        public MarkupColorKind Kind { get; } = kind;
        public string Value { get; } = value ?? throw new ArgumentNullException(nameof(value), "Color MarkupToken with value null");
        public int Position { get; } = position;
    }
}
