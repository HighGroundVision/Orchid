using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HGV.Orchid.Models
{
    public class Team
    {
        public uint cm_penalty { get; set; }

        public List<uint> cm_picks { get; }

        public List<uint> cm_bans { get; }

        public uint cm_captain_player_id { get; set; }
 
        public List<float> graph_net_worth { get; }
       
        public List<float> graph_gold_earned { get; }
  
        public List<float> graph_experience { get; }
    
        public List<Player> players { get; }

        public uint dota_team { get; set; }

        public bool cm_first_pick { get; set; }

        // ############################################

        public uint team_complete { get; set; }

        public uint guild_id { get; set; }

        public string team_tag { get; set; }

        public ulong team_logo { get; set; }

        public string team_name { get; set; }
    }
}
