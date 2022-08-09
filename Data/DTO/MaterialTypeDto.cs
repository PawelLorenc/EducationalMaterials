namespace Data.DTO.UserDTO
{
    public class MaterialTypeDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Definition { get; set; }
    }
}
