using Application.Dtos;

namespace Application.Posts.Commands.UpdatePost;

public sealed record UpdatePostRequest(Guid id, PostDto postDto);
