using Domain.Entities;

namespace Domain.Repositories
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAll();

        Task<Post?> GetById(Guid id);

        void Add(Post entity);

        void Update(Post entity);

        void Delete(Post entity);
    }
}
