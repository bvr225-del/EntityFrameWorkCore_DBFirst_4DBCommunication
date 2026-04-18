using System;
using System.Collections.Generic;

namespace EntityFrameWorkCore_DBFirst_4DBCommunication.MidlandModels;

public partial class Order
{
    public int Orderid { get; set; }

    public string? Ordername { get; set; }

    public string? Orderlocation { get; set; }
}
