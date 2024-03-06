using JupilerLeague.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace JupilerLeague.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TeamInLeagueTable> LeagueTable { get; set; }
        public DbSet<TeamInTeams> Teams { get; set; }
        public DbSet<MatchViewModel> Matches { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MatchViewModel>()
                .HasOne(m => m.HomeTeam)
                .WithMany(t => t.HomeMatches)
                .HasForeignKey(m => m.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MatchViewModel>()
                .HasOne(m => m.AwayTeam)
                .WithMany(t => t.AwayMatches)
                .HasForeignKey(m => m.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

    public class TeamInLeagueTable : TeamViewModel
    {
        // Dodatkowe właściwości związane z tabelą ligową, jeśli są potrzebne
    }

    public class TeamInTeams : TeamViewModel
    {
        // Dodatkowe właściwości związane z drużyną, jeśli są potrzebne
    }
}
