using System;
using System.Collections.Generic;

namespace EntityFrameWorkCore_DBFirst_4DBCommunication.RestaurantModels;

public partial class Restaurant
{
    public int Id { get; set; }

    public string? RestaurantName { get; set; }

    public string? RestaurantLocation { get; set; }

    public DateTime? CreationDate { get; set; }
}
