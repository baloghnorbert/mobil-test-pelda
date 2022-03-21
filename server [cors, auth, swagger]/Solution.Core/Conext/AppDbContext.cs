using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Solution.Core.Models.Entities;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Solution.Core.Conext
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Position> Positions { get; set; }

        public AppDbContext() : base()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Player>()
                                      .HasOne(x => x.Position);
            
            ImportPlayers(modelBuilder);
            ImportPositions(modelBuilder);
        }

        private void ImportPlayers(ModelBuilder modelBuilder)
        {
            List<Player> players = null;

            using (FileStream fs = new FileStream("data.json", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
                {
                    string jsonData = sr.ReadToEnd();

                    players = JsonConvert.DeserializeObject<List<Player>>(jsonData);

                    foreach (Player player in players)
                    {
                        modelBuilder.Entity<Player>()
                                                   .HasData(player);
                    }
                }
            }
        }

        private void ImportPositions(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Position>()
                                                   .HasData(new Position(1, "Spiker"));
            modelBuilder.Entity<Position>()
                                                   .HasData(new Position(2, "Setter"));
            modelBuilder.Entity<Position>()
                                                   .HasData(new Position(3, "Libero"));
            modelBuilder.Entity<Position>()
                                                   .HasData(new Position(4, "Opposite"));
            modelBuilder.Entity<Position>()
                                                   .HasData(new Position(5, "Center"));
        }
    }
}
