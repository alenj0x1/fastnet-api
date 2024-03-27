using System;
using System.Collections.Generic;

namespace fastnet_api.DBModels;

public partial class Payment
{
    public int Paymentid { get; set; }

    public DateTime? Paymentdate { get; set; }

    public double Amount { get; set; }

    public string? Description { get; set; }

    public int Clientid { get; set; }

    public virtual Client Client { get; set; } = null!;
}
