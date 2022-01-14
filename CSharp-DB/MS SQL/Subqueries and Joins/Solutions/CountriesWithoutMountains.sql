SELECT COUNT(*) FROM
(
SELECT c.CountryCode,mc.MountainId
From Countries c
LEFT JOIN MountainsCountries mc
ON mc.CountryCode = c.CountryCode
WHERE mc.MountainId IS NULL) as Temp