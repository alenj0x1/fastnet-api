using System;
using System.Collections.Generic;

namespace fastnet_api.DBModels;

public partial class Service
{
    public int Serviceid { get; set; }

    public string Servicename { get; set; } = null!;

    public string Servicedescription { get; set; } = null!;

    public string Price { get; set; } = null!;

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual ICollection<Device> Devices { get; set; } = new List<Device>();
}
