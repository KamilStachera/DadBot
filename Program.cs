using DSharpPlus;
using System;
using System.Threading.Tasks;

namespace DadBot
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task<string> GetApiKey()
        {
            return Environment.GetEnvironmentVariable("DiscordKey", EnvironmentVariableTarget.Machine);
        }

        static async Task MainAsync()
        {
            var discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = await GetApiKey(),
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.AllUnprivileged
            });
        }
    }
}
