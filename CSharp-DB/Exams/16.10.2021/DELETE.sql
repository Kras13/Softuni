UPDATE Cigars
SET PriceForSingleCigar = PriceForSingleCigar + PriceForSingleCigar * 0.2
WHERE TastId = 1

UPDATE Brands
SET BrandDescription = 'New description'
WHERE BrandDescription IS NULL

DELETE FROM ClientsCigars WHERE ClientId IN (4,7,8)
DELETE FROM Clients WHERE AddressId IN (4,7,8)
DELETE FROM Addresses WHERE Country LIKE 'C%'

