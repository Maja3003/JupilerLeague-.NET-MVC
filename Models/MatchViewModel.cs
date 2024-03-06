namespace JupilerLeague.Models
{
    public class MatchViewModel
    {
        public int Id { get; set; }
        public int Week { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public bool PointsUpdated { get; set; }

        public TeamViewModel HomeTeam { get; set; }
        public TeamViewModel AwayTeam { get; set; }
    }
}
