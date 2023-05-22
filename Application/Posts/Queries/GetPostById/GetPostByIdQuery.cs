using Application.Interfaces;

namespace Application.Posts.Queries.GetPostById;
public sealed record GetPostByIdQuery(Guid PostId) : IQuery<PostResponse>;
