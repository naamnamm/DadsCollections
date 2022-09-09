CREATE PROCEDURE [dbo].[spOrders_Insert]
	@customerId int,
	@status nvarchar(20),
	@totalCost money,
	@Id int output
AS
begin
	set nocount on;

	insert into dbo.Orders(CustomerId, [Status], TotalCost)
	values (@customerId, @status, @totalCost)

	set @Id = SCOPE_IDENTITY()
end

--https://courses.iamtimcorey.com/courses/1159420/lectures/24910699