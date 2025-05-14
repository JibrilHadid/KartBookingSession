SELECT KM.manufacturerName, K.kartPrice, K.productionDate
FROM booking.tblKartManufacturer as KM, booking.tblKarts as K
Where K.kartID = KM.kartID
AND (kartPrice <= 190.00  and K.productionDate >= '2021-01-01')
ORDER BY KM.manufacturerName, K.kartPrice, K.productionDate;