using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HGV.Orchid.Models
{
    public class Match
    {
        public List<MatchReward> item_rewards { get; }

        public ulong lobby_id { get; set; }

        public List<Team> teams { get; }

        // ############################################

        public uint game_mode { get; set; }

        public ulong match_seq_num { get; set; }
 
        public uint series_id { get; set; }

        public uint series_type { get; set; }
  
        public uint engine { get; set; }

        public uint leagueid { get; set; }

        public bool good_guys_win { get; set; }
  
        public uint duration { get; set; }

        public uint startTime { get; set; }

        public ulong match_id { get; set; }

        public List<uint> tower_status { get; }

        public List<uint> barracks_status { get; }

        public uint first_blood_time { get; set; }

        public uint cluster { get; set; }

        public uint lobby_type { get; set; }

        public uint human_players { get; set; }

        public uint average_skill { get; set; }

        public float game_balance { get; set; }

        public uint replay_salt { get; set; }

        // public uint positive_votes { get; set; }
        // public uint negative_votes { get; set; }
        // public List<Player> players { get; }
        // public uint server_ip { get; set; }
        // public uint server_port { get; set; }
        // public CustomGameData custom_game_data { get; set; }
        // public List<BroadcasterChannel> broadcaster_channels { get; }
        // public bool replay_state { get; set; }
        // public List<CMatchHeroSelectEvent> picks_bans { get; }

    }

}
