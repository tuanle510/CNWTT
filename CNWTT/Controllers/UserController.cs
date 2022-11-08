using CNWTTBL.Entities;
using CNWTTBL.Interfaces.Repositories;
using CNWTTBL.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CNWTT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : HUSTBaseController<Post>
    {
        public UserController(IBaseService<Post> baseService, IBaseRepo<Post> baseRepo) : base(baseService, baseRepo)
        {
        }
    }
}
