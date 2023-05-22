using Application.Dtos;
using Application.Posts.Commands.CreatePost;
using Application.Posts.Commands.DeletePost;
using Application.Posts.Commands.UpdatePost;
using Application.Posts.Queries.GetAllPosts;
using Application.Posts.Queries.GetPostById;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;


namespace Presentation.Controllers
{
    public class PostsController : ApiController
    {
        [HttpGet("{postId:guid}")]
        [ProducesResponseType(typeof(PostResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPostById(Guid postId, CancellationToken cancellationToken)
        {
            var query = new GetPostByIdQuery(postId);

            var post = await Sender.Send(query, cancellationToken);

            return Ok(post);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreatePost(
        [FromBody] CreatePostRequest request,
        CancellationToken cancellationToken)
        {          
            var postId = await Sender.Send(new CreatePostCommand(request.postDto), cancellationToken);

            return CreatedAtAction(nameof(GetPostById), new { postId }, postId);
        }

        [HttpGet]
        [ProducesResponseType(typeof(PostsResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPosts()
        {
            var posts = await Sender.Send(new GetAllPostsQuery());

            return Ok(posts);
        }

        [HttpPut]
        [ProducesResponseType(typeof(PostDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdatePost(UpdatePostRequest request, CancellationToken cancellationToken)
        {

           var result = await Sender.Send(new UpdatePostCommand(request.id, request.postDto));

            if (result is null) return BadRequest();

            return Ok(result);

        }

        [HttpDelete]
        public async Task<IActionResult> DeletePost(Guid id)
        {
            var result = await Sender.Send(new DeletePostCommand(id));
            return Ok();
        }
    }
}
