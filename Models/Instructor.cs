﻿using System;
using System.Collections.Generic;

namespace ML3.Models;

public partial class Instructor
{
    public int InstructorId { get; set; }

    public string? Name { get; set; }

    public string? LatestQualification { get; set; }

    public string? ExpertiseArea { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<EmotionalfeedbackReview> EmotionalfeedbackReviews { get; set; } = new List<EmotionalfeedbackReview>();

    public virtual ICollection<InstructorDiscussion> InstructorDiscussions { get; set; } = new List<InstructorDiscussion>();

    public virtual ICollection<Pathreview> Pathreviews { get; set; } = new List<Pathreview>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
