SELECT Mechanic, [Average Days]
FROM
(
SELECT m.FirstName + ' ' + m.LastName as Mechanic
, m.MechanicId as MechanicId,
AVG(DATEDIFF(DAY,j.IssueDate,j.FinishDate)) as [Average Days]
FROM Mechanics m
LEFT JOIN Jobs j
ON m.MechanicId = j.MechanicId
GROUP BY m.FirstName + ' ' + m.LastName, m.MechanicId
) as Temp
ORDER BY MechanicId
