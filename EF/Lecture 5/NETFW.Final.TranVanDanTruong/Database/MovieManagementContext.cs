using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using NETFW.Final.TranVanDanTruong.Models;

namespace NETFW.Final.TranVanDanTruong.Database
{
    public class MovieManagementContext : DbContext
    {
        public MovieManagementContext() : base("MovieManagementContext") { }

        public DbSet<Director> Directors { get; set; }
        public DbSet<ProductionCompany> ProductionCompanies { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }

        /// <summary>
        /// Create FluentAPI
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>()
                .HasMany<Movie>(a => a.Movies)
                .WithMany(m => m.Actors)
                .Map(cs =>
                {
                    cs.MapLeftKey("ActorID");
                    cs.MapRightKey("MovieID");
                    cs.ToTable("Performent");
                });
        }
    }
}