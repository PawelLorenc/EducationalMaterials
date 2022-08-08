namespace Data.Entities
{
    public record MaterialType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Definition { get; set; }

        public int MaterialNavigationPointId { get; set; }
        public MaterialNavigationPoint MaterianNavigationPoint { get; set; }

        
    }
}