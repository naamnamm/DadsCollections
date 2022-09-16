CREATE TABLE [dbo].[OrderProducts]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ProductId] INT NOT NULL, 
    [OrderId] INT NOT NULL, 
    CONSTRAINT [FK_OrderProducts_Products] FOREIGN KEY (ProductId) REFERENCES Products(Id), 
    CONSTRAINT [FK_OrderProducts_Orders] FOREIGN KEY (OrderId) REFERENCES Orders(Id)
)
