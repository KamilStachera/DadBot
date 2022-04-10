using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace DadBot.Ulityties
{
    public class Converts
    {
        /// <summary>
        /// Method reads list of champions from input file (in convention-> championId: championName, exaple list of all champion -> https://darkintaqt.com/blog/league-champ-id-list/)
        /// and then outputs sqlserver-insert-friendly format to outputFile path 
        /// </summary>
        /// <param name="inputFile">Path to input file</param>
        /// <param name="outputFile">Path to output File</param>
        public static void Convert(string inputFile, string outputFile)
        {
            var input = File.ReadAllLines(inputFile);
            File.Create(outputFile).Dispose();

            var champsSql = new List<string>();

            foreach (var champs in input)
            {
                var champSplitted = champs.Split(':');
                champsSql.Add($"({champSplitted[0]}, '{champSplitted[1].Trim().Replace("'", "''") }'),");
            }
            champsSql.ForEach(x => File.AppendAllText("ChampsSql.txt", $"{x}\n"));
        }

        /// <summary>
        /// Method takes one array and splits it's content into two arrays randomly
        /// </summary>
        /// <typeparam name="T">Any orderable type</typeparam>
        /// <param name="entryList">List to split</param>
        /// <returns>Tuple of two lists with randomly selected elements from initial list</returns>
        public static (List<T>, List<T>) SplitIntoTwoRandomArrays<T>(List<T> entryList)
        {
            var r = new Random();
            var shuffled = entryList.OrderBy(x => r.Next()).ToArray();

            var all = entryList.Count();
            var take = all / 2;
            var skip = all - take;

            return (shuffled.Take(take).ToList(), shuffled.Skip(skip).Take(take).ToList());
        }

    }
}
