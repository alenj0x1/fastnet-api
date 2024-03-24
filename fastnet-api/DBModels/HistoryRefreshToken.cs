using System;
using System.Collections.Generic;

namespace fastnet_api.DBModels;

public partial class HistoryRefreshToken
{
    public int Historytokenid { get; set; }

    public int? Userid { get; set; }

    public string? Token { get; set; }

    public string? Refreshtoken { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Expire { get; set; }

    public bool? Isactive { get; set; }

    public virtual User? User { get; set; }
}
