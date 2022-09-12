declare @firstName NVARCHAR(50);
declare @lastName NVARCHAR(50);
declare @email NVARCHAR(50);

set @firstName = 'Faith';
set @lastName = 'Jones';
set @email = 'faith.jones@gmail.com';


insert into dbo.Customers(FirstName, LastName, Email)
values (@firstName, @lastName, @email)

select SCOPE_IDENTITY()








