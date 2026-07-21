// ***************************************************************************************
// MIT LICENCE
// Copyright 2020 Patrik Svensson, Phil Scott, Nils Andresen.
// https://spectreconsole.net
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using ConsolePlusLibrary.Core;
using System;

namespace ConsolePlusLibrary.RuntimeEnvironment
{ 
    internal sealed class GitLab : BaseClassCI, IProfileEnrich
    {
        public bool TryEnrich(ProfileConsole profile)
        {
            if (Found((value) => value?.Equals("yes", StringComparison.OrdinalIgnoreCase) ?? false, "CI_SERVER"))
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