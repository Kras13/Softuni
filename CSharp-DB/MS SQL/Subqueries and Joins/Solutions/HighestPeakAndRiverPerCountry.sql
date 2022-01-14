SELECT TOP(5) CountryName,
	Max(HighestPeakElevation) as HighestPeakElevation,
	MAX (LongestRiverLength) as LongestRiverLength
FROM
(
SELECT c.CountryName ,
MAX(p.Elevation) as HighestPeakElevation,
MAX(riv.Length) as LongestRiverLength
FROM Countries c
	LEFT JOIN MountainsCountries mc
	ON mc.CountryCode = c.CountryCode
	LEFT JOIN Peaks p
	ON p.MountainId = mc.MountainId
	LEFT JOIN CountriesRivers cr
	ON cr.CountryCode = c.CountryCode
	LEFT JOIN Rivers riv 
	ON riv.Id = cr.RiverId
GROUP BY c.CountryName) AS Temp
GROUP BY CountryName
ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, CountryName ASC