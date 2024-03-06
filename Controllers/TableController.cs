using Microsoft.AspNetCore.Mvc;
using JupilerLeague.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using JupilerLeague.Models;
using Microsoft.AspNetCore.Identity;

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
            var matches = await _context.Matches
                .Include(m => m.HomeTeam)
                .Include(m => m.AwayTeam)
                .Where(m => !m.PointsUpdated)
                .ToListAsync();

            // Utwórz słownik do śledzenia, które mecze zostały zaktualizowane
            var updatedMatches = new Dictionary<string, bool>();

            foreach (var match in matches)
            {
                // Klucz unikalnie identyfikujący mecz bez względu na to, która drużyna jest gospodarzem
                var matchKey = $"{match.Week}_{System.Math.Min(match.HomeTeamId, match.AwayTeamId)}_{System.Math.Max(match.HomeTeamId, match.AwayTeamId)}";

                if (!updatedMatches.ContainsKey(matchKey))
                {
                    if (match.HomeScore > match.AwayScore)
                    {
                        match.HomeTeam.MatchesPlayed += 1;
                        match.HomeTeam.Win += 1;
                        match.HomeTeam.Points += 3;
                        match.AwayTeam.Lose += 1;
                        match.AwayTeam.MatchesPlayed += 1;
                    }
                    else if (match.HomeScore < match.AwayScore)
                    {
                        match.HomeTeam.MatchesPlayed += 1;
                        match.HomeTeam.Lose += 1;
                        match.AwayTeam.Win += 1;
                        match.AwayTeam.Points += 3;
                        match.AwayTeam.MatchesPlayed += 1;
                    }
                    else
                    {
                        match.HomeTeam.MatchesPlayed += 1;
                        match.AwayTeam.Draw += 1;
                        match.HomeTeam.Draw += 1;
                        match.HomeTeam.Points += 1;
                        match.AwayTeam.Points += 1;
                        match.AwayTeam.MatchesPlayed += 1;
                    }

                    // Oznacz, że punkty zostały zaktualizowane dla tego meczu
                    updatedMatches[matchKey] = true;
                    
                }
                match.PointsUpdated = true;
            }

            // Zapisz zmiany w bazie danych
            await _context.SaveChangesAsync();

            // Sortowanie i wyświetlanie drużyn
            var sortedTeams = await _context.Teams.OrderByDescending(t => t.Points).ToListAsync();
            // Przydzielaj kolejne pozycje
            int position = 1;
            foreach (var team in sortedTeams)
            {
                team.Position = position++;
                _context.Teams.Update(team);
            }

            await _context.SaveChangesAsync();

            return View(sortedTeams);
        }
    }
}


