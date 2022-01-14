SELECT j.JobId,
SUM(
	CASE WHEN o.OrderId IS NOT NULL
	THEN op.Quantity * p.Price 
	ELSE 0 END) as [Total]
FROM Jobs j
LEFT JOIN Orders o
ON o.JobId = j.JobId
LEFT JOIN OrderParts op
ON op.OrderId = o.OrderId
LEFT JOIN Parts p
ON p.PartId = op.PartId
WHERE j.Status = 'Finished'
GROUP BY j.JobId
ORDER BY Total DESC, j.JobId ASC

SELECT *
FROM Jobs j
LEFT JOIN Orders o
ON o.JobId = j.JobId
LEFT JOIN OrderParts op
ON op.OrderId = o.OrderId
LEFT JOIN Parts p
ON p.PartId = op.PartId