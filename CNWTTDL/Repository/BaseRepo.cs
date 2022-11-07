using CNWTTBL.Interfaces.Repositories;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNWTTDL.Repository
{
    public class BaseRepo<T> : IBaseRepo<T>
    {
        /// <summary>
        /// Xử lí kết nối với database 
        /// </summary>
        IConfiguration _configuration;
        readonly string _connectionString = string.Empty;
        protected MySqlConnection _sqlConnection;
        string _tableName;
        public BaseRepo(IConfiguration configuration)
        {
            _configuration = configuration;
            // Khai báo thông tin database:
            _connectionString = _configuration.GetConnectionString("LTTUAN");
            // Khỏi tạo kết nối đến database --> sử dụng mySqlConnector
            _sqlConnection = new MySqlConnection(_connectionString);
            _tableName = typeof(T).Name;
        }
        public List<T> Get()
        {
            // Thực hiện khai báo câu lệnh truy vấn SQL:
            var sqlCommand = $"SELECT * FROM {_tableName} ORDER BY CreatedDate DESC";

            // Thực hiện câu truy vấn:
            var entities = _sqlConnection.Query<T>(sqlCommand);

            // Trả về dữ liệu dạng List:
            return entities.ToList();
        }

        public T GetById(Guid entityId)
        {
            // Thực hiện khai báo câu lệnh truy vấn SQL:
            var sqlQuery = $"SELECT * FROM {_tableName} WHERE {_tableName}Id = @entityId";
            var parameters = new DynamicParameters();
            parameters.Add("@entityId", entityId);

            // Thực hiện câu truy vấn:
            var entities = _sqlConnection.QueryFirstOrDefault<T>(sqlQuery, param: parameters);

            // Trả về dữ liệu dạng List:
            return entities;
        }

        public int Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public int Update(Guid entityId, T entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid entityId)
        {
            // Khỏi tạo câu truy vấn:
            var sqlQuery = $"DELETE FROM {_tableName} WHERE {_tableName}Id = @entityId";
            var parameters = new DynamicParameters();
            parameters.Add("@entityId", entityId);
            // Thực hiện câu truy vấn: 
            var res = _sqlConnection.Execute(sqlQuery, param: parameters);
            return res;
        }

    }
}
