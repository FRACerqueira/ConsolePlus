// ***************************************************************************************
// MIT LICENCE
// Copyright 2020 Patrik Svensson, Phil Scott, Nils Andresen.
// https://spectreconsole.net
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using ConsolePlusLibrary.Core;

namespace ConsolePlusLibrary.RuntimeEnvironment
{
    internal sealed class AppVeyor : BaseClassCI, IProfileEnrich
    {
        public bool TryEnrich(ProfileConsole profile)
        {
            if (Found(null,"APPVEYOR"))
            {
                profile.ChangedSupportsAnsi = true;
                profile.ChangedColorDepth = true;
                profile.ColorDepth = ColorSystem.FourBit;
                profile.SupportsAnsi = AutoDetect.No;
                profile.Interactive = false;
                return true;
            }
            return false;
        }
    }
}
