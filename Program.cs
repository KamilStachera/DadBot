using DSharpPlus;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using DSharpPlus.CommandsNext;
using DadBot.Commands;

namespace DadBot
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static string GetApiKey()
        {
            return Environment.GetEnvironmentVariable("DiscordKey", EnvironmentVariableTarget.Machine);
        }

        static async Task MainAsync()
        {

            var discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = GetApiKey(),
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.AllUnprivileged
            });

            var commands = discord.UseCommandsNext(new CommandsNextConfiguration()
            {
                StringPrefixes = new[] { "!s" },
            });

            commands.RegisterCommands<LOLCommands>();
          //  commands.RegisterCommands<GeneralCommands>();

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }

    }
}
//#region codinghorror.com
//class Program : Object
//{
//    static int _I = 1;
//    /// <summary>
//    /// The quick brown fox jumps over the lazy dog
//    /// THE QUICK BROWN FOX JUMPS OVER THE LAZY DOG
//    /// </summary>
//    static void Main(string[] args)
//    {
//        Uri Illegal1Uri = new Uri("http://packmyboxwith/jugs.html?q=five-dozen&t=liquor");
//        Regex OperatorRegex = new Regex(@"S#$", RegexOptions.IgnorePatternWhitespace);
//        for (int O = 0; O < 123456789; O++)
//        {
//            _I += (O % 3) * ((O / 1) ^ 2) - 5;
//            if (!OperatorRegex.IsMatch(Illegal1Uri.ToString()))
//            {
//                Console.WriteLine(Illegal1Uri);
//            }
//        }
//    }
//}
//#endregion