namespace Api.Services.Interfaces
{
    public interface IUserService
    {
        public void RegisterUser(RegisterUserDTO dto);

        public string? Login(LoginDto loginDto);
    }
}
