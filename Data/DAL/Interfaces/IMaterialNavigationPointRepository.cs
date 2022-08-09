namespace Data.DAL.Interfaces
{
    public interface IMaterialNavigationPointRepository
    {
        public Task<List<MaterialNavigationPoint>> GetAll();
        public void Delete(MaterialNavigationPoint entity);
        public Task Save();
        public Task<MaterialNavigationPoint> GetById(int id);
        public void Create(MaterialNavigationPoint entity);

        public void Update(MaterialNavigationPoint entity);
        Task<IEnumerable<MaterialNavigationPoint>> GetByAuthorIdWithMinAverageReview(int authorId, double v);
        Task<IEnumerable<MaterialNavigationPoint>> GetByMaterialTypeId(int materialTypeId);
    }
}
