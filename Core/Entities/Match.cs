using Microsoft.EntityFrameworkCore;

namespace Core.Entities
{
    [PrimaryKey(nameof(MatchId))]
    public class Match
    {
        public string MatchId { get; set; }
        public DateTime MatchDate { get; set; }
        public int QueueId { get; set; }
        public string ParticipantPuuids { get; set; }
        public List<MatchParticipant> MatchParticipants { get; set; } = new List<MatchParticipant>();
    }
}