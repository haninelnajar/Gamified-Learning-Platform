﻿using System;
using System.Collections.Generic;

namespace ML3.Models;

public partial class LearningPreference
{
    public int LearnerId { get; set; }

    public string Preference { get; set; } = null!;

    public virtual Learner Learner { get; set; } = null!;
}
