﻿using System.Threading.Tasks;
using Discord.Commands;

namespace SteamDiscordBot.Commands
{
    public class VersionCommand : ModuleBase
    {
        [Command("version"), Summary("Get the current bot version.")]
        public async Task Say()
        {
            var client = Program.Instance.ghClient;
            var releases = await client.Repository.Release.GetAll(Program.config.GitHubUpdateUsername, Program.config.GitHubUpdateRepository);

            await Context.Channel.SendMessageAsync("Current version: " + Program.VERSION + " (latest is " + Helpers.GetLatestVersion(releases) + ")");
        }
    }
}