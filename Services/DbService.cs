using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DadBot.Services
{
    public class DbService
    {
        private static DbService _instance;
        public static DbService GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DbService();
            }

            return _instance;
        }

        public DbService()
        {

        }

        public List<string> GetChampions()
        {
            var champs = new List<string>();

            using (var db = new DadBotDbContext())
            {
                foreach (var champ in db.Champions)
                {
                    champs.Add(champ.ChampionName);
                }
            }

            return champs;
        }

        public List<string> GetChampions(int number)
        {
            var champs = GetChampions();
            var random = new Random();
            return champs.OrderBy(x => random.Next()).Take(number).ToList();
        }
    }
}
