CREATE PROCEDURE [dbo].[spOrders_SearchByEmail]
	@email varchar(50)
AS

begin
	set nocount on;

	select [o].[Id], [o].[CustomerId], [o].[CreatedDate], [o].[Status], [o].[TotalCost], [o].[orderProductIdList], 
		[c].[FirstName], [c].[LastName], [c].[Email] 
	from dbo.Orders o

	inner join dbo.Customers c on c.Id = o.CustomerID 

	where c.Email = @email;

end

