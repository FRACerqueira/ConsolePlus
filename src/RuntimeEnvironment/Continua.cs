// ***************************************************************************************
// MIT LICENCE
// Copyright 2020 Patrik Svensson, Phil Scott, Nils Andresen.
// https://spectreconsole.net
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using ConsolePlusLibrary.Core;

namespace ConsolePlusLibrary.RuntimeEnvironment
{
    internal sealed class Continua : BaseClassCI, IProfileEnrich
    {
        public bool TryEnrich(ProfileConsole profile)
        {
            if (Found(null, "ContinuaCI.Version"))
            {
                profile.ColorDepth = ColorSystem.FourBit;
                profile.Interactive = false;
                return true;
            }
            return false;
        }
    }
}