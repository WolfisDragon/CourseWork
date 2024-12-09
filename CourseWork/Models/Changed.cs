using System;
using System.Collections.Generic;

namespace CourseWork.Models;

public partial class Changed
{
    public int Id { get; set; }

    public int Stuffid { get; set; }

    public int Cabinetout { get; set; }

    public int Cabinetto { get; set; }

    public virtual Cabinet CabinetoutNavigation { get; set; } = null!;

    public virtual Cabinet CabinettoNavigation { get; set; } = null!;

    public virtual Stuff Stuff { get; set; } = null!;
}
