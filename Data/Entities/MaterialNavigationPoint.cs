namespace Data.Entities
{
    public record MaterialNavigationPoint
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int MaterialTypeId { get; set; }
        public MaterialType MaterialType { get; set; }

        public List<Review> Reviews { get; set; } = new List<Review>();

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime PublishingDate { set; get; } = DateTime.Now;
    }
}
