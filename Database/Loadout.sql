﻿CREATE TABLE [dbo].[Loadout]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[Name] VARCHAR(MAX) NOT NULL,
    [Ninja] INT NOT NULL, 
    CONSTRAINT [FK_Loadout_loadout] FOREIGN KEY ([Ninja]) REFERENCES [Ninja]([Id]) ON DELETE CASCADE
)
