-- 1. Learner Table
CREATE TABLE Learner (
    LearnerID INT PRIMARY KEY IDENTITY(1,1),
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Gender VARCHAR(10),
    BirthDate DATE,
    Country VARCHAR(50),
    CulturalBackground VARCHAR(50)
);
ALTER TABLE Learner
ADD Password VARCHAR(255) NULL;

GO
ALTER TABLE [dbo].[Admin]
ADD [password] VARCHAR (255) NULL;

-- 2. Skills Table
CREATE TABLE Skills (
    LearnerID INT,
    Skill VARCHAR(50),
    PRIMARY KEY (LearnerID, Skill),
    FOREIGN KEY (LearnerID) REFERENCES Learner(LearnerID) ON DELETE CASCADE
);
GO

-- 3. LearningPreference Table
CREATE TABLE LearningPreference (
    LearnerID INT PRIMARY KEY,
    Preference VARCHAR(50),
    FOREIGN KEY (LearnerID) REFERENCES Learner(LearnerID) ON DELETE CASCADE
);
GO

-- 4. PersonalizationProfiles Table
CREATE TABLE PersonalizationProfiles (
    ProfileID INT PRIMARY KEY IDENTITY(1,1),
    LearnerID INT UNIQUE,
    PreferredContentType VARCHAR(50),
    EmotionalState VARCHAR(50),
    PersonalityType VARCHAR(50),
    FOREIGN KEY (LearnerID) REFERENCES Learner(LearnerID) ON DELETE CASCADE
);
GO

-- 5. HealthCondition Table
CREATE TABLE HealthCondition (
    LearnerID INT,
    ProfileID INT,
    Condition VARCHAR(255),
    PRIMARY KEY (LearnerID, ProfileID, Condition),
    FOREIGN KEY (LearnerID) REFERENCES Learner(LearnerID) ON DELETE CASCADE,
    FOREIGN KEY (ProfileID) REFERENCES PersonalizationProfiles(ProfileID)
);
GO

-- 6. Course Table
CREATE TABLE Course (
    CourseID INT PRIMARY KEY IDENTITY(1,1),
    Title VARCHAR(100),
    Learning_Objective VARCHAR(500),
    Credit_Points INT,
    Difficulty_Level VARCHAR(50),
    Description VARCHAR(1000)
);
GO

-- 7. CoursePrerequisite Table
CREATE TABLE CoursePrerequisite (
    CourseID INT,
    Prereq INT,
    PRIMARY KEY (CourseID, Prereq),
    FOREIGN KEY (CourseID) REFERENCES Course(CourseID),
    FOREIGN KEY (Prereq) REFERENCES Course(CourseID)
);
GO

-- 8. Modules Table
CREATE TABLE Modules (
    ModuleID INT PRIMARY KEY IDENTITY(1,1),
    CourseID INT,
    Title VARCHAR(100),
    Difficulty VARCHAR(50),
    ContentURL VARCHAR(500),
    FOREIGN KEY (CourseID) REFERENCES Course(CourseID) ON DELETE CASCADE
);
GO

-- 9. TargetTraits Table
CREATE TABLE TargetTraits (
    ModuleID INT,
    CourseID INT,
    Trait VARCHAR(50),
    PRIMARY KEY (ModuleID, CourseID, Trait),
    FOREIGN KEY (ModuleID) REFERENCES Modules(ModuleID) ON DELETE CASCADE,
    FOREIGN KEY (CourseID) REFERENCES Course(CourseID)
);
GO

-- 10. ModuleContent Table
CREATE TABLE ModuleContent (
    ModuleID INT,
    CourseID INT,
    ContentType VARCHAR(50),
    PRIMARY KEY (ModuleID, CourseID, ContentType),
    FOREIGN KEY (ModuleID) REFERENCES Modules(ModuleID) ON DELETE CASCADE,
    FOREIGN KEY (CourseID) REFERENCES Course(CourseID)
);
GO

-- 11. ContentLibrary Table
CREATE TABLE ContentLibrary (
    ID INT PRIMARY KEY IDENTITY(1,1),
    ModuleID INT,
    CourseID INT,
    Title VARCHAR(100),
    Description VARCHAR(1000),
    Metadata VARCHAR(1000),
    Type VARCHAR(50),
    ContentURL VARCHAR(500),
    FOREIGN KEY (ModuleID) REFERENCES Modules(ModuleID) ON DELETE CASCADE,
    FOREIGN KEY (CourseID) REFERENCES Course(CourseID)
);
GO

