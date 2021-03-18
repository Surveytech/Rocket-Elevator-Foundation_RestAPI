using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BuildingApi.Models
{
    public partial class MaximeAuger_mysqlContext : DbContext
    {
        public MaximeAuger_mysqlContext()
        {
        }

        public MaximeAuger_mysqlContext(DbContextOptions<MaximeAuger_mysqlContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Addresses> Addresses { get; set; }
        public virtual DbSet<ArInternalMetadata> ArInternalMetadata { get; set; }
        public virtual DbSet<Batteries> Batteries { get; set; }
        public virtual DbSet<BuildingDetails> BuildingDetails { get; set; }
        public virtual DbSet<Buildings> Buildings { get; set; }
        public virtual DbSet<Columns> Columns { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Elevators> Elevators { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Leads> Leads { get; set; }
        public virtual DbSet<Quotes> Quotes { get; set; }
        public virtual DbSet<SchemaMigrations> SchemaMigrations { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("Server=localhost;port=3306;Database=MaximeAuger_mysql;uid=dana;password=12345");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Addresses>(entity =>
            {
                entity.ToTable("addresses");

                entity.HasIndex(e => e.BuildingId)
                    .HasName("index_addresses_on_building_id");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("index_addresses_on_customer_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.BuildingId)
                    .HasColumnName("building_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(255);

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasMaxLength(255);

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Entity)
                    .HasColumnName("entity")
                    .HasMaxLength(255);

                entity.Property(e => e.Latitude)
                    .HasColumnName("latitude")
                    .HasMaxLength(255);

                entity.Property(e => e.Longitude)
                    .HasColumnName("longitude")
                    .HasMaxLength(255);

                entity.Property(e => e.Notes).HasColumnName("notes");

                entity.Property(e => e.NumberStreet)
                    .HasColumnName("number_street")
                    .HasMaxLength(255);

                entity.Property(e => e.PostalCode)
                    .HasColumnName("postal_code")
                    .HasMaxLength(255);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(255);

                entity.Property(e => e.SuiteApt)
                    .HasColumnName("suite_apt")
                    .HasMaxLength(255);

                entity.Property(e => e.TypeAddress)
                    .HasColumnName("type_address")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.BuildingId)
                    .HasConstraintName("fk_rails_a9ab2347cc");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("fk_rails_d5f9efddd3");
            });

            modelBuilder.Entity<ArInternalMetadata>(entity =>
            {
                entity.HasKey(e => e.Key)
                    .HasName("PRIMARY");

                entity.ToTable("ar_internal_metadata");

                entity.Property(e => e.Key)
                    .HasColumnName("key")
                    .HasMaxLength(255);

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Batteries>(entity =>
            {
                entity.ToTable("batteries");

                entity.HasIndex(e => e.BuildingId)
                    .HasName("index_batteries_on_building_id");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("index_batteries_on_employee_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.BuildingId)
                    .HasColumnName("building_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CertificateOperations)
                    .HasColumnName("certificate_operations")
                    .HasMaxLength(255);

                entity.Property(e => e.DateCommissioning)
                    .HasColumnName("date_commissioning")
                    .HasColumnType("date");

                entity.Property(e => e.DateLastInspection)
                    .HasColumnName("date_last_inspection")
                    .HasColumnType("date");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employee_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Information)
                    .HasColumnName("information")
                    .HasMaxLength(255);

                entity.Property(e => e.Notes).HasColumnName("notes");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(255);

                entity.Property(e => e.TypeBuilding)
                    .HasColumnName("type_building")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.Batteries)
                    .HasForeignKey(d => d.BuildingId)
                    .HasConstraintName("fk_rails_fc40470545");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Batteries)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("fk_rails_ceeeaf55f7");
            });

            modelBuilder.Entity<BuildingDetails>(entity =>
            {
                entity.ToTable("building_details");

                entity.HasIndex(e => e.BuildingId)
                    .HasName("index_building_details_on_building_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.BuildingId)
                    .HasColumnName("building_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.InfoKey)
                    .HasColumnName("info_key")
                    .HasMaxLength(255);

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.BuildingDetails)
                    .HasForeignKey(d => d.BuildingId)
                    .HasConstraintName("fk_rails_51749f8eac");
            });

            modelBuilder.Entity<Buildings>(entity =>
            {
                entity.ToTable("buildings");

                entity.HasIndex(e => e.AddressId)
                    .HasName("index_buildings_on_address_id");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("index_buildings_on_customer_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.AddressId)
                    .HasColumnName("address_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.AdmContactEmail)
                    .HasColumnName("adm_contact_email")
                    .HasMaxLength(255);

                entity.Property(e => e.AdmContactFullName)
                    .HasColumnName("adm_contact_full_name")
                    .HasMaxLength(255);

                entity.Property(e => e.AdmContactPhone)
                    .HasColumnName("adm_contact_phone")
                    .HasMaxLength(255);

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.TechContactEmail)
                    .HasColumnName("tech_contact_email")
                    .HasMaxLength(255);

                entity.Property(e => e.TechContactFullName)
                    .HasColumnName("tech_contact_full_name")
                    .HasMaxLength(255);

                entity.Property(e => e.TechContactPhone)
                    .HasColumnName("tech_contact_phone")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Buildings)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("fk_rails_6dc7a885ab");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Buildings)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("fk_rails_c29cbe7fb8");
            });

            modelBuilder.Entity<Columns>(entity =>
            {
                entity.ToTable("columns");

                entity.HasIndex(e => e.BatteryId)
                    .HasName("index_columns_on_battery_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.BatteryId)
                    .HasColumnName("battery_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Information)
                    .HasColumnName("information")
                    .HasMaxLength(255);

                entity.Property(e => e.Notes).HasColumnName("notes");

                entity.Property(e => e.NumberFloorsServed)
                    .HasColumnName("number_floors_served")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(255);

                entity.Property(e => e.TypeBuilding)
                    .HasColumnName("type_building")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Battery)
                    .WithMany(p => p.Columns)
                    .HasForeignKey(d => d.BatteryId)
                    .HasConstraintName("fk_rails_021eb14ac4");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.ToTable("customers");

                entity.HasIndex(e => e.AddressId)
                    .HasName("index_customers_on_address_id");

                entity.HasIndex(e => e.UserId)
                    .HasName("index_customers_on_user_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.AddressId)
                    .HasColumnName("address_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CompanyName)
                    .HasColumnName("company_name")
                    .HasMaxLength(255);

                entity.Property(e => e.CpyContactEmail)
                    .HasColumnName("cpy_contact_email")
                    .HasMaxLength(255);

                entity.Property(e => e.CpyContactFullName)
                    .HasColumnName("cpy_contact_full_name")
                    .HasMaxLength(255);

                entity.Property(e => e.CpyContactPhone)
                    .HasColumnName("cpy_contact_phone")
                    .HasMaxLength(255);

                entity.Property(e => e.CpyDescription)
                    .HasColumnName("cpy_description")
                    .HasMaxLength(255);

                entity.Property(e => e.DateCreate)
                    .HasColumnName("date_create")
                    .HasColumnType("date");

                entity.Property(e => e.TechAuthorityServiceFullName)
                    .HasColumnName("tech_authority_service_full_name")
                    .HasMaxLength(255);

                entity.Property(e => e.TechAuthorityServicePhone)
                    .HasColumnName("tech_authority_service_phone")
                    .HasMaxLength(255);

                entity.Property(e => e.TechManagerServiceEmail)
                    .HasColumnName("tech_manager_service_email")
                    .HasMaxLength(255);

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("bigint(20)");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("fk_rails_3f9404ba26");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_rails_9917eeaf5d");
            });

            modelBuilder.Entity<Elevators>(entity =>
            {
                entity.ToTable("elevators");

                entity.HasIndex(e => e.ColumnId)
                    .HasName("index_elevators_on_column_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CertificateInspection)
                    .HasColumnName("certificate_inspection")
                    .HasMaxLength(255);

                entity.Property(e => e.ColumnId)
                    .HasColumnName("column_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.DateCommissioning)
                    .HasColumnName("date_commissioning")
                    .HasColumnType("date");

                entity.Property(e => e.DateLastInspection)
                    .HasColumnName("date_last_inspection")
                    .HasColumnType("date");

                entity.Property(e => e.Information)
                    .HasColumnName("information")
                    .HasMaxLength(255);

                entity.Property(e => e.Model)
                    .HasColumnName("model")
                    .HasMaxLength(255);

                entity.Property(e => e.Notes).HasColumnName("notes");

                entity.Property(e => e.SerialNumber)
                    .HasColumnName("serial_number")
                    .HasMaxLength(255);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(255);

                entity.Property(e => e.TypeBuilding)
                    .HasColumnName("type_building")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Column)
                    .WithMany(p => p.Elevators)
                    .HasForeignKey(d => d.ColumnId)
                    .HasConstraintName("fk_rails_69442d7bc2");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.ToTable("employees");

                entity.HasIndex(e => e.UserId)
                    .HasName("index_employees_on_user_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(255);

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasMaxLength(255);

                entity.Property(e => e.Function)
                    .HasColumnName("function")
                    .HasMaxLength(255);

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(255);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(255);

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("bigint(20)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_rails_dcfd3d4fc3");
            });

            modelBuilder.Entity<Leads>(entity =>
            {
                entity.ToTable("leads");

                entity.HasIndex(e => e.customers_id)
                    .HasName("index_leads_on_customers_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CompanyName)
                    .HasColumnName("company_name")
                    .HasMaxLength(255);

                entity.Property(e => e.customers_id)
                    .HasColumnName("customers_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Department)
                    .HasColumnName("department")
                    .HasMaxLength(255);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(255);

                entity.Property(e => e.FileAttachment)
                    .HasColumnName("file_attachment")
                    .HasColumnType("blob");

                entity.Property(e => e.Filename)
                    .HasColumnName("filename")
                    .HasMaxLength(255);

                entity.Property(e => e.FullName)
                    .HasColumnName("full_name")
                    .HasMaxLength(255);

                entity.Property(e => e.Message).HasColumnName("message");

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(255);

                entity.Property(e => e.ProjectDescription)
                    .HasColumnName("project_description")
                    .HasMaxLength(255);

                entity.Property(e => e.ProjectName)
                    .HasColumnName("project_name")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Customers)
                    .WithMany(p => p.Leads)
                    .HasForeignKey(d => d.customers_id)
                    .HasConstraintName("fk_rails_f6c5b6922a");
            });

            modelBuilder.Entity<Quotes>(entity =>
            {
                entity.ToTable("quotes");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.BuildingType)
                    .HasColumnName("building_type")
                    .HasMaxLength(255);

                entity.Property(e => e.BusinessHours)
                    .HasColumnName("business_hours")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ElevatorAmount)
                    .HasColumnName("elevator_amount")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FinalPrice)
                    .HasColumnName("final_price")
                    .HasMaxLength(255);

                entity.Property(e => e.InstallFees)
                    .HasColumnName("install_fees")
                    .HasMaxLength(255);

                entity.Property(e => e.MaximumOccupancy)
                    .HasColumnName("maximum_occupancy")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NumberOfApartments)
                    .HasColumnName("number_of_apartments")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NumberOfBasements)
                    .HasColumnName("number_of_basements")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NumberOfCompanies)
                    .HasColumnName("number_of_companies")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NumberOfCorporations)
                    .HasColumnName("number_of_corporations")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NumberOfElevators)
                    .HasColumnName("number_of_elevators")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NumberOfFloors)
                    .HasColumnName("number_of_floors")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NumberOfParking)
                    .HasColumnName("number_of_parking")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProductLine)
                    .HasColumnName("product_line")
                    .HasMaxLength(255);

                entity.Property(e => e.QuotesCompanyName)
                    .HasColumnName("quotes_company_name")
                    .HasMaxLength(255);

                entity.Property(e => e.QuotesEmail)
                    .HasColumnName("quotes_email")
                    .HasMaxLength(255);

                entity.Property(e => e.QuotesName)
                    .HasColumnName("quotes_name")
                    .HasMaxLength(255);

                entity.Property(e => e.TotalPrice)
                    .HasColumnName("total_price")
                    .HasMaxLength(255);

                entity.Property(e => e.UnitPrice)
                    .HasColumnName("unit_price")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<SchemaMigrations>(entity =>
            {
                entity.HasKey(e => e.Version)
                    .HasName("PRIMARY");

                entity.ToTable("schema_migrations");

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Email)
                    .HasName("index_users_on_email")
                    .IsUnique();

                entity.HasIndex(e => e.ResetPasswordToken)
                    .HasName("index_users_on_reset_password_token")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Admin)
                    .HasColumnName("admin")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.EncryptedPassword)
                    .IsRequired()
                    .HasColumnName("encrypted_password")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ResetPasswordToken)
                    .HasColumnName("reset_password_token")
                    .HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
