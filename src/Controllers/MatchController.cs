using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HGV.Crystalys;
using HGV.Orchid.Models;

namespace HGV.Orchid.Controllers
{
    [Produces("application/json")]
    [Route("api/match")]
    public class MatchController : Controller
    {
        DotaClient DotaClient { get; set; }

        public MatchController(DotaClient dotaClient)
        {
            this.DotaClient = dotaClient;
        }

        // GET api/match/3111014659
        [HttpGet("{id}")]
        [ResponseCache(Duration = 3600, VaryByQueryKeys = new string[] { "id" })]
        public async Task<Match> Get(long id)
        {
            var data = this.DotaClient.DownloadMatchData((ulong)id);
            var meta = await this.DotaClient.DownloadMeta(data.match_id, data.cluster, data.replay_salt);

            var match = new Match();
            match.average_skill = data.average_skill;
            match.barracks_status = data.barracks_status;
            match.cluster = data.cluster;
            match.duration = data.duration;
            match.engine = data.engine;
            match.first_blood_time = data.first_blood_time;
            match.game_balance = data.game_balance;
            match.game_mode = (uint)data.game_mode;
            match.human_players = data.human_players;
            match.leagueid = data.leagueid;
            match.lobby_id = meta.lobby_id;
            match.lobby_type = data.lobby_type;
            match.match_id = data.match_id;
            match.match_outcome = (uint)data.match_outcome;
            match.match_seq_num = data.match_seq_num;
            match.pre_game_duration = data.pre_game_duration;
            match.replay_recorded = data.replay_state != SteamKit2.GC.Dota.Internal.CMsgDOTAMatch.ReplayState.REPLAY_NOT_RECORDED;
            match.replay_salt = data.replay_salt;
            match.series_id = data.series_id;
            match.series_type = data.series_type;
            match.startTime = data.startTime;
            match.tournament_id = data.tournament_id;
            match.tournament_round = data.tournament_round;
            match.tower_status = data.tower_status;

            var teams = meta.teams.Take(2);
            var goodGuys = teams.FirstOrDefault();
            var badGuys = teams.LastOrDefault();

            if (goodGuys == null || badGuys == null)
                throw new ArgumentOutOfRangeException(nameof(teams));

            var radiant_team = new Team();
            radiant_team.dota_team = goodGuys.dota_team;
            radiant_team.graph_experience = goodGuys.graph_experience;
            radiant_team.graph_gold_earned = goodGuys.graph_gold_earned;
            radiant_team.graph_net_worth = goodGuys.graph_net_worth;
            radiant_team.bans = goodGuys.cm_bans;
            radiant_team.captain_player_id = goodGuys.cm_captain_player_id;
            radiant_team.first_pick = goodGuys.cm_first_pick;
            radiant_team.guild_id = data.radiant_guild_id;
            radiant_team.penalty = goodGuys.cm_penalty;
            radiant_team.picks = goodGuys.cm_picks;
            radiant_team.score = data.radiant_team_score;
            radiant_team.team_complete = data.radiant_team_complete;
            radiant_team.team_id = data.radiant_team_id;
            radiant_team.team_logo = data.radiant_team_logo;
            radiant_team.team_name = data.radiant_team_name;
            radiant_team.team_tag = data.radiant_team_tag;

            var radiant_players = goodGuys.players.Join(data.players, _ => _.player_slot, _ => _.player_slot, (lhs, rhs) => new { Source1 = lhs, Source2 = rhs }).ToList();
            foreach (var pair in radiant_players)
            {
                var player = new Player();
                player.account_id = pair.Source1.account_id;
                player.additional_units_inventory = pair.Source2.additional_units_inventory.Select(_ => new AdditionalUnitInventory() {
                    unit_name = _.unit_name,
                    items = _.items
                }).ToList();
                player.assists = pair.Source2.assists;
                player.avg_assists = pair.Source1.avg_assists_x16;
                player.avg_deaths = pair.Source1.avg_deaths_x16;
                player.avg_gpm = pair.Source1.avg_gpm_x16;
                player.avg_kills = pair.Source1.avg_kills_x16;
                player.avg_xpm = pair.Source1.avg_xpm_x16;
                player.avg_stats_calibrated = pair.Source1.avg_stats_calibrated;
                player.best_assists = pair.Source1.best_assists_x16;
                player.best_gpm = pair.Source1.best_gpm_x16;
                player.best_kills = pair.Source1.best_kills_x16;
                player.best_win_streak = pair.Source1.best_win_streak;
                player.best_xpm = pair.Source1.best_xpm_x16;
                player.claimed_denies = pair.Source2.claimed_denies;
                player.claimed_farm_gold = pair.Source2.claimed_farm_gold;
                player.claimed_misses = pair.Source2.claimed_misses;
                player.deaths = pair.Source2.deaths;
                player.denies = pair.Source2.denies;
                player.dota_team = radiant_team.dota_team;
                player.expected_team_contribution = pair.Source2.expected_team_contribution;
                player.farm_score = pair.Source1.farm_score;
                player.feeding_detected = pair.Source2.feeding_detected;
                player.fights = pair.Source1.kills.Select(_ => new Fight() {
                    count = _.count,
                    victim_slot = _.victim_slot
                }).ToList();
                player.fight_score = pair.Source1.fight_score;
                player.gold = pair.Source2.gold;
                player.gold_spent = pair.Source2.gold_spent;
                player.gpm = pair.Source2.gold_per_min;
                player.graph_net_worth = pair.Source1.graph_net_worth;
                player.hero_damage = pair.Source2.hero_damage;
                player.hero_healing = pair.Source2.hero_healing;
                player.hero_id = pair.Source2.hero_id;
                player.hero_play_count = pair.Source2.hero_play_count;
                player.inventory = new List<uint>() {
                    pair.Source2.item_0,
                    pair.Source2.item_1,
                    pair.Source2.item_2,
                    pair.Source2.item_3,
                    pair.Source2.item_4,
                    pair.Source2.item_5,
                    pair.Source2.item_6,
                    pair.Source2.item_7,
                    pair.Source2.item_8
                };
                player.last_hits = pair.Source2.last_hits;
                player.leaver_status = pair.Source2.leaver_status;
                player.level = pair.Source2.level;
                player.match_id = data.match_id;
                player.misses = pair.Source2.misses;
                player.party_id = pair.Source2.party_id;
                player.permanent_buffs = pair.Source2.permanent_buffs.Select(_ => new PermanentBuff() {
                    buff = _.permanent_buff,
                    count = _.stack_count
                }).ToList();
                player.player_name = pair.Source2.player_name;
                player.player_slot = pair.Source2.player_slot;
                player.previous_rank = pair.Source2.previous_rank;
                player.purchases = pair.Source1.items.Select(_ => new ItemPurchase() {
                    item_id = _.item_id,
                    purchase_time = _.purchase_time
                }).ToList();
                player.push_score = pair.Source1.push_score;
                player.rank_change = pair.Source2.rank_change;
                player.rank_uncertainty_change = pair.Source2.rank_uncertainty_change;
                player.scaled_assists = pair.Source2.scaled_assists;
                player.scaled_deaths = pair.Source2.scaled_deaths;
                player.scaled_kills = pair.Source2.scaled_kills;
                player.scaled_metric = pair.Source2.scaled_metric;
                player.search_rank = pair.Source2.search_rank;
                player.search_rank_uncertainty = pair.Source2.search_rank_uncertainty;
                player.snapshot = pair.Source1.inventory_snapshot.Select(_ => new Snapshot() {
                    assists = _.assists,
                    deaths = _.deaths,
                    game_time = _.game_time,
                    kills = _.kills,
                    level = _.level,
                    inventory = _.item_id
                }).ToList();
                player.solo_rank = pair.Source2.solo_rank;
                player.support_ability_value = pair.Source2.support_ability_value;
                player.support_gold = pair.Source2.support_gold;
                player.support_score = pair.Source1.support_score;
                player.time_last_seen = pair.Source2.time_last_seen;
                player.tower_damage = pair.Source2.tower_damage;
                player.upgrades = pair.Source2.ability_upgrades.Select(_ => new AbilityUpgrade()
                {
                    ability = _.ability,
                    time = _.time
                }).ToList();
                player.win_streak = pair.Source1.win_streak;
                player.xpm = pair.Source2.XP_per_min;

                radiant_team.players.Add(player);
            }

            match.teams.Add(radiant_team);

            var dire_team = new Team();
            dire_team.dota_team = goodGuys.dota_team;
            dire_team.graph_experience = goodGuys.graph_experience;
            dire_team.graph_gold_earned = goodGuys.graph_gold_earned;
            dire_team.graph_net_worth = goodGuys.graph_net_worth;
            dire_team.bans = goodGuys.cm_bans;
            dire_team.captain_player_id = goodGuys.cm_captain_player_id;
            dire_team.first_pick = goodGuys.cm_first_pick;
            dire_team.guild_id = data.dire_guild_id;
            dire_team.penalty = goodGuys.cm_penalty;
            dire_team.picks = goodGuys.cm_picks;
            dire_team.score = data.dire_team_score;
            dire_team.team_complete = data.dire_team_complete;
            dire_team.team_id = data.dire_team_id;
            dire_team.team_logo = data.dire_team_logo;
            dire_team.team_name = data.dire_team_name;
            dire_team.team_tag = data.dire_team_tag;

            var dire_players = badGuys.players.Join(data.players, _ => _.player_slot, _ => _.player_slot, (lhs, rhs) => new { }).ToList();
            foreach (var pair in radiant_players)
            {
                var player = new Player();
                player.account_id = pair.Source1.account_id;
                player.additional_units_inventory = pair.Source2.additional_units_inventory.Select(_ => new AdditionalUnitInventory()
                {
                    unit_name = _.unit_name,
                    items = _.items
                }).ToList();
                player.assists = pair.Source2.assists;
                player.avg_assists = pair.Source1.avg_assists_x16;
                player.avg_deaths = pair.Source1.avg_deaths_x16;
                player.avg_gpm = pair.Source1.avg_gpm_x16;
                player.avg_kills = pair.Source1.avg_kills_x16;
                player.avg_xpm = pair.Source1.avg_xpm_x16;
                player.avg_stats_calibrated = pair.Source1.avg_stats_calibrated;
                player.best_assists = pair.Source1.best_assists_x16;
                player.best_gpm = pair.Source1.best_gpm_x16;
                player.best_kills = pair.Source1.best_kills_x16;
                player.best_win_streak = pair.Source1.best_win_streak;
                player.best_xpm = pair.Source1.best_xpm_x16;
                player.claimed_denies = pair.Source2.claimed_denies;
                player.claimed_farm_gold = pair.Source2.claimed_farm_gold;
                player.claimed_misses = pair.Source2.claimed_misses;
                player.deaths = pair.Source2.deaths;
                player.denies = pair.Source2.denies;
                player.dota_team = radiant_team.dota_team;
                player.expected_team_contribution = pair.Source2.expected_team_contribution;
                player.farm_score = pair.Source1.farm_score;
                player.feeding_detected = pair.Source2.feeding_detected;
                player.fights = pair.Source1.kills.Select(_ => new Fight()
                {
                    count = _.count,
                    victim_slot = _.victim_slot
                }).ToList();
                player.fight_score = pair.Source1.fight_score;
                player.gold = pair.Source2.gold;
                player.gold_spent = pair.Source2.gold_spent;
                player.gpm = pair.Source2.gold_per_min;
                player.graph_net_worth = pair.Source1.graph_net_worth;
                player.hero_damage = pair.Source2.hero_damage;
                player.hero_healing = pair.Source2.hero_healing;
                player.hero_id = pair.Source2.hero_id;
                player.hero_play_count = pair.Source2.hero_play_count;
                player.inventory = new List<uint>() {
                    pair.Source2.item_0,
                    pair.Source2.item_1,
                    pair.Source2.item_2,
                    pair.Source2.item_3,
                    pair.Source2.item_4,
                    pair.Source2.item_5,
                    pair.Source2.item_6,
                    pair.Source2.item_7,
                    pair.Source2.item_8
                };
                player.last_hits = pair.Source2.last_hits;
                player.leaver_status = pair.Source2.leaver_status;
                player.level = pair.Source2.level;
                player.match_id = data.match_id;
                player.misses = pair.Source2.misses;
                player.party_id = pair.Source2.party_id;
                player.permanent_buffs = pair.Source2.permanent_buffs.Select(_ => new PermanentBuff()
                {
                    buff = _.permanent_buff,
                    count = _.stack_count
                }).ToList();
                player.player_name = pair.Source2.player_name;
                player.player_slot = pair.Source2.player_slot;
                player.previous_rank = pair.Source2.previous_rank;
                player.purchases = pair.Source1.items.Select(_ => new ItemPurchase()
                {
                    item_id = _.item_id,
                    purchase_time = _.purchase_time
                }).ToList();
                player.push_score = pair.Source1.push_score;
                player.rank_change = pair.Source2.rank_change;
                player.rank_uncertainty_change = pair.Source2.rank_uncertainty_change;
                player.scaled_assists = pair.Source2.scaled_assists;
                player.scaled_deaths = pair.Source2.scaled_deaths;
                player.scaled_kills = pair.Source2.scaled_kills;
                player.scaled_metric = pair.Source2.scaled_metric;
                player.search_rank = pair.Source2.search_rank;
                player.search_rank_uncertainty = pair.Source2.search_rank_uncertainty;
                player.snapshot = pair.Source1.inventory_snapshot.Select(_ => new Snapshot()
                {
                    assists = _.assists,
                    deaths = _.deaths,
                    game_time = _.game_time,
                    kills = _.kills,
                    level = _.level,
                    inventory = _.item_id
                }).ToList();
                player.solo_rank = pair.Source2.solo_rank;
                player.support_ability_value = pair.Source2.support_ability_value;
                player.support_gold = pair.Source2.support_gold;
                player.support_score = pair.Source1.support_score;
                player.time_last_seen = pair.Source2.time_last_seen;
                player.tower_damage = pair.Source2.tower_damage;
                player.upgrades = pair.Source2.ability_upgrades.Select(_ => new AbilityUpgrade()
                {
                    ability = _.ability,
                    time = _.time
                }).ToList();
                player.win_streak = pair.Source1.win_streak;
                player.xpm = pair.Source2.XP_per_min;

                dire_team.players.Add(player);
            }

            match.teams.Add(dire_team);
            
            return match;
        }
    }
}