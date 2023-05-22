using Application.Dtos;

namespace Application.Posts.Queries.GetAllPosts;

public sealed record PostsResponse(IEnumerable<PostDto> posts);