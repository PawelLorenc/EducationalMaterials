namespace Api.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepo;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository authorRepo, IMapper mapper)
        {
            _authorRepo = authorRepo;
            _mapper = mapper;
        }

        public async Task<List<Author>> GetAll()
        {
            var authorList = await _authorRepo.GetAll();
            var authorListDto = _mapper.Map<List<Author>>(authorList);
            return authorListDto;
        }
    }
}
