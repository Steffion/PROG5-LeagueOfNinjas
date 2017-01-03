CREATE TABLE [dbo].[Loadout]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Ninja] INT NOT NULL, 
    CONSTRAINT [FK_Loadout_Ninja] FOREIGN KEY ([Ninja]) REFERENCES [Ninja]([Id])
)
