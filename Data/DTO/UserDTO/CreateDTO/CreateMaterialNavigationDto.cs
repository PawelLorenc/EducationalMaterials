namespace Data.DTO.UserDTO.CreateDTO
{
    public class CreateMaterialNavigationDto
    {
        [Required]
        [MaxLength(5)]
        public string Title { get; set; }
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        [Required]
        [MaxLength(100)]
        public string Location { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public int MaterialTypeId { get; set; }
    }
}
