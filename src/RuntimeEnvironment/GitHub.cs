// ***************************************************************************************
// MIT LICENCE
// Copyright 2020 Patrik Svensson, Phil Scott, Nils Andresen.
// https://spectreconsole.net
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using ConsolePlusLibrary.Core;

namespace ConsolePlusLibrary.RuntimeEnvironment
{
    internal sealed class GitHub : BaseClassCI, IProfileEnrich
    {
        public bool TryEnrich(ProfileConsole profile)
        {
            if (Found((value) => !string.IsNullOrWhiteSpace(value), "GITHUB_ACTIONS"))
            {
                profile.ChangedColorDepth = true;
                profile.ChangedSupportsAnsi = true;
                profile.ColorDepth = ColorSystem.FourBit;
                profile.SupportsAnsi = AutoDetect.Yes;
                profile.Interactive = false;
                return true;
            }
            return false;
        }
    }
}