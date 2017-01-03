CREATE TABLE [dbo].[Loadout_has_Equipment]
(
	[Loadout] INT NOT NULL, 
    [Equipment] INT NOT NULL, 
    CONSTRAINT [FK_Loadout_has_Equipment_Loadout] FOREIGN KEY ([Loadout]) REFERENCES [Loadout]([Id]), 
    CONSTRAINT [FK_Loadout_has_Equipment_Equipment] FOREIGN KEY ([Equipment]) REFERENCES [Equipment]([Id]) 
)
