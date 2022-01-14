SELECT c.FirstName + ' ' + c.LastName,
DATEDIFF(DAY,j.IssueDate,'04/24/2017'),
j.Status
FROM Clients c
INNER JOIN Jobs j
ON c.ClientId = j.ClientId
WHERE j.Status <> 'Finished'