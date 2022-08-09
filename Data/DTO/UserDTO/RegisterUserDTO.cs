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


//public int Id { get; set; }
//public string UserName { get; set; }
//public string Password { get; set; }
//[EmailAddress]
//public string Email { get; set; }

//public Role Role { get; set; }
//public int RoleId { get; set; }
