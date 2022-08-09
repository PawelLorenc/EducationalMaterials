namespace Data.Context.Seeder
{
    public class MaterialSeeder
    {
        private readonly EducationalMaterialContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public MaterialSeeder(EducationalMaterialContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }
        public void Seed()
        {
            if (_context.Database.CanConnect())
            {

                if (!_context.MaterialNavigationPoints.Any())
                {
                    var materials = GetMaterials();
                    _context.MaterialNavigationPoints.AddRange(materials);
                    _context.SaveChanges();
                }
                if (!_context.Roles.Any())
                {
                    var roles = GetRoles();
                    _context.Roles.AddRange(roles);
                    _context.SaveChanges();
                }
                if (!_context.Users.Any())
                {
                    var admin = new User
                    {
                        Email = "admin@admin.pl",
                        Role = _context.Roles.First(r => r.Name.Equals("Admin")),
                        UserName = "Admin"
                    };
                    admin.Password = _passwordHasher.HashPassword(admin, "123456");
                    _context.Users.Add(admin);
                    _context.SaveChanges();
                }
            }
        }
        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "User"
                },
                new Role()
                {
                    Name = "Admin"
                }
            };
            return roles;
        }

        private IEnumerable<MaterialNavigationPoint> GetMaterials()
        {
            var materials = new List<MaterialNavigationPoint>();

            var material = new MaterialNavigationPoint()
            {
                Title = "Object Orientated programming",
                Description = "Introduction to object oriantated programming",
                Location = "CD",
            };

            var author = new Author()
            {
                Name = "Pawel Lorenc",
                Description = "Tall, blue eyed, handsome",
                MaterialCounter = 1
            };

            var materialType = new MaterialType()
            {
                Name = "Video Tutorial",
                Definition = "video tutorial that shows step by step solution",
            };
            var review = new Review()
            {
                TextReview = "Awesome resource",
                PointReview = 9
            };
            material.Author = author;
            material.MaterialType = materialType;
            material.Reviews.Add(review);
            materials.Add(material);

            var material2 = new MaterialNavigationPoint()
            {
                Title = "Solid Principles",
                Description = "Introduction to solid principles by Uncle Bob",
                Location = "Google drive",
            };

            var author2 = new Author()
            {
                Name = "Uncle Bob",
                Description = "Computer programmer with 20 years of experience",
                MaterialCounter = 1
            };

            var materialType2 = new MaterialType()
            {
                Name = "Video tutorial with homework",
                Definition = "video tutorial",
            };
            var review2 = new Review()
            {
                TextReview = "Average",
                PointReview = 5
            };

            material2.Author = author2;
            material2.MaterialType = materialType2;
            material2.Reviews.Add(review2);
            materials.Add(material2);

            return materials;
        }

    }
}
