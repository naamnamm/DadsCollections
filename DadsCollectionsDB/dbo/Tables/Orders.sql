CREATE TABLE [dbo].[Orders]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CustomerId] INT NOT NULL, 
    [CreatedDate] DATETIME2 NOT NULL, 
    [Status] NVARCHAR(20) NOT NULL, 
    [TotalCost] MONEY NOT NULL, 
    CONSTRAINT [FK_Orders_Customers] FOREIGN KEY ([CustomerId]) REFERENCES Customers(Id)
)
