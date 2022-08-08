namespace Data.Entities
{
    public record Material
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Definition { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}