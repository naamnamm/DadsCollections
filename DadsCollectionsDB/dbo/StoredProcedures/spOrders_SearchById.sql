CREATE PROCEDURE [dbo].[spOrders_SearchById]
	@Id int
AS

begin
	set nocount on;

	select [o].[Id], [o].[CustomerId], [o].[CreatedDate], [o].[Status], [o].[TotalCost], [o].[orderProductIdList], 
		[c].[FirstName], [c].[LastName], [c].[Email], [op].[ProductId], 
		[p].[Title] as ProductTitle , [p].[Description] as ProductDescription, [p].[Price], [p].[Quantity], [p].[ImgName], [p].[IsSold]
	from dbo.Orders o

	inner join dbo.Customers c on c.Id = o.CustomerID 
	inner join dbo.OrderProducts op on o.id = op.OrderId
	inner join dbo.Products p on p.id = op.ProductId

	where o.Id = @Id;

end
