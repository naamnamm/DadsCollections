CREATE TABLE [dbo].[Orders]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CustomerID] INT NOT NULL, 
    [CreatedDate] DATETIME2 NOT NULL, 
    [Status] NVARCHAR(20) NOT NULL, 
    [TotalCost] MONEY NOT NULL, 
    [ProductId_List] NVARCHAR(2000) NOT NULL, 
    CONSTRAINT [FK_Orders_Customers] FOREIGN KEY (CustomerID) REFERENCES Customers(Id)
)
