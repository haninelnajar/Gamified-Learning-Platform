-- 1. Insert into Learner
INSERT INTO Learner (FirstName, LastName, Gender, BirthDate, Country, CulturalBackground)
VALUES 
('Alice', 'Smith', 'Female', '2000-05-15', 'USA', 'Western'),
('David', 'Lee', 'Male', '1999-09-01', 'USA', 'Western');

-- 2. Insert into PersonalizationProfiles
INSERT INTO PersonalizationProfiles (LearnerID, PreferredContentType, EmotionalState, PersonalityType)
VALUES 
(1, 'Visual', 'Engaged', 'Introvert'),
(2, 'Auditory', 'Curious', 'Extrovert');

-- 3. Insert into LearningPreference
INSERT INTO LearningPreference (LearnerID, Preference)
VALUES 
(1, 'Visual'),
(2, 'Auditory');

-- 4. Insert into Skills
INSERT INTO Skills (LearnerID, Skill)
VALUES 
(1, 'SQL'),
(2, 'SQL');

-- 5. Insert into Instructor
INSERT INTO Instructor (Name, LatestQualification, ExpertiseArea, Email)
VALUES 
('Dr. John Doe', 'PhD in Psychology', 'Learning Behavior', 'johndoe@example.com'),
('Jane Smith', 'MSc in Computer Science', 'Databases', 'janesmith@example.com');

-- 6. Insert into Course
INSERT INTO Course (Title, Learning_Objective, Credit_Points, Difficulty_Level, Description)
VALUES 
('Intro to Databases', 'Learn SQL Basics', 3, 'Beginner', 'SQL and database fundamentals.'),
('Advanced Databases', 'Learn advanced SQL topics', 3, 'Intermediate', 'Advanced SQL and database concepts.');

-- 7. Associate Instructors with Courses
INSERT INTO CourseInstructor (CourseID, InstructorID)
VALUES
(1, 1),
(1, 2),
(2, 2);

-- 8. Insert into Modules
INSERT INTO Modules (CourseID, Title, Difficulty, ContentURL)
VALUES 
(1, 'Introduction to SQL', 'Beginner', 'http://example.com/sql-intro'),
(2, 'Advanced SQL Queries', 'Intermediate', 'http://example.com/advanced-sql');

-- 9. Insert into LearningActivities and Capture ActivityIDs
DECLARE @ActivityID1 INT, @ActivityID2 INT;

INSERT INTO LearningActivities (ModuleID, CourseID, ActivityType, InstructionDetails, MaxPoints)
VALUES (1, 1, 'Hands-On Coding', 'Solve SQL challenges.', 20);
SET @ActivityID1 = SCOPE_IDENTITY();

INSERT INTO LearningActivities (ModuleID, CourseID, ActivityType, InstructionDetails, MaxPoints)
VALUES (2, 2, 'Project', 'Develop a database application.', 50);
SET @ActivityID2 = SCOPE_IDENTITY();

-- 10. Insert into InteractionLog using Captured ActivityIDs
INSERT INTO InteractionLog (ActivityID, LearnerID, Duration, Timestamp, ActionType)
VALUES 
(@ActivityID1, 1, 120, '2024-11-29 09:30:00', 'Completed Activity'),
(@ActivityID2, 2, 90, '2024-11-29 10:30:00', 'Viewed Activity');

-- 11. Insert into EmotionalFeedback using Captured ActivityIDs
INSERT INTO EmotionalFeedback (LearnerID, ActivityID, Timestamp, EmotionalState)
VALUES 
(1, @ActivityID1, '2024-11-29 10:00:00', 'Excited'),
(2, @ActivityID2, '2024-11-29 11:00:00', 'Motivated');

-- 12. Insert into Badge
INSERT INTO Badge (Title, Description, Criteria, Points)
VALUES 
('SQL Beginner', 'Earned by completing SQL Basics', 'Completion of SQL Basics', 50),
('SQL Expert', 'Earned by scoring above 90% in SQL Basics', 'Score > 90%', 100);

-- 13. Insert into Achievement
INSERT INTO Achievement (LearnerID, BadgeID, Description, DateEarned, Type)
VALUES 
(1, 1, 'Completed SQL Basics with a high score.', '2024-11-29', 'Course Completion');

-- 14. Insert into Assessments
INSERT INTO Assessments (ModuleID, CourseID, Type, TotalMarks, PassingMarks, Criteria, Weightage, Description, Title)
VALUES 
(1, 1, 'Quiz', 100, 50, 'Complete within 30 minutes', 30, 'Test your basic SQL knowledge.', 'SQL Basics Quiz'),
(2, 2, 'Exam', 150, 75, 'Complete within 1 hour', 50, 'Test your advanced SQL skills.', 'Advanced SQL Exam');

-- 15. Insert into TakenAssessment
INSERT INTO TakenAssessment (LearnerID, AssessmentID, ScoredPoint)
VALUES 
(1, 1, 90),
(2, 1, 80);

-- 16. Insert into Reward
INSERT INTO Reward (Value, Description, Type)
VALUES
(100, 'Quest Completion Reward', 'Quest');

-- 17. Insert into Quest
INSERT INTO Quest (DifficultyLevel, Criteria, Description, Title)
VALUES 
('Beginner', 'Complete SQL Basics', 'Finish all modules in SQL Basics course', 'SQL Basics Quest'),
('Intermediate', 'Complete group challenges.', 'Work collaboratively.', 'Group Quest');