-- 12. Assessments Table
CREATE TABLE Assessments (
    ID INT PRIMARY KEY IDENTITY(1,1),
    ModuleID INT,
    CourseID INT,
    Type VARCHAR(50),
    TotalMarks INT,
    PassingMarks INT,
    Criteria VARCHAR(255),
    Weightage INT,
    Description VARCHAR(1000),
    Title VARCHAR(100),
    FOREIGN KEY (ModuleID) REFERENCES Modules(ModuleID) ON DELETE CASCADE,
    FOREIGN KEY (CourseID) REFERENCES Course(CourseID)
);
GO

-- 13. AssessmentResults Table
CREATE TABLE AssessmentResults (
    AssessmentID INT,
    LearnerID INT,
    Score INT,
    PRIMARY KEY (AssessmentID, LearnerID),
    FOREIGN KEY (AssessmentID) REFERENCES Assessments(ID) ON DELETE CASCADE,
    FOREIGN KEY (LearnerID) REFERENCES Learner(LearnerID) ON DELETE CASCADE
);
GO

-- 14. LearningActivities Table
CREATE TABLE LearningActivities (
    ActivityID INT PRIMARY KEY IDENTITY(1,1),
    ModuleID INT,
    CourseID INT,
    ActivityType VARCHAR(50),
    InstructionDetails VARCHAR(1000),
    MaxPoints INT,
    FOREIGN KEY (ModuleID) REFERENCES Modules(ModuleID) ON DELETE CASCADE,
    FOREIGN KEY (CourseID) REFERENCES Course(CourseID)
);
GO

-- 15. InteractionLog Table
CREATE TABLE InteractionLog (
    LogID INT PRIMARY KEY IDENTITY(1,1),
    ActivityID INT,
    LearnerID INT,
    Duration INT,
    Timestamp DATETIME,
    ActionType VARCHAR(50),
    FOREIGN KEY (LearnerID) REFERENCES Learner(LearnerID) ON DELETE CASCADE,
    FOREIGN KEY (ActivityID) REFERENCES LearningActivities(ActivityID) ON DELETE CASCADE
);
GO

-- 16. EmotionalFeedback Table (Updated to include ActivityID)
CREATE TABLE EmotionalFeedback (
    FeedbackID INT PRIMARY KEY IDENTITY(1,1),
    LearnerID INT,
    ActivityID INT,
    Timestamp DATETIME,
    EmotionalState VARCHAR(50),
    FOREIGN KEY (LearnerID) REFERENCES Learner(LearnerID) ON DELETE CASCADE,
    FOREIGN KEY (ActivityID) REFERENCES LearningActivities(ActivityID) ON DELETE CASCADE
);
GO

-- 17. LearningPath Table
CREATE TABLE LearningPath (
    PathID INT PRIMARY KEY IDENTITY(1,1),
    LearnerID INT UNIQUE,
    ProfileID INT,
    CompletionStatus VARCHAR(50),
    CustomContent VARCHAR(1000),
    AdaptiveRules VARCHAR(1000),
    FOREIGN KEY (LearnerID) REFERENCES Learner(LearnerID) ON DELETE CASCADE,
    FOREIGN KEY (ProfileID) REFERENCES PersonalizationProfiles(ProfileID)
);
GO

-- 18. Instructor Table
CREATE TABLE Instructor (
    InstructorID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100),
    LatestQualification VARCHAR(100),
    ExpertiseArea VARCHAR(100),
    Email VARCHAR(100)
);
GO

-- 19. CourseInstructor Table
CREATE TABLE CourseInstructor (
    CourseID INT,
    InstructorID INT,
    PRIMARY KEY (CourseID, InstructorID),
    FOREIGN KEY (CourseID) REFERENCES Course(CourseID),
    FOREIGN KEY (InstructorID) REFERENCES Instructor(InstructorID)
);
GO

-- 20. PathReview Table
CREATE TABLE PathReview (
    InstructorID INT,
    PathID INT,
    Feedback VARCHAR(1000),
    PRIMARY KEY (InstructorID, PathID),
    FOREIGN KEY (InstructorID) REFERENCES Instructor(InstructorID) ON DELETE CASCADE,
    FOREIGN KEY (PathID) REFERENCES LearningPath(PathID)
);
GO

-- 21. Notification Table
CREATE TABLE Notification (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Timestamp DATETIME DEFAULT GETDATE(),
    Message VARCHAR(1000),
    UrgencyLevel VARCHAR(20)
);
GO

-- 22. ReceivedNotification Table
CREATE TABLE ReceivedNotification (
    NotificationID INT,
    LearnerID INT,
    ReadStatus BIT DEFAULT 0,
    PRIMARY KEY (NotificationID, LearnerID),
    FOREIGN KEY (NotificationID) REFERENCES Notification(ID) ON DELETE CASCADE,
    FOREIGN KEY (LearnerID) REFERENCES Learner(LearnerID) ON DELETE CASCADE
);
GO

