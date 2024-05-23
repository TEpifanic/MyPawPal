using Microsoft.EntityFrameworkCore;

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
                  .WithOne()
                  .HasForeignKey(d => d.UserId);
        });

        // Configuration de la table Dog_Info
        modelBuilder.Entity<DogInfo>(entity =>
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
        });
    }

}