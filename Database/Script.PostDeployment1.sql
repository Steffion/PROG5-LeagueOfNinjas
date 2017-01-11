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
INSERT INTO Category
VALUES ('Head'), ('Shoulders'), ('Chest'), ('Belt'), ('Legs'), ('Feet');

INSERT INTO Ninja
--      gold name
VALUES ('0', 'Stef'), ('100', 'Sjoerd'), ('500', 'Merel'), ('279', 'Ger'), ('1245', 'Stijn');

INSERT INTO Equipment
--      type        value	    Strength	Intelligence	Agility	Name                  Image
VALUES ('Head',		'3500',		null,		'100',			null,	'Rabadons Deathcap',	null),
	   ('Shoulders','500',		'10',		null,			'-10',	'Shoulder plates',		null),
	   ('Chest',	'100',		'80',		null,			null,	'Guardian Angel',		null),
	   ('Belt',		'75',		'15',		null,			'-15',	'Giants Belt',			null),
	   ('Legs',		'150',		'10',		null,			'25',	'Dominionator pants',	null),
	   ('Feet',		'250',		null,		null,			'60',	'Boots of Swiftness',	null),
	   ('Chest',	'100',		'40',		'-5',			null,	'Chain Vest',			null),
	   ('Chest',	'1000',		'60',		'500',			'-50',	'Randuins Omen',		null),
	   ('Head',		'500',		'20',		'10',			'60',	'Spectres Cowl',		null),
	   ('Shoulders','250',		null,		null,			'60',	'Iceborn Gauntlet',		null),
	   ('Belt',		'2000',		'70',		null,			'80',	'Quicksilver Sash',		null),
	   ('Legs',		'350',		null,		null,			'60',	'Zrot portal',			null),
	   ('Shoulders','500',		null,		'100',			'20',	'Warmogs Armors',		null),
	   ('Head',		'700',		null,		'300',			'20',	'Morellonomicon',		null),
	   ('Feet',		'250',		null,		null,			'60',	'Boots of Speed',		null),
	   ('Feet',		'50',		'45',		null,			'10',	'Berserkers Graves',	null),
	   ('Chest',	'3333',		'9000',		'9000',			'9000',	'Trinity Force',		null),
	   ('Head',		'333',		'22',		'11',			'1',	'Banner of Command',	null); 


INSERT INTO PurchasedItems
--       ninja	    equipment
VALUES	 ('1',		'4'),
		 ('2',		'5'),
		 ('3',		'6'),
		 ('4',		'8'),
		 ('2',		'1'),
		 ('5',		'4');

INSERT INTO Loadout
--		name			ninja
VALUES	('Loadout #1',	'1'),
		('Loadout #2',	'2'),
		('Loadout #3',	'3'),
		('Loadout #4',	'4'),
		('Loadout #5',	'5'),
		('Loadout #6',	'2'); 

INSERT INTO LoadoutItems
--		Loadout   Equipment
VALUES ('1', '4'), ('2', '5'), ('3', '6'), ('4', '8'), ('5', '4'), ('6', '1'), ('6', '5');