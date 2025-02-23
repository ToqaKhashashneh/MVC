using System;
using System.Collections.Generic;

namespace Model_Lec1.Models;

public partial class Department
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public decimal? Budget { get; set; }

    public string? Location { get; set; }
}
