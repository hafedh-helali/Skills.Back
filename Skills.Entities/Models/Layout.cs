﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Skills.Entities.Models;

public partial class Layout
{
    public decimal LayoutId { get; set; }

    public int? Columns { get; set; }

    public int? Rows { get; set; }

    public decimal? EntityId { get; set; }

    public virtual ICollection<LayoutField> LayoutField { get; set; } = new List<LayoutField>();
}