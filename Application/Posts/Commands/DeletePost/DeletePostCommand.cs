using Application.Interfaces;

namespace Application.Posts.Commands.DeletePost;

public sealed record DeletePostCommand(Guid id) : ICommand<bool>;

