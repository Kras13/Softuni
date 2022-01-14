SELECT p.PartId,p.Description,
pn.Quantity as [Required],
p.StockQty as [In Stock],
ISNULL(op.Quantity,0) as Ordered
FROM Jobs j
LEFT JOIN PartsNeeded pn
ON pn.JobId = j.JobId
LEFT JOIN Parts p
ON p.PartId = pn.PartId
LEFT JOIN Orders o
ON o.JobId = j.JobId
LEFT JOIN OrderParts op
ON op.OrderId = o.OrderId
WHERE j.Status <> 'Finished' AND (o.Delivered = 0 OR o.Delivered IS NULL)
AND pn.Quantity > p.StockQty + op.Quantity
