SELECT SUM(Difference) FROM(
	SELECT
	wp1.FirstName as HostName,
	wp1.DepositAmount as [Host Wizard Deposit],
	wp2.FirstName as GuestWizzard,
	wp2.DepositAmount as [Guest Wizard Deposit],
	wp1.DepositAmount - wp2.DepositAmount as [Difference]
	FROM WizzardDeposits wp1
	INNER JOIN WizzardDeposits wp2 ON
	wp1.Id + 1 = wp2.Id) as Temp