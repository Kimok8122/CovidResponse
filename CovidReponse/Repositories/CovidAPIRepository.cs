using System;
using System.Collections.Generic;
using System.Net.Http;
using CovidReponse.Models;

namespace CovidReponse.Repositories
{
    public class CovidAPIRepository : ICovidAPIRepository
    {



    //    public async System.Threading.Tasks.Task<IEnumerable<CovidAPI>> GetAllCovidAsync()
    //    {
    //        var client = new HttpClient();
    //        var request = new HttpRequestMessage
    //        {
    //            Method = HttpMethod.Get,
    //            RequestUri = new Uri("https://rapidapi.p.rapidapi.com/statistics?country=North-America"),
    //            Headers =
    //{
    //    { "x-rapidapi-host", "covid-193.p.rapidapi.com" },
    //    { "x-rapidapi-key", "717f3ed96emshebef2c3dc48d153p1947e6jsnef12448f013f" },
    //},
    //        };
    //        using (var response = await client.SendAsync(request))
    //        {
    //            response.EnsureSuccessStatusCode();
    //            var body = await response.Content.ReadAsStringAsync();
    //            Console.WriteLine(body);
    //        }
    //    }
    }
}
