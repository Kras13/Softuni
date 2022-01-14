SELECT c.LastName,CEILING(AVG(s.Length)) as CiagrLength,CEILING(AVG(s.RingRange)) as CiagrRingRange
FROM Clients c
INNER JOIN ClientsCigars cc
ON cc.ClientId = c.Id
INNER JOIN Cigars cg
ON cg.Id = cc.CigarId
INNER JOIN Sizes s
ON s.Id = cg.SizeId
GROUP BY c.LastName 
ORDER BY CiagrLength DESC