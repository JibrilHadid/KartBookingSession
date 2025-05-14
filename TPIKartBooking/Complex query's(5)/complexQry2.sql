SELECT count(coachID) as totalCoaches, gender
FROM booking.tblCoach
WHERE gender = 'Female'
GROUP BY gender
ORDER BY totalcoaches, gender;