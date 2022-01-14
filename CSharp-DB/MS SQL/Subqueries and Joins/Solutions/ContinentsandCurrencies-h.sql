SELECT ContinentCode,CurrencyCode,CurrencyCount as CurrencyUsage
FROM(
SELECT 
	ContinentCode,CurrencyCode,CurrencyCount,
	DENSE_RANK() OVER (PARTITION BY ContinentCode ORDER BY CurrencyCount DESC) Rank
FROM
(SELECT ContinentCode,CurrencyCode, COUNT(CurrencyCode) AS CurrencyCount
FROM Countries
GROUP BY ContinentCode, CurrencyCode) AS Temp
WHERE CurrencyCount > 1 ) as Res
WHERE Rank = 1