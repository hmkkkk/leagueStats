import { MatchParticipant } from "./MatchParticipant";

export interface Match {
    matchId: string;
    matchDate: string;
    queueId: number;
    participantPuuids: string;
    region: string;
    matchParticipants: MatchParticipant[];
}