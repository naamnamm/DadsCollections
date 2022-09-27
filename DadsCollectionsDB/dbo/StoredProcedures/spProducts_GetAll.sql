CREATE PROCEDURE [dbo].[spProducts_GetAll]

AS
begin
	set nocount on;

	select p.*
	from dbo.Products p

end
