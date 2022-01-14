CREATE TABLE Students(
	StudentID INT PRIMARY KEY IDENTITY NOT NULL,
	Name VARCHAR(50) NOT NULL
)

CREATE TABLE Exams(
	ExamID INT PRIMARY KEY NOT NULL,
	Name VARCHAR(50) NOT NULL
)

CREATE TABLE StudentsExams(
	StudentID INT REFERENCES Students(StudentId) NOT NULL,
	ExamID INT REFERENCES Exams(ExamID) NOT NULL
)
ALTER TABLE StudentsExams
	ADD CONSTRAINT pk_compKey PRIMARY KEY (StudentID,ExamID)
	
INSERT INTO Students(Name)
VALUES
	('Mila'),
	('Toni'),
	('Ron')	

INSERT INTO Exams(ExamId, Name)
VALUES
	(101,'SpringMVC'),
	(102,'Neo4j'),
	(103,'Oracle 11g')

INSERT INTO StudentsExams(StudentID,ExamID)
VALUES
	(1,101),
	(1,102),
	(2,101),
	(3,103),
	(2,102),
	(2,103)