-- 23. CourseEnrollment Table
CREATE TABLE CourseEnrollment (
    EnrollmentID INT PRIMARY KEY IDENTITY(1,1),
    CourseID INT,
    LearnerID INT,
    CompletionDate DATE,
    EnrollmentDate DATE,
    Status VARCHAR(50),
    FOREIGN KEY (CourseID) REFERENCES Course(CourseID) ON DELETE CASCADE,
    FOREIGN KEY (LearnerID) REFERENCES Learner(LearnerID) ON DELETE CASCADE
);
GO

-- 24. Leaderboard Table
CREATE TABLE Leaderboard (
    BoardID INT PRIMARY KEY IDENTITY(1,1),
    Season VARCHAR(50)
);
GO

-- 25. Ranking Table
CREATE TABLE Ranking (
    BoardID INT,
    LearnerID INT,
    CourseID INT,
    Rank INT,
    TotalPoints INT,
    PRIMARY KEY (BoardID, LearnerID, CourseID),
    FOREIGN KEY (BoardID) REFERENCES Leaderboard(BoardID) ON DELETE CASCADE,
    FOREIGN KEY (LearnerID) REFERENCES Learner(LearnerID) ON DELETE CASCADE,
    FOREIGN KEY (CourseID) REFERENCES Course(CourseID) ON DELETE CASCADE
);
GO

-- 26. Badge Table
CREATE TABLE Badge (
    BadgeID INT PRIMARY KEY IDENTITY(1,1),
    Title VARCHAR(100),
    Description VARCHAR(1000),
    Criteria VARCHAR(255),
    Points INT
);
GO

-- 27. Achievement Table
CREATE TABLE Achievement (
    AchievementID INT PRIMARY KEY IDENTITY(1,1),
    LearnerID INT,
    BadgeID INT,
    Description VARCHAR(1000),
    DateEarned DATE,
    Type VARCHAR(50),
    FOREIGN KEY (LearnerID) REFERENCES Learner(LearnerID) ON DELETE CASCADE,
    FOREIGN KEY (BadgeID) REFERENCES Badge(BadgeID) ON DELETE CASCADE
);
GO

-- 28. Reward Table
CREATE TABLE Reward (
    RewardID INT PRIMARY KEY IDENTITY(1,1),
    Value INT,
    Description VARCHAR(1000),
    Type VARCHAR(50)
);
GO

-- 29. Quest Table
CREATE TABLE Quest (
    QuestID INT PRIMARY KEY IDENTITY(1,1),
    DifficultyLevel VARCHAR(50),
    Criteria VARCHAR(255),
    Description VARCHAR(1000),
    Title VARCHAR(100)
);
GO

-- 30. SkillMastery Table
CREATE TABLE SkillMastery (
    QuestID INT,
    Skill VARCHAR(50),
    PRIMARY KEY (QuestID, Skill),
    FOREIGN KEY (QuestID) REFERENCES Quest(QuestID) ON DELETE CASCADE
);
GO

-- 31. Collaborative Table
CREATE TABLE Collaborative (
    QuestID INT PRIMARY KEY,
    Deadline DATETIME,
    MaxNumParticipants INT,
    FOREIGN KEY (QuestID) REFERENCES Quest(QuestID) ON DELETE CASCADE
);
GO

-- 32. QuestReward Table
CREATE TABLE QuestReward (
    RewardID INT,
    QuestID INT,
    LearnerID INT,
    TimeEarned DATETIME,
    PRIMARY KEY (RewardID, QuestID, LearnerID),
    FOREIGN KEY (RewardID) REFERENCES Reward(RewardID) ON DELETE CASCADE,
    FOREIGN KEY (QuestID) REFERENCES Quest(QuestID) ON DELETE CASCADE,
    FOREIGN KEY (LearnerID) REFERENCES Learner(LearnerID) ON DELETE CASCADE
);
GO

-- 33. LearnersCollaboration Table
CREATE TABLE LearnersCollaboration (
    LearnerID INT,
    QuestID INT,
    PRIMARY KEY (LearnerID, QuestID),
    FOREIGN KEY (LearnerID) REFERENCES Learner(LearnerID) ON DELETE CASCADE,
    FOREIGN KEY (QuestID) REFERENCES Quest(QuestID) ON DELETE CASCADE
);
GO

-- 34. DiscussionForum Table
CREATE TABLE DiscussionForum (
    ForumID INT PRIMARY KEY IDENTITY(1,1),
    ModuleID INT,
    CourseID INT,
    Title VARCHAR(100),
    LastActive DATETIME,
    Timestamp DATETIME,
    Description VARCHAR(1000),
    FOREIGN KEY (ModuleID) REFERENCES Modules(ModuleID) ON DELETE CASCADE,
    FOREIGN KEY (CourseID) REFERENCES Course(CourseID)
);
GO

