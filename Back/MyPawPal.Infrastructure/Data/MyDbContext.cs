using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyPawPal.Domain.Entities;

namespace MyPawPal.Infrastructure
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<DogInfo> DogInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuration de la table User_Info
            modelBuilder.Entity<UserInfo>(ConfigureUserInfo);
            modelBuilder.Entity<DogInfo>(ConfigureDogInfo);
        }

        private void ConfigureUserInfo(EntityTypeBuilder<UserInfo> entity)
        {
            entity.ToTable("User_Info");

            entity.HasKey(e => e.UserId);

            entity.Property(e => e.UserId)
                  .HasColumnName("UserId")
                  .IsRequired()
                  .ValueGeneratedOnAdd();

            entity.Property(e => e.Email)
                  .HasColumnName("Email")
                  .HasMaxLength(50)
                  .IsRequired();

            entity.Property(e => e.FirstName)
                  .HasColumnName("First_Name")
                  .HasMaxLength(50)
                  .IsRequired();

            entity.Property(e => e.LastName)
                  .HasColumnName("Last_Name")
                  .HasMaxLength(50)
                  .IsRequired();

            entity.Property(e => e.Age)
                  .HasColumnName("Age");

            // One user can have many dogs
            entity.HasMany(u => u.Dogs)
                  .WithOne(d => d.User)
                  .HasForeignKey(d => d.UserId);
        }

        private void ConfigureDogInfo(EntityTypeBuilder<DogInfo> entity)
        {
            entity.ToTable("Dog_Info");

            entity.HasKey(e => e.DogId);

            entity.Property(e => e.DogId)
                  .HasColumnName("DogId")
                  .IsRequired()
                  .ValueGeneratedOnAdd();

            entity.Property(e => e.Name)
                  .HasColumnName("Name")
                  .HasMaxLength(50)
                  .IsRequired();

            entity.Property(e => e.Age)
                  .HasColumnName("Age")
                  .IsRequired();

            entity.Property(e => e.Race)
                  .HasColumnName("Race")
                  .HasMaxLength(50)
                  .IsRequired();

            entity.Property(e => e.UserId)
                  .HasColumnName("UserId")
                  .IsRequired();
        }
    }
}
