using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using TmPuzzle.Entities;

namespace TmPuzzle.Database
{
    public class TmPuzzleContext : DbContext
    {
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<CampaignMap> CampaignMaps { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<EasterEgg> EasterEggs { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerPermission> PlayerPermissions { get; set; }
        public DbSet<PlayerSolves> PlayerSolves { get; set; }

        public TmPuzzleContext(DbContextOptions<TmPuzzleContext> options, IConfiguration configuration)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseLazyLoadingProxies();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Campaign>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Name).HasColumnType("nvarchar(100)").IsRequired();
            });
            modelBuilder.Entity<CampaignMap>(entity =>
            {
                entity.HasKey(cm => cm.Id);
                entity.HasOne(cm => cm.Campaign).WithMany(c => c.CampaignMaps);
                entity.HasOne(cm => cm.Map).WithMany(m => m.CampaignMaps);
            });
            modelBuilder.Entity<Map>(entity =>
            {
                entity.HasKey(m => m.Id);
                entity.Property(m => m.Name).HasColumnType("nvarchar(100)").IsRequired();
                entity.Property(m => m.MapUid).HasColumnType("nvarchar(20)").IsRequired();
            });
            modelBuilder.Entity<EasterEgg>(entity =>
            {
                entity.HasKey(ee => ee.Id);
                entity.Property(ee => ee.Name).HasColumnType("nvarchar(50)").IsRequired();
                entity.Property(ee => ee.Value).HasColumnType("nvarchar(50)").IsRequired();
                entity.Property(ee => ee.ImageBlob).HasColumnType("nvarchar(max)").IsRequired();
                entity.Property(ee => ee.MediaUrl).HasColumnType("nvarchar(150)").IsRequired();
                entity.Property(ee => ee.Hint).HasColumnType("nvarchar(150)").IsRequired();
                entity.Property(ee => ee.ManiaScript).HasColumnType("nvarchar(max)").IsRequired();
                entity.HasOne(ee => ee.Map).WithMany(m => m.EasterEggs);
            });
            modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(m => m.Name).HasColumnType("nvarchar(20)").IsRequired();
            });
            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Login).HasColumnType("nvarchar(20)").IsRequired();
                entity.Property(p => p.Name).HasColumnType("nvarchar(50)").IsRequired();
                entity.Property(p => p.ContactInfo).HasColumnType("nvarchar(100)").IsRequired();
            });
            modelBuilder.Entity<PlayerPermission>(entity =>
            {
                entity.HasKey(pp => pp.Id);
                entity.HasOne(pp => pp.Player).WithMany(p => p.Permissions);
                entity.HasOne(pp => pp.Permission).WithMany(p => p.PlayerPermissions);
            });
            modelBuilder.Entity<PlayerSolves>(entity =>
            {
                entity.HasKey(ps => ps.Id);
                entity.HasOne(ps => ps.Player).WithMany(p => p.SolvedEasterEggs);
                entity.HasOne(ps => ps.EasterEgg).WithMany(p => p.PlayerSolves);
            });
        }
    }
}
