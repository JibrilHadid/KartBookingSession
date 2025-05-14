SELECT distinct(C.coachID), C.firstName, C.gender, CI.experienceLvl
FROM booking.tblCoach as C, booking.tblCoachInfo as CI
WHERE C.coachID = CI.coachID
AND C.gender = 'Male' 
AND C.firstName LIKE 'A%'
ORDER BY C.firstName, C.gender, CI.experienceLvl;