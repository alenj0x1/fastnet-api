using System;
using System.Collections.Generic;

namespace fastnet_api.DBModels;

public partial class Contract
{
    public int Contracit { get; set; }

    public DateTime Startdate { get; set; }

    public DateTime Enddate { get; set; }

    public int ServiceServiceid { get; set; }

    public string StatuscontractStatusid { get; set; } = null!;

    public int ClientClientid { get; set; }

    public int MethodpaymentMethodpaymentid { get; set; }

    public virtual Client ClientClient { get; set; } = null!;

    public virtual Methodpayment MethodpaymentMethodpayment { get; set; } = null!;

    public virtual Service ServiceService { get; set; } = null!;

    public virtual Statuscontract StatuscontractStatus { get; set; } = null!;
}
