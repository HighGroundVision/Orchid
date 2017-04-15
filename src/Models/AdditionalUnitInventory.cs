using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HGV.Orchid.Models
{
    public class AdditionalUnitInventory
    {
        public string unit_name { get; set; }
        public List<uint> items { get; set; }

        public AdditionalUnitInventory()
        {
            this.items = new List<uint>();
        }
    }
}
