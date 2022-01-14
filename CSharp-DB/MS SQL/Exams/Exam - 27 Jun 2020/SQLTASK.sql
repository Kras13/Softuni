INSERT INTO Clients(FirstName, LastName, Phone)
VALUES
	('Teri'	,'Ennaco','570-889-5187'),
	('Merlyn'	,'Lawler','201-588-7810'),
	('Georgene',	'Montezuma','925-615-5185'),
	('Jettie',	'Mconnell',	'908-802-3564'),
	('Lemuel',	'Latzke','631-748-6479'),
	('Melodie',	'Knipp','805-690-1682'),
	('Candida',	'Corbley','908-275-8357')

INSERT INTO Parts(SerialNumber, Description, Price, VendorId) VALUES												 
	('WP8182119','Door Boot Seal',117.86,2),
	('W10780048','Suspension Rod',42.81,1),
	('W10841140','Silicone Adhesive' ,6.77, 4),
	('WPY055980','High Temperature Adhesive',13.94,3)


UPDATE Jobs
SET MechanicId = 3, Status = 'In Progress'
WHERE Status = 'Pending'

DELETE FROM OrderParts WHERE OrderId = 19
DELETE FROM Orders WHERE OrderId = 19

SELECT m.FirstName + ' ' + m.LastName AS Mechanic, 
j.Status, j.IssueDate
FROM Mechanics AS m
LEFT JOIN Jobs AS j ON m.MechanicId = j.MechanicId
ORDER  BY  m.MechanicId, j.IssueDate, j.JobId DESC

SELECT c.FirstName + ' ' + c.LastName AS Client,
DATEDIFF(DAY,j.IssueDate,'04/24/2017') AS [Days going],
j.Status
FROM Jobs as j
 JOIN Clients as C ON c.ClientId = j.ClientId
WHERE j.Status != 'Finished'
ORDER BY [Days going] DESC, c.ClientId ASC

SELECT * FROM Jobs

SELECT m.FirstName + ' ' + m.LastName AS Mechanic,
AVG(DATEDIFF(DAY,IssueDate,FinishDate))
FROM Mechanics AS m
LEFT JOIN Jobs AS j ON m.MechanicId = j.MechanicId
GROUP BY (m.FirstName + ' ' + m.LastName), m.MechanicId
ORDER BY m.MechanicId ASC



	SELECT m.FirstName + ' ' + m.LastName AS FullName
			FROM Mechanics AS m
		LEFT JOIN Jobs AS j ON m.MechanicId =  j.MechanicId
			WHERE j.JobId IS NULL OR (SELECT COUNT(JobId)
									FROM Jobs
									WHERE Status != 'Finished' AND MechanicId = m.MechanicId
									GROUP BY MechanicId, Status) IS  NULL													
GROUP BY m.FirstName + ' ' + m.LastName, m.MechanicId
ORDER BY m.MechanicId ASC

