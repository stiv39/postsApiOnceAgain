using Application.Dtos;
using Application.Interfaces;

namespace Application.Posts.Commands.CreatePost;

public sealed record CreatePostCommand(CreatePostDto postDto) : ICommand<Guid>;