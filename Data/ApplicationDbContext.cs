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

        public DbSet<FavouriteTeamViewModel> FavouriteTeam { get; set; }
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

            modelBuilder.Entity<FavouriteTeamViewModel>().ToTable("FavouriteTeam");
        }
    }

    public class TeamInLeagueTable : TeamViewModel
    {
    }

    public class TeamInTeams : TeamViewModel
    {
    }
}
