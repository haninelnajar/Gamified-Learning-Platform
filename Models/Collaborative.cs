using System;
using System.Collections.Generic;

namespace ML3.Models;

public partial class Collaborative
{
    public int? QuestId { get; set; }

    public DateOnly? Deadline { get; set; }

    public int? MaxNumParticipants { get; set; }

    public virtual Quest? Quest { get; set; }
}
