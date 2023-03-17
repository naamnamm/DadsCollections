/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

if not exists (Select * from dbo.ProductTypes)
begin
    Insert into dbo.ProductTypes (Title, Description)
    values ('Ceramics', 'All types of ceramics such as cups, glasses, jars, plates, and etc'),
    ('Jewelries', 'All type of accessories such as necklaces, rings and earrings made of different types of gold, diamonds, pearls, jades, and etc'),
    ('Watches', 'Different kinds of watches such as antique and automatic made of gold, silver, stainless steel, and etc'),
    ('Other Antiques', 'All kinds of antiques');
end

if not exists (select 1 from dbo.products)
begin
    declare @productTypeId1 int;
    declare @productTypeId2 int;
    declare @productTypeId3 int;
    declare @productTypeId4 int;

    select @productTypeId1 = Id from dbo.ProductTypes where Title = 'Ceramics';
    select @productTypeId2 = Id from dbo.ProductTypes where Title = 'Jewelries';
    select @productTypeId3 = Id from dbo.ProductTypes where Title = 'Watches';
    select @productTypeId4 = Id from dbo.ProductTypes where Title = 'Other Antiques';

    Insert into dbo.Products(Title, [Description], Price, Quantity, ProductTypeId, ImgName)
    values ('Black Ceramic Bowl', 'An antique black ceramic bowl made of sustainable material.', 50, 1, @productTypeId1, 'Ceramics001.jpg', 0, 0),
    ('Diamond White Gold Ring', 'A half karat diamond on a 10k gold necklace', 1500, 1, @productTypeId2, 'Jewelries001.jpg', 0, 0),
    ('Stainless Rolex', 'A Stainless dial watch with black leather arm', 1000, 1, @productTypeId3, 'Watches001.jpg', 0, 0),
    ('Antique Lamp', 'An antique lamp made in the 19th century', 200, 1, @productTypeId4, 'OtherAntiques001.jpg', 0, 0);
end