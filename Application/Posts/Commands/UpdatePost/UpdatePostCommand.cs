using Application.Dtos;
using Application.Interfaces;

namespace Application.Posts.Commands.UpdatePost;

public sealed record UpdatePostCommand(Guid id, PostDto postDto) : ICommand<PostDto>;
