CREATE PROCEDURE [dbo].[spOrders_UpdateStatus]
	@Id int,
	@Status nvarchar(20)
AS

if (@Status = 'complete')
	begin
		set nocount on;
		--update Orders.Status = complete
		Update o SET o.Status = 'completed'
		from dbo.Orders o
		where Id = @Id;

		--update Products.IsSold = true
		UPDATE p SET p.IsSold = 1
		FROM dbo.Products p
		inner join dbo.OrderProducts op on op.ProductId = p.id
		inner join dbo.Orders o on o.Id = op.OrderId
		WHERE o.id = @Id

		--for all complete orders, delete from OrderProducts
		DELETE op
		FROM dbo.OrderProducts op
		WHERE op.OrderId = @Id
	end

if (@Status = 'cancel')
	begin
		set nocount on;
		--update Orders.Status = complete
		Update o SET o.Status = 'cancelled'
		from dbo.Orders o
		where Id = @Id;

		--for all complete orders, delete from OrderProducts
		DELETE op
		FROM dbo.OrderProducts op
		WHERE op.OrderId = @Id
	end
