using System.Security.Claims;

namespace Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository<User> _userRepo;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IConfiguration _config;

        public UserService(IUserRepository<User> userRepo, IPasswordHasher<User> passwordHasher, IConfiguration config)
        {
            _userRepo = userRepo;
            _passwordHasher = passwordHasher;
            _config = config;
        }

        public void RegisterUser(RegisterUserDTO dto)
        {
            var newUser = new User()
            {
                Email = dto.Email,
                UserName = dto.UserName,
                RoleId = dto.RoleId,
            };
            var hashedPassword = _passwordHasher.HashPassword(newUser, dto.Password);
            newUser.Password = hashedPassword;
            _userRepo.Add(newUser);
            _userRepo.Save();            
        }


        public string? Login(LoginDto loginDto)
        {
            User? user = _userRepo.GetByEmail(loginDto.Email);

            if (user != null)
            {
                var result = _passwordHasher.VerifyHashedPassword(user, user.Password, loginDto.Password);

                if (result != PasswordVerificationResult.Failed)
                {
                    return GenerateJwtToken(user);
                }
            }

            return null;
        }
        private string GenerateJwtToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Email , user.Email),
                new Claim(ClaimTypes.Role, user.Role.Name)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], claims, expires: DateTime.Now.AddMinutes(15), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
