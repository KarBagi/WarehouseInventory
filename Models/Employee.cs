using System;
using System.Collections.Generic;

namespace WarehouseInventory.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Position { get; set; } = null!;

    public DateTime HireDate { get; set; }

    public string Phone { get; set; } = null!;
}
