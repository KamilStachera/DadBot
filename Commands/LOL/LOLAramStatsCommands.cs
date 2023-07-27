using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using DadBot.Services;
using DadBot.Ulityties;

namespace DadBot.Commands.LOL
{
    internal class LOLAramStatsCommands : BaseCommandModule
    {
        [Command("addSummoner")]
        public async Task AddUserCommand(CommandContext ctx)
        {
            await ctx.RespondAsync($"Command use: !s addSummoner @Nickname LOLNickname");
        }

        [Command("addSummoner")]
        public async Task AddUserCommand(CommandContext ctx, DiscordMember user)
        {
            await ctx.RespondAsync($"Command use: !s addSummoner @Nickname LOLNickname");
        }

        [Command("addSummoner")]
        public async Task AddUserCommand(CommandContext ctx, DiscordMember user, string summonerName)
        {
            var puuid = await LolApiService.GetSummonnerPUUID(summonerName);
            await ctx.RespondAsync($"IGN: {summonerName} \n DiscordID: {user} \n PUUID: {puuid} \n added to ARAM database");
        }
    }
}
