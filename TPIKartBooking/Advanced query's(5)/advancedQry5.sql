SELECT C.firstName, C.lastName, CI.email, CI.phoneNumber
FROM booking.tblCoach as C, booking.tblCoachInfo as CI
WHERE C.coachID = CI.coachID
AND C.age > 30
ORDER BY C.firstName, C.lastName, C.age, CI.email, CI.phoneNumber;
