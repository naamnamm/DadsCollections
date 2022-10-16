CREATE PROCEDURE [dbo].[spProducts_Search]
	@Id int
AS

begin
	set nocount on

	select [Id], [Title], [Description], [Price], [Quantity], [ProductTypeId], [ImgName], [IsSold] 
	from dbo.Products p

	where p.Id = @Id;
end