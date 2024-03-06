using System.Collections.Generic;

namespace JupilerLeague.Models
{
    public class TeamViewModel
    {
        public int Id { get; set; }
        public int Position { get; set; }
        public string Name { get; set; }
        public string LogoPath { get; set; }
        public int MatchesPlayed { get; set; }
        public int Win { get; set; }
        public int Draw { get; set; }
        public int Lose { get; set; }
        public int GoalDifference { get; set; }
        public int Points { get; set; }

        public List<MatchViewModel> HomeMatches { get; set; }
        public List<MatchViewModel> AwayMatches { get; set; }

        public string Kolejka1Nazwa { get; set; }
        public int Wynik1 { get; set; }
        public int Wynik2 { get; set; }
        public string Kolejka1Herb { get; set; }
        public string Kolejka1Nazwa2 { get; set; }
        public string Kolejka1Herb2 { get; set; }

        public string Kolejka2Nazwa { get; set; }
        public int Wynik3 { get; set; }
        public int Wynik4 { get; set; }
        public string Kolejka2Herb { get; set; }
        public string Kolejka2Nazwa2 { get; set; }
        public string Kolejka2Herb2 { get; set; }

    }
}

