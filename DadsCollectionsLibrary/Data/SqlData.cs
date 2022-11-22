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
    public class SqlData : IDatabaseData
    {
        private readonly ISqlDataAccess _db;
        private const string connectionStringName = "SqlDB";

        public SqlData(ISqlDataAccess db)
        {
            _db = db;
        }

        public int CreateOrder(string firstName, string lastName, string email, decimal totalCost, List<int> orderProductIdList)
        {
            //1. load customer >> customerModel: {Id, FirstName, LastName, Email}
            CustomerModel customer = _db.LoadData<CustomerModel, dynamic>("dbo.spCustomers_Insert",
                                                                          new { firstName, lastName, email },
                                                                          connectionStringName,
                                                                          true).First();

            //2. save data to Orders >> OrderModel: {Id, CustomerId, CreatedDate, Status, TotalCost, orderProductIdList = {1,2,3}}
            OrderModel order = _db.LoadData<OrderModel, dynamic>("dbo.spOrders_Insert",
                                                                new { CustomerId = customer.Id, Status = "open", TotalCost = totalCost, orderProductIdList = string.Join(",", orderProductIdList) },
                                                                connectionStringName,
                                                                true).First();

            if (order is null)
            {
                return 0;
            }

            //3. for each order product save data to OrderProducts >> OrderProductModel: {Id, ProductId, OrderId}
            foreach (int orderProductId in orderProductIdList)
            {
                _db.SaveData("dbo.spOrderProducts_Insert", new { ProductId = orderProductId, OrderId = order.Id }, connectionStringName, true);
            }

            return order.Id; // which says this order ID has been created on front-end
        }

        public List<OrderFullModel> SearchOrders(string email) // search order from destop application
        {
            return _db.LoadData<OrderFullModel, dynamic>("dbo.spOrders_Search",
                                                                          new { email },
                                                                          connectionStringName,
                                                                          true);
        }

        public int UpdateOrderStatus(int orderId, string status) // update from destop application
        {
            _db.SaveData("dbo.spOrders_UpdateStatus", new { Id = orderId, status }, connectionStringName,
                                                                          true);

            return orderId;
        }

        public List<ProductModel> GetAvailableProducts()
        {
            return _db.LoadData<ProductModel, dynamic>("dbo.spProducts_GetAvailableProducts", new { }, connectionStringName, true);
        }

        public List<ProductModel> GetAllProducts()
        {
            return _db.LoadData<ProductModel, dynamic>("dbo.spProducts_GetAll", new { }, connectionStringName, true);
        }

        public List<ProductModel> SearchProduct(int productId)
        {
            return _db.LoadData<ProductModel, dynamic>("dbo.spProducts_Search", new { Id = productId }, connectionStringName, true);
        }

        public int CreateProducts(ProductModel Product)
        {
            ProductModel insertedProduct = _db.LoadData<ProductModel, dynamic>("dbo.spProducts_Insert",
                                                                          new { Product.Title, Product.Description, Product.Price, Product.Quantity, Product.ProductTypeId, Product.ImgName },
                                                                          connectionStringName,
                                                                          true).First();
            return insertedProduct.Id;
        }

        public int UpdateProductDetail(ProductModel Product)
        {
            //1. load Product that need to be updated

            ProductModel product = _db.LoadData<ProductModel, dynamic>("dbo.spProducts_Update",
                                                                          new { Product.Id, Product.Title, Product.Description, Product.Price, Product.Quantity, Product.ProductTypeId, Product.ImgName },
                                                                          connectionStringName,
                                                                          true).First();
            return product.Id;
        }

    }
}


//--1--//
//--method 1
//_db.SaveData("dbo.spOrder_Insert", new { CustomerId = customer.Id, Status = "open", TotalCost = 20 }, connectionStringName, true);
//--method 2
//DynamicParameters p = new DynamicParameters();
//p.Add("CustomerId", customer.Id);
//p.Add("Status", "open");
////--TODO-Later: need to update total cost (calculated from the front-end?)--//
//p.Add("TotalCost", 20);
//p.Add("Id", DbType.Int32, direction: ParameterDirection.Output);
////--TODO: need to create extra col for ListOfProductId > insert a List of Int
//_db.SaveData("dbo.spOrder_Insert", p, connectionStringName, true);
//int OrderID = p.Get<int>("Id");

//--2--//
// convert List<OrderProductModel> to List<int> to save it to 
// output listOfProductId = {1,2,3}
//should this be from the front end?
//foreach (OrderProductModel orderProduct in orderProducts)
//{
//    // convert List<OrderProductModel> to List<int>
//    // output listOfProductId = {1,2,3}
//    _orderProductList.Add(orderProduct.ProductId);
//}

//--3--//
//public int CreateOrder(string firstName, string lastName, string email, List<OrderProductModel> orderProducts, List<int> orderedProductList)
//foreach (OrderProductModel orderProduct in orderProducts)
//{

//    _db.SaveData("dbo.spOrderProducts_Insert", new { ProductId = orderProduct.ProductId, OrderId = order.Id }, connectionStringName, true);
//}

// _db.SaveData("dbo.spProducts_Insert", new { Product.Title, Product.Description, Product.Price, Product.Quantity, Product.ProductTypeId ,Product.ImgName }, connectionStringName,
//true);


//resources:
//https://stackoverflow.com/questions/27693885/add-multiple-items-for-one-orderid-in-mysql-database
//https://stackoverflow.com/questions/66461298/add-multiple-products-in-one-order-with-the-same-client-id