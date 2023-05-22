using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly DataContext _dataContext;

        public PostRepository(DataContext dataContext) =>
            _dataContext = dataContext;

        public async Task<IEnumerable<Post>> GetAll()
        {
            return await _dataContext.Posts.ToListAsync();
        }

        public async Task<Post?> GetById(Guid id)
        {
            return await _dataContext.Posts.FindAsync(id);
        }

        public void Add(Post entity)
        {
            _dataContext.Posts.Add(entity);
        }

        public void Update(Post entity)
        {
            _dataContext.Posts.Update(entity);
        }

        public void Delete(Post entity)
        {
            _dataContext.Posts.Remove(entity);
        }
    }

}
