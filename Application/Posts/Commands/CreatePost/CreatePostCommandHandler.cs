using Application.Interfaces;
using Domain.Interfaces;
using Domain.Repositories;
using Domain.Entities;

namespace Application.Posts.Commands.CreatePost
{
    internal sealed class CreatePostCommandHandler : ICommandHandler<CreatePostCommand, Guid>
    {
        private readonly IPostRepository _PostRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePostCommandHandler(IPostRepository PostRepository, IUnitOfWork unitOfWork)
        {
            _PostRepository = PostRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var post = new Post { Id = Guid.NewGuid(), Author = request.postDto.Author, Title = request.postDto.Title, Body = request.postDto.Body };

            _PostRepository.Add(post);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return post.Id;
        }
    }
}
