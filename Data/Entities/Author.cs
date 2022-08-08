namespace Data.Entities
{
    public record Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<MaterialNavigationPoint> Materials { get; set; }  = new List<MaterialNavigationPoint>();

        public int MaterialCounter { get; set; }
    }
}