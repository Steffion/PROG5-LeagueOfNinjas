CREATE TABLE [dbo].[PurchasedItems]
(
	[Ninja] INT NOT NULL, 
    [Equipment] INT NOT NULL, 
    CONSTRAINT [FK_PurchasedItems_Ninja] FOREIGN KEY ([Ninja]) REFERENCES [Ninja]([Id]), 
    CONSTRAINT [FK_PurchasedItems_Equipment] FOREIGN KEY ([Equipment]) REFERENCES [Equipment]([Id]) 
)
