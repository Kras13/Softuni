CREATE PROCEDURE usp_SearchByTaste @taste varchar(20)
AS
BEGIN
	SELECT cg.CigarName as CigarName,
	CONCAT('$',cg.PriceForSingleCigar) as Price,
	t.TasteType as TasteType,
	b.BrandName as BrandName,
	CONCAT(s.Length,' cm') as CigarLength,
	CONCAT(s.RingRange,' cm') as CigarRingRange
	FROM Cigars cg
	INNER JOIN Tastes t
	ON t.Id = cg.TastId
	INNER JOIN Brands b
	ON b.Id = cg.BrandId
	INNER JOIN Sizes s
	ON s.Id = cg.SizeID
	WHERE TasteType LIKE @taste
	ORDER BY s.Length ASC, s.RingRange DESC
END

EXEC usp_SearchByTaste 'Woody'

SELECT *
FROM Tastes

SELECT *
FROM Cigars

SELECT *
FROM Sizes