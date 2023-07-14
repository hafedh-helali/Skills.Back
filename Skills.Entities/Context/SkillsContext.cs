﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Skills.Entities.Entities;

namespace Skills.Entities.Context;

public partial class SkillsContext : DbContext
{
    public SkillsContext()
    {
    }

    public SkillsContext(DbContextOptions<SkillsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agency> Agency { get; set; }

    public virtual DbSet<Annualinterview> Annualinterview { get; set; }

    public virtual DbSet<AnnualinterviewRanking> AnnualinterviewRanking { get; set; }

    public virtual DbSet<Area> Area { get; set; }

    public virtual DbSet<Authorization> Authorization { get; set; }

    public virtual DbSet<ChangeTracking> ChangeTracking { get; set; }

    public virtual DbSet<Employee> Employee { get; set; }

    public virtual DbSet<Field> Field { get; set; }

    public virtual DbSet<FieldAccess> FieldAccess { get; set; }

    public virtual DbSet<FieldItem> FieldItem { get; set; }

    public virtual DbSet<FieldType> FieldType { get; set; }

    public virtual DbSet<FieldTypeItem> FieldTypeItem { get; set; }

    public virtual DbSet<Improvementarea> Improvementarea { get; set; }

    public virtual DbSet<Improvementareas> Improvementareas { get; set; }

    public virtual DbSet<Layout> Layout { get; set; }

    public virtual DbSet<LayoutField> LayoutField { get; set; }

    public virtual DbSet<LayoutType> LayoutType { get; set; }

    public virtual DbSet<Profile> Profile { get; set; }

    public virtual DbSet<RankingCriterion> RankingCriterion { get; set; }

    public virtual DbSet<Status> Status { get; set; }

    public virtual DbSet<StatusTracking> StatusTracking { get; set; }

    public virtual DbSet<SystemParameter> SystemParameter { get; set; }

    public virtual DbSet<User> User { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder()

            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json").Build();

        var c = config["ConnectionStrings:SkillsConnStr"];
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(c);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agency>(entity =>
        {
            entity.HasKey(e => e.AgencyId).HasName("PK_ENTITY");

            entity.ToTable("AGENCY");

            entity.Property(e => e.AgencyId)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("AGENCY_ID");
            entity.Property(e => e.AgencyName)
                .HasMaxLength(50)
                .HasColumnName("AGENCY_NAME");
            entity.Property(e => e.Comments)
                .HasMaxLength(1000)
                .HasColumnName("COMMENTS");
        });

        modelBuilder.Entity<Annualinterview>(entity =>
        {
            entity.ToTable("ANNUALINTERVIEW");

            entity.Property(e => e.AnnualinterviewId)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("ANNUALINTERVIEW_ID");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("date")
                .HasColumnName("CREATED_ON");
            entity.Property(e => e.DelegatedBy)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("DELEGATED_BY");
            entity.Property(e => e.EmployeeId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("EMPLOYEE_ID");
            entity.Property(e => e.InterviewedEnabled).HasColumnName("INTERVIEWED_ENABLED");
            entity.Property(e => e.InterviewerEnabled).HasColumnName("INTERVIEWER_ENABLED");
            entity.Property(e => e.InterviewerId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("INTERVIEWER_ID");
            entity.Property(e => e.SatisfactionlevelId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("SATISFACTIONLEVEL_ID");

            entity.HasOne(d => d.DelegatedByNavigation).WithMany(p => p.AnnualinterviewDelegatedByNavigation)
                .HasForeignKey(d => d.DelegatedBy)
                .HasConstraintName("FK_ANNUALINTERVIEW_EMPLOYEE1");

            entity.HasOne(d => d.Employee).WithMany(p => p.AnnualinterviewEmployee)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_ANNUALINTERVIEW_EMPLOYEE");

            entity.HasOne(d => d.Interviewer).WithMany(p => p.AnnualinterviewInterviewer)
                .HasForeignKey(d => d.InterviewerId)
                .HasConstraintName("FK_ANNUALINTERVIEW_EMPLOYEE_INTERVIEWER");
        });

        modelBuilder.Entity<AnnualinterviewRanking>(entity =>
        {
            entity.HasKey(e => new { e.AnnualinterviewId, e.RankingCriterionId }).HasName("PK_ANNUALINTERVIEW_RANKING1");

            entity.ToTable("ANNUALINTERVIEW_RANKING");

            entity.Property(e => e.AnnualinterviewId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("ANNUALINTERVIEW_ID");
            entity.Property(e => e.RankingCriterionId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("RANKING_CRITERION_ID");
            entity.Property(e => e.Value).HasColumnName("VALUE");

            entity.HasOne(d => d.Annualinterview).WithMany(p => p.AnnualinterviewRanking)
                .HasForeignKey(d => d.AnnualinterviewId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ANNUALINTERVIEW_RANKING_ANNUALINTERVIEW");

            entity.HasOne(d => d.RankingCriterion).WithMany(p => p.AnnualinterviewRanking)
                .HasForeignKey(d => d.RankingCriterionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ANNUALINTERVIEW_RANKING_RANKING_CRITERION");
        });

        modelBuilder.Entity<Area>(entity =>
        {
            entity.ToTable("AREA");

            entity.Property(e => e.AreaId)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("AREA_ID");
            entity.Property(e => e.Area1)
                .HasMaxLength(50)
                .HasColumnName("AREA");
            entity.Property(e => e.Comment)
                .HasMaxLength(100)
                .HasColumnName("COMMENT");
            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");
        });

        modelBuilder.Entity<Authorization>(entity =>
        {
            entity.HasKey(e => new { e.ProfileId, e.AreaId }).HasName("PK_AUTHORIZATION2");

            entity.ToTable("AUTHORIZATION");

            entity.Property(e => e.ProfileId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("PROFILE_ID");
            entity.Property(e => e.AreaId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("AREA_ID");
            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");

            entity.HasOne(d => d.Area).WithMany(p => p.Authorization)
                .HasForeignKey(d => d.AreaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AUTHORIZATION_AREA");

            entity.HasOne(d => d.Profile).WithMany(p => p.Authorization)
                .HasForeignKey(d => d.ProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AUTHORIZATION_PROFILE");
        });

        modelBuilder.Entity<ChangeTracking>(entity =>
        {
            entity.HasKey(e => e.HistoryId);

            entity.ToTable("CHANGE_TRACKING");

            entity.Property(e => e.HistoryId)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("HISTORY_ID");
            entity.Property(e => e.CreatedBy)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_ON");
            entity.Property(e => e.LayoutId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("LAYOUT_ID");
            entity.Property(e => e.UpdatedBy)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("UPDATED_BY");
            entity.Property(e => e.UpdatedOn)
                .HasColumnType("datetime")
                .HasColumnName("UPDATED_ON");

            entity.HasOne(d => d.Layout).WithMany(p => p.ChangeTracking)
                .HasForeignKey(d => d.LayoutId)
                .HasConstraintName("FK_CHANGE_TRACKING_LAYOUT");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("EMPLOYEE");

            entity.Property(e => e.EmployeeId)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("EMPLOYEE_ID");
            entity.Property(e => e.AgencyId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("AGENCY_ID");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("EMAIL");
            entity.Property(e => e.EmployeeNumber)
                .HasMaxLength(20)
                .HasColumnName("EMPLOYEE_NUMBER");
            entity.Property(e => e.EndDate)
                .HasColumnType("date")
                .HasColumnName("END_DATE");
            entity.Property(e => e.EntryDate)
                .HasColumnType("date")
                .HasColumnName("ENTRY_DATE");
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("FIRST_NAME");
            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("LAST_NAME");
            entity.Property(e => e.ManagerId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("MANAGER_ID");
            entity.Property(e => e.ProfileId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("PROFILE_ID");

            entity.HasOne(d => d.Agency).WithMany(p => p.Employee)
                .HasForeignKey(d => d.AgencyId)
                .HasConstraintName("FK_EMPLOYEE_ENTITY");

            entity.HasOne(d => d.Manager).WithMany(p => p.InverseManager)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("FK_MANAGER_EMPLOYEE");

            entity.HasOne(d => d.Profile).WithMany(p => p.Employee)
                .HasForeignKey(d => d.ProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EMPLOYEE_PROFILE");
        });

        modelBuilder.Entity<Field>(entity =>
        {
            entity.ToTable("FIELD");

            entity.Property(e => e.FieldId)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("FIELD_ID");
            entity.Property(e => e.Columns).HasColumnName("COLUMNS");
            entity.Property(e => e.Comments)
                .HasMaxLength(50)
                .HasColumnName("COMMENTS");
            entity.Property(e => e.FieldLabel)
                .HasMaxLength(50)
                .HasColumnName("FIELD_LABEL");
            entity.Property(e => e.FieldName)
                .HasMaxLength(100)
                .HasColumnName("FIELD_NAME");
            entity.Property(e => e.FieldTypeId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("FIELD_TYPE_ID");
            entity.Property(e => e.FieldValue)
                .HasMaxLength(2000)
                .HasColumnName("FIELD_VALUE");
            entity.Property(e => e.Height).HasColumnName("HEIGHT");
            entity.Property(e => e.LayoutId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("LAYOUT_ID");
            entity.Property(e => e.LinkedFieldId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("LINKED_FIELD_ID");
            entity.Property(e => e.Rows).HasColumnName("ROWS");
            entity.Property(e => e.Width).HasColumnName("WIDTH");

            entity.HasOne(d => d.FieldType).WithMany(p => p.Field)
                .HasForeignKey(d => d.FieldTypeId)
                .HasConstraintName("FK_FIELD_FIELD_TYPE");

            entity.HasOne(d => d.Layout).WithMany(p => p.Field)
                .HasForeignKey(d => d.LayoutId)
                .HasConstraintName("FK_FIELD_LAYOUT");
        });

        modelBuilder.Entity<FieldAccess>(entity =>
        {
            entity.HasKey(e => new { e.FieldId, e.ProfileId });

            entity.ToTable("FIELD_ACCESS");

            entity.Property(e => e.FieldId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("FIELD_ID");
            entity.Property(e => e.ProfileId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("PROFILE_ID");
            entity.Property(e => e.CanRead).HasColumnName("CAN_READ");
            entity.Property(e => e.CanWrite).HasColumnName("CAN_WRITE");

            entity.HasOne(d => d.Field).WithMany(p => p.FieldAccess)
                .HasForeignKey(d => d.FieldId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FIELD_ACCESS_FIELD");
        });

        modelBuilder.Entity<FieldItem>(entity =>
        {
            entity.ToTable("FIELD_ITEM");

            entity.Property(e => e.FieldItemId)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("FIELD_ITEM_ID");
            entity.Property(e => e.FieldId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("FIELD_ID");
            entity.Property(e => e.FieldItemHorizontal).HasColumnName("FIELD_ITEM_HORIZONTAL");
            entity.Property(e => e.FieldItemLabel)
                .HasMaxLength(50)
                .HasColumnName("FIELD_ITEM_LABEL");
            entity.Property(e => e.Tooltip)
                .HasMaxLength(50)
                .HasColumnName("TOOLTIP");

            entity.HasOne(d => d.Field).WithMany(p => p.FieldItem)
                .HasForeignKey(d => d.FieldId)
                .HasConstraintName("FK_FIELD_ITEM_FIELD");
        });

        modelBuilder.Entity<FieldType>(entity =>
        {
            entity.ToTable("FIELD_TYPE");

            entity.Property(e => e.FieldTypeId)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("FIELD_TYPE_ID");
            entity.Property(e => e.Comments)
                .HasMaxLength(100)
                .HasColumnName("COMMENTS");
            entity.Property(e => e.FieldType1)
                .HasMaxLength(50)
                .HasColumnName("FIELD_TYPE");
        });

        modelBuilder.Entity<FieldTypeItem>(entity =>
        {
            entity.HasKey(e => e.FieldTypeItemId).HasName("PK_FIELD_TYPE_ITEM1");

            entity.ToTable("FIELD_TYPE_ITEM");

            entity.Property(e => e.FieldTypeItemId)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("FIELD_TYPE_ITEM_ID");
            entity.Property(e => e.FieldTypeId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("FIELD_TYPE_ID");
            entity.Property(e => e.ItemLabel)
                .HasMaxLength(50)
                .HasColumnName("ITEM_LABEL");
        });

        modelBuilder.Entity<Improvementarea>(entity =>
        {
            entity.ToTable("IMPROVEMENTAREA");

            entity.Property(e => e.ImprovementareaId)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("IMPROVEMENTAREA_ID");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Improvementarea1)
                .HasMaxLength(50)
                .HasColumnName("IMPROVEMENTAREA");
            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");
        });

        modelBuilder.Entity<Improvementareas>(entity =>
        {
            entity.HasKey(e => new { e.ImprovementareaId, e.AnnualinterviewId });

            entity.ToTable("IMPROVEMENTAREAS");

            entity.Property(e => e.ImprovementareaId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("IMPROVEMENTAREA_ID");
            entity.Property(e => e.AnnualinterviewId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("ANNUALINTERVIEW_ID");
            entity.Property(e => e.Comments)
                .HasMaxLength(200)
                .HasColumnName("COMMENTS");

            entity.HasOne(d => d.Annualinterview).WithMany(p => p.Improvementareas)
                .HasForeignKey(d => d.AnnualinterviewId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IMPROVEMENTAREAS_ANNUALINTERVIEW");

            entity.HasOne(d => d.Improvementarea).WithMany(p => p.Improvementareas)
                .HasForeignKey(d => d.ImprovementareaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IMPROVEMENTAREAS_IMPROVEMENTAREA");
        });

        modelBuilder.Entity<Layout>(entity =>
        {
            entity.ToTable("LAYOUT");

            entity.Property(e => e.LayoutId)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("LAYOUT_ID");
            entity.Property(e => e.Columns).HasColumnName("COLUMNS");
            entity.Property(e => e.LayoutName)
                .HasMaxLength(100)
                .HasColumnName("LAYOUT_NAME");
            entity.Property(e => e.LayoutProfile)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("LAYOUT_PROFILE");
            entity.Property(e => e.LayoutTypeId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("LAYOUT_TYPE_ID");
            entity.Property(e => e.OtherProperties)
                .HasMaxLength(200)
                .HasColumnName("OTHER_PROPERTIES");
            entity.Property(e => e.Rows).HasColumnName("ROWS");

            entity.HasOne(d => d.LayoutType).WithMany(p => p.Layout)
                .HasForeignKey(d => d.LayoutTypeId)
                .HasConstraintName("FK_LAYOUT_LAYOUT_TYPE");
        });

        modelBuilder.Entity<LayoutField>(entity =>
        {
            entity.HasKey(e => new { e.FieldId, e.LayoutId });

            entity.ToTable("LAYOUT_FIELD");

            entity.Property(e => e.FieldId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("FIELD_ID");
            entity.Property(e => e.LayoutId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("LAYOUT_ID");
            entity.Property(e => e.HorizontalPosition).HasColumnName("HORIZONTAL_POSITION");
            entity.Property(e => e.HorizontalyAligned).HasColumnName("HORIZONTALY_ALIGNED");
            entity.Property(e => e.VerticalPosition).HasColumnName("VERTICAL_POSITION");
            entity.Property(e => e.WidthPercentage).HasColumnName("WIDTH_PERCENTAGE");
        });

        modelBuilder.Entity<LayoutType>(entity =>
        {
            entity.ToTable("LAYOUT_TYPE");

            entity.Property(e => e.LayoutTypeId)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("LAYOUT_TYPE_ID");
            entity.Property(e => e.Comments)
                .HasMaxLength(100)
                .HasColumnName("COMMENTS");
            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(e => e.LayoutTypeName)
                .HasMaxLength(50)
                .HasColumnName("LAYOUT_TYPE_NAME");
        });

        modelBuilder.Entity<Profile>(entity =>
        {
            entity.ToTable("PROFILE");

            entity.Property(e => e.ProfileId)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("PROFILE_ID");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(e => e.ProfileName)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("PROFILE_NAME");
        });

        modelBuilder.Entity<RankingCriterion>(entity =>
        {
            entity.ToTable("RANKING_CRITERION");

            entity.Property(e => e.RankingCriterionId)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("RANKING_CRITERION_ID");
            entity.Property(e => e.Coefficient).HasColumnName("COEFFICIENT");
            entity.Property(e => e.RankingCriterion1)
                .HasMaxLength(50)
                .HasColumnName("RANKING_CRITERION");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.ToTable("STATUS");

            entity.Property(e => e.StatusId)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("STATUS_ID");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(e => e.Status1)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("STATUS");
        });

        modelBuilder.Entity<StatusTracking>(entity =>
        {
            entity.HasKey(e => new { e.StatusId, e.AnnualinterviewId }).HasName("PK_STATUS_TRACKING1");

            entity.ToTable("STATUS_TRACKING");

            entity.Property(e => e.StatusId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("STATUS_ID");
            entity.Property(e => e.AnnualinterviewId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("ANNUALINTERVIEW_ID");
            entity.Property(e => e.Comments)
                .HasMaxLength(100)
                .HasColumnName("COMMENTS");
            entity.Property(e => e.UpdatedBy)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("UPDATED_BY");
            entity.Property(e => e.UpdatedOn)
                .HasColumnType("datetime")
                .HasColumnName("UPDATED_ON");

            entity.HasOne(d => d.Annualinterview).WithMany(p => p.StatusTracking)
                .HasForeignKey(d => d.AnnualinterviewId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_STATUS_TRACKING_ANNUALINTERVIEW");

            entity.HasOne(d => d.Status).WithMany(p => p.StatusTracking)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_STATUS_TRACKING_STATUS");
        });

        modelBuilder.Entity<SystemParameter>(entity =>
        {
            entity.HasKey(e => e.ParameterId);

            entity.ToTable("SYSTEM_PARAMETER");

            entity.Property(e => e.ParameterId)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("PARAMETER_ID");
            entity.Property(e => e.ParameterName)
                .HasMaxLength(50)
                .HasColumnName("PARAMETER_NAME");
            entity.Property(e => e.ParameterValue)
                .HasMaxLength(50)
                .HasColumnName("PARAMETER_VALUE");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Email);

            entity.ToTable("USER");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("EMAIL");
            entity.Property(e => e.AdAuthentication).HasColumnName("AD_AUTHENTICATION");
            entity.Property(e => e.EmployeeId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("EMPLOYEE_ID");
            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.PwdExpiresOn)
                .HasColumnType("date")
                .HasColumnName("PWD_EXPIRES_ON");

            entity.HasOne(d => d.Employee).WithMany(p => p.User)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_USER_EMPLOYEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}