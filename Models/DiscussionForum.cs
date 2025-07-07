using System;
using System.Collections.Generic;

namespace ML3.Models;

public partial class DiscussionForum
{
    public int ForumId { get; set; }

    public int? ModuleId { get; set; }

    public int? CourseId { get; set; }

    public string? Title { get; set; }

    public DateTime? LastActive { get; set; }

    public DateTime? TimeStamp { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<InstructorDiscussion> InstructorDiscussions { get; set; } = new List<InstructorDiscussion>();

    public virtual ICollection<LearnerDiscussion> LearnerDiscussions { get; set; } = new List<LearnerDiscussion>();

    public virtual Module? Module { get; set; }

    public virtual Course Course { get; set; }
}