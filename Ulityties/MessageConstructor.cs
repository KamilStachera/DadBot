using DadBot.Services;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var msg2 = "";

            (var firstGroup, var secondGroup) = Converts.SplitIntoTwoRandomArrays(users);

            var champsFirst = DbService.GetInstance().GetChampions(firstGroup.Count * 8);
            var champsSecond = DbService.GetInstance().GetChampions(secondGroup.Count * 8, champsFirst);

            msg += AddGroupToMessage(firstGroup, champsFirst); ;
            msg2 += AddGroupToMessage(secondGroup, champsSecond);

            firstGroup.First().SendMessageAsync(msg);
            secondGroup.First().SendMessageAsync(msg2);

            var user1 = GetUsersFromGroup(firstGroup);
            var user2 = GetUsersFromGroup(secondGroup);

            return $"Champs sent to group leaders {firstGroup.First().DisplayName} ({user1}), {secondGroup.First().DisplayName} ({user2})";
        }

        private static string AddGroupToMessage(List<DiscordMember> group, List<string> champs)
        {
            var msg = "";

            msg += "\nAvailable champs: \n--------------------------------------------------------------------------------------\n";

            foreach (var champ in champs)
            {
                msg += champ + " | ";
            }
            msg += "\n--------------------------------------------------------------------------------------\n\n";

            return msg;
        }

        private static string GetUsersFromGroup(List<DiscordMember> group)
        {
            var usersMerged = "";

            foreach (var user in group)
            {
                usersMerged += $"{user.Username} ";
            }

            return usersMerged.Trim();
        }
    }
}
