using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HGV.Orchid.Models
{
    public class Snapshot
    { 
        public int game_time { get; set; }      
        public uint kills { get; set; }      
        public uint deaths { get; set; }   
        public uint assists { get; set; }
        public uint level { get; set; }
        public List<uint> inventory { get; }
    }
}
