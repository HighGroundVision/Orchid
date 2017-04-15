using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HGV.Crystalys;
using HGV.Orchid.Models;
using System.IO;

namespace HGV.Orchid.Controllers
{
    [Route("api/replay")]
    public class ReplayController : Controller
    {
        DotaClient DotaClient { get; set; }

        public ReplayController(DotaClient dotaClient)
        {
            this.DotaClient = dotaClient;
        }

        // GET api/replay/3111014659
        [HttpGet("{id}")]
        public async Task<Stream> Get(long id)
        {
            var data = this.DotaClient.DownloadMatchData((ulong)id);
            var replay = await this.DotaClient.DownloadReplay(data.match_id, data.cluster, data.replay_salt);
            return new MemoryStream(replay);
        }
    }
}