using System;
using System.Collections.Generic;

namespace fastnet_api.DBModels;

public partial class Cash
{
    public int Cashid { get; set; }

    public string? Cashdescription { get; set; }

    public bool? Active { get; set; }

    public virtual ICollection<Turn> Turns { get; set; } = new List<Turn>();
}
