namespace API.Dtos
{
    public class MatchDTO
    {
        public string MatchId { get; set; }
        public DateTime MatchDate { get; set; }
        public int QueueId { get; set; }
        public string Region { get; set; }
        public List<MatchParticipantDTO> MatchParticipants { get; set; } = new List<MatchParticipantDTO>();
    }
}