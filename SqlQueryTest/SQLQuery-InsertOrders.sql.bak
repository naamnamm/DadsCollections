--1. create order and orderProducts
declare @createdDate datetime2(7);
declare @orderProductIdList varchar(500);

set @createdDate = GETDATE();
set @orderProductIdList = '2,3';

insert into dbo.Orders  (CustomerID, CreatedDate, [Status], TotalCost, orderProductIdList)
values (2, @createdDate, 'open', 2500, @orderProductIdList)

insert into dbo.OrderProducts (ProductId, OrderId)
values (2, 1013)

insert into dbo.OrderProducts (ProductId, OrderId)
values (3, 1013)




--2.
DELETE FROM dbo.Orders WHERE id = 1012;



--3. inner join to search for orders
select o.*, c.*, op.*, p.*
from dbo.orders o
inner join dbo.customers c on c.id = o.customerid 
inner join dbo.orderproducts op on o.id = op.orderid
inner join dbo.products p on p.id = op.productid

--3.1 edited version
select [o].[Id], [o].[CustomerId], [o].[CreatedDate], [o].[Status], [o].[TotalCost], [o].[orderProductIdList], 
		[c].[FirstName], [c].[LastName], [c].[Email], 
		[p].[Id], [p].[Title], [p].[Description], [p].[Price], [p].[Quantity], [p].[IsSold]
	from dbo.Orders o
	inner join dbo.Customers c on c.Id = o.CustomerID 
	inner join dbo.OrderProducts op on o.id = op.OrderId
	inner join dbo.Products p on p.id = op.ProductId

	where c.Email = 'faith.jones@gmail.com'