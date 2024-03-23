using System;
using System.Collections.Generic;

namespace fastnet_api.DBModels;

public partial class Userstatus
{
    public string Statusid { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
