using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MedWorking.Core.EntityFramework.Models
{
    public partial class MedWorkingContext : DbContext
    {
        public MedWorkingContext()
        {
        }

        public MedWorkingContext(DbContextOptions<MedWorkingContext> options)
            : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<ApprovalGeneralDocumentProcess> ApprovalGeneralDocumentProcesses { get; set; } = null!;
        public virtual DbSet<ApprovalGeneralDocumentProcessUnit> ApprovalGeneralDocumentProcessUnits { get; set; } = null!;
        public virtual DbSet<ConfigColumn> ConfigColumns { get; set; } = null!;
        public virtual DbSet<ConfigureBrowsingStep> ConfigureBrowsingSteps { get; set; } = null!;
        public virtual DbSet<Decentralize> Decentralizes { get; set; } = null!;
        public virtual DbSet<DecentralizeDocUser> DecentralizeDocUsers { get; set; } = null!;
        public virtual DbSet<DecentralizeDocument> DecentralizeDocuments { get; set; } = null!;
        public virtual DbSet<GroupDocument> GroupDocuments { get; set; } = null!;
        public virtual DbSet<ImplementingAgency> ImplementingAgencies { get; set; } = null!;
        public virtual DbSet<Office> Offices { get; set; } = null!;
        public virtual DbSet<PatternDocDetailByGroupDocGeneral> PatternDocDetailByGroupDocGenerals { get; set; } = null!;
        public virtual DbSet<PatternDocOffice> PatternDocOffices { get; set; } = null!;
        public virtual DbSet<PatternDocument> PatternDocuments { get; set; } = null!;
        public virtual DbSet<PatternDocumentDetailByGroupDocument> PatternDocumentDetailByGroupDocuments { get; set; } = null!;
        public virtual DbSet<Position> Positions { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<RoleDecentralize> RoleDecentralizes { get; set; } = null!;
        public virtual DbSet<TextBrowsingStep> TextBrowsingSteps { get; set; } = null!;
        public virtual DbSet<TextBrowsingStepsUnit> TextBrowsingStepsUnits { get; set; } = null!;
        public virtual DbSet<UserIdRole> UserIdRoles { get; set; } = null!;
        public virtual DbSet<UserImplement> UserImplements { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;
        public virtual DbSet<ViewAccountDetail> ViewAccountDetails { get; set; } = null!;
        public virtual DbSet<ViewApprovalGeneralDocumentProcess> ViewApprovalGeneralDocumentProcesses { get; set; } = null!;
        public virtual DbSet<ViewApprovalGeneralDocumentProcessUnit> ViewApprovalGeneralDocumentProcessUnits { get; set; } = null!;
        public virtual DbSet<ViewConfigureBrowsingStep> ViewConfigureBrowsingSteps { get; set; } = null!;
        public virtual DbSet<ViewDecentralizeDocument> ViewDecentralizeDocuments { get; set; } = null!;
        public virtual DbSet<ViewGetDetailUserRole> ViewGetDetailUserRoles { get; set; } = null!;
        public virtual DbSet<ViewInfoAccountDetail> ViewInfoAccountDetails { get; set; } = null!;
        public virtual DbSet<ViewSampleDocument> ViewSampleDocuments { get; set; } = null!;
        public virtual DbSet<ViewGetImplementOfficeOfConfigStep> ViewGetImplementOfficeOfConfigSteps { get; set; } = null!;
        public virtual DbSet<ViewGetImplementOfficeOfPatternDoc> ViewGetImplementOfficeOfPatternDocs { get; set; } = null!;
        public virtual DbSet<ViewDocumentDetailById> ViewDocumentDetailByIds { get; set; } = null!;
        public virtual DbSet<AdvisoryOffice> AdvisoryOffices { get; set; } = null!;
        public virtual DbSet<AdvisoryStaff> AdvisoryStaffs { get; set; } = null!;
        public virtual DbSet<ApprovalOfficeLevel> ApprovalOfficeLevels { get; set; } = null!;
        public virtual DbSet<ApprovalStaffLevel> ApprovalStaffLevels { get; set; } = null!;
        public virtual DbSet<ApprovalStepLevel> ApprovalStepLevels { get; set; } = null!;
        public virtual DbSet<DocumentAdvisory> DocumentAdvisories { get; set; } = null!;
        public virtual DbSet<DocumentComment> DocumentComments { get; set; } = null!;
        public virtual DbSet<DocumentImplementation> DocumentImplementations { get; set; } = null!;
        public virtual DbSet<Document> Documents { get; set; } = null!;
        public virtual DbSet<DocumentReference> DocumentReferences { get; set; } = null!;
        public virtual DbSet<DirectorApprovation> DirectorApprovations { get; set; } = null!;
        public virtual DbSet<FileReference> FileReferences { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=MedWorking_Dev;Username=postgres;Password=@Du18medworking;", x => x.UseNetTopologySuite());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("Accounts_pkey");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.AvatarUrl).HasMaxLength(500);

                entity.Property(e => e.CreateUser).HasMaxLength(20);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(50)
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.FullName).HasMaxLength(250);

                entity.Property(e => e.Hc).HasColumnName("HC");

                entity.Property(e => e.CreateDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.UpdateDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.PasswordHash).HasMaxLength(200);

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.Property(e => e.SerialNumber).HasMaxLength(50);

                entity.Property(e => e.SignatureUrl).HasMaxLength(500);

                entity.Property(e => e.UpdateUser).HasMaxLength(20);

                entity.Property(e => e.UserName).HasMaxLength(100);
            });

            modelBuilder.Entity<ApprovalGeneralDocumentProcess>(entity =>
            {
                entity.ToTable("ApprovalGeneralDocumentProcess");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.TimeApplication).HasColumnType("timestamp with time zone");

                entity.Property(e => e.UpdateDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.CreateUser).HasMaxLength(250);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.UpdateUser).HasMaxLength(250);
            });

            modelBuilder.Entity<ApprovalGeneralDocumentProcessUnit>(entity =>
            {
                entity.ToTable("ApprovalGeneralDocumentProcessUnit");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.TimeApplication).HasColumnType("timestamp with time zone");

                entity.Property(e => e.UpdateDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.CreateUser).HasMaxLength(250);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.UpdateUser).HasMaxLength(250);
            });


            modelBuilder.Entity<ConfigColumn>(entity =>
            {
                entity.ToTable("ConfigColumn");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.UpdateDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.CreateUser).HasMaxLength(200);

                entity.Property(e => e.UpdateUser).HasMaxLength(200);
            });

            modelBuilder.Entity<ConfigureBrowsingStep>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AllOffice).HasMaxLength(5);

                entity.Property(e => e.CreateDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.UpdateDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.CreateUser).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.StepName).HasMaxLength(250);

                entity.Property(e => e.UpdateUser).HasMaxLength(100);
            });

            modelBuilder.Entity<Decentralize>(entity =>
            {
                entity.ToTable("Decentralize");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.CreateUser).HasMaxLength(250);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Name).HasColumnType("character varying");

                entity.Property(e => e.UpdateDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.UpdateUser).HasMaxLength(250);
            });

            modelBuilder.Entity<DecentralizeDocUser>(entity =>
            {
                entity.ToTable("DecentralizeDocUser");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateUser).HasMaxLength(250);

                entity.Property(e => e.CreateDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.UpdateDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.DecentralizeDocumentNote).HasMaxLength(250);

                entity.Property(e => e.EmployeeId).HasMaxLength(250);

                entity.Property(e => e.UpdateUser).HasMaxLength(250);
            });

            modelBuilder.Entity<DecentralizeDocument>(entity =>
            {
                entity.ToTable("DecentralizeDocument");

                entity.Property(e => e.Id).ValueGeneratedNever();
                
                entity.Property(e => e.CreateDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.UpdateDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.CreateUser).HasMaxLength(250);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.UpdateUser).HasMaxLength(250);
            });

            modelBuilder.Entity<GroupDocument>(entity =>
            {
                entity.HasKey(e => e.GroupDocId)
                    .HasName("GroupDocId_pkey");

                entity.Property(e => e.GroupDocId).ValueGeneratedNever();

                entity.Property(e => e.AdvisoryUnit).HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.CreateUser).HasMaxLength(20);

                entity.Property(e => e.DocActive).HasComment("trạng thái nhóm văn bản");

                entity.Property(e => e.DocNode).HasMaxLength(500);

                entity.Property(e => e.DocType).HasComment("0: Thông báo/phát hành\n1: Thực hiện");

                entity.Property(e => e.GroupDocCode).HasMaxLength(10);

                entity.Property(e => e.GroupDocName).HasMaxLength(500);

                entity.Property(e => e.UpdateDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.UpdateUser).HasMaxLength(20);
            });

            modelBuilder.Entity<ImplementingAgency>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(500);
            });

            modelBuilder.Entity<Office>(entity =>
            {
                entity.ToTable("Office");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateUser).HasMaxLength(20);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.OfficeName).HasMaxLength(250);

                entity.Property(e => e.UpdateUser).HasMaxLength(20);
            });

            modelBuilder.Entity<PatternDocDetailByGroupDocGeneral>(entity =>
            {
                entity.ToTable("PatternDocDetailByGroupDocGeneral");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<PatternDocOffice>(entity =>
            {
                entity.ToTable("PatternDocOffice");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<PatternDocument>(entity =>
            {
                entity.HasKey(e => e.PatternDocId)
                    .HasName("PatternDocument_pkey");

                entity.ToTable("PatternDocument");

                entity.Property(e => e.PatternDocId).ValueGeneratedNever();

                entity.Property(e => e.CreateDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.CreateUser).HasMaxLength(20);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.DocumentValue).HasMaxLength(250);

                entity.Property(e => e.PatternDocCode).HasMaxLength(10);

                entity.Property(e => e.PatternDocName).HasMaxLength(500);

                entity.Property(e => e.UpdateDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.UpdateUser).HasMaxLength(20);
            });

            modelBuilder.Entity<PatternDocumentDetailByGroupDocument>(entity =>
            {
                entity.ToTable("PatternDocumentDetailByGroupDocument");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("Position");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateUser).HasMaxLength(20);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.PositionName).HasMaxLength(250);

                entity.Property(e => e.UpdateUser).HasMaxLength(20);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.UpdateDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.CreateUser).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.RoleCode).HasMaxLength(10);

                entity.Property(e => e.RoleName).HasMaxLength(250);

                entity.Property(e => e.UpdateUser).HasMaxLength(100);
            });

            modelBuilder.Entity<RoleDecentralize>(entity =>
            {
                entity.ToTable("RoleDecentralize");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<TextBrowsingStep>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Stt).HasColumnName("stt");
            });

            modelBuilder.Entity<TextBrowsingStepsUnit>(entity =>
            {
                entity.ToTable("TextBrowsingStepsUnit");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Stt).HasColumnName("stt");
            });

            modelBuilder.Entity<UserIdRole>(entity =>
            {
                entity.ToTable("UserId_Roles");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<UserImplement>(entity =>
            {
                entity.ToTable("UserImplement");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EmployeeId).HasMaxLength(50);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("UserRoles_pkey");

                entity.HasIndex(e => e.OfficeId, "fki_Fk_OfficeId");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.CreateDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.UpdateDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.CreateUser).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.EmployeeCode).HasMaxLength(10);

                entity.Property(e => e.EmployeeName).HasMaxLength(250);

               

                entity.Property(e => e.UpdateUser).HasMaxLength(100);
            });

            modelBuilder.Entity<ViewDocumentDetailById>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewDocumentDetailById");

                entity.Property(e => e.CreateUser).HasMaxLength(100);

                entity.Property(e => e.DocName).HasMaxLength(250);

                entity.Property(e => e.DocumentCode).HasMaxLength(20);

                entity.Property(e => e.Explaination).HasMaxLength(500);

                entity.Property(e => e.GroupDocName).HasMaxLength(500);

                entity.Property(e => e.Notes).HasMaxLength(500);

                entity.Property(e => e.PatternDocName).HasMaxLength(500);
            });

            modelBuilder.Entity<ViewAccountDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewAccountDetail");

                entity.Property(e => e.AvatarUrl).HasMaxLength(500);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(50)
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.FullName).HasMaxLength(250);

                entity.Property(e => e.OfficeName).HasMaxLength(250);

                entity.Property(e => e.Officeid).HasColumnName("officeid");

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.Property(e => e.PositionName).HasMaxLength(250);

                entity.Property(e => e.Positionid).HasColumnName("positionid");

                entity.Property(e => e.SerialNumber).HasMaxLength(50);

                entity.Property(e => e.SignatureUrl).HasMaxLength(500);

                entity.Property(e => e.UserName).HasMaxLength(100);
            });

            modelBuilder.Entity<ViewApprovalGeneralDocumentProcess>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewApprovalGeneralDocumentProcess");

                entity.Property(e => e.CreateUser).HasMaxLength(250);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.GroupDocName).HasMaxLength(500);
            });

            modelBuilder.Entity<ViewApprovalGeneralDocumentProcessUnit>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewApprovalGeneralDocumentProcessUnit");

                entity.Property(e => e.CreateUser).HasMaxLength(250);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.GroupDocName).HasMaxLength(500);

                entity.Property(e => e.OfficeName).HasMaxLength(250);
            });

            modelBuilder.Entity<ViewConfigureBrowsingStep>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewConfigureBrowsingSteps");

                entity.Property(e => e.AllOffice).HasMaxLength(5);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.OfficeName).HasMaxLength(250);

                entity.Property(e => e.StepName).HasMaxLength(250);
            });

            modelBuilder.Entity<ViewDecentralizeDocument>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewDecentralizeDocument");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.OfficeName).HasMaxLength(250);
            });

            modelBuilder.Entity<ViewGetDetailUserRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewGetDetailUserRole");

                entity.Property(e => e.CreateDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.EmployeeCode).HasMaxLength(10);

                entity.Property(e => e.EmployeeName).HasMaxLength(250);

                entity.Property(e => e.OfficeName).HasMaxLength(250);

                entity.Property(e => e.Officeid).HasColumnName("officeid");

                entity.Property(e => e.PositionName).HasMaxLength(250);

                entity.Property(e => e.Positionid).HasColumnName("positionid");

                entity.Property(e => e.Roleid).HasColumnName("roleid");

                entity.Property(e => e.Rolename).HasColumnName("rolename");
            });

            modelBuilder.Entity<ViewInfoAccountDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewInfoAccountDetail");

                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(50)
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.FullName).HasMaxLength(250);

                entity.Property(e => e.OfficeName).HasMaxLength(250);

                entity.Property(e => e.Officeid).HasColumnName("officeid");

                entity.Property(e => e.PositionName).HasMaxLength(250);

                entity.Property(e => e.Positionid).HasColumnName("positionid");

                entity.Property(e => e.UserName).HasMaxLength(100);
            });

            modelBuilder.Entity<ViewSampleDocument>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewSampleDocument");

                entity.Property(e => e.CreateDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.GroupDocName).HasMaxLength(500);

                entity.Property(e => e.Officename).HasColumnName("officename");

                entity.Property(e => e.PatternDocCode).HasMaxLength(10);

                entity.Property(e => e.PatternDocName).HasMaxLength(500);
            });

            modelBuilder.Entity<ViewGetImplementOfficeOfConfigStep>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewGetImplementOfficeOfConfigStep");

                entity.Property(e => e.OfficeName).HasMaxLength(250);
            });

            modelBuilder.Entity<ViewGetImplementOfficeOfPatternDoc>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewGetImplementOfficeOfPatternDoc");

                entity.Property(e => e.OfficeName).HasMaxLength(250);

                entity.Property(e => e.PatternDocCode).HasMaxLength(10);
            });

            modelBuilder.Entity<AdvisoryOffice>(entity =>
            {
                entity.ToTable("AdvisoryOffice");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DocId).ValueGeneratedNever();

                entity.Property(e => e.OfficeName).HasMaxLength(250);
            });

            modelBuilder.Entity<AdvisoryStaff>(entity =>
            {
                entity.ToTable("AdvisoryStaff");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AdvisoryOfficeId).ValueGeneratedNever();

                entity.Property(e => e.AdvisoryUserName).HasMaxLength(100);

                entity.Property(e => e.AdvisoryUserId).HasMaxLength(100);

            });
            
            modelBuilder.Entity<ApprovalOfficeLevel>(entity =>
            {
                entity.ToTable("ApprovalOfficeLevel");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.OfficeName).HasMaxLength(250);

                entity.Property(e => e.ApprovalStepLevelId).ValueGeneratedNever();

                entity.Property(e => e.OfficeId).HasColumnName("OfficeId");
            });

            modelBuilder.Entity<ApprovalStaffLevel>(entity =>
            {
                entity.ToTable("ApprovalStaffLevel");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ApprovalUserName).HasMaxLength(100);

                entity.Property(e => e.PositionName).HasMaxLength(250);

                entity.Property(e => e.ApprovalOfficeLevelId).ValueGeneratedNever();

                entity.Property(e => e.ApprovalUserId).HasMaxLength(100);
            });

            modelBuilder.Entity<ApprovalStepLevel>(entity =>
            {
                entity.ToTable("ApprovalStepLevel");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ApprovalStepLevelParentId).ValueGeneratedNever();

                entity.Property(e => e.StepName).HasMaxLength(250);

                entity.Property(e => e.ApprovalGeneralDocumentProcessId).ValueGeneratedNever();

                entity.Property(e => e.DocId).ValueGeneratedNever();
            });
            
            modelBuilder.Entity<DirectorApprovation>(entity =>
            {
                entity.ToTable("DirectorApprovation");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ApprovalUserId).HasMaxLength(100);

                entity.Property(e => e.DocId).ValueGeneratedNever();

                entity.Property(e => e.CreateDate).HasColumnType("timestamp with time zone");
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.ToTable("Document");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateUser).HasMaxLength(100);

                entity.Property(e => e.DocName).HasMaxLength(250);

                entity.Property(e => e.DocumentCode).HasMaxLength(20);

                entity.Property(e => e.Explaination).HasMaxLength(500);

                entity.Property(e => e.Notes).HasMaxLength(500);

                entity.Property(e => e.UpdateUser).HasMaxLength(100);

                entity.Property(e => e.GroupDocId).ValueGeneratedNever();

                entity.Property(e => e.PatternDocId).ValueGeneratedNever();

                entity.Property(e => e.ExpirationDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.CreateDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.UpdateDate).HasColumnType("timestamp with time zone");
            });

            modelBuilder.Entity<DocumentAdvisory>(entity =>
            {
                entity.ToTable("DocumentAdvisory");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DocId).ValueGeneratedNever();

                entity.Property(e => e.OfficeId).HasColumnName("OfficeId");
            });

            modelBuilder.Entity<DocumentComment>(entity =>
            {
                entity.ToTable("DocumentComment");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateUser).HasMaxLength(100);

                entity.Property(e => e.OfficeName).HasMaxLength(200);

                entity.Property(e => e.OfficeId).HasColumnName("OfficeId");

                entity.Property(e => e.UserId).HasMaxLength(100);

                entity.Property(e => e.CreateDate).HasColumnType("timestamp with time zone");
            });

            modelBuilder.Entity<DocumentImplementation>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DocId).ValueGeneratedNever();

                entity.Property(e => e.OfficeId).HasColumnName("OfficeId");
            });

            modelBuilder.Entity<DocumentReference>(entity =>
            {
                entity.ToTable("DocumentReference");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateUser).HasMaxLength(100);

                entity.Property(e => e.DocName).HasMaxLength(250);

                entity.Property(e => e.DocRefName).HasMaxLength(250);

                entity.Property(e => e.DocId).ValueGeneratedNever();

                entity.Property(e => e.CreateDate).HasColumnType("timestamp with time zone");
            });

            modelBuilder.Entity<FileReference>(entity =>
            {
                entity.ToTable("FileReference");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateUser).HasMaxLength(100);

                entity.Property(e => e.Extension).HasMaxLength(250);

                entity.Property(e => e.FileName).HasMaxLength(100);

                entity.Property(e => e.OriginalFileName).HasMaxLength(100);

                entity.Property(e => e.Path).HasMaxLength(250);

                entity.Property(e => e.DocId).ValueGeneratedNever();

                entity.Property(e => e.CreateDate).HasColumnType("timestamp with time zone");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
