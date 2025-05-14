SELECT Count(kartType) as totalKart250cc
FROM booking.tblKarts
WHERE kartType = '50cc'
ORDER BY totalKart250cc;