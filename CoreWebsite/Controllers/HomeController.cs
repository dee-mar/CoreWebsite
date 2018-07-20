using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreWebsite.Models;
using CoreWebsite.Models.SteamApi;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace CoreWebsite.Controllers
{
    public class HomeController : Controller
    {
        private IConfiguration _configuration;
        //private OwnedGamesSummary oOwnedGamesSummary;

        public HomeController(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<ActionResult> About()
        {
            string sSteamId = _configuration["Steam:SteamId"];
            OwnedGamesSummary oOwnedGamesSummary = await GetOwnedGames(sSteamId);
            SteamPlayerSummaries oSteamPlayerSummaries = await GetPlayerSummaries(sSteamId);

            return View(oOwnedGamesSummary);
        }

        private async Task<OwnedGamesSummary> GetOwnedGames(string steamId)
        {
            GetOwnedGamesResponse oResponse = new GetOwnedGamesResponse();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.steampowered.com/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                string sAPIKey = _configuration["Steam:ApiKey"];
                
                HttpResponseMessage Res = await client.GetAsync("IPlayerService/GetOwnedGames/v0001/?key=" + sAPIKey + "&steamid=" + steamId + "&format=json&include_appinfo=1");

                //Test Call https://api.steampowered.com/IPlayerService/GetOwnedGames/v0001/?key=573995896871E7891B78DA9E841FCEB5&steamid=76561197960434622&format=json&include_appinfo=1

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var SteamResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    oResponse = JsonConvert.DeserializeObject<GetOwnedGamesResponse>(SteamResponse);

                    //Console.WriteLine(oResponse.Response.game_count);
                }

                return oResponse.Response;
            }
        }

        private async Task<SteamPlayerSummaries> GetPlayerSummaries(string steamIds)
        {
            GetSteamPlayerSummariesResponse oResponse = new GetSteamPlayerSummariesResponse();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.steampowered.com/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                string sAPIKey = _configuration["Steam:ApiKey"];

                HttpResponseMessage Res = await client.GetAsync("ISteamUser/GetPlayerSummaries/v0002/?key=" + sAPIKey + "&steamids=" + steamIds + "&format=json");

                //Test Call https://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key=573995896871E7891B78DA9E841FCEB5&steamids=76561197960435530

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var SteamResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    oResponse = JsonConvert.DeserializeObject<GetSteamPlayerSummariesResponse>(SteamResponse);

                    //Console.WriteLine(oResponse.Response.game_count);
                }

                return oResponse.Response;
            }
        }
    }
}
