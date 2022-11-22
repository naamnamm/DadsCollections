CREATE PROCEDURE [dbo].[spOrders_Insert]
	@customerId int,
	@status nvarchar(20),
	@totalCost money,
	@orderProductIdList varchar(500)
AS

declare @createdDate datetime2(7);
set @createdDate = GETDATE();

begin
	set nocount on;

	insert into dbo.Orders(CustomerId, [Status], TotalCost, orderProductIdList, CreatedDate)
	values (@customerId, @status, @totalCost, @orderProductIdList, @createdDate)

	--attempt 1
	--Expectation: should return the inserted record (orderId)
	--Actual output: return null --- why?
	----SELECT SCOPE_IDENTITY()
	--https://stackoverflow.com/questions/13237015/scope-identity-returns-null

	--attempt 2
	select o.*
	from dbo.Orders o 
	where Id = SCOPE_IDENTITY()

end

	--@Id int output
	--select [Id], [CustomerId], [CreatedDate], [Status], [TotalCost]
	--from dbo.Orders
	--where CustomerId = @customerId
	--set @Id = SCOPE_IDENTITY()

--https://courses.iamtimcorey.com/courses/1159420/lectures/24910699
--ref: scopeidentity https://stackoverflow.com/questions/7917695/sql-server-return-value-after-insert