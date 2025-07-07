using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ML3.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    last_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    gender = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Admin__719FE4E84373BE7D", x => x.AdminID);
                });

            migrationBuilder.CreateTable(
                name: "Badge",
                columns: table => new
                {
                    BadgeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    criteria = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    points = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Badge__1918237CD9B99B77", x => x.BadgeID);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    learning_objective = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    credit_points = table.Column<int>(type: "int", nullable: true),
                    difficulty_level = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Course__C92D7187CDA610AF", x => x.CourseID);
                });

            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    InstructorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    latest_qualification = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    expertise_area = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Instruct__9D010B7B692BC7B8", x => x.InstructorID);
                });

            migrationBuilder.CreateTable(
                name: "Leaderboard",
                columns: table => new
                {
                    BoardID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    season = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Leaderbo__F9646BD29EAF30AB", x => x.BoardID);
                });

            migrationBuilder.CreateTable(
                name: "Learner",
                columns: table => new
                {
                    LearnerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    last_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    gender = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    birth_date = table.Column<DateOnly>(type: "date", nullable: true),
                    country = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    cultural_background = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Learner__67ABFCFA790F756C", x => x.LearnerID);
                });

            migrationBuilder.CreateTable(
                name: "Learning_goal",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    deadline = table.Column<DateOnly>(type: "date", nullable: true),
                    description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Learning__3214EC27E7E331DF", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    time_stamp = table.Column<DateTime>(type: "datetime", nullable: true),
                    message = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    urgency_level = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ReadStatus = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Notifica__3214EC271FB01112", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Quest",
                columns: table => new
                {
                    QuestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    difficulty_level = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    criteria = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    title = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Quest__B6619ACBA922E3A7", x => x.QuestID);
                });

            migrationBuilder.CreateTable(
                name: "Reward",
                columns: table => new
                {
                    RewardID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    value = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reward__82501599FBB65068", x => x.RewardID);
                });

            migrationBuilder.CreateTable(
                name: "Survey",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Survey__3214EC27DCC63DE3", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CoursePre_requisites",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    Pre_requisistes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CoursePr__C4C4D68F9903C5B4", x => new { x.CourseID, x.Pre_requisistes });
                    table.ForeignKey(
                        name: "FK__CoursePre__Cours__47DBAE45",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__CoursePre__Pre_r__48CFD27E",
                        column: x => x.Pre_requisistes,
                        principalTable: "Course",
                        principalColumn: "CourseID");
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    ModuleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    difficulty = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    contentURL = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Modules__47E6A09F4411C8CA", x => new { x.ModuleID, x.CourseID });
                    table.ForeignKey(
                        name: "FK__Modules__CourseI__4BAC3F29",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teaches",
                columns: table => new
                {
                    InstructorID = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Teaches__F193DC6360D1BDF6", x => new { x.InstructorID, x.CourseID });
                    table.ForeignKey(
                        name: "FK__Teaches__CourseI__797309D9",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Teaches__Instruc__787EE5A0",
                        column: x => x.InstructorID,
                        principalTable: "Instructor",
                        principalColumn: "InstructorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Achievement",
                columns: table => new
                {
                    AchievementID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LearnerID = table.Column<int>(type: "int", nullable: true),
                    BadgeID = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    date_earned = table.Column<DateOnly>(type: "date", nullable: true),
                    type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Achievem__276330E0FDE870D1", x => x.AchievementID);
                    table.ForeignKey(
                        name: "FK__Achieveme__Badge__1CBC4616",
                        column: x => x.BadgeID,
                        principalTable: "Badge",
                        principalColumn: "BadgeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Achieveme__Learn__1BC821DD",
                        column: x => x.LearnerID,
                        principalTable: "Learner",
                        principalColumn: "LearnerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Course_enrollment",
                columns: table => new
                {
                    EnrollmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseID = table.Column<int>(type: "int", nullable: true),
                    LearnerID = table.Column<int>(type: "int", nullable: true),
                    completion_date = table.Column<DateOnly>(type: "date", nullable: true),
                    enrollment_date = table.Column<DateOnly>(type: "date", nullable: true),
                    status = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Course_e__7F6877FBE2395291", x => x.EnrollmentID);
                    table.ForeignKey(
                        name: "FK__Course_en__Cours__74AE54BC",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Course_en__Learn__75A278F5",
                        column: x => x.LearnerID,
                        principalTable: "Learner",
                        principalColumn: "LearnerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LearningPreference",
                columns: table => new
                {
                    LearnerID = table.Column<int>(type: "int", nullable: false),
                    preference = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Learning__6032E158C24F170D", x => new { x.LearnerID, x.preference });
                    table.ForeignKey(
                        name: "FK__LearningP__Learn__3D5E1FD2",
                        column: x => x.LearnerID,
                        principalTable: "Learner",
                        principalColumn: "LearnerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonalizationProfiles",
                columns: table => new
                {
                    LearnerID = table.Column<int>(type: "int", nullable: false),
                    ProfileID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Preferred_content_type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    emotional_state = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    personality_type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Personal__353B3472C2DBAFEB", x => new { x.LearnerID, x.ProfileID });
                    table.ForeignKey(
                        name: "FK__Personali__Learn__403A8C7D",
                        column: x => x.LearnerID,
                        principalTable: "Learner",
                        principalColumn: "LearnerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ranking",
                columns: table => new
                {
                    BoardID = table.Column<int>(type: "int", nullable: false),
                    LearnerID = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: true),
                    rank = table.Column<int>(type: "int", nullable: true),
                    total_points = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ranking__4F1ED41DCC4FB712", x => new { x.BoardID, x.LearnerID });
                    table.ForeignKey(
                        name: "FK__Ranking__BoardID__7E37BEF6",
                        column: x => x.BoardID,
                        principalTable: "Leaderboard",
                        principalColumn: "BoardID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Ranking__CourseI__00200768",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Ranking__Learner__7F2BE32F",
                        column: x => x.LearnerID,
                        principalTable: "Learner",
                        principalColumn: "LearnerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    LearnerID = table.Column<int>(type: "int", nullable: false),
                    skill = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Skills__C45BDEA5515E9CB3", x => new { x.LearnerID, x.skill });
                    table.ForeignKey(
                        name: "FK__Skills__LearnerI__3A81B327",
                        column: x => x.LearnerID,
                        principalTable: "Learner",
                        principalColumn: "LearnerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LearnersGoals",
                columns: table => new
                {
                    GoalID = table.Column<int>(type: "int", nullable: false),
                    LearnerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Learners__3C3540FE3C198A0C", x => new { x.GoalID, x.LearnerID });
                    table.ForeignKey(
                        name: "FK__LearnersG__GoalI__04E4BC85",
                        column: x => x.GoalID,
                        principalTable: "Learning_goal",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__LearnersG__Learn__05D8E0BE",
                        column: x => x.LearnerID,
                        principalTable: "Learner",
                        principalColumn: "LearnerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReceivedNotification",
                columns: table => new
                {
                    NotificationID = table.Column<int>(type: "int", nullable: false),
                    LearnerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Received__96B591FD764F263E", x => new { x.NotificationID, x.LearnerID });
                    table.ForeignKey(
                        name: "FK__ReceivedN__Learn__14270015",
                        column: x => x.LearnerID,
                        principalTable: "Learner",
                        principalColumn: "LearnerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__ReceivedN__Notif__1332DBDC",
                        column: x => x.NotificationID,
                        principalTable: "Notification",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Collaborative",
                columns: table => new
                {
                    QuestID = table.Column<int>(type: "int", nullable: true),
                    deadline = table.Column<DateOnly>(type: "date", nullable: true),
                    max_num_participants = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__Collabora__Quest__25518C17",
                        column: x => x.QuestID,
                        principalTable: "Quest",
                        principalColumn: "QuestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LearnerMastery",
                columns: table => new
                {
                    QuestID = table.Column<int>(type: "int", nullable: false),
                    LearnerID = table.Column<int>(type: "int", nullable: false),
                    completionStatus = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LearnerM__001B2504A13579F6", x => new { x.QuestID, x.LearnerID });
                    table.ForeignKey(
                        name: "FK__LearnerMa__Learn__2BFE89A6",
                        column: x => x.LearnerID,
                        principalTable: "Learner",
                        principalColumn: "LearnerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__LearnerMa__Quest__2CF2ADDF",
                        column: x => x.QuestID,
                        principalTable: "Quest",
                        principalColumn: "QuestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LearnersCollaboration",
                columns: table => new
                {
                    QuestID = table.Column<int>(type: "int", nullable: false),
                    LearnerID = table.Column<int>(type: "int", nullable: false),
                    completionStatus = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Learners__001B250403DDCF3C", x => new { x.QuestID, x.LearnerID });
                    table.ForeignKey(
                        name: "FK__LearnersC__Learn__29221CFB",
                        column: x => x.LearnerID,
                        principalTable: "Learner",
                        principalColumn: "LearnerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__LearnersC__Quest__282DF8C2",
                        column: x => x.QuestID,
                        principalTable: "Quest",
                        principalColumn: "QuestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skill_Mastery",
                columns: table => new
                {
                    QuestID = table.Column<int>(type: "int", nullable: false),
                    skill = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Skill_Ma__1591B8948BDB2C25", x => new { x.QuestID, x.skill });
                    table.ForeignKey(
                        name: "FK__Skill_Mas__Quest__236943A5",
                        column: x => x.QuestID,
                        principalTable: "Quest",
                        principalColumn: "QuestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestReward",
                columns: table => new
                {
                    RewardID = table.Column<int>(type: "int", nullable: false),
                    QuestID = table.Column<int>(type: "int", nullable: false),
                    LearnerID = table.Column<int>(type: "int", nullable: false),
                    Time_earned = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__QuestRew__D251A7C90144D9B0", x => new { x.RewardID, x.QuestID, x.LearnerID });
                    table.ForeignKey(
                        name: "FK__QuestRewa__Learn__3864608B",
                        column: x => x.LearnerID,
                        principalTable: "Learner",
                        principalColumn: "LearnerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__QuestRewa__Quest__37703C52",
                        column: x => x.QuestID,
                        principalTable: "Quest",
                        principalColumn: "QuestID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__QuestRewa__Rewar__367C1819",
                        column: x => x.RewardID,
                        principalTable: "Reward",
                        principalColumn: "RewardID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurveyQuestions",
                columns: table => new
                {
                    SurveyID = table.Column<int>(type: "int", nullable: false),
                    Question = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SurveyQu__23FB983B81192395", x => new { x.SurveyID, x.Question });
                    table.ForeignKey(
                        name: "FK__SurveyQue__Surve__0A9D95DB",
                        column: x => x.SurveyID,
                        principalTable: "Survey",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assessments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleID = table.Column<int>(type: "int", nullable: true),
                    CourseID = table.Column<int>(type: "int", nullable: true),
                    type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    total_marks = table.Column<int>(type: "int", nullable: true),
                    passing_marks = table.Column<int>(type: "int", nullable: true),
                    criteria = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    weightage = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    title = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Assessme__3214EC279C191165", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Assessments__571DF1D5",
                        columns: x => new { x.ModuleID, x.CourseID },
                        principalTable: "Modules",
                        principalColumns: new[] { "ModuleID", "CourseID" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContentLibrary",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleID = table.Column<int>(type: "int", nullable: true),
                    CourseID = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    metadata = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    content_URL = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ContentL__3214EC27E26A7EF5", x => x.ID);
                    table.ForeignKey(
                        name: "FK__ContentLibrary__5441852A",
                        columns: x => new { x.ModuleID, x.CourseID },
                        principalTable: "Modules",
                        principalColumns: new[] { "ModuleID", "CourseID" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Discussion_forum",
                columns: table => new
                {
                    forumID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleID = table.Column<int>(type: "int", nullable: true),
                    CourseID = table.Column<int>(type: "int", nullable: true),
                    title = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    last_active = table.Column<DateTime>(type: "datetime", nullable: true),
                    time_stamp = table.Column<DateTime>(type: "datetime", nullable: true),
                    description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Discussi__BBA7A4402732E6FC", x => x.forumID);
                    table.ForeignKey(
                        name: "FK__Discussion_forum__2FCF1A8A",
                        columns: x => new { x.ModuleID, x.CourseID },
                        principalTable: "Modules",
                        principalColumns: new[] { "ModuleID", "CourseID" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Learning_activities",
                columns: table => new
                {
                    ActivityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleID = table.Column<int>(type: "int", nullable: true),
                    CourseID = table.Column<int>(type: "int", nullable: true),
                    activity_type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    instruction_details = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Max_points = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Learning__45F4A7F1B1FF17C5", x => x.ActivityID);
                    table.ForeignKey(
                        name: "FK__Learning_activit__5DCAEF64",
                        columns: x => new { x.ModuleID, x.CourseID },
                        principalTable: "Modules",
                        principalColumns: new[] { "ModuleID", "CourseID" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModuleContent",
                columns: table => new
                {
                    ModuleID = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    content_type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ModuleCo__402E75DAAEB65F75", x => new { x.ModuleID, x.CourseID, x.content_type });
                    table.ForeignKey(
                        name: "FK__ModuleContent__5165187F",
                        columns: x => new { x.ModuleID, x.CourseID },
                        principalTable: "Modules",
                        principalColumns: new[] { "ModuleID", "CourseID" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Target_traits",
                columns: table => new
                {
                    ModuleID = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    Trait = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Target_t__4E005E4C0CFB6BD5", x => new { x.ModuleID, x.CourseID, x.Trait });
                    table.ForeignKey(
                        name: "FK__Target_traits__4E88ABD4",
                        columns: x => new { x.ModuleID, x.CourseID },
                        principalTable: "Modules",
                        principalColumns: new[] { "ModuleID", "CourseID" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HealthCondition",
                columns: table => new
                {
                    LearnerID = table.Column<int>(type: "int", nullable: false),
                    ProfileID = table.Column<int>(type: "int", nullable: false),
                    condition = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__HealthCo__930320B02C9D864E", x => new { x.LearnerID, x.ProfileID, x.condition });
                    table.ForeignKey(
                        name: "FK__HealthCondition__4316F928",
                        columns: x => new { x.LearnerID, x.ProfileID },
                        principalTable: "PersonalizationProfiles",
                        principalColumns: new[] { "LearnerID", "ProfileID" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Learning_path",
                columns: table => new
                {
                    pathID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LearnerID = table.Column<int>(type: "int", nullable: true),
                    ProfileID = table.Column<int>(type: "int", nullable: true),
                    completion_status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    custom_content = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    adaptive_rules = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Learning__BFB8200AF2A88AA2", x => x.pathID);
                    table.ForeignKey(
                        name: "FK__Learning_path__68487DD7",
                        columns: x => new { x.LearnerID, x.ProfileID },
                        principalTable: "PersonalizationProfiles",
                        principalColumns: new[] { "LearnerID", "ProfileID" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillProgression",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    proficiency_level = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    LearnerID = table.Column<int>(type: "int", nullable: true),
                    skill_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    timestamp = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SkillPro__3214EC2762567287", x => x.ID);
                    table.ForeignKey(
                        name: "FK__SkillProgression__18EBB532",
                        columns: x => new { x.LearnerID, x.skill_name },
                        principalTable: "Skills",
                        principalColumns: new[] { "LearnerID", "skill" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilledSurvey",
                columns: table => new
                {
                    SurveyID = table.Column<int>(type: "int", nullable: false),
                    Question = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    LearnerID = table.Column<int>(type: "int", nullable: false),
                    Answer = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FilledSu__D89C33C749D1202F", x => new { x.SurveyID, x.Question, x.LearnerID });
                    table.ForeignKey(
                        name: "FK__FilledSur__Learn__0E6E26BF",
                        column: x => x.LearnerID,
                        principalTable: "Learner",
                        principalColumn: "LearnerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__FilledSurvey__0D7A0286",
                        columns: x => new { x.SurveyID, x.Question },
                        principalTable: "SurveyQuestions",
                        principalColumns: new[] { "SurveyID", "Question" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Takenassessment",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    LearnerID = table.Column<int>(type: "int", nullable: false),
                    scoredPoint = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Takenass__846E53E82D440181", x => new { x.ID, x.LearnerID });
                    table.ForeignKey(
                        name: "FK__Takenasse__Learn__59FA5E80",
                        column: x => x.LearnerID,
                        principalTable: "Learner",
                        principalColumn: "LearnerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Takenassessm__ID__5AEE82B9",
                        column: x => x.ID,
                        principalTable: "Assessments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstructorDiscussion",
                columns: table => new
                {
                    forumID = table.Column<int>(type: "int", nullable: false),
                    InstructorID = table.Column<int>(type: "int", nullable: false),
                    Post = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorDiscussion", x => new { x.forumID, x.InstructorID });
                    table.ForeignKey(
                        name: "FK__Instructo__Instr__3D2915A8",
                        column: x => x.InstructorID,
                        principalTable: "Instructor",
                        principalColumn: "InstructorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Instructo__forum__3C34F16F",
                        column: x => x.forumID,
                        principalTable: "Discussion_forum",
                        principalColumn: "forumID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LearnerDiscussion",
                columns: table => new
                {
                    ForumID = table.Column<int>(type: "int", nullable: false),
                    LearnerID = table.Column<int>(type: "int", nullable: false),
                    Post = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LearnerD__FBCECC4A844C76B1", x => new { x.ForumID, x.LearnerID, x.Post });
                    table.ForeignKey(
                        name: "FK__LearnerDi__Forum__32AB8735",
                        column: x => x.ForumID,
                        principalTable: "Discussion_forum",
                        principalColumn: "forumID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__LearnerDi__Learn__339FAB6E",
                        column: x => x.LearnerID,
                        principalTable: "Learner",
                        principalColumn: "LearnerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Emotional_feedback",
                columns: table => new
                {
                    FeedbackID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LearnerID = table.Column<int>(type: "int", nullable: true),
                    ActivityID = table.Column<int>(type: "int", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "datetime", nullable: true),
                    emotional_state = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Emotiona__6A4BEDF6383708B9", x => x.FeedbackID);
                    table.ForeignKey(
                        name: "FK__Emotional__Activ__656C112C",
                        column: x => x.ActivityID,
                        principalTable: "Learning_activities",
                        principalColumn: "ActivityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Emotional__Learn__6477ECF3",
                        column: x => x.LearnerID,
                        principalTable: "Learner",
                        principalColumn: "LearnerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Interaction_log",
                columns: table => new
                {
                    LogID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    activity_ID = table.Column<int>(type: "int", nullable: true),
                    LearnerID = table.Column<int>(type: "int", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "datetime", nullable: true),
                    action_type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Interact__5E5499A802D4A7FB", x => x.LogID);
                    table.ForeignKey(
                        name: "FK__Interacti__Learn__619B8048",
                        column: x => x.LearnerID,
                        principalTable: "Learner",
                        principalColumn: "LearnerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Interacti__activ__60A75C0F",
                        column: x => x.activity_ID,
                        principalTable: "Learning_activities",
                        principalColumn: "ActivityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pathreview",
                columns: table => new
                {
                    InstructorID = table.Column<int>(type: "int", nullable: false),
                    PathID = table.Column<int>(type: "int", nullable: false),
                    review = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Pathrevi__11D776B8E322469B", x => new { x.InstructorID, x.PathID });
                    table.ForeignKey(
                        name: "FK__Pathrevie__Instr__6D0D32F4",
                        column: x => x.InstructorID,
                        principalTable: "Instructor",
                        principalColumn: "InstructorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Pathrevie__PathI__6E01572D",
                        column: x => x.PathID,
                        principalTable: "Learning_path",
                        principalColumn: "pathID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Emotionalfeedback_review",
                columns: table => new
                {
                    FeedbackID = table.Column<int>(type: "int", nullable: false),
                    InstructorID = table.Column<int>(type: "int", nullable: false),
                    review = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Emotiona__C39BFD41C97ED4EB", x => new { x.FeedbackID, x.InstructorID });
                    table.ForeignKey(
                        name: "FK__Emotional__Feedb__70DDC3D8",
                        column: x => x.FeedbackID,
                        principalTable: "Emotional_feedback",
                        principalColumn: "FeedbackID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Emotional__Instr__71D1E811",
                        column: x => x.InstructorID,
                        principalTable: "Instructor",
                        principalColumn: "InstructorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Achievement_BadgeID",
                table: "Achievement",
                column: "BadgeID");

            migrationBuilder.CreateIndex(
                name: "IX_Achievement_LearnerID",
                table: "Achievement",
                column: "LearnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_ModuleID_CourseID",
                table: "Assessments",
                columns: new[] { "ModuleID", "CourseID" });

            migrationBuilder.CreateIndex(
                name: "IX_Collaborative_QuestID",
                table: "Collaborative",
                column: "QuestID");

            migrationBuilder.CreateIndex(
                name: "IX_ContentLibrary_ModuleID_CourseID",
                table: "ContentLibrary",
                columns: new[] { "ModuleID", "CourseID" });

            migrationBuilder.CreateIndex(
                name: "IX_Course_enrollment_CourseID",
                table: "Course_enrollment",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Course_enrollment_LearnerID",
                table: "Course_enrollment",
                column: "LearnerID");

            migrationBuilder.CreateIndex(
                name: "IX_CoursePre_requisites_Pre_requisistes",
                table: "CoursePre_requisites",
                column: "Pre_requisistes");

            migrationBuilder.CreateIndex(
                name: "IX_Discussion_forum_ModuleID_CourseID",
                table: "Discussion_forum",
                columns: new[] { "ModuleID", "CourseID" });

            migrationBuilder.CreateIndex(
                name: "IX_Emotional_feedback_ActivityID",
                table: "Emotional_feedback",
                column: "ActivityID");

            migrationBuilder.CreateIndex(
                name: "IX_Emotional_feedback_LearnerID",
                table: "Emotional_feedback",
                column: "LearnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Emotionalfeedback_review_InstructorID",
                table: "Emotionalfeedback_review",
                column: "InstructorID");

            migrationBuilder.CreateIndex(
                name: "IX_FilledSurvey_LearnerID",
                table: "FilledSurvey",
                column: "LearnerID");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorDiscussion_InstructorID",
                table: "InstructorDiscussion",
                column: "InstructorID");

            migrationBuilder.CreateIndex(
                name: "IX_Interaction_log_activity_ID",
                table: "Interaction_log",
                column: "activity_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Interaction_log_LearnerID",
                table: "Interaction_log",
                column: "LearnerID");

            migrationBuilder.CreateIndex(
                name: "IX_LearnerDiscussion_LearnerID",
                table: "LearnerDiscussion",
                column: "LearnerID");

            migrationBuilder.CreateIndex(
                name: "IX_LearnerMastery_LearnerID",
                table: "LearnerMastery",
                column: "LearnerID");

            migrationBuilder.CreateIndex(
                name: "IX_LearnersCollaboration_LearnerID",
                table: "LearnersCollaboration",
                column: "LearnerID");

            migrationBuilder.CreateIndex(
                name: "IX_LearnersGoals_LearnerID",
                table: "LearnersGoals",
                column: "LearnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Learning_activities_ModuleID_CourseID",
                table: "Learning_activities",
                columns: new[] { "ModuleID", "CourseID" });

            migrationBuilder.CreateIndex(
                name: "IX_Learning_path_LearnerID_ProfileID",
                table: "Learning_path",
                columns: new[] { "LearnerID", "ProfileID" });

            migrationBuilder.CreateIndex(
                name: "IX_Modules_CourseID",
                table: "Modules",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Pathreview_PathID",
                table: "Pathreview",
                column: "PathID");

            migrationBuilder.CreateIndex(
                name: "IX_QuestReward_LearnerID",
                table: "QuestReward",
                column: "LearnerID");

            migrationBuilder.CreateIndex(
                name: "IX_QuestReward_QuestID",
                table: "QuestReward",
                column: "QuestID");

            migrationBuilder.CreateIndex(
                name: "IX_Ranking_CourseID",
                table: "Ranking",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Ranking_LearnerID",
                table: "Ranking",
                column: "LearnerID");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivedNotification_LearnerID",
                table: "ReceivedNotification",
                column: "LearnerID");

            migrationBuilder.CreateIndex(
                name: "IX_SkillProgression_LearnerID_skill_name",
                table: "SkillProgression",
                columns: new[] { "LearnerID", "skill_name" });

            migrationBuilder.CreateIndex(
                name: "IX_Takenassessment_LearnerID",
                table: "Takenassessment",
                column: "LearnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Teaches_CourseID",
                table: "Teaches",
                column: "CourseID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Achievement");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Collaborative");

            migrationBuilder.DropTable(
                name: "ContentLibrary");

            migrationBuilder.DropTable(
                name: "Course_enrollment");

            migrationBuilder.DropTable(
                name: "CoursePre_requisites");

            migrationBuilder.DropTable(
                name: "Emotionalfeedback_review");

            migrationBuilder.DropTable(
                name: "FilledSurvey");

            migrationBuilder.DropTable(
                name: "HealthCondition");

            migrationBuilder.DropTable(
                name: "InstructorDiscussion");

            migrationBuilder.DropTable(
                name: "Interaction_log");

            migrationBuilder.DropTable(
                name: "LearnerDiscussion");

            migrationBuilder.DropTable(
                name: "LearnerMastery");

            migrationBuilder.DropTable(
                name: "LearnersCollaboration");

            migrationBuilder.DropTable(
                name: "LearnersGoals");

            migrationBuilder.DropTable(
                name: "LearningPreference");

            migrationBuilder.DropTable(
                name: "ModuleContent");

            migrationBuilder.DropTable(
                name: "Pathreview");

            migrationBuilder.DropTable(
                name: "QuestReward");

            migrationBuilder.DropTable(
                name: "Ranking");

            migrationBuilder.DropTable(
                name: "ReceivedNotification");

            migrationBuilder.DropTable(
                name: "Skill_Mastery");

            migrationBuilder.DropTable(
                name: "SkillProgression");

            migrationBuilder.DropTable(
                name: "Takenassessment");

            migrationBuilder.DropTable(
                name: "Target_traits");

            migrationBuilder.DropTable(
                name: "Teaches");

            migrationBuilder.DropTable(
                name: "Badge");

            migrationBuilder.DropTable(
                name: "Emotional_feedback");

            migrationBuilder.DropTable(
                name: "SurveyQuestions");

            migrationBuilder.DropTable(
                name: "Discussion_forum");

            migrationBuilder.DropTable(
                name: "Learning_goal");

            migrationBuilder.DropTable(
                name: "Learning_path");

            migrationBuilder.DropTable(
                name: "Reward");

            migrationBuilder.DropTable(
                name: "Leaderboard");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "Quest");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Assessments");

            migrationBuilder.DropTable(
                name: "Instructor");

            migrationBuilder.DropTable(
                name: "Learning_activities");

            migrationBuilder.DropTable(
                name: "Survey");

            migrationBuilder.DropTable(
                name: "PersonalizationProfiles");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "Learner");

            migrationBuilder.DropTable(
                name: "Course");
        }
    }
}
