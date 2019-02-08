using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ModelCore.HRMS.Admin.Recruitment
{
    public partial class AMTDEVContext : DbContext
    {
        public AMTDEVContext()
        {
        }

        public AMTDEVContext(DbContextOptions<AMTDEVContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MThrmsbranch> MThrmsbranch { get; set; }
        public virtual DbSet<MThrmsfiletest> MThrmsfiletest { get; set; }
        public virtual DbSet<MThrmscandidateEntry> MThrmscandidateEntry { get; set; }
        public virtual DbSet<MThrmschecklistItems> MThrmschecklistItems { get; set; }
        public virtual DbSet<MThrmscompany> MThrmscompany { get; set; }
        public virtual DbSet<MThrmscvrepository> MThrmscvrepository { get; set; }
        public virtual DbSet<MThrmsdepartment> MThrmsdepartment { get; set; }
        public virtual DbSet<MThrmsdesignation> MThrmsdesignation { get; set; }
        public virtual DbSet<MThrmsdesignationInventory> MThrmsdesignationInventory { get; set; }
        public virtual DbSet<MThrmsemployee> MThrmsemployee { get; set; }
        public virtual DbSet<MThrmsinterviewChecklistEvaluation> MThrmsinterviewChecklistEvaluation { get; set; }
        public virtual DbSet<MThrmsinterviewChecklistEvaluationDetails> MThrmsinterviewChecklistEvaluationDetails { get; set; }
        public virtual DbSet<MThrmsinterviewFeedback> MThrmsinterviewFeedback { get; set; }
        public virtual DbSet<MThrmsinterviewRoundsDefinition> MThrmsinterviewRoundsDefinition { get; set; }
        public virtual DbSet<MThrmsinterviewSchedule> MThrmsinterviewSchedule { get; set; }
        public virtual DbSet<MThrmsinterviewScheduleRoundDetails> MThrmsinterviewScheduleRoundDetails { get; set; }
        public virtual DbSet<MThrmsinterviewScheduleRounds> MThrmsinterviewScheduleRounds { get; set; }
        public virtual DbSet<MThrmsinventory> MThrmsinventory { get; set; }
        public virtual DbSet<MThrmsinventoryManagement> MThrmsinventoryManagement { get; set; }
        public virtual DbSet<MThrmsinventoryManagementDetails> MThrmsinventoryManagementDetails { get; set; }
        public virtual DbSet<MThrmsmanPowerBudget> MThrmsmanPowerBudget { get; set; }
        public virtual DbSet<MThrmsofferLetter> MThrmsofferLetter { get; set; }
        public virtual DbSet<MThrmsonboarding> MThrmsonboarding { get; set; }
        public virtual DbSet<MThrmsresourceAllocation> MThrmsresourceAllocation { get; set; }
        public virtual DbSet<MThrmsresourceRequisition> MThrmsresourceRequisition { get; set; }
        public virtual DbSet<MThrmsshortlist> MThrmsshortlist { get; set; }
        public virtual DbSet<MThrmssourcing> MThrmssourcing { get; set; }

        public virtual DbSet<MThrmsattendance> MThrmsattendance { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=AMTDEV;Trusted_Connection=True;");
                optionsBuilder.UseSqlServer("Server=196.29.169.131;Database=AMTDEV;username=markoncs;password=Mar@123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MThrmsbranch>(entity =>
            {
                entity.ToTable("mTHRMSBranch");

                entity.Property(e => e.MThrmsbranchId).HasColumnName("mTHRMSBranchId");

                entity.Property(e => e.AddressLine1).HasMaxLength(500);

                entity.Property(e => e.AddressLine2).HasMaxLength(500);

                entity.Property(e => e.AddressLine3).HasMaxLength(500);

                entity.Property(e => e.Branch).HasMaxLength(100);

                entity.Property(e => e.BranchCode).HasMaxLength(10);

                entity.Property(e => e.ContactNo).HasMaxLength(20);

                entity.Property(e => e.Email).HasMaxLength(500);

                entity.Property(e => e.MThrmscompanyId).HasColumnName("mTHRMSCompanyId");

                entity.HasOne(d => d.MThrmscompany)
                    .WithMany(p => p.MThrmsbranch)
                    .HasForeignKey(d => d.MThrmscompanyId)
                    .HasConstraintName("FK_mTHRMSBranch_mTHRMSCompany");
            });

            modelBuilder.Entity<MThrmscandidateEntry>(entity =>
            {
                entity.ToTable("mTHRMSCandidateEntry");

                entity.Property(e => e.MThrmscandidateEntryId).HasColumnName("mTHRMSCandidateEntryId");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.MThrmscandidateEntry)
                    .HasForeignKey(d => d.CandidateId)
                    .HasConstraintName("FK_mTHRMSCandidateEntry_mTHRMSCVRepository");

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.MThrmscandidateEntry)
                    .HasForeignKey(d => d.DesignationId)
                    .HasConstraintName("FK_mTHRMSCandidateEntry_mTHRMSDesignation");

                entity.HasOne(d => d.InventoryManagement)
                    .WithMany(p => p.MThrmscandidateEntry)
                    .HasForeignKey(d => d.InventoryManagementId)
                    .HasConstraintName("FK_mTHRMSCandidateEntry_mTHRMSInventoryManagement");

                entity.HasOne(d => d.ManPower)
                    .WithMany(p => p.MThrmscandidateEntry)
                    .HasForeignKey(d => d.ManPowerId)
                    .HasConstraintName("FK_mTHRMSCandidateEntry_mTHRMSManPowerBudget");

                entity.HasOne(d => d.OfferLetter)
                    .WithMany(p => p.MThrmscandidateEntry)
                    .HasForeignKey(d => d.OfferLetterId)
                    .HasConstraintName("FK_mTHRMSCandidateEntry_mTHRMSOfferLetter");

                entity.HasOne(d => d.Recruiter)
                    .WithMany(p => p.MThrmscandidateEntry)
                    .HasForeignKey(d => d.RecruiterId)
                    .HasConstraintName("FK_mTHRMSCandidateEntry_mTHRMSEmployee");

                entity.HasOne(d => d.ResourceAllocation)
                    .WithMany(p => p.MThrmscandidateEntry)
                    .HasForeignKey(d => d.ResourceAllocationId)
                    .HasConstraintName("FK_mTHRMSCandidateEntry_mTHRMSResourceAllocation");

                entity.HasOne(d => d.ResourceRequisition)
                    .WithMany(p => p.MThrmscandidateEntry)
                    .HasForeignKey(d => d.ResourceRequisitionId)
                    .HasConstraintName("FK_mTHRMSCandidateEntry_mTHRMSResourceRequisition");

                entity.HasOne(d => d.Shortlist)
                    .WithMany(p => p.MThrmscandidateEntry)
                    .HasForeignKey(d => d.ShortlistId)
                    .HasConstraintName("FK_mTHRMSCandidateEntry_mTHRMSShortlist");

                entity.HasOne(d => d.Sourcing)
                    .WithMany(p => p.MThrmscandidateEntry)
                    .HasForeignKey(d => d.SourcingId)
                    .HasConstraintName("FK_mTHRMSCandidateEntry_mTHRMSSourcing");
            });

            modelBuilder.Entity<MThrmschecklistItems>(entity =>
            {
                entity.ToTable("mTHRMSChecklistItems");

                entity.Property(e => e.MThrmschecklistItemsId).HasColumnName("mTHRMSChecklistItemsId");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.ScoreFrom).HasColumnType("decimal(36, 6)");

                entity.Property(e => e.ScoreTo).HasColumnType("decimal(36, 6)");
            });

            modelBuilder.Entity<MThrmscompany>(entity =>
            {
                entity.ToTable("mTHRMSCompany");

                entity.Property(e => e.MThrmscompanyId).HasColumnName("mTHRMSCompanyId");

                entity.Property(e => e.Company).HasMaxLength(100);

                entity.Property(e => e.CompanyTitle).HasMaxLength(255);
            });

            modelBuilder.Entity<MThrmscvrepository>(entity =>
            {
                entity.ToTable("mTHRMSCVRepository");

                entity.Property(e => e.MThrmscvrepositoryId).HasColumnName("mTHRMSCVRepositoryId");

                entity.Property(e => e.Contact).HasMaxLength(50);

                entity.Property(e => e.Cvfile)
                    .HasColumnName("CVFile")
                    .HasColumnType("image");

                entity.Property(e => e.Degree).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Experience).HasMaxLength(50);

                entity.Property(e => e.Faculty).HasMaxLength(50);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);
            });

            modelBuilder.Entity<MThrmsdepartment>(entity =>
            {
                entity.ToTable("mTHRMSDepartment");

                entity.Property(e => e.MThrmsdepartmentId).HasColumnName("mTHRMSDepartmentId");

                entity.Property(e => e.Department).HasMaxLength(100);

                entity.Property(e => e.DepartmentCode).HasMaxLength(50);

                entity.Property(e => e.MThrmscompanyId).HasColumnName("mTHRMSCompanyId");

                entity.HasOne(d => d.MThrmscompany)
                    .WithMany(p => p.MThrmsdepartment)
                    .HasForeignKey(d => d.MThrmscompanyId)
                    .HasConstraintName("FK_mTHRMSDepartment_mTHRMSCompany");
            });

            modelBuilder.Entity<MThrmsdesignation>(entity =>
            {
                entity.ToTable("mTHRMSDesignation");

                entity.Property(e => e.MThrmsdesignationId).HasColumnName("mTHRMSDesignationId");

                entity.Property(e => e.Basic).HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Cola)
                    .HasColumnName("COLA")
                    .HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Designation).HasMaxLength(100);

                entity.Property(e => e.DesignationCode).HasMaxLength(50);

                entity.Property(e => e.ExperienceRequired).HasMaxLength(50);

                entity.Property(e => e.Gross).HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Housing).HasColumnType("decimal(36, 6)");

                entity.Property(e => e.JobPurpose).HasMaxLength(100);

                entity.Property(e => e.JobTitle).HasMaxLength(50);

                entity.Property(e => e.LanguageKnowledge).HasMaxLength(100);

                entity.Property(e => e.MThrmsdepartmentId).HasColumnName("mTHRMSDepartmentId");

                entity.Property(e => e.MinimumAge).HasMaxLength(50);

                entity.Property(e => e.Pitax)
                    .HasColumnName("PITax")
                    .HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Si)
                    .HasColumnName("SI")
                    .HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Sicompany)
                    .HasColumnName("SICompany")
                    .HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Stamp).HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Transport).HasColumnType("decimal(36, 6)");

                entity.HasOne(d => d.MThrmsdepartment)
                    .WithMany(p => p.MThrmsdesignation)
                    .HasForeignKey(d => d.MThrmsdepartmentId)
                    .HasConstraintName("FK_mTHRMSDesignation_mTHRMSDepartment");
            });

            modelBuilder.Entity<MThrmsdesignationInventory>(entity =>
            {
                entity.ToTable("mTHRMSDesignationInventory");

                entity.Property(e => e.MThrmsdesignationInventoryId).HasColumnName("mTHRMSDesignationInventoryId");

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.MThrmsdesignationInventory)
                    .HasForeignKey(d => d.DesignationId)
                    .HasConstraintName("FK_mTHRMSDesignationInventory_mTHRMSDesignation");

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.MThrmsdesignationInventory)
                    .HasForeignKey(d => d.InventoryId)
                    .HasConstraintName("FK_mTHRMSDesignationInventory_mTHRMSInventory");
            });

            modelBuilder.Entity<MThrmsemployee>(entity =>
            {
                entity.ToTable("mTHRMSEmployee");

                entity.Property(e => e.MThrmsemployeeId).HasColumnName("mTHRMSEmployeeId");

                entity.Property(e => e.Basic).HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Cola)
                    .HasColumnName("COLA")
                    .HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Employee).HasMaxLength(100);

                entity.Property(e => e.EmployeeCode).HasMaxLength(50);

                entity.Property(e => e.Gross).HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Housing).HasColumnType("decimal(36, 6)");

                entity.Property(e => e.MThrmsbranchId).HasColumnName("mTHRMSBranchId");

                entity.Property(e => e.MThrmscompanyId).HasColumnName("mTHRMSCompanyId");

                entity.Property(e => e.MThrmsdepartmentId).HasColumnName("mTHRMSDepartmentId");

                entity.Property(e => e.MThrmsdesignationId).HasColumnName("mTHRMSDesignationId");

                entity.Property(e => e.Pitax)
                    .HasColumnName("PITax")
                    .HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Si)
                    .HasColumnName("SI")
                    .HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Sicompany)
                    .HasColumnName("SICompany")
                    .HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Stamp).HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Transport).HasColumnType("decimal(36, 6)");

                entity.HasOne(d => d.MThrmsbranch)
                    .WithMany(p => p.MThrmsemployee)
                    .HasForeignKey(d => d.MThrmsbranchId)
                    .HasConstraintName("FK_mTHRMSEmployee_mTHRMSBranch");

                entity.HasOne(d => d.MThrmscompany)
                    .WithMany(p => p.MThrmsemployee)
                    .HasForeignKey(d => d.MThrmscompanyId)
                    .HasConstraintName("FK_mTHRMSEmployee_mTHRMSCompany");

                entity.HasOne(d => d.MThrmsdepartment)
                    .WithMany(p => p.MThrmsemployee)
                    .HasForeignKey(d => d.MThrmsdepartmentId)
                    .HasConstraintName("FK_mTHRMSEmployee_mTHRMSDepartment");

                entity.HasOne(d => d.MThrmsdesignation)
                    .WithMany(p => p.MThrmsemployee)
                    .HasForeignKey(d => d.MThrmsdesignationId)
                    .HasConstraintName("FK_mTHRMSEmployee_mTHRMSDesignation");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.InverseManager)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("FK_mTHRMSEmployee_mTHRMSEmployee");
            });

            modelBuilder.Entity<MThrmsinterviewChecklistEvaluation>(entity =>
            {
                entity.ToTable("mTHRMSInterviewChecklistEvaluation");

                entity.Property(e => e.MThrmsinterviewChecklistEvaluationId).HasColumnName("mTHRMSInterviewChecklistEvaluationId");

                entity.HasOne(d => d.InterviewSchedule)
                    .WithMany(p => p.MThrmsinterviewChecklistEvaluation)
                    .HasForeignKey(d => d.InterviewScheduleId)
                    .HasConstraintName("FK_mTHRMSInterviewChecklistEvaluation_mTHRMSInterviewSchedule");

                entity.HasOne(d => d.InterviewScheduleRoundDetails)
                    .WithMany(p => p.MThrmsinterviewChecklistEvaluation)
                    .HasForeignKey(d => d.InterviewScheduleRoundDetailsId)
                    .HasConstraintName("FK_mTHRMSInterviewChecklistEvaluation_mTHRMSInterviewScheduleRoundDetails");

                entity.HasOne(d => d.InterviewScheduleRound)
                    .WithMany(p => p.MThrmsinterviewChecklistEvaluation)
                    .HasForeignKey(d => d.InterviewScheduleRoundId)
                    .HasConstraintName("FK_mTHRMSInterviewChecklistEvaluation_mTHRMSInterviewScheduleRounds");

                entity.HasOne(d => d.Interviewer)
                    .WithMany(p => p.MThrmsinterviewChecklistEvaluation)
                    .HasForeignKey(d => d.InterviewerId)
                    .HasConstraintName("FK_mTHRMSInterviewChecklistEvaluation_mTHRMSEmployee");
            });

            modelBuilder.Entity<MThrmsinterviewChecklistEvaluationDetails>(entity =>
            {
                entity.ToTable("mTHRMSInterviewChecklistEvaluationDetails");

                entity.Property(e => e.MThrmsinterviewChecklistEvaluationDetailsId).HasColumnName("mTHRMSInterviewChecklistEvaluationDetailsId");

                entity.Property(e => e.Score).HasColumnType("decimal(36, 6)");

                entity.HasOne(d => d.ChecklistItem)
                    .WithMany(p => p.MThrmsinterviewChecklistEvaluationDetails)
                    .HasForeignKey(d => d.ChecklistItemId)
                    .HasConstraintName("FK_mTHRMSInterviewChecklistEvaluationDetails_mTHRMSChecklistItems");

                entity.HasOne(d => d.InterviewChecklistEvaluation)
                    .WithMany(p => p.MThrmsinterviewChecklistEvaluationDetails)
                    .HasForeignKey(d => d.InterviewChecklistEvaluationId)
                    .HasConstraintName("FK_mTHRMSInterviewChecklistEvaluationDetails_mTHRMSInterviewChecklistEvaluation");
            });

            modelBuilder.Entity<MThrmsinterviewFeedback>(entity =>
            {
                entity.ToTable("mTHRMSInterviewFeedback");

                entity.Property(e => e.MThrmsinterviewFeedbackId).HasColumnName("mTHRMSInterviewFeedbackId");

                entity.Property(e => e.FeedbackDate).HasColumnType("datetime");

                entity.Property(e => e.Recommendation).HasMaxLength(50);

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.MThrmsinterviewFeedback)
                    .HasForeignKey(d => d.CandidateId)
                    .HasConstraintName("FK_mTHRMSInterviewFeedback_mTHRMSCVRepository");

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.MThrmsinterviewFeedback)
                    .HasForeignKey(d => d.DesignationId)
                    .HasConstraintName("FK_mTHRMSInterviewFeedback_mTHRMSDesignation");

                entity.HasOne(d => d.InterviewSchedule)
                    .WithMany(p => p.MThrmsinterviewFeedback)
                    .HasForeignKey(d => d.InterviewScheduleId)
                    .HasConstraintName("FK_mTHRMSInterviewFeedback_mTHRMSInterviewSchedule");

                entity.HasOne(d => d.InterviewScheduleRoundDetails)
                    .WithMany(p => p.MThrmsinterviewFeedback)
                    .HasForeignKey(d => d.InterviewScheduleRoundDetailsId)
                    .HasConstraintName("FK_mTHRMSInterviewFeedback_mTHRMSInterviewScheduleRoundDetails");

                entity.HasOne(d => d.InterviewScheduleRound)
                    .WithMany(p => p.MThrmsinterviewFeedback)
                    .HasForeignKey(d => d.InterviewScheduleRoundId)
                    .HasConstraintName("FK_mTHRMSInterviewFeedback_mTHRMSInterviewScheduleRounds");

                entity.HasOne(d => d.Interviewer)
                    .WithMany(p => p.MThrmsinterviewFeedbackInterviewer)
                    .HasForeignKey(d => d.InterviewerId)
                    .HasConstraintName("FK_mTHRMSInterviewFeedback_mTHRMSEmployee1");

                entity.HasOne(d => d.ManPower)
                    .WithMany(p => p.MThrmsinterviewFeedback)
                    .HasForeignKey(d => d.ManPowerId)
                    .HasConstraintName("FK_mTHRMSInterviewFeedback_mTHRMSManPowerBudget");

                entity.HasOne(d => d.Recruiter)
                    .WithMany(p => p.MThrmsinterviewFeedbackRecruiter)
                    .HasForeignKey(d => d.RecruiterId)
                    .HasConstraintName("FK_mTHRMSInterviewFeedback_mTHRMSEmployee");

                entity.HasOne(d => d.ResourceAllocation)
                    .WithMany(p => p.MThrmsinterviewFeedback)
                    .HasForeignKey(d => d.ResourceAllocationId)
                    .HasConstraintName("FK_mTHRMSInterviewFeedback_mTHRMSResourceAllocation");

                entity.HasOne(d => d.ResourceRequisition)
                    .WithMany(p => p.MThrmsinterviewFeedback)
                    .HasForeignKey(d => d.ResourceRequisitionId)
                    .HasConstraintName("FK_mTHRMSInterviewFeedback_mTHRMSResourceRequisition");

                entity.HasOne(d => d.Shortlist)
                    .WithMany(p => p.MThrmsinterviewFeedback)
                    .HasForeignKey(d => d.ShortlistId)
                    .HasConstraintName("FK_mTHRMSInterviewFeedback_mTHRMSShortlist");

                entity.HasOne(d => d.Sourcing)
                    .WithMany(p => p.MThrmsinterviewFeedback)
                    .HasForeignKey(d => d.SourcingId)
                    .HasConstraintName("FK_mTHRMSInterviewFeedback_mTHRMSSourcing");
            });

            modelBuilder.Entity<MThrmsinterviewRoundsDefinition>(entity =>
            {
                entity.ToTable("mTHRMSInterviewRoundsDefinition");

                entity.Property(e => e.MThrmsinterviewRoundsDefinitionId).HasColumnName("mTHRMSInterviewRoundsDefinitionId");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<MThrmsinterviewSchedule>(entity =>
            {
                entity.ToTable("mTHRMSInterviewSchedule");

                entity.Property(e => e.MThrmsinterviewScheduleId).HasColumnName("mTHRMSInterviewScheduleId");

                entity.Property(e => e.Basic).HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Cola)
                    .HasColumnName("COLA")
                    .HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Gross).HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Housing).HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Pitax)
                    .HasColumnName("PITax")
                    .HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Si)
                    .HasColumnName("SI")
                    .HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Sicompany)
                    .HasColumnName("SICompany")
                    .HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Stamp).HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.Transport).HasColumnType("decimal(36, 6)");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.MThrmsinterviewSchedule)
                    .HasForeignKey(d => d.CandidateId)
                    .HasConstraintName("FK_mTHRMSInterviewSchedule_mTHRMSCVRepository");

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.MThrmsinterviewSchedule)
                    .HasForeignKey(d => d.DesignationId)
                    .HasConstraintName("FK_mTHRMSInterviewSchedule_mTHRMSDesignation");

                entity.HasOne(d => d.ManPower)
                    .WithMany(p => p.MThrmsinterviewSchedule)
                    .HasForeignKey(d => d.ManPowerId)
                    .HasConstraintName("FK_mTHRMSInterviewSchedule_mTHRMSManPowerBudget");

                entity.HasOne(d => d.Recruiter)
                    .WithMany(p => p.MThrmsinterviewSchedule)
                    .HasForeignKey(d => d.RecruiterId)
                    .HasConstraintName("FK_mTHRMSInterviewSchedule_mTHRMSEmployee");

                entity.HasOne(d => d.ResourceAllocation)
                    .WithMany(p => p.MThrmsinterviewSchedule)
                    .HasForeignKey(d => d.ResourceAllocationId)
                    .HasConstraintName("FK_mTHRMSInterviewSchedule_mTHRMSResourceAllocation");

                entity.HasOne(d => d.ResourceRequisition)
                    .WithMany(p => p.MThrmsinterviewSchedule)
                    .HasForeignKey(d => d.ResourceRequisitionId)
                    .HasConstraintName("FK_mTHRMSInterviewSchedule_mTHRMSResourceRequisition");

                entity.HasOne(d => d.Shortlist)
                    .WithMany(p => p.MThrmsinterviewSchedule)
                    .HasForeignKey(d => d.ShortlistId)
                    .HasConstraintName("FK_mTHRMSInterviewSchedule_mTHRMSShortlist");

                entity.HasOne(d => d.Sourcing)
                    .WithMany(p => p.MThrmsinterviewSchedule)
                    .HasForeignKey(d => d.SourcingId)
                    .HasConstraintName("FK_mTHRMSInterviewSchedule_mTHRMSSourcing");
            });

            modelBuilder.Entity<MThrmsinterviewScheduleRoundDetails>(entity =>
            {
                entity.ToTable("mTHRMSInterviewScheduleRoundDetails");

                entity.Property(e => e.MThrmsinterviewScheduleRoundDetailsId).HasColumnName("mTHRMSInterviewScheduleRoundDetailsId");

                entity.HasOne(d => d.InterviewSchedule)
                    .WithMany(p => p.MThrmsinterviewScheduleRoundDetails)
                    .HasForeignKey(d => d.InterviewScheduleId)
                    .HasConstraintName("FK_mTHRMSInterviewScheduleRoundDetails_mTHRMSInterviewSchedule");

                entity.HasOne(d => d.InterviewScheduleRound)
                    .WithMany(p => p.MThrmsinterviewScheduleRoundDetails)
                    .HasForeignKey(d => d.InterviewScheduleRoundId)
                    .HasConstraintName("FK_mTHRMSInterviewScheduleRoundDetails_mTHRMSInterviewScheduleRounds");

                entity.HasOne(d => d.Interviewer)
                    .WithMany(p => p.MThrmsinterviewScheduleRoundDetails)
                    .HasForeignKey(d => d.InterviewerId)
                    .HasConstraintName("FK_mTHRMSInterviewScheduleRoundDetails_mTHRMSEmployee");
            });

            modelBuilder.Entity<MThrmsinterviewScheduleRounds>(entity =>
            {
                entity.ToTable("mTHRMSInterviewScheduleRounds");

                entity.Property(e => e.MThrmsinterviewScheduleRoundsId).HasColumnName("mTHRMSInterviewScheduleRoundsId");

                entity.Property(e => e.CandidatePlanDate).HasColumnType("datetime");

                entity.Property(e => e.InterviewPlanDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.InterviewSchedule)
                    .WithMany(p => p.MThrmsinterviewScheduleRounds)
                    .HasForeignKey(d => d.InterviewScheduleId)
                    .HasConstraintName("FK_mTHRMSInterviewScheduleRounds_mTHRMSInterviewSchedule");

                entity.HasOne(d => d.Round)
                    .WithMany(p => p.MThrmsinterviewScheduleRounds)
                    .HasForeignKey(d => d.RoundId)
                    .HasConstraintName("FK_mTHRMSInterviewScheduleRounds_mTHRMSInterviewRoundsDefinition");
            });

            modelBuilder.Entity<MThrmsinventory>(entity =>
            {
                entity.HasKey(e => e.MThrmsinventory1);

                entity.ToTable("mTHRMSInventory");

                entity.Property(e => e.MThrmsinventory1).HasColumnName("mTHRMSInventory");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<MThrmsinventoryManagement>(entity =>
            {
                entity.ToTable("mTHRMSInventoryManagement");

                entity.Property(e => e.MThrmsinventoryManagementId).HasColumnName("mTHRMSInventoryManagementId");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.MThrmsinventoryManagement)
                    .HasForeignKey(d => d.CandidateId)
                    .HasConstraintName("FK_mTHRMSInventoryManagement_mTHRMSCVRepository");

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.MThrmsinventoryManagement)
                    .HasForeignKey(d => d.DesignationId)
                    .HasConstraintName("FK_mTHRMSInventoryManagement_mTHRMSDesignation");

                entity.HasOne(d => d.ManPower)
                    .WithMany(p => p.MThrmsinventoryManagement)
                    .HasForeignKey(d => d.ManPowerId)
                    .HasConstraintName("FK_mTHRMSInventoryManagement_mTHRMSManPowerBudget");

                entity.HasOne(d => d.OfferLetter)
                    .WithMany(p => p.MThrmsinventoryManagement)
                    .HasForeignKey(d => d.OfferLetterId)
                    .HasConstraintName("FK_mTHRMSInventoryManagement_mTHRMSOfferLetter");

                entity.HasOne(d => d.Recruiter)
                    .WithMany(p => p.MThrmsinventoryManagement)
                    .HasForeignKey(d => d.RecruiterId)
                    .HasConstraintName("FK_mTHRMSInventoryManagement_mTHRMSEmployee");

                entity.HasOne(d => d.ResourceAllocation)
                    .WithMany(p => p.MThrmsinventoryManagement)
                    .HasForeignKey(d => d.ResourceAllocationId)
                    .HasConstraintName("FK_mTHRMSInventoryManagement_mTHRMSResourceAllocation");

                entity.HasOne(d => d.ResourceRequisition)
                    .WithMany(p => p.MThrmsinventoryManagement)
                    .HasForeignKey(d => d.ResourceRequisitionId)
                    .HasConstraintName("FK_mTHRMSInventoryManagement_mTHRMSResourceRequisition");

                entity.HasOne(d => d.Shortlist)
                    .WithMany(p => p.MThrmsinventoryManagement)
                    .HasForeignKey(d => d.ShortlistId)
                    .HasConstraintName("FK_mTHRMSInventoryManagement_mTHRMSShortlist");

                entity.HasOne(d => d.Sourcing)
                    .WithMany(p => p.MThrmsinventoryManagement)
                    .HasForeignKey(d => d.SourcingId)
                    .HasConstraintName("FK_mTHRMSInventoryManagement_mTHRMSSourcing");
            });

            modelBuilder.Entity<MThrmsinventoryManagementDetails>(entity =>
            {
                entity.ToTable("mTHRMSInventoryManagementDetails");

                entity.Property(e => e.MThrmsinventoryManagementDetailsId).HasColumnName("mTHRMSInventoryManagementDetailsId");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.EmployeeResponsible)
                    .WithMany(p => p.MThrmsinventoryManagementDetails)
                    .HasForeignKey(d => d.EmployeeResponsibleId)
                    .HasConstraintName("FK_mTHRMSInventoryManagementDetails_mTHRMSEmployee");

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.MThrmsinventoryManagementDetails)
                    .HasForeignKey(d => d.InventoryId)
                    .HasConstraintName("FK_mTHRMSInventoryManagementDetails_mTHRMSInventory");

                entity.HasOne(d => d.InventoryManagement)
                    .WithMany(p => p.MThrmsinventoryManagementDetails)
                    .HasForeignKey(d => d.InventoryManagementId)
                    .HasConstraintName("FK_mTHRMSInventoryManagementDetails_mTHRMSInventoryManagement");
            });

            modelBuilder.Entity<MThrmsmanPowerBudget>(entity =>
            {
                entity.ToTable("mTHRMSManPowerBudget");

                entity.Property(e => e.MThrmsmanPowerBudgetId).HasColumnName("mTHRMSManPowerBudgetId");

                entity.Property(e => e.Basic).HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Cola)
                    .HasColumnName("COLA")
                    .HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Gross).HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Housing).HasColumnType("decimal(36, 6)");

                entity.Property(e => e.MThrmsbranchId).HasColumnName("mTHRMSBranchId");

                entity.Property(e => e.MThrmscompanyId).HasColumnName("mTHRMSCompanyId");

                entity.Property(e => e.MThrmsdepartmentId).HasColumnName("mTHRMSDepartmentId");

                entity.Property(e => e.MThrmsdesignationId).HasColumnName("mTHRMSDesignationId");

                entity.Property(e => e.ManPowerBudgetCode).HasMaxLength(50);

                entity.Property(e => e.Pitax)
                    .HasColumnName("PITax")
                    .HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Si)
                    .HasColumnName("SI")
                    .HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Sicompany)
                    .HasColumnName("SICompany")
                    .HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Stamp).HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TotalBudget).HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Transport).HasColumnType("decimal(36, 6)");

                entity.HasOne(d => d.MThrmsbranch)
                    .WithMany(p => p.MThrmsmanPowerBudget)
                    .HasForeignKey(d => d.MThrmsbranchId)
                    .HasConstraintName("FK_mTHRMSManPowerBudget_mTHRMSBranch");

                entity.HasOne(d => d.MThrmscompany)
                    .WithMany(p => p.MThrmsmanPowerBudget)
                    .HasForeignKey(d => d.MThrmscompanyId)
                    .HasConstraintName("FK_mTHRMSManPowerBudget_mTHRMSCompany");

                entity.HasOne(d => d.MThrmsdepartment)
                    .WithMany(p => p.MThrmsmanPowerBudget)
                    .HasForeignKey(d => d.MThrmsdepartmentId)
                    .HasConstraintName("FK_mTHRMSManPowerBudget_mTHRMSDepartment");

                entity.HasOne(d => d.MThrmsdesignation)
                    .WithMany(p => p.MThrmsmanPowerBudget)
                    .HasForeignKey(d => d.MThrmsdesignationId)
                    .HasConstraintName("FK_mTHRMSManPowerBudget_mTHRMSDesignation");
            });

            modelBuilder.Entity<MThrmsofferLetter>(entity =>
            {
                entity.ToTable("mTHRMSOfferLetter");

                entity.Property(e => e.MThrmsofferLetterId).HasColumnName("mTHRMSOfferLetterId");

                entity.Property(e => e.AnnualLeaveDetails).HasMaxLength(50);

                entity.Property(e => e.Basic).HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Cola)
                    .HasColumnName("COLA")
                    .HasColumnType("decimal(36, 6)");

                entity.Property(e => e.EffectiveFrom).HasColumnType("datetime");

                entity.Property(e => e.Gross).HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Housing).HasColumnType("decimal(36, 6)");

                entity.Property(e => e.OfferLetterDate).HasColumnType("datetime");

                entity.Property(e => e.Pitax)
                    .HasColumnName("PITax")
                    .HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Si)
                    .HasColumnName("SI")
                    .HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Sicompany)
                    .HasColumnName("SICompany")
                    .HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Stamp).HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Transport).HasColumnType("decimal(36, 6)");

                entity.Property(e => e.TypeOfContract).HasMaxLength(50);

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.MThrmsofferLetter)
                    .HasForeignKey(d => d.CandidateId)
                    .HasConstraintName("FK_mTHRMSOfferLetter_mTHRMSCVRepository");

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.MThrmsofferLetter)
                    .HasForeignKey(d => d.DesignationId)
                    .HasConstraintName("FK_mTHRMSOfferLetter_mTHRMSDesignation");

                entity.HasOne(d => d.ManPower)
                    .WithMany(p => p.MThrmsofferLetter)
                    .HasForeignKey(d => d.ManPowerId)
                    .HasConstraintName("FK_mTHRMSOfferLetter_mTHRMSManPowerBudget");

                entity.HasOne(d => d.Recruiter)
                    .WithMany(p => p.MThrmsofferLetter)
                    .HasForeignKey(d => d.RecruiterId)
                    .HasConstraintName("FK_mTHRMSOfferLetter_mTHRMSEmployee");

                entity.HasOne(d => d.ResourceAllocation)
                    .WithMany(p => p.MThrmsofferLetter)
                    .HasForeignKey(d => d.ResourceAllocationId)
                    .HasConstraintName("FK_mTHRMSOfferLetter_mTHRMSResourceAllocation");

                entity.HasOne(d => d.ResourceRequisition)
                    .WithMany(p => p.MThrmsofferLetter)
                    .HasForeignKey(d => d.ResourceRequisitionId)
                    .HasConstraintName("FK_mTHRMSOfferLetter_mTHRMSResourceRequisition");

                entity.HasOne(d => d.Shortlist)
                    .WithMany(p => p.MThrmsofferLetter)
                    .HasForeignKey(d => d.ShortlistId)
                    .HasConstraintName("FK_mTHRMSOfferLetter_mTHRMSShortlist");

                entity.HasOne(d => d.Sourcing)
                    .WithMany(p => p.MThrmsofferLetter)
                    .HasForeignKey(d => d.SourcingId)
                    .HasConstraintName("FK_mTHRMSOfferLetter_mTHRMSSourcing");
            });

            modelBuilder.Entity<MThrmsonboarding>(entity =>
            {
                entity.ToTable("mTHRMSOnboarding");

                entity.Property(e => e.MThrmsonboardingId).HasColumnName("mTHRMSOnboardingId");

                entity.Property(e => e.OnboardingDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.CandidateEntry)
                    .WithMany(p => p.MThrmsonboarding)
                    .HasForeignKey(d => d.CandidateEntryId)
                    .HasConstraintName("FK_mTHRMSOnboarding_mTHRMSCandidateEntry");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.MThrmsonboarding)
                    .HasForeignKey(d => d.CandidateId)
                    .HasConstraintName("FK_mTHRMSOnboarding_mTHRMSCVRepository");

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.MThrmsonboarding)
                    .HasForeignKey(d => d.DesignationId)
                    .HasConstraintName("FK_mTHRMSOnboarding_mTHRMSDesignation");

                entity.HasOne(d => d.InventoryManagement)
                    .WithMany(p => p.MThrmsonboarding)
                    .HasForeignKey(d => d.InventoryManagementId)
                    .HasConstraintName("FK_mTHRMSOnboarding_mTHRMSInventoryManagement");

                entity.HasOne(d => d.ManPower)
                    .WithMany(p => p.MThrmsonboarding)
                    .HasForeignKey(d => d.ManPowerId)
                    .HasConstraintName("FK_mTHRMSOnboarding_mTHRMSManPowerBudget");

                entity.HasOne(d => d.OfferLetter)
                    .WithMany(p => p.MThrmsonboarding)
                    .HasForeignKey(d => d.OfferLetterId)
                    .HasConstraintName("FK_mTHRMSOnboarding_mTHRMSOfferLetter");

                entity.HasOne(d => d.Recruiter)
                    .WithMany(p => p.MThrmsonboarding)
                    .HasForeignKey(d => d.RecruiterId)
                    .HasConstraintName("FK_mTHRMSOnboarding_mTHRMSEmployee");

                entity.HasOne(d => d.ResourceAllocation)
                    .WithMany(p => p.MThrmsonboarding)
                    .HasForeignKey(d => d.ResourceAllocationId)
                    .HasConstraintName("FK_mTHRMSOnboarding_mTHRMSResourceAllocation");

                entity.HasOne(d => d.ResourceRequisition)
                    .WithMany(p => p.MThrmsonboarding)
                    .HasForeignKey(d => d.ResourceRequisitionId)
                    .HasConstraintName("FK_mTHRMSOnboarding_mTHRMSResourceRequisition");

                entity.HasOne(d => d.Shortlist)
                    .WithMany(p => p.MThrmsonboarding)
                    .HasForeignKey(d => d.ShortlistId)
                    .HasConstraintName("FK_mTHRMSOnboarding_mTHRMSShortlist");

                entity.HasOne(d => d.Sourcing)
                    .WithMany(p => p.MThrmsonboarding)
                    .HasForeignKey(d => d.SourcingId)
                    .HasConstraintName("FK_mTHRMSOnboarding_mTHRMSSourcing");
            });

            modelBuilder.Entity<MThrmsresourceAllocation>(entity =>
            {
                entity.ToTable("mTHRMSResourceAllocation");

                entity.Property(e => e.MThrmsresourceAllocationId).HasColumnName("mTHRMSResourceAllocationId");

                entity.Property(e => e.Basic).HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Cola)
                    .HasColumnName("COLA")
                    .HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Gross).HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Housing).HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Pitax)
                    .HasColumnName("PITax")
                    .HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Si)
                    .HasColumnName("SI")
                    .HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Sicompany)
                    .HasColumnName("SICompany")
                    .HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Stamp).HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Transport).HasColumnType("decimal(36, 6)");

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.MThrmsresourceAllocation)
                    .HasForeignKey(d => d.DesignationId)
                    .HasConstraintName("FK_mTHRMSResourceAllocation_mTHRMSDesignation");

                entity.HasOne(d => d.ManPower)
                    .WithMany(p => p.MThrmsresourceAllocation)
                    .HasForeignKey(d => d.ManPowerId)
                    .HasConstraintName("FK_mTHRMSResourceAllocation_mTHRMSManPowerBudget");

                entity.HasOne(d => d.Recruiter)
                    .WithMany(p => p.MThrmsresourceAllocation)
                    .HasForeignKey(d => d.RecruiterId)
                    .HasConstraintName("FK_mTHRMSResourceAllocation_mTHRMSEmployee");

                entity.HasOne(d => d.ResourceRequisition)
                    .WithMany(p => p.MThrmsresourceAllocation)
                    .HasForeignKey(d => d.ResourceRequisitionId)
                    .HasConstraintName("FK_mTHRMSResourceAllocation_mTHRMSResourceRequisition");
            });

            modelBuilder.Entity<MThrmsresourceRequisition>(entity =>
            {
                entity.ToTable("mTHRMSResourceRequisition");

                entity.Property(e => e.MThrmsresourceRequisitionId).HasColumnName("mTHRMSResourceRequisitionId");

                entity.Property(e => e.Basic).HasColumnType("decimal(36, 6)");

                entity.Property(e => e.CloseDate).HasColumnType("datetime");

                entity.Property(e => e.Cola)
                    .HasColumnName("COLA")
                    .HasColumnType("decimal(36, 6)");

                entity.Property(e => e.ContractType).HasMaxLength(50);

                entity.Property(e => e.Gross).HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Housing).HasColumnType("decimal(36, 6)");

                entity.Property(e => e.JobTiming).HasMaxLength(50);

                entity.Property(e => e.Pitax)
                    .HasColumnName("PITax")
                    .HasColumnType("decimal(36, 6)");

                entity.Property(e => e.PlannedClosingDate).HasColumnType("datetime");

                entity.Property(e => e.ReasonOfLeave).HasMaxLength(50);

                entity.Property(e => e.Remarks).HasMaxLength(50);

                entity.Property(e => e.RequisitionType).HasMaxLength(50);

                entity.Property(e => e.Si)
                    .HasColumnName("SI")
                    .HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Sicompany)
                    .HasColumnName("SICompany")
                    .HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Stamp).HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.Transport).HasColumnType("decimal(36, 6)");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.MThrmsresourceRequisition)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK_mTHRMSResourceRequisition_mTHRMSBranch");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.MThrmsresourceRequisition)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_mTHRMSResourceRequisition_mTHRMSCompany");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.MThrmsresourceRequisition)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_mTHRMSResourceRequisition_mTHRMSDepartment");

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.MThrmsresourceRequisition)
                    .HasForeignKey(d => d.DesignationId)
                    .HasConstraintName("FK_mTHRMSResourceRequisition_mTHRMSDesignation");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.MThrmsresourceRequisitionEmployee)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_mTHRMSResourceRequisition_mTHRMSEmployee2");

                entity.HasOne(d => d.ManPower)
                    .WithMany(p => p.MThrmsresourceRequisition)
                    .HasForeignKey(d => d.ManPowerId)
                    .HasConstraintName("FK_mTHRMSResourceRequisition_mTHRMSManPowerBudget");

                entity.HasOne(d => d.Subordinate)
                    .WithMany(p => p.MThrmsresourceRequisitionSubordinate)
                    .HasForeignKey(d => d.SubordinateId)
                    .HasConstraintName("FK_mTHRMSResourceRequisition_mTHRMSEmployee1");

                entity.HasOne(d => d.Supervisor)
                    .WithMany(p => p.MThrmsresourceRequisitionSupervisor)
                    .HasForeignKey(d => d.SupervisorId)
                    .HasConstraintName("FK_mTHRMSResourceRequisition_mTHRMSEmployee");
            });

            modelBuilder.Entity<MThrmsshortlist>(entity =>
            {
                entity.ToTable("mTHRMSShortlist");

                entity.Property(e => e.MThrmsshortlistId).HasColumnName("mTHRMSShortlistId");

                entity.Property(e => e.Basic).HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Cola)
                    .HasColumnName("COLA")
                    .HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Gross).HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Housing).HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Pitax)
                    .HasColumnName("PITax")
                    .HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Si)
                    .HasColumnName("SI")
                    .HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Sicompany)
                    .HasColumnName("SICompany")
                    .HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Stamp).HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.Transport).HasColumnType("decimal(36, 6)");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.MThrmsshortlist)
                    .HasForeignKey(d => d.CandidateId)
                    .HasConstraintName("FK_mTHRMSShortlist_mTHRMSCVRepository");

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.MThrmsshortlist)
                    .HasForeignKey(d => d.DesignationId)
                    .HasConstraintName("FK_mTHRMSShortlist_mTHRMSDesignation");

                entity.HasOne(d => d.ManPower)
                    .WithMany(p => p.MThrmsshortlist)
                    .HasForeignKey(d => d.ManPowerId)
                    .HasConstraintName("FK_mTHRMSShortlist_mTHRMSManPowerBudget");

                entity.HasOne(d => d.Recruiter)
                    .WithMany(p => p.MThrmsshortlist)
                    .HasForeignKey(d => d.RecruiterId)
                    .HasConstraintName("FK_mTHRMSShortlist_mTHRMSEmployee");

                entity.HasOne(d => d.ResourceAllocation)
                    .WithMany(p => p.MThrmsshortlist)
                    .HasForeignKey(d => d.ResourceAllocationId)
                    .HasConstraintName("FK_mTHRMSShortlist_mTHRMSResourceAllocation");

                entity.HasOne(d => d.ResourceRequisition)
                    .WithMany(p => p.MThrmsshortlist)
                    .HasForeignKey(d => d.ResourceRequisitionId)
                    .HasConstraintName("FK_mTHRMSShortlist_mTHRMSResourceRequisition");

                entity.HasOne(d => d.Sourcing)
                    .WithMany(p => p.MThrmsshortlist)
                    .HasForeignKey(d => d.SourcingId)
                    .HasConstraintName("FK_mTHRMSShortlist_mTHRMSSourcing");
            });

            modelBuilder.Entity<MThrmssourcing>(entity =>
            {
                entity.ToTable("mTHRMSSourcing");

                entity.Property(e => e.MThrmssourcingId).HasColumnName("mTHRMSSourcingId");

                entity.Property(e => e.Basic).HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Cola)
                    .HasColumnName("COLA")
                    .HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Gross).HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Housing).HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Pitax)
                    .HasColumnName("PITax")
                    .HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Si)
                    .HasColumnName("SI")
                    .HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Sicompany)
                    .HasColumnName("SICompany")
                    .HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Stamp).HasColumnType("decimal(36, 6)");

                entity.Property(e => e.Transport).HasColumnType("decimal(36, 6)");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.MThrmssourcing)
                    .HasForeignKey(d => d.CandidateId)
                    .HasConstraintName("FK_mTHRMSSourcing_mTHRMSCVRepository");

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.MThrmssourcing)
                    .HasForeignKey(d => d.DesignationId)
                    .HasConstraintName("FK_mTHRMSSourcing_mTHRMSDesignation");

                entity.HasOne(d => d.ManPower)
                    .WithMany(p => p.MThrmssourcing)
                    .HasForeignKey(d => d.ManPowerId)
                    .HasConstraintName("FK_mTHRMSSourcing_mTHRMSManPowerBudget");

                entity.HasOne(d => d.Recruiter)
                    .WithMany(p => p.MThrmssourcing)
                    .HasForeignKey(d => d.RecruiterId)
                    .HasConstraintName("FK_mTHRMSSourcing_mTHRMSEmployee");

                entity.HasOne(d => d.ResourceAllocation)
                    .WithMany(p => p.MThrmssourcing)
                    .HasForeignKey(d => d.ResourceAllocationId)
                    .HasConstraintName("FK_mTHRMSSourcing_mTHRMSResourceAllocation");

                entity.HasOne(d => d.ResourceRequisition)
                    .WithMany(p => p.MThrmssourcing)
                    .HasForeignKey(d => d.ResourceRequisitionId)
                    .HasConstraintName("FK_mTHRMSSourcing_mTHRMSResourceRequisition");
            });

            modelBuilder.Entity<MThrmsfiletest>(entity =>
            {
                entity.ToTable("mTHRMSfiletest");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fileupload)
                    .HasColumnName("fileupload")
                    .HasColumnType("image");
            });

            modelBuilder.Entity<MThrmsattendance>(entity =>
            {
                entity.ToTable("mTHRMSAttendance");

                entity.Property(e => e.MThrmsattendanceId).HasColumnName("mTHRMSAttendanceId");

                entity.Property(e => e.Attendancedate)
                    .HasColumnName("attendancedate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Checkin)
                    .HasColumnName("checkin")
                    .HasColumnType("datetime");

                entity.Property(e => e.Checkout)
                    .HasColumnName("checkout")
                    .HasColumnType("datetime");

                entity.Property(e => e.MThrmsemployeeId).HasColumnName("mTHRMSEmployeeId");

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(50);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(50);

                entity.Property(e => e.Workingdate).HasColumnName("workingdate");
            });

            modelBuilder.HasSequence("Seq_CRMLead").StartsAt(101);

            modelBuilder.HasSequence("Seq_mAddress").StartsAt(801);

            modelBuilder.HasSequence("Seq_mBranch").StartsAt(201);

            modelBuilder.HasSequence("Seq_mBrand").StartsAt(101);

            modelBuilder.HasSequence("Seq_mCategory").StartsAt(9001);

            modelBuilder.HasSequence("Seq_mCity").StartsAt(1300001);

            modelBuilder.HasSequence("Seq_mCompany").StartsAt(10001);

            modelBuilder.HasSequence("Seq_mContact").StartsAt(601);

            modelBuilder.HasSequence("Seq_mCostCenter").StartsAt(301);

            modelBuilder.HasSequence("Seq_mCountry").StartsAt(13001);

            modelBuilder.HasSequence("Seq_mCurrency").StartsAt(1001);

            modelBuilder.HasSequence("Seq_mEmail").StartsAt(501);

            modelBuilder.HasSequence("Seq_mFinancialYear").StartsAt(50001);

            modelBuilder.HasSequence("Seq_mLedger").StartsAt(100001);

            modelBuilder.HasSequence("Seq_mMobile").StartsAt(701);

            modelBuilder.HasSequence("Seq_mNewsLetter");

            modelBuilder.HasSequence("Seq_mPhone").StartsAt(401);

            modelBuilder.HasSequence("Seq_mState").StartsAt(130001);

            modelBuilder.HasSequence("Seq_mTask").StartsAt(20001);

            modelBuilder.HasSequence("Seq_mTaskActivity").StartsAt(20001);

            modelBuilder.HasSequence("Seq_mTaskActivityPreceding").StartsAt(20001);

            modelBuilder.HasSequence("Seq_mTaskAssignment").StartsAt(20001);

            modelBuilder.HasSequence("Seq_mTaskPreceding").StartsAt(20001);

            modelBuilder.HasSequence("Seq_mTRIALSp").StartsAt(101);

            modelBuilder.HasSequence("Seq_mUnit").StartsAt(40001);

            modelBuilder.HasSequence("Seq_mUser").StartsAt(300001);

            modelBuilder.HasSequence("Seq_txnMail");

            modelBuilder.HasSequence("seq_txnMailHistoryId");
        }
    }
}
