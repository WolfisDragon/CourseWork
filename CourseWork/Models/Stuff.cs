using System;
using System.Collections.Generic;

namespace CourseWork.Models;

public partial class Stuff
{
    public int Id { get; set; }

    public int Itemid { get; set; }

    public int Cabinetid { get; set; }

    public int Statusid { get; set; }

    public virtual Cabinet Cabinet { get; set; } = null!;

    public virtual ICollection<Changed> Changeds { get; set; } = new List<Changed>();

    public virtual Item Item { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;
}
