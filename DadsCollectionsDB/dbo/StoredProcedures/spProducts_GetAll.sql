CREATE PROCEDURE [dbo].[spProducts_GetAll]

AS

begin
	set nocount on;

	select [Id], [Title], [Description], [Price], [Quantity], [ProductTypeId], [ImgName] 
	from dbo.Products
end


--Scenario 1: if customer place an order on this one product -- do I treat it as unavailable? Yes!!
----Display all products that are not ordered or sold
----- ordered = true / sold = false
----- ordered = true / sold = true
