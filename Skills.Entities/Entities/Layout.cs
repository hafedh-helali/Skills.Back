﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Skills.Entities.Entities;

public partial class Layout
{
    public decimal LayoutId { get; set; }

    public int? Columns { get; set; }

    public int? Rows { get; set; }

    public string LayoutName { get; set; }

    public decimal? LayoutProfile { get; set; }

    public string OtherProperties { get; set; }

    public virtual ICollection<ChangeTracking> ChangeTracking { get; set; } = new List<ChangeTracking>();

    public virtual ICollection<LayoutField> LayoutField { get; set; } = new List<LayoutField>();
}