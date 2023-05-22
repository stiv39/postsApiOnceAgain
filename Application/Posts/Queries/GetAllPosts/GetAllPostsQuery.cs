using Application.Interfaces;

namespace Application.Posts.Queries.GetAllPosts;
public sealed record GetAllPostsQuery() : IQuery<PostsResponse>;
