using DadsCollectionsLibrary.DBAccess;
using DadsCollectionsLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DadsCollectionsLibrary.Data
{
    public class SqlData
    {
        private readonly ISqlDataAccess _db;
        private const string connectionStringName = "SqlDB";
        public SqlData(ISqlDataAccess db)
        {
            _db = db;
        }

        public List<ProductModel> GetProducts()
        {
            return _db.LoadData<ProductModel, dynamic>("dbo.spProducts_GetAll", new {}, connectionStringName, true);
        }
    }
}
