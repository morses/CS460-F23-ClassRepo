-- populate academic years table
INSERT INTO [dbo].[SUPAcademicYears] (Year) VALUES 
	('2016-2017'),
	('2017-2018'),
	('2018-2019'),
	('2019-2020'),
	('2020-2021'),
	('2021-2022'),
	('2022-2023'),
	('2023-2024'),
	('2024-2025'),
	('2025-2026');

INSERT INTO [dbo].[SUPAdvisors] (FirstName,LastName) VALUES
	('Scot','Morse'),
	('Becka','Morgan'),
	('Alex','LeClerc');

INSERT INTO [dbo].[SUPGroups] (Name,Motto,SUPAdvisorID,SUPAcademicYearID) VALUES
	('Boug Inc.','It''s pronounced Bog!',1,8),
	('CharpSpark','C Harps Park',1,8),
	('BitBenders','Be the Bracket',1,8),
	('Swift Solutions','Like the bird',1,8),
	('Team TBD','We''ll choose a name sometime',1,8),
	('Default','The most boring team',1,8);
