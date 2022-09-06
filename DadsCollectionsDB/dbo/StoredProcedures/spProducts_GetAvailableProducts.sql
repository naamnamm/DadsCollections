CREATE PROCEDURE [dbo].[spProducts_GetAvailableProducts]

AS

begin
	set nocount on;

	select p.*, op.*
	from dbo.Products p
	inner join dbo.OrderProducts op on p.id != op.ProductId

	-- if product is not in the OrderProducts table 

end


--not all products are available if some product is ordered, those should not be available.


-- Solution 1
--Scenario 1: if customer place an order on one particular product -- do I treat it as unavailable? Yes!!
----Display all products that are not ordered and sold.

--3 scenarios possible
----- ordered = true / sold = false
----- ordered = true / sold = true
----- ordered = false / sold = false

-- Solution 2
--* It's better not to include IsOrdered in the Products table instead ?
--* need to join Products + OrderProducts Tables
-- if implementing this
---- need to check if OrderProducts has this product ID
---- if yes, this product is not available.


--how do we determine if orders 