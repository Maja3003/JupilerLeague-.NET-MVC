using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JupilerLeague.Models
{
    public class FavouriteTeamViewModel
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public IdentityUser User { get; set; }

        public int TeamId { get; set; }

        [ForeignKey("TeamId")]
        public TeamViewModel Team { get; set; }
    }
}