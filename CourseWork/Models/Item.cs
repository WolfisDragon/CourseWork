using System;
using System.Collections.Generic;

namespace CourseWork.Models;

public partial class Item
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Stuff> Stuffs { get; set; } = new List<Stuff>();
}
