using CNWTTBL.Entities;
using CNWTTBL.Interfaces.Repositories;
using CNWTTBL.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CNWTT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : HUSTBaseController<User>
    {
        public UserController(IBaseService<User> baseService, IBaseRepo<User> baseRepo) : base(baseService, baseRepo)
        {
        }
    }
}
