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
--      type        value	    Strength	Intelligence	Agility	Name
VALUES ('Head',		'3500',		null,		'100',			null,	'Rabadons Deathcap'),
	   ('Shoulders','500',		'10',		null,			'-10',	'Shoulder plates'),
	   ('Chest',	'100',		'80',		null,			null,	'Guardian Angel'),
	   ('Belt',		'75',		'15',		null,			'-15',	'Giants Belt'),
	   ('Legs',		'150',		'10',		null,			'25',	'Dominionator pants'),
	   ('Feet',		'250',		null,		null,			'60',	'Boots of Swiftness'),
	   ('Chest',	'100',		'40',		'-5',			null,	'Chain Vest'),
	   ('Chest',	'1000',		'60',		'500',			'-50',	'Randuins Omen'),
	   ('Head',		'500',		'20',		'10',			'60',	'Spectres Cowl'),
	   ('Shoulders','250',		null,		null,			'60',	'Iceborn Gauntlet'),
	   ('Belt',		'2000',		'70',		null,			'80',	'Quicksilver Sash'),
	   ('Legs',		'350',		null,		null,			'60',	'Zrot portal'),
	   ('Shoulders','500',		null,		'100',			'20',	'Warmogs Armors'),
	   ('Head',		'700',		null,		'300',			'20',	'Morellonomicon'),
	   ('Feet',		'250',		null,		null,			'60',	'Boots of Speed'),
	   ('Feet',		'50',		'45',		null,			'10',	'Berserkers Graves'),
	   ('Chest',	'3333',		'9000',		'9000',			'9000',	'Trinity Force'),
	   ('Head',		'333',		'22',		'11',			'1',	'Banner of Command'); 


INSERT INTO PurchasedItems
--      ninja   equipment
VALUES ('1', '4'), ('2', '5'), ('3', '6'), ('4', '8'), ('2', '1'), ('5', '4');

INSERT INTO Loadout
--     ninja
VALUES ('1'), ('2'), ('3'), ('4'), ('5'), ('2'); 

INSERT INTO Loadout_has_Equipment
--		Loadout   Equipment
VALUES ('1', '4'), ('2', '5'), ('3', '6'), ('4', '8'), ('5', '4'), ('6', '1'), ('6', '5');