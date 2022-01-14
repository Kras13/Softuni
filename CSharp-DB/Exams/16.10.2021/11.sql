CREATE OR ALTER FUNCTION udf_ClientWithCigars(@name NVARCHAR(30))
RETURNS INT
AS
BEGIN
	DECLARE @totalCount INT

	SET @totalCount = (SELECT COUNT(cc.CigarId)
								FROM Clients c
								INNER JOIN ClientsCigars cc
								ON cc.ClientId = c.Id
								WHERE c.FirstName LIKE @name
								)

	RETURN @totalCount
END

SELECT dbo.udf_ClientWithCigars('Joan')