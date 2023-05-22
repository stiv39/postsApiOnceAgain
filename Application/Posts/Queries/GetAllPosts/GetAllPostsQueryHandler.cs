using Application.Dtos;
using Application.Interfaces;
using Application.Posts.Queries.GetPostById;
using AutoMapper;
using Domain.Repositories;

namespace Application.Posts.Queries.GetAllPosts
{
    internal sealed class GetAllPostsQueryHandler : IQueryHandler<GetAllPostsQuery, PostsResponse>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetAllPostsQueryHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<PostsResponse> Handle(
            GetAllPostsQuery request,
            CancellationToken cancellationToken)
        {

            var posts = await _postRepository.GetAll();

            var mapped = posts.Select(post => _mapper.Map<PostDto>(post));

            return new PostsResponse(mapped);
        }
    }
}
