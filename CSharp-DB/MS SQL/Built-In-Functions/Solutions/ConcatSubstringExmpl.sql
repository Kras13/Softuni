SELECT PeakName, RiverName, CONCAT(
	substring(LOWER(PeakName),1,len(peakname)),
	substring(LOWER(RiverName),2,len(RiverName)) 
) as Mix
FROM Peaks, Rivers
WHERE
	lower(SUBSTRING(PeakName,Len(PeakName),1)) = lower(SUBSTRING(RiverName,1,1))
	ORDER BY Mix