SELECT DISTINCT(DepartmentId),ThirdHighestSalary
FROM(
	SELECT e.DepartmentID as DepartmentId,
		e.Salary as ThirdHighestSalary,
		DENSE_RANK ( ) OVER (PARTITION BY e.DepartmentId ORDER BY e.Salary DESC) as Rank
	FROM Employees e
) as Temp
WHERE Temp.Rank = 3