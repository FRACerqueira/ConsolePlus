// ***************************************************************************************
// MIT LICENCE
// Copyright 2020 Patrik Svensson, Phil Scott, Nils Andresen.
// https://spectreconsole.net
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using ConsolePlusLibrary.Core;
using ConsolePlusLibrary.RuntimeEnvironment;

namespace ConsolePlusLibrary.ConsoleAbstractions
{
    internal static class ProfileExtensions
    {
        public static void EnrichersCI(this ProfileConsole profile)
        {
            IProfileEnrich[] defaultEnrichers =
            [
                new AppVeyor(),
                new AzurePipelines(),
                new Bamboo(),
                new Bitbucket(),
                new Bitrise(),
                new Continua(),
                new GitHub(),
                new GitLab(),
                new GoCD(),
                new Jenkins(),
                new MyGet(),
                new TeamCity(),
                new Tfs(),
                new Travis()
            ];
            //overwrite profile properties (Interactive and SupportsAnsi) based on known CI environments, the first that matches will enrich the profile and break the loop
            foreach (var itemCI in defaultEnrichers)
            {
                if (itemCI.TryEnrich(profile))
                {
                    break;
                }
            }
        }
    }
}
