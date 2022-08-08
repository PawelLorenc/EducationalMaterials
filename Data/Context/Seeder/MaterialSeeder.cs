﻿namespace Data.Context.Seeder
{
    public class MaterialSeeder
    {
        private readonly EducationalMaterialContext _context;

        public MaterialSeeder(EducationalMaterialContext context)
        {
            _context = context;
        }
        public void Seed()
        {
            if (_context.Database.CanConnect())
            {
                if (!_context.MaterialNavigationPoints.Any())
                {
                    var materials = GetMaterials();
                    _context.MaterialNavigationPoints.AddRange(materials);
                }
            }
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
            material.Material = materialType;
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
            material2.Material = materialType2;
            material2.Reviews.Add(review2);
            materials.Add(material2);

            return materials;
        }

    }
}
