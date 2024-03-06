using JupilerLeague.Data;
using JupilerLeague.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace JupilerLeague.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Account()
        {
            var userId = _userManager.GetUserId(User);

            var allTeams = await _context.Teams
                .Select(t => new TeamViewModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    LogoPath = t.LogoPath
                })
                .ToListAsync();

            var favoriteTeams = await _context.FavouriteTeam 
                .Where(ft => ft.UserId == userId)
                .Select(ft => new TeamViewModel
                {
                    Id = ft.Team.Id,
                    Name = ft.Team.Name,
                    LogoPath = ft.Team.LogoPath
                })
                .ToListAsync();

            var model = new AccountViewModel
            {
                AllTeams = allTeams,
                FavoriteTeams = favoriteTeams
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddFavoriteTeam(int teamId)
        {
            var userId = _userManager.GetUserId(User);


            var existingFav = await _context.FavouriteTeam 
                .AnyAsync(ft => ft.UserId == userId && ft.TeamId == teamId);
            if (!existingFav)
            {
                var favoriteTeam = new FavouriteTeamViewModel { UserId = userId, TeamId = teamId };
                _context.FavouriteTeam.Add(favoriteTeam);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Account));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFavoriteTeam(int teamId)
        {
            var userId = _userManager.GetUserId(User);

            var favoriteTeam = await _context.FavouriteTeam
                .FirstOrDefaultAsync(ft => ft.UserId == userId && ft.TeamId == teamId);

            if (favoriteTeam != null)
            {
                _context.FavouriteTeam.Remove(favoriteTeam);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Account));
        }
    }
}
