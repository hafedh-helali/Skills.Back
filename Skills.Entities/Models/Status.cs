﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Skills.Entities.Models;

public partial class Status
{
    public decimal StatusId { get; set; }

    public string Status1 { get; set; }

    public string Description { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<StatusTracking> StatusTracking { get; set; } = new List<StatusTracking>();
}