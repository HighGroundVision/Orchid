using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HGV.Crystalys;

namespace HGV.Orchid.Controllers
{
    [Produces("application/json")]
    [Route("api/match")]
    public class MatchController : Controller
    {
        DotaClient DotaClient { get; set; }

        public MatchController(DotaClient dotaClient)
        {
            this.DotaClient = dotaClient;
        }

        // GET api/match/3111014659
        [HttpGet("{id}")]
        public async Task<SteamKit2.GC.Dota.Internal.CDOTAMatchMetadata> Get(long id)
        {
            var data = this.DotaClient.DownloadMatchData((ulong)id);
            var meta = await this.DotaClient.DownloadMeta(data.match_id, data.cluster, data.replay_salt);

            return meta;
        }
    }
}