using System;
using System.Collections.Generic;

namespace fastnet_api.DBModels;

public partial class Turnstatus
{
    public int Statusid { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Turn> Turns { get; set; } = new List<Turn>();
}
