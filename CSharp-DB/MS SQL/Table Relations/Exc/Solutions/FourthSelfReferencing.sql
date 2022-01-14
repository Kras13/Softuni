CREATE TABLE Teachers(
	TeacherID INT PRIMARY KEY NOT NULL,
	Name VARCHAR(50) NOT NULL,
	ManagerID INT FOREIGN KEY REFERENCES Teachers
)

INSERT INTO Teachers(TeacherID,Name,ManagerId)
Values
	(101,'John',null),
	(102,'John',106),
	(103,'John',106),
	(104,'John',105),
	(105,'John',101),
	(106,'John',101)