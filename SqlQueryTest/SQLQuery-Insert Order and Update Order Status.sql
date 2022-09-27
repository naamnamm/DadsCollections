--//test insert orders\\
--declare @customerId int;
--declare	@status nvarchar(20);
--declare	@totalCost money;
--declare	@orderProductIdList varchar(500);
--declare @createdDate datetime2(7);

--set @customerId = 1;
--set @status = 'open';
--set @totalCost = 50;
--set @orderProductIdList = '1'; 
--set @createdDate = GETDATE();

--begin
--insert into dbo.Orders(CustomerId, [Status], TotalCost, orderProductIdList, CreatedDate)
--	values (@customerId, @status, @totalCost, @orderProductIdList, @createdDate)
--end

------------------------------------------------------------------------------------------------------------
--//test insert orderProducts\\--
--declare @productId int;
--declare	@orderId int;

--set @productId = 1;
--set @orderId = 1015;

--begin
--	insert into dbo.OrderProducts(ProductId, OrderId)
--	values (@productId, @orderId)
--end

------------------------------------------------------------------------------------------------------------
--//test complete order query\\--
--declare @Id int;
--declare @Status nvarchar(20);

--set @Status = 'complete';
--set @Id = 1015;


--if (@Status = 'complete')
--	begin
--		set nocount on;
--		--update Orders.Status = complete
--		Update o SET o.Status = 'completed'
--		from dbo.Orders o
--		where Id = @Id;

--		--update Products.IsSold = true
--		UPDATE p SET p.IsSold = 1
--		FROM dbo.Products p
--		inner join dbo.OrderProducts op on op.ProductId = p.id
--		inner join dbo.Orders o on o.Id = op.OrderId
--		WHERE o.id = @Id

--		--for all complete orders, delete from OrderProducts
--		DELETE op
--		FROM dbo.OrderProducts op
--		WHERE op.OrderId = @Id
--	end



------------------------------------------------------------------------------------------------------------
--//test cancel order query\\--
--declare @Id int;
--declare @Status nvarchar(20);

--set @Status = 'cancel';
--set @Id = 3;

--if (@Status = 'cancel')
--	begin
--		set nocount on;
--		--update Orders.Status = complete
--		Update o SET o.Status = 'cancelled'
--		from dbo.Orders o
--		where Id = @Id;

--		--for all complete orders, delete from OrderProducts
--		DELETE op
--		FROM dbo.OrderProducts op
--		WHERE op.OrderId = @Id
--	end

------------------------------------------------------------------------------------------------------------







