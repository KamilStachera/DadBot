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

namespace DadBot.Commands
{
    class LOLCommands : BaseCommandModule
    {
        [Command("addSummoner")]
        public async Task AddUserCommand(CommandContext ctx, DiscordMember user, string summonerName)
        {
            await ctx.RespondAsync($"IGN: {summonerName} \n DiscordID: {user} \n added to ARAM database");
        }

        [Description("This command creates aram on given discord channel")]
        [Command("Aram")]
        public async Task AramCommand(CommandContext ctx, [Description("Channel to generate aram on")] DiscordChannel channel)
        {
            var users = channel.Users.ToList();

            if (users.Count() == 0)
            {
                await ctx.RespondAsync("No users on given channel silly");
                return;
            }
            if (users.Count() % 2 != 0)
            {
                await ctx.RespondAsync("Channel should contain even number of users");
                return;
            } 

            await ctx.RespondAsync($"{MessageConstructor.CreateMessageForAram(users)}");
        }

        [Description("This command creates aram on callers discord channel")]
        [Command("Aram")]
        public async Task AramCommand(CommandContext ctx)
        {
            var channel = ctx.Member.VoiceState?.Channel;

            if (channel == null)
            {
                await ctx.RespondAsync("You should be connected to any channel to use this commad");
                return;
            }

            var users = channel.Users.ToList();

            if (users.Count() % 2 != 0)
            {
                await ctx.RespondAsync("Channel should contain even number of users");
                return;
            }

            await ctx.RespondAsync($"{MessageConstructor.CreateMessageForAram(users)}");
        }
    }
}
