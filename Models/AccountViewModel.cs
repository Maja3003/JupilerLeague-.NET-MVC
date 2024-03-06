using System.Collections.Generic;

namespace JupilerLeague.Models
{
    public class AccountViewModel
    {
        public IEnumerable<TeamViewModel> AllTeams { get; set; }
        public IEnumerable<TeamViewModel> FavoriteTeams { get; set; }
    }
}
