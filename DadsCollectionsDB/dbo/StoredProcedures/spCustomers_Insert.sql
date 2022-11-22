CREATE PROCEDURE [dbo].[spCustomers_Insert]
	@firstName nvarchar(50),
	@lastName nvarchar(50),
	@email varchar(50)
AS
begin
	set nocount on;

	if not exists (select 1 from dbo.Customers where FirstName = @firstName AND LastName = @lastName)
	begin
		insert into dbo.Customers (FirstName, LastName, Email)
		values (@firstName, @lastName, @email)
	end

	--assumption
	--John doe jd@gmail.com
	--Susan doe jd@gmail.com is ok -- treat these two as different customers

	select top 1 [Id], [FirstName], [LastName], [Email] 
	from dbo.Customers
	where FirstName = @firstName AND LastName = @lastName

end
