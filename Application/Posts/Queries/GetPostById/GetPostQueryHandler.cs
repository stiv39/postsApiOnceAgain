using Application.Dtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Repositories;


namespace Application.Posts.Queries.GetPostById;
internal sealed class GetPostQueryHandler : IQueryHandler<GetPostByIdQuery, PostResponse>
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;

    public GetPostQueryHandler(IPostRepository postRepository, IMapper mapper) 
    { 
        _postRepository = postRepository; 
        _mapper= mapper;
    }

    public async Task<PostResponse> Handle(
        GetPostByIdQuery request,
        CancellationToken cancellationToken)
    {

        var post = await _postRepository.GetById(request.PostId);
        
        if (post is null)
        {
          //  throw new PostNotFoundException(request.PostId);
        }

        var mapped = _mapper.Map<PostDto>(post);   

        return new PostResponse(mapped);
    }
}
