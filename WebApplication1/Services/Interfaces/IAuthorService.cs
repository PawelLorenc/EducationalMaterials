namespace Api.Services.Interfaces
{
    public interface IAuthorService
    {
        public Task<List<Author>> GetAll();
    }
}
