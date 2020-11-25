using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.DataModel;
using dotnet5sample.Shared;
using System.Linq;

namespace Server.Controllers
{
    [Route("api/post")]
    public class PostController : Controller
    {

        private readonly MyDb context;

        public PostController(MyDb context)
        {
            this.context = context;
        }

        [HttpGet("count")]
        public ActionResult<long> Count()
        {
            var total = context.Posts.Count();
            return Ok(total);
        }

        [HttpGet("part/{skip}/{take}")]
        public ActionResult<PostDto[]> Part(int skip, int take)
        {
            var posts = context.Posts.Skip(skip).Take(take).ToList().Select(o => new PostDto
            {
                Id = o.Id,
                Title = o.Title,
                Body = o.Body,
                Tags = o.Tags.Select(t => new TagPostDto
                {
                    Id = t.Id,
                    Name = t.Name
                }).ToArray()
            }).ToArray();
            return Ok(posts);
        }

        [HttpGet("all")]
        public ActionResult<PostDto[]> All()
        {
            var posts = context.Posts.ToList().Select(o => new PostDto
            {
                Id = o.Id,
                Title = o.Title,
                Body = o.Body,
                Tags = o.Tags.Select(t => new TagPostDto
                {
                    Id = t.Id,
                    Name = t.Name
                }).ToArray()
            }).ToArray();
            return Ok(posts);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PostDto>> Get(int id)
        {
            var post = await context.Posts.FindAsync(id);
            if (post is null)
                return NotFound();

            return Ok(new PostDto
            {
                Id = post.Id,
                Title = post.Title,
                Body = post.Body,
                Tags = post.Tags.Select(t => new TagPostDto
                {
                    Id = t.Id,
                    Name = t.Name
                }).ToArray()
            });
        }

        [HttpPut]
        public async Task<IActionResult> Update(PostDto dto)
        {
            var post = await context.Posts.FindAsync(dto.Id);

            if (post is not null)
            {
                post.Title = dto.Title;
                post.Body = dto.Body;
                post.Tags = dto.Tags.Select(o => new Tag
                {
                    Id = o.Id,
                    Name = o.Name
                }).ToList();

                await context.SaveChangesAsync();

                return NoContent();

            }
            else
            {
                return NotFound("Post non trovato");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(PostDto dto)
        {

            var post = new Post();
            var lastId = context.Posts.Max(o => o.Id);
            post.Id = lastId++;
            post.Title = dto.Title;
            post.Body = dto.Body;
            post.Tags = dto.Tags.Select(o => new Tag
            {
                Id = o.Id,
                Name = o.Name
            }).ToList();

            context.Add(post);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var post = await context.Posts.FindAsync(id);
            if (post is not null)
            {
                context.Remove(post);
                await context.SaveChangesAsync();

                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}