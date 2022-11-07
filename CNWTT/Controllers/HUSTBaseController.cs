using CNWTTBL.Interfaces.Repositories;
using CNWTTBL.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Exceptions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CNWTT.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class HUSTBaseController<T> : ControllerBase
    {
        #region Fiels
        IBaseService<T> _baseService;
        IBaseRepo<T> _baseRepo;
        #endregion

        #region Contructtor
        public HUSTBaseController(IBaseService<T> baseService, IBaseRepo<T> baseRepo)
        {
            _baseService = baseService;
            _baseRepo = baseRepo;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Xử lí lấy tất cả dữ liệu
        /// </summary>
        /// <returns></returns>
        // GET: api/<MISABaseController>
        [HttpGet]
        public virtual IActionResult Get()
        {
            try
            {
                var entitties = _baseRepo.Get();
                return Ok(entitties);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        /// <summary>
        /// Xử lí lấy dữ liệu về theo Id
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        // GET api/<MISABaseController>/5
        [HttpGet("{entityId}")]
        public IActionResult Get(Guid entityId)
        {
            try
            {
                var entitties = _baseRepo.GetById(entityId);
                return Ok(entitties);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        /// <summary>
        /// Xử lí thêm mới dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        // POST api/<MISABaseController>
        [HttpPost]
        public IActionResult Post([FromBody] T entity)
        {
            try
            {
                var res = _baseService.InsertService(entity);
                return StatusCode(201, res);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        /// <summary>
        /// Xử lí sửa đối tượng 
        /// </summary>
        /// <param name="entityId"> Id của đôi tượng </param>
        /// <param name="entity"> Dữ liệu mới </param>
        /// <returns></returns>
        // PUT api/<MISABaseController>/5
        [HttpPut("{entityId}")]
        public virtual IActionResult Put(Guid entityId, [FromBody] T entity)
        {
            try
            {
                var res = _baseService.UpdateService(entityId, entity);
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        /// <summary>
        /// Xử lí xóa đối tượng theo Id
        /// </summary>
        /// <param name="entityId"> Id của đối tượng </param>
        /// <returns></returns>
        [HttpDelete("{entityId}")]
        public virtual IActionResult Delete(Guid entityId)
        {
            try
            {
                var res = _baseRepo.Delete(entityId);
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
        #endregion

        /// <summary>
        /// Xử lí lỗi Exception
        /// </summary>
        /// <param name="ex"></param>
        /// <returns> Thông tin lỗi Exception </returns>
        protected IActionResult HandleException(Exception ex)
        {
            var res = new
            {
                devMsg = ex.Message,
                userMsg = "Có lỗi xấy ra vui lòng liên hệ  để được hỗ trợ",
                errorCode = "001",
                data = ex.Data
            };
            if (ex is HUSTValidateException)
                return StatusCode(200, res);
            else
                return StatusCode(500, res); //Lỗi từ server trả về 500
        }
    }
}
