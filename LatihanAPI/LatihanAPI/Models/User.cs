using System;
using System.Collections.Generic;

namespace LatihanAPI.Models;

public partial class User
{
    public string Id { get; set; } = null!;

    public string RolesId { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordUser { get; set; } = null!;

    public string NameUser { get; set; } = null!;

    public DateOnly Birthdate { get; set; }

    public string StatusUser { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    public virtual Role Roles { get; set; } = null!;
}
