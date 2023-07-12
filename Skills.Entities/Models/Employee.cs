﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Skills.Entities.Models;

public partial class Employee
{
    public decimal EmployeeId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public decimal ProfileId { get; set; }

    public string Email { get; set; }

    public DateTime EntryDate { get; set; }

    public DateTime? EndDate { get; set; }

    public bool IsActive { get; set; }

    public decimal? ManagerId { get; set; }

    public string EmployeeNumber { get; set; }

    public decimal? AgencyId { get; set; }

    public virtual Agency Agency { get; set; }

    public virtual ICollection<Annualinterview> AnnualinterviewDelegatedByNavigation { get; set; } = new List<Annualinterview>();

    public virtual ICollection<Annualinterview> AnnualinterviewEmployee { get; set; } = new List<Annualinterview>();

    public virtual ICollection<Annualinterview> AnnualinterviewInterviewer { get; set; } = new List<Annualinterview>();

    public virtual ICollection<Employee> InverseManager { get; set; } = new List<Employee>();

    public virtual Employee Manager { get; set; }

    public virtual Profile Profile { get; set; }

    public virtual ICollection<User> User { get; set; } = new List<User>();
}