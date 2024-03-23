using System;
using System.Collections.Generic;

namespace fastnet_api.DBModels;

public partial class Attentiontype
{
    public string Attentiontypeid { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Attention> Attentions { get; set; } = new List<Attention>();
}
