using Application.Dtos;
using Application.Interfaces;
using Application.Posts.Commands.UpdatePost;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Repositories;


namespace Application.Posts.Commands.DeletePost
{
    internal sealed class DeletePostCommandHandler: ICommandHandler<DeletePostCommand, bool>
    {
        private readonly IPostRepository _PostRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeletePostCommandHandler(IPostRepository PostRepository, IUnitOfWork unitOfWork)
        {
            _PostRepository = PostRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var postFromDb = await _PostRepository.GetById(request.id);

            if (postFromDb is null)
            {
                return false;
            }

            _PostRepository.Delete(postFromDb);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
