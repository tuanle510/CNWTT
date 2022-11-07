using CNWTTBL.Interfaces.Repositories;
using CNWTTBL.Interfaces.Services;
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

        public int InsertService(T entity)
        {
            throw new NotImplementedException();
        }

        public int UpdateService(Guid entityId, T entity)
        {
            throw new NotImplementedException();
        }
    }
}
