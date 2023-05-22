using Application.Dtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Repositories;


namespace Application.Posts.Commands.UpdatePost
{
    internal sealed class UpdatePostCommandHandler : ICommandHandler<UpdatePostCommand, PostDto>
    {
        private readonly IPostRepository _PostRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePostCommandHandler(IPostRepository PostRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _PostRepository = PostRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PostDto?> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var postFromDb = await _PostRepository.GetById(request.id);

            if(postFromDb is null)
            {
                return null;
            }


            postFromDb.Author = request.postDto.Author;
            postFromDb.Title = request.postDto.Title;
            postFromDb.Body = request.postDto.Body;


            _PostRepository.Update(postFromDb);

            _unitOfWork.SaveChanges();

            var updatedPost = await _PostRepository.GetById(request.id);

            return _mapper.Map<PostDto>(updatedPost);
        }
    }
}
