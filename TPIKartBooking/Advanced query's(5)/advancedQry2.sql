SELECT count(C.coachID) as totalCoaches, T.trackName 
FROM location.tblTracks AS T, location.tblCoachLocation AS CL, booking.tblCoach as C
WHERE T.trackID = CL.trackID
AND CL.coachID = C.coachID
GROUP BY T.trackName
ORDER BY totalCoaches desc;
