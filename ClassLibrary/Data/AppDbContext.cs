using Microsoft.EntityFrameworkCore;
using ClassLibrary.Models;


namespace ClassLibrary.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ShapeRecord> ShapeRecords { get; set; }
        public DbSet<CalculationRecord> CalculationRecords { get; set; }
        public DbSet<GameRecord> GameRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ShapeRecord>().HasKey(sr => sr.Id);
            modelBuilder.Entity<ShapeRecord>().Property(sr => sr.ShapeName).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<ShapeRecord>().Property(sr => sr.Parameters).HasMaxLength(500);
            modelBuilder.Entity<ShapeRecord>().Property(sr => sr.Area).IsRequired();
            modelBuilder.Entity<ShapeRecord>().Property(sr => sr.Perimeter).IsRequired();
            modelBuilder.Entity<ShapeRecord>().Property(sr => sr.CalculationDate).IsRequired();
            modelBuilder.Entity<ShapeRecord>().HasQueryFilter(sr => !sr.IsDeleted); // Soft delete


            modelBuilder.Entity<CalculationRecord>().HasKey(cr => cr.Id);
            modelBuilder.Entity<CalculationRecord>().Property(cr => cr.Operation).IsRequired().HasMaxLength(10);
            modelBuilder.Entity<CalculationRecord>().Property(cr => cr.Result).IsRequired();
            modelBuilder.Entity<CalculationRecord>().Property(cr => cr.Date).IsRequired();
            modelBuilder.Entity<CalculationRecord>().HasQueryFilter(cr => !cr.IsDeleted); // Soft delete


            modelBuilder.Entity<GameRecord>().HasKey(gr => gr.Id);
            modelBuilder.Entity<GameRecord>().Property(gr => gr.PlayerMove).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<GameRecord>().Property(gr => gr.ComputerMove).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<GameRecord>().Property(gr => gr.Result).IsRequired().HasMaxLength(10);
            modelBuilder.Entity<GameRecord>().Property(gr => gr.GameDate).IsRequired();
            modelBuilder.Entity<GameRecord>().Property(gr => gr.UserWinRate).IsRequired();
            modelBuilder.Entity<GameRecord>().Property(gr => gr.ComputerWinRate).IsRequired();


            DataSeeder.Seed(modelBuilder);
        }
    }
}

