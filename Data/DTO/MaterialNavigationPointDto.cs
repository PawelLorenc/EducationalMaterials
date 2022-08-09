namespace Data.DTO
{
    public class MaterialNavigationPointDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Author { get; set; }
        public string MaterialType { get; set; }
        public List<string> Reviews { get; set; }
        public DateTime PublishingDate { get; set; }
    }
}
