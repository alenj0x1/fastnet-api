using System;
using System.Collections.Generic;

namespace fastnet_api.DBModels;

public partial class Client
{
    public int Clientid { get; set; }

    public string Name { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Identification { get; set; } = null!;

    public string? Email { get; set; }

    public string? Phonenumber { get; set; }

    public string Address { get; set; } = null!;

    public string Referenceaddress { get; set; } = null!;

    public virtual ICollection<Attention> Attentions { get; set; } = new List<Attention>();

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
