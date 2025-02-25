using System;
using System.Collections.Generic;

namespace Model_Lec3__25_2_.Models;

public partial class Register
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? RePassword { get; set; }
}
