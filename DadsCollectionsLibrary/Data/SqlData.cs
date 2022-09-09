using DadsCollectionsLibrary.DBAccess;
using DadsCollectionsLibrary.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
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

        public int CreateOrder(string firstName, string lastName, string email, List<OrderProductModel> orderProducts)
        {
            //1. load customer 
            //customerModel: {Id, FirstName, LastName, Email}
            CustomerModel customer = _db.LoadData<CustomerModel, dynamic> ("dbo.spCustomers_Insert", new { firstName, lastName, email}, connectionStringName, true).First();

            //2.1 save data to Orders
            //OrderModel: {Id, CustomerId, CreatedDate, Status, TotalCost}
            DynamicParameters p = new DynamicParameters();
            p.Add("CustomerId", customer.Id);
            p.Add("Status", "open");
            p.Add("TotalCost", 20);
            p.Add("Id", DbType.Int32, direction: ParameterDirection.Output);

            _db.SaveData("dbo.spOrder_Insert", p, connectionStringName, true);

            int OrderID = p.Get<int>("Id");

            //2.2 save data to OrderProducts
            //OrderProductModel: {Id, ProductId, OrderId}
            //for each order product - save data
            foreach (OrderProductModel orderProduct in orderProducts)
            {
                _db.SaveData("dbo.spOrderProducts_Insert", new { ProductId = orderProduct.ProductId, OrderId = OrderID }, connectionStringName, true);
            }

            return OrderID;
        }
    }
}



//_db.SaveData("dbo.spOrder_Insert", new { CustomerId = customer.Id, Status = "open", TotalCost = 20 }, connectionStringName, true);