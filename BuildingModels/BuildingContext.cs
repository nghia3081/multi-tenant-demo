using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BuildingModels;

public partial class BuildingContext : DbContext
{
    public BuildingContext()
    {
    }

    public BuildingContext(DbContextOptions<BuildingContext> options)
        : base(options)
    {
    }
    public BuildingContext(DbContextOptions<BuildingContext> options, string connectionString)
    : base(options)
    {
        Database.SetConnectionString(connectionString);
    }
    public virtual DbSet<Apartment> Apartments { get; set; }

    public virtual DbSet<Assigment> Assigments { get; set; }

    public virtual DbSet<Building> Buildings { get; set; }

    public virtual DbSet<Contributor> Contributors { get; set; }

    public virtual DbSet<Finance> Finances { get; set; }

    public virtual DbSet<FinanceBuilding> FinanceBuildings { get; set; }

    public virtual DbSet<HandleRequest> HandleRequests { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Living> Livings { get; set; }

    public virtual DbSet<Notify> Notifies { get; set; }

    public virtual DbSet<NotifyCategory> NotifyCategories { get; set; }

    public virtual DbSet<OwnerShip> OwnerShips { get; set; }

    public virtual DbSet<Postion> Postions { get; set; }

    public virtual DbSet<RequestComplain> RequestComplains { get; set; }

    public virtual DbSet<Resident> Residents { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Salary> Salaries { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<ServiceContract> ServiceContracts { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<ThirdParty> ThirdParties { get; set; }

    public virtual DbSet<ThirdPartyContact> ThirdPartyContacts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Apartment>(entity =>
        {
            entity.ToTable("Apartment");

            entity.Property(e => e.ApartmentId).HasColumnName("Apartment_Id");
            entity.Property(e => e.BuildingId).HasColumnName("Building_Id");
            entity.Property(e => e.DepartmentType)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Building).WithMany(p => p.Apartments)
                .HasForeignKey(d => d.BuildingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Apartment_Building");
        });

        modelBuilder.Entity<Assigment>(entity =>
        {
            entity.ToTable("Assigment");

            entity.Property(e => e.AssigmentId).HasColumnName("Assigment_Id");
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.StaffId).HasColumnName("Staff_Id");
            entity.Property(e => e.StartTime).HasColumnType("datetime");
            entity.Property(e => e.TaskId).HasColumnName("Task_Id");

            entity.HasOne(d => d.Task).WithMany(p => p.Assigments)
                .HasForeignKey(d => d.TaskId)
                .HasConstraintName("FK_Assigment_Task");
        });

        modelBuilder.Entity<Building>(entity =>
        {
            entity.ToTable("Building");

            entity.Property(e => e.BuildingId).HasColumnName("Building_Id");
            entity.Property(e => e.BuildingName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Building_Name");
            entity.Property(e => e.CodePosition)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Code_Position");
            entity.Property(e => e.NumberApartment).HasColumnName("Number_Apartment");
            entity.Property(e => e.NumberFloor).HasColumnName("Number_Floor");

            entity.HasOne(d => d.CodePositionNavigation).WithMany(p => p.Buildings)
                .HasForeignKey(d => d.CodePosition)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Building_Postion");
        });

        modelBuilder.Entity<Contributor>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Contributor");

            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.StaffId).HasColumnName("Staff_Id");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.ThirdPartyId).HasColumnName("ThirdParty_Id");
        });

        modelBuilder.Entity<Finance>(entity =>
        {
            entity.ToTable("Finance");

            entity.Property(e => e.FinanceId).HasColumnName("Finance_Id");
            entity.Property(e => e.FinanceType).HasMaxLength(50);
            entity.Property(e => e.ProviderName)
                .HasMaxLength(50)
                .HasColumnName("providerName");
            entity.Property(e => e.ServiceFee).HasColumnName("serviceFee");
        });

        modelBuilder.Entity<FinanceBuilding>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Finance_Building");

