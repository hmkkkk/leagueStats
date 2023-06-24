using Newtonsoft.Json;

namespace Core.Models.RiotAPIDtos
{
    public class RiotApiParticipantDTO
    {
        [JsonProperty("allInPings")]
        public int AllInPings { get; set; }

        [JsonProperty("assistMePings")]
        public int AssistMePings { get; set; }

        [JsonProperty("assists")]
        public int Assists { get; set; }

        [JsonProperty("baitPings")]
        public int BaitPings { get; set; }

        [JsonProperty("baronKills")]
        public int BaronKills { get; set; }

        [JsonProperty("basicPings")]
        public int BasicPings { get; set; }

        [JsonProperty("bountyLevel")]
        public int BountyLevel { get; set; }

        [JsonProperty("champExperience")]
        public int ChampExperience { get; set; }

        [JsonProperty("champLevel")]
        public int ChampLevel { get; set; }

        [JsonProperty("championId")]
        public int ChampionId { get; set; }

        [JsonProperty("championName")]
        public string ChampionName { get; set; }

        [JsonProperty("championTransform")]
        public int ChampionTransform { get; set; }

        [JsonProperty("commandPings")]
        public int CommandPings { get; set; }

        [JsonProperty("consumablesPurchased")]
        public int ConsumablesPurchased { get; set; }

        [JsonProperty("damageDealtToBuildings")]
        public int DamageDealtToBuildings { get; set; }

        [JsonProperty("damageDealtToObjectives")]
        public int DamageDealtToObjectives { get; set; }

        [JsonProperty("damageDealtToTurrets")]
        public int DamageDealtToTurrets { get; set; }

        [JsonProperty("damageSelfMitigated")]
        public int DamageSelfMitigated { get; set; }

        [JsonProperty("dangerPings")]
        public int DangerPings { get; set; }

        [JsonProperty("deaths")]
        public int Deaths { get; set; }

        [JsonProperty("detectorWardsPlaced")]
        public int DetectorWardsPlaced { get; set; }

        [JsonProperty("doubleKills")]
        public int DoubleKills { get; set; }

        [JsonProperty("dragonKills")]
        public int DragonKills { get; set; }

        [JsonProperty("eligibleForProgression")]
        public bool EligibleForProgression { get; set; }

        [JsonProperty("enemyMissingPings")]
        public int EnemyMissingPings { get; set; }

        [JsonProperty("enemyVisionPings")]
        public int EnemyVisionPings { get; set; }

        [JsonProperty("firstBloodAssist")]
        public bool FirstBloodAssist { get; set; }

        [JsonProperty("firstBloodKill")]
        public bool FirstBloodKill { get; set; }

        [JsonProperty("firstTowerAssist")]
        public bool FirstTowerAssist { get; set; }

        [JsonProperty("firstTowerKill")]
        public bool FirstTowerKill { get; set; }

        [JsonProperty("gameEndedInEarlySurrender")]
        public bool GameEndedInEarlySurrender { get; set; }

        [JsonProperty("gameEndedInSurrender")]
        public bool GameEndedInSurrender { get; set; }

        [JsonProperty("getBackPings")]
        public int GetBackPings { get; set; }

        [JsonProperty("goldEarned")]
        public int GoldEarned { get; set; }

        [JsonProperty("goldSpent")]
        public int GoldSpent { get; set; }

        [JsonProperty("holdPings")]
        public int HoldPings { get; set; }

        [JsonProperty("individualPosition")]
        public string IndividualPosition { get; set; }

        [JsonProperty("inhibitorKills")]
        public int InhibitorKills { get; set; }

        [JsonProperty("inhibitorTakedowns")]
        public int InhibitorTakedowns { get; set; }

        [JsonProperty("inhibitorsLost")]
        public int InhibitorsLost { get; set; }

        [JsonProperty("item0")]
        public int Item0 { get; set; }

        [JsonProperty("item1")]
        public int Item1 { get; set; }

        [JsonProperty("item2")]
        public int Item2 { get; set; }

        [JsonProperty("item3")]
        public int Item3 { get; set; }

        [JsonProperty("item4")]
        public int Item4 { get; set; }

        [JsonProperty("item5")]
        public int Item5 { get; set; }

        [JsonProperty("item6")]
        public int Item6 { get; set; }

        [JsonProperty("itemsPurchased")]
        public int ItemsPurchased { get; set; }

        [JsonProperty("killingSprees")]
        public int KillingSprees { get; set; }

        [JsonProperty("kills")]
        public int Kills { get; set; }

        [JsonProperty("lane")]
        public string Lane { get; set; }

        [JsonProperty("largestCriticalStrike")]
        public int LargestCriticalStrike { get; set; }

        [JsonProperty("largestKillingSpree")]
        public int LargestKillingSpree { get; set; }

        [JsonProperty("largestMultiKill")]
        public int LargestMultiKill { get; set; }

        [JsonProperty("longestTimeSpentLiving")]
        public int LongestTimeSpentLiving { get; set; }

        [JsonProperty("magicDamageDealt")]
        public int MagicDamageDealt { get; set; }

        [JsonProperty("magicDamageDealtToChampions")]
        public int MagicDamageDealtToChampions { get; set; }

        [JsonProperty("magicDamageTaken")]
        public int MagicDamageTaken { get; set; }

        [JsonProperty("needVisionPings")]
        public int NeedVisionPings { get; set; }

        [JsonProperty("neutralMinionsKilled")]
        public int NeutralMinionsKilled { get; set; }

        [JsonProperty("nexusKills")]
        public int NexusKills { get; set; }

