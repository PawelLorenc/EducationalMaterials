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
        public List<MaterialNavigationPoint> MaterianNavigationPoint { get; set; }
                
    }
}