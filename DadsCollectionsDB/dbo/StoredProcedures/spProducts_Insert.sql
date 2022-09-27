CREATE PROCEDURE [dbo].[spProducts_Insert]
	@title nvarchar(100),
	@description nvarchar(2000),
	@price money,
	@quantity int,
	@productTypeId int,
	@imgName nvarchar(50)
AS
begin

	set nocount on;

	insert into dbo.Products(Title, [Description], Price, Quantity, ProductTypeId, ImgName)
	values (@title, @description, @price, @quantity, @productTypeId, @imgName)

	--returned the inserted record (orderId)
	SELECT SCOPE_IDENTITY()

end
