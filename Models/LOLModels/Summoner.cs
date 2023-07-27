using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DadBot.Models.LOLModels
{
    public class Summoner
    {
        [Key]
        public string PUUID { get; set; }
        public long DiscordId { get; set; }
    }
}
