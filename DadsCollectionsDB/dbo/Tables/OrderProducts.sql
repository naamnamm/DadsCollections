CREATE TABLE [dbo].[OrderProducts]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [ProductId] INT NOT NULL, 
    [OrderId] INT NOT NULL, 
    [IsSold] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_OrderProducts_Products] FOREIGN KEY (ProductId) REFERENCES Products(Id), 
    CONSTRAINT [FK_OrderProducts_Orders] FOREIGN KEY (OrderId) REFERENCES Orders(Id)
)
