SELECT m.FirstName + ' ' + m.LastName as Mechanic,j.Status,	j.IssueDate
FROM Mechanics m
INNER JOIN Jobs j
ON j.MechanicId = m.MechanicId 
ORDER BY m.MechanicId, j.IssueDate, j.JobId ASC


--Order by mechanic Id, issue date, job Id 