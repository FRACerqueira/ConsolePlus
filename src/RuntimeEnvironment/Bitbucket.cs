// ************************************// ***************************************************************************************
// MIT LICENCE
// Copyright 2020 Patrik Svensson, Phil Scott, Nils Andresen.
// https://spectreconsole.net
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using ConsolePlusLibrary.Core;

namespace ConsolePlusLibrary.RuntimeEnvironment
{
    internal sealed class Bitbucket : BaseClassCI, IProfileEnrich
    {
        public bool TryEnrich(ProfileConsole profile)
        {
            if (Found(null, "BITBUCKET_REPO_OWNER", "BITBUCKET_REPO_SLUG", "BITBUCKET_COMMIT"))
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