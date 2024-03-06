using Microsoft.AspNetCore.Mvc;
using JupilerLeague.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using JupilerLeague.Models;

namespace JupilerLeague.Controllers
{
    public class TableController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TableController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Table()
        {
            // Pobierz wszystkie drużyny
            var teams = await _context.Teams.Include(t => t.HomeMatches).Include(t => t.AwayMatches).ToListAsync();

            // Pobierz wszystkie mecze
            var matches = await _context.Matches
                .Include(m => m.HomeTeam)
                .Include(m => m.AwayTeam)
                .ToListAsync();

            // Aktualizuj statystyki drużyn na podstawie meczów
            foreach (var team in teams)
            {
                team.HomeMatches = matches.Where(m => m.HomeTeamId == team.Id).ToList();
                team.AwayMatches = matches.Where(m => m.AwayTeamId == team.Id).ToList();
                team.MatchesPlayed = team.HomeMatches.Count + team.AwayMatches.Count;
                team.Win = team.HomeMatches.Count(m => m.HomeScore > m.AwayScore) + team.AwayMatches.Count(m => m.AwayScore > m.HomeScore);
                team.Draw = team.HomeMatches.Count(m => m.HomeScore == m.AwayScore) + team.AwayMatches.Count(m => m.AwayScore == m.HomeScore);
                team.Lose = team.HomeMatches.Count(m => m.HomeScore < m.AwayScore) + team.AwayMatches.Count(m => m.AwayScore < m.HomeScore);
                team.GoalDifference = team.HomeMatches.Sum(m => m.HomeScore - m.AwayScore) + team.AwayMatches.Sum(m => m.AwayScore - m.HomeScore);
                team.Points = team.Win * 3 + team.Draw;
            }

            // Sortuj drużyny według punktów
            teams = teams.OrderByDescending(t => t.Points).ToList();

            return View(teams);
        }
    }
}
