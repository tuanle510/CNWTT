using CNWTTBL.Interfaces.Repositories;
using CNWTTBL.Interfaces.Services;
using MISA.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNWTTBL.Services
{
    public class BaseService<T> : IBaseService<T>
    {
        IBaseRepo<T> _baseRepo;
        protected List<String> ValidateErrorsMsg;
        string _tableName;
        public BaseService(IBaseRepo<T> baseRepo)
        {
            _baseRepo = baseRepo;
            ValidateErrorsMsg = new List<String>();
            _tableName = typeof(T).Name;
        }
        /// <summary>
        /// Kiểm tra dữ liệu khi insert
        /// </summary>
        /// <param name="entity">entity nhân viên để kiểm tra</param>
        /// <returns></returns>
        /// <exception cref="exception"></exception>
        /// CreatedBy: BDAnh(08/11/2022)
        public int InsertService(T entity)
        {
            //Thực hiện validate dữ liệu
            var isValid = Validate(entity) ;
            //Thực hiện thêm mới vào database:
            if(isValid == true)
            {
                var res = _baseRepo.Insert(entity);
                return res;
            }
            else
            {
                throw new HUSTValidateException("Dữ liệu đầu vào không hợp lệ");
            }
            
        }
        /// <summary>
        /// Kiểm tra dữ liệu khi insert
        /// </summary>
        /// <param name="entity">entity nhân viên để kiểm tra</param>
        /// <returns></returns>
        /// <exception cref="MISAValidateException"></exception>
        /// CreatedBy: BDAnh(10/05/2022)
        public int UpdateService(Guid id,T entity)
        {
            var isValid = Validate(entity);
            //Thực hiện thêm mới vào database:
            if (isValid == true)
            {
                var res = _baseRepo.Update(id, entity);
                return res;
            }
            else
            {
                throw new HUSTValidateException("Dữ liệu đầu vào không hợp lệ");
            }
        }

        /// <summary>
        /// Validate chung
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// CreatedBy: BDAnh(08/11/2022)
        protected virtual bool Validate(T entity)
        {

            return true;
        }
    }
}
