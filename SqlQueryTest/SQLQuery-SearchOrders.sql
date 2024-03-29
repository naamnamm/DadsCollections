﻿


--select o.*, c.*, op.*, p.*
--from dbo.Orders o
--inner join dbo.Customers c on c.Id = o.CustomerID 
--inner join dbo.OrderProducts op on o.id = op.OrderId
--inner join dbo.Products p on p.id = op.ProductId


select [o].[Id], [o].[CustomerId], [o].[CreatedDate], [o].[Status], [o].[TotalCost], [o].[orderProductIdList], 
		[c].[FirstName], [c].[LastName], [c].[Email], [op].[ProductId], 
		[p].[Title], [p].[Description], [p].[Price], [p].[Quantity], [p].[IsSold]
	from dbo.Orders o
	inner join dbo.Customers c on c.Id = o.CustomerID 
	inner join dbo.OrderProducts op on o.id = op.OrderId
	inner join dbo.Products p on p.id = op.ProductId
