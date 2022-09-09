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
            return _db.LoadData<ProductModel, dynamic>("dbo.spProducts_GetAvailableProducts", new {}, connectionStringName, true);
        }

        public void CreateOrder(string firstName, string lastName, string email, int productId)
        {
            // info needed from the frontend
            //get customer info
            //get Id of the product ordered

            //load customer
            CustomerModel customer = _db.LoadData<CustomerModel, dynamic> ("dbo.spCustomers_Insert", new { firstName, lastName, email}, connectionStringName, true).First();



            //save order

        }
    }
}
