using System;
using System.Collections.Generic;

namespace ML3.Models;

public partial class SkillMastery
{
    public int QuestId { get; set; }

    public string Skill { get; set; } = null!;

    public virtual Quest Quest { get; set; } = null!;
}
