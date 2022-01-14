SELECT FullName, Country, ZIP, CONCAT('$',CigarPrice)
FROM(
	SELECT c.FirstName + ' ' + c.LastName as FullName,
	a.Country as Country,a.ZIP as ZIP,cg.CigarName,
	DENSE_RANK ( ) OVER (PARTITION BY c.Id ORDER BY cg.PriceForSingleCigar DESC) as Rank,
	cg.PriceForSingleCigar CigarPrice
	FROM Clients c
	INNER JOIN Addresses a
	ON a.Id = c.AddressId
	INNER JOIN ClientsCigars cc
	ON cc.ClientId = c.Id
	INNER JOIN Cigars cg
	ON cg.Id = cc.CigarId
	WHERE ISNUMERIC(a.ZIP) = 1) as Temp
	WHERE RANK = 1
	ORDER BY FullName