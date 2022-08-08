namespace Data.Context.Seeder
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
                    var materials = GetMaterials;
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

            var MaterialType = new MaterialType()
            {
                Name = "Video Tutorial",
                Definition = "video tutorial 
is a video material that
focuses mostly on guiding
step - by - step in dedicated
topic",

            }
        }

    }
}
