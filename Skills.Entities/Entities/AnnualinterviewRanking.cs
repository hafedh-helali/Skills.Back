﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Skills.Entities.Entities;

public partial class AnnualinterviewRanking
{
    public decimal AnnualinterviewId { get; set; }

    public decimal RankingCriterionId { get; set; }

    public int? Value { get; set; }

    public virtual Annualinterview Annualinterview { get; set; }

    public virtual RankingCriterion RankingCriterion { get; set; }
}