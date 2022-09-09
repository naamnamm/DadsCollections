CREATE PROCEDURE [dbo].[spOrderProducts_Insert]
	@productId int,
	@orderId int
AS
begin
	set nocount on;

	insert into dbo.OrderProducts(ProductId, OrderId)
	values (@productId, @orderId)

end
