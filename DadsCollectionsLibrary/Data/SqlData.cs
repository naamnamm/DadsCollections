﻿using DadsCollectionsLibrary.DBAccess;
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
        private decimal totalCost = 0;

        public SqlData(ISqlDataAccess db)
        {
            _db = db;
        }

        public List<ProductModel> GetProducts()
        {
            return _db.LoadData<ProductModel, dynamic>("dbo.spProducts_GetAvailableProducts", new { }, connectionStringName, true);
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
            

            //3. for each order product save data to OrderProducts >> OrderProductModel: {Id, ProductId, OrderId}
            foreach (int orderProductId in orderProductIdList)
            {
                _db.SaveData("dbo.spOrderProducts_Insert", new { ProductId = orderProductId, OrderId = order.Id }, connectionStringName, true);
            }

            return order.Id; // which says this order ID has been created on front-end
        }

        public void SearchOrder(string email) // search order from destop application
        {
            OrderModel order = _db.LoadData<OrderModel, dynamic>("dbo.spOrders_Get",
                                                                          new { email },
                                                                          connectionStringName,
                                                                          true).First();
            
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


//resources:
//https://stackoverflow.com/questions/27693885/add-multiple-items-for-one-orderid-in-mysql-database
//https://stackoverflow.com/questions/66461298/add-multiple-products-in-one-order-with-the-same-client-id