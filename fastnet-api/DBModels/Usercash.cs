using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace fastnet_api.DBModels;

public partial class Usercash
{
    [Key]
    public int UserUserid { get; set; }

    public int CashCashid { get; set; }

    public virtual Cash CashCash { get; set; } = null!;

    public virtual User UserUser { get; set; } = null!;
}
