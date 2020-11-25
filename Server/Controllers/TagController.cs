using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.DataModel;
using dotnet5sample.Shared;
using System.Linq;

namespace Server.Controllers
{
    [Route("api/tag")]
    public class TagController :Controller
    {
        private readonly MyDb context;

        public TagController(MyDb context)
        {
            this.context = context;
        }

        [HttpGet("all")]
        public ActionResult<TagPostDto> GetAll()
        {
            var tags = context.Tags.ToList().Select( o => new TagPostDto{
                Id=o.Id,
                Name=o.Name});

            return Ok(tags);
        }
    }
}