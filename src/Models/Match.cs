using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HGV.Orchid.Models
{
    public class Match
    {
        public ulong match_id { get; set; }
        public ulong match_seq_num { get; set; }
        public uint engine { get; set; }
        public uint game_mode { get; set; }

        public uint average_skill { get; set; }
        public float game_balance { get; set; }
        public uint human_players { get; set; }

        public uint startTime { get; set; }
        public uint pre_game_duration { get; set; }
        public uint duration { get; set; }

        public uint leagueid { get; set; }
        public uint series_id { get; set; }
        public uint series_type { get; set; }

        public uint tournament_round { get; set; }
        public uint tournament_id { get; set; }

        public ulong lobby_id { get; set; }
        public uint lobby_type { get; set; }

        public List<uint> tower_status { get; }
        public List<uint> barracks_status { get; }
        public uint first_blood_time { get; set; }

        public uint cluster { get; set; }
        public uint replay_salt { get; set; }
        public bool replay_recorded { get; set; }

        public List<Team> teams { get; }

        public uint match_outcome { get; set; }
    }

}
