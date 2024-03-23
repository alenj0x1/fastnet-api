using System;
using System.Collections.Generic;

namespace fastnet_api.DBModels;

public partial class Cash
{
    public int Cashid { get; set; }

    public string Cashdescription { get; set; } = null!;

    public string Active { get; set; } = null!;

    public virtual ICollection<Turn> Turns { get; set; } = new List<Turn>();
}
