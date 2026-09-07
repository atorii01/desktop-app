using System;
using System.Collections.Generic;

namespace LatihanAPI;

public partial class Book
{
    public string Id { get; set; } = null!;

    public string BookTitle { get; set; } = null!;

    public string Author { get; set; } = null!;

    public string Publisher { get; set; } = null!;

    public int Stock { get; set; }

    public int Price { get; set; }

    public string IdUser { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
