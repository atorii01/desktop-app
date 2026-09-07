using System;
using System.Collections.Generic;

namespace LatihanAPI;

public partial class Role
{
    public string Id { get; set; } = null!;

    public string Title { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
