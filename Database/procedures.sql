
drop procedure loginproc
SELECT * 
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_NAME = 'Admin';

GO
CREATE PROCEDURE loginproc (
    @id INT,
    @password NVARCHAR(255),
    @success INT OUTPUT,
    @type NVARCHAR(50) OUTPUT
)
AS
BEGIN
    -- Initialize success as 0 (failure) by default
    SET @success = 0;
    SET @type = NULL;

    -- Check if the username and password match an entry in the Users table
    IF EXISTS (
        SELECT 1
        FROM Users
        WHERE username = @id AND password = @password
    )
    BEGIN
        -- Login successful
        SET @success = 1;

        -- Retrieve user type
        SELECT @type = user_type
        FROM Users
        WHERE username = @id;
    END
END;

-- Insert sample data
INSERT INTO Users (username, password, user_type)
VALUES (123, 'mypassword', 'admin'),
       (456, 'password123', 'regular');

-- Declare variables for outputs
DECLARE @success INT;
DECLARE @type NVARCHAR(50);

-- Call the procedure
EXEC loginproc @id = 123, @password = 'mypassword', @success = @success OUTPUT, @type = @type OUTPUT;

-- Check outputs
SELECT @success AS LoginSuccess, @type AS UserType;

CREATE TABLE Courses (
    id INT PRIMARY KEY IDENTITY(1,1),
    name NVARCHAR(255) NOT NULL, -- Course name
    description NVARCHAR(MAX) -- Optional description of the course
);

INSERT INTO Course(Title, description)
VALUES 
('Mathematics 101', 'An introduction to basic mathematics concepts'),
('Physics 201', 'Intermediate physics course focusing on mechanics'),
('Computer Science 101', 'Introduction to programming and computer science concepts');

GO
CREATE PROCEDURE availableCourses
AS
BEGIN
    SELECT name FROM Courses; -- Fetches all available course names
END;


Go
CREATE PROCEDURE ViewInfoIns
@InstructorID INT
AS
BEGIN
    SELECT * 
    FROM Instructor 
    WHERE InstructorID = @InstructorID;
END;

Go
CREATE PROCEDURE ViewInfoA
@AdminID INT
AS
BEGIN
    SELECT * 
    FROM Admin 
    WHERE AdminID = @AdminID;
END;

GO
CREATE PROCEDURE UpdateInfoLearner
    @LearnerID INT,
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @Gender CHAR(1),
    @BirthDate DATE,
    @Country VARCHAR(50),
    @CulturalBackground VARCHAR(50)
AS
BEGIN
    UPDATE Learner
    SET FirstName = @FirstName,
        LastName = @LastName,
        Gender = @Gender,
        BirthDate=@BirthDate, 
        Country=@Country,
        CulturalBackground=@CulturalBackground
    WHERE LearnerID = @LearnerID;
END;

GO
CREATE PROCEDURE UpdateInfoIns
   @InstructorID INT,
   @Name VARCHAR(100),
   @LatestQualification VARCHAR(100),
   @ExpertiseArea VARCHAR(100),
   @Email VARCHAR(100)
AS
BEGIN
    UPDATE Instructor
    SET name = @name,
        LatestQualification = @LatestQualification,
        ExpertiseArea = @ExpertiseArea,
        Email=@Email
    WHERE InstructorID = @InstructorID;
END;

GO
CREATE PROCEDURE ViewPath
    @LearnerID INT,
    @PathID INT
AS
BEGIN
    SELECT 
        CompletionStatus ,
        CustomContent ,
        AdaptiveRules 
    FROM LearningPath
    WHERE LearnerID = @LearnerID AND PathID=@PathID;
END;

GO 
CREATE PROCEDURE InsPost
    @InstructorID INT,
    @DiscussionID INT,
    @Post VARCHAR(MAX)
AS
BEGIN
    INSERT INTO InstructorDiscussion (ForumID, InstructorID, Post, time)
    VALUES (@DiscussionID, @InstructorID, @Post, GETDATE());
END;
-- 1. ViewInfo
IF OBJECT_ID('ViewInfo', 'P') IS NOT NULL
    DROP PROCEDURE ViewInfo;