-- 18. Insert into QuestReward
INSERT INTO QuestReward (RewardID, QuestID, LearnerID, TimeEarned)
VALUES 
(1, 1, 1, '2024-11-28 14:00:00'),
(1, 1, 2, '2024-11-28 15:00:00');

-- 19. Insert into Collaborative
INSERT INTO Collaborative (QuestID, Deadline, MaxNumParticipants)
VALUES 
(2, '2024-12-31', 5);

-- 20. Insert into LearnersCollaboration
INSERT INTO LearnersCollaboration (LearnerID, QuestID)
VALUES 
(1, 2),
(2, 2);

-- 21. Insert into SkillProgression
INSERT INTO SkillProgression (ProficiencyLevel, LearnerID, SkillName, Timestamp)
VALUES 
('Intermediate', 1, 'SQL', '2024-10-20 10:00:00'),
('Expert', 1, 'SQL', '2024-11-28 15:30:00'),
('Beginner', 2, 'SQL', '2024-10-25 11:00:00');

-- 22. Insert into LearningGoal
INSERT INTO LearningGoal (Status, Deadline, Description)
VALUES 
('Not Started', '2024-12-15', 'Complete advanced SQL programming.'),
('In Progress', '2024-12-31', 'Complete SQL Advanced Course.');

-- 23. Insert into LearnersGoals
INSERT INTO LearnersGoals (GoalID, LearnerID)
VALUES 
(1, 1),
(2, 1),
(2, 2);

-- 24. Insert into CourseEnrollment
INSERT INTO CourseEnrollment (CourseID, LearnerID, EnrollmentDate, Status)
VALUES 
(1, 1, '2024-10-01', 'Enrolled'),
(1, 2, '2024-10-05', 'Enrolled'),
(2, 1, '2024-11-25', 'Enrolled');

-- 25. Insert into Notification
INSERT INTO Notification (Message, UrgencyLevel)
VALUES 
('Complete the module before the deadline!', 'High'),
('New assignment available!', 'Medium');

-- 26. Insert into ReceivedNotification
INSERT INTO ReceivedNotification (NotificationID, LearnerID)
VALUES 
(1, 1),
(2, 2);

-- 27. Insert into DiscussionForum
INSERT INTO DiscussionForum (ModuleID, CourseID, Title, LastActive, Timestamp, Description)
VALUES 
(1, 1, 'SQL Basics Q&A', '2024-11-28 10:00:00', '2024-11-28 09:50:00', 'Discuss SQL-related queries here.'),
(2, 2, 'Advanced SQL Discussion', '2024-11-29 12:00:00', '2024-11-29 11:50:00', 'Discuss advanced SQL topics.');

-- 28. Insert into LearnerDiscussion
INSERT INTO LearnerDiscussion (ForumID, LearnerID, Post, Time)
VALUES 
(1, 1, 'This is my post about SQL functions.', '2024-11-28 16:00:00'),
(2, 2, 'Can someone explain window functions?', '2024-11-29 13:00:00');

-- 29. Insert into LearningPath
INSERT INTO LearningPath (LearnerID, ProfileID, CompletionStatus, CustomContent, AdaptiveRules)
VALUES 
(1, 1, 'In Progress', 'SQL Basics Videos', 'Adaptive rules based on emotional feedback.'),
(2, 2, 'In Progress', 'Advanced SQL Tutorials', 'Adaptive rules based on performance.');

-- 30. Insert into LearnerMastery
INSERT INTO LearnerMastery (LearnerID, QuestID, [Completion Status])
VALUES 
(1, 1, 'Completed'),
(1, 2, 'In Progress'),
(2, 1, 'Completed'),
(2, 2, 'In Progress');





INSERT INTO [dbo].[Users] (username, password, user_type, email)
VALUES
(9, 'learnerPassword123', 'Learner', 'learner@example.com');

INSERT INTO [dbo].[Users] (username, password, user_type, email)
VALUES
(5, 'instructorPassword123', 'Instructor', 'instructor@example.com');


SELECT * FROM Learner; 
SELECT * FROM Skills;
SELECT * FROM LearningPreference;
SELECT * FROM PersonalizationProfiles;
SELECT * FROM HealthCondition;
SELECT * FROM Course;
SELECT * FROM CoursePrerequisite;
SELECT * FROM Modules;
SELECT * FROM TargetTraits;
SELECT * FROM ModuleContent;
SELECT * FROM ContentLibrary;
SELECT * FROM Assessments;
SELECT * FROM AssessmentResults;
SELECT * FROM LearningActivities;
SELECT * FROM InteractionLog;
SELECT * FROM EmotionalFeedback;
SELECT * FROM LearningPath;
SELECT * FROM Instructor;
SELECT * FROM CourseInstructor;
SELECT * FROM PathReview;
SELECT * FROM Notification;
SELECT * FROM ReceivedNotification;
SELECT * FROM CourseEnrollment;
SELECT * FROM Leaderboard;
SELECT * FROM Ranking;
SELECT * FROM Badge;
SELECT * FROM Achievement;
SELECT * FROM Reward;
SELECT * FROM Quest;
SELECT * FROM SkillMastery;
SELECT * FROM Collaborative;
SELECT * FROM QuestReward;
SELECT * FROM LearnersCollaboration;
SELECT * FROM DiscussionForum;
SELECT * FROM LearnerDiscussion;
SELECT * FROM SkillProgression;
SELECT * FROM LearningGoal;
SELECT * FROM LearnersGoals;
SELECT * FROM Survey;
SELECT * FROM SurveyQuestions;
SELECT * FROM FilledSurvey;
SELECT * FROM LearnerMastery;
SELECT * FROM TakenAssessment;
