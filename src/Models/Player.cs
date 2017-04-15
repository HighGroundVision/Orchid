using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HGV.Orchid.Models
{
    public class Player
    {
        public uint account_id { get; set; }
        public string player_name { get; set; }
        public uint player_slot { get; set; }
        public uint time_last_seen { get; set; }

        public uint hero_id { get; set; }
        public uint hero_play_count { get; set; }
        
        public ulong party_id { get; set; }

        public uint leaver_status { get; set; }
        public uint dota_team { get; set; }
        public ulong match_id { get; set; }

        // AVG
        public bool avg_stats_calibrated { get; set; }
        public uint avg_kills_x16 { get; set; }
        public uint avg_deaths_x16 { get; set; }
        public uint avg_assists_x16 { get; set; }
        public uint avg_gpm_x16 { get; set; }
        public uint avg_xpm_x16 { get; set; }

        // Best
        public uint best_xpm_x16 { get; set; }
        public uint best_win_streak { get; set; }
        public uint best_gpm_x16 { get; set; }
        public uint best_kills_x16 { get; set; }
        public uint best_assists_x16 { get; set; }

        // Score
        public float fight_score { get; set; }
        public float farm_score { get; set; }
        public float support_score { get; set; }
        public float push_score { get; set; }

        public uint support_ability_value { get; set; }
        public bool feeding_detected { get; set; }

        // Rank
        public uint search_rank { get; set; }
        public uint search_rank_uncertainty { get; set; }
        public int rank_uncertainty_change { get; set; }
        public uint rank_change { get; set; }
        public bool solo_rank { get; set; }
        public uint previous_rank { get; set; }
        public float scaled_metric { get; set; }

        public float expected_team_contribution { get; set; }

        public uint level { get; set; }
        public uint win_streak { get; set; }
        public uint hero_healing { get; set; }

        public uint gold_spent { get; set; }
        public uint claimed_farm_gold { get; set; }
        public uint support_gold { get; set; }
        public uint gold { get; set; }

        public uint tower_damage { get; set; }     
        public uint hero_damage { get; set; }

        public float scaled_kills { get; set; }
        public float scaled_deaths { get; set; }
        public float scaled_assists { get; set; }
        public uint claimed_denies { get; set; }
        public uint claimed_misses { get; set; }
        public uint misses { get; set; }
        public uint deaths { get; set; }
        public uint assists { get; set; }
        public uint last_hits { get; set; }
        public uint denies { get; set; }
        public uint gpm { get; set; }
        public uint xpm { get; set; }

        public List<uint> inventory { get; set; }                   // public List<InventorySnapshot> inventory_snapshot { get; }
        public List<uint> additional_units_inventory { get; set; }  // public List<CMatchAdditionalUnitInventory> additional_units_inventory { get; }

        public List<float> graph_net_worth { get; }

        public List<Snapshot> snapshot { get; set; }
        public List<ItemPurchase> purchases { get; set; }           // public List<ItemPurchase> items { get; }
        public List<AbilityUpgrade> upgrades { get; set; }          // public List<CMatchPlayerAbilityUpgrade> ability_upgrades { get; }
        public List<Fight> fights { get; }                          // public List<PlayerKill> kills { get; }
        public List<PermanentBuff> permanent_buffs { get; set; }    // public List<CMatchPlayerPermanentBuff> permanent_buffs { get; }

    }
}
