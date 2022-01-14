SELECT Mechanic FROM
(
SELECT mech.FirstName + ' ' + mech.LastName as Mechanic, mech.MechanicId
FROM Mechanics mech
LEFT JOIN Jobs j
ON j.MechanicId = mech.MechanicId
WHERE (
		SELECT COUNT(*)
		FROM Mechanics m
		LEFT JOIN Jobs j
		ON j.MechanicId = m.MechanicId
		WHERE m.MechanicId = mech.MechanicId
) = (	SELECT COUNT(*)
		FROM Mechanics m
		LEFT JOIN Jobs j
		ON j.MechanicId = m.MechanicId
		WHERE m.MechanicId = mech.MechanicId AND( j.Status
		IN('Finished',NULL) OR j.JobId IS NULL ))
GROUP BY mech.FirstName + ' ' + mech.LastName,mech.MechanicId) as Temp
ORDER BY MechanicId


SELECT COUNT(*)
FROM Mechanics m
LEFT JOIN Jobs j
ON j.MechanicId = m.MechanicId
WHERE m.MechanicId = 3 AND j.Status = 'Finished'

