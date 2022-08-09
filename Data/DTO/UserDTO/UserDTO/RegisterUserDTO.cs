namespace Data.DTO.UserDTO
{
    public class RegisterUserDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public int RoleId { get; set; } = 1;

    }
}
