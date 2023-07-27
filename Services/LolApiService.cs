using DadBot.Models.LOLApiModels;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DadBot.Services
{
    public static class LolApiService
    {
        private static readonly ServiceProvider serviceProvider = new ServiceCollection().AddHttpClient().BuildServiceProvider();
        private static readonly IHttpClientFactory httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();
        private static readonly string riotApiKey = Environment.GetEnvironmentVariable("RiotApiKey", EnvironmentVariableTarget.Machine);
        
        public static async Task<string> GetSummonnerPUUID(string summonerName)
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://eun1.api.riotgames.com/lol/summoner/v4/summoners/by-name/{summonerName}?api_key={riotApiKey}");
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<SummonerApiInfo>(result).Puuid;
        }
    }
}

