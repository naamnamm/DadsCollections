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

if not exists (Select 1 from dbo.ProductTypes)

begin
    Insert into dbo.ProductTypes (Title,[Description])
    values ('Ceramics', 'All types of ceramics such as cups, glasses, jars, plates, and etc'),
    ('Jewelries', 'All type of accessories such as necklaces, rings and earrings made of different types of gold, diamonds, pearls, jades, and etc'),
    ('Watches', 'Different kinds of watches such as antique and automatic made of gold, silver, stainless steel, and etc'),
    ('Other Antiques', 'All kinds of antiques')
end

if not exists (Select 1 from dbo.Products)

begin
    declare @roomId1 int;
    declare @roomId2 int;
    declare @roomId3 int;
    declare @roomId4 int;

    select @roomId1 = Id from dbo.ProductTypes where Title = 'Ceramics';
    select @roomId2 = Id from dbo.ProductTypes where Title = 'Jewelries';
    select @roomId3 = Id from dbo.ProductTypes where Title = 'Watches';
    select @roomId4 = Id from dbo.ProductTypes where Title = 'Other Antiques';

    Insert into dbo.Products(Title, [Description], Price, Quantity, ProductTypeId, ImgName)
    values ('Black Ceramic Bowl', 'An antique black ceramic bowl made of sustainable material.', 50, 1, @roomId1, 'Ceramics001.jpg'),
    ('Diamond White Gold Ring', 'A half karat diamond on a 10k gold necklace', 1500, 1, @roomId2, 'Jewelries001.jpg'),
    ('Stainless Rolex', 'A Stainless dial watch with black leather arm', 1000, 1, @roomId3, 'Watches001.jpg'),
    ('Antique Lamp', 'An antique lamp made in the 19th century', 200, 1, @roomId4, 'OtherAntiques001.jpg')
end