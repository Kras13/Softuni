SELECT * 
FROM Jobs
WHERE Status = 'Finished'

SELECT * FROM
Orders

SELECT j.JobId, ISNULL(Sum(op.Quantity * p.Price),0) AS Total
FROM Jobs as j
 LEFT JOIN Orders as o ON  o.JobId = j.JobId 
 LEFT JOIN OrderParts op ON op.OrderId = o.OrderId
 LEFT JOIN Parts AS p ON op.PartId = p.PartId
WHERE j.Status = 'Finished'
GROUP BY j.JobId
ORDER BY Total DESC, j.JobId ASC
