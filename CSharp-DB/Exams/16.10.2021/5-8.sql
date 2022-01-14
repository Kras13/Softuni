SELECT c.CigarName, c.PriceForSingleCigar, c.ImageURL
FROM Cigars c
ORDER BY c.PriceForSingleCigar ASC, c.CigarName DESC

SELECT c.Id,c.CigarName,c.PriceForSingleCigar, t.TasteType,	t.TasteStrength
FROM Cigars c
INNER JOIN Tastes t
ON t.Id = c.TastId
WHERE t.TasteType IN ('Earthy','Woody')
ORDER BY c.PriceForSingleCigar DESC

SELECT c.Id,c.FirstName + ' ' + c.LastName as ClientName ,c.Email
FROM Clients c
LEFT JOIN ClientsCigars cc
ON cc.ClientId = c.Id
WHERE cc.ClientId IS NULL
ORDER BY ClientName

SELECT TOP(5) c.CigarName,c.PriceForSingleCigar,c.ImageURL
FROM Cigars c
INNER JOIN Sizes s 
ON s.Id = c.SizeId
WHERE Length >= 12 AND (CigarName LIKE '%ci%' OR PriceForSingleCigar > 50) AND RingRange > 2.55
ORDER BY c.CigarName ASC, c.PriceForSingleCigar DESC