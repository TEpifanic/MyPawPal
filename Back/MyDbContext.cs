using Microsoft.EntityFrameworkCore;

namespace MyPawPal
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
            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.ToTable("User_Info");

                entity.HasKey(e => e.User_Id);

                entity.Property(e => e.User_Id)
                    .HasColumnName("User_Id")
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Email)
                    .HasColumnName("Email")
                    .HasMaxLength(50)
                    .IsRequired();

                entity.Property(e => e.First_Name)
                    .HasColumnName("First_Name")
                    .HasMaxLength(50)
                    .IsRequired();

                entity.Property(e => e.Last_Name)
                    .HasColumnName("Last_Name")
                    .HasMaxLength(50)
                    .IsRequired();

                entity.Property(e => e.Age)
                    .HasColumnName("Age");

                entity.Property(e => e.Password_Hash)
                    .HasColumnName("Password_Hash")
                    .HasMaxLength(150)
                    .IsRequired();
            });

            // Configuration de la table Dog_Info
            modelBuilder.Entity<DogInfo>(entity =>
            {
                entity.ToTable("Dog_Info");

                entity.HasKey(e => e.Dog_Id);

                entity.Property(e => e.Dog_Id)
                    .HasColumnName("Dog_Id")
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
            });
        }
    }
}
