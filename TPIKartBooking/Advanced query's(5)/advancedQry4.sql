SELECT T.trackType, C.firstName, C.lastName
FROM location.tblTracks as T, location.tblCoachLocation as CL, booking.tblCoach as C
WHERE T.trackID = CL.trackID
AND CL.coachID = C.coachID
AND T.trackType = 'outdoor'
ORDER BY T.trackType, C.firstName, C.lastName;
