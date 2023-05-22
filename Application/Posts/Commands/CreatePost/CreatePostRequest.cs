using Application.Dtos;

namespace Application.Posts.Commands.CreatePost
{
    public sealed record CreatePostRequest(CreatePostDto postDto);
}
