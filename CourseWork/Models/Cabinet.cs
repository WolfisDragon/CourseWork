using System;
using System.Collections.Generic;

namespace CourseWork.Models;

public partial class Cabinet
{
    public int Id { get; set; }

    public string Number { get; set; } = null!;

    public virtual ICollection<Changed> ChangedCabinetoutNavigations { get; set; } = new List<Changed>();

    public virtual ICollection<Changed> ChangedCabinettoNavigations { get; set; } = new List<Changed>();

    public virtual ICollection<Stuff> Stuffs { get; set; } = new List<Stuff>();
}
