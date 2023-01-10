CREATE PROCEDURE [dbo].[spProducts_GetProductsByProductType]
	@productTypeTitle nvarchar(50)
AS
begin
	set nocount on;

	select [p].[Id], [p].Title, [p].[Description], [p].[Price], [p].[Quantity], 
		[p].[IsSold]
	from dbo.Products p

	inner join dbo.ProductTypes pt on pt.Id = p.ProductTypeId 

	where pt.Title = @productTypeTitle;

end
