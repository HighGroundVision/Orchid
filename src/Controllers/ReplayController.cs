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
    public class ReplayController : Controller
    {
        // GET api/match/3111014659
        [HttpGet("{id}")]
        public async Task<byte[]> Get(long id)
        {
            var steamUserName = "Thantsking";
            var steamPassword = "aPhan3sah";

            using (var gameClient = new DotaGameClient(timeout_seconds: 5))
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
                    return await gameClient.DownloadReplay(id);
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Failed to download meta", ex);
                }
            }
        }
    }
}