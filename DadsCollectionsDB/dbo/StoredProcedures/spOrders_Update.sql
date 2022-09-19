CREATE PROCEDURE [dbo].[spOrders_Update]
	@Id int,
	@Status nvarchar(20),
	@IsSold bit
AS

begin
	set nocount on;

	Update o SET o.Status = @Status
	from dbo.Orders o
	where Id = @Id;

	--need to look into this one
	UPDATE p SET p.IsSold = @IsSold 
	FROM dbo.Products 
	inner join dbo.OrderProducts op on p.id = op.ProductId
	inner join dbo.Orders o on o.Id = op.OrderId
	WHERE o.id = @Id

	DELETE op
	FROM dbo.OrderProducts op
	WHERE op.OrderId = @Id


end


--Update o SET o.Status = @Status
--	from dbo.Orders
--	where Id = @Id;


	--Update dbo.Orders
	--set [Status] = @Status
	--where Id = @Id;