            entity.Property(e => e.BuildingId).HasColumnName("Building_Id");
            entity.Property(e => e.FinanceId).HasColumnName("Finance_Id");

            entity.HasOne(d => d.Building).WithMany()
                .HasForeignKey(d => d.BuildingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Finance_Building_Building");

            entity.HasOne(d => d.Finance).WithMany()
                .HasForeignKey(d => d.FinanceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Finance_Building_Finance");
        });

        modelBuilder.Entity<HandleRequest>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("HandleRequest");

            entity.Property(e => e.AssigmentId).HasColumnName("Assigment_Id");
            entity.Property(e => e.RequestionId).HasColumnName("Requestion_Id");

            entity.HasOne(d => d.Assigment).WithMany()
                .HasForeignKey(d => d.AssigmentId)
                .HasConstraintName("FK_HandleRequest_Assigment");

            entity.HasOne(d => d.Requestion).WithMany()
                .HasForeignKey(d => d.RequestionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HandleRequest_RequestComplain");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.ToTable("Invoice");

            entity.Property(e => e.InvoiceId).HasColumnName("Invoice_Id");
            entity.Property(e => e.ApartmentId).HasColumnName("Apartment_ID");
            entity.Property(e => e.DueDate)
                .HasColumnType("datetime")
                .HasColumnName("Due_Date");
            entity.Property(e => e.IssueDate)
                .HasColumnType("datetime")
                .HasColumnName("Issue_Date");
            entity.Property(e => e.StatusId).HasColumnName("Status_Id");
            entity.Property(e => e.TransactionDate)
                .HasColumnType("datetime")
                .HasColumnName("Transaction_Date");

            entity.HasOne(d => d.Apartment).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.ApartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Invoice_Apartment");

            entity.HasOne(d => d.Status).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Invoice_Status");
        });

        modelBuilder.Entity<Living>(entity =>
        {
            entity.ToTable("Living");

            entity.Property(e => e.LivingId).HasColumnName("Living_Id");
            entity.Property(e => e.ApartmentId).HasColumnName("Apartment_Id");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("End_Date");
            entity.Property(e => e.ResidentId).HasColumnName("Resident_Id");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("Start_Date");

            entity.HasOne(d => d.Apartment).WithMany(p => p.Livings)
                .HasForeignKey(d => d.ApartmentId)
                .HasConstraintName("FK_Living_Apartment");

            entity.HasOne(d => d.Resident).WithMany(p => p.Livings)
                .HasForeignKey(d => d.ResidentId)
                .HasConstraintName("FK_Living_Resident");
        });

        modelBuilder.Entity<Notify>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Notify");

            entity.Property(e => e.AssigmentId).HasColumnName("Assigment_Id");
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.NewCategoryId)
                .ValueGeneratedOnAdd()
                .HasColumnName("NewCategory_Id");
            entity.Property(e => e.StartTime).HasColumnType("datetime");

            entity.HasOne(d => d.Assigment).WithMany()
                .HasForeignKey(d => d.AssigmentId)
                .HasConstraintName("FK_Notify_Assigment");

            entity.HasOne(d => d.NewCategory).WithMany()
                .HasForeignKey(d => d.NewCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Notify_NotifyCategory");
        });

        modelBuilder.Entity<NotifyCategory>(entity =>
        {
            entity.HasKey(e => e.NewCategoryId);

            entity.ToTable("NotifyCategory");

            entity.Property(e => e.NewCategoryId).HasColumnName("NewCategory_Id");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<OwnerShip>(entity =>
        {
            entity.HasKey(e => e.OwnerShipId).HasName("PK_OwnerShip_1");

            entity.ToTable("OwnerShip");

            entity.Property(e => e.OwnerShipId).HasColumnName("OwnerShip_Id");
            entity.Property(e => e.ApartmentId).HasColumnName("Apartment_Id");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("End_Date");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("Start_Date");

            entity.HasOne(d => d.Apartment).WithMany(p => p.OwnerShips)
                .HasForeignKey(d => d.ApartmentId)
                .HasConstraintName("FK_OwnerShip_Apartment");
        });

        modelBuilder.Entity<Postion>(entity =>
        {
            entity.HasKey(e => e.CodePosition);

            entity.ToTable("Postion");

            entity.Property(e => e.CodePosition)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Code_Position");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
        });

        modelBuilder.Entity<RequestComplain>(entity =>
        {
            entity.HasKey(e => e.RequestionId);

            entity.ToTable("RequestComplain");

            entity.Property(e => e.RequestionId).HasColumnName("Requestion_Id");
            entity.Property(e => e.DateRequest)
                .HasColumnType("datetime")
                .HasColumnName("Date_Request");
            entity.Property(e => e.ResidentId).HasColumnName("Resident_Id");

            entity.HasOne(d => d.Resident).WithMany(p => p.RequestComplains)
                .HasForeignKey(d => d.ResidentId)
                .HasConstraintName("FK_RequestComplain_Resident");
        });

        modelBuilder.Entity<Resident>(entity =>
        {
            entity.ToTable("Resident");

            entity.Property(e => e.ResidentId).HasColumnName("Resident_Id");
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.Fullname)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.OwnerShipId).HasColumnName("OwnerShip_Id");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber).HasColumnName("Phone_Number");
            entity.Property(e => e.RegistratorDate).HasColumnType("datetime");
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.OwnerShip).WithMany(p => p.Residents)
                .HasForeignKey(d => d.OwnerShipId)
                .HasConstraintName("FK_Resident_OwnerShip");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.RoleId).HasColumnName("Role_Id");
            entity.Property(e => e.RollName).HasMaxLength(50);
        });

        modelBuilder.Entity<Salary>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Salary");

            entity.Property(e => e.RollId).HasColumnName("Roll_Id");
            entity.Property(e => e.StaffId).HasColumnName("Staff_Id");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.ToTable("Service");

            entity.Property(e => e.ServiceId)
                .ValueGeneratedNever()
                .HasColumnName("Service_Id");
            entity.Property(e => e.ServiceName)
                .HasMaxLength(50)
                .HasColumnName("Service_Name");
            entity.Property(e => e.ServiceType)
                .HasMaxLength(50)
                .HasColumnName("Service_Type");
        });

        modelBuilder.Entity<ServiceContract>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ServiceContract");

            entity.Property(e => e.ApartmentId).HasColumnName("Apartment_Id");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("End_Date");
            entity.Property(e => e.ServiceId).HasColumnName("Service_Id");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("Start_Date");

            entity.HasOne(d => d.Apartment).WithMany()
                .HasForeignKey(d => d.ApartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServiceContract_Apartment");

            entity.HasOne(d => d.Service).WithMany()
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServiceContract_Service");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.Property(e => e.StaffId).HasColumnName("Staff_Id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.HireDate).HasColumnType("datetime");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber).HasColumnName("Phone_Number");
            entity.Property(e => e.RoleId).HasColumnName("Role_Id");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.ToTable("Status");

            entity.Property(e => e.StatusId).HasColumnName("Status_Id");
            entity.Property(e => e.StatusName)
                .HasMaxLength(20)
                .HasColumnName("Status_Name");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.ToTable("Task");

            entity.Property(e => e.TaskId).HasColumnName("Task_Id");
            entity.Property(e => e.TaskName)
                .HasMaxLength(50)
                .HasColumnName("Task_Name");
            entity.Property(e => e.TaskType)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ThirdParty>(entity =>
        {
            entity.ToTable("ThirdParty");

            entity.Property(e => e.ThirdPartyId)
                .ValueGeneratedNever()
                .HasColumnName("ThirdParty_Id");
            entity.Property(e => e.Contact)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ThirdPartyContact>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ThirdPartyContact");

            entity.Property(e => e.BuildingId).HasColumnName("Building_Id");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("End_Date");
            entity.Property(e => e.StaffId).HasColumnName("Staff_Id");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("Start_Date");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