        [JsonProperty("nexusLost")]
        public int NexusLost { get; set; }

        [JsonProperty("nexusTakedowns")]
        public int NexusTakedowns { get; set; }

        [JsonProperty("objectivesStolen")]
        public int ObjectivesStolen { get; set; }

        [JsonProperty("objectivesStolenAssists")]
        public int ObjectivesStolenAssists { get; set; }

        [JsonProperty("onMyWayPings")]
        public int OnMyWayPings { get; set; }

        [JsonProperty("participantId")]
        public int ParticipantId { get; set; }

        [JsonProperty("pentaKills")]
        public int PentaKills { get; set; }

        [JsonProperty("perks")]
        public RiotApiPerksDTO Perks { get; set; }

        [JsonProperty("physicalDamageDealt")]
        public int PhysicalDamageDealt { get; set; }

        [JsonProperty("physicalDamageDealtToChampions")]
        public int PhysicalDamageDealtToChampions { get; set; }

        [JsonProperty("physicalDamageTaken")]
        public int PhysicalDamageTaken { get; set; }

        [JsonProperty("profileIcon")]
        public int ProfileIcon { get; set; }

        [JsonProperty("pushPings")]
        public int PushPings { get; set; }

        [JsonProperty("puuid")]
        public string Puuid { get; set; }

        [JsonProperty("quadraKills")]
        public int QuadraKills { get; set; }

        [JsonProperty("riotIdName")]
        public string RiotIdName { get; set; }

        [JsonProperty("riotIdTagline")]
        public string RiotIdTagline { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("sightWardsBoughtInGame")]
        public int SightWardsBoughtInGame { get; set; }

        [JsonProperty("spell1Casts")]
        public int Spell1Casts { get; set; }

        [JsonProperty("spell2Casts")]
        public int Spell2Casts { get; set; }

        [JsonProperty("spell3Casts")]
        public int Spell3Casts { get; set; }

        [JsonProperty("spell4Casts")]
        public int Spell4Casts { get; set; }

        [JsonProperty("summoner1Casts")]
        public int Summoner1Casts { get; set; }

        [JsonProperty("summoner1Id")]
        public int Summoner1Id { get; set; }

        [JsonProperty("summoner2Casts")]
        public int Summoner2Casts { get; set; }

        [JsonProperty("summoner2Id")]
        public int Summoner2Id { get; set; }

        [JsonProperty("summonerId")]
        public string SummonerId { get; set; }

        [JsonProperty("summonerLevel")]
        public int SummonerLevel { get; set; }

        [JsonProperty("summonerName")]
        public string SummonerName { get; set; }

        [JsonProperty("teamEarlySurrendered")]
        public bool TeamEarlySurrendered { get; set; }

        [JsonProperty("teamId")]
        public int TeamId { get; set; }

        [JsonProperty("teamPosition")]
        public string TeamPosition { get; set; }

        [JsonProperty("timeCCingOthers")]
        public int TimeCCingOthers { get; set; }

        [JsonProperty("timePlayed")]
        public int TimePlayed { get; set; }

        [JsonProperty("totalAllyJungleMinionsKilled")]
        public int TotalAllyJungleMinionsKilled { get; set; }

        [JsonProperty("totalDamageDealt")]
        public int TotalDamageDealt { get; set; }

        [JsonProperty("totalDamageDealtToChampions")]
        public int TotalDamageDealtToChampions { get; set; }

        [JsonProperty("totalDamageShieldedOnTeammates")]
        public int TotalDamageShieldedOnTeammates { get; set; }

        [JsonProperty("totalDamageTaken")]
        public int TotalDamageTaken { get; set; }

        [JsonProperty("totalEnemyJungleMinionsKilled")]
        public int TotalEnemyJungleMinionsKilled { get; set; }

        [JsonProperty("totalHeal")]
        public int TotalHeal { get; set; }

        [JsonProperty("totalHealsOnTeammates")]
        public int TotalHealsOnTeammates { get; set; }

        [JsonProperty("totalMinionsKilled")]
        public int TotalMinionsKilled { get; set; }

        [JsonProperty("totalTimeCCDealt")]
        public int TotalTimeCCDealt { get; set; }

        [JsonProperty("totalTimeSpentDead")]
        public int TotalTimeSpentDead { get; set; }

        [JsonProperty("totalUnitsHealed")]
        public int TotalUnitsHealed { get; set; }

        [JsonProperty("tripleKills")]
        public int TripleKills { get; set; }

        [JsonProperty("trueDamageDealt")]
        public int TrueDamageDealt { get; set; }

        [JsonProperty("trueDamageDealtToChampions")]
        public int TrueDamageDealtToChampions { get; set; }

        [JsonProperty("trueDamageTaken")]
        public int TrueDamageTaken { get; set; }

        [JsonProperty("turretKills")]
        public int TurretKills { get; set; }

        [JsonProperty("turretTakedowns")]
        public int TurretTakedowns { get; set; }

        [JsonProperty("turretsLost")]
        public int TurretsLost { get; set; }

        [JsonProperty("unrealKills")]
        public int UnrealKills { get; set; }

        [JsonProperty("visionClearedPings")]
        public int VisionClearedPings { get; set; }

        [JsonProperty("visionScore")]
        public int VisionScore { get; set; }

        [JsonProperty("visionWardsBoughtInGame")]
        public int VisionWardsBoughtInGame { get; set; }

        [JsonProperty("wardsKilled")]
        public int WardsKilled { get; set; }

        [JsonProperty("wardsPlaced")]
        public int WardsPlaced { get; set; }

        [JsonProperty("win")]
        public bool Win { get; set; }
    }
}