GO
CREATE PROCEDURE ViewInfo (@LearnerID INT)
AS
BEGIN
    SELECT * FROM Learner WHERE LearnerID = @LearnerID;
END;
GO

-- 2. LearnerInfo
IF OBJECT_ID('LearnerInfo', 'P') IS NOT NULL
    DROP PROCEDURE LearnerInfo;
GO
CREATE PROCEDURE LearnerInfo (@LearnerID INT)
AS
BEGIN
    SELECT * FROM PersonalizationProfiles WHERE LearnerID = @LearnerID;
END;
GO

-- 3. EmotionalState (Updated)
IF OBJECT_ID('EmotionalState', 'P') IS NOT NULL
    DROP PROCEDURE EmotionalState;
GO
CREATE PROCEDURE EmotionalState (
    @LearnerID INT,
    @emotional_state VARCHAR(50) OUTPUT
)
AS
BEGIN
    SELECT TOP 1 @emotional_state = EmotionalState 
    FROM EmotionalFeedback 
    WHERE LearnerID = @LearnerID 
    ORDER BY Timestamp DESC;
END;
GO

-- 4. LogDetails
IF OBJECT_ID('LogDetails', 'P') IS NOT NULL
    DROP PROCEDURE LogDetails;
GO
CREATE PROCEDURE LogDetails (@LearnerID INT)
AS
BEGIN
    SELECT * FROM InteractionLog WHERE LearnerID = @LearnerID ORDER BY Timestamp DESC;
END;
GO

-- 5. InstructorReview
IF OBJECT_ID('InstructorReview', 'P') IS NOT NULL
    DROP PROCEDURE InstructorReview;
GO
CREATE PROCEDURE InstructorReview (@InstructorID INT)
AS
BEGIN
    SELECT EF.*
    FROM EmotionalFeedback EF
    INNER JOIN CourseEnrollment CE ON EF.LearnerID = CE.LearnerID
    INNER JOIN CourseInstructor CI ON CE.CourseID = CI.CourseID
    WHERE CI.InstructorID = @InstructorID;
END;
GO

-- 6. CourseRemove
IF OBJECT_ID('CourseRemove', 'P') IS NOT NULL
    DROP PROCEDURE CourseRemove;
GO
CREATE PROCEDURE CourseRemove (@courseID INT)
AS
BEGIN
    DELETE FROM Course WHERE CourseID = @courseID;
END;
GO

-- 7. ActivityEmotionalFeedback (New)
IF OBJECT_ID('ActivityEmotionalFeedback', 'P') IS NOT NULL
    DROP PROCEDURE ActivityEmotionalFeedback;
GO
CREATE PROCEDURE ActivityEmotionalFeedback (
    @ActivityID INT,
    @LearnerID INT,
    @Timestamp DATETIME,
    @EmotionalState VARCHAR(50)
)
AS
BEGIN
    INSERT INTO EmotionalFeedback (LearnerID, ActivityID, Timestamp, EmotionalState)
    VALUES (@LearnerID, @ActivityID, @Timestamp, @EmotionalState);
END;
GO

-- 8. InstructorCount
IF OBJECT_ID('InstructorCount', 'P') IS NOT NULL
    DROP PROCEDURE InstructorCount;
GO
CREATE PROCEDURE InstructorCount
AS
BEGIN
    SELECT CourseID 
    FROM CourseInstructor 
    GROUP BY CourseID 
    HAVING COUNT(InstructorID) > 1;
END;
GO

-- 9. ViewNot
IF OBJECT_ID('ViewNot', 'P') IS NOT NULL
    DROP PROCEDURE ViewNot;
GO
CREATE PROCEDURE ViewNot (@LearnerID INT)
AS
BEGIN
    SELECT N.*
    FROM Notification N
    INNER JOIN ReceivedNotification RN ON N.ID = RN.NotificationID
    WHERE RN.LearnerID = @LearnerID;
END;
GO

-- 10. ViewScore (Updated)
IF OBJECT_ID('ViewScore', 'P') IS NOT NULL
    DROP PROCEDURE ViewScore;
GO
CREATE PROCEDURE ViewScore (
    @LearnerID INT, 
    @AssessmentID INT,
    @Score INT OUTPUT
)
AS
BEGIN
    SELECT @Score = ScoredPoint
    FROM TakenAssessment
    WHERE LearnerID = @LearnerID AND AssessmentID = @AssessmentID;
