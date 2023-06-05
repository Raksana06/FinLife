using System;
using System.Collections.Generic;

namespace FinLife.Models;

public partial class User
{
    public string EmailId { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;
}
