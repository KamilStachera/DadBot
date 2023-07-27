using DSharpPlus;
using System;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DadBot.Commands.LOL;
using DadBot.Commands;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

namespace DadBot
{
    class Program
    {
        static async Task Main(string[] args)
        {


            var discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = GetApiKey(),
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.AllUnprivileged | DiscordIntents.MessageContents
            });

            var commands = discord.UseCommandsNext(new CommandsNextConfiguration()
            {
                StringPrefixes = new[] { "!s" },
            });

            commands.RegisterCommands<LOLAramCustomsCommands>();
            commands.RegisterCommands<LOLAramStatsCommands>();
            //  commands.RegisterCommands<GeneralCommands>();

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }

        static string GetApiKey()
        {
            return Environment.GetEnvironmentVariable("DiscordKey", EnvironmentVariableTarget.Machine);
        }
    }
}