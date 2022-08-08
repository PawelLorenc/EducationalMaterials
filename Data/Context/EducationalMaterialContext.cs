namespace Data.Context
{
    public class EducationalMaterialContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<MaterialNavigationPoint> MaterialNavigationPoints { get; set; }
        public DbSet<MaterialType> MaterialTypes { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }

        public EducationalMaterialContext(DbContextOptions<EducationalMaterialContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MaterialNavigationPoint>(m =>
            {
                m.HasOne(m => m.Author)
                .WithMany(a => a.Materials)
                .HasForeignKey(m => m.AuthorId);
                m.HasOne(m => m.Material)
                .WithOne(mt => mt.MaterianNavigationPoint)
                .HasForeignKey<MaterialNavigationPoint>(m => m.MaterialTypeId);
                m.HasMany(m => m.Reviews)
                .WithOne(r => r.Material)
                .HasForeignKey(r => r.MaterialNAvigationPointId);
                m.Property(x => x.Title)
                .HasColumnType("varchar(200)")
                .IsRequired();
                m.Property(x => x.Description)
                .HasColumnType("varchar(200)")
                .IsRequired();
                m.Property(x => x.Location)
                .HasColumnType("varchar(200)")
                .IsRequired();
            });
            builder.Entity<Author>(a =>
            {
                a.HasMany(a => a.Materials)
                .WithOne(m => m.Author)
                .HasForeignKey(m => m.MaterialTypeId);
                a.Property(x => x.Name)
                .HasColumnType("varchar(200)")
                .IsRequired();
                a.Property(x => x.Description)
                .HasColumnType("varchar(200)")
                .IsRequired();
            });
            builder.Entity<MaterialType>(m =>
            {
                m.HasOne(m => m.MaterianNavigationPoint)
                .WithOne(x => x.Material)
                .HasForeignKey<MaterialType>(m => m.MaterialNavigationPointId);
                m.Property(m => m.Name)
                .HasColumnType("varchar(200)")
                .IsRequired();
                m.Property(x => x.Definition)
                .HasColumnType("varchar(200)")
                .IsRequired();
            });
            builder.Entity<Review>(m =>
            {
                m.HasOne(a => a.Material)
                .WithMany(x => x.Reviews)
                .HasForeignKey(a => a.MaterialNAvigationPointId);
                m.Property(x => x.TextReview)
                .HasColumnType("varchar(200)")
                .IsRequired();
                m.Property(x => x.PointReview)
                .IsRequired();
            });
        }

    }
}
