using CNWTTBL.Entities;
using CNWTTBL.Interfaces.Repositories;
using CNWTTBL.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;


namespace CNWTT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : HUSTBaseController<Post>
    {
        public PostController(IBaseService<Post> baseService, IBaseRepo<Post> baseRepo) : base(baseService, baseRepo)
        {
        }
    }
}
