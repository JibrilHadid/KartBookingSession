SELECT Count(c.coachID) as totalCoach , CI.experienceLvl
FROM booking.tblCoach as C, booking.tblCoachInfo as CI
WHERE C.coachID = CI.coachID
AND CI.experienceLvl = 'Advanced'
GROUP BY CI.experienceLvl
ORDER BY totalCoach, CI.experienceLvl;