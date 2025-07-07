using System;
using System.Collections.Generic;

namespace ML3.Models;

public partial class Takenassessment
{
    public int Id { get; set; }

    public int LearnerId { get; set; }

    public int? ScoredPoint { get; set; }

    public virtual Assessment IdNavigation { get; set; } = null!;

    public virtual Learner Learner { get; set; } = null!;
}
