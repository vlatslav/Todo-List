namespace TodoList.DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public Task Add(TEntity model);
        public Task<IEnumerable<TEntity>> GetAll();
        public Task<TEntity> GetById(int modelid);
        public Task DeleteByIdAsync(int modelid);
        public void Update(TEntity model);
    }
}