-- 35. LearnerDiscussion Table
CREATE TABLE LearnerDiscussion (
    DiscussionID INT PRIMARY KEY IDENTITY(1,1),
    ForumID INT,
    LearnerID INT,
    Post VARCHAR(1000),
    Time DATETIME,
    FOREIGN KEY (ForumID) REFERENCES DiscussionForum(ForumID),
    FOREIGN KEY (LearnerID) REFERENCES Learner(LearnerID) ON DELETE CASCADE
);
GO

-- 36. SkillProgression Table
CREATE TABLE SkillProgression (
    ID INT PRIMARY KEY IDENTITY(1,1),
    ProficiencyLevel VARCHAR(50),
    LearnerID INT,
    SkillName VARCHAR(50),
    Timestamp DATETIME,
    FOREIGN KEY (LearnerID) REFERENCES Learner(LearnerID) ON DELETE CASCADE
);
GO

-- 37. LearningGoal Table
CREATE TABLE LearningGoal (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Status VARCHAR(50),
    Deadline DATETIME,
    Description VARCHAR(1000)
);
GO

-- 38. LearnersGoals Table
CREATE TABLE LearnersGoals (
    GoalID INT,
    LearnerID INT,
    PRIMARY KEY (GoalID, LearnerID),
    FOREIGN KEY (GoalID) REFERENCES LearningGoal(ID) ON DELETE CASCADE,
    FOREIGN KEY (LearnerID) REFERENCES Learner(LearnerID) ON DELETE CASCADE
);
GO

-- 39. Survey Table
CREATE TABLE Survey (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Title VARCHAR(100)
);
GO

-- 40. SurveyQuestions Table
CREATE TABLE SurveyQuestions (
    SurveyID INT,
    Question VARCHAR(255),
    PRIMARY KEY (SurveyID, Question),
    FOREIGN KEY (SurveyID) REFERENCES Survey(ID) ON DELETE CASCADE
);
GO

-- 41. FilledSurvey Table
CREATE TABLE FilledSurvey (
    SurveyID INT,
    Question VARCHAR(255),
    LearnerID INT,
    Answer VARCHAR(1000),
    PRIMARY KEY (SurveyID, Question, LearnerID),
    FOREIGN KEY (SurveyID, Question) REFERENCES SurveyQuestions(SurveyID, Question) ON DELETE CASCADE,
    FOREIGN KEY (LearnerID) REFERENCES Learner(LearnerID) ON DELETE CASCADE
);
GO

-- 42. LearnerMastery Table
CREATE TABLE LearnerMastery (
    LearnerID INT,
    QuestID INT,
    [Completion Status] VARCHAR(50),
    PRIMARY KEY (LearnerID, QuestID),
    FOREIGN KEY (LearnerID) REFERENCES Learner(LearnerID) ON DELETE CASCADE,
    FOREIGN KEY (QuestID) REFERENCES Quest(QuestID) ON DELETE CASCADE
);
GO

-- 43. TakenAssessment Table
CREATE TABLE TakenAssessment (
    LearnerID INT,
    AssessmentID INT,
    ScoredPoint INT,
    PRIMARY KEY (LearnerID, AssessmentID),
    FOREIGN KEY (LearnerID) REFERENCES Learner(LearnerID) ON DELETE CASCADE,
    FOREIGN KEY (AssessmentID) REFERENCES Assessments(ID) ON DELETE CASCADE
);
GO
CREATE TABLE Admin (
 AdminID INT PRIMARY KEY IDENTITY,
 first_name VARCHAR(50),
 last_name VARCHAR(50),
 gender CHAR(1)
);
CREATE TABLE InstructorDiscussion (
 ForumID INT,
 InstructorID INT,
 Post VARCHAR(100),
 time DATETIME,
 PRIMARY KEY (ForumID , InstructorID, Post),
 FOREIGN KEY (ForumID) REFERENCES DiscussionForum(ForumID) ON DELETE CASCADE ON
UPDATE CASCADE,
 FOREIGN KEY (InstructorID) REFERENCES Instructor(InstructorID) ON DELETE CASCADE ON UPDATE
CASCADE
);
CREATE TABLE Users (
    id INT NOT NULL,
    password NVARCHAR(255) NOT NULL,
    user_type NVARCHAR(50) NOT NULL,
    PRIMARY KEY (id, user_type)  -- Composite primary key
);

ALTER TABLE [dbo].[Users]
ADD [email] NVARCHAR(255) NULL;
