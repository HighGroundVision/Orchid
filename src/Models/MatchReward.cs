using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HGV.Orchid.Models
{
    public class MatchReward
    {
        public uint item_def_index { get; set; }

        public bool is_supply_crate { get; set; }

        public bool is_timed_drop { get; set; }

        public uint account_id { get; set; }

        public uint origin { get; set; }
    }
}
