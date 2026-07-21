// ***************************************************************************************
// MIT LICENCE
// Copyright 2020 Patrik Svensson, Phil Scott, Nils Andresen.
// https://spectreconsole.net
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using ConsolePlusLibrary.Core;

namespace ConsolePlusLibrary.RuntimeEnvironment
{
    internal sealed class TeamCity : BaseClassCI, IProfileEnrich
    {
        public bool TryEnrich(ProfileConsole profile)
        {
            if (Found(null, "TEAMCITY_VERSION"))
            {
                profile.ChangedColorDepth = true;
                profile.ColorDepth = ColorSystem.FourBit;
                profile.Interactive = false;
                return true;
            }
            return false;
        }
    }
}