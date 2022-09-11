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
            return _db.LoadData<ProductModel, dynamic>("dbo.spProducts_GetAvailableProducts", new { }, connectionStringName, true);
        }

        public int CreateOrder(string firstName, string lastName, string email, List<OrderProductModel> orderProducts)
        {
            //1. load customer >> customerModel: {Id, FirstName, LastName, Email}
            CustomerModel customer = _db.LoadData<CustomerModel, dynamic>("dbo.spCustomers_Insert", new { firstName, lastName, email }, connectionStringName, true).First();

            //2.1 save data to Orders >> OrderModel: {Id, CustomerId, CreatedDate, Status, TotalCost, ListOfProductId}
            DynamicParameters p = new DynamicParameters();
            p.Add("CustomerId", customer.Id);
            p.Add("Status", "open");
            //--TODO-Later: need to update total cost (calculated from the front-end?)--//
            p.Add("TotalCost", 20);
            p.Add("Id", DbType.Int32, direction: ParameterDirection.Output);
            //--TODO: need to create extra col for ListOfProductId > insert a List of Int
            _db.SaveData("dbo.spOrder_Insert", p, connectionStringName, true);

            int OrderID = p.Get<int>("Id");

            //2.2 for each order product save data to OrderProducts >> OrderProductModel: {Id, ProductId, OrderId}
            foreach (OrderProductModel orderProduct in orderProducts)
            {
                _db.SaveData("dbo.spOrderProducts_Insert", new { ProductId = orderProduct.ProductId, OrderId = OrderID }, connectionStringName, true);
            }

            return OrderID;
        }

        public int UpdateOrderStatus(int orderId) // update from destop application
        {
            //1. Completed order 

            //--OrderModel: {Id, CustomerId, CreatedDate, Status, TotalCost}
            //1.1 Order.Status = "complete" where OrderId == int orderId

            //--OrderProductModel: {Id, ProductId, OrderId}
            //1.2 update OrderProduct.

            //--ProductModel: {Id, Title, Description, Price, Quantity, ProductTypeId, ImgName, IsSold}
            //1.3.1 get OrderProducts where OrderId = int orderId >> get a List<OrderProducts> orderProducts
            //1.3.2 for each orderProduct in orderProducts
            //----- Product.IsSold = true where Product.Id == orderProduct.ProductId


            //2. Cancelled Order
        }
    }
}



//_db.SaveData("dbo.spOrder_Insert", new { CustomerId = customer.Id, Status = "open", TotalCost = 20 }, connectionStringName, true);


//resources:
//https://stackoverflow.com/questions/27693885/add-multiple-items-for-one-orderid-in-mysql-database