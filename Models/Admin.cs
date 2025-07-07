using System;
using System.Collections.Generic;

namespace ML3.Models;

public partial class Admin
{
    public int AdminId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Gender { get; set; }

    public string? Password { get; set; }
}