END;
GO

-- 11. AssessmentsList (Updated)
IF OBJECT_ID('AssessmentsList', 'P') IS NOT NULL
    DROP PROCEDURE AssessmentsList;
GO
CREATE PROCEDURE AssessmentsList (
    @CourseID INT,
    @ModuleID INT,
    @LearnerID INT
)
AS
BEGIN
    SELECT A.ID AS AssessmentID, A.Title, A.Type, A.TotalMarks, A.PassingMarks, A.Criteria, TA.ScoredPoint AS Score
    FROM Assessments A
    LEFT JOIN TakenAssessment TA ON A.ID = TA.AssessmentID AND TA.LearnerID = @LearnerID
    WHERE A.CourseID = @CourseID AND A.ModuleID = @ModuleID;
END;
GO

-- 12. CreateDiscussion
IF OBJECT_ID('CreateDiscussion', 'P') IS NOT NULL
    DROP PROCEDURE CreateDiscussion;
GO
CREATE PROCEDURE CreateDiscussion (@ModuleID INT, @CourseID INT, @Title VARCHAR(100), @Description VARCHAR(1000))
AS
BEGIN
    INSERT INTO DiscussionForum (ModuleID, CourseID, Title, Description, Timestamp)
    VALUES (@ModuleID, @CourseID, @Title, @Description, GETDATE());
END;
GO

-- 13. RemoveBadge
IF OBJECT_ID('RemoveBadge', 'P') IS NOT NULL
    DROP PROCEDURE RemoveBadge;
GO
CREATE PROCEDURE RemoveBadge (@BadgeID INT)
AS
BEGIN
    DELETE FROM Badge WHERE BadgeID = @BadgeID;
END;
GO

-- 14. CriteriaDelete
IF OBJECT_ID('CriteriaDelete', 'P') IS NOT NULL
    DROP PROCEDURE CriteriaDelete;
GO
CREATE PROCEDURE CriteriaDelete (@criteria VARCHAR(255))
AS
BEGIN
    DELETE FROM Quest WHERE Criteria = @criteria;
END;
GO

-- 15. NotificationUpdate
IF OBJECT_ID('NotificationUpdate', 'P') IS NOT NULL
    DROP PROCEDURE NotificationUpdate;
GO
CREATE PROCEDURE NotificationUpdate
    @LearnerID INT,
    @NotificationID INT,
    @ReadStatus BIT
AS
BEGIN
    UPDATE ReceivedNotification
    SET ReadStatus = @ReadStatus
    WHERE LearnerID = @LearnerID AND NotificationID = @NotificationID;
    
    IF @ReadStatus = 0
    BEGIN
        DELETE FROM ReceivedNotification
        WHERE LearnerID = @LearnerID AND NotificationID = @NotificationID;
    END;
END;
GO

-- 16. TotalPoints
IF OBJECT_ID('TotalPoints', 'P') IS NOT NULL
    DROP PROCEDURE TotalPoints;
GO
CREATE PROCEDURE TotalPoints
    @LearnerID INT, 
    @RewardType VARCHAR(50)
AS
BEGIN
    SELECT SUM(R.Value) AS TotalPoints
    FROM QuestReward QR
    JOIN Reward R ON QR.RewardID = R.RewardID
    WHERE QR.LearnerID = @LearnerID AND R.Type = @RewardType;
END;
GO

-- 17. EnrolledCourses
IF OBJECT_ID('EnrolledCourses', 'P') IS NOT NULL
    DROP PROCEDURE EnrolledCourses;
GO
CREATE PROCEDURE EnrolledCourses
    @LearnerID INT
AS
BEGIN
    SELECT C.CourseID, C.Title, C.Description
    FROM Course C
    JOIN CourseEnrollment CE ON C.CourseID = CE.CourseID
    WHERE CE.LearnerID = @LearnerID;
END;
GO

-- 18. GoalReminder (Updated)
IF OBJECT_ID('GoalReminder', 'P') IS NOT NULL
    DROP PROCEDURE GoalReminder;
