﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Skills.Entities.Entities;

public partial class RankingCriterion
{
    public decimal RankingCriterionId { get; set; }

    public string RankingCriterion1 { get; set; }

    public int? Coefficient { get; set; }

    public virtual ICollection<AnnualinterviewRanking> AnnualinterviewRanking { get; set; } = new List<AnnualinterviewRanking>();
}