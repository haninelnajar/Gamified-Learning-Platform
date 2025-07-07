using System;
using System.Collections.Generic;

namespace ML3.Models;

public partial class InstructorDiscussion
{
    public int ForumId { get; set; }

    public int InstructorId { get; set; }

    public string Post { get; set; } = null!;

    public DateTime? Time { get; set; } 

    public virtual DiscussionForum Forum { get; set; } = null!;

    public virtual Instructor Instructor { get; set; } = null!;
}
