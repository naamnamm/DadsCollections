CREATE TABLE [dbo].[Products]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NVARCHAR(100) NOT NULL, 
    [Description] NVARCHAR(2000) NOT NULL, 
    [Price] MONEY NOT NULL, 
    [Quantity] INT NOT NULL, 
    [ProductTypeId] INT NOT NULL, 
    [ImgName] NVARCHAR(50) NOT NULL, 
    [IsSold] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_Products_ProductTypes] FOREIGN KEY ([ProductTypeId]) REFERENCES ProductTypes(Id)
)

--I'll just leave IsOrdered alone.

--How to store image for the project
--https://stackoverflow.com/questions/17361812/best-way-to-store-images-for-a-website

--modification 1 > add IsOrdered and IsSold -- either need to set the default value or set it to nullable 
--otherwise it won't update since the table has existing records.