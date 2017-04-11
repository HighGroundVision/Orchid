// .NET
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// Microsoft
using Microsoft.AspNetCore.Mvc;
// HGV
using HGV.Crystalys;
using SteamKit2.GC.Dota.Internal;

namespace HGV.Orchid.Controllers
{
    [Route("api/[controller]")]
    public class MatchController : Controller
    {
        // GET api/match/3111014659
        [HttpGet("{id}")]
        public async Task<string> Get(long id)
        {
            
            var steamUserName = "Thantsking";
            var steamPassword = "aPhan3sah";

            using (var gameClient = new DotaGameClient(5))
            {
                try
                {
                    await gameClient.Connect(steamUserName, steamPassword);
                }
                catch (Exception ex)
                {
                    throw new TimeoutException("Failed to connect.", ex);
                }

                try
                {
                    var details = await gameClient.DownloadMatchData(id);
                    var meta = await gameClient.DownloadMeta(id, (int)details.cluster, (int)details.replay_salt);
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Failed to download meta", ex);
                }
            }

            return DateTime.Now.Ticks.ToString();
        }
    }
}