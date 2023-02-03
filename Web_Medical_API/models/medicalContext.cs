using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Web_Medical_API.models
{
    public partial class medicalContext : DbContext
    {
        public medicalContext()
        {
        }

        public medicalContext(DbContextOptions<medicalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MAdmin> MAdmins { get; set; } = null!;
        public virtual DbSet<MBank> MBanks { get; set; } = null!;
        public virtual DbSet<MBiodataAddress> MBiodataAddresses { get; set; } = null!;
        public virtual DbSet<MBiodataAttachment> MBiodataAttachments { get; set; } = null!;
        public virtual DbSet<MBiodatum> MBiodata { get; set; } = null!;
        public virtual DbSet<MBloodGroup> MBloodGroups { get; set; } = null!;
        public virtual DbSet<MCourier> MCouriers { get; set; } = null!;
        public virtual DbSet<MCourierType> MCourierTypes { get; set; } = null!;
        public virtual DbSet<MCustomer> MCustomers { get; set; } = null!;
        public virtual DbSet<MCustomerMember> MCustomerMembers { get; set; } = null!;
        public virtual DbSet<MCustomerRelation> MCustomerRelations { get; set; } = null!;
        public virtual DbSet<MDoctor> MDoctors { get; set; } = null!;
        public virtual DbSet<MDoctorEducation> MDoctorEducations { get; set; } = null!;
        public virtual DbSet<MEducationLevel> MEducationLevels { get; set; } = null!;
        public virtual DbSet<MLocation> MLocations { get; set; } = null!;
        public virtual DbSet<MLocationLevel> MLocationLevels { get; set; } = null!;
        public virtual DbSet<MMedicalFacility> MMedicalFacilities { get; set; } = null!;
        public virtual DbSet<MMedicalFacilityCategory> MMedicalFacilityCategories { get; set; } = null!;
        public virtual DbSet<MMedicalFacilitySchedule> MMedicalFacilitySchedules { get; set; } = null!;
        public virtual DbSet<MMedicalItem> MMedicalItems { get; set; } = null!;
        public virtual DbSet<MMedicalItemCategory> MMedicalItemCategories { get; set; } = null!;
        public virtual DbSet<MMedicalItemSegmentation> MMedicalItemSegmentations { get; set; } = null!;
        public virtual DbSet<MMenu> MMenus { get; set; } = null!;
        public virtual DbSet<MMenuRole> MMenuRoles { get; set; } = null!;
        public virtual DbSet<MPaymentMethod> MPaymentMethods { get; set; } = null!;
        public virtual DbSet<MRole> MRoles { get; set; } = null!;
        public virtual DbSet<MSpecialization> MSpecializations { get; set; } = null!;
        public virtual DbSet<MUser> MUsers { get; set; } = null!;
        public virtual DbSet<MWalletDefaultNominal> MWalletDefaultNominals { get; set; } = null!;
        public virtual DbSet<TAppointment> TAppointments { get; set; } = null!;
        public virtual DbSet<TAppointmentCancellation> TAppointmentCancellations { get; set; } = null!;
        public virtual DbSet<TAppointmentDone> TAppointmentDones { get; set; } = null!;
        public virtual DbSet<TAppointmentRescheduleHistory> TAppointmentRescheduleHistories { get; set; } = null!;
        public virtual DbSet<TCourierDiscount> TCourierDiscounts { get; set; } = null!;
        public virtual DbSet<TCurrentDoctorSpecialization> TCurrentDoctorSpecializations { get; set; } = null!;
        public virtual DbSet<TCustomerChatHistory> TCustomerChatHistories { get; set; } = null!;
        public virtual DbSet<TCustomerCustomNominal> TCustomerCustomNominals { get; set; } = null!;
        public virtual DbSet<TCustomerRegisteredCard> TCustomerRegisteredCards { get; set; } = null!;
        public virtual DbSet<TCustomerVa> TCustomerVas { get; set; } = null!;
        public virtual DbSet<TCustomerVaHistory> TCustomerVaHistories { get; set; } = null!;
        public virtual DbSet<TCustomerWallet> TCustomerWallets { get; set; } = null!;
        public virtual DbSet<TCustomerWalletTopUp> TCustomerWalletTopUps { get; set; } = null!;
        public virtual DbSet<TCustomerWalletWithdraw> TCustomerWalletWithdraws { get; set; } = null!;
        public virtual DbSet<TDoctorOffice> TDoctorOffices { get; set; } = null!;
        public virtual DbSet<TDoctorOfficeSchedule> TDoctorOfficeSchedules { get; set; } = null!;
        public virtual DbSet<TDoctorOfficeTreatment> TDoctorOfficeTreatments { get; set; } = null!;
        public virtual DbSet<TDoctorOfficeTreatmentPrice> TDoctorOfficeTreatmentPrices { get; set; } = null!;
        public virtual DbSet<TDoctorTreatment> TDoctorTreatments { get; set; } = null!;
        public virtual DbSet<TMedicalItemPurchase> TMedicalItemPurchases { get; set; } = null!;
        public virtual DbSet<TMedicalItemPurchaseDetail> TMedicalItemPurchaseDetails { get; set; } = null!;
        public virtual DbSet<TPrescription> TPrescriptions { get; set; } = null!;
        public virtual DbSet<TResetPassword> TResetPasswords { get; set; } = null!;
        public virtual DbSet<TToken> TTokens { get; set; } = null!;
        public virtual DbSet<TTreatmentDiscount> TTreatmentDiscounts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-FGIG7GC\\BASE;Initial Catalog=medical;user id=sa;Password=xsis123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MAdmin>(entity =>
            {
                entity.ToTable("m_admin");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BiodataId).HasColumnName("biodata_id");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("code");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeletedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_on");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");
            });

            modelBuilder.Entity<MBank>(entity =>
            {
                entity.ToTable("m_bank");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeletedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_on");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.VaCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("va_code");
            });

            modelBuilder.Entity<MBiodataAddress>(entity =>
            {
                entity.ToTable("m_biodata_address");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnType("text")
                    .HasColumnName("address");

                entity.Property(e => e.BiodataId).HasColumnName("biodata_id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeletedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_on");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.Label)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("label");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("postal_code");

                entity.Property(e => e.Recipient)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("recipient");

                entity.Property(e => e.RecipientPhoneNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("recipient_phone_number");
            });

            modelBuilder.Entity<MBiodataAttachment>(entity =>
            {
                entity.ToTable("m_biodata_attachment");

                entity.Property(e => e.BiodataId).HasColumnName("biodata_id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeletedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_on");

                entity.Property(e => e.File).HasColumnName("file");

                entity.Property(e => e.FileName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("file_name");

                entity.Property(e => e.FilePath)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("file_path");

                entity.Property(e => e.FileSize).HasColumnName("file_size");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");
            });

            modelBuilder.Entity<MBiodatum>(entity =>
            {
                entity.ToTable("m_biodata");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeletedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_on");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("fullname");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("image_path");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.MobilePhone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("mobile_phone");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");
            });

            modelBuilder.Entity<MBloodGroup>(entity =>
            {
                entity.ToTable("m_blood_group");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("code");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeletedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_on");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");
            });

            modelBuilder.Entity<MCourier>(entity =>
            {
                entity.ToTable("m_courier");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeletedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_on");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<MCourierType>(entity =>
            {
                entity.ToTable("m_courier_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CourierId).HasColumnName("courier_id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeltedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("delted_on");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<MCustomer>(entity =>
            {
                entity.ToTable("m_customer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BiodataId).HasColumnName("biodata_id");

                entity.Property(e => e.BloodGroupId).HasColumnName("blood_group_id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeletedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_on");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("dob");

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("gender");

                entity.Property(e => e.Height)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("height");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.RhesusType)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("rhesus_type");

                entity.Property(e => e.Weight)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("weight");
            });

            modelBuilder.Entity<MCustomerMember>(entity =>
            {
                entity.ToTable("m_customer_member");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.CustomerRelationId).HasColumnName("customer_relation_id");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeletedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_on");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.ParentBiodataId).HasColumnName("parent_biodata_id");
            });

            modelBuilder.Entity<MCustomerRelation>(entity =>
            {
                entity.ToTable("m_customer_relation");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeletedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_on");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<MDoctor>(entity =>
            {
                entity.ToTable("m_doctor");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BiodataId).HasColumnName("biodata_id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeletedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_on");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.Str)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("str");
            });

            modelBuilder.Entity<MDoctorEducation>(entity =>
            {
                entity.ToTable("m_doctor_education");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeltedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("delted_on");

                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");

                entity.Property(e => e.EducationLevelId).HasColumnName("education_level_id");

                entity.Property(e => e.EndYear)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("end_year");

                entity.Property(e => e.InstitutionName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("institution_name");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.IsLastEducation).HasColumnName("is_last_education");

                entity.Property(e => e.Major)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("major");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.StartYear)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("start_year");
            });

            modelBuilder.Entity<MEducationLevel>(entity =>
            {
                entity.ToTable("m_education_level");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeltedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("delted_on");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<MLocation>(entity =>
            {
                entity.ToTable("m_location");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeltedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("delted_on");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.LocationLevelId).HasColumnName("location_level_id");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.ParentId).HasColumnName("parent_id");
            });

            modelBuilder.Entity<MLocationLevel>(entity =>
            {
                entity.ToTable("m_location_level");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Abbreviation)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("abbreviation");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeltedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("delted_on");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<MMedicalFacility>(entity =>
            {
                entity.ToTable("m_medical_facility");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeltedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("delted_on");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Fax)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("fax");

                entity.Property(e => e.FullAddress)
                    .HasColumnType("text")
                    .HasColumnName("full_address");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.MedicalFacilityCategoryId).HasColumnName("medical_facility_category_id");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.PhoneCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("phone_code");
            });

            modelBuilder.Entity<MMedicalFacilityCategory>(entity =>
            {
                entity.ToTable("m_medical_facility_category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeltedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("delted_on");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<MMedicalFacilitySchedule>(entity =>
            {
                entity.ToTable("m_medical_facility_schedule");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.Day)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("day");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeltedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("delted_on");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.MedicalFacilityId).HasColumnName("medical_facility_id");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.TimeScheduleEnd)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("time_schedule_end");

                entity.Property(e => e.TimeScheduleStart)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("time_schedule_start");
            });

            modelBuilder.Entity<MMedicalItem>(entity =>
            {
                entity.ToTable("m_medical_item");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Caution)
                    .HasColumnType("text")
                    .HasColumnName("caution");

                entity.Property(e => e.Composition)
                    .HasColumnType("text")
                    .HasColumnName("composition");

                entity.Property(e => e.Contraindication)
                    .HasColumnType("text")
                    .HasColumnName("contraindication");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeltedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("delted_on");

                entity.Property(e => e.Directions)
                    .HasColumnType("text")
                    .HasColumnName("directions");

                entity.Property(e => e.Dosage)
                    .HasColumnType("text")
                    .HasColumnName("dosage");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("image_path");

                entity.Property(e => e.Indication)
                    .HasColumnType("text")
                    .HasColumnName("indication");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.Manufacturer)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("manufacturer");

                entity.Property(e => e.MedicalItemCategoryId).HasColumnName("medical_item_category_id");

                entity.Property(e => e.MedicalItemSegmentationId).HasColumnName("medical_item_segmentation_id");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Packaging)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("packaging");

                entity.Property(e => e.PriceMax).HasColumnName("price_max");

                entity.Property(e => e.PriceMin).HasColumnName("price_min");
            });

            modelBuilder.Entity<MMedicalItemCategory>(entity =>
            {
                entity.ToTable("m_medical_item_category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeltedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("delted_on");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<MMedicalItemSegmentation>(entity =>
            {
                entity.ToTable("m_medical_item_segmentation");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeltedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("delted_on");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<MMenu>(entity =>
            {
                entity.ToTable("m_menu");

                entity.Property(e => e.BigIcon)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("big_icon");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeletedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_on");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.Property(e => e.SmallIcon)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("small_icon");

                entity.Property(e => e.Url)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("url");
            });

            modelBuilder.Entity<MMenuRole>(entity =>
            {
                entity.ToTable("m_menu_role");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeletedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_on");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.MenuId).HasColumnName("menu_Id");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.RoleId).HasColumnName("role_Id");
            });

            modelBuilder.Entity<MPaymentMethod>(entity =>
            {
                entity.ToTable("m_payment_method");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeletedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_on");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<MRole>(entity =>
            {
                entity.ToTable("m_role");

                entity.Property(e => e.Code)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("code");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeletedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_on");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<MSpecialization>(entity =>
            {
                entity.ToTable("m_specialization");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeletedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_on");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<MUser>(entity =>
            {
                entity.ToTable("m_user");

                entity.Property(e => e.BiodataId).HasColumnName("biodata_id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeletedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_on");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.IsLocked).HasColumnName("is_locked");

                entity.Property(e => e.LastLogin)
                    .HasColumnType("datetime")
                    .HasColumnName("last_login");

                entity.Property(e => e.LoginAttempt).HasColumnName("login_attempt");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.RoleId).HasColumnName("role_id");
            });

            modelBuilder.Entity<MWalletDefaultNominal>(entity =>
            {
                entity.ToTable("m_wallet_default_nominal");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeletedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_on");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.Nominal).HasColumnName("nominal");
            });

            modelBuilder.Entity<TAppointment>(entity =>
            {
                entity.ToTable("t_appointment");

                entity.Property(e => e.AppointmentDate)
                    .HasColumnType("date")
                    .HasColumnName("appointment_date");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeletedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_on");

                entity.Property(e => e.DoctorOfficeId).HasColumnName("doctor_office_id");

                entity.Property(e => e.DoctorOfficeScheduleId).HasColumnName("doctor_office_schedule_id");

                entity.Property(e => e.DoctorOfficeTreatmentId).HasColumnName("doctor_office_treatment_id");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");
            });

            modelBuilder.Entity<TAppointmentCancellation>(entity =>
            {
                entity.ToTable("t_appointment_cancellation");

                entity.Property(e => e.AppointmentId).HasColumnName("appointment_id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeletedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_on");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");
            });

            modelBuilder.Entity<TAppointmentDone>(entity =>
            {
                entity.ToTable("t_appointment_done");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AppointmentId).HasColumnName("appointment_id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeletedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_on");

                entity.Property(e => e.Diagnosis)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("diagnosis");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");
            });

            modelBuilder.Entity<TAppointmentRescheduleHistory>(entity =>
            {
                entity.ToTable("t_appointment_reschedule_history");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AppointmentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("appointment_date");

                entity.Property(e => e.AppointmentId).HasColumnName("appointment_id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeletedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_on");

                entity.Property(e => e.DoctorOfficeScheduleId).HasColumnName("doctor_office_schedule_id");

                entity.Property(e => e.DoctorOfficeTreatmentId).HasColumnName("doctor_office_treatment_id ");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");
            });

            modelBuilder.Entity<TCourierDiscount>(entity =>
            {
                entity.ToTable("t_courier_discount");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CourierTypeId).HasColumnName("courier_type-id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeltedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("delted_on");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.Value)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("value");
            });

            modelBuilder.Entity<TCurrentDoctorSpecialization>(entity =>
            {
                entity.ToTable("t_current_doctor_specialization");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeletedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_on");

                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.SpecializationId).HasColumnName("specialization_id");
            });

            modelBuilder.Entity<TCustomerChatHistory>(entity =>
            {
                entity.ToTable("t_customer_chat_history");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ChatContent)
                    .HasColumnType("text")
                    .HasColumnName("chat_content");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.CustomerChatId).HasColumnName("customer_chat_id");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeletedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_on");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");
            });

            modelBuilder.Entity<TCustomerCustomNominal>(entity =>
            {
                entity.ToTable("t_customer_custom_nominal");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeletedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_on");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.Nominal).HasColumnName("nominal");
            });

            modelBuilder.Entity<TCustomerRegisteredCard>(entity =>
            {
                entity.ToTable("t_customer_registered_card");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CardNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("card_number");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.Cvv)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("cvv");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeletedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_on");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.ValidityPeriod)
                    .HasColumnType("date")
                    .HasColumnName("validity_period");
            });

            modelBuilder.Entity<TCustomerVa>(entity =>
            {
                entity.ToTable("t_customer_va");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CardNumber)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("card_number");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeletedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_on");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");
            });

            modelBuilder.Entity<TCustomerVaHistory>(entity =>
            {
                entity.ToTable("t_customer_va_history");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("amount");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.CustomerVaId).HasColumnName("customer_va_id");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeletedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_on");

                entity.Property(e => e.ExpiredOn)
                    .HasColumnType("datetime")
                    .HasColumnName("expired_on");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");
            });

            modelBuilder.Entity<TCustomerWallet>(entity =>
            {
                entity.ToTable("t_customer_wallet");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Balance)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("balance");

                entity.Property(e => e.Barcode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("barcode");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeletedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_on");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.Pin)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("pin");

                entity.Property(e => e.Points)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("points");
            });

            modelBuilder.Entity<TCustomerWalletTopUp>(entity =>
            {
                entity.ToTable("t_customer_wallet_top_up");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("amount");

                entity.Property(e => e.CreateBy).HasColumnName("create_by");

                entity.Property(e => e.CreateOn)
                    .HasColumnType("datetime")
                    .HasColumnName("create_on");

                entity.Property(e => e.CustomerWalletId).HasColumnName("customer_wallet_id");

                entity.Property(e => e.DeleteBy).HasColumnName("delete_by");

                entity.Property(e => e.DeleteOn)
                    .HasColumnType("datetime")
                    .HasColumnName("delete_on");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");
            });

            modelBuilder.Entity<TCustomerWalletWithdraw>(entity =>
            {
                entity.ToTable("t_customer_wallet_withdraw");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccountNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("account_number");

                entity.Property(e => e.AcoountName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("acoount_name");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.BankName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("bank_name");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeltedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("delted_on");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.Otp).HasColumnName("otp");

                entity.Property(e => e.WalletDefaultNominalId).HasColumnName("wallet_default_nominal_id");
            });

            modelBuilder.Entity<TDoctorOffice>(entity =>
            {
                entity.ToTable("t_doctor_office");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateBy).HasColumnName("create_by");

                entity.Property(e => e.CreateOn)
                    .HasColumnType("datetime")
                    .HasColumnName("create_on");

                entity.Property(e => e.DeleteBy).HasColumnName("delete_by");

                entity.Property(e => e.DeleteOn)
                    .HasColumnType("datetime")
                    .HasColumnName("delete_on");

                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.MedicalFacilityId).HasColumnName("medical_facility_id");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.Specialization)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("specialization");
            });

            modelBuilder.Entity<TDoctorOfficeSchedule>(entity =>
            {
                entity.ToTable("t_doctor_office_schedule");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateBy).HasColumnName("create_by");

                entity.Property(e => e.CreateOn)
                    .HasColumnType("datetime")
                    .HasColumnName("create_on");

                entity.Property(e => e.DeleteBy).HasColumnName("delete_by");

                entity.Property(e => e.DeleteOn)
                    .HasColumnType("datetime")
                    .HasColumnName("delete_on");

                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.MedicalFacilityScheduleId).HasColumnName("medical_facility_schedule_id");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.Slot).HasColumnName("slot");
            });

            modelBuilder.Entity<TDoctorOfficeTreatment>(entity =>
            {
                entity.ToTable("t_doctor_office_treatment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateBy).HasColumnName("create_by");

                entity.Property(e => e.CreateOn)
                    .HasColumnType("datetime")
                    .HasColumnName("create_on");

                entity.Property(e => e.DeleteBy).HasColumnName("delete_by");

                entity.Property(e => e.DeleteOn)
                    .HasColumnType("datetime")
                    .HasColumnName("delete_on");

                entity.Property(e => e.DoctorOfficeId).HasColumnName("doctor_office_id");

                entity.Property(e => e.DoctorTreatmentId).HasColumnName("doctor_treatment_id");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");
            });

            modelBuilder.Entity<TDoctorOfficeTreatmentPrice>(entity =>
            {
                entity.ToTable("t_doctor_office_treatment_price");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateBy).HasColumnName("create_by");

                entity.Property(e => e.CreateOn)
                    .HasColumnType("datetime")
                    .HasColumnName("create_on");

                entity.Property(e => e.DeleteBy).HasColumnName("delete_by");

                entity.Property(e => e.DeleteOn)
                    .HasColumnType("datetime")
                    .HasColumnName("delete_on");

                entity.Property(e => e.DoctorOfficeTreatmentId).HasColumnName("doctor_office_treatment_id");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("price");

                entity.Property(e => e.PriceStartFrom)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("price_start_from");

                entity.Property(e => e.PriceUntilFrom)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("price_until_from");
            });

            modelBuilder.Entity<TDoctorTreatment>(entity =>
            {
                entity.ToTable("t_doctor_treatment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateBy).HasColumnName("create_by");

                entity.Property(e => e.CreateOn)
                    .HasColumnType("datetime")
                    .HasColumnName("create_on");

                entity.Property(e => e.DeleteBy).HasColumnName("delete_by");

                entity.Property(e => e.DeleteOn)
                    .HasColumnType("datetime")
                    .HasColumnName("delete_on");

                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<TMedicalItemPurchase>(entity =>
            {
                entity.ToTable("t_medical_item_purchase");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateBy).HasColumnName("create_by");

                entity.Property(e => e.CreateOn)
                    .HasColumnType("datetime")
                    .HasColumnName("create_on");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.DeleteBy).HasColumnName("delete_by");

                entity.Property(e => e.DeleteOn)
                    .HasColumnType("datetime")
                    .HasColumnName("delete_on");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.PaymentMethodId).HasColumnName("payment_method_id");
            });

            modelBuilder.Entity<TMedicalItemPurchaseDetail>(entity =>
            {
                entity.ToTable("t_medical_item_purchase_detail");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CourirId).HasColumnName("courir_id");

                entity.Property(e => e.CreateBy).HasColumnName("create_by");

                entity.Property(e => e.CreateOn)
                    .HasColumnType("datetime")
                    .HasColumnName("create_on");

                entity.Property(e => e.DeleteBy).HasColumnName("delete_by");

                entity.Property(e => e.DeleteOn)
                    .HasColumnType("datetime")
                    .HasColumnName("delete_on");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.MedicalFacilityId).HasColumnName("medical_facility_id");

                entity.Property(e => e.MedicalItemItem).HasColumnName("medical_item_item");

                entity.Property(e => e.MedicalItemPurchaseId).HasColumnName("medical_item_purchase_id");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.Property(e => e.SubTotal)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("sub_total");
            });

            modelBuilder.Entity<TPrescription>(entity =>
            {
                entity.ToTable("t_prescription");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AppointmentId).HasColumnName("appointment_id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeltedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("delted_on");

                entity.Property(e => e.Direction)
                    .HasColumnType("text")
                    .HasColumnName("direction");

                entity.Property(e => e.Dosage)
                    .HasColumnType("text")
                    .HasColumnName("dosage");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.MedicalItemId).HasColumnName("medical_item_id");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.Notes)
                    .HasColumnType("text")
                    .HasColumnName("notes");

                entity.Property(e => e.Time)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("time");
            });

            modelBuilder.Entity<TResetPassword>(entity =>
            {
                entity.ToTable("t_reset_password");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateBy).HasColumnName("create_by");

                entity.Property(e => e.CreateOn)
                    .HasColumnType("datetime")
                    .HasColumnName("create_on");

                entity.Property(e => e.DeleteBy).HasColumnName("delete_by");

                entity.Property(e => e.DeleteOn)
                    .HasColumnType("datetime")
                    .HasColumnName("delete_on");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.NewPassword)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("new_password");

                entity.Property(e => e.OldPassword)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("old_password");

                entity.Property(e => e.ResetFor)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("reset_for");
            });

            modelBuilder.Entity<TToken>(entity =>
            {
                entity.ToTable("t_token");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateBy).HasColumnName("create_by");

                entity.Property(e => e.CreateOn)
                    .HasColumnType("datetime")
                    .HasColumnName("create_on");

                entity.Property(e => e.DeleteBy).HasColumnName("delete_by");

                entity.Property(e => e.DeleteOn)
                    .HasColumnType("datetime")
                    .HasColumnName("delete_on");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.ExpiredOn)
                    .HasColumnType("datetime")
                    .HasColumnName("expired_on");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.IsExpired).HasColumnName("is_expired");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.Token)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("token");

                entity.Property(e => e.UsedFor)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("used_for");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<TTreatmentDiscount>(entity =>
            {
                entity.ToTable("t_treatment_discount");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeltedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("delted_on");

                entity.Property(e => e.DoctorOfficeTreatmentPriceId).HasColumnName("doctor_office_treatment_price_id");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.Value)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("value");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
