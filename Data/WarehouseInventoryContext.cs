using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WarehouseInventory.Models;

    public class WarehouseInventoryContext : DbContext
    {
        public WarehouseInventoryContext (DbContextOptions<WarehouseInventoryContext> options)
            : base(options)
        {
        }

        public DbSet<WarehouseInventory.Models.Product> Product { get; set; } = default!;

public DbSet<WarehouseInventory.Models.Customer> Customer { get; set; } = default!;

public DbSet<WarehouseInventory.Models.OrderDetail> OrderDetail { get; set; } = default!;

public DbSet<WarehouseInventory.Models.Category> Category { get; set; } = default!;

public DbSet<WarehouseInventory.Models.Order> Order { get; set; } = default!;

public DbSet<WarehouseInventory.Models.Employee> Employee { get; set; } = default!;

public DbSet<WarehouseInventory.Models.Shipment> Shipment { get; set; } = default!;
    }
