using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HGV.Orchid.Models
{
    public class Player
    {
        public uint best_xpm_x16 { get; set; }

        public uint win_streak { get; set; }

        public uint best_win_streak { get; set; }

        public float fight_score { get; set; }

        public float farm_score { get; set; }
        
        public float support_score { get; set; }
        
        public float push_score { get; set; }
        
        public List<uint> level_up_times { get; }
      
        public List<float> graph_net_worth { get; }
  
        // public List<InventorySnapshot> inventory_snapshot { get; }
    
        public bool avg_stats_calibrated { get; set; }

        public uint best_gpm_x16 { get; set; }
       
        public uint account_id { get; set; }
       
        public List<uint> ability_upgrades { get; }
        
        public uint player_slot { get; set; }
        
        // public List<CSOEconItem> equipped_econ_items { get; }
       
        // public List<PlayerKill> kills { get; }
        
        // public List<ItemPurchase> items { get; }
        
        public uint avg_kills_x16 { get; set; }
        
        public uint avg_deaths_x16 { get; set; }
        
        public uint avg_assists_x16 { get; set; }
        
        public uint avg_gpm_x16 { get; set; }
        
        public uint avg_xpm_x16 { get; set; }
        
        public uint best_kills_x16 { get; set; }
        
        public uint best_assists_x16 { get; set; }

        // ############################################

        public uint hero_healing { get; set; }

        public uint level { get; set; }
   
        public uint time_last_seen { get; set; }
      
        public string player_name { get; set; }
      
        public uint support_ability_value { get; set; }

        public bool feeding_detected { get; set; }
        
        public uint search_rank { get; set; }
    
        public uint search_rank_uncertainty { get; set; }
        
        public int rank_uncertainty_change { get; set; }

        public uint hero_play_count { get; set; }
       
        public ulong party_id { get; set; }

        public float scaled_kills { get; set; }
       
        public float scaled_deaths { get; set; }
 
        public float scaled_assists { get; set; }
      
        public uint claimed_farm_gold { get; set; }
      
        public uint support_gold { get; set; }
        
        public uint claimed_denies { get; set; }

        public uint claimed_misses { get; set; }
        
        public uint misses { get; set; }
        
        // public List<CMatchPlayerAbilityUpgrade> ability_upgrades { get; }

        // public List<CMatchAdditionalUnitInventory> additional_units_inventory { get; }
       
        public uint tower_damage { get; set; }
      
        public uint hero_damage { get; set; }
        
        public uint gold_spent { get; set; }
       
        public uint XP_per_min { get; set; } 

        public uint hero_id { get; set; }
        
        public uint item_0 { get; set; }
 
        public uint item_1 { get; set; }
       
        public uint item_2 { get; set; }
   
        public uint item_3 { get; set; }
        
        public uint item_4 { get; set; }
    
        public uint item_5 { get; set; }
       
        public float expected_team_contribution { get; set; }

        public float scaled_metric { get; set; }
     
        public uint rank_change { get; set; }
       
        public bool solo_rank { get; set; }
 
        public uint deaths { get; set; }
      
        public uint assists { get; set; }
        
        public uint leaver_status { get; set; }
   
        public uint gold { get; set; }
        
        public uint last_hits { get; set; }

        public uint denies { get; set; }

        public uint gold_per_min { get; set; }

        public uint previous_rank { get; set; }

        // public CustomGameData custom_game_data { get; set; }

    }
}
