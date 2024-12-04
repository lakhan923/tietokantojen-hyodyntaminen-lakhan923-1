using System;
using System.Collections.Generic;

namespace BlazorApp.Models;

public partial class Event
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string? Location { get; set; }

    public int? CategoryId { get; set; }

    public int CreatedBy { get; set; }

    public virtual Category? Category { get; set; }

    public virtual User User { get; set; } = null!;

}
