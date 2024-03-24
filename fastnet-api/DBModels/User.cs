using System;
using System.Collections.Generic;

namespace fastnet_api.DBModels;

public partial class User
{
    public int Userid { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int RolRolid { get; set; }

    public DateTime? Creationdate { get; set; }

    public int? UserstatusStatusid { get; set; }

    public virtual ICollection<HistoryRefreshToken> HistoryRefreshTokens { get; set; } = new List<HistoryRefreshToken>();

    public virtual Rol RolRol { get; set; } = null!;

    public virtual Userstatus? UserstatusStatus { get; set; }
}
