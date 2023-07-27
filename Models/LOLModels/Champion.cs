using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DadBot.Models.LOLModels
{
    public class Champion
    {
        [Key]
        public int ChampionID { get; set; }
        public string ChampionName { get; set; }
    }
}
