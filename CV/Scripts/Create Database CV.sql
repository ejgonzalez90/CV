Create Database CV;
Go
Use CV;
Go

Create Schema MasterData
Go

Create Schema People
Go

Create Schema CertificationsAndExams
Go

Create Schema CoursesAndTrainings
Go

Create Schema Education
Go

Create Schema Skills
Go

Create Schema Transcript
Go

Create Schema WorkExperience
Go

----------------------------------------------------------------------------------------------------
-- DER

Delete From People.People;
Insert Into People.People( LastName, FirstName, MiddleName, BirthDate, CivilStatus, JobTitle, [Description] )
	Values	( 'González', 'Emiliano', 'Javier', '19900307', 1, 'Sr. .NET Developer',
			'Hi there! I know that a resume of a whole life of work can be a hard task to achieve, but I’ll try to complete this as much as I can, so I can save you time and effort :).
I’m a software developer, and my goal is to be a great software architect someday. I began to program from a young age, at the Huergo Institute to be more precise, and since then, although I have gone through several roles and professions, a few years ago I found the opportunity to start working professionally as a developer, and since then I have tried to perfect myself as much as I can.
Although I had to abandon my university studies, there is the idea of starting them again. Meanwhile I have been able to advance by taking some certification exams and doing specific courses on certain technologies.
I might be a restless guy, but I try to be a perfectionist as well, I try to do the best that languages and frameworks allow, and I think that should be a keep going learning experience.'
			),
			( 'Vales', 'María', 'Lucrecia', '19910429', 1, 'Docente de nivel inicial',
			''
			);

Declare @PersonId	Int
Select	@PersonId = PersonId
	From People.People
	Where LastName = 'González';

Delete From Education.Education;
Insert Into Education.Education( PersonId, Institute, Description, DateFrom, DateTo, StatusId)
	Values	( @PersonId, 'Medalla Milagrosa Institute', 'Elementary School', '19940101', '20020101', 1),
			( @PersonId, 'Luis A. Huergo Industrial Institute', 'Electronic technician specialized in computers', '20030101', '20080101', 1),
			( @PersonId, 'TAMABA Tertiary Institute', 'Professional Music Technician', '20090101', '20100101', 1),
			( @PersonId, 'National Technology Institute', 'Systems Engineering', '20110101', '20120101', 2);
Insert Into Education.Education( PersonId, Institute, Description, DateFrom, DateTo, StatusId, Enabled)
	Values	( @PersonId, 'CAECE University', 'Bachelor of Systems', '20190101', Null, 3, 0);

