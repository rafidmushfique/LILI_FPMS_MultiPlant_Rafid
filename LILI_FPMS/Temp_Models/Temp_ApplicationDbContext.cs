using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LILI_FPMS.Temp_Models
{
    public partial class Temp_ApplicationDbContext : DbContext
    {
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<TblBom> TblBom { get; set; }
        public virtual DbSet<TblBomdetail> TblBomdetail { get; set; }
        public virtual DbSet<TblBusinessSetupInfo> TblBusinessSetupInfo { get; set; }
        public virtual DbSet<TblCodingDetailLine> TblCodingDetailLine { get; set; }
        public virtual DbSet<TblCodingDetailMachine> TblCodingDetailMachine { get; set; }
        public virtual DbSet<TblCodingDetailShift> TblCodingDetailShift { get; set; }
        public virtual DbSet<TblEmployee> TblEmployee { get; set; }
        public virtual DbSet<TblEmployeeEducationalDetail> TblEmployeeEducationalDetail { get; set; }
        public virtual DbSet<TblEmployeeExpert> TblEmployeeExpert { get; set; }
        public virtual DbSet<TblFgtn> TblFgtn { get; set; }
        public virtual DbSet<TblFgtndetails> TblFgtndetails { get; set; }
        public virtual DbSet<TblFgtransferLocation> TblFgtransferLocation { get; set; }
        public virtual DbSet<TblFloorStock> TblFloorStock { get; set; }
        public virtual DbSet<TblLineSetup> TblLineSetup { get; set; }
        public virtual DbSet<TblMachineName> TblMachineName { get; set; }
        public virtual DbSet<TblMachineSetup> TblMachineSetup { get; set; }
        public virtual DbSet<TblMaintenanceInformation> TblMaintenanceInformation { get; set; }
        public virtual DbSet<TblManufacturingBreakDownCause> TblManufacturingBreakDownCause { get; set; }
        public virtual DbSet<TblManufacturingLine> TblManufacturingLine { get; set; }
        public virtual DbSet<TblManufacturingMachine> TblManufacturingMachine { get; set; }
        public virtual DbSet<TblManufacturingManPower> TblManufacturingManPower { get; set; }
        public virtual DbSet<TblManufacturingShift> TblManufacturingShift { get; set; }
        public virtual DbSet<TblMaterial> TblMaterial { get; set; }
        public virtual DbSet<TblMenuList> TblMenuList { get; set; }
        public virtual DbSet<TblMonthlyPlanning> TblMonthlyPlanning { get; set; }
        public virtual DbSet<TblMonthlyPlanningDetail> TblMonthlyPlanningDetail { get; set; }
        public virtual DbSet<TblOpeningStock> TblOpeningStock { get; set; }
        public virtual DbSet<TblPackingDetailLine> TblPackingDetailLine { get; set; }
        public virtual DbSet<TblPackingDetailMachine> TblPackingDetailMachine { get; set; }
        public virtual DbSet<TblPackingDetailShift> TblPackingDetailShift { get; set; }
        public virtual DbSet<TblPackingManPower> TblPackingManPower { get; set; }
        public virtual DbSet<TblProductionManPower> TblProductionManPower { get; set; }
        public virtual DbSet<TblProductionProcess> TblProductionProcess { get; set; }
        public virtual DbSet<TblProductionProcessDetail> TblProductionProcessDetail { get; set; }
        public virtual DbSet<TblProductionProcessDetailGrn> TblProductionProcessDetailGrn { get; set; }
        public virtual DbSet<TblProductWiseSectionSetup> TblProductWiseSectionSetup { get; set; }
        public virtual DbSet<TblProductWiseSectionSetupDetail> TblProductWiseSectionSetupDetail { get; set; }
        public virtual DbSet<TblQc> TblQc { get; set; }
        public virtual DbSet<TblQcdetails> TblQcdetails { get; set; }
        public virtual DbSet<TblQcparameter> TblQcparameter { get; set; }
        public virtual DbSet<TblQcparameterType> TblQcparameterType { get; set; }
        public virtual DbSet<TblRequisition> TblRequisition { get; set; }
        public virtual DbSet<TblRequisitionApprovalStatus> TblRequisitionApprovalStatus { get; set; }
        public virtual DbSet<TblRequisitionDetail> TblRequisitionDetail { get; set; }
        public virtual DbSet<TblReturn> TblReturn { get; set; }
        public virtual DbSet<TblReturnDetails> TblReturnDetails { get; set; }
        public virtual DbSet<TblRmrate> TblRmrate { get; set; }
        public virtual DbSet<TblSection> TblSection { get; set; }
        public virtual DbSet<TblShiftSetup> TblShiftSetup { get; set; }
        public virtual DbSet<TblStandardManHourSetup> TblStandardManHourSetup { get; set; }
        public virtual DbSet<TblUserWiseBusinessAndPlantCode> TblUserWiseBusinessAndPlantCode { get; set; }
        public virtual DbSet<TblVisibility> TblVisibility { get; set; }

        // Unable to generate entity type for table 'dbo.tblfloorstock_20230710'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.tblFloorStock_Backup'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.tblOpeningStock_20221201'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.FactoryRMPMStockWithValue'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.AspNetUsers'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.tblSubBusiness'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.AspNetRoleClaims'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.AspNetRoles'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.AspNetUserClaims'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.AspNetUserLogins'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.AspNetUserRoles'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.AspNetUsers_Post'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.AspNetUserTokens'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.MenuMaster'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.tblCountry'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.tblEmpGrade'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.tblFloorStock_20230625'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.tblExpertArea'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.tblMenu'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.tblMachineName_20230626'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server= 192.168.100.60;Database=dbToiletriesProduction_dev;user id=sa;password=dataport;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductCode);

                entity.Property(e => e.ProductCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.BrandCode)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.BusiSumGroupCode)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Business)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Carton).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.DiscountStatus)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.DistDiscount).HasColumnType("numeric(18, 4)");

                entity.Property(e => e.EffectedDate).HasColumnType("datetime");

                entity.Property(e => e.GroupCode)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Mrp)
                    .HasColumnName("MRP")
                    .HasColumnType("numeric(18, 4)");

                entity.Property(e => e.PackSize)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Pccc)
                    .IsRequired()
                    .HasColumnName("PCCC")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.PrincipalCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProductCategory)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName1)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.RatePerCarton).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.ReportGroupCode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Show)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Smscode)
                    .IsRequired()
                    .HasColumnName("SMSCODE")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Smsorder)
                    .IsRequired()
                    .HasColumnName("SMSOrder")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.StorageType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SubBusinessCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UnitPrice).HasColumnType("numeric(18, 4)");

                entity.Property(e => e.Vat)
                    .HasColumnName("VAT")
                    .HasColumnType("numeric(18, 4)");
            });

            modelBuilder.Entity<TblBom>(entity =>
            {
                entity.ToTable("tblBOM");

                entity.Property(e => e.Bomtext)
                    .HasColumnName("BOMText")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Bomtype)
                    .HasColumnName("BOMType")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BusinessCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Edate)
                    .HasColumnName("EDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Euser)
                    .HasColumnName("EUser")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Idate)
                    .HasColumnName("IDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Iuser)
                    .IsRequired()
                    .HasColumnName("IUser")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProductCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ValidFrom).HasColumnType("datetime");

                entity.Property(e => e.ValidTo).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblBomdetail>(entity =>
            {
                entity.ToTable("tblBOMDetail");

                entity.HasIndex(e => new { e.Bomid, e.MaterialCode })
                    .HasName("IX_tblBOMDetail")
                    .IsUnique();

                entity.Property(e => e.Bomid).HasColumnName("BOMId");

                entity.Property(e => e.CostPerProductUnit).HasColumnType("decimal(24, 8)");

                entity.Property(e => e.LossQuantity).HasColumnType("decimal(24, 8)");

                entity.Property(e => e.MaterialCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PerBatchQuantityExcludingLoss).HasColumnType("decimal(24, 8)");

                entity.Property(e => e.QuantityPerBatch).HasColumnType("decimal(24, 8)");
            });

            modelBuilder.Entity<TblBusinessSetupInfo>(entity =>
            {
                entity.ToTable("tblBusinessSetupInfo");

                entity.Property(e => e.Address)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.BusinessCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BusinessName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Edate)
                    .HasColumnName("EDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Euser)
                    .HasColumnName("EUser")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Idate)
                    .HasColumnName("IDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Iuser)
                    .IsRequired()
                    .HasColumnName("IUser")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblCodingDetailLine>(entity =>
            {
                entity.ToTable("tblCodingDetailLine");

                entity.Property(e => e.LineCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Production)
                    .WithMany(p => p.TblCodingDetailLine)
                    .HasForeignKey(d => d.ProductionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCodingDetailLine_tblProductionProcess");
            });

            modelBuilder.Entity<TblCodingDetailMachine>(entity =>
            {
                entity.ToTable("tblCodingDetailMachine");

                entity.Property(e => e.CodeMachineManHour)
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CodeMachineNoOfWorker)
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MachineCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MachineHour)
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Production)
                    .WithMany(p => p.TblCodingDetailMachine)
                    .HasForeignKey(d => d.ProductionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCodingDetailMachine_tblProductionProcess");
            });

            modelBuilder.Entity<TblCodingDetailShift>(entity =>
            {
                entity.ToTable("tblCodingDetailShift");

                entity.Property(e => e.BreakeDownTime)
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MachineCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShiftCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.BreakeDownCause)
                    .WithMany(p => p.TblCodingDetailShift)
                    .HasForeignKey(d => d.BreakeDownCauseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCodingDetailShift_tblCodingDetailBreakDownCause");

                entity.HasOne(d => d.Production)
                    .WithMany(p => p.TblCodingDetailShift)
                    .HasForeignKey(d => d.ProductionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCodingDetailShift_tblProductionProcess");
            });

            modelBuilder.Entity<TblEmployee>(entity =>
            {
                entity.ToTable("tblEmployee");

                entity.HasIndex(e => e.EmpId)
                    .HasName("IX_tblEmployee")
                    .IsUnique();

                entity.Property(e => e.Department)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Designation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.JoiningDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblEmployeeEducationalDetail>(entity =>
            {
                entity.ToTable("tblEmployeeEducationalDetail");

                entity.Property(e => e.Comment)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Result)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TblEmployeeEducationalDetail)
                    .HasPrincipalKey(p => p.EmpId)
                    .HasForeignKey(d => d.EmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmployeeEducationalDetails_tblEmployee");
            });

            modelBuilder.Entity<TblEmployeeExpert>(entity =>
            {
                entity.ToTable("tblEmployeeExpert");

                entity.Property(e => e.EmpId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TblEmployeeExpert)
                    .HasPrincipalKey(p => p.EmpId)
                    .HasForeignKey(d => d.EmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmployeeExpert_tblEmployee");
            });

            modelBuilder.Entity<TblFgtn>(entity =>
            {
                entity.ToTable("tblFGTN");

                entity.HasIndex(e => e.Fgtnno)
                    .HasName("IX_tblFGTN")
                    .IsUnique();

                entity.Property(e => e.BusinessCode)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Comments)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Edate)
                    .HasColumnName("EDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Euser)
                    .HasColumnName("EUser")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fgtndate)
                    .HasColumnName("FGTNDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fgtnno)
                    .IsRequired()
                    .HasColumnName("FGTNNo")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Idate)
                    .HasColumnName("IDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Iuser)
                    .IsRequired()
                    .HasColumnName("IUser")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LocationCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblFgtndetails>(entity =>
            {
                entity.ToTable("tblFGTNDetails");

                entity.Property(e => e.Comments)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Fgtnno)
                    .IsRequired()
                    .HasColumnName("FGTNNo")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Fgtnqty)
                    .HasColumnName("FGTNQty")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.ProcessNo)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ProductCode)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Qcno)
                    .IsRequired()
                    .HasColumnName("QCNo")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.QcpassQty)
                    .HasColumnName("QCPassQty")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.RequisitionNo)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.FgtnnoNavigation)
                    .WithMany(p => p.TblFgtndetails)
                    .HasPrincipalKey(p => p.Fgtnno)
                    .HasForeignKey(d => d.Fgtnno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblFGTNDetails_tblFGTNDetails");
            });

            modelBuilder.Entity<TblFgtransferLocation>(entity =>
            {
                entity.ToTable("tblFGTransferLocation");

                entity.Property(e => e.Comments)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.LocationCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LocationName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblFloorStock>(entity =>
            {
                entity.ToTable("tblFloorStock");

                entity.Property(e => e.AvailableStock)
                    .HasColumnType("numeric(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ConsumeStock)
                    .HasColumnType("numeric(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Grnno)
                    .IsRequired()
                    .HasColumnName("GRNNo")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IssueStock)
                    .HasColumnType("numeric(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MaterialCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RequisitionNo)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ReturnStock)
                    .HasColumnType("numeric(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.StockDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblLineSetup>(entity =>
            {
                entity.ToTable("tblLineSetup");

                entity.Property(e => e.Comments)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Edate)
                    .HasColumnName("EDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Euser)
                    .HasColumnName("EUser")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Idate)
                    .HasColumnName("IDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Iuser)
                    .IsRequired()
                    .HasColumnName("IUser")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LineCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LineName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblMachineName>(entity =>
            {
                entity.ToTable("tblMachineName");

                entity.HasIndex(e => e.MachineCode)
                    .HasName("IX_tblMachineName")
                    .IsUnique();

                entity.HasIndex(e => e.MachineName)
                    .HasName("IX_tblMachineName_1")
                    .IsUnique();

                entity.Property(e => e.MachineCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MachineName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblMachineSetup>(entity =>
            {
                entity.ToTable("tblMachineSetup");

                entity.Property(e => e.Capacity)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CapacityPacking)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Comments)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Edate)
                    .HasColumnName("EDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Euser)
                    .HasColumnName("EUser")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Idate)
                    .HasColumnName("IDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Iuser)
                    .IsRequired()
                    .HasColumnName("IUser")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MachineCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MachineName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Speed)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SpeedPacking)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblMaintenanceInformation>(entity =>
            {
                entity.ToTable("tblMaintenanceInformation");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Edate).HasColumnType("datetime");

                entity.Property(e => e.Euser)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Idate).HasColumnType("datetime");

                entity.Property(e => e.Iuser)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MachineCode)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MaintenanceCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaintenanceDate).HasColumnType("datetime");

                entity.Property(e => e.MaintenanceHour).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.MaintenanceName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MaintenanceType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblManufacturingBreakDownCause>(entity =>
            {
                entity.HasKey(e => e.BreakeDownCauseId);

                entity.ToTable("tblManufacturingBreakDownCause");

                entity.Property(e => e.BreakeDownCause)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblManufacturingLine>(entity =>
            {
                entity.ToTable("tblManufacturingLine");

                entity.Property(e => e.LineCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SectionCode).HasMaxLength(50);

                entity.HasOne(d => d.Production)
                    .WithMany(p => p.TblManufacturingLine)
                    .HasForeignKey(d => d.ProductionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblManufacturingLine_tblProductionProcess");
            });

            modelBuilder.Entity<TblManufacturingMachine>(entity =>
            {
                entity.ToTable("tblManufacturingMachine");

                entity.Property(e => e.MachineCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MachineHour).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.ManufacMachineManHour)
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ManufacMachineNoOfWorker)
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SectionCode).HasMaxLength(50);

                entity.HasOne(d => d.Production)
                    .WithMany(p => p.TblManufacturingMachine)
                    .HasForeignKey(d => d.ProductionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblManufacturingMachine_tblProductionProcess");
            });

            modelBuilder.Entity<TblManufacturingManPower>(entity =>
            {
                entity.ToTable("tblManufacturingManPower");

                entity.Property(e => e.SectionCode).HasMaxLength(50);

                entity.Property(e => e.StaffId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Production)
                    .WithMany(p => p.TblManufacturingManPower)
                    .HasForeignKey(d => d.ProductionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblManufacturingManPower_tblProductionProcess");
            });

            modelBuilder.Entity<TblManufacturingShift>(entity =>
            {
                entity.ToTable("tblManufacturingShift");

                entity.Property(e => e.BreakeDownTime)
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MachineCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SectionCode).HasMaxLength(50);

                entity.Property(e => e.ShiftCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.BreakeDownCause)
                    .WithMany(p => p.TblManufacturingShift)
                    .HasForeignKey(d => d.BreakeDownCauseId)
                    .HasConstraintName("FK_tblManufacturingShift_tblManufacturingBreakDownCause");

                entity.HasOne(d => d.Production)
                    .WithMany(p => p.TblManufacturingShift)
                    .HasForeignKey(d => d.ProductionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblManufacturingShift_tblProductionProcess");
            });

            modelBuilder.Entity<TblMaterial>(entity =>
            {
                entity.ToTable("tblMaterial");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AlternativeUoM)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AuoMconversionValue)
                    .HasColumnName("AUoMConversionValue")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.BaseUnit)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BusinessCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ConversionValue).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Discontinue)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Edate)
                    .HasColumnName("EDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.EditIpaddress)
                    .HasColumnName("EditIPAddress")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Euser)
                    .HasColumnName("EUser")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Idate)
                    .HasColumnName("IDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.InsertIpaddress)
                    .HasColumnName("InsertIPAddress")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Iuser)
                    .HasColumnName("IUser")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MaterialCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MaterialName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SkuoM)
                    .IsRequired()
                    .HasColumnName("SKUoM")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SubBusinessCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblMenuList>(entity =>
            {
                entity.ToTable("tblMenuList");

                entity.Property(e => e.ActionName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ControllerName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.MenuName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModuleName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PageUrl)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ParentMenuName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblMonthlyPlanning>(entity =>
            {
                entity.ToTable("tblMonthlyPlanning");

                entity.HasIndex(e => e.PlanningNo)
                    .HasName("IX_tblMonthlyPlanning")
                    .IsUnique();

                entity.Property(e => e.Comments)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Edate)
                    .HasColumnName("EDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Euser)
                    .HasColumnName("EUser")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Idate)
                    .HasColumnName("IDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Iuser)
                    .IsRequired()
                    .HasColumnName("IUser")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Month)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PlanningNo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Year).HasDefaultValueSql("((202209))");
            });

            modelBuilder.Entity<TblMonthlyPlanningDetail>(entity =>
            {
                entity.ToTable("tblMonthlyPlanningDetail");

                entity.Property(e => e.ActualForecast)
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Closing)
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Comments)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Fgcode)
                    .IsRequired()
                    .HasColumnName("FGCode")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.OpeningStock)
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PlanQty)
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PlanningNo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ProductionRequirement)
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ReviewedForecast)
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.RevisedPlanQty)
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.PlanningNoNavigation)
                    .WithMany(p => p.TblMonthlyPlanningDetail)
                    .HasPrincipalKey(p => p.PlanningNo)
                    .HasForeignKey(d => d.PlanningNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblMonthlyPlanningDetail_tblMonthlyPlanning");
            });

            modelBuilder.Entity<TblOpeningStock>(entity =>
            {
                entity.ToTable("tblOpeningStock");

                entity.Property(e => e.ClosingBalance)
                    .HasColumnType("numeric(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Consumption)
                    .HasColumnType("numeric(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MaterialCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Openning)
                    .HasColumnType("numeric(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PlantId).HasDefaultValueSql("((0))");

                entity.Property(e => e.Receive)
                    .HasColumnType("numeric(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Returned)
                    .HasColumnType("numeric(18, 4)")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TblPackingDetailLine>(entity =>
            {
                entity.ToTable("tblPackingDetailLine");

                entity.Property(e => e.LineCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Production)
                    .WithMany(p => p.TblPackingDetailLine)
                    .HasForeignKey(d => d.ProductionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPackingDetailLine_tblProductionProcess");
            });

            modelBuilder.Entity<TblPackingDetailMachine>(entity =>
            {
                entity.ToTable("tblPackingDetailMachine");

                entity.Property(e => e.MachineCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MachineHour).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.PackMachineManHour)
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PackMachineNoOfWorker)
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Production)
                    .WithMany(p => p.TblPackingDetailMachine)
                    .HasForeignKey(d => d.ProductionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPackingDetailMachine_tblProductionProcess");
            });

            modelBuilder.Entity<TblPackingDetailShift>(entity =>
            {
                entity.ToTable("tblPackingDetailShift");

                entity.Property(e => e.BreakeDownTime)
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MachineCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShiftCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.BreakeDownCause)
                    .WithMany(p => p.TblPackingDetailShift)
                    .HasForeignKey(d => d.BreakeDownCauseId)
                    .HasConstraintName("FK_tblPackingDetailShift_tblManufacturingBreakDownCause");

                entity.HasOne(d => d.Production)
                    .WithMany(p => p.TblPackingDetailShift)
                    .HasForeignKey(d => d.ProductionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPackingDetailShift_tblProductionProcess");
            });

            modelBuilder.Entity<TblPackingManPower>(entity =>
            {
                entity.ToTable("tblPackingManPower");

                entity.Property(e => e.StaffId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Production)
                    .WithMany(p => p.TblPackingManPower)
                    .HasForeignKey(d => d.ProductionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPackingManPower_tblProductionProcess");
            });

            modelBuilder.Entity<TblProductionManPower>(entity =>
            {
                entity.ToTable("tblProductionManPower");

                entity.Property(e => e.CostUnit)
                    .HasColumnName("Cost Unit")
                    .HasMaxLength(255);

                entity.Property(e => e.Designation).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.StaffId)
                    .HasColumnName("Staff_Id")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<TblProductionProcess>(entity =>
            {
                entity.ToTable("tblProductionProcess");

                entity.HasIndex(e => e.ProcessNo)
                    .HasName("IX_tblProductionProcess")
                    .IsUnique();

                entity.Property(e => e.BatchNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BusinessCode)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CodeBatchEndTime).HasColumnType("datetime");

                entity.Property(e => e.CodeBatchStartTime).HasColumnType("datetime");

                entity.Property(e => e.CodeCommonManHour).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.CodeCommonNoOfWorker).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.CodeLineCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CodeMachineCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CodeMachineHour).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.CodeMachineManHour).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.CodeMachineNoOfWorker).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.CodeManHour).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.CodeNoOfWorker).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.CodeShiftBreakDownChangeTime).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.CodeShiftCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CodingQty).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Comments)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Edate)
                    .HasColumnName("EDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Euser)
                    .HasColumnName("EUser")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Idate)
                    .HasColumnName("IDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.IssueNo)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Iuser)
                    .IsRequired()
                    .HasColumnName("IUser")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LumpQty)
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ManufacBatchEndTime).HasColumnType("datetime");

                entity.Property(e => e.ManufacBatchStartTime).HasColumnType("datetime");

                entity.Property(e => e.ManufacCommonManHour).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.ManufacCommonNoOfWorker).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.ManufacLineCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ManufacMachineCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ManufacMachineHour).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.ManufacMachineManHour)
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ManufacMachineNoOfWorker)
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ManufacManHour).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.ManufacNoOfWorker).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.ManufacShiftBreakDownChangeTime).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.ManufacShiftCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NumberOfBatch)
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PackBatchEndTime).HasColumnType("datetime");

                entity.Property(e => e.PackBatchStartTime).HasColumnType("datetime");

                entity.Property(e => e.PackCommonManHour).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.PackCommonNoOfWorker).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.PackLineCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PackMachineCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PackMachineHour).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.PackMachineManHour)
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PackMachineNoOfWorker)
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PackManHour).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.PackNoOfWorker).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.PackShiftBreakDownChangeTime).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.PackShiftCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PackingQty).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.ProcessDate).HasColumnType("datetime");

                entity.Property(e => e.ProcessNo)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ProductionQty).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.ProductionQtyBeforeConversion).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.ProductionQtyConversionFactor).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.QcreferenceSampleQty)
                    .HasColumnName("QCReferenceSampleQty")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.RequisitionNo)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.SectionCode).HasMaxLength(50);

                entity.Property(e => e.Sfgcode)
                    .HasColumnName("SFGCode")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.SfgproductionQty)
                    .HasColumnName("SFGProductionQty")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TblProductionProcessDetail>(entity =>
            {
                entity.ToTable("tblProductionProcessDetail");

                entity.Property(e => e.CurrentUseQty).HasColumnType("numeric(18, 4)");

                entity.Property(e => e.FloorStock).HasColumnType("numeric(18, 4)");

                entity.Property(e => e.IssuedQty).HasColumnType("numeric(18, 4)");

                entity.Property(e => e.MaterialCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PreviousUsedQty).HasColumnType("numeric(18, 4)");

                entity.Property(e => e.ProcessLoss).HasColumnType("numeric(18, 4)");

                entity.Property(e => e.ProcessNo)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ReqQuantity).HasColumnType("numeric(18, 4)");

                entity.Property(e => e.StdConsumptionQty)
                    .HasColumnType("numeric(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalConsumption).HasColumnType("numeric(18, 4)");

                entity.Property(e => e.Wastage).HasColumnType("numeric(18, 4)");

                entity.HasOne(d => d.ProcessNoNavigation)
                    .WithMany(p => p.TblProductionProcessDetail)
                    .HasPrincipalKey(p => p.ProcessNo)
                    .HasForeignKey(d => d.ProcessNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblProductionProcessDetail_tblProductionProcess");
            });

            modelBuilder.Entity<TblProductionProcessDetailGrn>(entity =>
            {
                entity.ToTable("tblProductionProcessDetailGRN");

                entity.Property(e => e.ConsumeStock)
                    .HasColumnType("numeric(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Grnno)
                    .IsRequired()
                    .HasColumnName("GRNNo")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MaterialCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProcessNo)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblProductWiseSectionSetup>(entity =>
            {
                entity.Property(e => e.Edate)
                    .HasColumnName("EDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Euser)
                    .HasColumnName("EUser")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Idate)
                    .HasColumnName("IDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Iuser)
                    .IsRequired()
                    .HasColumnName("IUser")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblProductWiseSectionSetupDetail>(entity =>
            {
                entity.Property(e => e.Comments)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IsQcrequired)
                    .HasColumnName("IsQCrequired")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Section)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Sequence)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.ProductSectionSetup)
                    .WithMany(p => p.TblProductWiseSectionSetupDetail)
                    .HasForeignKey(d => d.ProductSectionSetupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TblProductWiseSectionSetupDetail_TblProductWiseSectionSetupDetail");
            });

            modelBuilder.Entity<TblQc>(entity =>
            {
                entity.ToTable("tblQC");

                entity.HasIndex(e => e.Qcno)
                    .HasName("IX_tblQC")
                    .IsUnique();

                entity.Property(e => e.BusinessCode)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Comments)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Edate)
                    .HasColumnName("EDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Euser)
                    .HasColumnName("EUser")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FgqcqtyBeforeConversion)
                    .HasColumnName("FGQCQtyBeforeConversion")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FgqcqtyConversionFactor)
                    .HasColumnName("FGQCQtyConversionFactor")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Idate)
                    .HasColumnName("IDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsSendToFloorStockFg).HasColumnName("IsSendToFloorStockFG");

                entity.Property(e => e.IsSendToFloorStockSfg).HasColumnName("IsSendToFloorStockSFG");

                entity.Property(e => e.Iuser)
                    .IsRequired()
                    .HasColumnName("IUser")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProcessNo)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Qcdate)
                    .HasColumnName("QCDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.QcholdQty)
                    .HasColumnName("QCHoldQty")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Qcno)
                    .IsRequired()
                    .HasColumnName("QCNo")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.QcpassQty)
                    .HasColumnName("QCPassQty")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Qcqty)
                    .HasColumnName("QCQty")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.QcquarantineQty)
                    .HasColumnName("QCQuarantineQty")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.QcreferenceSampleQty)
                    .HasColumnName("QCReferenceSampleQty")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.QcrejectQty)
                    .HasColumnName("QCRejectQty")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.RequisitionNo)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.SfgqcpassQty)
                    .HasColumnName("SFGQCPassQty")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Sfgqcqty)
                    .HasColumnName("SFGQCQty")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SfgqcrejectQty)
                    .HasColumnName("SFGQCRejectQty")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TblQcdetails>(entity =>
            {
                entity.ToTable("tblQCDetails");

                entity.Property(e => e.Comments)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Qcno)
                    .IsRequired()
                    .HasColumnName("QCNo")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.QcparameterActualValue)
                    .IsRequired()
                    .HasColumnName("QCParameterActualValue")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.QcparameterCode)
                    .IsRequired()
                    .HasColumnName("QCParameterCode")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.QcnoNavigation)
                    .WithMany(p => p.TblQcdetails)
                    .HasPrincipalKey(p => p.Qcno)
                    .HasForeignKey(d => d.Qcno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblQCDetails_tblQC");
            });

            modelBuilder.Entity<TblQcparameter>(entity =>
            {
                entity.ToTable("tblQCParameter");

                entity.Property(e => e.Comments)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ProductCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.QcparameterCode)
                    .IsRequired()
                    .HasColumnName("QCParameterCode")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.QcparameterName)
                    .IsRequired()
                    .HasColumnName("QCParameterName")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.QcparameterStandardValue)
                    .IsRequired()
                    .HasColumnName("QCParameterStandardValue")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TypeCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblQcparameterType>(entity =>
            {
                entity.ToTable("tblQCParameterType");

                entity.Property(e => e.TypeCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblRequisition>(entity =>
            {
                entity.ToTable("tblRequisition");

                entity.HasIndex(e => e.RequisitionNo)
                    .HasName("IX_tblRequisition")
                    .IsUnique();

                entity.Property(e => e.BatchNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Bomid)
                    .HasColumnName("BOMId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BusinessCode)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Comments)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Edate)
                    .HasColumnName("EDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Euser)
                    .HasColumnName("EUser")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExtOfRequisitionNo)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Idate)
                    .HasColumnName("IDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.IssueStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Iuser)
                    .IsRequired()
                    .HasColumnName("IUser")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumberOfBatch).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.ProductCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RequisitionDate).HasColumnType("datetime");

                entity.Property(e => e.RequisitionNo)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblRequisitionApprovalStatus>(entity =>
            {
                entity.ToTable("tblRequisitionApprovalStatus");

                entity.Property(e => e.ApprovalStatus)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Approver)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RequisitionNo)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.RequisitionStatusDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblRequisitionDetail>(entity =>
            {
                entity.ToTable("tblRequisitionDetail");

                entity.Property(e => e.AvailableStock)
                    .HasColumnType("numeric(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FloorStock)
                    .HasColumnType("numeric(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MaterialCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RequiredQty)
                    .HasColumnType("numeric(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.RequisitionNo)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.StandardRecipeQty)
                    .HasColumnType("numeric(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.RequisitionNoNavigation)
                    .WithMany(p => p.TblRequisitionDetail)
                    .HasPrincipalKey(p => p.RequisitionNo)
                    .HasForeignKey(d => d.RequisitionNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRequisitionDetail_tblRequisition");
            });

            modelBuilder.Entity<TblReturn>(entity =>
            {
                entity.ToTable("tblReturn");

                entity.HasIndex(e => e.ReturnNo)
                    .HasName("IX_tblReturn")
                    .IsUnique();

                entity.Property(e => e.BusinessCode)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Comments)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Edate)
                    .HasColumnName("EDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Euser)
                    .HasColumnName("EUser")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Idate)
                    .HasColumnName("IDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.IssueNo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Iuser)
                    .IsRequired()
                    .HasColumnName("IUser")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RequisitionNo)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ReturnDate).HasColumnType("datetime");

                entity.Property(e => e.ReturnNo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.RequisitionNoNavigation)
                    .WithMany(p => p.TblReturn)
                    .HasPrincipalKey(p => p.RequisitionNo)
                    .HasForeignKey(d => d.RequisitionNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblReturn_tblRequisition");
            });

            modelBuilder.Entity<TblReturnDetails>(entity =>
            {
                entity.ToTable("tblReturnDetails");

                entity.Property(e => e.Grnno)
                    .HasColumnName("GRNNo")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IssuedQty).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.MaterialCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ReturnNo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ReturnQty).HasColumnType("numeric(18, 2)");

                entity.HasOne(d => d.ReturnNoNavigation)
                    .WithMany(p => p.TblReturnDetails)
                    .HasPrincipalKey(p => p.ReturnNo)
                    .HasForeignKey(d => d.ReturnNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblReturnDetails_tblReturn");
            });

            modelBuilder.Entity<TblRmrate>(entity =>
            {
                entity.ToTable("tblRMRate");

                entity.Property(e => e.ClosingCost).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Edate)
                    .HasColumnName("EDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Euser)
                    .HasColumnName("EUser")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Idate)
                    .HasColumnName("IDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Iuser)
                    .IsRequired()
                    .HasColumnName("IUser")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Period)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.PlantCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblSection>(entity =>
            {
                entity.ToTable("tblSection");

                entity.Property(e => e.SectionCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SectionName).HasMaxLength(50);
            });

            modelBuilder.Entity<TblShiftSetup>(entity =>
            {
                entity.ToTable("tblShiftSetup");

                entity.Property(e => e.Comments)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Edate)
                    .HasColumnName("EDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Euser)
                    .HasColumnName("EUser")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Idate)
                    .HasColumnName("IDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Iuser)
                    .IsRequired()
                    .HasColumnName("IUser")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PlannedDownChangeTime)
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ProductiveShiftHour)
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ShiftCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ShiftEndTime).HasColumnType("datetime");

                entity.Property(e => e.ShiftName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShiftStartTime).HasColumnType("datetime");

                entity.Property(e => e.StandardShiftHour)
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TblStandardManHourSetup>(entity =>
            {
                entity.ToTable("tblStandardManHourSetup");

                entity.HasIndex(e => e.ProductCode)
                    .HasName("IX_tblStandardManHourSetup")
                    .IsUnique();

                entity.Property(e => e.Comments)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Edate)
                    .HasColumnName("EDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Euser)
                    .HasColumnName("EUser")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Idate)
                    .HasColumnName("IDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Iuser)
                    .IsRequired()
                    .HasColumnName("IUser")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StdHrPerBatchPm)
                    .HasColumnName("StdHrPerBatchPM")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.StdHrPerBatchRm)
                    .HasColumnName("StdHrPerBatchRM")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.StdManPowerPerBatchPm)
                    .HasColumnName("StdManPowerPerBatchPM")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.StdManPowerPerBatchRm)
                    .HasColumnName("StdManPowerPerBatchRM")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.StdManPowerPerUnitPm).HasColumnName("StdManPowerPerUnitPM");

                entity.Property(e => e.StdManPowerPerUnitRm).HasColumnName("StdManPowerPerUnitRM");
            });

            modelBuilder.Entity<TblUserWiseBusinessAndPlantCode>(entity =>
            {
                entity.ToTable("tblUserWiseBusinessAndPlantCode");

                entity.Property(e => e.BusinessCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);
            });

            modelBuilder.Entity<TblVisibility>(entity =>
            {
                entity.ToTable("tblVisibility");

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
        }
    }
}
