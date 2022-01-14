DELETE FROM Clients
WHERE AddressId IN (7, 8 , 10, 23)

DELETE FROM Addresses
WHERE Country LIKE 'C%'