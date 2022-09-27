CREATE PROCEDURE [dbo].[spProducts_Update]
	@Id int,
	@title nvarchar(100),
	@description nvarchar(2000),
	@price money,
	@quantity int,
	@productTypeId int,
	@imgName nvarchar(50)
AS

begin
	set nocount on;

	Update p
	Set Title = @title,
		[Description] = @description,
		Price = @price,
		Quantity = @quantity,
		ProductTypeId = @productTypeId,
		ImgName = @imgName
	from dbo.Products p

	where p.Id = @Id
end