GO
CREATE PROCEDURE GoalReminder
    @LearnerID INT
AS
BEGIN
    DECLARE @Message VARCHAR(1000);
    SET @Message = 'You are falling behind on the following learning goals:';
    
    SELECT @Message AS NotificationMessage;
    
    SELECT lg.ID AS GoalID, lg.Description, lg.Deadline
    FROM LearningGoal lg
    INNER JOIN LearnersGoals lgs ON lg.ID = lgs.GoalID
    WHERE lgs.LearnerID = @LearnerID AND lg.Deadline < GETDATE() AND lg.Status <> 'Completed';
END;
GO

-- 19. ModuleTraits
IF OBJECT_ID('ModuleTraits', 'P') IS NOT NULL
    DROP PROCEDURE ModuleTraits;
GO
CREATE PROCEDURE ModuleTraits
    @TargetTrait VARCHAR(50),
    @CourseID INT
AS
BEGIN
    SELECT M.ModuleID, M.Title, M.Difficulty, M.ContentURL
    FROM Modules M
    JOIN TargetTraits T ON M.ModuleID = T.ModuleID AND M.CourseID = T.CourseID
    WHERE T.Trait = @TargetTrait AND M.CourseID = @CourseID;
END;
GO

-- 20. AssessmentAnalysis (Updated)
IF OBJECT_ID('AssessmentAnalysis', 'P') IS NOT NULL
    DROP PROCEDURE AssessmentAnalysis;
GO
CREATE PROCEDURE AssessmentAnalysis
    @LearnerID INT
AS
BEGIN
    SELECT a.ID AS AssessmentID, a.Title, a.TotalMarks, ta.ScoredPoint,
        ROUND((CAST(ta.ScoredPoint AS FLOAT) / a.TotalMarks) * 100, 2) AS PercentageScore,
        CASE 
            WHEN ROUND((CAST(ta.ScoredPoint AS FLOAT) / a.TotalMarks) * 100, 2) >= 90 THEN 'Excellent'
            WHEN ROUND((CAST(ta.ScoredPoint AS FLOAT) / a.TotalMarks) * 100, 2) >= 75 THEN 'Good'
            WHEN ROUND((CAST(ta.ScoredPoint AS FLOAT) / a.TotalMarks) * 100, 2) >= 50 THEN 'Average'
            ELSE 'Needs Improvement'
        END AS Performance
    FROM Assessments a
    INNER JOIN TakenAssessment ta ON a.ID = ta.AssessmentID
    WHERE ta.LearnerID = @LearnerID
    ORDER BY PercentageScore DESC;
END;
GO

-- 21. EmotionalTrendAnalysisIns (New)
IF OBJECT_ID('EmotionalTrendAnalysisIns', 'P') IS NOT NULL
    DROP PROCEDURE EmotionalTrendAnalysisIns;
GO
CREATE PROCEDURE EmotionalTrendAnalysisIns
    @CourseID INT,
    @ModuleID INT,
    @TimePeriod DATETIME
AS
BEGIN
    SELECT EF.LearnerID, EF.Timestamp AS Date, EF.EmotionalState
    FROM EmotionalFeedback EF
    INNER JOIN InteractionLog IL ON EF.LearnerID = IL.LearnerID AND EF.ActivityID = IL.ActivityID
    INNER JOIN LearningActivities LA ON IL.ActivityID = LA.ActivityID
    WHERE LA.CourseID = @CourseID
      AND LA.ModuleID = @ModuleID
      AND EF.Timestamp >= @TimePeriod
    ORDER BY EF.Timestamp;
END;
GO

-- 22. JoinQuest
IF OBJECT_ID('JoinQuest', 'P') IS NOT NULL
    DROP PROCEDURE JoinQuest;
GO
CREATE PROCEDURE JoinQuest
    @LearnerID INT,
    @QuestID INT
AS
BEGIN
    DECLARE @MaxParticipants INT;
    DECLARE @CurrParticipants INT;

    SELECT @MaxParticipants = MaxNumParticipants
    FROM Collaborative 
    WHERE QuestID = @QuestID;

    SELECT @CurrParticipants = COUNT(DISTINCT LearnerID)
    FROM LearnersCollaboration
    WHERE QuestID = @QuestID;

    IF @CurrParticipants < @MaxParticipants
    BEGIN
        INSERT INTO LearnersCollaboration (LearnerID, QuestID)
        VALUES (@LearnerID, @QuestID);
        SELECT 'Joined the quest' AS Message;
    END
    ELSE
    BEGIN
        SELECT 'The quest is full' AS Message;
    END
