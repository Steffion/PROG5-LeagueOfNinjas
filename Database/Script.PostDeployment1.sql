﻿/*
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
VALUES ('Head',		'3500',		null,		'100',			null,	'Rabadons Deathcap',	0x89504E470D0A1A0A0000000D49484452000000960000009608060000003C0171E20000707B4944415478DAEDFD49906459961D889DFBDEFB937E9D6D7477F3798C39323223A7CA9A50A80128A08002D0EC6653D8247BC11549A1904B5228DC71438AF486DD5C50845C10041B4001D535A00A28546655568E11199931644C3E),
	   ('Shoulders','500',		'10',		null,			'-10',	'Shoulder plates',		0x89504E470D0A1A0A0000000D49484452000000960000009608060000003C0171E2000000017352474200AECE1CE90000000467414D410000B18F0BFC6105000000097048597300000B1200000B1201D2DD7EFC00003C4D49444154785EED7D07805C6775EE77E7CE9DDE67B677F52ECB966D5972071730C6186348B0C32321),
	   ('Chest',	'100',		'80',		null,			null,	'Guardian Angel',		0x89504E470D0A1A0A0000000D49484452000000960000009608060000003C0171E20000800049444154789C54FD69D0ADE97516065FF7F40C7BEF7738638F520F96D4D6AC966449B6C1F8B3656CF361FC7D94F828B0F980C481901421E107865451AA4A52143F5295A9420209710C860092C1D8C660D9C836C646962CB7C696),
	   ('Belt',		'75',		'15',		null,			'-15',	'Giants Belt',			0x89504E470D0A1A0A0000000D49484452000000960000009608060000003C0171E2000000017352474200AECE1CE90000000467414D410000B18F0BFC6105000000206348524D00007A26000080840000FA00000080E8000075300000EA6000003A98000017709CBA513C00003D0E49444154785EED7C77785B75B6EDCCDC19),
	   ('Legs',		'150',		'10',		null,			'25',	'Dominionator pants',	0x89504E470D0A1A0A0000000D49484452000000960000009608060000003C0171E2000000017352474200AECE1CE90000000467414D410000B18F0BFC6105000000097048597300000EC300000EC301C76FA86400007D7149444154785EEDBD799865C959DED9DDB5E59E7933F3EE37EF9637F7CACACACACCDABAAAB296AEEE),
	   ('Feet',		'250',		null,		null,			'60',	'Boots of Swiftness',	0x89504E470D0A1A0A0000000D49484452000000960000009608060000003C0171E200000A4F6943435050686F746F73686F70204943432070726F66696C65000078DA9D53675453E9163DF7DEF4424B8880944B6F5215082052428B801491262A2109104A8821A1D91551C1114545041BC8A088038E8E808C15512C0C8A0AD8),
	   ('Chest',	'100',		'40',		'-5',			null,	'Chain Vest',			0x89504E470D0A1A0A0000000D49484452000000960000009608060000003C0171E20000200049444154789CEC7D77BC5E5599EEB3CA2E5F3B3D21A4118AA1851801918B0C6844044104514145044550B13B8CE3701DC7F13ACA38E3C858E63A36741C18411994A2D289480912427AEFC9393939F56BBBAD72FF586BEDEF0B32),
	   ('Chest',	'1000',		'60',		'500',			'-50',	'Randuins Omen',		0x89504E470D0A1A0A0000000D4948445200000040000000400806000000AA6971DE000000017352474200AECE1CE90000000467414D410000B18F0BFC6105000000097048597300000EC300000EC301C76FA864000015F849444154785EA59A7F4C94779EC7E78FFB833FFC83CB694F4E8F8340A9B322EDAC089D299665A4E5),
	   ('Head',		'500',		'20',		'10',			'60',	'Spectres Cowl',		0x89504E470D0A1A0A0000000D49484452000000960000009608060000003C0171E2000000017352474200AECE1CE90000000467414D410000B18F0BFC6105000000097048597300000B1200000B1201D2DD7EFC0000300149444154785EED7D079C5D659DF6737BEF657A4FAF8424848010A2088258D1AC20A0828B055D36C2),
	   ('Shoulders','250',		null,		null,			'60',	'Iceborn Gauntlet',		0xFFD8FFE000104A46494600010100000100010000FFDB0043000503040404030504040405050506070C08070707070F0B0B090C110F1212110F111113161C1713141A1511111821181A1D1D1F1F1F13172224221E241C1E1F1EFFDB0043010505050706070E08080E1E1411141E1E1E1E1E1E1E1E1E1E1E1E1E1E1E1E1E1E1E),
	   ('Belt',		'2000',		'70',		null,			'80',	'Quicksilver Sash',		0x89504E470D0A1A0A0000000D49484452000000960000009608060000003C0171E2000000017352474200AECE1CE90000000467414D410000B18F0BFC6105000000097048597300000EC300000EC301C76FA8640000403349444154785EED7D0798645779E58084120AA3499DBB3A54EACAB9BA72755575757775CEDD333D39),
	   ('Legs',		'350',		null,		null,			'60',	'Zrot portal',			0x89504E470D0A1A0A0000000D49484452000000960000009608060000003C0171E2000000017352474200AECE1CE9000000097048597300000B1300000B1301009A9C180000000774494D4507DC0516140002E19B9B470000002274455874436F6D6D656E74004372656174656420776974682047494D50206F6E2061204D61),
	   ('Shoulders','500',		null,		'100',			'20',	'Warmogs Armors',		0x89504E470D0A1A0A0000000D49484452000000960000009608060000003C0171E2000000017352474200AECE1CE90000000467414D410000B18F0BFC6105000000097048597300000B1200000B1201D2DD7EFC0000309A49444154785EED7D07601DD599F59979BDAB5BB22CB9E15E30B6E92D242418420B65970D2D041236),
	   ('Head',		'700',		null,		'300',			'20',	'Morellonomicon',		0x89504E470D0A1A0A0000000D49484452000000960000009608060000003C0171E2000000017352474200AECE1CE90000000467414D410000B18F0BFC6105000000097048597300000B1200000B1201D2DD7EFC000043BB49444154785EED7D079C5D55B5F7FFCEBD737B9B7BA7F79EC92433E9059240022474084D1104E4A9),
	   ('Feet',		'250',		null,		null,			'60',	'Boots of Speed',		0x89504E470D0A1A0A0000000D49484452000000960000009608060000003C0171E20000819149444154789CECFD7798655771EF8D7F56D8E9A4CE3D39078551CE4820092C10209119916CC2050B7C9DAFAF6D1CF068B0318ED7BEC618236730066BC8D1808424149184501A85C9B1A7A7739FBCC35AEBF7C7DEA76724E0FAFE),
	   ('Feet',		'50',		'45',		null,			'10',	'Berserkers Graves',	0x89504E470D0A1A0A0000000D49484452000000960000009608060000003C0171E20000000976704167000000960000009600F9F665CB000080434944415478DAECBD079C667775DEFF7BDBF45EB6F72EEDAE56D24A4212AA886201060101639B62EC0493D801431C9CC4D8C136B11D1327066C82890B188C02089090284205),
	   ('Chest',	'3333',		'9000',		'9000',			'9000',	'Trinity Force',		0x89504E470D0A1A0A0000000D4948445200000190000001590806000000B65879B00000200049444154785EE4BD0D9C5C75792F7ECE9973CE9C39F3B2B3B39BCD66B32C9B1802841823524444442F4544442F05A9D2AAB4DAD68BD6F6FAB1EDFD7BEF2DFDFBF1D3EBD55E6BD5DBAA1F6BA9A20245507C01441A306208218410),
	   ('Head',		'333',		'22',		'11',			'1',	'Banner of Command',	0x89504E470D0A1A0A0000000D49484452000000960000009608060000003C0171E2000000017352474200AECE1CE90000000467414D410000B18F0BFC6105000000097048597300000B1200000B1201D2DD7EFC000040E849444154785EED7D6994245775E6974B6466E45A7B5755EFAD6E756B171608B10DB67C8CE5857DF0


); 


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