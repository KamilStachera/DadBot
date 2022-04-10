using DadBot.Services;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DadBot.Ulityties
{
    public class MessageConstructor
    {
        /// <summary>
        /// Method creates message with evenly distributed users across two teams, every team has number of users times 3 champions to choose from 
        /// </summary>
        /// <param name="users">List of users to split into two teams</param>
        /// <returns>Message to send as response in discord</returns>
        public static string CreateMessageForAram(List<DiscordMember> users)
        {
            var msg = "";

            (var firstGroup, var secondGroup) = Converts.SplitIntoTwoRandomArrays(users);

            var champsFirst = DbService.GetInstance().GetChampions(firstGroup.Count * 3);
            var champsSecond = DbService.GetInstance().GetChampions(secondGroup.Count * 3);

            msg += AddGroupToMessage(firstGroup, champsFirst);
            msg += AddGroupToMessage(secondGroup, champsSecond);

            return msg;
        }
        private static string AddGroupToMessage(List<DiscordMember> group, List<string> champs)
        {
            var msg = "";

            foreach (var user in group)
            {
                msg += user.DisplayName + "\n";
            }

            msg += "\nAvailable champs: \n--------------------------------------------------------------------------------------\n";

            foreach (var champ in champs)
            {
                msg += champ + " | ";
            }
            msg += "\n--------------------------------------------------------------------------------------\n\n";

            return msg;
        }
    }
}
