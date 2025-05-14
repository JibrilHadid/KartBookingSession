SELECT Count(KM.manufacturerID) as totalManufacturers, K.productionDate 
FROM  booking.tblKarts as K, booking.tblKartManufacturer as KM
WHERE K.kartID = KM.kartID
AND K.productionDate BETWEEN '2020-01-01' AND '2021-12-31'
GROUP BY K.productionDate
ORDER BY totalManufacturers, K.productionDate;
