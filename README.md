# CV
This is My resume (The Web Version)!

This is just a simple example of microservices architecture with .NET Core Web APIs.
I've decided to create a single MSSQL Server database with the resume info across different schemas.
Those are:

CertificationsAndExams
CoursesAndTrainings
Education
MasterData
People
Skills
Transcript
WorkExperience

And for every schema, I've implemented a microservice to retrieve it's data trough EntityFramework Core.

CV.CertificationsAndExams
CV.CoursesAndTrainings
CV.Education
CV.People
CV.Site
CV.Site.Angular
CV.Skills
CV.Transcript
CV.WorkExperience

Work in progress... :)