using System;
using System.Collections.Generic;

namespace WarehouseInventory.Models;

public partial class Shipment
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public DateTime ShipDate { get; set; }

    public string Carrier { get; set; } = null!;

    public string TrackingNumber { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
