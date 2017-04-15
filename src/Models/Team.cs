using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HGV.Orchid.Models
{
    public class Team
    {
        public uint dota_team { get; set; }

        public uint team_id { get; set; }
        public uint team_complete { get; set; }
        public string team_tag { get; set; }
        public ulong team_logo { get; set; }
        public string team_name { get; set; }
        public uint guild_id { get; set; }

        public uint score { get; set; }

        public bool first_pick { get; set; }
        public uint captain_player_id { get; set; }
        public uint penalty { get; set; }
        public List<uint> picks { get; set; }
        public List<uint> bans { get; set; }
        
        public List<float> graph_net_worth { get; set; }
        public List<float> graph_gold_earned { get; set; }
        public List<float> graph_experience { get; set; }

        public List<Player> players { get; set; }

        public Team()
        {
            this.picks = new List<uint>();
            this.bans = new List<uint>();

            this.graph_experience = new List<float>();
            this.graph_gold_earned = new List<float>();
            this.graph_net_worth = new List<float>();

            this.players = new List<Player>();
        }
    }
}
