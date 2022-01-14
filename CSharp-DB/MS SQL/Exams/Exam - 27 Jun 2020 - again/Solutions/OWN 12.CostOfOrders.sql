-- own cost of order

CREATE FUNCTION udf_GetCost(@jobId INT)
RETURNS DECIMAL(6,2)
AS
BEGIN
	DECLARE @totalCost DECIMAL(6,2)

	DECLARE @jobOrdersCount INT = (SELECT COUNT(o.OrderId) FROM Jobs j								   
								   INNER JOIN Orders o
								   ON o.JobId = j.JobId
								   WHERE j.JobId = @jobId)

	IF @jobOrdersCount = 0
	BEGIN
		RETURN 0
	END

	SET @totalCost = (  SELECT SUM(op.Quantity * p.Price) 
						FROM Jobs j								   
						INNER JOIN Orders o
						ON o.JobId = j.JobId
						INNER JOIN OrderParts op
						ON op.OrderId = o.OrderId
						INNER JOIN Parts p
						ON p.PartId = op.PartId
						WHERE j.JobId = @jobId	)

	RETURN @totalCost
END