﻿using System;
using System.Collections.Generic;

namespace RPGInventory.Models;

public partial class ItemType
{
    public int Id { get; set; }

    public string? TypeName { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