END;
GO

-- 23. SkillsProficiency
IF OBJECT_ID('SkillsProficiency', 'P') IS NOT NULL
    DROP PROCEDURE SkillsProficiency;
GO
CREATE PROCEDURE SkillsProficiency
    @LearnerID INT
AS
BEGIN
    SELECT 
        SkillName AS Skill,
        ProficiencyLevel AS Proficiency,
        Timestamp AS LastUpdated
    FROM SkillProgression
    WHERE LearnerID = @LearnerID
    ORDER BY Timestamp DESC; 
END;
GO

-- 24. NotificationUpdate
IF OBJECT_ID('NotificationUpdate', 'P') IS NOT NULL
    DROP PROCEDURE NotificationUpdate;
GO
CREATE PROCEDURE NotificationUpdate
    @LearnerID INT,
    @NotificationID INT,
    @ReadStatus BIT
AS
BEGIN
    UPDATE ReceivedNotification
    SET ReadStatus = @ReadStatus
    WHERE LearnerID = @LearnerID AND NotificationID = @NotificationID;
    
    IF @ReadStatus = 0
    BEGIN
        DELETE FROM ReceivedNotification
        WHERE LearnerID = @LearnerID AND NotificationID = @NotificationID;
    END;
END;
GO

-- 25. CourseRegister
IF OBJECT_ID('CourseRegister', 'P') IS NOT NULL
    DROP PROCEDURE CourseRegister;
GO
CREATE PROCEDURE CourseRegister
    @LearnerID INT,
    @CourseID INT
AS
BEGIN
    IF NOT EXISTS (
        SELECT P.Prereq
        FROM CoursePrerequisite P
        WHERE P.CourseID = @CourseID
          AND P.Prereq NOT IN (
                SELECT CE.CourseID
                FROM CourseEnrollment CE
                WHERE CE.LearnerID = @LearnerID AND CE.Status = 'Completed'
            )
    )
    BEGIN
        INSERT INTO CourseEnrollment (CourseID, LearnerID, EnrollmentDate, Status)
        VALUES (@CourseID, @LearnerID, GETDATE(), 'Enrolled');
        SELECT 'Registration approved' AS Status;
    END
    ELSE
    BEGIN
        SELECT 'Prerequisites not completed' AS Status;
    END;
END;
GO

-- 26. Post
IF OBJECT_ID('Post', 'P') IS NOT NULL
    DROP PROCEDURE Post;
GO
CREATE PROCEDURE Post
    @LearnerID INT,
    @ForumID INT,
    @PostText VARCHAR(1000)
AS
BEGIN
    INSERT INTO LearnerDiscussion (ForumID, LearnerID, Post, Time)
    VALUES (@ForumID, @LearnerID, @PostText, GETDATE());
END;
GO

-- 27. AddGoal
IF OBJECT_ID('AddGoal', 'P') IS NOT NULL
    DROP PROCEDURE AddGoal;
GO
CREATE PROCEDURE AddGoal
    @LearnerID INT,
    @GoalID INT
AS
BEGIN
    INSERT INTO LearnersGoals (GoalID, LearnerID)
    VALUES (@GoalID, @LearnerID);
END;
GO

-- 28. CurrentPath
IF OBJECT_ID('CurrentPath', 'P') IS NOT NULL
    DROP PROCEDURE CurrentPath;
GO
CREATE PROCEDURE CurrentPath
    @LearnerID INT
AS
BEGIN
    SELECT PathID, CompletionStatus, CustomContent, AdaptiveRules
    FROM LearningPath
    WHERE LearnerID = @LearnerID;
END;
GO

-- 29. QuestMembers
IF OBJECT_ID('QuestMembers', 'P') IS NOT NULL
    DROP PROCEDURE QuestMembers;
GO
CREATE PROCEDURE QuestMembers
    @LearnerID INT
