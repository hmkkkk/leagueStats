import { SummonerRank } from "./SummonerRank";

export interface Summoner {
    profileIconId: number;
    name: string;
    summonerLevel: number;
    lastUpdated: string;
    summonerRanks: SummonerRank[];
    region: string;
}