using System;
using System.Collections.Generic;

namespace fastnet_api.DBModels;

public partial class Turn
{
    public int Turnid { get; set; }

    public int? Turnstatusid { get; set; }

    public DateTime? Date { get; set; }

    public int CashCashid { get; set; }

    public int Usergestorid { get; set; }

    public virtual ICollection<Attention> Attentions { get; set; } = new List<Attention>();

    public virtual Cash CashCash { get; set; } = null!;

    public virtual Turnstatus? Turnstatus { get; set; }
}
