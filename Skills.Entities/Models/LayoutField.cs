﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Skills.Entities.Models;

public partial class LayoutField
{
    public decimal FieldId { get; set; }

    public decimal LayoutId { get; set; }

    public int? HorizontalPosition { get; set; }

    public int? VerticalPosition { get; set; }

    public int? WidthPercentage { get; set; }

    public virtual Field Field { get; set; }

    public virtual Layout Layout { get; set; }
}