AS
BEGIN
    SELECT DISTINCT c.QuestID, l2.LearnerID, l2.FirstName, l2.LastName
    FROM LearnersCollaboration lc
    INNER JOIN Collaborative c ON lc.QuestID = c.QuestID
    INNER JOIN LearnersCollaboration lc2 ON c.QuestID = lc2.QuestID
    INNER JOIN Learner l2 ON lc2.LearnerID = l2.LearnerID
    WHERE lc.LearnerID = @LearnerID AND c.Deadline >= GETDATE()
    ORDER BY c.QuestID;
END;
GO

-- 30. QuestProgress
IF OBJECT_ID('QuestProgress', 'P') IS NOT NULL
    DROP PROCEDURE QuestProgress;
GO
CREATE PROCEDURE QuestProgress
    @LearnerID INT
AS
BEGIN
    SELECT 'Quest' AS ItemType, q.QuestID, q.Title, lm.[Completion Status] AS Status
    FROM LearnerMastery lm
    INNER JOIN Quest q ON lm.QuestID = q.QuestID
    WHERE lm.LearnerID = @LearnerID

    UNION ALL

    SELECT 'Badge' AS ItemType, b.BadgeID, b.Title,
        CASE WHEN a.BadgeID IS NOT NULL THEN 'Earned' ELSE 'Not Earned' END AS Status
    FROM Badge b
    LEFT JOIN Achievement a ON b.BadgeID = a.BadgeID AND a.LearnerID = @LearnerID;
END;
GO

-- 31. SkillProgressHistory
IF OBJECT_ID('SkillProgressHistory', 'P') IS NOT NULL
    DROP PROCEDURE SkillProgressHistory;
GO
CREATE PROCEDURE SkillProgressHistory
    @LearnerID INT,
    @Skill VARCHAR(50)
AS
BEGIN
    SELECT Timestamp, ProficiencyLevel
    FROM SkillProgression
    WHERE LearnerID = @LearnerID AND SkillName = @Skill
    ORDER BY Timestamp;
END;
GO

-- 32. GradeUpdate
IF OBJECT_ID('GradeUpdate', 'P') IS NOT NULL
    DROP PROCEDURE GradeUpdate;
GO
CREATE PROCEDURE GradeUpdate(
    @LearnerID INT,
    @AssessmentID INT,
    @NewGrade INT
)
AS
BEGIN
    UPDATE TakenAssessment
    SET ScoredPoint = @NewGrade
    WHERE LearnerID = @LearnerID AND AssessmentID = @AssessmentID;

    SELECT 'Grade updated successfully' AS ConfirmationMessage;
END;
GO

-- 33. AssessmentNot
IF OBJECT_ID('AssessmentNot', 'P') IS NOT NULL
    DROP PROCEDURE AssessmentNot;
GO
CREATE PROCEDURE AssessmentNot(
    @Timestamp DATETIME,
    @Message VARCHAR(1000),
    @UrgencyLevel VARCHAR(20),
    @LearnerID INT
)
AS
BEGIN
    INSERT INTO Notification (Timestamp, Message, UrgencyLevel)
    VALUES (@Timestamp, @Message, @UrgencyLevel);

    DECLARE @NotificationID INT = SCOPE_IDENTITY();

    INSERT INTO ReceivedNotification (NotificationID, LearnerID)
    VALUES (@NotificationID, @LearnerID);

    SELECT 'Notification sent successfully' AS ConfirmationMessage;
END;
GO

-- 34. NewGoal
IF OBJECT_ID('NewGoal', 'P') IS NOT NULL
    DROP PROCEDURE NewGoal;
GO
CREATE PROCEDURE NewGoal(
    @Status VARCHAR(50),
    @Deadline DATETIME,
    @Description VARCHAR(1000)
)
AS
BEGIN
    INSERT INTO LearningGoal (Status, Deadline, Description)
    VALUES (@Status, @Deadline, @Description);
END;
GO

-- 35. LearnersCourses
IF OBJECT_ID('LearnersCourses', 'P') IS NOT NULL
    DROP PROCEDURE LearnersCourses;
