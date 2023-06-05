using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FinLife.Models;

public partial class FinLifeContext : DbContext
{
    public FinLifeContext()
    {
    }

    public FinLifeContext(DbContextOptions<FinLifeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<ApprovalReject> ApprovalRejects { get; set; }

    public virtual DbSet<AssessmentScore> AssessmentScores { get; set; }

    public virtual DbSet<QuestionOption> QuestionOptions { get; set; }

    public virtual DbSet<Questionnaire> Questionnaires { get; set; }

    public virtual DbSet<RiskManager> RiskManagers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vendor> Vendors { get; set; }

    public virtual DbSet<VendorAssessment> VendorAssessments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("server=localhost;database=FinLife;port=5432;user id=postgres;password=raksana");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Admin_pkey");

            entity.ToTable("Admin");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.EmailId).HasColumnName("emailId");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.QuestionId).HasColumnName("questionId");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.VendorId).HasColumnName("vendorId");
        });

        modelBuilder.Entity<ApprovalReject>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ApprovalReject");

            entity.Property(e => e.AssessmentId).HasColumnName("assessmentId");
            entity.Property(e => e.Decision).HasColumnName("decision");
            entity.Property(e => e.DecisionBy).HasColumnName("decisionBy");
            entity.Property(e => e.LastModifiedOn)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("lastModifiedOn");
            entity.Property(e => e.VendorId).HasColumnName("vendorId");

            entity.HasOne(d => d.Assessment).WithMany()
                .HasForeignKey(d => d.AssessmentId)
                .HasConstraintName("ApprovalReject_assessmentId_fkey");

            entity.HasOne(d => d.Vendor).WithMany()
                .HasForeignKey(d => d.VendorId)
                .HasConstraintName("ApprovalReject_vendorId_fkey");
        });

        modelBuilder.Entity<AssessmentScore>(entity =>
        {
            entity.HasKey(e => e.QuestionSet).HasName("AssessmentScore_pkey");

            entity.ToTable("AssessmentScore");

            entity.Property(e => e.QuestionSet)
                .ValueGeneratedNever()
                .HasColumnName("questionSet");
            entity.Property(e => e.AssessmentId).HasColumnName("assessmentId");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdDate");
            entity.Property(e => e.Score).HasColumnName("score");
            entity.Property(e => e.VendorId).HasColumnName("vendorID");

            entity.HasOne(d => d.Assessment).WithMany(p => p.AssessmentScores)
                .HasForeignKey(d => d.AssessmentId)
                .HasConstraintName("AssessmentScore_assessmentId_fkey");

            entity.HasOne(d => d.Vendor).WithMany(p => p.AssessmentScores)
                .HasForeignKey(d => d.VendorId)
                .HasConstraintName("AssessmentScore_vendorID_fkey");
        });

        modelBuilder.Entity<QuestionOption>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("QuestionOptions_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.QuestionId).HasColumnName("questionId");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        modelBuilder.Entity<Questionnaire>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Questionnaire_pkey");

            entity.ToTable("Questionnaire");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Category).HasColumnName("category");
            entity.Property(e => e.LastModifiedBy).HasColumnName("lastModifiedBy");
            entity.Property(e => e.LastModifiedOn)
                .HasColumnType("time with time zone")
                .HasColumnName("lastModifiedOn");
            entity.Property(e => e.Question).HasColumnName("question");
            entity.Property(e => e.QuestionNumber).HasColumnName("questionNumber");
            entity.Property(e => e.QuestionSet).HasColumnName("questionSet");
            entity.Property(e => e.QuestionType).HasColumnName("questionType");
            entity.Property(e => e.Weightage).HasColumnName("weightage");
        });

        modelBuilder.Entity<RiskManager>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("RiskManager_pkey");

            entity.ToTable("RiskManager");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.VendorAssesmentId).HasColumnName("vendorAssesmentId");

            entity.HasOne(d => d.VendorAssesment).WithMany(p => p.RiskManagers)
                .HasForeignKey(d => d.VendorAssesmentId)
                .HasConstraintName("RiskManager_vendorAssesmentId_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.EmailId).HasName("Users_pkey");

            entity.Property(e => e.EmailId).HasColumnName("emailId");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Role).HasColumnName("role");
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Vendor_pkey");

            entity.ToTable("Vendor");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CompanyName).HasColumnName("companyName");
            entity.Property(e => e.EmailId).HasColumnName("emailId");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.ServiceDescription).HasColumnName("serviceDescription");
            entity.Property(e => e.ServiceOffering).HasColumnName("serviceOffering");
            entity.Property(e => e.Url).HasColumnName("url");
            entity.Property(e => e.YearInBusiness).HasColumnName("yearInBusiness");
        });

        modelBuilder.Entity<VendorAssessment>(entity =>
        {
            entity.HasKey(e => e.AssessementId).HasName("VendorAssessment_pkey");

            entity.ToTable("VendorAssessment");

            entity.Property(e => e.AssessementId)
                .ValueGeneratedNever()
                .HasColumnName("assessementId");
            entity.Property(e => e.LastModifiedBy).HasColumnName("lastModifiedBy");
            entity.Property(e => e.LastModifiedOn)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("lastModifiedOn");
            entity.Property(e => e.OptionTitle).HasColumnName("optionTitle");
            entity.Property(e => e.OptionValue).HasColumnName("optionValue");
            entity.Property(e => e.QuestionId).HasColumnName("questionId");
            entity.Property(e => e.QuestionNumber).HasColumnName("questionNumber");
            entity.Property(e => e.QuestionTitle).HasColumnName("questionTitle");
            entity.Property(e => e.VendorId).HasColumnName("vendorId");

            entity.HasOne(d => d.Question).WithMany(p => p.VendorAssessments)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("VendorAssessment_questionId_fkey");

            entity.HasOne(d => d.Vendor).WithMany(p => p.VendorAssessments)
                .HasForeignKey(d => d.VendorId)
                .HasConstraintName("VendorAssessment_vendorId_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
