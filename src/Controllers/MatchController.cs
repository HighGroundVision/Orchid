// .NET
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// Microsoft
using Microsoft.AspNetCore.Mvc;
// HGV
using HGV.Crystalys;

namespace HGV.Orchid.Controllers
{
    [Route("api/[controller]")]
    public class MatchController : Controller
    {
        // GET api/match/5654634654456345
        [HttpGet("{id}")]
        public async Task<string> Get(long id)
        {
            try
            {
                var steamUserName = "Thantsking";
                var steamPassword = "aPhan3sah";

                using (var gameClient = new DotaGameClient())
                {
                    await gameClient.Connect(steamUserName, steamPassword);

                    // Download match details from game client
                    var details = await gameClient.DownloadMatchData(id);

                    // Use by pass to just download the replay from a know exist match details
                    var meta = await gameClient.DownloadMeta(id, (int)details.cluster, (int)details.replay_salt);

                    return id.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to Get match data.", ex);
            }
        }
    }
}