GO
CREATE PROCEDURE LearnersCourses(
    @CourseID INT,
    @InstructorID INT
)
AS
BEGIN
    SELECT DISTINCT L.LearnerID, L.FirstName, L.LastName
    FROM Learner L
    INNER JOIN CourseEnrollment CE ON L.LearnerID = CE.LearnerID
    INNER JOIN CourseInstructor CI ON CE.CourseID = CI.CourseID
    WHERE CE.CourseID = @CourseID AND CI.InstructorID = @InstructorID;
END;
GO

-- 36. NewActivity
IF OBJECT_ID('NewActivity', 'P') IS NOT NULL
    DROP PROCEDURE NewActivity;
GO
CREATE PROCEDURE NewActivity
    @CourseID INT,
    @ModuleID INT,
    @ActivityType VARCHAR(50),
    @InstructionDetails VARCHAR(1000),
    @MaxPoints INT
AS
BEGIN
    INSERT INTO LearningActivities (CourseID, ModuleID, ActivityType, InstructionDetails, MaxPoints)
    VALUES (@CourseID, @ModuleID, @ActivityType, @InstructionDetails, @MaxPoints);
END;
GO

-- 37. NewAchievement
IF OBJECT_ID('NewAchievement', 'P') IS NOT NULL
    DROP PROCEDURE NewAchievement;
GO
CREATE PROCEDURE NewAchievement(
    @LearnerID INT,
    @BadgeID INT,
    @Description VARCHAR(1000),
    @DateEarned DATE,
    @Type VARCHAR(50)
)
AS
BEGIN
    INSERT INTO Achievement (LearnerID, BadgeID, Description, DateEarned, Type)
    VALUES (@LearnerID, @BadgeID, @Description, @DateEarned, @Type);
END;
GO

-- 38. Prerequisites
IF OBJECT_ID('Prerequisites', 'P') IS NOT NULL
    DROP PROCEDURE Prerequisites;
GO
CREATE PROCEDURE Prerequisites 
    @LearnerID INT, 
    @CourseID INT
AS
BEGIN
    DECLARE @PrerequisitesCompleted VARCHAR(50);

    IF NOT EXISTS (
        SELECT P.Prereq
        FROM CoursePrerequisite P
        WHERE P.CourseID = @CourseID
          AND P.Prereq NOT IN (
                SELECT CE.CourseID
                FROM CourseEnrollment CE
                WHERE CE.LearnerID = @LearnerID AND CE.Status = 'Completed'
            )
    )
    BEGIN
        SET @PrerequisitesCompleted = 'completed.';
    END
    ELSE
    BEGIN
        SET @PrerequisitesCompleted = 'prerequisites not completed.';
    END

    SELECT @PrerequisitesCompleted AS PrerequisitesStatus;
END;
GO

-- 39. LeaderboardRank
IF OBJECT_ID('LeaderboardRank', 'P') IS NOT NULL
    DROP PROCEDURE LeaderboardRank;
GO
CREATE PROCEDURE LeaderboardRank
    @LeaderboardID INT
AS
BEGIN
    SELECT R.LearnerID, L.FirstName, L.LastName, R.Rank
    FROM Ranking R
    JOIN Learner L ON R.LearnerID = L.LearnerID
    WHERE R.BoardID = @LeaderboardID
    ORDER BY R.Rank;
END;
GO

-- 40. LeaderboardFilter
IF OBJECT_ID('LeaderboardFilter', 'P') IS NOT NULL
    DROP PROCEDURE LeaderboardFilter;
GO
CREATE PROCEDURE LeaderboardFilter
    @LearnerID INT
AS
BEGIN
    SELECT r.*
    FROM Ranking r
    WHERE r.BoardID IN (SELECT BoardID FROM Ranking WHERE LearnerID = @LearnerID)
    ORDER BY r.Rank DESC;
END;
GO

-- 41. SkillLearners
IF OBJECT_ID('SkillLearners', 'P') IS NOT NULL
    DROP PROCEDURE SkillLearners;
GO
CREATE PROCEDURE SkillLearners
    @SkillName VARCHAR(50)
AS
BEGIN
    SELECT L.LearnerID, L.FirstName, L.LastName
    FROM Skills S
    JOIN Learner L ON S.LearnerID = L.LearnerID
    WHERE S.Skill = @SkillName;
END;
GO
